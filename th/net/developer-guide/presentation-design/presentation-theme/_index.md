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
- ตั้งธีม
- เปลี่ยนธีม
- จัดการธีม
- ธีมภายนอก
- THMX
- สีธีม
- พาเล็ทเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ธีมการนำเสนอหลักใน Aspose.Slides สำหรับ .NET เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการจัดแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี ฟอนต์ สไตล์พื้นหลัง การเติม การวาดเส้น และเอฟเฟกต์ที่สอดคล้องกัน อ็อบเจกต์ที่รับรู้ธีมจะอ้างอิงถึงคำนิยามที่ใช้ร่วมกันเหล่านี้แทนการเก็บค่าคุณสมบัติดิจิทัลแต่ละอย่างเป็นค่าคงที่ ทำให้การเปลี่ยนธีมสามารถอัปเดตอ็อบเจกต์หลาย ๆ ตัวพร้อมกัน

ใน Aspose.Slides ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่านคุณสมบัติ [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/) การนำเสนออาจมีการเขียนทับธีมในระดับที่ต่ำกว่า มาสเตอร์สามารถเขียนทับธีมการนำเสนอผ่าน [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/) layout สามารถเขียนทับธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) และสไลด์แต่ละสไลด์ก็สามารถทำเช่นเดียวกันได้ ในการใช้งานจริง ธีมที่มีผลสำหรับสไลด์จะถูกกำหนดผ่านห่วงโซ่การสืบทอดนี้: ธีมการนำเสนอ → การเขียนทับของมาสเตอร์ → การเขียนทับของเลย์เอาต์ → การเขียนทับของสไลด์

![ส่วนประกอบของธีม: สี ฟอนต์ สไตล์พื้นหลังและเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานของธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้รับการแก้ไข

## **ตรวจสอบธีม**

อ็อบเจกต์ [MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/) เปิดเผย [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/), และ [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/) ของธีม การตรวจสอบคอลเล็กชันเหล่านี้ก่อนทำการเปลี่ยนแปลงเป็นประโยชน์อย่างยิ่งเมื่อการนำเสนอมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติหลักของธีมและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่ถูกเก็บไว้ในธีม:

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

หากไฟล์ใช้มาสเตอร์หลายตัว อย่าสันนิษฐานว่าสไลด์ทุกสไลด์มีธีมที่มีผลเดียวกัน ตรวจสอบมาสเตอร์ที่สัมพันธ์กับสไลด์และใช้กระบวนการทำงานของธีมที่มีผลที่แสดงต่อไปนี้เมื่ออาจมีการเขียนทับที่เลย์เอาต์หรือสไลด์

## **เปลี่ยนสีของธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงถึงสีเชิงตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) ของธีม ทุกอ็อบเจกต์ที่ยังอ้างอิงสีธีมนั้นจะได้รับการแก้ไขด้วยค่าที่ใหม่ อ็อบเจกต์ที่ใช้สี RGB โดยตรงจะไม่เปลี่ยนแปลงจากการอัปเดตสีธีม

ตัวอย่างต่อไปนี้เป็นการสร้างรูปร่างที่ใช้ `Accent4`, เปลี่ยนสีธีม `Accent4` เป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่, และพิมพ์สีเติมที่มีผล:

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

เพราะสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีเชิงสคีมด้วยสีโดยตรงบนรูปร่าง การเปลี่ยนแปลงต่อไปของ `Accent4` จะไม่ส่งผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเล็ทเพิ่มเติม**

PowerPoint สร้างเวอร์ชันสีอ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/)

![สีธีมหลักและสีอ่อนเข้มที่สร้างจากพาเล็ทเพิ่มเติม](additional-palette-colors.png)

**1** – สีธีมหลัก  
**2** – เวอร์ชันสีอ่อนและเข้มที่สร้างจากสีธีมหลัก  

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปที่อิงจาก `Accent4`, ใช้การแปลงความสว่างกับห้ารูป, และบันทึกผลลัพธ์:

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

เวอร์ชันเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมปค่า `SchemeColor` ไปยังช่อง `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2` ในขณะที่ [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2` การแมปเป็นคงที่:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

เหล่านี้เป็นชื่อแทนสำหรับช่องธีมเดียวกัน; พวกมันไม่ใช่ค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง

## **เปลี่ยนฟอนต์ของธีม**

สกีมฟอนต์ของธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์ย่อยสำหรับข้อความธรรมดา คุณสมบัติ [FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) และ [FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) เปิดเผยชุดเหล่านั้น

ตัวระบุฟอนต์ธีมที่เข้ากันกับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความ:

* `+mn-lt` – ฟอนต์ตัวอักษรลาติน (ฟอนต์ย่อยลาติน)  
* `+mj-lt` – ฟอนต์หัวเรื่องลาติน (ฟอนต์หลักลาติน)  
* `+mn-ea` – ฟอนต์ลาตินเอเชียตะวันออก (ฟอนต์ย่อยเอเชียตะวันออก)  
* `+mj-ea` – ฟอนต์หัวเรื่องเอเชียตะวันออก (ฟอนต์หลักเอเชียตะวันออก)  
* `+mn-cs` – ฟอนต์สคริปต์ซับซ้อน (ฟอนต์ย่อยสคริปต์ซับซ้อน)  
* `+mj-cs` – ฟอนต์หัวเรื่องสคริปต์ซับซ้อน (ฟอนต์หลักสคริปต์ซับซ้อน)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้ฟอนต์ธีมลาตินหลักและบรรทัดข้อความธรรมดาหนึ่งที่ใช้ฟอนต์ธีมลาตินย่อย จากนั้นเปลี่ยนฟอนต์ธีมและบันทึกผลลัพธ์:

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

หัวเรื่องใช้ฟอนต์หลักและข้อความใช้ฟอนต์ย่อย ข้อความที่มีชื่อฟอนต์โดยตรงแทนตัวระบุธีมจะไม่สลับโดยอัตโนมัติเมื่อสกีมฟอนต์ธีมเปลี่ยน

ชุดฟอนต์หลักและย่อยอาจมีการแมปฟอนต์สำหรับระบบเขียนแบบเฉพาะ เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana เพื่อดู, เพิ่ม, แทนที่ หรือเอาการแมปเหล่านี้ออก ให้ดูที่ [Script-Specific Theme Fonts](/slides/th/net/script-specific-font-mappings/)

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์การนำเสนอ โปรดดูที่ [PowerPoint Fonts](/slides/th/net/powerpoint-fonts/)
{{% /alert %}}

### **แก้ไขการอ้างอิงฟอนต์ธีม**

เมื่อทำการตรวจสอบข้อความ [IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) อาจมีการอ้างอิงธีมเช่น `+mn-lt` แทนชื่อฟอนต์ ใช้ [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/) พร้อมกับ [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/) ที่เหมาะสมเพื่อแก้ไขการอ้างอิงนั้น คำปัจจัย `+mj` และ `+mn` เลือกชุดฟอนต์หลักและย่อย; ส่วนต่อท้าย `-lt`, `-ea`, และ `-cs` เลือกฟอนต์ลาติน, เอเชียตะวันออก, และสคริปต์ซับซ้อนตามลำดับ

ขอธีมที่มีผลผ่าน [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) บนวัตถุที่ธีมของมันใช้กับข้อความที่ตรวจสอบ สำหรับข้อความธรรมดาบนสไลด์ ใช้ `slide.CreateThemeEffective()` เพื่อให้บริบทรวมธีมที่สืบทอดและการเขียนทับท้องถิ่น เมื่อทำการตรวจสอบเลย์เอาต์หรือมาสเตอร์เอง ใช้ธีมที่มีผลของมันเอง อย่าสันนิษฐานว่าธีมของมาสเตอร์แรกใช้กับสไลด์ทุกสไลด์

ตัวอย่างต่อไปนี้สร้างส่วนข้อความที่อ้างอิงฟอนต์ลาตินย่อยอย่างชัดเจน จะเริ่มต้นสไลด์ฟอนต์สกีมผ่าน [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) และตั้งฟอนต์ลาตินหลักและย่อยเป็น `Arial` และ `Calibri` ทำให้ผลลัพธ์ทำซ้ำได้โดยไม่มีไฟล์อินพุต

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var theme = slide.ThemeManager.OverrideTheme;
theme.InitFontSchemeFromInherited();
theme.FontScheme.Major.LatinFont = new FontData("Arial");
theme.FontScheme.Minor.LatinFont = new FontData("Calibri");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Text using the minor theme font";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("+mn-lt");

var font = portion.PortionFormat.LatinFont;
var effectiveTheme = slide.CreateThemeEffective();
Console.WriteLine($"{font.FontName} -> {font.GetFontName(effectiveTheme)}");

var explicitFont = new FontData("Verdana");
Console.WriteLine($"{explicitFont.FontName} -> {explicitFont.GetFontName(effectiveTheme)}");
```

ผลลัพธ์คือ `+mn-lt -> Calibri` ตามด้วย `Verdana -> Verdana` การอ้างอิงที่เก็บไว้ยังคงไม่เปลี่ยนแปลง ในขณะที่ชื่อฟอนต์โดยตรงถูกส่งคืนตามเดิม หากส่วนข้อความใช้ `+mj-lt` จะแก้เป็น `Arial` ในธีมนี้

การแก้ไขการอ้างอิงธีมบ่งบอกฟอนต์ที่ธีมระบุ ไม่ได้ตรวจสอบว่าฟอนต์นั้นพร้อมใช้งานหรือกำหนดไฟล์ฟอนต์ที่ใช้จริงหลังการแทนที่หรือ fallback ของ glyph ระหว่างการเรนเดอร์ ดูที่ [Font Selection Sequence](/slides/th/net/font-selection-sequence/) และ [Font Substitution](/slides/th/net/font-substitution/) สำหรับขั้นตอนเหล่านั้น

## **คัดลอกหรือใช้ธีม**

กระบวนการต่อไปนี้แก้ปัญหาเรื่องธีมที่แตกต่างกัน

### **ใช้ธีมภายนอกกับสไลด์ที่ขึ้นกับมาสเตอร์**

ใช้ [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์ทุกสไลด์ที่ขึ้นกับมาสเตอร์เฉพาะ เลือกมาสเตอร์จากคอลเล็กชัน [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) ซึ่ง implements [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/) และส่งพาธไฟล์ธีมให้เมธอด

เมธอดทำการต่อไปนี้:

1. สร้างมาสเตอร์สไลด์ใหม่จากมาสเตอร์ที่เลือก  
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่  
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่เคยขึ้นกับมาสเตอร์ที่เลือก  
1. คืนค่า [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/) ที่สร้างใหม่  

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

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) หรือหนึ่งในคลาสย่อยที่เกี่ยวกับรูปแบบ ตรวจสอบพาธที่ผู้ใช้ระบุ, จัดการข้อผิดพลาดการเข้าถึงไฟล์ระบบ, และบันทึกการนำเสนอหลังจากธีมถูกใช้สำเร็จเท่านั้น  

เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือกเท่านั้นที่จะถูกกำหนดใหม่ สไลด์ที่เชื่อมกับมาสเตอร์อื่นจะรักษามาสเตอร์และธีมเดิมไว้ สี, ฟอนต์, การเติม, เส้น, พื้นหลัง, และเอฟเฟกต์ที่รับรู้ธีมจะได้รับการแก้ไขตามธีมภายนอก สี, ฟอนต์, การเติม, และการจัดรูปแบบอื่น ๆ ที่กำหนดโดยตรงอาจไม่เปลี่ยนแปลง การเขียนทับระดับเลย์เอาต์และสไลด์อาจมีลำดับความสำคัญเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่  

ธีมอาจอ้างอิงฟอนต์ที่ไม่มีในสภาพแวดล้อมรันไทม์ เพื่อให้การเรนเดอร์และการส่งออกสอดคล้องกัน ให้ติดตั้งฟอนต์ที่จำเป็น, จัดหาไฟล์ผ่าน [custom font sources](/slides/th/net/custom-font/), หรือกำหนดค่า [font substitution](/slides/th/net/font-substitution/)  

นี่เป็นกระบวนการระดับมาสเตอร์โดยตรง: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการเขียนทับธีมระดับสไลด์หรือเลย์เอาต์ด้วยตนเอง  

### **ใช้ธีมภายนอกที่ต่างกันในงานนำเสนอหลายมาสเตอร์**

เมื่อมาสเตอร์ที่เกี่ยวข้องไม่ทราบล่วงหน้า ให้นำมาจากสไลด์แทนที่ผ่าน [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) และ [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/) เก็บอ้างอิงมาสเตอร์ดั้งเดิมก่อนใช้ธีมใด ๆ เพราะแต่ละการเรียกจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ  

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

การเรียกครั้งแรกส่งผลเฉพาะสไลด์ที่ขึ้นกับ `firstGroupMaster` การเรียกครั้งที่สองส่งผลเฉพาะสไลด์ที่ขึ้นกับ `secondGroupMaster` สไลด์ที่เป็นของมาสเตอร์อื่นจะไม่ถูกปรับสไตล์  

### **คงธีมต้นฉบับเมื่อย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและคงการออกแบบเดิม ให้โคลนมาสเตอร์ต้นฉบับไปยังงานนำหมายด้วย [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) จากนั้นโคลนสไลด์ด้วย [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) และมาสเตอร์ที่โคลน นี้จะทำให้มาสเตอร์, เลย์เอาต์, และธีมที่เกี่ยวข้องเดินทางไปด้วยกัน  

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องดูเหมือนกันในปลายทาง การโคลนเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลง  

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องอยู่บนมาสเตอร์และเลย์เอาต์ปัจจุบัน ให้เริ่มต้นการเขียนทับระดับสไลด์จากธีมต้นฉบับ วิธี [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/), และ [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) คัดลอกส่วนประกอบธีมหลักสามส่วนไปยังการเขียนทับ  

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

การทำเช่นนี้จะเปลี่ยนธีมที่สไลด์ใช้โดยไม่เปลี่ยนธีมที่สืบทอดจากสไลด์อื่น ๆ เพื่อเอาการเขียนทับท้องถิ่นออกและกลับไปใช้ค่าที่สืบทอด ให้เรียก [OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/)  

### **ใช้การเขียนทับธีมกับเลย์เอาต์**

การเขียนทับระดับเลย์เอาต์ใช้กับสไลด์ที่ใช้เลย์เอาต์นั้น ยกเว้นกรณีที่สไลด์มีการเขียนทับของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/) ของเลย์เอาต์:

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

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ต้องการแชร์การออกแบบพื้นฐานเดียวกัน ใช้การเขียนทับเลย์เอาต์เมื่อครอบครัวเลย์เอาต์หนึ่งต้องการสไตล์ที่แตกต่าง และใช้การเขียนทับสไลด์เฉพาะกรณีพิเศษ การเขียนทับระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมทั่วโลกในภายหลังทำนายได้ยาก  

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกเก็บไว้ใน [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) PowerPoint สามารถแสดงตัวเลือกพื้นหลังเพิ่มเติมใน UI ของมันมากกว่าจำนวนการเติมที่ถูกเก็บในคอลเล็กชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ  

![แกลเลอรีสไตล์พื้นหลัง PowerPoint สำหรับธีมการนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ตรวจสอบคอลเล็กชันที่เก็บและ [Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/) ปัจจุบัน `StyleIndex` ใช้ค่า `0` สำหรับไม่มีการเติมธีม; ค่าบวกเป็นการอ้างอิงสไตล์พื้นหลังธีม นี่ต่างจากการใช้ดัชนีของคอลเล็กชัน .NET โดยตรงที่ `[0]` หมายถึงรายการแรกที่เก็บไว้ อย่าสันนิษฐานว่าการนำเสนอทุกอันมีจำนวนสไตล์การเติมพื้นหลังเท่ากัน  

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังธีมให้กับมาสเตอร์แรก, และบันทึกการนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการเขียนทับพื้นหลังที่ระดับเลย์เอาต์หรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนเฉพาะพื้นหลังมาสเตอร์อาจไม่เปลี่ยนสไลด์นั้น ใช้ [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) เมื่อต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอด  

{{% alert color="warning" title="Warning" %}}
อย่าใช้ `StyleIndex` เป็นดัชนีคอลเล็กชันที่เริ่มจากศูนย์ อย่าฮาร์ดโค้ดหมายเลขสไตล์จากไฟล์หนึ่งและสันนิษฐานว่ามันมีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ธีมเป็นเอกลักษณ์ของการนำเสนอ
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ให้ดูที่ [Presentation Background](/slides/th/net/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

สกีมฟอร์แมตของธีมมีคอลเล็กชันแยกต่างหากสำหรับ [FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/), และ [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/) โดยทั่วไปธีมของ Office มีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบแบบ Subtle, Moderate, และ Intense แต่โค้ดควรตรวจสอบแต่ละคอลเล็กชันแทนการสันนิษฐานว่ามีจำนวนคงที่  

![เอฟเฟกต์ธีม Subtle, Moderate, และ Intense ที่ใช้กับรูปร่างเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเล็กชันเหล่านี้ใน C# ดัชนีคอลเล็กชันเริ่มจากศูนย์: `[0]` คือสไตล์แรกที่เก็บและ `[2]` คือสไตล์ที่สาม รูปแบบอ้างอิงสไตล์ของรูปร่างเป็นแนวคิดแยกต่างหาก ที่เปิดเผยผ่าน [IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/) การแก้ไขสไตล์ธีมส่งผลต่อรูปร่างที่อ้างอิงสไตล์ธีมนั้น; รูปร่างที่มีการจัดรูปแบบโดยตรงอาจไม่เปลี่ยนแปลง  

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

สำหรับรูปร่างที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟกต์ที่สามจะมีเงานอกระยะ 10 pt ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นอยู่กับว่ารูปร่างอ้างอิงช่องสไตล์ใดและว่าการจัดรูปแบบโดยตรงเขียนทับธีมหรือไม่  

![สไตล์เอฟเฟกต์ธีมหลังจากการเปลี่ยนเส้น, เติม, และการตั้งค่าเงา](presentation-design_11.png)

## **เลือกสไตล์การเติมและเส้นของธีมสำหรับรูปร่าง**

รูปร่างสามารถเลือกการเติมและเส้นขอบของมันอย่างอิสระผ่าน [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) และ [LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/) สำหรับคุณสมบัติเช่นนี้ ดัชนี `1` เลือกรายการแรกในคอลเล็กชันธีมที่สอดคล้อง (`FillStyles[0]` หรือ `LineStyles[0]`), ดัชนี `2` เลือกรายการที่สอง  

ตัวอย่างต่อไปนี้ตั้งค่าสไตล์การเติมสองแบบ (ทองและฟ้าฟ้า) และสไตล์เส้นสองแบบ (สีน้ำเงินเข้ม 6 pt และสีแดงเข้ม 12 pt) ในธีมเริ่มต้นของการนำเสนอใหม่ จะบันทึกสไลด์ในสามขั้นตอนเพื่อให้คุณเปรียบเทียบผลใน PowerPoint  

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var styles = presentation.MasterTheme.FormatScheme;

var goldFill = styles.FillStyles[0];
goldFill.FillType = FillType.Solid;
goldFill.SolidFillColor.Color = Color.Gold;
var blueFill = styles.FillStyles[1];
blueFill.FillType = FillType.Solid;
blueFill.SolidFillColor.Color = Color.SkyBlue;

var thinLine = styles.LineStyles[0];
thinLine.FillFormat.FillType = FillType.Solid;
thinLine.FillFormat.SolidFillColor.Color = Color.DarkBlue;
thinLine.Width = 6;
var thickLine = styles.LineStyles[1];
thickLine.FillFormat.FillType = FillType.Solid;
thickLine.FillFormat.SolidFillColor.Color = Color.DarkRed;
thickLine.Width = 12;

var shapes = presentation.Slides[0].Shapes;
var left = shapes.AddAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
var right = shapes.AddAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
left.ShapeStyle.FillStyleIndex = 1;
right.ShapeStyle.FillStyleIndex = 2;
left.ShapeStyle.LineStyleIndex = 1;
right.ShapeStyle.LineStyleIndex = 1;
presentation.Save("01-initial.pptx", SaveFormat.Pptx);

right.ShapeStyle.LineStyleIndex = 2;
presentation.Save("02-line-changed.pptx", SaveFormat.Pptx);

goldFill.SolidFillColor.Color = Color.SeaGreen;
presentation.Save("03-theme-changed.pptx", SaveFormat.Pptx);
```

| สไตล์เริ่มต้น | เปลี่ยนเส้นขอบขวา | แก้ไขสไตล์เติมธีมแรก |
|:---:|:---:|:---:|
| ![สี่เหลี่ยมสีทองและสีน้ำเงินฟ้าใส่เส้นขอบสีฟ้าเข้มบางที่ตรงกัน](theme-style-initial.png) | ![สี่เหลี่ยมสีน้ำเงินฟ้าเดี๋ยวนี้มีเส้นขอบสีแดงเข้มหนา](theme-style-line-changed.png) | ![สี่เหลี่ยมซ้ายตอนนี้เป็นสีเขียวและเส้นขอบทั้งสองคงเดิม](theme-style-fill-changed.png) |

การเลือกสไตล์เส้นที่ต่างกันจะเปลี่ยนเส้นขอบของสี่เหลี่ยมขวาเท่านั้น การแก้ไขสไตล์เติมธีมแรกจะอัปเดตทุกรูปร่างที่ใช้สไตล์นั้น ที่นี่สี่เหลี่ยมซ้ายเท่านั้นที่เปลี่ยนเป็นสีเขียว  

บนรูปร่างที่มีอยู่ สีเติมท้องถิ่น, สีเส้น, หรือความกว้างเส้นสามารถเขียนทับสไตล์ธีมส่วนนั้นได้ หากการเปลี่ยนดัชนีสไตล์ไม่มีผลปรากฏ ให้ตรวจสอบ [direct formatting](/slides/th/net/shape-formatting/)

## **ตรวจสอบว่าการเติมแบบทึบที่มีผลใช้สีธีมหรือไม่**

การเติมอาจถูกเก็บโดยตรงบนอ็อบเจกต์หรือสืบทอดจากย่อหน้า, เลย์เอาต์, มาสเตอร์, สไตล์ธีม, หรือระดับการจัดรูปแบบอื่น ๆ เรียก [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/) เพื่อแก้ลำดับชั้นนี้เป็น [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/) ที่ไม่เปลี่ยนแปลง ก่อนตรวจสอบ [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/) เฉพาะเมื่อเป็น `FillType.Solid` จึงอ่านคุณสมบัติการเติมแบบทึบ  

สำหรับการเติมแบบทึบ [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) คืนค่ารหัส RGB ขั้นสุดท้ายหลังจากสืบทอด, ค้นหาธีม, และแปลงสี [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) คืนช่อง [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) ที่สอดคล้อง เช่น `Text1` หรือ `Accent6` ค่า `SchemeColor.NotDefined` หมายถึงการเติมแบบทึบที่มีผลไม่ได้อิงจากสีสคีม ในเวิร์กโฟลว์ที่การเติมเป็นสีธีมหรือสี RGB แบบตรง ค่าเหล่านี้บ่งชี้การเติม RGB โดยตรง  

อย่าเพียงพิจารณาค่า [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) ในระดับท้องถิ่นเพื่อจำแนกการเติม ตัวอย่างเช่น ส่วนข้อความอาจไม่มีสีสคีมระดับท้องถิ่น จึงค่า `NotDefined` แต่การเติมที่มีผลอาจสืบทอดสีธีมและแก้เป็น `Text1` หรือ `Accent6` อีกด้าน `SolidFillSchemeColor` บอกว่าช่องธีมใดได้สร้างสีที่มีผล แต่ไม่บอกว่าช่องนั้นมาจากอ็อบเจกต์, ย่อหน้า, เลย์เอาต์, มาสเตอร์ หรือระดับอื่น  

ตัวอย่างต่อไปนี้โหลดการนำเสนอ, ตรวจสอบการเติมของรูปร่างและส่วนข้อความ, พิมพ์ค่ารหัส RGB สุดท้ายและสคีมที่เกี่ยวข้อง, และทำเครื่องหมายการเติมแบบทึบที่ไม่ตอบสนองต่อการเปลี่ยนสีธีม:

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

สาขา `NotDefined` ให้รายการตรวจสอบการเติมแบบทึบที่ไม่ตอบสนองต่อการเปลี่ยนแปลงในช่องสีธีม ตรวจสอบอ็อบเจกต์เหล่านั้นเมื่อการนำเสนอจำเป็นต้องปฏิบัติตามพาเล็ทแบรนด์ใหม่ ค่า RGB ที่แสดงยังคงเป็นลักษณะปัจจุบัน ส่วนค่าสคีมอธิบายว่าลักษณะนั้นเชื่อมต่อกับธีมหรือไม่  

อ็อบเจกต์ที่ได้จากการอ่านค่าที่มีผลเป็นสแนปชอต หลังจากเปลี่ยนธีมการนำเสนอ, การเขียนทับธีม, หรือการจัดรูปแบบที่สืบทอดใด ๆ ให้เรียก `GetEffective` อีกครั้งและอ่านอ็อบเจกต์ `IFillFormatEffectiveData` ใหม่ก่อนเปรียบเทียบหรือรายงานสี  

## **อ่านค่าธีมที่มีผล**

อ็อบเจกต์ธีมดิบบอกว่ามีการกำหนดอะไรที่ระดับหนึ่ง ส่วนค่าที่มีผลบอกว่าสไลด์หรือรูปร่างใช้อะไรจริงหลังจากการสืบทอดและการเขียนทับค่าท้องถิ่นถูกแก้ไข สำหรับสไลด์ ให้เรียก [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) สำหรับพื้นหลัง ใช้ [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) และสำหรับการเติม ใช้ [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/)  

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมของรูปแรกจากสไลด์:

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

ใช้ข้อมูลที่มีผลเพื่อการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเพียง [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/) คุณอาจพลาดมาสเตอร์, เลย์เอาต์, สไลด์, หรือการเขียนทับของรูปร่างที่เปลี่ยนลักษณะสุดท้าย  

## **คำถามที่พบบ่อย**

**การใช้ธีมภายนอกส่งผลต่อทุกสไลด์ในงานนำเสนอหรือไม่?**  
ไม่ ตัวเมธอด [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) จะกำหนดใหม่เฉพาะสไลด์ที่ขึ้นกับมาสเตอร์ที่เลือก สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิมไว้  

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**  
ได้ ใช้ [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) ของสไลด์และเริ่มต้นการเขียนทับธีม การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมเดิม  

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งคืออะไร?**  
เมื่อย้ายสไลด์และคงลักษณะต้นฉบับ ให้โคลนมาสเตอร์ต้นฉบับไปยังปลายทางและโคลนสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) และ [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) วิธีนี้ทำให้มาสเตอร์, เลย์เอาต์, และธีมคงอยู่ด้วยกัน  

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการเขียนทับได้อย่างไร?**  
ใช้ [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) สำหรับสไลด์หรือเลย์เอาต์ธีมและเมธอดข้อมูลที่มีผลที่สอดคล้องสำหรับอ็อบเจกต์รูปแบบ เช่น [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) และ [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/) API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการเขียนทับถูกนำไปใช้  