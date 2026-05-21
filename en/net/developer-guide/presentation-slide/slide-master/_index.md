---
title: Manage Presentation Slide Masters in .NET
linktitle: Slide Master
type: docs
weight: 80
url: /net/slide-master/
keywords:
- slide master
- master slide
- PPT master slide
- multiple master slides
- compare master slides
- background
- placeholder
- clone master slide
- copy master slide
- duplicate master slide
- unused master slide
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Manage slide masters in Aspose.Slides for .NET: access, edit, clone, compare, and remove master slides in PowerPoint and OpenDocument presentations."
---

## **Overview**

A **slide master** defines shared design settings for a group of slides. It can contain common shapes, logos, backgrounds, text styles, theme settings, and footer settings. In PowerPoint, editing a slide master is the usual way to keep a presentation consistent without repeating the same formatting on every slide.

Aspose.Slides for .NET supports the same model. A presentation can contain one or more master slides, and each master slide can contain several layout slides. Normal slides do not usually refer to a master slide directly. Instead, a normal slide uses a layout slide, and that layout slide belongs to a master slide.

The hierarchy is:

1. **Slide master** - defines the shared design and theme.
1. **Layout slide** - defines a specific arrangement of placeholders and layout-level formatting.
1. **Normal slide** - contains the actual presentation content and uses one layout slide.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

In Aspose.Slides, a slide master is represented by the [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/) interface. All master slides in a presentation are available through the [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) collection, which implements [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

When the same property is defined at more than one level, the more specific level wins. For example, if a master slide and a layout slide both define a background, slides based on that layout use the layout background. For more information about layout slides, see [Apply or Change Slide Layouts](/slides/net/slide-layout/).

{{% /alert %}}

## **Access Slide Masters**

In PowerPoint, you can open the Slide Master view from **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

In Aspose.Slides, use the `Masters` collection to access master slides:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];

Console.WriteLine("Master slides: " + presentation.Masters.Count);
Console.WriteLine("Layouts in the first master: " + firstMasterSlide.LayoutSlides.Count);
```

You can also get the master slide used by a normal slide through its layout:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;

Console.WriteLine(masterSlide.Name);
```

## **What a Slide Master Contains**

A master slide is a slide-like object. It implements [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/), so it exposes many of the same slide properties used by normal and layout slides. Master-specific members are listed on the [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/) API page.

Commonly used master slide members include:

| Member | Purpose |
| --- | --- |
| `Background` | Sets the master-level slide background. |
| `Shapes` | Stores shapes placed on the master, such as logos, picture frames, and shared text. |
| `LayoutSlides` | Stores the layout slides that belong to the master. |
| `AsIMasterThemeable` | Provides access to the master theme APIs. |
| `HeaderFooterManager` | Controls headers, footers, dates, and slide numbers for the master and its child layouts. |
| `GetDependingSlides` | Returns normal slides that depend on the master through their layouts. |

## **Add an Image to a Slide Master**

When you add an image to a master slide, it appears on slides that use layouts from that master. This is useful for logos, watermarks, decorative bands, and other repeated visual elements.

The following example adds a logo to the first master slide:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoImage = presentation.Images.AddImage(File.ReadAllBytes("logo.png"));

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

For more information about picture frames, see [Picture Frame](/slides/net/picture-frame/).

## **Work with Placeholders**

Placeholders are normally defined on layout slides. The master slide provides the shared style and theme that those layouts inherit, while each layout decides which placeholders are available and where they are placed.

In PowerPoint, placeholder commands are available in Slide Master view.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

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
    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, Color.FromArgb(255, 0, 0));
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, Color.FromArgb(128, 0, 128));
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

For more placeholder and text formatting options, see [Set Prompt Text in Placeholder](/slides/net/manage-placeholder/) and [Text Formatting](/slides/net/text-formatting/).

## **Change a Slide Master Background**

A master background is inherited by layouts and slides that do not override it. The following example sets a solid background color for the first master slide:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

For related topics, see [Presentation Background](/slides/net/presentation-background/) and [Presentation Theme](/slides/net/presentation-theme/).

## **Clone a Slide Master to Another Presentation**

Use [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) to copy a master slide into another presentation. The copied master can then be used by layouts and slides in the destination presentation.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

If you need to clone normal slides together with their master, see [Clone Slides](/slides/net/clone-slides/).

## **Add Multiple Slide Masters**

A presentation can contain multiple master slides. This is useful when different sections require different branding, page structure, or theme settings.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

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

## **Compare Slide Masters**

Master slides can be compared with the `Equals` method inherited from [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/). The comparison checks structure and static content, such as shapes, text, formatting, animations, and other slide settings. It does not compare unique identifiers, such as slide IDs, or dynamic placeholder values, such as the current date.

```csharp
using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentation.Masters.Count; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentation.Masters.Count; secondMasterIndex++)
    {
        if (firstPresentation.Masters[firstMasterIndex].Equals(secondPresentation.Masters[secondMasterIndex]))
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

For more information, see [Compare Presentation Slides](/slides/net/compare-slides/).

## **Set Slide Master View as the Default View**

Use the `LastView` property on [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/) to control the view that PowerPoint opens first. The following example opens the presentation in Slide Master view:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

For more view settings, see [Save Presentation](/slides/net/save-presentation/).

## **Remove Unused Master Slides**

Presentations sometimes contain master slides that are no longer used by any normal slides. Removing unused masters can reduce file size and simplify template maintenance.

Use [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection/removeunused/) to remove unused masters from the `Masters` collection:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

You can also use the low-code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) method:

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**What is the difference between a slide master and a layout slide?**

A slide master defines shared design settings such as theme, background, common shapes, and text styles. A layout slide belongs to a master slide and defines a specific arrangement of placeholders. A normal slide uses a layout slide, so it inherits from both the layout and the master.

**Can one presentation contain several slide masters?**

Yes. A presentation can contain several slide masters. Use multiple masters when different sections need different visual systems or branding.

**Should I add placeholders to a master slide or a layout slide?**

In most cases, add placeholders to layout slides. Put shared visual elements and shared formatting on the master slide, then put content placeholders on the layouts that normal slides will use.

**Can I delete a master slide that is still used?**

No. A master slide that has dependent slides cannot be safely removed directly. First move those slides to layouts under another master, or use an unused-master cleanup method that removes only masters that are not in use.
