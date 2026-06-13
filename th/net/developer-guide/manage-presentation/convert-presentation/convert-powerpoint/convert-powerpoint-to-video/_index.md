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
description: "เรียนรู้วิธีแปลงการนำเสนอ PowerPoint เป็นวิดีโอใน .NET ค้นหาตัวอย่างโค้ด C# และเทคนิคการทำอัตโนมัติเพื่อทำให้กระบวนการทำงานของคุณเป็นระบบ"
---
## **บทนำ**

โดยการแปลงการนำเสนอ PowerPoint หรือ OpenDocument ของคุณเป็นวิดีโอ คุณจะได้:

**เพิ่มการเข้าถึง:** ทุกอุปกรณ์ไม่ว่าบนแพลตฟอร์มใดก็มีตัวเล่นวิดีโอเป็นค่าเริ่มต้น ทำให้ผู้ใช้เปิดหรือเล่นวิดีโอได้ง่ายกว่าการใช้แอปพลิเคชันนำเสนอแบบดั้งเดิม  

**ขยายการเข้าถึง:** วิดีโอช่วยให้คุณเข้าถึงผู้ชมจำนวนมากขึ้นและนำเสนอข้อมูลในรูปแบบที่น่าสนใจมากขึ้น การสำรวจและสถิติแสดงว่าผู้คนชอบดูและรับชมวิดีโอมากกว่ารูปแบบอื่น ทำให้ข้อความของคุณมีผลกระทบมากขึ้น  

{{% alert color="primary" %}} 
ลองดู [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/th/video) ของเรา เพราะมันให้การใช้งานแบบสดและมีประสิทธิภาพของกระบวนการที่อธิบายไว้ที่นี่  
{{% /alert %}} 

ใน Aspose.Slides for .NET เราได้เพิ่มการสนับสนุนการแปลงการนำเสนอเป็นวิดีโอ

* ใช้ Aspose.Slides for .NET เพื่อสร้างเฟรมจากสไลด์การนำเสนอที่อัตราเฟรม (FPS) ที่กำหนด  
* จากนั้นใช้เครื่องมือของบุคคลที่สามเช่น ffmpeg เพื่อนำเฟรมเหล่านั้นมาประกอบเป็นวิดีโอ  

## **แปลงการนำเสนอ PowerPoint เป็นวิดีโอ**

1. ใช้คำสั่ง `dotnet add package` เพื่อติดตั้ง Aspose.Slides และไลบรารี FFMpegCore ในโปรเจกต์ของคุณ:  
   * เรียกใช้ `dotnet add package Aspose.Slides.NET --version 22.11.0`  
   * เรียกใช้ `dotnet add package FFMpegCore --version 4.8.0`  
2. ดาวน์โหลด ffmpeg จาก [ที่นี่](https://ffmpeg.org/download.html)  
3. FFMpegCore ต้องการให้คุณระบุพาธไปยัง ffmpeg ที่ดาวน์โหลด (เช่น แตกไฟล์ไว้ที่ "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. เรียกใช้โค้ดการแปลง PowerPoint เป็นวิดีโอ  

โค้ด C# นี้แสดงวิธีแปลงการนำเสนอ (ซึ่งมีรูปร่างและเอฟเฟ็กต์การเคลื่อนไหวสองรายการ) ให้เป็นวิดีโอ:  

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // จะใช้ไบนารีของ FFmpeg ที่เราดึงมาไว้ที่ C:\tools\ffmpeg ก่อนหน้านี้.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างหัวยิ้มแล้วทำการเคลื่อนไหว.
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

    // กำหนดโฟลเดอร์ไบนารีของ ffmpeg. ดูหน้านี้: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // แปลงเฟรมเป็นวิดีโอ webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **เอฟเฟ็กต์วิดีโอ**

เมื่อแปลงการนำเสนอ PowerPoint เป็นวิดีโอด้วย Aspose.Slides for .NET คุณสามารถใช้เอฟเฟ็กต์วิดีโอต่าง ๆ เพื่อเพิ่มคุณภาพภาพของผลลัพธ์ เอฟเฟ็กต์เหล่านี้ช่วยให้คุณควบคุมการแสดงสไลด์ในวิดีโอสุดท้ายโดยการเพิ่มการเปลี่ยนภาพที่ราบรื่น การเคลื่อนไหว และองค์ประกอบภาพอื่น ๆ ส่วนนี้อธิบายตัวเลือกเอฟเฟ็กต์วิดีโอที่มีและวิธีการนำไปใช้  

{{% alert color="primary" %}} 
ดู:  
- [การเพิ่มประสิทธิภาพการนำเสนอ PowerPoint ด้วยการเคลื่อนไหวใน C#](https://docs.aspose.com/slides/th/net/powerpoint-animation/)  
- [การเคลื่อนไหวรูปทรง](https://docs.aspose.com/slides/th/net/shape-animation/)  
- [การใช้เอฟเฟ็กต์รูปทรงใน PowerPoint ด้วย C#](https://docs.aspose.com/slides/th/net/shape-effect/)  
{{% /alert %}} 

การเคลื่อนไหวและการเปลี่ยนภาพทำให้การสไลด์โชว์น่าสนใจและน่าดึงดูด — เช่นเดียวกับวิดีโอ เรามาเพิ่มสไลด์และการเปลี่ยนภาพอีกสไลด์หนึ่งในโค้ดของการนำเสนอก่อนหน้า:  

```c#
// เพิ่มรูปร่างหัวยิ้มและทำการเคลื่อนไหว.
// ...

// เพิ่มสไลด์ใหม่และการเปลี่ยนภาพแบบเคลื่อนไหว.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides ยังรองรับการเคลื่อนไหวข้อความ ในตัวอย่างนี้ เราจะทำให้ย่อหน้าบนวัตถุแสดงตามลำดับโดยมีการหน่วงเวลา 1 วินาทีระหว่างแต่ละย่อหน้า:  

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มข้อความและการเคลื่อนไหว.
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

    // กำหนดโฟลเดอร์ไบนารีของ ffmpeg. ดูหน้านี้: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // แปลงเฟรมเป็นวิดีโอ webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **คลาสสำหรับการแปลงวิดีโอ**

เพื่อเปิดใช้งานงานแปลง PowerPoint ไปเป็นวิดีโอ Aspose.Slides for .NET มีคลาส [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/net/aspose.slides.export/presentationanimationsgenerator/) และ [PresentationPlayer](https://reference.aspose.com/slides/th/net/aspose.slides.export/presentationplayer/)  

`PresentationAnimationsGenerator` ให้คุณตั้งขนาดเฟรมสำหรับวิดีโอ (ซึ่งจะสร้างต่อไป) และค่า FPS (เฟรมต่อวินาที) ผ่านตัวสร้าง หากคุณส่งอินสแตนซ์ของการนำเสนอ `Presentation.SlideSize` จะถูกใช้และมันจะสร้างการเคลื่อนไหวที่ [PresentationPlayer](https://reference.aspose.com/slides/th/net/aspose.slides.export/presentationplayer/) ใช้  

เมื่อการเคลื่อนไหวถูกสร้าง จะมีเหตุการณ์ `NewAnimation` ถูกเรียกสำหรับแต่ละการเคลื่อนไหวต่อเนื่อง ซึ่งมีพารามิเตอร์ [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipresentationanimationplayer/) คลาสนี้เป็นผู้เล่นสำหรับการเคลื่อนไหวนั้น ๆ  

เพื่อทำงานกับ [IPresentationAnimationPlayer](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipresentationanimationplayer/) คุณใช้คุณสมบัติ [Duration](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipresentationanimationplayer/duration/) (ให้ระยะเวลาทั้งหมดของการเคลื่อนไหว) และเมธอด [SetTimePosition](https://reference.aspose.com/slides/th/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) แต่ละตำแหน่งการเคลื่อนไหวถูกกำหนดภายในช่วง *0 ถึง duration* และเมธอด `GetFrame` จะคืนค่า Bitmap ที่แสดงสถานะการเคลื่อนไหวในเวลานั้น  

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // เพิ่มรูปร่างหัวยิ้มและทำการเคลื่อนไหว.
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

            animationPlayer.SetTimePosition(0);          // สถานะการเคลื่อนไหวเริ่มต้น.
            Bitmap bitmap = animationPlayer.GetFrame();  // บิตแมพของสถานะการเคลื่อนไหวเริ่มต้น.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // สถานะสุดท้ายของการเคลื่อนไหว.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // เฟรมสุดท้ายของการเคลื่อนไหว.
            lastBitmap.Save("last.png");
        };
    }
}
```

เพื่อให้การเคลื่อนไหวทั้งหมดในการนำเสนอเล่นพร้อมกัน ใช้คลาส [PresentationPlayer](https://reference.aspose.com/slides/th/net/aspose.slides.export/presentationplayer/) คลาสนี้รับอินสแตนซ์ของ [PresentationAnimationsGenerator](https://reference.aspose.com/slides/th/net/aspose.slides.export/presentationanimationsgenerator/) และค่า FPS สำหรับเอฟเฟ็กต์ในตัวสร้าง แล้วเรียกเหตุการณ์ `FrameTick` สำหรับการเคลื่อนไหวทั้งหมดเพื่อเล่นมัน:  

```c#
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

จากนั้นเฟรมที่สร้างขึ้นสามารถประกอบเป็นวิดีโอได้ ดูส่วน [แปลงการนำเสนอ PowerPoint เป็นวิดีโอ](/slides/th/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video)  

## **การเคลื่อนไหวและเอฟเฟ็กต์ที่รองรับ**

เมื่อแปลงการนำเสนอ PowerPoint เป็นวิดีโอด้วย Aspose.Slides for .NET สิ่งสำคัญคือการเข้าใจว่าการเคลื่อนไหวและเอฟเฟ็กต์ใดบ้างที่ได้รับการสนับสนุนในผลลัพธ์ Aspose.Slides รองรับเอฟเฟ็กต์การเข้ามา, การออก, และการเน้นหลากหลายประเภท เช่น fade, fly in, zoom, และ spin อย่างไรก็ตาม การเคลื่อนไหวขั้นสูงหรือที่กำหนดเองบางอย่างอาจไม่ได้รับการเก็บรักษาอย่างเต็มที่หรืออาจแสดงผลแตกต่างในวิดีโอสุดท้าย ส่วนนี้สรุปการเคลื่อนไหวและเอฟเฟ็กต์ที่ได้รับการสนับสนุน  

**การเข้าสู่**:

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
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

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
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

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
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

**เส้นทางการเคลื่อนไหว**:

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **เอฟเฟ็กต์การเปลี่ยนสไลด์ที่รองรับ**

เอฟเฟ็กต์การเปลี่ยนสไลด์มีความสำคัญในการสร้างการเปลี่ยนภาพที่ราบรื่นและสวยงามระหว่างสไลด์ในวิดีโอ Aspose.Slides for .NET รองรับเอฟเฟ็กต์การเปลี่ยนที่ใช้บ่อยหลายประเภทเพื่อช่วยรักษาโฟลว์และสไตล์ของการนำเสนอเดิมของคุณ ส่วนนี้เน้นเอฟเฟ็กต์การเปลี่ยนที่ได้รับการสนับสนุนในกระบวนการแปลง  

**ละเอียดอ่อน**:

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
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

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
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

| ประเภทการเคลื่อนไหว | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **คำถามที่พบบ่อย**

**สามารถแปลงการนำเสนอที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?**  

ใช่ Aspose.Slides for .NET รองรับการทำงานกับการนำเสนอที่มีการป้องกันด้วยรหัสผ่าน เมื่อต้องประมวลผลไฟล์เหล่านี้คุณจำเป็นต้องระบุรหัสผ่านที่ถูกต้องเพื่อให้ไลบรารีเข้าถึงเนื้อหาของการนำเสนอได้  

**Aspose.Slides for .NET รองรับการใช้งานในโซลูชันคลาวด์หรือไม่?**  

ใช่ Aspose.Slides for .NET สามารถบูรณาการเข้ากับแอปพลิเคชันและบริการคลาวด์ได้ ไลบรารีออกแบบให้ทำงานในสภาพแวดล้อมเซิร์ฟเวอร์ โดยให้ประสิทธิภาพสูงและสามารถขยายได้สำหรับการประมวลผลไฟล์เป็นชุด  

**มีข้อจำกัดขนาดไฟล์สำหรับการนำเสนอระหว่างการแปลงหรือไม่?**  

Aspose.Slides for .NET สามารถจัดการกับการนำเสนอที่มีขนาดเกือบทั้งหมด อย่างไรก็ตามเมื่อต้องทำงานกับไฟล์ขนาดใหญ่มากอาจต้องใช้ทรัพยากรระบบเพิ่มเติม และบางครั้งอาจแนะนำให้ปรับแต่งการนำเสนอเพื่อเพิ่มประสิทธิภาพการทำงาน