---
title: Clone Slides
type: docs
weight: 40
url: /cpp/clone-slides/
---


## **Clone Slide in Presentation**
Cloning is the process of making an exact copy or replica of something. Aspose.Slides for C++ also makes it possible to make a copy or clone of any slide and then insert that cloned slide to the current or any other opened presentation. The process of slide cloning creates a new slide that can be modified by developers without changing the original slide. There are several possible ways to clone a slide:

- Clone at End within a Presentation.
- Clone at Another Position with in Presentation.
- Clone at End in another Presentation.
- Clone at Another Position in another Presentation.
- Clone at specific position in another Presentation.

In Aspose.Slides for C++, (a collection of [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) objects) exposed by the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) object provides the [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) and [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) methods to perform the above types of slide cloning

## **Clone at End within Presentation**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) method according to the steps listed below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Instantiate the [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) class by referencing the Slides collection exposed by the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) object.
1. Call the [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) method exposed by the [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) object and pass the slide to be cloned as a parameter to the [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) method.
1. Write the modified presentation file.

In the example given below, we have cloned a slide (lying at the first position – zero index – of the presentation) to the end of the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}


## **Clone at Another Position in Presentation**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) method:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Instantiate the class by referencing the **Slides** collection exposed by the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) object.
1. Call the [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) method exposed by the [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) object and pass the slide to be cloned along with the index for the new position as a parameter to the [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) method.
1. Write the modified presentation as a PPTX file.

In the example given below, we have cloned a slide (lying at the zero index – position 1 – of the presentation) to index 1 – Position 2 – of the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Clone Slide to End in Another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at the end of the existing slides:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class containing the presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class containing the destination presentation that the slide will be added to.
1. Instantiate the [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) class by referencing the **Slides** collection exposed by the Presentation object of the destination presentation.
1. Call the [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) method exposed by the [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) object and pass the slide from the source presentation as a parameter to the [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the first index of the source presentation) to the end of the destination presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clone Slide to Another Position in Another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class containing the presentation the slide will be added to.
1. Instantiate the [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) class by referencing the Slides collection exposed by the Presentation object of the destination presentation.
1. Call the [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) method exposed by the [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) object and pass the slide from the source presentation along with the desired position as parameter to the [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to index 1 (position 2) of the destination presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}
## **Clone Slide at Specific Position in Another Presentation**
If you need to clone a slide with master slide from one presentation from and use it in another presentation , you need to clone the desired master slide from source presentation to destination presentation first. Then you need to use that master slide for cloning slide with master slide. The **AddClone(ISlide, IMasterSlide)** expects master slide from destination presentation rather than from source presentation. In order to clone the slide with master, please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class containing the destination presentation the slide will be cloned to.
1. Access the slide to be cloned along with the master slide.
1. Instantiate the [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection) class by referencing the Masters collection exposed by the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) object of the destination presentation.
1. Call the [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) method exposed by the [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection) object and pass the master from the source PPTX to be cloned as parameter to the [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) method.
1. Instantiate the [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) class by setting the reference to the Slides collection exposed by the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) object of the destination presentation.
1. Call the [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) method exposed by the [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) object and pass the slide from the source presentation to be cloned and master slide as parameter to the [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide with master (lying at the zero index of the source presentation) to the end of the destination presentation using master from source slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}
## **Clone Slide to Specified Section**
If you want to clone a slide and then use it within the same presentation file but at a different section, then use the [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a46981dac8b18355531a04a70c70c444b) method exposed by the [**ISlideCollection** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection)interface. Aspose.Slides for C++ makes it possible to clone a slide from the first section and then insert that cloned slide to the second section of the same presentation.

The following code snippet shows you how to clone a slide and insert the cloned slide into a specified section.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

