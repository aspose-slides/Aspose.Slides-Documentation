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
description: "Präsentationen in Handouts in Java konvertieren. Folien pro Seite festlegen, Notizen beibehalten, mit Aspose.Slides für Android in PDF oder Bilder exportieren, inklusive Beispielcode. Kostenlos testen."
---
## **Einleitung**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handouts zum Drucken im Handout‑Modus. Dieser Modus ermöglicht es, zu konfigurieren, wie mehrere Folien auf einer einzigen Seite erscheinen, was für Konferenzen, Seminare und andere Veranstaltungen nützlich ist. Sie können diesen Modus aktivieren, indem Sie die `setSlidesLayoutOptions`‑Methode in den [IPdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihtmloptions/) und [ITiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itiffoptions/) Schnittstellen festlegen.

Um die Handout‑Seitengröße und -Ausrichtung vor dem Export festzulegen, siehe [Notizseiten‑Größe](/slides/de/androidjava/notes-size/).

## **Export im Handout‑Modus**

Um den Handout‑Modus zu konfigurieren, verwenden Sie das [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/handoutlayoutingoptions/) Objekt, das bestimmt, wie viele Folien auf einer einzelnen Seite platziert werden und andere Anzeigeparameter.

Unten finden Sie ein Codebeispiel, das zeigt, wie man eine Präsentation im Handout‑Modus in PDF konvertiert.

```java
import com.aspose.slides.*;

// Präsentation laden.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Exportoptionen festlegen.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 Folien pro Seite horizontal
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // Foliennummern drucken
	slidesLayoutOptions.setPrintFrameSlide(true);                     // Rahmen um Folien drucken
	slidesLayoutOptions.setPrintComments(false);                      // keine Kommentare

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Präsentation mit dem gewählten Layout nach PDF exportieren.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Beachten Sie, dass die `setSlidesLayoutOptions`‑Methode nur für bestimmte Ausgabformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

**Was ist die maximale Anzahl von Folienminiaturbildern pro Seite im Handout‑Modus?**

Aspose.Slides unterstützt [presets](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/handouttype/) bis zu 9 Miniaturbilder pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster definieren, z. B. 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Anordnung der Miniaturbilder wird strikt durch die Klasse [HandoutType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich versteckte Folien in der Handout‑Ausgabe einbeziehen?**

Ja. Aktivieren Sie die versteckten Folien mit der `setShowHiddenSlides`‑Methode in den Export‑Einstellungen für das Zielformat, zum Beispiel [PdfOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/).