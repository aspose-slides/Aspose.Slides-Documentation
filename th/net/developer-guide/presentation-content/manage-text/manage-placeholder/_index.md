---
title: จัดการ Placeholder การนำเสนอใน .NET
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/net/manage-placeholder/
keywords:
- ตัวแทนตำแหน่ง
- ตัวแทนตำแหน่งข้อความ
- ตัวแทนตำแหน่งภาพ
- ตัวแทนตำแหน่งแผนภูมิ
- ตัวแทนตำแหน่งเนื้อหา
- ข้อความ Prompt
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการตรวจสอบและแก้ไขตัวแทนตำแหน่งข้อความ, ภาพ, แผนภูมิและเนื้อหาและทำความเข้าใจการสืบทอดตัวแทนตำแหน่งด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Placeholder คือรูปทรงที่สงวนตำแหน่งสำหรับประเภทเนื้อหาเฉพาะในเทมเพลตการนำเสนอ ตัวอย่างทั่วไปได้แก่ Placeholder ของหัวเรื่อง, เนื้อหา, รูปภาพ, แผนภูมิ, และ Placeholder เนื้อหาทั่วไป ไม่เหมือนรูปทรงทั่วไป Placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบและการตั้งค่าอื่น ๆ จากสไลด์เลเอาท์หรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านคุณสมบัติ [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) ค่าของคุณสมบัตินี้จะคืนออบเจกต์ [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) หรือ `null` สำหรับรูปทรงปกติ ใช้ [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) เพื่อกำหนดว่าผู้เล่นตำแหน่งนี้ตั้งใจจะบรรจุอะไร

อินเทอร์เฟซรูปทรงยังคงสำคัญหลังจากคุณรู้ประเภทของ placeholder:

- Placeholder ของข้อความ, รูปภาพ, แผนภูมิ หรือเนื้อหาที่ว่างเปล่ามักจะแสดงเป็น [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
- Placeholder รูปภาพที่มีเนื้อหาแล้วสามารถแสดงเป็น [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/).
- Placeholder แผนภูมิที่มีเนื้อหาแล้วสามารถแสดงเป็น [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/).
- Placeholder เนื้อหาอาจบรรจุหลายประเภทของเนื้อหา ตรวจสอบทั้ง [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) และอินเทอร์เฟซรูปทรงในขณะรันไทม์แทนการสันนิษฐานว่า placeholder ทุกตัวเป็น [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) บรรยายบทบาทของ placeholder; ไม่รับประกันประเภทของรูปทรงในขณะรันไทม์ ควรตรวจสอบประเภทเสมอก่อนเข้าถึงสมาชิกที่เกี่ยวกับข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่อ
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder สร้างเป็นลำดับชั้น:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่ใช้ซ้ำได้และในบางกรณี placeholder ระดับมาสเตอร์.
2. สไลด์เลเอาท์กำหนดการจัดวางที่ใช้โดยสไลด์ปกติโดยหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์.
3. สไลด์ปกติมี placeholder ของสไลด์นั้นและสามารถสืบทอดจากเลเอาท์ของมัน.

เรียกใช้ [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) เพื่อย้ายขึ้นหนึ่งระดับในลำดับชั้นนี้ Placeholder ของสไลด์โดยทั่วไปจะคืน Placeholder ของเลเอาท์; Placeholder ของเลเอาท์สามารถคืน Placeholder ของมาสเตอร์ได้ วิธีการนี้จะคืนค่า `null` เมื่อรูปทรงไม่มี base placeholder.

ตัวอย่างต่อไปนี้แสดงรายการ placeholder บนสไลด์แรกและรายงาน base placeholder ของพวกมัน:

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

การแก้ไข placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการแทนที่เฉพาะท้องถิ่นสำหรับสไลด์นั้น การแก้ไขเลเอาท์หรือมาสเตอร์ที่เกี่ยวข้องสามารถส่งผลต่อสไลด์ทั้งหมดที่ยังคงสืบทอดการตั้งคินั้น รูปทรงปกติทั่วไปไม่มี base placeholder และไม่เริ่มสืบทอดเพียงเพราะว่าตำแหน่งเดียวกัน

## **ลบสถานะ Placeholder**

เมื่อปรับแต่งเทมเพลต, ให้ใช้ [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) เพื่อเก็บออบเจกต์ที่มีอยู่ให้เป็นรูปทรงปกติ คุณสมบัติ [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) จะกลายเป็น `null` แต่รูปทรงยังคงอยู่ในคอลเลกชันของสไลด์ ในทางตรงกันข้าม, [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) จะลบรูปทรงออกจากคอลเลกชันนั้น.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // การเรียกเมธอดบนรูปทรงปกติจะไม่มีผล
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

{{% alert color="warning" title="Warning" %}}
การลบสถานะ placeholder ไม่ได้ทำให้การตั้งค่าลักษณะที่สืบทอดโดยอัตโนมัติยังคงอยู่ ตัวอย่างด้านล่างตั้งใจปล่อยให้การตั้งค่าเหล่านั้นไม่เปลี่ยนแปลง ดังนั้นผลลัพธ์อาจดูแตกต่าง รูปทรงที่ตำแหน่งและขนาดสืบทอดมาทั้งหมดอาจมีพิกัดและมิติเป็นศูนย์หลังจากเรียกและกลายเป็นไม่มองเห็น แม้ว่ายังคงอยู่ในคอลเลกชัน
{{% /alert %}}

สำหรับ placeholder ที่ตรงกัน การตรวจสอบทั้งสามกรณีจะแสดงผลเป็น `True` ข้อความคงอยู่ แต่ตำแหน่ง, ขนาด, การหมุน, ฟอนต์, การจัดย่อหน้า, ระยะขอบของ text‑frame, การยืดแนวตั้ง, การเติมและการตั้งค่าเส้นที่สืบทอดอาจเปลี่ยนเมื่อความสัมพันธ์ของ placeholder ถูกลบ ตัวอย่างเช่น การฟอร์แมตหัวเรื่องที่สืบทอดอาจย้อนกลับไปเป็นฟอร์แมตข้อความปกติ ดู [Slide Layout](/slides/th/net/slide-layout/) เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับเลเอาท์

เพื่อรักษาลักษณะที่ต้องการ ให้บันทึกตำแหน่ง, ขนาดและการหมุนที่ได้แก้ไขก่อนเรียกเมธอด และคัดลอกค่าการฟอร์แมตที่มีผลจริงที่จำเป็นไปยังตัวแปรแยกต่างหาก ดึงค่าดังกล่าวผ่าน [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), และ [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/). อย่าพึ่งพาแค่วัตถุ effective‑format เนื่องจากค่าการฟอร์แมตข้อความอาจเปลี่ยนหลังจากความสัมพันธ์ถูกลบ นำค่าที่บันทึกไว้ไปใช้กับรูปทรงปกติโดยชัดเจนหลังจากนั้น รวมถึงตระกูลฟอนต์, ขนาด, สไตล์, สี, การตั้งค่าข้อความย่อย, การตั้งค่า text‑frame, การเติมและเส้นที่ใช้ในเทมเพลตของคุณ

การกำหนดเรขาคณิตของรูปทรงที่สืบทอดอาจต้องกำหนดอย่างชัดเจนผ่าน [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/). สำหรับ placeholder ข้อความสี่เหลี่ยมจัตุรัส หมายถึงการกำหนด [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/); การฟื้นฟูเพียงการเติมและเส้นอาจไม่ทำให้สี่เหลี่ยมที่มองเห็นได้กลับคืนเทมเพลตที่มีเอฟเฟกต์เพิ่มเติมหรือฟอร์แมตที่ซับซ้อนต้องจัดการการตั้งค่าเหล่านั้นด้วยเช่นกัน

## **เปลี่ยนข้อความใน Placeholder**

หัวเรื่อง, centered‑title, subtitle, body, และ placeholder ที่เป็นข้อความมักจะสนับสนุนข้อความ ตรวจสอบว่ามี [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ก่อนใช้คุณสมบัติ [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) ของมัน

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

รูปแบบนี้หลีกเลี่ยงการแคสต์ placeholder ของรูปภาพ, แผนภูมิ, ตาราง หรือสื่อให้เป็น [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) อีกทั้งยังระบุ placeholder ตามวัตถุประสงค์แทนการพึ่งพาดัชนีรูปทรงที่เปราะบาง

## **ตั้งข้อความ Prompt บนเลเอาท์**

Prompt text คือคำแนะนำในช่วงการออกแบบที่แสดงใน placeholder ว่างเปล่า เช่น *Click to add title* ตั้งข้อความ Prompt ที่กำหนดเองบน placeholder ของเลเอาท์แทนการพยายามเข้าถึงผ่านคอลเลกชันรูปทรงของสไลด์ปกติ เข้าถึงเลเอาท์ผ่าน [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) และวนลูปผ่าน [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/)

ตัวอย่างต่อไปนี้เปลี่ยน Prompt ของหัวเรื่องและ subtitle บนเลเอาท์ที่ใช้โดยสไลด์แรก:

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

Prompt text ไม่ได้เป็นเนื้อหาของสไลด์ปกติ มันตั้งใจให้กับ placeholder ว่างเปล่าในโปรแกรมแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริง Prompt จะไม่แสดงอีกต่อไป การเปลี่ยน Prompt ก็ไม่ทำให้ข้อความที่มีอยู่บนสไลด์ที่ใช้เลเอาท์นั้นถูกแทนที่

## **อัปเดต Picture Placeholder**

มีสองกรณีที่ต้องจัดการ:

- หาก picture placeholder มีเนื้อหาแล้วและแสดงเป็น [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), ให้แทนที่ภาพผ่าน [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) และ [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/).
- หากยังเป็น placeholder ว่าง, ให้เพิ่ม picture frame ที่พิกัดของ placeholder ด้วย [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) แล้วลบ placeholder ว่างออก

ตัวอย่างต่อไปนี้รองรับทั้งสองกรณีและบันทึกงานนำเสนอ:

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

การแทนที่ที่สร้างสำหรับ placeholder ว่างเป็น picture frame ภายในท้องถิ่น ไม่ใช่ placeholder ใหม่ เนื่องจาก [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) เป็นแบบอ่าน‑อย่างเดียว มันเก็บตำแหน่งที่สงวนไว้ไว้ แต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder หากการรักษาความสัมพันธ์ของ placeholder มีความสำคัญให้เตรียมและเติม placeholder ใน PowerPoint ก่อน แล้วจึงอัปเดต [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับความโปร่งใสของภาพ, การครอปและเอฟเฟกต์เฉพาะของรูปภาพอื่น ๆ ดูที่ [Manage Picture Frames](/slides/th/net/picture-frame/). การดำเนินการเหล่านั้นเป็นของ picture frame หรือ picture fill ไม่ใช่เมทาดาต้า placeholder

## **ทำงานกับ Chart และ Content Placeholder**

Placeholder ของแผนภูมิที่มีเนื้อหาแล้วสามารถแสดงเป็น [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/). ตัวอย่างนี้ค้นหาแผนภูมินั้นโดยอ้างอิงทั้งประเภท placeholder และอินเทอร์เฟซรันไทม์, เปลี่ยนชื่อแผนภูมิและบันทึกไฟล์:

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

Content placeholder ทั่วไปมักมี [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/). ใน PowerPoint มันทำหน้าที่เป็นตัวเปิดสำหรับหลายประเภทของเนื้อหา รวมถึงแผนภูมิ, ตาราง, แผนผัง, รูปภาพและสื่อ หลังจากที่ถูกเติมแล้ว ให้ตรวจสอบอินเทอร์เฟซรูปทรงจริงเพื่อดูว่ามันบรรจุอะไรไว้เลเอาท์พิเศษบางอย่างอาจเปิดเผย [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), หรือ [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/).

Aspose.Slides ไม่ได้แปลง placeholder ของ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ที่ว่างเป็น [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) เพียงโดยการเปลี่ยน [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/); ประเภทนั้นเป็นแบบอ่าน‑อย่างเดียว เพื่อเติมแผนภูมิหรือพื้นที่เนื้อหาที่ว่างโดยโปรแกรมให้เพิ่มออบเจกต์ที่ต้องการที่พิกัดของ placeholder แล้วลบ placeholder ว่างออก ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับแผนภูมิ:

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

แผนภูมิที่เพิ่มขึ้นเป็นแผนภูมิท้องถิ่นทั่วไป มันครอบคลุมพื้นที่ของ placeholder แต่ไม่สืบทอดจาก placeholder ของเลเอาท์ ใช้บทความการจัดการแผนภูมิที่อุทิศเฉพาะ [chart management articles](/slides/th/net/powerpoint-charts/) เมื่อคุณต้องการแทนที่หมวดหมู่, ชุดข้อมูลหรือข้อมูลเวิร์กบุ๊กของมัน

## **ตัวอย่างเต็ม: อัปเดตข้อความหรือภาพเนื้อหา**

ตัวอย่าง end‑to‑end นี้เปิดเทมเพลต, ค้นหาสไลด์แรกสำหรับ placeholder ของหัวเรื่องหรือรูปภาพ, ตรวจสอบประเภท placeholder และรูปทรง, อัปเดตเนื้อหาที่เหมาะสมและบันทึกผลลัพธ์ ตัวอย่างตั้งใจหลีกเลี่ยงการสันนิษฐานดัชนีรูปทรงหรือการแคสต์ placeholder ทุกตัวเป็นอินเทอร์เฟซเดียวกัน:

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

**อะไรคือ base placeholder?**

Base placeholder คือรูปทรงที่ตรงกันบนเลเอาท์หรือมาสเตอร์ซึ่ง placeholder อื่นสืบทอดมาจาก ใช้ [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) เพื่อดึงมัน รูปทรงท้องถิ่นทั่วไปจะคืน `null` เพราะไม่ได้เป็นส่วนหนึ่งของลำดับชั้น placeholder

**ฉันสามารถเปลี่ยนหัวเรื่องสไลด์ทั้งหมดโดยการแก้ไข layout placeholder ได้หรือไม่?**

คุณสามารถเปลี่ยนการฟอร์แมตที่สืบทอดหรือข้อความ Prompt ผ่านเลเอาท์ได้ แต่เนื้อหาหัวเรื่องที่มีอยู่ถูกเก็บไว้บนสไลด์ปกติ เพื่อแทนที่ข้อความหัวเรื่องจริง ๆ ทั่วทั้งงานนำเสนอ ให้วนลูปผ่านสไลด์และอัปเดตแต่ละ placeholder ของหัวเรื่อง

**ฉันจะจัดการ placeholder ของวันที่, หมายเลขสไลด์, ส่วนหัวและส่วนท้ายอย่างไร?**

ใช้ตัวจัดการส่วนหัวและส่วนท้ายในสโคปของสไลด์, เลเอาท์, มาสเตอร์, โน้ตหรือแฮนด์เอาต์ที่เหมาะสม ดูที่ [Manage Presentation Header and Footer](/slides/th/net/presentation-header-and-footer/) สำหรับตัวอย่างครบถ้วน.