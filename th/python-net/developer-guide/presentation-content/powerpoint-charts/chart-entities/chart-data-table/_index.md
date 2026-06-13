---
title: ปรับแต่งตารางข้อมูลแผนภูมิใน Python
linktitle: ตารางข้อมูล
type: docs
url: /th/python-net/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติแบบอักษร
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ปรับแต่งตารางข้อมูลแผนภูมิใน Python สำหรับ PPT, PPTX และ ODP ด้วย Aspose.Slides เพื่อเพิ่มประสิทธิภาพและความน่าสนใจในงานนำเสนอ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับตารางข้อมูลแผนภูมิใน Aspose.Slides โดยแสดงวิธีการแสดงตารางข้อมูลสำหรับแผนภูมิและปรับรูปแบบข้อความโดยการตั้งค่าคุณสมบัติแบบอักษร เช่น สไตล์หนาและความสูงของแบบอักษร ตัวอย่างสาธิตการโหลดงานนำเสนอ การเพิ่มแผนภูมิ การเปิดใช้งานตารางข้อมูลแผนภูมิ การกำหนดค่าฟอนต์ และการบันทึกงานนำเสนอที่อัปเดต

บทความยังให้คำตอบสั้น ๆ สำหรับคำถามทั่วไปเกี่ยวกับการแสดงคีย์คำอธิบายในตารางข้อมูลแผนภูมิ การคงตารางข้อมูลไว้ระหว่างการส่งออก การทำงานกับแผนภูมิที่โหลดจากงานนำเสนอหรือเทมเพลตที่มีอยู่แล้ว และวิธีการระบุแผนภูมิที่เปิดใช้งานตารางข้อมูล

## **กำหนดคุณสมบัติแบบอักษรสำหรับตารางข้อมูลแผนภูมิ**
Aspose.Slides for Python via .NET ให้การสนับสนุนการเปลี่ยนสีของหมวดหมู่ในสีของชุดข้อมูล  

1. สร้างอ็อบเจกต์ของคลาส [การนำเสนอ](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เพิ่มแผนภูมิบนสไลด์
1. ตั้งค่าตารางแผนภูมิ
1. ตั้งค่าความสูงของแบบอักษร
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่างโค้ดที่แสดงด้านล่าง  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงคีย์คำอธิบายขนาดเล็กข้างค่าต่าง ๆ ในตารางข้อมูลของแผนภูมิได้หรือไม่?**

ใช่ ตารางข้อมูลรองรับ [คีย์คำอธิบาย](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datatable/show_legend_key/) และคุณสามารถเปิดหรือปิดได้

**ตารางข้อมูลจะถูกเก็บไว้เมื่อส่งออกงานนำเสนอเป็น PDF, HTML หรือภาพหรือไม่?**

ใช่ Aspose.Slides จะเรนเดอร์แผนภูมิเป็นส่วนหนึ่งของสไลด์ ดังนั้นไฟล์ที่ส่งออกเป็น [PDF](/slides/th/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/th/python-net/convert-powerpoint-to-html/)/[ภาพ](/slides/th/python-net/convert-powerpoint-to-png/) จะรวมแผนภูมิพร้อมตารางข้อมูล

**ตารางข้อมูลรองรับสำหรับแผนภูมิที่มาจากไฟล์เทมเพลตหรือไม่?**

ใช่ สำหรับแผนภูมิใด ๆ ที่โหลดจากงานนำเสนอหรือเทมเพลตที่มีอยู่แล้ว คุณสามารถตรวจสอบและเปลี่ยนแปลงว่าตารางข้อมูล [ถูกแสดง](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/has_data_table/) หรือไม่โดยใช้คุณสมบัติของแผนภูมิ

**ฉันจะค้นหาแผนภูมิที่เปิดใช้งานตารางข้อมูลในไฟล์ได้อย่างรวดเร็วอย่างไร?**

ตรวจสอบคุณสมบัติของแต่ละแผนภูมิที่ระบุว่าตารางข้อมูล [ถูกแสดง](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/has_data_table/) หรือไม่ และวนลูปผ่านสไลด์เพื่อระบุแผนภูมิที่เปิดใช้งานตารางข้อมูลนั้น