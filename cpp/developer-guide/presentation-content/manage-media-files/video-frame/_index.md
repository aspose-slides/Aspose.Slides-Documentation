---
title: Video Frame
type: docs
weight: 10
url: /cpp/video-frame/
---



## **Create Video Frame**
Developers can add and play video files in the slides to enrich their presentations. Aspose.Slides for C++ supports adding Video Frames to the slides that make it possible for developers to add videos to their presentations. This topic will help developers to follow the simple steps with examples for adding video frames in their slides. To add a Video Frame in a slide using Aspose.Slides for C++, please follow the steps below:

1. Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/).
1. Obtain the reference of a slide by using its Index.
1. Add the Video Frame (containing the video file name) into the slide.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a Video Frame into the slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-EmbeddedVideoFrame-EmbeddedVideoFrame.cpp" >}}

## **Create Video Frame with Video from Web Source**
PowerPoint 2010 and newer versions support YouTube videos. To play these videos in PowerPoint make sure your [environment meet requirements ](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)for embedding videos from web source.

In order To add video from YouTube with Aspose.Slides, please use following code snippet:

1. Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/)
1. Obtain the reference of a slide by using its Index
1. Add the Video Frame by passing video URL
1. Set Image for Video Frame
1. Save presentation as a PPTX file

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddVideoFrameFromWebSource-AddVideoFrameFromWebSource.cpp" >}}


## **Create Embedded Video Frame**
Developers can also embed and play video files in the slides to enrich their presentations. Aspose.Slides for C++ supports adding Embedded Video Frames to the slides that make it possible for developers to add videos to their presentations. This topic will help developers to follow the simple steps with examples for adding video frames in their slides.

To add an Embedded Video Frame in a slide using Aspose.Slides for C++, please follow the steps below:

1. Create an instance of [Presentation class](http://www.aspose.com/api/net/slides/aspose.slides/)
1. Obtain the reference of a slide by using its Index
1. Add the Video Frame (containing the video file name) into the slide
1. Add the video to be embedded inside presentation Video collection using Video
1. Set embedded video to Video frame
1. Write the modified presentation as a PPTX file

In the example given below, we have added a Video Frame into the slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddVideoFrame-AddVideoFrame.cpp" >}}


## **Extract Video from Slide**
Aspose.Slides for C++ supports extracting video from the slide. In order to extract the video. Please follow the steps below:

- Load a Presentation containing a video.
- Loop through all the slides of Presentation.
- Search for Video Frame.
- Save the Video to disk.
  In the example given below, we have saved the video file from a slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ExtractVideo-ExtractVideo.cpp" >}}