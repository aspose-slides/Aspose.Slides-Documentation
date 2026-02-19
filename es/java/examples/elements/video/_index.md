---
title: Vídeo
type: docs
weight: 80
url: /es/java/examples/elements/video/
keywords:
- ejemplo de código
- vídeo
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Añade y controla vídeos con Aspose.Slides for Java: inserta, reproduce, recorta, establece marcos de póster y exporta con ejemplos Java para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo incrustar marcos de vídeo y establecer opciones de reproducción mediante **Aspose.Slides for Java**.

## **Agregar un Marco de Vídeo**

Inserte un marco de vídeo vacío en una diapositiva.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Añadir un vídeo.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a un Marco de Vídeo**

Recupere el primer marco de vídeo añadido a una diapositiva.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Acceder al primer marco de vídeo en la diapositiva.
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar un Marco de Vídeo**

Elimine un marco de vídeo de la diapositiva.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Eliminar el marco de vídeo.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Establecer la Reproducción del Vídeo**

Configure el vídeo para que se reproduzca automáticamente cuando se muestre la diapositiva.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Configurar el vídeo para que se reproduzca automáticamente.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```