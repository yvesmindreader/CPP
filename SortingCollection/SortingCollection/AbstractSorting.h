#pragma once
#include <vector>
#include <algorithm>
using namespace std;
class AbstractSorting
{
public:
	AbstractSorting(void);
	~AbstractSorting(void);
	void init();
	int getArrayLength() const;
protected:
	vector<int> m_vArray;
	void printresults();
	void shufflearray();
};

class Quicksort : public AbstractSorting
{
public:
	Quicksort();
	Quicksort(vector<int>& vArray);
	~Quicksort();
	void quicksort(int low, int high);
	int	partitionsort(int low, int high);
private:

};
class Heapsort : public AbstractSorting
{
public:
	Heapsort();
	Heapsort(vector<int>& vArray);
	~Heapsort();
	void heapsort();
	void Heapify(int heapsize, int k);
	inline int LeftChild(int n){return 2*n + 1;}
	inline int RightChild(int n){return 2*n + 2;}
private:

};