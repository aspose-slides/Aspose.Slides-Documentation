---
title: Anpassen von Datenpunkten in Treemap‑ und Sunburst‑Diagrammen in Python
linktitle: Datenpunkte in Treemap‑ und Sunburst‑Diagrammen
type: docs
url: /de/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap‑Diagramm
- Sunburst‑Diagramm
- Hierarchisches Diagramm
- Datenpunkt
- Datenbeschriftung
- Zweigfarbe
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie hierarchische Daten erstellen und Ebenen, Beschriftungen und Farben in Treemap‑ und Sunburst‑Diagrammen mit Aspose.Slides für Python via .NET anpassen."
---
## **Übersicht**

Treemap‑ und Sunburst‑Diagramme zeigen dieselbe Art von hierarchischen Daten an, verwenden jedoch unterschiedliche Layouts. Ein Treemap stellt die Hierarchie als verschachtelte Rechtecke dar, deren Flächen die Blattwerte repräsentieren. Ein Sunburst stellt sie als konzentrische Ringe dar: Oberste Gruppen befinden sich in der Nähe des Zentrums, und Blattkategorien liegen auf dem äußeren Ring.

In Aspose.Slides for Python via .NET ist jeder numerische Wert ein [ChartDataPoint](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatapoint/). Seine [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/)‑Sammlung bietet Zugriff auf das Blatt und seine übergeordneten Gruppen. Dieser Artikel erklärt diese Zuordnung und zeigt, wie beide Diagrammtypen aus denselben Beispieldaten erstellt und formatiert werden.

![Ein Treemap‑Diagramm mit den Zweigen Consumer und Business](treemap-hierarchy.png)

![Ein Sunburst‑Diagramm mit derselben Consumer‑ und Business‑Hierarchie](sunburst-hierarchy.png)

## **Kategorien, Datenpunkte und Ebenen verstehen**

Das unten verwendete Beispiel enthält drei Kategoriewebenen und eine numerische Serie:

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

Jede Zeile erzeugt eine Blattkategorie und einen Datenpunkt. Die Kategoriegruppierungsebenen beschreiben den Pfad von diesem Blatt zu seinen Eltern. Für die erste Zeile lautet der Pfad `Consumer > Computers > Laptops`.

Die Indizes in [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) laufen vom Blatt nach oben:

| Index `data_point_levels` | Logische Ebene | Treemap‑Darstellung | Sunburst‑Darstellung |
| ---: | --- | --- | --- |
| `0` | Blatt | Wertrechteck | Segment des äußeren Rings |
| `1` | Stamm | Elternrechteck oder -überschrift | Segment des mittleren Rings |
| `2` | Zweig | Oberstes Rechteck oder -überschrift | Segment des inneren Rings |

Diese Reihenfolge ist für beide Diagrammtypen identisch, obwohl ihre visuellen Layouts unterschiedlich sind. Ein übergeordnetes Segment wird von mehreren Blättern gemeinsam genutzt. Um es zu formatieren, verwenden Sie die entsprechende Ebene des ersten Datenpunkts in dieser Gruppe. Zum Beispiel beginnt der `Consumer`‑Zweig mit dem `Laptops`‑Punkt, während der `Software`‑Stamm mit dem `Licenses`‑Punkt beginnt. Referenzen auf diese Punkte zu behalten ist klarer und sicherer, als undefinierte Ausdrücke wie `data_points[0]` oder `data_points[6]` zu nutzen.

## **Beide Diagrammtypen erstellen und anpassen**

Das folgende vollständige Beispiel erstellt ein Treemap auf der ersten Folie und ein Sunburst auf der zweiten Folie. Es baut die Hierarchie auf, zeigt den Wert für `Tablets` an, wendet feste Farben auf ausgewählte Ebenen an, formatiert eine Zweig‑Beschriftung und speichert die Präsentation.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # Füge die Blattkategorien hinzu. Ein Gruppierungselement wird nur gesetzt, wenn eine neue Gruppe beginnt;
    # Die folgenden Kategorien bleiben in dieser Gruppe, bis ein weiteres Element gesetzt wird.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Zeige die Kategorie und den Wert im Blatt Tablets an.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Formatiere den Consumer‑Zweig über das erste Blatt in diesem Zweig.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Formatiere den Software‑Stamm über das erste Blatt in diesem Stamm.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout beeinflusst die Elternbeschriftungen bei Treemap; Sunburst verwendet Ringsegmente.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

Die Kategoriezellen und Wertzellen verwenden dieselbe Tabellenzeile, sodass ihre Sammlungspositionen ausgerichtet bleiben. Wenn Sie mit einem bestehenden Diagramm arbeiten, anstatt eines neuen zu erstellen, prüfen Sie zunächst die Kategorierows und speichern Sie benannte Verweise auf die Datenpunkte und Ebenen, die Sie formatieren möchten.

## **Verhalten und praktische Überlegungen**

### **Unterschiede zwischen Treemap und Sunburst**

- Ein Treemap verwendet Fläche, um einen Wert zu kommunizieren, und verschachtelte Rechtecke, um die Hierarchie darzustellen. Die [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/parent_label_layout/)‑Eigenschaft steuert, wie übergeordnete Beschriftungen in diesem Diagrammtyp erscheinen.
- Ein Sunburst verwendet Winkel, um einen Wert zu kommunizieren, und Ringtiefe, um die Hierarchie darzustellen. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/parent_label_layout/) steuert nicht die Ringbeschriftungen.
- Beide Diagrammtypen nutzen dieselben Kategoriegruppierungsebenen und dieselbe Blatt‑zu‑Eltern‑Reihenfolge in `data_point_levels`, sodass der Code zum Aufbau der Daten und zur Ebenenformatierung gemeinsam genutzt werden kann.
- Elternwerte werden aus ihren nachgeordneten Blättern berechnet. Fügen Sie keine separaten numerischen Punkte für Zweige oder Stämme hinzu.

### **Sortierung und Segmentreihenfolge**

Die Diagrammlayout‑Engine bestimmt die endgültige Platzierung von Rechtecken und Ringsegmenten. Ordnen Sie zusammengehörige Kategorierows vor dem Hinzufügen, verlassen Sie sich jedoch nicht auf eine bestimmte Rechteckposition oder Startwinkel. Wenn die Reihenfolge eine Bedeutung hat, integrieren Sie sie in die Beschriftungen oder verwenden Sie einen Diagrammtyp mit einer expliziten Kategorienachse.

### **Design und feste Farben**

Unformatierte Diagrammebenen erben Farben aus dem Präsentationsdesign. Das Beispiel verwendet explizite RGB‑Füllungen für vorhersagbare Ergebnisse. Wenn das Diagramm Designänderungen folgen soll, verwenden Sie Scheme‑Farben anstelle fester RGB‑Werte und vermeiden Sie das Überschreiben jeder Ebene. Prüfen Sie außerdem den Beschriftungskontrast, nachdem Sie die Füllung eines Zweigs oder Stammes geändert haben.

### **Beschriftungen und verfügbarer Platz**

PowerPoint kann Beschriftungen ausblenden oder abschneiden, wenn ein Segment zu klein ist. Das Vergrößern des Diagramms, Kürzen von Kategorienamen oder das Anzeigen weniger Beschriftungsfelder führt in der Regel zu einem klareren Ergebnis. Eine Beschriftung kann den Kategorienamen, den Seriennamen und den Wert über [DataLabelFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datalabelformat/) kombinieren, doch das Aktivieren aller Felder erschwert häufig das Ablesen hierarchischer Diagramme.

### **Export und Rendering**

Das Speichern als PPTX hält das Diagramm bearbeitbar. Wenn Aspose.Slides die Präsentation in PDF oder ein Bild rendert, werden die unterstützten Füllungen und Beschriftungseinstellungen mit dem Diagramm gerendert. Schriftarten‑Substitution und kleine Unterschiede im verfügbaren Layout‑Platz können Zeilenumbrüche oder Beschriftungs­sichtbarkeit ändern, also installieren Sie die erforderlichen Schriften und prüfen Sie wichtige Exportziele.

## **FAQ**

**Warum wirkt sich das Ändern einer übergeordneten Ebene auf mehrere Blätter aus?**

Ein Zweig oder Stamm ist ein gemeinsam genutztes visuelles Segment. Sein [ChartDataPointLevel](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatapointlevel/) kann über ein nachgeordnetes Blatt erreicht werden, doch die Formatierung gehört zum gemeinsamen Elternsegment und nicht nur zu diesem Blatt.

**Warum fehlt eine Datenbeschriftung?**

Aktivieren Sie zunächst die erforderlichen Felder im [DataLabelFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datalabelformat/)‑Objekt der Beschriftung. Prüfen Sie dann, ob das Segment ausreichend Platz bietet. Das Treemap‑Parent‑Label‑Layout, die Diagrammgröße, Beschriftungslänge, Schriftgröße und die Anzahl aktivierter Felder beeinflussen, ob eine Beschriftung angezeigt werden kann.

**Kann ich die genaue Reihenfolge oder Koordinaten von Segmenten festlegen?**

Sie können die Reihenfolge der Quell‑Rows steuern und jede Gruppe zusammenhängend halten, aber Sie können keine exakten Treemap‑Rechtecke oder Sunburst‑Winkel zuweisen. Die Diagrammlayout‑Engine berechnet sie aus der Hierarchie, den Werten und dem verfügbaren Platz.

**Warum ändern sich die Farben, wenn das Präsentationsdesign geändert wird?**

Designbasierte Füllungen folgen der Präsentationspalette. Verwenden Sie explizite RGB‑Farben für Ebenen, die fix bleiben müssen, oder behalten Sie Scheme‑Farben bei, wenn eine Anpassung an ein neues Design gewünscht ist.

**Wird die benutzerdefinierte Formatierung bei PDF- und Bildexporten beibehalten?**

Ja, unterstützte Diagrammfills und Beschriftungseinstellungen werden beim Rendering berücksichtigt. Für konsistente Ergebnisse stellen Sie die erforderlichen Schriften bereit und testen die endgültige Exportgröße, da die Beschriftungs­anpassung vom Layout abhängt.

## **Siehe auch**

- [Treemap‑Diagramme erstellen](/slides/de/python-net/create-chart/#create-tree-map-charts)
- [Sunburst‑Diagramme erstellen](/slides/de/python-net/create-chart/#create-sunburst-charts)
- [Export von Präsentations‑Diagrammen](/slides/de/python-net/export-chart/)
- [Verwalten von Präsentationsdesigns](/slides/de/python-net/presentation-theme/)