---
title: "Diagrammdatentabellen in Präsentationen mit Python anpassen"
linktitle: "Datentabelle"
type: docs
url: /de/python-java/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schrifteigenschaften
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Passen Sie Schriftarten, Rahmen und Legendenkennzeichnungen der Diagrammdatentabelle in PowerPoint-Präsentationen mit Aspose.Slides für Python über Java an."
---
## **Übersicht**

Aspose.Slides für Python über Java ermöglicht das Anzeigen einer Datentabelle eines Diagramms und das Anpassen ihrer Textformatierung, Rahmen und Legendenkennzeichnungen. Dieser Artikel erklärt, wie die Tabelle aktiviert, ihr Text formatiert, jeder Rahmentyp gesteuert und Legendenkennzeichnungen ein‑ oder ausgeblendet werden. Die Beispiele speichern die konfigurierten Diagramme in PPTX‑Dateien.

## **Schriftarteigenschaften festlegen**

Um die Datentabelle eines Diagramms anzuzeigen, übergeben Sie `True` an [setDataTable](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#setDataTable). Verwenden Sie [getChartDataTable](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#getChartDataTable), um auf die Tabelle zuzugreifen und ihre Textformatierung zu konfigurieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
1. Fügen Sie der ersten Folie ein gruppiertes Säulendiagramm hinzu.
1. Aktivieren Sie die Datentabelle des Diagramms.
1. Aktivieren Sie fetten Text mit [setFontBold](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setFontBold) und übergeben Sie `20` an [setFontHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setFontHeight), um 20‑Punkt‑Text zu erhalten.
1. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel erfordert die Datei `test.pptx` im Arbeitsverzeichnis mit mindestens einer Folie. Es fügt ein Diagramm mit Standarddaten an der Position (50, 50) ein, mit einer Breite von 600 Punkten und einer Höhe von 400 Punkten. Die gespeicherte Datei `output.pptx` enthält das Diagramm mit aktivierter Datentabelle und den angegebenen Schriftsatzeinstellungen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rahmen der Datentabelle anpassen**

Aktivieren Sie die Tabelle mit [Chart.setDataTable](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#setDataTable) und greifen Sie über [Chart.getChartDataTable](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#getChartDataTable) darauf zu. Sie können drei Arten von Rahmen unabhängig steuern:

- [setBorderHorizontal](https://reference.aspose.com/slides/de/python-java/aspose.slides/datatable/#setBorderHorizontal) steuert die horizontalen Zellenrahmen.
- [setBorderVertical](https://reference.aspose.com/slides/de/python-java/aspose.slides/datatable/#setBorderVertical) steuert die vertikalen Zellenrahmen.
- [setBorderOutline](https://reference.aspose.com/slides/de/python-java/aspose.slides/datatable/#setBorderOutline) steuert den äußeren Tabellenrahmen.

Übergeben Sie `True` an jede Methode, um deren Rahmen anzuzeigen, oder `False`, um sie zu verbergen. Das folgende Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten, zeigt horizontale Rahmen und den äußeren Rahmen an und verbirgt die vertikalen Rahmen. Es benötigt keine Eingabedatei. Position und Größe des Diagramms werden in Punkten angegeben.

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
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der Vergleich unten verwendet in allen vier Fällen dieselben Diagrammdaten und dieselbe Legenden‑Schlüssel‑Einstellung. Beginnend mit allen aktivierten Rahmen deaktiviert jede weitere Variante genau einen Rahmeneinstellung. Die links‑untere Variante entspricht den Rahmeneinstellungen im Beispiel.

![Diagramm‑Datentabellen mit allen aktivierten Rahmen, ohne horizontale Rahmen, ohne vertikale Rahmen und ohne äußeren Rahmen](data-table-borders.png)

## **Legendenkennzeichnungen ein- oder ausblenden**

Legendenkennzeichnungen sind kleine farbige Markierungen neben den Seriennamen in der Datentabelle. Sie helfen den Lesern, jede Tabellenzeile einer Diagrammserie zuzuordnen. Übergeben Sie `True` an [setShowLegendKey](https://reference.aspose.com/slides/de/python-java/aspose.slides/datatable/#setShowLegendKey), um diese Markierungen anzuzeigen, oder `False`, um sie zu verbergen.

Die separate Legende des Diagramms wird über [Chart.setLegend](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#setLegend) gesteuert. Diese Einstellungen sind unabhängig: Das Ausblenden der separaten Legende blendet die Kennzeichnungen in der Datentabelle nicht aus, und das Ausblenden der Tabellenkennzeichnungen blendet die separate Legende nicht aus.

Das folgende Beispiel erstellt ein Diagramm mit Standarddaten, aktiviert dessen Datentabelle und zeigt Legendenkennzeichnungen darin an, während die separate Legende ausgeblendet wird. Alle Tabellenrahmen werden ausdrücklich aktiviert. Keine Eingabepräsentation ist erforderlich. Um nur die Kennzeichnungen der Tabelle zu verbergen, übergeben Sie `False` an [setShowLegendKey](https://reference.aspose.com/slides/de/python-java/aspose.slides/datatable/#setShowLegendKey).

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
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der Vergleich unten zeigt dieselbe Tabelle mit aktivierten und deaktivierten Legendenkennzeichnungen. Alle Rahmen bleiben aktiviert, und die separate Diagrammlegende ist in beiden Fällen ausgeblendet.

![Diagramm‑Datentabellen mit Legendenkennzeichnungen links angezeigt und rechts ausgeblendet](data-table-legend-keys.png)

## **FAQ**

**Kann ich Legendenkennzeichnungen in einer Diagrammdatentabelle anzeigen?**

Ja. Übergeben Sie `True` an [setShowLegendKey](https://reference.aspose.com/slides/de/python-java/aspose.slides/datatable/#setShowLegendKey), um Legendenkennzeichnungen anzuzeigen, oder `False`, um sie zu verbergen.

**Wird die Datentabelle beim Export der Präsentation nach PDF, HTML oder Bildern beibehalten?**

Ja. Aspose.Slides rendert das Diagramm und die angezeigte Datentabelle als Teil der Folie, wenn Sie nach [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/de/python-java/convert-powerpoint-to-html/) oder [Bilder](/slides/de/python-java/convert-powerpoint-to-png/) exportieren.

**Kann ich mit Datentabellen in aus einer Vorlage geladenen Diagrammen arbeiten?**

Ja. Für ein Diagramm, das aus einer bestehenden Präsentation oder Vorlage geladen wurde, verwenden Sie [hasDataTable](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#hasDataTable) und [setDataTable](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#setDataTable), um zu prüfen oder zu ändern, ob dessen Datentabelle angezeigt wird.

**Wie kann ich Diagramme finden, bei denen die Datentabelle aktiviert ist?**

Iterieren Sie über die Formen jeder Folie, identifizieren Sie die Diagramme und rufen Sie deren Methode [hasDataTable](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#hasDataTable) auf. Ein Wert von `True` zeigt an, dass die Datentabelle aktiviert ist.