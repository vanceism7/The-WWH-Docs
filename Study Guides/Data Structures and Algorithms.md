# Data Structures and Algorithms
(Based on the book Introduction to Algorithms)

<!-- Link References -->
[Algorithms]: ./Data%20Structures%20and%20Algorithms.md#algorithms
[Loop Invariants]: ./Data%20Structures%20and%20Algorithms.md#loop-invariants
[Data Structures]: ./Data%20Structures%20and%20Algorithms.md#data-structures
[Algorithm Types]: ./Data%20Structures%20and%20Algorithms.md#algorithm-types
[Incremental Algorithms]: ./Data%20Structures%20and%20Algorithms.md#incremental-algorithms
[Divide and Conquer Algorithms]: ./Data%20Structures%20and%20Algorithms.md#divide-and-conquer-algorithms
[Computational Problems]: ./Data%20Structures%20and%20Algorithms.md#computational-problems 
[Sorting]: ./Data%20Structures%20and%20Algorithms.md#sorting
[Insertion Sort]: ./Data%20Structures%20and%20Algorithms.md#insertion-sort
[Merge Sort]: ./Data%20Structures%20and%20Algorithms.md#merge-sort
[Efficiency]: ./Data%20Structures%20and%20Algorithms.md#efficiency
  

# Table of Contents

[Algorithms]  
[Loop Invariants]  
[Data Structures]  
[Algorithm Types]  
- [Incremental Algorithms]
- [Divide And Conquer Algorithms]  
[Computational Problems]  
- [Sorting]
- - [Insertion Sort]
- - [Merge Sort]  

[Efficiency]  

# The Beginning 

## Algorithms
### 1. What does it do?
Informally, an algorithm is any well-defined computational procedure that takes some value, or set of values, as input and produces some value, or set of values, as output. An algorithm is thus a sequence of computational steps that transform the input into the output

### 2. Why does it exist?
Algorithms are a tool for solving well-specified [Computational Problems].

### 3. How does it work?
An Algorithm can be specified in whatever way is convenient (code, pseudo-code, plain english, etc), as long as it provides a precise description of its procedure.
There are a number of different factors that contribute to the way algorithms work, listed below

1. [Loop Invariants]
2. [Data Structures] 
3. The [Algorithm Type][Algorithm Types]
4. The type of [Computational Problem][Computational Problems]
5. [Efficiency]

---

## Loop Invariants
[next][Data Structures] [Parent][Algorithms]
### 1. What does it do?
Loop Invariants are specific properties about an algorithm which are true prior to any loop iterations, true at the beginning and end of each loop iteration, and remain true when the algorithm has completed

### 2. Why does it exist?
Loop Invariants help us to understand why an [algorithm][Algorithms] is correct

### 3. How does it work?

---

## Data Structures 
[previous][Loop Invariants] [next][Algorithm Types] [Parent][Algorithms]
### 1. What does it do?
A data structure is a way to store and organize data in order to facilitate access and modifications. No single data structure works well for all purposes.

### 2. Why does it exist?
### 3. How does it work?

---

## Algorithm Types
[previous][Data Structures] [next][Computational Problems]
### 1. What does it do?
Algorithms follow certain patterns that will generally place them within a specific algorithm category

### 2. Why does it exist?
Different algorithm types are better suited to certain [Computational Problems] than others.

### 3. How does it work?
The different algorithm types are

1. [Incremental][Incremental Algorithms]
2. [Divide And Conquer][Divide and Conquer Algorithms]

---

## Incremental Algorithms
### 1. What does it do?
### 2. Why does it exist?
### 3. How does it work?

---

## Divide And Conquer Algorithms
### 1. What does it do?
### 2. Why does it exist?
### 3. How does it work?

---

## Computational Problems
[previous][Algorithm Types] [next][Efficiency] [Parent][Algorithms]
### 1. What does it do?
### 2. Why does it exist?
### 3. How does it work?

The way an algorithm works will depend on the type of *computational problem* you are trying to solve. Below are a list of computational problems to which an algorithm can be applied:

1. [Sorting]

---

## Sorting
### 1. What does it do?
The sorting problem is the problem in which we take a sequence of numbers and re-order them to be in numerical ascending or descending order.
I.e: `[5,2,4,1,3]` sorted becomes `[1,2,3,4,5]`

### 2. Why does it exist?
We use sorting in order to locate and work with sequences much more quickly and efficiently

### 3. How does it work?
The numbers to be sorted are called *keys*. 
There are a number of different sorting algorithms

1. [Insertion Sort]
2. [Merge Sort]

---

## Insertion Sort
### 1. What does it do?
It's a [Sorting] algorithm. Insertion sort does an *in-place* sort, meaning it sorts the numbers within the array itself.

### 2. Why does it exist?
It is used for efficiently [Sorting] a small set of numbers

### 3. How does it work?
Insertion sort moves from left to right starting from the 2nd element. The currently selected number, `n`, is compared with every number, `x`, left of it. If `n` is less than `x`, then `x` is shifted right, and the next left number is compared. Once `n` is greater than `x`, the process stops, and n is placed in that position.

Intro to algorithms describes it this way:
> Insertion sort works the way many people sort a hand of
playing cards. We start with an empty left hand and the cards face down on the
table. We then remove one card at a time from the table and insert it into the
correct position in the left hand. To find the correct position for a card, we compare
it with each of the cards already in the hand, __from right to left__..

Here is insertion sort in code:
```
for( int i = 1; i < seq.Length; ++i )
{
  int key = seq[i];
  int j = i-1;

  while( j >= 0 && seq[j] > key )
  {
    seq[j+1] = seq[j];
    j--;
  }

  seq[j+1] = key;
}
```
Wikipedia has a great gif image of how this works:  
![Insertion Sort](https://upload.wikimedia.org/wikipedia/commons/0/0f/Insertion-sort-example-300px.gif)

---

## Merge Sort
### 1. What does it do?
It's a [Sorting] algorithm.

### 2. Why does it exist?
### 3. How does it work?

---

## Efficiency
[previous][computational problems] [Parent][Algorithms]
### 1. What does it do?
Efficiency is the measure of how many computational steps an algorithm takes in order to solve a particular [computational problems]. Inefficient algorithms will take a great number of steps relative to the size of its input, whereas efficient ones will take very few. 

### 2. Why does it exist?
Effiency is incredibly important to solving a [computation problem][computational problems] in a reasonable amount of time using minimal computing power

### 3. How does it work?
The efficiency of an algorithm, or how long it takes to complete, is dependent on it's input size, usually denoted as *n*. We can use algebraic equations to describe its running time. For example, the efficiency may be written in equations such as `n^2 + 2n + 3` or `2n + 4`. 

Although technically an equation will have many different terms and constants, what is most important in analyzing an algorithms efficiency is it's rate of growth, or [Order Of Growth], of its running-time. For that reason, only the leading term of it's running-time formula is used.

For example: 
[Insertion sorts][Insertion Sort] efficiency: `cn^2` has a growth factor of `n^2`
[Merge sorts][Merge Sort] efficiency: `cn*lg(n)` has a factor of `lg(n)`

These running-times are more formally written as O(n), typically called [Big O Notation]

When analyzing an algorithm, it is most useful to examine the worst-case scenario.
> We usually consider one algorithm to be more efficient than another if its worstcase
running time has a lower order of growth. 

Some common growth factors of an algorithm are listed below (from most efficient to least efficient)
- lg(n)
- sqrt(n)
- n
- n\*lg(n)
- n^2
- n^3
- 2^n
- n!

---

## Title
### 1. What does it do?
### 2. Why does it exist?
### 3. How does it work?

---
