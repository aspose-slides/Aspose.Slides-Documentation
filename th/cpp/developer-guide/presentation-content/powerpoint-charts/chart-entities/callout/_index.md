---
title: จัดการ Callout ในแผนภูมิการนำเสนอโดยใช้ С++
linktitle: Callout
type: docs
url: /th/cpp/callout/
keywords:
- chart callout
- ใช้ callout
- ป้ายข้อมูล
- รูปแบบป้าย
- PowerPoint
- การนำเสนอ
- С++
- Aspose.Slides
description: "สร้างและจัดรูปแบบ callout ใน Aspose.Slides สำหรับ С++ ด้วยตัวอย่างโค้ดสั้น ๆ ที่เข้ากันได้กับ PPT และ PPTX เพื่ออัตโนมัติขั้นตอนการทำงานของการนำเสนอ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับ callout สำหรับป้ายข้อมูลของแผนภูมิใน Aspose.Slides โดยแสดงวิธีใช้เมธอด `set_ShowLabelAsDataCallout` เพื่อแสดงป้ายเป็น callout วิธีกำหนดค่าการตั้งค่าป้ายที่เกี่ยวข้องกับ callout สำหรับแผนภูมิ doughnut และระบุว่า callout และลักษณะของมันจะคงไว้เมื่อการนำเสนอถูกส่งออกเป็น PDF, HTML5, SVG และรูปแบบภาพเรสเตอร์

## **การใช้ Callout**
คุณสมบัติใหม่ **ShowLabelAsDataCallout** ได้ถูกเพิ่มไปยังคลาส **DataLabelFormat** และอินเทอร์เฟซ **IDataLabelFormat** ซึ่งกำหนดว่าป้ายข้อมูลของแผนภูมิที่ระบุจะถูกแสดงเป็น data callout หรือเป็นป้ายข้อมูลทั่วไป ในตัวอย่างด้านล่างนี้ เราได้ตั้งค่า Callout

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **ตั้งค่า Callout สำหรับแผนภูมิ Doughnut**
Aspose.Slides for C++ มีการสนับสนุนการตั้งค่ารูปแบบ callout ของป้ายข้อมูลชุดข้อมูลสำหรับแผนภูมิ Doughnut ตัวอย่างโค้ดด้านล่างนี้แสดงให้เห็น

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **คำถามที่พบบ่อย**

**Callout จะคงอยู่เมื่อแปลงการนำเสนอเป็น PDF, HTML5, SVG หรือภาพหรือไม่?**

ใช่. Callout เป็นส่วนหนึ่งของการเรนเดอร์แผนภูมิ ดังนั้นเมื่อคุณส่งออกเป็น [PDF](/slides/th/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/th/cpp/export-to-html5/), [SVG](/slides/th/cpp/render-a-slide-as-an-svg-image/), หรือ [raster images](/slides/th/cpp/convert-powerpoint-to-png/) พวกมันจะถูกคงไว้พร้อมกับการจัดรูปแบบของสไลด์

**ฟอนท์แบบกำหนดเองทำงานใน Callout หรือไม่ และลักษณะของมันสามารถคงไว้ได้เมื่อส่งออกหรือไม่?**

ใช่. Aspose.Slides รองรับการ [ฝังฟอนท์](/slides/th/cpp/embedded-font/) ไปยังการนำเสนอและควบคุมการฝังฟอนท์ในระหว่างการส่งออก เช่น [PDF](/slides/th/cpp/convert-powerpoint-to-pdf/) ทำให้ Callout มีลักษณะเดียวกันบนระบบต่าง ๆ