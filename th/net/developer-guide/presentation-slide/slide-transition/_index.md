---
title: จัดการการเปลี่ยนสไลด์ในการพรีเซนเทชั่นใน .NET
linktitle: การเปลี่ยนสไลด์
type: docs
weight: 90
url: /th/net/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- ใช้การเปลี่ยนสไลด์
- การเปลี่ยนสไลด์ขั้นสูง
- การเปลี่ยน Morph
- ประเภทการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- พรีเซนเทชั่น
- .NET
- C#
- Aspose.Slides
description: "ใช้การเปลี่ยนสไลด์, กำหนดการเลื่อนสไลด์อัตโนมัติ, และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ควบคุมว่าแต่ละสไลด์จะแสดงอย่างไรระหว่างการแสดงสไลด์โชว์ ด้วย Aspose.Slides for .NET คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสไลด์สำหรับแต่ละสไลด์ ตั้งค่าการเลื่อนหน้าโดยคลิกเมาส์หรือโดยตัวจับเวลา และปรับตัวเลือกที่เฉพาะเจาะจงต่อเอฟเฟกต์ บทความนี้ใช้ตัวอย่าง C# เพื่อใช้การเปลี่ยนสไลด์ ตั้งระยะเวลาการเปลี่ยนสไลด์อย่างแม่นยำ จัดการเวลาแสดงสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยนสไลด์ ให้โหลดพรีเซนเทชั่นด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) แล้วเข้าถึงคุณสมบัติ [SlideShowTransition](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/slideshowtransition/) ของสไลด์ ตั้งค่า [Type](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/type/) ให้เป็นค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/transitiontype/) จากนั้นบันทึกพรีเซนเทชั่น

ตัวอย่างต่อไปนี้ใช้การเปลี่ยนแบบ Circle กับสไลด์แรกและการเปลี่ยนแบบ Comb กับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์อยู่บนหน้าจอและว่าการคลิกเมาส์จะเลื่อนสไลด์โชว์หรือไม่ คุณสมบัติดังต่อไปนี้ควบคุมพฤติกรรมนี้:

- [AdvanceOnClick](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/advanceonclick/) อนุญาตให้ผู้ชมเลื่อนหน้าจอด้วยการคลิกเมาส์
- [AdvanceAfter](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/advanceafter/) เปิดใช้งานการเลื่อนอัตโนมัติ
- [AdvanceAfterTime](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/advanceaftertime/) กำหนดระยะเวลาหน่วงก่อนการเลื่อนอัตโนมัติเป็นมิลลิวินาที

เปิดใช้งานทั้งการคลิกและการเลื่อนตามเวลาเพื่อให้ผู้ชมสามารถดำเนินการต่อด้วยการคลิกหรือรอจนถึงตัวจับเวลา หากต้องการใช้เฉพาะตัวจับเวลา ให้ตั้งค่า [AdvanceOnClick](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/advanceonclick/) เป็น `false` ระยะหน่วงกำหนดว่าจะเลื่อนสไลด์โชว์เมื่อใด; มันไม่ได้กำหนดระยะเวลาแสดงเอฟเฟกต์การเปลี่ยนจริง

ตัวอย่างนี้กำหนดเอฟเฟกต์ที่แตกต่างให้กับสามสไลด์แรกและเปิดการเลื่อนอัตโนมัติหลังจาก 3, 5, และ 7 วินาทีตามลำดับ การคลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้เช่นกัน ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

เพื่อดูว่าการเลื่อนตามเวลาถูกเปิดใช้งานหรือไม่ ให้อ่านค่า [AdvanceAfter](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/advanceafter/) ค่าหน่วงที่จัดเก็บเพียงอย่างเดียวไม่ได้บ่งบอกว่าตัวจับเวลากำลังทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานตัวจับเวลาที่เปิดอยู่แต่ละรายการ และปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีระยะหน่วงมากกว่าสองวินาที แล้วเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าใหม่

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **ควบคุมเวลาการเปลี่ยนสไลด์อย่างแม่นยำ**

ใช้ [Duration](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/duration/) เพื่อระบุความยาวที่แน่นอนของเอฟเฟกต์การเปลี่ยนเป็นมิลลิวินาที คุณสมบัติ [SlideShowTransition](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/slideshowtransition/) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [ISlideShowTransition](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/):

| Property | Purpose |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/duration/) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนเองเป็นมิลลิวินาที |
| [AdvanceAfterTime](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | กำหนดระยะหน่วงเวลาก่อนสไลด์เลื่อนไปโดยอัตโนมัติเป็นมิลลิวินาที เปิดใช้งาน [AdvanceAfter](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/advanceafter/) เพื่อเปิดตัวจับเวลานี้ |
| [Speed](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/speed/) | เลือกประเภทความเร็วที่กำหนดไว้ล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium หรือ Fast ใช้เมื่อไม่ได้ระบุระยะเวลาอย่างแม่นยำ |

[Duration](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/duration/) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน; มันไม่ได้กำหนดว่าสตอกจะคงอยู่บนหน้าจอเป็นเวลานานเท่าใด ตั้งค่าหน่วงเวลาการเลื่อนอัตโนมัติแยกต่างหาก เมื่อไม่มีการตั้งค่าระยะเวลาชัดเจน Aspose.Slides จะคำนวณระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนและค่า [Speed](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/speed/)

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสม่ำเสมอ ให้ใช้เอฟเฟกต์และระยะเวลาที่แน่นอนเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/transitiontype/) และตั้งระยะเวลาการเปลี่ยนเป็น 750 มิลลิวินาที สำหรับแต่ละสไลด์ นอกจากนี้ยังเปิดการเลื่อนอัตโนมัติหลังจาก 5 000 มิลลิวินาทีและปิดการเลื่อนด้วยการคลิกเมาส์ แล้วบันทึกผลเป็น PPTX

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // กำหนดการเลื่อนอัตโนมัติโดยแยกจากระยะเวลาเอฟเฟกต์.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **ตั้งระยะเวลาต่างกันสำหรับสไลด์แต่ละสไลด์**

สไลด์ที่แตกต่างกันสามารถใช้ระยะเวลาเอฟเฟกต์ที่ต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนสั้น ๆ สำหรับสไลด์หัวเรื่องและการเปลี่ยนยาวกว่าสำหรับการแนะนำส่วน ตัวอย่างนี้ตั้งค่า 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1 200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **ประสานการเปลี่ยนกับผลลัพธ์แบบเคลื่อนไหว**

เมื่อเตรียม [animated GIF](/slides/th/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/net/export-to-html5/) หรือ [video](/slides/th/net/convert-powerpoint-to-video/) ให้ตั้งระยะเวลาการเปลี่ยนอย่างแม่นยำก่อนการส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การจางแบบ Fade 600 มิลลิวินาทีระหว่างฉาก และปรับระยะหน่วงการเลื่อนของแต่ละสไลด์แยกกันเพื่อให้มีเวลาสำหรับการบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีเทียบกับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 เปิดใช้งานการเปลี่ยนแบบเคลื่อนไหวในการตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาที่สนับสนุนโดยรูปแบบการส่งออกที่เลือก และดูตัวอย่างผลลัพธ์เพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาการเปลี่ยนที่มีอยู่**

อ่านค่า [Duration](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/duration/) ก่อนแก้ไขการเปลี่ยนเพื่อดูว่ามีค่าที่ระบุชัดเจนหรือไม่ ค่า `-1` หมายความว่าไม่มีการตั้งค่าระยะเวลาชัดเจน; ค่าที่เป็นจำนวนเต็มบวกหรือศูนย์ระบุระยะเวลาที่เก็บไว้เป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งไว้ไม่ใช่ระยะเวลาการเล่นที่คำนวณได้: Aspose.Slides ใช้ประเภทการเปลี่ยนและ [Speed](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/speed/) เพื่อคำนวณระยะเวลานั้น การตั้งค่าประเภทการเปลี่ยนอาจทำให้มีการกำหนดระยะเวลาโดยอัตโนมัติ ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **การเปลี่ยน Morph**

การเปลี่ยน Morph ทำแอนิเมชันการเปลี่ยนแปลงระหว่างวัตถุในสไลด์ต่อเนื่อง เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้คัดลอกสไลด์ ย้ายหรือปรับขนาดวัตถุบนสำเนา แล้วใช้การเปลี่ยน Morph กับสไลด์ที่สอง ทำให้วัตถุที่เกี่ยวข้องสามารถแอนิเมชันจากสถานะเดิมไปยังสถานะที่แก้ไข

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ คัดลอกสไลด์และเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสำเนา จากนั้นเลือก Morph จาก enumeration [TransitionType](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกในตัวชมพรีเซนเทชั่นที่รองรับ Morph เพื่อดูเอฟเฟกต์ระหว่างการแสดงสไลด์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **ประเภทการเปลี่ยน Morph**

enumeration [TransitionMorphType](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/transitionmorphtype/) กำหนดว่าการจับคู่และแอนิเมชันของ Morph จะทำอย่างไร:

- [ByObject](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/transitionmorphtype/) พิจารณาแต่ละรูปเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/transitionmorphtype/) ทำแอนิเมชันข้อความโดยจับคู่คำที่เป็นไปได้
- [ByChar](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/transitionmorphtype/) ทำแอนิเมชันข้อความโดยจับคู่อักขระที่เป็นไปได้

ตั้งค่า [Type](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/type/) ของการเปลี่ยนเป็น Morph ก่อนเข้าถึง [Value](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/value/). ค่าที่ได้จะให้ส่วนต่อประสาน [IMorphTransition](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/imorphtransition/) ซึ่งคุณสมบัติ [MorphType](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/imorphtransition/morphtype/) เลือกโหมดการจับคู่

ตัวอย่างนี้เปิดพรีเซนเทชั่นที่สร้างในส่วนก่อนหน้าและกำหนดให้สไลด์ที่สองใช้การแอนิเมชัน Morph ตามคำ

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **ตั้งค่าเอฟเฟกต์การเปลี่ยน**

บางการเปลี่ยนเปิดเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าจะเริ่มจากหน้าจอสีดำหรือไม่ ตัวเลือกที่มีอยู่ขึ้นกับ [Type](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/type/) ที่เลือก ตั้งค่าประเภทก่อน แล้วใช้ส่วนต่อประสานที่เหมาะสมจาก [Value](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/value/)

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` โดยตั้งค่า [FromBlack](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) ผ่าน [IOptionalBlackTransition](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/ioptionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ใช่. ควรเลือกใช้ [Duration](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/duration/) เมื่อต้องการระยะเวลาเอฟเฟกต์ที่แม่นยำเป็นมิลลิวินาที ใช้ [Speed](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/slideshowtransition/speed/) เมื่อหมวดหมู่ความเร็วที่กำหนดไว้ล่วงหน้าใน [TransitionSpeed](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/transitionspeed/) — Slow, Medium หรือ Fast — เพียงพอและไม่มีการตั้งค่าระยะเวลาชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนโดยไม่กระทบต่อระยะเวลาการเลื่อนอัตโนมัติ

**ฉันสามารถแนบเสียงกับการเปลี่ยนสไลด์และทำให้วนซ้ำได้หรือไม่?**

ได้. กำหนดเสียงที่ฝังไว้ให้กับ [Sound](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/sound/), ตั้งค่า [SoundMode](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/soundmode/) เป็น StartSound จาก enumeration [TransitionSoundMode](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/transitionsoundmode/), และเปิดใช้งาน [SoundLoop](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/soundloop/). เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงต่อไปในสไลด์โชว์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชัน [Slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slides/th/) ของพรีเซนเทชั่นและตั้งค่า [Type](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/type/) ของการเปลี่ยนของแต่ละสไลด์เป็นค่าเดียวกัน ตั้งค่าตัวเลือกเวลาและเอฟเฟกต์อื่น ๆ ในลูปเดียวกันเพื่อให้พฤติกรรมสม่ำเสมอในทุกสไลด์

**ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกตั้งค่าบนสไลด์ขณะนี้ได้อย่างไร?**

อ่านคุณสมบัติ [Type](https://reference.aspose.com/slides/th/net/aspose.slides/islideshowtransition/type/) จาก [SlideShowTransition](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/slideshowtransition/) ของสไลด์ จะได้ค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/net/aspose.slides.slideshow/transitiontype/); None หมายความว่าไม่มีการใช้เอฟเฟกต์การเปลี่ยนใด ๆ