---
title: Optimera diagramberäkningar för presentationer i Python
linktitle: Diagramberäkningar
type: docs
weight: 50
url: /sv/python-net/chart-calculations/
keywords:
- diagramberäkningar
- diagramelement
- elementposition
- faktisk position
- underordnat element
- överordnat element
- diagramvärden
- faktiskt värde
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Förstå diagramberäkningar, datauppdateringar och precisionstyrning i Aspose.Slides för Python via .NET för PPT, PPTX och ODP, med praktiska kodexempel."
---
## **Översikt**

Aspose.Slides tillhandahåller API:er för att arbeta med diagramberäkningar och layoutdata i presentationer. Denna artikel visar hur man hämtar de faktiska värdena för diagramelement, inklusive den verkliga positionen och storleken på element som implementerar `ActualLayout` samt de faktiska värdena för diagramaxlar. Den förklarar också att dessa värden fylls i efter validering av diagramlayout.

Dessutom visar artikeln hur man får den faktiska positionen för överordnade diagramelement och hur man döljer diagramkomponenter såsom titel, axlar, legend och rutnät. Tillsammans hjälper dessa exempel dig att inspektera diagramlayoutinformation och styra synligheten för diagramelement i PowerPoint-presentationer programmässigt.

## **Beräkna faktiska värden för diagramelement**
Aspose.Slides för Python via .NET tillhandahåller ett enkelt API för att hämta dessa egenskaper. Detta hjälper dig att beräkna faktiska värden för diagramelement. De faktiska värdena inkluderar positionen för element som ärver [IActualLayout](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/iactuallayout/) klassen (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) och faktiska axelvärden (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```

## **Beräkna faktisk position för överordnade diagramelement**
Aspose.Slides för Python via .NET tillhandahåller ett enkelt API för att hämta dessa egenskaper. Egenskaperna i IActualLayout ger information om den faktiska positionen för överordnat diagramelement. Det är nödvändigt att tidigare anropa metoden IChart.ValidateChartLayout() för att fylla egenskaperna med faktiska värden.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```

## **Dölj information från diagram**
Detta ämne hjälper dig att förstå hur du döljer information från diagram. Med Aspose.Slides för Python via .NET kan du dölja **Titel, Vertikal axel, Horisontell axel** och **Rutnät** från diagrammet. Nedanstående kodexempel visar hur du använder dessa egenskaper.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Döljer diagramtitel
    chart.has_title = False

    # Döljer värdeaxel
    chart.axes.vertical_axis.is_visible = False

    # Synlighet för kategorinäxel
    chart.axes.horizontal_axis.is_visible = False

    # Döljer förklaringsruta
    chart.has_legend = False

    # Döljer huvudrutnätlinjer
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Anger serielinjefärg
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Fungerar externa Excel-arbetsböcker som datakälla, och hur påverkar det omberäkning?**

Ja. Ett diagram kan referera till en extern arbetsbok: när du ansluter eller uppdaterar den externa källan hämtas formler och värden från den arbetsboken, och diagrammet återspeglar uppdateringarna under öppnings-/redigeringsoperationer. API:et låter dig [ange den externa arbetsboken](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/set_external_workbook/) sökväg och hantera den länkade datan.

**Kan jag beräkna och visa trendlinjer utan att implementera regression själv?**

Ja. [Trendlinjer](/slides/sv/python-net/trend-line/) (linjära, exponentiella och andra) läggs till och uppdateras av Aspose.Slides; deras parametrar beräknas om automatiskt utifrån seriedatan, så du behöver inte implementera egna beräkningar.

**Om en presentation har flera diagram med externa länkar, kan jag styra vilken arbetsbok varje diagram använder för beräknade värden?**

Ja. Varje diagram kan peka på sin egen [externa arbetsbok](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chartdata/set_external_workbook/), eller så kan du skapa/ersätta en extern arbetsbok per diagram oberoende av de andra.