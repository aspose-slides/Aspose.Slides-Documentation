---
title: Adding Frame to the Slide
type: docs
weight: 10
url: /java/adding-frame-to-the-slide/
---

## **Adding Picture Frame to the Slide**
{{% alert color="primary" %}} 

Picture frame is also one of the shapes offered by Aspose.Slides for Java. Adding picture frame to a slide is bit trickier than simple shapes. A picture frame is like a picture in a frame. You can add any desired picture to your slide as a picture frame. Let's see, how can we do it.

{{% /alert %}} 

This article explains how picture frames can be used in different ways:
### **Adding Simple Picture Frame to the Slide**
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
### **Controlling Picture Frame Formatting**
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
### **Adding Picture Frame with Relative Scale**
The picture frame that we created in the above section were simple as well as well formatted. We can also control the relative scaling of image added in picture frame as well. In order to control the relative scaling of the image in a picture frame, please follow the steps below:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its index.
1. Add an image to the presentation image collection.
1. Create an [IPPImage](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPPImage) object by adding an image to the **Images** collection associated with the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) object that will be used to fill the shape.
1. Set the relative width and height of the image in the picture frame.
1. Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingPictureFrameWithRelativeScale-AddingPictureFrameWithRelativeScale.java" >}}
### **Add SVG into Slide**
Now Aspose.Slides for Java allows you to add SVG image into presentation image collection. The implementation is demonstrated in the example below.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-CRUD-InsertSvgIntoSlide-InsertSvgIntoSlide.java" >}}
## **Adding Audio Frame to the Slide**
{{% alert color="primary" %}} 

Aspose.Slides for Java allows developers to add audio files in their slides. These audio files are embedded in the slides as **Audio Frames**. An Audio Frame contains the embedded audio file. In this topic, we will discuss that how can developers embed audio frames in their slides using Aspose.Slides for Java.

{{% /alert %}} 

To add an Embedded Audio Frame in a slide using Aspose.Slides for Java, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Open the Audio File Stream to be embedded in the slide.
- Add the Embedded Audio Frame (containing audio file) into the slide.
- Set PlayMode and Volume exposed by [IAudioFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IAudioFrame) object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added an Embedded Audio Frame in the slide.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingAudioFrameToSlide-AddingAudioFrameToSlide.java" >}}


The above code snippet adds an Embedded Audio Frame to the slide as shown below:

|![todo:image_alt_text](http://i.imgur.com/wlQAEZC.jpg)|
| :- |
|**Figure: Audio Frame embedded in the slide**|
Audio Frame appears on the slide as an icon of speaker. To play this audio file, you can right click on the shape and select Preview as shown below in the figure:

|![todo:image_alt_text](http://i.imgur.com/bnOfI4E.jpg)|
| :- |
|**Figure: Playing embedded sound in the slide**|
## **Add Images as EMF in Slides**
Aspose.Slides for Java provides a facility that generates EMF image of excel sheet and add the image as EMF in slides with the help of Aspose.Cells. The sample code is implemented in the example given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ImageAsEMF-ImageAsEMF.java" >}}
## **Adding Video Frame to the Slide**
{{% alert color="primary" %}} 

Developers can also add and play video files in the slides to enrich their presentations. Aspose.Slides for Java supports adding **Video Frames** to the slides that make it possible for developers to add videos to their presentations. This topic will help developers to follow the simple steps with examples for adding video frames in their slides.

{{% /alert %}} 

To add a **Video Frame** in a slide using Aspose.Slides for Java, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add the Video Frame (containing the video file name) into the slide.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a **Video Frame** into the slide.



{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingVideoFramesToSlides-AddingVideoFramesToSlides.java" >}}

|![todo:image_alt_text](http://i.imgur.com/1xW1eHt.jpg)|
| :- |
|**Figure: Video Frame added into the slide**|
**Video Frame** appears on the slide as a media player. To play this video file, you can right click on the shape and select Preview as shown below in the figure:

|![todo:image_alt_text](http://i.imgur.com/JNtlePA.jpg)|
| :- |
|**Figure: Playing video in the slide**|
### **Setting image on a video frame**
To set image on a video frame, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add the Video Frame (containing the video file name) into the slide.
- Set image for videoframe.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-SettingImageOnAVideoFrame-SettingImageOnAVideoFrame.java" >}}
## **Adding an Embedded Video Frame to the Slide**
{{% alert color="primary" %}} 

Developers can also embed and play video files in the slides to enrich their presentations. Aspose.Slides for Java supports adding **Embedded Video Frames** to the slides that make it possible for developers to add videos to their presentations. This topic will help developers to follow the simple steps with examples for adding video frames in their slides.

{{% /alert %}} 

To add an **Embedded Video Frame** in a slide using Aspose.Slides for Java, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add the Video Frame (containing the video file name) into the slide.
- Add the video to be embedded inside presentation Video collection using **Video**.
- Set embedded video to Video frame* Write the modified presentation as a PPTX file.

In the example given below, we have added a **Video Frame** into the slide.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingAnEmbeddedVideoFrameToSlide-AddingAnEmbeddedVideoFrameToSlide.java" >}}


**Video Frame** appears on the slide as a media player and video gets embedded in presentation. To play this video file, you can right click on the shape and select Preview as shown below in the figure:

|![todo:image_alt_text](http://i.imgur.com/Rvy1rAK.png)|
| :- |
|**Figure: Playing video in the slide**|
## **Adding Video Frame with Video from Web Source**
PowerPoint 2010 and newer versions support YouTube videos. To play these videos in PowerPoint make sure your [environment meet requirements](https://support.office.com/en-us/article/Requirements-for-using-the-PowerPoint-YouTube-feature-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-US&rs=en-US&ad=US) for embedding videos from web source.
In order To add video from YouTube with Aspose.Slides, please use following code snippet:

1. Create an instance of Presentation class
1. Obtain the reference of a slide by using its Index
1. Add the Video Frame by passing video URL
1. Set Image for Video Frame
1. Save presentation as a PPTX file

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingVideoFrameWithVideoFromWebSource-AddingVideoFrameWithVideoFromWebSource.java" >}}
## **Working with OLE Object Frames**
{{% alert color="primary" %}} 

OLE stands for **Object Linking & Embedding**. It's a Microsoft technology that allows objects created in one application to be embedded in another application. For example, you can create a chart in an Excel Worksheet and then embed that chart object into your PowerPoint slide. After the chart object is embedded, you just double click the object and the chart object will be opened in editable form as you see in MS Excel. Aspose.Slides for Java supports adding OLE Objects to the slides in the form of **OLE Object Frames**. In this topic, we will work with **OLE Object Frames** to see that how can we add and access these objects to and from slides using Aspose.Slides for Java.

{{% /alert %}} 

This article explains different examples of working with Ole frames:
### **Adding an OLE Object Frame to the Slide**
Suppose, you have created a **Microsoft Excel Chart** in an Excel file and want to embed that chart object in a slide as an **OLE Object Frame** using Aspose.Slides for Java. Then you can do that using the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Open the Excel file containing Microsoft Excel Chart object and save it to MemoryStream.
- Add the OLE Object Frame to the slide containing the array of bytes and other information about the OLE object.
- Write the modified presentation as a PPTX file.

In the example given below, a **Microsoft Excel Chart** object in an Excel file is added to a slide as an **OLE Object Frame** using Aspose.Slides for Java.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingAnOLEObjectFrameToASlide-AddingAnOLEObjectFrameToASlide.java" >}}


The above code snippet adds an**OLE Object Frame** to a slide as shown below in the figure:

|![todo:image_alt_text](http://i.imgur.com/xCIIi5m.jpg)|
| :- |
|**Figure: Microsoft Excel Chart object added to a slide**|
### **Accessing an OLE Object Frame from the Slide**
If an OLE object is already embedded in a slide, you can access that object easily using Aspose.Slides for Java. Please follow the steps below to find or access an OLE object from a slide:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Access the OLE Object Frame shape (in this example, we have used the PPTX created above which has only one shape at first slide) and typecast that object as an OLE Object Frame. This was the desired OLE Object Frame to be accessed.
- Once the OLE Object Frame is accessed, you can perform any operation on it.

In the example given below, an **OLE Object Frame** (that is a **Microsoft Excel Chart** object embedded in a slide) is accessed and then all of its **Object Data** is written to an Excel file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AccessingAnOLEObjectFrameFromASlide-AccessingAnOLEObjectFrameFromASlide.java" >}}
### **Set File Type for an Embedding Object**
Using Aspose.Slides for Java you can set file type for an embedding object. For this purpose, new methods **addOleObjectFrame** and **insertOleObjectFrame** have been added into **IShapeCollection**.

These methods allow to get **IOleEmbeddedDataInfo** object as a parameter so now OLE object knows its type and PowerPoint can open created OLE objects.

The following example shows how to set file type for an embedding object:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-SetFileTypeForAnEmbeddingObject-SetFileTypeForAnEmbeddingObject.java" >}}


### **Extract Embedded Files from OLE Object**
Aspose.Slides for Java supports extracting embedded files from OLE Object. In order to extract embedded files, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class and Load a presentation contains OLE Object
- Loop through all the shapes in a presentation and access the OLE Object Frame shape
- Access the data of the Embedded file from OLE Object Frame and write it to disk

The implementation of the above steps is demonstrated in the example below.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ExtractEmbeddedFileDataFromOLEObject-ExtractEmbeddedFileDataFromOLEObject.java" >}}
## **Getting Paragraph and Portion coordinates in a TextFrame**
{{% alert color="primary" %}} 

Using Aspose.Slides for Java, developers can now get the rectangular coordinates for Paragraph inside paragraphs collection of TextFrame. It also allows you to get the coordinates of portion inside portion collection of a paragraph. In this topic, we are going to demonstrate with the help of an example that how to get the rectangular coordinates for paragraph along with position of portion inside a paragraph.

{{% /alert %}} 
### **Getting Rectangular coordinates of a Paragraph**
Using **GetRect()** method developers can get paragraph bounds rectangle.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-GettingRectangularCoordinatesOfParagraph-GettingRectangularCoordinatesOfParagraph.java" >}}
### **Getting position coordinates of a Portion**
**GetCoordinates()** method has been added to [IPortion](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPortion) and [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion) class which allows retrieving the coordinates of the beginning of the portion.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-GettingPositionCoordinatesOfPortion-GettingPositionCoordinatesOfPortion.java" >}}
