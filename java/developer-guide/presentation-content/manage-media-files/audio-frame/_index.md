---
title: Audio Frame
type: docs
weight: 10
url: /java/audio-frame/
description: Creating Audio Frame from PowerPoint using Java. Change Audio Frame properties in PowerPoint using Java. Extract Audio from PowerPoint in Java.
---

## **Creating Audio Frame**
Aspose.Slides for Java allows you to add audio files to slides. Audio files are embedded in slides as audio frames. 
To add an audio file in a slide using Aspose.Slides for Java, please follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Obtain the reference of a slide by using its Index.
3. Open the audio file stream to be embedded in the slide.
4. Add the embedded audio Frame (containing the audio file) to the slide.
5. Set [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) and Volume exposed by [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame) object.
6. Write the modified presentation as a PPTX file.

This Java shows you how to add an embedded audio frame into a slide:

```Java
// Instantiate Presentation class that represents the presentation file
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Load the wav sound file to stream
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Add Audio Frame
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Set Play Mode and Volume of the Audio
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Write the PPTX file to disk
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change Audio Frame properties**
Aspose.Slides for Java allows you to change the properties for audio frames. 

This is the Audio Options pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

These are the correspondences between PowerPoint Audio Options and [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) properties:
- Audio Options **Start** drop-down list matches the [AudioFrame.PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayMode--) property
- Audio Options **Volume** matches the [AudioFrame.Volume](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getVolume--) property
- Audio Options **Play Across Slides** matches the [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) property
- Audio Options **Loop until Stopped** matches the [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayLoopMode--) property
- Audio Options **Hide During Show** matches the [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getHideAtShowing--) property
- Audio Options **Rewind after Playing** matches the [AudioFrame.RewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getRewindAudio--) property

To change the Audio Frame properties, please follow these steps:

1. [Сreate](#create-audio-frame) or get the Audio Frame.
2. Set new values for the Audio Frame properties you need. 
3. Save the modified PPTX file.

This sample code demonstrates the operation:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Get the AudioFrame shape
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Change Play mode to play on click
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Set Volume to Low
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Set audio to play across slides
    audioFrame.setPlayAcrossSlides(true);

    // Set audio to not loop
    audioFrame.setPlayLoopMode(false);

    // Hide AudioFrame during the slide show
    audioFrame.setHideAtShowing(true);

    // Rewind audio to start after playing
    audioFrame.setRewindAudio(true);

    // Save the PPTX file to disk
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extract Audio**
Aspose.Slides for Java allows you to extract the sound used in slide show transitions. The sound is associated with slides.

To extract the audio, please follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class and load the presentation with slide transitions.
2. Access the desired slide.
3. Access the [slideshow transitions](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) for the slide.
4. Extract the sound in byte data.

This code in Java shows you how to extract the audio used in a slide:

```java
// Instantiate Presentation class that represents the presentation file
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Access the desired slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Get the slideshow transition effects for slide
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Extract sound in byte array
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```
