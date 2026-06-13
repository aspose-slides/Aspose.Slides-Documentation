---
title: กำหนดแบบอักษรเริ่มต้นสำหรับการนำเสนอบน Android
linktitle: แบบอักษรเริ่มต้น
type: docs
weight: 30
url: /th/androidjava/default-font/
keywords:
- แบบอักษรเริ่มต้น
- แบบอักษรปกติ
- แบบอักษรธรรมดา
- แบบอักษรเอเชีย
- การส่งออก PDF
- การส่งออก XPS
- การส่งออกรูปภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ตั้งค่าแบบอักษรเริ่มต้นใน Aspose.Slides สำหรับ Android ผ่าน Java เพื่อให้การแปลง PowerPoint (PPT, PPTX) และ OpenDocument (ODP) ไปเป็น PDF, XPS และรูปภาพทำได้อย่างถูกต้อง."
---
## **ภาพรวม**

Aspose.Slides อนุญาตให้คุณกำหนดแบบอักษรเริ่มต้นที่ใช้เมื่อการนำเสนอถูกเรนเดอร์ ซึ่งเป็นประโยชน์เมื่อต้องสร้างภาพย่อของสไลด์หรือส่งออกการนำเสนอเป็นรูปแบบต่าง ๆ เช่น PDF และ XPS แบบอักษรเริ่มต้นจะถูกกำหนดผ่าน `LoadOptions` ก่อนที่จะโหลดการนำเสนอ

`setDefaultRegularFont` กำหนดแบบอักษรเริ่มต้นสำหรับข้อความทั่วไป ในขณะที่ `setDefaultAsianFont` กำหนดแบบอักษรเริ่มต้นสำหรับข้อความเอเชีย หลังจากตั้งค่าเหล่านี้แล้ว การนำเสนอสามารถโหลดและเรนเดอร์โดยใช้แบบอักษรที่ระบุได้

## **ใช้แบบอักษรเริ่มต้นสำหรับการเรนเดอร์การนำเสนอ**
Aspose.Slides ให้คุณตั้งค่าแบบอักษรเริ่มต้นสำหรับการเรนเดอร์การนำเสนอเป็น PDF, XPS หรือภาพย่อ บทความนี้แสดงวิธีกำหนด DefaultRegular Font และ DefaultAsian Font เพื่อใช้เป็นแบบอักษรเริ่มต้น โปรดทำตามขั้นตอนด้านล่างเพื่อโหลดแบบอักษรจากไดเรกทอรีภายนอกโดยใช้ Aspose.Slides สำหรับ Android ผ่าน Java API:

1. สร้างอินสแตนซ์ของ [LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LoadOptions).
2. [ตั้งค่า DefaultRegularFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) ตามแบบอักษรที่คุณต้องการ ตัวอย่างต่อไปนี้ฉันใช้ Wingdings.
3. [ตั้งค่า DefaultAsianFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) ตามแบบอักษรที่คุณต้องการ ฉันใช้ Wingdings ในตัวอย่างต่อไปนี้.
4. โหลดการนำเสนอโดยใช้ Presentation และตั้งค่า load options.
5. ตอนนี้สร้างภาพย่อของสไลด์, PDF และ XPS เพื่อตรวจสอบผลลัพธ์.

การดำเนินการของข้างต้นแสดงด้านล่าง

```java
// ใช้ตัวเลือกการโหลดเพื่อกำหนดแบบอักษรปกติและแบบอักษรเอเชียเริ่มต้น
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// โหลดการนำเสนอ
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // สร้างภาพย่อของสไลด์
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // บันทึกรูปภาพลงในดิสก์.
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

**DefaultRegularFont และ DefaultAsianFont มีผลกระทบอย่างไรบ้าง—เฉพาะการส่งออกหรือรวมถึงภาพย่อ, PDF, XPS, HTML และ SVG ด้วย?**

พวกมันทำงานร่วมในกระบวนการเรนเดอร์สำหรับผลลัพธ์ที่สนับสนุนทั้งหมด ซึ่งรวมถึงภาพย่อของสไลด์, [PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/th/androidjava/convert-powerpoint-to-xps/), [raster images](/slides/th/androidjava/convert-powerpoint-to-png/), [HTML](/slides/th/androidjava/convert-powerpoint-to-html/), และ [SVG](/slides/th/androidjava/render-a-slide-as-an-svg-image/), เนื่องจาก Aspose.Slides ใช้ตรรกะการจัดวางและการแก้ไข glyph เดียวกันในเป้าหมายเหล่านี้.

**แบบอักษรเริ่มต้นจะถูกนำไปใช้เมื่อเพียงอ่านและบันทึกไฟล์ PPTX โดยไม่ทำการเรนเดอร์หรือไม่?**

ไม่. แบบอักษรเริ่มต้นมีผลเมื่อจำเป็นต้องวัดและวาดข้อความ การบันทึกเปิด‑บันทึกของการนำเสนอโดยตรงจะไม่เปลี่ยนแปลงฟอนต์รันที่จัดเก็บหรือโครงสร้างของไฟล์ แบบอักษรเริ่มต้นจะถูกใช้ในการดำเนินการที่เรนเดอร์หรือจัดข้อความใหม่.

**ถ้าฉันเพิ่มโฟลเดอร์แบบอักษรของตัวเองหรือจัดหาแบบอักษรจากหน่วยความจำ จะถูกพิจารณาเมื่อตัดสินใจเลือกแบบอักษรเริ่มต้นหรือไม่?**

ใช่. [Custom font sources](/slides/th/androidjava/custom-font/) ขยายแคตตาล็อกของฟอนต์และ glyph ที่เครื่องยนต์สามารถใช้ได้ แบบอักษรเริ่มต้นและกฎการสำรองใด ๆ จะทำการ resolve กับแหล่งเหล่านั้นก่อน ทำให้ครอบคลุมได้เชื่อถือได้มากขึ้นบนเซิร์ฟเวอร์และในคอนเทนเนอร์.

**แบบอักษรเริ่มต้นจะส่งผลต่อเมตริกของข้อความ (kerning, advances) และดังนั้นจึงมีผลต่อการตัดบรรทัดและการห่อหุ้มข้อความหรือไม่?**

ใช่. การเปลี่ยนแบบอักษรเปลี่ยนเมตริกของ glyph และอาจทำให้เกิดการเปลี่ยนแปลงการตัดบรรทัด, การห่อหุ้ม, และการแบ่งหน้าในระหว่างการเรนเดอร์ เพื่อความเสถียรของการจัดวาง, [embed the original fonts](/slides/th/androidjava/embedded-font/) หรือเลือกฟอนต์เริ่มต้นและสำรองที่เข้ากันตามเมตริก.

**มีเหตุผลใดที่จะตั้งค่าแบบอักษรเริ่มต้นหากฟอนต์ทั้งหมดที่ใช้ในการนำเสนอถูกฝังไว้แล้วหรือไม่?**

บ่อยครั้งไม่จำเป็น เนื่องจาก [embedded fonts](/slides/th/androidjava/embedded-font/) ได้รับประกันความสอดคล้องของการแสดงผลแล้ว แบบอักษรเริ่มต้นยังคงเป็นเครือข่ายความปลอดภัยสำหรับอักขระที่ไม่ได้ครอบคลุมโดยชุดฟอนต์ที่ฝังไว้หรือเมื่อไฟล์ผสมฟอนต์ที่ฝังและไม่ฝัง.