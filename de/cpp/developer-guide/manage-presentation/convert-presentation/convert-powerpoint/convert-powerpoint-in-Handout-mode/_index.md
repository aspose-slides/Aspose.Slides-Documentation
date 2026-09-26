---
title: PowerPoint-Präsentationen im Handout-Modus mit C++ konvertieren
linktitle: Handout-Modus
type: docs
weight: 150
url: /de/cpp/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Handout-Modus
- Handout
- PPT
- PPTX
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Konvertieren Sie Präsentationen in Handouts mit C++. Legen Sie Folien pro Seite fest, behalten Sie Notizen bei, exportieren Sie zu PDF oder Bildern mit Aspose.Slides, inkl. Beispielcode. Testen Sie es kostenlos."
---
## **Einleitung**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handzetteln zum Drucken im Handout‑Modus. Dieser Modus ermöglicht es Ihnen, zu konfigurieren, wie mehrere Folien auf einer einzelnen Seite angezeigt werden, was ihn für Konferenzen, Seminare und andere Veranstaltungen nützlich macht. Sie können diesen Modus aktivieren, indem Sie die `set_SlidesLayoutOptions`‑Methode in den [IPdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ihtmloptions/) und [ITiffOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/itiffoptions/)‑Schnittstellen aufrufen.

Um die Handout‑Seitengröße und -Ausrichtung vor dem Export festzulegen, siehe [Notes Page Size](/slides/de/cpp/notes-size/).

## **Handout‑Modus‑Export**

Um den Handout‑Modus zu konfigurieren, verwenden Sie das [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/handoutlayoutingoptions/)‑Objekt, das bestimmt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

Unten finden Sie ein Codebeispiel, das zeigt, wie man eine Präsentation im Handout‑Modus in PDF konvertiert.

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Load a presentation.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 Folien horizontal auf einer Seite
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // Foliennummern drucken
slidesLayoutOptions->set_PrintFrameSlide(true);                      // Ein Rahmen um die Folien drucken
slidesLayoutOptions->set_PrintComments(false);                       // keine Kommentare

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Beachten Sie, dass die `set_SlidesLayoutOptions`‑Methode nur für bestimmte Ausgabeformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

### Was ist die maximale Anzahl von Folien‑Miniaturansichten pro Seite im Handout‑Modus?

Aspose.Slides unterstützt [presets](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/handouttype/) von bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

### Kann ich ein benutzerdefiniertes Raster definieren, z. B. 5 oder 8 Folien pro Seite?

Nein. Die Anzahl und Anordnung der Miniaturansichten werden strikt durch die [HandoutType](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/handouttype/)‑Aufzählung gesteuert; beliebige Layouts werden nicht unterstützt.

### Kann ich ausgeblendete Folien in die Handout‑Ausgabe einbeziehen?

Ja. Verwenden Sie die `set_ShowHiddenSlides`‑Methode in den Exporteinstellungen für das Zielformat, z. B. [PdfOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/tiffoptions/).