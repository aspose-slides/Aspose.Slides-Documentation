---
title: Anpassa diagramförklaringar i presentationer med Java
linktitle: Diagramförklaring
type: docs
url: /sv/java/chart-legend/
keywords:
- diagramförklaring
- förklaringsposition
- teckenstorlek
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Anpassa diagramförklaringar med Aspose.Slides för Java för att optimera PowerPoint-presentationer med skräddarsydd förklaringsformatering."
---
## **Översikt**

Aspose.Slides erbjuder alternativ för att anpassa diagramförklaringar i PowerPoint-presentationer. Denna artikel visar hur man placerar och storlekar en förklaring, anger teckenstorlek för hela förklaringen och tillämpar formatering på en enskild förklaringspost.

Den behandlar också flera relaterade beteenden i FAQ, inklusive att använda icke‑överlappningsläge så att plotområdet gör plats för förklaringen, tillåter långa förklaringsetiketter att radbrytas eller använda radbrytningar, och låter förklaringsformatering ärva från presentationens tema när explicita text‑ och fyllningsinställningar inte har använts.

## **Placering av förklaring**
För att ställa in förklaringens egenskaper, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) klass.
- Hämta referensen till bilden.
- Lägg till ett diagram på bilden.
- Ställ in förklaringens egenskaper.
- Spara presentationen som en PPTX‑fil.

I exemplet nedan har vi ställt in position och storlek för diagramförklaringen.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Hämta referens till bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lägg till ett stapeldiagram med grupperade kolumner på bilden
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Ställ in förklaringsegenskaper
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Spara presentationen till disk
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ställ in teckenstorlek för en förklaring**
Aspose.Slides för Java låter utvecklare ange teckenstorlek för förklaringen. Följ stegen nedan:

- Instansiera [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) klass.
- Skapa standarddiagrammet.
- Ange teckenstorleken.
- Ange minimivärde för axeln.
- Ange maximivärde för axeln.
- Spara presentationen till disk.

```java
// Skapa en instans av Presentation-klassen
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

## **Ställ in teckenstorlek för en enskild förklaring**
Aspose.Slides för Java låter utvecklare ange teckenstorlek för enskilda förklaringsposter. Följ stegen nedan:

- Instansiera [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) klass.
- Skapa standarddiagrammet.
- Åtkomst till förklaringspost.
- Ange teckenstorleken.
- Ange minimivärde för axeln.
- Ange maximivärde för axeln.
- Spara presentationen till disk.

```java
// Skapa en instans av Presentation-klassen
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

**Kan jag aktivera förklaringen så att diagrammet automatiskt avsätter utrymme för den istället för att överlagra den?**

Ja. Använd icke‑överlappningsläget ([setOverlay(false)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/legend/#setOverlay-boolean-)); i detta fall kommer plotområdet att krympas för att rymma förklaringen.

**Kan jag skapa flerradiga förklaringsetiketter?**

Ja. Långa etiketter radbryts automatiskt när utrymmet är otillräckligt; tvingade radbrytningar stöds via nyradstecken i serienamnet.

**Hur får jag förklaringen att följa presentationens temafärgschema?**

Ange inte explicita färger/fyllningar/teckensnitt för förklaringen eller dess text. De kommer då att ärva från temat och uppdateras korrekt när designen ändras.