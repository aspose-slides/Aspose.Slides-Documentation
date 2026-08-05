---
title: จัดการ Callouts ในแผนภูมิการนำเสนอด้วย C++
linktitle: คอลเอาต์
type: docs
url: /th/cpp/callout/
keywords:
- คอลเอาต์แผนภูมิ
- ใช้คอลเอาต์
- ป้ายข้อมูล
- รูปแบบป้าย
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "สร้างและออกแบบคอลเอาต์ใน Aspose.Slides สำหรับ C++ ด้วยตัวอย่างโค้ดสั้น ๆ ที่รองรับไฟล์ PPT และ PPTX เพื่ออัตโนมัติกระบวนการทำงานของการนำเสนอ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับ callout สำหรับป้ายข้อมูลของแผนภูมิใน Aspose.Slides แสดงวิธีใช้เมธอด `set_ShowLabelAsDataCallout` เพื่อแสดงป้ายเป็น callout วิธีกำหนดค่าการตั้งค่าป้ายที่เกี่ยวข้องกับ callout สำหรับแผนภูมิ Doughnut และระบุว่า callout และลักษณะการแสดงผลจะถูกเก็บไว้เมื่อนำเสนอถูกส่งออกเป็น PDF, HTML5, SVG และรูปแบบภาพเรสเตอร์

## **การใช้ Callouts**
คุณสมบัติใหม่ **ShowLabelAsDataCallout** ได้ถูกเพิ่มเข้าไปในคลาส **DataLabelFormat** และอินเทอร์เฟซ **IDataLabelFormat** ซึ่งกำหนดว่าป้ายข้อมูลของแผนภูมิที่ระบุจะถูกแสดงเป็น data callout หรือเป็นป้ายข้อมูล ในตัวอย่างด้านล่างนี้ เราได้ตั้งค่า Callouts

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **ตั้ง Callout สำหรับแผนภูมิ Doughnut**
Aspose.Slides สำหรับ C++ มีการสนับสนุนการตั้งค่ารูปร่าง callout ของป้ายข้อมูลซีรีส์สำหรับแผนภูมิ Doughnut ตัวอย่างโค้ดด้านล่างนี้แสดงให้ดู

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Callouts จะยังคงอยู่เมื่อตอนแปลงการนำเสนอเป็น PDF, HTML5, SVG หรือรูปภาพหรือไม่?**

ใช่. Callouts เป็นส่วนหนึ่งของการเรนเดอร์แผนภูมิ ดังนั้นเมื่อคุณส่งออกเป็น [PDF](/slides/th/cpp/convert-powerpoint-to-pdf/),[HTML5](/slides/th/cpp/export-to-html5/),[SVG](/slides/th/cpp/render-a-slide-as-an-svg-image/),หรือ[raster images](/slides/th/cpp/convert-powerpoint-to-png/) พวกมันจะถูกเก็บไว้พร้อมกับรูปแบบของสไลด์

**ฟอนต์ที่กำหนดเองทำงานใน callouts ได้หรือไม่ และลักษณะการแสดงผลสามารถคงอยู่เมื่อส่งออกหรือไม่?**

ใช่. Aspose.Slides รองรับการ[embedding fonts](/slides/th/cpp/embedded-font/)ในงานนำเสนอและควบคุมการฝังฟอนต์ในระหว่างการส่งออกเช่น[PDF](/slides/th/cpp/convert-powerpoint-to-pdf/) เพื่อให้แน่ใจว่า callouts จะดูเหมือนเดิมในระบบต่างๆ