---
title: จัดการสไลด์มาสเตอร์ใน .NET
linktitle: สไลด์มาสเตอร์
type: docs
weight: 80
url: /th/net/slide-master/
keywords:
- มาสเตอร์สไลด์
- สไลด์มาสเตอร์
- สไลด์มาสเตอร์ PPT
- หลายสไลด์มาสเตอร์
- เปรียบเทียบสไลด์มาสเตอร์
- พื้นหลัง
- ตำแหน่งตัวอักษร
- คัดลอกสไลด์มาสเตอร์
- ทำสำเนาสไลด์มาสเตอร์
- ทำซ้ำสไลด์มาสเตอร์
- สไลด์มาสเตอร์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการสไลด์มาสเตอร์ใน Aspose.Slides สำหรับ .NET: เข้าถึง, แก้ไข, คัดลอก, เปรียบเทียบและลบสไลด์มาสเตอร์ในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

**สไลด์มาสเตอร์** กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์หนึ่งกลุ่ม สามารถประกอบด้วยรูปทรงทั่วไป โลโก้ พื้นหลัง สไตล์ข้อความ การตั้งค่าธีม และการตั้งค่าเท้า (footer) ได้ ใน PowerPoint การแก้ไขสไลด์มาสเตอร์เป็นวิธีปกติที่ทำให้การนำเสนอมีความสอดคล้องโดยไม่ต้องทำรูปแบบเดียวกันซ้ำในแต่ละสไลด์

Aspose.Slides for .NET รองรับโมเดลเดียวกัน การนำเสนอสามารถมีสไลด์มาสเตอร์หนึ่งหรือหลายสไลด์ และแต่ละสไลด์มาสเตอร์สามารถมีสไลด์เลย์เอาต์หลายสไลด์ สไลด์ปกติทั่วไปจะไม่ได้อ้างอิงสไลด์มาสเตอร์โดยตรง แต่จะใช้สไลด์เลย์เอาต์ และสไลด์เลย์เอาต์นั้นเป็นส่วนหนึ่งของสไลด์มาสเตอร์

ลำดับขั้นคือ:

1. **สไลด์มาสเตอร์** – กำหนดการออกแบบและธีมที่ใช้ร่วมกัน  
1. **สไลด์เลย์เอาต์** – กำหนดการจัดเรียงเฉพาะของ placeholder และการจัดรูปแบบระดับเลย์เอาต์  
1. **สไลด์ปกติ** – ประกอบด้วยเนื้อหาการนำเสนอจริงและใช้สไลด์เลย์เอาต์หนึ่งสไลด์

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

ใน Aspose.Slides สไลด์มาสเตอร์ถูกแทนด้วยอินเทอร์เฟซ [IMasterSlide](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/) ทั้งหมดของสไลด์มาสเตอร์ในงานนำเสนอสามารถเข้าถึงได้ผ่านคอลเลกชัน [Presentation.Masters](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/masters/) ซึ่งทำงานตาม [IMasterSlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/)

{{% alert color="info" title="การสืบทอด" %}}

เมื่อคุณสมบัติเกิดขึ้นในหลายระดับ ระดับที่เจาะจงมากกว่าจะชนะ ตัวอย่างเช่น หากสไลด์มาสเตอร์และสไลด์เลย์เอาต์กำหนดพื้นหลังร่วมกัน สไลด์ที่สร้างจากเลย์เอาต์นั้นจะใช้พื้นหลังของเลย์เอาต์ รายละเอียดเพิ่มเติมเกี่ยวกับสไลด์เลย์เอาต์ ดูที่ [Apply or Change Slide Layouts](/slides/th/net/slide-layout/)

{{% /alert %}}

## **การเข้าถึงสไลด์มาสเตอร์**

ใน PowerPoint คุณสามารถเปิดมุมมองสไลด์มาสเตอร์ได้จาก **View** > **Slide Master**

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

ใน Aspose.Slides ใช้คอลเลกชัน `Masters` เพื่อเข้าถึงสไลด์มาสเตอร์:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

คุณยังสามารถดึงสไลด์มาสเตอร์ที่สไลด์ปกติใช้ผ่านเลย์เอาต์ของมันได้:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **สไลด์มาสเตอร์ประกอบด้วยอะไร**

สไลด์มาสเตอร์เป็นอ็อบเจ็กต์คล้ายสไลด์ มันทำตาม [IBaseSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/) ดังนั้นจึงเปิดเผยคุณสมบัติของสไลด์หลายอย่างที่ใช้โดยสไลด์ปกติและเลย์เอาต์ สมาชิกเฉพาะสไลด์มาสเตอร์ถูกระบุในหน้ API ของ [IMasterSlide](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/)

สมาชิกสไลด์มาสเตอร์ที่ใช้งานบ่อยรวมถึง:

| สมาชิก | จุดประสงค์ |
| --- | --- |
| `Background` | ตั้งค่าพื้นหลังระดับมาสเตอร์ของสไลด์ |
| `Shapes` | เก็บรูปทรงที่วางบนมาสเตอร์ เช่น โลโก้ เฟรมรูปภาพ และข้อความที่แชร์ |
| `LayoutSlides` | เก็บสไลด์เลย์เอาต์ที่เป็นส่วนหนึ่งของมาสเตอร์ |
| `ThemeManager` | ให้เข้าถึง API ของธีมมาสเตอร์ |
| `HeaderFooterManager` | ควบคุมส่วนหัว ส่วนท้าย วันที่ และหมายเลขสไลด์สำหรับมาสเตอร์และเลย์เออต์ลูก |
| `GetDependingSlides` | คืนค่าสไลด์ปกติที่พึ่งพามาสเตอร์ผ่านเลย์เอาต์ของมัน |

## **เพิ่มรูปภาพลงในสไลด์มาสเตอร์**

เมื่อคุณเพิ่มรูปภาพลงในสไลด์มาสเตอร์ มันจะปรากฏบนสไลด์ที่ใช้เลย์เอาต์จากมาสเตอร์นั้น ใช้สำหรับโลโก้, ลายน้ำ, แถบตกแต่ง, และองค์ประกอบภาพที่ต้องการทำซ้ำ

ตัวอย่างต่อไปนี้เพิ่มโลโก้ลงในสไลด์มาสเตอร์แรก:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับเฟรมรูปภาพ ดูที่ [Picture Frame](/slides/th/net/picture-frame/)

## **ควบคุมการมองเห็นของกราฟิกมาสเตอร์**

ใช้ [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/showmastershapes/) เพื่อซ่อนกราฟิกมาสเตอร์ที่สืบทอดมา เช่น โลโก้หรือรูปทรงตกแต่ง โดยไม่ต้องลบออกจากมาสเตอร์ ตั้งค่า [Slide.ShowMasterShapes](https://reference.aspose.com/slides/th/net/aspose.slides/slide/showmastershapes/) เป็น `false` บนสไลด์ที่ต้องการละเว้นกราฟิกเหล่านั้น และให้ค่า `true` บนสไลด์ที่ต้องการแสดง

ตัวอย่างต่อไปนี้สร้างแถบตกแต่งสีน้ำเงินบนมาสเตอร์และสไลด์สองสไลด์ที่ใช้เลย์เอาต์เปล่าเดียวกัน แถบแสดงบนสไลด์แรกแต่ซ่อนบนสไลด์ที่สอง ไม่ต้องมีงานนำเสนอหรือรูปภาพอินพุตใด ๆ

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

ตัวอย่างใช้เลย์เอาต์ **Blank** ที่มากับงานนำเสนอใหม่และลบ placeholder ของสไลด์แรกออก

### **เลือกช่วงของการตั้งค่า**

สไลด์ปกติใช้มาสเตอร์ของมันผ่าน [ISlide.LayoutSlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/layoutslide/) และ [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/masterslide/)。การตั้งค่าคุณสมบัติบนสไลด์เดี่ยวจะส่งผลต่อสไลด์นั้นเท่านั้น การตั้งค่า [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/th/net/aspose.slides/layoutslide/showmastershapes/) เป็น `false` จะซ่อนกราฟิกมาสเตอร์สำหรับสไลด์ทั้งหมดที่ใช้เลย์เอาต์นั้น แม้ว่าการตั้งค่าบนสไลด์ของตนเองจะเป็น `true` ก็ตาม หากต้องการซ่อนกราฟิกบนสไลด์เดียวให้เปลี่ยนคุณสมบัติของสไลด์นั้นและคงเลย์เอาต์ที่แชร์ไว้เดิม

การตั้งค่านี้ไม่ได้รับการสนับสนุนเป็นการควบคุมการมองเห็นบนสไลด์มาสเตอร์เอง บนมาสเตอร์จะคืนค่า `false` เสมอ และการกำหนดค่าเป็น `true` จะทำให้เกิด `NotSupportedException` ให้ใช้กับสไลด์ปกติหรือเลย์เอาต์แทน

### **แยกแยะกราฟิกจากพื้นหลัง**

| การกระทำ | ผลลัพธ์ |
| --- | --- |
| ซ่อนกราฟิกมาสเตอร์ | ควบคุมการมองเห็นของรูปทรงมาสเตอร์ที่สืบทอดมาโดยไม่ลบหรือเปลี่ยนรูปทรงของสไลด์เอง |
| เปลี่ยนการเติมสีพื้นหลังของสไลด์ | เปลี่ยนสี, การไล่สี, หรือรูปภาพพื้นหลัง รูปทรงมาสเตอร์เป็นรูปทรงแยกต่างหากและสามารถมองเห็นอยู่เหนือพื้นหลังนั้นได้ ดูที่ [Presentation Background](/slides/th/net/presentation-background/) |
| ลบรูปทรงจากมาสเตอร์ | ลบรูปทรงต้นฉบับที่แชร์ ทำให้ไม่สามารถใช้ได้กับสไลด์ใด ๆ ที่ใช้มาสเตอร์นั้นต่อไป |

## **ทำงานกับ Placeholder**

Placeholder ปกติจะกำหนดบนสไลด์เลย์เอาต์ มาสเตอร์ให้สไตล์และธีมที่เลย์เอาต์สืบทอด ส่วนแต่ละเลย์เอาต์จะกำหนดว่า placeholder ใดบ้างที่พร้อมใช้งานและตำแหน่งของมัน

ใน PowerPoint คำสั่ง placeholder พบได้ในมุมมอง Slide Master

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

เพื่อเพิ่ม placeholder ใหม่ด้วย Aspose.Slides ให้ทำงานกับสไลด์เลย์เอาต์ที่เป็นส่วนหนึ่งของมาสเตอร์:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

คุณยังสามารถจัดรูปแบบรูปทรง placeholder ที่มีอยู่บนสไลด์มาสเตอร์ได้ ตัวอย่างต่อไปนี้ค้นหา placeholder ของหัวเรื่องและใช้การเติมสีน้ำสีไลเนียร:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

สำหรับตัวเลือกการจัดรูปแบบ placeholder และข้อความเพิ่มเติม ดูที่ [Set Prompt Text in Placeholder](/slides/th/net/manage-placeholder/) และ [Text Formatting](/slides/th/net/text-formatting/)

## **เปลี่ยนพื้นหลังของสไลด์มาสเตอร์**

พื้นหลังมาสเตอร์จะสืบทอดไปยังเลย์เอาต์และสไลด์ที่ไม่ได้กำหนดทับ ตัวอย่างต่อไปนี้ตั้งค่าสีพื้นหลังแบบทึบสำหรับสไลด์มาสเตอร์แรก:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

หัวข้อที่เกี่ยวข้อง ดูที่ [Presentation Background](/slides/th/net/presentation-background/) และ [Presentation Theme](/slides/th/net/presentation-theme/)

## **คัดลอกสไลด์มาสเตอร์ไปยังงานนำเสนออื่น**

ใช้ [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/addclone/) เพื่อคัดลอกสไลด์มาสเตอร์ไปยังงานนำเสนออื่น มาสเตอร์ที่คัดลอกแล้วสามารถใช้โดยเลย์เอาต์และสไลด์ในงานนำหมายปลายทางได้

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

หากต้องการคัดลอกสไลด์ปกติกับมาสเตอร์ของมันด้วย ให้ดูที่ [Clone Slides](/slides/th/net/clone-slides/)

## **เพิ่มสไลด์มาสเตอร์หลายรายการ**

งานนำเสนอสามารถมีสไลด์มาสเตอร์หลายรายการ ซึ่งเป็นประโยชน์เมื่อแต่ละส่วนต้องการแบรนด์, โครงสร้างหน้า หรือการตั้งค่าธีมที่แตกต่างกัน

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

ตัวอย่างต่อไปนี้คัดลอกมาสเตอร์เริ่มต้น, ให้คัดลอกมีพื้นหลังต่างกัน, สร้างเลย์เอาต์ภายใต้มาสเตอร์ที่คัดลอก, แล้วเพิ่มสไลด์ใหม่ที่อิงจากเลย์เอาต์นั้น:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **เปรียบเทียบสไลด์มาสเตอร์**

สไลด์มาสเตอร์สามารถเปรียบเทียบโดยใช้เมธอด `Equals` ที่สืบทอดมาจาก [IBaseSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/) การเปรียบเทียบตรวจสอบโครงสร้างและเนื้อหาคงที่ เช่น รูปทรง, ข้อความ, การจัดรูปแบบ, แอนิเมชัน และการตั้งค่าสไลด์อื่น ๆ ไม่ได้เปรียบเทียบตัวระบุเฉพาะ เช่น slide ID หรือค่าตัวแปร placeholder ที่เป็นไดนามิก เช่น วันที่ปัจจุบัน

```csharp
using Aspose.Slides;

using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

ข้อมูลเพิ่มเติม ดูที่ [Compare Presentation Slides](/slides/th/net/compare-slides/)

## **ตั้งค่ามุมมองสไลด์มาสเตอร์เป็นมุมมองเริ่มต้น**

ใช้คุณสมบัติ `LastView` บน [ViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/) เพื่อควบคุมมุมมองที่ PowerPoint เปิดเป็นครั้งแรก ตัวอย่างต่อไปนี้เปิดงานนำเสนอในมุมมองสไลด์มาสเตอร์:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

ตั้งค่ามุมมองเพิ่มเติมดูที่ [Save Presentation](/slides/th/net/save-presentation/)

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้**

บางครั้งงานนำเสนออาจมีสไลด์มาสเตอร์ที่ไม่มีสไลด์ปกติใดใช้ การลบมาสเตอร์ที่ไม่ได้ใช้สามารถลดขนาดไฟล์และทำให้การบำรุงรักษาเทมเพลตง่ายขึ้น

ใช้ [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/th/net/aspose.slides/masterslidecollection/removeunused/) เพื่อลบมาสเตอร์ที่ไม่ได้ใช้จากคอลเลกชัน `Masters`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

คุณยังสามารถใช้เมธอด low‑code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) ได้เช่นกัน:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**สไลด์มาสเตอร์กับสไลด์เลย์เอาต์ต่างกันอย่างไร?**

สไลด์มาสเตอร์กำหนดการออกแบบที่ใช้ร่วมกัน เช่น ธีม, พื้นหลัง, รูปทรงทั่วไป, และสไตล์ข้อความ สไลด์เลย์เอาต์เป็นส่วนหนึ่งของสไลด์มาสเตอร์และกำหนดการจัดเรียงเฉพาะของ placeholder สไลด์ปกติใช้สไลด์เลย์เอาต์ จึงสืบทอดจากทั้งเลย์เอาต์และมาสเตอร์

**งานนำเสนอหนึ่งสามารถมีสไลด์มาสเตอร์หลายรายการได้หรือไม่?**

ได้ งานนำเสนอสามารถมีสไลด์มาสเตอร์หลายรายการ ใช้หลายมาสเตอร์เมื่อส่วนต่าง ๆ ต้องการระบบภาพหรือแบรนด์ที่แตกต่างกัน

**ควรเพิ่ม placeholder ไปที่สไลด์มาสเตอร์หรือสไลด์เลย์เอาต์?**

ในส่วนใหญ่ให้เพิ่ม placeholder ไปที่สไลด์เลย์เอาต์ ใส่องค์ประกอบภาพและการจัดรูปแบบที่แชร์บนสไลด์มาสเตอร์ แล้วใส่ placeholder เนื้อหาบนเลย์เอาต์ที่สไลด์ปกติจะใช้

**สามารถลบสไลด์มาสเตอร์ที่ยังถูกใช้ได้หรือไม่?**

ไม่ได้ สไลด์มาสเตอร์ที่มีสไลด์ที่พึ่งพาไม่สามารถลบโดยตรงอย่างปลอดภัย ต้องย้ายสไลด์เหล่านั้นไปยังเลย์เอตต์ภายใต้มาสเตอร์อื่นก่อน หรือใช้วิธีทำความสะอาดมาสเตอร์ที่ไม่ได้ใช้เพื่อเอามาสเตอร์ที่ไม่ได้ถูกอ้างอิงออกเท่านั้น