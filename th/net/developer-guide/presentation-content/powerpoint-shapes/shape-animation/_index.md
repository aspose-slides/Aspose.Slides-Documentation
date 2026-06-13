---
title: ใช้การเคลื่อนไหวรูปทรงในงานนำเสนอใน .NET
linktitle: การเคลื่อนไหวรูปทรง
type: docs
weight: 60
url: /th/net/shape-animation/
keywords:
- รูปทรง
- การเคลื่อนไหว
- เอฟเฟกต์
- รูปทรงเคลื่อนไหว
- ข้อความเคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- รับการเคลื่อนไหว
- สกัดการเคลื่อนไหว
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- สกัดเอฟเฟกต์
- เสียงเอฟเฟกต์
- ใช้การเคลื่อนไหว
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบวิธีสร้างและปรับแต่งการเคลื่อนไหวรูปทรงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET ให้โดดเด่น!"
---
## **บทนำ**

การเคลื่อนไหวเป็นเอฟเฟกต์ภาพที่สามารถนำไปใช้กับข้อความ ภาพ รูปร่าง หรือ [แผนภูมิ](/slides/th/net/animated-charts/). พวกมันทำให้การนำเสนอหรือส่วนประกอบของมันมีชีวิตชีวา. 

## **ทำไมต้องใช้การเคลื่อนไหวในงานนำเสนอ?**

การใช้การเคลื่อนไหวคุณสามารถ 

* ควบคุมการไหลของข้อมูล
* เน้นจุดสำคัญ
* เพิ่มความสนใจหรือการมีส่วนร่วมของผู้ชม
* ทำให้เนื้อหาง่ายต่อการอ่าน หรือการทำความเข้าใจ หรือการประมวลผล
* ดึงดูดความสนใจของผู้อ่านหรือผู้ชมไปยังส่วนสำคัญในงานนำเสนอ

PowerPoint มีตัวเลือกและเครื่องมือหลายอย่างสำหรับการเคลื่อนไหวและเอฟเฟกต์การเคลื่อนไหวในหมวด **entrance**, **exit**, **emphasis**, และ **motion paths**. 

## **การเคลื่อนไหวใน Aspose.Slides**

* Aspose.Slides มีคลาสและชนิดที่คุณต้องการใช้สำหรับการทำงานกับการเคลื่อนไหวในเนมสเปซ [Aspose.Slides.Animation](https://reference.aspose.com/slides/th/net/aspose.slides.animation/) 
* Aspose.Slides มีเอฟเฟกต์การเคลื่อนไหวกว่า **150** ชนิดใน enumeration [EffectType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effecttype). เอฟเฟกต์เหล่านี้โดยพื้นฐานแล้วเหมือนกับ (หรือเทียบเท่า) เอฟเฟกต์ที่ใช้ใน PowerPoint.

## **ใช้การเคลื่อนไหวกับ TextBox**

Aspose.Slides สำหรับ .NET ให้คุณเพิ่มการเคลื่อนไหวให้กับข้อความในรูปทรง. 

1. สร้างอินสแตนซ์ของคลาส [Presentation](http://www.aspose.com/api/net/slides/th/aspose.slides/). 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape). 
4. เพิ่มข้อความไปยัง [IAutoShape.TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/properties/textframe). 
5. รับลำดับหลักของเอฟเฟกต์. 
6. เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape). 
7. ตั้งค่า property [TextAnimation.BuildType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/textanimation/properties/buildtype) ให้เป็นค่าจาก [BuildType Enumeration](https://reference.aspose.com/slides/th/net/aspose.slides.animation/buildtype). 
8. บันทึกงานนำเสนอลงดิสก์เป็นไฟล์ PPTX. 

โค้ด C# นี้แสดงวิธีการใช้เอฟเฟกต์ `Fade` กับ AutoShape และตั้งค่าการเคลื่อนไหวของข้อความเป็นค่า *By 1st Level Paragraphs* :

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // เพิ่ม AutoShape ใหม่พร้อมข้อความ
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // รับลำดับหลักของสไลด์.
    ISequence sequence = sld.Timeline.MainSequence;

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว Fade ให้กับรูปร่าง
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // ทำให้ข้อความของรูปร่างเคลื่อนไหวตามย่อหน้าเชิงระดับที่ 1
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

นอกจากการเพิ่มการเคลื่อนไหวให้กับข้อความแล้ว คุณยังสามารถเพิ่มการเคลื่อนไหวให้กับ [Paragraph](https://reference.aspose.com/slides/th/net/aspose.slides/iparagraph) เดียวได้ ดูที่ [**Animated Text**](/slides/th/net/animated-text/).

{{% /alert %}} 

## **ใช้การเคลื่อนไหวกับ PictureFrame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](http://www.aspose.com/api/net/slides/th/aspose.slides/) 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เพิ่มหรือรับ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe) บนสไลด์. 
5. รับลำดับหลักของเอฟเฟกต์. 
6. เพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe). 
8. บันทึกงานนำเสนอลงดิสก์เป็นไฟล์ PPTX. 

โค้ด C# นี้แสดงวิธีการใช้เอฟเฟกต์ `Fly` กับ picture frame:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
using (Presentation pres = new Presentation())
{
    // โหลดภาพที่จะเพิ่มในคอลเลกชันภาพของงานนำเสนอ
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // เพิ่ม picture frame ไปยังสไลด์
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // รับลำดับหลักของสไลด์.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว Fly จากด้านซ้ายให้กับ picture frame
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **ใช้การเคลื่อนไหวกับ Shape**

1. สร้างอินสแตนซ์ของคลาส [Presentation](http://www.aspose.com/api/net/slides/th/aspose.slides/) 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เพิ่ม `rectangle` [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape). 
4. เพิ่ม `Bevel` [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape) (เมื่อออบเจกต์นี้ถูกคลิก การเคลื่อนไหวจะถูกเล่น). 
5. สร้างลำดับของเอฟเฟกต์บนรูปร่าง bevel. 
6. สร้าง `UserPath` แบบกำหนดเอง. 
7. เพิ่มคำสั่งสำหรับการย้ายไปยัง `UserPath`. 
8. บันทึกงานนำเสนอลงดิสก์เป็นไฟล์ PPTX. 

โค้ด C# นี้แสดงวิธีการใช้เอฟเฟกต์ `PathFootball` (path football) กับรูปทร่าง:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // สร้างเอฟเฟกต์ PathFootball สำหรับรูปร่างที่มีอยู่ตั้งแต่ต้น.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // สร้างบางอย่างคล้าย "ปุ่ม".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // สร้างลำดับของเอฟเฟกต์สำหรับปุ่ม.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // สร้างเส้นทางผู้ใช้แบบกำหนดเอง. วัตถุของเราจะเคลื่อนที่หลังจากคลิกปุ่มเท่านั้น.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // เพิ่มคำสั่งการย้ายเนื่องจากเส้นทางที่สร้างยังว่างเปล่า.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // เขียนไฟล์ PPTX ลงดิสก์
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับ Shape**

ตัวอย่างต่อไปนี้แสดงวิธีการใช้เมธอด `GetEffectsByShape` จากอินเตอร์เฟส [ISequence](https://reference.aspose.com/slides/th/net/aspose.slides.animation/isequence/) เพื่อรับเอฟเฟกต์การเคลื่อนไหวทั้งหมดที่ใช้กับรูปร่าง.

**ตัวอย่าง 1: รับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับรูปร่างบนสไลด์ปกติ**

ก่อนหน้านี้คุณได้เรียนรู้วิธีเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับรูปร่างในงานนำเสนอ PowerPoint ตัวอย่างโค้ดต่อไปนี้แสดงวิธีรับเอฟเฟกต์ที่ใช้กับรูปร่างแรกบนสไลด์ปกติแรกในงานนำเสนอ `AnimExample_out.pptx`.

```c#
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

**ตัวอย่าง 2: รับเอฟเฟกต์การเคลื่อนไหวทั้งหมด รวมถึงที่สืบทอดจาก placeholder**

หากรูปร่างบนสไลด์ปกติมี placeholder ที่อยู่บนสไลด์เลย์เอาต์และ/หรือสไลด์มาสเตอร์ และมีการเพิ่มเอฟเฟกต์การเคลื่อนไหวให้กับ placeholder เหล่านี้ แล้วเอฟเฟกต์ทั้งหมดของรูปร่างจะถูกเล่นระหว่างการแสดงสไลด์ รวมถึงที่สืบทอดจาก placeholder ด้วย

สมมติว่าเรามีไฟล์งานนำเสนอ PowerPoint `sample.pptx` ที่มีสไลด์หนึ่งสไลด์ซึ่งมีเพียงรูปร่าง footer เท่านั้นที่มีข้อความ “Made with Aspose.Slides” และได้ใช้เอฟเฟกต์ **Random Bars** กับรูปร่างนั้น

![Slide shape animation effect](slide-shape-animation.png)

สมมติว่าเรายังได้ใช้เอฟเฟกต์ **Split** กับ placeholder ของ footer บนสไลด์ **layout** ด้วย

![Layout shape animation effect](layout-shape-animation.png)

และสุดท้ายได้ใช้เอฟเฟกต์ **Fly In** กับ placeholder ของ footer บนสไลด์ **master** ด้วย

![Master shape animation effect](master-shape-animation.png)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการใช้เมธอด `GetBasePlaceholder` จากอินเตอร์เฟส [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) เพื่อเข้าถึง placeholder ของรูปร่างและรับเอฟเฟกต์การเคลื่อนไหวที่ใช้กับรูปร่าง footer รวมถึงที่สืบทอดจาก placeholder ที่อยู่บนสไลด์เลย์เอาต์และมาสเตอร์

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // รับเอฟเฟกต์การเคลื่อนไหวของรูปทรงบนสไลด์ปกติ.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // รับเอฟเฟกต์การเคลื่อนไหวของ placeholder บนสไลด์เลย์เอาต์.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // รับเอฟเฟกต์การเคลื่อนไหวของ placeholder บนสไลด์มาสเตอร์.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```
```cs
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

Aspose.Slides สำหรับ .NET ให้คุณเปลี่ยนคุณสมบัติ Timing ของเอฟเฟกต์การเคลื่อนไหว

นี่คือแถบ Animation Timing และเมนูขยายใน Microsoft PowerPoint:

![example1_image](shape-animation.png)

ต่อไปนี้คือการจับคู่ระหว่าง PowerPoint Timing และคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effect/properties/timing):

- เมนูดรอปดาวน์ **Start** ของ PowerPoint ตรงกับคุณสมบัติ [Effect.Timing.TriggerType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/properties/triggertype) 
- เมนู **Duration** ของ PowerPoint ตรงกับคุณสมบัติ [Effect.Timing.Duration](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/properties/duration) ซึ่งระยะเวลาของการเคลื่อนไหว (เป็นวินาที) คือเวลารวมที่การเคลื่อนไหวใช้เพื่อทำครบหนึ่งรอบ 
- เมนู **Delay** ของ PowerPoint ตรงกับคุณสมบัติ [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/properties/triggerdelaytime) 
- เมนูดรอปดาวน์ **Repeat** ของ PowerPoint ตรงกับคุณสมบัติเหล่านี้:
  * คุณสมบัติ [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatcount) ซึ่งอธิบาย *จำนวน* ครั้งที่เอฟเฟกต์ทำซ้ำ;
  * ธง [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatuntilendslide) ที่ระบุว่าเอฟเฟกต์จะทำซ้ำจนถึงตอนจบของสไลด์;
  * ธง [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/repeatuntilnextclick) ที่ระบุว่าเอฟเฟกต์จะทำซ้ำจนกว่าจะคลิกครั้งถัดไป.
- ช่องทำเครื่องหมาย **Rewind when done playing** ของ PowerPoint ตรงกับคุณสมบัติ [Effect.Timing.Rewind](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itiming/rewind/) 

นี่คือวิธีการเปลี่ยนคุณสมบัติ Effect Timing:

1. [ใช้](#apply-animation-to-shape) หรือรับเอฟเฟกต์การเคลื่อนไหว
2. ตั้งค่าคุณสมบัติ [Effect.Timing](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effect/properties/timing) ใหม่ตามที่ต้องการ
3. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว

โค้ด C# นี้แสดงการดำเนินการ:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // รับลำดับหลักของสไลด์.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // รับเอฟเฟ็กต์แรกของลำดับหลัก.
    IEffect effect = sequence[0];

    // เปลี่ยน TriggerType ของเอฟเฟ็กต์ให้เริ่มเมื่อคลิก
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // เปลี่ยน Duration ของเอฟเฟ็กต์
    effect.Timing.Duration = 3f;

    // เปลี่ยน TriggerDelayTime ของเอฟเฟ็กต์
    effect.Timing.TriggerDelayTime = 0.5f;

    // ถ้า Repeat ของเอฟเฟ็กต์เท่ากับ "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // เปลี่ยน Repeat ของเอฟเฟ็กต์เป็น "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // เปลี่ยน Repeat ของเอฟเฟ็กต์เป็น "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // เปิดใช้งาน Rewind ของเอฟเฟ็กต์
        effect.Timing.Rewind = true;
    
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **เสียงของเอฟเฟกต์การเคลื่อนไหว**

Aspose.Slides มีคุณสมบัติเหล่านี้เพื่อให้คุณทำงานกับเสียงในเอฟเฟกต์การเคลื่อนไหว: 
- คุณสมบัติ [IEffect.Sound](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effect/sound/) 
- คุณสมบัติ [IEffect.StopPreviousSound](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effect/stopprevioussound/) 

### **เพิ่มเสียงให้กับเอฟเฟกต์การเคลื่อนไหว**

โค้ด C# นี้แสดงวิธีการเพิ่มเสียงให้กับเอฟเฟกต์การเคลื่อนไหวและหยุดเสียงเมื่อเอฟเฟกต์ถัดไปเริ่มต้น:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // เพิ่มเสียงไปยังคอลเลกชันเสียงของงานนำเสนอ
    IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

    ISlide firstSlide = pres.Slides[0];

    // รับลำดับหลักของสไลด์.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // รับเอฟเฟ็กต์แรกของลำดับหลัก
    IEffect firstEffect = sequence[0];

    // ตรวจสอบว่าเอฟเฟ็กต์ไม่มีเสียง
    if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
    {
        // เพิ่มเสียงให้กับเอฟเฟ็กต์แรก
        firstEffect.Sound = effectSound;
    }

    // รับลำดับโต้ตอบแรกของสไลด์.
    ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

    // ตั้งค่าสถานะ "Stop previous sound" ของเอฟเฟ็กต์
    interactiveSequence[0].StopPreviousSound = true;

    // เขียนไฟล์ PPTX ลงดิสก์
    pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **สกัดเสียงจากเอฟเฟกต์การเคลื่อนไหว**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. รับลำดับหลักของเอฟเฟกต์. 
4. สกัด [Sound](https://reference.aspose.com/slides/th/net/aspose.slides.animation/effect/sound/) ที่ฝังอยู่ในแต่ละเอฟเฟกต์การเคลื่อนไหว. 

โค้ด C# นี้แสดงวิธีการสกัดเสียงที่ฝังอยู่ในเอฟเฟกต์การเคลื่อนไหว:

```c#
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

        // สกัดเสียงเอฟเฟ็กต์เป็นอาร์เรย์ของไบต์
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **หลังการเคลื่อนไหว**

Aspose.Slides สำหรับ .NET ให้คุณเปลี่ยนคุณสมบัติ After animation ของเอฟเฟกต์การเคลื่อนไหว

นี่คือแถบ Animation Effect และเมนูขยายใน Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

เมนูดรอปดาวน์ **After animation** ของ PowerPoint ตรงกับคุณสมบัติเหล่านี้: 

- คุณสมบัติ [IEffect.AfterAnimationType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/afteranimationtype/) ที่อธิบายประเภท After animation :
  * PowerPoint **More Colors** ตรงกับประเภท [AfterAnimationType.Color](https://reference.aspose.com/slides/th/net/aspose.slides.animation/afteranimationtype/) 
  * PowerPoint **Don't Dim** ตรงกับประเภท [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/th/net/aspose.slides.animation/afteranimationtype/) (ประเภท After animation เริ่มต้น) 
  * PowerPoint **Hide After Animation** ตรงกับประเภท [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/th/net/aspose.slides.animation/afteranimationtype/) 
  * PowerPoint **Hide on Next Mouse Click** ตรงกับประเภท [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/th/net/aspose.slides.animation/afteranimationtype/) 
- คุณสมบัติ [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/afteranimationcolor/) ที่กำหนดรูปแบบสี After animation. คุณสมบัตินี้ทำงานร่วมกับประเภท [AfterAnimationType.Color](https://reference.aspose.com/slides/th/net/aspose.slides.animation/afteranimationtype/). หากคุณเปลี่ยนประเภทเป็นค่าอื่น สี After animation จะถูกล้าง

โค้ด C# นี้แสดงวิธีการเปลี่ยนเอฟเฟกต์ After animation:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // รับเอฟเฟ็กต์แรกของลำดับหลัก
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // เปลี่ยนชนิด After animation เป็น Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // ตั้งค่าสี After animation ที่ทำให้มืด
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **ทำให้ข้อความเคลื่อนไหว**

Aspose.Slides มีคุณสมบัติเหล่านี้เพื่อให้คุณทำงานกับบล็อก *Animate text* ของเอฟเฟกต์การเคลื่อนไหว:

- คุณสมบัติ [IEffect.AnimateTextType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/animatetexttype/) ที่อธิบายประเภทการเคลื่อนที่ของข้อความในเอฟเฟกต์. ข้อความในรูปร่างสามารถเคลื่อนไหวได้:
  - ทั้งหมดพร้อมกัน ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/th/net/aspose.slides.animation/animatetexttype/) type)
  - ตามคำ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/th/net/aspose.slides.animation/animatetexttype/) type)
  - ตามอักษร ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/th/net/aspose.slides.animation/animatetexttype/) type)
- คุณสมบัติ [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/delaybetweentextparts/) ตั้งค่าการหน่วงเวลาระหว่างส่วนของข้อความที่เคลื่อนไหว (คำหรืออักษร). ค่าบวกระบุเป็นเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์. ค่าลบระบุเป็นวินาที

นี่คือวิธีการเปลี่ยนคุณสมบัติ Effect Animate text:

1. [ใช้](#apply-animation-to-shape) หรือรับเอฟเฟกต์การเคลื่อนไหว
2. ตั้งค่าคุณสมบัติ [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/itextanimation/buildtype/) ให้เป็นค่า [BuildType.AsOneObject](https://reference.aspose.com/slides/th/net/aspose.slides.animation/buildtype/) เพื่อปิดโหมดการเคลื่อนไหว *By Paragraphs*
3. ตั้งค่าค่าใหม่ให้กับคุณสมบัติ [IEffect.AnimateTextType](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/animatetexttype/) และ [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/th/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 
4. บันทึกไฟล์ PPTX ที่แก้ไขแล้ว

โค้ด C# นี้แสดงการดำเนินการ:

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
	// รับเอฟเฟ็กต์แรกของลำดับหลัก
	IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

	// เปลี่ยนประเภทการเคลื่อนไหวข้อความของเอฟเฟ็กต์เป็น "As One Object"
	firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

	// เปลี่ยนประเภท Animate text ของเอฟเฟ็กต์เป็น "By word"
	firstEffect.AnimateTextType = AnimateTextType.ByWord;

	// ตั้งค่าการหน่วงเวลาระหว่างคำเป็น 20% ของระยะเวลาเอฟเฟ็กต์
	firstEffect.DelayBetweenTextParts = 20f;

	// เขียนไฟล์ PPTX ลงดิสก์
	pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**ฉันจะทำให้แน่ใจว่าการเคลื่อนไหวคงอยู่เมื่อเผยแพร่การนำเสนอบนเว็บได้อย่างไร?**

[Export to HTML5](/slides/th/net/export-to-html5/) และเปิดใช้งาน [options](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/) ที่รับผิดชอบสำหรับการเคลื่อนไหวของ [shape](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/animateshapes/) และ [transition](https://reference.aspose.com/slides/th/net/aspose.slides.export/html5options/animatetransitions/). HTML ธรรมดาไม่เล่นการเคลื่อนไหวของสไลด์ ในขณะที่ HTML5 ทำได้

**การเปลี่ยนลำดับชั้น (z-order) ของรูปร่างมีผลต่อการเคลื่อนไหวอย่างไร?**

การเคลื่อนไหวและลำดับการวาดเป็นเรื่องอิสระ: เอฟเฟกต์กำหนดเวลาและประเภทของการปรากฏ/หายไป ในขณะที่ [z-order](https://reference.aspose.com/slides/th/net/aspose.slides/shape/zorderposition/) กำหนดว่าอะไรอยู่ด้านบนอะไร ผลลัพธ์ที่มองเห็นได้ถูกกำหนดโดยการผสมผสานของทั้งสอง (นี่เป็นพฤติกรรมทั่วไปของ PowerPoint; โมเดลเอฟเฟกต์และรูปร่างของ Aspose.Slides ทำตามตรรกะเดียวกัน)

**มีข้อจำกัดใดบ้างเมื่อแปลงการเคลื่อนไหวเป็นวิดีโอสำหรับเอฟเฟกต์บางอย่างหรือไม่?**

โดยทั่วไป [animations are supported](/slides/th/net/convert-powerpoint-to-video/), แต่ในกรณีหายากหรือเอฟเฟกต์เฉพาะอาจถูกเรนเดอร์แตกต่างออกไป แนะนำให้ทดสอบกับเอฟเฟกต์ที่คุณใช้และกับเวอร์ชันของไลบรารี.