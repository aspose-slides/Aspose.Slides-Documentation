---
title: แปลง PPT และ PPTX เป็น JPG ด้วย JavaScript
linktitle: PowerPoint เป็น JPG
type: docs
weight: 60
url: /th/nodejs-java/convert-powerpoint-to-jpg/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น JPG
- งานนำเสนอเป็น JPG
- สไลด์เป็น JPG
- PPT เป็น JPG
- PPTX เป็น JPG
- บันทึก PowerPoint เป็น JPG
- บันทึกงานนำเสนอเป็น JPG
- บันทึกสไลด์เป็น JPG
- บันทึก PPT เป็น JPG
- บันทึก PPTX เป็น JPG
- ส่งออก PPT เป็น JPG
- ส่งออก PPTX เป็น JPG
- Node.js
- JavaScript
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint (PPT, PPTX) เป็นภาพ JPG คุณภาพสูงใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java โดยใช้ตัวอย่างโค้ดที่เร็วและเชื่อถือได้."
---
## **คำนำ**

การแปลงงานนำเสนอ PowerPoint และ OpenDocument ไปเป็นภาพ JPG ช่วยในการแชร์สไลด์, ปรับประสิทธิภาพ, และฝังเนื้อหาในเว็บไซต์หรือแอปพลิเคชัน Aspose.Slides อนุญาตให้คุณแปลงไฟล์ PPTX, PPT, และ ODP เป็นภาพ JPEG คุณภาพสูง คู่มือนี้อธิบายวิธีต่าง ๆ สำหรับการแปลง

ด้วยคุณลักษณะเหล่านี้ การสร้างตัวดูงานนำเสนอของคุณเองและสร้างภาพย่อของทุกสไลด์ทำได้ง่าย อาจเป็นประโยชน์หากคุณต้องการป้องกันการคัดลอกสไลด์หรือแสดงงานนำเสนอในโหมดอ่านอย่างเดียว Aspose.Slides อนุญาตให้คุณแปลงงานนำเสนอทั้งหมดหรือสไลด์เฉพาะเป็นรูปแบบภาพ

## **แปลง PowerPoint PPT/PPTX เป็น JPG**

1. สร้างอินสแตนซ์ของประเภท [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
2. เรียกออบเจ็กต์สไลด์ของประเภท [Slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Slide) จากคอลเลกชัน [Presentation.getSlides()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--)  
3. สร้างภาพย่อของแต่ละสไลด์แล้วแปลงเป็น JPG. วิธีการ [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Slide#getImage-float-float-) ถูกใช้เพื่อรับภาพย่อของสไลด์, จะคืนค่าอ็อบเจ็กต์ [Imagess](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Images) เป็นผลลัพธ์. วิธีการ [getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) ต้องถูกเรียกจากสไลด์ที่ต้องการของประเภท [Slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Slide), โดยส่งค่าการสเกลของภาพย่อที่ต้องการเข้าไปในเมธอด.  
4. หลังจากที่คุณได้ภาพย่อของสไลด์แล้ว ให้เรียกวิธีการ [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/#save) จากอ็อบเจ็กต์ภาพย่อ. ส่งชื่อไฟล์ผลลัพธ์และรูปแบบภาพเข้าไปในเมธอดนั้น.  

{{% alert color="primary" %}}
**หมายเหตุ**: การแปลง PPT/PPTX ไป JPG มีความแตกต่างจากการแปลงเป็นประเภทอื่นใน Aspose.Slides API. สำหรับประเภทอื่นคุณมักใช้ [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) แต่ที่นี่คุณต้องใช้ [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/#save) 
{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // สร้างภาพขนาดเต็มสเกล
        var slideImage = sld.getImage(1.0, 1.0);
        // บันทึกภาพลงดิสก์ในรูปแบบ JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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

## **แปลง PowerPoint PPT/PPTX เป็น JPG พร้อมขนาดที่กำหนดเอง**

เพื่อเปลี่ยนขนาดของภาพย่อและภาพ JPG ที่ได้, คุณสามารถตั้งค่า *ScaleX* และ *ScaleY* ได้โดยส่งค่าเหล่านั้นเข้าไปในเมธอด [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Slide#getImage-float-float-) :

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // กำหนดมิติ
    var desiredX = 1200;
    var desiredY = 800;
    // รับค่าการสเกลของ X และ Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // สร้างภาพขนาดเต็มสเกล
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // บันทึกภาพลงดิสก์ในรูปแบบ JPEG
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
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

## **เรนเดอร์คอมเมนต์เมื่อบันทึกงานนำเสนอเป็นภาพ**

Aspose.Slides สำหรับ Node.js ผ่าน Java มีฟีเจอร์ที่อนุญาตให้คุณเรนเดอร์คอมเมนต์ในสไลด์ของงานนำเสนอเมื่อต้องการแปลงสไลด์เหล่านั้นเป็นภาพ โค้ด JavaScript นี้แสดงการทำงาน:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
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

{{% alert title="Tip" color="primary" %}}
Aspose ให้บริการ [FREE Collage web app](https://products.aspose.app/slides/th/collage). โดยใช้บริการออนไลน์นี้ คุณสามารถรวมภาพ [JPG to JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG to PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) และอื่น ๆ 
{{% /alert %}}

## **ดูเพิ่มเติม**

ดูตัวเลือกอื่น ๆ สำหรับการแปลง PPT/PPTX เป็นภาพ เช่น:

- [การแปลง PPT/PPTX เป็น SVG](/slides/th/nodejs-java/render-a-slide-as-an-svg-image/).

## **คำถามที่พบบ่อย**

**วิธีนี้รองรับการแปลงเป็นชุดหรือไม่?**  
ใช่, Aspose.Slides รองรับการแปลงเป็นชุดของหลายสไลด์เป็น JPG ในการดำเนินการเดียว  

**การแปลงรองรับ SmartArt, แผนภูมิ, และวัตถุซับซ้อนอื่น ๆ หรือไม่?**  
ใช่, Aspose.Slides จะเรนเดอร์เนื้อหาทั้งหมดรวมถึง SmartArt, แผนภูมิ, ตาราง, รูปร่าง และอื่น ๆ อย่างไรก็ตาม ความแม่นยำของการเรนเดอร์อาจแตกต่างเล็กน้อยจาก PowerPoint, โดยเฉพาะเมื่อใช้ฟอนต์ที่กำหนดเองหรือฟอนต์ที่หายไป  

**มีข้อจำกัดใด ๆ เกี่ยวกับจำนวนสไลด์ที่สามารถประมวลผลได้หรือไม่?**  
Aspose.Slides เองไม่กำหนดขีดจำกัดที่เคร่งครัดเกี่ยวกับจำนวนสไลด์ที่คุณสามารถประมวลผลได้ อย่างไรก็ตาม คุณอาจเจอข้อผิดพลาด out-of-memory เมื่อทำงานกับงานนำเสนอขนาดใหญ่หรือภาพความละเอียดสูง