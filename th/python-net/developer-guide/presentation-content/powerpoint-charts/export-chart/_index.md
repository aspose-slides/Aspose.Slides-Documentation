---
title: ส่งออกแผนภูมิการนำเสนอด้วย Python
linktitle: ส่งออกแผนภูมิ
type: docs
weight: 90
url: /th/python-net/export-chart/
keywords:
- แผนภูมิ
- แผนภูมิเป็นภาพ
- แผนภูมิเป็นภาพ
- สกัดภาพแผนภูมิ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีส่งออกแผนภูมิการนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน .NET รองรับรูปแบบ PPT, PPTX และ ODP และทำให้การรายงานเป็นกระบวนการอัตโนมัติในทุก workflow."
---
## **ภาพรวม**

Aspose.Slides ให้คุณส่งออกแผนภูมิจากงานนำเสนอเป็นภาพ บทความนี้แสดงวิธีดึงภาพจากแผนภูมิและบันทึกไว้ ซึ่งมีประโยชน์เมื่อคุณต้องการใช้ภาพแผนภูมิซ้ำนอกเหนือจากงานนำเสนอ PowerPoint

## **รับภาพแผนภูมิ**
Aspose.Slides for Python ผ่าน .NET รองรับการสกัดภาพของแผนภูมิเฉพาะ ตัวอย่างโค้ดด้านล่างแสดงให้เห็น

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **FAQ**

**ฉันสามารถส่งออกแผนภูมิเป็นเวกเตอร์ (SVG) แทนภาพเรสเตอร์ได้หรือไม่?**

ใช่ แผนภูมิเป็นรูปทรงและเนื้อหาของมันสามารถบันทึกเป็น SVG ได้โดยใช้ [วิธีการบันทึก shape-to-SVG](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/write_as_svg/)

**ฉันจะตั้งขนาดที่แน่นอนของแผนภูมิที่ส่งออกเป็นพิกเซลได้อย่างไร?**

ใช้ overload การเรนเดอร์ภาพที่อนุญาตให้ระบุขนาดหรือสเกล—ไลบรารีสนับสนุนการเรนเดอร์อ็อบเจ็กต์ด้วยมิติ/สเกลที่กำหนด

**ฉันควรทำอย่างไรหากฟอนต์ในป้ายและคำอธิบายดูผิดพลาดหลังการส่งออก?**

[โหลดฟอนต์ที่ต้องการ](/slides/th/python-net/custom-font/) ผ่าน [FontsLoader](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsloader/) เพื่อให้การเรนเดอร์แผนภูมิรักษาเมตริกและลักษณะข้อความ

**การส่งออกเคารพธีม สไตล์ และเอฟเฟกต์ของ PowerPoint หรือไม่?**

ใช่ ตัวเรนเดอร์ของ Aspose.Slides ปฏิบัติตามการจัดรูปแบบของงานนำเสนอ (ธีม, สไตล์, การเติม, เอฟเฟกต์) ทำให้ลักษณะของแผนภูมิถูกเก็บรักษา

**ฉันสามารถค้นหาความสามารถในการเรนเดอร์/ส่งออกที่มีนอกเหนือจากภาพแผนภูมิได้ที่ไหน?**

ดูส่วนการส่งออกของ [API](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/)/[documentation](/slides/th/python-net/convert-powerpoint/) เพื่อดูเป้าหมายผลลัพธ์ ([PDF](/slides/th/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/th/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/th/python-net/convert-powerpoint-to-xps/), [HTML](/slides/th/python-net/convert-powerpoint-to-html/), ฯลฯ) และตัวเลือกการเรนเดอร์ที่เกี่ยวข้อง