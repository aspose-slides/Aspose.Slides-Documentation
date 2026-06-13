---
title: ปรับแต่งแผนภูมโดนัทในงานนำเสนอด้วย С++
linktitle: แผนภูมโดนัท
type: docs
weight: 30
url: /th/cpp/doughnut-chart/
keywords:
- แผนภูมโดนัท
- ช่องว่างศูนย์กลาง
- ขนาดช่องกลาง
- PowerPoint
- งานนำเสนอ
- С++
- Aspose.Slides
description: "ค้นพบวิธีสร้างและปรับแต่งแผนภูมโดนัทใน Aspose.Slides สำหรับ С++ พร้อมสนับสนุนรูปแบบ PowerPoint สำหรับงานนำเสนอแบบไดนามิก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำงานกับแผนภูมโดนัทใน Aspose.Slides โดยการเพิ่มแผนภูมิลงในสไลด์, ตั้งค่าขนาดของช่องกลางของแผนภูมิ, และบันทึกพรีเซนเทชัน. มุ่งเน้นที่เมธอด `set_DoughnutHoleSize` และสาธิตขั้นตอนพื้นฐานที่จำเป็นสำหรับการปรับแต่งประเภทแผนภูมนี้ในโค้ด.

## **ระบุช่องว่างศูนย์กลางในแผนภูมโดนัท**
เพื่อระบุขนาดของช่องกลางในแผนภูมโดนัท กรุณาปฏิบัติตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) .
- เพิ่มแผนภูมโดนัทลงในสไลด์.
- ระบุขนาดของช่องกลางในแผนภูมโดนัท.
- บันทึกพรีเซนเทชันลงดิสก์.

ในตัวอย่างด้านล่างนี้ เราได้ตั้งค่าขนาดของช่องกลางในแผนภูมโดนัท.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **คำถามที่พบบ่อย**

**ฉันสามารถสร้างโดนัทหลายระดับที่มีหลายวงได้หรือไม่?**

ได้. เพิ่มหลาย series ลงในแผนภูมโดนัทเดียว—แต่ละ series จะกลายเป็นวงแยกต่างหาก. ลำดับของวงจะกำหนดโดยลำดับของ series ในคอลเลกชัน.

**โดนัทแบบ "exploded" (แผ่นแยก) ได้รับการสนับสนุนหรือไม่?**

ได้. มีแผนภูมิ Exploded Doughnut [chart type](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/charttype/) และคุณสมบัติ explosion บนจุดข้อมูล; คุณสามารถแยกชิ้นส่วนแต่ละชิ้นได้.

**ฉันจะรับภาพของแผนภูมโดนัท (PNG/SVG) สำหรับรายงานได้อย่างไร?**

แผนภูมเป็นรูปทรง; คุณสามารถแปลงเป็น [raster image](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/getimage/) หรือส่งออกแผนภูมิเป็น [SVG image](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/writeassvg/).