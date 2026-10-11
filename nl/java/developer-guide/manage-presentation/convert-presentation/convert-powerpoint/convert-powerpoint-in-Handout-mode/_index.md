---
title: PowerPoint-presentaties converteren in handout-modus met Java
linktitle: Handout-modus
type: docs
weight: 150
url: /nl/java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint converteren
- presentatie converteren
- handout-modus
- handout
- PPT
- PPTX
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Converteer presentaties naar hand-outs in Java. Stel het aantal dia's per pagina in, behoud notities, exporteer naar PDF of afbeeldingen met Aspose.Slides, met voorbeeldcode in Java. Probeer het gratis."
---
## **Introductie**

Met Aspose.Slides kunt u presentaties converteren naar uitvoerformaten die Handout-modus ondersteunen. In deze modus worden meerdere dia's op één pagina geplaatst, wat handig is voor het afdrukken van presentatiematerialen voor conferenties, seminars en soortgelijke evenementen.

Handout-modus wordt geconfigureerd via de `setSlidesLayoutOptions`-methode, die beschikbaar is in [IPdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihtmloptions/) en [ITiffOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itiffoptions/). Gebruik om de handout-indeling te definiëren het [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/handoutlayoutingoptions/) object.

Om de afmetingen en oriëntatie van de handout-pagina vóór de export in te stellen, zie [Notes Page Size](/slides/nl/java/notes-size/).

## **Handout-modus Export**

Om een presentatie in Handout-modus te exporteren, stelt u de `setSlidesLayoutOptions`-methode in voor de doel-exportopties en kent u een [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/handoutlayoutingoptions/) instance toe die het aantal dia's per pagina en bijbehorende weergave‑parameters definieert.

Hieronder staat een code‑voorbeeld dat laat zien hoe u een presentatie naar PDF converteert in Handout-modus.

```java
import com.aspose.slides.*;

// Laad een presentatie.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Stel de exportopties in.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 dia's op één pagina horizontaal
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // druk dia nummers af
    slidesLayoutOptions.setPrintFrameSlide(true);                     // teken een kader rond dia's
    slidesLayoutOptions.setPrintComments(false);                      // geen opmerkingen

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Exporteer de presentatie naar PDF met de gekozen lay-out.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" title="Warning" %}}
Houd er rekening mee dat de `setSlidesLayoutOptions`-methode alleen beschikbaar is voor bepaalde uitvoerformaten, zoals PDF, HTML, TIFF, en bij het renderen als afbeeldingen.
{{% /alert %}} 

## **FAQ**

**Wat is het maximale aantal dia‑miniaturen per pagina in Handout-modus?**

Aspose.Slides ondersteunt [presets](https://reference.aspose.com/slides/nl/java/com.aspose.slides/handouttype/) tot 9 miniaturen per pagina met horizontale of verticale volgorde: 1, 2, 3, 4 (horizontaal/verticaal), 6 (horizontaal/verticaal) en 9 (horizontaal/verticaal).

**Kan ik een aangepast raster definiëren, bijvoorbeeld 5 of 8 dia's per pagina?**

Nee. Het aantal en de volgorde van miniaturen worden strikt beheerd door de [HandoutType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/handouttype/)‑klasse; willekeurige indelingen worden niet ondersteund.

**Kan ik verborgen dia's opnemen in de Handout-uitvoer?**

Ja. Schakel de verborgen dia's in met de `setShowHiddenSlides`-methode in de exportinstellingen voor het doelformaat, zoals [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/htmloptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tiffoptions/).