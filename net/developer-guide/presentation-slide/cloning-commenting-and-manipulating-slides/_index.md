---
title: Cloning, Commenting and Manipulating Slides
type: docs
weight: 20
url: /net/cloning-commenting-and-manipulating-slides/
---

## **Cloning Slides**
Cloning is the process of making an exact copy or replica of something. Aspose.Slides for .NET also makes it possible to make a copy or clone of any slide and then insert that cloned slide to the current or any other opened presentation. The process of slide cloning creates a new slide that can be modified by developers without changing the original slide. There are several possible ways to clone a slide:

- Clone at End within a Presentation.
- Clone at Another Position within Presentation.
- Clone at End in another Presentation.
- Clone at Another Position in another Presentation.
- Clone at a specific position in another Presentation.

In Aspose.Slides for .NET, (a collection of [ISlide](https://apireference.aspose.com/net/slides/aspose.slides/islide) objects) exposed by the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) object provides the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) and [InsertClone](https://apireference.aspose.com/net/slides/aspose.slides.ishapecollection/insertclone/methods/1) methods to perform the above types of slide cloning
### **Clone at End within a Presentation**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method according to the steps listed below:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) class by referencing the Slides collection exposed by the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) object.
1. Call the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method exposed by the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) object and pass the slide to be cloned as a parameter to the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method.
1. Write the modified presentation file.

In the example given below, we have cloned a slide (lying at the first position – zero index – of the presentation) to the end of the presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cs" >}}
### **Clone at Another Position with in Presentation.**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the [InsertClone](https://apireference.aspose.com/net/slides/aspose.slides.ishapecollection/insertclone/methods/1) method:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Instantiate the class by referencing the **Slides** collection exposed by the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) object.
1. Call the [InsertClone](https://apireference.aspose.com/net/slides/aspose.slides.ishapecollection/insertclone/methods/1) method exposed by the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) object and pass the slide to be cloned along with the index for the new position as a parameter to the [InsertClone](https://apireference.aspose.com/net/slides/aspose.slides.ishapecollection/insertclone/methods/1) method.
1. Write the modified presentation as a PPTX file.

In the example given below, we have cloned a slide (lying at the zero index – position 1 – of the presentation) to index 1 – Position 2 – of the presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-CloneWithInSamePresentation-CloneWithInSamePresentation.cs" >}}
### **Clone at End in another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at the end of the existing slides:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the destination presentation that the slide will be added to.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) class by referencing the **Slides** collection exposed by the Presentation object of the destination presentation.
1. Call the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method exposed by the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) object and pass the slide from the source presentation as a parameter to the [AddClone](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection/methods/addclone/index) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the first index of the source presentation) to the end of the destination presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-CloneAtEndOfAnother-CloneAtEndOfAnother.cs" >}}
### **Clone at Another Position in another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class containing the presentation the slide will be added to.
1. Instantiate the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) class by referencing the Slides collection exposed by the Presentation object of the destination presentation.
1. Call the [InsertClone](https://apireference.aspose.com/net/slides/aspose.slides.ishapecollection/insertclone/methods/1) method exposed by the [ISlideCollection](https://apireference.aspose.com/net/slides/aspose.slides/islidecollection) object and pass the slide from the source presentation along with the desired position as a parameter to the [InsertClone](https://apireference.aspose.com/net/slides/aspose.slides.ishapecollection/insertclone/methods/1) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to index 1 (position 2) of the destination presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-CRUD-CloneAtEndOfAnother-CloneAtEndOfAnother.cs" >}}
### **Clone at specific position in another Presentation**
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
## **Extracting Video From A Slide**
Aspose.Slides for .NET supports extracting video from the slide. In order to extract the video. Please follow the steps below:

- Load a Presentation containing a video.
- Loop through all the slides of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation).
- Search for Video Frame.
- Save the Video to disk.
  In the example given below, we have saved the video file from a slide.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Media-ExtractVideo-ExtractVideo.cs" >}}
## **Support for managing Header/Footer in handout and notes slides**
Aspose.Slides for .NET supports Header and Footer in Handout and notes slides. Please follow the steps below:

- Load a [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)containing a video.
- Change Header and Footer settings for notes master and all notes slides.
- Set master notes slide and all child Footer placeholders visible.
- Set master notes slide and all child Date and time placeholders visible.
- Change Header and Footer settings for first notes slide only.
- Set notes slide Header placeholder visible.
- Set text to notes slide Header placeholder.
- Set text to notes slide Date-time placeholder.
- Write the modified presentation file.

Code Snippet provided in the below Example.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Notes-HeaderAndFooterInNotesSlide-HeaderAndFooterInNotesSlide.cs" >}}
## **Managing Hyperlinks in Presentation**
Aspose.Slides for .NET allows developers to manage the hyperlinks in presentation on the presentation, slide and text frame level. The [IHyperlinkQueries](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries) class helps to manage hyperlinks in a presentation.
### **Supported Properties in IHyperlinkQueries**
The IHyperlinkQueries class can be accessed from the presentation, slide and text frame that the hyperlink is defined for.

- [IPresentation.HyperlinkQueries](https://apireference.aspose.com/net/slides/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://apireference.aspose.com/net/slides/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://apireference.aspose.com/net/slides/aspose.slides/itextframe/properties/hyperlinkqueries)

The IHyperlinkQueries class supports the following methods and properties.

- [IHyperlinkQueries.GetHyperlinkClicks();](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)
### **Removing Hyperlinks inside Presentation**
To remove hyperlinks from a presentation on the presentation level:

1. Create an instance of the Presentation class and access the desired presentation.
1. Remove the hyperlinks in the presentation on the presentation level by accessing [IPresentation.HyperlinkQueries](https://apireference.aspose.com/net/slides/aspose.slides/ipresentation/properties/hyperlinkqueries) and calling the [RemoveAllHyperlinks()](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks) method.
1. Apply a slide transition effect on a slide.
1. Write the modified presentation as a [PPTX](https://wiki.fileformat.com/presentation/pptx/) file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Transitions-BetterSlideTransitions-BetterSlideTransitions.cs" >}}


### **Add Hyperlink inside Presentation**
To add a hyperlink in a presentation on the presentation level:

1. Create an instance of the Presentation class and access the desired presentation.
1. Add an AutoShape of Rectangle type using [AddAutoShape](https://apireference.aspose.com/net/slides/aspose.slides/shapecollection/methods/addautoshape) method exposed by Shapes object.
1. Add hyperlink.
1. Save the presentation as a PPTX file.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Slides-Hyperlinks-AddHyperlink-AddHyperlink.cs" >}}


### **Mutable Hyperlink**
[Hyperlink](https://apireference.aspose.com/net/slides/aspose.slides/hyperlink) class changed to be mutable. Now it is possible to change values of the following properties which were read-only before:

- [IHyperlink.TargetFrame](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/highlightclick)
- [IHyperlink.StopSoundOnClick](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/stopsoundonclick)

The code snippet below shows adding a hyperlink to the slide and editing its tooltip later:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Slides-Hyperlinks-MutableHyperlink-MutableHyperlink.cs" >}}


### **Set Hyperlink Color**
A new property [ColorSource](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink/properties/colorsource) has been added to [IHyperlink](https://apireference.aspose.com/net/slides/aspose.slides/ihyperlink) interface and Hyperlink class.

It allows to get or set the source of hyperlink color, which could be obtained either from slide/presentation styles or corresponding PortionFormat properties. This is a new feature of PowerPoint 2019 and any changes made to this property will take affect only in PowerPoint 2019 or higher versions.

The code snippet below shows a sample of adding two hyperlinks with different colors to the same slide:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Slides-Hyperlinks-SetHyperLinkColor-SetHyperLinkColor.cs" >}}
