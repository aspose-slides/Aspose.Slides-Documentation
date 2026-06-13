---
title: ปรับแต่งแผนภูมิโดนัทในงานนำเสนอด้วย Python
linktitle: แผนภูมิโดนัท
type: docs
weight: 30
url: /th/python-net/doughnut-chart/
keywords:
- แผนภูมิโดนัท
- ช่องว่างศูนย์กลาง
- ขนาดช่อง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบวิธีการสร้างและปรับแต่งแผนภูมิโดนัทใน Aspose.Slides สำหรับ Python ผ่าน .NET รองรับรูปแบบ PowerPoint และ OpenDocument สำหรับงานนำเสนอที่มีการเปลี่ยนแปลงอย่างไดนามิก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำงานกับแผนภูมิแบบโดนัทใน Aspose.Slides โดยการเพิ่มแผนภูมิลงในสไลด์ กำหนดขนาดของช่องศูนย์กลาง และบันทึกงานนำเสนอ มุ่งเน้นที่การตั้งค่า `doughnut_hole_size` และสาธิตขั้นตอนพื้นฐานที่จำเป็นสำหรับการปรับแต่งประเภทแผนภูมินี้ในโค้ด

บทความนี้ยังรวมคำถามที่พบบ่อยสั้น ๆ ที่ครอบคลุมสถานการณ์ที่เกี่ยวข้องกับแผนภูมิดอนัท เช่น การใช้หลายซีรีส์เพื่อสร้างหลายวง แผนภูมิดอนัทแบบระเบิด (exploded) และการส่งออกแผนภูมิเป็นรูปภาพแรสเตอร์หรือ SVG

## **ระบุช่องว่างศูนย์กลางในแผนภูมิโดนัท**
เพื่อระบุขนาดของช่องศูนย์กลางในแผนภูมิดอนัท กรุณาตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) class.
- เพิ่มแผนภูมิโดนัทบนสไลด์.
- ระบุขนาดของช่องศูนย์กลางในแผนภูมิดอนัท.
- บันทึกการนำเสนอลงดิสก์.

ในตัวอย่างที่แสดงด้านล่าง เราได้กำหนดขนาดของช่องศูนย์กลางในแผนภูมิดอนัท

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # บันทึกงานนำเสนอลงดิสก์
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถสร้างโดนัทหลายระดับที่มีหลายวงได้หรือไม่?**

ได้. เพิ่มหลายซีรีส์ลงในแผนภูมิโดนัทเดียว—แต่ละซีรีส์จะกลายเป็นวงแยกต่างหาก ลำดับของวงจะกำหนดโดยลำดับของซีรีส์ในคอลเลกชัน

**โดนัทแบบ “exploded” (แยกชิ้น) ถูกสนับสนุนหรือไม่?**

ได้. มี Exploded Doughnut [ประเภทแผนภูมิ](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/charttype/) และคุณสมบัติการระเบิดบนจุดข้อมูล; คุณสามารถแยกชิ้นแต่ละชิ้นได้

**ฉันจะได้ภาพของแผนภูมิดอนัท (PNG/SVG) สำหรับรายงานได้อย่างไร?**

แผนภูมิเป็นรูปทรง; คุณสามารถเรนเดอร์เป็น [รูปภาพแบบแรสเตอร์](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/get_image/) หรือส่งออกแผนภูมิเป็น [รูปภาพ SVG](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/write_as_svg/).