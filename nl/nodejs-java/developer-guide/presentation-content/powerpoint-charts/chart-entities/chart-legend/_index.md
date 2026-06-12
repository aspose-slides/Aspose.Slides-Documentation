---
title: Grafieklegendes aanpassen in presentaties met JavaScript
linktitle: Grafieklegende
type: docs
url: /nl/nodejs-java/chart-legend/
keywords:
- grafieklegende
- legende positie
- lettergrootte
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas grafieklegendes aan met JavaScript en Aspose.Slides voor Node.js om PowerPoint-presentaties te optimaliseren met op maat gemaakte legende-opmaak."
---
## **Overzicht**

Aspose.Slides biedt opties om diagramlegendes in PowerPoint‑presentaties aan te passen. Dit artikel laat zien hoe je een legende kunt positioneren en van grootte kunt wijzigen, de lettergrootte voor de volledige legende kunt instellen, en opmaak kunt toepassen op een individuele legende‑item.

Het behandelt ook verschillende verwante gedragspunten in de FAQ, waaronder het gebruik van de niet‑overlay‑modus zodat het plotgebied ruimte vrijmaakt voor de legende, het toestaan dat lange legende‑labels automatisch worden afgebroken of regelafbrekingen gebruiken, en het laten overerven van legende‑opmaak vanuit het presentatiethema wanneer er geen expliciete tekst‑ en opvullingsinstellingen zijn toegepast.

## **Legende positionering**

Om de legende‑eigenschappen in te stellen, volg de onderstaande stappen:

- Maak een instantie van de [Presentation] klasse.
- Haalt een referentie naar de dia op.
- Voeg een diagram toe aan de dia.
- Stel de eigenschappen van de legende in.
- Schrijf de presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we de positie en grootte van de diagramlegende ingesteld.

```javascript
// Maak een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    // Haal een referentie naar de dia op
    var slide = pres.getSlides().get_Item(0);
    // Voeg een gegroepeerd kolomdiagram toe aan de dia
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Stel legende-eigenschappen in
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Schrijf de presentatie naar schijf
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lettergrootte van legende instellen**

Aspose.Slides voor Node.js via Java stelt ontwikkelaars in staat de lettergrootte van de legende in te stellen. Volg de onderstaande stappen:

- Instantieer de [Presentation] klasse.
- Maak het standaard diagram aan.
- Stel de lettergrootte in.
- Stel de minimale aswaarde in.
- Stel de maximale aswaarde in.
- Schrijf de presentatie naar schijf.

```javascript
// Maak een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lettergrootte van individuele legende instellen**

Aspose.Slides voor Node.js via Java stelt ontwikkelaars in staat de lettergrootte van individuele legende‑items in te stellen. Volg de onderstaande stappen:

- Instantieer de [Presentation] klasse.
- Maak het standaard diagram aan.
- Toegang tot legende‑item.
- Stel de lettergrootte in.
- Stel de minimale aswaarde in.
- Stel de maximale aswaarde in.
- Schrijf de presentatie naar schijf.

```javascript
// Maak een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik de legende inschakelen zodat het diagram automatisch ruimte reserveert in plaats van het te overlappen?**

Ja. Gebruik de niet‑overlay‑modus ([setOverlay(false)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/legend/setoverlay/)); in dit geval zal het plotgebied krimpen om de legende te huisvesten.

**Kan ik meerregelige legende‑labels maken?**

Ja. Lange labels worden automatisch afgebroken wanneer er onvoldoende ruimte is; geforceerde regeleinden worden ondersteund via nieuwe‑regel‑tekens in de serienaam.

**Hoe laat ik de legende het kleurenpalet van het presentatiethema volgen?**

Stel geen expliciete kleuren/opvullingen/lettertypes in voor de legende of de tekst ervan. Ze zullen dan overerven van het thema en correct worden bijgewerkt wanneer het ontwerp verandert.

---
title: Grafieklegendes aanpassen in presentaties met JavaScript
linktitle: Grafieklegende
type: docs
url: /nl/nodejs-java/chart-legend/
keywords:
- grafieklegende
- legende positie
- lettergrootte
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas grafieklegendes aan met JavaScript en Aspose.Slides voor Node.js om PowerPoint-presentaties te optimaliseren met op maat gemaakte legende-opmaak."
---