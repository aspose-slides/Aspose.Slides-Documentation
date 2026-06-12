---
title: Video
type: docs
weight: 80
url: /cs/php-java/examples/elements/video/
keywords:
- video
- video rámeček
- přidat video
- přístup k videu
- odstranit video
- přehrávání videa
- ukázky kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Pracujte s videem v PHP pomocí Aspose.Slides: vkládejte, nahrazujte, ořezávejte, nastavujte posterové rámečky a možnosti přehrávání a exportujte prezentace do formátů PPT, PPTX a ODP."
---
Ukazuje, jak vložit video rámečky a nastavit možnosti přehrávání pomocí **Aspose.Slides for PHP via Java**.

## **Přidat video rámeček**

Vložte video rámeček do snímku.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přidejte video rámeček.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Přístup k video rámečku**

Získejte první video rámeček přidaný do snímku.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přístup k prvnímu video rámečku na snímku.
        $firstVideoFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $firstVideoFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranit video rámeček**

Odstraňte video rámeček ze snímku.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je video rámeček.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Odstraňte video rámeček.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Nastavit přehrávání videa**

Nakonfigurujte video tak, aby se přehrávalo automaticky při zobrazení snímku.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Předpokládáme, že první tvar na snímku je video rámeček.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Nastavte video tak, aby se přehrávalo automaticky.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```