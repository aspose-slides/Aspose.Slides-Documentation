---
title: Fehlerbalken in Präsentationsdiagrammen mit Python anpassen
linktitle: Fehlerbalken
type: docs
url: /de/python-net/error-bar/
keywords:
- Fehlerbalken
- benutzerdefinierter Wert
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Fehlerbalken in Diagrammen mit Aspose.Slides für Python via .NET hinzufügen und anpassen - optimieren Sie die Datenvisualisierung in PowerPoint- und OpenDocument-Präsentationen."
---

## **Fehlerbalken hinzufügen**
Aspose.Slides for Python via .NET bietet eine einfache API zum Verwalten von Fehlerbalkenwerten. Der Beispielcode gilt für die Verwendung eines benutzerdefinierten Werttyps. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der **DataPoints**‑Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Fügen Sie auf der gewünschten Folie ein Blasendiagramm hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Fehlerbalken‑X‑Format.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Fehlerbalken‑Y‑Format.
1. Werte und Format der Balken festlegen.
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstellen einer leeren Präsentation
with slides.Presentation() as presentation:
    # Erstellen eines Blasendiagramms
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
Aspose.Slides for Python via .NET bietet eine einfache API zum Verwalten benutzerdefinierter Fehlerbalkenwerte. Der Beispielcode gilt, wenn die **IErrorBarsFormat.ValueType**‑Eigenschaft den Wert **Custom** hat. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der **DataPoints**‑Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Fügen Sie auf der gewünschten Folie ein Blasendiagramm hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Fehlerbalken‑X‑Format.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Fehlerbalken‑Y‑Format.
1. Greifen Sie auf einzelne Datenpunkte der Diagrammserie zu und legen Sie die Fehlerbalkenwerte für den jeweiligen Datenpunkt fest.
1. Werte und Format der Balken festlegen.
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Erstellen einer leeren Präsentation
with slides.Presentation() as presentation:
    # Erstellen eines Blasendiagramms
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Hinzufügen benutzerdefinierter Fehlerbalken und Festlegen des Formats
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Zugriff auf Datenpunkt der Diagrammserie und Festlegen der Fehlerbalkenwerte für einzelnen Punkt
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Festlegen der Fehlerbalken für Diagrammserienpunkte
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Speichern der Präsentation
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Was passiert mit Fehlerbalken beim Export einer Präsentation in PDF oder Bilddateien?**

Sie werden als Teil des Diagramms gerendert und während der Konvertierung zusammen mit der restlichen Diagrammformatierung erhalten, vorausgesetzt, es wird eine kompatible Version oder ein kompatibler Renderer verwendet.

**Können Fehlerbalken mit Markern und Datenbeschriftungen kombiniert werden?**

Ja. Fehlerbalken sind ein separates Element und sind mit Markern und Datenbeschriftungen kompatibel; überschneiden sich die Elemente, müssen Sie ggf. die Formatierung anpassen.

**Wo finde ich die Liste der Eigenschaften und Aufzählungen für die Arbeit mit Fehlerbalken in der API?**

In der API‑Referenz: die [ErrorBarsFormat](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarsformat/)‑Klasse und die zugehörigen Aufzählungen [ErrorBarType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbartype/) und [ErrorBarValueType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarvaluetype/).