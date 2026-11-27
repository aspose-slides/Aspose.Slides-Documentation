---
title: การจัดรูปแบบแผนภูมิในงานนำเสนอโดยใช้ Python
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/python-net/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- เอนทิตีแผนภูมิ
- คุณสมบัติแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกแผนภูมิ
- คุณสมบัติแบบอักษร
- ขอบโค้ง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ Python ผ่าน .NET และยกระดับงานนำเสนอ PowerPoint ของคุณด้วยแกนที่กำหนดเอง, แบบอักษร, รูปแบบตัวเลข, และขอบแผนภูมิโค้ง."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint ด้วยการใช้ Aspose.Slides. มันแสดงวิธีปรับแต่งองค์ประกอบสำคัญของแผนภูมิ เช่น แกน, เส้นกริด, ชื่อเรื่อง, ค่าตัวอักษรอธิบาย, พื้นที่พล็อต, และการเติมผนังเพื่อปรับปรุงรูปลักษณ์และความอ่านง่ายของข้อมูลแผนภูมิ

นอกจากนี้ยังสาธิตวิธีตั้งค่าคุณสมบัติของแบบอักษรสำหรับข้อความในแผนภูมิ, ใช้รูปแบบตัวเลขที่กำหนดล่วงหน้าให้กับข้อมูลแผนภูมิ, และเปิดใช้งานมุมโค้งสำหรับพื้นที่แผนภูมิ. ตัวอย่างเหล่านี้แสดงวิธีควบคุมทั้งสไตล์การแสดงผลและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

สำหรับการเติมและขอบที่แยกกันในช่วงที่เพิ่มและลด, ดูที่ [ตัวอย่างแผนภูมิหุ้น](/slides/th/python-net/create-chart/#create-stock-charts)

## **จัดรูปแบบองค์ประกอบของแผนภูมิ**

ใช้ [แผนภูมิ](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) เพื่อจัดรูปแบบชื่อเรื่อง, แกน, เส้นกริด, ค่าตัวอักษรอธิบาย, และพื้นที่พล็อต. ตัวอย่างนี้สร้างแผนภูมิเส้นที่มีเครื่องหมายและข้อมูลเริ่มต้น, จากนั้นใช้สไตล์ข้อความและเส้นแยกต่างหากสำหรับแกนค่และแกนประเภท. ขนาดแบบอักษรและความกว้างเส้นระบุเป็นหน่วยจุด; ป้ายชื่อประเภทถูกหมุน 45 องศา.

แกนค่ใช้ [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) อย่างอิสระจากเซลล์ต้นทาง. ช่วงของแกนรันจาก -2 ถึง 15, โดยมีช่วงหลักที่ 2 และช่วงย่อยที่ 0.5. ตัวอย่างนี้ยังรวมการฟอร์แมตเปอร์เซ็นต์กับ [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) ที่ตั้งเป็นพัน, ดังนั้นให้ปรับตั้งค่าเหล่านี้ให้สอดคล้องกับความหมายและขนาดของข้อมูลของคุณ. ค่าตัวอักษรอธิบายอยู่ด้านนอกพื้นที่พล็อตเนื่องจาก [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) ถูกปิด. การเติมผนังด้านหลังและพื้นจัดการผ่าน [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) และ [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), แต่พื้นผิวเหล่านี้มองเห็นได้เฉพาะในแผนภูมิ 3D.

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

## **ตั้งค่าคุณสมบัติแบบอักษรสำหรับแผนภูมิ**

กำหนดขนาดแบบอักษรเริ่มต้นสำหรับข้อความแผนภูมิผ่าน [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มที่มีแบบอักษรขนาด 20 จุดและเปิดใช้งานป้ายค่าของซีรีส์แรกผ่าน [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). อิลิเมนต์ข้อความที่มีการตั้งค่าแบบอักษรของตนเองสามารถทับค่าดีฟอลต์ของแผนภูมิได้.

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

## **ใช้การจัดรูปแบบกรอบข้อความซ้ำสำหรับค่าตัวอักษรอธิบายของแผนภูมิ**

เพื่อให้ค่าตัวอักษรอธิบายตรงกับหัวข้อสไลด์, ตั้งค่าแบบอักษรผ่าน [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) ของย่อหน้าตัวแรกของหัวข้อ. เรียกใช้ [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) บน [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) ของค่าตัวอักษรอธิบาย. มันคัดลอกการตั้งค่ากรอบข้อความ, การจัดรูปแบบของย่อหน้าแรก, และคุณสมบัติแบบอักษรเริ่มต้นของย่อหน้านั้น. การจัดรูปแบบที่กำหนดโดยตรงให้กับส่วนย่อยแต่ละส่วนหรือให้กับย่อหน้าต่อ ๆ ไปจะคงอยู่เฉพาะแหล่งข้อมูลนั้น.

ตัวอย่างใช้หัวข้อที่เป็นตัวหนา, สีกรมทม, 26 จุด Calibri เป็นแม่แบบ. หลังจากสไตล์ค่าตัวอักษรอธิบาย, ตัวอย่างใช้ [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) เพื่อใช้การจัดรูปแบบเดียวกันกับคำอธิบายที่แยกออกมา.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

ในงานนำเสนอที่บันทึกแล้ว, ค่าตัวอักษรอธิบายและคำอธิบายตรงกับหัวข้อในด้านขนาด, ความหนา, และสี. ค่าตัวอักษรอธิบายยังคงแสดงชื่อซีรีส์, และคำอธิบายยังคงมีข้อความของตนเอง. หากส่วนหนึ่งในคำอธิบายมีขนาดแบบอักษรที่กำหนดไว้แล้ว, ขนาดนั้นจะมีลำดับความสำคัญเหนือค่าดีฟอลต์ของย่อหน้าที่คัดลอกมา.

| ก่อนคัดลอก | หลังคัดลอก |
| --- | --- |
| ![Quarterly sales chart with regular black legend labels and a black caption](legend-formatting-before.png) | ![The same chart with larger, bold navy legend labels and a matching caption](legend-formatting.png) |

## **ตั้งค่ารูปแบบตัวเลข**

ใช้ [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) เพื่อใช้รูปแบบตัวเลขที่สร้างไว้ล่วงหน้ากับเซลล์เวิร์กบุ๊กของแผนภูมิ. ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มที่ใช้ข้อมูลที่แบ็คด้วยเซลล์และใช้รูปแบบดัชนี 10 (`0.00%`) กับเซลล์ค่าของแต่ละซีรีส์. สิ่งนี้เปลี่ยนวิธีการแสดงค่าที่เวิร์กบุ๊กโดยไม่เปลี่ยนตัวเลขต้นฉบับ; ตัวอย่างเช่น 0.25 จะปรากฏเป็น 25.00%. รูปแบบแกนและป้ายข้อมูลสามารถกำหนดค่าแยกกันได้.

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

ตารางต่อไปนี้แสดงดัชนีรูปแบบตัวเลขที่สร้างไว้ล่วงหน้าพร้อมรูปแบบ Excel ตัวแทนสำหรับพื้นที่ภาษาอังกฤษ (สหรัฐอเมริกา). สตริงรูปแบบและการแสดงผลอาจแตกต่างตามแอปพลิเคชันและพื้นที่, โดยเฉพาะอย่างยิ่งสำหรับสกุลเงินและวันที่. รูปแบบ Excel บางอย่างยังแตกต่างจากค่าเริ่มต้นในมาตรฐาน OOXML, ดังที่อธิบายใน [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

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

เปิดใช้งาน [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) เพื่อทำให้มุมของพื้นที่แผนภูมิเป็นโค้ง. ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มและใช้ [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) เพื่อให้ขอบของมันเป็นสีเทาแบบทึบและสไตล์เส้นเดียวก่อนบันทึกงานนำเสนอ.

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

แผนภูมิสามารถมีรูปร่างที่กำหนดเองได้, เช่น คำอธิบายข้อความที่อธิบายสถานะของรายงาน. เข้าถึงรูปร่างเหล่านี้ผ่าน [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). คอลlektion [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) ของมันมีรูปร่างที่เป็นของแผนภูมิ.

กล่องข้อความธรรมดาที่วางเหนือแผนภูมิถือเป็นของสไลด์, แม้ว่ามันจะดูเหมือนเป็นส่วนหนึ่งของแผนภูมิ. การวนลูปผ่าน [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) จะพบแผนภูมิและรูปร่างสไลด์ทั่วไป, แต่จะไม่แสดงรูปร่างแต่ละอันภายในแผนภูมิ. ชื่อเรื่องแผนภูมิและป้ายข้อมูลเป็นองค์ประกอบแผนภูมิแยกต่างหาก, ไม่ใช่คำอธิบายกำหนดเองในคอลlektionนี้.

ดาวน์โหลด [chart-annotations.pptx](chart-annotations.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน. สไลด์แรกของไฟล์นี้มีแผนภูมิพร้อมคำอธิบายที่ไม่ได้รวมกลุ่มโดยมีข้อความ “Preliminary results”, เส้นที่เป็นของแผนภูมิ, และกล่องข้อความสไลด์ธรรมดาที่มีข้อความ “Slide overlay”. ตัวอย่างค้นหาแผนภูมิแรกบนสไลด์นั้นและเปลี่ยนคำอธิบายเป็น “Final results” เมื่อรายงานพร้อมเผยแพร่. มันตรวจสอบว่าคอลlektionว่างหรือไม่และแก้ไขเฉพาะ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ที่มี [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) ไม่เป็น `None` และมีข้อความตามที่คาดไว้.

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

เส้นและกล่องข้อความสไลด์ยังคงไม่เปลี่ยนแปลง. ภาพต่อไปนี้แสดงอินพุตและผลลัพธ์ที่บันทึกและเปิดใหม่อีกครั้ง:

| ก่อนแก้ไข | หลังแก้ไข |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
ตัวอย่างตรวจสอบเฉพาะรูปร่างระดับบนสุดที่เป็นของแผนภูมิ. หากคำอธิบายอยู่ภายใน [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), ตรวจสอบคอลlektion [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) ของกลุ่มนั้นด้วย. ทำซ้ำขั้นตอนนี้แบบเรียกซ้ำสำหรับกลุ่มที่ซ้อนกัน, ใช้การตรวจสอบข้อความเดียวกันกับรูปร่างลูกของพวกมัน. กลุ่มเองเป็นคอนเทนเนอร์; อย่าพิจารณาให้เป็นกล่องข้อความ.
{{% /alert %}}

## **FAQ**

**ฉันสามารถตั้งค่าการเติมกึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่โดยยังคงให้ขอบเป็นทึบได้หรือไม่?**

ได้. ความโปร่งใสของการเติมและขอบสามารถกำหนดค่าแยกกันได้ ซึ่งเป็นประโยชน์สำหรับการปรับปรุงความอ่านง่ายของกริดและข้อมูลในภาพที่ซับซ้อน.

**ฉันจะจัดการกับป้ายข้อมูลเมื่อมันทับกันอย่างไร?**

ลดขนาดแบบอักษร, ปิดการใช้งานส่วนประกอบของป้ายที่ไม่จำเป็น (เช่น ประเภท), ปรับตำแหน่งป้าย, แสดงป้ายเฉพาะจุดที่เลือกหากจำเป็น, หรือสลับรูปแบบเป็น “ค่า + คำอธิบาย”.

**ฉันสามารถใช้การเติมแบบไล่ระดับสีหรือแบบลายเส้นให้กับซีรีส์ได้หรือไม่?**

ได้. ซีรีส์รองรับการเติมแบบทึบ, ไล่ระดับสี, และลายเส้น. ในการปฏิบัติ, ใช้ไล่ระดับสีอย่างประหยัดและหลีกเลี่ยงการผสมผสานที่ลดความคอนทราสต์กับกริดและข้อความ.