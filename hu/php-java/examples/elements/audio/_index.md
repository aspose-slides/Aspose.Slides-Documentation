---
title: Hang
type: docs
weight: 70
url: /hu/php-java/examples/elements/audio/
keywords:
- hang
- audio keret
- hang hozzáadása
- hang elérése
- hang eltávolítása
- hang lejátszása
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Hanggal való munka PHP-ben az Aspose.Slides használatával: hangok hozzáadása, cseréje, kinyerése és vágása, hangerő és lejátszás beállítása diákhoz és alakzatokhoz PowerPointban és OpenDocumentben."
---
Bemutatja, hogyan ágyazhat be audio kereteket, és vezérelheti a lejátszást a **Aspose.Slides for PHP via Java** segítségével. A következő példák az alapvető audio műveleteket mutatják be.

## **Audio Keret Hozzáadása**

Audio keret beillesztése.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Audio keret létrehozása.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Audio Keret Elérése**

Ez a kód lekéri a dián található első audio keretet.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Az első audio keret elérése a dián.
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

## **Audio Keret Eltávolítása**

Korábban hozzáadott audio keret törlése.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dia első alakzata egy audio keret.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Az audio keret eltávolítása.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Audio Lejátszás Beállítása**

Állítsa be az audio keretet, hogy a dia megjelenésekor automatikusan lejátszódjon.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dia első alakzata egy audio keret.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Automatikus lejátszás a dia megjelenésekor.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```