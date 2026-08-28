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
- พาเลตเพิ่มเติม
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟ็กต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ .NET เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี, แบบอักษร, สไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟ็กต์ที่สอดคล้องกัน วัตถุที่รับรู้ธีมจะอ้างอิงคำนิยามที่ใช้ร่วมกันเหล่านี้แทนการเก็บคุณสมบัติวิสัยภาพทุกอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัปเดตวัตถุหลายๆ ตัวพร้อมกัน

ใน Aspose.Slides ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่านคุณสมบัติ [Presentation.MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/mastertheme/) มาสเตอร์สามารถกำจัดค่าเดิมของธีมการนำเสนอได้โดยใช้ [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/masterthememanager/overridetheme/) การจัดวางสามารถกำจัดธีมที่สืบทอดได้ผ่าน [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) และสไลด์แต่ละสไลด์ก็ทำได้เช่นกัน ในทางปฏิบัติ ธีมที่ใช้จริงสำหรับสไลด์จะถูกกำหนดผ่านลำดับการสืบทอดนี้: ธีมการนำเสนอ, การกำจัดมาสเตอร์, การกำจัดการจัดวาง, และการกำจัดสไลด์

![ส่วนประกอบของธีม: สี, แบบอักษร, สไตล์พื้นหลัง, และเอฟเฟ็กต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานกับธีมที่พบมากที่สุด: ตรวจสอบธีม, เปลี่ยนสีและแบบอักษร, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟ็กต์, และอ่านค่าที่ใช้จริงหลังจากการสืบทอดและการกำจัดได้ถูกประมวลผล

## **ตรวจสอบธีม**

[MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/) จะเปิดเผย [ColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/fontscheme/), และ [FormatScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/formatscheme/) ของธีม การตรวจสอบคอลเลกชันเหล่านี้ก่อนการเปลี่ยนแปลงจะเป็นประโยชน์เป็นพิเศษเมื่อการนำเสนอมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟ็กต์ที่ถูกจัดเก็บในธีม:

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

หากไฟล์ใช้มาสเตอร์หลายชุด อย assumed ว่าสไลด์ทุกสไลด์มีธีมที่ใช้จริงเดียวกัน ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์และใช้กระบวนการทำงานธีมที่ใช้จริงตามที่แสดงต่อไปนี้เมื่ออาจมีการกำจัดระดับการจัดวางหรือสไลด์

## **เปลี่ยนสีของธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีเชิงตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [IColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/icolorscheme/) ของธีม ทุกวัตถุที่ยังอ้างอิงสีธีมนั้นจะถูกประมวลผลกับค่าที่ใหม่ วัตถุที่ใช้สี RGB ตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัปเดตสีธีม

ตัวอย่างต่อไปนี้สร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่, และพิมพ์สีการเติมที่ใช้จริง:

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสกีมด้วยสีตรงบนรูปทรง การเปลี่ยนแปลงต่อเนื่องของ `Accent4` จะไม่กระทบต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันสีอ่อนและสีเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน [ColorTransformOperation](https://reference.aspose.com/slides/th/net/aspose.slides/colortransformoperation/)

![สีธีมหลักและสีอ่อน‑สีเข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** – สีธีมหลัก

**2** – เวอร์ชันสีอ่อนและสีเข้มที่ผลิตจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอิงจาก `Accent4`, ใส่การแปลงความสว่างให้กับห้ารูป และบันทึกผลลัพธ์:

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

เวอร์ชันเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงแล้วจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมปค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2` ในขณะที่ [IColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2` การแมปคงที่ดังนี้

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อสลับของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่ง

## **เปลี่ยนแบบอักษรของธีม**

สกีมแบบอักษรของธีมประกอบด้วยชุดแบบอักษรหลักสำหรับหัวเรื่องและชุดแบบอักษรรองสำหรับข้อความเนื้อหา คุณสมบัติ [FontScheme.Major](https://reference.aspose.com/slides/th/net/aspose.slides.theme/fontscheme/major/) และ [FontScheme.Minor](https://reference.aspose.com/slides/th/net/aspose.slides.theme/fontscheme/minor/) จะเปิดเผยชุดเหล่านั้น

ตัวระบุแบบอักษรธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในรูปแบบข้อความได้:

* `+mn‑lt` – แบบอักษรตัว본문 Latin (Minor Latin Font)
* `+mj‑lt` – แบบอักษรหัวเรื่อง Latin (Major Latin Font)
* `+mn‑ea` – แบบอักษรตัว본문 East Asian (Minor East Asian Font)
* `+mj‑ea` – แบบอักษรหัวเรื่อง East Asian (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้แบบอักษร Latin หลักและบรรทัดเนื้อหาหนึ่งที่ใช้แบบอักษร Latin รอง จากนั้นเปลี่ยนแบบอักษรธีมและบันทึกผลลัพธ์:

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

หัวเรื่องจะใช้แบบอักษรหลักและข้อความเนื้อหาจะใช้แบบอักษรรอง ข้อความที่ระบุชื่อแบบอักษรอย่างชัดเจนแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อสกีมแบบอักษรธีมเปลี่ยน

ชุดแบบอักษรหลักและรองยังสามารถมีการแมปแบบอักษรสำหรับระบบเขียนข้อความต่างๆ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana เพื่อดู การเพิ่ม, แทนที่, หรือเอาออกให้ดูที่ [Script‑Specific Theme Fonts](/slides/th/net/script-specific-font-mappings/)

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับแบบอักษรการนำเสนอ โปรดดู [PowerPoint Fonts](/slides/th/net/powerpoint-fonts/)
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

กระบวนการต่อไปนี้แก้ปัญหาเรื่องธีมที่แตกต่างกัน

### **ใช้ธีมภายนอกกับสไลด์ที่ขึ้นกับมาสเตอร์**

ใช้ [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการจัดสไตล์สไลด์ทั้งหมดที่ขึ้นกับมาสเตอร์ใดมาสเตอร์หนึ่ง เลือกมาสเตอร์จากคอลเลกชัน [Presentation.Masters](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/masters/) ซึ่งทำงานเป็น [IMasterSlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/) แล้วส่งพาธไฟล์ธีมไปยังเมธอด

เมธอดทำการต่อไปนี้

1. สร้างสไลด์มาสเตอร์ใหม่จากมาสเตอร์ที่เลือก
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่เคยขึ้นกับมาสเตอร์ที่เลือก
1. ส่งคืน [IMasterSlide](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/) ที่สร้างใหม่

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

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่สนับสนุนอาจทำให้เกิด [PptxException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxexception/) หรือคลาสย่อยที่เกี่ยวกับรูปแบบ ตรวจสอบพาธที่ผู้ใช้ป้อน, จัดการข้อผิดพลาดการเข้าถึงระบบไฟล์, และบันทึกการนำเสนอหลังจากธีมถูกใช้สำเร็จเท่านั้น

จะมีการกำหนดสไลด์ใหม่เฉพาะกับสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือกเท่านั้น สไลด์ที่เชื่อมโยงกับมาสเตอร์อื่นจะคงมาสเตอร์และธีมเดิมไว้ สี, แบบอักษร, การเติม, เส้น, พื้นหลัง, และเอฟเฟ็กต์ที่รับรู้ธีมจะถูกประมวลผลกับธีมภายนอก ส่วนสี, แบบอักษร, การเติม และรูปแบบที่กำหนดโดยตรงอาจคงเดิม การกำจัดระดับการจัดวางและระดับสไลด์ก็อาจมีลำดับความสำคัญเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่

ธีมอาจอ้างอิงแบบอักษรที่ไม่มีในสภาพแวดล้อมรันไทม์ สำหรับการเรนเดอร์และการส่งออกที่สอดคล้องกัน ให้ติดตั้งแบบอักษรที่จำเป็น, จัดหาโดยผ่าน [custom font sources](/slides/th/net/custom-font/), หรือกำหนดค่า [font substitution](/slides/th/net/font-substitution/)

นี่คือกระบวนการทำงานระดับมาสเตอร์โดยตรง: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการกำจัดธีมระดับสไลด์หรือระดับการจัดวางด้วยตนเอง

### **ใช้ธีมภายนอกที่แตกต่างกันในงานนำเสนอหลายมาสเตอร์**

เมื่อมาสเตอร์ที่เกี่ยวข้องไม่ทราบล่วงหน้า ให้รับมาสเตอร์จากสไลด์ตัวอย่างผ่าน [ISlide.LayoutSlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/layoutslide/) และ [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/masterslide/) เก็บอ้างอิงมาสเตอร์เดิมก่อนใช้ธีมใดๆ เพราะแต่ละการเรียกจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อหามาสเตอร์และใช้ธีมภายนอกที่แตกต่างกันกับแต่ละกลุ่ม:

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

การเรียกแรกส่งผลต่อสไลด์ที่ขึ้นกับ `firstGroupMaster` เท่านั้น, การเรียกที่สองส่งผลต่อสไลด์ที่ขึ้นกับ `secondGroupMaster` เท่านั้น สไลด์ที่อยู่ภายใต้มาสเตอร์อื่นจะไม่ถูกจัดสไตล์ใหม่

### **รักษาธีมต้นฉบับเมื่ย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและรักษาการออกแบบเดิม ให้โคลนมาสเตอร์ต้นฉบับเข้าสู่งานนำหมายด้วย [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/addclone/), จากนั้นโคลนสไลด์ด้วย [ISlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) และมาสเตอร์ที่โคลนไว้ วิธีนี้จะพามาสเตอร์, การจัดวาง, และธีมที่เชื่อมโยงมาด้วยกัน

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องดูเหมือนเดิมในปลายทาง การโคลนเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, แบบอักษร, พื้นหลัง, และเอฟเฟ็กต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนไป

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องอยู่บนมาสเตอร์และการจัดวางปัจจุบัน ให้เริ่มการกำจัดระดับสไลด์จากธีมต้นฉบับ วิธี [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/initfontschemefrom/), และ [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/initformatschemefrom/) จะคัดลอกส่วนประกอบธีมหลักสามส่วนเข้าสู่การกำจัด

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

วิธีนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่เปลี่ยนธีมที่สืบทอดโดยสไลด์อื่น เพื่อเอาการกำจัดในระดับท้องถิ่นออกและกลับไปใช้ค่าที่สืบทอด ให้เรียก [OverrideTheme.Clear](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/clear/)

### **ใช้การกำจัดธีมกับการจัดวาง**

การกำจัดระดับการจัดวางจะใช้กับสไลด์ที่ใช้การจัดวางนั้น, ยกเว้นกรณีที่สไลด์นั้นมีการกำจัดของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ได้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/net/aspose.slides.theme/layoutslidethememanager/) ของการจัดวาง

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

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายการจัดวางและสไลด์ควรแชร์การออกแบบพื้นฐานเดียวกัน, ใช้การกำจัดระดับการจัดวางเมื่อกลุ่มการจัดวางต้องการสไตล์ที่แตกต่าง, และใช้การกำจัดระดับสไลด์เฉพาะกรณีพิเศษ การกำจัดระดับสไลด์เกินเกินทำให้การเปลี่ยนธีมทั่วโลกในภายหลังคาดเดาได้ยาก

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกเก็บใน [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) PowerPoint สามารถแสดงตัวเลือกพื้นหลังมากกว่าจำนวนการกำหนดการเติมที่จัดเก็บจริงในคอลเลกชันนี้ เพราะ UI สามารถรวมการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่นได้

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมการนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่จัดเก็บและค่า [Background.StyleIndex](https://reference.aspose.com/slides/th/net/aspose.slides/background/styleindex/) ปัจจุบัน `StyleIndex` ใช้ค่า `0` สำหรับไม่มีการเติมธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม นี้แตกต่างจากการใช้ดัชนีของคอลเลกชัน .NET โดยตรงที่ `[0]` หมายถึงรายการแรก อย่าสมมติว่าการนำเสนอทุกไฟล์มีจำนวนสไตล์การเติมพื้นหลังเท่าเดียวกัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังของธีมให้กับมาสเตอร์แรก, และบันทึกการนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการกำจัดพื้นหลังที่ระดับการจัดวางหรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังมาสเตอร์เพียงอย่างเดียวอาจไม่กระทบต่อสไลด์นั้น ใช้ [Background.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/background/geteffective/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอด

{{% alert color="warning" title="Warning" %}}
อย่าปฏิบัติเช่น `StyleIndex` เป็นดัชนีคอลเลกชันที่เริ่มจากศูนย์ นอกจากนี้ หลีกเลี่ยงการกำหนดค่าตัวเลขสไตล์จากไฟล์หนึ่งและสมมติว่ามีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความของสไตล์ธีมเป็นเฉพาะของการนำเสนอ
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ให้ดู [Presentation Background](/slides/th/net/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟ็กต์ของธีม**

สกีมรูปแบบของธีมมีคอลเลกชันแยกต่างหากสำหรับ [FillStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/linestyles/), และ [EffectStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/effectstyles/) ปกติธีมของ Office จะมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบที่ Subtle, Moderate, และ Intense แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติว่ามีจำนวนคงที่

![เอฟเฟ็กต์ธีม Subtle, Moderate, และ Intense ที่ใช้กับรูปทรงเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน C# ดัชนีของคอลเลกชันเริ่มจากศูนย์: `[0]` คือสไตล์แรกและ `[2]` คือสไตล์ที่สาม ดัชนีการอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกที่เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/net/aspose.slides/ishapestyle/) การแก้ไขสไตล์ธีมจะส่งผลต่อรูปทรงที่อ้างอิงสไตล์นั้น; รูปทรงที่มีการกำหนดรูปแบบโดยตรงอาจคงเดิม

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์การเติมที่สาม, เปิดเงานอกในสไตล์เอฟเฟ็กต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์การเติมธีมที่สามจะกลายเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟ็กต์ที่สามจะมีเงานอกด้วยระยะ 10 points ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นอยู่กับว่ารูปทรงอ้างอิงช่องสไตล์ใดและว่าการกำหนดรูปแบบโดยตรงได้กำจัดธีมหรือไม่

![เอฟเฟ็กต์ธีมหลังจากเปลี่ยนเส้น, การเติม, และการตั้งค่าเงา](presentation-design_11.png)

## **ตรวจสอบว่าการเติมแบบทึบที่ใช้จริงใช้สีธีมหรือไม่**

การเติมอาจถูกเก็บโดยตรงบนวัตถุหรือสืบทอดจากย่อหน้า, การจัดวาง, มาสเตอร์, สไตล์ธีม, หรือระดับการจัดรูปแบบอื่น เรียก [IFillFormat.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/ifillformat/geteffective/) เพื่อแปลงลำดับชั้นนั้นเป็น [IFillFormatEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ifillformateffectivedata/) ตรวจสอบ [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/th/net/aspose.slides/ifillformateffectivedata/filltype/) ก่อน หากเป็น `FillType.Solid` จึงอ่านคุณสมบัติการเติมแบบทึบ

สำหรับการเติมแบบทึบ, [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/th/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) คืนค่ารหัส RGB ที่เรนเดอร์สุดท้ายหลังจากการสืบทอด, การค้นหาธีม, และการแปลงสี [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) คืนช่อง [SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/schemecolor/) ที่สอดคล้อง เช่น `Text1` หรือ `Accent6` ค่า `SchemeColor.NotDefined` หมายความว่าการเติมแบบทึบที่ใช้จริงไม่อิงจากสีสกีม ในเวิร์กโฟลว์ที่การเติมเป็นสีธีมหรือสี RGB ตรง ค่านี้ระบุการเติม RGB ตรง

อย่าใช้ค่า [IColorFormat.SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/icolorformat/schemecolor/) ในระดับท้องถิ่นเพียงอย่างเดียวเพื่อจำแนกการเติม ตัวอย่างเช่น ส่วนของข้อความอาจไม่มีสีสกีมที่กำหนดในระดับท้องถิ่น ดังนั้นค่าท้องถิ่นจะเป็น `NotDefined` แต่การเติมที่ใช้จริงอาจสืบทอดสีธีมและแปลงเป็น `Text1` หรือ `Accent6` กลับกัน `SolidFillSchemeColor` บอกว่าช่องธีมเชิงตรรกะใดสร้างสีที่ใช้จริง, แต่ไม่ได้บอกว่าช่องนั้นมาจากวัตถุ, ย่อหน้า, การจัดวาง, มาสเตอร์ หรือระดับอื่นของลำดับการจัดรูปแบบ

ตัวอย่างต่อไปนี้โหลดการนำเสนอ, ตรวจสอบการเติมของรูปทรงและส่วนข้อความ, พิมพ์ค่ารหัส RGB สุดท้ายและสีสกีมที่เกี่ยวข้อง, และทำเครื่องหมายการเติมแบบทึบที่ไม่ติดตามการเปลี่ยนแปลงสีธีม:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

สาขา `NotDefined` ให้รายการตรวจสอบของการเติมแบบทึบที่ไม่ตอบสนองต่อการเปลี่ยนแปลงในช่องสีธีม ตรวจสอบวัตถุเหล่านั้นเมื่อการนำเสนอจำเป็นต้องสอดคล้องกับพาเลตแบรนด์ใหม่ ค่ารหัส RGB ที่รายงานยังคงแสดงลักษณะปัจจุบัน ส่วนค่าสกีมอธิบายว่าลักษณะนั้นเชื่อมต่อกับธีมหรือไม่

วัตถุแบบฟอร์แมตที่ใช้จริงเป็นสแนปช็อต หลังจากเปลี่ยนธีมการนำเสนอ, การกำจัดธีม, หรือการจัดรูปแบบที่สืบทอดใดๆ ให้เรียก `GetEffective` อีกครั้งและอ่านอ็อบเจ็กต์ `IFillFormatEffectiveData` ใหม่ก่อนทำการเปรียบเทียบหรือรายงานสี

## **อ่านค่าธีมที่ใช้จริง**

อ็อบเจ็กต์ธีมดิบบอกสิ่งที่กำหนดในระดับใดระดับหนึ่ง ค่าที่ใช้จริงบอกสิ่งที่สไลด์หรือรูปทรงจริง ๆ ใช้หลังจากการสืบทอดและการกำจัดในระดับท้องถิ่นได้ถูกประมวลผล สำหรับสไลด์ ให้เรียก [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/th/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) สำหรับพื้นหลังใช้ [Background.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/background/geteffective/) และสำหรับการเติมใช้ [FillFormat.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/geteffective/)

ตัวอย่างต่อไปนี้อ่านธีมที่ใช้จริง, พื้นหลัง, และการเติมรูปทรงแรกจากสไลด์:

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

ใช้ข้อมูลที่ใช้จริงสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/mastertheme/) คุณอาจพลาดการกำจัดที่มาจากมาสเตอร์, การจัดวาง, สไลด์, หรือรูปทรงที่เปลี่ยนลักษณะสุดท้าย

## **คำถามที่พบบ่อย**

**การใช้ธีมภายนอกส่งผลต่อสไลด์ทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) จะกำหนดสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือกเท่านั้น สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิม

**ฉันสามารถใช้ธีมกับสไลด์เดี่ยวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/net/aspose.slides.theme/slidethememanager/) ของสไลด์และเริ่มต้นการกำจัดธีม การเปลี่ยนแปลงจะอยู่ในระดับสไลด์นั้นเท่านั้น; สไลด์อื่นจะยังคงสืบทอดธีมเดิม

**วิธีที่ปลอดภัยที่สุดในการพาธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอคืออะไร?**

เมื่อย้ายสไลด์และต้องการรักษาลักษณะต้นฉบับ ให้โคลนมาสเตอร์ต้นฉบับเข้าสู่ปลายทางและโคลนสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/addclone/) และ [ISlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) วิธีนี้ทำให้มาสเตอร์, การจัดวาง, และธีมคงอยู่ด้วยกัน

**ฉันจะดูค่าที่ใช้จริงหลังจากการสืบทอดและการกำจัดได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/th/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) สำหรับสไลด์หรือธีมการจัดวางและเมธอดข้อมูลที่ใช้จริงที่สอดคล้องสำหรับอ็อบเจ็กต์รูปแบบ เช่น [Background.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/background/geteffective/) และ [FillFormat.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/geteffective/) API เหล่านี้จะคืนค่าที่ประมวลผลแล้วหลังจากการสืบทอดและการกำจัดถูกนำไปใช้