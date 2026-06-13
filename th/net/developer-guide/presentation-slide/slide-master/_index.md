---
title: จัดการมาสเตอร์สไลด์การนำเสนอใน .NET
linktitle: มาสเตอร์สไลด์
type: docs
weight: 80
url: /th/net/slide-master/
keywords:
- มาสเตอร์สไลด์
- สไลด์มาสเตอร์
- สไลด์มาสเตอร์ PPT
- สไลด์มาสเตอร์หลายรายการ
- เปรียบเทียบสไลด์มาสเตอร์
- พื้นหลัง
- ตัวครอบข้อความ
- ทำสำเนาสไลด์มาสเตอร์
- คัดลอกสไลด์มาสเตอร์
- ทำซ้ำสไลด์มาสเตอร์
- สไลด์มาสเตอร์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการมาสเตอร์สไลด์ใน Aspose.Slides สำหรับ .NET: เข้าถึง, แก้ไข, ทำสำเนา, เปรียบเทียบ, และลบสไลด์มาสเตอร์ในการนำเสนอ PowerPoint และ OpenDocument."
---
## **ภาพรวม**

A **slide master** defines shared design settings for a group of slides. It can contain common shapes, logos, backgrounds, text styles, theme settings, and footer settings. In PowerPoint, editing a slide master is the usual way to keep a presentation consistent without repeating the same formatting on every slide.

Aspose.Slides for .NET supports the same model. A presentation can contain one or more master slides, and each master slide can contain several layout slides. Normal slides do not usually refer to a master slide directly. Instead, a normal slide uses a layout slide, and that layout slide belongs to a master slide.

The hierarchy is:

1. **มาสเตอร์สไลด์** - defines the shared design and theme.  
1. **สไลด์แบบจัดวาง** - defines a specific arrangement of placeholders and layout-level formatting.  
1. **สไลด์ปกติ** - contains the actual presentation content and uses one layout slide.  

![ลำดับชั้นของมาสเตอร์สไลด์, สไลด์แบบจัดวาง, และสไลด์ปกติ](slide-master_2.jpg)

In Aspose.Slides, a slide master is represented by the [IMasterSlide](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/) interface. All master slides in a presentation are available through the [Presentation.Masters](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/masters/) collection, which implements [IMasterSlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

When the same property is defined at more than one level, the more specific level wins. For example, if a master slide and a layout slide both define a background, slides based on that layout use the layout background. For more information about layout slides, see [Apply or Change Slide Layouts](/slides/th/net/slide-layout/).

{{% /alert %}}

## **การเข้าถึงมาสเตอร์สไลด์**

In PowerPoint, you can open the Slide Master view from **View** > **Slide Master**.

![คำสั่ง Slide Master บนแท็บ View ของ PowerPoint](slide-master_3.jpg)

In Aspose.Slides, use the `Masters` collection to access master slides:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

You can also get the master slide used by a normal slide through its layout:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **สิ่งที่มาสเตอร์สไลด์ประกอบด้วย**

A master slide is a slide-like object. It implements [IBaseSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/), so it exposes many of the same slide properties used by normal and layout slides. Master-specific members are listed on the [IMasterSlide](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/) API page.

Commonly used master slide members include:

| Member | วัตถุประสงค์ |
| --- | --- |
| `Background` | Sets the master-level slide background. |
| `Shapes` | Stores shapes placed on the master, such as logos, picture frames, and shared text. |
| `LayoutSlides` | Stores the layout slides that belong to the master. |
| `ThemeManager` | Provides access to the master theme APIs. |
| `HeaderFooterManager` | Controls headers, footers, dates, and slide numbers for the master and its child layouts. |
| `GetDependingSlides` | Returns normal slides that depend on the master through their layouts. |

## **เพิ่มรูปภาพลงในมาสเตอร์สไลด์**

When you add an image to a master slide, it appears on slides that use layouts from that master. This is useful for logos, watermarks, decorative bands, and other repeated visual elements.

The following example adds a logo to the first master slide:

```csharp
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

For more information about picture frames, see [กรอบรูป](/slides/th/net/picture-frame/).

## **ทำงานกับตัวครอบข้อความ**

Placeholders are normally defined on layout slides. The master slide provides the shared style and theme that those layouts inherit, while each layout decides which placeholders are available and where they are placed.

In PowerPoint, placeholder commands are available in Slide Master view.

![คำสั่ง Insert Placeholder ในมุมมอง Slide Master ของ PowerPoint](slide-master_5.png)

To add new placeholders with Aspose.Slides, work with the layout slide that belongs to the master:

```csharp
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

You can also format placeholder shapes that already exist on a master slide. The following example finds the title placeholder and applies a linear gradient fill:

```csharp
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

![ตัวครอบข้อความหัวข้อที่จัดรูปแบบแล้วสืบทอดโดยสไลด์ปกติ](slide-master_8.png)

For more placeholder and text formatting options, see [ตั้งข้อความ Prompt ใน Placeholder](/slides/th/net/manage-placeholder/) and [การจัดรูปแบบข้อความ](/slides/th/net/text-formatting/).

## **เปลี่ยนพื้นหลังมาสเตอร์สไลด์**

A master background is inherited by layouts and slides that do not override it. The following example sets a solid background color for the first master slide:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

For related topics, see [พื้นหลังการนำเสนอ](/slides/th/net/presentation-background/) and [ธีมการนำเสนอ](/slides/th/net/presentation-theme/).

## **คัดลอกมาสเตอร์สไลด์ไปยังการนำเสนออื่น**

Use [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslidecollection/addclone/) to copy a master slide into another presentation. The copied master can then be used by layouts and slides in the destination presentation.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

If you need to clone normal slides together with their master, see [Clone Slides](/slides/th/net/clone-slides/).

## **เพิ่มมาสเตอร์สไลด์หลายรายการ**

A presentation can contain multiple master slides. This is useful when different sections require different branding, page structure, or theme settings.

![คำสั่ง PowerPoint สำหรับแทรกและจัดการมาสเตอร์สไลด์](slide-master_9.jpg)

The following example clones the default master, gives the clone a different background, creates a layout under that cloned master, and adds a new slide based on that layout:

```csharp
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

## **เปรียบเทียบมาสเตอร์สไลด์**

Master slides can be compared with the `Equals` method inherited from [IBaseSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ibaseslide/). The comparison checks structure and static content, such as shapes, text, formatting, animations, and other slide settings. It does not compare unique identifiers, such as slide IDs, or dynamic placeholder values, such as the current date.

```csharp
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

For more information, see [เปรียบเทียบสไลด์การนำเสนอ](/slides/th/net/compare-slides/).

## **ตั้งมุมมองมาสเตอร์สไลด์เป็นมุมมองเริ่มต้น**

Use the `LastView` property on [ViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/) to control the view that PowerPoint opens first. The following example opens the presentation in Slide Master view:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

For more view settings, see [บันทึกการนำเสนอ](/slides/th/net/save-presentation/).

## **ลบมาสเตอร์สไลด์ที่ไม่ได้ใช้**

Presentations sometimes contain master slides that are no longer used by any normal slides. Removing unused masters can reduce file size and simplify template maintenance.

Use [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/th/net/aspose.slides/masterslidecollection/removeunused/) to remove unused masters from the `Masters` collection:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

You can also use the low-code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) method:

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างมาสเตอร์สไลด์และสไลด์แบบจัดวางคืออะไร?**

A slide master defines shared design settings such as theme, background, common shapes, and text styles. A layout slide belongs to a master slide and defines a specific arrangement of placeholders. A normal slide uses a layout slide, so it inherits from both the layout and the master.

**การนำเสนอหนึ่งสามารถมีมาสเตอร์สไลด์หลายรายการได้หรือไม่?**

Yes. A presentation can contain several slide masters. Use multiple masters when different sections need different visual systems or branding.

**ฉันควรเพิ่มตัวครอบข้อความลงในมาสเตอร์สไลด์หรือสไลด์แบบจัดวาง?**

In most cases, add placeholders to layout slides. Put shared visual elements and shared formatting on the master slide, then put content placeholders on the layouts that normal slides will use.

**ฉันสามารถลบมาสเตอร์สไลด์ที่ยังถูกใช้อยู่ได้หรือไม่?**

No. A master slide that has dependent slides cannot be safely removed directly. First move those slides to layouts under another master, or use an unused‑master cleanup method that removes only masters that are not in use.