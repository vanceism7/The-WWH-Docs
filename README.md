[WWH]:#wwh
[WWH Converter]:#wwh-converter

## Table of Contents
[WWH]  
[WWH Converter]  

## WWH
### What: 
WWH is a information organization system. It is best applied as a format for note taking/writing documentation.

WWH is an acronym used to categorize info, it stands for 
1. What -- As in: what is it/what does it do?
2. Why -- As in: why is it significant?
3. How -- How does it work?
### Why: 
Why do we need information organization?  
We are now living in a new world: a world where information is always right at our finger-tips. But it doesn't seem that we've fully adjusted to this fact. In just about every knowledge medium you can find, information is presented to us in a linear fashion -- like a novel. When info has such a clear-cut linear path, this approach to presentation is fine.   
 
Unfortunately, information is rarely well suited to linear presentation; rather, it is more like a tree. Pick any topic as a root, and it will consist of many subtopics, each of which have little to do with each other aside from the root, and of which each subtopic requires knowing little or nothing of the others to effectively understand.

e.g: If we look at the topic of science, there are many subtopics here, conveniently called *branches*. Some branches of science are: biology, anatomy, chemistry, physics, astrology, etc. None of these branches are linearly connected. They do not require deep knowledge of any other in order to be understood. They may have common elements, but they are not linear. 

The example above may be a bit grand, and obviously these branches have been setup in a tree-like way, rather than linear. But much information within more specific context is still presented incorrectly. Therefore, we need information organization.   

And leaving off with a quote from Elon Musk:
> One bit of advice: it is important to view knowledge as sort of a semantic tree - make sure you understand the fundamental principles, ie the trunk and big branches, before you get into the leaves/details or there is nothing for them to hang on to.
### How: 
Side note: WWH has its own syntax-light documentation language. See [WWH Converter] for more info!

We start off with any topic, and simply ask the questions:

1. What is it/What does it do? 
2. Why does it do it/why does it matter?
3. How does it work?

Answering these questions will often give us a much clearer outlook on the topic at hand.
There are two major keys to making this system work well however.

#### 1. Parent-concept references
Often times, we want the *what* or *why* section to refer back its parent-concept. 
e.g: 
> Section: Steering Wheel  
> What: A steering wheel is the wheel in front of the driver seat of a *car*. It allows the car to be directionally maneuvered left or right.

By referencing *car* in the what section of steering wheel, we have a way of relating it back to the parent concept *car*.


#### 2. Child-concept references
In the *how* section of our notes/docs, we want to break our current concept into as many subtopics as seems reasonable. This gives us links and digs us deeper into the details of the topic we're learning.

e.g:
> Section: Cars  
> What: A car is a common land-traveling vehicle  
> How:  
> A car is typically *gasoline* or *electric* powered, or in some cases, it may be a combination *hybrid* vehicle. 
> Two foot pedals are located on the ground in front of the driver seat. One pedal is a *brake pedal* -- responsible for slowing/stopping the car, the other is the gas/*power pedal* -- this pedal makes the car increase in speed. Besides these, cars have a *gear shifter*, *steering wheel*, and some *instruments* for viewing the cars various properties such as speed, gas tank, etc. 

Just by investigating the various aspects of how a car works, we have listed off 8 different child concepts which could be recursively examined with WWH to understand how they work -- this process can be repeated as much as desired until the reader/doc has sufficiently explored any root topic.

#### My personal tips from using this
##### If you're using this as a studying tool:   
One important thing I've learned from applying this technique in my studies is that you definitely want to take a breadth-first approach to your note-taking/study. It is very easy to just keep digging deeper and deeper into child concepts -- those of which are irrelevant to your study. One of the advantages of WWH is that you don't have to move through information linearly. Once you've listed off all the child concepts of a topic, there is no need to dig deeper into them if you dont need to. It is enough merely to *know* the names of those concepts. Half of the battle in gaining knowledge is being able to name off the things you don't know.  
Also: Don't be afraid to take dirty ugly bullet-point notes written in cave-man language. Wrapping your mind around something is most important -- the finer points and presentation can be fixed later.

##### If you're writing technical documentation for an API or something of the sort:  
WWH is a sort of middle ground between a tutorial and an API reference. Once a concept has been dug deep enough into, there is nothing more to do than to give a link to the API reference which shows the lowest level details of how a construct is used.


See the [Study Guides](https://github.com/vanceism7/The-WWH-Docs/tree/master/Study%20Guides) section to see some real-world examples of WWH in action.

---
## WWH Converter
### What: 
The wwh conversion tool will take documents written using wwh syntax, and convert them to a varying number of formats in a neat document layout. In addition to setting the layout, it creates a table of contents with links to each of the wwh sections, and will replace wwh links with live section links as well.

For the moment, WWH Conversion tool will only convert to markdown. However -- markdown is sufficient to get to any other format if you use [Pandoc](https://pandoc.org/)
### How: 
WWH syntax is minimal and non-intrusive. It is meant to work in conjunction with other scripting languages such as markdown, or html. -- Consequently, whatever format you write it in, it will be married to. I may add more wwh constructs later which will convert properly between formats. But I will add features as they are needed.

The syntax is as follows:

#### Reserved keywords 
```
 Section:
 What:
 Why:
 How:
```
These keywords are only recognized when placed at the beginning of a line. Any text following after these will be interpreted as essentially plain text, and may have markdown formatting or any other formatting applied to them. 
`Section:` must have its title specified on the same line. The keywords may have their text on the same line or next lines.

Lastly, `Section:` and `What:` are required for each section. `How:` and `Why:` are optional

#### Section References
```
&Section Name&
&Click Here:Section Name&
```
-- Any text found between a pair of ampersands `&` will be interpreted as a reference to another section within the document. It also allows a display:link reference style such as that found in markdown. 
I.e: 
[WWH Converter] -- Here's a reference back to the beginning of this section
[Click here][WWH] -- Here's a display style reference to the first section of the document

The actual "&" symbol can be added in using the standard "\\" escape symbol
The ":" symbol can be added in references using standard "\\" as well.  

---
## Conclusion[^1] [^2] [^3] [^4]
So with all of that said, I will be using this repo to publish all of my note taking exploits as I continue to explore new technologies in programming. I hope that my efforts will help streamline the process of learning for others.

[^1]: Notice that I used the WWH format to explain what WWH is, the power is already at work!

[^2]: I realize this WWH is super simple, and not earth shattering or ground breaking in anyway, as well as a very common teaching used in elementary schools, but sometimes simple is better

[^3]: WWH is pronounced "Wahoo!", like "yahoo", but with a W...

[^4]: I know I probably need an editor haha...

---
