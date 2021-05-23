// EXAM2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;


typedef struct _Node {
	void* value;
	struct _Node* next;
	struct _Node* prev;
} Node;

typedef struct _DblLinkedList {
	size_t size;
	Node* head;
	Node* tail;
}DblLinkedList;

DblLinkedList* createDblLinkedList() {
	DblLinkedList* tmp = (DblLinkedList*)malloc(sizeof(DblLinkedList));
	tmp->size = 0;
	tmp->head = tmp->tail = NULL;

	return tmp;
}



void pushFront(DblLinkedList* list, void* data) {
	Node* tmp = (Node*)malloc(sizeof(Node));
	if (tmp == NULL) {
		exit(1);
	}
	tmp->value = data;
	tmp->next = list->head;
	tmp->prev = NULL;
	if (list->head) {
		list->head->prev = tmp;
	}
	list->head = tmp;

	if (list->tail == NULL) {
		list->tail = tmp;
	}
	list->size++;
}

void pushBack(DblLinkedList* list, void* value) {
	Node* tmp = (Node*)malloc(sizeof(Node));
	if (tmp == NULL) {
		exit(3);
	}
	tmp->value = value;
	tmp->next = NULL;
	tmp->prev = list->tail;
	if (list->tail) {
		list->tail->next = tmp;
	}
	list->tail = tmp;

	if (list->head == NULL) {
		list->head = tmp;
	}
	list->size++;
}

Node* getNth(DblLinkedList* list, size_t index) {
	Node* tmp = list->head;
	size_t i = 0;

	while (tmp && i < index) {
		tmp = tmp->next;
		i++;
	}

	return tmp;
}

void insert(DblLinkedList* list, size_t index, void* value) {
	Node* elm = NULL;
	Node* ins = NULL;
	elm = getNth(list, index);
	if (elm == NULL) {
		exit(5);
	}
	ins = (Node*)malloc(sizeof(Node));
	ins->value = value;
	ins->prev = elm;
	ins->next = elm->next;
	if (elm->next) {
		elm->next->prev = ins;
	}
	elm->next = ins;

	if (!elm->prev) {
		list->head = elm;
	}
	if (!elm->next) {
		list->tail = elm;
	}

	list->size++;
}

void* deleteNth(DblLinkedList* list, size_t index) {
	Node* elm = NULL;
	void* tmp = NULL;
	elm = getNth(list, index);
	if (elm == NULL) {
		exit(5);
	}
	if (elm->prev) {
		elm->prev->next = elm->next;
	}
	if (elm->next) {
		elm->next->prev = elm->prev;
	}
	tmp = elm->value;

	if (!elm->prev) {
		list->head = elm->next;
	}
	if (!elm->next) {
		list->tail = elm->prev;
	}

	free(elm);

	list->size--;

	return tmp;
}


void printDblLinkedList(DblLinkedList* list, void (*fun)(void*)) {
	Node* tmp = list->head;
	while (tmp) {
		fun(tmp->value);
		tmp = tmp->next;
	}
	printf("\n");
}


void printInt(void* value) {
	printf("%d ", *((int*)value));
}

// Тестовый пример
void main()
{
	DblLinkedList* list = createDblLinkedList();
	int a, b, c, d, e, f, g, h;

	a = 10;
	b = 20;
	c = 30;
	d = 40;
	e = 50;
	f = 60;
	g = 70;
	h = 80;
	pushFront(list, &a);
	pushFront(list, &b);
	pushFront(list, &c);
	pushBack(list, &d);
	pushBack(list, &e);
	pushBack(list, &f);
	insert(list, 3, &g);
	printDblLinkedList(list, printInt);
}
// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
