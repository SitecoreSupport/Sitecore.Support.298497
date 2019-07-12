namespace Sitecore.Support.XA.Foundation.Search.Services
{
    using Sitecore.Data.Items;
    using Sitecore.XA.Foundation.Multisite;
    using Sitecore.XA.Foundation.Search.Services;
    using Sitecore.XA.Foundation.SitecoreExtensions.Repositories;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Templates = Sitecore.XA.Foundation.Search.Templates;

    public class FacetService : Sitecore.XA.Foundation.Search.Services.FacetService
    {
        public FacetService(ISearchContextService searchContextService, IContentRepository contentRepository, ISharedSitesContext sharedSitesContext) : base(searchContextService, contentRepository, sharedSitesContext)
        {
        }

        protected override Item GetMatchingFacetDefinition(IEnumerable<Item> facets, string categoryName)
        {
            return facets.FirstOrDefault(i =>
            {
                #region Changed code
                string parameters = i[Templates.Facet.Fields.Parameters].ToLower(CultureInfo.InvariantCulture);
                categoryName = categoryName.ToLower(CultureInfo.InvariantCulture);
                return !string.IsNullOrWhiteSpace(parameters) && (categoryName.Contains(parameters) || categoryName.Contains(parameters.Replace(" ", "_"))); 
                #endregion
            });
        }
    }
}