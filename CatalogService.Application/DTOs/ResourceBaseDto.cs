using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.DTOs
{
    public abstract class ResourceBaseDto
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
