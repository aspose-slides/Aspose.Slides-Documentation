---
title: Manage Audio in Presentations Using JavaScript
linktitle: Audio Frame
type: docs
weight: 10
url: /nodejs-java/audio-frame/
keywords:
- audio
- audio frame
- thumbnail
- add audio
- audio properties
- audio options
- extract audio
- Node.js
- JavaScript
- Aspose.Slides
description: "Create and control audio frames in Aspose.Slides for Node.js—examples to embed, trim, loop, and configure playback across PPT, PPTX, and ODP presentations."
---

## **Create Audio Frames**

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
const pres = new aspose.slides.Presentation();
try {
    // Gets the first slide
    const sld = pres.getSlides().get_Item(0);
    // Loads the wav sound file to stream
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Adds the Audio Frame
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
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
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Adds an audio frame to the slide with a specified position and size.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Adds an image to presentation resources.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
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

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/) properties:
- **Start** drop-down list matches the [AudioFrame.setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) method
- **Volume** matches the [AudioFrame.setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) method
- **Play Across Slides** matches the [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) method
- **Loop until Stopped** matches the [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) method
- **Hide During Show** matches the [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) method
- **Rewind after Playing** matches the [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) method


PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/) properties:

- **Fade In** matches the [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) method 
- **Fade Out** matches the [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) method 
- **Trim Audio Start Time** matches the [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) method 
- **Trim Audio End Time** value equals the audio duration minus the value of [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) method

The PowerPoint **Volume controll** on the audio control panel corresponds to the [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) method. It lets you change the audio volume as a percentage.

This is how you change the Audio Play options:

1. [Сreate](#create-audio-frame) or get the Audio Frame.
2. Set new values for the Audio Frame properties you want to adjust.
3. Save the modified PowerPoint file.

This JavaScript code demonstrates an operation in which an audio's options are adjusted:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Gets the AudioFrame shape
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
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

This JavaScript example shows how to add a new audio frame with embedded audio, trim it, and set the fade durations:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Sets the trimming start offset to 1.5 seconds
    audioFrame.setTrimFromStart(1500);
    // Sets the trimming end offset to 2 seconds
    audioFrame.setTrimFromEnd(2000);

    // Sets the fade-in duration to 200 ms
    audioFrame.setFadeInDuration(200);
    // Sets the fade-out duration to 500 ms
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

The following code sample shows how to retrieve an audio frame with embedded audio and set its volume to 85%:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Gets an audio frame shape
    const audioFrame = slide.getShapes().get_Item(0);

    // Sets the audio volume to 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
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
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Accesses the desired slide
    const slide = pres.getSlides().get_Item(0);
    // Gets the slideshow transition effects for the slide
    const transition = slide.getSlideShowTransition();
    // Extracts the sound in byte array
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Can I reuse the same audio asset across multiple slides without inflating the file size?**

Yes. Add the audio once to the presentation’s shared [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/) and create additional audio frames that reference that existing asset. This avoids duplicating media data and keeps the presentation size under control.

**Can I replace the sound in an existing audio frame without recreating the shape?**

Yes. For a linked sound, update the [link path](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) to point to the new file. For an embedded sound, swap the [embedded audio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) object with another one from the presentation’s [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/). The frame’s formatting and most playback settings remain intact.

**Does trimming change the underlying audio data stored in the presentation?**

No. Trimming adjusts only the playback boundaries. The original audio bytes remain untouched and accessible through the embedded audio or the presentation’s audio collection.
