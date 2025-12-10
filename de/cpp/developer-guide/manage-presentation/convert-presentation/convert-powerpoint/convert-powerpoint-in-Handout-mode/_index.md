---
title: Präsentationen im Handout‑Modus mit C++ konvertieren
linktitle: Handout‑Modus
type: docs
weight: 150
url: /de/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Handout‑Modus
- Handout
- PPT
- PPTX
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Konvertieren Sie Präsentationen in Handouts in C++. Legen Sie Folien pro Seite fest, behalten Sie Notizen, exportieren Sie zu PDF oder Bildern mit Aspose.Slides, inklusive Beispielcode. Testen Sie es kostenlos."
---

## **Handout-Modus Export**

Aspose.Slides stellt die Möglichkeit bereit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handouts zum Drucken im Handout‑Modus. Dieser Modus ermöglicht es, zu konfigurieren, wie mehrere Folien auf einer einzigen Seite erscheinen, was für Konferenzen, Seminare und andere Veranstaltungen nützlich ist. Sie können diesen Modus aktivieren, indem Sie die `set_SlidesLayoutOptions`‑Methode in den Schnittstellen [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/) und [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) festlegen.

Um den Handout‑Modus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/), das bestimmt, wie viele Folien auf einer einzigen Seite platziert werden und weitere Anzeigeparameter.

Untenstehend ein Codebeispiel, das zeigt, wie eine Präsentation im Handout‑Modus in PDF konvertiert wird.
```cpp
// Lade eine Präsentation.
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

Beachten Sie, dass die `set_SlidesLayoutOptions`‑Methode nur für bestimmte Ausgabformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.

{{% /alert %}} 

## **FAQ**

**Was ist die maximale Anzahl von Folienminiaturansichten pro Seite im Handout‑Modus?**

Aspose.Slides unterstützt [Voreinstellungen](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) von bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster festlegen, z. B. 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Anordnung der Miniaturansichten wird strikt durch die Aufzählung [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich ausgeblendete Folien in die Handout‑Ausgabe aufnehmen?**

Ja. Verwenden Sie die `set_ShowHiddenSlides`‑Methode in den Exporteinstellungen für das Ziel­format, wie zum Beispiel [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/).