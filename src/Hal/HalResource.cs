using System;
using System.Collections.Generic;

namespace Hal {
    public class HalResource : HalNode, IHalResource {
		public string Rel { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public string Type { get; set; }

		public OrderedDictionary<string, HalNode> Contents { get; set; }

		public IHalResource Parent { get; internal set; }


    	public HalResource(string rel, Uri href)
			: this(rel, href.AsString())
    	{
    	}

		public HalResource(string rel, string href)
		{
    		Contents = new OrderedDictionary<string, HalNode>();

			Rel = rel;
			Href = href;
		}

        public override string Key {
            get {
                return Rel + (string.IsNullOrEmpty(Name) ? string.Empty : "[" + Name + "]");
            }
        }

        public HalLink ResourceLink {
			get {
				return new HalLink {
                    Href = Href,
                    Rel = Rel
                };
			}
		}
    }
}
