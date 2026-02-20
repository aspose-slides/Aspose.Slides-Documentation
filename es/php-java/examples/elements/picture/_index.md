---
title: Imagen
type: docs
weight: 50
url: /es/php-java/examples/elements/picture/
keywords:
- imagen
- marco de imagen
- añadir imagen
- acceder a la imagen
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Trabaja con imágenes en PHP usando Aspose.Slides: inserta, sustituye, recorta, comprime, ajusta la transparencia y los efectos, rellena formas y exporta a PPT, PPTX y ODP."
---
Muestra cómo insertar y acceder a imágenes utilizando **Aspose.Slides for PHP via Java**. Los ejemplos siguientes colocan una imagen en una diapositiva y luego la recuperan.

## **Agregar una imagen**

Este código inserta una imagen como un marco de imagen en la primera diapositiva.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Añadir la imagen a los recursos de la presentación.
        $ppImage = $presentation->getImages()->addImage($image);

        // Insertar un marco de imagen que muestra la foto en la primera diapositiva.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acceder a una imagen**

Este ejemplo verifica que una diapositiva contenga un marco de imagen y luego accede al primero que encuentra.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acceder al primer PictureFrame en la diapositiva.
        $firstPictureFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $firstPictureFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```