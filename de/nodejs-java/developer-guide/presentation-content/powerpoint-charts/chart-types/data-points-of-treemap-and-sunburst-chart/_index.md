---
title: "Anpassen von Datenpunkten in Treemap- und Sunburst-Diagrammen mit JavaScript"
linktitle: "Datenpunkte in Treemap- und Sunburst-Diagrammen"
type: docs
url: /de/nodejs-java/data-points-of-treemap-and-sunburst-chart/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie hierarchische Daten erstellen und Ebenen, Beschriftungen und Farben in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für Node.js über Java anpassen."
---
## **Übersicht**

Treemap- und Sunburst-Diagramme zeigen dieselbe Art hierarchischer Daten an, verwenden jedoch unterschiedliche Layouts. Ein Treemap stellt die Hierarchie als verschachtelte Rechtecke dar, deren Flächen die Blattwerte repräsentieren. Ein Sunburst stellt sie als konzentrische Ringe dar: Oberste Gruppen befinden sich in der Nähe des Zentrums, und Blattkategorien liegen auf dem Außenring.

In Aspose.Slides für Node.js über Java stellt jeder numerische Wert ein [ChartDataPoint](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatapoint/). Seine [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels)‑Methode ermöglicht den Zugriff auf das Blatt und seine übergeordneten Gruppen. Dieser Artikel erklärt diese Zuordnung und zeigt, wie beide Diagrammtypen aus denselben Beispieldaten erstellt und formatiert werden können.

![Ein Treemap-Diagramm mit den Zweigen Consumer und Business](treemap-hierarchy.png)

![Ein Sunburst-Diagramm mit derselben Consumer- und Business-Hierarchie](sunburst-hierarchy.png)

## **Verstehen von Kategorien, Datenpunkten und Ebenen**

Das unten verwendete Beispiel hat drei Kategorieebenen und eine numerische Serie:

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

Jede Zeile erzeugt eine Blattkategorie und einen Datenpunkt. Die Gruppierungsebenen der Kategorien beschreiben den Pfad von diesem Blatt zu seinen übergeordneten Elementen. Für die erste Zeile ist der Pfad `Consumer > Computers > Laptops`.

Die von [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) zurückgegebenen Indizes laufen vom Blatt aufwärts:

| Index (`getDataPointLevels()`) | Logische Ebene | Treemap-Darstellung | Sunburst-Darstellung |
| ---: | --- | --- | --- |
| `0` | Blatt | Wertrechteck | Außenringsegment |
| `1` | Stamm | Elternrechteck oder -überschrift | Mittelringsegment |
| `2` | Zweig | Oberste Rechteck oder Überschrift | Innenringsegment |

Diese Reihenfolge ist für beide Diagrammtypen gleich, obwohl sich ihre visuellen Layouts unterscheiden. Ein übergeordnetes Segment wird von mehreren Blättern gemeinsam genutzt. Um es zu formatieren, verwenden Sie die entsprechende Ebene des ersten Datenpunkts in dieser Gruppe. Zum Beispiel beginnt der `Consumer`‑Zweig mit dem `Laptops`‑Punkt, während der `Software`‑Stamm mit dem `Licenses`‑Punkt beginnt. Verweise auf diese Punkte zu behalten ist klarer und sicherer, als ungeklärte Ausdrücke wie `dataPoints.get_Item(0)` oder `dataPoints.get_Item(6)` zu verwenden.

## **Erstellen und Anpassen beider Diagrammtypen**

Das folgende vollständige Beispiel erstellt ein Treemap auf der ersten Folie und ein Sunburst auf der zweiten Folie. Es baut die Hierarchie auf, zeigt den Wert für `Tablets` an, wendet feste Farben auf ausgewählte Ebenen an, formatiert ein Zweig‑Label und speichert die Präsentation.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Fügen Sie die Blattkategorien hinzu. Ein Gruppierungselement wird nur gesetzt, wenn eine neue Gruppe beginnt;
        // die folgenden Kategorien bleiben in dieser Gruppe, bis ein weiteres Element gesetzt wird.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Zeige die Kategorie und den Wert im Blatt Tablets an.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formatiere den Consumer‑Zweig über das erste Blatt in diesem Zweig.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Formatiere den Software‑Stamm über das erste Blatt in diesem Stamm.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout beeinflusst die übergeordneten Beschriftungen bei Treemap; Sunburst verwendet Ringsegmente.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Zellen für Kategorien und Werte verwenden dieselbe Arbeitsblattzeile, sodass ihre Sammelpositionen ausgerichtet bleiben. Wenn Sie mit einem bestehenden Diagramm arbeiten, anstatt eines zu erstellen, prüfen Sie zunächst die Kategorierreihen und speichern Sie benannte Verweise auf die Datenpunkte und Ebenen, die Sie formatieren möchten.

## **Verhalten und praktische Überlegungen**

### **Unterschiede zwischen Treemap und Sunburst**

- Ein Treemap verwendet die Fläche, um den Wert zu vermitteln, und verschachtelte Rechtecke, um die Hierarchie darzustellen. Die [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout)‑Methode steuert, wie übergeordnete Beschriftungen in diesem Diagrammtyp angezeigt werden.
- Ein Sunburst verwendet den Winkel, um den Wert zu vermitteln, und die Ringtiefe, um die Hierarchie darzustellen. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) steuert nicht die Ringbeschriftungen.
- Beide Diagrammtypen verwenden dieselben Kategorie‑Gruppierungsebenen und dieselbe Blatt‑zu‑Eltern‑Reihenfolge, die von [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) zurückgegeben wird, sodass der Code zum Erstellen der Daten und zum Formatieren der Ebenen gemeinsam genutzt werden kann.
- Übergeordnete Werte werden aus ihren nachgelagerten Blättern berechnet. Fügen Sie keine separaten numerischen Punkte für Zweige oder Stämme hinzu.

### **Sortierung und Segmentreihenfolge**

Die Layout‑Engine des Diagramms bestimmt die endgültige Platzierung von Rechtecken und Ringsegmenten. Ordnen Sie verwandte Kategorierreihen zusammen, bevor Sie sie hinzufügen, aber verlassen Sie sich nicht auf eine bestimmte Rechteckposition oder einen Startwinkel. Wenn die Reihenfolge eine Bedeutung hat, integrieren Sie sie in die Beschriftungen oder verwenden Sie einen Diagrammtyp mit einer expliziten Kategorienachse.

### **Thema und feste Farben**

Unformatierte Diagrammebenen übernehmen Farben aus dem Präsentationsthema. Das Beispiel verwendet explizite RGB‑Füllungen für vorhersehbare Ergebnisse. Wenn das Diagramm Theme‑Änderungen folgen soll, verwenden Sie Farbschemas anstelle fester RGB‑Werte und vermeiden Sie das Überschreiben jeder Ebene. Überprüfen Sie zudem den Kontrast der Beschriftungen, nachdem Sie die Füllung eines Zweigs oder Stamms geändert haben.

### **Beschriftungen und verfügbarer Platz**

PowerPoint kann Beschriftungen ausblenden oder abschneiden, wenn ein Segment zu klein ist. Die Vergrößerung des Diagramms, das Kürzen von Kategorienamen oder das Anzeigen weniger Beschriftungsfelder führt in der Regel zu einem klareren Ergebnis. Eine Beschriftung kann den Kategorienamen, den Seriennamen und den Wert über [DataLabelFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/datalabelformat/) kombinieren, aber das Aktivieren aller Felder macht hierarchische Diagramme oft schwer lesbar.

### **Export und Rendering**

Das Speichern im PPTX-Format hält das Diagramm editierbar. Wenn Aspose.Slides die Präsentation zu PDF oder einem Bild rendert, werden die unterstützten Füllungen und Beschriftungseinstellungen zusammen mit dem Diagramm gerendert. Schriftartersetzungen und kleine Unterschiede im verfügbaren Layout‑Raum können Zeilenumbrüche oder die Sichtbarkeit von Beschriftungen ändern, daher sollten die erforderlichen Schriftarten installiert und wichtige Exportziele überprüft werden.

## **FAQ**

**Warum wirkt sich das Ändern einer übergeordneten Ebene auf mehrere Blätter aus?**

Ein Zweig oder Stamm ist ein gemeinsam genutztes visuelles Segment. Sein [ChartDataPointLevel](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chartdatapointlevel/) kann über ein nachgelagertes Blatt erreicht werden, aber die Formatierung gehört zum gemeinsamen übergeordneten Segment und nicht nur zu diesem Blatt.

**Warum fehlt ein Datenbeschriftung?**

Aktivieren Sie zunächst die erforderlichen Felder im [DataLabelFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/datalabelformat/)‑Objekt der Beschriftung. Überprüfen Sie dann, ob das Segment genügend Platz hat. Das Treemap‑Parent‑Label‑Layout, die Diagrammgröße, die Beschriftungslänge, die Schriftgröße und die Anzahl aktivierter Felder beeinflussen alle, ob eine Beschriftung angezeigt werden kann.

**Kann ich die genaue Reihenfolge oder Koordinaten von Segmenten festlegen?**

Sie können die Reihenfolge der Quellzeilen steuern und jede Gruppe zusammenhängend halten, aber Sie können keine genauen Treemap‑Rechtecke oder Sunburst‑Winkel zuweisen. Die Layout‑Engine des Diagramms berechnet sie aus der Hierarchie, den Werten und dem verfügbaren Raum.

**Warum ändern sich Farben, nachdem das Präsentationsthema geändert wurde?**

Theme‑basierte Füllungen sind dafür vorgesehen, der Präsentationspalette zu folgen. Verwenden Sie explizite RGB‑Farben für die Ebenen, die fest bleiben sollen, oder behalten Sie Farbschemas bei, wenn das Anpassen an ein neues Theme bevorzugt wird.

**Wird benutzerdefinierte Formatierung bei PDF‑ und Bildexporten beibehalten?**

Ja, unterstützte Diagrammfüllungen und Beschriftungseinstellungen werden beim Rendern berücksichtigt. Für konsistente Ergebnisse auf verschiedenen Systemen stellen Sie die erforderlichen Schriftarten bereit und testen Sie die endgültige Exportgröße, da die Anpassung der Beschriftung vom Layout abhängt.

## **Siehe auch**

- [Treemap-Diagramme erstellen](/slides/de/nodejs-java/create-chart/#creating-tree-map-charts)
- [Sunburst-Diagramme erstellen](/slides/de/nodejs-java/create-chart/#creating-sunburst-charts)
- [Präsentationsdiagramme exportieren](/slides/de/nodejs-java/export-chart/)
- [Präsentationsthemen verwalten](/slides/de/nodejs-java/presentation-theme/)