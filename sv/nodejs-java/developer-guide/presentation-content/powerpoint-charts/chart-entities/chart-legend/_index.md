---
title: Anpassa diagramförklaringar i presentationer med JavaScript
linktitle: Diagramförklaring
type: docs
url: /sv/nodejs-java/chart-legend/
keywords:
- diagramförklaring
- förklaringsposition
- teckenstorlek
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Anpassa diagramförklaringar med JavaScript och Aspose.Slides för Node.js för att optimera PowerPoint-presentationer med skräddarsydd förklaringsformatering."
---
## **Översikt**

Aspose.Slides erbjuder alternativ för att anpassa diagramförklaringar i PowerPoint-presentationer. Den här artikeln visar hur man placerar och storlekar en förklaring, anger teckenstorleken för hela förklaringen och tillämpar formatering på ett enskilt förklaringsobjekt.

Den täcker också flera relaterade beteenden i FAQ, inklusive att använda icke‑överlappningsläge så att diagramområdet gör plats för förklaringen, tillåter långa förklaringsetiketter att radbrytas eller använda radbrytningar, och låter förklaringsformatering ärva från presentationens tema när explicita text‑ och fyllnadsinställningar inte har använts.

## **Placering av förklaring**

För att ange egenskaperna för förklaringen. Följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)-klassen.
- Hämta referensen till bilden.
- Lägg till ett diagram på bilden.
- Ställ in egenskaperna för förklaringen.
- Skriv presentationen som en PPTX-fil.

I exemplet nedan har vi ställt in positionen och storleken för diagramförklaringen.

```javascript
// Skapa en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Hämta referensen till bilden
    var slide = pres.getSlides().get_Item(0);
    // Lägg till ett grupperat stapeldiagram på bilden
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Ställ in legendegenskaper
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Skriv presentationen till disk
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ange teckenstorlek för förklaring**

Aspose.Slides för Node.js via Java låter utvecklare ange teckenstorlek för förklaringen. Följ stegen nedan:

- Instansiera [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)-klassen.
- Skapa standarddiagrammet.
- Ange teckenstorleken.
- Ange minimalt axelvärde.
- Ange maximalt axelvärde.
- Skriv presentationen till disk.

```javascript
// Skapa en instans av Presentation-klassen
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

## **Ange teckenstorlek för enskild förklaring**

Aspose.Slides för Node.js via Java låter utvecklare ange teckenstorlek för enskilda förklaringsposter. Följ stegen nedan:

- Instansiera [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)-klassen.
- Skapa standarddiagrammet.
- Åtkom förklaringsposten.
- Ange teckenstorleken.
- Ange minimalt axelvärde.
- Ange maximalt axelvärde.
- Skriv presentationen till disk.

```javascript
// Skapa en instans av Presentation-klassen
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

**Kan jag aktivera förklaringen så att diagrammet automatiskt avsätter utrymme för den istället för att överlappa den?**

Ja. Använd icke‑överlappningsläget ([setOverlay(false)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/legend/setoverlay/)); i så fall kommer diagramområdet att krympa för att rymma förklaringen.

**Kan jag skapa flerradiga förklaringsetiketter?**

Ja. Långa etiketter radbryts automatiskt när utrymmet är otillräckligt; tvingade radbrytningar stöds via newline‑tecken i seriernas namn.

**Hur får jag förklaringen att följa presentationens temanfärgschema?**

Ange inte explicita färger/fyllningar/teckensnitt för förklaringen eller dess text. De kommer då att ärva från temat och uppdateras korrekt när designen ändras.