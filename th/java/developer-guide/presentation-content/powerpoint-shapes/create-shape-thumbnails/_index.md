---
title: "สร้างภาพขนาดย่อของรูปร่างงานนำเสนอใน Java"
linktitle: "ภาพขนาดย่อของรูปทรง"
type: docs
weight: 70
url: /th/java/create-shape-thumbnails/
keywords:
- "ภาพขนาดย่อของรูปทรง"
- "รูปภาพของรูปทรง"
- "เรนเดอร์รูปทรง"
- "การเรนเดอร์รูปทรง"
- "ขอบเขตการแสดงผล"
- "ขอบเขตรูปทรง"
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "สร้างภาพขนาดย่อของรูปทรงคุณภาพสูงจากสไลด์ PowerPoint ด้วย Aspose.Slides for Java – สร้างและส่งออกภาพขนาดย่อของงานนำเสนอได้อย่างง่ายดาย."
---
## **บทนำ**

Aspose.Slides for Java สามารถใช้สร้างไฟล์งานนำเสนอที่แต่ละหน้าตรงกับสไลด์หนึ่งสไลด์ได้ สไลด์เหล่านี้สามารถดูได้โดยเปิดไฟล์งานนำเสนอด้วย Microsoft PowerPoint อย่างไรก็ตาม นักพัฒนาบางครั้งต้องการดูภาพของรูปร่างแยกต่างหากในโปรแกรมแสดงภาพ ในกรณีเช่นนี้ Aspose.Slides for Java ช่วยให้พวกเขาสร้างภาพขนาดย่อของรูปร่างในสไลด์ได้

บทความนี้อธิบายวิธีการสร้างภาพขนาดย่อของสไลด์ในรูปแบบต่าง ๆ :

- การสร้างภาพขนาดย่อของรูปร่างภายในสไลด์
- การสร้างภาพขนาดย่อของรูปร่างสำหรับสไลด์พร้อมขนาดที่กำหนดโดยผู้ใช้
- การสร้างภาพขนาดย่อของรูปร่างภายในขอบเขตของการแสดงผลของรูปร่าง

## **สร้างภาพขนาดย่อของรูปร่างจากสไลด์**
เพื่อสร้างภาพขนาดย่อของรูปร่างจากสไลด์ใด ๆ ด้วย Aspose.Slides for Java ให้ทำตามขั้นตอนต่อไปนี้ :

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)  
1. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของสไลด์  
1. [รับภาพขนาดย่อของรูปร่าง](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getImage--) ของสไลด์ที่อ้างอิงบนสเกลเริ่มต้น  
1. บันทึกภาพขนาดย่อในรูปแบบภาพที่คุณต้องการ

โค้ดตัวอย่างต่อไปนี้แสดงวิธีการสร้างภาพขนาดย่อของรูปร่างจากสไลด์ :

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // สร้างภาพเต็มสเกล
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // บันทึกภาพไปยังดิสก์ในรูปแบบ PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **สร้างภาพขนาดย่อที่กำหนดสเกลด้วยตัวเอง**
เพื่อสร้างภาพขนาดย่อของรูปร่างจากสไลด์ด้วย Aspose.Slides for Java ให้ทำตามขั้นตอนต่อไปนี้ :

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)  
1. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของสไลด์  
1. [รับภาพขนาดย่อของรูปร่าง](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getImage-int-float-float-) ของสไลด์ที่อ้างอิงพร้อมขนาดที่กำหนดโดยผู้ใช้  
1. บันทึกภาพขนาดย่อในรูปแบบภาพที่คุณต้องการ

โค้ดตัวอย่างต่อไปนี้แสดงวิธีการสร้างภาพขนาดย่อของรูปร่างโดยอิงจากสเกลที่กำหนด :

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // สร้างภาพเต็มสเกล
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // บันทึกภาพไปยังดิสก์ในรูปแบบ PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **สร้างภาพขนาดย่อตามขอบเขตของการแสดงผลของรูปร่าง**
วิธีนี้ช่วยให้นักพัฒนาสร้างภาพขนาดย่อของรูปร่างโดยอิงจากขอบเขตการแสดงผลของรูปร่าง ซึ่งคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปร่าง ภาพขนาดย่อที่สร้างจะถูกจำกัดโดยขอบของสไลด์ เพื่อสร้างภาพขนาดย่อของรูปร่างในขอบเขตการแสดงผล ให้ทำตามขั้นตอนต่อไปนี้ :

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)  
1. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของสไลด์  
1. รับภาพขนาดย่อของสไลด์ที่อ้างอิงโดยใช้ขอบเขตของรูปร่างเป็นการแสดงผล  
1. บันทึกภาพขนาดย่อในรูปแบบภาพที่คุณต้องการ

โค้ดตัวอย่างต่อไปนี้อิงตามขั้นตอนข้างต้น :

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // สร้างภาพเต็มสเกล
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // บันทึกภาพไปยังดิสก์ในรูปแบบ PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **รับขอบเขตการแสดงผลจริงของรูปร่าง**

คุณสมบัติกรอบของ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) — วิธี `getX()`, `getY()`, `getWidth()`, และ `getHeight()` — อธิบายสี่เหลี่ยมที่จัดเก็บในโมเดลงานนำเสนอ เนื้อหาที่จริง ๆ แล้วถูกเรนเดอร์อาจขยายออกไปนอกกรอบนั้นหรืออยู่ในสี่เหลี่ยมที่จัดแนวตามแกนต่างกัน การหมุน, เส้นขอบ, ลูกศร, การจัดวางข้อความและการล้น, เรขาคณิต SmartArt ที่สร้างขึ้น, และเอฟเฟกต์การเรนเดอร์อื่น ๆ สามารถเปลี่ยนพื้นที่ที่ใช้ได้ทั้งหมด

ใช้ [Shape.getVisualBounds](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getVisualBounds--) เพื่อคำนวณพื้นที่ที่ใช้โดยไม่ต้องสร้างภาพ วิธีนี้คืนค่าเป็น [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) ในพิกัดของสไลด์ สี่เหลี่ยมที่คืนค่าไม่ได้ถูกตัดคลิปกับสไลด์ ดังนั้นพิกัดอาจเป็นค่าลบเมื่อเนื้อหาขยายออกไปนอกจุดกำเนิดของสไลด์

[Shape.getVisualBounds](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getVisualBounds--) ยังไม่ได้ถูกประกาศในอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) ดังนั้นให้เก็บรูปร่างที่ดึงมาจากคอลเลกชันของสไลด์เป็นค่าอินเทอร์เฟซและทำการแคสเมื่อเรียกใช้เมธอดเท่านั้น

ตัวอย่างต่อไปนี้แสดงการดึงและเปรียบเทียบกรอบและขอบเขตการแสดงผล :

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

[Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) เดียวกันสามารถนำไปใช้จัดตำแหน่งรูปร่างที่อยู่ใกล้เคียงให้ชิดซ้าย, ชิดขวา, ชิดบน หรือชิดล่าง; จองพื้นที่เพียงพอในเลเอาต์ที่สร้าง; หรือตรวจจับเนื้อหานอกเขตที่อนุญาตได้ ขอบเขตการแสดงผลมีประโยชน์เป็นพิเศษสำหรับ SmartArt, กล่องข้อความ, ลูกศร, รูปภาพ, รูปร่างที่หมุน, และกลุ่มรูปร่าง ซึ่งกรอบที่จัดเก็บอาจไม่แสดงผลการเรนเดอร์ที่เต็มรูป

ใช้ [Shape.getVisualBounds](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getVisualBounds--) เมื่อคุณต้องการพิกัดสำหรับการจัดเลเอาต์หรือการตรวจสอบและไม่ต้องการบิตแมพ ใช้ [IShape.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getImage--) เมื่อคุณต้องการเรนเดอร์รูปร่าง กับ [ShapeThumbnailBounds](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds.Shape` กำหนดขนาดภาพจากขอบเขตของรูปร่างรวมถึงการตั้งค่าเส้นขอบ, ในขณะที่ `ShapeThumbnailBounds.Appearance` กำหนดขนาดจากการแสดงผลของรูปร่างและจำกัดผลลัพธ์ให้อยู่ภายในขอบของสไลด์ ตรงกันข้าม, [Shape.getVisualBounds](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getVisualBounds--) คืนค่าเฉพาะสี่เหลี่ยมที่คำนวณได้และไม่ตัดคลิปกับสไลด์

## **คำถามที่พบบ่อย**

**รูปแบบภาพใดบ้างที่สามารถใช้เมื่อบันทึกภาพขนาดย่อของรูปร่าง?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/java/com.aspose.slides/imageformat/), และรูปแบบอื่น ๆ รูปร่างยังสามารถ [exported as vector SVG](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) ได้ด้วยการบันทึกเนื้อหารูปร่างเป็น SVG

**ความแตกต่างระหว่างขอบเขต Shape กับ Appearance คืออะไรเมื่อเรนเดอร์ภาพขนาดย่อ?**

`Shape` ใช้เรขาคณิตของรูปร่าง; `Appearance` นำ [visual effects](/slides/th/java/shape-effect/) (เงา, แสงสว่าง ฯลฯ) มาพิจารณา

**ถ้ารูปร่างถูกทำเครื่องหมายว่า hidden จะเกิดอะไรขึ้น? ยังสามารถเรนเดอร์เป็นภาพขนาดย่อได้หรือไม่?**

รูปร่างที่ซ่อนอยู่ยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธง hidden มีผลต่อการแสดงในโหมดสไลด์โชว์เท่านั้น ไม่ได้ป้องกันการสร้างภาพของรูปร่าง

**รูปแบบกลุ่มรูปร่าง, แผนภูมิ, SmartArt, และออบเจ็กต์ซับซ้อนอื่น ๆ รองรับหรือไม่?**

ใช่. อ็อบเจ็กต์ใดก็ได้ที่เป็นตัวแทนเป็น [Shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/) (รวมถึง [GroupShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/java/com.aspose.slides/chart/), และ [SmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides/smartart/)) สามารถบันทึกเป็นภาพขนาดย่อหรือเป็น SVG ได้

**ฟอนต์ที่ติดตั้งในระบบมีผลต่อคุณภาพของภาพขนาดย่อสำหรับรูปร่างข้อความหรือไม่?**

ใช่. คุณควร [provide the required fonts](/slides/th/java/custom-font/) (หรือ [configure font substitutions](/slides/th/java/font-substitution/)) เพื่อหลีกเลี่ยงการ fallback ที่ไม่ต้องการและการจัดวางข้อความที่ผิดพลาด