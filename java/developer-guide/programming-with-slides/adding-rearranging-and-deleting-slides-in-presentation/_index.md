---
title: Adding, Rearranging, and Deleting Slides in Presentation
type: docs
weight: 10
url: /java/adding-rearranging-and-deleting-slides-in-presentation/
---

## **Adding Slides to the Presentation**
{{% alert color="primary" %}} 

Before talking about adding slides to the presentation files, let us discuss some facts about the slides. Each PowerPoint presentation file contains **Master / Layout** slide and other **Normal** slides. It means that a presentation file contains at least one or more slides. It is important to know that presentation files without slides are not supported by Aspose.Slides for Java. Each slide has a unique Id and all the Normal Slides are arranged in an order specified by the zero-based index.

{{% /alert %}} 

Aspose.Slides for Java allows developers to add empty slides to their presentation. To add an empty slide in the presentation, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class.
- Instantiate [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) class by setting a reference to the Slides (collection of content Slide objects) property exposed by the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) object.
- Add an empty slide to the presentation at the end of the content slides collection by calling the [**AddEmptySlide**](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) methods exposed by [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) object.
- Do some work with the newly added empty slide.
- Finally, write the presentation file using the Presentation object.



{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-AddingSlidesToPresentation-AddingSlidesToPresentation.java" >}}
### **Adding or Removing section**
Aspose.Slides for Java now allows developers to add a section or remove the section where a group of slides can be added or removed. Developers can also add a section at any desired location in the presentation. The code snippet below demonstrates how to use this feature.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-ISectionCollection-ISectionCollection.java" >}}
## **Accessing Slides of a Presentation**
{{% alert color="primary" %}} 

In this topic, we will introduce the possible ways to access a slide from a presentation file. Each slide in a presentation has a unique Id. On the other hand, all the slides in the presentation are arranged in the order of the slide position starting from 0, that is, slide at position 1 will be accessible through 0 index of [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) associated with a [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) object.

{{% /alert %}} 

Aspose.Slides for Java provides [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class that can be used to find and access any desired slide present in the presentation. Currently, developers can access a slide in two ways:

1. Accessing Slide by Index
1. Accessing Slide by ID
### **Using Slides Collection to Access Slide by Index**
[Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class represents a presentation file and exposes all slides in it as a [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) collection (that is a collection of [ISlide](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlide) objects). All of these slides can be accessed from this **Slides** collection using a slide index as shown below in the example.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-AccessingSlideByIndex-AccessingSlideByIndex.java" >}}
### **Using Presentation class to Access Slide by ID**
Every slide in the presentation has a unique ID associated with it. The [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class exposes the [**getSlideById(id)**](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation#getSlideById-long-) method that can be used to access the slide by ID. All you need to do is to provide the valid slide ID and access that slide using **getSlideById(id)** method as shown below in the example.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-AccessingSlideByID-AccessingSlideByID.java" >}}
## **Removing Slides from a Presentation**
{{% alert color="primary" %}} 

Sometimes, developers may need to remove a slide from the presentation due to any reason. Aspose.Slides for Java offers few methods to do so. In this topic, we will explore these methods to accomplish this task.

{{% /alert %}} 

We know that [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class in Aspose.Slides for Java represents a presentation file. [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class encapsulates a [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) that acts as a repository of all slides that are the part of the presentation. Developers can remove a slide from this **Slides** collection in two ways:

1. Using Slide Reference
1. Using Slide Index
### **Using Slide Reference**
To remove a slide using its reference, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Id or Index
1. Remove the referenced slide from the presentation
1. Write the modified presentation file



{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-RemoveASlideUsingSlideReference-RemoveASlideUsingSlideReference.java" >}}
### **Using Slide Index**
To remove a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class.
1. Remove the slide from the presentation by using its index position
1. Write the modified presentation file



{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-RemoveASlideUsingSlideIndex-RemoveASlideUsingSlideIndex.java" >}}
## **Cloning Slides in Presentation**
{{% alert color="primary" %}} 

Cloning is the process of making an exact copy or replica of something. Aspose.Slides for Java also makes it possible to make a copy or clone of any slide and then insert that cloned slide to the current or any other opened presentation. The process of slide cloning creates a new slide that can be modified by developers without changing the original slide. In this topic, we will learn how to perform slide cloning.

{{% /alert %}} 

There are several possible ways to clone a slide:

- Cloning a slide from one position to the end of the slides within the same presentation.
- Cloning a slide from one position to another position within the same presentation.
- Cloning a slide from one presentation to another one at the end of the existing collection of slides.
- Cloning a slide from one presentation to another one at a specified position.
- In Another presentation with a master slide from the source presentation at the end of the existing slides.

In Aspose.Slides for Java, [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) (a collection of [ISlide](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlide) objects) exposed by the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) object provides the [**addClone**](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) and [**insertClone**](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) methods to perform the above types of slide cloning. Let's discuss the use of this method in the below sections with the help of examples.
### **Within the Same Presentation from One Position to the End**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [**addClone** ](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)method according to the steps listed below:

1. Create an instance of the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) class by referencing the slides collection exposed by the Presentation object.
1. Call the **addClone** method exposed by the [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) object and pass the slide to be cloned as a parameter to the **addClone** method.
1. Write the modified presentation file.

In the example given below, we have cloned a slide (lying at the first position – zero index – of the presentation) to the end of the presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-CloningASlideFromOnePositionToTheEndWithinSamePresentation-CloningASlideFromOnePositionToTheEndWithinSamePresentation.java" >}}
### **From One Position to Another within the Same Presentation**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the **insertClone** method:

1. Create an instance of the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) class by referencing the Slides collection exposed by the Presentation object.
1. Call the [**insertClone** ](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)method exposed by the [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) object and pass the slide to be cloned along with the index for the new position as a parameter to the **insertClone** method.
1. Write the modified presentation as a [PPTX ](https://wiki.fileformat.com/presentation/pptx/)file.

In the example given below, we have cloned a slide (lying at the zero index – position 1 – of the presentation) to index 1 – Position 2 – of the presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-CloningASlideFromOnePositionToAnotherWithinSamePresentation-CloningASlideFromOnePositionToAnotherWithinSamePresentation.java" >}}
### **In Another Presentation at the End of the Existing Slides**
If you need to clone a slide from one presentation and use it in another presentation file at the end of the existing slides:

1. Create an instance of the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class containing the presentation the slide will be cloned from.
1. Create an instance of the Presentation class containing the destination presentation that the slide will be added to.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) class by referencing the Slides collection exposed by the Presentation object of the destination presentation.
1. Call the [**addClone** ](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)method exposed by the ISlideCollection object and pass the slide from the source presentation as a parameter to the **addClone** method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to the end of the destination presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-CloningASlideFromOnePresentationToAnotherAtTheEnd-CloningASlideFromOnePresentationToAnotherAtTheEnd.java" >}}
### **In Another Presentation at the Specified Position**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. Create an instance of the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the Presentation class containing the presentation the slide will be added to.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) class by referencing the Slides collection exposed by the Presentation object of the destination presentation.
1. Call the [**insertClone**](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) method exposed by the ISlideCollection object and pass the slide from the source presentation along with the desired position as a parameter to the **InsertClone** method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to index 1 (position 2) of the destination presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-CloningASlideFromOnePresentationToAnotherAtASpecifiedPosition-CloningASlideFromOnePresentationToAnotherAtASpecifiedPosition.java" >}}
### **In Another Presentation with Master Slide from Source Presentation at the End of the Existing Slides**
If you need to clone a slide with a master slide from one presentation and use it in another presentation, you need to clone the desired master slide from source presentation to destination presentation first. Then you need to use that master slide for cloning slide with master slide. The **addClone(ISlide, IMasterSlide)** expects a master slide from destination presentation rather than from source presentation. In order to clone the slide with the master, please follow the steps below:

1. Create an instance of the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the Presentation class containing the destination presentation the slide will be cloned to.
1. Access the slide to be cloned along with the master slide.
1. Instantiate the [IMasterSlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/IMasterSlideCollection) class by referencing the*{Masters* collection exposed by the Presentation object of the destination presentation.
1. Call the [**addClone**](https://apireference.aspose.com/java/slides/com.aspose.slides/IMasterSlideCollection#addClone-com.aspose.slides.IMasterSlide-) method exposed by the IMasterSlideCollection object and pass the master from the source PPTX to be cloned as a parameter to the **addClone** method.
1. Instantiate the [ISlideCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ISlideCollection) class by setting the reference to the Slides collection exposed by the Presentation object of the destination presentation.
1. Call the [**addClone**](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) method exposed by the [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) object and pass the slide from the source presentation to be cloned and master slide as a parameter to the **addClone** method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide with the master (lying at the zero index of the source presentation) to the end of the destination presentation using master from source slide.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-CloneASlideWithMasterSlideFromOnePresentationToAnother-CloneASlideWithMasterSlideFromOnePresentationToAnother.java" >}}
## **Clone Slide to Specified Section**
If you want to clone a slide and then use it within the same presentation file but at a different section, then use the [**addClone()**](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) method exposed by the [**ISlideCollection** ](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection)interface. Aspose.Slides for Java makes it possible to clone a slide from the first section and then insert that cloned slide to the second section of the same presentation.

The following code snippet shows you how to clone a slide and insert the cloned slide into a specified section.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Creation-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.java" >}}



## **Changing the Position of a Slide**
{{% alert color="primary" %}} 

If you create a presentation using **MS PowerPoint**, you would have experienced that whenever you add a new slide to your presentation, it is appended at the end of the presentation by default. Using **MS PowerPoint**, you can drag a selected slide to any other position of the presentation. Aspose.Slides for Java also allows developers to change the position of a slide within the presentation. Let's see how to get it done.

{{% /alert %}} 

It's very simple to change the position of a slide in the presentation. Just follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Change the SlideNumber of the referenced slide.
- Write the modified presentation file.

In the example given below, we have changed the position of a slide (lying at the zero index position 1) of the presentation) to index 1 (Position 2).

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-ChangingThePositionOfASlide-ChangingThePositionOfASlide.java" >}}


The example above moves the slide (that was at position 1 to the second position and the slide that was at a second position, is moved to the first position and so on. In this way, all slides are adjusted automatically by Aspose.Slides for Java.
