---
title: Video
type: docs
weight: 80
url: /es/php-java/examples/elements/video/
keywords:
- video
- marco de video
- agregar video
- acceder video
- eliminar video
- reproducción de video
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Trabaje con video en PHP usando Aspose.Slides: inserte, reemplace, recorte, establezca marcos de póster y opciones de reproducción, y exporte presentaciones a PPT, PPTX y ODP."
---
Muestra cómo incrustar marcos de video y establecer opciones de reproducción usando **Aspose.Slides for PHP via Java**.

## **Agregar un Marco de Video**

Inserta un marco de video en una diapositiva.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Agregar un marco de video.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acceder a un Marco de Video**

Recupera el primer marco de video añadido a una diapositiva.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acceder al primer marco de video en la diapositiva.
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

## **Eliminar un Marco de Video**

Elimina un marco de video de la diapositiva.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma en la diapositiva es el marco de video.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Eliminar el marco de video.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Configurar la reproducción del video**

Configura el video para que se reproduzca automáticamente cuando se muestre la diapositiva.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma en la diapositiva es el marco de video.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Configurar el video para que se reproduzca automáticamente.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```