---
title: Diagramm‑Datentabellen in Präsentationen mit Python anpassen
linktitle: Datentabelle
type: docs
url: /de/python-java/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schriftarteigenschaften
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Passen Sie Diagramm‑Datentabellen in Python für PPT und PPTX mit Aspose.Slides für Python via Java an, um Effizienz und Attraktivität von Präsentationen zu steigern."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Datentabellen in Aspose.Slides arbeitet. Er zeigt, wie man eine Datentabelle für ein Diagramm anzeigt und deren Textformatierung anpasst, indem man Schriftarteigenschaften wie fetten Stil und Schriftgröße festlegt. Das Beispiel demonstriert das Erstellen einer Präsentation, das Hinzufügen eines Diagramms, das Aktivieren der Diagramm‑Datentabelle, das Anwenden von Schriftarteinstellungen und das Speichern der aktualisierten Präsentation.

Es enthält außerdem kurze Antworten auf häufige Fragen zum Anzeigen von Legenden‑Schlüsseln in einer Diagramm‑Datentabelle, zum Erhalt der Datentabelle beim Export, zur Arbeit mit Diagrammen, die aus vorhandenen Präsentationen oder Vorlagen geladen wurden, und zur Identifizierung von Diagrammen, bei denen die Datentabelle aktiviert ist.

## **Schriftarteigenschaften für eine Diagramm‑Datentabelle festlegen**

Aspose.Slides für Python via Java ermöglicht das Anzeigen der Datentabelle eines Diagramms und das Ändern der Schriftarteigenschaften seines Textes.

1. Instanziieren Sie die [Präsentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
1. Fügen Sie der Folie ein Diagramm hinzu.
1. Zeigen Sie die Diagramm‑Datentabelle an.
1. Legen Sie den fetten Stil und die Schriftgröße des Datentabelle‑Textes fest.
1. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel demonstriert diese Schritte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Erstelle eine leere Präsentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich kleine Legenden‑Schlüssel neben den Werten in der Diagramm‑Datentabelle anzeigen?**

Ja. Die Datentabelle unterstützt [Legenden‑Schlüssel](https://reference.aspose.com/slides/de/python-java/aspose.slides/datatable/#setShowLegendKey) und Sie können sie ein- oder ausschalten.

**Wird die Datentabelle beim Exportieren der Präsentation nach PDF, HTML oder Bildern beibehalten?**

Ja. Aspose.Slides rendert das Diagramm als Teil der Folie, sodass das exportierte [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/de/python-java/convert-powerpoint-to-html/)/[Bild](/slides/de/python-java/convert-powerpoint-to-png/) das Diagramm mit seiner Datentabelle enthält.

**Werden Datentabellen für Diagramme unterstützt, die aus einer Vorlagendatei stammen?**

Ja. Für jedes aus einer bestehenden Präsentation oder Vorlage geladene Diagramm können Sie mithilfe der Diagrammeigenschaften prüfen und ändern, ob eine Datentabelle [angezeigt wird](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#hasDataTable).

**Wie kann ich schnell herausfinden, welche Diagramme in einer Datei die Datentabelle aktiviert haben?**

Untersuchen Sie die Eigenschaft jedes Diagramms, die angibt, ob die Datentabelle [angezeigt wird](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#hasDataTable), und durchlaufen Sie die Folien, um die Diagramme zu identifizieren, bei denen sie aktiviert ist.