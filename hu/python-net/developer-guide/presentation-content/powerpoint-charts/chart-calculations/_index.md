---
title: Diagram számítások optimalizálása prezentációkhoz Pythonban
linktitle: Diagram számítások
type: docs
weight: 50
url: /hu/python-net/chart-calculations/
keywords:
- diagram számítások
- diagram elemek
- elem pozíció
- valós pozíció
- gyermek elem
- szülő elem
- diagram értékek
- valós érték
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Értsd meg a diagram számításokat, az adatok frissítését és a pontosság vezérlését az Aspose.Slides for Python via .NET-ben PPT, PPTX és ODP esetén, gyakorlati kódpéldákkal."
---
## **Áttekintés**

Az Aspose.Slides API-kat biztosít a diagramok számításainak és elrendezési adatainak kezeléséhez a bemutatókban. Ez a cikk bemutatja, hogyan lehet lekérni a diagramelemek tényleges értékeit, beleértve a `ActualLayout`-et megvalósító elemek valós pozícióját és méretét, valamint a diagram tengelyeinek tényleges értékeit. Emellett elmagyarázza, hogy ezek az értékek a diagramelrendezés ellenőrzése után töltődnek fel.

Továbbá a cikk bemutatja, hogyan lehet lekérni a szülő diagramelemek tényleges pozícióját, valamint hogyan lehet elrejteni a diagram komponenseit, mint a cím, a tengelyek, a jelmagyarázat és a rácsvonalak. Ezek a példák segítenek a diagramelrendezési információk ellenőrzésében és a diagramelemek láthatóságának programozott vezérlésében a PowerPoint-bemutatókban.

## **A diagramelemek tényleges értékeinek kiszámítása**
Az Aspose.Slides for Python via .NET egyszerű API-t biztosít ezen tulajdonságok lekéréséhez. Ez segít a diagramelemek tényleges értékeinek kiszámításában. A tényleges értékek tartalmazzák azoknak az elemeknek a pozícióját, amelyek öröklik az [IActualLayout](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/iactuallayout/) osztályt (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight), valamint a tengelyek tényleges értékeit (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

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

## **A szülő diagramelemek tényleges pozíciójának kiszámítása**
Az Aspose.Slides for Python via .NET egyszerű API-t biztosít ezen tulajdonságok lekéréséhez. Az IActualLayout tulajdonságai információt nyújtanak a szülő diagramelem tényleges pozíciójáról. Előzetesen meg kell hívni az IChart.ValidateChartLayout() metódust, hogy a tulajdonságok tényleges értékekkel legyenek feltöltve.

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

## **Információ elrejtése a diagramról**
Ez a téma segít megérteni, hogyan lehet információkat elrejteni a diagramról. Az Aspose.Slides for Python via .NET használatával elrejtheti a **Címet, függőleges tengelyt, vízszintes tengelyt** és a **Rácsvonalakat** a diagramról. Az alábbi kódrészlet bemutatja, hogyan kell használni ezeket a tulajdonságokat.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Diagram címének elrejtése
    chart.has_title = False

    # Az érték tengely elrejtése
    chart.axes.vertical_axis.is_visible = False

    # Kategória tengely láthatósága
    chart.axes.horizontal_axis.is_visible = False

    # Jelmagyarázat elrejtése
    chart.has_legend = False

    # Fő rácsvonalak elrejtése
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Sorozat vonal színének beállítása
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Működnek-e külső Excel munkafüzetek adatforrásként, és ez hogyan befolyásolja az újraszámítást?**

Igen. A diagram hivatkozhat egy külső munkafüzetre: amikor csatlakozik vagy frissíti a külső forrást, a képletek és értékek az adott munkafüzettől származnak, és a diagram az nyitási/szerkesztési műveletek során frissül. Az API lehetővé teszi a [külső munkafüzet megadását](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) az elérési úttal, valamint a kapcsolt adatok kezelését.

**Számíthatok‑ és megjeleníthetek‑trendvonalakat anélkül, hogy magam implementálnám a regressziót?**

Igen. A [trendvonalak](/slides/hu/python-net/trend-line/) (lineáris, exponenciális és egyebek) hozzáadódnak és frissülnek az Aspose.Slides által; paramétereiket a sorozat adataiból automatikusan újraszámítja a rendszer, így nem kell saját számításokat implementálni.

**Ha egy bemutató több diagramot tartalmaz külső hivatkozásokkal, irányíthatom, hogy melyik munkafüzetet használja az egyes diagram a számított értékekhez?**

Igen. Minden diagram saját [külső munkafüzete](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) lehet, vagy diagramonként külön‑külön létrehozhat/lecserélhet egy külső munkafüzettet, függetlenül a többitől.