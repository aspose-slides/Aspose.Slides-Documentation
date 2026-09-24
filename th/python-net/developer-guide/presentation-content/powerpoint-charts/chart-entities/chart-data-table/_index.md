---
title: ปรับแต่งตารางข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ตารางข้อมูล
type: docs
url: /th/python-net/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติฟอนต์
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "ปรับแต่งฟอนต์, เส้นขอบ, และคีย์คำอธิบายของตารางข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET ให้คุณแสดงตารางข้อมูลของแผนภูมิและปรับแต่งการจัดรูปแบบข้อความ, เส้นขอบ, และคีย์คำอธิบายของตาราง โดยบทความนี้จะอธิบายวิธีเปิดใช้งานตาราง, จัดรูปแบบข้อความ, ควบคุมแต่ละประเภทของเส้นขอบ, และแสดงหรือซ่อนคีย์คำอธิบาย ตัวอย่างจะบันทึกแผนภูมิที่กำหนดค่าไว้เป็นไฟล์ PPTX

## **ตั้งค่าคุณสมบัติแบบอักษร**

เพื่อแสดงตารางข้อมูลของแผนภูมิ, ตั้งค่า [has_data_table](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/has_data_table/) เป็น `True`. ใช้ [chart_data_table](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/chart_data_table/) เพื่อเข้าถึงตารางและกำหนดการจัดรูปแบบข้อความ

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เพิ่มแผนภูมิคอลัมน์แบบจัดกลุ่มในสไลด์แรก
1. เปิดใช้งานตารางข้อมูลของแผนภูมิ
1. เปิดใช้งานข้อความหนาด้วย [font_bold](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/font_bold/) และตั้งค่า [font_height](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseportionformat/font_height/) เป็น `20` สำหรับข้อความขนาด 20 จุด
1. บันทึกงานนำเสนอที่ถูกแก้ไข

ตัวอย่างต่อไปนี้ต้องมีไฟล์ `test.pptx` อยู่ในไดเรกทอรีทำงานพร้อมสไลด์อย่างน้อยหนึ่งสไลด์ โดยจะเพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นที่ตำแหน่ง (50, 50) ความกว้าง 600 จุดและความสูง 400 จุด ไฟล์ `output.pptx` ที่บันทึกไว้จะมีแผนภูมิพร้อมตารางข้อมูลที่เปิดใช้งานและตั้งค่าฟอนต์ตามที่ระบุ

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ปรับแต่งเส้นขอบตารางข้อมูล**

เปิดใช้งานตารางด้วย [Chart.has_data_table](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/has_data_table/) และเข้าถึงมันผ่าน [Chart.chart_data_table](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/chart_data_table/). คุณสามารถควบคุมเส้นขอบสามประเภทแยกกันได้:

- [has_border_horizontal](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datatable/has_border_horizontal/) ควบคุมเส้นขอบแนวนอนของเซลล์
- [has_border_vertical](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datatable/has_border_vertical/) ควบคุมเส้นขอบแนวตั้งของเซลล์
- [has_border_outline](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datatable/has_border_outline/) ควบคุมเส้นขอบภายนอกของตาราง

ตั้งค่าคุณสมบัติเหล่านี้เป็น `True` เพื่อแสดงเส้นขอบหรือ `False` เพื่อซ่อนเส้นขอบ ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์แบบจัดกลุ่มพร้อมข้อมูลเริ่มต้น, แสดงเส้นขอบแนวนอนและเส้นขอบภายนอก, และซ่อนเส้นขอบแนวตั้ง ไม่ต้องใช้ไฟล์อินพุตใด ๆ ตำแหน่งและขนาดของแผนภูมิระบุเป็นจุด

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

การเปรียบเทียบด้านล่างใช้ข้อมูลแผนภูมิและการตั้งค่าคีย์คำอธิบายเดียวกันในทั้งหมดสี่กรณี เริ่มจากเปิดใช้งานเส้นขอบทั้งหมด, แต่ละตัวแปรที่เหลือจะปิดใช้งานคุณสมบัติเส้นขอบเพียงหนึ่งประเภท เท่าไหร่ด้านซ้ายล่างจะตรงกับการตั้งค่าเส้นขอบในตัวอย่าง

![แผนภูมิตารางข้อมูลที่เปิดใช้งานเส้นขอบทั้งหมด, ไม่มีเส้นขอบแนวนอน, ไม่มีเส้นขอบแนวตั้ง, และไม่มีเส้นขอบภายนอก](data-table-borders.png)

## **แสดงหรือซ่อนคีย์คำอธิบาย**

คีย์คำอธิบายคือสัญลักษณ์สีเล็ก ๆ ที่อยู่ถัดจากชื่อซีรีส์ในตารางข้อมูล ช่วยให้ผู้อ่านจับคู่แต่ละแถวของตารางกับซีรีส์ในแผนภูมิได้ ตั้งค่า [show_legend_key](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datatable/show_legend_key/) เป็น `True` เพื่อแสดงสัญลักษณ์เหล่านี้หรือ `False` เพื่อซ่อน

Legend แยกของแผนภูมิควบคุมโดย [Chart.has_legend](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/has_legend/). การตั้งค่าเหล่านี้เป็นอิสระต่อกัน: การซ่อน Legend แยกไม่ทำให้คีย์ภายในตารางข้อมูลหายไป, และการซ่อนคีย์ในตารางก็ไม่ทำให้ Legend แยกหายไป

ตัวอย่างต่อไปนี้สร้างแผนภูมิพร้อมข้อมูลเริ่มต้น, เปิดใช้งานตารางข้อมูล, และแสดงคีย์คำอธิบายในตารางในขณะที่ซ่อน Legend แยก เส้นขอบของตารางทั้งหมดถูกเปิดใช้งานอย่างชัดเจน ไม่จำเป็นต้องมีงานนำเสนออินพุต หากต้องการซ่อนคีย์ของตารางเท่านั้น ให้เปลี่ยน `data_table.show_legend_key` เป็น `False`

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

การเปรียบเทียบด้านล่างแสดงตารางเดียวกันที่เปิดและปิดคีย์คำอธิบาย เส้นขอบทั้งหมดยังคงเปิดอยู่และ Legend แยกของแผนภูมิก็ถูกซ่อนในทั้งสองกรณี

![แผนภูมิตารางข้อมูลที่แสดงคีย์คำอธิบายทางซ้ายและซ่อนคีย์ทางขวา](data-table-legend-keys.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงคีย์คำอธิบายในตารางข้อมูลของแผนภูมิได้หรือไม่?**

ใช่. ตั้งค่า [show_legend_key](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datatable/show_legend_key/) เป็น `True` เพื่อแสดงคีย์คำอธิบายหรือเป็น `False` เพื่อซ่อน

**ตารางข้อมูลจะคงอยู่เมื่อส่งออกงานนำเสนอเป็น PDF, HTML หรือรูปภาพหรือไม่?**

ใช่. Aspose.Slides จะเรนเดอร์แผนภูมิและตารางข้อมูลที่แสดงเป็นส่วนหนึ่งของสไลด์เมื่อส่งออกเป็น [PDF](/slides/th/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/th/python-net/convert-powerpoint-to-html/), หรือ [images](/slides/th/python-net/convert-powerpoint-to-png/)

**ฉันสามารถทำงานกับตารางข้อมูลในแผนภูมิที่โหลดจากเทมเพลตได้หรือไม่?**

ใช่. สำหรับแผนภูมิที่โหลดจากงานนำเสนอหรือเทมเพลตที่มีอยู่, ใช้ [has_data_table](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/has_data_table/) เพื่อตรวจสอบหรือเปลี่ยนแปลงว่าตารางข้อมูลของแผนภูมินั้นถูกแสดงหรือไม่

**ฉันจะค้นหาแผนภูมิที่มีตารางข้อมูลเปิดใช้งานได้อย่างไร?**

วนรอบผ่านรูปร่างในแต่ละสไลด์, ระบุแผนภูมิ, และตรวจสอบคุณสมบัติ [has_data_table](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/has_data_table/) ของมัน ค่าที่เป็น `True` ระบุว่าตารางข้อมูลถูกเปิดใช้งาน