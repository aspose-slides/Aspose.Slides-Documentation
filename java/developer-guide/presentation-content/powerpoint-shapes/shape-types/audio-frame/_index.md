---
title: Audio Frame
type: docs
weight: 10
url: /java/audio-frame/
---

## **Add Audio Frame to Slide**
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


## **Extract Audio used in SlideShow Transitions**
{{% alert color="primary" %}} 

Aspose.Slides also offer to extract the sound that is used in slideshow transition effects for presentation slides.

{{% /alert %}} 

Aspose.Slides for Java allows developers to extract the sound that is used in slide show transitions associated with slides. To extract the audio, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with slide transitions
- Access the desired slide
- Access the slideshow transitions for slide
- Extract the sound in byte data

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Media-ExtractingAudioUsedInSlideShowTransitions-ExtractingAudioUsedInSlideShowTransitions.java" >}}
