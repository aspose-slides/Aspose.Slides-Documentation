---
title: สร้างงานนำเสนอใน Java
linktitle: สร้างงานนำเสนอ
type: docs
weight: 10
url: /th/java/create-presentation/
keywords:
- สร้างงานนำเสนอ
- งานนำเสนอใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "สร้างงานนำเสนอใน Java ด้วย Aspose.Slides — สร้างไฟล์ PPT, PPTX และ ODP, ใช้ประโยชน์จากการสนับสนุน OpenDocument และบันทึกไฟล์โดยโปรแกรมเพื่อผลลัพธ์ที่เชื่อถือได้."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างงานนำเสนอใน Aspose.Slides, เพิ่มเนื้อหาแบบง่ายลงในสไลด์, และบันทึกผลลัพธ์เป็นไฟล์ นอกจากนี้ยังสาธิตวิธีสร้างและบันทึกงานนำเสนอใหม่, เปิดงานนำเสนอที่มีอยู่ในรูปแบบที่รองรับ, และบันทึกเป็นรูปแบบอื่น อีกทั้งยังมี FAQ สั้น ๆ ครอบคลุมคำถามทั่วไปเกี่ยวกับรูปแบบ, แม่แบบ, ขนาดสไลด์, หน่วยวัด, การใช้หน่วยความจำ, การทำงานหลายเธรด, การให้ลิขสิทธิ์, ลายเซ็นดิจิทัล, และการสนับสนุน VBA

## **สร้างการนำเสนอ**

การสร้างไฟล์ PowerPoint ตั้งแต่ต้นใน Aspose.Slides for Java ทำได้โดยการสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) โดยอัตโนมัติคอนสตรัคเตอร์จะจัดหาชุดสไลด์ว่างเปล่าที่มีสไลด์หนึ่งใบให้คุณใช้งานทันทีสำหรับรูปทรง, ข้อความ, แผนภูมิ หรือเนื้อหาอื่น ๆ ที่แอปพลิเคชันของคุณต้องการ เมื่อตัวคุณแก้ไขสไลด์นั้นหรือเพิ่มสไลด์ใหม่ คุณสามารถบันทึกผลลัพธ์เป็นรูปแบบ PPTX, PPT เก่า, หรือแม้แต่รูปแบบ OpenDocument ตัวอย่างโค้ดสั้นด้านล่างแสดงขั้นตอนการทำงานนี้โดยเพิ่มรูปทรงง่าย ๆ ลงในสไลด์แรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)  
1. รับอ้างอิงถึงสไลด์ตามลำดับดัชนี  
1. เพิ่มอ็อบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ประเภท `Cloud` ด้วยเมธอด `addAutoShape` ในคอลเลกชัน `Shapes`  
1. เพิ่มข้อความลงในออโต้เชป  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง จะมีการเพิ่มรูปทรงเมฆลงในสไลด์แรกของงานนำเสนอ

```java
// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation presentation = new Presentation();
try {
    // รับสไลด์แรก.
    ISlide slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโต้เชปประเภทเมฆ.
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![งานนำเสนอใหม่](new_presentation.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกงานนำเสนอใหม่เป็นรูปแบบใดได้บ้าง?**

คุณสามารถบันทึกเป็น [PPTX, PPT, และ ODP](/slides/th/java/save-presentation/) และส่งออกเป็น [PDF](/slides/th/java/convert-powerpoint-to-pdf/), [XPS](/slides/th/java/convert-powerpoint-to-xps/), [HTML](/slides/th/java/convert-powerpoint-to-html/), [SVG](/slides/th/java/convert-powerpoint-to-png/), และ [ภาพ](/slides/th/java/convert-powerpoint-to-png/) เป็นต้น

**ฉันสามารถเริ่มจากแม่แบบ (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?**

ได้ โหลดแม่แบบแล้วบันทึกเป็นรูปแบบที่ต้องการ; รูปแบบ POTX/POTM/PPTM เป็นต้น [ได้รับการสนับสนุน](/slides/th/java/supported-file-formats/)

**ฉันจะควบคุมขนาด/อัตราส่วนของสไลด์เมื่อสร้างงานนำเสนออย่างไร?**

ตั้งค่า [ขนาดสไลด์](/slides/th/java/slide-size/) (รวมถึงค่าที่ตั้งล่วงหน้าเช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกวิธีที่เนื้อหาจะสเกล

**ขนาดและพิกัดวัดเป็นหน่วยใด?**

เป็นจุด (points): 1 นิ้วเท่ากับ 72 หน่วย

**ฉันจะจัดการงานนำเสนอขนาดใหญ่ (มีไฟล์สื่อจำนวนมาก) เพื่อลดการใช้หน่วยความจำอย่างไร?**

ใช้ [กลยุทธ์การจัดการ BLOB](/slides/th/java/manage-blob/), จำกัดการเก็บในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และเลือกเวิร์กฟลว์แบบไฟล์มากกว่าการสตรีมในหน่วยความจำเท่านั้น

**ฉันสามารถสร้าง/บันทึกงานนำเสนอพร้อมกันหลายกระบวนการได้หรือไม่?**

คุณไม่สามารถดำเนินการกับอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เดียวกันจาก [หลายเธรด](/slides/th/java/multithreading/) ได้ ให้รันอินสแตนซ์แยกที่แยกจากกันต่อเธรดหรือกระบวนการ

**ฉันจะลบลายน้ำแบบทดลองและข้อจำกัดต่าง ๆ อย่างไร?**

[ใช้ลิขสิทธิ์](/slides/th/java/licensing/) ครั้งเดียวต่อกระบวนการ XML ของลิขสิทธิ์ต้องไม่ถูกแก้ไข และการตั้งค่าลิขสิทธิ์ควรกระทำให้สอดคล้องกันหากมีหลายเธรด

**ฉันสามารถลงลายเซ็นดิจิทัลให้กับ PPTX ที่สร้างได้หรือไม่?**

ได้ รองรับ [ลายเซ็นดิจิทัล](/slides/th/java/digital-signature-in-powerpoint/) (การเพิ่มและการตรวจสอบ) สำหรับงานนำเสนอ

**มาร์โคร (VBA) รองรับในงานนำเสนอที่สร้างหรือไม่?**

ได้ คุณสามารถ [สร้าง/แก้ไขโครงการ VBA](/slides/th/java/presentation-via-vba/) และบันทึกไฟล์ที่เปิดใช้งานมาร์โครเช่น PPTM/PPSM