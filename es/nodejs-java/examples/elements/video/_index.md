---
title: Vídeo
type: docs
weight: 80
url: /es/nodejs-java/examples/elements/video/
keywords:
- ejemplo de código
- vídeo
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Agregar y controlar vídeos con Aspose.Slides para Node.js: insertar, reproducir, recortar, establecer marcos de póster y exportar con ejemplos para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo incrustar marcos de vídeo y establecer opciones de reproducción usando **Aspose.Slides for Node.js via Java**.

## **Agregar un marco de vídeo**
Agrega un marco de vídeo a una diapositiva.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Añadir un vídeo.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a un marco de vídeo**
Recupera el primer marco de vídeo añadido a una diapositiva.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Acceder al primer marco de vídeo en la diapositiva.
        let firstVideo = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IVideoFrame")) {
                firstVideo = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Eliminar un marco de vídeo**
Elimina un marco de vídeo de la diapositiva.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Se asume que la primera forma es el marco de vídeo.
        let videoFrame = slide.getShapes().get_Item(0);

        // Eliminar el marco de vídeo.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Establecer reproducción de vídeo**
Configura el vídeo para que se reproduzca automáticamente cuando se muestre la diapositiva.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Se asume que la primera forma es el marco de vídeo.
        let videoFrame = slide.getShapes().get_Item(0);

        // Configurar el vídeo para que se reproduzca automáticamente.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```