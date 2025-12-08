---
title: Diagrammdaten-Tabellen in Python anpassen
linktitle: Diagrammdaten-Tabelle
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
description: "Passen Sie Diagrammdaten-Tabellen in Python für PPT, PPTX und ODP mit Aspose.Slides an, um die Effizienz und Attraktivität von Präsentationen zu steigern."
---

## **Schriftattribute für Diagrammdatenfeld festlegen**
Aspose.Slides für Python via .NET bietet Unterstützung zum Ändern der Farbe von Kategorien in einer Serienfarbe.

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klassenobjekt.
2. Fügen Sie dem Folie ein Diagramm hinzu.
3. Diagrammtabelle festlegen.
4. Schriftgröße festlegen.
5. Speichern Sie die geänderte Präsentation.

Im Folgenden wird ein Beispiel gezeigt.
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

**Kann ich kleine Legenden‑Schlüssel neben den Werten in der Diagrammdaten‑tabelle anzeigen?**

Ja. Die Datentabelle unterstützt [Legenden‑Schlüssel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/), und Sie können sie ein- oder ausschalten.

**Wird die Datentabelle beim Exportieren der Präsentation nach PDF, HTML oder Bildern beibehalten?**

Ja. Aspose.Slides rendert das Diagramm als Teil der Folie, sodass das exportierte [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/de/python-net/convert-powerpoint-to-html/)/[image](/slides/de/python-net/convert-powerpoint-to-png/) das Diagramm mit seiner Datentabelle enthält.

**Werden Datentabellen für Diagramme unterstützt, die aus einer Vorlagendatei stammen?**

Ja. Für jedes aus einer vorhandenen Präsentation oder Vorlage geladene Diagramm können Sie mithilfe der Diagrammeigenschaften prüfen und ändern, ob eine Datentabelle [angezeigt wird](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/).

**Wie kann ich schnell herausfinden, welche Diagramme in einer Datei die Datentabelle aktiviert haben?**

Untersuchen Sie die Eigenschaft jedes Diagramms, die anzeigt, ob die Datentabelle [angezeigt wird](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/), und durchlaufen Sie die Folien, um die Diagramme zu identifizieren, bei denen sie aktiviert ist.