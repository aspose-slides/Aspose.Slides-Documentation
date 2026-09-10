---
title: "Datenpunkte in Treemap- und Sunburst-Diagrammen in Python anpassen"
linktitle: "Datenpunkte in Treemap- und Sunburst-Diagrammen"
type: docs
url: /de/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap-Diagramm
- Sunburst-Diagramm
- Hierarchisches Diagramm
- Datenpunkt
- Datenbeschriftung
- Zweigfarbe
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie hierarchische Daten erstellen und Ebenen, Beschriftungen und Farben in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für Python via Java anpassen."
---
## **Übersicht**

Treemap‑ und Sunburst‑Diagramme zeigen dieselbe Art hierarchischer Daten, verwenden jedoch unterschiedliche Layouts. Ein Treemap zeichnet die Hierarchie als verschachtelte Rechtecke, deren Flächen die Blattwerte repräsentieren. Ein Sunburst zeichnet sie als konzentrische Ringe: Oberste Gruppen befinden sich nahe dem Zentrum, und Blattkategorien liegen am äußeren Ring.

In Aspose.Slides für Python via Java ist jeder numerische Wert ein [ChartDataPoint](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/). Seine Methode [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) bietet Zugriff auf das Blatt und seine übergeordneten Gruppen. Dieser Artikel erklärt diese Zuordnung und zeigt, wie beide Diagrammtypen aus denselben Beispieldaten erstellt und formatiert werden.

![Ein Treemap‑Diagramm mit den Zweigen Consumer und Business](treemap-hierarchy.png)

![Ein Sunburst‑Diagramm mit derselben Consumer‑ und Business‑Hierarchie](sunburst-hierarchy.png)

## **Kategorien, Datenpunkte und Ebenen verstehen**

Das unten verwendete Beispiel hat drei Kategorisierungsebenen und eine numerische Serie:

| Zweig | Stamm | Blatt | Umsatz |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Jede Zeile erzeugt eine Blattkategorie und einen Datenpunkt. Die Kategorisierungs­ebenen beschreiben den Pfad von diesem Blatt zu seinen Eltern. Für die erste Zeile lautet der Pfad `Consumer > Computers > Laptops`.

Die von [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) zurückgegebenen Indizes laufen vom Blatt nach oben:

| `getDataPointLevels()`‑Index | Logische Ebene | Treemap‑Darstellung | Sunburst‑Darstellung |
| ---: | --- | --- | --- |
| `0` | Blatt | Werte‑Rechteck | Segment des Außenrings |
| `1` | Stamm | Eltern‑Rechteck oder Header | Segment des Mittelrings |
| `2` | Zweig | Oberstes Rechteck oder Header | Segment des Innenrings |

Diese Reihenfolge ist für beide Diagrammtypen gleich, obwohl ihre visuellen Layouts unterschiedlich sind. Ein Eltern‑Segment wird von mehreren Blättern gemeinsam genutzt. Um es zu formatieren, verwenden Sie die entsprechende Ebene des ersten Datenpunkts in dieser Gruppe. Beispiel: Der `Consumer`‑Zweig beginnt mit dem Punkt `Laptops`, während der `Software`‑Stamm mit dem Punkt `Licenses` beginnt. Referenzen auf diese Punkte zu behalten, ist klarer und sicherer, als unerklärte Ausdrücke wie `data_points.get_Item(0)` oder `data_points.get_Item(6)` zu benutzen.

## **Erstellen und Anpassen beider Diagrammtypen**

Das folgende vollständige Beispiel erstellt ein Treemap auf der ersten Folie und ein Sunburst auf der zweiten Folie. Es baut die Hierarchie auf, zeigt den Wert für `Tablets` an, wendet feste Farben auf ausgewählte Ebenen an, formatiert eine Zweig‑Beschriftung und speichert die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # Blattkategorien hinzufügen. Ein Gruppierungselement wird nur gesetzt, wenn eine neue Gruppe beginnt;
        # die folgenden Kategorien bleiben in dieser Gruppe, bis ein weiteres Element gesetzt wird.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Kategorie und Wert im Blatt 'Tablets' anzeigen.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Den Consumer-Zweig über das erste Blatt dieses Zweigs formatieren.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Den Software-Stamm über das erste Blatt dieses Stamms formatieren.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout beeinflusst die Elternbeschriftungen von Treemap; Sunburst verwendet Ringsegmente.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Kategoriezellen und Wertzellen verwenden dieselbe Arbeitsblattzeile, sodass ihre Sammlungspositionen ausgerichtet bleiben. Wenn Sie mit einem bereits vorhandenen Diagramm arbeiten, prüfen Sie zuerst die Kategorier­zeilen und speichern Sie benannte Verweise auf die Datenpunkte und Ebenen, die Sie formatieren möchten.

## **Verhalten und praktische Überlegungen**

### **Unterschiede zwischen Treemap und Sunburst**

- Ein Treemap verwendet Fläche, um Werte zu kommunizieren, und verschachtelte Rechtecke, um die Hierarchie darzustellen. Die Methode [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#setParentLabelLayout) steuert, wie Eltern‑Beschriftungen in diesem Diagrammtyp angezeigt werden.
- Ein Sunburst verwendet Winkel, um Werte zu kommunizieren, und Ringtiefe, um die Hierarchie darzustellen. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#setParentLabelLayout) steuert seine Ring‑Beschriftungen nicht.
- Beide Diagrammtypen verwenden dieselben Kategorisierungs­ebenen und dieselbe Blatt‑zu‑Eltern‑Reihenfolge, die von [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) zurückgegeben wird, sodass der Code zum Aufbau der Daten und zur Ebenen‑Formatierung gemeinsam genutzt werden kann.
- Elternwerte werden aus ihren nachfolgenden Blättern berechnet. Fügen Sie keine separaten numerischen Punkte für Zweige oder Stämme hinzu.

### **Sortierung und Segmentreihenfolge**

Die Layout‑Engine des Diagramms bestimmt die endgültige Platzierung von Rechtecken und Ringsegmenten. Ordnen Sie verwandte Kategorier­zeilen zusammen, bevor Sie sie hinzufügen, verlassen Sie sich jedoch nicht auf eine bestimmte Rechtecksposition oder Startwinkel. Wenn die Reihenfolge Bedeutung hat, fügen Sie sie in die Beschriftungen ein oder verwenden Sie einen Diagrammtyp mit expliziter Kategorien‑Achse.

### **Design und feste Farben**

Unformatierte Diagramm‑Ebenen erben Farben aus dem Präsentations‑Design. Das Beispiel verwendet explizite RGB‑Füllungen für vorhersehbare Ergebnisse. Wenn das Diagramm Design‑Änderungen folgen soll, nutzen Sie Schemafarben anstelle fester RGB‑Werte und überschreiben Sie nicht jede Ebene. Prüfen Sie zudem den Beschriftungs‑Kontrast, nachdem Sie die Füllung eines Zweigs oder Stamms geändert haben.

### **Beschriftungen und verfügbarer Raum**

PowerPoint kann Beschriftungen ausblenden oder abschneiden, wenn ein Segment zu klein ist. Das Vergrößern des Diagramms, das Kürzen von Kategorienamen oder das Anzeigen weniger Beschriftungsfelder erzeugt in der Regel ein klareres Ergebnis. Eine Beschriftung kann den Kategorienamen, Seriennamen und Wert über [DataLabelFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabelformat/) kombinieren, doch das Aktivieren jedes Feldes macht hierarchische Diagramme häufig schwer lesbar.

### **Export und Rendering**

Das Speichern im PPTX‑Format hält das Diagramm editierbar. Wenn Aspose.Slides die Präsentation zu PDF oder einem Bild rendert, werden die unterstützten Füllungen und Beschriftungseinstellungen mit dem Diagramm gerendert. Schriftart‑Ersetzung und kleine Unterschiede im verfügbaren Layout‑Raum können Zeilenumbrüche oder die Sichtbarkeit von Beschriftungen ändern, also stellen Sie die erforderlichen Schriftarten bereit und überprüfen Sie die wichtigen Export‑Ziele.

## **FAQ**

**Warum beeinflusst das Ändern einer Eltern‑Ebene mehrere Blätter?**

Ein Zweig oder Stamm ist ein gemeinsam genutztes visuelles Segment. Sein [ChartDataPointLevel](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapointlevel/) kann über ein nachgelagertes Blatt erreicht werden, doch die Formatierung gehört zum gemeinsam genutzten Eltern‑Segment und nicht nur zu diesem Blatt.

**Warum fehlt ein Datenbeschriftungsfeld?**

Aktivieren Sie zuerst die gewünschten Felder im [DataLabelFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/datalabelformat/)-Objekt der Beschriftung. Prüfen Sie dann, ob das Segment genug Platz hat. Das Layout‑Verhalten von Treemap‑Eltern‑Beschriftungen, Diagrammgröße, Beschriftungslänge, Schriftgröße und die Anzahl aktivierter Felder beeinflussen, ob eine Beschriftung angezeigt werden kann.

**Kann ich die exakte Reihenfolge oder Koordinaten von Segmenten festlegen?**

Sie können die Reihenfolge der Quell‑Zeilen steuern und jede Gruppe zusammenhängend halten, aber Sie können keine genauen Treemap‑Rechtecke oder Sunburst‑Winkel zuweisen. Die Layout‑Engine berechnet sie aus der Hierarchie, den Werten und dem verfügbaren Raum.

**Warum ändern sich Farben, wenn das Präsentations‑Design geändert wird?**

Design‑basierte Füllungen sind dafür vorgesehen, der Präsentations‑Palette zu folgen. Verwenden Sie explizite RGB‑Farben für Ebenen, die fest bleiben müssen, oder behalten Sie Schemafarben bei, wenn die Anpassung an ein neues Design gewünscht ist.

**Werden benutzerdefinierte Formatierungen bei PDF‑ und Bild‑Exporten beibehalten?**

Ja, unterstützte Diagramm‑Füllungen und Beschriftungseinstellungen werden beim Rendern berücksichtigt. Für konsistente Ergebnisse auf allen Systemen stellen Sie die benötigten Schriftarten bereit und testen die endgültige Exportgröße, da die Beschriftungs‑Anpassung layoutsensitiv ist.

## **Siehe auch**

- [Create Treemap charts](/slides/de/python-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/de/python-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/de/python-java/export-chart/)
- [Manage presentation themes](/slides/de/python-java/presentation-theme/)