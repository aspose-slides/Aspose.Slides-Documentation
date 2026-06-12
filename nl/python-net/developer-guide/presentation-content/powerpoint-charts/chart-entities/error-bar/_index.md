---
title: Foutbalken aanpassen in presentatiediagrammen met Python
linktitle: Foutbalk
type: docs
url: /nl/python-net/error-bar/
keywords:
- foutbalk
- aangepaste waarde
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u foutbalken kunt toevoegen en aanpassen in diagrammen met Aspose.Slides for Python via .NET — optimaliseer gegevensvisualisaties in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe je met foutbalken in presentatiediagrammen werkt met behulp van Aspose.Slides. Het toont hoe je foutbalken toevoegt aan een diagramreeks, X‑ en Y‑foutbalkinstellingen configureert en verschillende waardetypen toepast, zoals vaste, procentuele en aangepaste waarden.

Het laat ook zien hoe je aangepaste foutbalkwaarden toekent aan individuele gegevenspunten in een reeks via de bijbehorende verzameling gegevenspunten. Daarnaast bevat het artikel korte opmerkingen over hoe foutbalken zich gedragen tijdens export, hun compatibiliteit met markers en data‑labels, en waar je de gerelateerde API‑referentieklassen en enumeraties kunt vinden.

## **Foutbalk toevoegen**
Aspose.Slides for Python via .NET biedt een eenvoudige API voor het beheren van foutbalkwaarden. De voorbeeldcode is van toepassing bij het gebruik van een aangepast waardetype. Om een waarde op te geven, gebruik je de **ErrorBarCustomValues**‑eigenschap van een specifiek gegevenspunt in de **DataPoints**‑verzameling van de reeks:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse aan.
1. Voeg een bubbelgrafiek toe op de gewenste dia.
1. Toegang tot de eerste diagramreeks en stel het foutbalk‑X‑formaat in.
1. Toegang tot de eerste diagramreeks en stel het foutbalk‑Y‑formaat in.
1. Stel de waarden en het formaat van de balken in.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Een lege presentatie maken
with slides.Presentation() as presentation:
    # Een bubbelgrafiek maken
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Foutbalken toevoegen en het formaat instellen
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Presentatie opslaan
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Aangepaste foutbalkwaarde toevoegen**
Aspose.Slides for Python via .NET biedt een eenvoudige API voor het beheren van aangepaste foutbalkwaarden. De voorbeeldcode is van toepassing wanneer de **IErrorBarsFormat.ValueType**‑eigenschap gelijk is aan **Custom**. Om een waarde op te geven, gebruik je de **ErrorBarCustomValues**‑eigenschap van een specifiek gegevenspunt in de **DataPoints**‑verzameling van de reeks:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse aan.
1. Voeg een bubbelgrafiek toe op de gewenste dia.
1. Toegang tot de eerste diagramreeks en stel het foutbalk‑X‑formaat in.
1. Toegang tot de eerste diagramreeks en stel het foutbalk‑Y‑formaat in.
1. Toegang tot de individuele gegevenspunten van de diagramreeks en stel de foutbalkwaarden in voor elk gegevenspunt van de reeks.
1. Stel de waarden en het formaat van de balken in.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Een lege presentatie maken
with slides.Presentation() as presentation:
    # Een bubbelgrafiek maken
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Aangepaste foutbalken toevoegen en het formaat instellen
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # De gegevenspunten van de diagramreeks benaderen en foutbalkwaarden instellen voor individueel punt
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Foutbalken instellen voor diagramreekspunten
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Presentatie opslaan
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wat gebeurt er met foutbalken bij het exporteren van een presentatie naar PDF of afbeeldingen?**

Ze worden gerenderd als onderdeel van het diagram en behouden tijdens de conversie samen met de rest van de diagramopmaak, mits er een compatibele versie of renderer wordt gebruikt.

**Kunnen foutbalken worden gecombineerd met markers en datalabels?**

Ja. Foutbalken zijn een afzonderlijk element en zijn compatibel met markers en datalabels; als elementen elkaar overlappen, moet je mogelijk de opmaak aanpassen.

**Waar kan ik de lijst met eigenschappen en enumeraties vinden voor het werken met foutbalken in de API?**

In de API‑referentie: de [ErrorBarsFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/errorbarsformat/) klasse en de gerelateerde enumeraties [ErrorBarType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/errorbartype/) en [ErrorBarValueType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/errorbarvaluetype/).