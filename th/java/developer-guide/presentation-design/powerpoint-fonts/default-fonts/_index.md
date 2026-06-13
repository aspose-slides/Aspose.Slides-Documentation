---
title: ระบุแบบอักษรเริ่มต้นสำหรับการนำเสนอใน Java
linktitle: แบบอักษรเริ่มต้น
type: docs
weight: 30
url: /th/java/default-font/
keywords:
- แบบอักษรเริ่มต้น
- แบบอักษรปกติ
- แบบอักษรธรรมดา
- แบบอักษรเอเชีย
- การส่งออก PDF
- การส่งออก XPS
- การส่งออกภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตั้งค่าแบบอักษรเริ่มต้นใน Aspose.Slides สำหรับ Java เพื่อให้การแปลง PowerPoint (PPT, PPTX) และ OpenDocument (ODP) เป็น PDF, XPS และภาพทำได้อย่างถูกต้อง"
---
## **ภาพรวม**

Aspose.Slides ให้คุณระบุแบบอักษรเริ่มต้นที่ใช้เมื่อการนำเสนอดำเนินการแสดงผล ซึ่งมีประโยชน์เมื่อสร้างภาพย่อของสไลด์หรือส่งออกการนำเสนอเป็นรูปแบบต่าง ๆ เช่น PDF และ XPS แบบอักษรเริ่มต้นจะถูกกำหนดผ่าน `LoadOptions` ก่อนที่จะโหลดการนำเสนอ

`setDefaultRegularFont` กำหนดแบบอักษรเริ่มต้นสำหรับข้อความปกติ ในขณะที่ `setDefaultAsianFont` กำหนดแบบอักษรเริ่มต้นสำหรับข้อความภาษาเอเชีย หลังจากตั้งค่าตัวเลือกเหล่านี้แล้ว การนำเสนอสามารถโหลดและเรนเดอร์โดยใช้แบบอักษรที่ระบุได้

## **ใช้แบบอักษรเริ่มต้นสำหรับการเรนเดอร์การนำเสนอ**
Aspose.Slides ให้คุณตั้งค่าแบบอักษรเริ่มต้นสำหรับการเรนเดอร์การนำเสนอเป็น PDF, XPS หรือภาพย่อ บทความนี้แสดงวิธีการกำหนด DefaultRegular Font และ DefaultAsian Font เพื่อใช้เป็นแบบอักษรเริ่มต้น กรุณาทำตามขั้นตอนด้านล่างเพื่อโหลดแบบอักษรจากไดเรกทอรีภายนอกโดยใช้ Aspose.Slides สำหรับ Java API:

1. สร้างอินสแตนซ์ของ [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/LoadOptions).
2. [ตั้งค่า DefaultRegularFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) ให้เป็นแบบอักษรที่คุณต้องการ ตัวอย่างต่อไปนี้ใช้ Wingdings.
3. [ตั้งค่า DefaultAsianFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) ให้เป็นแบบอักษรที่คุณต้องการ ตัวอย่างต่อไปนี้ใช้ Wingdings.
4. โหลดการนำเสนอโดยใช้คลาส Presentation และตั้งค่า load options.
5. จากนั้นสร้างภาพย่อของสไลด์, PDF และ XPS เพื่อตรวจสอบผลลัพธ์.

การทำงานของขั้นตอนข้างต้นแสดงไว้ด้านล่าง

```java
// ใช้ load options เพื่อกำหนดแบบอักษรเริ่มต้นสำหรับข้อความปกติและข้อความเอเชีย
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// โหลดการนำเสนอ
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // สร้างภาพย่อของสไลด์
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // บันทึกรูปภาพลงดิสก์.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // สร้าง PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // สร้าง XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**DefaultRegularFont และ DefaultAsianFont มีผลกระทบอย่างไรบ้าง—เฉพาะการส่งออกหรือรวมถึงภาพย่อ, PDF, XPS, HTML และ SVG ด้วยหรือไม่?**

พวกมันทำงานในขั้นตอนการเรนเดอร์สำหรับเอาต์พุตที่รองรับทั้งหมด ซึ่งรวมถึงภาพย่อของสไลด์, [PDF](/slides/th/java/convert-powerpoint-to-pdf/), [XPS](/slides/th/java/convert-powerpoint-to-xps/), [ภาพแรสเตอร์](/slides/th/java/convert-powerpoint-to-png/), [HTML](/slides/th/java/convert-powerpoint-to-html/), และ [SVG](/slides/th/java/render-a-slide-as-an-svg-image/), เนื่องจาก Aspose.Slides ใช้ตรรกะการจัดวางและการแก้ไข glyph เดียวกันสำหรับเป้าหมายเหล่านี้

**แบบอักษรเริ่มต้นจะถูกนำไปใช้เมื่ออ่านและบันทึกไฟล์ PPTX อย่างเดียวโดยไม่ทำการเรนเดอร์หรือไม่?**

ไม่. แบบอักษรเริ่มต้นมีผลเมื่อข้อความต้องถูกวัดและวาด การเปิด‑บันทึกโดยตรงของการนำเสนอจะไม่เปลี่ยนแปลงฟอนต์ที่จัดเก็บหรือโครงสร้างของไฟล์ แบบอักษรเริ่มต้นจะมีผลเฉพาะในการดำเนินการที่ต้องเรนเดอร์หรือจัดรูปข้อความใหม่

**หากฉันเพิ่มโฟลเดอร์ฟอนต์ของตนเองหรือจัดหาแบบอักษรจากหน่วยความจำ จะถูกพิจารณาเมื่อต้องเลือกแบบอักษรเริ่มต้นหรือไม่?**

ใช่. [Custom font sources](/slides/th/java/custom-font/) ขยายแคตาล็อกของฟอนต์และ glyph ที่มีให้เครื่องยนต์ใช้ แบบอักษรเริ่มต้นและ [fallback rules](/slides/th/java/fallback-font/) จะตรวจสอบแหล่งเหล่านั้นก่อน ทำให้ครอบคลุมได้อย่างเชื่อถือได้มากขึ้นบนเซิร์ฟเวอร์และในคอนเทนเนอร์

**แบบอักษรเริ่มต้นจะส่งผลต่อเมตริกของข้อความ (เช่น kerning, advances) ทำให้การตัดบรรทัดและการตัดคำเปลี่ยนแปลงหรือไม่?**

ใช่. การเปลี่ยนแบบอักษรจะเปลี่ยนเมตริกของ glyph และอาจทำให้การตัดบรรทัด, การตัดคำและการแบ่งหน้าเปลี่ยนแปลงระหว่างการเรนเดอร์ เพื่อความเสถียรของการจัดวาง ควร [embed the original fonts](/slides/th/java/embedded-font/) หรือเลือกฟอนต์เริ่มต้นและฟอนต์สำรองที่มีเมตริกเข้ากันได้

**มีประโยชน์ใด ๆ ในการตั้งค่าแบบอักษรเริ่มต้นหากฟอนต์ที่ใช้ทั้งหมดในการนำเสนอถูกฝังไว้แล้วหรือไม่?**

บ่อยครั้งไม่จำเป็น เนื่องจาก [embedded fonts](/slides/th/java/embedded-font/) รับประกันลักษณะการแสดงผลที่สม่ำเสมออยู่แล้ว แบบอักษรเริ่มต้นยังคงเป็นมาตรการสำรองสำหรับอักขระที่ฟอนต์ที่ฝังไว้ไม่ครอบคลุม หรือเมื่อไฟล์ผสมระหว่างข้อความที่ฝังและข้อความที่ไม่ได้ฝัง.