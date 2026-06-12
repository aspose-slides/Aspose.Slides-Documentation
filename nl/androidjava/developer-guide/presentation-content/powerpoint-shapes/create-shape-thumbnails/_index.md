---
title: Maak miniaturen van presentatiesvormen op Android
linktitle: Vormminiaturen
type: docs
weight: 70
url: /nl/androidjava/create-shape-thumbnails/
keywords:
- vormminiatuur
- vormafbeelding
- vorm renderen
- vormrendering
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint-dia's met Aspose.Slides for Android via Java – eenvoudig presentatieminiaturen maken en exporteren."
---
## **Introductie**

Aspose.Slides for Android via Java kan worden gebruikt om presentatiebestanden te maken waarbij elke pagina overeenkomt met een dia. De dia’s kunnen worden bekeken door de presentatiebestanden te openen met Microsoft PowerPoint. Soms moeten ontwikkelaars echter de afbeeldingen van de vormen afzonderlijk bekijken in een beeldviewer. In dergelijke gevallen helpt Aspose.Slides for Android via Java hen om miniatuurafbeeldingen van de dia‑vormen te genereren.

In dit onderwerp laten we zien hoe je dia‑miniaturen kunt genereren in verschillende situaties:

- Een miniatuur van een vorm binnen een dia genereren.
- Een miniatuur van een vorm voor een dia‑vorm met door de gebruiker gedefinieerde afmetingen genereren.
- Een miniatuur van een vorm genereren binnen de grenzen van de vorm‑weergave.

## **Miniatuur van een vorm uit een dia genereren**
Om een miniatuur van een vorm uit een willekeurige dia te genereren met Aspose.Slides for Android via Java, doe je het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of de index.
1. Haal via [Get the shape thumbnail image](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#getImage--) de miniatuurafbeelding van de vorm van de referentiemaandia op met de standaard schaal.
1. Sla de miniatuurafbeelding op in je gewenste beeldformaat.

Deze voorbeeldcode laat zien hoe je een miniatuur van een vorm uit een dia kunt genereren:

```java
// Instantieer een Presentation-klasse die het presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Maak een afbeelding op volledige schaal
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Sla de afbeelding op schijf op in PNG-formaat
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Miniatuur met door gebruiker gedefinieerde schaalfactor genereren**
Om de miniatuur van een vorm van een dia te genereren met Aspose.Slides for Android via Java, doe je het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of de index.
1. Haal via [Get the shape thumbnail image](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) de miniatuurafbeelding van de vorm van de referentiemaandia op met door de gebruiker opgegeven afmetingen.
1. Sla de miniatuurafbeelding op in je gewenste beeldformaat.

Deze voorbeeldcode laat zien hoe je een miniatuur van een vorm kunt genereren op basis van een gedefinieerde schaalfactor:

```java
// Instantieer een Presentation-klasse die het presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Maak een afbeelding op volledige schaal
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Sla de afbeelding op schijf op in PNG-formaat
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Miniatuur van vormweergave op basis van grenzen maken**
Deze methode om miniaturen van vormen te maken stelt ontwikkelaars in staat om een miniatuur te genereren binnen de grenzen van de vormweergave. Hierbij worden alle vormeffecten in overweging genomen. De gegenereerde vormminiatuur wordt beperkt door de dia‑grenzen. Om een miniatuur van een dia‑vorm binnen de grenzen van de weergave te genereren, doe je het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑klasse.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of de index.
1. Haal de miniatuurafbeelding van de referentiemaandia op met de vormgrenzen als weergave.
1. Sla de miniatuurafbeelding op in je gewenste beeldformaat.

Deze voorbeeldcode is gebaseerd op de bovenstaande stappen:

```java
// Instantieer een Presentation-klasse die het presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Maak een afbeelding op volledige schaal
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Sla de afbeelding op schijf op in PNG-formaat
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Welke beeldformaten kunnen worden gebruikt bij het opslaan van vormminiaturen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imageformat/), en andere. Vormen kunnen ook worden [geëxporteerd als vector SVG](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen Shape‑ en Appearance‑grenzen bij het renderen van een miniatuur?**

`Shape` gebruikt de geometrie van de vorm; `Appearance` houdt rekening met [visuele effecten](/slides/nl/androidjava/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm gemarkeerd is als verborgen? Wordt deze nog steeds als miniatuur gerenderd?**

Een verborgen vorm blijft deel van het model en kan gerenderd worden; de verborgen‑vlag beïnvloedt alleen de weergave in de diavoorstelling maar verhindert niet het genereren van de afbeelding van de vorm.

**Worden groepsvormen, grafieken, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als Shape (inclusief GroupShape, Chart en SmartArt) kan worden opgeslagen als miniatuur of als SVG.

**Hebben systeembrede geïnstalleerde lettertypen invloed op de kwaliteit van miniaturen van tekstvormen?**

Ja. Je moet de benodigde lettertypen [aanleveren](/slides/nl/androidjava/custom-font/) (of [lettertype‑vervangingen configureren](/slides/nl/androidjava/font-substitution/)) om ongewenste fallback‑lettertypen en tekst‑reflow te voorkomen.