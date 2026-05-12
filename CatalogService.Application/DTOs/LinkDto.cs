using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.DTOs
{
    public class LinkDto
    {
        public string Href { get; set; } = string.Empty;
        public string Rel { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;

        public LinkDto(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}
