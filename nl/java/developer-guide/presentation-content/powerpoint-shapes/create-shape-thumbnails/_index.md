---
title: Maak miniaturen van presentatievormen in Java
linktitle: Vormminiaturen
type: docs
weight: 70
url: /nl/java/create-shape-thumbnails/
keywords:
- vormminiatuur
- vormafbeelding
- vorm renderen
- vormrendering
- visuele grenzen
- vormgrenzen
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint-dia's met Aspose.Slides for Java – maak en exporteer eenvoudig presentatieminiaturen."
---
## **Introductie**

Aspose.Slides for Java kan worden gebruikt om presentatiebestanden te maken waarbij elke pagina overeenkomt met een dia. De dia's kunnen worden bekeken door de presentatiebestanden te openen met Microsoft PowerPoint. Soms moeten ontwikkelaars echter de afbeeldingen van de vormen afzonderlijk in een afbeeldingsviewer bekijken. In dergelijke gevallen helpt Aspose.Slides for Java hen miniatuurafbeeldingen van de dia‑vormen te genereren.

Dit artikel legt uit hoe je dia‑miniaturen op verschillende manieren kunt genereren:

- Een vorm‑miniatuur genereren binnen een dia.
- Een vorm‑miniatuur genereren voor een dia‑vorm met door de gebruiker gedefinieerde afmetingen.
- Een vorm‑miniatuur genereren binnen de grenzen van de weergave van een vorm.

## **Genereer een vorm‑miniatuur van een dia**
Om een vorm‑miniatuur van een willekeurige dia te genereren met Aspose.Slides for Java, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
1. Verkrijg de referentie van een willekeurige dia via het ID of de index.
1. Haal de [shape thumbnail image](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getImage--) op van de gerefereerde dia met de standaard schaal.
1. Sla de miniatuurafbeelding op in het door jou gewenste afbeeldingsformaat.

```java
// Instantieer een Presentation-klasse die het presentatiebestand voorstelt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Maak een afbeelding in volledige schaal
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Sla de afbeelding op schijf in PNG-formaat
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Genereer een miniatuur met een door de gebruiker gedefinieerde schaalfactor**
Om de vorm‑miniatuur van een dia te genereren met Aspose.Slides for Java, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
1. Verkrijg de referentie van een willekeurige dia via het ID of de index.
1. Haal de [shape thumbnail image](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getImage-int-float-float-) op van de gerefereerde dia met door de gebruiker gedefinieerde afmetingen.
1. Sla de miniatuurafbeelding op in het door jou gewenste afbeeldingsformaat.

```java
// Instantieer een Presentation-klasse die het presentatiebestand voorstelt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Maak een afbeelding in volledige schaal
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Sla de afbeelding op schijf in PNG-formaat
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Maak een miniatuur op basis van de grenzen van de vormweergave**
Deze methode om miniaturen van vormen te maken stelt ontwikkelaars in staat om een miniatuur te genereren binnen de grenzen van de weergave van de vorm. Hierbij worden alle vormeffecten meegenomen. De gegenereerde vorm‑miniatuur is beperkt tot de dia‑grenzen. Om een miniatuur van een dia‑vorm binnen de weergave‑grenzen te genereren, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
1. Verkrijg de referentie van een willekeurige dia via het ID of de index.
1. Haal de miniatuurafbeelding van de gerefereerde dia op met vorm‑grenzen als weergave.
1. Sla de miniatuurafbeelding op in het door jou gewenste afbeeldingsformaat.

```java
// Instantieer een Presentation-klasse die het presentatiebestand voorstelt
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Maak een afbeelding in volledige schaal
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Sla de afbeelding op schijf in PNG-formaat
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Haalt de werkelijke visuele grenzen van een vorm op**
De frame‑eigenschappen van [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/)—de `getX()`, `getY()`, `getWidth()` en `getHeight()` methoden—beschrijven het rechthoekige kader dat in het presentatiemodel wordt opgeslagen. De inhoud die werkelijk wordt gerenderd kan buiten dat frame uitsteken of een andere, as‑gealigneerde rechthoek innemen. Rotatie, contouren, pijpwijzers, tekstlayout en overflow, gegenereerde SmartArt‑geometrie en andere rendering‑effecten kunnen het bezette gebied allemaal wijzigen.

Gebruik [Shape.getVisualBounds](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getVisualBounds--) om dat bezette gebied te berekenen zonder een afbeelding te maken. De methode retourneert een [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) in dia‑coördinaten. Het geretourneerde rechthoek wordt niet afgeknipt tot de dia, dus de coördinaten kunnen negatief zijn wanneer de inhoud buiten de oorsprong van de dia reikt.

[Shape.getVisualBounds](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getVisualBounds--) wordt momenteel niet gedeclareerd door de [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) interface. Daarom moet je de vorm die je uit de vormcollectie van de dia haalt, als een interface‑waarde behouden en pas casten wanneer je de methode aanroept.

Het volgende voorbeeld haalt en vergelijkt het frame en de visuele grenzen:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Dezelfde [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) kan worden gebruikt om naburige vormen uit te lijnen op de linker-, rechter-, boven- of onderkant; voldoende ruimte te reserveren in een gegenereerde lay-out; of inhoud buiten een toegestane regio te detecteren. Visuele grenzen zijn vooral nuttig voor SmartArt, tekstvakken, pijlen, afbeeldingen, gedraaide vormen en groepvormen, waarbij het opgeslagen frame niet het volledige gerenderde resultaat weergeeft.

Gebruik [Shape.getVisualBounds](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getVisualBounds--) wanneer je coördinaten nodig hebt voor lay-out of validatie en geen bitmap nodig hebt. Gebruik [IShape.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getImage--) wanneer je de vorm moet renderen. Met [ShapeThumbnailBounds](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapethumbnailbounds/) bepaalt `ShapeThumbnailBounds.Shape` de grootte van de afbeelding op basis van de vorm‑grenzen, inclusief contourinstellingen, terwijl `ShapeThumbnailBounds.Appearance` de grootte baseert op de weergave van de vorm en het resultaat beperkt tot de dia‑grenzen. Daarentegen retourneert [Shape.getVisualBounds](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getVisualBounds--) alleen de berekende rechthoek en knipt deze niet af tot de dia.

## **Veelgestelde vragen**

**Welke afbeeldingsformaten kunnen worden gebruikt bij het opslaan van vorm‑miniaturen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imageformat/), en andere. Vormen kunnen ook worden [geëxporteerd als vector‑SVG](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen Shape‑ en Appearance‑grenzen bij het renderen van een miniatuur?**

`Shape` gebruikt de geometrie van de vorm; `Appearance` houdt rekening met [visuele effecten](/slides/nl/java/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm gemarkeerd is als verborgen? Wordt deze nog steeds gerenderd als een miniatuur?**

Een verborgen vorm blijft onderdeel van het model en kan worden gerenderd; de verborgen‑vlag beïnvloedt de weergave in de diavoorstelling, maar voorkomt niet dat de afbeelding van de vorm wordt gegenereerd.

**Worden groepvormen, diagrammen, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als [Shape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/chart/), en [SmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/smartart/)) kan worden opgeslagen als een miniatuur of als SVG.

**Hebben systeembrede geïnstalleerde lettertypen invloed op de kwaliteit van miniaturen voor tekstvormen?**

Ja. Je moet [de benodigde lettertypen leveren](/slides/nl/java/custom-font/) (of [lettertype‑substituties configureren](/slides/nl/java/font-substitution/)) om ongewenste fallback‑lettertypen en tekst‑herindeling te vermijden.