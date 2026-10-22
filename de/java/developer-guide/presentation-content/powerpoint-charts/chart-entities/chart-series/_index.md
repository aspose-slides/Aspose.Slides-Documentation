---
title: Diagrammdatenserien in Präsentationen mit Java verwalten
linktitle: Datenserien
type: docs
url: /de/java/chart-series/
keywords:
- Diagrammserien
- Serienüberlappung
- Serienfarbe
- Serienname
- Datenpunkt
- Arbeitsmappenzelle
- Serienlücke
- negativer Wert
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien, Datenpunkte, Arbeitsmappenzellen, Formatierungen, Überlappungen, Abstandsbreiten und negative Werte in Präsentationen mit Java verwalten."
---
## **Übersicht**

Ein Diagramm kann seine geplotteten Werte in Arbeitsmappenzellen speichern oder direkt als numerische Literale. Ein [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) stellt einen Satz zusammengehöriger Werte dar, und jeder [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) stellt einen Punkt in dieser Serie dar. [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/)‑Objekte liefern die Beschriftungen oder Gruppierungswerte, die von den Serien gemeinsam genutzt werden. In Diagrammen, die mit Standarddaten erstellt wurden, verwenden Seriennamen, Kategorien und Punktewerte [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/)‑Objekte aus der Diagramm‑Arbeitsmappe.

Bei einem typischen Kategoriediagramm verwendet die Standardarbeitsmappe Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die übrigen Zellen für Serienwerte. Arbeitsblatt‑, Zeilen‑ und Spaltenindizes, die an [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) übergeben werden, sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber Sie sollten nicht davon ausgehen, dass jedes vorhandene Diagramm es verwendet. Bei einer geladenen Präsentation sollten Sie die von den Serien, Kategorien und Datenpunkten referenzierten Zellen prüfen, bevor Sie Arbeitsmappenwerte ändern.

Diagrammeinstellungen haben drei verschiedene Geltungsbereiche:

- Einstellungen auf Serienebene, wie [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--), stellen das Standardaussehen für alle Punkte einer Serie bereit.
- Einstellungen für Datenpunkte, wie [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--), überschreiben das Serienaussehen für einen einzelnen Punkt.
- Gruppeneinstellungen gelten für kompatible Serien, die zur selben [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) gehören. Greifen Sie über [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Abstandsbreite festlegen müssen.

Wenn kein expliziter Punkt‑ oder Serien‑Füllstil festgelegt ist, bestimmen der Diagrammstil und das Design das automatische Erscheinungsbild. Wenn sowohl Serien‑ als auch Punktformatierungen vorhanden sind, hat die Punktformatierung für diesen Punkt Vorrang.

![Diagramm-Serien-Powerpoint](chart-series-powerpoint.png)

## **Serienwerte mithilfe numerischer Literale festlegen**

Verwenden Sie numerische Literale, wenn Serienwerte aus Anwendungsdaten oder Berechnungen stammen und keine Arbeitsblattzellenreferenzen benötigen. Rufen Sie [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) mit [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) auf, bevor Sie das Ergebnis von [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) jedes Punktes über [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-) zuweisen.

Die Sammlungs‑Einstellung steuert den Quelltyp aller Punktwerte in dieser Serie. Die Methode [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) jedes Punktwerts gibt den ausgewählten Typ zurück; ändern Sie ihn über die Sammlungs‑Einstellung. Bei `Worksheet` verwenden Sie [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) , um auf die referenzierte Zelle zuzugreifen. Bei `DoubleLiterals` verwenden Sie [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) oder `setAsLiteralDouble`, um die Zahl direkt zu lesen oder zu schreiben.

Das folgende Beispiel erstellt ein Säulendiagramm mit Standardserien und -kategorien und weist dann berechnete Werte von 10, 20 usw. den vorhandenen Punkten der ersten Serie zu. Es speichert die Präsentation, öffnet sie erneut und gibt die gespeicherten Werte aus.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Der Quelltyp des Punktwerts ist getrennt von [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--), das die interne oder externe Arbeitsmappen‑Konfiguration des Diagramms identifiziert. Die Verwendung numerischer Literale entfernt die eingebettete Arbeitsmappe nicht automatisch. In diesem Beispiel bleibt die Arbeitsmappe für Kategorienbeschriftungen, Seriennamen und die anderen Serien verfügbar. Siehe [Diagramm‑Arbeitsmappe](/slides/de/java/chart-workbook/) für die Verwaltung der Arbeitsmappe.

Für Streu‑ und Blasendiagramme verwenden Sie [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) und [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-), um die Quellen für [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) bzw. [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--) auszuwählen. Blasendiagramme verwenden zudem [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) für [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--). Setzen Sie jede entsprechende Quelle auf `DoubleLiterals`, bevor Sie Zahlen über die `setAsLiteralDouble`‑Methode des jeweiligen Werts zuweisen.

## **Diagramm-Serien-Überlappung festlegen**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) gibt an, wie stark Balken oder Säulen in einem 2D‑Diagramm überlappen, von -100 bis 100 Prozent. Es stellt eine schreibgeschützte Projektion der Einstellung der übergeordneten Seriengruppe dar. Verwenden Sie [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-), um jede kompatible Serie in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen darstellen; sie beeinflusst keine unverbundenen Seriengruppen in einem Kombinationsdiagramm.

Das folgende Beispiel setzt die Überlappung für die Gruppe, die die erste Serie enthält:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Das neue Diagramm enthält Beispielserien, Kategorien und Werte.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Die Serien-Überlappung](series_overlap.png)

## **Serien-Füllfarbe ändern**

Verwenden Sie [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) , um die Standardfüllung für eine gesamte Serie festzulegen. Hat ein Punkt bereits eine explizite Füllung, überschreibt dessen [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)‑Einstellung die Serienfüllung für diesen Punkt.

Das folgende Beispiel wendet eine durchgehend blaue Füllung auf die erste Serie an:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Die Farbe der Serie](series_color.png)

## **Seriennamen ändern**

Ein Serienname wird in der Diagramm‑Datenarbeitsmappe gespeichert und normalerweise in der Legende angezeigt. In der Standardarbeitsmappe, die für ein gruppiertes Säulendiagramm erstellt wird, befindet sich die Zelle B1 in Zeile 0, Spalte 1 und enthält den Namen der ersten Serie. Die benannten Konstanten im folgenden Beispiel machen diese Struktur explizit:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sie können auch die bereits von [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) referenzierte Zelle aktualisieren. Dieser Ansatz vermeidet Annahmen über eine bestimmte Zeile und Spalte in einem bestehenden Diagramm:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Der Serienname](series_name.png)

### **Eine Serie mit einem Namen aus mehreren Zellen erstellen**

Ein zusammengesetzter Serienname ist nützlich, wenn ein Produktname und ein Berichtszeitraum in separaten Arbeitsmappenzellen gespeichert sind. Zum Beispiel können Sie `Product A` in B1 und `2026` in C1 zu einem einzigen Seriennamen kombinieren, wobei beide Teile mit ihren Quellzellen verknüpft bleiben.

Verwenden Sie [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-), um den Namensbereich abzurufen, und übergeben Sie diese Sammlung dann an [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Das Argument `skipHiddenCells` steuert, ob versteckte Zellen einbezogen werden: `true` schließt sie aus, `false` schließt sie ein. Dieses Beispiel verwendet `false`, um jede Zelle im Namensbereich einzuschließen.

Das folgende Beispiel erstellt eine Präsentation mit einer Serie und zwei Datenpunkten. Zellen B1:C1 liefern nur den Seriennamen; A2:A3 liefern die Kategorienamen, und B2:B3 liefern die numerischen Werte.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Diese beiden Zellen liefern den Seriennamen.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // Separate Zellen liefern die Kategorien und numerischen Datenpunkte.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der resultierende Serienname ist `Product A 2026`, mit einem Leerzeichen zwischen den beiden Zellwerten. Die Legende zeigt dies als einen Eintrag für beide Spalten. Das Bild unten illustriert das Ergebnis:

![Säulendiagramm mit Nord- und Südwerten und dem zusammengesetzten Seriennamen Product A 2026 in der Legende](composite_series_name.png)

## **Automatische Serien-Füllfarbe ermitteln**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) gibt die aus dem Serienindex und dem Diagrammstil berechnete Farbe zurück. Dies ist die Farbe, die verwendet wird, wenn die Serienfüllung nicht explizit definiert wurde. Der Aufruf der Methode liest die berechnete Farbe; sie weist keine neue Füllung zu.

Das folgende Beispiel gibt die automatische Farbe jeder Standardserie aus:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Die genauen Farben hängen vom Diagrammstil und -design ab.

## **Invertierte Füllfarbe für eine Diagrammserie festlegen**

Für Balken‑, Säulen‑ und Blasensereien kann [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negative Werte mit einer anderen Füllung darstellen. Setzen Sie die reguläre Serienfüllung auf fest, aktivieren Sie die Invertierung und weisen Sie die Farbe für negative Werte über [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) zu. Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur ihre Anzeigefarbe ändert sich.

Das folgende Beispiel ersetzt die Standarddiagrammdaten durch eine Serie. Zeile 0 des Arbeitsblatts enthält den Seriennamen, Spalte 0 enthält die Kategorienamen, und Spalte 1 enthält die Werte:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Die invertierte feste Füllfarbe](inverted_solid_fill_color.png)

Sie können die Invertierung für einen einzelnen Punkt über [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) aktivieren. Im folgenden Beispiel ist die Invertierung für die Serie deaktiviert und nur für den ausgewählten Punkt aktiviert. Der Punkt erhält außerdem einen negativen Wert, damit der Effekt sichtbar ist:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Einen bestimmten Datenpunktwert löschen**

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie die zugehörige Arbeitsmappen‑Zelle auf `null`. Für ein Säulendiagramm ist der geplottete Wert über [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) abrufbar. Der Datenpunkt bleibt an derselben Kategorienposition, aber das Diagramm behandelt seinen Wert als leer gemäß den Diagrammeinstellungen für leere Werte.

Das folgende Beispiel löscht nur den zweiten Punkt in der ersten Serie:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Streu‑Diagramme verwenden separate X‑ und Y‑Zellen, und Blasen‑Diagramme verwenden zusätzlich eine Größenzelle. Löschen Sie nur die Zelle, die den zu entfernenden Wert repräsentiert. Rufen Sie nicht [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) auf, wenn Sie die anderen Punkte behalten möchten, da diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Anzeige leerer Zellen steuern**

Versteckte Zellen, die Werte enthalten, sind ein anderer Fall als leere Zellen. Um Daten aus versteckten Arbeitsblattzeilen und -spalten einzuschließen oder auszuschließen, siehe [Daten aus versteckten Zeilen und Spalten einbeziehen](/slides/de/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Eine leere Arbeitsmappen‑Zelle stellt fehlende Daten dar; eine Zelle mit `0` stellt einen bekannten numerischen Wert dar. Rufen Sie [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) mit `null` auf, um eine Zelle leer zu machen. Eine numerische Null bleibt eine Null, unabhängig von der Einstellung für leere Zellen.

Verwenden Sie [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-), um zu wählen, wie das Diagramm leere Zellen darstellt. Diese Einstellung gilt für das gesamte Diagramm. Sie ändert die Darstellung von Lücken, ohne die leere Arbeitsmappen‑Zelle mit Null oder einem interpolierten Wert zu füllen.

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit einer Serie, löscht den Wert für Tag 3 und speichert dasselbe Diagramm in jedem Modus. Es wird keine Eingabedatei benötigt. Das [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) verwendet Arbeitsblatt 0, Spalte 0 für Kategorienamen und Spalte 1 für Werte; Zeile 0 enthält den Seriennamen. Die endgültigen Daten sind `10, 20, empty, 30, 40`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Tag 3 wirklich leer lassen, dabei die Kategorie und den Datenpunkt erhalten behalten.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Jede Ausgabedatei speichert den vor dem Speichern zugewiesenen Modus: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` und `empty_cells_Span.pptx`. Um nur eine Version zu speichern, weisen Sie den gewünschten Modus zu und speichern die Präsentation einmalig statt über die Modi zu iterieren.

Der Vergleich unten zeigt dieselben Daten in allen drei Dateien. Tag 3 ist in der Arbeitsmappe in jedem Fall leer:

![Liniendiagramme mit identischen Daten: Gap trennt die Linie an Tag 3, Zero lässt die Linie auf Null fallen, und Span verbindet Tag 2 mit Tag 4.](display_blanks_as.png)

Der sichtbare Effekt hängt vom Diagrammtyp ab. Ein Liniendiagramm macht alle drei Modi leicht vergleichbar. Balken‑ und Säulendiagramme haben keine Linie, die über eine fehlende Kategorie hinweg verbindet, sodass `Span` nicht das im Bild gezeigte Verbindungselement erzeugen kann; ein fehlender Balken und ein Balken mit Höhe 0 können ebenfalls ähnlich aussehen. Ebenso hat ein Streudiagramm mit nur Markern keine Verbindungslinie. Erwarten Sie nicht für jeden Diagrammtyp drei unterschiedliche Ergebnisse; prüfen Sie die Ausgabe für den von Ihnen verwendeten Typ.

## **Abstandsbbreite der Serie festlegen**

Die Abstandsbbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen‑Klustern, ausgedrückt als Prozentsatz der Balken‑ bzw. Säulenbreite. Wie die Überlappung gehört sie zur übergeordneten Seriengruppe und nicht zu einer einzelnen Serie. Rufen Sie einmal [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) für die Gruppe auf. Ein größerer Wert erzeugt mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

Das folgende Beispiel ändert die Abstandsbbreite und speichert nur die endgültige Präsentation:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Die Abstandsbbreite](gap_width.png)

## **FAQ**

**Welche Diagrammtypen unterstützen Datenserien?**  
Alle Diagrammtypen, die durch die [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)‑Aufzählung dargestellt werden, verwenden Diagrammdaten, aber ihre Serien besitzen nicht alle dieselbe Werte‑Struktur oder dieselben Einstellungen. Beispielsweise verwenden Kategoriediagramme Kategorien und Werte, Streudiagramme X‑ und Y‑Werte und Blasendiagramme zusätzlich Blasengrößen. Verwenden Sie die Datenpunkt‑Erstellungsmethode, die dem Seri­entyp entspricht. Optionen wie Überlappung und Abstandsbbreite gelten nur für kompatible Balken‑ oder Säulengruppen.

**Was ist eine Diagramm‑Serien‑Gruppe?**  
Eine [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) enthält kompatible Serien, die gruppenweite Plot‑Einstellungen teilen. Ein Kombinationsdiagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der Gruppe über eine Serie nicht zwangsläufig alle Serien im Diagramm ändert.

**Enthält ein neu erstelltes Diagramm Standarddaten?**  
Ja. Standardmäßig erzeugt [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) Beispielserien, -kategorien und -werte. Sie können diese Zellen bearbeiten oder sowohl die Serien‑ als auch die Kategorien‑Sammlungen leeren, bevor Sie einen komplett benutzerdefinierten Datensatz hinzufügen. Eine Überladung kann außerdem ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagramm‑Objekte mit Arbeitsmappen‑Zellen verbunden?**  
Seriennamen, Kategorienbeschriftungen und Datenpunktwerte referenzieren Zellen in einer [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagrammelement. Beim Erstellen benutzerdefinierter Daten sollten Sie die Zeilen für Kategorien und die Zeilen für Serienwerte ausrichten, sodass jeder Punkt unter der gewünschten Kategorie geplottet wird.

**Wie lösche ich einen Punkt anstatt der gesamten Serie?**  
Setzen Sie die betreffende Wert‑Zelle auf `null`, um die Position des Punkts als leeren Punkt zu behalten. Verwenden Sie [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) nur, wenn Sie alle Punkte dieser Serie entfernen möchten. Entfernen Sie außerdem nicht die Kategorien, ohne die übrigen Serien anzupassen, damit Werte und Kategorien weiterhin übereinstimmen.

**Wie werden leere Punkte dargestellt?**  
Das Ergebnis hängt vom Diagrammtyp und der über [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) konfigurierten Einstellung ab. Unterstützte Diagramme können Lücken als Leerstellen, als Nullwerte oder durch das Verbinden benachbarter Punkte darstellen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht. Siehe [Anzeige leerer Zellen steuern](#control-the-display-of-empty-cells) für ein vollständiges Beispiel und einen visuellen Vergleich.

**Wie werden negative Werte formatiert?**  
Für unterstützte Balken‑, Säulen‑ und Blasensereien rufen Sie [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) auf und setzen die Farbe, die über [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) zurückgegeben wird. Sie können das Verhalten für einen einzelnen Punkt mit [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) überschreiben. Diese Methoden beeinflussen die Formatierung, nicht die gespeicherten numerischen Werte.

**Welche Formatierung hat Vorrang, wenn sowohl eine Serie als auch ein Punkt formatiert sind?**  
Explizite Datenpunkt‑Formatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin das explizite Serienformat oder, wenn das Serienformat nicht definiert ist, den automatischen Diagrammstil und das Design. Gruppeneinstellungen wie Überlappung und Abstandsbbreite steuern das Layout und sind keine Punkt‑Formatierungs‑Überschreibungen.

**Gibt es ein Limit für die Anzahl von Serien in einem Diagramm?**  
Aspose.Slides legt kein separates festes Serien‑Zähl‑Limit fest. In der Praxis bestimmen Dateigrößen‑Beschränkungen, verfügbarer Speicher, Renderzeit und die Lesbarkeit des Diagramms ein sinnvolles Limit.

**Was sollte ich ändern, wenn Spalten zu eng oder zu weit auseinander liegen?**  
Rufen Sie [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) auf der entsprechenden übergeordneten Seriengruppe auf. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzubringen.