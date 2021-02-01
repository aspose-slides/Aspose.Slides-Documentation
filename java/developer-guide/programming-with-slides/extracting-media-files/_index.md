---
title: Extracting media files
type: docs
weight: 60
url: /java/extracting-media-files/
---

## **Exporting media files to HTML file**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports exporting the media files to HTML. Public class [VideoPlayerHtmlController](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/VideoPlayerHtmlController) has been added to Aspose.Slides.Export namespace. Using the instance of this class you can export video and audio files into HTML. In this topic, we will see with an example how to export audio and video files to an HTML file in Aspose.Slides. [VideoPlayerHtmlController](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/VideoPlayerHtmlController) constructors accepts the following parameters:
path: The path where video and audio files will be generated
fileName: The name of the HTML file
baseUri: The base URI which will be used to generate links

{{% /alert %}} 
### **Exporting the media files**
In the example given below, we have exported the media files to HTML.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Media-ExportingMediaFilesIntoHtmlFile-ExportingMediaFilesIntoHtmlFile.java" >}}
## **Extracting Video From A Slide**
{{% alert color="primary" %}} 

Aspose.Slides for Java supports extracting video from the slide. In this topic, we will see with an example how to extract the video using Aspose.Slides.

{{% /alert %}} 
### **Extracting Video From A Slide**
In order to extract the video. Please follow the steps below:

- Load a Presentation containing a video
- Loop through all the slides of Presentation
- Search for Video Frame
- Save the Video to disk

In the example given below, we have saved the video file from a slide.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Media-ExtractingVideoFromASlide-ExtractingVideoFromASlide.java" >}}
## **Extracting Flash objects from Presentation**
Aspose.Slides for Java provides a facility for extracting flash objects from a presentation. You can access the flash control by name and extract it from the presentation and including store SWF object data.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Media-ExtractFlashObjects-ExtractFlashObjects.java" >}}
## **Extracting Audio Used In SlideShow Transitions**
{{% alert color="primary" %}} 

Aspose.Slides also offer to extract the sound that is used in slideshow transition effects for presentation slides.

{{% /alert %}} 
### **Extracting sound from Slideshow transition**
Aspose.Slides for Java allows developers to extract the sound that is used in slide show transitions associated with slides. To extract the audio, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with slide transitions
- Access the desired slide
- Access the slideshow transitions for slide
- Extract the sound in byte data

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Media-ExtractingAudioUsedInSlideShowTransitions-ExtractingAudioUsedInSlideShowTransitions.java" >}}
