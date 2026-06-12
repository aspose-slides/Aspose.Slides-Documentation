---
title: Miniaturen van presentatiesvormen maken in Java
linktitle: Vormminiaturen
type: docs
weight: 70
url: /nl/java/create-shape-thumbnails/
keywords:
- vormminiatuur
- vormafbeelding
- vorm renderen
- vormrendering
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint-dia's met Aspose.Slides voor Java - maak en exporteer eenvoudig presentatieminiaturen."
---
## **Inleiding**

Aspose.Slides for Java kan worden gebruikt om presentatiedocumenten te maken waarin elke pagina overeenkomt met een dia. De dia's kunnen worden bekeken door de presentatiedocumenten te openen met Microsoft PowerPoint. Soms moeten ontwikkelaars echter de afbeeldingen van de vormen afzonderlijk bekijken in een afbeeldingsviewer. In dergelijke gevallen helpt Aspose.Slides for Java hen bij het genereren van miniatuurafbeeldingen van de dia-vormen.

Dit artikel legt uit hoe u dia-miniaturen op verschillende manieren kunt genereren:

- Een vorm-miniatuur genereren binnen een dia.
- Een vorm-miniatuur genereren voor een dia-vorm met door de gebruiker gedefinieerde afmetingen.
- Een vorm-miniatuur genereren binnen de grenzen van de weergave van een vorm.

## **Genereer een vorm-miniatuur vanuit een dia**
Om een vorm-miniatuur vanuit een willekeurige dia te genereren met Aspose.Slides for Java, doet u het volgende:

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
1. [Haal de vorm-miniatuurafbeelding op](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShape#getImage--) van de verwezen dia op de standaard schaal.
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingsformaat.

Deze voorbeeldcode laat zien hoe u een vorm-miniatuur vanuit een dia kunt genereren:

```java
// Instantieer een Presentation-klasse die het presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Maak een afbeelding op volledig schaal
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

## **Genereer een miniatuur met door de gebruiker gedefinieerde schaalfactor**
Om de vorm-miniatuur van een dia te genereren met Aspose.Slides for Java, doet u het volgende:

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
1. [Haal de vorm-miniatuurafbeelding op](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShape#getImage-int-float-float-) van de verwezen dia met door de gebruiker gedefinieerde afmetingen.
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingsformaat.

Deze voorbeeldcode laat zien hoe u een vorm-miniatuur kunt genereren op basis van een gedefinieerde schaalfactor:

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

## **Maak een miniatuur van de vormweergave op basis van de grenzen**
Deze methode om miniaturen van vormen te maken stelt ontwikkelaars in staat een miniatuur te genereren binnen de grenzen van de weergave van de vorm. Hierbij worden alle vorm-effecten in aanmerking genomen. De gegenereerde vorm-miniatuur wordt beperkt door de grenzen van de dia. Om een miniatuur van een dia-vorm binnen de grenzen van de weergave te genereren, doet u het volgende:

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) klasse.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
1. Haal de miniatuurafbeelding op van de verwezen dia met vorm-grenzen als weergave.
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingsformaat.

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

**Welke beeldformaten kunnen worden gebruikt bij het opslaan van vorm-miniaturen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imageformat/), en andere. Vormen kunnen ook worden [geëxporteerd als vector-SVG](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen Shape- en Appearance-grenzen bij het renderen van een miniatuur?**

`Shape` gebruikt de geometrie van de vorm; `Appearance` houdt rekening met [visual effects](/slides/nl/java/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm gemarkeerd is als verborgen? Wordt deze nog steeds gerenderd als een miniatuur?**

Een verborgen vorm blijft onderdeel van het model en kan gerenderd worden; de verborgen-vlag beïnvloedt de weergave van de diavoorstelling, maar voorkomt niet dat de afbeelding van de vorm wordt gegenereerd.

**Worden groepsvormen, grafieken, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als [Shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chart/) en [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/smartart/)) kan worden opgeslagen als miniatuur of als SVG.

**Hebben systeembrede geïnstalleerde lettertypen invloed op de kwaliteit van miniaturen van tekstvormen?**

Ja. U dient de benodigde lettertypen te [leveren](/slides/nl/java/custom-font/) (of [lettertype-substituties te configureren](/slides/nl/java/font-substitution/)) om ongewenste fallback-opties en tekst-herindeling te voorkomen.