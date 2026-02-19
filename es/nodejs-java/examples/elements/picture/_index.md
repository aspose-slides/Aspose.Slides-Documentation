---
title: Imagen
type: docs
weight: 50
url: /es/nodejs-java/examples/elements/picture/
keywords:
- ejemplo de código
- imagen
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Trabajar con imágenes en Aspose.Slides para Node.js: insertar, recortar, comprimir, recolorear y exportar imágenes con ejemplos para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo insertar y acceder a imágenes usando **Aspose.Slides for Node.js via Java**. Los ejemplos a continuación leen una imagen de un archivo, la colocan en una diapositiva y luego la recuperan.

## **Agregar una imagen**

Este código lee una imagen de un archivo y la inserta como un marco de imagen en la primera diapositiva.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Insertar un marco de imagen que muestra la imagen en la primera diapositiva.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acceder a una imagen**

Este ejemplo verifica que una diapositiva contenga un marco de imagen y luego accede al primero que encuentra.

```js
function accessPicture() {
    let presentation = new aspose.slides.Presentation("picture.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pictureFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                pictureFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```