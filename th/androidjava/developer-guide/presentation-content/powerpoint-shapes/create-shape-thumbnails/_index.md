---
title: สร้างภาพย่อของรูปร่างการนำเสนอบน Android
linktitle: ภาพย่อของรูปร่าง
type: docs
weight: 70
url: /th/androidjava/create-shape-thumbnails/
keywords:
- ภาพย่อของรูปร่าง
- ภาพของรูปร่าง
- เรนเดอร์รูปร่าง
- การเรนเดอร์รูปร่าง
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างภาพย่อของรูปร่างคุณภาพสูงจากสไลด์ PowerPoint ด้วย Aspose.Slides for Android via Java – สร้างและส่งออกรูปย่อการนำเสนอได้อย่างง่ายดาย."
---
## **คำนำ**

Aspose.Slides for Android via Java สามารถใช้เพื่อสร้างไฟล์การนำเสนอซึ่งแต่ละหน้าตรงกับสไลด์หนึ่ง สไลด์สามารถดูได้โดยการเปิดไฟล์การนำเสนอด้วย Microsoft PowerPoint อย่างไรก็ตาม นักพัฒนาบางครั้งต้องการดูภาพของรูปร่างแยกจากกันในโปรแกรมดูภาพ ในกรณีเช่นนี้ Aspose.Slides for Android via Java ช่วยให้พวกเขาสร้างภาพย่อของรูปร่างในสไลด์ได้

ในหัวข้อนี้เราจะอธิบายวิธีการสร้างภาพย่อสไลด์ในสถานการณ์ต่าง ๆ:

- สร้างภาพย่อของรูปร่างภายในสไลด์
- สร้างภาพย่อของรูปร่างในสไลด์โดยกำหนดขนาดตามผู้ใช้
- สร้างภาพย่อของรูปร่างตามขอบเขตของลักษณะที่ปรากฏของรูปร่าง

## **สร้างภาพย่อของรูปร่างจากสไลด์**
เพื่อสร้างภาพย่อของรูปร่างจากสไลด์ใด ๆ โดยใช้ Aspose.Slides for Android via Java ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation).
1. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน.
1. ดึงภาพย่อของรูปร่างจากสไลด์ที่อ้างถึงโดยใช้สเกลเริ่มต้นโดยใช้เมธอด [Get the shape thumbnail image](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#getImage--).
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ.

ตัวอย่างโค้ดนี้แสดงวิธีการสร้างภาพย่อของรูปร่างจากสไลด์:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
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

## **สร้างภาพย่อด้วยตัวคูณสเกลที่กำหนดโดยผู้ใช้**
เพื่อสร้างภาพย่อของรูปร่างจากสไลด์โดยกำหนดสเกลตามผู้ใช้ด้วย Aspose.Slides for Android via Java ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation).
1. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน.
1. ดึงภาพย่อของรูปร่างจากสไลด์ที่อ้างถึงโดยกำหนดขนาดตามผู้ใช้โดยใช้เมธอด [Get the shape thumbnail image](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#getImage-int-float-float-).
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ.

ตัวอย่างโค้ดนี้แสดงวิธีการสร้างภาพย่อของรูปร่างโดยอิงจากตัวคูณสเกลที่กำหนด:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
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

## **สร้างภาพย่อของรูปร่างตามขอบเขตของลักษณะการแสดง**
วิธีการสร้างภาพย่อของรูปร่างนี้ช่วยให้ผู้พัฒนาสามารถสร้างภาพย่อภายในขอบเขตของลักษณะที่ปรากฏของรูปร่าง โดยคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปร่าง ภาพย่อที่สร้างจะถูกจำกัดโดยขอบเขตของสไลด์ เพื่อต้องการสร้างภาพย่อของรูปร่างในสไลด์ภายในขอบเขตของลักษณะที่ปรากฏ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation).
1. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน.
1. ดึงภาพย่อของสไลด์ที่อ้างถึงโดยใช้ขอบเขตของรูปร่างเป็นลักษณะที่ปรากฏ.
1. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ.

ตัวอย่างโค้ดนี้อิงตามขั้นตอนข้างต้น:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
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

**รูปแบบภาพใดที่สามารถใช้เมื่อบันทึกภาพย่อของรูปร่าง?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imageformat/), และอื่น ๆ รูปร่างยังสามารถ[ส่งออกเป็นเวกเตอร์ SVG](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)โดยบันทึกเนื้อหาของรูปร่างเป็น SVG.

**ความแตกต่างระหว่างขอบเขต Shape กับ Appearance เมื่อเรนเดอร์ภาพย่อคืออะไร?**

`Shape` ใช้รูปทรงเรขาคณิตของรูปร่าง; `Appearance` พิจารณา[เอฟเฟกต์ภาพ](/slides/th/androidjava/shape-effect/) (เงา, แสงเรืองแสง, ฯลฯ).

**จะเกิดอะไรขึ้นถ้ารูปร่างถูกทำเครื่องหมายว่าเป็นซ่อน? มันยังจะเรนเดอร์เป็นภาพย่อหรือไม่?**

รูปร่างที่ซ่อนยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธงซ่อนมีผลต่อการแสดงสไลด์โชว์แต่ไม่ได้ป้องกันการสร้างภาพของรูปร่าง.

**รองรับการทำงานกับกลุ่มรูปร่าง, แผนภูมิ, SmartArt และอ็อบเจกต์ซับซ้อนอื่น ๆ หรือไม่?**

ใช่. อ็อบเจกต์ใด ๆ ที่แสดงเป็น[Shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/) (รวมถึง[GroupShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/), และ[SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/smartart/)) สามารถบันทึกเป็นภาพย่อหรือเป็น SVG ได้.

**ฟอนต์ที่ติดตั้งในระบบมีผลต่อคุณภาพของภาพย่อสำหรับรูปร่างข้อความหรือไม่?**

มี. คุณควร[จัดเตรียมฟอนต์ที่จำเป็น](/slides/th/androidjava/custom-font/) (หรือ[กำหนดการทดแทนฟอนต์](/slides/th/androidjava/font-substitution/)) เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรองที่ไม่ต้องการและการปรับตำแหน่งข้อความ.