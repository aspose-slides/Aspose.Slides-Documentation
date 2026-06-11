---
title: Dźwięk
type: docs
weight: 70
url: /pl/php-java/examples/elements/audio/
keywords:
- dźwięk
- ramka audio
- dodaj dźwięk
- dostęp do dźwięku
- usuń dźwięk
- odtwarzanie dźwięku
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Pracuj z dźwiękiem w PHP przy użyciu Aspose.Slides: dodawaj, zamieniaj, wyodrębniaj i przycinaj dźwięki, ustawiaj głośność i odtwarzanie dla slajdów i kształtów w PowerPoint i OpenDocument."
---
Ilustruje, jak osadzić ramki audio i kontrolować odtwarzanie przy użyciu **Aspose.Slides for PHP via Java**. Poniższe przykłady pokazują podstawowe operacje na dźwięku.

## **Dodaj ramkę audio**

Wstaw ramkę audio.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Utwórz ramkę audio.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Dostęp do ramki audio**

Ten kod pobiera pierwszą ramkę audio na slajdzie.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Uzyskaj dostęp do pierwszej ramki audio na slajdzie.
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

## **Usuń ramkę audio**

Usuń wcześniej dodaną ramkę audio.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszym kształtem na slajdzie jest ramka audio.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Usuń ramkę audio.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ustaw odtwarzanie audio**

Skonfiguruj ramkę audio, aby odtwarzała się automatycznie, gdy slajd się pojawi.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszym kształtem na slajdzie jest ramka audio.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Odtwarzaj automatycznie, gdy slajd się pojawi.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```