---
title: Vidéo
type: docs
weight: 80
url: /fr/php-java/examples/elements/video/
keywords:
- vidéo
- cadre vidéo
- ajouter une vidéo
- accéder à une vidéo
- supprimer une vidéo
- lecture vidéo
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Travailler avec la vidéo en PHP en utilisant Aspose.Slides : insérer, remplacer, couper, définir des images d’affiche et des options de lecture, et exporter des présentations au format PPT, PPTX et ODP."
---
Montre comment intégrer des cadres vidéo et définir les options de lecture en utilisant **Aspose.Slides for PHP via Java**.

## **Ajouter un cadre vidéo**

Insérer un cadre vidéo dans une diapositive.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Ajouter un cadre vidéo.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accéder à un cadre vidéo**

Récupérer le premier cadre vidéo ajouté à une diapositive.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accéder au premier cadre vidéo de la diapositive.
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

## **Supprimer un cadre vidéo**

Supprimer un cadre vidéo de la diapositive.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supposant que la première forme de la diapositive est le cadre vidéo.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Supprimer le cadre vidéo.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Définir la lecture vidéo**

Configurer la vidéo pour qu'elle se lise automatiquement lorsque la diapositive est affichée.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supposant que la première forme de la diapositive est le cadre vidéo.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Configurer la vidéo pour qu'elle se lise automatiquement.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```