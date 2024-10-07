---
title: Die gesamte Präsentationsfolien-Hintergrund als Bild erhalten
type: docs
weight: 95
url: /cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- Folie
- Hintergrund
- Folienhintergrund
- Hintergrund als Bild
- PowerPoint
- PPT
- PPTX
- PowerPoint-Präsentation
- C++
- Aspose.Slides für C++
---

In PowerPoint-Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Neben dem Bild, das als [Folienhintergrund](/slides/cpp/presentation-background/) festgelegt ist, kann der endgültige Hintergrund durch das Präsentationsthema, das Farbschema und die Formen, die auf der Master- und Layoutfolie platziert sind, beeinflusst werden.

Aspose.Slides für C++ bietet keine einfache Methode, um den gesamten Folienhintergrund der Präsentation als Bild zu extrahieren, aber Sie können die folgenden Schritte ausführen, um dies zu tun:
1. Laden Sie die Präsentation mithilfe der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie die Foliengröße von der Präsentation.
1. Wählen Sie eine Folie aus.
1. Erstellen Sie eine temporäre Präsentation.
1. Setzen Sie dieselbe Foliengröße in der temporären Präsentation.
1. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
1. Löschen Sie die Formen von der geklonten Folie.
1. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Präsentationsfolien-Hintergrund als Bild.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```