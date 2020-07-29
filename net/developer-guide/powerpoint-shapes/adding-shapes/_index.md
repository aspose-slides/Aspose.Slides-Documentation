---
title: Adding Shapes
type: docs
weight: 10
url: /net/adding-shapes/
---

## **Adding Shapes**
Aspose.Slides for .NET supports adding different kinds of shapes to the slides. In this topic, we will start working with shapes by adding lines to the slides. Using Aspose.Slides for .NET, developers can not only create simple lines , but some fancy lines can also be drawn on the slides.
### **Add Plain Line**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using [AddAutoShape](https://apireference.aspose.com/net/slides/aspose.slides/ishapecollection/methods/addautoshape/index) method exposed by Shapes object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-AddPlainLineToSlide-AddPlainLineToSlide.cs" >}}
### **Add Arrow Shaped Line**
Aspose.Slides for .NET also allows developers to configure some properties of the line to make it look more appealing. Let's try to configure few properties of a line to make it look like an arrow. Please follow the steps below to do so:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object.
- Set the Line Style to one of the styles as offered by Aspose.Slides for .NET.
- Set the Width of the line.
- Set the [Dash Style](https://apireference.aspose.com/net/slides/aspose.slides/linedashstyle) of the line to one of the styles offered by Aspose.Slides for .NET.
- Set the [Arrow Head Style](https://apireference.aspose.com/net/slides/aspose.slides/linearrowheadstyle) and Length of the start point of the line.
- Set the Arrow Head Style and Length of the end point of the line.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cs" >}}
### **Add Picture Frame**
Picture frame is also one of the shapes offered by Aspose.Slides for .NET. Adding picture frame to a slide is bit trickier than simple shapes. A picture frame is like a picture in a frame. You can add any desired picture to your slide as a picture frame. Let's see, how can we do it.
This article explains how picture frames can be used in different ways:

- Adding Simple Picture Frames to Slides.
- Controlling Picture Frame Formatting.
- Adding Picture Frame with Relative Scale.

To add a simple picture frame to your slide, please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its index.
- Create an Image object by adding an image to the Images collection associated with the Presentation object that will be used to fill the Shape.
- Calculate the width and height of the image.
- Create a PictureFrame according to the width and height of the image by using the AddPictureFrame method exposed by the Shapes object associated with the referenced slide.
- Add a picture frame (containing the picture) to the slide.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-PictureFrameFormatting-PictureFrameFormatting.cs" >}}
### **Adding Picture Frame with Relative Scale**
The picture frame that we created in the above section were simple as well as well formatted. We can also control the relative scaling of image added in picture frame as well. In order to control the relative scaling of the image in a picture frame, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its index.
- Add an image to the presentation image collection.
- Create an [IPPImage](https://apireference.aspose.com/net/slides/aspose.slides/ippimage) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the shape.
- Set the relative width and height of the image in the picture frame.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-AddRelativeScaleHeightPictureFrame-AddRelativeScaleHeightPictureFrame.cs" >}}
### **Add Audio Frame**
Aspose.Slides for .NET allows developers to add audio files in their slides. These audio files are embedded in the slides as Audio Frames . An Audio Frame contains the embedded audio file. In this topic, we will discuss that how can developers embed audio frames in their slides using Aspose.Slides for .NET . To add an Embedded Audio Frame in a slide using Aspose.Slides for .NET , please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)
- Obtain the reference of a slide by using its Index
- Open the Audio File Stream to be embedded in the slide
- Add the Embedded Audio Frame (containing audio file) into the slide
- Set [PlayMode](https://apireference.aspose.com/net/slides/aspose.slides/audioplaymodepreset) and Volume exposed by [IAudioFrame](https://apireference.aspose.com/net/slides/aspose.slides/audioframe) object
- Write the modified presentation as a PPTX file

In the example given below, we have added an Embedded Audio Frame into the slide.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-AddAudioFrame-AddAudioFrame.cs" >}}
### **Add Embedded Video Frame**
Developers can also add and play video files in the slides to enrich their presentations. Aspose.Slides for .NET supports adding Video Frames to the slides that make it possible for developers to add videos to their presentations. This topic will help developers to follow the simple steps with examples for adding video frames in their slides. To add a Video Frame in a slide using Aspose.Slides for .NET, please follow the steps below:

1. Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
1. Obtain the reference of a slide by using its Index.
1. Add the Video Frame (containing the video file name) into the slide.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a Video Frame into the slide.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-EmbeddedVideoFrame-EmbeddedVideoFrame.cs" >}}
### **Adding Video Frame with Video from Web Source**
PowerPoint 2010 and newer versions support YouTube videos. To play these videos in PowerPoint make sure your [environment meet requirements ](https://support.office.com/en-us/article/Requirements-for-using-the-PowerPoint-YouTube-feature-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-US&rs=en-US&ad=US)for embedding videos from web source.

In order To add video from YouTube with Aspose.Slides, please use following code snippet:

1. Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class
1. Obtain the reference of a slide by using its Index
1. Add the Video Frame by passing video URL
1. Set Image for Video Frame
1. Save presentation as a PPTX file

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-AddVideoFrameFromWebSource-AddVideoFrameFromWebSource.cs" >}}
### **Add Video Frame**
Developers can also embed and play video files in the slides to enrich their presentations. Aspose.Slides for .NET supports adding Embedded Video Frames to the slides that make it possible for developers to add videos to their presentations. This topic will help developers to follow the simple steps with examples for adding video frames in their slides.

To add an Embedded Video Frame in a slide using Aspose.Slides for .NET, please follow the steps below:

1. Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class
1. Obtain the reference of a slide by using its Index
1. Add the Video Frame (containing the video file name) into the slide
1. Add the video to be embedded inside presentation Video collection using Video
1. Set embedded video to Video frame
1. Write the modified presentation as a PPTX file

In the example given below, we have added a Video Frame into the slide.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-AddVideoFrame-AddVideoFrame.cs" >}}
### **Add Ellipse**
In this topic, we will introduce developers about adding ellipse shapes to their slides using Aspose.Slides for .NET . Aspose.Slides for .NET provides an easier set of APIs to draw different kinds of shapes with just a few lines of code. To add a simple ellipse to a selected slide of the presentation, please follow the steps below:

1. Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class
1. Obtain the reference of a slide by using its Index
1. Add an AutoShape of Ellipse type using AddAutoShape method exposed by IShapes object
1. Write the modified presentation as a PPTX file

In the example given below, we have added an ellipse to the first slide.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-SimpleEllipse-SimpleEllipse.cs" >}}
### **Adding Formatted Ellipse**
To add a better formatted ellipse to a slide, please follow the steps below:

1. Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
1. Obtain the reference of a slide by using its Index.
1. Add an AutoShape of Ellipse type using AddAutoShape method exposed by IShapes object.
1. Set the Fill Type of the Ellipse to Solid.
1. Set the Color of the Ellipse using SolidFillColor.Color property as exposed by FillFormat object associated with the IShape object.
1. Set the Color of the lines of the Ellipse.
1. Set the Width of the lines of the Ellipse.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a formatted ellipse to the first slide of the presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-FormattedEllipse-FormattedEllipse.cs" >}}
### **Add Simple Rectangle**
Like previous topics, this one is also about adding a shape and this time the shape we will discuss about is Rectangle. In this topic, we have described that how developers can add simple or formatted rectangles to their slides using Aspose.Slides for .NET . To add a simple rectangle to a selected slide of the presentation, please follow the steps below:

1. Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
1. Obtain the reference of a slide by using its Index.
1. Add an IAutoShape of Rectangle type using AddAutoShape method exposed by IShapes object.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a simple rectangle to the first slide of the presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-SimpleRectangle-SimpleRectangle.cs" >}}
### **Add Formatted Rectangle**
To add a formatted rectangle to a slide, please follow the steps below:

1. Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
1. Obtain the reference of a slide by using its Index.
1. Add an IAutoShape of Rectangle type using AddAutoShape method exposed by IShapes object.
1. Set the Fill Type of the Rectangle to Solid.
1. Set the Color of the Rectangle using SolidFillColor.Color property as exposed by FillFormat object associated with the IShape object.
1. Set the Color of the lines of the Rectangle.
1. Set the Width of the lines of the Rectangle.
1. Write the modified presentation as PPTX file.
   The above steps are implemented in the example given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Shapes-FormattedRectangle-FormattedRectangle.cs" >}}
### **Add SVG Into Slide**
Now Aspose.Slides for .NET allows you to add Svg image into presentation image collection. The implementation is demonstrated in the example below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-InsertSvgIntoPresentation-InsertSvgIntoPresentation.cs" >}}
