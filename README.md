[WWH]:./README.md#wwh
[The Details]:./README.md#the-details
[WWH Converter]:./README.md#wwh-converter

## Table of Contents
[WWH]  
[The Details]  
[WWH Converter]  

## Section: WWH
### What: 
WWH is a study method, documentation/note-taking format, and knowledge sharing system!

WWH is an acronym which stands for three questions we ask ourselves when studying
1. What does it do?
2. Why do we use it/Why does it exist?
3. How does it work?
### Why: 
WWH is used for organizing large amounts of information. It is meant to give a natural starting point on approaching new concepts, and then allows for quickly digging into the details without becoming overwhelmed or lost among the content. The guides we write using WWH can then be shared with others, allowing them to benefit from a simplistic, streamlined guide!
### How: 
To Start, we look at new concepts from a birds eye view and just ask the three simple questions:

1. What does it do?
2. How does it do it?
3. Why does it do it/Why is it used?

When answering these questions, it is important to keep the answers as brief as possible. Only the how section is permitted to be of a greater length in order to accommodate for example content. To see how each section should be used in more detail, see [The Details]

In addition to the above, wwh comes with its own document drafting language, which can be run through the wwh conversion tool to create neat, view-able documents of varying formats, such as markdown, pdf, etc
 
See [WWH Converter] for more.

---
## Section: The Details
### What: 
This section will explain in greater detail how each of the sections can be used.
### How: 
The type of information that should be contained in each section is outlined below:

### The *"What does it do"* section?
This section should only name off what the concept is/does.

---
### The *"Why does it exist?"* section
This section is self-explanatory, to name off why said concept exists. But an important detail to note here is that the *why* is usually a reference back to the bigger picture. When ever possible, it should name off which greater concept it's a part of.

I.e: (Let's say we're talking about a tire)
> Why: "Tires sit underneath **_cars_**, allowing them to travel smoothly and absorbing impact"

The car reference in this *why* section brings us up a level to it's parent-concept, a car, which in our study guide would have its own WWH section

---
### The *"How does it work?"* section
The how section is particularly important, as it presents us a gateway for digging deeper into the topic at hand. The how section should contain key-terms which in turn will get their own WWH section, in this way, the details can be examined without losing view of the bigger picture.

I.e: 
> How: A car helps us travel through the use of many components as follows:
> 1. *Internal Controls* - These are used to maneuver the vehicle
> 2. *The Engine* -  This provides the moving power of the vehicle
> 3. *Tires* - The car sits on top of 4 tires, providing balance and removing friction

Each of these sections named can then be easily the next subjects for digging deeper into how a car functions.

---
### Technically (a.k.a For the geeky people)
WWH is meant to take the shape of a tree-like data structure. 
- The what section defines what the node is
- The How section not only defines how it works, but also any child-nodes which support its function
- The why section should be a reference to how it supports its parent-node (except for the root).

In this way, we create a nice concept map of how everything links together.

In general, WWH meant to be used in a note-taking fashion. Although it is useful for focusing our study efforts, the real benefit comes from the concept map it creates once written down.

---
## Section: WWH Converter
### What: 
The wwh conversion tool will take documents written using wwh syntax, and convert them to a varying number of formats in a neat document layout. In addition to setting the layout, it creates a table of contents with links to each of the wwh sections, and will replace wwh links with live section links as well.
### How: 
WWH syntax is minimal and non-intrusive. It is meant to work in conjunction with other scripting languages such as markdown, or latex. 

The syntax is as follows:

#### Reserved keywords 
```
 Section:
 What:
 Why:
 How:
```
These keywords are only recognized when placed at the beginning of a line. Any text following after these will be interpreted as essentially plain text, and may have markdown formatting or any other formatting applied to them. 
`Section:` must have its title specified on the same line. The other keywords may have their text on the same line or next lines.

Lastly, `Section:` and `What:` are required for each section. `How:` and `Why:` are optional

#### Section References
```
&Section Name&
&Click Here:Section Name&
```
-- Any text found between a pair of ampersands `&` will be interpreted as a reference to another section within the document. It also allows a display:link reference style such as that found in markdown.  
I.e:  
[WWH Converter] -- Here's a reference back to the beginning of this section  
[WWH] -- Here's a reference to the first section of the document  

The actual "&" symbol can be added in using the standard "\\" escape symbol  

---
## Conclusion[^1] [^2] [^3]
So with all of that said, I will be using this repo to publish all of my note taking exploits as I continue to explore new technologies in programming. I hope that my efforts will help streamline the process of learning for others.

[^1]: Notice that I used the WWH format to explain what WWH is, the power is already at work!

[^2]: I realize this WWH is super simple, and not earth shattering or ground breaking in anyway, as well as a very common teaching used in elementary schools, but sometimes simple is better

[^3]: WWH is pronounced "Wahoo!", like "yahoo", but with a W...

---
