---
title: Miniaturen van presentatievormen op Android maken
linktitle: Vormminiaturen
type: docs
weight: 70
url: /nl/androidjava/create-shape-thumbnails/
keywords:
- vormminiatuur
- vormafbeelding
- vorm renderen
- vormrendering
- visuele grenzen
- vormgrenzen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint-dia's met Aspose.Slides for Android via Java - maak en exporteer eenvoudig presentatie-miniaturen."
---
## **Inleiding**

Aspose.Slides for Android via Java kan worden gebruikt om presentatiebestanden te maken waarbij elke pagina overeenkomt met een dia. Dia’s kunnen worden bekeken door de presentatiebestanden te openen met Microsoft PowerPoint. Soms moeten ontwikkelaars echter de afbeeldingen van de vormen apart bekijken in een afbeeldingsviewer. In zulke gevallen helpt Aspose.Slides for Android via Java hen miniatuuropnames van de dia‑vormen te genereren.

In dit onderwerp laten we zien hoe miniaturen van dia’s in verschillende situaties te genereren:

- Een vormminiatuur genereren binnen een dia.
- Een vormminiatuur genereren voor een dia‑vorm met door de gebruiker gedefinieerde afmetingen.
- Een vormminiatuur genereren binnen de grenzen van het uiterlijk van een vorm.

## **Miniatuur van een vorm uit een dia genereren**
Om een miniatuur van een vorm uit een willekeurige dia te genereren met Aspose.Slides for Android via Java, doe het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse.
2. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
3. [Haal de miniatuurafbeelding van de vorm op](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#getImage--) van de referentie‑dia op de standaard schaal.
4. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingformaat.

Deze voorbeeldcode laat zien hoe u een miniatuur van een vorm uit een dia genereert:

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

## **Miniatuur met gebruikergedefinieerde schaalfactor genereren**
Om de vormminiatuur van een dia met een door de gebruiker gedefinieerde schaalfactor te genereren met Aspose.Slides for Android via Java, doe het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse.
2. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
3. [Haal de miniatuurafbeelding van de vorm op](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) van de referentie‑dia met door de gebruiker opgegeven afmetingen.
4. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingformaat.

Deze voorbeeldcode laat zien hoe u een vormminiatuur genereert op basis van een gedefinieerde schaalfactor:

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

## **Miniatuur op basis van vormgrenzen en uiterlijk maken**
Deze methode om miniaturen van vormen te maken stelt ontwikkelaars in staat een miniatuur te genereren binnen de grenzen van het uiterlijk van de vorm. Alle vorm‑effecten worden in aanmerking genomen. De gegenereerde vormminiatuur wordt beperkt door de dia‑grenzen. Om een miniatuur van een dia‑vorm binnen de grenzen van zijn uiterlijk te genereren, doe het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse.
2. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
3. Haal de miniatuurafbeelding van de referentie‑dia op met vormgrenzen als uiterlijk.
4. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingformaat.

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

## **De werkelijke visuele grenzen van een vorm ophalen**

De frame‑eigenschappen van [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/)—zijn `getX()`, `getY()`, `getWidth()` en `getHeight()` methoden—beschrijven het rechthoekige kader dat in het presentatiemodel is opgeslagen. De inhoud die daadwerkelijk wordt gerenderd kan buiten dat frame uitsteken of een andere rechthoek beslaan die met de assen is uitgelijnd. Rotatie, contouren, pijlpuntjes, tekstlay-out en -overloop, gegenereerde SmartArt‑geometrie en andere render‑effecten kunnen het bezette gebied allemaal wijzigen.

Gebruik [Shape.getVisualBounds](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getVisualBounds--) om dat bezette gebied te berekenen zonder een afbeelding te maken. De methode retourneert een [RectF](https://developer.android.com/reference/android/graphics/RectF) in diacoördinaten. Het geretourneerde rechthoekige gebied wordt niet bijgesneden tot de dia, zodat de coördinaten negatief kunnen zijn wanneer de inhoud buiten de oorsprong van de dia uitbreidt.

[Shape.getVisualBounds](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getVisualBounds--) is momenteel niet gedeclareerd in de [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) interface. Houd daarom de vorm die u uit de vormcollectie van de dia haalt als een interface‑waarde en cast deze alleen wanneer u de methode aanroept.

Het volgende voorbeeld haalt de frame‑ en visuele grenzen op en vergelijkt ze:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Dezelfde [RectF](https://developer.android.com/reference/android/graphics/RectF) kan worden gebruikt om aangrenzende vormen uit te lijnen aan de linker‑, rechter‑, boven‑ of onderkant; voldoende ruimte te reserveren in een gegenereerde lay‑out; of om inhoud buiten een toegestane regio te detecteren. Visuele grenzen zijn vooral nuttig voor SmartArt, tekstvakken, pijlen, afbeeldingen, geroteerde vormen en groep‑vormen, waar het opgeslagen frame mogelijk niet het volledige gerenderde resultaat weergeeft.

Gebruik [Shape.getVisualBounds](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getVisualBounds--) wanneer u coördinaten nodig hebt voor lay‑out of validatie en geen bitmap nodig hebt. Gebruik [IShape.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getImage--) wanneer u de vorm moet renderen. Met [ShapeThumbnailBounds](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapethumbnailbounds/) bepaalt `ShapeThumbnailBounds.Shape` de afbeelding op basis van de vormgrenzen, inclusief contourinstellingen, terwijl `ShapeThumbnailBounds.Appearance` deze bepaalt op basis van het uiterlijk van de vorm en het resultaat beperkt tot de dia‑grenzen. In contrast retourneert [Shape.getVisualBounds](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getVisualBounds--) alleen het berekende rechthoekige gebied en bijsnijdt het niet tot de dia.

## **FAQ**

**Welke afbeeldingsformaten kunnen worden gebruikt bij het opslaan van vormminiaturen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imageformat/), en anderen. Vormen kunnen ook worden [geëxporteerd als vector‑SVG](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) door de inhoud van de vorm als SVG op te slaan.

**Wat is het verschil tussen Shape‑ en Appearance‑grenzen bij het renderen van een miniatuur?**

`Shape` gebruikt de geometrie van de vorm; `Appearance` houdt rekening met [visuele effecten](/slides/nl/androidjava/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm gemarkeerd is als verborgen? Wordt er nog steeds een miniatuur van gemaakt?**

Een verborgen vorm blijft deel uitmaken van het model en kan worden gerenderd; de verborgen‑vlag beïnvloedt alleen de weergave tijdens een diavoorstelling, maar verhindert niet het genereren van de afbeelding van de vorm.

**Worden groepsvormen, grafieken, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als [Shape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/chart/) en [SmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/smartart/)) kan worden opgeslagen als miniatuur of als SVG.

**Hebben systeem‑geïnstalleerde lettertypen invloed op de kwaliteit van miniaturen voor tekstvormen?**

Ja. U moet [de vereiste lettertypen leveren](/slides/nl/androidjava/custom-font/) (of [lettertype‑substitutie configureren](/slides/nl/androidjava/font-substitution/)) om ongewenste fallback‑lettertypen en tekst‑reflow te voorkomen.