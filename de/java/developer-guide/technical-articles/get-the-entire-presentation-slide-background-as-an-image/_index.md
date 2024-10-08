---
title: Holen Sie sich den gesamten Hintergrund der Präsentationsfolie als Bild
type: docs
weight: 95
url: /de/java/get-the-entire-presentation-slide-background-as-an-image/
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
- Aspose.Slides für Java
---

In PowerPoint-Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Neben dem Bild, das als [Folienhintergrund](/slides/de/java/presentation-background/) festgelegt ist, kann der endgültige Hintergrund durch das Präsentationsthema, das Farbschema und die Formen, die auf der Masterfolie und Layoutfolie platziert sind, beeinflusst werden.

Aspose.Slides für Java bietet keine einfache Methode, um den gesamten Folienhintergrund der Präsentation als Bild zu extrahieren, aber Sie können die folgenden Schritte durchführen, um dies zu tun:
1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
2. Holen Sie die Foliengröße der Präsentation ab.
3. Wählen Sie eine Folie aus.
4. Erstellen Sie eine temporäre Präsentation.
5. Setzen Sie die gleiche Foliengröße in der temporären Präsentation.
6. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
7. Löschen Sie die Formen von der geklonten Folie.
8. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Folienhintergrund der Präsentation als Bild.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```