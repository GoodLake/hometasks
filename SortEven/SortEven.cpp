#include "stdafx.h"

void Out(int n, int *data)
{
	for (int i = 0; i < n; ++i)
	{
		std::cout << std::setw(5);
		std::cout << data[i];
	}
	std::cout << std::endl;
}

void Fill(int n, int *data)
{
	for (int i = 0; i < n; ++i)
	{
		data[i] = rand() % 1001;
	}
}

void SortEven(int n, int *data)
{
	for (int i = 0; i < n - 1; ++i)
	{
		if (data[i] & 1)
			continue;
		int min = data[i];
		int J = i;
		for (int j = i + 1; j < n; ++j)
		{
			if (data[j] & 1)
				continue;
			if (min > data[j])
				min = data[J = j];
		}
		std::swap(data[J], data[i]);
	}
}

int main()
{
	srand(static_cast<unsigned int>(time(nullptr)));
	int n;
	std::cout << "Enter a count of the digits." << std::endl;
	std::cin >> n;
	int *data = new int[n];
	Fill(n, data);
	Out(n, data);
	SortEven(n, data);
	Out(n, data);
	delete[] data;
	return 0;
}

