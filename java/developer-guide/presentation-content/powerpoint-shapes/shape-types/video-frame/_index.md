---
title: Video Frame
type: docs
weight: 10
url: /java/video-frame/
---

## **Create Embedded Video Frame**
Developers can also add and play video files in slides to enrich their presentations. Aspose.Slides for Java supports addition of Video Frames into slides—and this means you get to add videos to your presentations. In this topic, we will describe operations to add video frames to slides using examples and simple steps.

To add a Video Frame in a slide using Aspose.Slides for Java, do this:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. [Add the Video Frame](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) (containing the video file name) into the slide.
1. Write the modified presentation as a PPTX file.

In the example below, we added a Video Frame to the slide.

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Embed video inside presentation
    IVideo vid = pres.getVideos().addVideo(new FileInputStream(new File("Wildlife.mp4")));

    // Add Video Frame
    IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 350, vid);

    // Set video to Video Frame
    vf.setEmbeddedVideo(vid);

    // Set Play Mode and Volume of the Video
    vf.setPlayMode(VideoPlayModePreset.Auto);
    vf.setVolume(AudioVolumeMode.Loud);

    // Write the PPTX file to disk
    pres.save("VideoFrame.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create Video Frame with Video from Web Source**
PowerPoint 2010 and newer versions support YouTube videos. To play such videos in PowerPoint, verify that your [environment meet the requirements](https://support.office.com/en-us/article/Requirements-for-using-the-PowerPoint-YouTube-feature-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-US&rs=en-US&ad=US) for embedding videos from web sources.

To add video from YouTube with Aspose.Slides, do this:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. [Add the Video Frame](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addVideoFrame-float-float-float-float-java.lang.String-) by passing video URL.
1. Set Image for Video Frame.
1. Save presentation as a PPTX file.

This sample code shows you how to add a video from YouTube to a slide:

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // add videoFrame
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // load thumbnail
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **Create Video Frame**
Developers can also embed and play video files in slides to enrich their presentations. Aspose.Slides for Java supports addition of Embedded Video Frames to slides—and this means you get to add videos to your presentations. 

To add an Embedded Video Frame in a slide using Aspose.Slides for Java, do this:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. [Add the Video Frame](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addVideoFrame-float-float-float-float-java.lang.String-) (containing the video file name) into the slide.
1. Add the video to be embedded inside presentation Video collection using Video.
1. Set embedded video to Video frame.
1. Write the modified presentation as a PPTX file.

In the example below, we added a Video Frame to the slide.

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add Video Frame
    IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "Wildlife.mp4");

    // Set Play Mode and Volume of the Video
    vf.setPlayMode(VideoPlayModePreset.Auto);
    vf.setVolume(AudioVolumeMode.Loud);

    // Write the PPTX file to disk
    pres.save("VideoFrame.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extract Video From Slide**
Aspose.Slides for Java supports extraction of videos from slides. To extract a video from a slide, do this:

- Load a [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) containing a video.
- Loop through all the slides of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Search for Video Frame.
- Save the Video to disk.

In the example given below, we saved the video file from a slide.

```java
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                //Get File Extension
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```