---
title: "Foutbalken aanpassen in presentatiediagrammen met Python"
linktitle: "Foutbalk"
type: docs
url: /nl/python-java/error-bar/
keywords:
- foutbalk
- aangepaste waarde
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u foutbalken kunt toevoegen en aanpassen in diagrammen met Aspose.Slides voor Python via Java—optimaliseer gegevensvisualisaties in PowerPoint‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u met foutbalken in presentatiediagrammen kunt werken met behulp van Aspose.Slides. Het laat zien hoe u foutbalken aan een diagramreeks kunt toevoegen, X‑ en Y‑foutbalkinstellingen kunt configureren, en verschillende waardetypen zoals vast, percentage en aangepast kunt toepassen.

Het laat ook zien hoe u aangepaste foutbalkwaarden kunt toewijzen aan afzonderlijke gegevenspunten in een reeks door de bijbehorende gegevenspuntverzameling te gebruiken. Bovendien bevat het artikel korte notities over hoe foutbalken zich gedragen tijdens export, hun compatibiliteit met markers en gegevenslabels, en waar u de gerelateerde API‑referentieklassen en enumeraties kunt vinden.

## **Foutbalken toevoegen**

Aspose.Slides for Python via Java biedt een eenvoudige API voor het beheren van foutbalkwaarden. De volgende voorbeeldcode gebruikt vaste en percentage waardetypen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Voeg een bubbel‑diagram toe aan de gewenste dia.
1. Open de eerste diagramreeks en stel het X‑foutbalkformaat in.
1. Open de eerste diagramreeks en stel het Y‑foutbalkformaat in.
1. Stel de foutbalkwaarden en opmaak in.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Maak een instantie van de Presentation-klasse.
presentation = Presentation()
try:
    # Maak een bubbel-diagram.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Voeg foutbalken toe en stel hun opmaak in.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # Sla de presentatie op.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aangepaste foutbalkwaarden toevoegen**

Aspose.Slides for Python via Java biedt een eenvoudige API voor het beheren van aangepaste foutbalkwaarden. De volgende voorbeeldcode is van toepassing wanneer [getValueType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/errorbarsformat/#getValueType) [ErrorBarValueType.Custom](https://reference.aspose.com/slides/nl/python-java/aspose.slides/errorbarvaluetype/#Custom) retourneert. Om een waarde op te geven, gebruikt u [getErrorBarsCustomValues](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) voor een specifiek gegevenspunt in de collectie die wordt geretourneerd door de seriemethode [getDataPoints](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#getDataPoints).

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Voeg een bubbel‑diagram toe aan de gewenste dia.
1. Open de eerste diagramreeks en stel het X‑foutbalkformaat in.
1. Open de eerste diagramreeks en stel het Y‑foutbalkformaat in.
1. Open de afzonderlijke gegevenspunten in de diagramreeks en stel hun foutbalkwaarden in.
1. Stel de foutbalkwaarden en opmaak in.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Maak een instantie van de Presentation-klasse.
presentation = Presentation()
try:
    # Maak een bubbel-diagram.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Voeg aangepaste foutbalken toe en stel hun opmaak in.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Open de gegevenspunten van de diagramreeks en configureer hun foutbalkwaarde‑bronnen.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Stel foutbalkwaarden in voor de gegevenspunten van de diagramreeks.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Sla de presentatie op.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Wat gebeurt er met foutbalken bij het exporteren van een presentatie naar PDF of afbeeldingen?**

Ze worden gerenderd als onderdeel van het diagram en behouden tijdens de conversie, samen met de rest van de diagramopmaak, mits er een compatibele versie of renderer wordt gebruikt.

**Kunnen foutbalken gecombineerd worden met markers en gegevenslabels?**

Ja. Foutbalken zijn een afzonderlijk element en zijn compatibel met markers en gegevenslabels; als elementen overlappen, moet u mogelijk de opmaak aanpassen.

**Waar kan ik de lijst met eigenschappen en klassen vinden om met foutbalken te werken in de API?**

In de API‑referentie: de klasse [ErrorBarsFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/errorbarsformat/) en de verwante klassen [ErrorBarType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/errorbartype/) en [ErrorBarValueType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/errorbarvaluetype/).