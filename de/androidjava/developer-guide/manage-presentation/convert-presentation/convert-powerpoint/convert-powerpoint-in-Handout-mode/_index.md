---
title: PowerPoint-Präsentationen im Handout-Modus auf Android konvertieren
linktitle: Handout-Modus
type: docs
weight: 150
url: /de/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Handout-Modus
- Handout
- PPT
- PPTX
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Präsentationen in Handouts in Java konvertieren. Folien pro Seite festlegen, Notizen beibehalten, mit Aspose.Slides für Android in PDF oder Bilder exportieren, inklusive Beispielcode. Jetzt kostenlos testen."
---
## **Einführung**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handouts zum Drucken im Handout‑Modus. Dieser Modus ermöglicht es, zu konfigurieren, wie mehrere Folien auf einer einzelnen Seite erscheinen, was für Konferenzen, Seminare und andere Veranstaltungen nützlich ist. Sie können diesen Modus aktivieren, indem Sie die `setSlidesLayoutOptions`‑Methode in den [IPdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihtmloptions/) und [ITiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiffoptions/) Schnittstellen setzen.

## **Export im Handout‑Modus**

Um den Handout‑Modus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/handoutlayoutingoptions/), das bestimmt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

Unten ist ein Codebeispiel, das zeigt, wie man eine Präsentation im Handout‑Modus in PDF konvertiert.

```java
// Präsentation laden.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Exportoptionen festlegen.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 Folien horizontal auf einer Seite
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // Foliennummern drucken
	slidesLayoutOptions.setPrintFrameSlide(true);                     // Rahmen um Folien drucken
	slidesLayoutOptions.setPrintComments(false);                      // keine Kommentare

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Präsentation mit dem gewählten Layout als PDF exportieren.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
Beachten Sie, dass die `setSlidesLayoutOptions`‑Methode nur für bestimmte Ausgabformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

**Wie viele Folienminiaturansichten können maximal pro Seite im Handout‑Modus angezeigt werden?**  
Aspose.Slides unterstützt [presets](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/handouttype/) bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster festlegen, z. B. 5 oder 8 Folien pro Seite?**  
Nein. Die Anzahl und Anordnung der Miniaturansichten wird streng von der Klasse [HandoutType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich versteckte Folien im Handout‑Ausgabe einbeziehen?**  
Ja. Aktivieren Sie versteckte Folien über die `setShowHiddenSlides`‑Methode in den Export‑Einstellungen des Zielformats, z. B. [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/).