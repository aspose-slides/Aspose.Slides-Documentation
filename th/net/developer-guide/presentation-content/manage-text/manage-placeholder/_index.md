---
title: จัดการ Placeholder การนำเสนอใน .NET
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/net/manage-placeholder/
keywords:
- ตัวแสดงตำแหน่ง
- placeholder ข้อความ
- placeholder รูปภาพ
- placeholder แผนภูมิ
- placeholder เนื้อหา
- ข้อความเชิญ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไข placeholder ประเภทข้อความ, รูปภาพ, แผนภูมิ และเนื้อหา พร้อมทำความเข้าใจการสืบทอดของ placeholder ด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Placeholder คือรูปทรงที่สงวนตำแหน่งสำหรับประเภทเนื้อหาเฉพาะในเทมเพลตการนำเสนอ ตัวอย่างทั่วไปได้แก่ placeholder สำหรับหัวเรื่อง, เนื้อหา, รูปภาพ, แผนภูมิ, และ placeholder เนื้อหาทั่วไปอื่น ๆ แตกต่างจากรูปทรงทั่วไป placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบ, และการตั้งค่าอื่น ๆ จากสไลด์เลย์เอาต์หรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านคุณสมบัติ [IShape.Placeholder](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/placeholder/) ซึ่งจะคืนค่าอ็อบเจ็กต์ [IPlaceholder](https://reference.aspose.com/slides/th/net/aspose.slides/iplaceholder/) หรือ `null` สำหรับรูปทรงปกติ ใช้ [IPlaceholder.Type](https://reference.aspose.com/slides/th/net/aspose.slides/iplaceholder/type/) เพื่อกำหนดว่าตัว placeholder มีวัตถุประสงค์เพื่อบรรจุอะไร

อินเทอร์เฟซของรูปทรงยังคงสำคัญหลังจากคุณทราบประเภทของ placeholder:

- Placeholder ที่ว่างเปล่าสำหรับข้อความ, รูปภาพ, แผนภูมิ หรือเนื้อหาอื่น ๆ มักจะแทนด้วย [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)  
- Placeholder รูปภาพที่มีข้อมูลแล้วอาจแทนด้วย [IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/)  
- Placeholder แผนภูมิที่มีข้อมูลแล้วอาจแทนด้วย [IChart](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/)  
- Placeholder เนื้อหาอาจบรรจุหลายประเภท ตรวจสอบทั้ง [IPlaceholder.Type](https://reference.aspose.com/slides/th/net/aspose.slides/iplaceholder/type/) และอินเทอร์เฟซรูปแบบระหว่างการทำงานแทนการสันนิษฐานว่า placeholder ทุกตัวเป็น [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/)

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/th/net/aspose.slides/iplaceholder/type/) บรรยายบทบาทของ placeholder; มันไม่ได้รับประกันประเภทของรูปทรงในเวลารันไทม์ ควรตรวจสอบประเภทก่อนเข้าถึงสมาชิกของข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่ออื่น ๆ เสมอ
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder มีลำดับชั้นดังนี้:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่ใช้ซ้ำได้และในบางกรณีอาจมี placeholder ระดับมาสเตอร์
2. สไลด์เลย์เอาต์กำหนดการจัดวางที่ใช้โดยสไลด์ปกติหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์ได้
3. สไลด์ปกติประกอบด้วย placeholder ของสไลด์นั้นและสามารถสืบทอดจากเลย์เอาต์ของมัน

เรียกใช้ [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/getbaseplaceholder/) เพื่อย้ายขึ้นหนึ่งระดับในลำดับชั้นนี้ สไลด์ placeholder ปกติจะคืนค่า placeholder ของเลย์เอาต์; placeholder ของเลย์เอาต์อาจคืนค่า placeholder ของมาสเตอร์ วิธีนี้จะคืนค่า `null` เมื่อรูปทรงไม่มี base placeholder

ตัวอย่างต่อไปนี้แสดงรายการ placeholder บนสไลด์แรกและรายงาน base placeholder ของแต่ละรายการ:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

การแก้ไข placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการทับซ้อนในระดับท้องถิ่นสำหรับสไลด์นั้น การแก้ไขเลย์เออต์หรือมาสเตอร์ที่เกี่ยวข้องสามารถส่งผลต่อสไลด์ทั้งหมดที่ยังคงสืบทอดการตั้งคินั้น รูปทรงปกติที่เป็นรูปแบบท้องถิ่นไม่มี base placeholder และจะไม่เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน

## **เปลี่ยนข้อความใน Placeholder**

Placeholder สำหรับหัวเรื่อง, หัวเรื่องกึ่งกลาง, ชื่อรอง, เนื้อหา, และข้อความทั่วไปมักสนับสนุนข้อความ ตรวจสอบว่ามันเป็น [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ก่อนที่จะใช้คุณสมบัติ [TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/textframe/)

ตัวอย่างนี้อัปเดต placeholder ของหัวเรื่องแรกบนสไลด์แรกและบันทึกผลลัพธ์:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

รูปแบบนี้หลีกเลี่ยงการแคสต์ placeholder ของรูปภาพ, แผนภูมิ, ตาราง หรือสื่อให้เป็น [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) อีกทั้งยังระบุ placeholder ตามจุดประสงค์แทนการพึ่งพาดัชนีรูปทรงที่เปราะบาง

## **ตั้งข้อความแจ้งเตือนบนเลย์เอาต์**

ข้อความแจ้งเตือน (prompt text) คือคำแนะนำที่แสดงใน placeholder ที่ว่างเปล่า เช่น *คลิกเพื่อเพิ่มหัวเรื่อง* ควรตั้งข้อความแจ้งเตือนแบบกำหนดเองบน placeholder ของเลย์เอาต์แทนการพยายามเข้าถึงผ่านคอลเลกชันรูปทรงของสไลด์ปกติ เข้าถึงเลย์เอาต์ผ่าน [ISlide.LayoutSlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/layoutslide/) แล้ววนลูปผ่าน [ILayoutSlide.Shapes](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/shapes/)

ตัวอย่างต่อไปนี้เปลี่ยนข้อความแจ้งเตือนของหัวเรื่องและชื่อรองบนเลย์เอาต์ที่ใช้โดยสไลด์แรก:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

ข้อความแจ้งเตือนไม่ใช่เนื้อหาของสไลด์ปกติ มันออกแบบมาสำหรับ placeholder ที่ว่างเปล่าในแอปพลิเคชันการแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริงแล้วข้อความแจ้งเตือนจะหายไป การเปลี่ยนข้อความแจ้งเตือนยังไม่ทำให้ข้อความเดิมบนสไลด์ที่ใช้เลย์เออต์นั้นถูกแทนที่

## **อัปเดต Placeholder รูปภาพ**

มีสองกรณีให้จัดการ:

- หาก placeholder รูปภาพถูกเติมแล้วและแสดงเป็น [IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/) ให้แทนที่ภาพผ่าน [IPictureFillFormat.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/picture/) และ [ISlidesPicture.Image](https://reference.aspose.com/slides/th/net/aspose.slides/islidespicture/image/)
- หากยังเป็น placeholder ว่างเปล่า ให้เพิ่ม picture frame ที่พิกัดของ placeholder ด้วย [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addpictureframe/) แล้วลบ placeholder ที่ว่างออก

ตัวอย่างต่อไปนี้รองรับทั้งสองกรณีและบันทึกการนำเสนอ:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

การแทนที่ที่สร้างสำหรับ placeholder ที่ว่างเปล่าเป็น picture frame ท้องถิ่น ไม่ได้เป็น placeholder ใหม่ เนื่องจาก [IShape.Placeholder](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/placeholder/) เป็นแบบอ่านอย่างเดียว มันรักษาตำแหน่งที่สงวนไว้แต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder หากต้องการรักษาความสัมพันธ์กับ placeholder อย่างสำคัญ ให้เตรียมและเติม placeholder ใน PowerPoint ก่อน แล้วจึงอัปเดต [IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับการปรับความโปร่งใสของภาพ, การครอป, และเอฟเฟ็กต์อื่น ๆ ของรูปภาพ ดูบทความ [Manage Picture Frames](/slides/th/net/picture-frame/) การดำเนินการเหล่านี้เป็นของ picture frame หรือ picture fill ไม่ใช่ของเมทาดาต้า placeholder

## **ทำงานกับ Placeholder ของแผนภูมิและเนื้อหา**

Placeholder ของแผนภูมิที่ถูกเติมแล้วสามารถแสดงเป็น [IChart](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/) ตัวอย่างนี้ค้นหาแผนภูมิที่ตรงตามประเภท placeholder และอินเทอร์เฟซระหว่างการทำงาน, เปลี่ยนหัวเรื่อง, แล้วบันทึกไฟล์:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Placeholder เนื้อหาทั่วไปมักมี [PlaceholderType.Object](https://reference.aspose.com/slides/th/net/aspose.slides/placeholdertype/) ใน PowerPoint จะทำหน้าที่เป็นตัวเริ่มสำหรับหลายประเภทเนื้อหา เช่น แผนภูมิ, ตาราง, ไดอะแกรม, รูปภาพ, และสื่อ หลังจากถูกเติมแล้วให้ตรวจสอบอินเทอร์เฟซรูปทรงจริงเพื่อทราบว่ามีอะไรบ้าง เลย์เอาต์เฉพาะยังอาจเผย [PlaceholderType.Chart](https://reference.aspose.com/slides/th/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/th/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/th/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/th/net/aspose.slides/placeholdertype/), หรือ [PlaceholderType.Diagram](https://reference.aspose.com/slides/th/net/aspose.slides/placeholdertype/)

Aspose.Slides ไม่ได้แปลง placeholder ของ [IAutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/iautoshape/) ที่ว่างเปล่าให้เป็น [IChart](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/) เพียงแค่เปลี่ยน [IPlaceholder.Type](https://reference.aspose.com/slides/th/net/aspose.slides/iplaceholder/type/) ; ประเภทเป็นแบบอ่านอย่างเดียว เพื่อเติมแผนภูมิหรือพื้นที่เนื้อหาที่ว่างเปล่าโดยโปรแกรมmatically ให้เพิ่มอ็อบเจ็กต์ที่พิกัดของ placeholder แล้วลบ placeholder ที่ว่างออก ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับแผนภูมิ:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

แผนภูมิที่เพิ่มเข้ามาเป็นแผนภูมิท้องถิ่นทั่วไป มันใช้พื้นที่ของ placeholder แต่ไม่สืบทอดจาก placeholder ของเลย์เอาต์ ใช้บทความการจัดการแผนภูมิที่เฉพาะเจาะจง [/slides/th/net/powerpoint-charts/] เมื่อคุณต้องการแทนที่ประเภท, ชุดข้อมูล, หรือข้อมูลเวิร์กบุ๊คของแผนภูมิ

## **ตัวอย่างสมบูรณ์: อัปเดตข้อความหรือเนื้อหารูปภาพ**

ตัวอย่างต่อไปนี้เป็นการทำงานแบบครบวงจร เปิดเทมเพลต, ค้นหาสไลด์แรกสำหรับ placeholder ของหัวเรื่องหรือรูปภาพ, ตรวจสอบประเภทของ placeholder และรูปทรง, อัปเดตเนื้อหาที่เหมาะสม, และบันทึกผลลัพธ์ ตัวอย่างนี้หลีกเลี่ยงการสันนิษฐานว่าดัชนีรูปทรงหรือการแคสต์ทุก placeholder เป็นอินเทอร์เฟซเดียวกัน:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**Placeholder ฐานคืออะไร?**

Placeholder ฐานคือรูปทรงที่สอดคล้องบนเลย์เอ็ตหรือมาสเตอร์ซึ่ง placeholder อื่นสืบทอดมาจากนั้น ใช้ [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/getbaseplaceholder/) เพื่อดึงค่า รูปทรงท้องถิ่นทั่วไปจะคืนค่า `null` เนื่องจากไม่ได้เป็นส่วนหนึ่งของลำดับชั้น placeholder

**ฉันสามารถเปลี่ยนหัวเรื่องทั้งหมดของสไลด์โดยแก้ไข placeholder ของเลย์เออต์ได้หรือไม่?**

คุณสามารถเปลี่ยนการจัดรูปแบบหรือข้อความแจ้งเตือนที่สืบทอดผ่านเลย์เอ็ตได้ แต่เนื้อหาหัวเรื่องที่มีอยู่จริงถูกจัดเก็บบนสไลด์ปกติ หากต้องการแทนที่ข้อความหัวเรื่องจริงทั่วทั้งงานนำเสนอ ต้องวนลูปผ่านสไลด์และอัปเดตแต่ละ placeholder ของหัวเรื่อง

**ฉันจะจัดการ placeholder ของวันที่, เลขสไลด์, ส่วนหัว, และส่วนท้ายอย่างไร?**

ใช้ตัวจัดการส่วนหัวและส่วนท้ายในระดับสไลด์, เลย์เอ็ต, มาสเตอร์, โน้ต, หรือสไลด์แจกจ่าย ตามที่ระบุในบทความ [Manage Presentation Header and Footer](/slides/th/net/presentation-header-and-footer/) สำหรับตัวอย่างครบถ้วน