---
title: Diagrammdatenserien in Präsentationen unter Android verwalten
linktitle: Datenserien
type: docs
url: /de/androidjava/chart-series/
keywords:
- Diagrammserien
- Serienüberlappung
- Serienfarbe
- Serienname
- Datenpunkt
- Arbeitsblattzelle
- Serienlücke
- Negativer Wert
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien, Datenpunkte, Arbeitsblattzellen, Formatierung, Überlappung, Lückenbreite und negative Werte in Präsentationen unter Android verwalten."
---
## **Übersicht**

Ein Diagramm speichert seine geplotteten Daten in einer Diagrammdaten-Arbeitsmappe. Ein [IChartSeries](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/) repräsentiert einen Satz zusammenhängender Werte, und jedes [IChartDataPoint](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/) in der Serie bezieht sich auf eine oder mehrere Zellen der Arbeitsmappe. [IChartCategory](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartcategory/)-Objekte liefern die Beschriftungen oder Gruppierungswerte, die von den Serien gemeinsam verwendet werden. Der Serienname, die Kategorien und die Punktwerte sind daher mit [IChartDataCell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/)‑Objekten verbunden und werden nicht nur als Anzeigetext gespeichert.

Für ein typisches Kategoriendiagramm verwendet die Standard‑Arbeitsmappe Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die übrigen Zellen für Serienwerte. Arbeitsblatt‑, Zeilen‑ und Spaltenindizes, die an [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) übergeben werden, sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, jedoch sollten Sie nicht davon ausgehen, dass jedes bestehende Diagramm es verwendet. Bei einer geladenen Präsentation sollten Sie die von den Serien, Kategorien und Datenpunkten referenzierten Zellen prüfen, bevor Sie Arbeitsmappendaten ändern.

Diagrammeinstellungen haben drei verschiedene Geltungsbereiche:

- Serien‑bezogene Einstellungen, wie [IChartSeries.getFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getFormat--), stellen das Standardaussehen für alle Punkte einer Serie bereit.
- Datenpunkt‑Einstellungen, wie [IChartDataPoint.getFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), überschreiben das Serienaussehen für einen einzelnen Punkt.
- Gruppeneinstellungen gelten für kompatible Serien, die zur selben [IChartSeriesGroup](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseriesgroup/) gehören. Greifen Sie über [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Lückenbreite festlegen müssen.

Wenn keine explizite Punkt‑ oder Serienfüllung festgelegt ist, bestimmen Diagrammstil und -thema das automatische Aussehen. Wenn sowohl Serien‑ als auch Punktformatierung vorhanden sind, hat die Punktformatierung für diesen Punkt Vorrang.

![Diagramm‑Serie‑PowerPoint](chart-series-powerpoint.png)

## **Diagrammserien‑Überlappung festlegen**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getOverlap--) gibt an, wie stark Balken oder Säulen in einem 2D‑Diagramm überlappen, von -100 bis 100 Prozent. Es ist eine schreibgeschützte Projektion der Einstellung in der übergeordneten Seriengruppe. Verwenden Sie [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-), um jede kompatible Serie in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen anzeigen; sie wirkt sich nicht auf nicht verwandte Seriengruppen in einem Kombinationsdiagramm aus.

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

![Die Serienüberlappung](series_overlap.png)

## **Füllfarbe der Serie ändern**

Verwenden Sie [IChartSeries.getFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getFormat--) , um die Standardfüllung für eine gesamte Serie festzulegen. Wenn ein Punkt bereits eine explizite Füllung hat, überschreibt seine [IChartDataPoint.getFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)‑Einstellung die Serienfüllung für diesen Punkt.

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

## **Seriennamen ändern**

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

Sie können auch die Zelle aktualisieren, die bereits von [IChartSeries.getName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getName--) referenziert wird. Dieser Ansatz vermeidet Annahmen über eine bestimmte Zeile und Spalte in einem bestehenden Diagramm:

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

## **Automatische Füllfarbe der Serie abrufen**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) gibt die Farbe zurück, die aus dem Serienindex und dem Diagrammstil als Android‑ARGB‑Farbwert berechnet wird. Dies ist die Farbe, die verwendet wird, wenn die Serienfüllung nicht explizit definiert ist. Der Aufruf der Methode liest die berechnete Farbe; er weist keine neue Füllung zu.

Das folgende Beispiel gibt die automatische Farb‑Integer‑Zahl jeder Standard‑Serie aus:

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

Die genauen Ganzzahlenwerte hängen vom Diagrammstil und -thema ab.

## **Invertierte Füllfarbe für eine Diagrammserie festlegen**

Für Balken‑, Säulen‑ und Blasensereien kann [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negative Werte mit einer anderen Füllung anzeigen. Legen Sie die reguläre Serienfüllung auf einfarbig fest, aktivieren Sie die Invertierung und weisen Sie die Farbe für negative Werte über [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) zu. Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur ihre Anzeigefarbe ändert sich.

Das folgende Beispiel ersetzt die Standard‑Diagrammdaten durch eine Serie. Arbeitsblatt‑Zeile 0 enthält den Seriennamen, Spalte 0 enthält Kategorienamen und Spalte 1 die Werte:

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

Sie können die Invertierung für einen Punkt über [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) aktivieren. Im folgenden Beispiel wird die Invertierung für die Serie deaktiviert und nur für den ausgewählten Punkt aktiviert. Der Punkt erhält zudem einen negativen Wert, damit der Effekt sichtbar wird:

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

## **Wert eines bestimmten Datenpunkts löschen**

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie dessen zugrundeliegende Arbeitsmappendatei‑Zelle auf `null`. Für ein Säulendiagramm ist der geplottete Wert über [IChartDataPoint.getValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) abrufbar. Der Datenpunkt bleibt an derselben Kategorienposition, aber das Diagramm behandelt seinen Wert als leer gemäß den Blank‑Value‑Einstellungen des Diagramms.

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

Streudiagramme verwenden separate X‑ und Y‑Zellen, und Blasendiagramme nutzen zusätzlich eine Größenzelle. Löschen Sie ausschließlich die Zelle, die den zu entfernenden Wert repräsentiert. Rufen Sie nicht [IChartDataPointCollection.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) auf, wenn Sie die anderen Punkte behalten möchten, da diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Anzeige leerer Zellen steuern**

Ausgeblendete Zellen, die Werte enthalten, sind ein separater Fall von leeren Zellen. Um Daten aus ausgeblendeten Arbeitsblatt‑Zeilen und -Spalten ein‑ oder auszuschließen, siehe [Daten aus ausgeblendeten Zeilen und Spalten einbeziehen](/slides/de/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns).

Eine leere Arbeitsmappendatei‑Zelle stellt fehlende Daten dar; eine Zelle, die `0` enthält, stellt einen bekannten numerischen Wert dar. Rufen Sie [IChartDataCell.setValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) mit `null` auf, um eine Zelle leer zu machen. Eine numerische Null bleibt eine Null, unabhängig von der Einstellung für leere Zellen.

Verwenden Sie [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-), um festzulegen, wie das Diagramm leere Zellen darstellt. Diese Einstellung gilt für das gesamte Diagramm. Sie ändert, wie Lücken geplottet werden, ohne die leere Arbeitsmappendatei‑Zelle mit Null oder einem interpolierten Wert zu füllen.

Das folgende, eigenständige Beispiel erstellt ein Liniendiagramm mit einer Serie, löscht den Wert für Tag 3 und speichert das gleiche Diagramm für jeden Modus. Keine Eingabedatei ist erforderlich. Der [IChartDataWorkbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/) verwendet Arbeitsblatt 0, Spalte 0 für Kategorienamen und Spalte 1 für Werte; Zeile 0 enthält den Seriennamen. Die Enddaten lauten `10, 20, empty, 30, 40`.

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

    // Lassen Sie Tag 3 tatsächlich leer, während Sie die Kategorie und den Datenpunkt beibehalten.
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

Jede Ausgabedatei speichert den vor dem Speichern zugewiesenen Modus: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` und `empty_cells_Span.pptx`. Um nur eine Version zu speichern, weisen Sie den gewünschten Modus zu und speichern Sie die Präsentation ein einziges Mal, anstatt über die Modi zu iterieren.

Der Vergleich unten zeigt dieselben Daten in allen drei Dateien. Tag 3 ist in der Arbeitsmappe in jedem Fall leer:

![Liniendiagramme mit identischen Daten: Lücke trennt die Linie bei Tag 3, Null lässt die Linie auf Null fallen, und Span verbindet Tag 2 mit Tag 4.](display_blanks_as.png)

Der sichtbare Effekt hängt vom Diagrammtyp ab. Ein Liniendiagramm macht alle drei Modi leicht vergleichbar. Balken‑ und Säulendiagramme besitzen keine Linie, die über eine fehlende Kategorie hinwegführen könnte, sodass `Span` nicht das verbundene Segment erzeugen kann; eine fehlende Säule und eine Säule mit Höhe 0 können ebenfalls ähnlich aussehen. Ebenso hat ein Streudiagramm nur Marker und keine verbindende Linie. Erwarten Sie nicht drei unterschiedliche Ergebnisse für jeden Diagrammtyp; prüfen Sie die Ausgabe für den von Ihnen genutzten Typ.

## **Lückenbreite der Serie festlegen**

Die Lückenbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, angegeben als Prozentsatz der Balken‑ bzw. Säulenbreite. Ähnlich wie die Überlappung gehört sie zur übergeordneten Seriengruppe und nicht zu einer einzelnen Serie. Rufen Sie [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) einmal für die Gruppe auf. Ein größerer Wert erzeugt mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

Das folgende Beispiel ändert die Lückenbreite und speichert nur die endgültige Präsentation:

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

![Die Lückenbreite](gap_width.png)

## **FAQ**

**Welche Diagrammtypen unterstützen Datenserien?**

Alle Diagrammtypen, die durch die [ChartType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/charttype/)-Aufzählung repräsentiert werden, verwenden Diagrammdaten, jedoch haben ihre Serien nicht alle dieselbe Werte‑Struktur oder dieselben Einstellungen. Beispielsweise verwenden Kategoriendiagramme Kategorien und Werte, Streudiagramme X‑ und Y‑Werte und Blasendiagramme zusätzlich Blasengrößen. Verwenden Sie die Datenpunkt‑Erstellungsmethode, die zum Seriotyp passt. Optionen wie Überlappung und Lückenbreite gelten nur für kompatible Balken‑ oder Säulengruppen.

**Was ist eine Diagrammseriengruppe?**

Eine [IChartSeriesGroup](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseriesgroup/) enthält kompatible Serien, die gruppen­bezogene Darstellungseinstellungen teilen. Ein Kombinationsdiagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der Gruppe, die über eine Serie erreicht wird, nicht zwangsläufig jede Serie im Diagramm beeinflusst.

**Enthält ein neu erstelltes Diagramm Standarddaten?**

Ja. Standardmäßig erzeugt [IShapeCollection.addChart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) Beispielserien, Kategorien und Werte. Sie können diese Zellen bearbeiten oder sowohl die Serien‑ als auch die Kategorien‑Sammlungen leeren, bevor Sie ein vollständig eigenes Datenset hinzufügen. Eine Überladung kann zudem ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagrammobjekte mit Arbeitsmappendaten verknüpft?**

Seriennamen, Kategorien‑Beschriftungen und Werte von Datenpunkten referenzieren Zellen in einem [IChartDataWorkbook](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagrammelement. Wenn Sie eigene Daten erstellen, halten Sie die Reihenfolge von Kategorie‑ und Serien‑Wert‑Zeilen ausgerichtet, sodass jeder Punkt unter der beabsichtigten Kategorie geplottet wird.

**Wie lösche ich einen einzelnen Punkt statt der gesamten Serie?**

Setzen Sie die betreffende Wertzelle auf `null`, um die Position des Punktes als leeren Punkt beizubehalten. Verwenden Sie [IChartDataPointCollection.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) nur, wenn Sie sämtliche Punkte dieser Serie entfernen möchten. Entfernen Sie gleichzeitig Kategorien, passen Sie jede Serie an, damit deren Werte mit der Kategorieliste ausgerichtet bleiben.

**Wie werden leere Punkte dargestellt?**

Das Ergebnis hängt vom Diagrammtyp und von der über [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) konfigurierten Einstellung ab. Unterstützte Diagramme können Lücken, Null‑Werte oder eine Verbindung benachbarter Punkte anzeigen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht. Siehe [Anzeige leerer Zellen steuern](#anzeige-leerer-zellen-steuern) für ein komplettes Beispiel und einen visuellen Vergleich.

**Wie werden negative Werte formatiert?**

Für unterstützte Balken‑, Säulen‑ und Blasensereien rufen Sie [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) auf und setzen die Farbe, die über [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) zurückgegeben wird. Sie können das Verhalten für einen einzelnen Punkt mit [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) überschreiben. Diese Methoden beeinflussen die Formatierung, nicht die gespeicherten numerischen Werte.

**Welche Formatierung hat Vorrang, wenn sowohl Serie als auch Punkt formatiert sind?**

Explizite Datenpunkt‑Formatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin das explizite Serienformat oder, falls kein Serienformat definiert ist, den automatischen Diagrammstil und das Theme. Gruppeneinstellungen wie Überlappung und Lückenbreite steuern das Layout und sind keine punktbezogenen Formatierungsüberschreibungen.

**Gibt es ein Limit für die Anzahl von Serien in einem Diagramm?**

Aspose.Slides legt kein separates festes Limit für die Serienzahl fest. In der Praxis bestimmen Dateigrößen‑Beschränkungen, verfügbarer Speicher, Renderzeit und Lesbarkeit des Diagramms ein sinnvolles Limit.

**Was soll ich ändern, wenn Säulen zu eng oder zu weit auseinander liegen?**

Rufen Sie [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) für die entsprechende übergeordnete Seriengruppe auf. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzubringen.