---
title: Image
type: docs
weight: 50
url: /fr/php-java/examples/elements/picture/
keywords:
- image
- cadre d'image
- ajouter une image
- accéder à une image
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Travaillez avec les images en PHP à l'aide d'Aspose.Slides : insérez, remplacez, recadrez, compressez, ajustez la transparence et les effets, remplissez des formes, et exportez vers PPT, PPTX et ODP."
---
Montre comment insérer et accéder aux images en utilisant **Aspose.Slides for PHP via Java**. Les exemples ci-dessous placent une image sur une diapositive, puis la récupèrent.

## **Ajouter une image**

Ce code insère une image en tant que cadre d'image sur la première diapositive.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Ajoutez l'image aux ressources de la présentation.
        // Insérez un cadre d'image affichant l'image sur la première diapositive.
        $ppImage = $presentation->getImages()->addImage($image);

        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accéder à une image**

Cet exemple vérifie qu'une diapositive contient un cadre d'image, puis accède au premier qu'il trouve.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accédez au premier PictureFrame sur la diapositive.
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