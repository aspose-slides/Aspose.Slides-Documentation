---
title: นำการเคลื่อนไหวรูปทรงไปใช้ในงานนำเสนอบน Android
linktitle: การเคลื่อนไหวรูปทรง
type: docs
weight: 60
url: /th/androidjava/shape-animation/
keywords:
- รูปทรง
- การเคลื่อนไหว
- เอฟเฟกต์
- รูปทรงเคลื่อนไหว
- ข้อความเคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- รับการเคลื่อนไหว
- ดึงการเคลื่อนไหว
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- ดึงเอฟเฟกต์
- เสียงเอฟเฟกต์
- ใช้การเคลื่อนไหว
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีสร้างและปรับแต่งการเคลื่อนไหวรูปทรงในการนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java. ทำให้โดดเด่น!"
---
## **บทนำ**

การเคลื่อนไหวเป็นเอฟเฟกต์ภาพที่สามารถนำไปใช้กับข้อความ รูปภาพ รูปร่าง หรือ [charts](https://docs.aspose.com/slides/th/androidjava/animated-charts/). พวกมันทำให้การนำเสนอหรือส่วนประกอบของมันมีชีวิตชีวา

## **ทำไมต้องใช้การเคลื่อนไหวในงานนำเสนอ?**

การใช้การเคลื่อนไหว คุณสามารถ  

* ควบคุมการไหลของข้อมูล  
* เน้นจุดสำคัญ  
* เพิ่มความสนใจหรือการมีส่วนร่วมของผู้ชม  
* ทำให้เนื้อหาอ่านง่ายหรือประมวลผลได้ง่ายขึ้น  
* ดึงความสนใจของผู้อ่านหรือผู้ชมไปยังส่วนสำคัญของการนำเสนอ  

PowerPoint มีตัวเลือกและเครื่องมือหลายอย่างสำหรับการเคลื่อนไหวและเอฟเฟกต์การเคลื่อนไหวในหมวด **entrance**, **exit**, **emphasis**, และ **motion paths**  

## **การเคลื่อนไหวใน Aspose.Slides**

* Aspose.Slides ให้คลาสและประเภทที่คุณต้องการเพื่อทำงานกับการเคลื่อนไหวภายใต้เนมสเปซ `Aspose.Slides.Animation`  
* Aspose.Slides มีเอฟเฟกต์การเคลื่อนไหวกว่า **150** รายการภายใต้ enumeration [EffectType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effecttype) เอฟเฟกต์เหล่านี้โดยพื้นฐานคือเอฟเฟกต์เดียวกัน (หรือเทียบเท่า) ที่ใช้ใน PowerPoint  

## **นำการเคลื่อนไหวไปใช้กับ TextBox**

Aspose.Slides for Android via Java ให้คุณนำการเคลื่อนไหวไปใช้กับข้อความในรูปทรงได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape)  
4. เพิ่มข้อความไปยัง [IAutoShape.TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-)  
5. รับลำดับหลักของเอฟเฟกต์  
6. เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape)  
7. ตั้งค่าคุณสมบัติ `TextAnimation.BuildType` ให้เป็นค่าจาก enumeration `BuildType`  
8. บันทึกการนำเสนอเป็นไฟล์ PPTX ลงดิสก์  

โค้ด Java นี้แสดงวิธีใช้เอฟเฟกต์ `Fade` กับ AutoShape และตั้งค่าการเคลื่อนไหวข้อความเป็นค่า *By 1st Level Paragraphs* :

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ใหม่พร้อมข้อความ
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // รับลำดับหลักของสไลด์.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว Fade ไปยังรูปทรง
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // ทำให้ข้อความในรูปทรงเคลื่อนไหวตามย่อหน้าระดับที่ 1
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}}  
นอกเหนือจากการนำการเคลื่อนไหวไปใช้กับข้อความ คุณสามารถนำการเคลื่อนไหวไปใช้กับ [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph) เดียวได้ ดู [**ข้อความเคลื่อนไหว**](/slides/th/androidjava/animated-text/)  
{{% /alert %}}  

## **นำการเคลื่อนไหวไปใช้กับ PictureFrame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มหรือรับ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe) บนสไลด์  
4. รับลำดับหลักของเอฟเฟกต์  
5. เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ [PictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pictureframe)  
6. บันทึกการนำเสนอเป็นไฟล์ PPTX ลงดิสก์  

โค้ด Java นี้แสดงวิธีใช้เอฟเฟกต์ `Fly` กับ PictureFrame :

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation pres = new Presentation();
try {
    // โหลดภาพที่จะเพิ่มในคอลเลกชันภาพของการนำเสนอ
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // เพิ่มเฟรมรูปภาพไปยังสไลด์
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // รับลำดับหลักของสไลด์.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว Fly จากด้านซ้ายไปยังเฟรมรูปภาพ
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **นำการเคลื่อนไหวไปใช้กับ Shape**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape)  
4. เพิ่ม `Bevel` [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape) (เมื่ออ็อบเจกต์นี้ถูกคลิก การเคลื่อนไหวจะเล่น)  
5. สร้างลำดับของเอฟเฟกต์บนรูปร่าง bevel  
6. สร้าง `UserPath` แบบกำหนดเอง  
7. เพิ่มคำสั่งสำหรับการย้ายไปยัง `UserPath`  
8. บันทึกการนำเสนอเป็นไฟล์ PPTX ลงดิสก์  

โค้ด Java นี้แสดงวิธีใช้เอฟเฟกต์ `PathFootball` กับรูปร่าง :

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // สร้างเอฟเฟกต์ PathFootball สำหรับรูปทรงที่มีอยู่จากศูนย์.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // สร้างสิ่งที่คล้ายปุ่ม.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // สร้างลำดับของเอฟเฟกต์สำหรับปุ่มนี้.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // สร้างเส้นทางผู้ใช้แบบกำหนดเอง. วัตถุของเราจะเคลื่อนที่หลังจากคลิกปุ่มเท่านั้น.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // เพิ่มคำสั่งการเคลื่อนที่ เนื่องจากเส้นทางที่สร้างยังว่างเปล่า.
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

## **รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับ Shape**

ตัวอย่างต่อไปนี้แสดงวิธีใช้เมธอด `getEffectsByShape` จากอินเทอร์เฟซ [ISequence](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isequence/) เพื่อรับเอฟเฟกต์การเคลื่อนไหวทั้งหมดที่ใช้กับรูปร่าง  

**Example 1: รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับรูปร่างบนสไลด์ปกติ**  

ก่อนหน้านี้ คุณได้เรียนรู้วิธีเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับรูปร่างใน PowerPoint ตัวอย่างโค้ดต่อไปนี้แสดงวิธีรับเอฟเฟกต์ที่ใช้กับรูปร่างแรกบนสไลด์ปกติตัวแรกในไฟล์ `AnimExample_out.pptx`  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // รับลำดับการเคลื่อนไหวหลักของสไลด์.
    // รับรูปทรงแรกบนสไลด์แรก.
    // รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับรูปทรง.

    IShape shape = firstSlide.getShapes().get_Item(0);

    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Example 2: รับเอฟเฟกต์การเคลื่อนไหวทั้งหมด รวมถึงที่สืบทอดจาก placeholder**  

หากรูปร่างบนสไลด์ปกติมี placeholder ที่อยู่บนสไลด์เลย์เอาต์หรือมาสเตอร์ และมีการเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ placeholder เหล่านั้น เอฟเฟกต์ทั้งหมดของรูปร่างจะเล่นในระหว่างการแสดงสไลด์ รวมถึงที่สืบทอดจาก placeholder  

สมมติว่าเรามีไฟล์ PowerPoint `sample.pptx` ที่มีสไลด์หนึ่งสไลด์ที่มีเฉพาะรูปร่างฟุตเตอร์ที่มีข้อความ “Made with Aspose.Slides” และมีเอฟเฟกต์ **Random Bars** ถูกนำไปใช้  

![เอฟเฟกต์การเคลื่อนไหวรูปร่างสไลด์](slide-shape-animation.png)  

สมมติว่าเอฟเฟกต์ **Split** ถูกนำไปใช้กับ placeholder ฟุตเตอร์บนสไลด์ **layout**  

![เอฟเฟกต์การเคลื่อนไหวรูปร่างเลย์เอาต์](layout-shape-animation.png)  

และสุดท้ายเอฟเฟกต์ **Fly In** ถูกนำไปใช้กับ placeholder ฟุตเตอร์บนสไลด์ **master**  

![เอฟเฟกต์การเคลื่อนไหวรูปร่างมาสเตอร์](master-shape-animation.png)  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้เมธอด `getBasePlaceholder` จากอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) เพื่อเข้าถึง placeholder ของรูปร่างและรับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับรูปร่างฟุตเตอร์ รวมถึงที่สืบทอดจาก placeholder บนเลย์เอาต์และมาสเตอร์  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// รับเอฟเฟกต์การเคลื่อนไหวของรูปทรงบนสไลด์ปกติ.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// รับเอฟเฟกต์การเคลื่อนไหวของ placeholder บนสไลด์เลย์เอาต์.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// รับเอฟเฟกต์การเคลื่อนไหวของ placeholder บนสไลด์มาสเตอร์.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

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

## **เปลี่ยนคุณสมบัติการกำหนดเวลาของเอฟเฟกต์การเคลื่อนไหว**

Aspose.Slides for Android via Java ให้คุณเปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์การเคลื่อนไหว  

นี่คือแถบ Animation Timing ใน Microsoft PowerPoint:  

![แผงการตั้งค่าเวลาเอฟเฟกต์](shape-animation.png)  

ความสัมพันธ์ระหว่าง PowerPoint Timing กับคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IEffect#getTiming--) มีดังนี้  

- รายการดึงลง **Start** ของ PowerPoint ตรงกับคุณสมบัติ [Effect.Timing.TriggerType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITiming#getTriggerType--)  
- **Duration** ของ PowerPoint ตรงกับคุณสมบัติ [Effect.Timing.Duration](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITiming#getDuration--) ระยะเวลาของการเคลื่อนไหว (หน่วยเป็นวินาที) คือเวลาทั้งหมดที่การเคลื่อนไหวใช้ครบหนึ่งรอบ  
- **Delay** ของ PowerPoint ตรงกับคุณสมบัติ [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--)  

วิธีการเปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์  

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์การเคลื่อนไหว  
2. ตั้งค่าคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IEffect#getTiming--) ใหม่ตามที่ต้องการ  
3. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว  

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // รับลำดับหลักของสไลด์.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // รับเอฟเฟ็กต์แรกของลำดับหลัก.
    IEffect effect = sequence.get_Item(0);

    // เปลี่ยน TriggerType ของเอฟเฟ็กต์ให้เริ่มเมื่อคลิก
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // เปลี่ยนระยะเวลา (Duration) ของเอฟเฟ็กต์
    effect.getTiming().setDuration(3f);

    // เปลี่ยน TriggerDelayTime ของเอฟเฟ็กต์
    effect.getTiming().setTriggerDelayTime(0.5f);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เสียงของเอฟเฟกต์การเคลื่อนไหว**

Aspose.Slides มีคุณสมบัติเหล่านี้เพื่อให้คุณทำงานกับเสียงในเอฟเฟกต์การเคลื่อนไหวได้  

- [setSound(IAudio value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **เพิ่มเสียงให้กับเอฟเฟกต์การเคลื่อนไหว**

โค้ด Java นี้แสดงวิธีเพิ่มเสียงให้กับเอฟเฟกต์การเคลื่อนไหวและหยุดเสียงเมื่อเอฟเฟกต์ถัดไปเริ่มต้น :  

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // เพิ่มเสียงเข้าไปในคอลเลกชันเสียงของการนำเสนอ
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // รับลำดับหลักของสไลด์.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // รับเอฟเฟกต์แรกของลำดับหลัก
    IEffect firstEffect = sequence.get_Item(0);

    // ตรวจสอบว่าเอฟเฟกต์ไม่มีเสียง
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // เพิ่มเสียงให้กับเอฟเฟกต์แรก
        firstEffect.setSound(effectSound);
    }

    // รับลำดับเชิงโต้ตอบแรกของสไลด์.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // ตั้งค่าสถานะ "หยุดเสียงก่อนหน้า" ของเอฟเฟกต์
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ดึงเสียงจากเอฟเฟกต์การเคลื่อนไหว**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. รับลำดับหลักของเอฟเฟกต์  
4. ดึงเมธอด [setSound(IAudio value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) ที่ฝังอยู่ในแต่ละเอฟเฟกต์การเคลื่อนไหว  

โค้ด Java นี้แสดงวิธีดึงเสียงที่ฝังอยู่ในเอฟเฟกต์การเคลื่อนไหว :  

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // รับลำดับหลักของสไลด์.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // ดึงเสียงของเอฟเฟกต์เป็นอาร์เรย์ไบต์
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **After Animation**

Aspose.Slides for Android via Java ให้คุณเปลี่ยนคุณสมบัติ After animation ของเอฟเฟกต์การเคลื่อนไหว  

นี่คือแถบ Animation Effect และเมนูขยายใน Microsoft PowerPoint:  

![เมนู After Animation](shape-after-animation.png)  

รายการดึงลง After animation ของ PowerPoint ตรงกับคุณสมบัติดังนี้  

- เมธอด [setAfterAnimationType(int value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) ที่บรรยายประเภท After animation :  
  * **More Colors** ของ PowerPoint ตรงกับชนิด [AfterAnimationType.Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#Color)  
  * **Don't Dim** ของ PowerPoint ตรงกับชนิด [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (ประเภท After animation เริ่มต้น)  
  * **Hide After Animation** ของ PowerPoint ตรงกับชนิด [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation)  
  * **Hide on Next Mouse Click** ของ PowerPoint ตรงกับชนิด [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick)  
- เมธอด [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) ที่กำหนดรูปแบบสี After animation นี้ทำงานร่วมกับชนิด [AfterAnimationType.Color](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/afteranimationtype/#Color) หากเปลี่ยนประเภทไปเป็นค่าอื่น สี After animation จะถูกล้าง  

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // รับเอฟเฟ็กต์แรกของลำดับหลัก
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // เปลี่ยนประเภท After animation เป็นสี
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // ตั้งค่าสี After animation dim
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animate Text**

Aspose.Slides มีคุณสมบัติเหล่านี้เพื่อให้คุณทำงานกับบล็อก *Animate text* ของเอฟเฟกต์การเคลื่อนไหวได้  

- เมธอด [setAnimateTextType(int value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) ที่บรรยายประเภทการเคลื่อนไหวข้อความของเอฟเฟกต์ ข้อความในรูปร่างสามารถเคลื่อนไหวได้:  
  - ทั้งหมดพร้อมกัน ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce))  
  - ตามคำ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/animatetexttype/#ByWord))  
  - ตามอักษร ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/animatetexttype/#ByLetter))  
- เมธอด [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) ตั้งค่าการหน่วงเวลาระหว่างส่วนข้อความที่เคลื่อนไหว (คำหรืออักษร) ค่าเป็นบวกระบุเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์ ค่าเป็นลบระบุหน่วงเวลาเป็นวินาที  

วิธีเปลี่ยนคุณสมบัติ Animate text ของเอฟเฟกต์  

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์การเคลื่อนไหว  
2. ตั้งค่าคุณสมบัติ [setBuildType(int value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) เป็นค่า [BuildType.AsOneObject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/buildtype/#AsOneObject) เพื่อปิดโหมด *By Paragraphs*  
3. ตั้งค่าคุณสมบัติ [setAnimateTextType(int value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) และ [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) ใหม่ตามต้องการ  
4. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว  

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // รับเอฟเฟ็กต์แรกของลำดับหลัก
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // เปลี่ยนประเภทการเคลื่อนไหวข้อความของเอฟเฟ็กต์เป็น "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // เปลี่ยนประเภทการเคลื่อนไหวข้อความของเอฟเฟ็กต์เป็น "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // ตั้งค่าการหน่วงเวลาระหว่างคำเป็น 20% ของระยะเวลาเอฟเฟ็กต์
    firstEffect.setDelayBetweenTextParts(20f);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### วิธีทำให้การเคลื่อนไหวคงไว้เมื่อเผยแพร่การนำเสนอบนเว็บได้อย่างไร?

[Export to HTML5](/slides/th/androidjava/export-to-html5/) และเปิดใช้ [options](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/) ที่รับผิดชอบการเคลื่อนไหวของ [shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) และ [transition](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). HTML ธรรมดาไม่เล่นการเคลื่อนไหวของสไลด์ ส่วน HTML5 ทำได้  

### การเปลี่ยนลำดับ z-order (ลำดับชั้น) ของรูปร่างส่งผลต่อการเคลื่อนไหวอย่างไร?

การจัดลำดับการเคลื่อนไหวและการวาดเป็นอิสระกัน: เอฟเฟกต์ควบคุมเวลาและประเภทของการปรากฏ/หายไป ขณะที่ [z-order](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getZOrderPosition--) กำหนดว่าชั้นใดบังชั้นใด ผลลัพธ์ที่มองเห็นเป็นผลรวมของทั้งสอง (เป็นพฤติกรรมทั่วไปของ PowerPoint; โมเดลเอฟเฟกต์และรูปร่างของ Aspose.Slides ทำตามตรรกะเดียวกัน)  

### มีข้อจำกัดใดเมื่อแปลงการเคลื่อนไหวเป็นวิดีโอสำหรับเอฟเฟกต์บางประเภทหรือไม่?

โดยทั่วไป [animations are supported](/slides/th/androidjava/convert-powerpoint-to-video/), แต่ในบางกรณีหรือเอฟเฟกต์เฉพาะอาจแสดงผลต่างออกไป ควรทดสอบกับเอฟเฟกต์ที่ใช้และรุ่นไลบรารีที่ใช้อยู่