---
title: Diagrammdatentabellen in Python anpassen
linktitle: Datentabelle
type: docs
url: /de/python-net/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schriftattribute
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Diagrammdatentabellen in Python für PPT, PPTX und ODP mit Aspose.Slides anpassen, um die Effizienz und Attraktivität von Präsentationen zu steigern."
---

## **Schriftattribute für Diagrammdatentabelle festlegen**
Aspose.Slides für Python via .NET bietet Unterstützung zum Ändern der Farbe von Kategorien in einer Serienfarbe.

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klassenobjekt.
1. Diagramm auf der Folie hinzufügen.
1. Diagrammtabelle festlegen.
1. Schriftgröße festlegen.
1. Modifizierte Präsentation speichern.

Nachstehendes Beispiel wird angegeben.  
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich kleine Legenden-Schlüssel neben den Werten in der Diagrammdatentabelle anzeigen?**

Ja. Die Datentabelle unterstützt [legend keys](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/), und Sie können sie ein- oder ausschalten.

**Wird die Datentabelle beim Exportieren der Präsentation in PDF, HTML oder Bilder erhalten bleiben?**

Ja. Aspose.Slides rendert das Diagramm als Teil der Folie, sodass das exportierte [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/de/python-net/convert-powerpoint-to-html/)/[image](/slides/de/python-net/convert-powerpoint-to-png/) die Diagramm mit seiner Datentabelle enthält.

**Werden Datentabellen für Diagramme unterstützt, die aus einer Vorlagendatei stammen?**

Ja. Für jedes Diagramm, das aus einer vorhandenen Präsentation oder Vorlage geladen wird, können Sie prüfen und ändern, ob eine Datentabelle [is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) mithilfe der Diagrammeigenschaften.

**Wie kann ich schnell herausfinden, welche Diagramme in einer Datei die Datentabelle aktiviert haben?**

Untersuchen Sie die Eigenschaft jedes Diagramms, die angibt, ob die Datentabelle [is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) und durchlaufen Sie die Folien, um die Diagramme zu identifizieren, bei denen sie aktiviert ist.