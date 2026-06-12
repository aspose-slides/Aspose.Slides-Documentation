---
title: Trendlijnen toevoegen aan presentatiediagrammen in Python
linktitle: Trendlijn
type: docs
url: /nl/python-net/trend-line/
keywords:
- diagram
- trendlijn
- exponentiële trendlijn
- lineaire trendlijn
- logaritmische trendlijn
- voortschrijdend gemiddelde trendlijn
- polynomiale trendlijn
- machttrendlijn
- aangepaste trendlijn
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Voeg snel trendlijnen toe en pas ze aan in PowerPoint- en OpenDocument-diagrammen met Aspose.Slides for Python via .NET — een praktische gids en codevoorbeelden om de voorspellingsnauwkeurigheid te verbeteren en uw publiek te boeien."
---
## **Overzicht**

Dit artikel legt uit hoe u trendlijnen kunt toevoegen aan presentatiediagrammen met behulp van Aspose.Slides. Het toont hoe u een diagram maakt, trendlijnen toevoegt aan diagramreeksen, en werkt met verschillende trendlijntypen, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynoom en macht.

Het beschrijft ook hoe u een aangepaste lijn aan een diagram kunt toevoegen door een lijntvorm in te voegen, en bevat een korte FAQ over de projectiewaarden van trendlijnen naar voren en naar achteren, en of trendlijnen behouden blijven bij het exporteren naar PDF of SVG en bij het renderen van diagrammen als afbeeldingen.

## **Trendlijn toevoegen**
Aspose.Slides for Python via .NET biedt een eenvoudige API voor het beheren van verschillende diagram‑trendlijnen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een diagram toe met standaardgegevens en een gewenst type (in dit voorbeeld wordt ChartType.CLUSTERED_COLUMN gebruikt).
1. Voeg een exponentiële trendlijn toe voor diagramreeks 1.
1. Voeg een lineaire trendlijn toe voor diagramreeks 1.
1. Voeg een logaritmische trendlijn toe voor diagramreeks 2.
1. Voeg een voortschrijdend gemiddelde trendlijn toe voor diagramreeks 2.
1. Voeg een polynomiale trendlijn toe voor diagramreeks 3.
1. Voeg een machttrendlijn toe voor diagramreeks 3.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

De onderstaande code wordt gebruikt om een diagram met trendlijnen te maken.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Een lege presentatie maken
with slides.Presentation() as pres:

    # Een gegroepeerde kolomgrafiek maken
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Een exponentiële trendlijn toevoegen voor diagramreeks 1
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Een lineaire trendlijn toevoegen voor diagramreeks 1
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Een logaritmische trendlijn toevoegen voor diagramreeks 2
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Een voortschrijdend gemiddelde trendlijn toevoegen voor diagramreeks 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Een polynomiale trendlijn toevoegen voor diagramreeks 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Een machttrendlijn toevoegen voor diagramreeks 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Presentatie opslaan
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Aangepaste lijn toevoegen**
Aspose.Slides for Python via .NET biedt een eenvoudige API om aangepaste lijnen aan een diagram toe te voegen. Om een eenvoudige rechte lijn aan een geselecteerde dia van de presentatie toe te voegen, volgt u de onderstaande stappen:

- Maak een instantie van de Presentation‑klasse
- Verkrijg de referentie van een dia door de Index te gebruiken
- Maak een nieuw diagram met de AddChart‑methode van het Shapes‑object
- Voeg een AutoShape van het type Lijn toe met de AddAutoShape‑methode van het Shapes‑object
- Stel de kleur van de vormlijnen in.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand

De onderstaande code wordt gebruikt om een diagram met aangepaste lijnen te maken.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wat betekenen ‘forward’ en ‘backward’ voor een trendlijn?**

Het zijn de lengtes van de trendlijn die naar voren/naar achteren worden geprojecteerd: voor scatter (XY)-diagrammen — in as‑eenheden; voor niet‑scatter diagrammen — in aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia als afbeelding?**

Ja. Aspose.Slides converteert presentaties naar [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/nl/python-net/render-a-slide-as-an-svg-image/) en rendert diagrammen naar afbeeldingen; trendlijnen, als onderdeel van het diagram, worden behouden tijdens deze operaties. Er is ook een methode beschikbaar om [een afbeelding van het diagram exporteren](/slides/nl/python-net/create-shape-thumbnails/) zelf.