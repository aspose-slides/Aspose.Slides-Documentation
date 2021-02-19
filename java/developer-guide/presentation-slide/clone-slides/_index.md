---
title: Clone Slides
type: docs
weight: 40
url: /java/clone-slides/
---


## **Clone Slide in Presentation**
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
## **Clone Slide to End**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [**addClone** ](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)method according to the steps listed below:

1. Create an instance of the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) class by referencing the slides collection exposed by the Presentation object.
1. Call the **addClone** method exposed by the [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) object and pass the slide to be cloned as a parameter to the **addClone** method.
1. Write the modified presentation file.

In the example given below, we have cloned a slide (lying at the first position – zero index – of the presentation) to the end of the presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-CloningASlideFromOnePositionToTheEndWithinSamePresentation-CloningASlideFromOnePositionToTheEndWithinSamePresentation.java" >}}
## **Clone Slide to Another Position**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the **insertClone** method:

1. Create an instance of the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) class by referencing the Slides collection exposed by the Presentation object.
1. Call the [**insertClone** ](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)method exposed by the [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) object and pass the slide to be cloned along with the index for the new position as a parameter to the **insertClone** method.
1. Write the modified presentation as a [PPTX ](https://wiki.fileformat.com/presentation/pptx/)file.

In the example given below, we have cloned a slide (lying at the zero index – position 1 – of the presentation) to index 1 – Position 2 – of the presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-CloningASlideFromOnePositionToAnotherWithinSamePresentation-CloningASlideFromOnePositionToAnotherWithinSamePresentation.java" >}}


## **Clone Slide to Specified Section**
If you want to clone a slide and then use it within the same presentation file but at a different section, then use the [**addClone()**](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) method exposed by the [**ISlideCollection** ](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection)interface. Aspose.Slides for Java makes it possible to clone a slide from the first section and then insert that cloned slide to the second section of the same presentation.

The following code snippet shows you how to clone a slide and insert the cloned slide into a specified section.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Creation-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.java" >}}


## **Clone Slide from Another Presentation to End**
If you need to clone a slide from one presentation and use it in another presentation file at the end of the existing slides:

1. Create an instance of the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class containing the presentation the slide will be cloned from.
1. Create an instance of the Presentation class containing the destination presentation that the slide will be added to.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) class by referencing the Slides collection exposed by the Presentation object of the destination presentation.
1. Call the [**addClone** ](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)method exposed by the ISlideCollection object and pass the slide from the source presentation as a parameter to the **addClone** method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to the end of the destination presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-CloningASlideFromOnePresentationToAnotherAtTheEnd-CloningASlideFromOnePresentationToAnotherAtTheEnd.java" >}}


## **Clone Slide from Another Presentation to Specified Position**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. Create an instance of the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the Presentation class containing the presentation the slide will be added to.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection) class by referencing the Slides collection exposed by the Presentation object of the destination presentation.
1. Call the [**insertClone**](https://apireference.aspose.com/java/slides/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) method exposed by the ISlideCollection object and pass the slide from the source presentation along with the desired position as a parameter to the **InsertClone** method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to index 1 (position 2) of the destination presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-CloningASlideFromOnePresentationToAnotherAtASpecifiedPosition-CloningASlideFromOnePresentationToAnotherAtASpecifiedPosition.java" >}}


## **Clone Slide with Master Slide from Another Presentation**
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

