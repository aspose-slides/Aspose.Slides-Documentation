---
title: Pas diagramlegendes aan in presentaties op Android
linktitle: Diagramlegende
type: docs
url: /nl/androidjava/chart-legend/
keywords:
- diagramlegende
- positie van legenda
- lettergrootte
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Pas diagramlegendes aan met Aspose.Slides voor Android via Java om PowerPoint-presentaties te optimaliseren met op maat gemaakte legende-opmaak."
---
## **Overview**

Aspose.Slides biedt opties om diagramlegendes in PowerPoint‑presentaties aan te passen. Dit artikel laat zien hoe u een legende kunt positioneren en van grootte kunt wijzigen, de lettergrootte voor de hele legende kunt instellen en opmaak kunt toepassen op een enkel legende‑item.

Het behandelt tevens verschillende gerelateerde gedragspunten in de FAQ, waaronder het gebruik van de non‑overlay‑modus zodat het plotgebied ruimte maakt voor de legende, het toestaan dat lange legende‑labels worden afgebroken of regelbreuken gebruiken, en het laten overerven van legende‑opmaak van het presentatiethema wanneer er geen expliciete tekst‑ en opvulkleurinstellingen zijn.

## **Legend Positioning**
We moeten de legende‑eigenschappen instellen. Volg de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
- Verkrijg een referentie naar de dia.
- Voeg een diagram toe aan de dia.
- Stel de eigenschappen van de legende in.
- Schrijf de presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we de positie en grootte van de diagramlegende ingesteld.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Haal een referentie naar de dia op
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Voeg een gegroepeerde kolomgrafiek toe aan de dia
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Stel de legendaparameters in
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Schrijf de presentatie naar schijf
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set the Font Size of a Legend**
Met Aspose.Slides voor Android via Java kunnen ontwikkelaars de lettergrootte van de legende instellen. Volg de onderstaande stappen:

- Instantieer de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
- Maak het standaarddiagram aan.
- Stel de lettergrootte in.
- Stel de minimale aswaarde in.
- Stel de maximale aswaarde in.
- Schrijf de presentatie naar schijf.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set the Font Size of an Individual Legend**
Met Aspose.Slides voor Android via Java kunnen ontwikkelaars de lettergrootte van individuele legende‑items instellen. Volg de onderstaande stappen:

- Instantieer de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
- Maak het standaarddiagram aan.
- Toegang tot het legende‑item.
- Stel de lettergrootte in.
- Stel de minimale aswaarde in.
- Stel de maximale aswaarde in.
- Schrijf de presentatie naar schijf.

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

Ja. Gebruik de non‑overlay‑modus ([setOverlay(false)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); in dat geval zal het plotgebied krimpen om de legende te huisvesten.

**Can I make multi-line legend labels?**

Ja. Lange labels worden automatisch afgebroken wanneer er onvoldoende ruimte is; geforceerde regeleinden worden ondersteund via newline‑tekens in de serienaam.

**How do I make the legend follow the presentation theme’s color scheme?**

Stel geen expliciete kleuren/opvullingen/lettertypen in voor de legende of de tekst ervan. Ze zullen dan van het thema overerven en correct bijgewerkt worden wanneer het ontwerp verandert.