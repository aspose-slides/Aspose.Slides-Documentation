---
title: จัดการการเปลี่ยนสไลด์ในการนำเสนอใน .NET
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
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้การเปลี่ยนสไลด์ กำหนดค่าการก้าวหน้าสไลด์อัตโนมัติ และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

การเปลี่ยนภาพสไลด์ควบคุมวิธีการที่สไลด์ปรากฏระหว่างการแสดงสไลด์โดยใช้ Aspose.Slides for .NET คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ กำหนดการก้าวหน้าด้วยคลิกเมาส์หรือด้วยตัวจับเวลา และปรับตัวเลือกที่เฉพาะเจาะจงสำหรับเอฟเฟกต์ บทความนี้ใช้ตัวอย่าง C# เพื่อใช้การเปลี่ยน ตั้งค่าเวลาเปลี่ยนที่แน่นอน จัดการเวลาแสดงสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีการบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยน โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) และเข้าถึงคุณสมบัติ [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) ของสไลด์ ตั้งค่า [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) ให้เป็นค่าหนึ่งจากการนับ [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) จากนั้นบันทึกงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Circle กับสไลด์แรกและการเปลี่ยน Comb กับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

## **การเปลี่ยน Wheel**

คุณสมบัติ [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) ของ [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) ควบคุมจำนวนส่วนรัศมีที่เปิดเผยสไลด์ปลายทาง ตั้งค่า [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) ของสไลด์เป็น Wheel จาก [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) ก่อนเข้าถึง [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) ในฐานะ [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/)

ตัวอย่างนี้สร้างคู่สไลด์ที่เหมือนกันสองคู่: สไลด์สีดำตามด้วยสไลด์ที่มีสี่เหลี่ยมสีทอง สไลด์ปลายทางใช้จำนวนสป๊อก 1 และ 8 มีค่า [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) เท่ากันและ [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) ชัดเจนที่ 8,000 มิลลิวินาที เพื่อให้สังเกตความแตกต่างได้ง่าย

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slideWidth = presentation.SlideSize.Size.Width;
var slideHeight = presentation.SlideSize.Size.Height;

var blackSlide = presentation.Slides[0];
blackSlide.Shapes.Clear();
blackSlide.Background.Type = BackgroundType.OwnBackground;
blackSlide.Background.FillFormat.FillType = FillType.Solid;
blackSlide.Background.FillFormat.SolidFillColor.Color = Color.Black;

var destinationSlide = presentation.Slides.AddClone(blackSlide);
var rectangle = destinationSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
rectangle.FillFormat.FillType = FillType.Solid;
rectangle.FillFormat.SolidFillColor.Color = Color.Gold;
rectangle.TextFrame.Text = "Wheel transition";

presentation.Slides.AddClone(blackSlide);
presentation.Slides.AddClone(destinationSlide);

var spokeCounts = new uint[] { 1, 8 };
for (var i = 0; i < spokeCounts.Length; i++)
{
    var transition = presentation.Slides[i * 2 + 1].SlideShowTransition;
    transition.Type = TransitionType.Wheel;
    var wheelTransition = (IWheelTransition)transition.Value;
    wheelTransition.Spokes = spokeCounts[i];
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 8000;
}

presentation.Save("wheel-transitions.pptx", SaveFormat.Pptx);
```

เปิดงานนำเสนอผลลัพธ์ใน PowerPoint และเรียกการแสดงสไลด์ ก้าวจากสไลด์ 1 ไปยังสไลด์ 2 แล้วจากสไลด์ 3 ไปยังสไลด์ 4 ในการเล่นของ PowerPoint จำนวนสป็อกที่ตรวจสอบได้ 1 เปิดเผยสไลด์ด้วยการกวาดตามเข็มนาฬิกาหนึ่งครั้ง; จำนวน 8 เปิดเผยด้วยส่วนรัศมีแปดส่วนพร้อมกัน เนื้อหาและเวลาการเปลี่ยนของสไลด์ปลายทางเหมือนกัน ดังนั้นความแตกต่างจึงอยู่ที่จำนวนส่วนที่เปิดเผย

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์คงอยู่บนหน้าจอและว่าการคลิกเมาส์จะก้าวหน้าการแสดงสไลด์หรือไม่ คุณสมบัติดังต่อไปนี้ควบคุมพฤติกรรมนี้:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) อนุญาตให้ผู้ชมก้าวหน้าด้วยการคลิกเมาส์
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) เปิดใช้งานการก้าวหน้าอัตโนมัติ
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) ระบุเวลาหน่วงก่อนการก้าวหน้าอัตโนมัติเป็นมิลลิวินาที

เปิดใช้งานทั้งการคลิกและการก้าวหน้าแบบตั้งเวลาเพื่อให้ผู้ชมก้าวหน้าด้วยคลิกหรือรอว่าตัวจับเวลา จะใช้ค่า `false` กับ [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) หากต้องการใช้เพียงตัวจับเวลา เวลาหน่วงควบคุมเวลาที่การแสดงสไลด์ก้าวหน้า ไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนภาพ

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่าง ๆ ให้กับสามสไลด์แรกและเปิดการก้าวหน้าอัตโนมัติหลังจาก 3, 5, และ 7 วินาทีตามลำดับ คลิกเมาส์ก็สามารถก้าวหน้าได้เช่นกัน ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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

เพื่อตรวจสอบว่ามีการเปิดการก้าวหน้าแบบตั้งเวลาหรือไม่ อ่านค่า [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) การหน่วงเวลาที่เก็บไว้เพียงอย่างเดียวไม่บ่งบอกว่าตัวจับเวลากำลังทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานตัวจับเวลาที่เปิดอยู่แต่ละตัว และปิดการก้าวหน้าอัตโนมัติสำหรับสไลด์ที่มีเวลาหน่วงมากกว่าสองวินาที จะเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าใหม่

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

## **ควบคุมเวลาการเปลี่ยนอย่างแม่นยำ**

ใช้ [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) เพื่อกำหนดความยาวที่แน่นอนของเอฟเฟกต์การเปลี่ยนเป็นมิลลิวินาที คุณสมบัติ [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| Property | Purpose |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนเองเป็นมิลลิวินาที |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | กำหนดเวลาหน่วงก่อนสไลด์ก้าวหน้าอัตโนมัติเป็นมิลลิวินาที เปิดใช้งาน [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) เพื่อเปิดตัวจับเวลานี้ |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | เลือกประเภทความเร็วที่กำหนดไว้ล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) : Slow, Medium, หรือ Fast ใช้เมื่อไม่ได้ระบุระยะเวลาที่แน่นอน |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน ไม่ได้กำหนดเวลาที่สไลด์คงอยู่บนหน้าจอ กำหนดเวลาหน่วงการก้าวหน้าอัตโนมัติแยกต่างหาก เมื่อไม่มีการตั้งค่า Duration ชัดเจน Aspose.Slides จะคำนวณระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนและค่า [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/)

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะคงที่ ให้ใช้เอฟเฟกต์และระยะเวลาที่แน่นอนเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) และกำหนดระยะเวลา 750 มิลลิวินาทีให้แต่ละการเปลี่ยน แยกเปิดการก้าวหน้าอัตโนมัติหลัง 5,000 มิลลิวินาทีและปิดการก้าวหน้าโดยคลิกเมาส์ แล้วบันทึกผลเป็น PPTX

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

    // กำหนดการก้าวหน้าตามอัตโนมัติแยกจากระยะเวลาเอฟเฟกต์.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **ตั้งระยะเวลาต่างกันสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่แตกต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวเรื่องและการเปลี่ยนยาวสำหรับการแนะนำส่วน ตัวอย่างนี้ตั้งค่า 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1,200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

### **ประสานการเปลี่ยนกับผลลัพธ์ที่เคลื่อนไหว**

เมื่อเตรียม [animated GIF](/slides/th/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/net/export-to-html5/), หรือ [video](/slides/th/net/convert-powerpoint-to-video/), ตั้งระยะเวลาเปลี่ยนที่แน่นอนไปก่อนการส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การเฟด 600 มิลลิวินาทีระหว่างฉาก และปรับเวลาหน่วงการก้าวหน้าของแต่ละสไลด์แยกต่างหากเพื่อให้มีเวลาสำหรับการบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีเท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 เปิดใช้งานการเปลี่ยนแบบเคลื่อนไหวในการตั้งค่าการส่งออก ตรวจสอบว่ารูปแบบการส่งออกที่เลือกสนับสนุนเอฟเฟกต์และตัวเลือกเวลาใดบ้าง และดูตัวอย่างผลลัพธ์เพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาเปลี่ยนที่มีอยู่**

อ่านค่า [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) ก่อนแก้ไขการเปลี่ยนเพื่อดูว่ามีการเก็บค่าที่ชัดเจนหรือไม่ ค่า `-1` หมายถึงไม่มีการตั้งค่า Duration ชัดเจน; ค่าที่ไม่เป็นลบระบุระยะเวลาที่เก็บไว้เป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งนี้ไม่ใช่ระยะเวลาการเล่นที่คำนวณ: Aspose.Slides ใช้ประเภทการเปลี่ยนและ [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) เพื่อกำหนดระยะเวลานั้น การตั้งค่าประเภทการเปลี่ยนอาจทำให้ค่า Duration เริ่มต้นได้ ดังนั้นตรวจสอบการตั้งค่าเดิมก่อน

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

การเปลี่ยน Morph ทำให้การเปลี่ยนแปลงระหว่างวัตถุบนสไลด์ต่อเนื่องกันเป็นภาพเคลื่อนไหว เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้คัดลอกสไลด์ ย้ายหรือปรับขนาดวัตถุบนสำเนา แล้วใช้การเปลี่ยน Morph กับสไลด์ที่สอง วิธีนี้จะทำให้วัตถุที่ตรงกันทำการเคลื่อนไหวระหว่างสถานะเดิมและสถานะที่แก้ไข

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ คัดลอกสไลด์และเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสำเนา จากนั้นเลือก Morph จากการนับ [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกไว้ในโปรแกรมดูงานนำเสนอที่รองรับ Morph เพื่อดูเอฟเฟกต์ระหว่างการแสดงสไลด์

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

การนับ [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) กำหนดวิธีที่ Morph จับคู่และทำภาพเคลื่อนไหวของเนื้อหา:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) ถือแต่ละรูปร่างเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) ทำภาพเคลื่อนไหวข้อความโดยจับคู่วลี (word) หากเป็นไปได้
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) ทำภาพเคลื่อนไหวข้อความโดยจับคู่ตัวอักษร (character) หากเป็นไปได้

ตั้ง [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) ของการเปลี่ยนเป็น Morph ก่อนเข้าถึง [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) ค่าที่ได้ให้อินเทอร์เฟซ [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/) ซึ่งคุณสมบัติ [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) เลือกโหมดการจับคู่

ตัวอย่างนี้เปิดงานนำเสนอที่สร้างในส่วนก่อนหน้าและกำหนดให้สไลด์ที่สองใช้การเคลื่อนไหว Morph ตามคำ

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

<!-- visual-explanation:slide-transition:start -->
[![Morph matching units shown as a whole shape, individual words, and individual characters.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph สามารถจับคู่รูปร่างทั้งหมด คำ หรืออักษรตามที่เป็นไปได้ กล่องเหล่านี้บ่งบอกหน่วยการจับคู่แทนการเคลื่อนที่ที่สังเกตได้ ตัวอย่างเลือก ByWord บนสไลด์ที่สอง*
<!-- visual-explanation:slide-transition:end -->

## **ตั้งค่าเอฟเฟกต์การเปลี่ยน**

บางการเปลี่ยนเปิดเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าเอฟเฟกต์เริ่มจากหน้าจอนาอดสี ดำ ตัวเลือกที่ใช้ได้ขึ้นอยู่กับ [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) ที่เลือก ตั้งค่าชนิดก่อน แล้วใช้อินเทอร์เฟซที่เหมาะสมจาก [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/)

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` ตั้งค่า [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) ผ่าน [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

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

## **FAQ**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ใช่. ให้เลือกใช้ [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) เมื่อคุณต้องการระยะเวลาเอฟเฟกต์ที่แน่นอนเป็นมิลลิวินาที ใช้ [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) เมื่อหมวด [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) ที่กำหนดไว้ล่วงหน้า — Slow, Medium หรือ Fast เพียงพอและไม่มีการกำหนด Duration ชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนโดยไม่กระทบต่อเวลาหน่วงการก้าวหน้าอัตโนมัติ

**ฉันสามารถแนบเสียงกับการเปลี่ยนและทำให้มันวนซ้ำได้หรือไม่?**

ใช่. กำหนดเสียงฝังใน [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/), ตั้งค่า [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) เป็น StartSound จากการนับ [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/) และเปิดใช้งาน [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/) เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงถัดไปในการแสดงสไลด์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชัน [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) ของงานนำเสนอและตั้งค่า [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) ของการเปลี่ยนแต่ละสไลด์ให้เท่ากัน ตั้งค่าตัวเลือกเวลาและเอฟเฟกต์ในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันทั่วทั้งสไลด์

**ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกตั้งไว้ในสไลด์ปัจจุบันได้อย่างไร?**

อ่านคุณสมบัติ [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) จาก [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) ของสไลด์ มันจะคืนค่าจากการนับ [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) ; None หมายถึงไม่มีการใช้เอฟเฟกต์การเปลี่ยนใด ๆ