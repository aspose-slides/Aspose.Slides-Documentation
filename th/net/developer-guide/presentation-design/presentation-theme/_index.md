---
title: จัดการธีมการนำเสนอใน .NET
linktitle: ธีมการนำเสนอ
type: docs
weight: 10
url: /th/net/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมการนำเสนอ
- ธีมสไลด์
- ตั้งค่าธีม
- เปลี่ยนธีม
- จัดการธีม
- ธีมภายนอก
- THMX
- สีธีม
- พาเล็ตเพิ่มเติม
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟ็กต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอหลักใน Aspose.Slides สำหรับ .NET เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ให้มีการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **คำนำ**

ธีมการนำเสนอกำหนดชุดของสี, แบบอักษร, สไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟ็กต์ที่สอดคล้องกัน วัตถุที่รับรู้ธีมจะอ้างอิงคำนิยามที่ใช้ร่วมกันเหล่านี้แทนการเก็บคุณสมบัติวิสัยทุกอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมสามารถอัปเดตหลายวัตถุพร้อมกันได้

ใน Aspose.Slides ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่านคุณสมบัติ [Presentation.MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/mastertheme/) . การนำเสนออาจมีการเขียนทับธีมในระดับที่ต่ำกว่าได้ มาสเตอร์สามารถเขียนทับธีมการนำเสนอผ่าน [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/masterthememanager/overridetheme/) , เลย์เอาต์สามารถเขียนทับธีมที่สืบต่อมาผ่าน [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) , และสไลด์แต่ละสไลด์ก็ทำเช่นเดียวกัน ตามปฏิบัติ ธีมที่มีผลสำหรับสไลด์หนึ่งจะถูกกำหนดผ่านโซ่การสืบทอดนี้: ธีมการนำเสนอ → การเขียนทับโดยมาสเตอร์ → การเขียนทับโดยเลย์เอาต์ → การเขียนทับโดยสไลด์

![ส่วนประกอบของธีม: สี, แบบอักษร, สไตล์พื้นหลัง, และเอฟเฟ็กต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงการทำงานของธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟ็กต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้รับการแก้ไข

## **ตรวจสอบธีม**

วัตถุ [MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/) จะเปิดเผย [ColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/fontscheme/), และ [FormatScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/formatscheme/) ของธีม การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์โดยเฉพาะเมื่อนำเสนอมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟ็กต์ที่จัดเก็บในธีม:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

หากไฟล์ใช้มาสเตอร์หลายตัว อย่าเชื่อว่าสไลด์แต่ละสไลด์มีธีมที่มีผลเดียวกัน ตรวจสอบมาสเตอร์ที่สัมพันธ์กับสไลด์ และใช้ขั้นตอนการทำงานของธีมที่มีผลที่อธิบายต่อไปนี้เมื่ออาจมีการเขียนทับโดยเลย์เอาต์หรือสไลด์

## **เปลี่ยนสีของธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีตรรกะแบบลอจิกจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/schemecolor/) ได้ เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [IColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/icolorscheme/) ของธีม วัตถุที่ยังอ้างอิงสีธีมนั้นจะได้รับการแก้ไขด้วยค่าที่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัปเดตสีธีม

ตัวอย่างต่อไปนี้สร้างรูปร่างที่ใช้ `Accent4`, เปลี่ยนสีของธีม `Accent4` เป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีเติมที่มีผล:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

เพราะสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสคีมด้วยสีโดยตรงบนรูปร่าง การเปลี่ยนแปลง `Accent4` ในภายหลังจะไม่ส่งผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเล็ตเพิ่มเติม**

PowerPoint สร้างสีที่อ่อนกว่าและเข้มกว่าจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน [ColorTransformOperation](https://reference.aspose.com/slides/th/net/aspose.slides/colortransformoperation/)

![สีธีมหลักและสีอ่อน‑เข้มที่สร้างจากพาเล็ตเพิ่มเติม](additional-palette-colors.png)

**1** – สีธีมหลัก

**2** – สีอ่อน‑เข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอ้างอิง `Accent4`, ใช้การแปลงความสว่างกับห้ารูป และบันทึกผลลัพธ์:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

รูปแบบเหล่านี้ยังคงอิงตามสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงแล้วจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมปค่า `SchemeColor` ไปยังสล็อต `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2` ขณะที่ [IColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/icolorscheme/) เปิดเผยสล็อตของธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2` การแมปคงที่ดังนี้:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกสำหรับสล็อตธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง

## **เปลี่ยนแบบอักษรของธีม**

สคีมแบบอักษรของธีมประกอบด้วยชุดแบบอักษรหลักสำหรับหัวเรื่องและชุดแบบอักษรรองสำหรับข้อความหลัก คุณสมบัติ [FontScheme.Major](https://reference.aspose.com/slides/th/net/aspose.slides.theme/fontscheme/major/) และ [FontScheme.Minor](https://reference.aspose.com/slides/th/net/aspose.slides.theme/fontscheme/minor/) จะเปิดเผยชุดเหล่านั้น

ตัวระบุแบบอักษรธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในรูปแบบข้อความได้:

* `+mn‑lt` – แบบอักษรเนื้อหา Latin (Minor Latin Font)
* `+mj‑lt` – แบบอักษรหัวเรื่อง Latin (Major Latin Font)
* `+mn‑ea` – แบบอักษรเนื้อหา East Asian (Minor East Asian Font)
* `+mj‑ea` – แบบอักษรหัวเรื่อง East Asian (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งบรรทัดที่ใช้แบบอักษร Latin หลัก และบรรทัดเนื้อหาหนึ่งบรรทัดที่ใช้แบบอักษร Latin รอง จากนั้นเปลี่ยนแบบอักษรของธีมและบันทึกผลลัพธ์:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

หัวเรื่องจะใช้แบบอักษรหลักและข้อความหลักจะใช้แบบอักษรรอง ข้อความที่มีการระบุชื่อแบบอักษรโดยตรงแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อสคีมแบบอักษรของธีมเปลี่ยน

คอลเลกชันแบบอักษรหลักและรองยังสามารถมีการแมปแบบอักษรสำหรับระบบการเขียนแยกต่างหาก เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana เพื่อดู, เพิ่ม, แทนที่ หรือเอาการแมปเหล่านี้ออก โปรดดู [Script‑Specific Theme Fonts](/slides/th/net/script-specific-font-mappings/)

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรของการนำเสนอ โปรดดู [แบบอักษร PowerPoint](/slides/th/net/powerpoint-fonts/)
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

ขั้นตอนการทำงานด้านล่างแก้ปัญหาที่เกี่ยวข้องกับธีมต่าง ๆ

### **ใช้ธีมภายนอกกับสไลด์ที่ขึ้นกับมาสเตอร์**

ใช้ [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์ทุกสไลด์ที่ขึ้นกับมาสเตอร์เฉพาะ เลือกมาสเตอร์จากคอลเลกชัน [Presentation.Masters](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/masters/) ซึ่งทำงานเป็น [IMasterSlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/) แล้วส่งพาธไฟล์ธีมไปยังเมธอด

เมธอดทำงานดังต่อไปนี้:

1. สร้างมาสเตอร์สไลด์ใหม่บนพื้นมาสเตอร์ที่เลือก
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่ก่อนหน้านี้ขึ้นกับมาสเตอร์ที่เลือก
1. คืนค่า [IMasterSlide](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/) ที่สร้างใหม่

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่ขึ้นกับมาสเตอร์แรก, บันทึกการนำเสนอ, และเปิดผลลัพธ์ใหม่:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxexception/) หรือคลาสย่อยที่เกี่ยวกับรูปแบบอื่น ๆ ตรวจสอบพาธที่ผู้ใช้ป้อน, จัดการความล้มเหลวของการเข้าถึงระบบไฟล์, และบันทึกการนำเสนอเฉพาะหลังจากที่ธีมถูกใช้เรียบร้อย

เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือกเท่านั้นที่จะถูกกำหนดใหม่ สไลด์ที่สัมพันธ์กับมาสเตอร์อื่นจะคงมาสเตอร์และธีมเดิมของตนไว้ สี, แบบอักษร, การเติม, เส้น, พื้นหลัง, และเอฟเฟ็กต์ที่รับรู้ธีมจะได้รับการแก้ไขตามธีมภายนอก สี, แบบอักษร, การเติม, และการจัดรูปแบบโดยตรงอาจคงเดิม การเขียนทับระดับเลย์เอาต์และระดับสไลด์ก็อาจมีอำนาจเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่

ธีมอาจอ้างอิงแบบอักษรที่ไม่มีในสภาพแวดล้อมการรันไทม์ เพื่อให้การเรนเดอร์และการส่งออกสอดคล้องกัน ให้ติดตั้งแบบอักษรที่ต้องการ, ให้บริการผ่าน [custom font sources](/slides/th/net/custom-font/), หรือกำหนดค่า [font substitution](/slides/th/net/font-substitution/)

นี่เป็นขั้นตอนทำงานระดับมาสเตอร์โดยตรง: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการเขียนทับธีมระดับสไลด์หรือเลย์เอาต์ด้วยตนเอง

### **ใช้ธีมภายนอกที่ต่างกันในงานนำเสนอหลายมาสเตอร์**

เมื่อมาสเตอร์ที่เกี่ยวข้องไม่ทราบล่วงหน้า ให้รับมาสเตอร์จากสไลด์แบบแทนที่ผ่าน [ISlide.LayoutSlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/layoutslide/) และ [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/masterslide/) เก็บอ้างอิงมาสเตอร์ต้นฉบับไว้ก่อนทำการใช้ธีมใด ๆ เพราะแต่ละครั้งที่เรียกเมธอดจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อหามาสเตอร์ของพวกเขาและใช้ธีมภายนอกที่ต่างกันกับแต่ละกลุ่ม:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

การเรียกครั้งแรกมีผลเฉพาะสไลด์ที่ขึ้นกับ `firstGroupMaster` เท่านั้น, ส่วนการเรียกครั้งที่สองมีผลเฉพาะสไลด์ที่ขึ้นกับ `secondGroupMaster` สไลด์ที่สัมพันธ์กับมาสเตอร์อื่นจะไม่ถูกปรับสไตล์ใหม่

### **คงธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและคงการออกแบบเดิม ให้คัดลอกมาสเตอร์ต้นฉบับเข้าไปในงานนำหมายปลายทางด้วย [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/addclone/), แล้วคัดลอกสไลด์ด้วย [ISlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) พร้อมมาสเตอร์ที่คัดลอกแล้ว วิธีนี้จะพ้อมมาสเตอร์, เลย์เอาต์, และธีมที่สัมพันธ์กันไปด้วย

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

นี่เป็นขั้นตอนทำงานที่แนะนำเมื่อสไลด์ต้นฉบับต้องแสดงผลเดียวกันในปลายทาง การคัดลอกเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, แบบอักษร, พื้นหลัง, และเอฟเฟ็กต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลง

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลย์เอาต์ปัจจุบัน ให้เริ่มการเขียนทับระดับสไลด์จากธีมต้นฉบับ เมธอด [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/initfontschemefrom/), และ [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/initformatschemefrom/) จะคัดลอกส่วนสำคัญของธีมสามส่วนเข้าไปในการเขียนทับ

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

การทำเช่นนี้เปลี่ยนธีมที่ใช้โดยสไลด์นั้นโดยไม่กระทบธีมที่สืบทอดโดยสไลด์อื่น ๆ เพื่อลบการเขียนทับในระดับท้องถิ่นและคืนค่าไปยังค่าที่สืบทอด ให้เรียก [OverrideTheme.Clear](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/clear/)

### **ใช้การเขียนทับธีมกับเลย์เอาต์**

การเขียนทับระดับเลย์เอาต์จะมีผลต่อสไลด์ที่ใช้เลย์เอาต์นั้น ยกเว้นกรณีที่สไลด์ใด ๆ มีการเขียนทับของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ได้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/net/aspose.slides.theme/layoutslidethememanager/) ของเลย์เอาต์

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ควรใช้พื้นฐานการออกแบบเดียวกัน ใช้การเขียนทับระดับเลย์เอาต์เมื่อกลุ่มเลย์เอาต์หนึ่งต้องการสไตล์ที่แตกต่าง และใช้การเขียนทับระดับสไลด์เฉพาะในกรณียกเว้นจริง ๆ การเขียนทับระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมแบบรวมในภายหลังคาดเดาได้ยาก

## **อัปเดตสไตล์พื้นหลังของธีม**

สไตล์การเติมพื้นหลังของธีมถูกจัดเก็บใน [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) PowerPoint สามารถนำเสนอตัวเลือกพื้นหลังได้มากกว่าตัวเลขการเติมที่จัดเก็บจริงในคอลเลกชันนี้ เพราะ UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![แกลลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมการนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่จัดเก็บและค่า [Background.StyleIndex](https://reference.aspose.com/slides/th/net/aspose.slides/background/styleindex/) ปัจจุบัน `StyleIndex` ใช้ค่า `0` สำหรับไม่มีการเติมธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม ซึ่งแตกต่างจากการใช้ดัชนีของคอลเลกชัน .NET โดยตรงที่ `[0]` หมายถึงรายการแรกที่จัดเก็บ อย่าถือว่าการนำเสนอทุกไฟล์มีจำนวนสไตล์การเติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่พร้อมใช้งาน, กำหนดการอ้างอิงพื้นหลังของธีมให้กับมาสเตอร์แรก, และบันทึกการนำเสนอ:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการเขียนทับพื้นหลังที่ระดับเลย์เอ็ตหรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังของมาสเตอร์เท่านั้นอาจไม่ส่งผลต่อสไลด์นั้น ใช้ [Background.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/background/geteffective/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอด

{{% alert color="warning" title="คำเตือน" %}}
อย่าใช้ `StyleIndex` เป็นดัชนีของคอลเลกชันที่เริ่มจากศูนย์ นอกจากนี้หลีกเลี่ยงการกำหนดหมายเลขสไตล์จากไฟล์หนึ่งแล้วถือว่าแสดงผลเดียวกันในไฟล์อื่น; คำจำกัดความของสไตล์ธีมเป็นแบบเฉพาะการนำเสนอ
{{% /alert %}}

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง โปรดดู [Presentation Background](/slides/th/net/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟ็กต์ของธีม**

สคีมรูปแบบของธีมมีคอลเลกชันแยกกันสำหรับ [FillStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/linestyles/), และ [EffectStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/effectstyles/) โดยทั่วไปธีม Office จะมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบแบบ Subtle, Moderate, และ Intense อย่างไรก็ตามโค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติว่ามีจำนวนคงที่

![เอฟเฟ็กต์ธีมแบบ Subtle, Moderate, และ Intense ที่ใช้กับรูปแบบเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน C# ดัชนีของคอลเลกชันเป็นแบบศูนย์‑ฐาน: `[0]` คือสไตล์แรกที่จัดเก็บและ `[2]` คือสไตล์ที่สาม ดัชนีอ้างอิงสไตล์ของรูปร่างเป็นแนวคิดแยกต่างหากที่เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/net/aspose.slides/ishapestyle/) การแก้ไขสไตล์ธีมจะส่งผลต่อรูปร่างที่อ้างอิงสไตล์ธีมนั้น; รูปร่างที่มีการจัดรูปแบบโดยตรงอาจคงเดิม

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์การเติมที่สาม, เปิดเงาแบบนอกในสไตล์เอฟเฟ็กต์ที่สาม, และบันทึกผลลัพธ์:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

สำหรับรูปร่างที่อ้างอิงสล็อตเหล่านี้ สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์การเติมธีมที่สามจะเป็นสีเขียวป่าแบบ Solid, และสไตล์เอฟเฟ็กต์ที่สามจะเพิ่มเงานอกระยะ 10 จุด ผลลัพธ์ภาพสุดท้ายยังคงขึ้นอยู่กับว่ารูปร่างอ้างอิงสไตล์ใดและการจัดรูปแบบโดยตรงจะเขียนทับธีมหรือไม่

![สไตล์เอฟเฟ็กต์ของธีมหลังจากการเปลี่ยนเส้น, การเติม, และการตั้งค่าเงา](presentation-design_11.png)

## **อ่านค่าธีมที่มีผล**

วัตถุธีมดิบบอกคุณว่าอะไรถูกกำหนดที่ระดับใด ค่าที่มีผลบอกคุณว่าสไลด์หรือรูปร่างใช้ค่าใดจริงหลังจากการสืบทอดและการเขียนทับในท้องถิ่นได้รับการแก้ไข สำหรับสไลด์ ให้เรียก [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/th/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) สำหรับพื้นหลัง ใช้ [Background.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/background/geteffective/) และสำหรับการเติม ใช้ [FillFormat.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/geteffective/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมรูปแบบแรกจากสไลด์:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

ใช้ข้อมูลที่มีผลสำหรับการวินัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/mastertheme/) เท่านั้น คุณอาจพลาดมาสเตอร์, เลย์เอ็ต, สไลด์, หรือการเขียนทับของรูปร่างที่เปลี่ยนลักษณะสุดท้าย

## **คำถามที่พบบ่อย**

**การใช้ธีมภายนอกส่งผลต่อทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่ . [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) จะกำหนดใหม่เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือกเท่านั้น สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิม

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้ . ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/net/aspose.slides.theme/slidethememanager/) ของสไลด์และเริ่มต้นการเขียนทับธีมของมัน การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมเดิมต่อไป

**วิธีที่ปลอดภัยที่สุดในการถ่ายโอนธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอคืออะไร?**

เมื่อย้ายสไลด์และคงลักษณะเดิมของแหล่งให้คัดลอกมาสเตอร์ต้นฉบับไปยังปลายทางและคัดลอกสไลด์พร้อมมาสเตอร์นั้นด้วย [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/addclone/) และ [ISlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) วิธีนี้จะรักษามาสเตอร์, เลย์เอ็ต, และธีมไว้ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/th/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) สำหรับสไลด์หรือธีมเลย์เอ็ตและเมธอดข้อมูลที่มีผลที่สอดคล้องสำหรับอ็อบเจกต์รูปแบบ เช่น [Background.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/background/geteffective/) และ [FillFormat.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/geteffective/) API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการเขียนทับได้รับการนำไปใช้