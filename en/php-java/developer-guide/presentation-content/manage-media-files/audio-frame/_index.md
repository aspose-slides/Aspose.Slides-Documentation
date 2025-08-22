---
title: Manage Audio in Presentations Using PHP
linktitle: Audio Frame
type: docs
weight: 10
url: /php-java/audio-frame/
keywords:
- audio
- audio frame
- thumbnail
- add audio
- audio properties
- audio options
- extract audio
- PHP
- Aspose.Slides
description: "Create and control audio frames in Aspose.Slides for PHP—code examples to embed, trim, loop, and configure playback across PPT, PPTX, and ODP presentations."
---

## **Create Audio Frames**

Aspose.Slides for PHP via Java allows you to add audio files to slides. The audio files are embedded in slides as audio frames.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Get a slide's reference through its index.
3. Load the audio file stream you want to embed in the slide.
4. Add the embedded audio frame (containing the audio file) to the slide.
5. Set [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) and `Volume` exposed by the [IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame) object.
6. Save the modified presentation.

This PHP code shows you how to add an embedded audio frame to a slide:

```php
// Instantiates a Presentation class that represents a presentation file
$pres = new Presentation();
try {
    # Gets the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Loads the wav sound file to stream
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Adds the Audio Frame
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Sets the Play Mode and Volume of the Audio
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Writes the PowerPoint file to disk
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Change Audio Frame Thumbnail**

When you add an audio file to a presentation, the audio appears as a frame with a standard default image (see the image in the section below). You change the audio frame's preview image (set your preferred image).

This PHP code shows you how to change an audio frame's thumbnail or preview image:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Adds an audio frame to the slide with a specified position and size.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Adds an image to presentation resources.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Sets the image for the audio frame.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# Saves the modified presentation to disk
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Change Audio Play Options**

Aspose.Slides for PHP via Java allows you to change options that control an audio's playback or properties. For example, you can adjust an audio's volume, set the audio to play looped, or even hide the audio icon.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) properties:

- **Start** drop-down list matches the [AudioFrame.setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayMode) method
- **Volume** matches the [AudioFrame.setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolume) method
- **Play Across Slides** matches the [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayAcrossSlides) method
- **Loop until Stopped** matches the [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayLoopMode) method
- **Hide During Show** matches the [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setHideAtShowing) method
- **Rewind after Playing** matches the [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setRewindAudio) method

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) properties:

- **Fade In** matches the [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) method 
- **Fade Out** matches the [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) method 
- **Trim Audio Start Time** matches the [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) method 
- **Trim Audio End Time** value equals the audio duration minus the value of [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) method

The PowerPoint **Volume controll** on the audio control panel corresponds to the [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) method. It lets you change the audio volume as a percentage.

This is how you change the Audio Play options:

1. [Сreate](#create-audio-frame) or get the Audio Frame.
2. Set new values for the Audio Frame properties you want to adjust.
3. Save the modified PowerPoint file.

This PHP code demonstrates an operation in which an audio's options are adjusted:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Gets the AudioFrame shape
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Sets the Play mode to play on click
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Sets the volume to Low
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Sets the audio to play across slides
    $audioFrame->setPlayAcrossSlides(true);
    # Disables loop for the audio
    $audioFrame->setPlayLoopMode(false);
    # Hides the AudioFrame during the slide show
    $audioFrame->setHideAtShowing(true);
    # Rewinds the audio to start after playing
    $audioFrame->setRewindAudio(true);
    # Saves the PowerPoint file to disk
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

This PHP example shows how to add a new audio frame with embedded audio, trim it, and set the fade durations:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Sets the trimming start offset to 1.5 seconds
    $audioFrame->setTrimFromStart(1500);
    // Sets the trimming end offset to 2 seconds
    $audioFrame->setTrimFromEnd(2000);

    // Sets the fade-in duration to 200 ms
    $audioFrame->setFadeInDuration(200);
    // Sets the fade-out duration to 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

The following code sample shows how to retrieve an audio frame with embedded audio and set its volume to 85%:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Gets an audio frame shape
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Sets the audio volume to 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Extract Audio**

Aspose.Slides for PHP via Java allows you to extract the sound used in slide show transitions. For example, you can extract the sound used in a specific slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class and load the presentation containing the audio.
2. Get the relevant slide's reference through its index.
3. Access the [slideshow transitions](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--) for the slide.
4. Extract the sound in byte data.

This code  shows you how to extract the audio used in a slide:

```php
# Instantiates a Presentation class that represents a presentation file
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Accesses the desired slide
	$slide = $pres->getSlides()->get_Item(0);
	# Gets the slideshow transition effects for the slide
	$transition = $slide->getSlideShowTransition();
	# Extracts the sound in byte array
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```
