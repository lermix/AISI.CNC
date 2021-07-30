using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC_test
{
	class stlVecor
	{
		public float x { get; set; }
		public float y { get; set; }
		public float z { get; set; }

		

		public stlVecor(byte[] facet)
		{
			byte[] f1 = { facet[0], facet[1], facet[2], facet[3]  };
			byte[] f2 = { facet[4], facet[5], facet[6], facet[7] };
			byte[] f3 = { facet[8], facet[9], facet[10], facet[11] };

			x = BitConverter.ToSingle( f1,0 ) < 0.001 ? 0 : BitConverter.ToSingle( f1, 0 );
			y = BitConverter.ToSingle( f2,0 ) < 0.001 ? 0 : BitConverter.ToSingle( f2, 0 );
			z = BitConverter.ToSingle( f3,0 ) < 0.001 ? 0 : BitConverter.ToSingle( f3, 0 );
		}

		public static bool operator ==(stlVecor first, stlVecor second) => (first.x, first.y, first.z) == (second.x, second.y, second.z);

		public static bool operator !=(stlVecor first, stlVecor second) => (first.x, first.y, first.z) != (second.x, second.y, second.z);



		public override string ToString()
		{
			return "x: " + x + ", y: " + y + ", z: " + z;
		}

		public override bool Equals(object obj)
		{
			return obj is stlVecor vecor &&
					 x == vecor.x &&
					 y == vecor.y &&
					 z == vecor.z;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine( x, y, z );
		}

	}
}
