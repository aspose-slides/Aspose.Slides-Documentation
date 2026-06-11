---
title: Anpassa diagramlegendrar i presentationer med Python
linktitle: Diagramlegendar
type: docs
url: /sv/python-net/chart-legend/
keywords:
- diagramlegendar
- legendposition
- teckenstorlek
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Anpassa diagramlegendrar med Aspose.Slides för Python via .NET för att optimera PowerPoint- och OpenDocument-presentationer med skräddarsydd legendformatering."
---
## **Översikt**

Aspose.Slides för Python ger full kontroll över diagramlegendrar så att du kan göra datamärkningar tydliga och presentationsklara. Du kan visa eller dölja legendraden, välja dess position på bilden och justera layouten för att förhindra överlappning med plotområdet. API:et låter dig styla text och markörer, finjustera utfyllnad och bakgrund samt formatera kanter och fyllningar för att matcha ditt tema. Utvecklare kan också komma åt enskilda legendposter för att byta namn på dem eller filtrera dem, så att endast de mest relevanta serierna visas. Med dessa möjligheter förblir dina diagram läsbara, konsekventa och i linje med presentationens designstandarder.

## **Positionering av legend**

Med Aspose.Slides kan du snabbt styra var diagramlegendren visas och hur den passar in i din bildlayout. Lär dig hur du placerar legendren exakt.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
1. Hämta en referens till bilden.
1. Lägg till ett diagram på bilden.
1. Ställ in legendegenskaperna.
1. Spara presentationen som en PPTX-fil.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:

    # Hämta en referens till bilden.
    slide = presentation.slides[0]

    # Lägg till ett grupperat stapeldiagram på bilden.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Ställ in legendegenskaperna.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Spara presentationen till disk.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in legendens teckenstorlek**

En diagramlegends teckensnitt bör vara lika läsbart som den data den förklarar. Detta avsnitt visar hur du justerar legendens teckenstorlek så att du kan matcha presentationens typografi och förbättra tillgängligheten.

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
1. Skapa ett diagram.
1. Ställ in teckenstorleken.
1. Spara presentationen till disk.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in teckenstorlek för en legendpost**

Aspose.Slides låter dig finjustera utseendet på diagramlegendrar genom att formatera enskilda poster. Exemplet nedan visar hur du riktar in dig på ett specifikt legendobjekt och ställer in dess egenskaper utan att ändra resten av legendren.

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
1. Skapa ett diagram.
1. Åtkomst till en legendpost.
1. Ställ in postens egenskaper.
1. Spara presentationen till disk.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan jag aktivera legendren så att diagrammet automatiskt avsätter utrymme för den istället för att överlagra den?**

Ja. Använd icke‑överlappningsläget ([overlay](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/legend/overlay/) = `false`); i detta fall kommer plotområdet att krympa för att rymma legendren.

**Kan jag skapa flerradiga legendetiketter?**

Ja. Långa etiketter radbryts automatiskt när utrymmet är otillräckligt; tvingade radbrytningar stöds via nyradstecken i seriens namn.

**Hur får jag legendren att följa presentationens temafärgschema?**

Ange inte explicit färger/fyllningar/typsnitt för legendren eller dess text. De ärver då från temat och uppdateras korrekt när designen ändras.