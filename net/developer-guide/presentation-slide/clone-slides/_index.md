---
title: Clone Slides
type: docs
weight: 40
url: /net/clone-slides/
---

## **Clone Slides in Presentation**
Cloning is the process of making an exact copy or replica of something. Aspose.Slides for .NET also makes it possible to make a copy or clone of any slide and then insert that cloned slide to the current or any other opened presentation. The process of slide cloning creates a new slide that can be modified by developers without changing the original slide. There are several possible ways to clone a slide:

- Clone at End within a Presentation.
- Clone at Another Position within Presentation.
- Clone at End in another Presentation.
- Clone at Another Position in another Presentation.
- Clone at a specific position in another Presentation.

In Aspose.Slides for .NET, (a collection of [ISlide](https://apireference.aspose.com/net/slides/aspose.slides/islide) objects) exposed by the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) object provides the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) and [InsertClone](https://apireference.aspose.com/net/slides/aspose.slides.ishapecollection/insertclone/methods/1) methods to perform the above types of slide cloning
## **Clone at End within a Presentation**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method according to the steps listed below:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) class by referencing the Slides collection exposed by the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) object.
1. Call the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method exposed by the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) object and pass the slide to be cloned as a parameter to the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method.
1. Write the modified presentation file.

In the example given below, we have cloned a slide (lying at the first position – zero index – of the presentation) to the end of the presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cs" >}}
## **Clone at Another Position with in Presentation**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the [InsertClone](https://apireference.aspose.com/net/slides/aspose.slides.ishapecollection/insertclone/methods/1) method:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Instantiate the class by referencing the **Slides** collection exposed by the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) object.
1. Call the [InsertClone](https://apireference.aspose.com/net/slides/aspose.slides.ishapecollection/insertclone/methods/1) method exposed by the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) object and pass the slide to be cloned along with the index for the new position as a parameter to the [InsertClone](https://apireference.aspose.com/net/slides/aspose.slides.ishapecollection/insertclone/methods/1) method.
1. Write the modified presentation as a PPTX file.

In the example given below, we have cloned a slide (lying at the zero index – position 1 – of the presentation) to index 1 – Position 2 – of the presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-CloneWithInSamePresentation-CloneWithInSamePresentation.cs" >}}
## **Clone at End in another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at the end of the existing slides:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the destination presentation that the slide will be added to.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) class by referencing the **Slides** collection exposed by the Presentation object of the destination presentation.
1. Call the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method exposed by the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) object and pass the slide from the source presentation as a parameter to the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the first index of the source presentation) to the end of the destination presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-CloneAtEndOfAnother-CloneAtEndOfAnother.cs" >}}
## **Clone at Another Position in another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the presentation the slide will be added to.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) class by referencing the Slides collection exposed by the Presentation object of the destination presentation.
1. Call the [InsertClone](https://apireference.aspose.com/net/slides/aspose.slides.ishapecollection/insertclone/methods/1) method exposed by the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) object and pass the slide from the source presentation along with the desired position as a parameter to the [InsertClone](https://apireference.aspose.com/net/slides/aspose.slides.ishapecollection/insertclone/methods/1) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to index 1 (position 2) of the destination presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-CloneAtEndOfAnother-CloneAtEndOfAnother.cs" >}}
## **Clone at specific position in another Presentation**
If you need to clone a slide with a master slide from one presentation from and use it in another presentation, you need to clone the desired master slide from source presentation to destination presentation first. Then you need to use that master slide for cloning slide with master slide. The **AddClone(ISlide, IMasterSlide)** expects a master slide from destination presentation rather than from source presentation. In order to clone the slide with a master, please follow the steps below:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the destination presentation the slide will be cloned to.
1. Access the slide to be cloned along with the master slide.
1. Instantiate the [IMasterSlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/imasterslidecollection) class by referencing the Masters collection exposed by the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) object of the destination presentation.
1. Call the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method exposed by the [IMasterSlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/imasterslidecollection) object and pass the master from the source PPTX to be cloned as a parameter to the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) class by setting the reference to the Slides collection exposed by the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) object of the destination presentation.
1. Call the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method exposed by the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) object and pass the slide from the source presentation to be cloned and master slide as a parameter to the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide with a master (lying at the zero index of the source presentation) to the end of the destination presentation using a master from source slide.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cs" >}}
