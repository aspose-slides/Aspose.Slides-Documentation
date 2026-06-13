---
title: แปลงงานนำเสนอ PowerPoint เป็น GIF เคลื่อนไหวใน JavaScript
linktitle: PowerPoint เป็น GIF
type: docs
weight: 65
url: /th/nodejs-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF เคลื่อนไหว
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น GIF
- งานนำเสนอเป็น GIF
- สไลด์เป็น GIF
- PPT เป็น GIF
- PPTX เป็น GIF
- บันทึก PPT เป็น GIF
- บันทึก PPTX เป็น GIF
- ส่งออก PPT เป็น GIF
- ส่งออก PPTX เป็น GIF
- การตั้งค่าเริ่มต้น
- การตั้งค่ากำหนดเอง
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint (PPT, PPTX) เป็น GIF เคลื่อนไหวใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java อย่างง่ายและรวดเร็ว ให้ผลลัพธ์คุณภาพสูง"
---
## **ภาพรวม**

Aspose.Slides ให้คุณแปลงงานนำเสนอ PowerPoint เป็นไฟล์ GIF แบบเคลื่อนไหวได้ด้วยเพียงไม่กี่บรรทัดของโค้ด ซึ่งเป็นประโยชน์เมื่อคุณต้องการแชร์เนื้อหาสไลด์ในรูปแบบที่มีน้ำหนักเบา รองรับอย่างกว้างขวาง และสามารถฝังลงในหน้าเว็บ แชทเมสเซนเจอร์ หรือเอกสารต่าง ๆ บทความนี้อธิบายวิธีส่งออกงานนำเสนอเป็น GIF ด้วยการตั้งค่าเริ่มต้นและวิธีการปรับแต่งผลลัพธ์โดยกำหนดตัวเลือกต่าง ๆ เช่น ขนาดเฟรม ความหน่วงของสไลด์และอัตราเฟรมการเปลี่ยนผ่านผ่าน [GifOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/gifoptions/)  

## **การแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวด้วยการตั้งค่าเริ่มต้น**

ตัวอย่างโค้ดใน JavaScript นี้แสดงวิธีแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่ามาตรฐาน:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

GIF แบบเคลื่อนไหวจะถูกสร้างด้วยพารามิเตอร์เริ่มต้น  

{{%  alert  title="TIP"  color="primary"  %}} 
หากคุณต้องการปรับแต่งพารามิเตอร์สำหรับ GIF คุณสามารถใช้คลาส [GifOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GifOptions) ได้ ดูตัวอย่างโค้ดด้านล่าง. 
{{% /alert %}} 

## **การแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวด้วยการตั้งค่ากำหนดเอง**

ตัวอย่างโค้ดนี้แสดงวิธีแปลงงานนำเสนอเป็น GIF แบบเคลื่อนไหวโดยใช้การตั้งค่ากำหนดเองใน JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// ขนาดของ GIF ที่ได้
    gifOptions.setDefaultDelay(2000);// ระยะเวลาที่แต่ละสไลด์จะแสดงก่อนเปลี่ยนไปสไลด์ต่อไป
    gifOptions.setTransitionFps(35);// เพิ่ม FPS เพื่อคุณภาพการเปลี่ยนภาพที่ดียิ่งขึ้น
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
คุณอาจต้องการลองใช้ตัวแปลงฟรี [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) ที่พัฒนาโดย Aspose. 
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ถ้าแบบอักษรที่ใช้ในงานนำเสนอไม่ได้ติดตั้งบนระบบจะทำอย่างไร?**  
ติดตั้งแบบอักษรที่หายไปหรือ [กำหนดค่าแบบอักษรสำรอง](/slides/th/nodejs-java/powerpoint-fonts/). Aspose.Slides จะทำการแทนที่ แต่ลักษณะอาจแตกต่างกัน สำหรับการสร้างแบรนด์ ควรตรวจสอบให้แน่ใจว่าแบบอักษรที่จำเป็นมีให้ใช้อย่างชัดเจน  

**ฉันสามารถใส่วอเทอร์มาร์คทับบนเฟรมของ GIF ได้หรือไม่?**  
ได้. [เพิ่มวัตถุ/โลโก้กึ่งโปร่งแสง](/slides/th/nodejs-java/watermark/) ไปยังสไลด์หลักหรือสไลด์แต่ละสไลด์ก่อนการส่งออก — วอเทอร์มาร์คจะแสดงบนทุกเฟรม  