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
- สีธีม
- พาเลตเพิ่มเติม
- แบบอักษรธีม
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

ธีมการนำเสนอกำหนดคุณสมบัติขององค์ประกอบการออกแบบ เมื่อคุณเลือกธีมการนำเสนอ คุณกำลังเลือกชุดขององค์ประกอบภาพและคุณสมบัติเฉพาะของมัน

ใน PowerPoint ธีมประกอบด้วยสี, [แบบอักษร](/slides/th/net/powerpoint-fonts/), [สไตล์พื้นหลัง](/slides/th/net/presentation-background/), และเอฟเฟกต์

![theme-constituents](theme-constituents.png)

## **เปลี่ยนสีธีม**

ธีม PowerPoint ใช้ชุดสีเฉพาะสำหรับองค์ประกอบต่าง ๆ บนสไลด์ หากคุณไม่พอใจกับสีเหล่านั้น คุณสามารถเปลี่ยนสีได้โดยการใช้สีใหม่สำหรับธีม เพื่อให้คุณเลือกสีธีมใหม่ Aspose.Slides ให้ค่าต่าง ๆ ภายใต้การอธิบาย [SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/schemecolor/) 

โค้ด C# นี้แสดงวิธีเปลี่ยนสีเน้นสำหรับธีม:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

คุณสามารถกำหนดค่าที่มีผลของสีที่ได้ด้วยวิธีนี้:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (สี [A=255, R=128, G=100, B=162])
}
```

เพื่อสาธิตการเปลี่ยนสีเพิ่มเติม เราสร้างองค์ประกอบใหม่และกำหนดสีเน้น (จากการดำเนินการแรก) ให้กับมัน จากนั้นเราจะเปลี่ยนสีในธีม:

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

สีใหม่จะถูกนำไปใช้โดยอัตโนมัติบนทั้งสององค์ประกอบ

### **ตั้งค่าสีธีมจากพาเลตเพิ่มเติม**

เมื่อคุณทำการแปลงความสว่างของสีธีมหลัก(1) สีจากพาเลตเพิ่มเติม(2) จะถูกสร้างขึ้น จากนั้นคุณสามารถกำหนดและดึงค่าสีธีมเหล่านั้นได้

![additional-palette-colors](additional-palette-colors.png)

**1** - สีธีมหลัก  
**2** - สีจากพาเลตเพิ่มเติม

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // สีเน้น 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // สีเน้น 4, สว่างขึ้น 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // สีเน้น 4, สว่างขึ้น 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // สีเน้น 4, สว่างขึ้น 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // สีเน้น 4, มืดลง 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // สีเน้น 4, มืดลง 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **แม็ป `SchemeColor` ไปยังสี `IColorScheme`**

เมื่อคุณทำงานกับ [SchemeColor](https://reference.aspose.com/slides/th/net/aspose.slides/schemecolor/), คุณอาจสังเกตว่ามันมีค่าของสีธีมต่อไปนี้:

`Background1`, `Background2`, `Text1`, and `Text2`.

อย่างไรก็ตาม `Presentation.MasterTheme.ColorScheme` จะคืนค่า [IColorScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/icolorscheme/), ซึ่งเปิดเผยสีที่สอดคล้องเป็น:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

ความแตกต่างนี้เป็นเพียงเรื่องชื่อเท่านั้น ค่าเหล่านี้อ้างอิงถึงช่องสีธีมเดียวกันและการแมพถูกกำหนดไว้คงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ไม่มีการแปลงแบบไดนามิกระหว่าง `Text`/`Background` กับ `Dark`/`Light` พวกมันเป็นชื่อทางเลือกของสีธีมเดียวกันเท่านั้น

ความแตกต่างของชื่อเหล่านี้มาจากศัพท์ของ Microsoft Office เวอร์ชันเก่าใช้ `Dark 1`, `Light 1`, `Dark 2`, `Light 2` ขณะที่ UI รุ่นใหม่แสดงช่องเดียวกันเป็น `Text 1`, `Background 1`, `Text 2`, `Background 2`.

## **เปลี่ยนแบบอักษรธีม**

เพื่อให้คุณเลือกแบบอักษรสำหรับธีมและการใช้งานอื่น ๆ Aspose.Slides ใช้ตัวระบุตัวพิเศษเหล่านี้ (คล้ายกับที่ใช้ใน PowerPoint):

* **+mn-lt** - แบบอักษรเนื้อหา Latin (Minor Latin Font)
* **+mj-lt** - แบบอักษรหัวเรื่อง Latin (Major Latin Font)
* **+mn-ea** - แบบอักษรเนื้อหา East Asian (Minor East Asian Font)
* **+mj-ea** - แบบอักษรหัวเรื่อง East Asian (Minor East Asian Font)

โค้ด C# นี้แสดงวิธีกำหนดแบบอักษร Latin ให้กับองค์ประกอบธีม:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

โค้ด C# นี้แสดงวิธีเปลี่ยนแบบอักษรธีมการนำเสนอ:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

แบบอักษรในกล่องข้อความทั้งหมดจะถูกอัปเดต

{{% alert color="info" title="TIP" %}} 
คุณอาจต้องการดู [แบบอักษร PowerPoint](/slides/th/net/powerpoint-fonts/).
{{% /alert %}}

## **เปลี่ยนสไตล์พื้นหลังธีม**

โดยค่าเริ่มต้น แอป PowerPoint จะให้พื้นหลังที่กำหนดล่วงหน้า 12 แบบ แต่ในงานนำเสนอทั่วไปจะบันทึกเพียง 3 แบบจาก 12 แบบเท่านั้น

![todo:image_alt_text](presentation-design_8.png)

ตัวอย่างเช่น หลังจากคุณบันทึกงานนำเสนอในแอป PowerPoint คุณสามารถรันโค้ด C# นี้เพื่อตรวจสอบจำนวนพื้นหลังที่กำหนดล่วงหน้าในงานนำเสนอ:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
โดยใช้คุณสมบัติ [BackgroundFillStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/) คุณสามารถเพิ่มหรือเข้าถึงสไตล์พื้นหลังในธีม PowerPoint ได้.
{{% /alert %}}

โค้ด C# นี้แสดงวิธีตั้งค่าพื้นหลังสำหรับงานนำเสนอ:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**คำแนะนำดัชนี**: 0 ใช้สำหรับไม่มีการเติม สี ดัชนีเริ่มจาก 1

{{% alert color="info" title="TIP" %}} 
คุณอาจต้องการดู [พื้นหลัง PowerPoint](/slides/th/net/presentation-background/).
{{% /alert %}}

## **เปลี่ยนเอฟเฟกต์ธีม**

ธีม PowerPoint ปกติมีค่า 3 ค่าในแต่ละอาร์เรย์สไตล์ อาร์เรย์เหล่านั้นจะถูกรวมเป็น 3 เอฟเฟกต์: เบา, ปานกลาง, และเข้ม ตัวอย่างเช่น นี่คือผลลัพธ์เมื่อเอฟเฟ็กต์ถูกนำไปใช้กับรูปทรงเฉพาะ:

![todo:image_alt_text](presentation-design_10.png)

โดยใช้ 3 คุณสมบัติ ([FillStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme/effectstyles)) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/formatscheme) คุณสามารถเปลี่ยนแปลงองค์ประกอบในธีมได้ (ยืดหยุ่นกว่าตัวเลือกใน PowerPoint)

โค้ด C# นี้แสดงวิธีเปลี่ยนเอฟเฟกต์ธีมโดยการเปลี่ยนส่วนขององค์ประกอบ:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

การเปลี่ยนแปลงที่เกิดขึ้นในสีเติม, ชนิดการเติม, เงา, ฯลฯ:

![todo:image_alt_text](presentation-design_11.png)

## **คำถามที่พบบ่อย**

### ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?

ใช่. Aspose.Slides รองรับการแทนที่ธีมระดับสไลด์ ดังนั้นคุณสามารถใส่ธีมท้องถิ่นให้สไลด์นั้นโดยยังคงธีมมาสเตอร์เอาไว้ (ผ่าน [SlideThemeManager](https://reference.aspose.com/slides/th/net/aspose.slides.theme/slidethememanager/))

### วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานหนึ่งคืออะไร?

ให้ทำการ [Clone slides](/slides/th/net/clone-slides/) พร้อมกับมาสเตอร์ของพวกมันไปยังงานนำเป้าหมาย วิธีนี้จะคงมาสเตอร์, เค้าโครง, และธีมที่เกี่ยวข้องไว้ ทำให้ลักษณะการแสดงผลคงที่

### ฉันจะดูค่าที่ "effective" หลังจากการสืบทอดและการแทนที่ทั้งหมดได้อย่างไร?

ใช้มุมมอง ["effective"](/slides/th/net/shape-effective-properties/) ของ API สำหรับธีม/สี/แบบอักษร/เอฟเฟกต์ ซึ่งจะคืนค่าคุณสมบัติสุดท้ายที่ได้จากการผสานมาสเตอร์และการแทนที่ท้องถิ่น.