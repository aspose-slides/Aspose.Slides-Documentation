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
- พาเลตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอหลักใน Aspose.Slides สำหรับ .NET เพื่อสร้าง, ปรับแต่งและแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สม่ำเสมอ."
---
## **แนะนำ**

ธีมงานนำเสนอกำหนดชุดสี ฟอนต์ สไตล์พื้นหลัง การเติมแบบต่าง ๆ เส้น และเอฟเฟกต์ที่สอดคล้องกัน ออบเจกต์ที่รับรู้ธีมจะอ้างอิงถึงคำนิยามที่ใช้ร่วมกันเหล่านี้แทนการเก็บค่าแต่ละคุณสมบัติเชิงภาพเป็นค่าตายตัว ดังนั้นการเปลี่ยนธีมสามารถอัปเดตออบเจกต์หลาย ๆ ตัวพร้อมกันได้

ใน Aspose.Slides ธีมระดับงานนำเสนอสามารถเข้าถึงได้ผ่านคุณสมบัติ [Presentation.MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/mastertheme/) งานนำเสนออาจมีการกำหนดค่าธีมทับระดับต่ำกว่าได้ มาสเตอร์สามารถกำหนดค่าธีมที่ทับธีมงานนำเสนอได้ผ่าน [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/masterthememanager/overridetheme/), เค้าโครงสามารถกำหนดค่าธีมที่สืบทอดมาทับได้ผ่าน [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), และสไลด์แต่ละสไลด์ก็ทำเช่นเดียวกัน ในการปฏิบัติ ธีมที่มีผลสำหรับสไลด์จะถูกแก้ไขผ่านสายการสืบทอดนี้: ธีมงานนำเสนอ → มาสเตอร์ทับ → เค้าโครงทับ → สไลด์ทับ

![ส่วนประกอบของธีม: สี, ฟอนต์, สไตล์พื้นหลัง, และเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงขั้นตอนการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการกำหนดค่าทับได้ถูกแก้ไขแล้ว

## **ตรวจสอบธีม**

ออบเจกต์ [MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/) เปิดเผย [ColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/fontscheme/), และ [FormatScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/mastertheme/formatscheme/) ของธีม การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์อย่างยิ่งเมื่องานนำเสนอมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, เติม, เส้น, และเอฟเฟกต์ที่จัดเก็บในธีม:

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

หากไฟล์ใช้หลายมาสเตอร์ อย่าสมมติว่าสไลด์ทุกสไลด์มีธีมที่มีผลเช่นเดียวกัน ตรวจสอบมาสเตอร์ที่เชื่อมกับสไลด์และใช้กระบวนการทำงานของธีมที่มีผลที่แสดงต่อไปนี้เมื่ออาจมีการกำหนดค่าทับระดับเค้าโครงหรือสไลด์

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงถึงสีเชิงตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [IColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/icolorscheme/) ของธีม วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะถูกแก้ไขให้ตรงกับค่าใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่เปลี่ยนแปลงจากการอัปเดตสีธีม

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากเปลี่ยนธีม หากคุณแทนที่สีสกีมด้วยสีตรงบนรูปร่าง การเปลี่ยนแปลงต่อมาใน `Accent4` จะไม่ส่งผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างรูปแบบสีอ่อนและสีเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน [ColorTransformOperation](https://reference.aspose.com/slides/th/net/aspose.slides/colortransformoperation/)

![สีธีมหลักและสีอ่อนและสีเข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - รูปแบบสีอ่อนและสีเข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างหกสี่เหลี่ยมอ้างอิงจาก `Accent4`, ประยุกต์การแปลงความสว่างให้กับห้าตัว แบะบันทึกผล:

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

### **แมปค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2` ในขณะที่ [IColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2` การแมปคงที่ดังนี้:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

นี่คือชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง

## **เปลี่ยนฟอนต์ธีม**

สเค็มฟอนต์ของธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับข้อความในเนื้อหา คุณสมบัติ [FontScheme.Major](https://reference.aspose.com/slides/th/net/aspose.slides.theme/fontscheme/major/) และ [FontScheme.Minor](https://reference.aspose.com/slides/th/net/aspose.slides.theme/fontscheme/minor/) เปิดเผยชุดเหล่านั้น

ตัวระบุฟอนต์ธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งบรรทัดที่ใช้ฟอนต์ Latin หลักของธีมและบรรทัดเนื้อหาหนึ่งบรรทัดที่ใช้ฟอนต์ Latin รองของธีม แล้วเปลี่ยนฟอนต์ธีมและบันทึกผล:

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

หัวเรื่องใช้ฟอนต์หลักและข้อความเนื้อหาจะใช้ฟอนต์รอง ข้อความที่ระบุชื่อฟอนต์โดยตรงแทนตัวระบุธีมจะไม่สลับโดยอัตโนมัติเมื่อสเค็มฟอนต์ธีมเปลี่ยน

{{% alert color="info" title="Tip" %}}

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์ในงานนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/net/powerpoint-fonts/)

{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

มีสองกระบวนการทำงานที่พบบ่อยและแก้ปัญหาต่างกัน

### **คงธีมต้นฉบับเมื่อนำสไลด์ไปยังงานนำเสนออื่น**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและคงการออกแบบเดิม ให้คัดลอกมาสเตอร์ต้นฉบับไปยังงานนำเป้าหมายด้วย [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/addclone/), แล้วคัดลอกสไลด์ด้วย [ISlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) และมาสเตอร์ที่คัดลอก นี้จะนำมาสเตอร์, เค้าโครง, และธีมที่เชื่อมโยงมาด้วยกัน

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องดูเหมือนเดิมในปลายทาง การคัดลอกเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่มีความเกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนโดยธีมเปลี่ยนไป

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเค้าโครงปัจจุบัน ให้เริ่มต้นการกำหนดค่าทับระดับสไลด์จากธีมต้นฉบับ วิธีการ [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/initfontschemefrom/), และ [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/initformatschemefrom/) คัดลอกสามส่วนประกอบหลักของธีมเข้าสู่การกำหนดค่าทับ

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

การทำเช่นนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบธีมที่สืบทอดโดยสไลด์อื่น ๆ เพื่อยกเลิกการกำหนดค่าทับระดับท้องถิ่นและกลับไปใช้ค่าที่สืบทอด ให้เรียก [OverrideTheme.Clear](https://reference.aspose.com/slides/th/net/aspose.slides.theme/overridetheme/clear/)

### **ใช้การกำหนดค่าทับธีมกับเค้าโครง**

การกำหนดค่าทับระดับเค้าโครงจะใช้กับสไลด์ที่ใช้เค้าโครงนั้น ยกเว้นกรณีสไลด์ใดสไลด์หนึ่งมีการกำหนดค่าทับของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/net/aspose.slides.theme/layoutslidethememanager/) ของเค้าโครงได้

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

ใช้ธีมระดับมาสเตอร์หรือระดับงานนำเสนอเมื่อหลายเค้าโครงและสไลด์ควรแชร์การออกแบบฐานเดียวกัน ใช้การกำหนดค่าทับเค้าโครงเมื่อกลุ่มเค้าโครงหนึ่งต้องการสไตล์แตกต่างกัน และใช้การกำหนดค่าทับสไลด์เฉพาะกรณีพิเศษที่แท้จริง การกำหนดค่าทับระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมแบบรวมในภายหลังคาดเดายาก

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกจัดเก็บใน [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าที่มีการกำหนดในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมงานนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่จัดเก็บและ [Background.StyleIndex](https://reference.aspose.com/slides/th/net/aspose.slides/background/styleindex/) ปัจจุบัน `StyleIndex` ใช้ค่า `0` เพื่อแสดงว่าไม่มีการเติมตามธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังของธีม สิ่งนี้ต่างจากการอ้างอิงดัชนีของคอลเลกชัน .NET โดยตรงที่ `[0]` หมายถึงรายการแรกที่จัดเก็บ อย่าสมมติว่าทุกงานนำเสนอมีจำนวนสไตล์การเติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มีอยู่, กำหนดการอ้างอิงพื้นหลังแบบธีมให้กับมาสเตอร์แรก, และบันทึกงานนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการกำหนดค่าทับพื้นหลังที่ระดับเค้าโครงหรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังของมาสเตอร์เพียงอย่างเดียวอาจไม่กระทบสไลด์นั้น ใช้ [Background.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/background/geteffective/) เมื่อต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอดได้ถูกประยุกต์

{{% alert color="warning" title="Warning" %}}

อย่าปฏิบัติกับ `StyleIndex` เหมือนกับดัชนีคอลเลกชันที่เริ่มจากศูนย์ อีกทั้งควรหลีกเลี่ยงการฮาร์ดโค้ดหมายเลขสไตล์จากไฟล์หนึ่งแล้วสมมติว่ามีลักษณะเดียวกันในไฟล์อื่น; คำนิยามสไตล์ธีมเป็นเรื่องเฉพาะงานนำเสนอ

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/net/presentation-background/)

{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สเค็มรูปแบบของธีมมีคอลเลกชัน [FillStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/linestyles/), และ [EffectStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/effectstyles/) แยกต่างหาก ธีม Office ปกติจะมีรายการสไตล์หลักสามรายการที่แสดงผลเป็นแบบ Subtle, Moderate, และ Intense แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติว่ามีจำนวนคงที่

![เอฟเฟกต์ธีมแบบ Subtle, Moderate, และ Intense ที่ใช้กับรูปร่างเดียวกัน](presentation-design_10.png)

เมื่อตรวจสอบคอลเลกชันเหล่านี้ใน C# ดัชนีคอลเลกชันเริ่มจากศูนย์: `[0]` คือสไตล์แรกที่จัดเก็บและ `[2]` คือสไตล์ที่สาม ดัชนีการอ้างอิงสไตล์ของรูปร่างเป็นแนวคิดแยกต่างหากที่เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/th/net/aspose.slides/ishapestyle/) การปรับเปลี่ยนสไตล์ธีมจะส่งผลต่อรูปร่างที่อ้างอิงสไตล์ธีมนั้น; รูปร่างที่มีการฟอร์แมตโดยตรงอาจคงที่ไม่เปลี่ยนแปลง

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่จำเป็นหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดใช้งานเงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผล:

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

สำหรับรูปร่างที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงานอกด้วยระยะ 10 จุด ผลลัพธ์ภาพที่แน่นอนไม่ได้ขึ้นอยู่กับช่องสไตล์ที่แต่ละรูปร่างอ้างอิงและว่าการฟอร์แมตโดยตรงจะทับธีมหรือไม่

![สไตล์เอฟเฟกต์ของธีมหลังจากเปลี่ยนการตั้งค่าเส้น, เติม, และเงา](presentation-design_11.png)

## **อ่านค่าธีมที่มีผล**

ออบเจกต์ธีมดิบบอกคุณว่ามีการกำหนดอะไรไว้ที่ระดับใดระดับหนึ่ง ค่าที่มีผลบอกว่าสตอรีหรือรูปร่างใช้ค่าอะไรจริงหลังจากการสืบทอดและการกำหนดค่าทับ คำสั่งสำหรับสไลด์คือ [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/th/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). สำหรับพื้นหลังใช้ [Background.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/background/geteffective/), และสำหรับการเติมใช้ [FillFormat.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/geteffective/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมของรูปร่างแรกจากสไลด์:

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/mastertheme/) คุณอาจพลาดมาสเตอร์, เค้าโครง, สไลด์, หรือการกำหนดค่าทับของรูปร่างที่เปลี่ยนลักษณะสุดท้าย

## **FAQ**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้ ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/net/aspose.slides.theme/slidethememanager/) ของสไลด์และเริ่มต้นธีมที่กำหนดค่าทับ การเปลี่ยนแปลงจะคงอยู่เฉพาะสไลด์นั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมเดิม

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานหนึ่งคืออะไร?**

เมื่อนำสไลด์ไปและคงลักษณะต้นฉบับให้คัดลอกมาสเตอร์ต้นฉบับไปยังปลายทางและคัดลอกสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/addclone/) และ [ISlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/islidecollection/addclone/) วิธีนี้จะรักษามาสเตอร์, เค้าโครง, และธีมไว้ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการกำหนดค่าทับได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/th/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) สำหรับธีมของสไลด์หรือเค้าโครงและเมธอดข้อมูลที่มีผลที่สอดคล้องกันสำหรับออบเจกต์รูปแบบ เช่น [Background.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/background/geteffective/) และ [FillFormat.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/geteffective/) API เหล่านี้จะคืนค่าที่ได้จากการสืบทอดและการกำหนดค่าทับแล้ว