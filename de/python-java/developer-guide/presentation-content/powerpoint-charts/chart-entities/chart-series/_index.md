---
title: Diagrammdatenserien in Präsentationen mit Python verwalten
linktitle: Datenserien
type: docs
url: /de/python-java/chart-series/
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
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien, Datenpunkte, Arbeitsmappenzellen, Formatierungen, Überlappungen, Lückenbreiten und negative Werte in Präsentationen mit Aspose.Slides für Python über Java verwalten."
---
## **Übersicht**

Ein Diagramm speichert seine geplotteten Daten in einer Diagrammdaten‑Arbeitsmappe. Eine [ChartSeries](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/) stellt einen Satz zusammengehöriger Werte dar, und jeder [ChartDataPoint](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/) in der Serie verweist auf eine oder mehrere Zellen der Arbeitsmappe. [ChartCategory](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartcategory/)-Objekte liefern die Beschriftungen oder Gruppierungswerte, die von den Serien gemeinsam genutzt werden. Der Serienname, die Kategorien und die Punktwerte sind daher mit [ChartDataCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatacell/)-Objekten verknüpft und werden nicht nur als Anzeigetext gespeichert.

Bei einem typischen Kategoriediagramm verwendet die Standardsarbeitsmappe Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die übrigen Zellen für Serienwerte. Arbeitsblatt‑, Zeilen‑ und Spaltenindizes, die an [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/#getCell) übergeben werden, sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber Sie sollten nicht davon ausgehen, dass jedes vorhandene Diagramm es verwendet. Für eine geladene Präsentation überprüfen Sie die von den Serien, Kategorien und Datenpunkten referenzierten Zellen, bevor Sie Arbeitsmappenwerte ändern.

Diagrammeinstellungen haben drei verschiedene Geltungsbereiche:

- Einstellungen auf Serienebene, wie [ChartSeries.getFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getFormat), geben das Standardaussehen für alle Punkte einer Serie vor.
- Datenpunkt‑Einstellungen, wie [ChartDataPoint.getFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#getFormat), überschreiben das Serien‑Aussehen für einen einzelnen Punkt.
- Gruppeneinstellungen gelten für kompatible Serien, die zur selben [ChartSeriesGroup](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/). Greifen Sie über [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getParentSeriesGroup) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Lückenbreite festlegen müssen.

Wenn keine explizite Punkt‑ oder Serien‑Füllung festgelegt ist, bestimmen Diagrammstil und -thema das automatische Aussehen. Wenn sowohl Serien‑ als auch Punktformatierung vorhanden sind, hat die Punktformatierung für diesen Punkt Vorrang.

![Diagrammserie-Powerpoint](chart-series-powerpoint.png)

## **Überlappung der Diagrammserie festlegen**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getOverlap) meldet, wie stark Balken oder Säulen in einem 2D-Diagramm überlappen, von -100 bis 100 Prozent. Es ist eine schreibgeschützte Projektion der Einstellung der übergeordneten Seriengruppe. Verwenden Sie [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/#setOverlap), um alle kompatiblen Serien in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen darstellen; sie beeinflusst keine nicht verwandten Seriengruppen in einem Kombinationsdiagramm.

Das folgende Beispiel setzt die Überlappung für die Gruppe, die die erste Serie enthält:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # Das neue Diagramm enthält Beispielserien, Kategorien und Werte.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Serienüberlappung](series_overlap.png)

## **Füllfarbe der Serie ändern**

Verwenden Sie [ChartSeries.getFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getFormat), um die Standardfüllung für eine komplette Serie festzulegen. Hat ein Punkt bereits eine explizite Füllung, überschreibt dessen [ChartDataPoint.getFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#getFormat) Einstellung die Serienfüllung für diesen Punkt.

Das folgende Beispiel wendet eine einfarbige blaue Füllung auf die erste Serie an:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Farbe der Serie](series_color.png)

## **Seriennamen ändern**

Ein Serienname wird in der Diagrammdaten‑Arbeitsmappe gespeichert und normalerweise in der Legende angezeigt. In der Standardarbeitsmappe, die für ein gruppiertes Säulendiagramm erstellt wird, befindet sich Zelle B1 in Zeile 0, Spalte 1 und enthält den Namen der ersten Serie. Die benannten Variablen im folgenden Beispiel machen diese Struktur explizit:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sie können auch die bereits von [ChartSeries.getName](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getName) referenzierte Zelle aktualisieren. Dieser Ansatz vermeidet Annahmen über eine bestimmte Zeile und Spalte in einem bestehenden Diagramm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Der Serienname](series_name.png)

## **Automatische Serienfüllfarbe abrufen**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) gibt die aus dem Serienindex und dem Diagrammstil berechnete Farbe zurück. Dies ist die Farbe, die verwendet wird, wenn die Serienfüllung nicht explizit definiert ist. Der Aufruf der Methode liest die berechnete Farbe; er weist keine neue Füllung zu.

Das folgende Beispiel gibt die automatische Farbe jeder Standardserie aus:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Beispielausgabe für den Standarddiagrammstil:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Die genauen Farben hängen vom Diagrammstil und -thema ab.

## **Invertierte Füllfarbe für eine Diagrammserie festlegen**

Für Balken‑, Säulen‑ und Blasensereien kann [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#setInvertIfNegative) negative Werte mit einer anderen Füllung darstellen. Setzen Sie die reguläre Serienfüllung auf einfarbig, aktivieren Sie die Invertierung und weisen Sie die Farbe für negative Werte über [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) zu. Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur ihre Anzeige­farbe ändert sich.

Das folgende Beispiel ersetzt die Standarddiagrammdaten durch eine Serie. Zeile 0 des Arbeitsblatts enthält den Seriennamen, Spalte 0 enthält die Kategorienamen und Spalte 1 enthält die Werte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die invertierte einfarbige Füllfarbe](inverted_solid_fill_color.png)

Sie können die Invertierung für einen einzelnen Punkt über [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) aktivieren. Im folgenden Beispiel ist die Invertierung für die Serie deaktiviert und nur für den ausgewählten Punkt aktiviert. Dem Punkt wird zudem ein negativer Wert zugewiesen, damit der Effekt sichtbar wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Einen bestimmten Datenpunktwert löschen**

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie die zugehörige Zelle der Arbeitsmappe auf `None`. Für ein Säulendiagramm ist der geplottete Wert über [ChartDataPoint.getValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#getValue) abrufbar. Der Datenpunkt bleibt an derselben Kategorienposition, aber das Diagramm behandelt seinen Wert als leer gemäß den Einstellungen für leere Werte des Diagramms.

Das folgende Beispiel löscht nur den zweiten Punkt in der ersten Serie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Scatter‑Diagramme verwenden separate X‑ und Y‑Zellen, und Blasen‑Diagramme nutzen zusätzlich eine Größenzelle. Löschen Sie nur die Zelle, die den zu entfernenden Wert darstellt. Rufen Sie nicht [ChartDataPointCollection.clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapointcollection/#clear) auf, wenn Sie die anderen Punkte behalten möchten, da diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Lückenbreite der Serie festlegen**

Die Lückenbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, ausgedrückt als Prozentsatz der Balken‑ oder Säulenbreite. Wie die Überlappung gehört sie zur übergeordneten Seriengruppe und nicht zu einer einzelnen Serie. Rufen Sie [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/#setGapWidth) einmal für die Gruppe auf. Ein größerer Wert schafft mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

Das folgende Beispiel ändert die Lückenbreite und speichert nur die abschließende Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis:

![Die Lückenbreite](gap_width.png)

## **FAQ**

**Welche Diagrammtypen unterstützen Datenserien?**  
Alle durch die Aufzählung [ChartType](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/) dargestellten Diagrammtypen verwenden Diagrammdaten, aber ihre Serien haben nicht alle dieselbe Wertstruktur oder dieselben Einstellungen. Beispielsweise verwenden Kategoriediagramme Kategorien und Werte, Scatter‑Diagramme X‑ und Y‑Werte und Blasen‑Diagramme zusätzlich die Blasengrößen. Verwenden Sie die Datenpunkt‑Erstellungsmethode, die zum Serientyp passt. Optionen wie Überlappung und Lückenbreite gelten nur für kompatible Balken‑ oder Säulengruppen.

**Was ist eine Diagrammseriengruppe?**  
Eine [ChartSeriesGroup](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/) enthält kompatible Serien, die gruppenbezogene Plot‑Einstellungen gemeinsam nutzen. Ein Kombinationsdiagramm kann mehrere Gruppen enthalten, sodass das Ändern der über eine Serie erreichten Gruppe nicht zwangsläufig jede Serie im Diagramm verändert.

**Enthält ein neu erstelltes Diagramm Standarddaten?**  
Ja. Standardmäßig erzeugt [ShapeCollection.addChart](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addChart) Beispielserien, -kategorien und -werte. Sie können diese Zellen bearbeiten oder sowohl die Serien‑ als auch die Kategoriensammlungen leeren, bevor Sie ein völlig eigenes Datenset hinzufügen. Eine Überladung kann zudem ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagrammobjekte mit Arbeitsmappenzellen verknüpft?**  
Seriennamen, Kategorienbeschriftungen und Datenpunktwerte verweisen auf Zellen in einer [ChartDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagrammelement. Wenn Sie eigene Daten erstellen, halten Sie die Zeilen für Kategorien und die Zeilen für Serienwerte ausgerichtet, sodass jeder Punkt unter der gewünschten Kategorie geplottet wird.

**Wie lösche ich einen einzelnen Punkt statt der gesamten Serie?**  
Setzen Sie die entsprechende Wertzelle auf `None`, um die Kategorienposition des Punktes als leeren Punkt beizubehalten. Verwenden Sie [ChartDataPointCollection.clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapointcollection/#clear) nur, wenn Sie alle Punkte dieser Serie entfernen möchten. Entfernen Sie zudem Kategorien, aktualisieren Sie jede Serie, damit deren Werte mit der Kategoriensammlung ausgerichtet bleiben.

**Wie werden leere Punkte dargestellt?**  
Das Ergebnis hängt vom Diagrammtyp und dem über [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#setDisplayBlanksAs) konfigurierten Wert ab. Unterstützte Diagramme können leere Werte als Lücken, als Nullwerte oder durch Verbinden benachbarter Punkte darstellen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht.

**Wie werden negative Werte formatiert?**  
Für unterstützte Balken‑, Säulen‑ und Blasensereien rufen Sie [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#setInvertIfNegative) auf und setzen die über [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) zurückgegebene Farbe. Sie können das Verhalten für einen einzelnen Punkt mit [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) überschreiben. Diese Methoden beeinflussen die Formatierung, nicht die gespeicherten numerischen Werte.

**Welche Formatierung hat Vorrang, wenn sowohl eine Serie als auch ein Punkt formatiert sind?**  
Explizite Datenpunktformatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin das explizite Serienformat oder, wenn das Serienformat nicht definiert ist, den automatischen Diagrammstil und das -thema. Gruppeneinstellungen wie Überlappung und Lückenbreite steuern das Layout und stellen keine Punkte‑Formatierungsüberschreibungen dar.

**Gibt es eine Obergrenze für die Anzahl der Serien in einem Diagramm?**  
Aspose.Slides legt keine feste Obergrenze für die Anzahl der Serien fest. In der Praxis bestimmen die Beschränkungen der Präsentationsdatei, verfügbarer Speicher, Renderzeit und die Lesbarkeit des Diagramms eine sinnvolle Grenze.

**Was sollte ich ändern, wenn Säulen zu eng beieinander oder zu weit auseinander liegen?**  
Rufen Sie [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/#setGapWidth) für die entsprechende übergeordnete Seriengruppe auf. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzubringen.