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

Den här artikeln förklarar hur du anpassar diagramaxlar med Aspose.Slides för Python via .NET. Den täcker beräknade axiella värden, byte av diagramrader och -kolumner, axiell synlighet, intervaller för kategorietiketter och tick‑markeringar, datumkategorier och formatering, titeltrotation, axiell positionering, visningsenheter och logaritmisk skalning.

## **Hämta maxvärdena på den vertikala axeln i diagram**

Skapa en [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) och lägg till ett områdesdiagram med standarddata. Anropa [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) innan du läser beräknade axiella värden så att diagramlayouten är uppdaterad.

Läs [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) och [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) för axiellimitterna samt [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) och [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) för tick‑intervallerna. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) och [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) tillhandahåller tidsenhetsskalor, vilket är relevant för datumaxlar. Exemplet lagrar dessa värden i lokala variabler och sparar diagrammet.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Byt data mellan axlarna**

Använd [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) för att byta rollerna för serier och kategorier i diagramdata. Varje tidigare kategori blir en serie och varje tidigare serie blir en kategori. Detta ändrar hur data grupperas; det byter inte de horisontella och vertikala axlarna. Exemplet använder [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) för att binda standarddata till `Sheet1!A1:D5`, inklusive rubrikraden och kategori­kolumnen, innan rader och kolumner byts. Det sparar ett diagram med fyra serier och tre kategorier.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Inaktivera den vertikala axeln för linjediagram**

Ställ in [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) till `False` på den vertikala axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den vertikala axeln dold.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Inaktivera den horisontella axeln för linjediagram**

Ställ in [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) till `False` på den horisontella axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den horisontella axeln dold.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Ändra en kategori‑axel**

Ställ in [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) för att välja en datum- eller text‑kategori‑axel. Detta exempel kräver `ExistingChart.pptx`, med ett diagram som den första formen på den första bilden och kategoriceller som innehåller numeriska Excel‑datumvärden. Det ändrar den horisontella axeln till en datumaxel. Genom att sätta [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) till `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) till `1` och [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) till månader placeras huvudtickmarkeringar med ett‑månadsintervall.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Styr intervaller för kategori‑axelns etiketter**

När ett diagram har många kategorier, minska antalet synliga axel‑etiketter utan att ta bort kategorier eller datapunkter. Ställ in [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) till `False` och sätt sedan [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) till det önskade kategori‑intervallet. För textkategorier i deras normala ordning börjar räknandet vid den första kategorin:

| Intervall | Etiketter som visas i exemplet |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Ett intervall på `3` visar varje tredje etikett och lämnar två etiketter dolda mellan de visade etiketterna. Det tar inte bort motsvarande kolumner. Automatisk spacing väljer ett intervall baserat på tillgängligt utrymme; det visar inte nödvändigtvis varje etikett.

Tick‑markeringar har separata kontroller. Ställ in [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) till `False` och använd [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) för att ange deras intervall. Till exempel behåller `1` en tick‑markering vid varje kategori‑intervall medan etiketter bara visas var tredje kategori. Ställ in [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) till en synlig stil så att du kan se resultatet. Att återställa någon av de automatiska spacing‑egenskaperna till `True` låter diagrammet välja det intervallet igen.

Följande fristående exempel skapar 24 kategorier och en serie, och sparar sedan tre bilder i `CategoryAxisIntervals.pptx`: automatisk spacing, manuell etikett‑spacing med oberoende tick‑markeringar, och återställd automatisk spacing. De två kopiorna behåller de ursprungliga diagramdata. Ingen indatapresentation krävs. Horisontell etiketttext gör skillnaden i täthet lätt att se.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Slide 2: visa varje tredje etikett, men behåll en tick‑markering för varje kategori.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Slide 3: låt diagrammet välja båda intervallen igen.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatisk spacing (bild 1):** I den här rendering‑visningen visas varje andra kategori‑etikett och radbryts till två rader. Det automatiska resultatet kan variera beroende på diagramstorlek, typsnitt och renderaren.

![Automatisk kategori‑etikett‑spacing med alla 24 kolumner synliga](category-axis-automatic.png)

**Manuell spacing (bild 2):** Varje tredje etikett visas på en rad, medan tick‑markeringar förblir vid varje kategori‑intervall. Alla 24 kolumner, inklusive de utan etiketter, förblir synliga med samma värden. Bild 3 återställer den automatiska utseendet som visas ovan.

![Manuellt kategori‑etikett‑intervall på tre med alla 24 kolumner synliga](category-axis-manual.png)

### **Välj rätt axel och intervall**

Använd detta kategori‑räkne‑intervall för en text‑kategori‑axel, såsom kategori‑axeln i ett stapel-, linje-, område- eller stapeldiagram. I ett stapeldiagram är den den horisontella axeln. I ett horisontellt stapeldiagram är kategori‑axeln vertikal, så tillämpa dessa inställningar på [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Tick‑mark‑spacing gäller även för en serie‑axel i diagram som har en.

Använd inte kategori‑etikett‑spacing för att sätta den numeriska skalan på en värde‑axel. På en värde‑axel specificerar [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) en skillnad i värden: till exempel ger en huvud‑enhet på `10` tick‑markeringar vid 0, 10, 20 osv när axeln börjar vid noll. Ett kategori‑etikett‑intervall på `3` räknar istället kategori‑positioner, oavsett deras datavärden. Spridnings‑ och bubbeldiagram använder värde‑axlar snarare än en text‑kategori‑axel. För en datum‑axel, använd tidsbaserade huvud‑enheter och skalor som beskrivs i [Ändra en kategori‑axel](#change-a-category-axis).

## **Ange datumformatet för kategori‑axelns värden**

Exemplet ersätter standarddiagramdata med fyra årliga värden. Datum lagras som OLE Automation‑serienummer i det första arbetsbladet (index `0`). Ställ in [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) till en datum‑axel, inaktivera [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) och tilldela `yyyy` till [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) så att kategori‑etiketterna visar fyrsiffriga år oberoende av cellformateringen.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange en rotationsvinkel för en diagramaxeltitel**

Aktivera [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) på den vertikala axeln, ange titeltext och sätt [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) för att rotera titeln. Vinkeln mäts i grader; detta exempel sparar ett stapeldiagram med dess värde‑axeltitel roterad 90 grader.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange axelpositionen på en kategori‑ eller värdeaxel**

Använd [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) för att styra om värde‑axeln korsar kategori‑axeln mellan kategorier eller vid kategori‑tick‑markeringar. Denna egenskap gäller kategori‑axlar. Exemplet sätter den till `True` på den horisontella kategori‑axeln i ett stapeldiagram och sparar resultatet.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange display‑enheten på en diagramvärde‑axel**

Ställ in [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) för att skala etiketterna på en värde‑axel utan att ändra de underliggande data. Med [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) satt till `MILLIONS` visas ett värde på 60 000 000 som 60. Exemplet skapar ett stapeldiagram och tillämpar miljon‑display‑enheten på dess vertikala axel.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Konfigurera en logaritmisk värde‑axel**

En logaritmisk värde‑axel är användbar när positiva värden spänner över flera storleksordningar. Till exempel kan en tjänst ta emot 10, 100, 1 000, 10 000 och 100 000 förfrågningar under fem perioder. På en linjär skala ligger de mindre värdena nära varandra nära noll. En logaritmisk skala gör deras relativa tillväxt enklare att jämföra: lika avstånd representerar lika förhållanden snarare än lika skillnader.

Ställ in [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) till `True` på värde‑axeln och använd [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) för att välja basen. Detta ändrar hur befintliga värden visas; det ändrar inte data eller lägger till en logaritmisk trendlinje. En trendlinje representerar ett anpassat förhållande i data och är en separat funktion.

### **Välj värde‑axeln och basen**

För ett linje‑ eller stapeldiagram är värde‑axeln [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). För ett horisontellt stapeldiagram är den [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Spridnings‑ och bubbeldiagram har två värde‑axlar, så välj den horisontella axeln för X‑värden, den vertikala axeln för Y‑värden, eller båda. Applicera inte logaritmisk skalning på en kategori‑axel.

Standard‑logaritmbasen är `10`. För PPTX‑diagram, använd en bas från `2` till `1000` inklusive; bråktalsbaser som `2.5` stöds också. Med bas `10` är efterföljande potenser som 10, 100, 1 000 och 10 000 lika stora.

### **Jämför linjär och logaritmisk skalning**

Följande fristående exempel skapar ett linjediagram med de fem förfrågningsantalena på den första bilden, klonar sedan bilden och aktiverar en base‑10 logaritmisk värde‑axel på den andra. Båda bilderna behåller samma data.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Behåll den första bilden linjär och ändra bara kopians värdeaxelskala.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Linjär skala (bild 1):** Lika vertikala avstånd representerar lika skillnader i förfrågningsantal. Det största värdet dominerar diagrammet, vilket gör de mindre värdena svåra att skilja åt.

![Linjediagram i PowerPoint som visar fem förfrågningsantal på en linjär värde‑axel](value-axis-linear.png)

**Logaritmisk skala (bild 2):** Lika vertikala avstånd representerar lika förhållanden. Varje period har tio gånger så många förfrågningar som föregående, så punkterna bildar en rak stigande linje på base‑10‑skalan. Axel­etiketterna visar fortfarande de ursprungliga förfrågningsantalena.

![Samma fem förfrågningsantal i PowerPoint på en base‑10 logaritmisk värde‑axel](value-axis-logarithmic.png)

### **Hantera noll‑ och negativa värden**

En logaritmisk skala kan bara visa strikt positiva värden. Kontrollera data innan du aktiverar den. Om noll‑ eller negativa värden är meningsfulla, behåll en linjär skala eller visa dem separat. Om det är lämpligt att utesluta dessa värden för analysen, förklara borttagandet. Ersätt dem inte tyst med små positiva tal, eftersom detta ändrar datameningen. Alla manuellt konfigurerade minimum eller maximum för en logaritmisk axel måste också vara positiva.

## **FAQ**

**Hur anger jag värdet där en axel korsar den andra (axelkorsning)?**

Använd [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) för att välja korsningsbeteende. För att ange ett numeriskt korsningsvärde, sätt [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Dessa inställningar låter dig flytta axelkorsningen till en lämplig baslinje.

**Hur kan jag placera tick‑etiketter i förhållande till axeln?**

Ställ in [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) med [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` eller `NONE`. För att styra själva tick‑markeringarna, använd [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) eller [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); dessa är separata från etikett‑positioneringen.