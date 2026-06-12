---
title: Diagramlegenda's aanpassen in presentaties met Java
linktitle: Diagramlegenda
type: docs
url: /nl/java/chart-legend/
keywords:
- diagramlegenda
- legenda positie
- lettergrootte
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Pas diagramlegenda's aan met Aspose.Slides voor Java om PowerPoint-presentaties te optimaliseren met op maat gemaakte legendapresentatie."
---
## **Overzicht**

Aspose.Slides biedt opties om diagramlegenda's aan te passen in PowerPoint‑presentaties. Dit artikel laat zien hoe je een legenda kunt positioneren en de grootte kunt aanpassen, de lettergrootte voor de gehele legenda kunt instellen, en opmaak kunt toepassen op een individueel legendapunt.

Het behandelt ook verschillende gerelateerde gedragingen in de FAQ, inclusief het gebruik van de non‑overlay‑modus zodat het plotgebied plaats maakt voor de legenda, het toestaan dat lange legendarlabels worden afgebroken of een regeleinde bevatten, en het laten erven van de legenda‑opmaak van het presentatiethema wanneer geen expliciete tekst‑ en opvullingsinstellingen zijn toegepast.

## **Positionering van de legenda**
Om de legenda‑eigenschappen in te stellen, volg de onderstaande stappen:

- Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) aan.
- Haal een referentie naar de slide op.
- Voeg een diagram toe aan de slide.
- Stel de eigenschappen van de legenda in.
- Schrijf de presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we de positie en grootte van de diagramlegenda ingesteld.

```java
// Maak een instantie van de Presentation‑klasse
Presentation pres = new Presentation();
try {
    // Haal de referentie van de slide op
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Voeg een gegroepeerd kolomdiagram toe aan de slide
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Stel legendeigenschappen in
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

## **Lettergrootte van een legenda instellen**
Aspose.Slides for Java stelt ontwikkelaars in staat de lettergrootte van de legenda in te stellen. Volg de onderstaande stappen:

- Instantieer de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation).
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

## **Lettergrootte van een individuele legenda instellen**
Aspose.Slides for Java stelt ontwikkelaars in staat de lettergrootte van individuele legendaposten in te stellen. Volg de onderstaande stappen:

- Instantieer de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation).
- Maak het standaarddiagram aan.
- Toegang tot de legendapost.
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

**Kan ik de legenda activeren zodat het diagram automatisch ruimte voor de legenda reserveert in plaats van deze te overlappen?**

Ja. Gebruik de non‑overlay‑modus ([setOverlay(false)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/legend/#setOverlay-boolean-)); in dit geval krimpt het plotgebied om de legenda te huisvesten.

**Kan ik meerregelige legendalabels maken?**

Ja. Lange labels worden automatisch afgebroken wanneer er onvoldoende ruimte is; geforceerde regeleinden worden ondersteund via newline‑tekens in de serienaam.

**Hoe zorg ik dat de legenda het kleurenpalet van het presentatiethema volgt?**

Stel geen expliciete kleuren/opvullingen/lettertypen in voor de legenda of de tekst ervan. Ze erven dan van het thema en worden correct bijgewerkt wanneer het ontwerp verandert.