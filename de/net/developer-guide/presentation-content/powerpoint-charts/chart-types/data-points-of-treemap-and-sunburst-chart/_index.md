---
title: "Anpassen von Datenpunkten in Treemap- und Sunburst-Diagrammen in .NET"
linktitle: "Datenpunkte in Treemap- und Sunburst-Diagrammen"
type: docs
url: /de/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap-Diagramm
- Sunburst-Diagramm
- hierarchisches Diagramm
- Datenpunkt
- Datenbeschriftung
- Zweigfarbe
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie hierarchische Daten erstellen und Ebenen, Beschriftungen und Farben in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für .NET anpassen."
---
## **Übersicht**

Treemap- und Sunburst-Diagramme stellen dieselben hierarchischen Daten dar, verwenden jedoch unterschiedliche Layouts. Ein Treemap zeichnet die Hierarchie als verschachtelte Rechtecke, deren Flächen die Blattwerte darstellen. Ein Sunburst stellt sie als konzentrische Ringe dar: Gruppen der obersten Ebene befinden sich nahe der Mitte, und Blattkategorien liegen auf dem äußeren Ring.

In Aspose.Slides for .NET ist jeder numerische Wert ein [IChartDataPoint](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatapoint/). Seine [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatapoint/datapointlevels/)‑Sammlung bietet Zugriff auf das Blatt und seine übergeordneten Gruppen. Dieser Artikel erklärt diese Zuordnung und zeigt, wie beide Diagrammtypen aus denselben Beispieldaten erstellt und formatiert werden können.

![Ein Treemap-Diagramm mit den Zweigen Consumer und Business](treemap-hierarchy.png)

![Ein Sunburst-Diagramm mit derselben Consumer- und Business-Hierarchie](sunburst-hierarchy.png)

## **Verstehen von Kategorien, Datenpunkten und Ebenen**

Das unten verwendete Beispiel enthält drei Kategorisierungsebenen und eine numerische Serie:

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

Jede Zeile erzeugt eine Blattkategorie und einen Datenpunkt. Die Kategorisierungs‑Ebenen beschreiben den Pfad von diesem Blatt zu seinen Eltern. Für die erste Zeile lautet der Pfad `Consumer > Computers > Laptops`.

Die Indizes in [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) laufen vom Blatt aufwärts:

| `DataPointLevels`‑Index | Logische Ebene | Treemap‑Darstellung | Sunburst‑Darstellung |
| ---: | --- | --- | --- |
| `0` | Blatt | Wertrechteck | Äußerer Ringabschnitt |
| `1` | Stamm | Elternrechteck oder -überschrift | Mittlerer Ringabschnitt |
| `2` | Zweig | Rechteck oder Überschrift der obersten Ebene | Innerer Ringabschnitt |

Diese Reihenfolge ist für beide Diagrammtypen gleich, obwohl ihre visuellen Layouts unterschiedlich sind. Ein Elternsegment wird von mehreren Blättern gemeinsam genutzt. Um es zu formatieren, verwenden Sie die entsprechende Ebene des ersten Datenpunkts in dieser Gruppe. Beispielsweise beginnt der `Consumer`‑Zweig mit dem `Laptops`‑Punkt, während der `Software`‑Stamm mit dem `Licenses`‑Punkt beginnt. Das Beibehalten von Referenzen zu diesen Punkten ist klarer und sicherer als die Verwendung unerklärter Ausdrücke wie `dataPoints[0]` oder `dataPoints[6]`.

## **Erstellen und Anpassen beider Diagrammtypen**

Das folgende vollständige Beispiel erstellt ein Treemap auf der ersten Folie und ein Sunburst auf der zweiten Folie. Es baut die Hierarchie auf, zeigt den Wert für `Tablets` an, wendet feste Farben auf ausgewählte Ebenen an, formatiert eine Zweig‑Beschriftung und speichert die Präsentation.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // Fügen Sie die Blattkategorien hinzu. Ein Gruppierungselement wird nur gesetzt, wenn eine neue Gruppe beginnt;
    // Die folgenden Kategorien bleiben in dieser Gruppe, bis ein weiteres Element gesetzt wird.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // Zeigen Sie die Kategorie und den Wert im Blatt „Tablets“ an.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Formatieren Sie den Consumer‑Zweig über das erste Blatt in diesem Zweig.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Formatieren Sie den Software‑Stamm über das erste Blatt in diesem Stamm.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout beeinflusst die Elternbeschriftungen bei Treemap; Sunburst verwendet Ringsegmente.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

Die Kategorienzellen und Wertzellen verwenden dieselbe Arbeitsblattzeile, sodass ihre Sammlungspositionen ausgerichtet bleiben. Wenn Sie mit einem vorhandenen Diagramm arbeiten, anstatt eines zu erstellen, prüfen Sie zuerst die Kategoriezellen und speichern Sie benannte Referenzen zu den Datenpunkten und Ebenen, die Sie formatieren möchten.

## **Verhalten und praktische Überlegungen**

### **Treemap- und Sunburst‑Unterschiede**

- Ein Treemap verwendet Fläche, um den Wert zu vermitteln, und verschachtelte Rechtecke, um die Hierarchie zu zeigen. Die [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseries/parentlabellayout/)‑Eigenschaft steuert, wie Eltern‑Beschriftungen in diesem Diagrammtyp erscheinen.
- Ein Sunburst verwendet Winkel, um den Wert zu vermitteln, und Ringtiefe, um die Hierarchie zu zeigen. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartseries/parentlabellayout/) steuert seine Ring‑Beschriftungen nicht.
- Beide Diagrammtypen verwenden dieselben Kategorisierungs‑Ebenen und dieselbe Blatt‑zu‑Eltern‑Reihenfolge in `DataPointLevels`, sodass der Code zum Aufbau der Daten und zur Ebenen‑Formatierung gemeinsam genutzt werden kann.
- Elternwerte werden aus ihren nachfolgenden Blättern berechnet. Fügen Sie keine separaten numerischen Punkte für Zweige oder Stämme hinzu.

### **Sortierung und Segmentreihenfolge**

Die Diagramm‑Layout‑Engine bestimmt die endgültige Platzierung von Rechtecken und Ringsegmenten. Ordnen Sie verwandte Kategoriezellen zusammen, bevor Sie sie hinzufügen, aber verlassen Sie sich nicht auf eine bestimmte Rechtecksposition oder Startwinkel. Wenn die Reihenfolge Bedeutung hat, integrieren Sie sie in die Beschriftungen oder verwenden Sie einen Diagrammtyp mit einer expliziten Kategorien‑Achse.

### **Thema und feste Farben**

Nicht formatierte Diagramm‑Ebenen erben Farben aus dem Präsentationsthema. Das Beispiel verwendet explizite RGB‑Füllungen für vorhersehbare Ergebnisse. Wenn das Diagramm Themenänderungen folgen soll, verwenden Sie Schemata‑Farben anstelle fester RGB‑Werte und vermeiden Sie das Überschreiben jeder Ebene. Überprüfen Sie zudem den Beschriftungs‑Kontrast, nachdem Sie die Füllung eines Zweigs oder Stammes geändert haben.

### **Beschriftungen und verfügbarer Platz**

PowerPoint kann Beschriftungen ausblenden oder abschneiden, wenn ein Segment zu klein ist. Das Vergrößern des Diagramms, Kürzen von Kategorienamen oder Anzeigen weniger Beschriftungsfelder führt in der Regel zu einem klareren Ergebnis. Eine Beschriftung kann den Kategorienamen, den Seriennamen und den Wert über [IDataLabelFormat](https://reference.aspose.com/slides/de/net/aspose.slides.charts/idatalabelformat/) kombinieren, aber das Aktivieren jedes Felds macht hierarchische Diagramme oft schwer lesbar.

### **Export und Rendering**

Das Speichern im PPTX‑Format hält das Diagramm editierbar. Wenn Aspose.Slides die Präsentation zu PDF oder einem Bild rendert, werden die unterstützten Füllungen und Beschriftungseinstellungen mit dem Diagramm gerendert. Schriftarten­ersatz und kleine Unterschiede im verfügbaren Layout‑Platz können Zeilenumbrüche oder die Sichtbarkeit von Beschriftungen ändern; installieren Sie daher die benötigten Schriftarten und prüfen Sie wichtige Export‑Ziele.

## **FAQ**

**Warum wirkt sich das Ändern einer übergeordneten Ebene auf mehrere Blätter aus?**

Ein Zweig oder Stamm ist ein gemeinsam genutztes visuelles Segment. Sein [IChartDataPointLevel](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichartdatapointlevel/) kann über ein nachgelagertes Blatt erreicht werden, aber die Formatierung gehört zum gemeinsamen Elternsegment und nicht nur zu diesem Blatt.

**Warum fehlt ein Datenbeschriftung?**

Aktivieren Sie zunächst die erforderlichen Felder im [IDataLabelFormat](https://reference.aspose.com/slides/de/net/aspose.slides.charts/idatalabelformat/)-Objekt der Beschriftung. Prüfen Sie dann, ob das Segment ausreichend Platz hat. Treemap‑Eltern‑Beschriftungs‑Layout, Diagrammgröße, Beschriftungslänge, Schriftgröße und die Anzahl aktivierter Felder beeinflussen, ob eine Beschriftung angezeigt werden kann.

**Kann ich die genaue Reihenfolge oder Koordinaten von Segmenten festlegen?**

Sie können die Reihenfolge der Quell‑Zeilen steuern und jede Gruppe zusammenhängend halten, aber Sie können keine exakten Treemap‑Rechtecke oder Sunburst‑Winkel zuweisen. Die Layout‑Engine berechnet sie aus der Hierarchie, den Werten und dem verfügbaren Platz.

**Warum ändern sich die Farben, nachdem das Präsentationsthema geändert wurde?**

Themenbasierte Füllungen folgen der Präsentationspalette. Verwenden Sie explizite RGB‑Farben für Ebenen, die fest bleiben müssen, oder behalten Sie Schemata‑Farben bei, wenn die Anpassung an ein neues Thema bevorzugt wird.

**Wird benutzerdefinierte Formatierung bei PDF- und Bildexporten beibehalten?**

Ja, unterstützte Diagramm‑Füllungen und Beschriftungseinstellungen werden beim Rendern berücksichtigt. Für konsistente Ergebnisse über Systeme hinweg stellen Sie die erforderlichen Schriftarten bereit und testen die finale Exportgröße, da das Beschriftungs‑Fit‑Verhalten vom Layout abhängt.

## **Siehe auch**

- [Treemap‑Diagramme erstellen](/slides/de/net/create-chart/#create-tree-map-charts)
- [Sunburst‑Diagramme erstellen](/slides/de/net/create-chart/#create-sunburst-charts)
- [Präsentations‑Diagramme exportieren](/slides/de/net/export-chart/)
- [Präsentationsthemen verwalten](/slides/de/net/presentation-theme/)