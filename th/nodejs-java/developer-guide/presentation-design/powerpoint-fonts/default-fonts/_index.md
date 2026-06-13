---
title: ระบุแบบอักษรเริ่มต้นสำหรับการนำเสนอใน JavaScript
linktitle: แบบอักษรเริ่มต้น
type: docs
weight: 30
url: /th/nodejs-java/default-font/
keywords:
- แบบอักษรเริ่มต้น
- แบบอักษรทั่วไป
- แบบอักษรปกติ
- แบบอักษรเอเชีย
- ส่งออก PDF
- ส่งออก XPS
- ส่งออกภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ตั้งค่าแบบอักษรเริ่มต้นใน Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อให้การแปลง PowerPoint (PPT, PPTX) และ OpenDocument (ODP) เป็น PDF, XPS และภาพทำได้อย่างถูกต้อง"
---
## **ภาพรวม**

Aspose.Slides ให้คุณกำหนดแบบอักษรเริ่มต้นที่ใช้เมื่อทำการเรนเดอร์การนำเสนอ ซึ่งเป็นประโยชน์เมื่อต้องสร้างภาพย่อของสไลด์หรือส่งออกการนำเสนอเป็นรูปแบบต่าง ๆ เช่น PDF และ XPS แบบอักษรเริ่มต้นสามารถกำหนดได้ผ่าน `LoadOptions` ก่อนที่การนำเสนอจะถูกโหลด

เมธอด `setDefaultRegularFont` กำหนดแบบอักษรเริ่มต้นสำหรับข้อความทั่วไป ในขณะที่ `setDefaultAsianFont` กำหนดแบบอักษรเริ่มต้นสำหรับข้อความเอเชีย หลังจากตั้งค่าเหล่านี้แล้ว การนำเสนอสามารถโหลดและเรนเดอร์โดยใช้แบบอักษรที่ระบุได้

## **ใช้แบบอักษรเริ่มต้นสำหรับการเรนเดอร์การนำเสนอ**

Aspose.Slides ช่วยให้คุณตั้งค่าแบบอักษรเริ่มต้นสำหรับการเรนเดอร์การนำเสนอเป็น PDF, XPS หรือภาพย่อ บทความนี้จะแสดงวิธีกำหนด DefaultRegularFont และ DefaultAsianFont เพื่อใช้เป็นแบบอักษรเริ่มต้น โปรดทำตามขั้นตอนด้านล่างเพื่อโหลดแบบอักษรจากไดเรกทอรีภายนอกโดยใช้ Aspose.Slides for Node.js ผ่าน Java API:

1. สร้างอินสแตนซ์ของ [LoadOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/LoadOptions)  
2. [Set the DefaultRegularFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) ไปยังแบบอักษรที่คุณต้องการ ในตัวอย่างต่อไปนี้เราใช้ Wingdings  
3. [Set the DefaultAsianFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) ไปยังแบบอักษรที่คุณต้องการ เราใช้ Wingdings ในตัวอย่างต่อไปนี้  
4. โหลดการนำเสนอโดยใช้ Presentation และตั้งค่า load options  
5. จากนั้นสร้างภาพย่อของสไลด์, PDF และ XPS เพื่อตรวจสอบผลลัพธ์  

การดำเนินการตามขั้นตอนด้านบนมีดังนี้

```javascript
// ใช้ตัวเลือกการโหลดเพื่อกำหนดแบบอักษรเริ่มต้นสำหรับข้อความทั่วไปและเอเชีย
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// โหลดการนำเสนอ
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // สร้างภาพย่อของสไลด์
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // บันทึกภาพลงในดิสก์.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // สร้าง PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // สร้าง XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**DefaultRegularFont และ DefaultAsianFont มีผลต่ออะไรบ้าง—เฉพาะการส่งออกหรือรวมถึงภาพย่อ, PDF, XPS, HTML, และ SVG ด้วยหรือไม่?**

พวกมันมีส่วนร่วมใน pipeline การเรนเดอร์สำหรับผลลัพธ์ที่รองรับทั้งหมด ซึ่งรวมถึงภาพย่อของสไลด์, [PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/th/nodejs-java/convert-powerpoint-to-xps/), [raster images](/slides/th/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/th/nodejs-java/convert-powerpoint-to-html/), และ [SVG](/slides/th/nodejs-java/render-a-slide-as-an-svg-image/) เนื่องจาก Aspose.Slides ใช้ตรรกะการจัดรูปแบบและการแก้ปัญหา glyph เดียวกันสำหรับเป้าหมายเหล่านี้

**แบบอักษรเริ่มต้นจะถูกนำไปใช้เมื่อทำการอ่านและบันทึก PPTX โดยไม่ทำการเรนเดอร์ใด ๆ หรือไม่?**

ไม่ใช่ แบบอักษรเริ่มต้นมีผลเมื่อจำเป็นต้องวัดและวาดข้อความ การบันทึกเปิด‑ปิดโดยตรงของการนำเสนอจะไม่เปลี่ยนแปลงฟอนต์รันหรือโครงสร้างไฟล์แบบอักษรเริ่มต้นจะเข้ามาใช้เฉพาะในกระบวนการที่ทำการเรนเดอร์หรือจัดรูปแบบข้อความใหม่

**หากฉันเพิ่มโฟลเดอร์แบบอักษรของตัวเองหรือให้แบบอักษรจากหน่วยความจำ จะถูกพิจารณาเมื่อเลือกแบบอักษรเริ่มต้นหรือไม่?**

ใช่ การใช้ [Custom font sources](/slides/th/nodejs-java/custom-font/) จะขยายแคตตาล็อกของฟอนต์และ glyph ที่เอนจินสามารถใช้ได้ แบบอักษรเริ่มต้นและกฎ [fallback](/slides/th/nodejs-java/fallback-font/) จะตรวจสอบแหล่งเหล่านี้ก่อน ซึ่งทำให้การครอบคลุมบนเซิร์ฟเวอร์และคอนเทนเนอร์มีความน่าเชื่อถือมากขึ้น

**แบบอักษรเริ่มต้นจะส่งผลต่อเมตริกของข้อความ (เช่น kerning, advances) และทำให้การตัดบรรทัดและการเวราบล็อกเปลี่ยนแปลงหรือไม่?**

ใช่ การเปลี่ยนแบบอักษรจะเปลี่ยนเมตริกของ glyph และอาจทำให้การตัดบรรทัด, การเวราบล็อก, และการแบ่งหน้าในการเรนเดอร์เปลี่ยนแปลงได้ เพื่อความเสถียรของเลย์เอาต์ ควร [embed the original fonts](/slides/th/nodejs-java/embedded-font/) หรือเลือกฟอนต์เริ่มต้นและ fallback ที่มีเมตริกสอดคล้องกัน

**มีความจำเป็นต้องตั้งค่าแบบอักษรเริ่มต้นหรือไม่ หากฟอนต์ทั้งหมดที่ใช้ในการนำเสนอถูกฝังไว้แล้ว?**

โดยส่วนมากไม่จำเป็น เพราะ [embedded fonts](/slides/th/nodejs-java/embedded-font/) ทำให้รูปแบบคงที่อยู่แล้ว อย่างไรก็ตามแบบอักษรเริ่มต้นยังคงทำหน้าที่เป็นเครือข่ายความปลอดภัยสำหรับอักขระที่ไม่ครอบคลุมโดยฟอนต์ที่ฝัง หรือเมื่อไฟล์ผสมผสานข้อความที่ฝังและไม่ฝังเข้าด้วยกัน