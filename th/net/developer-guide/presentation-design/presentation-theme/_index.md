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
- กำหนดธีม
- เปลี่ยนธีม
- จัดการธีม
- สีธีม
- พาเลตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟ็กต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ .NET เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สม่ำเสมอ."
---
## **บทนำ**

ธีมการนำเสนอกำหนดคุณสมบัติขององค์ประกอบการออกแบบ เมื่อคุณเลือกธีมการนำเสนอ คุณกำลังเลือกชุดขององค์ประกอบภาพและคุณสมบัติเฉพาะของมัน

ใน PowerPoint ธีมประกอบด้วยสี, [ฟอนต์](/slides/th/net/powerpoint-fonts/), [สไตล์พื้นหลัง](/slides/th/net/presentation-background/), และเอฟเฟกต์

![theme-constituents](theme-constituents.png)

## **เปลี่ยนสีธีม**

ธีม PowerPoint ใช้ชุดสีเฉพาะสำหรับองค์ประกอบต่าง ๆ ในสไลด์ หากคุณไม่ชอบสีเหล่านั้น คุณสามารถเปลี่ยนสีโดยกำหนดสีใหม่ให้กับธีม เพื่อให้คุณเลือกสีธีมใหม่ Aspose.Slides มีค่าสีให้เลือกภายใต้ enumeration [SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/schemecolor/)

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

คุณสามารถกำหนดค่าที่มีผลของสีที่ได้โดยวิธีนี้:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (สี [A=255, R=128, G=100, B=162])
```

เพื่อสาธิตการเปลี่ยนสีเพิ่มเติม เราจะสร้างองค์ประกอบใหม่และกำหนดสี accent (จากการดำเนินการครั้งแรก) ให้กับมัน จากนั้นเปลี่ยนสีในธีม:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

สีใหม่จะถูกนำไปใช้โดยอัตโนมัติบนทั้งสององค์ประกอบ

### **กำหนดสีธีมจากพาเลตเพิ่มเติม**

เมื่อคุณใช้การแปลงความสว่างกับสีธีมหลัก(1) จะได้สีจากพาเลตเพิ่มเติม(2) แล้วคุณสามารถตั้งค่าและดึงค่าสีธีมเหล่านั้นได้

![additional-palette-colors](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - สีจากพาเลตเพิ่มเติม

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // สี Accent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // สี Accent 4, สว่างขึ้น 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // สี Accent 4, สว่างขึ้น 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // สี Accent 4, สว่างขึ้น 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // สี Accent 4, มืดลง 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // สี Accent 4, มืดลง 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **แมป `SchemeColor` ไปยังสี `IColorScheme`**

เมื่อคุณทำงานกับ [SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/schemecolor/) คุณอาจสังเกตว่ามีค่าธีมสีต่อไปนี้:

`Background1`, `Background2`, `Text1`, และ `Text2`.

อย่างไรก็ตาม `Presentation.MasterTheme.ColorScheme` คืนค่า [IColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/icolorscheme/) ซึ่งเผยสีที่สอดคล้องกันเป็น:

`Dark1`, `Dark2`, `Light1`, และ `Light2`.

ความแตกต่างนี้เป็นเพียงชื่อเท่านั้น ค่าดังกล่าวอ้างอิงถึงช่องสีธีมเดียวกันและการแมปคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ไม่มีการแปลงแบบไดนามิกระหว่าง `Text`/`Background` และ `Dark`/`Light` เพียงแค่ชื่อที่ต่างกันสำหรับสีธีมเดียวกัน

ความแตกต่างของชื่อมาจากคำศัพท์ของ Microsoft Office รุ่นเก่าใช้ `Dark 1`, `Light 1`, `Dark 2`, `Light 2` ส่วน UI รุ่นใหม่แสดงช่องเดียวกันเป็น `Text 1`, `Background 1`, `Text 2`, `Background 2`

## **เปลี่ยนฟอนต์ธีม**

เพื่อให้คุณเลือกฟอนต์สำหรับธีมและวัตถุประสงค์อื่น ๆ Aspose.Slides ใช้ตัวระบุพิเศษเหล่านี้ (คล้ายกับที่ใช้ใน PowerPoint):

* **+mn-lt** - ฟอนต์ตัวอักษรหลัก Latin (Minor Latin Font)
* **+mj-lt** - ฟอนต์หัวเรื่อง Latin (Major Latin Font)
* **+mn-ea** - ฟอนต์ตัวอักษรหลัก East Asian (Minor East Asian Font)
* **+mj-ea** - ฟอนต์หัวเรื่อง East Asian (Major East Asian Font)

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

ฟอนต์ในทุกกล่องข้อความจะได้รับการอัปเดต

{{% alert color="primary" title="TIP" %}} 
คุณอาจต้องการดู [ฟอนต์ใน PowerPoint](/slides/th/net/powerpoint-fonts/).
{{% /alert %}}

## **เปลี่ยนสไตล์พื้นหลังธีม**

โดยค่าเริ่มต้น แอป PowerPoint มีพื้นหลังที่กำหนดไว้ล่วงหน้า 12 แบบ แต่เพียง 3 แบบจาก 12 แบบนั้นจะถูกบันทึกในงานนำเสนอปกติ

![todo:image_alt_text](presentation-design_8.png)

ตัวอย่าง หลังจากคุณบันทึกงานนำเสนอในแอป PowerPoint คุณสามารถรันโค้ด C# นี้เพื่อค้นหาจำนวนพื้นหลังที่กำหนดไว้ล่วงหน้าในงานนำเสนอได้:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
โดยใช้คุณสมบัติ [BackgroundFillStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/) คุณสามารถเพิ่มหรือเข้าถึงสไตล์พื้นหลังในธีม PowerPoint ได้
{{% /alert %}}

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**คู่มือดัชนี**: 0 ใช้สำหรับไม่มีการเติม ดัชนีเริ่มจาก 1

{{% alert color="primary" title="TIP" %}} 
คุณอาจต้องการดู [พื้นหลัง PowerPoint](/slides/th/net/presentation-background/).
{{% /alert %}}

## **เปลี่ยนเอฟเฟ็กต์ธีม**

ธีม PowerPoint ปกติมีค่าที่กำหนดไว้ 3 ค่าในแต่ละอาเรย์สไตล์ ซึ่งอาเรย์เหล่านี้รวมกันเป็น 3 เอฟเฟ็กต์: Subtle, Moderate, และ Intense ตัวอย่างผลลัพธ์เมื่อเอฟเฟ็กต์ถูกนำไปใช้กับรูปร่างเฉพาะ:

![todo:image_alt_text](presentation-design_10.png)

โดยใช้คุณสมบัติ 3 อย่าง ([FillStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/effectstyles)) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme) คุณสามารถเปลี่ยนองค์ประกอบในธีมได้อย่างยืดหยุ่นกว่าตัวเลือกใน PowerPoint

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

การเปลี่ยนแปลงที่เกิดขึ้นในสีเติม, ประเภทการเติม, เอฟเฟ็กต์เงา ฯลฯ:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้ Aspose.Slides รองรับการแทนที่ธีมระดับสไลด์ ดังนั้นคุณสามารถใช้ธีมเฉพาะกับสไลด์นั้นได้โดยคงธีมมาสเตอร์ไว้ (ผ่าน [SlideThemeManager](https://reference.aspose.com/slides/th/net/aspose.slides.theme/slidethememanager/))

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานหนึ่งคืออะไร?**

[ค Clone slides](/slides/th/net/clone-slides/) พร้อมกับมาสเตอร์ของมันไปยังงานนำเป้าหมาย จะรักษามาสเตอร์, เลย์เอาต์ และธีมที่สัมพันธ์กันเพื่อให้รูปลักษณ์คงที่

**ฉันจะดูค่าที่ “effective” หลังจากการสืบทอดและการแทนที่ทั้งหมดได้อย่างไร?**

ใช้ ["effective" views](/slides/th/net/shape-effective-properties/) ของ API สำหรับธีม/สี/ฟอนต์/เอฟเฟ็กต์ ซึ่งจะคืนค่าคุณสมบัติสุดท้ายที่ได้หลังจากนำมาสเตอร์มารวมกับการแทนที่ระดับท้องถิ่น.