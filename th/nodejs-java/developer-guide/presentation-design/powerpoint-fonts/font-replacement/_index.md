---
title: ทำให้การแทนที่ฟอนต์ในงานนำเสนอด้วย JavaScript เป็นเรื่องง่าย
linktitle: การแทนที่ฟอนต์
type: docs
weight: 60
url: /th/nodejs-java/font-replacement/
keywords:
- ฟอนต์
- แทนที่ฟอนต์
- การแทนที่ฟอนต์
- เปลี่ยนฟอนต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แทนที่ฟอนต์ใน JavaScript อย่างราบรื่นด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อให้การจัดรูปแบบตัวอักษรสอดคล้องกันในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณแทนที่ฟอนต์หนึ่งด้วยอีกฟอนต์หนึ่งทั่วทั้งงานนำเสนอ เมื่อฟอนต์ถูกแทนที่ ตัวอย่างทั้งหมดของฟอนต์ต้นฉบับจะถูกเปลี่ยนเป็นฟอนต์ใหม่

เพื่อทำการแทนที่ฟอนต์ ให้โหลดงานนำเสนอ กำหนดฟอนต์ต้นทางและฟอนต์ที่จะแทนที่ เรียกใช้เมธอดแทนที่ฟอนต์ และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX วิธีนี้มีประโยชน์เมื่อคุณต้องการสลับจากฟอนต์ตระกูลหนึ่งไปยังอีกตระกูลหนึ่งทั่วงานนำเสนอโดยเจตนา

## **แทนที่ฟอนต์**

หากคุณเปลี่ยนใจเกี่ยวกับการใช้ฟอนต์ คุณสามารถแทนที่ฟอนต์นั้นด้วยฟอนต์อื่นได้ ตัวอย่างทั้งหมดของฟอนต์เก่าจะถูกแทนที่ด้วยฟอนต์ใหม่

Aspose.Slides อนุญาตให้คุณแทนที่ฟอนต์ได้ดังนี้:

1. โหลดงานนำเสนอที่เกี่ยวข้อง  
2. โหลดฟอนต์ที่ต้องการจะแทนที่  
3. โหลดฟอนต์ใหม่  
4. แทนที่ฟอนต์  
5. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด JavaScript นี้แสดงการแทนที่ฟอนต์:

```javascript
// โหลดงานนำเสนอ
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // โหลดฟอนต์ต้นทางที่จะถูกแทนที่
    var sourceFont = new aspose.slides.FontData("Arial");
    // โหลดฟอนต์ใหม่
    var destFont = new aspose.slides.FontData("Times New Roman");
    // แทนที่ฟอนต์
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // บันทึกงานนำเสนอ
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
เพื่อกำหนดกฎที่ระบุว่าอะไรจะเกิดขึ้นในเงื่อนไขบางอย่าง (เช่น ฟอนต์ไม่สามารถเข้าถึงได้) ดูที่ [**การแทนที่ฟอนต์**](/slides/th/nodejs-java/font-substitution/). 
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง “font replacement”, “font substitution” และ “fallback fonts” คืออะไร?**  
การแทนที่เป็นการสลับอย่างเจตนารมณ์จากฟอนต์ตระกูลหนึ่งไปยังอีกตระกูลหนึ่งทั่วทั้งเอกสาร [Substitution](/slides/th/nodejs-java/font-substitution/) คือกฎเช่น “ถ้าฟอนต์ไม่พร้อมใช้งาน ให้ใช้ X.” [Fallback](/slides/th/nodejs-java/fallback-font/) จะถูกนำมาใช้แบบเฉพาะสำหรับ glyph ที่หายไปแต่ละตัวเมื่อตัวฟอนต์พื้นฐานติดตั้งแล้วแต่ไม่มีอักขระที่ต้องการ

**การแทนที่ใช้กับ master slides, layouts, notes และ comments หรือไม่?**  
ใช่ การแทนที่มีผลต่อวัตถุทั้งหมดในงานนำเสนอที่ใช้ฟอนต์ต้นฉบับ รวมถึง master slides และ notes; comments ก็เป็นส่วนของเอกสารและจะถูกพิจารณาโดยเอ็นจิ้นฟอนต์

**ฟอนต์จะเปลี่ยนภายในวัตถุ OLE ที่ฝังอยู่ (เช่น Excel) หรือไม่?**  
ไม่ [OLE content](/slides/th/nodejs-java/manage-ole/) ถูกควบคุมโดยแอปพลิเคชันของมันเอง การแทนที่ในงานนำเสนอจะไม่จัดรูปแบบข้อมูล OLE ภายในใหม่; อาจแสดงเป็นรูปภาพหรือเป็นเนื้อหาที่สามารถแก้ไขจากภายนอกได้

**ฉันสามารถแทนที่ฟอนต์ได้เฉพาะบางส่วนของงานนำเสนอ (ตามสไลด์หรือพื้นที่) หรือไม่?**  
การแทนที่แบบเจาะจงเป็นไปได้หากคุณเปลี่ยนฟอนต์ในระดับของวัตถุ/ช่วงที่ต้องการแทนที่จะทำการแทนที่ทั่วทั้งเอกสารตราส่วน การเลือกฟอนต์โดยรวมในระหว่างการเรนเดอร์ยังคงเหมือนเดิม

**ฉันจะตรวจสอบล่วงหน้าว่างานนำเสนอใช้ฟอนต์ใดบ้างได้อย่างไร?**  
ใช้ [ตัวจัดการฟอนต์](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/): มันให้รายการของ [ฟอนต์ตระกูลที่ใช้](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getfonts/) และข้อมูลเกี่ยวกับ [การแทนที่/ฟอนต์ที่ไม่รู้จัก](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/), ซึ่งช่วยวางแผนการแทนที่

**การแทนที่ฟอนต์ทำงานเมื่อแปลงเป็น PDF/รูปภาพหรือไม่?**  
ใช่ ในระหว่างการส่งออก Aspose.Slides จะใช้ [font selection/substitution sequence](/slides/th/nodejs-java/font-selection-sequence/) เดียวกัน ดังนั้นการแทนที่ที่ทำไว้ล่วงหน้าจะถูกนำไปใช้ในการแปลง

**ฉันต้องติดตั้งฟอนต์เป้าหมายในระบบหรือไม่ หรือสามารถแนบโฟลเดอร์ฟอนต์ได้หรือไม่?**  
ไม่จำเป็นต้องติดตั้ง: ไลบรารีอนุญาตให้ [loading external fonts](/slides/th/nodejs-java/custom-font/) จากโฟลเดอร์ของผู้ใช้เพื่อใช้ระหว่าง [rendering and export](/slides/th/nodejs-java/convert-powerpoint/).

**การแทนที่จะทำให้แก้ปัญหา “tofu” (สี่เหลี่ยม) แทนตัวอักษรหรือไม่?**  
เฉพาะเมื่อฟอนต์เป้าหมายมี glyph ที่ต้องการจริง ๆ หากไม่มี ให้ [configure fallback](/slides/th/nodejs-java/fallback-font/) เพื่อครอบคลุมอักขระที่หายไป