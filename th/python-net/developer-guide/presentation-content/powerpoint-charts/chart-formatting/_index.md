---
title: "จัดรูปแบบแผนภูมิในงานนำเสนอโดยใช้ Python"
linktitle: "การจัดรูปแบบแผนภูมิ"
type: docs
weight: 60
url: /th/python-net/chart-formatting/
keywords:
- "จัดรูปแบบแผนภูมิ"
- "การจัดรูปแบบแผนภูมิ"
- "องค์ประกอบแผนภูมิ"
- "คุณสมบัติแผนภูมิ"
- "การตั้งค่าแผนภูมิ"
- "ตัวเลือกแผนภูมิ"
- "คุณสมบัติฟอนต์"
- "ขอบโค้ง"
- PowerPoint
- "การนำเสนอ"
- Python
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ Python ผ่าน .NET และยกระดับการนำเสนอ PowerPoint ของคุณด้วยแกนที่กำหนดเอง, ฟอนต์, รูปแบบตัวเลข, และขอบแผนภูมิที่โค้งมน."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดรูปแบบแผนภูมิในการนำเสนอ PowerPoint โดยใช้ Aspose.Slides แสดงวิธีปรับแต่งองค์ประกอบหลักของแผนภูมิ เช่น แกน, เส้นกริด, ชื่อ, คำอธิบาย, พื้นที่พล็อต, และการเติมผนัง เพื่อปรับปรุงรูปลักษณ์และความอ่านง่ายของข้อมูลแผนภูมิ  
มันยังแสดงวิธีตั้งค่าแอตทริบิวต์ฟอนต์สำหรับข้อความในแผนภูมิ, นำรูปแบบตัวเลขที่กำหนดล่วงหน้าไปใช้กับข้อมูลแผนภูมิ, และเปิดใช้งานมุมโค้งสำหรับพื้นที่แผนภูมิ ตัวอย่างเหล่านี้ร่วมกันแสดงวิธีควบคุมทั้งสไตล์ภาพและการนำเสนอข้อมูลของแผนภูมิในการนำเสนอ

## **จัดรูปแบบองค์ประกอบของแผนภูมิ**

ใช้ [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) เพื่อจัดรูปแบบชื่อแผนภูมิ, แกน, เส้นกริด, คำอธิบาย, และพื้นที่พล็อต ตัวอย่างนี้สร้างแผนภูมิเส้นพร้อมเครื่องหมายและข้อมูลค่าเริ่มต้น, จากนั้นใช้สไตล์ข้อความและเส้นแยกต่างหากสำหรับแกนค่และแกนประเภท ขนาดฟอนต์และความกว้างของเส้นระบุเป็นจุด; ป้ายชื่อประเภทถูกหมุน 45 องศา  

แกนค่าใช้ [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) อย่างอิสระจากเซลล์ต้นทาง มาตราส่วนของมันเริ่มจาก -2 ถึง 15 โดยช่วงหลักที่ 2 และช่วงรองที่ 0.5 ตัวอย่างนี้ยังผสมการจัดรูปแบบเปอร์เซ็นต์กับ [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) ตั้งเป็นพัน ดังนั้นปรับการตั้งค่าเหล่านี้ให้สอดคล้องกับความหมายและขนาดของข้อมูลของคุณ คำอธิบายอยู่ด้านนอกพื้นที่พล็อตเนื่องจาก [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) ถูกปิดใช้งาน การเติมผนังหลังและพื้นกำหนดผ่าน [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) และ [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), แต่พื้นผิวเหล่านี้จะมองเห็นได้เฉพาะในแผนภูมิ 3 มิติ

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าแอตทริบิวต์ฟอนต์สำหรับแผนภูมิ**

ตั้งค่าขนาดฟอนต์เริ่มต้นสำหรับข้อความแผนภูมิผ่าน [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มพร้อมฟอนต์ขนาด 20 จุดและเปิดใช้งานป้ายค่สำหรับชุดแรกผ่าน [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). ส่วนประกอบข้อความที่มีการตั้งค่าฟอนต์เฉพาะของตัวเองสามารถทับค่าตั้งต้นของแผนภูมิได้

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่ารูปแบบตัวเลข**

ใช้ [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) เพื่อใช้รูปแบบตัวเลขที่มีมาในตัวกับเซลล์เวิร์กบุ๊กของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลค่าเริ่มต้นที่มาจากเซลล์และกำหนดรูปแบบดัชนี 10 (`0.00%`) ให้กับเซลล์ค่าของแต่ละชุด การนี้ทำให้การแสดงค่าต่างๆ ในเวิร์กบุ๊กเปลี่ยนโดยไม่แก้เลขฐาน; ตัวอย่างเช่น 0.25 จะแสดงเป็น 25.00% รูปแบบของแกนและป้ายข้อมูลสามารถกำหนดแยกกันได้

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

ตารางต่อไปนี้แสดงดัชนีรูปแบบตัวเลขที่มีมาในตัวพร้อมรูปแบบ Excel ตัวอย่างสำหรับภูมิภาคอังกฤษ (สหรัฐอเมริกา) รูปแบบสตริงที่แน่นอนและการแสดงผลอาจแตกต่างตามแอปพลิเคชันและภูมิภาค โดยเฉพาะสำหรับสกุลเงินและวันที่ บางรูปแบบ Excel ยังแตกต่างจากค่าเริ่มต้นในมาตรฐาน OOXML ตามที่อธิบายใน [บันทึกอธิบายรูปแบบตัวเลขของ Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| ดัชนี | รูปแบบ |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **ตั้งค่าขอบโค้งของพื้นที่แผนภูมิ**

เปิดใช้งาน [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) เพื่อทำให้มุมของพื้นที่แผนภูมิเป็นมุมโค้ง ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มและใช้ [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) เพื่อกำหนดเส้นขอบเป็นสีเทาแบบทึบและสไตล์เส้นเดียวก่อนบันทึกการนำเสนอ

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **แก้ไขคำอธิบายแผนภูมิที่มีอยู่**

แผนภูมิสามารถมีรูปร่างที่กำหนดเอง เช่น คำอธิบายข้อความที่อธิบายสถานะของรายงาน เข้าถึงรูปร่างเหล่านี้ผ่าน [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). คอลเลกชัน [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) ของมันประกอบด้วยรูปร่างที่เป็นของแผนภูมิ  

กล่องข้อความทั่วไปที่วางเหนือแผนภูมิเป็นของสไลด์ แม้ว่าจะดูเหมือนเป็นส่วนของแผนภูมิ การวนผ่าน [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) จะพบแผนภูมิและรูปร่างสไลด์ทั่วไป แต่ไม่ได้แสดงรายการรูปร่างย่อยภายในแผนภูมิ ชื่อแผนภูมิและป้ายข้อมูลเป็นองค์ประกอบแผนภูมิแยกจากกัน ไม่ใช่คำอธิบายที่กำหนดเองในคอลเลกชันนี้  

ดาวน์โหลด [chart-annotations.pptx](chart-annotations.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกของมันมีแผนภูมิพร้อมคำอธิบายที่ไม่ได้จัดกลุ่มที่เขียนว่า "Preliminary results", เส้นที่เป็นของแผนภูมิ, และกล่องข้อความสไลด์ทั่วไปที่เขียนว่า "Slide overlay". ตัวอย่างจะค้นหาแผนภูมิแรกบนสไลด์นั้นและเปลี่ยนคำอธิบายเป็น "Final results" เมื่อรายงานพร้อมเผยแพร่ จะตรวจสอบคอลเลกชันที่ว่างและแก้ไขเฉพาะ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ที่มี [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) ที่ไม่เป็น `None` และมีข้อความตามที่คาดหวัง

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

เส้นและกล่องข้อความสไลด์ยังคงไม่เปลี่ยนแปลง. ภาพต่อไปนี้แสดงอินพุตและผลลัพธ์ที่บันทึกแล้วเปิดใหม่:

| ก่อนแก้ไข | หลังแก้ไข |
| --- | --- |
| ![คำอธิบายแผนภูมิอ่าน Preliminary results](chart-annotations-before.png) | ![คำอธิบายแผนภูมิอ่าน Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
ตัวอย่างตรวจสอบเฉพาะรูปร่างระดับบนสุดที่เป็นของแผนภูมิ หากคำอธิบายอยู่ภายใน [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/) ให้ตรวจสอบคอลเลกชัน [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) ของกลุ่มนั้นด้วย ทำซ้ำแบบเรียกซ้ำสำหรับกลุ่มซ้อนกัน และใช้การตรวจสอบข้อความเดียวกันกับรูปร่างลูกของพวกมัน กลุ่มเองเป็นคอนเทนเนอร์; อย่าปฏิบัติมันเป็นกล่องข้อความ
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าสีเติมกึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่ในขณะที่ยังคงให้ขอบทึบได้หรือไม่?**  
ใช่ ความโปร่งใสของการเติมและเส้นขอบกำหนดแยกกัน นี่เป็นประโยชน์ในการปรับปรุงความอ่านง่ายของกริดและข้อมูลในภาพที่มีความหนาแน่นสูง  

**ฉันจะจัดการกับป้ายข้อมูลเมื่อมันทับซ้อนกันได้อย่างไร?**  
ลดขนาดฟอนต์, ปิดใช้งานส่วนประกอบของป้ายที่ไม่จำเป็น (เช่น หมวดหมู่), ปรับตำแหน่งป้าย, แสดงป้ายเฉพาะจุดที่เลือกหากจำเป็น, หรือเปลี่ยนรูปแบบเป็น "value + legend"  

**ฉันสามารถใช้การเติมแบบไล่สีหรือแบบลายเส้นกับชุดข้อมูลได้หรือไม่?**  
ใช่ ชุดข้อมูลรองรับการเติมแบบทึบ, ไล่สี, และลายเส้น ในการใช้งานจริงให้ใช้ไล่สีอย่างจำกัดและหลีกเลี่ยงการผสมที่ทำให้ความคอนทราสต์กับกริดและข้อความลดลง