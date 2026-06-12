---
title: Audio
type: docs
weight: 70
url: /cs/php-java/examples/elements/audio/
keywords:
- audio
- audio rámec
- přidat audio
- přístup k audiu
- odstranit audio
- přehrávání audia
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Pracujte s audiem v PHP pomocí Aspose.Slides: přidávejte, nahrazujte, extrahujte a ořezávejte zvuky, nastavujte hlasitost a přehrávání pro snímky a tvary v PowerPointu a OpenDocumentu."
---
Ukazuje, jak vložit audio rámečky a řídit jejich přehrávání pomocí **Aspose.Slides for PHP via Java**. Následující příklady ukazují základní operace s audio.

## **Přidat audio rámeček**

Vložte audio rámeček.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Vytvořte audio rámeček.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Přístup k audio rámečku**

Tento kód získá první audio rámeček na snímku.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přístup k prvnímu audio rámečku na snímku.
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

## **Odstranit audio rámeček**

Odstraňte dříve přidaný audio rámeček.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je audio rámeček.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Odstraňte audio rámeček.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Nastavit přehrávání audio**

Nastavte audio rámeček tak, aby se přehrál automaticky při zobrazení snímku.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je audio rámeček.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Přehrát automaticky při zobrazení snímku.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```