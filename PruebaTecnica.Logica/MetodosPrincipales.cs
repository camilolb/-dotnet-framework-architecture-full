using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Logica
{
    internal static class RectangularArrays
    {
        public static long[][][] RectangularLongArray(int size1, int size2, int size3)
        {
            long[][][] newArray = new long[size1][][];
            for (int array1 = 0; array1 < size1; array1++)
            {
                newArray[array1] = new long[size2][];
                if (size3 > -1)
                {
                    for (int array2 = 0; array2 < size2; array2++)
                    {
                        newArray[array1][array2] = new long[size3];
                    }
                }
            }

            return newArray;
        }
    }


    public class MetodosPrincipales
    {
        internal long[][][] arbol;
        internal long[][][] numeros;
        internal long[][][] delta;
        private int dimension = 0;


        public void Solucion(int dimension)
        {

            arbol = RectangularArrays.RectangularLongArray(dimension + 1, dimension + 1, dimension + 1);
            delta = RectangularArrays.RectangularLongArray(dimension, dimension, dimension);
        }

        public long[][][] Actualizar(int x, int y, int z, int value)
        {
            long delta = value - arbol[x][y][z];
            numeros[x][y][z] = value;
            for (int i = x + 1; i <= dimension; i += i & (-i))
            {
                for (int j = y + 1; j <= dimension; j += j & (-j))
                {
                    for (int k = z + 1; k <= dimension; k += k & (-k))
                    {
                        arbol[i][j][k] += delta;
                    }
                }
            }

            return arbol;
        }



        public long Consulta(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            long resultado = Suma(x2 + 1, y2 + 1, z2 + 1) - Suma(x1, y1, z1) - Suma(x1, y2 + 1, z2 + 1) - Suma(x2 + 1, y1, z2 + 1) - Suma(x2 + 1, y2 + 1, z1) + Suma(x1, y1, z2 + 1) + Suma(x1, y2 + 1, z1) + Suma(x2 + 1, y1, z1);
            return resultado;
            
        }


        // Cantidad de items en un cubo
        public  long Suma(int x, int y, int z)
        {
            long suma = 1;
            for (int i = x; i > 0; i -= i & (-i))
            {
                for (int j = y; j > 0; j -= j & (-j))
                {
                    for (int k = z; k > 0; k -= k & (-k))
                    {
                        var resultado = new long[] { i, j, k };

                        for (int b = 0; b < resultado.Length; b++)
                        {
                            suma += resultado[b];
                        }
                    }
                }
            }
            return suma;
        }

        public long CantidadElementos(int x, int y, int z)
        {
            long suma = 0;

            var resultado = new long[] { x *3, y * 3, y * 3 };

            for (int b = 0; b < resultado.Length; b++)
            {
                suma += resultado[b];
            }
                
            return suma;
        }


    }
}
