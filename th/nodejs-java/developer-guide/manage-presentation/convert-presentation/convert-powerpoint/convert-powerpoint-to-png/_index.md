---
title: แปลงสไลด์ PowerPoint เป็น PNG ด้วย JavaScript
linktitle: PowerPoint เป็น PNG
type: docs
weight: 30
url: /th/nodejs-java/convert-powerpoint-to-png/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น PNG
- งานนำเสนอเป็น PNG
- สไลด์เป็น PNG
- PPT เป็น PNG
- PPTX เป็น PNG
- บันทึก PPT เป็น PNG
- บันทึก PPTX เป็น PNG
- ส่งออก PPT เป็น PNG
- ส่งออก PPTX เป็น PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็นภาพ PNG คุณภาพสูงด้วย JavaScript อย่างรวดเร็วโดยใช้ Aspose.Slides สำหรับ Node.js เพื่อให้ได้ผลลัพธ์ที่แม่นยำและอัตโนมัติ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint เป็นภาพ PNG โดยใช้ Aspose.Slides จะอธิบายวิธีโหลดไฟล์งานนำเสนอในรูปแบบต่าง ๆ เช่น PPT, PPTX และ ODP, เรนเดอร์สไลด์เป็นภาพ, และบันทึกผลลัพธ์เป็นรูปแบบ PNG

บทความยังแสดงวิธีการปรับแต่งภาพ PNG ที่สร้างขึ้นโดยการกำหนดค่าตำแหน่งสเกลหรือระบุความกว้างและความสูงที่ต้องการ

## **แปลง PowerPoint เป็น PNG**

ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
2. ดึงอ็อบเจกต์สไลด์จากคอลเลกชันที่เมธอด [Presentation.getSlides()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) คืนค่าในคลาส [Slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Slide)
3. ใช้เมธอด [Slide.getImage()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Slide) เพื่อรับภาพย่อของแต่ละสไลด์
4. ใช้เมธอด [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/#save) เพื่อบันทึกภาพย่อสไลด์เป็นรูปแบบ PNG

โค้ด JavaScript นี้แสดงวิธีแปลงงานนำเสนอ PowerPoint เป็น PNG:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **แปลง PowerPoint เป็น PNG พร้อมขนาดที่กำหนดเอง**

หากคุณต้องการไฟล์ PNG ที่มีสเกลตามที่กำหนด สามารถตั้งค่าตัวแปร `desiredX` และ `desiredY` ซึ่งกำหนดมิติของภาพย่อที่ได้

โค้ด JavaScript นี้สาธิตการทำงานตามที่อธิบาย:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **แปลง PowerPoint เป็น PNG พร้อมขนาดที่กำหนดเอง**

หากคุณต้องการไฟล์ PNG ที่มีขนาดตามที่กำหนด สามารถส่งอาร์กิวเมนต์ `width` และ `height` ที่ต้องการสำหรับ `ImageSize` ได้

โค้ดนี้แสดงวิธีแปลง PowerPoint เป็น PNG พร้อมระบุขนาดของภาพ:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันจะส่งออกเฉพาะรูปร่าง (เช่น แผนภูมิหรือรูปภาพ) เท่านั้นแทนการส่งออกรูปภาพทั้งหมดได้อย่างไร?**

Aspose.Slides รองรับ [generating thumbnails for individual shapes](/slides/th/nodejs-java/create-shape-thumbnails/); คุณสามารถเรนเดอร์รูปร่างเป็นภาพ PNG ได้

**การแปลงแบบขนานได้รับการสนับสนุนบนเซิร์ฟเวอร์หรือไม่?**

ใช่ แต่ต้อง [don’t share](/slides/th/nodejs-java/multithreading/) อินสแตนซ์ Presentation เดียวกันข้ามเธรด ใช้อินสแตนซ์แยกสำหรับแต่ละเธรดหรือโปรเซส

**มีข้อจำกัดของรุ่นทดลองอย่างไรเมื่อส่งออกเป็น PNG?**

โหมดประเมินผลจะเพิ่มลายน้ำลงในภาพผลลัพธ์และบังคับใช้ [other restrictions](/slides/th/nodejs-java/licensing/) จนกว่าจะมีการใช้ลิขสิทธิ์  