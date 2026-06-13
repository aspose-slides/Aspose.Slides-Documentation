---
title: ใช้การเคลื่อนไหวรูปร่างในงานนำเสนอบน Android
linktitle: การเคลื่อนไหวรูปร่าง
type: docs
weight: 60
url: /th/androidjava/shape-animation/
keywords:
- รูปร่าง
- การเคลื่อนไหว
- เอฟเฟ็กต์
- รูปร่างเคลื่อนไหว
- ข้อความเคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- รับการเคลื่อนไหว
- สกัดการเคลื่อนไหว
- เพิ่มเอฟเฟ็กต์
- รับเอฟเฟ็กต์
- สกัดเอฟเฟ็กต์
- เสียงเอฟเฟ็กต์
- ใช้การเคลื่อนไหว
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีการสร้างและปรับแต่งการเคลื่อนไหวรูปร่างในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. ทำให้โดดเด่น!"
---
## **คำนำ**

การเคลื่อนไหวเป็นเอฟเฟกต์ภาพที่สามารถนำไปใช้กับข้อความ, รูปภาพ, รูปทรง, หรือ [แผนภูมิ](https://docs.aspose.com/slides/th/androidjava/animated-charts/). พวกมันทำให้การนำเสนอหรือส่วนประกอบของมันมีชีวิตชีวา.

## **ทำไมต้องใช้การเคลื่อนไหวในการนำเสนอ?**

* ควบคุมการไหลของข้อมูล
* เน้นจุดสำคัญ
* เพิ่มความสนใจหรือการมีส่วนร่วมของผู้ชม
* ทำให้เนื้อหาอ่านง่ายหรือเข้าใจหรือประมวลผลได้ง่ายขึ้น
* ดึงดูดความสนใจของผู้อ่านหรือผู้ชมไปยังส่วนสำคัญในงานนำเสนอ

PowerPoint มีตัวเลือกและเครื่องมือมากมายสำหรับการเคลื่อนไหวและเอฟเฟกต์การเคลื่อนไหวในประเภท **entrance**, **exit**, **emphasis**, และ **motion paths**.

## **การเคลื่อนไหวใน Aspose.Slides**

* Aspose.Slides มีคลาสและประเภทที่คุณต้องการเพื่อทำงานกับการเคลื่อนไหวภายใต้เนมสเปซ `Aspose.Slides.Animation`,
* Aspose.Slides มีเอฟเฟกต์การเคลื่อนไหวกว่า **150** รายการใน enumeration [EffectType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effecttype). เอฟเฟกต์เหล่านี้โดยพื้นฐานแล้วคือน้ำเดียวกัน (หรือเทียบเท่า) กับที่ใช้ใน PowerPoint.

## **ใช้การเคลื่อนไหวกับ TextBox**

Aspose.Slides for Android ผ่าน Java ช่วยให้คุณสามารถใช้การเคลื่อนไหวกับข้อความในรูปร่างได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape).
4. เพิ่มข้อความไปยัง [IAutoShape.TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. รับลำดับหลักของเอฟเฟกต์.
6. เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape).
7. ตั้งค่า property `TextAnimation.BuildType` เป็นค่าจาก enumeration `BuildType`.
8. เขียนการนำเสนอไปยังดิสก์เป็นไฟล์ PPTX.

โค้ด Java นี้แสดงวิธีการใช้เอฟเฟกต์ `Fade` กับ AutoShape และตั้งค่า animation ของข้อความเป็นค่า *By 1st Level Paragraphs* :

```java
// สร้างอินสแตนซ์ของคลาสการนำเสนอที่แทนไฟล์การนำเสนอ.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ใหม่พร้อมข้อความ
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // ดึงลำดับหลักของสไลด์.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว Fade ให้กับรูปร่าง
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // ทำให้ข้อความของรูปร่างเคลื่อนไหวตามย่อหน้าระดับที่ 1
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 
นอกจากการใช้การเคลื่อนไหวกับข้อความแล้ว คุณยังสามารถใช้การเคลื่อนไหวกับ [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph) เดียวได้ ดู [**Animated Text**](/slides/th/androidjava/animated-text/). 
{{% /alert %}} 

## **ใช้การเคลื่อนไหวกับ PictureFrame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. เพิ่มหรือรับ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe) บนสไลด์.
4. รับลำดับหลักของเอฟเฟกต์.
5. เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe).
6. เขียนการนำเสนอไปยังดิสก์เป็นไฟล์ PPTX.

โค้ด Java นี้แสดงวิธีการใช้เอฟเฟกต์ `Fly` กับ picture frame:

```java
// สร้างอินสแตนซ์ของคลาสการนำเสนอที่แทนไฟล์การนำเสนอ.
Presentation pres = new Presentation();
try {
    // โหลดรูปภาพที่จะเพิ่มในคอลเลกชันรูปภาพของการนำเสนอ
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // เพิ่มกรอบรูปไปยังสไลด์
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // ดึงลำดับหลักของสไลด์.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว Fly จากซ้ายให้กับกรอบรูป
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **ใช้การเคลื่อนไหวกับ Shape**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape).
4. เพิ่ม `Bevel` [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape) (เมื่อคลิกวัตถุนี้ การเคลื่อนไหวจะเริ่มทำงาน).
5. สร้างลำดับของเอฟเฟกต์บนรูปแบบ bevel.
6. สร้าง `UserPath` แบบกำหนดเอง.
7. เพิ่มคำสั่งเพื่อย้ายไปยัง `UserPath`.
8. เขียนการนำเสนอไปยังดิสก์เป็นไฟล์ PPTX.

โค้ด Java นี้แสดงวิธีการใช้เอฟเฟกต์ `PathFootball` (path football) กับรูปทรง:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // สร้างเอฟเฟกต์ PathFootball ให้กับรูปทรงที่มีอยู่ตั้งแต่ต้น.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // สร้างบางอย่างเช่น "ปุ่ม".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // สร้างลำดับของเอฟเฟกต์สำหรับปุ่มนี้.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // สร้างเส้นทางผู้ใช้แบบกำหนดเอง. วัตถุของเราจะเคลื่อนไหวหลังจากคลิกปุ่มเท่านั้น.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // เพิ่มคำสั่งการเคลื่อนที่ เนื่องจากเส้นทางที่สร้างยังว่างเปล่า.
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับ Shape**

ตัวอย่างต่อไปนี้แสดงวิธีใช้เมธอด `getEffectsByShape` จากอินเทอร์เฟซ [ISequence](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/) เพื่อรับเอฟเฟกต์การเคลื่อนไหวทั้งหมดที่ใช้กับรูปทรง.

**ตัวอย่าง 1: รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับ Shape บนสไลด์ปกติ**

ก่อนหน้านี้ คุณได้เรียนรู้วิธีเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับรูปทรงในงานนำเสนอ PowerPoint ตัวอย่างโค้ดต่อไปนี้แสดงวิธีรับเอฟเฟกต์ที่ใช้กับรูปทรงแรกบนสไลด์ปกติแรกในงานนำเสนอ `AnimExample_out.pptx`.

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // ดึงลำดับการเคลื่อนไหวหลักของสไลด์.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // ดึงรูปทรงแรกบนสไลด์แรก.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // ดึงเอฟเฟกต์การเคลื่อนไหวที่ใช้กับรูปทรง.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**ตัวอย่าง 2: รับเอฟเฟกต์การเคลื่อนไหวทั้งหมด รวมถึงที่สืบทอดจาก placeholder**

หากรูปทรงบนสไลด์ปกติมี placeholder ที่อยู่บนสไลด์เลย์เอาต์และ/หรือสไลด์มาสเตอร์ และมีการเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ placeholder เหล่านี้ แล้วเอฟเฟกต์ทั้งหมดของรูปทรงจะถูกเล่นในระหว่างการแสดงสไลด์ รวมถึงที่สืบทอดจาก placeholder ด้วย

สมมติว่าเรามีไฟล์งานนำเสนอ PowerPoint `sample.pptx` ที่มีสไลด์หนึ่งที่มีเพียงรูปทรงส่วนท้าย (footer) ที่มีข้อความ "Made with Aspose.Slides" และมีการใช้เอฟเฟกต์ **Random Bars** กับรูปทรงนั้น

![Slide shape animation effect](slide-shape-animation.png)

เรายังสมมติว่าเอฟเฟกต์ **Split** ถูกใช้กับ footer placeholder บนสไลด์ **layout**.

![Layout shape animation effect](layout-shape-animation.png)

สุดท้าย เอฟเฟกต์ **Fly In** ถูกใช้กับ footer placeholder บนสไลด์ **master**.

![Master shape animation effect](master-shape-animation.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีใช้เมธอด `getBasePlaceholder` จากอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) เพื่อเข้าถึง placeholder ของรูปทรงและรับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับรูปทรงส่วนท้าย รวมถึงที่สืบทอดจาก placeholder ที่อยู่บนเลย์เอาต์และมาสเตอร์สไลด์.

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

## **เปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์การเคลื่อนไหว**

Aspose.Slides for Android ผ่าน Java ช่วยให้คุณสามารถเปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์การเคลื่อนไหวได้.

นี่คือตาราง Animation Timing ใน Microsoft PowerPoint:

![example1_image](shape-animation.png)

การจับคู่ระหว่าง PowerPoint Timing และคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IEffect#getTiming--) มีดังนี้:

- ตัวเลือกดรอป‑ดาวน์ **Start** ของ PowerPoint Timing ตรงกับ property [Effect.Timing.TriggerType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITiming#getTriggerType--).
- ตัวเลือก **Duration** ของ PowerPoint Timing ตรงกับ property [Effect.Timing.Duration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITiming#getDuration--). ระยะเวลา (เป็นวินาที) คือเวลาทั้งหมดที่เอฟเฟกต์ใช้ในการทำรอบหนึ่ง.
- ตัวเลือก **Delay** ของ PowerPoint Timing ตรงกับ property [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).

วิธีการเปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์:

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์การเคลื่อนไหว.
2. ตั้งค่าที่ใหม่สำหรับ property [Effect.Timing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IEffect#getTiming--) ที่คุณต้องการ.
3. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว.

โค้ด Java นี้สาธิตการดำเนินการ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // ดึงลำดับหลักของสไลด์.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // ดึงเอฟเฟกต์แรกของลำดับหลัก.
    IEffect effect = sequence.get_Item(0);

    // เปลี่ยน TriggerType ของเอฟเฟกต์ให้เริ่มเมื่อคลิก
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // เปลี่ยนระยะเวลา (Duration) ของเอฟเฟกต์
    effect.getTiming().setDuration(3f);

    // เปลี่ยน TriggerDelayTime ของเอฟเฟกต์
    effect.getTiming().setTriggerDelayTime(0.5f);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เสียงของเอฟเฟกต์การเคลื่อนไหว**

Aspose.Slides ให้ property เหล่านี้เพื่อให้คุณทำงานกับเสียงในเอฟเฟกต์การเคลื่อนไหว:

- [setSound(IAudio value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **เพิ่มเสียงให้กับเอฟเฟกต์การเคลื่อนไหว**

โค้ด Java นี้แสดงวิธีเพิ่มเสียงให้กับเอฟเฟกต์การเคลื่อนไหวและหยุดเสียงเมื่อเอฟเฟกต์ถัดไปเริ่มต้น:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // เพิ่มออดิโอไปยังคอลเลกชันออดิโอของงานนำเสนอ
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // ดึงลำดับหลักของสไลด์.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // ดึงเอฟเฟกต์แรกของลำดับหลัก
    IEffect firstEffect = sequence.get_Item(0);

    // ตรวจสอบเอฟเฟกต์สำหรับ "ไม่มีเสียง"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // เพิ่มเสียงให้กับเอฟเฟกต์แรก
        firstEffect.setSound(effectSound);
    }

    // ดึงลำดับเชิงโต้ตอบแรกของสไลด์.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // ตั้งค่าสถานะ \"หยุดเสียงก่อนหน้า\" ของเอฟเฟกต์
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ดึงเสียงออกจากเอฟเฟกต์การเคลื่อนไหว**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. รับลำดับหลักของเอฟเฟกต์. 
4. ดึง [setSound(IAudio value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) ที่ฝังอยู่ในแต่ละเอฟเฟกต์การเคลื่อนไหว.

โค้ด Java นี้แสดงวิธีดึงเสียงที่ฝังอยู่ในเอฟเฟกต์การเคลื่อนไหว:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ดึงลำดับหลักของสไลด์.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // สกัดเสียงของเอฟเฟกต์เป็นอาร์เรย์ของไบต์
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **หลังการเคลื่อนไหว**

Aspose.Slides for Android ผ่าน Java ช่วยให้คุณสามารถเปลี่ยนคุณสมบัติ After animation ของเอฟเฟกต์การเคลื่อนไหวได้.

นี่คือตาราง Animation Effect และเมนูขยายใน Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

รายการดรอป‑ดาวน์ **After animation** ของ PowerPoint Effect ตรงกับคุณสมบัติดังต่อไปนี้:

- property [setAfterAnimationType(int value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) ที่บรรยายประเภท After animation :
  * PowerPoint **More Colors** ตรงกับประเภท [AfterAnimationType.Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#Color);
  * รายการ PowerPoint **Don't Dim** ตรงกับประเภท [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (ประเภท After animation เริ่มต้น);
  * รายการ PowerPoint **Hide After Animation** ตรงกับประเภท [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * รายการ PowerPoint **Hide on Next Mouse Click** ตรงกับประเภท [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- property [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) ที่กำหนดรูปแบบสี After animation. property นี้ทำงานร่วมกับประเภท [AfterAnimationType.Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#Color). หากคุณเปลี่ยนประเภทอื่น สี After animation จะถูกล้าง.

โค้ด Java นี้แสดงวิธีการเปลี่ยนเอฟเฟกต์ After animation:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // ดึงเอฟเฟกต์แรกของลำดับหลัก
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // เปลี่ยนประเภท After animation เป็น Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // ตั้งค่าสี After animation dim
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ทำให้ข้อความเคลื่อนไหว**

Aspose.Slides มี property เหล่านี้เพื่อให้คุณทำงานกับบล็อก *Animate text* ของเอฟเฟกต์การเคลื่อนไหว:

- [setAnimateTextType(int value)] ที่บรรยายประเภท Animate text ของเอฟเฟกต์. ข้อความของ shape สามารถเคลื่อนไหวได้:
  * ทั้งหมดพร้อมกัน ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) type)
  * ตามคำ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/animatetexttype/#ByWord) type)
  * ตามอักษร ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)] ตั้งค่าการหน่วงเวลา ระหว่างส่วนของข้อความที่เคลื่อนไหว (คำหรืออักษร). ค่าเป็นบวกระบุเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์. ค่าเป็นลบระบุเวลาหน่วงเป็นวินาที.

นี่คือวิธีการเปลี่ยนคุณสมบัติ Animate text ของเอฟเฟกต์:

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์การเคลื่อนไหว.
2. ตั้งค่า property [setBuildType(int value)] เป็นค่า [BuildType.AsOneObject] เพื่อปิดโหมดการเคลื่อนไหว *By Paragraphs*.
3. ตั้งค่าที่ใหม่สำหรับ property [setAnimateTextType(int value)] และ [setDelayBetweenTextParts(float value)].
4. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว.

โค้ด Java นี้สาธิตการดำเนินการ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // ดึงเอฟเฟกต์แรกของลำดับหลัก
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // เปลี่ยนประเภทการเคลื่อนที่ข้อความของเอฟเฟกต์เป็น "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // เปลี่ยนประเภท Animate text ของเอฟเฟกต์เป็น "By word"
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

**ฉันจะทำอย่างไรเพื่อให้แน่ใจว่าการเคลื่อนไหวยังคงอยู่เมื่อนำเสนอบนเว็บ?**

[Export to HTML5](/slides/th/androidjava/export-to-html5/) และเปิดใช้งาน [options](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/) ที่รับผิดชอบต่อการเคลื่อนไหวของ [shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และ [transition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). HTML ธรรมดาไม่เล่นการเคลื่อนไหวของสไลด์ ในขณะที่ HTML5 ทำได้.

**การเปลี่ยนลำดับชั้น (z-order) ของรูปทรงมีผลต่อการเคลื่อนไหวอย่างไร?**

การเคลื่อนไหวและลำดับการวาดเป็นเรื่องแยกกัน: เอฟเฟกต์กำหนดเวลาและประเภทของการปรากฏ/หายไป ในขณะที่ [z-order](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getZOrderPosition--) กำหนดว่าอะไรจะบังอะไร ผลลัพธ์ที่เห็นกำหนดโดยการผสมผสานของทั้งสอง (นี่คือพฤติกรรมทั่วไปของ PowerPoint; โมเดล effects-and-shapes ของ Aspose.Slides ทำตามตรรกะเดียวกัน).

**มีข้อจำกัดในการแปลงการเคลื่อนไหวเป็นวีดีโอสำหรับเอฟเฟกต์บางอย่างหรือไม่?**

โดยทั่วไป [การเคลื่อนไหวได้รับการสนับสนุน](/slides/th/androidjava/convert-powerpoint-to-video/), แต่ในกรณีบางกรณีที่หายากหรือเอฟเฟกต์เฉพาะอาจแสดงผลแตกต่างออกไป แนะนำให้ทดสอบกับเอฟเฟกต์ที่คุณใช้และกับเวอร์ชันของไลบรารี.