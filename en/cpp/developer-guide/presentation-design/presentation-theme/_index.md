---
title: Manage Presentation Themes in C++
linktitle: Presentation Theme
type: docs
weight: 10
url: /cpp/presentation-theme/
keywords:
- PowerPoint theme
- presentation theme
- slide theme
- set theme
- change theme
- manage theme
- external theme
- THMX
- theme color
- additional palette
- theme font
- theme style
- theme effect
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Master presentation themes in Aspose.Slides for C++ to create, customize and convert PowerPoint files with consistent branding."
---

## **Introduction**

A presentation theme defines a coordinated set of colors, fonts, background styles, fills, lines, and effects. Theme-aware objects refer to these shared definitions instead of storing every visual property as a fixed value, so a theme change can update many objects at once.

In Aspose.Slides, the presentation-level theme is available through [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/). A presentation can also contain theme overrides at lower levels. A master can override the presentation theme through [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), while a layout or an individual slide can use [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). In practice, the effective theme for a slide is resolved through this inheritance chain: presentation theme, master override, layout override, and slide override.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

The sections below show the most common theme workflows: inspect a theme, change colors and fonts, copy or apply a theme, update background and effect styles, and read effective values after inheritance and overrides have been resolved.

## **Inspect a Theme**

The [MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/) object exposes the theme's [get_ColorScheme()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_fontscheme/), and [get_FormatScheme()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_formatscheme/) methods. Inspecting these collections before changing them is especially useful when a presentation comes from an external source because the number and content of style entries can vary.

The following example reads the main theme properties and reports how many background, fill, line, and effect styles are stored in the theme:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

If a file uses multiple masters, do not assume that every slide has the same effective theme. Inspect the master associated with the slide, and use the effective-theme workflow shown later in this article when layout or slide overrides may be present.

## **Change Theme Colors**

Theme-aware fills, lines, and text can refer to a logical color from the [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) enumeration. When you change the corresponding entry in the theme's [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/), all objects that still reference that theme color are resolved against the new value. Objects that use a direct RGB color are not changed by a theme-color update.

The following end-to-end example creates a shape that uses `Accent4`, changes the theme's `Accent4` color to red, saves the presentation, reopens it, and prints the effective fill color:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Because the rectangle remains linked to `Accent4`, its visible color becomes red after the theme is changed. If you replace the scheme color with a direct color on the shape, later changes to `Accent4` will no longer affect that fill.

### **Use Colors from the Additional Palette**

PowerPoint derives lighter and darker variants from a theme color by applying color transformations. Aspose.Slides exposes these transformations through [ColorTransformOperation](https://reference.aspose.com/slides/cpp/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Main theme colors.

**2** - Lighter and darker variants produced from the main theme colors.

The following example creates six rectangles based on `Accent4`, applies luminance transformations to five of them, and saves the result:

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

These variants remain based on the theme color. If `Accent4` changes later, the transformed colors are recalculated from the new `Accent4` value.

### **Map `SchemeColor` Values to `IColorScheme` Slots**

The [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) enumeration uses `Text1`, `Background1`, `Text2`, and `Background2`, while [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) exposes the same theme slots as `Dark1`, `Light1`, `Dark2`, and `Light2`. The mapping is fixed:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

These are alternate names for the same theme slots; they are not values that are dynamically converted from one form to another.

## **Change Theme Fonts**

A theme font scheme contains a major font set for headings and a minor font set for body text. The [FontScheme::get_Major()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_major/) and [FontScheme::get_Minor()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_minor/) methods expose those sets.

PowerPoint-compatible theme font identifiers can be used in text formatting:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

The following example creates one heading that uses the major Latin theme font and one body line that uses the minor Latin theme font. It then changes the theme fonts and saves the result:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

The heading follows the major font and the body text follows the minor font. Text that has an explicit font name instead of a theme identifier will not automatically switch when the theme font scheme changes.

The major and minor font collections can also contain font mappings for individual writing systems, such as Cyrillic, Arabic, Japanese, Georgian, and Thaana. To inspect, add, replace, or remove these mappings, see [Script-Specific Theme Fonts](/slides/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

For more information about presentation fonts, see [PowerPoint Fonts](/slides/cpp/powerpoint-fonts/).

{{% /alert %}}

## **Copy or Apply a Theme**

The workflows below solve different theme-related problems.

### **Apply an External Theme to a Master's Dependent Slides**

Use [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) when you have a PowerPoint theme file (`.thmx`) and want to restyle every slide that depends on a particular master. Select the master from the [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) collection, which implements [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/), and pass the theme file path to the method.

The method performs the following operations:

1. Creates a new master slide based on the selected master.
1. Applies the external theme to the new master.
1. Assigns the new master to all slides that previously depended on the selected master.
1. Returns the newly created [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/).

The following example applies an external theme to the slides that depend on the first master and saves the presentation:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);
auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");

Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());
presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

An invalid, corrupted, or unsupported theme can cause [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) or one of its format-related subclasses. Validate paths supplied by users, handle file-system access failures, and save the presentation only after the theme has been applied successfully.

Only the slides that depended on the selected master are reassigned. Slides associated with other masters retain their existing masters and themes. Theme-aware colors, fonts, fills, lines, backgrounds, and effects are resolved against the external theme. Directly assigned colors, fonts, fills, and other explicit formatting may remain unchanged. Layout-level and slide-level overrides can also take precedence over values inherited from the new master.

The theme can reference fonts that are not available in the runtime environment. For consistent rendering and export, install the required fonts, provide them through [custom font sources](/slides/cpp/custom-font/), or configure [font substitution](/slides/cpp/font-substitution/).

This is a direct master-level workflow: the method accepts a file path to a `.thmx` file and does not require manually creating slide-level or layout-level theme overrides.

### **Apply Different External Themes in a Multi-Master Presentation**

When the relevant master is not known in advance, obtain it from a representative slide through [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) and [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_masterslide/). Store the original master references before applying any themes because each call creates another master in the presentation.

The following example uses slides from two sections to locate their masters and applies a different external theme to each group:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());
        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

The first call affects only slides that depended on `firstGroupMaster`, and the second call affects only slides that depended on `secondGroupMaster`. Slides belonging to any other master are not restyled.

### **Preserve a Source Theme When Moving Slides**

If you want to move a slide to another presentation and preserve its original design, clone the source master into the target presentation with [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/), then clone the slide with [ISlideCollection::AddClone()](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) and the cloned master. This carries the master, its layouts, and the associated theme together.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

This is the preferred workflow when the source slide must look the same in the destination. Simply cloning content onto an unrelated destination master can change theme-driven colors, fonts, backgrounds, and effects.

### **Apply Theme Values to an Existing Slide**

If the target slide must stay on its current master and layout, initialize a slide-level override from the source theme. The [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/), and [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) methods copy the three main theme components into the override.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

This changes the theme used by that slide without changing the theme inherited by other slides. To remove the local override and return to inherited values, call [OverrideTheme::Clear()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/clear/).

### **Apply a Theme Override to a Layout**

A layout-level override applies to slides that use that layout, unless a particular slide has its own override. The same initialization methods can be used through the layout's [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/):

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Use a master or presentation-level theme when many layouts and slides should share the same base design, a layout override when one layout family needs different styling, and a slide override only for true exceptions. Excessive slide-level overrides make later global theme changes harder to predict.

## **Update Theme Background Styles**

The theme's background fills are stored in [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint can present more background choices in its UI than the number of fill definitions physically stored in this collection because the UI can combine theme fills with theme colors and other style references.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Before using a background style, inspect the stored collection and the current [Background::get_StyleIndex()](https://reference.aspose.com/slides/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` uses `0` for no themed fill; positive values are theme background-style references. This is different from indexing a C++ collection directly with `idx_get(0)`, where `0` means the first stored item. Do not assume that every presentation contains the same number of background fill styles.

The following example reports the available background fill count, assigns a themed background reference to the first master, and saves the presentation:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

The visible result depends on the theme entry referenced by the master and on any background overrides at the layout or slide level. If a slide uses its own background, changing only the master background may not change that slide. Use [Background::GetEffective()](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) when you need to know the final background after inheritance has been applied.

{{% alert color="warning" title="Warning" %}}

Do not treat `StyleIndex` as a zero-based collection index. Also avoid hard-coding a style number from one file and assuming it has the same appearance in another file; theme style definitions are presentation-specific.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

For direct background formatting and background inheritance, see [Presentation Background](/slides/cpp/presentation-background/).

{{% /alert %}}

## **Update Theme Effects**

A theme format scheme contains separate [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_linestyles/), and [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_effectstyles/) collections. Typical Office themes often contain three principal style entries that correspond visually to subtle, moderate, and intense formatting, but code should inspect each collection instead of assuming a fixed count.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

When you access these collections in C++, the collection index is zero-based: `idx_get(0)` is the first stored style and `idx_get(2)` is the third. A shape's style-reference indexes are a separate concept, exposed through [IShapeStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/). Modifying a theme style affects shapes that reference that theme style; shapes with direct formatting may remain unchanged.

The following example checks that the required style entries exist, changes the first line style, changes the third fill style, enables an outer shadow in the third effect style, and saves the result:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

For shapes that reference these slots, the first theme line style becomes red, the third theme fill style becomes solid forest green, and the third effect style gains an outer shadow with a distance of 10 points. The exact visual result still depends on which style slots each shape references and whether direct formatting overrides the theme.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Read Effective Theme Values**

Raw theme objects tell you what is defined at a particular level. Effective values tell you what a slide or shape actually uses after inheritance and local overrides are resolved. For a slide, call [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). For a background, use [Background::GetEffective()](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/), and for a fill, use [FillFormat::GetEffective()](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/).

The following example reads the effective theme, background, and first shape fill from a slide:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Use effective data for rendering diagnostics, validation, and comparisons. If you inspect only [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/), you can miss a master, layout, slide, or shape override that changes the final appearance.

## **FAQ**

**Does applying an external theme affect every slide in the presentation?**

No. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) reassigns only the slides that depend on the selected master. Slides that use other masters retain their existing themes.

**Can I apply a theme to a single slide without changing the master?**

Yes. Use the slide's [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) and initialize its override theme. The change remains local to that slide; other slides continue to inherit their existing themes.

**What is the safest way to carry a theme from one presentation to another?**

When moving a slide and preserving its source appearance, clone the source master into the destination and clone the slide with that master using [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) and [ISlideCollection::AddClone()](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/). This keeps the master, layouts, and theme together.

**How can I see the effective values after inheritance and overrides?**

Use [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) for a slide or layout theme and the corresponding effective-data methods for format objects such as [Background::GetEffective()](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) and [FillFormat::GetEffective()](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/). These APIs return the resolved values after inheritance and overrides are applied.
