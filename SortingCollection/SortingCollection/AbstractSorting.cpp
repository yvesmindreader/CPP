#include "stdafx.h"
#include "AbstractSorting.h"
#include <iostream>
#include <time.h>
using namespace std;
AbstractSorting::AbstractSorting(void)
{
}

AbstractSorting::~AbstractSorting(void)
{
}

void AbstractSorting::printresults()
{
	vector<int>::iterator iter;
	cout<<"array as:"<<endl;
	for ( iter = m_vArray.begin(); iter != m_vArray.end(); iter++)
	{
		cout<<*iter<<" ";
	}
	cout<<endl;
}
void AbstractSorting::shufflearray()
{
	srand(time(NULL));
	random_shuffle(m_vArray.begin(), m_vArray.end());
	cout<<"shuffle array...";
	printresults();
}
void AbstractSorting::init()
{	
	printresults();
	shufflearray();
}

Quicksort::Quicksort()
{
	init();
}
Quicksort::Quicksort(vector<int>& vArray)
{
	m_vArray = vArray;
	init();
}
Quicksort::~Quicksort()
{
}

int AbstractSorting::getArrayLength() const
{
	return m_vArray.size();
}
void Quicksort::quicksort(int low, int high)
{
	if (low >= high)
	{
		return;
	}

	int k = partitionsort(low, high);

	if (low < k - 1)
	{
		quicksort(low, k - 1);
	}
	if (k + 1 < high)
	{
		quicksort(k + 1, high);
	}
}

int	Quicksort::partitionsort(int low, int high)
{
	int pivot = m_vArray[low];
	while (low < high)
	{
		while (low < high && m_vArray[high] <= pivot) high--;
		m_vArray[low] = m_vArray[high];
		while (low < high && m_vArray[low] >= pivot) low++;
		m_vArray[high] = m_vArray[low];
		m_vArray[low] = pivot;
	}
	printresults();
	return low;
}
Heapsort::Heapsort()
{
	init();
}
Heapsort::Heapsort(vector<int>& vArray)
{
	m_vArray = vArray;
	init();
}
Heapsort::~Heapsort()
{}
void Heapsort:: heapsort()
{
	int heapsize = getArrayLength();
	for (int i = (heapsize - 1) /2; i >= 0 ; i--)
	{
		Heapify(heapsize, i);
	}
	heapsize--;
	for (int i = heapsize; i > 0 ; i--)
	{
		swap(m_vArray[0], m_vArray[i]);
		Heapify(i, 0);
	}
	printresults();
}

void Heapsort::Heapify(int heapsize, int k)
{
	if (k > heapsize -1)
	{
		return;
	}
	int min = k;
	if (LeftChild(k) < heapsize && m_vArray[LeftChild(k)] < m_vArray[min])
	{
		min = LeftChild(k);
	}
	if (RightChild(k) < heapsize && m_vArray[RightChild(k)] < m_vArray[min])
	{
		min = RightChild(k);
	}
	if(min != k)
	{
		swap(m_vArray[k], m_vArray[min]);	
		Heapify(heapsize, min);
	}
}