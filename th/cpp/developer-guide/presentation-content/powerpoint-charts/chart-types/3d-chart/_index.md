---
title: ปรับแต่งแผนภูมิ 3 มิติในงานนำเสนอโดยใช้ С++
linktitle: แผนภูมิ 3 มิติ
type: docs
url: /th/cpp/3d-chart/
keywords:
- แผนภูมิ 3 มิติ
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- С++
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิ 3 มิติใน Aspose.Slides สำหรับ С++ พร้อมการสนับสนุนไฟล์ PPT และ PPTX—เพิ่มประสิทธิภาพงานนำเสนอของคุณวันนี้."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งแผนภูมิ 3 มิติใน Aspose.Slides โดยกำหนดค่าการตั้งค่า `Rotation3D` เช่น `RotationX`, `RotationY`, `DepthPercents` และ `RightAngleAxes` มันแสดงขั้นตอนการสร้างงานนำเสนอ, เพิ่มแผนภูมิ 3 มิติพร้อมข้อมูลเริ่มต้น, นำการตั้งค่ามุมมอง 3 มิติตามที่ต้องการ, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

## **ตั้งค่า RotationX, RotationY และคุณสมบัติ DepthPercents ของแผนภูมิ 3 มิติ**

Aspose.Slides for C++ มี API ที่ง่ายต่อการตั้งค่าคุณสมบัติเหล่านี้ บทความต่อไปนี้จะช่วยคุณในการตั้งค่าต่างๆ เช่น การหมุน X, Y , **DepthPercents**  เป็นต้น ตัวอย่างโค้ดนี้แสดงการตั้งค่าคุณสมบัติเกือบกล่าวถึงข้างต้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
4. ตั้งค่าคุณสมบัติ Rotation3D
5. เขียนงานนำเสนอที่แก้ไขลงไฟล์ PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดบ้างที่รองรับโหมด 3 มิติใน Aspose.Slides?**

Aspose.Slides รองรับแผนภูมิคอลัมน์แบบ 3 มิติหลายประเภท รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D พร้อมกับประเภท 3 มิติที่เกี่ยวข้องซึ่งเปิดให้ใช้ผ่าน enumeration [ChartType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/charttype/) สำหรับรายการที่เป็นปัจจุบันและครบถ้วนที่สุด ให้ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/charttype/) ในเอกสารอ้างอิง API ของเวอร์ชันที่คุณติดตั้ง

**ฉันสามารถรับภาพเรสเตอร์ของแผนภูมิ 3 มิติสำหรับรายงานหรือเว็บได้หรือไม่?**

ใช่ คุณสามารถส่งออกแผนภูมิเป็นภาพโดยใช้ [chart API](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/getimage/) หรือ [render the entire slide](/slides/th/cpp/convert-powerpoint-to-png/) ไปเป็นรูปแบบเช่น PNG หรือ JPEG สิ่งนี้มีประโยชน์เมื่อคุณต้องการพรีวิวที่พิกเซลสมบูรณ์หรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องการ PowerPoint

**ประสิทธิภาพการสร้างและเรนเดอร์แผนภูมิ 3 มิติขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของการแสดงผล เพื่อให้ได้ผลดีที่สุด ควรลดเอฟเฟกต์ 3 มิติให้น้อยที่สุด, หลีกเลี่ยงการใช้เทกซ์เจอร์หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อซีรีส์เมื่อเป็นไปได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับจอแสดงผลหรือความต้องการพิมพ์