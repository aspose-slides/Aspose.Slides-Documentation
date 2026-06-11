---
title: Ljud
type: docs
weight: 70
url: /sv/php-java/examples/elements/audio/
keywords:
- ljud
- ljudram
- lägg till ljud
- åtkomst till ljud
- ta bort ljud
- ljuduppspelning
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Arbeta med ljud i PHP med Aspose.Slides: lägg till, ersätt, extrahera och trimma ljud, ställ in volym och uppspelning för bilder och former i PowerPoint och OpenDocument."
---
Visar hur man bäddar in ljudramar och styr uppspelning med **Aspose.Slides for PHP via Java**. Följande exempel visar grundläggande ljudoperationer.

## **Lägg till en ljudram**

Infoga en ljudram.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Skapa en ljudram.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Åtkomst till en ljudram**

Den här koden hämtar den första ljudramen på en bild.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Åtkomst till den första ljudramen på bilden.
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

## **Ta bort en ljudram**

Radera en tidigare tillagd ljudram.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antag att den första formen på bilden är en ljudram.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Ta bort ljudramen.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ställ in ljuduppspelning**

Konfigurera ljudramen så att den spelas upp automatiskt när bilden visas.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antag att den första formen på bilden är en ljudram.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Spela automatiskt när bilden visas.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```