---
title: Picture Frame
type: docs
weight: 10
url: /java/picture-frame/
---

{{% alert color="primary" %}} 

Picture frame is also one of the shapes offered by Aspose.Slides for Java. Adding picture frame to a slide is bit trickier than simple shapes. A picture frame is like a picture in a frame. You can add any desired picture to your slide as a picture frame. Let's see, how can we do it.

{{% /alert %}} 


## **Add Picture Frame to Slide**
To add a simple picture frame to your slide, please follow the steps below:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its index.
1. Create an **Image** object by adding an image to the **Images** collection associated with the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object that will be used to fill the **Shape**.
1. Calculate the width and height of the image.
1. Create a [PictureFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/PictureFrame) according to the width and height of the image by using the **addPictureFrame** method exposed by the **Shapes** object associated with the referenced slide.
1. Add a picture frame (containing the picture) to the slide.
1. Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingSimplePictureFramesToSlides-AddingSimplePictureFramesToSlides.java" >}}


The code snippet above adds a simple picture frame to the slide as shown below:

|![todo:image_alt_text](http://i.imgur.com/IBj7awt.jpg)|
| :- |
|**Figure: Picture frame added to a slide**|

## **Add Picture Frame with Relative Scale**
The picture frame that we created in the above section were simple as well as well formatted. We can also control the relative scaling of image added in picture frame as well. In order to control the relative scaling of the image in a picture frame, please follow the steps below:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its index.
1. Add an image to the presentation image collection.
1. Create an [IPPImage](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPPImage) object by adding an image to the **Images** collection associated with the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object that will be used to fill the shape.
1. Set the relative width and height of the image in the picture frame.
1. Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingPictureFrameWithRelativeScale-AddingPictureFrameWithRelativeScale.java" >}}

## **Picture Frame Formatting**
The picture frame that we created in the above section is simple. We can also control the formatting of a picture frame according to the requirement. There are many formatting settings that can be applied on a picture frame. To control the formatting of a picture frame in a slide, please follow the steps below:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its index.
1. Create an [IPPImage](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPPImage) object by adding an image to the **Images** collection associated with the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object that will be used to fill the shape.
1. Calculate the width and height of image.
1. Create a [PictureFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/PictureFrame) according to the width and height of the image by using the **addPictureFrame** method exposed by the **IShapes** object associated with the referenced slide.
1. Add the picture frame (containing the picture) to the slide.
1. Set the picture frame's line color.
1. Set the picture frame's line width.
1. Rotate the picture frame by giving it either a positive or negative value. A positive value rotates it clockwise; a negative value rotates it anti-clockwise.
1. Add the picture frame (containing the picture) to the slide.
1. Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ControllingPictureFrameFormatting-ControllingPictureFrameFormatting.java" >}}


The code above adds a more controlled formatted Picture Frame to the slide as shown below:

|![todo:image_alt_text](http://i.imgur.com/1Jc15Vl.jpg)|
| :- |
|**Figure: Formatted picture frame added to a slide**|
