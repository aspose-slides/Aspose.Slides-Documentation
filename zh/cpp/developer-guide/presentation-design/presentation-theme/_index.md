---
title: 在 C++ 中管理演示文稿主题
linktitle: 演示文稿主题
type: docs
weight: 10
url: /zh/cpp/presentation-theme/
keywords:
- PowerPoint 主题
- 演示文稿主题
- 幻灯片主题
- 设置主题
- 更改主题
- 管理主题
- 主题颜色
- 附加调色板
- 主题字体
- 主题样式
- 主题效果
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中管理演示文稿主题，以创建、定制和转换具有一致品牌的 PowerPoint 文件。"
---
## **介绍**

演示文稿主题定义了一套协调的颜色、字体、背景样式、填充、线条和效果。支持主题的对象引用这些共享定义，而不是将每个视觉属性存储为固定值，因此更改主题可以一次性更新多个对象。

在 Aspose.Slides 中，演示文稿级别的主题可通过[Presentation::get_MasterTheme()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_mastertheme/)获取。演示文稿还可以在更低层级包含主题覆盖。母版可以通过[MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/)覆盖演示文稿主题，而布局或单个幻灯片可以使用[IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/)。实际上，幻灯片的有效主题通过以下继承链解析：演示文稿主题 → 母版覆盖 → 布局覆盖 → 幻灯片覆盖。

![主题组成：颜色、字体、背景样式和效果](theme-constituents.png)

以下章节展示了最常见的主题工作流：检查主题、修改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/mastertheme/)对象暴露了主题的[get_ColorScheme()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/mastertheme/get_colorscheme/)、[get_FontScheme()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/mastertheme/get_fontscheme/)和[get_FormatScheme()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/mastertheme/get_formatscheme/)方法。在更改这些集合之前先检查它们尤其有用，因为来自外部源的演示文稿其样式条目的数量和内容可能各不相同。

下面的示例读取主要主题属性并报告主题中存储了多少背景、填充、线条和效果样式：

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

如果一个文件使用多个母版，请不要假设每张幻灯片都有相同的有效主题。检查与幻灯片关联的母版，并在布局或幻灯片可能存在覆盖时使用本文后面展示的有效主题工作流。

## **更改主题颜色**

支持主题的填充、线条和文本可以引用[SchemeColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides/schemecolor/)枚举中的逻辑颜色。当您更改主题的[IColorScheme](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/icolorscheme/)中的相应条目时，所有仍然引用该主题颜色的对象都会使用新值解析。直接使用 RGB 颜色的对象则不会受到主题颜色更新的影响。

下面的端到端示例创建了一个使用 `Accent4` 的形状，将主题的 `Accent4` 颜色更改为红色，保存演示文稿，重新打开，并打印有效的填充颜色：

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

因为矩形仍然链接到 `Accent4`，主题更改后其可见颜色会变为红色。如果您将形状的方案颜色替换为直接颜色，则以后对 `Accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过应用颜色变换从主题颜色派生出更浅和更深的变体。Aspose.Slides 通过[ColorTransformOperation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/colortransformoperation/)公开这些变换。

![主主题颜色及从附加调色板生成的更浅和更深颜色](additional-palette-colors.png)

**1** - 主主题颜色。

**2** - 从主主题颜色生成的更浅和更深变体。

下面的示例基于 `Accent4` 创建了六个矩形，对其中五个应用亮度变换，并保存结果：

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

这些变体仍然基于主题颜色。如果以后 `Accent4` 更改，变换后的颜色会根据新的 `Accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `IColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides/schemecolor/)枚举使用 `Text1`、`Background1`、`Text2` 和 `Background2`，而[IColorScheme](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/icolorscheme/)将相同的主题槽位公开为 `Dark1`、`Light1`、`Dark2` 和 `Light2`。映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

这些是相同主题槽位的别名；它们不是从一种形式动态转换为另一种形式的值。

## **更改主题字体**

主题字体方案包含标题的主要字体集和正文的次要字体集。[FontScheme::get_Major()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/fontscheme/get_major/)和[FontScheme::get_Minor()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/fontscheme/get_minor/)方法公开这些集合。

PowerPoint 兼容的主题字体标识符可用于文本格式化：

* `+mn-lt` - 正文字体拉丁文（Minor Latin Font）
* `+mj-lt` - 标题字体拉丁文（Major Latin Font）
* `+mn-ea` - 正文字体东亚（Minor East Asian Font）
* `+mj-ea` - 标题字体东亚（Major East Asian Font）

下面的示例创建一个使用主要拉丁主题字体的标题和一个使用次要拉丁主题字体的正文行。随后更改主题字体并保存结果：

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

标题使用主要字体，正文使用次要字体。使用显式字体名称而非主题标识符的文本在主题字体方案更改时不会自动切换。

{{% alert color="info" title="Tip" %}}
有关演示文稿字体的更多信息，请参阅[PowerPoint Fonts](/slides/zh/cpp/powerpoint-fonts/)。
{{% /alert %}}

## **复制或应用主题**

常见的工作流有两种，它们解决不同的问题。

### **在移动幻灯片时保留源主题**

如果要将幻灯片移动到另一个演示文稿并保留其原始设计，请使用[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterslidecollection/addclone/)将源母版克隆到目标演示文稿中，然后使用[ISlideCollection::AddClone()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/)将幻灯片与克隆的母版一起克隆。这样会一起携带母版、其布局以及关联的主题。

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

当源幻灯片必须在目标中保持相同外观时，这是首选工作流。仅将内容克隆到不相关的目标母版上可能会更改主题驱动的颜色、字体、背景和效果。

### **将主题值应用于现有幻灯片**

如果目标幻灯片必须保持在其当前母版和布局上，请从源主题初始化幻灯片级别的覆盖。使用[OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/)、[OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/)和[OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/)方法将三个主要主题组件复制到覆盖中。

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

这会更改该幻灯片使用的主题，而不影响其他幻灯片继承的主题。要移除本地覆盖并恢复到继承值，请调用[OverrideTheme::Clear()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/overridetheme/clear/)。

### **将主题覆盖应用于布局**

布局级覆盖适用于使用该布局的幻灯片，除非特定幻灯片有自己的覆盖。相同的初始化方法可以通过布局的[IOverrideThemeManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/ioverridethememanager/)使用：

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

当许多布局和幻灯片应共享相同基础设计时使用母版或演示文稿级主题；当某一布局族需要不同样式时使用布局覆盖；仅在真正的例外情况下使用幻灯片覆盖。过多的幻灯片级覆盖会使后续全局主题更改难以预测。

## **更新主题背景样式**

主题的背景填充存储在[FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/)中。PowerPoint 在其 UI 中可以呈现比此集合实际存储的填充定义更多的背景选项，因为 UI 可以将主题填充与主题颜色及其他样式引用组合。

![PowerPoint 演示文稿主题的背景样式画廊](presentation-design_8.png)

在使用背景样式之前，检查存储的集合以及当前的[Background::get_StyleIndex()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/background/get_styleindex/)。`StyleIndex` 使用 `0` 表示无主题填充；正值为主题背景样式引用。这不同于直接使用 `idx_get(0)` 对 C++ 集合进行索引，后者的 `0` 表示第一个存储项。不要假设每个演示文稿都有相同数量的背景填充样式。

下面的示例报告可用的背景填充计数，将主题化的背景引用分配给第一个母版，并保存演示文稿：

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

可见结果取决于母版引用的主题条目以及布局或幻灯片级的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要了解继承后最终背景时，请使用[Background::GetEffective()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/background/geteffective/)。

{{% alert color="warning" title="Warning" %}}
不要将 `StyleIndex` 当作零基集合索引来使用。也避免从一个文件硬编码样式编号并假设在另一个文件中具有相同外观；主题样式定义是针对特定演示文稿的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有关直接背景格式化和背景继承，请参阅[Presentation Background](/slides/zh/cpp/presentation-background/)。
{{% /alert %}}

## **更新主题效果**

主题格式方案包含独立的[FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/formatscheme/get_fillstyles/)、[FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/formatscheme/get_linestyles/)和[FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/formatscheme/get_effectstyles/)集合。典型的 Office 主题通常包含三个主要样式条目，视觉上对应于细微、适中和强烈的格式，但代码应检查每个集合而不是假设固定数量。

![对同一形状应用的细微、适中和强烈主题效果](presentation-design_10.png)

在 C++ 中访问这些集合时，集合索引是零基的：`idx_get(0)` 是第一个存储的样式，`idx_get(2)` 是第三个。形状的样式引用索引是另一概念，通过[IShapeStyle](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapestyle/)公开。修改主题样式会影响引用该主题样式的形状；直接格式化的形状可能保持不变。

下面的示例检查所需的样式条目是否存在，修改第一条线条样式，修改第三条填充样式，在第三条效果样式中启用外部阴影，并保存结果：

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

对于引用这些槽位的形状，第一条主题线条样式变为红色，第三条主题填充样式变为实心森林绿，第三条效果样式获得距离为 10 点的外部阴影。具体视觉结果仍取决于每个形状引用的样式槽位以及是否有直接格式覆盖主题。

![更改线条、填充和阴影设置后主题效果样式](presentation-design_11.png)

## **读取有效主题值**

原始主题对象告诉您在特定层级定义了什么。有效值则告诉您幻灯片或形状在继承和本地覆盖解析后实际使用的内容。对于幻灯片，调用[IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)。对于背景，使用[Background::GetEffective()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/background/geteffective/)，对于填充，则使用[FillFormat::GetEffective()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fillformat/geteffective/)。

下面的示例读取幻灯片的有效主题、背景以及第一形状的填充：

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

使用有效数据进行渲染诊断、验证和比较。如果只检查[Presentation::get_MasterTheme()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_mastertheme/)，可能会错过改变最终外观的母版、布局、幻灯片或形状覆盖。

## **常见问题**

**我可以在不更改母版的情况下将主题应用于单个幻灯片吗？**

可以。使用幻灯片的[IOverrideThemeManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/ioverridethememanager/)并初始化其覆盖主题。更改仅局限于该幻灯片；其他幻灯片继续继承各自的主题。

**将主题从一个演示文稿迁移到另一个演示文稿的最安全方式是什么？**

在移动幻灯片并保留其源外观时，使用[IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterslidecollection/addclone/)将源母版克隆到目标演示文稿，然后使用[ISlideCollection::AddClone()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidecollection/addclone/)克隆幻灯片并关联该母版。这样可保持母版、布局和主题一起迁移。

**如何查看继承和覆盖后的有效值？**

对于幻灯片或布局主题，使用[IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/zh/cpp/aspose.slides.theme/ithemeable/createthemeeffective/)；对于诸如背景和填充等格式对象，使用相应的有效数据方法，如[Background::GetEffective()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/background/geteffective/)和[FillFormat::GetEffective()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fillformat/geteffective/)。这些 API 在应用继承和覆盖后返回解析后的值。