---
title: Skapa linjeformer i presentationer med Python
linktitle: Linje
type: docs
weight: 50
url: /sv/python-net/line/
keywords:
- linje
- skapa linje
- lägga till linje
- enkel linje
- konfigurera linje
- anpassa linje
- streckstil
- pilspets
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig att manipulera linjeformatering i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET. Upptäck egenskaper, metoder och exempel."
---
## **Översikt**

Aspose.Slides för Python via .NET stöder att lägga till olika typer av former på bilderna. I det här avsnittet kommer vi att börja arbeta med former genom att lägga till linjer på bilderna. Med Aspose.Slides kan utvecklare inte bara skapa enkla linjer, utan även några avancerade linjer kan ritas på bilderna.

## **Skapa enkla linjer**

Använd Aspose.Slides för att lägga till en enkel linje på en bild som en enkel avgränsare eller anslutning. För att lägga till en enkel linje på en vald bild i en presentation, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till bilden via index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) av typen `LINE` med hjälp av metoden `add_auto_shape` på objektet [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/).
1. Spara presentationen som en PPTX-fil.

I exemplet nedan läggs en linje till den första bilden i presentationen.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoshape av typen LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Spara presentationen som en PPTX-fil.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Skapa pilarformade linjer**

Aspose.Slides låter dig konfigurera linjeegenskaper för att göra dem mer visuellt tilltalande. Nedan konfigurerar vi några egenskaper för en linje så att den ser ut som en pil. Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild via index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) av typen `LINE` med hjälp av metoden `add_auto_shape` på objektet [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/).
1. Ställ in [line style](https://reference.aspose.com/slides/sv/python-net/aspose.slides/linestyle/).
1. Ställ in linjebredden.
1. Ange linjens [dash style](https://reference.aspose.com/slides/sv/python-net/aspose.slides/linedashstyle/).
1. Ange [arrowhead style](https://reference.aspose.com/slides/sv/python-net/aspose.slides/linearrowheadstyle/) och längd för linjens startpunkt.
1. Ange [arrowhead style](https://reference.aspose.com/slides/sv/python-net/aspose.slides/linearrowheadstyle/) och längd för linjens slutpunkt.
1. Spara presentationen som en PPTX-fil.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instansiera Presentation-klassen som representerar PPTX-filen.
with slides.Presentation() as presentation:
    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoshape av typen LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Tillämpa formatering på linjen.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Spara presentationen som en PPTX-fil.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan jag konvertera en vanlig linje till en connector så att den snäpper till former?**

Nej. En vanlig linje (en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) av typen [LINE](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapetype/)) blir inte automatiskt en connector. För att få den att snäppa till former, använd den dedikerade [Connector](https://reference.aspose.com/slides/sv/python-net/aspose.slides/connector/)‑typen och de [motsvarande API:er](/slides/sv/python-net/connector/) för anslutningar.

**Vad ska jag göra om en linjes egenskaper ärvs från temat och det är svårt att bestämma de slutgiltiga värdena?**

[Läs de effektiva egenskaperna](/slides/sv/python-net/shape-effective-properties/) via klasserna [ILineFormatEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ilinefillformateffectivedata/) . Dessa tar redan hänsyn till arv och temastilar.

**Kan jag låsa en linje mot redigering (flytt, storleksändring)?**

Ja. Former tillhandahåller [lock objects](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/auto_shape_lock/) som låter dig [förbjuda redigeringsoperationer](/slides/sv/python-net/applying-protection-to-presentation/).