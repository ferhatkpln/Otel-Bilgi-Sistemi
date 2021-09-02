using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelBilgiSistemi
{
    public class Heap
    {
        private OtelBilgileri[] heapArray;
        private int maxSize;
        private int currentSize;

        public Heap(int max)
        {
            maxSize = max;
            currentSize = 0;
            heapArray = new OtelBilgileri[maxSize];
        }

        public bool insert(OtelBilgileri birOtel)
        {
            if (currentSize == maxSize)
                return false;
            OtelBilgileri newNode = birOtel;
            heapArray[currentSize] = newNode;
            trickleUp(currentSize++);
            return true;
        }

        public void trickleUp(int index)
        {
            int parent = (index - 1) / 2;
            OtelBilgileri bottom = heapArray[index];
            while (index > 0 && heapArray[parent].puan > bottom.puan)
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }

        public OtelBilgileri remove()
        {
            OtelBilgileri root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            trickleDown(0);
            return root;
        }

        public void trickleDown(int index)
        {
            int largerChild;
            OtelBilgileri top = heapArray[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                if (rightChild < currentSize && heapArray[leftChild].puan > heapArray[rightChild].puan)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                if (top.puan <= heapArray[largerChild].puan)
                    break;
                heapArray[index] = heapArray[largerChild];
                index = largerChild;
            }
            heapArray[index] = top;
        }

        public OtelBilgileri displayHeap()
        {
            OtelBilgileri birOtel;
            birOtel = remove();
            string temp = "";

            temp += "Otel Adı:" + birOtel.Ad + "Otel İl:" + birOtel.Il + "Otel İlçe:" + birOtel.Ilce +
                    "Yıldız Sayısı:" + birOtel.YildizSayisi + "Oda Tipi:" + birOtel.OdaTipi + "Oda Sayisi:" + birOtel.OdaSayisi +
                    "Puan:" + birOtel.puan;
            return birOtel;
        }
    }
}
