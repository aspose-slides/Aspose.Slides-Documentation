---
title: ใช้การเคลื่อนไหวรูปร่างในงานนำเสนอด้วย JavaScript
linktitle: การเคลื่อนไหวรูปร่าง
type: docs
weight: 60
url: /th/nodejs-java/shape-animation/
keywords:
- รูปร่าง
- การเคลื่อนไหว
- เอฟเฟกต์
- รูปร่างที่เคลื่อนไหว
- ข้อความที่เคลื่อนไหว
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
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบวิธีสร้างและปรับแต่งการเคลื่อนไหวรูปร่างในงานนำเสนอ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อให้โดดเด่น!"
---
## **บทนำ**

การเคลื่อนไหวเป็นเอฟเฟกต์ภาพที่สามารถใช้กับข้อความ, รูปภาพ, รูปร่าง หรือ [แผนภูมิ](/slides/th/nodejs-java/animated-charts/). พวกมันทำให้การนำเสนอหรือส่วนประกอบของมันมีชีวิตชีวา.

## **ทำไมต้องใช้การเคลื่อนไหวในการนำเสนอ?**

โดยใช้การเคลื่อนไหว, คุณสามารถ  

* ควบคุมการไหลของข้อมูล  
* เน้นจุดสำคัญ  
* เพิ่มความสนใจหรือการมีส่วนร่วมของผู้ฟัง  
* ทำให้เนื้อหาอ่านง่ายขึ้นหรือเข้าใจและประมวลผลได้ง่ายกว่า  
* ดึงดูดความสนใจของผู้อ่านหรือผู้ชมไปยังส่วนสำคัญในงานนำเสนอ  

PowerPoint มีตัวเลือกและเครื่องมือมากมายสำหรับการเคลื่อนไหวและเอฟเฟกต์การเคลื่อนไหวในหมวด **entrance**, **exit**, **emphasis**, และ **motion paths**.

## **การเคลื่อนไหวใน Aspose.Slides**

* Aspose.Slides มีคลาสและประเภทที่คุณต้องการเพื่อทำงานกับการเคลื่อนไหวภายใต้เนมสเปซ `Aspose.Slides.Animation`  
* Aspose.Slides มีเอฟเฟกต์การเคลื่อนไหวกว่า **150** รายการภายใต้ enumeration [EffectType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effecttype). เอฟเฟกต์เหล่านี้โดยพื้นฐานแล้วเหมือนหรือเทียบเท่ากับเอฟเฟกต์ที่ใช้ใน PowerPoint.

## **ใช้การเคลื่อนไหวกับ TextBox**

Aspose.Slides สำหรับ Node.js ผ่าน Java ให้คุณสามารถใช้การเคลื่อนไหวกับข้อความในรูปร่างได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation).  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape) ประเภท `rectangle`.  
4. เพิ่มข้อความโดยใช้ [AutoShape.addTextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).  
5. รับลำดับหลักของเอฟเฟกต์.  
6. เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape).  
7. เรียกเมธอด `TextAnimation.setBuildType` พร้อมค่าจาก enumeration `BuildType`.  
8. บันทึกการนำเสนอลงดิสก์เป็นไฟล์ PPTX.  

โค้ด Javascript นี้แสดงให้คุณเห็นวิธีการใช้เอฟเฟกต์ `Fade` กับ AutoShape และตั้งค่าการเคลื่อนไหวข้อความเป็นค่า *By 1st Level Paragraphs*:

```javascript
// สร้างอินสแตนซ์ของคลาสการนำเสนอที่แทนไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape ใหม่พร้อมข้อความ
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // รับลำดับหลักของสไลด์.
    var sequence = sld.getTimeline().getMainSequence();
    // เพิ่มเอฟเฟกต์การเคลื่อนไหว Fade ให้กับรูปร่าง
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // ทำให้ข้อความของรูปร่างเคลื่อนไหวตามย่อหน้าระดับที่ 1
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 
นอกจากการใช้การเคลื่อนไหวกับข้อความแล้ว คุณยังสามารถใช้การเคลื่อนไหวกับ [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph) เดี่ยวได้ ดู [**Animated Text**](/slides/th/nodejs-java/animated-text/).
{{% /alert %}} 

## **ใช้การเคลื่อนไหวกับ PictureFrame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation).  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.  
3. เพิ่มหรือรับ [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe) บนสไลด์.  
4. รับลำดับหลักของเอฟเฟกต์.  
5. เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe).  
6. บันทึกการนำเสนอลงดิสก์เป็นไฟล์ PPTX.  

โค้ด Javascript นี้แสดงให้คุณเห็นวิธีการใช้เอฟเฟกต์ `Fly` กับกรอบรูปภาพ:

```javascript
// สร้างอินสแตนซ์ของคลาสการนำเสนอที่แทนไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation();
try {
    // โหลดรูปภาพที่จะเพิ่มในคอลเลกชันรูปภาพของการนำเสนอ
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // เพิ่มเฟรมภาพไปยังสไลด์
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // รับลำดับหลักของสไลด์.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // เพิ่มเอฟเฟกต์การเคลื่อนไหว Fly จากด้านซ้ายให้กับเฟรมภาพ
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ใช้การเคลื่อนไหวกับ Shape**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation).  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape) ประเภท `rectangle`.  
4. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape) ประเภท `Bevel` (เมื่อคลิกวัตถุนี้ การเคลื่อนไหวจะเล่น).  
5. สร้างลำดับของเอฟเฟกต์บนรูปร่าง bevel.  
6. สร้าง `UserPath` แบบกำหนดเอง.  
7. เพิ่มคำสั่งการเคลื่อนที่ไปยัง `UserPath`.  
8. บันทึกการนำเสนอลงดิสก์เป็นไฟล์ PPTX.  

โค้ด Javascript นี้แสดงให้คุณเห็นวิธีการใช้เอฟเฟกต์ `PathFootball` (path football) กับรูปร่าง:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // สร้างเอฟเฟกต์ PathFootball ให้กับรูปร่างที่มีอยู่จากศูนย์
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // เพิ่มเอฟเฟกต์การเคลื่อนไหว PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // สร้าง "ปุ่ม" ประเภทหนึ่ง
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // สร้างลำดับของเอฟเฟกต์สำหรับปุ่มนี้
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // สร้างเส้นทางผู้ใช้แบบกำหนดเอง วัตถุของเราจะเคลื่อนที่หลังจากคลิกปุ่มเท่านั้น
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // เพิ่มคำสั่งการเคลื่อนที่เนื่องจากเส้นทางที่สร้างยังว่างเปล่า
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับ Shape**

ตัวอย่างต่อไปนี้แสดงให้คุณเห็นวิธีการใช้เมธอด `getEffectsByShape` จากคลาส [Sequence](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/) เพื่อรับเอฟเฟกต์การเคลื่อนไหวทั้งหมดที่ใช้กับรูปร่าง.

**ตัวอย่าง 1: รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับรูปร่างบนสไลด์ปกติ**

ก่อนหน้านี้คุณได้เรียนรู้วิธีการเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับรูปร่างในงานนำเสนอ PowerPoint ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับเอฟเฟกต์ที่ใช้กับรูปร่างแรกบนสไลด์ปกติแรกในไฟล์การนำเสนอ `AnimExample_out.pptx`.

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // รับลำดับการเคลื่อนไหวหลักของสไลด์.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // รับรูปร่างแรกบนสไลด์แรก.
    var shape = firstSlide.getShapes().get_Item(0);

    // รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับรูปร่าง.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**ตัวอย่าง 2: รับเอฟเฟกต์การเคลื่อนไหวนทั้งหมด รวมถึงที่สืบทอดจาก placeholder**

หากรูปร่างบนสไลด์ปกติมี placeholder ที่อยู่บนสไลด์เลย์เอาต์และ/หรือสไลด์มาสเตอร์ และได้เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ placeholder เหล่านั้น ทั้งหมดของรูปร่างจะถูกเล่นในระหว่างการแสดงสไลด์รวมถึงเอฟเฟกต์ที่สืบทอดจาก placeholder  

สมมติว่าเรามีไฟล์การนำเสนอ PowerPoint `sample.pptx` ที่มีสไลด์หนึ่งที่มีเพียงรูปร่างส่วนท้ายที่มีข้อความ "Made with Aspose.Slides" และได้ใช้เอฟเฟกต์ **Random Bars** กับรูปร่างนั้น.

![Slide shape animation effect](slide-shape-animation.png)

สมมติเพิ่มเติมว่าเอฟเฟกต์ **Split** ถูกใช้กับ placeholder ส่วนท้ายบนสไลด์ **layout**.

![Layout shape animation effect](layout-shape-animation.png)

และสุดท้ายว่าเอฟเฟกต์ **Fly In** ถูกใช้กับ placeholder ส่วนท้ายบนสไลด์ **master**.

![Master shape animation effect](master-shape-animation.png)

ตัวอย่างโค้ดต่อไปนี้แสดงให้คุณเห็นวิธีการใช้เมธอด `getBasePlaceholder` จากคลาส [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) เพื่อเข้าถึง placeholder ของรูปทรงและรับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับรูปร่างส่วนท้าย, รวมถึงที่สืบทอดจาก placeholder ที่อยู่บนสไลด์เลย์เอาต์และมาสเตอร์.

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // บิน, ด้านล่าง
Type: 134, subtype: 45            // แบ่ง, แนวตั้งเข้า
Type: 126, subtype: 22            // แถบสุ่ม, แนวนอน
```

## **เปลี่ยนคุณสมบัติเวลา (Timing) ของเอฟเฟกต์การเคลื่อนไหว**

Aspose.Slides สำหรับ Node.js ผ่าน Java ให้คุณสามารถเปลี่ยนคุณสมบัติเวลา (Timing) ของเอฟเฟกต์การเคลื่อนไหวได้  

นี่คือแผง Animation Timing ใน Microsoft PowerPoint:

![example1_image](shape-animation.png)

การจับคู่ระหว่าง PowerPoint Timing และคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Effect#getTiming--) มีดังนี้  

- รายการแบบดรอป‑ดาวน์ PowerPoint Timing **Start** ตรงกับคุณสมบัติ [Effect.Timing.TriggerType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Timing#getTriggerType--)  
- PowerPoint Timing **Duration** ตรงกับคุณสมบัติ [Effect.Timing.Duration](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Timing#getDuration--). ระยะเวลาของการเคลื่อนไหว (เป็นวินาที) คือเวลาทั้งหมดที่การเคลื่อนที่ใช้เพื่อจบหนึ่งรอบ  
- PowerPoint Timing **Delay** ตรงกับคุณสมบัติ [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--)  

วิธีการเปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์:  

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์การเคลื่อนไหว.  
2. ตั้งค่าค่าใหม่สำหรับคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Effect#getTiming--) ที่คุณต้องการ.  
3. บันทึกไฟล์ PPTX ที่แก้ไข.  

โค้ด Javascript นี้แสดงการดำเนินการ:

```javascript
// สร้างอินสแตนซ์ของคลาสการนำเสนอที่แทนไฟล์การนำเสนอ.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // รับลำดับหลักของสไลด์.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // รับเอฟเฟกต์แรกของลำดับหลัก.
    var effect = sequence.get_Item(0);
    // เปลี่ยน TriggerType ของเอฟเฟกต์ให้เริ่มเมื่อคลิก
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // เปลี่ยนระยะเวลาเอฟเฟกต์
    effect.getTiming().setDuration(3.0);
    // เปลี่ยน TriggerDelayTime ของเอฟเฟกต์
    effect.getTiming().setTriggerDelayTime(0.5);
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เสียงของเอฟเฟกต์การเคลื่อนไหว**

Aspose.Slides ให้คุณสมบัติเหล่านี้เพื่อทำงานกับเสียงในเอฟเฟกต์การเคลื่อนไหว:  

- [setSound(IAudio value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **เพิ่มเสียงให้เอฟเฟกต์การเคลื่อนไหว**

โค้ด Javascript นี้แสดงให้คุณเห็นวิธีการเพิ่มเสียงให้เอฟเฟกต์การเคลื่อนไหวและหยุดเสียงเมื่อเอฟเฟกต์ถัดไปเริ่มต้น:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // เพิ่มเสียงไปยังคอลเลกชันเสียงของการนำเสนอ
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // รับลำดับหลักของสไลด์.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // รับเอฟเฟกต์แรกของลำดับหลัก
    var firstEffect = sequence.get_Item(0);
    // ตรวจสอบว่าเอฟเฟกต์ไม่มีเสียง
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // เพิ่มเสียงให้กับเอฟเฟกต์แรก
        firstEffect.setSound(effectSound);
    }
    // รับลำดับโต้ตอบแรกของสไลด์.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // ตั้งค่าสถานะ "หยุดเสียงก่อนหน้า" ของเอฟเฟกต์
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ดึงเสียงจากเอฟเฟกต์การเคลื่อนไหว**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/).  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.  
3. รับลำดับหลักของเอฟเฟกต์.  
4. ดึง [setSound(IAudio value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) ที่ฝังอยู่ในแต่ละเอฟเฟกต์การเคลื่อนไหว.  

โค้ด Javascript นี้แสดงวิธีการดึงเสียงที่ฝังอยู่ในเอฟเฟกต์การเคลื่อนไหว:

```javascript
// สร้างอินสแตนซ์ของคลาสการนำเสนอที่แทนไฟล์การนำเสนอ.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // รับลำดับหลักของสไลด์.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // ดึงเสียงเอฟเฟกต์เป็นอาร์เรย์ไบต์
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **หลังการเคลื่อนไหว**

Aspose.Slides สำหรับ Node.js ผ่าน Java ให้คุณสามารถเปลี่ยนคุณสมบัติ After animation ของเอฟเฟกต์การเคลื่อนไหวได้  

นี่คือแผง Animation Effect และเมนูขยายใน Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

รายการแบบดรอป‑ดาวน์ PowerPoint Effect **After animation** ตรงกับคุณสมบัติดังต่อไปนี้  

- เมธอด [setAfterAnimationType(int value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) ที่อธิบายประเภท After animation;  
  * PowerPoint **More Colors** ตรงกับประเภท [AfterAnimationType.Color](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/afteranimationtype/#Color)  
  * รายการ PowerPoint **Don't Dim** ตรงกับประเภท [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (ประเภท after animation ค่าเริ่มต้น)  
  * รายการ PowerPoint **Hide After Animation** ตรงกับประเภท [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation)  
  * รายการ PowerPoint **Hide on Next Mouse Click** ตรงกับประเภท [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick)  
- เมธอด [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) ซึ่งกำหนดรูปแบบสีของ after animation. เมธอดนี้ทำงานร่วมกับประเภท [AfterAnimationType.Color](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/afteranimationtype/#Color). หากคุณเปลี่ยนประเภทเป็นค่าอื่น สี after animation จะถูกลบออก.

โค้ด Javascript นี้แสดงวิธีการเปลี่ยนเอฟเฟกต์ after animation:

```javascript
// สร้างอินสแตนซ์ของคลาสการนำเสนอที่แทนไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // รับเอฟเฟกต์แรกของลำดับหลัก
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // เปลี่ยนประเภท after animation เป็นสี
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // ตั้งค่าสีของ after animation
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เคลื่อนไหวข้อความ**

Aspose.Slides ให้คุณสมบัติเหล่านี้เพื่อทำงานกับบล็อก *Animate text* ของเอฟเฟกต์:  

- เมธอด [setAnimateTextType(int value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) ที่อธิบายประเภทการเคลื่อนไหวข้อความของเอฟเฟกต์. ข้อความของรูปร่างสามารถเคลื่อนไหวได้:  
  - ทั้งหมดพร้อมกัน ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce))  
  - ทีละคำ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/animatetexttype/#ByWord))  
  - ทีละตัวอักษร ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/animatetexttype/#ByLetter))  
- เมธอด [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) กำหนดค่าหน่วงเวลาระหว่างส่วนของข้อความที่เคลื่อนไหว (คำหรืออักษร). ค่าบวกระบุเป็นเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์, ค่าลบระบุเป็นวินาที.

นี่คือวิธีการเปลี่ยนคุณสมบัติ Effect Animate text:

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์การเคลื่อนไหว.  
2. ตั้งค่าเมธอด [setBuildType(int value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) เป็นค่า [BuildType.AsOneObject](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/buildtype/#AsOneObject) เพื่อปิดโหมดการเคลื่อนไหว *By Paragraphs*.  
3. ตั้งค่าค่าใหม่สำหรับเมธอด [setAnimateTextType(int value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) และ [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-).  
4. บันทึกไฟล์ PPTX ที่แก้ไข.  

โค้ด Javascript นี้แสดงการดำเนินการ:

```javascript
// สร้างอินสแตนซ์ของคลาสการนำเสนอที่แทนไฟล์การนำเสนอ.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // รับเอฟเฟกต์แรกของลำดับหลัก
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // เปลี่ยนประเภทการเคลื่อนไหวข้อความของเอฟเฟกต์เป็น "As One Object"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // เปลี่ยนประเภทการเคลื่อนไหวข้อความของเอฟเฟกต์เป็น "By word"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // ตั้งค่าการหน่วงเวลาระหว่างคำเป็น 20% ของระยะเวลาเอฟเฟกต์
    firstEffect.setDelayBetweenTextParts(20.0);
    // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันจะทำอย่างไรให้แน่ใจว่าการเคลื่อนไหวยังคงอยู่เมื่อทำการเผยแพร่การนำเสนอไปยังเว็บ?**  
[Export to HTML5](/slides/th/nodejs-java/export-to-html5/) และเปิดใช้งาน [options](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/html5options/) ที่รับผิดชอบการเคลื่อนไหวของ [shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/html5options/setanimateshapes/) และ [transition](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/html5options/setanimatetransitions/). HTML ธรรมดาไม่สามารถเล่นการเคลื่อนไหวของสไลด์ได้, แต่ HTML5 สามารถทำได้.

**การเปลี่ยนลำดับ z‑order (ลำดับชั้น) ของรูปร่างมีผลต่อการเคลื่อนไหวอย่างไร?**  
การเคลื่อนไหวและลำดับการวาดเป็นสิ่งอิสระ: เอฟเฟกต์ควบคุมเวลาและประเภทของการปรากฏ/หายไป, ในขณะที่ [z-order](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getzorderposition/) กำหนดว่ารูปร่างใดครอบคลุมรูปร่างใด ผลลัพธ์ที่มองเห็นได้ถูกกำหนดโดยการผสมผสานของทั้งสอง (นี่คือพฤติกรรมทั่วไปของ PowerPoint; โมเดล effects‑and‑shapes ของ Aspose.Slides ทำตามตรรกะเดียวกัน).

**มีข้อจำกัดอะไรบ้างเมื่อแปลงการเคลื่อนไหวเป็นวิดีโอสำหรับเอฟเฟกต์บางประเภท?**  
โดยทั่วไปแล้ว [animations are supported](/slides/th/nodejs-java/convert-powerpoint-to-video/), แต่ในกรณีที่หายากหรือเอฟเฟกต์เฉพาะอาจแสดงผลแตกต่างกัน แนะนำให้ทดสอบกับเอฟเฟกต์ที่คุณใช้และกับเวอร์ชันของไลบรารี.