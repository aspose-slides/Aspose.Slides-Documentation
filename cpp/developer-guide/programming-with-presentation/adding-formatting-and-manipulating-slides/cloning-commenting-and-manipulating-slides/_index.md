---
title: Cloning, Commenting and Manipulating Slides
type: docs
weight: 30
url: /cpp/cloning-commenting-and-manipulating-slides/
---

## **Cloning Slides**
Cloning is the process of making an exact copy or replica of something. Aspose.Slides for C++ also makes it possible to make a copy or clone of any slide and then insert that cloned slide to the current or any other opened presentation. The process of slide cloning creates a new slide that can be modified by developers without changing the original slide. There are several possible ways to clone a slide:

- Clone at End within a Presentation.
- Clone at Another Position with in Presentation.
- Clone at End in another Presentation.
- Clone at Another Position in another Presentation.
- Clone at specific position in another Presentation.

In Aspose.Slides for C++, (a collection of [ISlide](http://www.aspose.com/api/net/slides/aspose.slides/islide) objects) exposed by the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) object provides the [AddClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/index) and [InsertClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/insertclone/index) methods to perform the above types of slide cloning
### **Clone at End within a Presentation**
If you want to clone a slide and then use it within the same presentation file at the end of the existing slides, use the [AddClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/index) method according to the steps listed below:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Instantiate the [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) class by referencing the Slides collection exposed by the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) object.
1. Call the [AddClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/index) method exposed by the [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) object and pass the slide to be cloned as a parameter to the [AddClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/index) method.
1. Write the modified presentation file.

In the example given below, we have cloned a slide (lying at the first position – zero index – of the presentation) to the end of the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}
### **Clone at Another Position with in Presentation.**
If you want to clone a slide and then use it within the same presentation file but at a different position, use the [InsertClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/insertclone/index) method:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Instantiate the class by referencing the **Slides** collection exposed by the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) object.
1. Call the [InsertClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/insertclone/index) method exposed by the [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) object and pass the slide to be cloned along with the index for the new position as a parameter to the [InsertClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/insertclone/index) method.
1. Write the modified presentation as a PPTX file.

In the example given below, we have cloned a slide (lying at the zero index – position 1 – of the presentation) to index 1 – Position 2 – of the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}
### **Clone at End in another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at the end of the existing slides:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class containing the presentation the slide will be cloned from.
1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class containing the destination presentation that the slide will be added to.
1. Instantiate the [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) class by referencing the **Slides** collection exposed by the Presentation object of the destination presentation.
1. Call the [AddClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/index) method exposed by the [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) object and pass the slide from the source presentation as a parameter to the [AddClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/index) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the first index of the source presentation) to the end of the destination presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}
### **Clone at Another Position in another Presentation**
If you need to clone a slide from one presentation and use it in another presentation file, at a specific position:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class containing the presentation the slide will be added to.
1. Instantiate the [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) class by referencing the Slides collection exposed by the Presentation object of the destination presentation.
1. Call the [InsertClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/insertclone/index) method exposed by the [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) object and pass the slide from the source presentation along with the desired position as parameter to the [InsertClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/insertclone/index) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide (from the zero index of the source presentation) to index 1 (position 2) of the destination presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}
### **Clone at specific position in another Presentation**
If you need to clone a slide with master slide from one presentation from and use it in another presentation , you need to clone the desired master slide from source presentation to destination presentation first. Then you need to use that master slide for cloning slide with master slide. The **AddClone(ISlide, IMasterSlide)** expects master slide from destination presentation rather than from source presentation. In order to clone the slide with master, please follow the steps below:

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class containing the source presentation the slide will be cloned from.
1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class containing the destination presentation the slide will be cloned to.
1. Access the slide to be cloned along with the master slide.
1. Instantiate the [IMasterSlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/masterslidecollection) class by referencing the Masters collection exposed by the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) object of the destination presentation.
1. Call the [AddClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/index) method exposed by the [IMasterSlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/masterslidecollection) object and pass the master from the source PPTX to be cloned as parameter to the [AddClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/index) method.
1. Instantiate the [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) class by setting the reference to the Slides collection exposed by the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) object of the destination presentation.
1. Call the [AddClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/index) method exposed by the [ISlideCollection](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection) object and pass the slide from the source presentation to be cloned and master slide as parameter to the [AddClone](http://www.aspose.com/api/net/slides/aspose.slides/islidecollection/methods/index) method.
1. Write the modified destination presentation file.

In the example given below, we have cloned a slide with master (lying at the zero index of the source presentation) to the end of the destination presentation using master from source slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}


## **Clone Slide to Specified Section**
If you want to clone a slide and then use it within the same presentation file but at a different section, then use the [**AddClone()**](https://apireference.aspose.com/cpp/slides/class/aspose.slides.i_slide_collection/#a46981dac8b18355531a04a70c70c444b) method exposed by the [**ISlideCollection** ](https://apireference.aspose.com/cpp/slides/class/aspose.slides.i_slide_collection/)interface. Aspose.Slides for C++ makes it possible to clone a slide from the first section and then insert that cloned slide to the second section of the same presentation.

The following code snippet shows you how to clone a slide and insert the cloned slide into a specified section.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}
## **Extracting Video From A Slide**
Aspose.Slides for C++ supports extracting video from the slide. In order to extract the video. Please follow the steps below:

- Load a Presentation containing a video.
- Loop through all the slides of Presentation.
- Search for Video Frame.
- Save the Video to disk.
  In the example given below, we have saved the video file from a slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ExtractVideo-ExtractVideo.cpp" >}}
## **Working with Slide Comments**
Slide comment is like an annotation in PDF file or a note that one can attach with a slide. Slide comments are generally used while reviewing the slides in PowerPoint. However, they can also serve as a useful utility for highlighting something important in presentation slide and giving the needed explanation for that.
### **Adding Slide Comments**
In Aspose.Slides for C++, the presentation slide comment are associated with a particular author. The [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class holds the collection of authors in **ICommentAuthorCollection** that are responsible for adding slide comments. For each author, there is a collection of comments in **ICommentCollection**. The **IComment** class includes information like an author who added slide comment, time of creation, slide where a comment is added, the position of slide comment on the selected slide and the comment text. The **CommentAuthor** class includes the author's name, his initials and list of associated comments. In the following example, we have added the code snippet for adding the slide comments.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlideComments-AddSlideComments.cpp" >}}
### **Accessing Slide Comments**
In the following example, we will learn how to access the existing slide comments and can even modify the comments as well.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSlideComments-AccessSlideComments.cpp" >}}
### **Support For Comments Replies**
New **get_ParentComment()** and **set_ParentComment()** methods have been added to **IComment** and **Comment** classes. These methods allow to get or set the parent comment, thus creating a dialog in the form of a hierarchy of comments and replies.

The code snippet below shows a sample of adding some comments and some replies to them:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddParentComments-AddParentComments.cpp" >}}

**Attention: Remove** method of **IComment** interface removes the comment with all its replies.

**NOTE:** If setting **ParentComment** leads to a circular reference, the exception of type **PptxEditException** will be thrown.
## **Managing Slides Transitions**
Aspose.Slides for C++ also allows developers to manage or customize the slide transition effects of the slides. In this topic, we will discuss how can we control slide transitions with a great ease using Aspose.Slides for C++.
### **Managing Simple Slide Transitions**
To make it easier to understand, we have demonstrated the use of Aspose.Slides for C++ to manage simple slide transitions. Developers can not only apply different slide transition effects on the slides, but also customize the behavior of these transition effects.To create a simple slide transition effect, follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for C++ through TransitionType enum
1. Write the modified presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}
### **Managing Better Slide Transitions**
In the above section, we just applied a simple transition effect on the slide. Now, to make that simple transition effect even better and controlled, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Apply a Slide Transition Type on the slide from one of the transition effects offered by Aspose.Slides for C++
1. You can also set the transition to Advance On Click, after a specific time period or both.
1. If the slide transition is enabled to Advance On Click, the transition will only advance when someone will click the mouse. Moreover, if the Advance After Time property is set, the transition will advance automatically after the specified advance time will be passed.
1. Write the modified presentation as a presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}
### **Morph Transition**
Aspose.Slides for C++ now supports the Morph Transition. They represent new morph transition introduced in PowerPoint 2019. The Morph transition allows you to animate smooth movement from one slide to the next. This article describes the concept and how to use the Morph transition. To use the Morph transition effectively, you will need to have two slides with at least one object in common. The easiest way is to duplicate the slide and then move the object on the second slide to a different place.

The following code snippet shows you how to add a clone of the slide with some text to the presentation and set a transition of morph type to the second slide.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}


### **Morph Transition Types**
New Aspose.Slides.SlideShow.TransitionMorphType enum has been added. It represents different types of Morph slide transition.

TransitionMorphType enum has three members:

- ByObject: Morph transition will be performed considering shapes as indivisible objects.
- ByWord: Morph transition will be performed with transferring text by words where possible.
- ByChar: Morph transition will be performed with transferring text by characters where possible.

The following code snippet shows you how to set morph transition to slide and change morph type:





{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}




## **Managing Hyperlinks in Presentation**
Aspose.Slides for C++ allows developers to manage the hyperlinks in presentation on the presentation, slide and text frame level. The IHyperlinkQueries class helps to manage hyperlinks in a presentation.
### **Supported Properties in IHyperlinkQueries**
The IHyperlinkQueries class can be accessed from the presentation, slide and text frame that the hyperlink is defined for.

- [IPresentation.HyperlinkQueries](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](http://www.aspose.com/api/net/slides/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](http://www.aspose.com/api/net/slides/aspose.slides/itextframe/properties/hyperlinkqueries)

The IHyperlinkQueries class supports the following methods and properties.

- [IHyperlinkQueries.GetHyperlinkClicks();](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)
### **Removing Hyperlinks inside Presentation**
To remove hyperlinks from a presentation on the presentation level:

1. Create an instance of the Presentation class and access the desired presentation.
1. Remove the hyperlinks in the presentation on the presentation level by accessing [IPresentation.HyperlinkQueries](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries) and calling the [RemoveAllHyperlinks()](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks) method.
1. Write the modified presentation as a PPTX file.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-Hyperlinks-RemoveHyperlinks.cpp" >}}




### **Add Hyperlink inside Presentation**
To add hyperlink in a presentation on the presentation level:

1. Create an instance of the Presentation class and access the desired presentation.
1. Add an AutoShape of Rectangle type using AddAutoShape method exposed by Shapes object.
1. Add hyperlink.
1. Save presentation as a PPTX file.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddHyperlink-AddHyperlink.cpp" >}}


### **Mutable Hyperlink**
Hyperlink class changed to be mutable. Now it is possible to use the following methods:

- Hyperlink::set_TargetFrame()
- Hyperlink::set_Tooltip()
- Hyperlink::set_History()
- Hyperlink::set_HighlightClick()
- Hyperlink::set_StopSoundOnClick()

The code snippet below shows adding a hyperlink to the slide and editing its tooltip later:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-MutableHyperlink-MutableHyperlink.cpp" >}}


### **Set Hyperlink Color**
New get_ColorSource() and set_ColorSource() methods have been added to IHyperlink and Hyperlink classes.

These methods allow to get or set the source of hyperlink color, which could be obtained either from slide/presentation styles or corresponding PortionFormat properties. This is a new feature of PowerPoint 2019 and any changes made to this property will take affect only in PowerPoint 2019 or higher versions.



The code snippet below shows a sample of adding two hyperlinks with different colors to the same slide:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetHyperlinkColor-SetHyperlinkColor.cpp" >}}
