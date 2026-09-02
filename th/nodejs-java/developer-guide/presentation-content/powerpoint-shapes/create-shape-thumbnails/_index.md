---
title: สร้างรูปขนาดย่อของรูปทรงในพรีเซนเทชันด้วย JavaScript
linktitle: รูปขนาดย่อของรูปทรง
type: docs
weight: 70
url: /th/nodejs-java/create-shape-thumbnails/
keywords:
- รูปขนาดย่อของรูปทรง
- รูปภาพของรูปทรง
- เรนเดอร์รูปทรง
- การเรนเดอร์รูปทรง
- ขอบเขตการแสดงผล
- ขอบเขตของรูปทรง
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างรูปขนาดย่อของรูปทรงคุณภาพสูงจากสไลด์ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js – สร้างและส่งออกรูปขนาดย่อของพรีเซนเทชันได้อย่างง่ายดาย."
---
## **บทนำ**

Aspose.Slides ใช้สำหรับสร้างไฟล์พรีเซนเทชันที่แต่ละหน้าคือสไลด์ สไลด์เหล่านี้สามารถดูได้โดยการเปิดไฟล์พรีเซนเทชันด้วย Microsoft PowerPoint แต่บางครั้งนักพัฒนาอาจต้องการดูรูปภาพของรูปทรงแยกต่างหากในโปรแกรมดูรูป ในกรณีนั้น Aspose.Slides ช่วยคุณสร้างรูปภาพขนาดย่อของรูปทรงในสไลด์ วิธีการใช้คุณสมบัตินี้อธิบายไว้ในบทความนี้
บทความนี้อธิบายวิธีสร้างรูปขนาดย่อของสไลด์ในหลายวิธี:

- สร้างรูปขนาดย่อของรูปทรงภายในสไลด์
- สร้างรูปขนาดย่อของรูปทรงสไลด์โดยกำหนดขนาดเอง
- สร้างรูปขนาดย่อของรูปทรงในขอบเขตของลักษณะการแสดงผลของรูป

## **สร้างรูปขนาดย่อของรูปทรงจากสไลด์**
เพื่อสร้างรูปขนาดย่อของรูปทรงจากสไลด์ใด ๆ โดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
1. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน
1. [รับรูปขนาดย่อของรูปทรง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getImage--) ของสไลด์ที่อ้างอิงโดยใช้สเกลเริ่มต้น
1. บันทกรูปขนาดย่อในรูปแบบภาพที่คุณต้องการ

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // สร้างภาพขนาดเต็มสเกล
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // บันทึกภาพไปยังดิสก์ในรูปแบบ PNG
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

## **สร้างรูปขนาดย่อของรูปทรงด้วยปัจจัยสเกลที่กำหนดโดยผู้ใช้**
เพื่อสร้างรูปขนาดย่อของรูปทรงสไลด์โดยใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
1. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน
1. [รับรูปขนาดย่อของรูปทรง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) ของสไลด์ที่อ้างอิงด้วยขนาดที่กำหนดโดยผู้ใช้
1. บันทกรูปขนาดย่อในรูปแบบภาพที่คุณต้องการ

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // สร้างภาพขนาดเต็มสเกล
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // บันทึกภาพไปยังดิสก์ในรูปแบบ PNG
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

## **สร้างรูปขนาดย่อของรูปทรงตามขอบเขต**
วิธีนี้ช่วยให้นักพัฒนาสามารถสร้างรูปขนาดย่อที่อยู่ในขอบเขตของการแสดงผลของรูปทรงได้ โดยคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปทรง รูปขนาดย่อที่สร้างจะถูกจำกัดโดยขอบเขตของสไลด์ เพื่อสร้างรูปขนาดย่อของรูปทรงสไลด์ในขอบเขตของการแสดงผล ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
1. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน
1. รับภาพขนาดย่อของสไลด์ที่อ้างอิงโดยใช้ขอบเขตของรูปทรงเป็นลักษณะการแสดงผล
1. บันทกรูปขนาดย่อในรูปแบบภาพที่คุณต้องการ

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // สร้างภาพขนาดเต็มสเกล
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // บันทึกภาพไปยังดิสก์ในรูปแบบ PNG
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

## **รับขอบเขตการแสดงผลที่แท้จริงของรูปทรง**

คุณลักษณะของเฟรมของ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/)—เมธอด `getX()`, `getY()`, `getWidth()`, และ `getHeight()`—อธิบายสี่เหลี่ยมที่จัดเก็บในโมเดลพรีเซนเทชัน เนื้อหาที่จริง ๆ แล้วถูกเรนเดอร์อาจขยายออกนอกเฟรมนั้นหรืออยู่ในสี่เหลี่ยมที่จัดแนวตามแกนอื่น การหมุน, โครงร่าง, ปลายลูกศร, การจัดเลย์เอาต์และการล้นของข้อความ, รูปทรง SmartArt ที่สร้างขึ้น, และเอฟเฟกต์การเรนเดอร์อื่น ๆ สามารถเปลี่ยนพื้นที่ที่ครอบคลุมได้

ใช้ [Shape.getVisualBounds](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getVisualBounds--) เพื่อคำนวณพื้นที่ที่ครอบคลุมโดยไม่ต้องสร้างภาพ เมธอดจะคืนอ็อบเจกต์ [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) ในพิกัดของสไลด์ สี่เหลี่ยมที่คืนค่าจะไม่ถูกคลิปกับสไลด์ ดังนั้นพิกัดอาจเป็นค่าลบเมื่อเนื้อหาขยายออกนอกจุดกำเนิดของสไลด์

ตัวอย่างต่อไปนี้รับและเปรียบเทียบเฟรมกับขอบเขตการแสดงผล:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

สี่เหลี่ยมเดียวกันนี้สามารถใช้จัดตำแหน่งรูปทรงใกล้เคียงให้ชิดด้านซ้าย, ขวา, บนหรือล่าง; จัดสรรพื้นที่เพียงพอในเลย์เอาต์ที่สร้าง; หรือระบุเนื้อหานอกเขตที่อนุญาต ขอบเขตการแสดงผลมีประโยชน์เป็นพิเศษสำหรับ SmartArt, กล่องข้อความ, ลูกศร, รูปภาพ, รูปทรงที่หมุน, และรูปทรงกลุ่มที่เฟรมที่เก็บอาจไม่สอดคล้องกับผลลัพธ์ที่เรนเดอร์เต็มรูปแบบ

ใช้ [Shape.getVisualBounds](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getVisualBounds--) เมื่อคุณต้องการพิกัดสำหรับการจัดเลย์เอาต์หรือการตรวจสอบและไม่ต้องการบิตแมป ใช้ [Shape.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getImage--) เมื่อคุณต้องการเรนเดอร์รูปทรง ด้วย [ShapeThumbnailBounds](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds.Shape` ปรับขนาดภาพจากขอบเขตของรูปทรงรวมถึงการตั้งค่าโครงร่างขณะที่ `ShapeThumbnailBounds.Appearance` ปรับขนาดจากการแสดงผลของรูปทรงและจำกัดผลลัพธ์ให้อยู่ในขอบเขตของสไลด์ ในทางตรงกันข้าม [Shape.getVisualBounds](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getVisualBounds--) จะคืนเฉพาะสี่เหลี่ยมที่คำนวณได้และไม่คลิปกับสไลด์

## **คำถามที่พบบ่อย**

**รูปแบบภาพใดบ้างที่สามารถใช้เมื่อบันทึกรูปขนาดย่อของรูปทรง?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imageformat/), and others. รูปทรงยังสามารถ [ส่งออกเป็นเวกเตอร์ SVG](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/writeassvg/) โดยบันทึกเนื้อหาของรูปทรงเป็น SVG.

**ความแตกต่างระหว่างขอบเขต Shape และ Appearance เมื่อเรนเดอร์รูปขนาดย่อคืออะไร?**

`Shape` ใช้รูปทรงทางเรขาคณิตของรูป; `Appearance` พิจารณา [visual effects](/slides/th/nodejs-java/shape-effect/) (เงา, แสงเรืองแสง ฯลฯ) ในการคำนวณ

**จะเกิดอะไรขึ้นหากรูปทรงถูกทำเครื่องหมายว่าเป็นซ่อน? จะยังคงเรนเดอร์เป็นรูปขนาดย่อหรือไม่?**

รูปทรงที่ซ่อนจะยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธงซ่อนมีผลต่อการแสดงผลสไลด์โชว์แต่ไม่ป้องกันการสร้างภาพของรูปทรง

**รูปทรงกลุ่ม, แผนภูมิ, SmartArt และวัตถุซับซ้อนอื่น ๆ รองรับหรือไม่?**

ใช่. วัตถุใด ๆ ที่แสดงเป็น [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) (รวมถึง [GroupShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/), และ [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartart/)) สามารถบันทึกเป็นรูปขนาดย่อหรือเป็น SVG

**ฟอนท์ที่ติดตั้งในระบบมีผลต่อคุณภาพของรูปขนาดย่อสำหรับรูปทรงข้อความหรือไม่?**

ใช่. คุณควร [provide the required fonts](/slides/th/nodejs-java/custom-font/) (หรือ [configure font substitutions](/slides/th/nodejs-java/font-substitution/)) เพื่อหลีกเลี่ยงการใช้ฟอนท์สำรองที่ไม่ต้องการและการจัดเรียงข้อความใหม่.