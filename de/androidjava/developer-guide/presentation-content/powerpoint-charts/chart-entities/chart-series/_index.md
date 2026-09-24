---
title: Verwalten von Diagrammdatenserien in Präsentationen auf Android
linktitle: Datenserien
type: docs
url: /de/androidjava/chart-series/
keywords:
- Diagrammserie
- Serienüberlappung
- Serienfarbe
- Serienname
- Datenpunkt
- Arbeitsmappenzelle
- Serienlücke
- Negativwert
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien, Datenpunkte, Arbeitsmappenzellen, Formatierungen, Überlappungen, Abstandsbreiten und negative Werte in Präsentationen auf Android verwalten."
---
## **Übersicht**

Ein Diagramm speichert seine geplotteten Daten in einer Diagrammdaten‑Arbeitsmappe. Ein [IChartSeries](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/) stellt einen Satz zusammenhängender Werte dar, und jedes [IChartDataPoint](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/) in der Serie bezieht sich auf eine oder mehrere Zellen der Arbeitsmappe. [IChartCategory](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartcategory/)‑Objekte liefern die Beschriftungen oder Gruppierungswerte, die von den Serien gemeinsam genutzt werden. Der Serienname, die Kategorien und die Punktewerte sind daher mit [IChartDataCell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/)‑Objekten verbunden und werden nicht nur als Anzeigetext gespeichert.

Für ein typisches Kategoriendiagramm verwendet die Standard‑Arbeitsmappe Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die übrigen Zellen für Serienwerte. Arbeitsblatt‑, Zeilen‑ und Spaltenindizes, die an [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) übergeben werden, sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber gehen Sie nicht davon aus, dass jedes vorhandene Diagramm es verwendet. Für eine geladene Präsentation sollten Sie die von den Serien, Kategorien und Datenpunkten referenzierten Zellen prüfen, bevor Sie Arbeitsmappenwerte ändern.

Diagrammeinstellungen haben drei verschiedene Geltungsbereiche:

- Serien‑bezogene Einstellungen, wie [IChartSeries.getFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getFormat--), stellen das Standard‑Aussehen für alle Punkte einer Serie bereit.
- Datenpunkt‑bezogene Einstellungen, wie [IChartDataPoint.getFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), überschreiben das Serien‑Aussehen für einen einzelnen Punkt.
- Gruppeneinstellungen gelten für kompatible Serien, die zur selben [IChartSeriesGroup](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseriesgroup/) gehören. Greifen Sie über [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Abstandsbreite festlegen müssen.

Wenn weder ein expliziter Punkt‑ noch ein Serien‑Füllstil gesetzt ist, bestimmen Diagrammstil und -thema das automatische Aussehen. Wenn sowohl Serien‑ als auch Punkt‑Formatierung vorhanden sind, hat die Punkt‑Formatierung für diesen Punkt Vorrang.

![Diagramm‑Serie‑Powerpoint](chart-series-powerpoint.png)

## **Festlegen der Überlappung von Diagrammserien**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getOverlap--) gibt an, wie stark Balken oder Spalten in einem 2D‑Diagramm überlappen, von –100 bis 100 Prozent. Es ist eine schreib‑geschützte Projektion der Einstellung in der übergeordneten Seriengruppe. Verwenden Sie [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-), um jede kompatible Serie in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Spalten anzeigen; sie wirkt sich nicht auf unabhängige Seriengruppen in einem Kombinationsdiagramm aus.

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

Das Ergebnis:

![Die Serien‑Überlappung](series_overlap.png)

## **Ändern der Füllfarbe einer Serie**

Verwenden Sie [IChartSeries.getFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getFormat--), um die Standard‑Füllung für eine gesamte Serie festzulegen. Wenn ein Punkt bereits eine explizite Füllung hat, überschreibt dessen [IChartDataPoint.getFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) Einstellung die Serien‑Füllung für diesen Punkt.

Das folgende Beispiel wendet eine einfarbige blaue Füllung auf die erste Serie an:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Die Farbe der Serie](series_color.png)

## **Ändern des Seriennamens**

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

Sie können auch die Zelle aktualisieren, die bereits von [IChartSeries.getName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getName--) referenziert wird. Dieser Ansatz vermeidet Annahmen über bestimmte Zeilen und Spalten in einem vorhandenen Diagramm:

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

![Der Serienname](series_name.png)

## **Abrufen der automatischen Serien‑Füllfarbe**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) gibt die aus dem Serienindex und dem Diagrammstil berechnete Farbe als Android‑ARGB‑Integer zurück. Dies ist die Farbe, die verwendet wird, wenn die Serien‑Füllung nicht explizit definiert ist. Der Methodenaufruf liest die berechnete Farbe; er weist keine neue Füllung zu.

Das folgende Beispiel gibt den automatischen Farbwert jeder Standard‑Serie aus:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Die genauen Ganzzahlwerte hängen vom Diagrammstil und -thema ab.

## **Invertierte Füllfarbe für eine Diagrammserie festlegen**

Für Balken‑, Säulen‑ und Blasendiagramme kann [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negative Werte mit einer anderen Füllung anzeigen. Legen Sie die reguläre Serien‑Füllung auf einfarbig fest, aktivieren Sie die Invertierung und setzen Sie die Farbe für negative Werte über [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur ihre Anzeigefarbe ändert sich.

Das folgende Beispiel ersetzt die Standard‑Diagrammdaten durch eine Serie. Arbeitsblatt‑Zeile 0 enthält den Seriennamen, Spalte 0 enthält Kategorienamen und Spalte 1 enthält die Werte:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

![Die invertierte einfarbige Füllfarbe](inverted_solid_fill_color.png)

Sie können die Invertierung für einen Punkt über [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) aktivieren. Im folgenden Beispiel ist die Invertierung für die Serie deaktiviert und nur für den ausgewählten Punkt aktiviert. Der Punkt erhält zudem einen negativen Wert, damit der Effekt sichtbar ist:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

## **Löschen eines bestimmten Datenpunktwerts**

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie die zugehörige Arbeitsmappen‑Zelle auf `null`. Für ein Säulendiagramm ist der geplottete Wert über [IChartDataPoint.getValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) abrufbar. Der Datenpunkt bleibt an derselben Kategorienposition, aber das Diagramm behandelt seinen Wert als leer gemäß den Leere‑Wert‑Einstellungen des Diagramms.

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

Streudiagramme verwenden separate X‑ und Y‑Zellen, und Blasendiagramme verwenden zusätzlich eine Größenzelle. Löschen Sie nur die Zelle, die den zu entfernenden Wert repräsentiert. Rufen Sie nicht [IChartDataPointCollection.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) auf, wenn Sie die anderen Punkte behalten möchten, da diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Steuerung der Anzeige leerer Zellen**

Eine leere Arbeitsmappen‑Zelle steht für fehlende Daten; eine Zelle mit `0` steht für einen bekannten numerischen Wert. Rufen Sie [IChartDataCell.setValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) mit `null` auf, um eine Zelle leer zu machen. Eine numerische Null bleibt eine Null, unabhängig von der Leere‑Zellen‑Einstellung.

Verwenden Sie [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-), um festzulegen, wie das Diagramm leere Zellen darstellt. Diese Einstellung gilt für das gesamte Diagramm. Sie ändert, wie Leereinträge geplottet werden, ohne die leere Arbeitsmappendatei mit Null oder einem interpolierten Wert zu füllen.

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit einer Serie, löscht den Wert für Tag 3 und speichert dasselbe Diagramm in jedem Modus. Eine Eingabedatei ist nicht erforderlich. Das [IChartDataWorkbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/) verwendet Arbeitsblatt 0, Spalte 0 für Kategorienamen und Spalte 1 für Werte; Zeile 0 enthält den Seriennamen. Die endgültigen Daten lauten `10, 20, leer, 30, 40`.

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

Jede Ausgabedatei speichert den vor dem Speichern zugewiesenen Modus: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` und `empty_cells_Span.pptx`. Um nur eine Version zu speichern, setzen Sie den gewünschten Modus und speichern Sie die Präsentation ein einziges Mal, anstatt über die Modi zu iterieren.

Der Vergleich unten zeigt dieselben Daten in allen drei Dateien. Tag 3 ist in der Arbeitsmappe in jedem Fall leer:

![Liniendiagramme mit identischen Daten: Gap bricht die Linie an Tag 3, Zero lässt die Linie bis Null fallen, und Span verbindet Tag 2 mit Tag 4.](display_blanks_as.png)

Der sichtbare Effekt hängt vom Diagrammtyp ab. Ein Liniendiagramm macht alle drei Modi leicht vergleichbar. Balken‑ und Säulendiagramme haben keine Linie, die über eine fehlende Kategorie hinweg verbindet, sodass `Span` nicht das oben gezeigte verbindende Segment erzeugen kann; eine fehlende Spalte und eine Null‑Höhen‑Spalte können ebenfalls ähnlich aussehen. Ähnlich hat ein Streudiagramm mit reinen Markern keine Verbindungslinie. Erwarten Sie nicht für jeden Diagrammtyp drei unterschiedliche Ergebnisse; prüfen Sie die Ausgabe für den von Ihnen verwendeten Typ.

## **Festlegen der Abstandsbreite von Serien**

Die Abstandsbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, angegeben als Prozentsatz der Balken‑ bzw. Säulenbreite. Wie die Überlappung gehört sie zur übergeordneten Seriengruppe und nicht zu einer einzelnen Serie. Rufen Sie [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) einmal für die Gruppe auf. Ein größerer Wert erzeugt mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

Das folgende Beispiel ändert die Abstandsbreite und speichert nur die abschließende Präsentation:

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

![Die Abstandsbreite](gap_width.png)

## **FAQ**

**Welche Diagrammtypen unterstützen Datenserien?**

Alle Diagrammtypen, die durch die Aufzählung [ChartType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/charttype/) repräsentiert werden, verwenden Diagrammdaten, jedoch haben ihre Serien nicht alle dieselbe Wertstruktur oder dieselben Einstellungen. Beispielsweise verwenden Kategoriendiagramme Kategorien und Werte, Streudiagramme X‑ und Y‑Werte und Blasendiagramme zusätzlich Blasengrößen. Verwenden Sie die Datenpunkt‑Erstellungsmethode, die zum Seriotyp passt. Optionen wie Überlappung und Abstandsbreite gelten nur für kompatible Balken‑ oder Säulengruppen.

**Was ist eine Diagrammseriengruppe?**

Eine [IChartSeriesGroup](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseriesgroup/) enthält kompatible Serien, die gruppenbezogene Darstellungseinstellungen teilen. Ein Kombinationsdiagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der über eine Serie erreichten Gruppe nicht zwangsläufig jede Serie im Diagramm ändert.

**Enthält ein neu erstelltes Diagramm Standardsdaten?**

Ja. Standardmäßig erzeugt [IShapeCollection.addChart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) Beispielserien, -kategorien und -werte. Sie können diese Zellen bearbeiten oder sowohl die Serien‑ als auch die Kategorien‑Sammlungen leeren, bevor Sie ein komplett eigenes Datenset hinzufügen. Eine Überladung kann zudem ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagrammobjekte mit Arbeitsmappen‑Zellen verknüpft?**

Seriennamen, Kategorie‑Beschriftungen und Datenpunkt‑Werte referenzieren Zellen in einer [IChartDataWorkbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagrammelement. Beim Erstellen benutzerdefinierter Daten sollten Sie Kategorie‑Zeilen und Serien‑Wert‑Zeilen ausrichten, sodass jeder Punkt unter der vorgesehenen Kategorie geplottet wird.

**Wie lösche ich einen einzelnen Punkt statt der gesamten Serie?**

Setzen Sie die betreffende Wert‑Zelle auf `null`, um die Kategorienposition des Punktes als leeren Punkt zu erhalten. Verwenden Sie [IChartDataPointCollection.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) nur, wenn Sie alle Punkte dieser Serie entfernen möchten. Entfernen Sie außerdem Kategorien, aktualisieren Sie jede Serie, damit deren Werte mit der Kategorien‑Sammlung ausgerichtet bleiben.

**Wie werden leere Punkte dargestellt?**

Das Ergebnis hängt vom Diagrammtyp und der über [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) konfigurierten Einstellung ab. Unterstützte Diagramme können Leereinträge als Lücken, als Nullwerte oder durch Verbinden benachbarter Punkte darstellen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht. Siehe **Steuerung der Anzeige leerer Zellen** für ein vollständiges Beispiel und einen visuellen Vergleich.

**Wie werden negative Werte formatiert?**

Für unterstützte Balken‑, Säulen‑ und Blasendiagramme rufen Sie [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) auf und setzen die über [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) zurückgegebene Farbe. Sie können das Verhalten für einen einzelnen Punkt mit [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) überschreiben. Diese Methoden beeinflussen die Formatierung, nicht die gespeicherten numerischen Werte.

**Welche Formatierung gewinnt, wenn sowohl eine Serie als auch ein Punkt formatiert sind?**

Explizite Datenpunkt‑Formatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin das explizite Serienformat oder, wenn das Serienformat nicht definiert ist, den automatischen Diagrammstil und das Theme. Gruppeneinstellungen wie Überlappung und Abstandsbreite steuern das Layout und sind keine Punkt‑Level‑Formatierungsüberschreibungen.

**Gibt es ein Limit für die Anzahl von Serien in einem Diagramm?**

Aspose.Slides legt kein separates festes Serien‑Zahl‑Limit fest. In der Praxis bestimmen Dateigrößen‑Beschränkungen, verfügbarer Speicher, Renderzeit und Lesbarkeit des Diagramms ein sinnvolles Limit.

**Was soll ich ändern, wenn Säulen zu eng oder zu weit auseinander liegen?**

Rufen Sie [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) auf der entsprechenden übergeordneten Seriengruppe auf. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzubringen.