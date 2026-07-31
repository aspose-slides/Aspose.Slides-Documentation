---
title: PowerPoint-presentaties converteren in handout-modus op Android
linktitle: Handout-modus
type: docs
weight: 150
url: /nl/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint converteren
- presentatie converteren
- handout-modus
- handout
- PPT
- PPTX
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Converteer presentaties naar handouts in Java. Stel dia's per pagina in, behoud notities, exporteer naar PDF of afbeeldingen met Aspose.Slides voor Android, inclusief voorbeeldcode. Probeer het gratis."
---
## **Inleiding**

Aspose.Slides biedt de mogelijkheid om presentaties om te zetten naar verschillende formaten, inclusief het maken van handouts voor afdrukken in Handout-modus. Deze modus stelt u in staat om te configureren hoe meerdere dia's op één pagina verschijnen, wat handig is voor conferenties, seminars en andere evenementen. U kunt deze modus inschakelen door de `setSlidesLayoutOptions`‑methode in te stellen op de interfaces [IPdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihtmloptions/) en [ITiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itiffoptions/).

## **Exporteren in Handout-modus**

Om Handout-modus te configureren, gebruikt u het object [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/handoutlayoutingoptions/), dat bepaalt hoeveel dia's op één pagina worden geplaatst en andere weergave‑parameters.

Hieronder vindt u een code‑voorbeeld dat laat zien hoe u een presentatie converteert naar PDF in Handout-modus.

```java
// Laad een presentatie.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Stel de exportopties in.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 dia's op één pagina horizontaal
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // afdrukken dia-nummers
	slidesLayoutOptions.setPrintFrameSlide(true);                     // een kader om de dia's afdrukken
	slidesLayoutOptions.setPrintComments(false);                      // geen opmerkingen

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Exporteer de presentatie naar PDF met de gekozen lay-out.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
Houd er rekening mee dat de `setSlidesLayoutOptions`‑methode alleen beschikbaar is voor bepaalde uitvoerformaten, zoals PDF, HTML, TIFF, en bij het renderen als afbeeldingen. 
{{% /alert %}} 

## **Veelgestelde vragen**

**Wat is het maximale aantal dia‑miniaturen per pagina in Handout-modus?**

Aspose.Slides ondersteunt [presets](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/handouttype/) tot 9 miniaturen per pagina met horizontale of verticale ordening: 1, 2, 3, 4 (horizontaal/verticaal), 6 (horizontaal/verticaal) en 9 (horizontaal/verticaal).

**Kan ik een aangepast raster definiëren, bijvoorbeeld 5 of 8 dia's per pagina?**

Nee. Het aantal en de volgorde van miniaturen wordt strikt bepaald door de klasse [HandoutType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/handouttype/); willekeurige lay‑outs worden niet ondersteund.

**Kan ik verborgen dia's opnemen in de Handout‑output?**

Ja. Schakel de verborgen dia's in met de `setShowHiddenSlides`‑methode in de exportinstellingen voor het doelformaat, zoals [PdfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/htmloptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/).