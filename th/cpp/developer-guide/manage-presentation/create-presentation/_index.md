---
title: สร้างการนำเสนอใน C++
linktitle: สร้างการนำเสนอ
type: docs
weight: 10
url: /th/cpp/create-presentation/
keywords:
- สร้างการนำเสนอ
- การนำเสนอใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "สร้างการนำเสนอใน C++ ด้วย Aspose.Slides—สร้างไฟล์ PPT, PPTX และ ODP, รับประโยชน์จากการสนับสนุน OpenDocument, และบันทึกไฟล์โดยโปรแกรมเพื่อผลลัพธ์ที่เชื่อถือได้."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างงานพรีเซนเทชันใน Aspose.Slides, เพิ่มเนื้อหาง่าย ๆ ลงในสไลด์, และบันทึกผลลัพธ์เป็นไฟล์.

## **สร้าง PowerPoint Presentation**
เพื่อเพิ่มเส้นธรรมดาแบบเรียบง่ายในสไลด์ที่เลือกของงานพรีเซนเทชัน, โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation).
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
1. เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้งานโดยออบเจกต์ Shapes.
1. เขียนงานพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX.

ในตัวอย่างด้านล่างนี้, เราได้เพิ่มเส้นลงในสไลด์แรกของงานพรีเซนเทชัน.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **FAQ**

**ฉันสามารถบันทึกงานพรีเซนเทชันใหม่เป็นรูปแบบอะไรได้บ้าง?**

คุณสามารถบันทึกเป็น [PPTX, PPT, และ ODP](/slides/th/cpp/save-presentation/), และส่งออกเป็น [PDF](/slides/th/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/th/cpp/convert-powerpoint-to-xps/), [HTML](/slides/th/cpp/convert-powerpoint-to-html/), [SVG](/slides/th/cpp/convert-powerpoint-to-png/), และ [images](/slides/th/cpp/convert-powerpoint-to-png/), เป็นต้น.

**ฉันสามารถเริ่มจากเทมเพลต (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?**

ใช่. โหลดเทมเพลตและบันทึกเป็นรูปแบบที่ต้องการ; รูปแบบ POTX/POTM/PPTM และรูปแบบคล้ายกัน [ได้รับการสนับสนุน](/slides/th/cpp/supported-file-formats/).

**ฉันจะควบคุมขนาด/อัตราส่วนของสไลด์เมื่อสร้างงานพรีเซนเทชันได้อย่างไร?**

ตั้งค่า [slide size](/slides/th/cpp/slide-size/) (รวมถึงค่าตั้งล่วงหน้าเช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกวิธีการสเกลของเนื้อหา.

**ขนาดและพิกัดวัดเป็นหน่วยใด?**

ในหน่วย points: 1 นิ้วเท่ากับ 72 หน่วย.

**ฉันจะจัดการกับงานพรีเซนเทชันขนาดใหญ่ (ที่มีไฟล์สื่อหลายไฟล์) เพื่อลดการใช้หน่วยความจำได้อย่างไร?**

ใช้ [BLOB management strategies](/slides/th/cpp/manage-blob/), จำกัดการเก็บข้อมูลในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และควรเลือกเวิร์กโฟลว์ที่อิงไฟล์แทนการสตรีมแบบในหน่วยความจำเต็มรูปแบบ.

**ฉันสามารถสร้าง/บันทึกงานพรีเซนเทชันพร้อมกันได้หรือไม่?**

คุณไม่สามารถดำเนินการกับอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ตัวเดียวจาก [หลายเธรด](/slides/th/cpp/multithreading/) ได้. ให้รันอินสแตนซ์แยกจากกันสำหรับแต่ละเธรดหรือกระบวนการ.

**ฉันจะลบลายน้ำและข้อจำกัดของรุ่นทดลองได้อย่างไร?**

[Apply a license](/slides/th/cpp/licensing/) หนึ่งครั้งต่อกระบวนการ. XML ใบอนุญาตต้องไม่ถูกแก้ไข, และการตั้งค่าใบอนุญาตควรทำให้สอดคล้องกันหากมีหลายเธรด.

**ฉันสามารถลงลายเซ็นดิจิทัลให้กับ PPTX ที่สร้างได้หรือไม่?**

ใช่. [Digital signatures](/slides/th/cpp/digital-signature-in-powerpoint/) (การเพิ่มและตรวจสอบ) ได้รับการสนับสนุนสำหรับงานพรีเซนเทชัน.

**มักร (VBA) ได้รับการสนับสนุนในงานพรีเซนเทชันที่สร้างหรือไม่?**

ใช่. คุณสามารถ [create/edit VBA projects](/slides/th/cpp/presentation-via-vba/) และบันทึกไฟล์ที่เปิดใช้งานมักรเช่น PPTM/PPSM.