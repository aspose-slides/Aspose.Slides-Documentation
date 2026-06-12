---
title: Audio
type: docs
weight: 70
url: /nl/php-java/examples/elements/audio/
keywords:
- audio
- audioframe
- audio toevoegen
- toegang tot audio
- audio verwijderen
- audio afspelen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Werken met audio in PHP met Aspose.Slides: geluiden toevoegen, vervangen, extraheren en bijsnijden, volume en afspelen instellen voor dia's en vormen in PowerPoint en OpenDocument."
---
Illustreert hoe u audio-frames kunt insluiten en de afspeelwerking kunt regelen met **Aspose.Slides for PHP via Java**. De volgende voorbeelden tonen basis-audiooperaties.

## **Audioframe toevoegen**

Voeg een audioframe in.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Maak een audioframe aan.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Toegang tot een audioframe**

Deze code haalt het eerste audioframe op een dia op.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Toegang tot het eerste audioframe op de dia.
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

## **Audioframe verwijderen**

Verwijder een eerder toegevoegd audioframe.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aannemende dat de eerste vorm op de dia een audioframe is.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Verwijder het audioframe.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Audio-afspelen instellen**

Configureer het audioframe om automatisch af te spelen wanneer de dia verschijnt.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aannemende dat de eerste vorm op de dia een audioframe is.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Speel automatisch af wanneer de dia verschijnt.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```