---
title: PowerPoint-Präsentationen im Handout-Modus auf Android konvertieren
linktitle: Handout-Modus
type: docs
weight: 150
url: /de/androidjava/convert-powerpoint-in-Handout-mode/
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
description: "Präsentationen in Handouts in Java konvertieren. Folien pro Seite festlegen, Notizen beibehalten, mit Aspose.Slides für Android in PDF oder Bilder exportieren, inklusive Beispielcode. Testen Sie es kostenlos."
---

## **Handout-Modus Export**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handzetteln zum Druck im Handout‑Modus. Dieser Modus ermöglicht die Konfiguration, wie mehrere Folien auf einer einzigen Seite erscheinen, was für Konferenzen, Seminare und andere Veranstaltungen nützlich ist. Sie können diesen Modus aktivieren, indem Sie die Methode `setSlidesLayoutOptions` in den Schnittstellen [IPdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihtmloptions/), und [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) festlegen.

Um den Handout‑Modus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handoutlayoutingoptions/), das bestimmt, wie viele Folien auf einer einzigen Seite platziert werden und weitere Anzeigeparameter.

Unten finden Sie ein Codebeispiel, das zeigt, wie eine Präsentation im Handout‑Modus in PDF konvertiert wird.
```java
// Lade eine Präsentation.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Setze die Exportoptionen.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 Folien auf einer Seite horizontal
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // Foliennummern drucken
	slidesLayoutOptions.setPrintFrameSlide(true);                     // Rahmen um Folien drucken
	slidesLayoutOptions.setPrintComments(false);                      // keine Kommentare

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Exportiere die Präsentation zu PDF mit dem gewählten Layout.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```


{{% alert color="warning" %}} 

Beachten Sie, dass die Methode `setSlidesLayoutOptions` nur für bestimmte Ausgabeformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.

{{% /alert %}} 

## **FAQ**

**Wie lautet die maximale Anzahl von Folienminiaturansichten pro Seite im Handout‑Modus?**

Aspose.Slides unterstützt [Voreinstellungen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) von bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster definieren, z. B. 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Anordnung der Miniaturansichten wird strikt von der Klasse [HandoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich ausgeblendete Folien in die Handout‑Ausgabe einbeziehen?**

Ja. Aktivieren Sie ausgeblendete Folien über die Methode `setShowHiddenSlides` in den Exporteinstellungen für das Zielformat, wie [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/htmloptions/), oder [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/).