---
title: Datenpunkte in Treemap- und Sunburst-Diagrammen in Java anpassen
linktitle: Datenpunkte in Treemap- und Sunburst-Diagrammen
type: docs
url: /de/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap-Diagramm
- Sunburst-Diagramm
- hierarchisches Diagramm
- Datenpunkt
- Datenbeschriftung
- Zweigfarbe
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie hierarchische Daten erstellen und Ebenen, Beschriftungen und Farben in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für Java anpassen."
---
## **Übersicht**

Treemap‑ und Sunburst‑Diagramme zeigen dieselbe Art von hierarchischen Daten, verwenden jedoch unterschiedliche Layouts. Ein Treemap stellt die Hierarchie als verschachtelte Rechtecke dar, deren Flächen die Werte der Blattknoten repräsentieren. Ein Sunburst stellt sie als konzentrische Ringe dar: Gruppen der obersten Ebene liegen nahe dem Zentrum, Blattkategorien am äußeren Ring.

In Aspose.Slides for Java ist jeder numerische Wert ein [IChartDataPoint](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/). Seine [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--)‑Methode liefert Zugriff auf das Blatt und seine übergeordneten Gruppen. Dieser Artikel erklärt diese Zuordnung und zeigt, wie beide Diagrammtypen aus denselben Beispieldaten erstellt und formatiert werden.

![Ein Treemap‑Diagramm mit den Zweigen Consumer und Business](treemap-hierarchy.png)

![Ein Sunburst‑Diagramm mit derselben Consumer‑ und Business‑Hierarchie](sunburst-hierarchy.png)

## **Kategorien, Datenpunkte und Ebenen verstehen**

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

Jede Zeile erzeugt eine Blattkategorie und einen Datenpunkt. Die Kategorie‑Gruppierungsebenen beschreiben den Pfad von diesem Blatt zu seinen Eltern. Für die erste Zeile lautet der Pfad `Consumer > Computers > Laptops`.

Die von [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) zurückgegebenen Indizes laufen vom Blatt nach oben:

| `getDataPointLevels()` Index | Logische Ebene | Treemap‑Darstellung | Sunburst‑Darstellung |
| ---: | --- | --- | --- |
| `0` | Blatt | Werte‑Rechteck | Segment des Außenrings |
| `1` | Stamm | Eltern‑Rechteck oder -Header | Segment des Mittelrings |
| `2` | Zweig | Rechteck oder Header der obersten Ebene | Segment des Innenrings |

Diese Reihenfolge ist für beide Diagrammtypen identisch, obwohl sich ihre visuellen Layouts unterscheiden. Ein übergeordnetes Segment wird von mehreren Blättern gemeinsam genutzt. Um es zu formatieren, verwenden Sie die entsprechende Ebene des ersten Datenpunkts in dieser Gruppe. Beispielsweise beginnt der `Consumer`‑Zweig mit dem Punkt `Laptops`, während der `Software`‑Stamm mit dem Punkt `Licenses` beginnt. Das Beibehalten von Referenzen auf diese Punkte ist klarer und sicherer als die Verwendung undefinierter Ausdrücke wie `dataPoints.get_Item(0)` oder `dataPoints.get_Item(6)`.

## **Beide Diagrammtypen erstellen und anpassen**

Das folgende vollständige Beispiel erzeugt ein Treemap auf der ersten Folie und ein Sunburst auf der zweiten Folie. Es baut die Hierarchie auf, zeigt den Wert für `Tablets`, wendet feste Farben auf ausgewählte Ebenen an, formatiert ein Zweig‑Label und speichert die Präsentation.

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

        // Add the leaf categories. A grouping item is set only when a new group begins;
        // the following categories remain in that group until another item is set.
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

        // Show the category and value on the Tablets leaf.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Format the Consumer branch through the first leaf in that branch.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Format the Software stem through the first leaf in that stem.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout affects Treemap parent labels; Sunburst uses ring segments.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Kategoriezellen und Wertzellen verwenden dieselbe Tabellenzeile, sodass ihre Sammlungspositionen ausgerichtet bleiben. Wenn Sie mit einem vorhandenen Diagramm arbeiten, statt eines neuen zu erstellen, prüfen Sie zuerst die Kategorierows und speichern Sie benannte Referenzen zu den Datenpunkten und Ebenen, die Sie formatieren möchten.

## **Verhalten und praktische Überlegungen**

### **Unterschiede zwischen Treemap und Sunburst**

- Ein Treemap verwendet Fläche, um den Wert zu kommunizieren, und verschachtelte Rechtecke, um die Hierarchie darzustellen. Die [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-)‑Methode steuert, wie übergeordnete Labels in diesem Diagrammtyp erscheinen.
- Ein Sunburst verwendet Winkel, um den Wert zu kommunizieren, und Ringtiefe, um die Hierarchie darzustellen. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) beeinflusst seine Ring‑Labels nicht.
- Beide Diagrammtypen nutzen dieselben Kategorie‑Gruppierungsebenen und dieselbe Blatt‑zu‑Eltern‑Reihenfolge, die von [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) zurückgegeben wird, sodass der Code zum Aufbau der Daten und zur Ebenen‑Formatierung gemeinsam verwendet werden kann.
- Elternwerte werden aus ihren nachgelagerten Blättern berechnet. Fügen Sie keine separaten numerischen Punkte für Zweige oder Stämme hinzu.

### **Sortierung und Segmentreihenfolge**

Die Diagrammlayout‑Engine bestimmt die endgültige Platzierung von Rechtecken und Ringsegmenten. Ordnen Sie verwandte Kategorierows zusammen, bevor Sie sie hinzufügen, verlassen Sie sich jedoch nicht auf eine bestimmte Rechteckposition oder Startwinkel. Wenn die Reihenfolge Bedeutung hat, integrieren Sie sie in die Labels oder verwenden Sie einen Diagrammtyp mit einer expliziten Kategorienachse.

### **Design und feste Farben**

Nicht formatierte Diagrammebenen erben Farben aus dem Präsentationsdesign. Das Beispiel verwendet explizite RGB‑Füllungen für vorhersehbare Ergebnisse. Wenn das Diagramm Design‑Änderungen folgen soll, verwenden Sie Schema‑Farben anstelle fester RGB‑Werte und vermeiden Sie das Überschreiben jeder Ebene. Prüfen Sie zudem den Label‑Kontrast, nachdem Sie eine Zweig‑ oder Stamm‑Füllung geändert haben.

### **Beschriftungen und verfügbarer Platz**

PowerPoint kann Labels ausblenden oder abschneiden, wenn ein Segment zu klein ist. Das Vergrößern des Diagramms, das Kürzen von Kategorienamen oder das Anzeigen weniger Label‑Felder führt meist zu einem klareren Ergebnis. Ein Label kann den Kategorienamen, Seriennamen und Wert über [IDataLabelFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/idatalabelformat/) kombinieren, aber das Aktivieren jedes Feldes erschwert häufig das Lesen hierarchischer Diagramme.

### **Export und Rendering**

Das Speichern im PPTX‑Format hält das Diagramm editierbar. Wenn Aspose.Slides die Präsentation in PDF oder ein Bild rendert, werden die unterstützten Füllungen und Label‑Einstellungen mit dem Diagramm gerendert. Schriftart‑Ersetzung und kleine Unterschiede im verfügbaren Layout‑Platz können Zeilenumbrüche oder Label‑Sichtbarkeit ändern, daher sollten die erforderlichen Schriftarten installiert und wichtige Export‑Ziele überprüft werden.

## **FAQ**

**Warum wirkt sich das Ändern einer übergeordneten Ebene auf mehrere Blätter aus?**  
Ein Zweig oder Stamm ist ein gemeinsam genutztes visuelles Segment. Sein [IChartDataPointLevel](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapointlevel/) ist über ein nachgelagertes Blatt erreichbar, aber die Formatierung gehört zum gemeinsamen übergeordneten Segment und nicht nur zu diesem Blatt.

**Warum fehlt ein Datenlabel?**  
Aktivieren Sie zuerst die gewünschten Felder im [IDataLabelFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/idatalabelformat/)-Objekt des Labels. Prüfen Sie dann, ob das Segment ausreichend Platz bietet. Treemap‑Eltern‑Label‑Layout, Diagrammgröße, Label‑Länge, Schriftgröße und die Anzahl aktivierter Felder beeinflussen, ob ein Label angezeigt werden kann.

**Kann ich die genaue Reihenfolge oder Koordinaten der Segmente festlegen?**  
Sie können die Reihenfolge der Quell‑Zeilen steuern und jede Gruppe zusammenhängend halten, aber Sie können keine exakten Treemap‑Rechtecke oder Sunburst‑Winkel zuweisen. Die Diagrammlayout‑Engine berechnet sie aus Hierarchie, Werten und verfügbarem Platz.

**Warum ändern sich Farben, wenn das Präsentations‑Design wechselt?**  
Design‑basierte Füllungen folgen der Präsentations‑Palette. Verwenden Sie explizite RGB‑Farben für Ebenen, die unverändert bleiben sollen, oder behalten Sie Schema‑Farben bei, wenn die Anpassung an ein neues Design gewünscht ist.

**Werden benutzerdefinierte Formatierungen in PDF‑ und Bild‑Exporten beibehalten?**  
Ja, unterstützte Diagramm‑Füllungen und Label‑Einstellungen werden beim Rendern übernommen. Für konsistente Ergebnisse stellen Sie die erforderlichen Schriftarten bereit und testen Sie die endgültige Export‑Größe, da das Anpassen von Labels layoutsensitiv ist.

## **Siehe auch**

- [Create Treemap charts](/slides/de/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/de/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/de/java/export-chart/)
- [Manage presentation themes](/slides/de/java/presentation-theme/)