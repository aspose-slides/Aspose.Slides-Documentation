---
title: Audio Frame
type: docs
weight: 10
url: /nodejs-java/audio-frame/
keywords: "Add audio, Audio frame, Audio properties, Extract audio, Java, Aspose.Slides for Node.js via Java"
description: "Add audio to PowerPoint presentation in JavaScript"
---

## **Create Audio Frame**
Aspose.Slides for Node.js via Java allows you to add audio files to slides. The audio files are embedded in slides as audio frames.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index.
3. Load the audio file stream you want to embed in the slide.
4. Add the embedded audio frame (containing the audio file) to the slide.
5. Set [PlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioPlayModePreset) and `Volume` exposed by the [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame) object.
6. Save the modified presentation.

This JavaScript code shows you how to add an embedded audio frame to a slide:

```javascript
// Instantiates a Presentation class that represents a presentation file
var pres = new aspose.slides.Presentation();
try {
    // Gets the first slide
    var sld = pres.getSlides().get_Item(0);
    // Loads the wav sound file to stream
    var fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Adds the Audio Frame
    var audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Sets the Play Mode and Volume of the Audio
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Writes the PowerPoint file to disk
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Change Audio Frame Thumbnail**

When you add an audio file to a presentation, the audio appears as a frame with a standard default image (see the image in the section below). You change the audio frame's preview image (set your preferred image).

This JavaScript code shows you how to change an audio frame's thumbnail or preview image:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // Adds an audio frame to the slide with a specified position and size.
    var audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    var audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Adds an image to presentation resources.
    var picture;
    var image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Sets the image for the audio frame.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Saves the modified presentation to disk
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Change Audio Play Options**

Aspose.Slides for Node.js via Java allows you to change options that control an audio's playback or properties. For example, you can adjust an audio's volume, set the audio to play looped, or even hide the audio icon.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint Audio options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame) properties:
- Audio Options **Start** drop-down list matches the [AudioFrame.PlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame#getPlayMode--) property
- Audio Options **Volume** matches the [AudioFrame.Volume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame#getVolume--) property
- Audio Options **Play Across Slides** matches the [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame#getPlayAcrossSlides--) property
- Audio Options **Loop until Stopped** matches the [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame#getPlayLoopMode--) property
- Audio Options **Hide During Show** matches the [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame#getHideAtShowing--) property
- Audio Options **Rewind after Playing** matches the [AudioFrame.RewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame#getRewindAudio--) property

This is how you change the Audio Play options:

1. [Сreate](#create-audio-frame) or get the Audio Frame.
2. Set new values for the Audio Frame properties you want to adjust.
3. Save the modified PowerPoint file.

This JavaScript code demonstrates an operation in which an audio's options are adjusted:

```javascript
var pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Gets the AudioFrame shape
    var audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Sets the Play mode to play on click
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Sets the volume to Low
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Sets the audio to play across slides
    audioFrame.setPlayAcrossSlides(true);
    // Disables loop for the audio
    audioFrame.setPlayLoopMode(false);
    // Hides the AudioFrame during the slide show
    audioFrame.setHideAtShowing(true);
    // Rewinds the audio to start after playing
    audioFrame.setRewindAudio(true);
    // Saves the PowerPoint file to disk
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Extract Audio**

Aspose.Slides for Node.js via Java allows you to extract the sound used in slide show transitions. For example, you can extract the sound used in a specific slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class and load the presentation containing the audio.
2. Get the relevant slide's reference through its index.
3. Access the [slideshow transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) for the slide.
4. Extract the sound in byte data.

This code in JavaScript shows you how to extract the audio used in a slide:

```javascript
// Instantiates a Presentation class that represents a presentation file
var pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Accesses the desired slide
    var slide = pres.getSlides().get_Item(0);
    // Gets the slideshow transition effects for the slide
    var transition = slide.getSlideShowTransition();
    // Extracts the sound in byte array
    var audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
