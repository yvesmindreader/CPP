// SortingCollection.cpp : 
//implement and compare different sorting algorithms
//

#include "stdafx.h"
#include <iostream>

#include "AbstractSorting.h"
using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	int a[] = {0,1,2,3,4,5,6,7,8,9,5};
	vector<int> vArray(a, a +sizeof(a)/sizeof(a[0]));

	char cSortingAlg;
	cout << "Please input sorting # to choose algorithm:"<<endl;
	cout<<"\t#1 Quicksort"<<endl;
	cout<<"\t#2 Heapsort"<<endl;
	cout<<"\tother to exit"<<endl;

	while (cin >> cSortingAlg)
	{
		switch (cSortingAlg)
		{
		case '1':
			{
				cout << "Quicksort Alg is selected" <<endl;
				Quicksort qs(vArray);
				qs.quicksort(0, qs.getArrayLength() -1);
				break;
			}
		case '2':
			{
				cout << "Heapsort Alg is selected" <<endl;
				Heapsort hs(vArray);
				hs.heapsort();
				break;
			}
		default:
			return 0;
		}
	}
	
	return 0;
}
