---
title: แปลงการนำเสนอ PowerPoint เป็นวิดีโอใน .NET
linktitle: PowerPoint เป็นวิดีโอ
type: docs
weight: 130
url: /th/net/convert-powerpoint-to-video/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็นวิดีโอ
- การนำเสนอเป็นวิดีโอ
- PPT เป็นวิดีโอ
- PPTX เป็นวิดีโอ
- PowerPoint เป็น MP4
- การนำเสนอเป็น MP4
- PPT เป็น MP4
- PPTX เป็น MP4
- บันทึก PPT เป็น MP4
- บันทึก PPTX เป็น MP4
- ส่งออก PPT เป็น MP4
- ส่งออก PPTX เป็น MP4
- การแปลงวิดีโอ
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการแปลงการนำเสนอ PowerPoint เป็นวิดีโอใน .NET. ค้นหาโค้ดตัวอย่าง C# และเทคนิคการทำอัตโนมัติเพื่อทำให้กระบวนการทำงานของคุณเป็นระเบียบและมีประสิทธิภาพ."
---
## **บทนำ**

โดยการแปลงการนำเสนอ PowerPoint หรือ OpenDocument ของคุณเป็นวิดีโอ คุณจะได้:

**การเข้าถึงที่เพิ่มขึ้น:** อุปกรณ์ทั้งหมด ไม่ว่าจะเป็นแพลตฟอร์มใด ก็มีโปรแกรมเล่นวิดีโอเป็นค่าเริ่มต้น ทำให้ผู้ใช้สามารถเปิดหรือเล่นวิดีโอได้ง่ายกว่าการใช้แอปพลิเคชันนำเสนอแบบดั้งเดิม.

**การเข้าถึงที่กว้างขวางกว่า:** วิดีโอช่วยให้คุณเข้าถึงผู้ชมจำนวนมากขึ้นและนำเสนอข้อมูลในรูปแบบที่ดึงดูดมากกว่า การสำรวจและสถิติแสดงให้เห็นว่าผู้คนชอบดูและบริโภคเนื้อหาวิดีโอมากกว่ารูปแบบอื่น ทำให้ข้อความของคุณมีผลกระทบมากขึ้น.

{{% alert color="info" %}} 
ตรวจสอบ [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/th/video) เพราะมันให้การดำเนินการแบบเรียลไทม์และมีประสิทธิภาพของกระบวนการที่อธิบายไว้ที่นี่.
{{% /alert %}} 

ใน Aspose.Slides for .NET เราได้เพิ่มการสนับสนุนการแปลงการนำเสนอเป็นวิดีโอ.

* ใช้ Aspose.Slides for .NET เพื่อสร้างเฟรมจากสไลด์การนำเสนอที่อัตราเฟรมที่กำหนด (FPS)
* จากนั้น ใช้ยูทิลิตี้ของบุคคลที่สาม เช่น ffmpeg เพื่อรวบรวมเฟรมเหล่านี้เป็นวิดีโอ.

## **แปลงการนำเสนอ PowerPoint เป็นวิดีโอ**

1. ใช้คำสั่ง `dotnet add package` เพื่อเพิ่ม Aspose.Slides และไลบรารี FFMpegCore ไปยังโครงการของคุณ:
   * รัน `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * รัน `dotnet add package FFMpegCore --version 4.8.0`
2. ดาวน์โหลด ffmpeg จาก [ที่นี่](https://ffmpeg.org/download.html).
3. FFMpegCore ต้องการให้คุณระบุเส้นทางไปยัง ffmpeg ที่ดาวน์โหลด (เช่น แยกออกไปที่ "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. เรียกใช้โค้ดการแปลง PowerPoint ไปเป็นวิดีโอ.

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // จะใช้ไบนารี FFmpeg ที่เราดึงออกไปยัง C:\tools\ffmpeg ก่อนหน้านี้.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างรอยยิ้มแล้วทำแอนิเมชันให้มัน.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // กำหนดโฟลเดอร์ไบนารี ffmpeg ดูหน้านี้: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // แปลงเฟรมเป็นวิดีโอ webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **เอฟเฟกต์วิดีโอ**

เมื่อแปลงการนำเสนอ PowerPoint เป็นวิดีโอโดยใช้ Aspose.Slides for .NET คุณสามารถนำเอาเอฟเฟกต์วิดีโอต่างๆ มาประยุกต์ใช้เพื่อปรับปรุงคุณภาพภาพของผลลัพธ์ได้ เอฟเฟกต์เหล่านี้ช่วยให้คุณควบคุมการปรากฏของสไลด์ในวิดีโอขั้นสุดท้ายโดยการเพิ่มการเปลี่ยนผ่านที่ราบรื่น, แอนิเมชัน, และองค์ประกอบภาพอื่นๆ ส่วนนี้จะอธิบายตัวเลือกของเอฟเฟกต์วิดีโอที่มีและแสดงวิธีการใช้งาน

{{% alert color="info" %}} 
ดู:
- [Enhancing PowerPoint Presentations with Animations in C#](https://docs.aspose.com/slides/th/net/powerpoint-animation/)
- [Shape Animation](https://docs.aspose.com/slides/th/net/shape-animation/)
- [Apply Shape Effects in PowerPoint Using C#](https://docs.aspose.com/slides/th/net/shape-effect/)
{{% /alert %}} 

แอนิเมชันและการเปลี่ยนผ่านทำให้การแสดงสไลด์น่าสนใจและดึงดูดมากขึ้น — และทำเช่นเดียวกันกับวิดีโอ เรามาเพิ่มสไลด์และการเปลี่ยนผ่านอีกหนึ่งลงในโค้ดของการนำเสนอก่อนหน้า:
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // เพิ่มรูปร่างรอยยิ้มและทำแอนิเมชันให้มัน (ดูโค้ดด้านบน).

    // เพิ่มสไลด์ใหม่และการเปลี่ยนผ่านแบบแอนิเมชัน.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides ยังสนับสนุนแอนิเมชันข้อความด้วย ตัวอย่างนี้ เราแอนิเมชันย่อหน้าบนวัตถุให้ปรากฏต่อกันโดยมีการหน่วงเวลา 1 วินาทีระหว่างแต่ละย่อหน้า:
```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มข้อความและแอนิเมชัน.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // กำหนดโฟลเดอร์ไบนารี ffmpeg ดูหน้านี้: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // แปลงเฟรมเป็นวิดีโอ webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **คลาสการแปลงวิดีโอ**

เพื่อให้ทำงานแปลง PowerPoint เป็นวิดีโอได้ Aspose.Slides for .NET มีคลาส [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/net/aspose.slides.export/presentationanimationsgenerator/) และ [PresentationPlayer](https://reference.aspose.com/slides/th/net/aspose.slides.export/presentationplayer/)  

`PresentationAnimationsGenerator` ให้คุณกำหนดขนาดเฟรมสำหรับวิดีโอ (ที่จะสร้างต่อไป) และค่า FPS (เฟรมต่อวินาที) ผ่านคอนสตรัคเตอร์ของมัน ถ้าคุณส่งอินสแตนซ์ของการนำเสนอ `Presentation.SlideSize` จะถูกใช้และมันจะสร้างแอนิเมชันที่ [PresentationPlayer](https://reference.aspose.com/slides/th/net/aspose.slides.export/presentationplayer/) ใช้

เมื่อแอนิเมชันถูกสร้าง จะเกิดเหตุการณ์ `NewAnimation` สำหรับแต่ละแอนิเมชันต่อเนื่อง ซึ่งมีพารามิเตอร์ [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipresentationanimationplayer/) คลาสนี้เป็นผู้เล่นสำหรับแอนิเมชันแต่ละรายการ

ในการทำงานกับ [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipresentationanimationplayer/) คุณใช้คุณสมบัติ [Duration](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipresentationanimationplayer/duration/) (ให้ระยะเวลาทั้งหมดของแอนิเมชัน) และเมธอด [SetTimePosition](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) แต่ละตำแหน่งของแอนิเมชันกำหนดในช่วง *0 ถึง duration* และเมธอด `GetFrame` จะคืนค่า Bitmap ที่แทนสภาพแอนิเมชันในช่วงเวลานั้น

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างรอยยิ้มและทำแอนิเมชันให้มัน.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);        // สถานะเริ่มต้นของแอนิเมชัน.
            IImage image = animationPlayer.GetFrame(); // ภาพสถานะเริ่มต้นของแอนิเมชัน.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // สถานะสุดท้ายของแอนิเมชัน.
            IImage lastImage = animationPlayer.GetFrame();             // เฟรมสุดท้ายของแอนิเมชัน.
            lastImage.Save("last.png");
        };
    }
}
```

เพื่อให้แอนิเมชันทั้งหมดในการนำเสนอเล่นพร้อมกัน ใช้คลาส [PresentationPlayer](https://reference.aspose.com/slides/th/net/aspose.slides.export/presentationplayer/) คลาสนี้รับอินสแตนซ์ของ [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/net/aspose.slides.export/presentationanimationsgenerator/) และค่า FPS สำหรับเอฟเฟกต์ในคอนสตรัคเตอร์ แล้วเรียกเหตุการณ์ `FrameTick` สำหรับแอนิเมชันทั้งหมดเพื่อเล่นพวกมัน:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```

จากนั้นเฟรมที่สร้างสามารถประกอบเป็นวิดีโอได้ ดูส่วน [Convert a PowerPoint Presentation to Video](/slides/th/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video)

## **แอนิเมชันและเอฟเฟกต์ที่สนับสนุน**

เมื่อแปลงการนำเสนอ PowerPoint เป็นวิดีโอโดยใช้ Aspose.Slides for .NET สิ่งสำคัญคือต้องเข้าใจว่าแอนิเมชันและเอฟเฟกต์ใดบ้างที่ได้รับการสนับสนุนในผลลัพธ์ Aspose.Slides รองรับเอฟเฟกต์การเข้า, การออก, และการเน้นทั่วไปหลายประเภท เช่น fade, fly in, zoom, และ spin อย่างไรก็ตาม แอนิเมชันขั้นสูงหรือแบบกำหนดเองบางอย่างอาจไม่ถูกเก็บรักษาอย่างสมบูรณ์หรืออาจปรากฏแตกต่างในวิดีโอขั้นสุดท้าย ส่วนนี้สรุปแอนิเมชันและเอฟเฟกต์ที่สนับสนุน

**การเข้าสู่**:

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**การเน้น**:

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**การออก**:

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**เส้นทางการเคลื่อนที่**:

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **เอฟเฟกต์การเปลี่ยนสไลด์ที่สนับสนุน**

เอฟเฟกต์การเปลี่ยนสไลด์มีบทบาทสำคัญในการสร้างการเปลี่ยนแปลงที่ราบรื่นและสวยงามระหว่างสไลด์ในวิดีโอ Aspose.Slides for .NET รองรับเอฟเฟกต์การเปลี่ยนสไลด์หลายประเภทที่ใช้บ่อยเพื่อช่วยรักษาโฟลว์และสไตล์ของการนำเสนอเดิมของคุณ ส่วนนี้เน้นเอฟเฟกท์การเปลี่ยนสไลด์ที่ได้รับการสนับสนุนระหว่างกระบวนการแปลง

**เรียบง่าย**:

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**น่าตื่นเต้น**:

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**เนื้อหาแบบไดนามิก**:

| ประเภทแอนิเมชัน | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **คำถามที่พบบ่อย**

### สามารถแปลงการนำเสนอที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?

ใช่, Aspose.Slides for .NET อนุญาตให้ทำงานกับการนำเสนอที่มีการป้องกันด้วยรหัสผ่าน เมื่อประมวลผลไฟล์ดังกล่าวคุณต้องระบุรหัสผ่านที่ถูกต้องเพื่อให้ไลบรารีเข้าถึงเนื้อหาของการนำเสนอได้

### Aspose.Slides for .NET รองรับการใช้งานในโซลูชันคลาวด์หรือไม่?

ใช่, Aspose.Slides for .NET สามารถผสานรวมเข้าในแอปพลิเคชันและบริการคลาวด์ได้ ไลบรารีออกแบบมาให้ทำงานในสภาพแวดล้อมเซิร์ฟเวอร์ เพื่อให้ได้ประสิทธิภาพสูงและสเกลได้สำหรับการประมวลผลไฟล์แบบเป็นกลุ่ม

### มีข้อจำกัดขนาดของการนำเสนอระหว่างการแปลงหรือไม่?

Aspose.Slides for .NET สามารถจัดการการนำเสนอที่มีขนาดใกล้เคียงจะไม่มีข้อจำกัดที่สำคัญ อย่างไรก็ตามเมื่อทำงานกับไฟล์ขนาดใหญ่มากอาจต้องใช้ทรัพยากรระบบเพิ่มเติม และบางครั้งแนะนำให้ทำการปรับขนาดหรือเพิ่มประสิทธิภาพการนำเสนอเพื่อให้การประมวลผลรวดเร็วขึ้น.