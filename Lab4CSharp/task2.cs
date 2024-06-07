// dotnet run --property:DefineConstants="RUN_VECTOR"
using System;

class VectorInt
{
    protected int[] IntArray;
    protected uint size;
    protected int codeError;
    protected static uint num_vec;

    public VectorInt()
    {
        this.size = 1;
        this.IntArray = new int[this.size];
        this.IntArray[0] = 0;
        num_vec++;
    }

    public VectorInt(uint size)
    {
        this.size = size;
        this.IntArray = new int[this.size];
        for (int i = 0; i < this.size; i++)
        {
            this.IntArray[i] = 0;
        }
        num_vec++;
    }

    public VectorInt(uint size, int initValue)
    {
        this.size = size;
        this.IntArray = new int[this.size];
        for (int i = 0; i < this.size; i++)
        {
            this.IntArray[i] = initValue;
        }
        num_vec++;
    }

    ~VectorInt()
    {
        Console.WriteLine("Destructor called");
        num_vec--;
    }

    public void InputElements()
    {
        for (int i = 0; i < this.size; i++)
        {
            Console.Write($"Element [{i}]: ");
            this.IntArray[i] = int.Parse(Console.ReadLine());
        }
    }

    public void PrintElements()
    {
        Console.WriteLine("Vector elements:");
        for (int i = 0; i < this.size; i++)
        {
            Console.Write($"{this.IntArray[i]} ");
        }
        Console.WriteLine();
    }

    public void AssignValue(int value)
    {
        for (int i = 0; i < this.size; i++)
        {
            this.IntArray[i] = value;
        }
    }

    public static uint CountVectors()
    {
        return num_vec;
    }

    public uint Size
    {
        get { return this.size; }
    }

    public int CodeError
    {
        get { return this.codeError; }
        set { this.codeError = value; }
    }

    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < this.size)
            {
                return this.IntArray[index];
            }
            else
            {
                this.codeError = -1;
                return 0;
            }
        }
        set
        {
            if (index >= 0 && index < this.size)
            {
                this.IntArray[index] = value;
            }
            else
            {
                this.codeError = -1;
            }
        }
    }

    public static VectorInt operator ++(VectorInt v)
    {
        for (int i = 0; i < v.size; i++)
        {
            v.IntArray[i]++;
        }
        return v;
    }

    public static VectorInt operator --(VectorInt v)
    {
        for (int i = 0; i < v.size; i++)
        {
            v.IntArray[i]--;
        }
        return v;
    }

    public static bool operator true(VectorInt v)
    {
        if (v.size != 0)
        {
            for (int i = 0; i < v.size; i++)
            {
                if (v.IntArray[i] != 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool operator false(VectorInt v)
    {
        if (v.size == 0)
        {
            return true;
        }
        for (int i = 0; i < v.size; i++)
        {
            if (v.IntArray[i] != 0)
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator !(VectorInt v)
    {
        return v.size == 0;
    }

    public static VectorInt operator ~(VectorInt v)
    {
        for (int i = 0; i < v.size; i++)
        {
            v.IntArray[i] = ~v.IntArray[i];
        }
        return v;
    }

    public static VectorInt operator +(VectorInt v1, VectorInt v2)
    {
        uint maxSize = Math.Max(v1.size, v2.size);
        uint minSize = Math.Min(v1.size, v2.size);
        VectorInt result = new VectorInt(maxSize);
        
        for (int i = 0; i < minSize; i++)
        {
            result.IntArray[i] = v1.IntArray[i] + v2.IntArray[i];
        }
        
        for (int i = (int)minSize; i < maxSize; i++)
        {
            if (v1.size == maxSize)
            {
                result.IntArray[i] = v1.IntArray[i];
            }
            else
            {
                result.IntArray[i] = v2.IntArray[i];
            }
        }
        return result;
    }

    public static VectorInt operator +(VectorInt v, int scalar)
    {
        VectorInt result = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
        {
            result.IntArray[i] = v.IntArray[i] + scalar;
        }
        return result;
    }

    public static VectorInt operator -(VectorInt v1, VectorInt v2)
    {
        uint maxSize = Math.Max(v1.size, v2.size);
        uint minSize = Math.Min(v1.size, v2.size);
        VectorInt result = new VectorInt(maxSize);
        
        for (int i = 0; i < minSize; i++)
        {
            result.IntArray[i] = v1.IntArray[i] - v2.IntArray[i];
        }
        
        for (int i = (int)minSize; i < maxSize; i++)
        {
            if (v1.size == maxSize)
            {
                result.IntArray[i] = v1.IntArray[i];
            }
            else
            {
                result.IntArray[i] = -v2.IntArray[i];
            }
        }
        return result;
    }

    public static VectorInt operator -(VectorInt v, int scalar)
    {
        VectorInt result = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
        {
            result.IntArray[i] = v.IntArray[i] - scalar;
        }
        return result;
    }

    public static VectorInt operator *(VectorInt v1, VectorInt v2)
    {
        uint maxSize = Math.Max(v1.size, v2.size);
        uint minSize = Math.Min(v1.size, v2.size);
        VectorInt result = new VectorInt(maxSize);
        
        for (int i = 0; i < minSize; i++)
        {
            result.IntArray[i] = v1.IntArray[i] * v2.IntArray[i];
        }
        
        for (int i = (int)minSize; i < maxSize; i++)
        {
            if (v1.size == maxSize)
            {
                result.IntArray[i] = v1.IntArray[i];
            }
            else
            {
                result.IntArray[i] = v2.IntArray[i];
            }
        }
        return result;
    }

    public static VectorInt operator *(VectorInt v, int scalar)
    {
        VectorInt result = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
        {
            result.IntArray[i] = v.IntArray[i] * scalar;
        }
        return result;
    }

    public static VectorInt operator /(VectorInt v1, VectorInt v2)
    {
        uint maxSize = Math.Max(v1.size, v2.size);
        uint minSize = Math.Min(v1.size, v2.size);
        VectorInt result = new VectorInt(maxSize);
        
        for (int i = 0; i < minSize; i++)
        {
            if (v2.IntArray[i] != 0)
            {
                result.IntArray[i] = v1.IntArray[i] / v2.IntArray[i];
            }
            else
            {
                result.IntArray[i] = 0;
            }
        }
        
        for (int i = (int)minSize; i < maxSize; i++)
        {
            if (v1.size == maxSize)
            {
                result.IntArray[i] = v1.IntArray[i];
            }
            else
            {
                result.IntArray[i] = 0;
            }
        }
        return result;
    }

    public static VectorInt operator /(VectorInt v, int scalar)
    {
        VectorInt result = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
        {
            if (scalar != 0)
            {
                result.IntArray[i] = v.IntArray[i] / scalar;
            }
            else
            {
                result.IntArray[i] = 0;
            }
        }
        return result;
    }

    public static VectorInt operator %(VectorInt v1, VectorInt v2)
    {
        uint maxSize = Math.Max(v1.size, v2.size);
        uint minSize = Math.Min(v1.size, v2.size);
        VectorInt result = new VectorInt(maxSize);
        
        for (int i = 0; i < minSize; i++)
        {
            result.IntArray[i] = v1.IntArray[i] % v2.IntArray[i];
        }
        
        for (int i = (int)minSize; i < maxSize; i++)
        {
            if (v1.size == maxSize)
            {
                result.IntArray[i] = v1.IntArray[i];
            }
            else
            {
                result.IntArray[i] = v2.IntArray[i];
            }
        }
        return result;
    }

    public static VectorInt operator %(VectorInt v, int scalar)
    {
        VectorInt result = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
        {
            result.IntArray[i] = v.IntArray[i] % scalar;
        }
        return result;
    }

    public static VectorInt operator |(VectorInt v1, VectorInt v2)
    {
        uint maxSize = Math.Max(v1.size, v2.size);
        uint minSize = Math.Min(v1.size, v2.size);
        VectorInt result = new VectorInt(maxSize);
        
        for (int i = 0; i < minSize; i++)
        {
            result.IntArray[i] = v1.IntArray[i] | v2.IntArray[i];
        }
        
        for (int i = (int)minSize; i < maxSize; i++)
        {
            if (v1.size == maxSize)
            {
                result.IntArray[i] = v1.IntArray[i];
            }
            else
            {
                result.IntArray[i] = v2.IntArray[i];
            }
        }
        return result;
    }

    public static VectorInt operator |(VectorInt v, int scalar)
    {
        VectorInt result = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
        {
            result.IntArray[i] = v.IntArray[i] | scalar;
        }
        return result;
    }

    public static VectorInt operator ^(VectorInt v1, VectorInt v2)
    {
        uint maxSize = Math.Max(v1.size, v2.size);
        uint minSize = Math.Min(v1.size, v2.size);
        VectorInt result = new VectorInt(maxSize);
        
        for (int i = 0; i < minSize; i++)
        {
            result.IntArray[i] = v1.IntArray[i] ^ v2.IntArray[i];
        }
        
        for (int i = (int)minSize; i < maxSize; i++)
        {
            if (v1.size == maxSize)
            {
                result.IntArray[i] = v1.IntArray[i];
            }
            else
            {
                result.IntArray[i] = v2.IntArray[i];
            }
        }
        return result;
    }

    public static VectorInt operator ^(VectorInt v, int scalar)
    {
        VectorInt result = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
        {
            result.IntArray[i] = v.IntArray[i] ^ scalar;
        }
        return result;
    }

    public static VectorInt operator &(VectorInt v1, VectorInt v2)
    {
        uint maxSize = Math.Max(v1.size, v2.size);
        uint minSize = Math.Min(v1.size, v2.size);
        VectorInt result = new VectorInt(maxSize);
        
        for (int i = 0; i < minSize; i++)
        {
            result.IntArray[i] = v1.IntArray[i] & v2.IntArray[i];
        }
        
        for (int i = (int)minSize; i < maxSize; i++)
        {
            if (v1.size == maxSize)
            {
                result.IntArray[i] = v1.IntArray[i];
            }
            else
            {
                result.IntArray[i] = v2.IntArray[i];
            }
        }
        return result;
    }

    public static VectorInt operator &(VectorInt v, int scalar)
    {
        VectorInt result = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
        {
            result.IntArray[i] = v.IntArray[i] & scalar;
        }
        return result;
    }

    public static VectorInt operator >>(VectorInt v, int shift)
    {
        VectorInt result = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
        {
            result.IntArray[i] = v.IntArray[i] >> shift;
        }
        return result;
    }

    public static VectorInt operator <<(VectorInt v, int shift)
    {
        VectorInt result = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
        {
            result.IntArray[i] = v.IntArray[i] << shift;
        }
        return result;
    }

    public static bool operator ==(VectorInt v1, VectorInt v2)
    {
        if (v1.size != v2.size)
        {
            return false;
        }

        for (int i = 0; i < v1.size; i++)
        {
            if (v1.IntArray[i] != v2.IntArray[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator !=(VectorInt v1, VectorInt v2)
    {
        return !(v1 == v2);
    }

    public static bool operator >(VectorInt v1, VectorInt v2)
    {
        for (int i = 0; i < Math.Min(v1.size, v2.size); i++)
        {
            if (v1.IntArray[i] <= v2.IntArray[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator >=(VectorInt v1, VectorInt v2)
    {
        for (int i = 0; i < Math.Min(v1.size, v2.size); i++)
        {
            if (v1.IntArray[i] < v2.IntArray[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator <(VectorInt v1, VectorInt v2)
    {
        for (int i = 0; i < Math.Min(v1.size, v2.size); i++)
        {
            if (v1.IntArray[i] >= v2.IntArray[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator <=(VectorInt v1, VectorInt v2)
    {
        for (int i = 0; i < Math.Min(v1.size, v2.size); i++)
        {
            if (v1.IntArray[i] > v2.IntArray[i])
            {
                return false;
            }
        }
        return true;
    }
}

class ProgramVector
{
#if RUN_VECTOR
    static void Main(string[] args)
    {
        VectorInt v1 = new VectorInt(5, 2);
        VectorInt v2 = new VectorInt(5, 3);

        v1.PrintElements();
        v2.PrintElements();

        VectorInt v3 = v1 + v2;
        v3.PrintElements();

        v3 = v1 + 10;
        v3.PrintElements();

        v3 = v1 - v2;
        v3.PrintElements();

        v3 = v1 - 1;
        v3.PrintElements();

        v3 = v1 * v2;
        v3.PrintElements();

        v3 = v1 * 2;
        v3.PrintElements();

        v3 = v1 / v2;
        v3.PrintElements();

        v3 = v1 / 2;
        v3.PrintElements();

        v3 = v1 % v2;
        v3.PrintElements();

        v3 = v1 % 2;
        v3.PrintElements();

        v3 = v1 | v2;
        v3.PrintElements();

        v3 = v1 | 2;
        v3.PrintElements();

        v3 = v1 ^ v2;
        v3.PrintElements();

        v3 = v1 ^ 2;
        v3.PrintElements();

        v3 = v1 & v2;
        v3.PrintElements();

        v3 = v1 & 2;
        v3.PrintElements();

        v3 = v1 >> 1;
        v3.PrintElements();

        v3 = v1 << 1;
        v3.PrintElements();

        Console.WriteLine(v1 == v2);
        Console.WriteLine(v1 != v2);
        Console.WriteLine(v1 > v2);
        Console.WriteLine(v1 >= v2);
        Console.WriteLine(v1 < v2);
        Console.WriteLine(v1 <= v2);
    }
#endif
}
