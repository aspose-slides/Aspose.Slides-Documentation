---
title: Immagine
type: docs
weight: 50
url: /it/php-java/examples/elements/picture/
keywords:
- immagine
- cornice immagine
- aggiungi immagine
- accedi immagine
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Lavora con le immagini in PHP usando Aspose.Slides: inserisci, sostituisci, ritaglia, comprimi, regola trasparenza ed effetti, riempi le forme e esporta per PPT, PPTX e ODP."
---
Mostra come inserire e accedere alle immagini usando **Aspose.Slides for PHP via Java**. Gli esempi seguenti inseriscono un'immagine su una diapositiva e poi la recuperano.

## **Aggiungi un'immagine**

Questo codice inserisce un'immagine come cornice grafica nella prima diapositiva.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Aggiungi l'immagine alle risorse della presentazione.
        $ppImage = $presentation->getImages()->addImage($image);

        // Inserisci una cornice immagine che mostra l'immagine sulla prima diapositiva.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accedi a un'immagine**

Questo esempio verifica che una diapositiva contenga una cornice grafica e quindi accede alla prima trovata.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accedi al primo PictureFrame sulla diapositiva.
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