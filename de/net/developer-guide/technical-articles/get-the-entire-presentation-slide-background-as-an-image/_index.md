---
title: Den gesamten Folienhintergrund aus einer Präsentation als Bild extrahieren
linktitle: Gesamter Folienhintergrund
type: docs
weight: 95
url: /de/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- Folienhintergrund
- Endhintergrund
- Hintergrund extrahieren
- vollständiger Hintergrund
- Hintergrund zu Bild
- PPT-Hintergrund
- PPTX-Hintergrund
- ODP-Hintergrund
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Vollständige Folienhintergründe als Bilder aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET extrahieren und so visuelle Arbeitsabläufe optimieren."
---

## **Gesamten Folienhintergrund abrufen**

In PowerPoint-Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Zusätzlich zum als [Folienhintergrund](/slides/de/net/presentation-background/) festgelegten Bild kann der endgültige Hintergrund vom Präsentationsthema, Farbschema und den Formen, die auf der Masterfolie und der Layoutfolie platziert wurden, beeinflusst werden.

Aspose.Slides für .NET bietet keine einfache Methode zum Extrahieren des gesamten Folienhintergrunds einer Präsentation als Bild, aber Sie können die folgenden Schritte ausführen:
1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Klasse.
1. Ermitteln Sie die Foliengröße aus der Präsentation.
1. Wählen Sie eine Folie aus.
1. Erstellen Sie eine temporäre Präsentation.
1. Setzen Sie die gleiche Foliengröße in der temporären Präsentation.
1. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
1. Löschen Sie die Formen von der geklonten Folie.
1. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Folienhintergrund einer Präsentation als Bild.
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


## **FAQ**

**Werden komplexe Verläufe, Texturen oder Bildfüllungen einer Masterfolie im resultierenden Hintergrundbild erhalten?**

Ja. Aspose.Slides rendert Gradienten-, Bild- und Texturfüllungen, die auf der Folie, dem Layout oder dem Master definiert sind. Wenn Sie das Aussehen von geerbten Mastern isolieren müssen, [setzen Sie einen eigenen Hintergrund](/slides/de/net/presentation-background/) auf der aktuellen Folie, bevor Sie exportieren.

**Kann ich vor dem Speichern ein Wasserzeichen zum resultierenden Hintergrundbild hinzufügen?**

Ja. Sie können ein [Wasserzeichen hinzufügen](/slides/de/net/watermark/) Form oder Bild auf einer Arbeits-[Kopie der Folie](/slides/de/net/clone-slides/) (hinter anderem Inhalt platziert) hinzufügen und dann exportieren. So erhalten Sie ein Hintergrundbild, in das das Wasserzeichen eingebettet ist.

**Kann ich den Hintergrund für ein bestimmtes Layout oder einen Master erhalten, ohne ihn an eine vorhandene Folie zu binden?**

Ja. Greifen Sie auf den gewünschten Master oder das Layout zu, wenden Sie ihn auf eine [temporäre Folie](/slides/de/net/clone-slides/) mit der erforderlichen Größe an und exportieren Sie diese Folie, um den aus diesem Layout oder Master abgeleiteten Hintergrund zu erhalten.

**Gibt es Lizenzbeschränkungen, die den Bildexport beeinflussen?**

Renderfunktionen sind mit einer [gültigen Lizenz](/slides/de/net/licensing/) vollständig verfügbar. Im Evaluierungsmodus kann die Ausgabe Einschränkungen wie ein Wasserzeichen enthalten. Aktivieren Sie die Lizenz einmal pro Prozess, bevor Sie Batch-Exporte ausführen.