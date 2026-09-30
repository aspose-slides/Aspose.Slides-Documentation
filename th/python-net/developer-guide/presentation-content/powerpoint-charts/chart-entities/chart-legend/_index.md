---
title: ปรับแต่งคำอธิบายภาพของแผนภูมิในงานนำเสนอด้วย Python
linktitle: คำอธิบายภาพแผนภูมิ
type: docs
url: /th/python-net/chart-legend/
keywords:
- คำอธิบายแผนภูมิ
- ตำแหน่งคำอธิบายภาพ
- ขนาดแบบอักษร
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ปรับแต่งคำอธิบายแผนภูมิด้วย Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อเพิ่มประสิทธิภาพงานนำเสนอ PowerPoint ด้วยการจัดรูปแบบคำอธิบายที่ปรับให้เหมาะเจาะ"
---
## **ภาพรวม**

Aspose.Slides for Python via .NET ให้ตัวเลือกในการปรับแต่งคำอธิบายภาพในงานนำเสนอ PowerPoint บทความนี้แสดงวิธีการกำหนดตำแหน่งและขนาดของคำอธิบายภาพ, ตั้งค่าขนาดแบบอักษรสำหรับคำอธิบายภาพทั้งหมด, จัดรูปแบบรายการคำอธิบายภาพแบบแยกเดี่ยว, และซ่อนหรือกู้คืนรายการที่เลือก

FAQ ครอบคลุมพฤติกรรมที่เกี่ยวข้อง รวมถึงการสำรองพื้นที่สำหรับคำอธิบายภาพ, การแสดงป้ายหลายบรรทัด, และการสืบทอดการจัดรูปแบบจากธีมของงานนำเสนอ

## **การกำหนดตำแหน่งคำอธิบายภาพ**

ใช้คุณสมบัติ [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/), และ [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) ของคำอธิบายภาพเพื่อระบุตำแหน่งและขนาดของมันเป็นส่วนสัดส่วนของมิติของแผนภูมิ

ตัวอย่างนี้สร้างงานนำเสนอและเพิ่มแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลเริ่มต้นลงในสไลด์แรก การหารค่าออฟเซ็ตและมิติต้องการของคำอธิบายภาพด้วยความกว้างและความสูงของแผนภูมิเพื่อแปลงเป็นค่าที่สัมพันธ์กัน: คำอธิบายภาพถูกเลื่อนออกจากมุมซ้ายบนของแผนภูมิ 50 จุดและมีขนาด 100x100 จุด

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # แสดงตำแหน่งและขนาดของคำอธิบายภาพสัมพันธ์กับแผนภูมิ
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าขนาดแบบอักษรของคำอธิบายภาพ**

ใช้ [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) ของคำอธิบายภาพเพื่อเข้าถึงการจัดรูปแบบข้อความและตั้งค่า [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) เป็นจุด

ตัวอย่างนี้สร้างแผนภูมิกับข้อมูลเริ่มต้นและตั้งค่าข้อความของคำอธิบายภาพเป็น 20 จุด นอกจากนี้ยังปิดการกำหนดขอบอัตโนมัติสำหรับแกนตั้งและตั้งช่วงเป็น -5 ถึง 10

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าขนาดแบบอักษรของรายการคำอธิบายภาพเดี่ยว**

ใช้คอลเลกชัน [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) ของคำอธิบายภาพเพื่อเข้าถึงการจัดรูปแบบของรายการเฉพาะ ดัชนีของรายการเริ่มจากศูนย์ ดังนั้นดัชนี `1` หมายถึงรายการที่สอง

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มที่ข้อมูลเริ่มต้นมีอย่างน้อยสองชุดข้อมูล มันจัดรูปแบบรายการคำอธิบายภาพที่สองด้วยตัวหนา, ตัวเอียง, และข้อความสีน้ำเงินขนาด 20 จุด

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **ซ่อนรายการคำอธิบายภาพเดี่ยว**

เพื่อลบชุดข้อมูลเสริมออกจากคำอธิบายภาพในขณะที่ยังคงให้ข้อมูลมองเห็นได้ ให้ตั้งค่า [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) เป็น `True` ผ่าน [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). การทำเช่นนี้จะซ่อนเฉพาะรายการคำอธิบายภาพที่เลือก; ไม่ได้ลบชุดข้อมูลหรือจุดข้อมูลของมัน การตั้งค่า [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) เป็น `False` จะซ่อนคำอธิบายภาพทั้งหมด

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบกลุ่มที่มีหลายชุดข้อมูลโดยใช้ข้อมูลเริ่มต้น มันซ่อนรายการคำอธิบายภาพของชุดข้อมูลที่สอง (ดัชนี `1`) แล้วบันทึกงานนำเสนอ จากนั้นกู้คืนรายการโดยตั้งค่า [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) เป็น `False` และบันทึกสำเนาที่สอง คอลัมน์ยังคงมองเห็นได้ในทั้งสองไฟล์

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # กู้คืนรายการเดียวกันโดยไม่เปลี่ยนแปลงข้อมูลแผนภูมิ.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

การเปรียบเทียบด้านล่างแสดงแผนภูมิเดียวกันที่มีรายการทั้งหมดมองเห็นและรายการที่สองถูกซ่อน คอลัมน์ของชุดข้อมูลที่สองยังคงไม่มีการเปลี่ยนแปลง

![เปรียบเทียบแผนภูมิที่มีรายการคำอธิบายภาพทั้งหมดมองเห็นและรายการ Series 2 ถูกซ่อนจากคำอธิบายภาพ; คอลัมน์ทั้งหมดยังคงมองเห็นได้.](hide-legend-entry.png)

ในแผนภูมิคอลัมน์, แถบ, และเส้น, รายการคำอธิบายภาพระบุชุดข้อมูล สำหรับแผนภูมิวงกลม, พวกมันระบุจุดข้อมูลแต่ละจุด (ส่วน), ดังนั้นควรใช้ [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) กับส่วนที่เลือกแทน แฟ้ม API ระบุคุณสมบัติจุดข้อมูลนี้สำหรับประเภทแผนภูมิ `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE`, และ `BAR_OF_PIE` อย่าสันนิษฐานว่ามันใช้กับแผนภูมโดนัท ซึ่งไม่ได้รวมอยู่ในรายการนั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถทำให้แผนภูมิสำรองพื้นที่ให้กับคำอธิบายภาพแทนการทับซ้อนได้หรือไม่?**

ได้ ใช้การตั้งค่า [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) เป็น `False` เพื่อสำรองพื้นที่ให้กับคำอธิบายภาพแทนการให้มันทับพื้นที่พล็อต

**ฉันสามารถทำให้ป้ายคำอธิบายภาพหลายบรรทัดได้หรือไม่?**

ได้ ป้ายที่ยาวสามารถห่อได้เมื่อความกว้างที่มีไม่พอ คุณยังสามารถใช้อักขระขึ้นบรรทัดใหม่ในชื่อชุดข้อมูลเพื่อขอการขึ้นบรรทัด

**ฉันจะทำให้คำอธิบายภาพตามสไลด์ธีมสีของงานนำเสนออย่างไร?**

ปล่อยให้สี, การเติม, และแบบอักษรของคำอธิบายภาพไม่ได้กำหนดค่า เพื่อให้มันสืบทอดการจัดรูปแบบจากธีม การจัดรูปแบบอย่างชัดเจนจะเขียนทับการตั้งค่าธีมที่สอดคล้อง