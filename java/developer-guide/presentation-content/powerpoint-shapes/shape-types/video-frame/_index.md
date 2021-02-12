---
title: Video Frame
type: docs
weight: 10
url: /java/video-frame/
---

## **Add Video Frame to Slide**
{{% alert color="primary" %}} 

Developers can also add and play video files in the slides to enrich their presentations. Aspose.Slides for Java supports Add **Video Frames** to the slides that make it possible for developers to add videos to their presentations. This topic will help developers to follow the simple steps with examples for Add video frames in their slides.

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

## **Set Image to Video Frame**
To set image on a video frame, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add the Video Frame (containing the video file name) into the slide.
- Set image for videoframe.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-SettingImageOnAVideoFrame-SettingImageOnAVideoFrame.java" >}}

## **Add Embedded Video Frame to Slide**
{{% alert color="primary" %}} 

Developers can also embed and play video files in the slides to enrich their presentations. Aspose.Slides for Java supports Add **Embedded Video Frames** to the slides that make it possible for developers to add videos to their presentations. This topic will help developers to follow the simple steps with examples for Add video frames in their slides.

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

## **Add Video Frame from Web Source**
PowerPoint 2010 and newer versions support YouTube videos. To play these videos in PowerPoint make sure your [environment meet requirements](https://support.office.com/en-us/article/Requirements-for-using-the-PowerPoint-YouTube-feature-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-US&rs=en-US&ad=US) for embedding videos from web source.
In order To add video from YouTube with Aspose.Slides, please use following code snippet:

1. Create an instance of Presentation class
1. Obtain the reference of a slide by using its Index
1. Add the Video Frame by passing video URL
1. Set Image for Video Frame
1. Save presentation as a PPTX file

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-AddingVideoFrameWithVideoFromWebSource-AddingVideoFrameWithVideoFromWebSource.java" >}}


## **Extract Video from Slide**
{{% alert color="primary" %}} 

Aspose.Slides for Java supports extracting video from the slide. In this topic, we will see with an example how to extract the video using Aspose.Slides.

{{% /alert %}} 

In order to extract the video, please follow the steps below:

- Load a Presentation containing a video
- Loop through all the slides of Presentation
- Search for Video Frame
- Save the Video to disk

In the example given below, we have saved the video file from a slide.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Media-ExtractingVideoFromASlide-ExtractingVideoFromASlide.java" >}}

