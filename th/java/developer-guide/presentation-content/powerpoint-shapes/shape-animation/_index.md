---
title: ใช้แอนิเมชันรูปทรงในงานนำเสนอด้วย Java
linktitle: แอนิเมชันรูปทรง
type: docs
weight: 60
url: /th/java/shape-animation/
keywords:
- รูปทรง
- แอนิเมชัน
- เอฟเฟกต์
- รูปทรงที่แอนิเมชัน
- ข้อความที่แอนิเมชัน
- เพิ่มแอนิเมชัน
- รับแอนิเมชัน
- ดึงแอนิเมชัน
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- ดึงเอฟเฟกต์
- เสียงเอฟเฟกต์
- ใช้แอนิเมชัน
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบวิธีสร้างและปรับแต่งแอนิเมชันรูปทรงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java. ทำให้โดดเด่น!"
---
## **บทนำ**

แอนิเมชันเป็นเอฟเฟกต์ภาพที่สามารถนำไปใช้กับข้อความ, รูปภาพ, รูปร่าง, หรือ [แผนภูมิ](https://docs.aspose.com/slides/th/java/animated-charts/). พวกมันให้ชีวิตกับงานนำเสนอหรือส่วนประกอบของมัน. 

## **ทำไมต้องใช้แอนิเมชันในการนำเสนอ?**

ใช้แอนิเมชัน, คุณสามารถ 

* ควบคุมการไหลของข้อมูล
* เน้นจุดสำคัญ
* เพิ่มความสนใจหรือการมีส่วนร่วมของผู้ชม
* ทำให้เนื้อหาอ่านง่ายขึ้นหรือย่อยรวมหรือประมวลผลได้ง่ายขึ้น
* ดึงความสนใจของผู้อ่านหรือผู้ชมไปยังส่วนสำคัญในงานนำเสนอ

PowerPoint มีตัวเลือกและเครื่องมือหลายอย่างสำหรับแอนิเมชันและเอฟเฟกต์แอนิเมชันในหมวด **entrance**, **exit**, **emphasis**, และ **motion paths**. 

## **แอนิเมชันใน Aspose.Slides**

* Aspose.Slides มีคลาสและประเภทที่คุณต้องการเพื่อทำงานกับแอนิเมชันภายใต้เนมสเปซ `Aspose.Slides.Animation`,
* Aspose.Slides มีเอฟเฟกต์แอนิเมชันกว่า **150** รายการภายใต้ enumeration [EffectType](https://reference.aspose.com/slides/th/java/com.aspose.slides/effecttype). เอฟเฟกต์เหล่านี้เป็นเอฟเฟกต์เดียวกัน (หรือเทียบเท่า) ที่ใช้ใน PowerPoint.

## **ใช้แอนิเมชันกับ TextBox**

Aspose.Slides for Java อนุญาตให้คุณใช้แอนิเมชันกับข้อความในรูปร่าง. 

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape). 
4. เพิ่มข้อความไปยัง [IAutoShape.TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. รับลำดับหลักของเอฟเฟกต์.
6. เพิ่มเอฟเฟกต์แอนิเมชันให้กับ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape). 
7. ตั้งค่าคุณสมบัติ `TextAnimation.BuildType` ให้เป็นค่าจาก enumeration `BuildType`.
8. เขียนงานนำเสนอลงดิสก์เป็นไฟล์ PPTX.

โค้ด Java นี้แสดงวิธีใช้เอฟเฟกต์ `Fade` กับ AutoShape และตั้งค่าแอนิเมชันข้อความเป็นค่า *By 1st Level Paragraphs*:

```java
// สร้างอินสแทนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ใหม่พร้อมข้อความ
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // ดึงลำดับหลักของสไลด์.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // เพิ่มเอฟเฟกต์แอนิเมชัน Fade ให้กับรูปร่าง
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // แอนิเมชันข้อความของรูปร่างตามย่อหน้าอันดับแรก
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

นอกจากการใช้แอนิเมชันกับข้อความแล้ว คุณยังสามารถใช้แอนิเมชันกับ [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph) เพียงหนึ่งรายการได้ ดูที่ [**Animated Text**](/slides/th/java/animated-text/).

{{% /alert %}} 

## **ใช้แอนิเมชันกับ PictureFrame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนี.
3. เพิ่มหรือรับ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe) บนสไลด์. 
4. รับลำดับหลักของเอฟเฟกต์.
5. เพิ่มเอฟเฟกต์แอนิเมชันให้กับ [PictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/pictureframe).
6. เขียนงานนำเสนอลงดิสก์เป็นไฟล์ PPTX.

โค้ด Java นี้แสดงวิธีใช้เอฟเฟกต์ `Fly` กับ picture frame:

```java
// สร้างอินสแทนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
Presentation pres = new Presentation();
try {
    // โหลดรูปภาพที่จะเพิ่มในคอลเลกชันภาพของงานนำเสนอ
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // เพิ่ม picture frame ไปยังสไลด์
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // ดึงลำดับหลักของสไลด์.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // เพิ่มเอฟเฟกต์แอนิเมชัน Fly จากด้านซ้ายให้กับ picture frame
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **ใช้แอนิเมชันกับ Shape**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนี.
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape). 
4. เพิ่ม `Bevel` [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape) (เมื่ออ็อบเจกต์นี้ถูกคลิก แอนิเมชันจะเล่น)
5. สร้างลำดับของเอฟเฟกต์บนรูปร่าง bevel
6. สร้าง `UserPath` แบบกำหนดเอง
7. เพิ่มคำสั่งสำหรับการเคลื่อนที่ไปยัง `UserPath`
8. เขียนงานนำเสนอลงดิสก์เป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีใช้เอฟเฟกต์ `PathFootball` (path football) กับรูปร่าง:

```java
// สร้างอินสแทนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // สร้างเอฟเฟกต์ PathFootball ให้กับรูปร่างที่มีอยู่ตั้งแต่ต้น.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // เพิ่มเอฟเฟกต์แอนิเมชัน PathFootball
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // สร้างบางอย่างที่คล้ายกับ "ปุ่ม".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // สร้างลำดับของเอฟเฟกต์สำหรับปุ่มนี้.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // สร้างเส้นทางผู้ใช้แบบกำหนดเอง. วัตถุของเราจะเคลื่อนที่เฉพาะหลังจากปุ่มถูกคลิก.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // เพิ่มคำสั่งการเคลื่อนที่เนื่องจากเส้นทางที่สร้างยังว่าง.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **รับเอฟเฟกต์แอนิเมชันที่ใช้กับ Shape**

ตัวอย่างต่อไปนี้แสดงวิธีใช้เมธอด `getEffectsByShape` จากอินเทอร์เฟซ [ISequence](https://reference.aspose.com/slides/th/java/com.aspose.slides/isequence/) เพื่อรับเอฟเฟกต์แอนิเมชันทั้งหมดที่ใช้กับรูปร่าง

**ตัวอย่างที่ 1: รับเอฟเฟกต์แอนิเมชันที่ใช้กับ Shape บนสไลด์ปกติ**

ก่อนหน้านี้ คุณได้เรียนรู้วิธีเพิ่มเอฟเฟกต์แอนิเมชันให้กับรูปร่างในงานนำเสนอ PowerPoint ตัวอย่างโค้ดต่อไปนี้แสดงวิธีดึงเอฟเฟกต์ที่ใช้กับรูปร่างแรกบนสไลด์ปกติแรกในงานนำเสนอ `AnimExample_out.pptx`.

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // ดึงลำดับแอนิเมชันหลักของสไลด์.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // ดึงรูปร่างแรกบนสไลด์แรก.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // ดึงเอฟเฟกต์แอนิเมชันที่ใช้กับรูปร่าง.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**ตัวอย่างที่ 2: รับเอฟเฟกต์แอนิเมชันทั้งหมดรวมถึงที่สืบทอดจาก placeholder**

หากรูปร่างบนสไลด์ปกติมี placeholder ที่อยู่บนสไลด์ layout และ/หรือ master และมีการเพิ่มเอฟเฟกต์แอนิเมชันให้กับ placeholder เหล่านี้ แล้วเอฟเฟกต์ทั้งหมดของรูปร่างจะถูกเล่นระหว่างการแสดงสไลด์ รวมถึงที่สืบทอดจาก placeholder ด้วย

สมมติว่าเรา มีไฟล์งานนำเสนอ PowerPoint `sample.pptx` ที่มีสไลด์หนึ่งสไลด์ที่มีเพียง shape footer ที่มีข้อความ “Made with Aspose.Slides” และได้กำหนดเอฟเฟกต์ **Random Bars** ให้กับ shape นั้น

![เอฟเฟกต์แอนิเมชันของ Shape บนสไลด์](slide-shape-animation.png)

และสมมติว่าเอฟเฟกต์ **Split** ถูกกำหนดให้กับ placeholder footer บนสไลด์ **layout**

![เอฟเฟกต์แอนิเมชันของ Shape บน Layout](layout-shape-animation.png)

และสุดท้ายเอฟเฟกต์ **Fly In** ถูกกำหนดให้กับ placeholder footer บนสไลด์ **master**

![เอฟเฟกต์แอนิเมชันของ Shape บน Master](master-shape-animation.png)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้เมธอด `getBasePlaceholder` จากอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) เพื่อเข้าถึง placeholder ของ shape และรับเอฟเฟกต์แอนิเมชันที่ใช้กับ shape footer รวมถึงที่สืบทอดจาก placeholder ที่อยู่บนสไลด์ layout และ master

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **เปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์แอนิเมชัน**

Aspose.Slides for Java อนุญาตให้คุณเปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์แอนิเมชัน.

นี่คือแถบ Animation Timing ใน Microsoft PowerPoint:

![หน้าต่าง Animation Timing](shape-animation.png)

นี่คือการจับคู่ระหว่าง PowerPoint Timing และคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/java/com.aspose.slides/IEffect#getTiming--) :

- รายการดรอปดาวน์ **Start** ของ PowerPoint Timing ตรงกับคุณสมบัติ [Effect.Timing.TriggerType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITiming#getTriggerType--). 
- **Duration** ของ PowerPoint Timing ตรงกับคุณสมบัติ [Effect.Timing.Duration](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITiming#getDuration--). ระยะเวลาของแอนิเมชัน (วินาที) คือเวลารวมที่แอนิเมชันใช้ทำหนึ่งรอบ. 
- **Delay** ของ PowerPoint Timing ตรงกับคุณสมบัติ [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITiming#getTriggerDelayTime--). 

นี่คือวิธีเปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์:

1. [ใช้](#apply-animation-to-shape) หรือรับเอฟเฟกต์แอนิเมชัน.
2. ตั้งค่าค่าใหม่สำหรับคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/java/com.aspose.slides/IEffect#getTiming--) ที่คุณต้องการ. 
3. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว.

```java
// สร้างอินสแทนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // ดึงลำดับหลักของสไลด์.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // ดึงเอฟเฟกต์แรกของลำดับหลัก.
    IEffect effect = sequence.get_Item(0);

    // เปลี่ยน TriggerType ของเอฟเฟกต์ให้เริ่มเมื่อคลิก
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // เปลี่ยนระยะเวลาของเอฟเฟกต์
    effect.getTiming().setDuration(3f);

    // เปลี่ยน TriggerDelayTime ของเอฟเฟกต์
    effect.getTiming().setTriggerDelayTime(0.5f);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เสียงของเอฟเฟกต์แอนิเมชัน**

Aspose.Slides มีคุณสมบัติเหล่านี้เพื่อให้คุณทำงานกับเสียงในเอฟเฟกต์แอนิเมชัน: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **เพิ่มเสียงให้เอฟเฟกต์แอนิเมชัน**

โค้ด Java นี้แสดงวิธีเพิ่มเสียงให้เอฟเฟกต์แอนิเมชันและหยุดเมื่อเอฟเฟกต์ถัดไปเริ่ม:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // เพิ่มไฟล์เสียงลงในคอลเลกชันเสียงของงานนำเสนอ
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // ดึงลำดับหลักของสไลด์.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // ดึงเอฟเฟกต์แรกของลำดับหลัก
    IEffect firstEffect = sequence.get_Item(0);

    // ตรวจสอบว่าเอฟเฟ็กต์ไม่มีเสียง
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // เพิ่มเสียงให้กับเอฟเฟกต์แรก
        firstEffect.setSound(effectSound);
    }

    // ดึงลำดับเชิงโต้ตอบแรกของสไลด์.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // ตั้งค่าสถานะ "หยุดเสียงก่อนหน้า" ของเอฟเฟกต์
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ดึงเสียงจากเอฟเฟกต์แอนิเมชัน**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/).
2. รับอ้างอิงสไลด์ผ่านดัชนี. 
3. รับลำดับหลักของเอฟเฟกต์. 
4. ดึง [setSound(IAudio value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) ที่ฝังอยู่ในแต่ละเอฟเฟกต์แอนิเมชัน. 

โค้ด Java นี้แสดงวิธีดึงเสียงที่ฝังอยู่ในเอฟเฟกต์แอนิเมชัน:

```java
// สร้างอินสแทนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ดึงลำดับหลักของสไลด์.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // ดึงเสียงของเอฟเฟกต์เป็นอาเรย์ไบต์
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **หลังแอนิเมชัน**

Aspose.Slides for Java อนุญาตให้คุณเปลี่ยนคุณสมบัติ After animation ของเอฟเฟกต์แอนิเมชัน.

![หน้าต่าง After Animation](shape-after-animation.png)

รายการดรอปดาวน์ **After animation** ของ PowerPoint Effect ตรงกับคุณสมบัติเหล่านี้: 

- คุณสมบัติ [setAfterAnimationType(int value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) ที่บรรยายประเภท After animation :
  * **More Colors** ของ PowerPoint ตรงกับประเภท [AfterAnimationType.Color](https://reference.aspose.com/slides/th/java/com.aspose.slides/afteranimationtype/#Color);
  * **Don't Dim** ของ PowerPoint ตรงกับประเภท [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/th/java/com.aspose.slides/afteranimationtype/#DoNotDim) (ค่าเริ่มต้น);
  * **Hide After Animation** ของ PowerPoint ตรงกับประเภท [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/th/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * **Hide on Next Mouse Click** ของ PowerPoint ตรงกับประเภท [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/th/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- คุณสมบัติ [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) ที่กำหนดรูปแบบสีของ After animation. คุณสมบัตินี้ทำงานร่วมกับประเภท [AfterAnimationType.Color](https://reference.aspose.com/slides/th/java/com.aspose.slides/afteranimationtype/#Color). หากเปลี่ยนประเภทเป็นค่าอื่น สี After animation จะถูกลบ.

```java
// สร้างอินสแทนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // ดึงเอฟเฟกต์แรกของลำดับหลัก
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // เปลี่ยนประเภท After animation เป็น Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // ตั้งค่าสีของ After animation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **แอนิเมตข้อความ**

Aspose.Slides มีคุณสมบัติเหล่านี้เพื่อให้คุณทำงานกับบล็อก *Animate text* ของเอฟเฟกต์แอนิเมชัน:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) ที่บรรยายประเภทการแอนิเมตข้อความของเอฟเฟกต์. ข้อความของ shape สามารถแอนิเมตได้:
  - ทั้งหมดพร้อมกัน ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/th/java/com.aspose.slides/animatetexttype/#AllAtOnce) type)
  - ตามคำ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/th/java/com.aspose.slides/animatetexttype/#ByWord) type)
  - ตามตัวอักษร ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/th/java/com.aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) ตั้งค่าเวลาหน่วงระหว่างส่วนของข้อความที่แอนิเมต (คำหรืออักษร) ค่าเป็นบวกระบุเป็นเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์ ค่าเป็นลบระบุเป็นวินาที.

นี่คือขั้นตอน:

1. [ใช้](#apply-animation-to-shape) หรือรับเอฟเฟกต์แอนิเมชัน.
2. ตั้งคุณสมบัติ [setBuildType(int value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextanimation/#setBuildType-int-) ให้เป็นค่า [BuildType.AsOneObject](https://reference.aspose.com/slides/th/java/com.aspose.slides/buildtype/#AsOneObject) เพื่อปิดโหมดแอนิเมชัน *By Paragraphs*.
3. ตั้งค่าตัวใหม่ให้คุณสมบัติ [setAnimateTextType(int value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) และ [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/th/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว.

```java
// สร้างอินสแทนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // ดึงเอฟเฟกต์แรกของลำดับหลัก
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // เปลี่ยนประเภทการแอนิเมตข้อความของเอฟเฟกต์เป็น "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // เปลี่ยนประเภทการแอนิเมตข้อความของเอฟเฟกต์เป็น "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // ตั้งค่าการหน่วงเวลาระหว่างคำเป็น 20% ของระยะเวลาเอฟเฟกต์
    firstEffect.setDelayBetweenTextParts(20f);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะทำอย่างไรให้แอนิเมชันคงอยู่เมื่อนำงานนำเสนอไปเผยแพร่บนเว็บ?**

[Export to HTML5](/slides/th/java/export-to-html5/) และเปิดใช้งาน [options](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/) ที่รับผิดชอบการแอนิเมชันของ [shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และ [transition](https://reference.aspose.com/slides/th/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). HTML ธรรมดาไม่เล่นแอนิเมชันสไลด์ แต่ HTML5 ทำได้.

**การเปลี่ยนลำดับ z-order (ลำดับชั้น) ของรูปร่างส่งผลต่อแอนิเมชันอย่างไร?**

แอนิเมชันและลำดับการวาดเป็นอิสระกัน: เอฟเฟกต์ควบคุมเวลาและประเภทของการปรากฏ/หายไป ในขณะที่ [z-order](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getZOrderPosition--) กำหนดว่าอะไรอยู่เหนืออะไร ผลลัพธ์ที่มองเห็นได้ถูกกำหนดโดยการผสมผสานของทั้งสอง (นี่เป็นพฤติกรรมทั่วไปของ PowerPoint; โมเดลเอฟเฟกต์และรูปร่างของ Aspose.Slides ทำตามตรรกะเดียวกัน.)

**มีข้อจำกัดใดเมื่อแปลงแอนิเมชันเป็นวิดีโอสำหรับเอฟเฟกต์บางอย่างหรือไม่?**

โดยทั่วไป [แอนิเมชันได้รับการสนับสนุน](/slides/th/java/convert-powerpoint-to-video/), แต่ในกรณีที่หายากหรือเอฟเฟกต์เฉพาะบางอย่างอาจแสดงผลแตกต่างกัน คำแนะนำคือให้ทดสอบกับเอฟเฟกต์ที่คุณใช้และกับเวอร์ชันของไลบรารี.