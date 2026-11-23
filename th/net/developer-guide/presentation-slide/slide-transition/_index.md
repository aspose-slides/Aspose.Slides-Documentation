---
title: จัดการการเปลี่ยนสไลด์ในงานนำเสนอด้วย .NET
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
- ชนิดการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้การเปลี่ยนสไลด์ กำหนดการเลื่อนสไลด์อัตโนมัติ และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ควบคุมวิธีการที่สไลด์ปรากฏระหว่างการแสดงสไลด์ ด้วย Aspose.Slides for .NET คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสไลด์สำหรับแต่ละสไลด์ กำหนดการเลื่อนไปโดยคลิกเมาส์หรือด้วยตัวจับเวลา และปรับตัวเลือกที่เฉพาะเจาะจงต่อเอฟเฟกต์ บทความนี้ใช้ตัวอย่าง C# เพื่อใช้การเปลี่ยนสไลด์ ตั้งระยะเวลาการเปลี่ยนสไลด์ที่แม่นยำ จัดการเวลาแสดงสไลด์ และสร้างการเปลี่ยนสไลด์ Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยนสไลด์ ให้โหลดการนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) แล้วเข้าถึงคุณสมบัติ [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) ของสไลด์ ตั้งค่า [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) ให้เป็นค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) จากนั้นบันทึกการนำเสนอ

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

คุณสมบัติ [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) ของ [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) ควบคุมจำนวนเซกเตอร์รัศมีที่เปิดเผยสไลด์ปลายทาง ตั้งค่า [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) ของสไลด์เป็น Wheel จาก [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) ก่อนเข้าถึง [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) ในฐานะ [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/)

ตัวอย่างนี้สร้างคู่สไลด์ที่เหมือนกันสองคู่: สไลด์สีดำตามด้วยสไลด์ที่มีสี่เหลี่ยมสีทอง สไลด์ปลายทางใช้จำนวน spoke 1 และ 8 โดยมี [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) เท่ากันและตั้งค่า [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) อย่างชัดเจนเป็น 8,000 มิลลิวินาที เพื่อให้สังเกตความแตกต่างได้ง่าย

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

เปิดการนำเสนอผลลัพธ์ใน PowerPoint แล้วรันการแสดงสไลด์ เลื่อนจากสไลด์ 1 ไปสไลด์ 2 จากนั้นจากสไลด์ 3 ไปสไลด์ 4 ในการเล่นของ PowerPoint จำนวน spoke 1 ที่ตรวจสอบแล้วจะเปิดสไลด์ด้วยการกวาดตามเข็มนาฬิกาเดียว; จำนวน 8 ที่ตรวจสอบแล้วจะเปิดโดยใช้แปดเซกเตอร์รัศมีพร้อมกัน เนื้อหาและเวลาการเปลี่ยนสไลด์ของสไลด์ปลายทางเหมือนกัน ดังนั้นความแตกต่างจึงเป็นจำนวนเซกเตอร์ที่เปิดเผย

## **Fade Through Black พร้อมการเปลี่ยน Reveal**

ตั้งประเภทการเปลี่ยนของสไลด์ปลายทางเป็น Reveal แล้วใช้ [IRevealTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/) เพื่อตั้งค่า [ThroughBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/throughblack/) ตัวอย่างนี้สร้างสไลด์ต้นทางสีเทาเขียวและสไลด์ปลายทางสีโค้รัล จากนั้นโคลนทั้งสองสไลด์เพื่อให้คุณเปรียบเทียบการเปลี่ยนสองวินาทีที่เปิดหรือปิดการจาง

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var source = presentation.Slides[0];
var destination = presentation.Slides.AddClone(source);
StyleSlide(source, Color.Teal, "Source");
StyleSlide(destination, Color.Coral, "Destination");
presentation.Slides.AddClone(source);
presentation.Slides.AddClone(destination);

foreach (var index in new[] { 1, 3 })
{
    var transition = presentation.Slides[index].SlideShowTransition;
    transition.Type = TransitionType.Reveal;
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 2000;

    var reveal = (IRevealTransition)transition.Value;
    reveal.Direction = TransitionLeftRightDirectionType.Left;
    reveal.ThroughBlack = index == 3;
}

presentation.Save("reveal-transitions.pptx", SaveFormat.Pptx);

void StyleSlide(ISlide slide, Color background, string label)
{
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = background;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
    shape.TextFrame.Text = label;
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 44;
}
```

ในการแสดงสไลด์ของ PowerPoint เลื่อนจากสไลด์ 1 ไปสไลด์ 2 สีเทาเขียวจางโดยตรงเข้าสีโค้รัล จากนั้นเลื่อนจากสไลด์ 3 ไปสไลด์ 4 หน้าจอจะคลายสีไปเกือบสีดำก่อนที่สไลด์โค้รัลจะปรากฏ สไลด์ทั้งสองคงสีพื้นหลังเดิมของตน

แถวด้านล่างแสดงเฟรมจาก PowerPoint ทุกครึ่งวินาที เปรียบเทียบเฟรมกลางของแต่ละแถวเพื่อดูผลของการตั้งค่า

![PowerPoint playback with ThroughBlack disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดเวลาที่สไลด์ค้างบนหน้าจอและว่าการคลิกเมาส์จะเลื่อนไปหรือไม่ คุณสมบัติดังต่อไปนี้ควบคุมพฤติกรรมนี้:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) ให้ผู้ชมเลื่อนไปโดยคลิกเมาส์
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) เปิดการเลื่อนอัตโนมัติ
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) ระบุความล่าช้าก่อนการเลื่อนอัตโนมัติเป็นมิลลิวินาที

เปิดการเลื่อนด้วยคลิกและด้วยตัวจับเวลาเพื่อให้ผู้ชมสามารถกดคลิกหรือรอจนกาตัวจับเวลาจะทำงาน หากต้องการใช้เฉพาะตัวจับเวลา ให้ตั้งค่า [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) เป็น `false` ความล่าช้าควบคุมเวลาที่การแสดงสไลด์เลื่อนไป ไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนสไลด์

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่าง ๆ ให้กับสามสไลด์แรกและเปิดการเลื่อนอัตโนมัติหลัง 3, 5 และ 7 วินาทีตามลำดับ การคลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้ ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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

เพื่อเช็คว่าการเลื่อนตามเวลาเปิดอยู่หรือไม่ ให้อ่านค่า [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) ค่าที่เก็บไว้เพียงอย่างเดียวไม่แสดงว่าตัวจับเวลาใช้งานอยู่

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานแต่ละตัวจับเวลาที่เปิดอยู่และปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีความล่าชุมากกว่าสองวินาที พร้อมเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าใหม่

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

## **ควบคุมระยะเวลาการเปลี่ยนอย่างแม่นยำ**

ใช้ [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) เพื่อระบุความยาวที่แน่นอนของเอฟเฟกต์การเปลี่ยนในหน่วยมิลลิวินาที คุณสมบัติ [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| คุณสมบัติ | วัตถุประสงค์ |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนเองในหน่วยมิลลิวินาที |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | กำหนดความล่าช้าก่อนสไลด์เลื่อนไปอัตโนมัติในหน่วยมิลลิวินาที เปิดใช้งาน [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) เพื่อให้ตัวจับเวลานี้ทำงาน |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | เลือกหมวดความเร็วที่กำหนดไว้ล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) ได้แก่ Slow, Medium หรือ Fast ใช้เมื่อไม่ได้ระบุระยะเวลาอย่างชัดเจน |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน ไม่ได้กำหนดเวลาที่สไลด์คงอยู่บนหน้าจอ กำหนดความล่าช้าการเลื่อนอัตโนมัติต่างหาก เมื่อไม่มีการตั้งค่า Duration อย่างชัดเจน Aspose.Slides จะคำนวณระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนและค่า [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/)

### **กำหนดระยะเวลาเดียวกันให้ทุกสไลด์**

เพื่อให้จังหวะคงที่ ให้ใช้เอฟเฟกต์และระยะเวลาเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) แล้วกำหนดระยะเวลาให้แต่ละการเปลี่ยนเป็น 750 มิลลิวินาที แยกเปิดการเลื่อนอัตโนมัติหลัง 5,000 มิลลิวินาทีและปิดการเลื่อนด้วยคลิกเมาส์ แล้วบันทึกผลเป็น PPTX

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

    // กำหนดการเลื่อนอัตโนมัติอย่างอิสระจากระยะเวลาเอฟเฟ็กต์.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **กำหนดระยะเวลาต่างกันสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่ต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวข้อและใช้การเปลี่ยนยาวสำหรับสไลด์แนะนำส่วน ตัวอย่างนี้ตั้งค่า 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1,200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

เมื่อเตรียม [animated GIF](/slides/th/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/net/export-to-html5/) หรือ [video](/slides/th/net/convert-powerpoint-to-video/) ให้ตั้งระยะเวลาเปลี่ยนที่แม่นยำก่อนส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การจาง 600 มิลลิวินาทีระหว่างฉาก และปรับความล่าช้าการเลื่อนของแต่ละสไลด์แยกต่างหากเพื่อให้มีเวลาแก่การบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีเท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 เปิดการเปลี่ยนแบบเคลื่อนไหวในการตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาที่ฟอร์แมตการส่งออกสนับสนุนและดูตัวอย่างผลลัพธ์เพื่อยืนยันการซิงโครไนส์

### **อ่านระยะเวลาเปลี่ยนที่มีอยู่**

ก่อนแก้ไขการเปลี่ยนให้อ่านค่า [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) เพื่อดูว่ามีค่าที่ระบุไว้หรือไม่ ค่า `-1` หมายถึงไม่มีการกำหนดระยะเวลาอย่างชัดเจน; ค่าที่เป็นจำนวนเต็มบวกหรือศูนย์คือระยะเวลาที่เก็บไว้เป็นมิลลิวินาที ค่าไม่ได้ตั้งนี้ไม่ใช่ระยะเวลาการเล่นที่คำนวณแล้ว: Aspose.Slides ใช้ประเภทการเปลี่ยนและ [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) เพื่อกำหนดระยะเวลา การตั้งประเภทการเปลี่ยนอาจกำหนดค่า Duration ให้โดยอัตโนมัติ ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

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

การเปลี่ยน Morph ทำให้วัตถุเปลี่ยนแปลงระหว่างสไลด์ต่อเนื่อง เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้โคลนสไลด์ ย้ายหรือปรับขนาดวัตถุบนสำเนา แล้วใช้การเปลี่ยน Morph กับสไลด์ที่สอง การทำเช่นนี้จะทำให้วัตถุที่สอดคล้องกันทำการเคลื่อนไหวจากสถานะเดิมไปยังสถานะที่แก้ไข

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ โคลนสไลด์นั้นและเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสำเนา จากนั้นเลือก Morph จาก enumeration [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกไว้ในโปรแกรมดูการนำเสนอที่สนับสนุน Morph เพื่อดูเอฟเฟกต์ระหว่างการแสดงสไลด์

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

enumeration [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และเคลื่อนไหวเนื้อหา:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) พิจารณาทรูรูปร่างแต่ละอันเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) เคลื่อนที่ข้อความโดยจับคู่ตามคำเมื่อเป็นไปได้
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) เคลื่อนที่ข้อความโดยจับคู่ตามอักขระเมื่อเป็นไปได้

ตั้งค่า [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) ของการเปลี่ยนเป็น Morph ก่อนเข้าถึง [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) ค่าแล้วจะให้ interface [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/) ซึ่งคุณสมบัติ [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) เลือกโหมดการจับคู่

ตัวอย่างนี้เปิดการนำเสนอที่สร้างในส่วนก่อนหน้าและกำหนดให้สไลด์ที่สองใช้การเคลื่อนไหว Morph แบบจับคู่ตามคำ

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

*Morph สามารถจับคู่รูปทรงทั้งหมด คำ หรืออักขระเมื่อเป็นไปได้ กล่องเหล่านี้บ่งบอกหน่วยที่จับคู่ ไม่ใช่การเคลื่อนที่ที่เห็น ตัวอย่างเลือก ByWord บนสไลด์ที่สอง*
<!-- visual-explanation:slide-transition:end -->

## **ตั้งค่าเอฟเฟกต์การเปลี่ยน**

บางการเปลี่ยนมีตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าเอฟเฟกต์เริ่มจากหน้าจอสีดำ ตัวเลือกที่ใช้ได้ขึ้นกับ [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) ที่เลือก ให้ตั้งประเภทก่อน แล้วใช้ interface ที่เหมาะสมจาก [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/)

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

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ได้. ควรใช้ [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) เมื่อคุณต้องการระยะเวลาเอฟเฟกต์ที่แม่นยำเป็นมิลลิวินาที ใช้ [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) เมื่อหมวดความเร็วที่กำหนดไว้ล่วงหน้าใน [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) เช่น Slow, Medium หรือ Fast เพียงพอและไม่มีการตั้งค่า Duration อย่างชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนโดยอิสระจากความล่าช้าการเลื่อนอัตโนมัติ

**ฉันสามารถแนบเสียงกับการเปลี่ยนและทำให้วนได้หรือไม่?**

ได้. กำหนดเสียงฝังลงใน [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) ตั้งค่า [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) เป็น StartSound จาก enumeration [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/) แล้วเปิดใช้งาน [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/) เสียงจะวนจนกว่าจะมีเหตุการณ์เสียงถัดไปในการแสดงสไลด์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชัน [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) ของการนำเสนอและตั้งค่า [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) ของการเปลี่ยนของแต่ละสไลด์ให้เป็นค่าเดียวกัน ตั้งค่าการจังหวะและตัวเลือกเอฟเฟกต์ในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันระหว่างสไลด์ทั้งหมด

**ฉันจะตรวจสอบว่าการเปลี่ยนใดตั้งอยู่บนสไลด์ปัจจุบันได้อย่างไร?**

อ่านคุณสมบัติ [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) จาก [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) ของสไลด์ จะได้ค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) ค่า None หมายถึงไม่มีการตั้งค่าเอฟเฟกต์การเปลี่ยน.