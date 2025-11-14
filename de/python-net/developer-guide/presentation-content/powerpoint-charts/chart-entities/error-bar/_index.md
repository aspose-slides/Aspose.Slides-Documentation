---
title: Fehlerbalken in Präsentationsdiagrammen mit Python anpassen
linktitle: Fehlerbalken
type: docs
url: /de/python-net/error-bar/
keywords:
- Fehlerbalken
- Benutzerdefinierter Wert
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides for Python via .NET Fehlerbalken in Diagrammen hinzufügen und anpassen – optimieren Sie Datenvisualisierungen in PowerPoint- und OpenDocument-Präsentationen."
---

## **Fehlerbalken hinzufügen**
Aspose.Slides für Python über .NET bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode gilt, wenn ein benutzerdefinierter Wertetyp verwendet wird. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**-Eigenschaft eines bestimmten Datenpunkts in der **DataPoints**-Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Fügen Sie ein Blasen-Diagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Fehlerbalken-X-Format.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Fehlerbalken-Y-Format.
1. Festlegen der Balkenwerte und des Formats.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstellen einer leeren Präsentation
with slides.Presentation() as presentation:
    # Erstellen eines Blasen-Diagramms
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Hinzufügen von Fehlerbalken und Festlegen des Formats
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

    # Speichern der Präsentation
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Benutzerdefinierten Fehlerbalkenwert hinzufügen**
Aspose.Slides für Python über .NET bietet eine einfache API zur Verwaltung benutzerdefinierter Fehlerbalkenwerte. Der Beispielcode gilt, wenn die **IErrorBarsFormat.ValueType**-Eigenschaft gleich **Custom** ist. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**-Eigenschaft eines bestimmten Datenpunkts in der **DataPoints**-Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Fügen Sie ein Blasen-Diagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Fehlerbalken-X-Format.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Fehlerbalken-Y-Format.
1. Greifen Sie auf die einzelnen Datenpunkte der Diagrammserie zu und legen Sie die Fehlerbalkenwerte für den einzelnen Datenpunkt der Serie fest.
1. Festlegen der Balkenwerte und des Formats.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstellen einer leeren Präsentation
with slides.Presentation() as presentation:
    # Erstellen eines Blasen-Diagramms
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Hinzufügen von benutzerdefinierten Fehlerbalken und Festlegen des Formats
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Zugriff auf die Datenpunkte der Diagrammserie und Festlegen der Fehlerbalkenwerte für den einzelnen Punkt
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Festlegen der Fehlerbalken für die Punkte der Diagrammserie
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Speichern der Präsentation
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```