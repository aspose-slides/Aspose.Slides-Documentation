---
title: จัดการ Callout ในแผนภูมิการนำเสนอด้วย Python
linktitle: การอธิบาย
type: docs
url: /th/python-java/callout/
keywords:
- การอธิบายแผนภูมิ
- ใช้การอธิบาย
- ป้ายข้อมูล
- รูปแบบป้าย
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างและจัดรูปแบบการอธิบายใน Aspose.Slides สำหรับ Python ผ่าน Java ด้วยตัวอย่างโค้ดสั้น ๆ ที่รองรับไฟล์ PPT และ PPTX เพื่ออัตโนมัติการทำงานของการนำเสนอ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับ Callout สำหรับป้ายชื่อข้อมูลของแผนภูมิใน Aspose.Slides แสดงวิธีใช้เมธอด [setShowLabelAsDataCallout](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) เพื่อนำป้ายชื่อแสดงเป็น Callout วิธีกำหนดค่าการตั้งค่าป้ายชื่อที่เกี่ยวข้องกับ Callout สำหรับแผนภูมิ Doughnut และบันทึกว่าการ Callout และลักษณะการแสดงผลของมันจะถูกเก็บไว้เมื่อนำเสนอออกเป็น PDF, HTML5, SVG และรูปแบบภาพเรสเตอร์

## **การใช้ Callout**

เมธอด [getShowLabelAsDataCallout](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) และ [setShowLabelAsDataCallout](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) ของคลาส [DataLabelFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabelformat/) กำหนดว่าป้ายชื่อข้อมูลของแผนภูมิจะแสดงเป็น Callout หรือเป็นป้ายชื่อข้อมูลทั่วไป

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400)
    labels = chart.getChartData().getSeries().get_Item(0).getLabels()
    default_label_format = labels.getDefaultDataLabelFormat()
    default_label_format.setShowValue(True)
    default_label_format.setShowLabelAsDataCallout(True)
    labels.get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(False)

    presentation.save("DisplayCharts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่า Callout สำหรับแผนภูมิ Doughnut**

Aspose.Slides for Python via Java รองรับการตั้งค่ารูปแบบ Callout ของป้ายชื่อข้อมูลซีรีส์สำหรับแผนภูมิ Doughnut ตัวอย่างต่อไปนี้แสดงวิธีทำ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat, TextAutofitType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, False)
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(False)

    for series_index in range(15):
        series_cell = workbook.getCell(0, 0, series_index + 1, f"SERIES {series_index}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        series.setExplosion(0)
        series.getParentSeriesGroup().setDoughnutHoleSize(jpype.JByte(20))
        series.getParentSeriesGroup().setFirstSliceAngle(351)

    for category_index in range(15):
        category_cell = workbook.getCell(0, category_index + 1, 0, f"CATEGORY {category_index}")
        chart.getChartData().getCategories().add(category_cell)
        for i in range(chart.getChartData().getSeries().size()):
            series = chart.getChartData().getSeries().get_Item(i)
            data_cell = workbook.getCell(0, category_index + 1, i + 1, jpype.JInt(1))
            data_point = series.getDataPoints().addDataPointForDoughnutSeries(data_cell)
            data_point.getFormat().getFill().setFillType(FillType.Solid)
            line_format = data_point.getFormat().getLine()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)
            line_format.setWidth(1)
            line_format.setStyle(LineStyle.Single)
            line_format.setDashStyle(LineDashStyle.Solid)
            if i == chart.getChartData().getSeries().size() - 1:
                label = data_point.getLabel()
                label.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape)
                label_format = label.getDataLabelFormat()
                portion_format = label_format.getTextFormat().getPortionFormat()
                portion_format.setFontBold(NullableBool.True_)
                font = FontData("DINPro-Bold")
                portion_format.setLatinFont(font)
                portion_format.setFontHeight(12)
                portion_format.getFillFormat().setFillType(FillType.Solid)
                portion_format.getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)
                label_format.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.WHITE)
                label_format.setShowValue(False)
                label_format.setShowCategoryName(True)
                label_format.setShowSeriesName(False)
                label_format.setShowLeaderLines(True)
                label_format.setShowLabelAsDataCallout(False)
                chart.validateChartLayout()
                label.setX(label.getX() + 0.5)
                label.setY(label.getY() + 0.5)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**การ Callout จะถูกเก็บรักษาไว้เมื่อตัวแปลงการนำเสนอเป็น PDF, HTML5, SVG หรือภาพหรือไม่?**

ใช่. Callout เป็นส่วนหนึ่งของการเรนเดอร์แผนภูมิ ดังนั้นเมื่อคุณส่งออกเป็น [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/th/python-java/export-to-html5/), [SVG](/slides/th/python-java/render-a-slide-as-an-svg-image/), หรือ [raster images](/slides/th/python-java/convert-powerpoint-to-png/), พวกมันจะถูกเก็บรักษาพร้อมกับการจัดรูปแบบของสไลด์

**ฟอนต์ที่กำหนดเองทำงานใน Callout หรือไม่ และลักษณะการแสดงผลสามารถถูกเก็บรักษาในการส่งออกได้หรือไม่?**

ใช่. Aspose.Slides รองรับการ [embedding fonts](/slides/th/python-java/embedded-font/) ลงในงานนำเสนอและควบคุมการฝังฟอนต์ระหว่างการส่งออกเช่น [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/), ทำให้ Callout มีลักษณะเดียวกันบนระบบต่าง ๆ