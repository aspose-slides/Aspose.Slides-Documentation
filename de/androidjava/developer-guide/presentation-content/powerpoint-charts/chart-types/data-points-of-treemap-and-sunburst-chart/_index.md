---
title: Anpassen von Datenpunkten in Treemap- und Sunburst-Diagrammen auf Android
linktitle: Datenpunkte in Treemap- und Sunburst-Diagrammen
type: docs
url: /de/androidjava/data-points-of-treemap-and-sunburst-chart/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie hierarchische Daten erstellen und Ebenen, Beschriftungen und Farben in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für Android via Java anpassen."
---
## **Übersicht**

Treemap- und Sunburst-Diagramme zeigen dieselbe Art von hierarchischen Daten an, verwenden jedoch unterschiedliche Layouts. Ein Treemap zeichnet die Hierarchie als verschachtelte Rechtecke, deren Flächen die Blattwerte darstellen. Ein Sunburst stellt sie als konzentrische Ringe dar: Oberste Gruppen befinden sich in der Nähe des Zentrums, und Blattkategorien liegen auf dem Außenring.

In Aspose.Slides for Android via Java ist jeder numerische Wert ein [IChartDataPoint](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/). Seine [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--)‑Methode bietet Zugriff auf das Blatt und seine übergeordneten Gruppen. Dieser Artikel erklärt diese Zuordnung und zeigt, wie beide Diagrammtypen aus denselben Beispieldaten erstellt und formatiert werden können.

![Ein Treemap-Diagramm mit den Zweigen Consumer und Business](treemap-hierarchy.png)

![Ein Sunburst-Diagramm mit derselben Consumer- und Business-Hierarchie](sunburst-hierarchy.png)

## **Kategorien, Datenpunkte und Ebenen verstehen**

Das nachfolgende Beispiel enthält drei Kategorieebenen und eine numerische Reihe:

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

Jede Zeile erzeugt eine Blattkategorie und einen Datenpunkt. Die Gruppierungsebenen der Kategorie beschreiben den Pfad von diesem Blatt zu seinen übergeordneten Elementen. Für die erste Zeile ist der Pfad `Consumer > Computers > Laptops`.

Die von [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) zurückgegebenen Indizes laufen vom Blatt nach oben:

| `getDataPointLevels()` index | Logische Ebene | Treemap-Darstellung | Sunburst-Darstellung |
| ---: | --- | --- | --- |
| `0` | Blatt | Value rectangle | Outer-ring segment |
| `1` | Stamm | Parent rectangle or header | Middle-ring segment |
| `2` | Zweig | Top-level rectangle or header | Inner-ring segment |

Diese Reihenfolge ist für beide Diagrammtypen identisch, obwohl ihre visuellen Layouts unterschiedlich sind. Ein übergeordnetes Segment wird von mehreren Blättern gemeinsam genutzt. Um es zu formatieren, verwenden Sie die entsprechende Ebene des ersten Datenpunkts in dieser Gruppe. Beispielsweise beginnt der `Consumer`‑Zweig mit dem `Laptops`‑Punkt, während der `Software`‑Stamm mit dem `Licenses`‑Punkt beginnt. Das Beibehalten von Verweisen auf diese Punkte ist klarer und sicherer als die Verwendung unerklärter Ausdrücke wie `dataPoints.get_Item(0)` oder `dataPoints.get_Item(6)`.

## **Beide Diagrammtypen erstellen und anpassen**

Das folgende vollständige Beispiel erstellt ein Treemap auf der ersten Folie und ein Sunburst auf der zweiten Folie. Es baut die Hierarchie auf, zeigt den Wert für `Tablets` an, wendet feste Farben auf ausgewählte Ebenen an, formatiert ein Zweig‑Label und speichert die Präsentation.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Fügen Sie die Blattkategorien hinzu. Ein Gruppierungselement wird nur gesetzt, wenn eine neue Gruppe beginnt;
        // die folgenden Kategorien verbleiben in dieser Gruppe, bis ein weiteres Element gesetzt wird.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Zeigen Sie die Kategorie und den Wert im Blatt Tablets an.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formatieren Sie den Consumer‑Zweig über das erste Blatt in diesem Zweig.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Formatieren Sie den Software‑Stamm über das erste Blatt in diesem Stamm.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout beeinflusst Treemap‑Elternbeschriftungen; Sunburst verwendet Ringsegmente.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Kategorie‑Zellen und Werte‑Zellen verwenden dieselbe Arbeitsblatt‑Zeile, sodass ihre Sammlungs‑Positionen ausgerichtet bleiben. Wenn Sie mit einem bereits vorhandenen Diagramm arbeiten, statt eines neuen zu erstellen, prüfen Sie zuerst die Kategorie‑Zeilen und speichern Sie benannte Verweise auf die Datenpunkte und Ebenen, die Sie formatieren möchten.

## **Verhalten und praktische Überlegungen**

### **Unterschiede zwischen Treemap und Sunburst**

- Ein Treemap verwendet Fläche, um den Wert zu vermitteln, und verschachtelte Rechtecke, um die Hierarchie darzustellen. Die [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-)‑Methode steuert, wie Eltern‑Labels in diesem Diagrammtyp angezeigt werden.
- Ein Sunburst verwendet Winkel, um den Wert zu vermitteln, und Ringtiefe, um die Hierarchie darzustellen. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) steuert seine Ring‑Labels nicht.
- Beide Diagrammtypen benutzen dieselben Kategorie‑Gruppierungsebenen und dieselbe Blatt‑zu‑Eltern‑Reihenfolge, die von [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) zurückgegeben wird, sodass der Code zum Aufbau der Daten und zur Ebenen‑Formatierung gemeinsam genutzt werden kann.
- Elternwerte werden aus den nachfolgenden Blättern berechnet. Fügen Sie keine separaten numerischen Punkte für Zweige oder Stämme hinzu.

### **Sortieren und Segmentreihenfolge**

Die Layout‑Engine des Diagramms bestimmt die endgültige Platzierung von Rechtecken und Ringsegmenten. Ordnen Sie zusammengehörige Kategorie‑Zeilen vor dem Hinzufügen, verlassen Sie sich jedoch nicht auf eine bestimmte Rechteck‑Position oder Start‑Winkel. Wenn die Reihenfolge eine Bedeutung hat, integrieren Sie sie in die Labels oder verwenden Sie einen Diagrammtyp mit einer expliziten Kategorien‑Achse.

### **Design und feste Farben**

Nicht formatierte Diagramm‑Ebenen erben Farben aus dem Präsentations‑Design. Das Beispiel verwendet explizite RGB‑Füllungen für vorhersehbare Ausgaben. Wenn das Diagramm Design‑Änderungen folgen soll, verwenden Sie Design‑Farben anstelle fester RGB‑Werte und überschreiben Sie nicht jede Ebene. Prüfen Sie außerdem den Label‑Kontrast, nachdem Sie die Füllung eines Zweigs oder Stamms geändert haben.

### **Beschriftungen und verfügbarer Raum**

PowerPoint kann Labels ausblenden oder abschneiden, wenn ein Segment zu klein ist. Das Vergrößern des Diagramms, das Kürzen von Kategorienamen oder das Anzeigen weniger Label‑Felder führt meist zu einem klareren Ergebnis. Ein Label kann den Kategorienamen, den Seriennamen und den Wert über [IDataLabelFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabelformat/) kombinieren, aber das Aktivieren aller Felder erschwert häufig das Lesen hierarchischer Diagramme.

### **Export und Rendering**

Das Speichern als PPTX hält das Diagramm editierbar. Wenn Aspose.Slides die Präsentation zu PDF oder einem Bild rendert, werden die unterstützten Füllungen und Label‑Einstellungen mit dem Diagramm gerendert. Schriftarten‑Ersetzung und kleine Unterschiede im verfügbaren Layout‑Raum können Zeilen‑Umbruch oder Label‑Sichtbarkeit ändern; stellen Sie daher die erforderlichen Schriften bereit und prüfen Sie wichtige Export‑Ziele.

## **FAQ**

**Warum wirkt sich das Ändern einer übergeordneten Ebene auf mehrere Blätter aus?**

Ein Zweig oder Stamm ist ein gemeinsam genutztes visuelles Segment. Sein [IChartDataPointLevel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapointlevel/) kann über ein nachgelagertes Blatt erreicht werden, aber die Formatierung gehört zum gemeinsamen übergeordneten Segment und nicht nur zu diesem Blatt.

**Warum fehlt ein Datenlabel?**

Aktivieren Sie zunächst die gewünschten Felder auf dem [IDataLabelFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabelformat/)‑Objekt des Labels. Prüfen Sie dann, ob das Segment genug Platz hat. Treemap‑Eltern‑Label‑Layout, Diagrammgröße, Label‑Länge, Schriftgröße und die Anzahl aktivierter Felder beeinflussen, ob ein Label angezeigt werden kann.

**Kann ich die exakte Reihenfolge oder die Koordinaten von Segmenten festlegen?**

Sie können die Reihenfolge der Quell‑Zeilen steuern und jede Gruppe zusammenhängend halten, aber Sie können keine genauen Treemap‑Rechtecke oder Sunburst‑Winkel zuweisen. Die Layout‑Engine berechnet sie aus der Hierarchie, den Werten und dem verfügbaren Raum.

**Warum ändern sich die Farben, nachdem das Präsentationsdesign geändert wurde?**

Design‑basierte Füllungen folgen der Präsentations‑Palette. Verwenden Sie explizite RGB‑Farben für Ebenen, die unverändert bleiben sollen, oder behalten Sie Design‑Farben bei, wenn die Anpassung an ein neues Design gewünscht ist.

**Wird benutzerdefinierte Formatierung bei PDF- und Bildexporten beibehalten?**

Ja, unterstützte Diagramm‑Füllungen und Label‑Einstellungen werden beim Rendern einbezogen. Für konsistente Ergebnisse stellen Sie die erforderlichen Schriftarten bereit und testen die endgültige Export‑Größe, da das Anpassen von Labels layoutsensitiv ist.

## **Siehe auch**

- [Treemap-Diagramme erstellen](/slides/de/androidjava/create-chart/#create-tree-map-charts)
- [Sunburst-Diagramme erstellen](/slides/de/androidjava/create-chart/#create-sunburst-charts)
- [Präsentationsdiagramme exportieren](/slides/de/androidjava/export-chart/)
- [Präsentationsdesigns verwalten](/slides/de/androidjava/presentation-theme/)