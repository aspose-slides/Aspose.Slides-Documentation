---
title: Obraz
type: docs
weight: 50
url: /pl/php-java/examples/elements/picture/
keywords:
- obraz
- ramka obrazu
- dodaj obraz
- uzyskaj dostęp do obrazu
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Pracuj z obrazami w PHP przy użyciu Aspose.Slides: wstawiaj, zamieniaj, przycinaj, kompresuj, dostosowuj przezroczystość i efekty, wypełniaj kształty oraz eksportuj do formatów PPT, PPTX i ODP."
---
Pokazuje, jak wstawiać i uzyskiwać dostęp do obrazów przy użyciu **Aspose.Slides for PHP via Java**. Poniższe przykłady umieszczają obraz na slajdzie, a następnie go pobierają.

## **Dodaj obraz**

Ten kod wstawia obraz jako ramkę obrazu na pierwszym slajdzie.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Dodaj obraz do zasobów prezentacji.
        $ppImage = $presentation->getImages()->addImage($image);

        // Wstaw ramkę obrazu wyświetlającą obraz na pierwszym slajdzie.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Uzyskaj dostęp do obrazu**

Ten przykład zapewnia, że slajd zawiera ramkę obrazu, a następnie uzyskuje dostęp do pierwszej znalezionej.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Uzyskaj dostęp do pierwszej ramki obrazu na slajdzie.
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