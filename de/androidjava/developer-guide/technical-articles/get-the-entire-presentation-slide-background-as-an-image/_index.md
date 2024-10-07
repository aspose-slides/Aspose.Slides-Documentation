---
title: Erhalten Sie den gesamten Hintergrund einer Präsentationsfolie als Bild
type: docs
weight: 95
url: /androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- folie
- hintergrund
- folienhintergrund
- hintergrund zu einem bild
- PowerPoint
- PPT
- PPTX
- PowerPoint-präsentation
- Java
- Aspose.Slides für Android über Java
---

In PowerPoint-Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Neben dem Bild, das als [folienhintergrund](/slides/androidjava/presentation-background/) gesetzt ist, kann der endgültige Hintergrund durch das Präsentationsthema, das Farbschema und die Formen, die auf der Masterfolie und der Layoutfolie platziert sind, beeinflusst werden.

Aspose.Slides für Android über Java bietet keine einfache Methode, um den gesamten Folienhintergrund der Präsentation als Bild zu extrahieren, aber Sie können die folgenden Schritte ausführen, um dies zu tun:
1. Laden Sie die Präsentation mithilfe der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Foliengröße aus der Präsentation.
1. Wählen Sie eine Folie aus.
1. Erstellen Sie eine temporäre Präsentation.
1. Setzen Sie die gleiche Foliengröße in der temporären Präsentation.
1. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
1. Löschen Sie die Formen von der geklonten Folie.
1. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Folienhintergrund der Präsentation als Bild.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```