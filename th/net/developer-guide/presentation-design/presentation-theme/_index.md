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
- สีธีม
- พาเล็ตเสริม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการธีมการนำเสนอหลักใน Aspose.Slides สำหรับ .NET เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมงานนำเสนอกำหนดชุดสี ฟอนต์ สไตล์พื้นหลัง เติม สี เส้น และเอฟเฟกต์ที่สอดคล้องกัน วัตถุที่รับรู้ธีมจะอ้างอิงคำนิยามที่ใช้ร่วมกันเหล่านี้แทนการเก็บค่าคุณสมบัติวิสัยเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัปเดตวัตถุหลายรายการพร้อมกันได้

ใน Aspose.Slides ธีมระดับงานนำเสนอสามารถเข้าถึงได้ผ่านคุณสมบัติ [Presentation.MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/mastertheme/) งานนำเสนอสามารถมีการเขียนทับธีมในระดับล่างได้ด้วยเช่นกัน มาสเตอร์สามารถเขียนทับธีมงานนำเสนอได้ผ่าน [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/masterthememanager/overridetheme/), เค้าโครงสามารถเขียนทับธีมที่สืบทอดได้ผ่าน [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), และสไลด์แต่ละสไลด์ก็ทำได้เช่นกัน ในทางปฏิบัติ ธีมที่มีผลสำหรับสไลด์หนึ่งจะถูกกำหนดผ่านสายการสืบทอดนี้: ธีมงานนำเสนอ → การเขียนทับมาสเตอร์ → การเขียนทับเค้าโครง → การเขียนทับสไลด์

![ส่วนประกอบของธีม: สี ฟอนต์ สไตล์พื้นหลังและเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงขั้นตอนการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้รับการแก้ไขแล้ว

## **ตรวจสอบธีม**

วัตถุ [MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/) เปิดเผย [ColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/fontscheme/), และ [FormatScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/formatscheme/) ของธีม การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์อย่างยิ่งเมื่อการนำเสนอมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติธีมหลักและรายงานจำนวนสไตล์พื้นหลัง, เติม, เส้น, และเอฟเฟกต์ที่เก็บไว้ในธีม:

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

หากไฟล์ใช้มาสเตอร์หลายรายการ อย่าสันนิษฐานว่าสไลด์ทุกสไลด์มีธีมที่มีผลเท่าเดิม ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์, และใช้ขั้นตอนการทำงานกับธีมที่มีผลที่แสดงในบทความนี้ต่อไปเมื่ออาจมีการเขียนทับที่ระดับเค้าโครงหรือสไลด์

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [IColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/icolorscheme/) ของธีม, วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะถูกแก้ไขให้ใช้ค่าที่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัปเดตสีธีม

ตัวอย่างต่อไปนี้สร้างรูปร่างที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกงานนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีเติมที่มีผล:

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

เพราะสี่เหลี่ยมยังคงเชื่อมต่อกับ `Accent4`, สีที่มองเห็นจะกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสกีมด้วยสีโดยตรงบนรูปร่าง, การเปลี่ยนแปลงต่อไปของ `Accent4` จะไม่ส่งผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเล็ตเสริม**

PowerPoint สร้างสีที่อ่อนและเข้มขึ้นจากสีธีมโดยการใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน [ColorTransformOperation](https://reference.aspose.com/slides/th/net/aspose.slides/colortransformoperation/)

![สีธีมหลักและสีอ่อน‑เข้มที่สร้างจากพาเล็ตเสริม](additional-palette-colors.png)

**1** – สีธีมหลัก

**2** – สีอ่อน‑เข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างหกสี่เหลี่ยมพื้นฐานจาก `Accent4`, ใช้การแปลงความสว่างกับห้าตัว, และบันทึกผลลัพธ์:

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

รูปแบบเหล่านี้ยังคงอิงตามสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมปค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2` ส่วน [IColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2` การแมปเป็นค่าคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกสำหรับช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง

## **เปลี่ยนฟอนต์ธีม**

สกีมฟอนต์ของธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับเนื้อความ คุณสมบัติ [FontScheme.Major](https://reference.aspose.com/slides/th/net/aspose.slides.theme/fontscheme/major/) และ [FontScheme.Minor](https://reference.aspose.com/slides/th/net/aspose.slides.theme/fontscheme/minor/) เปิดเผยชุดเหล่านี้

ตัวระบุฟอนต์ธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn‑lt` – ฟอนต์เนื้อหา Latin (Minor Latin Font)
* `+mj‑lt` – ฟอนต์หัวเรื่อง Latin (Major Latin Font)
* `+mn‑ea` – ฟอนต์เนื้อหา East Asian (Minor East Asian Font)
* `+mj‑ea` – ฟอนต์หัวเรื่อง East Asian (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้ฟอนต์ Latin ระดับสำคัญและบรรทัดเนื้อหาหนึ่งที่ใช้ฟอนต์ Latin ระดับรอง จากนั้นเปลี่ยนฟอนต์ธีมและบันทึกผลลัพธ์:

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

หัวเรื่องจะใช้ฟอนต์หลักและข้อความส่วนเนื้อหาจะใช้ฟอนต์รอง ข้อความที่ระบุชื่อฟอนต์อย่างชัดเจนแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อสกีมฟอนต์ธีมเปลี่ยน

คอลเลกชันฟอนต์หลักและรองยังสามารถมีการแมปฟอนต์สำหรับระบบเขียนแต่ละระบบ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana เพื่อดู, เพิ่ม, แทนที่ หรือเอาออกให้ดูที่ [Script‑Specific Theme Fonts](/slides/th/net/script-specific-font-mappings/)

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์ในงานนำเสนอ, ดูที่ [PowerPoint Fonts](/slides/th/net/powerpoint-fonts/)
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

มีกระบวนการทำงานที่พบบ่อยสองแบบ, ซึ่งแก้ปัญหาต่างกัน

### **คงธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและคงการออกแบบเดิมไว้, ให้โคลนมาสเตอร์ต้นฉบับเข้าไปในงานนำหมายปลายทางด้วย [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/addclone/), แล้วโคลนสไลด์ด้วย [ISlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) พร้อมมาสเตอร์ที่โคลนไว้ วิธีนี้ทำให้มาสเตอร์, เค้าโครง, และธีมที่เชื่อมโยงอยู่ด้วยกัน

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องดูเหมือนกันในปลายทาง การโคลนเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่มีความสัมพันธ์อาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลงได้

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์ปลายทางต้องคงอยู่บนมาสเตอร์และเค้าโครงปัจจุบัน, ให้เริ่มการเขียนทับระดับสไลด์จากธีมต้นฉบับ วิธีการ [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/initfontschemefrom/), และ [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/initformatschemefrom/) จะคัดลอกสามส่วนหลักของธีมเข้าสู่การเขียนทับ

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

วิธีนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบธีมที่สืบทอดจากสไลด์อื่น ๆ เพื่อเอาการเขียนทับในระดับท้องถิ่นออกและกลับสู่ค่าที่สืบทอด, เรียกใช้ [OverrideTheme.Clear](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/clear/)

### **ใช้การเขียนทับธีมกับเค้าโครง**

การเขียนทับระดับเค้าโครงจะใช้กับสไลด์ที่ใช้เค้าโครงนั้น, ยกเว้นกรณีที่สไลด์เฉพาะมีการเขียนทับของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/net/aspose.slides.theme/layoutslidethememanager/) ของเค้าโครงได้:

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

ใช้ธีมระดับมาสเตอร์หรือระดับงานนำเสนอเมื่อหลายเค้าโครงและสไลด์ต้องการแบ่งปันการออกแบบฐานเดียวกัน, ใช้การเขียนทับเค้าโครงเมื่อครอบครัวเค้าโครงหนึ่งต้องการสไตล์ที่แตกต่าง, และใช้การเขียนทับสไลด์เฉพาะเมื่อเป็นข้อยกเว้นจริง การเขียนทับระดับสไลด์มากเกินไปทำให้การเปลี่ยนแปลงธีมทั่วโลกในภายหลังคาดเดายากขึ้น

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมจะถูกเก็บใน [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าอีกหลายแบบใน UI ของมัน เนื่องจาก UI สามารถผสมการเติมธีมกับสีธีมและอ้างอิงสไตล์อื่น ๆ

![แกลเลอรีสไตล์พื้นหลัง PowerPoint สำหรับธีมงานนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง, ให้ตรวจสอบคอลเลกชันที่เก็บและค่า [Background.StyleIndex](https://reference.aspose.com/slides/th/net/aspose.slides/background/styleindex/) ปัจจุบัน `StyleIndex` ใช้ค่า `0` สำหรับไม่มีการเติมตามธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม สิ่งนี้ต่างจากการทำดัชนีคอลเลกชัน .NET โดยตรงที่ `[0]` หมายถึงไอเท็มแรกที่เก็บ อย่าสันนิษฐานว่างานนำเสนอทุกไฟล์มีจำนวนสไตล์เติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังตามธีมให้กับมาสเตอร์แรก, และบันทึกงานนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการเขียนทับพื้นหลังในระดับเค้าโครงหรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังมาสเตอร์เพียงอย่างเดียวอาจไม่เปลี่ยนสไลด์นั้น ใช้วิธี [Background.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/background/geteffective/) เมื่อต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอด

{{% alert color="warning" title="คำเตือน" %}}
อย่าใช้ `StyleIndex` เป็นดัชนีของคอลเลกชันที่เริ่มจากศูนย์ นอกจากนี้ควรหลีกเลี่ยงการกำหนดหมายเลขสไตล์จากไฟล์หนึ่งและสันนิษฐานว่ามีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ของธีมเป็นเฉพาะงานนำเสนอ
{{% /alert %}}

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง, ดูที่ [Presentation Background](/slides/th/net/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สกีมฟอร์แมตของธีมมีคอลเลกชันแยกต่างหากสำหรับ [FillStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/linestyles/), และ [EffectStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/effectstyles/) โดยทั่วไปธีมของ Office จะมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการฟอร์แมตแบบละมุน, ปานกลาง, และเข้มข้น, แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสันนิษฐานว่ามีจำนวนคงที่

![เอฟเฟกต์ธีมละมุน, ปานกลาง, และเข้มข้นที่ใช้กับรูปร่างเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน C#, ดัชนีคอลเลกชันเริ่มจากศูนย์: `[0]` คือสไตล์แรกที่เก็บและ `[2]` คือสไตล์ที่สาม ดัชนีการอ้างอิงสไตล์ของรูปร่างเป็นแนวคิดแยกต่างหาก, เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/net/aspose.slides/ishapestyle/). การแก้ไขสไตล์ธีมจะส่งผลต่อรูปร่างที่อ้างอิงสไตล์ธีมนั้น; รูปร่างที่มีการฟอร์แมตโดยตรงอาจไม่เปลี่ยน

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่จำเป็นหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดเงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปร่างที่อ้างอิงช่องเหล่านี้, สไตล์เส้นแรกของธีมจะกลายเป็นสีแดง, สไตล์เติมที่สามของธีมจะเป็นสีเขียวฟอเรสต์ทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงานอกที่ระยะ 10 จุด ผลลัพธ์ภาพที่แน่นอนยังขึ้นอยู่กับว่ารูปร่างแต่ละอันอ้างอิงช่องสไตล์ใดและว่าการฟอร์แมตโดยตรงเขียนทับธีมหรือไม่

![สไตล์เอฟเฟกต์ธีมหลังจากเปลี่ยนการตั้งค่าเส้น, เติม, และเงา](presentation-design_11.png)

## **อ่านค่าธีมที่มีผล**

วัตถุธีมดิบบอกให้คุณรู้ว่ามีการกำหนดอะไรไว้ที่ระดับนั้น ๆ ค่าที่มีผลบอกว่าผลลัพธ์ที่สไลด์หรือรูปร่างใช้จริงหลังจากการสืบทอดและการเขียนทับท้องถิ่นได้รับการแก้ไขแล้ว สำหรับสไลด์ให้เรียก [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/th/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) สำหรับพื้นหลังใช้ [Background.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/background/geteffective/) และสำหรับการเติมใช้ [FillFormat.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/geteffective/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมของรูปร่างแรกจากสไลด์หนึ่ง:

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการแสดงผล, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/mastertheme/) คุณอาจพลาดการเขียนทับของมาสเตอร์, เค้าโครง, สไลด์, หรือรูปร่างที่เปลี่ยนลักษณะสุดท้าย

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ให้ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/net/aspose.slides.theme/slidethememanager/) ของสไลด์และเริ่มต้นธีมเขียนทับของมัน การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมที่มีอยู่

**วิธีที่ปลอดภัยที่สุดในการนำธีมจากงานนำเสนอหนึ่งไปยังอีกงานหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และคงลักษณะต้นฉบับ, ให้โคลนมาสเตอร์ต้นฉบับเข้าสู่ปลายทางและโคลนสไลด์พร้อมมาสเตอร์นั้นโดยใช้ [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/addclone/) และ [ISlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) วิธีนี้ทำให้มัสเตอร์, เค้าโครง, และธีมอยู่ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/th/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) สำหรับสไลด์หรือธีมเค้าโครงและวิธีการรับข้อมูลที่มีผลที่สอดคล้องสำหรับออบเจ็กต์ฟอร์แมต เช่น [Background.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/background/geteffective/) และ [FillFormat.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/geteffective/) API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการเขียนทับถูกนำไปใช้