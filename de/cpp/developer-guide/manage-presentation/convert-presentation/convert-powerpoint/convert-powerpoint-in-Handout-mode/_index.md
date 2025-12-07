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
description: "Präsentationen in Handouts mit C++ konvertieren. Folien pro Seite festlegen, Notizen behalten, mit Aspose.Slides in PDF oder Bilder exportieren, inklusive Beispielcode. Kostenlos testen."
---

## **Handout-Modus-Export**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handzetteln für den Druck im Handout-Modus. Der Modus ermöglicht es, zu konfigurieren, wie mehrere Folien auf einer einzigen Seite angezeigt werden, was für Konferenzen, Seminare und andere Veranstaltungen nützlich ist. Sie können diesen Modus aktivieren, indem Sie die Methode `set_SlidesLayoutOptions` in den Schnittstellen [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/) und [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) festlegen.

Um den Handout-Modus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/), das bestimmt, wie viele Folien auf einer einzigen Seite platziert werden und weitere Anzeigeparameter.

Unten finden Sie ein Codebeispiel, das zeigt, wie eine Präsentation im Handout-Modus in PDF konvertiert wird.
```cpp
// Lade eine Präsentation.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Setze die Exportoptionen.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 Folien horizontal auf einer Seite
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
Beachten Sie, dass die Methode `set_SlidesLayoutOptions` nur für bestimmte Ausgabformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

**Was ist die maximale Anzahl von Folien‑Miniaturansichten pro Seite im Handout-Modus?**

Aspose.Slides unterstützt [presets](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) von bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster definieren, z. B. 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Anordnung der Miniaturansichten werden strikt durch die Aufzählung [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich ausgeblendete Folien in die Handout‑Ausgabe einbeziehen?**

Ja. Verwenden Sie die Methode `set_ShowHiddenSlides` in den Exporteinstellungen für das Zielformat, z. B. [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/).