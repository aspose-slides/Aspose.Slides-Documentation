---
title: Verwalten von Diagrammdatenserien in Präsentationen mit Java
linktitle: Datenserien
type: docs
url: /de/java/chart-series/
keywords:
- Diagrammserie
- Serienüberlappung
- Serienfarbe
- Serienname
- Datenpunkt
- Arbeitsmappenzelle
- Serienlücke
- Negativer Wert
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien, Datenpunkte, Arbeitsmappenzellen, Formatierung, Überlappung, Lückenbreite und negative Werte in Präsentationen mit Java verwalten."
---
## **Übersicht**

Ein Diagramm speichert seine geplotteten Daten in einer Diagrammdaten‑Arbeitsmappe. Ein [IChartSeries](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/) repräsentiert einen Satz zusammenhängender Werte, und jeder [IChartDataPoint](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/) in der Serie bezieht sich auf eine oder mehrere Zellen der Arbeitsmappe. [IChartCategory](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartcategory/)‑Objekte liefern die Beschriftungen oder Gruppierungswerte, die von den Serien gemeinsam genutzt werden. Der Serienname, die Kategorien und die Punktwerte sind daher mit [IChartDataCell](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatacell/)-Objekten verknüpft und werden nicht nur als Anzeigetext gespeichert.

Für ein typisches Kategorien‑Diagramm verwendet die Standard‑Arbeitsmappe Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die übrigen Zellen für Serienwerte. Arbeitsblatt‑, Zeilen‑ und Spaltenindizes, die an [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) übergeben werden, sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber Sie sollten nicht davon ausgehen, dass jedes vorhandene Diagramm es verwendet. Bei einer geladenen Präsentation sollten Sie die von den Serien, Kategorien und Datenpunkten referenzierten Zellen prüfen, bevor Sie Arbeitsmappendaten ändern.

Diagrammeinstellungen haben drei verschiedene Ebenen:

- Einstellungen auf Serien‑Ebene, wie [IChartSeries.getFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getFormat--), stellen das Standard‑Aussehen aller Punkte einer Serie bereit.
- Einstellungen auf Datenpunkt‑Ebene, wie [IChartDataPoint.getFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/#getFormat--), überschreiben das Serien‑Aussehen für einen einzelnen Punkt.
- Gruppeneinstellungen gelten für kompatible Serien, die zur selben [IChartSeriesGroup](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseriesgroup/). Greifen Sie auf die Gruppe über [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) zu, wenn Sie Optionen wie Überlappung oder Lückenbreite festlegen müssen.

Wenn kein expliziter Punkt‑ oder Serien‑Füllwert festgelegt ist, bestimmen der Diagrammstil und das Theme das automatische Erscheinungsbild. Wenn sowohl Serien‑ als auch Punktformatierung vorhanden sind, hat die Punktformatierung für diesen Punkt Vorrang.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Überlappung der Diagrammserie festlegen**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getOverlap--) berichtet, wie stark Balken oder Säulen in einem 2D‑Diagramm überlappen, von -100 bis 100 Prozent. Es ist eine schreibgeschützte Projektion der Einstellung in der übergeordneten Seriengruppe. Verwenden Sie [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-), um die Überlappung aller kompatiblen Serien in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen anzeigen; sie beeinflusst nicht nicht verwandte Seriengruppen in einem Kombinationsdiagramm.

Das folgende Beispiel legt die Überlappung für die Gruppe fest, die die erste Serie enthält:

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

Das Ergebnis:

![The series overlap](series_overlap.png)

## **Serien‑Füllfarbe ändern**

Verwenden Sie [IChartSeries.getFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getFormat--) um die Standard‑Füllung für eine gesamte Serie festzulegen. Hat ein Punkt bereits eine explizite Füllung, überschreibt seine [IChartDataPoint.getFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/#getFormat--)‑Einstellung die Serien‑Füllung für diesen Punkt.

Das folgende Beispiel wendet eine einheitliche blaue Füllung auf die erste Serie an:

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

Das Ergebnis:

![The color of the series](series_color.png)

## **Serienname ändern**

Ein Serienname wird in der Diagrammdaten‑Arbeitsmappe gespeichert und normalerweise in der Legende angezeigt. In der Standard‑Arbeitsmappe, die für ein gruppiertes Säulendiagramm erstellt wird, befindet sich Zelle B1 in Zeile 0, Spalte 1 und enthält den Namen der ersten Serie. Die benannten Konstanten im folgenden Beispiel machen diese Struktur explizit:

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

Sie können außerdem die bereits von [IChartSeries.getName](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getName--) referenzierte Zelle aktualisieren. Dieser Ansatz vermeidet Annahmen über eine bestimmte Zeile und Spalte in einem vorhandenen Diagramm:

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

Das Ergebnis:

![The series name](series_name.png)

## **Automatische Serien‑Füllfarbe abrufen**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) gibt die Farbe zurück, die aus dem Serien‑Index und dem Diagrammstil berechnet wird. Dies ist die Farbe, die verwendet wird, wenn die Serien‑Füllung nicht explizit definiert ist. Der Aufruf der Methode liest die berechnete Farbe; er weist keine neue Füllung zu.

Das folgende Beispiel gibt die automatische Farbe jeder Standard‑Serie aus:

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

Beispielausgabe für den Standard‑Diagrammstil:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Die genauen Farben hängen vom Diagrammstil und Theme ab.

## **Invertierte Füllfarbe für eine Diagrammserie festlegen**

Für Balken‑, Säulen‑ und Blasendiagramm‑Serien kann [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negative Werte mit einer anderen Füllung anzeigen. Setzen Sie die reguläre Serien‑Füllung auf einfarbig, aktivieren Sie die Invertierung und bestimmen Sie die Farbe für negative Werte über [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur ihre Anzeigefarbe ändert sich.

Das folgende Beispiel ersetzt die Standard‑Diagrammdaten durch eine Serie. Arbeitsblatt‑Zeile 0 enthält den Seriennamen, Spalte 0 enthält die Kategorienamen und Spalte 1 enthält die Werte:

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

Das Ergebnis:

![The inverted solid fill color](inverted_solid_fill_color.png)

Sie können die Invertierung für einen Punkt über [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) aktivieren. Im folgenden Beispiel ist die Invertierung für die Serie deaktiviert und nur für den ausgewählten Punkt aktiviert. Dem Punkt wird zudem ein negativer Wert zugewiesen, damit der Effekt sichtbar wird:

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

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie die zugehörige Arbeitsmappen‑Zelle auf `null`. Für ein Säulendiagramm ist der geplottete Wert über [IChartDataPoint.getValue](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/#getValue--) verfügbar. Der Datenpunkt bleibt an derselben Kategorieposition, aber das Diagramm behandelt seinen Wert als leer gemäß den Leere‑Wert‑Einstellungen des Diagramms.

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

Scatter‑Diagramme verwenden separate X‑ und Y‑Zellen, und Blasendiagramme benutzen zusätzlich eine Größen‑Zelle. Löschen Sie nur die Zelle, die den zu entfernenden Wert darstellt. Rufen Sie nicht [IChartDataPointCollection.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapointcollection/#clear--) auf, wenn Sie die anderen Punkte behalten möchten, da diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Anzeige leerer Zellen steuern**

Eine leere Arbeitsmappen‑Zelle steht für fehlende Daten; eine Zelle mit `0` steht für einen bekannten numerischen Wert. Rufen Sie [IChartDataCell.setValue](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) mit `null` auf, um eine Zelle leer zu machen. Eine numerische Null bleibt eine Null, unabhängig von der Einstellung für leere Zellen.

Verwenden Sie [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-), um zu wählen, wie das Diagramm leere Zellen darstellt. Diese Einstellung gilt für das gesamte Diagramm. Sie ändert, wie Leereinträge geplottet werden, ohne die leere Arbeitsmappen‑Zelle mit Null oder einem interpolierten Wert zu füllen.

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit einer Serie, löscht den Wert für Tag 3 und speichert dasselbe Diagramm in jedem Modus. Keine Eingabedatei ist erforderlich. Der [IChartDataWorkbook](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdataworkbook/) verwendet Arbeitsblatt 0, Spalte 0 für Kategorienamen und Spalte 1 für Werte; Zeile 0 enthält den Seriennamen. Die Enddaten sind `10, 20, empty, 30, 40`.

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

    // Lassen Sie Tag 3 wirklich leer, während Sie seine Kategorie und den Datenpunkt beibehalten.
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

Jede Ausgabedatei speichert den vor dem Speichern zugewiesenen Modus: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` und `empty_cells_Span.pptx`. Um nur eine Version zu speichern, weisen Sie den gewünschten Modus zu und speichern die Präsentation einmal, anstatt über die Modi zu iterieren.

Der Vergleich unten zeigt dieselben Daten in allen drei Dateien. Tag 3 ist in der Arbeitsmappe in jedem Fall leer:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Die sichtbare Wirkung hängt vom Diagrammtyp ab. Ein Liniendiagramm macht alle drei Modi leicht vergleichbar. Balken‑ und Säulendiagramme haben keine Linie, die über eine fehlende Kategorie hinweg verbindet, sodass `Span` nicht das oben gezeigte verbindende Segment erzeugen kann; eine fehlende Säule und eine Säule mit Höhe Null können ebenfalls ähnlich aussehen. Ebenso hat ein Scatter‑Diagramm mit nur Markern keine verbindende Linie. Erwartet nicht drei unterschiedliche Ergebnisse für jeden Diagrammtyp; prüft die Ausgabe für den von euch genutzten Typ.

## **Lückenbreite der Serie festlegen**

Lückenbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, ausgedrückt als Prozentsatz der Balken‑ oder Säulenbreite. Wie die Überlappung gehört sie zur übergeordneten Seriengruppe und nicht zu einer einzelnen Serie. Rufen Sie [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) einmal für die Gruppe auf. Ein größerer Wert erzeugt mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

Das folgende Beispiel ändert die Lückenbreite und speichert nur die finale Präsentation:

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

Das Ergebnis:

![The gap width](gap_width.png)

## **FAQ**

**Welche Diagrammtypen unterstützen Datenserien?**

Alle Diagrammtypen, die durch die Aufzählung [ChartType](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/) repräsentiert werden, verwenden Diagrammdaten, jedoch haben ihre Serien nicht alle dieselbe Werte‑Struktur oder Einstellungen. Zum Beispiel verwenden Kategorien‑Diagramme Kategorien und Werte, Streudiagramme X‑ und Y‑Werte, und Blasendiagramme zusätzlich Blasengrößen. Verwenden Sie die Datenpunkt‑Erstellungsmethode, die dem Serientyp entspricht. Optionen wie Überlappung und Lückenbreite gelten nur für kompatible Balken‑ oder Säulengruppen.

**Was ist eine Diagramm‑Serien‑Gruppe?**

Eine [IChartSeriesGroup](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseriesgroup/) enthält kompatible Serien, die gruppen‑weite Plot‑Einstellungen teilen. Ein Kombinationsdiagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der Gruppe, die über eine Serie erreicht wird, nicht notwendigerweise jede Serie im Diagramm verändert.

**Enthält ein neu erstelltes Diagramm Standarddaten?**

Ja. Standardmäßig erstellt [IShapeCollection.addChart](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) Beispiel‑Serien, Kategorien und Werte. Sie können diese Zellen bearbeiten oder sowohl die Serien‑ als auch die Kategorien‑Sammlungen leeren, bevor Sie einen komplett benutzerdefinierten Datensatz hinzufügen. Eine Überladung kann ebenfalls ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagrammobjekte mit Arbeitsmappenzellen verknüpft?**

Seriennamen, Kategorien‑Beschriftungen und Datenpunkt‑Werte referenzieren Zellen in einem [IChartDataWorkbook](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagrammelement. Wenn Sie benutzerdefinierte Daten erstellen, halten Sie Kategorie‑Zeilen und Serien‑Wert‑Zeilen ausgerichtet, sodass jeder Punkt unter der vorgesehenen Kategorie geplottet wird.

**Wie lösche ich einen einzelnen Punkt anstelle der gesamten Serie?**

Setzen Sie die betreffende Werte‑Zelle auf `null`, um die Kategorie‑Position des Punktes als leeren Punkt beizubehalten. Verwenden Sie [IChartDataPointCollection.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapointcollection/#clear--) nur, wenn Sie alle Punkte dieser Serie entfernen möchten. Wenn Sie außerdem Kategorien entfernen, aktualisieren Sie jede Serie, damit ihre Werte mit der Kategorien‑Sammlung ausgerichtet bleiben.

**Wie werden leere Punkte angezeigt?**

Das Ergebnis hängt vom Diagrammtyp und der über [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) konfigurierten Einstellung ab. Unterstützte Diagramme können Leereinträge als Lücken, als Null‑Werte oder durch Verbinden benachbarter Punkte darstellen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht. Siehe „Anzeige leerer Zellen steuern“ für ein vollständiges Beispiel und visuellen Vergleich.

**Wie werden negative Werte formatiert?**

Für unterstützte Balken‑, Säulen‑ und Blasendiagramm‑Serien rufen Sie [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) auf und setzen die Farbe, die von [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) zurückgegeben wird. Sie können das Verhalten für einen einzelnen Punkt mit [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) überschreiben. Diese Methoden beeinflussen die Formatierung, nicht die gespeicherten numerischen Werte.

**Welche Formatierung gewinnt, wenn sowohl eine Serie als auch ein Punkt formatiert sind?**

Explizite Datenpunkt‑Formatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin das explizite Serien‑Format oder, wenn das Serien‑Format nicht definiert ist, den automatischen Diagrammstil und das Theme. Gruppeneinstellungen wie Überlappung und Lückenbreite steuern das Layout und sind keine Punkt‑Level‑Formatierungs‑Überschreibungen.

**Gibt es ein Limit, wie viele Serien ein Diagramm enthalten kann?**

Aspose.Slides legt kein separates festes Serien‑Zahl‑Limit fest. In der Praxis bestimmen Rahmenbedingungen der Präsentationsdatei, verfügbarer Speicher, Render‑Zeit und Lesbarkeit des Diagramms ein sinnvolles Limit.

**Was sollte ich ändern, wenn Säulen zu nahe beieinander oder zu weit auseinander liegen?**

Rufen Sie [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) auf der entsprechenden übergeordneten Seriengruppe auf. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzubringen.