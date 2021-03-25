---
title: Picture Frame
type: docs
weight: 10
url: /cpp/picture-frame/
---


## **Create Picture Frame**
Picture frame is also one of the shapes offered by Aspose.Slides for C++. Adding picture frame to a slide is bit trickier than simple shapes. A picture frame is like a picture in a frame. You can add any desired picture to your slide as a picture frame. Let's see, how can we do it.
This article explains how picture frames can be used in different ways:

- Adding Simple Picture Frames to Slides.
- Controlling Picture Frame Formatting.
- Adding Picture Frame with Relative Scale.

To add a simple picture frame to your slide, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its index.
- Create an Image object by adding an image to the Images collection associated with the Presentation object that will be used to fill the Shape.
- Calculate the width and height of the image.
- Create a PictureFrame according to the width and height of the image by using the AddPictureFrame method exposed by the Shapes object associated with the referenced slide.
- Add a picture frame (containing the picture) to the slide.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-PictureFrameFormatting-PictureFrameFormatting.cpp" >}}

## **Create Picture Frame with Relative Scale**
The picture frame that we created in the above section were simple as well as well formatted. We can also control the relative scaling of image added in picture frame as well. In order to control the relative scaling of the image in a picture frame, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its index.
- Add an image to the presentation image collection.
- Create an [IPPImage](http://www.aspose.com/api/net/slides/aspose.slides/ippimage) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the shape.
- Set the relative width and height of the image in the picture frame.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddRelativeScaleHeightPictureFrame-AddRelativeScaleHeightPictureFrame.cpp" >}}


## **Picture Frame Formatting**
The picture frame that we created in the above section is simple. We can also control the formatting of a picture frame according to the requirement. There are many formatting settings that can be applied on a picture frame. To control the formatting of a picture frame in a slide, please follow the steps below:

- Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its index.
- Create an [IPPImage](http://www.aspose.com/api/net/slides/aspose.slides/ippimage) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the shape.
- Calculate the width and height of the image.
- Create a PictureFrame according to the width and height of the image by using the [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) method exposed by the [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) object associated with the referenced slide.
- Add the picture frame (containing the picture) to the slide.
- Set the picture frame's line color.
- Set the picture frame's line width.
- Rotate the picture frame by giving it either a positive or negative value.
- A positive value rotates it clockwise; a negative value rotates it anti-clockwise.
- Add the picture frame (containing the picture) to the slide.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-PictureFrameFormatting-PictureFrameFormatting.cpp" >}}