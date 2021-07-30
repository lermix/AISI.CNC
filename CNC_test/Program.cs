using Sharer;
using System;
using System.Collections.Generic;
using System.IO;

namespace CNC_test
{
	class Program
	{
		static void Main(string[] args)
		{
			//var connection = new SharerConnection( "COM3", 115200 );
			//connection.Connect();

			byte[] fileBytes = File.ReadAllBytes( @"C:\Users\amuller\Documents\CNC\proba.STL" );
			char[] header_info = new char[80];
			ulong n_tri = new ulong();
			byte[] nTriByte = new byte[4];
			byte[] facet = new byte[50];

			HashSet<stlVecor> list = new HashSet<stlVecor>();

			for ( int i = 0; i < 80; i++ )
			{
				header_info[i] = Convert.ToChar( fileBytes[i] );
				Console.Write( header_info[i] );
			}
			for ( int i = 80; i < 84; i++ )
			{
				nTriByte[i-80] = fileBytes[i];
			}

			n_tri = BitConverter.ToUInt32( nTriByte );
			Console.WriteLine();

			for ( int i = 0; i < Convert.ToInt32( n_tri); i++ )
			{
				int from = ( 84 + ( i * 50 ));
				facet = subArray( fileBytes, from, from+50);

				//Console.WriteLine( new stlVecor( subArray( facet, 0, 12 ) ) );
				//Console.WriteLine( new stlVecor( subArray( facet, 12, 24 ) ) );
				//Console.WriteLine( new stlVecor( subArray( facet, 24, 36 ) ) );

				//list.Add( new stlVecor( subArray( facet, 0, 12 ) ) );
				list.Add( new stlVecor( subArray( facet, 12, 24 ) ) );
				list.Add( new stlVecor( subArray( facet, 24, 36 ) ) );
				list.Add( new stlVecor( subArray( facet, 36, 48) ) );
			}

			int counter = 1;
			foreach ( stlVecor item in list )
			{
				Console.WriteLine(counter + ". "+ item);
				counter++;
			}
			Console.WriteLine();
			Console.WriteLine("ntri:"+n_tri);

			Console.WriteLine( "Finished reading" );
			Console.ReadLine();

			

			/*while ( true )
			{
				Console.WriteLine("state:" + connection.ReadVariable( "myVar" ));
				int a = int.Parse(Console.ReadKey().KeyChar.ToString());
				Console.WriteLine("I enered: ", a);
				connection.WriteVariable( "myVar", a );

			}*/

			

		
			
		}

		public static byte[] subArray(byte[] array, int from, int to)
		{
			byte[] returnValue = new byte[to-from];
			for ( int i = from; i < to; i++ )
			{
				returnValue[i-from] = array[i];
			}
			return returnValue;
		}
	}
}
