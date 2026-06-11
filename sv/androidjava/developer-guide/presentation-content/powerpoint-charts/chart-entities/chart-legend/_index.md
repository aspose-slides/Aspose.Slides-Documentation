---
title: Använda diagramförklaringar i presentationer på Android
linktitle: Diagramförklaring
type: docs
url: /sv/androidjava/chart-legend/
keywords:
- diagramförklaring
- förklaringsposition
- teckenstorlek
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Anpassa diagramförklaringar med Aspose.Slides för Android via Java för att optimera PowerPoint-presentationer med skräddarsydd förklaringsformatering."
---
## **Översikt**

Aspose.Slides erbjuder alternativ för att anpassa diagramförklaringar i PowerPoint-presentationer. Denna artikel visar hur man placerar och storlekar en förklaring, anger teckenstorleken för hela förklaringen och tillämpar formatering på ett enskilt förklaringsobjekt.

Den behandlar också flera relaterade beteenden i FAQ, inklusive att använda icke-överlappningsläge så att plotområdet ger plats åt förklaringen, tillåter långa förklaringsetiketter att radbrytas eller använda radbrytningar, samt låter förklaringsformatering ärva från presentationens tema när explicita text- och fyllnadsinställningar inte har använts.

## **Placering av förklaring**
För att ange förklaringens egenskaper. Följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) klassen.
- Hämta referens till bilden.
- Lägg till ett diagram på bilden.
- Ställ in förklaringens egenskaper.
- Skriv presentationen som en PPTX-fil.

I exemplet nedan har vi angett position och storlek för diagramförklaringen.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Hämta referens till bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lägg till ett grupperat stapeldiagram på bilden
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Ställ in förklaringsegenskaper
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Skriv presentationen till disk
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange teckenstorlek för en förklaring**
Aspose.Slides för Android via Java låter utvecklare ange teckenstorlek för förklaringen. Följ stegen nedan:

- Instansiera [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) klassen.
- Skapa standarddiagrammet.
- Ange teckenstorleken.
- Ange minimalt axelvärde.
- Ange maximalt axelvärde.
- Skriv presentationen till disk.

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

## **Ange teckenstorlek för en enskild förklaring**
Aspose.Slides för Android via Java låter utvecklare ange teckenstorlek för enskilda förklaringsposter. Följ stegen nedan:

- Instansiera [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) klassen.
- Skapa standarddiagrammet.
- Åtkomst till förklaringspost.
- Ange teckenstorleken.
- Ange minimalt axelvärde.
- Ange maximalt axelvärde.
- Skriv presentationen till disk.

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

**Kan jag aktivera förklaringen så att diagrammet automatiskt avsätter utrymme för den istället för att överlappa den?**

Ja. Använd icke‑överlappningsläget ([setOverlay(false)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); i så fall kommer plotområdet att krympa för att rymma förklaringen.

**Kan jag skapa flerradiga förklaringsetiketter?**

Ja. Långa etiketter radbryts automatiskt när utrymmet är otillräckligt; tvingade radbrytningar stöds via nyradstecken i seriens namn.

**Hur får jag förklaringen att följa presentationens temas färgschema?**

Ange inte explicita färger/fyllningar/typsnitt för förklaringen eller dess text. De kommer då att ärva från temat och uppdateras korrekt när designen ändras.