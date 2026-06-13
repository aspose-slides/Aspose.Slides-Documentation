---
title: สร้างภาพย่อของรูปร่างพรีเซนเทชันใน Java
linktitle: ภาพย่อรูปร่าง
type: docs
weight: 70
url: /th/java/create-shape-thumbnails/
keywords:
- ภาพย่อรูปร่าง
- รูปภาพรูปร่าง
- เรนเดอร์รูปร่าง
- การเรนเดอร์รูปร่าง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างภาพย่อของรูปร่างคุณภาพสูงจากสไลด์ PowerPoint ด้วย Aspose.Slides for Java - สร้างและส่งออกรูปภาพย่อของพรีเซนเทชันได้อย่างง่ายดาย."
---
## **บทนำ**

Aspose.Slides for Java สามารถใช้สร้างไฟล์พรีเซนเทชันที่แต่ละหน้าตรงกับสไลด์ได้ สไลด์สามารถดูได้โดยเปิดไฟล์พรีเซนเทชันด้วย Microsoft PowerPoint อย่างไรก็ตามนักพัฒนาบางครั้งต้องการดูรูปภาพของรูปร่างแยกออกในโปรแกรมดูรูปภาพ ในกรณีดังกล่าว Aspose.Slides for Java ช่วยให้พวกเขาสร้างภาพย่อของรูปร่างในสไลด์ได้

บทความนี้อธิบายวิธีการสร้างภาพย่อของสไลด์ในหลายวิธี:

- สร้างภาพย่อของรูปร่างภายในสไลด์
- สร้างภาพย่อของรูปร่างในสไลด์โดยกำหนดขนาดตามผู้ใช้
- สร้างภาพย่อของรูปร่างภายในขอบเขตการแสดงผลของรูปร่าง

## **สร้างภาพย่อของรูปร่างจากสไลด์**

เพื่อสร้างภาพย่อของรูปร่างจากสไลด์ใด ๆ ด้วย Aspose.Slides for Java ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
1. ดึงอ้างอิงของสไลด์ใด ๆ ด้วย ID หรือ index ของมัน
1. [รับภาพย่อของรูปร่าง](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#getImage--) ของสไลด์ที่อ้างอิงโดยใช้สเกลค่าเริ่มต้น
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ

โค้ดตัวอย่างต่อไปนี้แสดงวิธีสร้างภาพย่อของรูปร่างจากสไลด์:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // สร้างภาพเต็มสเกล
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // บันทึกภาพลงดิสก์ในรูปแบบ PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **สร้างภาพย่อด้วยอัตราส่วนการขยายที่กำหนดโดยผู้ใช้**

เพื่อสร้างภาพย่อของรูปร่างในสไลด์ด้วย Aspose.Slides for Java ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
1. ดึงอ้างอิงของสไลด์ใด ๆ ด้วย ID หรือ index ของมัน
1. [รับภาพย่อของรูปร่าง](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape#getImage-int-float-float-) ของสไลด์ที่อ้างอิงด้วยขนาดที่กำหนดโดยผู้ใช้
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ

โค้ดตัวอย่างต่อไปนี้แสดงวิธีสร้างภาพย่อของรูปร่างโดยอิงจากอัตราส่วนการขยายที่กำหนด:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // สร้างภาพเต็มสเกล
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // บันทึกภาพลงดิสก์ในรูปแบบ PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **สร้างภาพย่อของรูปร่างตามขอบเขตการแสดงผล**

วิธีนี้ในการสร้างภาพย่อของรูปร่างช่วยให้นักพัฒนาสามารถสร้างภาพย่อภายในขอบเขตการแสดงผลของรูปร่างได้ โดยคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปร่าง ภาพย่อที่สร้างจะถูกจำกัดโดยขอบเขตของสไลด์ เพื่อสร้างภาพย่อของรูปร่างสไลด์ภายในขอบเขตการแสดงผลทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
1. ดึงอ้างอิงของสไลด์ใด ๆ ด้วย ID หรือ index ของมัน
1. ดึงภาพย่อของสไลด์ที่อ้างอิงโดยใช้ขอบเขตรูปร่างเป็นการแสดงผล
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ

โค้ดตัวอย่างต่อไปนี้อ้างอิงจากขั้นตอนข้างต้น:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // สร้างภาพเต็มสเกล
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // บันทึกภาพลงดิสก์ในรูปแบบ PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**รูปแบบภาพใดบ้างที่สามารถใช้เมื่อบันทึกภาพย่อของรูปร่าง?**

รูปแบบ [PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/java/com.aspose.slides/imageformat/), เป็นต้น รูปร่างยังสามารถ [ส่งออกเป็นเวกเตอร์ SVG](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) โดยบันทึกเนื้อหารูปร่างเป็น SVG.

**ความแตกต่างระหว่างขอบเขต Shape และ Appearance เมื่อเรนเดอร์ภาพย่อคืออะไร?**

`Shape` ใช้เรขาคณิตของรูปร่าง; `Appearance` พิจารณา [เอฟเฟกต์ภาพ](/slides/th/java/shape-effect/) (เงา, ส่องแสง, ฯลฯ) ด้วย

**จะเกิดอะไรขึ้นหากรูปร่างถูกทำเครื่องหมายว่าเป็น hidden? จะยังคงเรนเดอร์เป็นภาพย่อหรือไม่?**

รูปร่างที่ซ่อนอยู่ยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธง hidden มีผลต่อการแสดงผลสไลด์โชว์เท่านั้น แต่ไม่ป้องกันการสร้างภาพของรูปร่าง

**รองรับรูปแบบกลุ่ม, แผนภูมิ, SmartArt และวัตถุซับซ้อนอื่น ๆ หรือไม่?**

ใช่ วัตถุใด ๆ ที่แสดงเป็น [Shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/) (รวมถึง [GroupShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/), และ [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/smartart/)) สามารถบันทึกเป็นภาพย่อหรือเป็น SVG ได้

**ฟอนต์ที่ติดตั้งในระบบส่งผลต่อคุณภาพของภาพย่อสำหรับรูปร่างข้อความหรือไม่?**

ใช่ คุณควร [จัดหาแบบอักษรที่จำเป็น](/slides/th/java/custom-font/) (หรือ [กำหนดการทดแทนแบบอักษร](/slides/th/java/font-substitution/)) เพื่อหลีกเลี่ยงการเปลี่ยนฟอนต์โดยไม่ต้องการและการจัดข้อความซ้ำ