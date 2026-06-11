---
title: Bild
type: docs
weight: 50
url: /sv/php-java/examples/elements/picture/
keywords:
- bild
- bildram
- lägg till bild
- få åtkomst till bild
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Arbeta med bilder i PHP med Aspose.Slides: infoga, ersätta, beskära, komprimera, justera transparens och effekter, fylla former och exportera till PPT, PPTX och ODP."
---
Visar hur man infogar och får åtkomst till bilder med **Aspose.Slides for PHP via Java**. Exemplen nedan placerar en bild på en bild och hämtar den sedan.

## **Lägg till en bild**

Den här koden infogar en bild som en bildram på den första bilden.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Lägg till bilden i presentationens resurser.
        $ppImage = $presentation->getImages()->addImage($image);

        // Infoga en bildram som visar bilden på den första bilden.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Få åtkomst till en bild**

Detta exempel säkerställer att en bild innehåller en bildram och får sedan åtkomst till den första som den hittar.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Åtkomst till den första PictureFrame på bilden.
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