---
title: สร้างภาพขนาดย่อของรูปทรงการนำเสนอใน JavaScript
linktitle: ภาพขนาดย่อของรูปทรง
type: docs
weight: 70
url: /th/nodejs-java/create-shape-thumbnails/
keywords:
- ภาพขนาดย่อของรูปทรง
- ภาพรูปทรง
- เรนเดอร์รูปทรง
- การเรนเดอร์รูปทรง
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างภาพขนาดย่อของรูปทรงคุณภาพสูงจากสไลด์ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js – สร้างและส่งออกรูปขนาดย่อของงานนำเสนอได้อย่างง่ายดาย."
---
## **บทนำ**

Aspose.Slides ใช้ในการสร้างไฟล์งานนำเสนอที่แต่ละหน้าจะเป็นสไลด์ สไลด์เหล่านี้สามารถดูได้โดยการเปิดไฟล์งานนำเสนอด้วย Microsoft PowerPoint แต่บางครั้งนักพัฒนาอาจต้องการดูภาพของรูปร่างแยกต่างหากในโปรแกรมดูภาพ ในกรณีเช่นนี้ Aspose.Slides จะช่วยคุณสร้างภาพขนาดย่อของรูปร่างในสไลด์ วิธีการใช้ฟีเจอร์นี้จะอธิบายในบทความนี้  
บทความนี้อธิบายวิธีสร้างภาพย่อของสไลด์ในหลายรูปแบบ:

- สร้างภาพย่อของรูปร่างภายในสไลด์
- สร้างภาพย่อของรูปร่างสำหรับรูปร่างสไลด์โดยกำหนดขนาดตามผู้ใช้
- สร้างภาพย่อของรูปร่างในขอบเขตของการแสดงผลของรูปร่าง

## **สร้างภาพย่อของรูปร่างจากสไลด์**
เพื่อสร้างภาพย่อของรูปร่างจากสไลด์ใด ๆ โดยใช้ Aspose.Slides for Node.js ผ่าน Java ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation).
2. ดึงอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน.
3. [รับภาพย่อของรูปร่าง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getImage--) ของสไลด์ที่อ้างอิงโดยใช้สเกลเริ่มต้น.
4. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ.

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // สร้างภาพขนาดเต็มสเกล
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // บันทึกภาพลงดิสก์ในรูปแบบ PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **สร้างภาพย่อของรูปร่างด้วยอัตราส่วนการปรับขนาดที่กำหนดโดยผู้ใช้**
เพื่อสร้างภาพย่อของรูปร่างจากสไลด์โดยใช้ Aspose.Slides for Node.js ผ่าน Java ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation).
2. ดึงอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน.
3. [รับภาพย่อของรูปร่าง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) ของสไลด์ที่อ้างอิงโดยใช้ขนาดที่กำหนดโดยผู้ใช้.
4. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ.

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // สร้างภาพขนาดเต็มสเกล
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // บันทึกภาพลงดิสก์ในรูปแบบ PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **สร้างภาพย่อของรูปร่างตามขอบเขต**
วิธีการสร้างภาพย่อของรูปร่างนี้ช่วยให้นักพัฒนาสามารถสร้างภาพย่อภายในขอบเขตของการแสดงผลของรูปร่างได้ จะคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปร่าง ภาพย่อของรูปร่างที่สร้างจะถูกจำกัดโดยขอบเขตของสไลด์ เพื่อสร้างภาพย่อของรูปร่างในสไลด์ตามขอบเขตการแสดงผล ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation).
2. ดึงอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน.
3. รับภาพย่อของสไลด์ที่อ้างอิงโดยใช้ขอบเขตของรูปร่างเป็นการแสดงผล.
4. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ.

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // สร้างภาพขนาดเต็มสเกล
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // บันทึกภาพลงดิสก์ในรูปแบบ PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**รูปแบบภาพใดที่สามารถใช้เมื่อบันทึกภาพย่อของรูปร่าง?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imageformat/), และอื่น ๆ รูปร่างยังสามารถ [ส่งออกเป็นเวกเตอร์ SVG](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/writeassvg/) โดยบันทึกเนื้อหารูปร่างเป็น SVG.

**ความแตกต่างระหว่างขอบเขต Shape กับ Appearance เมื่อเรนเดอร์ภาพย่อคืออะไร?**  
`Shape` ใช้เรขาคณิตของรูปร่าง; `Appearance` คำนึงถึง [เอฟเฟกต์ภาพ](/slides/th/nodejs-java/shape-effect/) (เงา, แสงเรืองรอบ, ฯลฯ).

**จะเกิดอะไรขึ้นหากรูปร่างถูกทำเครื่องหมายว่าเป็น hidden? จะยังคงเรนเดอร์เป็นภาพย่อหรือไม่?**  
รูปร่างที่ซ่อนอยู่ยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธง hidden มีผลต่อการแสดงสไลด์โชว์แต่ไม่ได้หลุดการสร้างภาพของรูปร่าง.

**รองรับรูปแบบกลุ่มรูปร่าง, แผนภูมิ, SmartArt, และอ็อบเจกต์ซับซ้อนอื่น ๆ หรือไม่?**  
ใช่. อ็อบเจกต์ใด ๆ ที่เป็นตัวแทนเป็น [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) (รวมถึง [GroupShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/), และ [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartart/)) สามารถบันทึกเป็นภาพย่อหรือเป็น SVG ได้.

**ฟอนต์ที่ติดตั้งในระบบมีผลต่อคุณภาพของภาพย่อสำหรับรูปร่างข้อความหรือไม่?**  
ใช่. คุณควร [จัดหาแบบอักษรที่ต้องการ](/slides/th/nodejs-java/custom-font/) (หรือ [ตั้งค่าการแทนที่ฟอนต์](/slides/th/nodejs-java/font-substitution/)) เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรองที่ไม่ต้องการและการจัดเรียงข้อความใหม่.