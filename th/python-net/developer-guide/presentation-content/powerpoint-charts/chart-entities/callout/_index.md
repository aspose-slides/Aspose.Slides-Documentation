---
title: จัดการคอลเอาต์ในแผนภูมิการนำเสนอด้วย Python
linktitle: คอลเอาต์
type: docs
url: /th/python-net/callout/
keywords:
- แผนภูมิคอลเอาต์
- ใช้คอลเอาต์
- ป้ายข้อมูล
- รูปแบบป้าย
- Python
- Aspose.Slides
description: "สร้างและกำหนดสไตล์คอลเอาต์ใน Aspose.Slides สำหรับ Python .NET ด้วยตัวอย่างโค้ดที่กระชับ, รองรับไฟล์ PPT, PPTX และ ODP เพื่ออัตโนมัติขั้นตอนการทำงานของการนำเสนอ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับการเรียกเส้นแสดงข้อมูล (callouts) สำหรับป้ายข้อมูลของแผนภูมิใน Aspose.Slides แสดงวิธีใช้คุณสมบัติ `show_label_as_data_callout` เพื่อแสดงป้ายเป็น callout วิธีกำหนดค่าการตั้งค่าป้ายที่เกี่ยวกับ callout สำหรับแผนภูมิแบบโดนัท และระบุว่า callout และลักษณะที่ปรากฏของมันจะถูกเก็บรักษาไว้เมื่อการนำเสนอถูกส่งออกเป็น PDF, HTML5, SVG และรูปแบบภาพแบบราสเตอร์

## **การใช้ Callouts**
คุณสมบัติใหม่ **show_label_as_data_callout** ได้ถูกเพิ่มเข้าไปในคลาส **DataLabelFormat** ซึ่งกำหนดว่าป้ายข้อมูลของแผนภูมิที่ระบุจะถูกแสดงเป็น data callout หรือเป็นป้ายข้อมูลทั่วไป ในตัวอย่างที่ให้ด้านล่าง เราได้ตั้งค่า Callouts ไว้แล้ว

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่า Callout สำหรับแผนภูมิ Doughnut**
Aspose.Slides for Python via .NET มีการสนับสนุนการตั้งรูปแบบ callout ของป้ายข้อมูลซีรีส์สำหรับแผนภูมิ Doughnut ตัวอย่างต่อไปนี้ได้ถูกจัดทำขึ้น

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.DOUGHNUT, 10, 10, 500, 500, False)
    workBook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = False
    seriesIndex = 0
    while seriesIndex < 15:
        series = chart.chart_data.series.add(workBook.get_cell(0, 0, seriesIndex + 1, "SERIES " + str(seriesIndex)), chart.type)
        series.explosion = 0
        series.parent_series_group.doughnut_hole_size = 20
        series.parent_series_group.first_slice_angle = 351
        seriesIndex += 1
    categoryIndex = 0
    while categoryIndex < 15:
        chart.chart_data.categories.add(workBook.get_cell(0, categoryIndex + 1, 0, "CATEGORY " + str(categoryIndex)))
        i = 0
        while i < len(chart.chart_data.series):
            iCS = chart.chart_data.series[i]
            dataPoint = iCS.data_points.add_data_point_for_doughnut_series(workBook.get_cell(0, categoryIndex + 1, i + 1, 1))
            dataPoint.format.fill.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.solid_fill_color.color = draw.Color.white
            dataPoint.format.line.width = 1
            dataPoint.format.line.style = slides.LineStyle.SINGLE
            dataPoint.format.line.dash_style = slides.LineDashStyle.SOLID
            if i == len(chart.chart_data.series) - 1:
                lbl = dataPoint.label
                lbl.text_format.text_block_format.autofit_type = slides.TextAutofitType.SHAPE
                lbl.data_label_format.text_format.portion_format.font_bold = 1
                lbl.data_label_format.text_format.portion_format.latin_font = slides.FontData("DINPro-Bold")
                lbl.data_label_format.text_format.portion_format.font_height = 12
                lbl.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
                lbl.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.light_gray
                lbl.data_label_format.format.line.fill_format.solid_fill_color.color = draw.Color.white
                lbl.data_label_format.show_value = False
                lbl.data_label_format.show_category_name = True
                lbl.data_label_format.show_series_name = False
                lbl.data_label_format.show_leader_lines = True
                lbl.data_label_format.show_label_as_data_callout = False
                chart.validate_chart_layout()
                lbl.as_i_layoutable.x += 0.5
                lbl.as_i_layoutable.y += 0.5
            i += 1
        categoryIndex +=1 
    pres.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**Callouts จะถูกเก็บรักษาไว้เมื่อแปลงการนำเสนอเป็น PDF, HTML5, SVG หรือรูปภาพหรือไม่?**

ใช่. Callouts เป็นส่วนหนึ่งของการเรนเดอร์แผนภูมิ ดังนั้นเมื่อคุณส่งออกเป็น [PDF](/slides/th/python-net/convert-powerpoint-to-pdf/), [HTML5](/slides/th/python-net/export-to-html5/), [SVG](/slides/th/python-net/render-a-slide-as-an-svg-image/), หรือ [raster images](/slides/th/python-net/convert-powerpoint-to-png/), พวกมันจะถูกเก็บรักษาร่วมกับการจัดรูปแบบของสไลด์

**ฟอนต์ที่กำหนดเองทำงานใน callouts ได้หรือไม่ และลักษณะที่ปรากฏของมันสามารถถูกเก็บรักษาไว้เมื่อส่งออกได้หรือไม่?**

ใช่. Aspose.Slides รองรับการ [embedding fonts](/slides/th/python-net/embedded-font/) เข้าไปในการนำเสนอและควบคุมการฝังฟอนต์ในระหว่างการส่งออก เช่น [PDF](/slides/th/python-net/convert-powerpoint-to-pdf/), เพื่อให้แน่ใจว่า callouts จะดูเหมือนเดิมในระบบต่าง ๆ