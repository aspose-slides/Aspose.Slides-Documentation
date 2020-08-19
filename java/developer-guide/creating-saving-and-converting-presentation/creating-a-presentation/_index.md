---
title: Creating a Presentation
type: docs
weight: 20
url: /java/creating-a-presentation/
---

## **Create a PowerPoint Presentation**
{{% alert color="primary" %}} 

In this simple application, we will create a PowerPoint presentation having **Hello World** text at a specified position of the slide.

{{% /alert %}} 

Please follow the steps below to create a PowerPoint presentation having Hello World text at a specified position of the slide.

1. Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class.
1. Obtain the reference of the first slide in the presentation which is created on instantiating the Presentation.
1. Add an [AutoShape](https://apireference.aspose.com/java/slides/com.aspose.slides/AutoShape) with ShapeType as Rectangle at a specified position of the slide.
1. Add a [TextFrame ](https://apireference.aspose.com/java/slides/com.aspose.slides/TextFrame)to the AutoShape containing Hello World as default text.
1. Change the Text Color to Black as it is white by default and is not visible on the slide with a white background.
1. Change the Line Color of the shape to white in order to hide the shape border.
1. Remove the default Fill Format of the shape.
1. Finally, write the presentation to the desired file format using the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object.
   The implementation of the above steps is demonstrated below in an example.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Creation-CreateAPresentation-CreateAPresentation.java" >}}

|**The above code snippet produces a PowerPoint presentation that contains only one slide having the Hello World text as shown below:**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/0fbYGsj.jpg)| |
## **Setting Default Zoom Value for Presentation**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports setting the default zoom value for presentation such that when the presentation is opened, zoom is set already. This could be done by setting the [ViewProperties](https://apireference.aspose.com/java/slides/com.aspose.slides/ViewProperties) of a presentation. SlideViewProperties as well as NotesViewProperties could be set programmatically. In this topic, we will see with an example how to set the View Properties of Presentation in [Aspose.Slides](https://docs.aspose.com/slides/).

{{% /alert %}} 

In order to set the view properties. Please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class.
1. Set View Properties of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation).
1. Write the presentation as a [PPTX ](https://wiki.fileformat.com/presentation/pptx/)file.
   In the example given below, we have set the zoom value for slide view as well as notes view.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Creation-SettingDefaultZoomValueForPresentation-SettingDefaultZoomValueForPresentation.java" >}}
## **Setting the Slide Number**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports, setting the Slide Number. In this topic, we will see with example how to get and set the slide number property in Aspose.Slides.

{{% /alert %}} 

The new methods added to [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class allow to get or to set the number of the first slide in a presentation. When a new FirstSlideNumber value is specified all slide numbers are recalculated. In order to get or set the Slide Number, please follow the steps below:

1. Create an instance of Presentation class
1. Get the slide number
1. Set the slide number
1. Write the presentation as a PPTX file
   In the example given below, we have get and set the slide number.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Creation-SettingTheSlideNumber-SettingTheSlideNumber.java" >}}




