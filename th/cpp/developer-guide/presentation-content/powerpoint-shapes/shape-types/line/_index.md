---
title: เพิ่มรูปร่างเส้นในงานนำเสนอด้วย C++
linktitle: เส้น
type: docs
weight: 50
url: /th/cpp/line/
keywords:
- เส้น
- สร้างเส้น
- เพิ่มเส้น
- เส้นธรรมดา
- กำหนดค่าเส้น
- ปรับแต่งเส้น
- สไตล์เส้นประ
- หัวลูกศร
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้การจัดการรูปแบบเส้นในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ C++ ค้นพบคุณสมบัติ วิธีการ และตัวอย่าง."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถเพิ่มรูปร่างเส้นลงในสไลด์ PowerPoint อย่างโปรแกรมเมิกได้ บทความนี้แสดงวิธีสร้างเส้นธรรมดาและวิธีปรับแต่งเส้นให้ปรากฏเป็นลูกศร

คุณจะได้เรียนรู้วิธีการเพิ่มรูปร่างเส้นลงในสไลด์ ปรับลักษณะการแสดงผลของมัน และบันทึกการนำเสนอที่อัปเดต ตัวอย่างมุ่งเน้นที่การตั้งค่าการจัดรูปแบบเส้นที่ใช้ได้จริง เช่น สไตล์ ความกว้าง แบบเส้นประ ตัวเลือกหัวลูกศร และสีเติม

## **สร้างเส้นธรรมดา**
เพื่อเพิ่มเส้นธรรมดาไปยังสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้：

- สร้างอินสแตนซ์ของ[คลาส Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน  
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด[AddAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addautoshape/)ที่เปิดให้ใช้งานจากออบเจ็กต์ Shapes  
- เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง เราได้เพิ่มเส้นลงในสไลด์แรกของการนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **สร้างเส้นรูปแบบลูกศร**
Aspose.Slides for C++ ยังอนุญาตให้ผู้พัฒนาตั้งค่าบางคุณสมบัติของเส้นเพื่อให้ดูน่าสนใจยิ่งขึ้น ลองกำหนดค่าบางคุณสมบัติของเส้นเพื่อให้มันดูเหมือนลูกศรโดยทำตามขั้นตอนต่อไปนี้：

- สร้างอินสแตนซ์ของ[คลาส Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน  
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด AddAutoShape ที่เปิดให้ใช้งานจากออบเจ็กต์ Shapes  
- ตั้งค่า Line Style ให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides for C++ มีให้  
- ตั้งค่าความกว้างของเส้น  
- ตั้งค่า[Dash Style](https://reference.aspose.com/slides/th/cpp/aspose.slides/linedashstyle/)ของเส้นให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides for C++ มีให้  
- ตั้งค่า[Arrow Head Style](https://reference.aspose.com/slides/th/cpp/aspose.slides/lineformat/)และความยาวของจุดเริ่มต้นของเส้น  
- ตั้งค่า Arrow Head Style และความยาวของจุดสิ้นสุดของเส้น  
- เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงเส้นปกติให้เป็นคอนเน็กเตอร์เพื่อให้ “จับ” กับรูปร่างได้หรือไม่？**

ไม่ได้ เฉพาะเส้นปกติ([AutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/autoshape/)ประเภท[Line](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapetype/)) จะไม่กลายเป็นคอนเน็กเตอร์โดยอัตโนมัติ หากต้องการให้จับกับรูปร่าง ให้ใช้ประเภท[Connector](https://reference.aspose.com/slides/th/cpp/aspose.slides/connector/)และ[API ที่สอดคล้องกัน](/slides/th/cpp/connector/)สำหรับการเชื่อมต่อ

**ฉันควรทำอย่างไรหากคุณสมบัติของเส้นถูกสืบทอดจากธีมและยากที่จะกำหนดค่าที่สุดท้าย？**

[อ่านคุณสมบัติมีผล](/slides/th/cpp/shape-effective-properties/)ผ่านอินเทอร์เฟซ[ILineFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilinefillformateffectivedata/) — อินเทอร์เฟซเหล่านี้จะคำนึงถึงการสืบทอดและสไตล์ของธีมแล้ว

**ฉันสามารถล็อคเส้นเพื่อป้องกันการแก้ไข (ย้าย, ปรับขนาด) ได้หรือไม่？**

ได้ Shapes มี[อ็อบเจ็กต์ล็อค](https://reference.aspose.com/slides/th/cpp/aspose.slides/autoshape/get_autoshapelock/)ที่ทำให้คุณ[ป้องกันการดำเนินการแก้ไข](/slides/th/cpp/applying-protection-to-presentation/)ได้