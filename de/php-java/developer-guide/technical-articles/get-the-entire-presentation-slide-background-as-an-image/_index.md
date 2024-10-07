---
title: Holen Sie sich den gesamten Präsentationsfolienhintergrund als Bild
type: docs
weight: 95
url: /php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- folie
- hintergrund
- folienhintergrund
- hintergrund zu einem bild
- PowerPoint
- PPT
- PPTX
- PowerPoint-Präsentation
- Java
- Php
- Aspose.Slides für PHP über Java
---

In PowerPoint-Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Neben dem Bild, das als [folienhintergrund](/slides/php-java/presentation-background/) festgelegt wurde, kann der endgültige Hintergrund durch das Präsentationsthema, das Farbschema und die Formen beeinflusst werden, die auf der Masterfolie und der Layoutfolie platziert sind.

Aspose.Slides für PHP über Java bietet keine einfache Methode, um den gesamten Folienhintergrund der Präsentation als Bild zu extrahieren, aber Sie können die folgenden Schritte ausführen, um dies zu tun:
1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Foliengröße aus der Präsentation.
1. Wählen Sie eine Folie aus.
1. Erstellen Sie eine temporäre Präsentation.
1. Stellen Sie die gleiche Foliengröße in der temporären Präsentation ein.
1. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
1. Löschen Sie die Formen von der geklonten Folie.
1. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Folienhintergrund der Präsentation als Bild.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```