---
title: Fehlerbalken in Präsentationsdiagrammen mit Python anpassen
linktitle: Fehlerbalken
type: docs
url: /de/python-java/error-bar/
keywords:
- Fehlerbalken
- benutzerdefinierter Wert
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für Python via Java Fehlerbalken in Diagrammen hinzufügen und anpassen – optimieren Sie die Datenvisualisierung in PowerPoint‑Präsentationen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Fehlerbalken in Präsentationsdiagrammen unter Verwendung von Aspose.Slides arbeitet. Er zeigt, wie man Fehlerbalken zu einer Diagrammserie hinzufügt, X‑ und Y‑Fehlerbalkeneinstellungen konfiguriert und verschiedene Werttypen wie fest, prozentual und benutzerdefiniert anwendet.

Außerdem wird demonstriert, wie man für einzelne Datenpunkte einer Serie benutzerdefinierte Fehlerbalkenwerte zuweist, indem man die entsprechende Datenpunkt‑Sammlung verwendet. Zusätzlich enthält der Artikel kurze Hinweise dazu, wie sich Fehlerbalken beim Export verhalten, ihre Kompatibilität mit Markern und Datenbeschriftungen sowie wo man die zugehörigen API‑Referenzklassen und Aufzählungen findet.

## **Fehlerbalken hinzufügen**

Aspose.Slides for Python via Java provides a simple API for managing error bar values. The following sample code uses fixed and percentage value types.

1. Erstellen Sie eine Instanz der Klasse Presentation.
1. Fügen Sie der gewünschten Folie ein Blasendiagramm hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Format des Fehlerbalkens.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Format des Fehlerbalkens.
1. Legen Sie die Fehlerbalkenwerte und die Formatierung fest.
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Erstelle eine Instanz der Klasse Presentation.
presentation = Presentation()
try:
    # Erstelle ein Blasendiagramm.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Füge Fehlerbalken hinzu und setze deren Formatierung.
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

    # Speichere die Präsentation.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Benutzerdefinierte Fehlerbalkenwerte hinzufügen**

Aspose.Slides for Python via Java provides a simple API for managing custom error bar values. The following sample code applies when [getValueType](https://reference.aspose.com/slides/de/python-java/aspose.slides/errorbarsformat/#getValueType) returns [ErrorBarValueType.Custom](https://reference.aspose.com/slides/de/python-java/aspose.slides/errorbarvaluetype/#Custom). To specify a value, use [getErrorBarsCustomValues](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) for a specific data point in the collection returned by the series method [getDataPoints](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getDataPoints).

1. Erstellen Sie eine Instanz der Klasse Presentation.
1. Fügen Sie der gewünschten Folie ein Blasendiagramm hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Format des Fehlerbalkens.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Format des Fehlerbalkens.
1. Greifen Sie auf die einzelnen Datenpunkte in der Diagrammserie zu und setzen Sie deren Fehlerbalkenwerte.
1. Legen Sie die Fehlerbalkenwerte und die Formatierung fest.
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Erstelle eine Instanz der Klasse Presentation.
presentation = Presentation()
try:
    # Erstelle ein Blasendiagramm.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Füge benutzerdefinierte Fehlerbalken hinzu und setze deren Formatierung.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Greife auf die Datenpunkte der Diagrammserie zu und konfiguriere deren Fehlerbalken‑Wertquellen.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Setze Fehlerbalkenwerte für die Datenpunkte der Diagrammserie.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Speichere die Präsentation.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Was passiert mit Fehlerbalken, wenn eine Präsentation in PDF oder Bilder exportiert wird?**

Sie werden als Teil des Diagramms gerendert und bei der Konvertierung zusammen mit der restlichen Diagrammformatierung erhalten, vorausgesetzt, es wird eine kompatible Version oder ein Renderer verwendet.

**Können Fehlerbalken mit Markern und Datenbeschriftungen kombiniert werden?**

Ja. Fehlerbalken sind ein separates Element und sind mit Markern und Datenbeschriftungen kompatibel; wenn sich Elemente überschneiden, müssen Sie möglicherweise die Formatierung anpassen.

**Wo finde ich die Liste der Eigenschaften und Klassen für die Arbeit mit Fehlerbalken in der API?**

In der API‑Referenz: die Klasse [ErrorBarsFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/errorbarsformat/) und die zugehörigen Klassen [ErrorBarType](https://reference.aspose.com/slides/de/python-java/aspose.slides/errorbartype/) und [ErrorBarValueType](https://reference.aspose.com/slides/de/python-java/aspose.slides/errorbarvaluetype/).