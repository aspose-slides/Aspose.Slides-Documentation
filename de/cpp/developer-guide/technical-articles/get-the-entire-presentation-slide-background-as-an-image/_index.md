---
title: Den gesamten Folienhintergrund aus einer Präsentation als Bild erhalten
linktitle: Gesamter Folienhintergrund
type: docs
weight: 95
url: /de/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- Folienhintergrund
- endgültiger Hintergrund
- Hintergrund extrahieren
- gesamter Hintergrund
- Hintergrund zu Bild
- PPT-Hintergrund
- PPTX-Hintergrund
- ODP-Hintergrund
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Extrahieren Sie vollständige Folienhintergründe als Bilder aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++, um visuelle Arbeitsabläufe zu optimieren."
---

## **Den gesamten Folienhintergrund abrufen**

In PowerPoint‑Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Zusätzlich zu dem als [Folienhintergrund](/slides/de/cpp/presentation-background/) festgelegten Bild kann der endgültige Hintergrund vom Präsentationsthema, Farbschema und den auf der Master‑Folien und Layout‑Folien platzierten Formen beeinflusst werden.

Aspose.Slides für C++ bietet keine einfache Methode, um den gesamten Folienhintergrund einer Präsentation als Bild zu extrahieren, aber Sie können die folgenden Schritte ausführen:
1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Ermitteln Sie die Foliengröße aus der Präsentation.
1. Wählen Sie eine Folie aus.
1. Erstellen Sie eine temporäre Präsentation.
1. Setzen Sie dieselbe Foliengröße in der temporären Präsentation.
1. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
1. Löschen Sie die Formen aus der geklonten Folie.
1. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Folienhintergrund einer Präsentation als Bild.
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


## **FAQ**

**Werden komplexe Farbverläufe, Texturen oder Bildfüllungen einer Master‑Folien im resultierenden Hintergrundbild erhalten?**

Ja. Aspose.Slides rendert Farbverläufe, Bild- und Texturfüllungen, die auf der Folie, dem Layout oder dem Master definiert sind. Wenn Sie das Aussehen von geerbten Mastern isolieren müssen, [setzen Sie einen eigenen Hintergrund](/slides/de/cpp/presentation-background/) auf der aktuellen Folie, bevor Sie exportieren.

**Kann ich dem resultierenden Hintergrundbild vor dem Speichern ein Wasserzeichen hinzufügen?**

Ja. Sie können ein [Wasserzeichen](/slides/de/cpp/watermark/) als Form oder Bild auf einer Arbeits-[Kopie der Folie](/slides/de/cpp/clone-slides/) (hinter anderem Inhalt platziert) hinzufügen und dann exportieren. So erzeugen Sie ein Hintergrundbild, in das das Wasserzeichen eingebettet ist.

**Kann ich den Hintergrund für ein bestimmtes Layout oder einen Master erhalten, ohne ihn an eine vorhandene Folie zu binden?**

Ja. Greifen Sie auf den gewünschten Master oder das gewünschte Layout zu, wenden Sie es auf eine [temporäre Folie](/slides/de/cpp/clone-slides/) mit der erforderlichen Größe an und exportieren Sie diese Folie, um den aus diesem Layout oder Master abgeleiteten Hintergrund zu erhalten.

**Gibt es Lizenzbeschränkungen, die den Bildexport beeinflussen?**

Render‑Funktionen sind mit einer [gültigen Lizenz](/slides/de/cpp/licensing/) vollständig verfügbar. Im Evaluationsmodus kann die Ausgabe Einschränkungen wie ein Wasserzeichen enthalten. Aktivieren Sie die Lizenz einmal pro Prozess, bevor Sie Stapel‑Exporte ausführen.