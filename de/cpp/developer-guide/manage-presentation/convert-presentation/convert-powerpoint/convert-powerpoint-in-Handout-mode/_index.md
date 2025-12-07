---
title: PowerPoint-Präsentationen im Handout-Modus mit C++ konvertieren
linktitle: Handout-Modus
type: docs
weight: 150
url: /de/cpp/convert-powerpoint-in-Handout-mode/
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
description: "Konvertieren Sie Präsentationen in Handouts mit C++. Legen Sie Folien pro Seite fest, behalten Sie Notizen bei, exportieren Sie zu PDF oder Bildern mit Aspose.Slides, inklusive Beispielcode. Testen Sie es kostenlos."
---

## **Handout-Modus Export**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handzetteln zum Drucken im Handout-Modus. Dieser Modus ermöglicht es Ihnen, zu konfigurieren, wie mehrere Folien auf einer einzigen Seite angezeigt werden, was ihn für Konferenzen, Seminare und andere Veranstaltungen nützlich macht. Sie können diesen Modus aktivieren, indem Sie die `set_SlidesLayoutOptions`-Methode in den [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/) und [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) Schnittstellen festlegen.

Um den Handout-Modus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/), das festlegt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

Unten finden Sie ein Codebeispiel, das zeigt, wie eine Präsentation im Handout-Modus in PDF konvertiert wird.
```cpp
// Präsentation laden.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 Folien auf einer Seite horizontal
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // Foliennummern drucken
slidesLayoutOptions->set_PrintFrameSlide(true);                      // Rahmen um Folien drucken
slidesLayoutOptions->set_PrintComments(false);                       // keine Kommentare

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 
Beachten Sie, dass die `set_SlidesLayoutOptions`-Methode nur für bestimmte Ausgabefomate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

**Was ist die maximale Anzahl von Folienminiaturansichten pro Seite im Handout-Modus?**

Aspose.Slides unterstützt [presets](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster definieren, z.B. 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Anordnung der Miniaturansichten wird streng durch die Aufzählung [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich versteckte Folien in die Handout-Ausgabe einbeziehen?**

Ja. Verwenden Sie die `set_ShowHiddenSlides`-Methode in den Exporteinstellungen für das Zielformat, z.B. [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/).