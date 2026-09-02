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
- Negativer Wert
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien, Datenpunkte, Arbeitsmappenzellen, Formatierungen, Überlappungen, Lückenbreiten und negative Werte in Präsentationen mit Java verwalten."
---
## **Übersicht**

Ein Diagramm speichert seine geplotteten Daten in einer Diagrammdaten‑Arbeitsmappe. Ein [IChartSeries](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/) repräsentiert einen Satz zusammengehöriger Werte, und jedes [IChartDataPoint](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/) in der Serie bezieht sich auf eine oder mehrere Zellen der Arbeitsmappe. [IChartCategory](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartcategory/)-Objekte stellen die Beschriftungen oder Gruppierungswerte bereit, die von den Serien gemeinsam genutzt werden. Der Serienname, die Kategorien und die Punktwerte sind daher mit [IChartDataCell](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatacell/)‑Objekten verbunden und nicht nur als Anzeigetext gespeichert.

Für ein typisches Kategoriediagramm verwendet die Standardsarbeitsmappe Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die übrigen Zellen für Serienwerte. Arbeitsblatt‑, Zeilen‑ und Spaltenindizes, die an [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) übergeben werden, sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber gehen Sie nicht davon aus, dass jedes vorhandene Diagramm es verwendet. Bei einer geladenen Präsentation prüfen Sie die Zellen, auf die die Serien, Kategorien und Datenpunkte verweisen, bevor Sie Arbeitsmappenwerte ändern.

Diagrammeinstellungen haben drei verschiedene Geltungsbereiche:

- Einstellungen auf Seri­enebene, wie [IChartSeries.getFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getFormat--), geben das Standardaussehen für alle Punkte einer Serie vor.
- Datenpunkt‑Einstellungen, wie [IChartDataPoint.getFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/#getFormat--), überschreiben das Serien‑Aussehen für einen einzelnen Punkt.
- Gruppeneinstellungen gelten für kompatible Serien, die zur selben [IChartSeriesGroup](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseriesgroup/) gehören. Greifen Sie über [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Lückenbreite festlegen müssen.

Wenn keine explizite Punkt‑ oder Serien‑Füllung festgelegt ist, bestimmen der Diagrammstil und das Thema das automatische Aussehen. Wenn sowohl Serien‑ als auch Punkt‑Formatierung vorhanden sind, hat die Punkt‑Formatierung für diesen Punkt Vorrang.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Überlappung der Diagrammserie festlegen**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getOverlap--) gibt an, wie stark Balken oder Säulen in einem 2D‑Diagramm von –100 % bis 100 % überlappen. Es ist eine schreibgeschützte Projektion der Einstellung in der übergeordneten Seriengruppe. Verwenden Sie [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-), um jede kompatible Serie in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen anzeigen; sie beeinflusst keine nicht zusammenhängenden Seriengruppen in einem Kombinationsdiagramm.

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

![The series overlap](series_overlap.png)

## **Füllfarbe der Serie ändern**

Verwenden Sie [IChartSeries.getFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getFormat--) , um die Standardfüllung für eine gesamte Serie festzulegen. Hat ein Punkt bereits eine explizite Füllung, überschreibt dessen [IChartDataPoint.getFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/#getFormat--) Einstellung die Serien‑Füllung für diesen Punkt.

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

Das Ergebnis:

![The color of the series](series_color.png)

## **Seriennamen ändern**

Ein Serienname wird in der Diagrammdaten‑Arbeitsmappe gespeichert und normalerweise in der Legende angezeigt. In der Standardarbeitsmappe, die für ein gruppiertes Säulendiagramm erstellt wird, befindet sich Zelle B1 in Zeile 0, Spalte 1 und enthält den Namen der ersten Serie. Die benannten Konstanten im folgenden Beispiel machen diese Struktur explizit:

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

Sie können die Zelle, auf die bereits [IChartSeries.getName](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getName--) verweist, ebenfalls aktualisieren. Dieser Ansatz vermeidet Annahmen über eine bestimmte Zeile und Spalte in einem bestehenden Diagramm:

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

## **Automatische Füllfarbe der Serie abrufen**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) liefert die Farbe, die aus dem Serien‑Index und dem Diagrammstil berechnet wird. Dies ist die Farbe, die verwendet wird, wenn die Serien‑Füllung nicht explizit definiert wurde. Der Aufruf der Methode liest die berechnete Farbe; er weist keine neue Füllung zu.

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

Beispielausgabe für den Standard‑Diagrammstil:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Die genauen Farben hängen vom Diagrammstil und -thema ab.

## **Umgekehrte Füllfarbe für eine Diagrammserie festlegen**

Für Balken‑, Säulen‑ und Blasendiagramme kann [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negative Werte mit einer anderen Füllung anzeigen. Setzen Sie die reguläre Serien‑Füllung auf solide, aktivieren Sie die Inversion und weisen Sie die Farbe für negative Werte über [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) zu. Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur ihre Anzeige­farbe ändert sich.

Das folgende Beispiel ersetzt die Standard‑Diagrammdaten durch eine Serie. Zeile 0 des Arbeitsblatts enthält den Seriennamen, Spalte 0 enthält die Kategorienamen und Spalte 1 die Werte:

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

Sie können die Inversion für einen einzelnen Punkt über [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) aktivieren. Im folgenden Beispiel ist die Inversion für die Serie deaktiviert und nur für den ausgewählten Punkt aktiviert. Der Punkt erhält zudem einen negativen Wert, damit der Effekt sichtbar ist:

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

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie die zugehörige Arbeitsmappen‑Zelle auf `null`. Bei einem Säulendiagramm ist der geplottete Wert über [IChartDataPoint.getValue](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/#getValue--) abrufbar. Der Datenpunkt bleibt an derselben Kategorienposition, aber das Diagramm behandelt seinen Wert als leer gemäß den Leere‑Wert‑Einstellungen des Diagramms.

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

Punkt‑Diagramme verwenden separate X‑ und Y‑Zellen, und Blasendiagramme benötigen zudem eine Größen‑Zelle. Löschen Sie nur die Zelle, die den Wert repräsentiert, den Sie entfernen möchten. Rufen Sie nicht [IChartDataPointCollection.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapointcollection/#clear--) auf, wenn Sie die anderen Punkte behalten wollen, da diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Lückenbreite der Serie festlegen**

Die Lückenbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, ausgedrückt als Prozentsatz der Balken‑ bzw. Säulenbreite. Wie die Überlappung gehört sie zur übergeordneten Seriengruppe und nicht zu einer einzelnen Serie. Rufen Sie [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) einmal für die Gruppe auf. Ein größerer Wert erzeugt mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

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

![The gap width](gap_width.png)

## **FAQ**

**Welche Diagrammtypen unterstützen Datenserien?**

Alle Diagrammtypen, die durch die [ChartType](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/)-Aufzählung dargestellt werden, verwenden Diagrammdaten, aber ihre Serien besitzen nicht überall dieselbe Wertstruktur oder dieselben Einstellungen. Beispielsweise verwenden Kategoriediagramme Kategorien und Werte, Streudiagramme X‑ und Y‑Werte und Blasendiagramme zusätzlich die Blasengrößen. Verwenden Sie die Datenpunkt‑Erstellungsmethode, die zum Serientyp passt. Optionen wie Überlappung und Lückenbreite gelten nur für kompatible Balken‑ oder Säulengruppen.

**Was ist eine Diagrammserien‑Gruppe?**

Eine [IChartSeriesGroup](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseriesgroup/) enthält kompatible Serien, die gruppenbezogene Darstellungs‑Einstellungen teilen. Ein Kombinationsdiagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der Gruppe über eine Serie nicht zwingend jede Serie im Diagramm beeinflusst.

**Enthält ein neu erstelltes Diagramm Standarddaten?**

Ja. Standardmäßig erzeugt [IShapeCollection.addChart](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) Beispielserien, -kategorien und -werte. Sie können diese Zellen bearbeiten oder sowohl Serien‑ als auch Kategorien‑Sammlungen leeren, bevor Sie einen völlig eigenen Datensatz hinzufügen. Eine Überladung kann zudem ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagrammobjekte mit Arbeitsmappen‑Zellen verknüpft?**

Seriennamen, Kategorielabels und Datenpunktwerte verweisen auf Zellen in einer [IChartDataWorkbook](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagrammelement. Beim Aufbau eigener Daten halten Sie die Zeilen für Kategorien und Serien‑Werte ausgerichtet, sodass jeder Punkt unter der vorgesehenen Kategorie geplottet wird.

**Wie lösche ich einen Punkt statt einer ganzen Serie?**

Setzen Sie die relevante Wertzelle auf `null`, um die Position des Punktes als leeren Punkt beizubehalten. Verwenden Sie [IChartDataPointCollection.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapointcollection/#clear--) nur, wenn Sie alle Punkte dieser Serie entfernen möchten. Entfernen Sie zudem nicht versehentlich Kategorien, ohne die Serienwerte entsprechend anzupassen, damit die Ausrichtung erhalten bleibt.

**Wie werden leere Punkte angezeigt?**

Das Ergebnis hängt vom Diagrammtyp und der über [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) konfigurierten Einstellung ab. Unterstützte Diagramme können Leere als Lücken, als Nullwerte oder durch Verbinden benachbarter Punkte darstellen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht.

**Wie werden negative Werte formatiert?**

Für unterstützte Balken‑, Säulen‑ und Blasendiagramme rufen Sie [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) auf und setzen die Farbe, die über [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) zurückgegeben wird. Für einzelne Punkte können Sie das Verhalten mit [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) überschreiben. Diese Methoden beeinflussen die Formatierung, nicht die gespeicherten Zahlenwerte.

**Welche Formatierung hat Vorrang, wenn sowohl Serie als auch Punkt formatiert sind?**

Explizite Datenpunkt‑Formatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin das explizite Serienformat oder, wenn kein Serienformat definiert ist, das automatische Diagramm‑Stil‑ und Themen‑Aussehen. Gruppeneinstellungen wie Überlappung und Lückenbreite steuern das Layout und sind keine punktbezogenen Formatierungs‑Überschreibungen.

**Gibt es ein Limit für die Anzahl der Serien in einem Diagramm?**

Aspose.Slides setzt kein separates festes Serien‑Zähl‑Limit. In der Praxis bestimmen Dateigrößen‑Beschränkungen, verfügbarer Arbeitsspeicher, Render‑Zeit und die Lesbarkeit des Diagramms ein sinnvolles Limit.

**Was sollte ich ändern, wenn Säulen zu nahe beieinander oder zu weit auseinander liegen?**

Rufen Sie [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) auf der entsprechenden übergeordneten Seriengruppe auf. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzubringen.