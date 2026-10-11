---
title: PowerPoint-presentaties converteren in hand‑out‑modus op Android
linktitle: Handout-modus
type: docs
weight: 150
url: /nl/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint converteren
- presentatie converteren
- hand‑out‑modus
- hand‑out
- PPT
- PPTX
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Converteer presentaties naar hand‑outs in Java. Stel dia's per pagina in, behoud notities, exporteer naar PDF of afbeeldingen met Aspose.Slides voor Android, inclusief voorbeeldcode. Probeer het gratis."
---
## **Inleiding**

Aspose.Slides biedt de mogelijkheid om presentaties te converteren naar verschillende formaten, inclusief het maken van hand‑outs voor afdrukken in Handout-modus. Deze modus stelt je in staat om te configureren hoe meerdere dia's op één pagina verschijnen, wat het nuttig maakt voor congressen, seminars en andere evenementen. Je kunt deze modus inschakelen door de `setSlidesLayoutOptions`‑methode in te stellen op de [IPdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihtmloptions/) en [ITiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiffoptions/) interfaces.

Om de afmeting en orientatie van de hand‑outpagina in te stellen vóór export, zie [Notities Paginagrootte](/slides/nl/androidjava/notes-size/).

## **Handout-modus Export**

Om Handout-modus te configureren, gebruik je het [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/handoutlayoutingoptions/) object, dat bepaalt hoeveel dia's op één pagina worden geplaatst en andere weergave‑parameters.

Hieronder staat een codevoorbeeld dat laat zien hoe je een presentatie naar PDF converteert in Handout-modus.

```java
import com.aspose.slides.*;

// Laad een presentatie.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Stel de exportopties in.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 dia's op één pagina horizontaal
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // druk dia‑nummers af
	slidesLayoutOptions.setPrintFrameSlide(true);                     // teken een kader om de dia's
	slidesLayoutOptions.setPrintComments(false);                      // geen opmerkingen

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Exporteer de presentatie naar PDF met de gekozen lay‑out.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Houd er rekening mee dat de `setSlidesLayoutOptions`‑methode alleen beschikbaar is voor bepaalde uitvoerformaten, zoals PDF, HTML, TIFF, en bij het renderen als afbeeldingen.
{{% /alert %}} 

## **FAQ**

**Wat is het maximale aantal dia‑miniaturen per pagina in Handout-modus?**

Aspose.Slides ondersteunt [presets](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/handouttype/) tot 9 miniaturen per pagina met horizontale of verticale ordening: 1, 2, 3, 4 (horizontaal/verticaal), 6 (horizontaal/verticaal) en 9 (horizontaal/verticaal).

**Kan ik een aangepast raster definiëren, bijvoorbeeld 5 of 8 dia's per pagina?**

Nee. Het aantal en de volgorde van miniaturen worden strikt beheerd door de [HandoutType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/handouttype/) klasse; willekeurige lay‑outs worden niet ondersteund.

**Kan ik verborgen dia's opnemen in de Handout‑uitvoer?**

Ja. Schakel de verborgen dia's in met behulp van de `setShowHiddenSlides`‑methode in de exportinstellingen voor het doel­formaat, zoals [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/htmloptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/).