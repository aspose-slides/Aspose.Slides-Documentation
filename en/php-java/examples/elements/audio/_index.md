---
title: Audio
type: docs
weight: 70
url: /php-java/examples/elements/audio/
keywords:
- audio
- audio frame
- add audio
- access audio
- remove audio
- audio playback
- code examples
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Work with audio in PHP using Aspose.Slides: add, replace, extract, and trim sounds, set volume and playback for slides and shapes in PowerPoint and OpenDocument."
---

Illustrates how to embed audio frames and control playback with **Aspose.Slides for PHP via Java**. The following examples show basic audio operations.

## **Add an Audio Frame**

Insert an audio frame.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Create an audio frame.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access an Audio Frame**

This code retrieves the first audio frame on a slide.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Access the first audio frame on the slide.
        $firstAudioFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
                $firstAudioFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove an Audio Frame**

Delete a previously added audio frame.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assuming the first shape on the slide is an audio frame.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Remove the audio frame.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Set Audio Playback**

Configure the audio frame to play automatically when the slide appears.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assuming the first shape on the slide is an audio frame.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Play automatically when the slide appears.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```
