---
title: ใช้การเคลื่อนไหวรูปทรงในงานนำเสนอด้วย .NET
linktitle: การเคลื่อนไหวรูปทรง
type: docs
weight: 60
url: /th/net/shape-animation/
keywords:
- รูปทรง
- การเคลื่อนไหว
- เอฟเฟกต์
- รูปทรงที่เคลื่อนไหว
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
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบวิธีการสร้างและปรับแต่งการเคลื่อนไหวรูปทรงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET ให้โดดเด่น!"
---
## **บทนำ**

การเคลื่อนไหวเป็นเอฟเฟกต์ภาพที่สามารถนำไปใช้กับข้อความ, รูปภาพ, รูปร่าง, หรือ [แผนภูมิ](/slides/th/net/animated-charts/). มันทำให้การนำเสนอหรือส่วนประกอบของมันมีชีวิตชีวา. 

## **ทำไมต้องใช้การเคลื่อนไหวในการนำเสนอ?**

ใช้การเคลื่อนไหว, คุณสามารถ 

* ควบคุมการไหลของข้อมูล
* เน้นจุดสำคัญ
* เพิ่มความสนใจหรือการมีส่วนร่วมของผู้ชม
* ทำให้เนื้อหาอ่านง่ายหรือรับรู้หรือประมวลผลได้ง่ายขึ้น
* ดึงความสนใจของผู้อ่านหรือผู้ชมไปยังส่วนสำคัญในการนำเสนอ

PowerPoint มีตัวเลือกและเครื่องมือหลายอย่างสำหรับการเคลื่อนไหวและเอฟเฟกต์การเคลื่อนไหวในหมวด **entrance**, **exit**, **emphasis**, และ **motion paths**. 

## **การเคลื่อนไหวใน Aspose.Slides**

* Aspose.Slides มีคลาสและประเภทที่คุณต้องการทำงานกับการเคลื่อนไหวภายใต้เนมสเปซ [Aspose.Slides.Animation](https://reference.aspose.com/slides/th/net/aspose.slides.animation/).
* Aspose.Slides มีเอฟเฟกต์การเคลื่อนไหวกว่า **150** ภายใต้ enumeration [EffectType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effecttype). เอฟเฟกต์เหล่านี้โดยพื้นฐานแล้วเหมือน (หรือเทียบเท่า) กับเอฟเฟกต์ที่ใช้ใน PowerPoint.

## **เพิ่มการเคลื่อนไหวให้กับ TextBox**

Aspose.Slides สำหรับ .NET ให้คุณเพิ่มการเคลื่อนไหวให้กับข้อความในรูปทรง. 

1. สร้างอินสแตนซ์ของคลาส [Presentation](http://www.aspose.com/api/net/slides/th/aspose.slides/).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape). 
4. เพิ่มข้อความไปยัง [IAutoShape.TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/properties/textframe).
5. รับลำดับหลักของเอฟเฟกต์.
6. เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape).
7. ตั้งค่า property [TextAnimation.BuildType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/textanimation/properties/buildtype) ให้เป็นค่าจาก [BuildType Enumeration](https://reference.aspose.com/slides/th/net/aspose.slides.animation/buildtype).
8. เขียนการนำเสนอไปยังดิสก์เป็นไฟล์ PPTX.

โค้ด C# นี้แสดงวิธีการเพิ่มเอฟเฟกต์ `Fade` ให้กับ AutoShape และตั้งค่าการเคลื่อนไหวของข้อความเป็นค่า *By 1st Level Paragraphs*:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาสการนำเสนอที่แทนไฟล์การนำเสนอ
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // เพิ่ม AutoShape ใหม่พร้อมข้อความ
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // เพิ่มย่อหน้าสามย่อหน้าเพื่อให้การสร้างตามย่อหน้ามีเนื้อหาที่จะก้าวผ่าน
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // รับลำดับหลักของสไลด์
    ISequence sequence = sld.Timeline.MainSequence;

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว Fade ให้กับรูปทรง
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // ทำให้ข้อความของรูปทรงเคลื่อนไหวตามย่อหน้าระดับที่ 1
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

นอกจากการเพิ่มการเคลื่อนไหวให้กับข้อความแล้ว คุณยังสามารถเพิ่มการเคลื่อนไหวให้กับ [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph) เพียงหนึ่งได้ ดู [**Animated Text**](/slides/th/net/animated-text/).

{{% /alert %}} 

## **เพิ่มการเคลื่อนไหวให้กับ PictureFrame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](http://www.aspose.com/api/net/slides/th/aspose.slides/).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. เพิ่มหรือรับ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe) บนสไลด์. 
5. รับลำดับหลักของเอฟเฟกต์.
6. เพิ่มเอฟเฟ็กต์การเคลื่อนไหวให้กับ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe).
8. เขียนการนำเสนอไปยังดิสก์เป็นไฟล์ PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาสการนำเสนอที่แทนไฟล์การนำเสนอ
using (Presentation pres = new Presentation())
{
    // โหลดรูปภาพที่จะเพิ่มในคอลเลกชันภาพของการนำเสนอ
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // เพิ่มเฟรมรูปภาพลงในสไลด์
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // รับลำดับหลักของสไลด์.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว Fly จากซ้ายให้กับเฟรมรูปภาพ
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **เพิ่มการเคลื่อนไหวให้กับ Shape**

1. สร้างอินสแตนซ์ของคลาส [Presentation](http://www.aspose.com/api/net/slides/th/aspose.slides/).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape). 
4. เพิ่ม `Bevel` [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape) (เมื่อวัตถุนี้ถูกคลิก การเคลื่อนไหวจะเริ่มเล่น).
5. สร้างลำดับของเอฟเฟกต์บนรูปทรง bevel.
6. สร้าง `UserPath` แบบกำหนดเอง.
7. เพิ่มคำสั่งสำหรับการเคลื่อนที่ไปยัง `UserPath`.
8. เขียนการนำเสนอไปยังดิสก์เป็นไฟล์ PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // สร้างเอฟเฟกต์ PathFootball สำหรับรูปทรงที่มีอยู่ตั้งแต่ต้น.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // สร้างบางประเภทของ "button".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // สร้างลำดับของเอฟเฟกต์สำหรับปุ่ม.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // สร้างเส้นทางผู้ใช้แบบกำหนดเอง วัตถุของเราจะเคลื่อนที่เฉพาะหลังจากคลิกปุ่ม.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // เพิ่มคำสั่งการเคลื่อนที่เนื่องจากเส้นทางที่สร้างว่างเปล่า.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับ Shape**

ตัวอย่างต่อไปนี้จะแสดงวิธีการใช้เมธอด `GetEffectsByShape` จากอินเทอร์เฟซ [ISequence](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence/) เพื่อรับเอฟเฟกต์การเคลื่อนไหวทั้งหมดที่ใช้กับรูปทรง.

**Example 1: Get animation effects applied to a shape on a normal slide**

ก่อนหน้านี้คุณได้เรียนรู้วิธีการเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับรูปทรงในการนำเสนอ PowerPoint ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับเอฟเฟกต์ที่ใช้กับรูปทรงแรกบนสไลด์ปกติเทั้งแรกในไฟล์การนำเสนอ `AnimExample_out.pptx`.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // รับลำดับการเคลื่อนไหวหลักของสไลด์.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // รับรูปทรงแรกบนสไลด์แรก.
    IShape shape = firstSlide.Shapes[0];

    // รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับรูปทรง.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Example 2: Get all animation effects, including those inherited from placeholders**

หากรูปทรงบนสไลด์ปกติมี placeholder ที่อยู่บนสไลด์ layout และ/หรือ master slide และมีการเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ placeholder เหล่านั้น แล้วเอฟเฟกต์ทั้งหมดของรูปทรงจะถูกเล่นระหว่างการแสดงสไลด์รวมถึงที่สืบทอดจาก placeholder

สมมติว่าไฟล์การนำเสนอ PowerPoint `sample.pptx` มีสไลด์หนึ่งที่มีเฉพาะรูปร่าง footer ที่มีข้อความ "Made with Aspose.Slides" และเอฟเฟกต์ **Random Bars** ถูกใช้กับรูปทรงนั้น

![เอฟเฟกต์การเคลื่อนไหวของรูปทรงสไลด์](slide-shape-animation.png)

สมมติว่าเอฟเฟกต์ **Split** ถูกใช้กับ placeholder ของส่วนท้ายบนสไลด์ **layout**

![เอฟเฟกต์การเคลื่อนไหวของรูปทรง Layout](layout-shape-animation.png)

และสุดท้ายเอฟเฟกต์ **Fly In** ถูกใช้กับ placeholder ของส่วนท้ายบนสไลด์ **master**

![เอฟเฟกต์การเคลื่อนไหวของรูปทรง Master](master-shape-animation.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการใช้เมธอด `GetBasePlaceholder` จากอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) เพื่อเข้าถึง placeholder ของรูปทรงและรับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับรูปทรง footer รวมถึงที่สืบทอดจาก placeholder ที่อยู่บนสไลด์ layout และ master

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // รับเอฟเฟกต์การเคลื่อนไหวของรูปทรงบนสไลด์ปกติ.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // รับเอฟเฟกต์การเคลื่อนไหวของ placeholder บนสไลด์ layout.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // รับเอฟเฟกต์การเคลื่อนไหวของ placeholder บนสไลด์ master.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
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

## **เปลี่ยนคุณสมบัติการกำหนดเวลาเอฟเฟกต์การเคลื่อนไหว**

Aspose.Slides สำหรับ .NET ให้คุณเปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์การเคลื่อนไหว.

นี่คือแถบ Animation Timing และเมนูขยายใน Microsoft PowerPoint:

![example1_image](shape-animation.png)

นี่คือความสอดคล้องระหว่าง PowerPoint Timing และคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effect/properties/timing):

- เมนูดรอปดาวน์ **Start** ของ PowerPoint Timing ตรงกับ property [Effect.Timing.TriggerType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/properties/triggertype). 
- เมนูดรอปดาวน์ **Duration** ของ PowerPoint Timing ตรงกับ property [Effect.Timing.Duration](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/properties/duration). ระยะเวลาของการเคลื่อนไหว (หน่วยเป็นวินาที) คือเวลาทั้งหมดที่การเคลื่อนไหวใช้เพื่อทำครบหนึ่งรอบ. 
- เมนูดรอปดาวน์ **Delay** ของ PowerPoint Timing ตรงกับ property [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- เมนูดรอปดาวน์ **Repeat** ของ PowerPoint Timing ตรงกับคุณสมบัติเหล่านี้: 
  * property [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatcount) ที่อธิบาย *จำนวน* ครั้งที่เอฟเฟกต์ทำซ้ำ;
  * flag [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatuntilendslide) ที่ระบุว่าเอฟเฟกต์ทำซ้ำจนจบสไลด์;
  * flag [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatuntilnextclick) ที่ระบุว่าเอฟเฟกต์ทำซ้ำจนกว่าจะมีการคลิกครั้งต่อไป.
- ช่องทำเครื่องหมาย **Rewind when done playing **ของ PowerPoint Timing ตรงกับ property [Effect.Timing.Rewind](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/rewind/). 

นี่คือลำดับการเปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์:

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์การเคลื่อนไหว.
2. ตั้งค่าตัวใหม่สำหรับ property [Effect.Timing](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effect/properties/timing) ที่คุณต้องการ. 
3. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // รับลำดับหลักของสไลด์.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // รับเอฟเฟกต์แรกของลำดับหลัก.
    IEffect effect = sequence[0];

    // เปลี่ยน TriggerType ของเอฟเฟกต์ให้เริ่มเมื่อคลิก
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // เปลี่ยนระยะเวลาของเอฟเฟกต์
    effect.Timing.Duration = 3f;

    // เปลี่ยน TriggerDelayTime ของเอฟเฟกต์
    effect.Timing.TriggerDelayTime = 0.5f;

    // ถ้าค่าการทำซ้ำของเอฟเฟกต์เป็น "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // เปลี่ยนการทำซ้ำของเอฟเฟกต์เป็น "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // เปลี่ยนการทำซ้ำของเอฟเฟกต์เป็น "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // เปิดการรีวินด์ของเอฟเฟกต์
        effect.Timing.Rewind = true;
    
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **เสียงของเอฟเฟกต์การเคลื่อนไหว**

Aspose.Slides มีคุณสมบัติเหล่านี้ให้คุณทำงานกับเสียงในเอฟเฟกต์การเคลื่อนไหว: 
- [IEffect.Sound](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effect/stopprevioussound/) 

### **เพิ่มเสียงให้กับเอฟเฟกต์การเคลื่อนไหว**

โค้ด C# นี้แสดงวิธีการเพิ่มเสียงให้กับเอฟเฟกต์การเคลื่อนไหวและหยุดเสียงเมื่อเอฟเฟกต์ต่อไปเริ่มทำงาน:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// เพิ่มเสียงเข้าไปในคอลเลกชันเสียงของการนำเสนอ
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// รับลำดับหลักของสไลด์.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// รับเอฟเฟกต์แรกของลำดับหลัก
	IEffect firstEffect = sequence[0];

	// ตรวจสอบว่าเอฟเฟกต์ไม่มีเสียง
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// เพิ่มเสียงให้กับเอฟเฟกต์แรก
		firstEffect.Sound = effectSound;
	}

	// รับลำดับเชิงโต้ตอบแรกของสไลด์.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// ตั้งค่าสถานะ "Stop previous sound" ของเอฟเฟกต์
	interactiveSequence[0].StopPreviousSound = true;

	// เขียนไฟล์ PPTX ไปยังดิสก์
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **ดึงเสียงของเอฟเฟกต์การเคลื่อนไหว**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. รับลำดับหลักของเอฟเฟกต์. 
4. ดึง [Sound] ที่ฝังอยู่ในแต่ละเอฟเฟกต์การเคลื่อนไหว. 

โค้ด C# นี้แสดงวิธีการดึงเสียงที่ฝังอยู่ในเอฟเฟกต์การเคลื่อนไหว:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // รับลำดับหลักของสไลด์.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // ดึงเสียงของเอฟเฟกต์เป็นอาเรย์ไบต์
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **หลังการเคลื่อนไหว**

Aspose.Slides สำหรับ .NET ให้คุณเปลี่ยนคุณสมบัติ After animation ของเอฟเฟกต์การเคลื่อนไหว.

นี่คือแถบ Animation Effect และเมนูขยายใน Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

เมนูดรอปดาวน์ **After animation** ของ PowerPoint Effect ตรงกับคุณสมบัติเหล่านี้: 

- property [IEffect.AfterAnimationType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/afteranimationtype/) ที่อธิบายประเภท After animation :
  * **More Colors** ของ PowerPoint ตรงกับ type [AfterAnimationType.Color](https://reference.aspose.com/slides/th/net/aspose.slides.animation/afteranimationtype/).
  * รายการ **Don't Dim** ของ PowerPoint ตรงกับ type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/th/net/aspose.slides.animation/afteranimationtype/) (ประเภท After animation เริ่มต้น);
  * รายการ **Hide After Animation** ของ PowerPoint ตรงกับ type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/th/net/aspose.slides.animation/afteranimationtype/);
  * รายการ **Hide on Next Mouse Click** ของ PowerPoint ตรงกับ type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/th/net/aspose.slides.animation/afteranimationtype/);
- property [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/afteranimationcolor/) ที่กำหนดรูปแบบสีของ After animation. Property นี้ทำงานร่วมกับ type [AfterAnimationType.Color](https://reference.aspose.com/slides/th/net/aspose.slides.animation/afteranimationtype/). หากคุณเปลี่ยนประเภทเป็นอื่น สี After animation จะถูกล้างออก.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // รับเอฟเฟกต์แรกของลำดับหลัก
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // เปลี่ยนประเภท After animation เป็น Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // ตั้งค่าสี After animation dim
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **เคลื่อนไหวข้อความ**

Aspose.Slides มีคุณสมบัติเหล่านี้ให้คุณทำงานกับบล็อก *Animate text* ของเอฟเฟกต์การเคลื่อนไหว:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/animatetexttype/) ที่อธิบายประเภทการเคลื่อนไหวของข้อความ. ข้อความของรูปทรงสามารถเคลื่อนไหวได้:
  - ทั้งหมดพร้อมกัน ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/th/net/aspose.slides.animation/animatetexttype/) type)
  - ตามคำ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/th/net/aspose.slides.animation/animatetexttype/) type)
  - ตามตัวอักษร ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/th/net/aspose.slides.animation/animatetexttype/) type)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/delaybetweentextparts/) ตั้งค่าเดเลย์ระหว่างส่วนของข้อความที่เคลื่อนไหว (คำหรืออักษร). ค่าบวกระบุเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์. ค่าลบระบุเวลาหน่วงในหน่วยวินาที.

นี่คือลำดับการเปลี่ยนคุณสมบัติ Animate text ของเอฟเฟ็กต์:

1. [Apply](#apply-animation-to-shape) หรือรับเอฟเฟกต์การเคลื่อนไหว.
2. ตั้งค่า property [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itextanimation/buildtype/) ให้เป็นค่า [BuildType.AsOneObject](https://reference.aspose.com/slides/th/net/aspose.slides.animation/buildtype/) เพื่อปิดโหมดการเคลื่อนไหว *By Paragraphs*.
3. ตั้งค่าตัวใหม่สำหรับ property [IEffect.AnimateTextType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/animatetexttype/) และ [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // รับเอฟเฟกต์แรกของลำดับหลัก
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // เปลี่ยนประเภทการเคลื่อนไหวข้อความของเอฟเฟกต์เป็น "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // เปลี่ยนประเภท Animate text ของเอฟเฟ็กต์เป็น "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // ตั้งค่าการหน่วงระหว่างคำเป็น 20% ของระยะเวลาเอฟเฟกต์
    firstEffect.DelayBetweenTextParts = 20f;

    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

### ฉันจะทำอย่างไรเพื่อให้การเคลื่อนไหวยังคงอยู่เมื่อนำเสนอไปยังเว็บ?

[Export to HTML5](/slides/th/net/export-to-html5/) และเปิดใช้ [options](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/) ที่รับผิดชอบสำหรับการเคลื่อนไหวของ [shape](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/animateshapes/) และ [transition](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/animatetransitions/). HTML ปกติไม่เล่นการเคลื่อนไหวของสไลด์ แต่ HTML5 ทำได้.

### การเปลี่ยนลำดับชั้น (z-order) ของรูปร่างมีผลต่อการเคลื่อนไหวอย่างไร?

การกำหนดลำดับการวาดและการเคลื่อนไหวเป็นอิสระกัน: เอฟเฟกต์กำหนดเวลาและประเภทของการปรากฏ/หายไป, ส่วน [z-order](https://reference.aspose.com/slides/th/net/aspose.slides/shape/zorderposition/) กำหนดว่าอะไรจะบังอะไร ผลลัพธ์ที่มองเห็นจะขึ้นกับการผสานของทั้งสอง (เป็นพฤติกรรมทั่วไปของ PowerPoint; โมเดลเอฟเฟกต์และรูปร่างของ Aspose.Slides ทำตามตรรกะเดียวกัน).

### มีข้อจำกัดใดเมื่อแปลงการเคลื่อนไหวเป็นวิดีโอสำหรับเอฟเฟกต์บางอย่างหรือไม่?

โดยทั่วไป [animations are supported](/slides/th/net/convert-powerpoint-to-video/), แต่ในบางกรณีหรือเอฟเฟกต์เฉพาะอาจแสดงผลแตกต่างกัน แนะนำให้ทดสอบกับเอฟเฟกต์ที่คุณใช้และกับรุ่นของไลบรารี.