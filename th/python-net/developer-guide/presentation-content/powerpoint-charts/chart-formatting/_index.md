---
title: จัดรูปแบบแผนภูมิในงานนำเสนอด้วย Python
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/python-net/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- วัตถุแผนภูมิ
- คุณสมบัติแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกแผนภูมิ
- คุณสมบัติตัวอักษร
- ขอบโค้ง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ Python ผ่าน .NET และยกระดับงานนำเสนอ PowerPoint หรือ OpenDocument ของคุณด้วยสไตล์มืออาชีพที่ดึงดูดความสนใจ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides แสดงวิธีการปรับแต่งองค์ประกอบสำคัญของแผนภูมิ เช่น แกน, เส้นกริด, ชื่อเรื่อง, คำอธิบาย, พื้นที่พล็อต, และการเติมผนังเพื่อปรับปรุงรูปลักษณ์และความอ่านง่ายของข้อมูลแผนภูมิ

บทความยังสาธิตวิธีการตั้งค่าคุณสมบัติตัวอักษรสำหรับข้อความในแผนภูมิ, การใช้รูปแบบตัวเลขที่ตั้งล่วงหน้าและกำหนดเองสำหรับข้อมูลแผนภูมิ, และการเปิดใช้งานมุมโค้งสำหรับพื้นที่แผนภูมิ ตัวอย่างเหล่านี้แสดงให้เห็นถึงการควบคุมทั้งสไตล์ภาพและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

## **จัดรูปแบบองค์ประกอบของแผนภูมิ**

Aspose.Slides for Python ช่วยให้นักพัฒนาสามารถเพิ่มแผนภูมิที่กำหนดเองลงในสไลด์ได้ตั้งแต่เริ่มต้น ส่วนนี้อธิบายวิธีการจัดรูปแบบองค์ประกอบแผนภูมิต่างๆ รวมถึงแกนหมวดหมู่และแกนค่า

Aspose.Slides มี API ที่ง่ายต่อการจัดการองค์ประกอบแผนภูมิและการใช้รูปแบบที่กำหนดเอง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นของชนิดที่ต้องการ (ในตัวอย่างนี้คือ `ChartType.LINE_WITH_MARKERS`)  
4. เข้าถึงแกนค่าของแผนภูมิและตั้งค่าดังต่อไปนี้:  
   1. ตั้งค่า **รูปแบบเส้น** สำหรับเส้นกริดหลักของแกนค่า  
   2. ตั้งค่า **รูปแบบเส้น** สำหรับเส้นกริดรองของแกนค่า  
   3. ตั้งค่า **รูปแบบตัวเลข** สำหรับแกนค่า  
   4. ตั้งค่า **ค่าสูงสุด, ต่ำสุด, หน่วยหลักและหน่วยรอง** สำหรับแกนค่า  
   5. ตั้งค่า **คุณสมบัติตัวอักษร** สำหรับป้ายกำกับแกนค่า  
   6. ตั้งค่า **ชื่อ** สำหรับแกนค่า  
   7. ตั้งค่า **รูปแบบเส้น** สำหรับแกนค่า  
5. เข้าถึงแกนหมวดหมู่ของแผนภูมิและตั้งค่าดังต่อไปนี้:  
   1. ตั้งค่า **รูปแบบเส้น** สำหรับเส้นกริดหลักของแกนหมวดหมู่  
   2. ตั้งค่า **รูปแบบเส้น** สำหรับเส้นกริดรองของแกนหมวดหมู่  
   3. ตั้งค่า **คุณสมบัติตัวอักษร** สำหรับป้ายกำกับแกนหมวดหมู่  
   4. ตั้งค่า **ชื่อ** สำหรับแกนหมวดหมู่  
   5. ตั้งค่า **ตำแหน่งป้ายกำกับ** สำหรับแกนหมวดหมู่  
   6. ตั้งค่า **มุมการหมุน** สำหรับป้ายกำกับแกนหมวดหมู่  
6. เข้าถึงคำอธิบายของแผนภูมิและตั้งค่า **คุณสมบัติตัวอักษร** ของมัน  
7. แสดงคำอธิบายของแผนภูมิโดยไม่ให้ทับซ้อนกับแผนภูมิ  
8. เข้าถึง **แกนค่ารอง** ของแผนภูมิและตั้งค่าดังต่อไปนี้:  
   1. เปิดใช้งาน **แกนค่ารอง**  
   2. ตั้งค่า **รูปแบบเส้น** สำหรับแกนค่ารอง  
   3. ตั้งค่า **รูปแบบตัวเลข** สำหรับแกนค่ารอง  
   4. ตั้งค่า **ค่าสูงสุด, ต่ำสุด, หน่วยหลักและหน่วยรอง** สำหรับแกนค่ารอง  
9. วางชุดข้อมูลแผนภูมิแรกบนแกนค่ารอง  
10. ตั้งค่าสีเติมพื้นผนังด้านหลังของแผนภูมิ  
11. ตั้งค่าสีเติมพื้นที่พล็อตของแผนภูมิ  
12. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มแผนภูมิตัวอย่าง.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # ตั้งค่าชื่อเรื่องของแผนภูมิ.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # ตั้งค่ารูปแบบเส้นกริดหลักสำหรับแกนค่า.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # ตั้งค่ารูปแบบเส้นกริดรองสำหรับแกนค่า.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # ตั้งค่ารูปแบบตัวเลขของแกนค่า.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # ตั้งค่าค่าสูงสุด, ต่ำสุด, หน่วยหลักและหน่วยรองของแกนค่า.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # ตั้งค่าคุณสมบัติตัวอักษรของแกนค่า.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # ตั้งค่าชื่อเรื่องของแกนค่า.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # ตั้งค่ารูปแบบเส้นกริดหลักสำหรับแกนหมวดหมู่.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # ตั้งค่ารูปแบบเส้นกริดรองสำหรับแกนหมวดหมู่.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # ตั้งค่าคุณสมบัติตัวอักษรของแกนหมวดหมู่.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # ตั้งค่าชื่อเรื่องของแกนหมวดหมู่.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # ตั้งค่าตำแหน่งป้ายกำกับของแกนหมวดหมู่.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # ตั้งค่ามุมการหมุนของป้ายกำกับแกนหมวดหมู่.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # ตั้งค่าคุณสมบัติตัวอักษรของคำอธิบาย.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # แสดงคำอธิบายแผนภูมิที่ทับซ้อนกับแผนภูมิ.
    chart.legend.overlay = True
                
    # ตั้งค่าสีผนังด้านหลังของแผนภูมิ.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # ตั้งค่าสีพื้นที่พล็อต.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # บันทึกการนำเสนอ.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าคุณสมบัติฟอนต์ของแผนภูมิ**

Aspose.Slides for Python รองรับการตั้งค่าคุณสมบัติเกี่ยวกับฟอนต์สำหรับแผนภูมิ ทำตามขั้นตอนด้านล่างเพื่อกำหนดคุณสมบัติฟอนต์ของแผนภูมิ:

1. สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. เพิ่มแผนภูมิลงในสไลด์  
3. ตั้งค่าความสูงของฟอนต์  
4. บันทึกการนำเสนอที่แก้ไขแล้ว  

ตัวอย่างโค้ดได้แสดงไว้ด้านล่าง  

```py
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

Aspose.Slides for Python มี API ที่ง่ายต่อการจัดการรูปแบบข้อมูลของแผนภูมิ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นของชนิดใดก็ได้ที่ต้องการ  
4. ตั้งค่ารูปแบบตัวเลขที่ตั้งล่วงหน้าจากค่าที่มีให้เลือก  
5. เดินทางผ่านเซลล์ข้อมูลของแต่ละชุดและตั้งค่ารูปแบบตัวเลข  
6. บันทึกการนำเสนอ  
7. ตั้งค่ารูปแบบตัวเลขที่กำหนดเอง  
8. เดินทางผ่านเซลล์ข้อมูลของแต่ละชุดและตั้งค่ารูปแบบตัวเลขที่แตกต่างกัน  
9. บันทึกการนำเสนอ  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มแผนภูมิคอลัมน์แบบกลุ่มเริ่มต้น.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # ตั้งค่ารูปแบบตัวเลขที่ตั้งล่วงหน้า.
    # วนลูปแต่ละชุดข้อมูลของแผนภูมิ.
    for series in chart.chart_data.series:
        # วนลูปแต่ละจุดข้อมูลในชุด.
        for cell in series.data_points:
            # ตั้งค่ารูปแบบตัวเลข.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # บันทึกการนำเสนอ.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

รูปแบบตัวเลขที่ตั้งล่วงหน้าที่มีให้เลือกและดัชนีที่สอดคล้องกันแสดงตารางด้านล่าง

|**0**|ทั่ว​ไป|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **ตั้งค่าขอบมนสำหรับพื้นที่แผนภูมิ**

Aspose.Slides for Python รองรับการกำหนดค่าพื้นที่แผนภูมิด้วยคุณสมบัติ `Chart.has_rounded_corners`

1. สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. เพิ่มแผนภูมิลงในสไลด์  
3. ตั้งค่าประเภทและสีเติมของแผนภูมิ  
4. ตั้งค่าคุณสมบัติมุมโค้งเป็น `True`  
5. บันทึกการนำเสนอที่แก้ไขแล้ว  

ตัวอย่างได้แสดงไว้ด้านล่าง  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าสีเติมกึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่โดยให้ขอบยังคงทึบได้หรือไม่?**

ได้ การตั้งค่าความโปร่งใสของการเติมและเส้นขอบจะทำแยกกัน ซึ่งเป็นประโยชน์ในการเพิ่มความอ่านง่ายของกริดและข้อมูลในภาพที่แน่นมาก

**ฉันจะจัดการกับป้ายข้อมูลเมื่อมันทับซ้อนได้อย่างไร?**

ลดขนาดฟอนต์, ปิดใช้งานส่วนประกอบของป้ายที่ไม่จำเป็น (เช่น หมวดหมู่), ตั้งค่าการย้าย/ตำแหน่งของป้าย, แสดงป้ายเฉพาะจุดที่เลือกถ้าจำเป็น, หรือเปลี่ยนรูปแบบเป็น “ค่า + คำอธิบาย”

**ฉันสามารถใช้การเติมแบบไล่สีหรือแบบลวดลายกับชุดข้อมูลได้หรือไม่?**

ได้ ทั้งการเติมแบบหนาแน่นและแบบไล่สี/ลวดลายมักจะพร้อมใช้งาน ในการปฏิบัติ ควรใช้ไล่สีอย่างจำกัดและหลีกเลี่ยงการผสมที่ทำให้ความคอนทราสต์กับกริดและข้อความลดลง