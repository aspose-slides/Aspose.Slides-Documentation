---
title: Holen Sie sich den gesamten Hintergrund der Präsentationsfolie als Bild
type: docs
weight: 95
url: /de/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- folie
- hintergrund
- folienhintergrund
- hintergrund zu einem bild
- PowerPoint
- PPT
- PPTX
- PowerPoint-Präsentation
- C#
- VB.NET
- Aspose.Slides für .NET
---

In PowerPoint-Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Neben dem Bild, das als [Folienhintergrund](/slides/de/net/presentation-background/) festgelegt ist, kann der endgültige Hintergrund durch das Präsentationsthema, das Farbschema und die Formen, die auf der Masterfolie und der Layoutfolie platziert sind, beeinflusst werden.

Aspose.Slides für .NET bietet keine einfache Methode, um den gesamten Hintergrund der Präsentationsfolie als Bild zu extrahieren, aber Sie können die folgenden Schritte ausführen, um dies zu tun:
1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Foliengröße aus der Präsentation.
1. Wählen Sie eine Folie aus.
1. Erstellen Sie eine temporäre Präsentation.
1. Setzen Sie die gleiche Foliengröße in der temporären Präsentation.
1. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
1. Löschen Sie die Formen von der geklonten Folie.
1. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Hintergrund der Präsentationsfolie als Bild.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```