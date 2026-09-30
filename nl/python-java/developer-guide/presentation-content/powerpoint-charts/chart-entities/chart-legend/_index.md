---
title: Grafieklegenda's aanpassen in presentaties met Python
linktitle: Grafieklegenda
type: docs
url: /nl/python-java/chart-legend/
keywords:
- grafieklegenda
- legenda positie
- lettergrootte
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Pas grafieklegenda's aan met Aspose.Slides voor Python via Java om PowerPoint-presentaties te optimaliseren met op maat gemaakte legenda-opmaak."
---
## **Overzicht**

Aspose.Slides for Python via Java biedt opties om de legenda van een diagram in PowerPoint‑presentaties aan te passen. Dit artikel toont hoe je een legenda positioneert en de grootte ervan instelt, het lettertype voor de volledige legenda aanpast, een individuele legenda‑item opmaakt, en geselecteerde items verbergt of herstelt.

De FAQ behandelt gerelateerde gedragspatronen, waaronder het reserveren van ruimte voor de legenda, het weergeven van meerregelige labels en het erven van opmaak vanaf het themavoorbeeld van de presentatie.

## **Legenda‑positionering**

Gebruik de methoden [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) en [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) van de legenda om de positie en afmetingen op te geven als fracties van de afmetingen van het diagram.

Dit voorbeeld maakt een presentatie en voegt een gegroepeerd kolomdiagram met standaardgegevens toe aan de eerste dia. Door de gewenste offset‑ en dimensiewaarden van de legenda te delen door de breedte en hoogte van het diagram, worden ze omgezet naar relatieve waarden: de legenda wordt met 50 points van de linkerbovenhoek van het diagram verschoven en krijgt een grootte van 100 bij 100 points.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Druk de positie en grootte van de legenda uit relatief ten opzichte van het diagram.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Het lettertype van een legenda instellen**

Gebruik de methode [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) van de legenda om de tekstopmaak te benaderen en [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) om de lettergrootte in points in te stellen.

Dit voorbeeld maakt een diagram met standaardgegevens en stelt de legendartekst in op 20 points. Het schakelt ook de automatische grenzen voor de verticale as uit en stelt het bereik in op –5 tot 10.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Het lettertype van een individueel legenda‑item instellen**

Gebruik de verzameling die wordt geretourneerd door de methode [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) van de legenda om de opmaak van een specifiek item te benaderen. Item‑indexen beginnen bij nul, dus index `1` verwijst naar het tweede item.

Dit voorbeeld maakt een gegroepeerd kolomdiagram waarvan de standaardgegevens ten minste twee series bevatten. Het formatteert het tweede legenda‑item met vet, cursief en 20‑points blauwe tekst.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Individuele legenda‑items verbergen**

Om een aanvullende serie uit de legenda te verwijderen terwijl de gegevens zichtbaar blijven, roep je [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) aan met `True` via [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). Dit verbergt alleen het geselecteerde legenda‑item; het verwijdert de serie of de gegevenspunten niet. Het aanroepen van [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) met `False` verbergt daarentegen de volledige legenda.

Het voorbeeld hieronder maakt een gegroepeerd kolomdiagram met meerdere series met standaardgegevens. Het verbergt het legenda‑item van de tweede serie (index `1`) en slaat de presentatie op. Daarna herstelt het het item door [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) met `False` aan te roepen en slaat een tweede kopie op. De kolommen blijven in beide bestanden zichtbaar.

```python
import jpype
import asposeslides

if not jpame.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Herstel hetzelfde item zonder de diagramgegevens te wijzigen.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De vergelijking hieronder toont hetzelfde diagram met alle items zichtbaar en met het tweede item verborgen. De kolommen van de tweede serie blijven ongewijzigd.

![Vergelijking van een diagram met alle legenda‑items zichtbaar en met Serie 2 verborgen in de legenda; alle kolommen blijven zichtbaar.](hide-legend-entry.png)

In kolom‑, staaf‑ en lijndiagrammen identifiëren legenda‑items series. In cirkeldiagrammen identificeren ze individuele datapunten (segmenten); gebruik hiervoor [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) op het geselecteerde segment. De API documenteert deze methode voor de diagramtypen `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` en `BarOfPie`. Veronderstel niet dat dit van toepassing is op doughnut‑diagrammen, die niet in die lijst staan.

## **FAQ**

**Kan ik de presentatie laten reserveren voor de legenda in plaats van die eroverheen te laten liggen?**

Ja. Roep [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) met `False` aan om ruimte voor de legenda te reserveren in plaats van toe te staan dat deze het plotgebied overlapt.

**Kan ik meerregelige legenda‑labels maken?**

Ja. Lange labels kunnen worden afgebroken wanneer de beschikbare breedte onvoldoende is. Je kunt ook een regeleinde‑teken in serienaam gebruiken om handmatig een regelbreuk af te dwingen.

**Hoe zorg ik ervoor dat de legenda het kleurenschema van het presentatiethema volgt?**

Laat de kleuren, vullingen en lettertypen van de legenda ongedefinieerd, zodat zij de themavormgeving kunnen overnemen. Expliciete opmaak overschrijft de overeenkomstige thema‑instellingen.