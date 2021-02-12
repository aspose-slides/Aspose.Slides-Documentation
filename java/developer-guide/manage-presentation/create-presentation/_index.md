---
title: Create Presentation
type: docs
weight: 20
url: /java/create-presentation/
---

## **Create PowerPoint Presentation**
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





