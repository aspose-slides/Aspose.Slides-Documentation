---
title: Audio
type: docs
weight: 70
url: /es/androidjava/examples/elements/audio/
keywords:
- ejemplo de código
- audio
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Descubra ejemplos de audio de Aspose.Slides for Android: inserte, reproduzca, recorte y extraiga sonido en presentaciones PPT, PPTX y ODP con código Java claro."
---
Este artículo muestra cómo incrustar marcos de audio y controlar la reproducción con **Aspose.Slides for Android via Java**. Los ejemplos siguientes demuestran operaciones básicas de audio.

## **Agregar un marco de audio**

Inserte un marco de audio vacío que luego pueda contener datos de sonido incrustados.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Crear un marco de audio vacío (el audio se incrustará más tarde).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a un marco de audio**

Este código recupera el primer marco de audio en una diapositiva.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Acceder al primer marco de audio en la diapositiva.
        IAudioFrame firstAudio = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAudioFrame) {
                firstAudio = (IAudioFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar un marco de audio**

Elimine un marco de audio añadido previamente.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Eliminar el marco de audio.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Configurar la reproducción de audio**

Configure el marco de audio para que se reproduzca automáticamente cuando aparezca la diapositiva.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Reproducir automáticamente cuando la diapositiva aparezca.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```