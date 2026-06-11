---
title: Anpassa diagramförklaringar i presentationer med PHP
linktitle: Diagramförklaring
type: docs
url: /sv/php-java/chart-legend/
keywords:
- diagramförklaring
- förklaringsposition
- teckenstorlek
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Anpassa diagramförklaringar med Aspose.Slides för PHP via Java för att optimera PowerPoint-presentationer med skräddarsydd förklaringsformatering."
---
## **Översikt**

Aspose.Slides erbjuder alternativ för att anpassa diagramförklaringar i PowerPoint‑presentationer. Den här artikeln visar hur du placerar och storlekar en förklaring, anger teckenstorleken för hela förklaringen och tillämpar formatering på en enskild förklaringspost.

Den täcker också flera relaterade beteenden i FAQ, inklusive att använda icke‑överlappningsläge så att diagramområdet ger plats åt förklaringen, tillåter långa förklaringsetiketter att radbrytas eller använda radbrytningar, samt låter förklaringsformatering ärva från presentationens tema när explicita text‑ och fyllningsinställningar inte har använts.

## **Placering av förklaring**
För att ange egenskaperna för förklaringen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
- Hämta referensen till bilden.
- Lägg till ett diagram på bilden.
- Ställ in egenskaperna för förklaringen.
- Skriv presentationen som en PPTX‑fil.

I exemplet nedan har vi ställt in position och storlek för diagramförklaringen.

```php
  # Skapa en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    # Hämta referensen till bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Lägg till ett grupperat kolumndiagram på bilden
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Ställ in förklaringsegenskaper
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Spara presentationen till disk
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange teckenstorlek för en förklaring**
Aspose.Slides för PHP via Java låter utvecklare ange teckenstorlek för förklaringen. Följ stegen nedan:

- Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
- Skapa standarddiagrammet.
- Ange teckenstorlek.
- Ange minimalt axelvärde.
- Ange maximalt axelvärde.
- Spara presentationen på disk.

```php
  # Skapa en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange teckenstorlek för en enskild förklaring**
Aspose.Slides för PHP via Java låter utvecklare ange teckenstorlek för individuella förklaringsposter. Följ stegen nedan:

- Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
- Skapa standarddiagrammet.
- Kom åt förklaringsposten.
- Ange teckenstorlek.
- Ange minimalt axelvärde.
- Ange maximalt axelvärde.
- Spara presentationen på disk.

```php
  # Skapa en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan jag aktivera förklaringen så att diagrammet automatiskt avsätter utrymme för den istället för att överlappa den?**

Ja. Använd icke‑överlappningsläget ([setOverlay(false)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/legend/setoverlay/)); i så fall kommer diagramområdet att krympa för att ge plats åt förklaringen.

**Kan jag skapa flerradiga förklaringsetiketter?**

Ja. Långa etiketter radbryts automatiskt när utrymmet är otillräckligt; tvingade radbrytningar stöds via nyradstecken i seriens namn.

**Hur får jag förklaringen att följa presentationens temafärgschema?**

Ange inte explicita färger/fyllningar/typsnitt för förklaringen eller dess text. De kommer då att ärva från temat och uppdateras korrekt när designen ändras.