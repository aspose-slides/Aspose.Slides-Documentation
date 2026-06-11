---
title: Anpassa diagramaxlar i presentationer med Python
linktitle: Diagramaxel
type: docs
url: /sv/python-net/chart-axis/
keywords:
- diagramaxel
- vertikal axel
- horisontell axel
- anpassa axel
- manipulera axel
- hantera axel
- axelegenskaper
- maxvärde
- minvärde
- axellinje
- datumformat
- axeltitel
- axelposition
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Upptäck hur du använder Aspose.Slides för Python via .NET för att anpassa diagramaxlar i PowerPoint- och OpenDocument-presentationer för rapporter och visualiseringar."
---
## **Översikt**

Denna artikel förklarar hur du anpassar diagramaxlar i Aspose.Slides. Den visar hur du får faktiska axelvärden, byter data mellan axlar, döljer den vertikala eller horisontella axeln för linjediagram, ändrar kategoriaxeltypen, ställer in datumformatet för kategoriaxelvärden, roterar en axeltitel, anger axelns position och visar en enhetsetikett på värdeaxeln.

## **Hämta maxvärdena på den vertikala axeln i diagram**
Aspose.Slides for Python via .NET låter dig hämta de minsta och största värdena på en vertikal axel. Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Öppna den första bilden.
1. Lägg till ett diagram med standarddata.
1. Hämta det faktiska maximala värdet på axeln.
1. Hämta det faktiska minsta värdet på axeln.
1. Hämta den faktiska huvudenheten för axeln.
1. Hämta den faktiska underenheten för axeln.
1. Hämta den faktiska skalan för huvudenheten på axeln.
1. Hämta den faktiska skalan för underenheten på axeln.

Denna exempelkod—en implementering av stegen ovan—visar hur du får de nödvändiga värdena i Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Sparar presentationen
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Byta data mellan axlar**
Aspose.Slides låter dig snabbt byta data mellan axlar—data som visas på den vertikala axeln (y-axeln) flyttas till den horisontella axeln (x-axeln) och vice versa. 

Denna Python‑kod visar hur du utför datautbytesuppgiften mellan axlar i ett diagram:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Skapar tom presentation
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Byter rader och kolumner
    chart.chart_data.switch_row_column()
            
    # Sparar presentationen
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Inaktivera den vertikala axeln för linjediagram**

Denna Python‑kod visar hur du döljer den vertikala axeln för ett linjediagram:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Inaktivera den horisontella axeln för linjediagram**

Denna kod visar hur du döljer den horisontella axeln för ett linjediagram:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Ändra kategoriaxel**

Med egenskapen **CategoryAxisType** kan du specificera önskad kategoriaxeltyp (**date** eller **text**). Denna kod i Python demonstrerar operationen: 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställa in datumformatet för kategoriaxelvärde**
Aspose.Slides for Python via .NET låter dig ange datumformatet för ett kategoriaxelvärde. Operationen demonstreras i denna Python‑kod:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställa in rotationsvinkeln för diagramaxeltitel**
Aspose.Slides for Python via .NET låter dig ange rotationsvinkeln för en diagramaxeltitel. Denna Python‑kod demonstrerar operationen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställa in positionsaxeln i en kategori‑ eller värdeaxel**
Aspose.Slides for Python via .NET låter dig ange positionsaxeln i en kategori‑ eller värdeaxel. Denna Python‑kod visar hur du utför uppgiften:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktivera visning av enhetsetikett på diagrammets värdeaxel**
Aspose.Slides for Python via .NET låter dig konfigurera ett diagram så att det visar en enhetsetikett på dess värdeaxel. Denna Python‑kod demonstrerar operationen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Hur ställer jag in värdet där en axel korsar den andra (axelkorsning)?**

Axlar erbjuder en korsningsinställning: du kan välja att korsa vid noll, vid den maximala kategori-/värdet, eller vid ett specifikt numeriskt värde. Detta är användbart för att flytta X-axeln upp eller ner eller för att framhäva en baslinje.

**Hur kan jag positionera tics‑etiketterna i förhållande till axeln (bredvid, utanför, innanför)?**

Ställ in etikettpositionen till "cross", "outside" eller "inside". Detta påverkar läsbarheten och hjälper till att spara utrymme, särskilt i små diagram.