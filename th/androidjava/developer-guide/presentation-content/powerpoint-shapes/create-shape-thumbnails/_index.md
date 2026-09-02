---
title: สร้างภาพขนาดย่อของรูปร่างการนำเสนอบน Android
linktitle: ภาพขนาดย่อของรูปร่าง
type: docs
weight: 70
url: /th/androidjava/create-shape-thumbnails/
keywords:
- ภาพขนาดย่อของรูปร่าง
- รูปภาพของรูปร่าง
- การแสดงผลรูปร่าง
- การเรนเดอร์รูปร่าง
- ขอบเขตภาพจริง
- ขอบเขตของรูปร่าง
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างภาพขนาดย่อของรูปร่างคุณภาพสูงจากสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java – สร้างและส่งออกภาพขนาดย่อของงานนำเสนอได้อย่างง่ายดาย."
---
## **บทนำ**

Aspose.Slides for Android via Java สามารถใช้สร้างไฟล์งานนำเสนอซึ่งแต่ละหน้าตรงกับสไลด์ได้ ไฟล์สไลด์สามารถดูได้โดยเปิดไฟล์งานนำเสนอด้วย Microsoft PowerPoint อย่างไรก็ตาม นักพัฒนาบางครั้งอาจต้องดูรูปภาพของรูปร่างแยกต่างหากในโปรแกรมดูรูปภาพ ในกรณีเช่นนี้ Aspose.Slides for Android via Java ช่วยให้พวกเขาสร้างภาพขนาดย่อของรูปร่างในสไลด์ได้

ในหัวข้อนี้ เราจะอธิบายวิธีการสร้างภาพขนาดย่อของสไลด์ในสถานการณ์ต่างๆ:

- การสร้างภาพขนาดย่อของรูปร่างภายในสไลด์
- การสร้างภาพขนาดย่อของรูปร่างสไลด์ด้วยมิติที่ผู้ใช้กำหนด
- การสร้างภาพขนาดย่อของรูปร่างภายในขอบเขตของการปรากฏของรูปร่าง

## **สร้างภาพขนาดย่อของรูปร่างจากสไลด์**
เพื่อสร้างภาพขนาดย่อของรูปร่างจากสไลด์ใด ๆ ด้วย Aspose.Slides for Android via Java ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation).
2. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน.
3. รับภาพขนาดย่อของรูปร่างโดยใช้ [Get the shape thumbnail image](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#getImage--) ของสไลด์ที่อ้างอิงด้วยสเกลเริ่มต้น.
4. บันทึกภาพขนาดย่อลงในรูปแบบภาพที่คุณต้องการ.

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // สร้างภาพขนาดเต็มสเกล
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

## **สร้างภาพขนาดย่อด้วยสเกลที่กำหนดเอง**
เพื่อสร้างภาพขนาดย่อของรูปร่างสไลด์ด้วย Aspose.Slides for Android via Java ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation).
2. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน.
3. รับภาพขนาดย่อของรูปร่างโดยใช้ [Get the shape thumbnail image](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) ของสไลด์ที่อ้างอิงด้วยมิติตามที่ผู้ใช้กำหนด.
4. บันทึกภาพขนาดย่อลงในรูปแบบภาพที่คุณต้องการ.

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // สร้างภาพขนาดเต็มสเกล
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

## **สร้างภาพขนาดย่อของรูปร่างตามขอบเขตการปรากฏ**
วิธีการสร้างภาพขนาดย่อของรูปร่างนี้ช่วยให้นักพัฒนาสามารถสร้างภาพขนาดย่อภายในขอบเขตการปรากฏของรูปร่างได้ โดยพิจารณาผลกระทบทั้งหมดของรูปร่าง ภาพขนาดย่อของรูปร่างที่สร้างขึ้นจะถูกจำกัดโดยขอบเขตของสไลด์ เพื่อสร้างภาพขนาดย่อของรูปร่างสไลด์ในขอบเขตของการปรากฏให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation).
2. รับอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรือดัชนีของมัน.
3. รับภาพขนาดย่อของสไลด์ที่อ้างอิงโดยใช้ขอบเขตของรูปร่างเป็นการปรากฏ.
4. บันทึกภาพขนาดย่อลงในรูปแบบภาพที่คุณต้องการ.

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์งานนำเสนอ
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // สร้างภาพขนาดเต็มสเกล
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

## **รับขอบเขตภาพจริงของรูปร่าง**
คุณสมบัติกรอบของ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) — วิธี `getX()`, `getY()`, `getWidth()`, และ `getHeight()` — ระบุสี่เหลี่ยมที่เก็บไว้ในโมเดลการนำเสนอ เนื้อหาจริงที่แสดงอาจขยายออกนอกกรอบนั้นหรือครอบคลุมสี่เหลี่ยมที่เรียงตามแกนต่างกัน การหมุน, เส้นขอบ, ปลายลูกศร, การจัดวางข้อความและการล้น, รูปเรขาคณิต SmartArt ที่สร้างขึ้น, และเอฟเฟ็กต์การเรนเดอร์อื่น ๆ สามารถเปลี่ยนพื้นที่ที่ครอบคลุมได้

ใช้ [Shape.getVisualBounds](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getVisualBounds--) เพื่อคำนวณพื้นที่ที่ครอบคลุมโดยไม่ต้องสร้างภาพ วิธีนี้คืนค่าเป็น [RectF](https://developer.android.com/reference/android/graphics/RectF) ในพิกัดของสไลด์ สี่เหลี่ยมที่คืนค่าจะไม่ถูกคลิปให้เข้ากับสไลด์ ดังนั้นพิกัดของมันอาจเป็นค่าติดลบเมื่อเนื้อหาขยายออกนอกจุดกำเนิดของสไลด์

[Shape.getVisualBounds](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getVisualBounds--) ยังไม่ได้ถูกประกาศในอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) ดังนั้น ให้เก็บรูปร่างที่ได้รับจากคอลเลคชันรูปร่างของสไลด์เป็นค่าอินเทอร์เฟซและทำการคาสต์เมื่อเรียกใช้เมธอดเท่านั้น

ตัวอย่างต่อไปนี้จะรับและเปรียบเทียบกรอบและขอบเขตภาพจริง:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

คุณสามารถใช้ [RectF](https://developer.android.com/reference/android/graphics/RectF) เดียวกันเพื่อจัดตำแหน่งรูปร่างที่อยู่ใกล้เคียงให้สอดคล้องกับขอบซ้าย, ขวา, ด้านบน หรือด้านล่าง; สำรองพื้นที่เพียงพอในเลย์เอาต์ที่สร้าง; หรือตรวจจับเนื้อหานอกเขตที่อนุญาต ขอบเขตภาพจริงมีประโยชน์เป็นพิเศษสำหรับ SmartArt, กล่องข้อความ, ลูกศร, รูปภาพ, รูปร่างที่หมุน, และกลุ่มรูปร่าง ที่กรอบที่เก็บอาจไม่แสดงผลเต็มที่ของการเรนเดอร์

ใช้ [Shape.getVisualBounds](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getVisualBounds--) เมื่อคุณต้องการพิกัดสำหรับการจัดเลย์เอาต์หรือการตรวจสอบและไม่ต้องการบิตแมป ใช้ [IShape.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getImage--) เมื่อคุณต้องการเรนเดอร์รูปร่าง ด้วย [ShapeThumbnailBounds](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds.Shape` กำหนดขนาดภาพจากขอบเขตของรูปร่างรวมถึงการตั้งค่าเส้นขอบ ในขณะที่ `ShapeThumbnailBounds.Appearance` กำหนดขนาดจากการปรากฏของรูปร่างและจำกัดผลลัพธ์ให้อยู่ในขอบเขตของสไลด์ ตรงกันข้าม [Shape.getVisualBounds](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getVisualBounds--) จะคืนค่าเพียงสี่เหลี่ยมที่คำนวณได้และไม่คลิปให้เข้ากับสไลด์

## **คำถามที่พบบ่อย**

**รูปแบบภาพใดบ้างที่สามารถใช้เมื่อบันทึกภาพขนาดย่อของรูปร่าง?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imageformat/), และอื่น ๆ รูปร่างยังสามารถ [ส่งออกเป็นเวกเตอร์ SVG](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) โดยบันทึกเนื้อหารูปร่างเป็น SVG

**ความแตกต่างระหว่างขอบเขต Shape และ Appearance คืออะไรเมื่อเรนเดอร์ภาพขนาดย่อ?**  
`Shape` ใช้เรขาคณิตของรูปร่าง; `Appearance` พิจารณา [เอฟเฟ็กต์ภาพ](/slides/th/androidjava/shape-effect/) (เงา, แสงเรืองแสง ฯลฯ) เข้าไปด้วย

**จะเกิดอะไรขึ้นหากรูปร่างถูกทำเครื่องหมายว่าเป็นซ่อน? จะยังคงเรนเดอร์เป็นภาพขนาดย่อหรือไม่?**  
รูปร่างที่ซ่อนอยู่ยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธงซ่อนจะส่งผลต่อการแสดงสไลด์โชว์แต่จะไม่ขัดขางการสร้างภาพของรูปร่าง

**รูปแบบกลุ่ม, แผนภูมิ, SmartArt, และวัตถุซับซ้อนอื่น ๆ รองรับหรือไม่?**  
ใช่ วัตถุใด ๆ ที่แสดงเป็น [Shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/) (รวมถึง [GroupShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chart/), และ [SmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/smartart/)) สามารถบันทึกเป็นภาพขนาดย่อหรือเป็น SVG ได้

**ฟอนต์ที่ติดตั้งในระบบส่งผลต่อคุณภาพของภาพขนาดย่อของรูปร่างข้อความหรือไม่?**  
ใช่ คุณควร [จัดเตรียมฟอนต์ที่จำเป็น](/slides/th/androidjava/custom-font/) (หรือ [กำหนดการทดแทนฟอนต์](/slides/th/androidjava/font-substitution/)) เพื่อหลีกเลี่ยงการ fallback ที่ไม่ต้องการและการจัดเรียงข้อความใหม่