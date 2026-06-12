---
title: Afbeelding
type: docs
weight: 50
url: /nl/php-java/examples/elements/picture/
keywords:
- afbeelding
- afbeeldingsframe
- afbeelding toevoegen
- afbeelding benaderen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Werken met afbeeldingen in PHP met Aspose.Slides: invoegen, vervangen, bijsnijden, comprimeren, transparantie en effecten aanpassen, vormen vullen, en exporteren naar PPT, PPTX en ODP."
---
Toont hoe je afbeeldingen kunt invoegen en benaderen met **Aspose.Slides for PHP via Java**. De onderstaande voorbeelden plaatsen een afbeelding op een dia en halen deze daarna op.

## **Add a Picture**

Deze code voegt een afbeelding in als een afbeeldingframe op de eerste dia.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Voeg de afbeelding toe aan de presentatieresources.
        // Voeg een afbeeldingsframe toe dat de afbeelding weergeeft op de eerste dia.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access a Picture**

Dit voorbeeld controleert of een dia een afbeeldingframe bevat en benadert vervolgens de eerste die het vindt.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Toegang tot het eerste PictureFrame op de dia.
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