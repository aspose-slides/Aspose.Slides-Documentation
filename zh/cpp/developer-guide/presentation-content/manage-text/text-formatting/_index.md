---
title: 在 C++ 中格式化演示文稿文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/cpp/text-formatting/
keywords:
- 对齐段落
- 文本样式
- 文本背景
- 文本透明度
- 字符间距
- 字体属性
- 字体系列
- 文本旋转
- 旋转角度
- 文本框
- 行距
- 自动适配属性
- 文本框锚点
- 文本制表
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 演示文稿中格式化和美化文本。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 演示文稿中对文本进行格式化。内容包括背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适配行为、文本锚定、制表位和语言设置。

除非另有说明，示例均使用 [sample.pptx](sample.pptx)。其第一张幻灯片的第一个形状是一个文本框，第一段落包含下面显示的文本。幻灯片和形状的索引均从零开始。选择粗体部分的示例使用有效格式，包括继承的粗体格式：

![示例文本](sample_text.png)

要查找并突出显示文字或正则表达式匹配项，请参阅 [搜索和替换文本](/slides/zh/cpp/search-and-replace-text/)。

## **设置文本背景颜色**

使用 [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) 为段落设置默认突出显示颜色，或使用 [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) 为单个文本片段设置。

下面的示例将第一段落的默认突出显示颜色设置为浅灰色。对单个片段的显式突出显示颜色优先于此默认值：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
auto highlightColor = System::Drawing::Color::get_LightGray();

// 为整个段落设置突出显示颜色。
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![灰色段落](gray_paragraph.png)

下面的代码示例演示如何为 **粗体字体的文本片段** 设置背景颜色：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto highlightColor = System::Drawing::Color::get_LightGray();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // 为文本片段设置突出显示颜色。
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![灰色文本片段](gray_text_portions.png)

## **对齐文本段落**

使用 [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) 在文本框内设置段落对齐方式。取值可以是居中、左对齐、右对齐、两端对齐等。

下面的代码示例演示如何将段落对齐方式设置为 **居中**：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextAlignment.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// 将段落的对齐方式设置为居中。
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![对齐的段落](aligned_paragraph.png)

## **在行内对齐字体**

使用 [IParagraphFormat::set_FontAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_fontalignment/) 在行内垂直对齐不同字号的文本片段。此设置适用于整个段落，并控制每行内的对齐方式。

下面的独立示例在同一张幻灯片上创建四个带标签的文本框。每个段落的文字相同，字号分别为 18、36、54 点，且使用不同的字体对齐方式。示例使用 Arial，禁用自动适配和换行，并保持文本框足够大以容纳单行文本。

```cpp
#include <DOM/FontAlignment.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

FontAlignment alignments[] = { FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom };
String labels[] = { u"Baseline", u"Top", u"Center", u"Bottom" };
float fontSizes[] = { 18.0f, 36.0f, 54.0f };
auto font = MakeObject<FontData>(u"Arial");

for (auto i = 0; i < 4; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 20 + i * 130, 660, 120);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);

    auto label = textFrame->get_Paragraph(0);
    label->set_Text(labels[i]);
    label->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto labelFormat = label->get_ParagraphFormat()->get_DefaultPortionFormat();
    labelFormat->set_FontHeight(14);
    labelFormat->set_LatinFont(font);
    labelFormat->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_FontAlignment(alignments[i]);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto portionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    portionFormat->set_LatinFont(font);
    portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
    portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    for (auto fontSize : fontSizes)
    {
        auto portion = MakeObject<Portion>(u"Ag ");
        portion->get_PortionFormat()->set_FontHeight(fontSize);
        paragraph->get_Portions()->Add(portion);
    }

    textFrame->get_Paragraphs()->Add(paragraph);
}

presentation->Save(u"font_alignment.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![基线、顶部、居中和底部字体对齐的比较（混合字号）](font_alignment.png)

字体对齐使用字体度量，因此各个字母的可见边缘不一定完全对齐。示例同时包含大写字母和下行字符，以帮助展示基线与底部对齐的差异。字体可用性与替换、所使用的字符以及字号差异都会影响结果。框架尺寸、边距、行距、换行和自动适配也会影响布局；比较模式时请使用相同的字体和布局设置。

此设置不同于 [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/)，后者控制水平段落对齐；也不同于 [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/)，后者在形状内部垂直定位文本块。通过 [IBasePortionFormat::set_Escapement](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_escapement/) 实现的上标和下标格式会相对于基线移动单个片段，而不是为段落行设置字体对齐。

## **为文本设置透明度**

文本透明度通过 [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/) 分配的颜色的 Alpha 分量来控制。下面示例中，`alpha = 50` 是 0‑255 范围的 ARGB Alpha 通道值，而非透明度百分比。

下面的代码示例展示如何对 **整个段落** 应用透明度：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// 将文本的填充颜色设置为透明颜色。
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![透明段落](transparent_paragraph.png)

下面的代码示例展示如何对 **粗体字体的文本片段** 应用透明度：

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // 设置文本片段的透明度。
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![透明文本片段](transparent_text_portions.png)

## **为文本设置字符间距**

使用 [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_spacing/) 可以在文本框中扩大或压缩字符之间的间距。示例中添加了 3 点的间距；负值则会压缩文本。

下面的 C++ 代码展示如何在 **整个段落** 中扩大字符间距：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// 注意：使用负值可以压缩字符间距。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // 扩大字符间距。

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例展示如何在 **粗体字体的文本片段** 中扩大字符间距：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // 注意：使用负值可以压缩字符间距。
        portionFormat->set_Spacing(3.0f); // 扩大字符间距。
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![文本片段中的字符间距](character_spacing_in_text_portions.png)

### **为特定字体禁用连字**

在某些情况下，Aspose.Slides 渲染的文本看起来比 PowerPoint 中略紧。这可能是因为 PowerPoint 对某些字体会忽略连字数据，即使该字体包含有效的连字信息且在 PowerPoint 设置中已启用连字。

为使渲染输出更接近 PowerPoint，可以为使用受影响字体的文本片段禁用连字。使用 [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) 将值设置为大于实际字号的数值。本例需要一个在第一张幻灯片第一张形状上为文本框的 “presentation.pptx”。它检查有效的字体名称（包括继承的字体），并对使用 Roboto 的片段设置 100 点的阈值：低于 100 点的匹配片段将禁用连字：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
System::String targetFont = u"Roboto";
auto textFrame = autoShape->get_TextFrame();
auto paragraphs = textFrame->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto textFormat = portionFormat->GetEffective();
        auto latinFont = textFormat->get_LatinFont();
        auto eastAsianFont = textFormat->get_EastAsianFont();
        auto complexScriptFont = textFormat->get_ComplexScriptFont();

        bool isLatinFont = latinFont != nullptr && latinFont->get_FontName() == targetFont;
        bool isEastAsianFont = eastAsianFont != nullptr && eastAsianFont->get_FontName() == targetFont;
        bool isComplexScriptFont = complexScriptFont != nullptr && complexScriptFont->get_FontName() == targetFont;

        if (isLatinFont || isEastAsianFont || isComplexScriptFont)
        {
            portionFormat->set_KerningMinimalSize(100.0f);
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

对于低于阈值的匹配文本，此设置会阻止连字，并有助于使 Aspose.Slides 的渲染效果与 PowerPoint 对受此 PowerPoint 特定行为影响的字体的视觉输出保持一致。

## **管理文本字体属性**

字体属性可以通过 [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) 在段落级别设置，或者通过 [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/) 在单个片段上设置。

下面的示例将第一段落的默认字体设置为 12 点 Times New Roman，且带粗体、斜体和点划下划线。对单个片段的显式格式会优先于这些默认值：

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// 设置段落的字体属性。
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![段落的字体属性](font_properties_for_paragraph.png)

下面的示例对有效格式为粗体的片段应用 13 点 Times New Roman、斜体以及点划下划线：

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto font = System::MakeObject<FontData>(u"Times New Roman");

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // 为文本片段设置字体属性。
        portionFormat->set_FontHeight(13.0f);
        portionFormat->set_FontItalic(NullableBool::True);
        portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
        portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![文本片段的字体属性](font_properties_for_text_portions.png)

## **控制文本高度归一化**

使用 [IBasePortionFormat::set_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_normaliseheight/) 可在复制模板排版或研究字符高度差异时进行归一化。在 PowerPoint 中，启用归一化会在垂直方向上拉伸或压缩单个字符，使其在文本片段内呈现统一的可视高度，但并不保证不同字体之间的文本高度相等。

将属性设置为 [NullableBool::True or False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) 可显式启用或禁用归一化。`NullableBool::NotDefined` 会保持本地设置未定义，从而使片段继承段落的 [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) 等值。这并不等同于 `False`。使用 [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) 并读取 [IBasePortionFormatEffectiveData::get_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformateffectivedata/get_normaliseheight/) 可获得解析后的布尔值。

下面的独立示例要求安装 **Arial**。它创建两个文本块，均包含相同的大写字母、小写字母、下行字符和带重音的字符，字号为 54 点。两个段落默认启用归一化。上部片段显式禁用，下部片段继承设置。框架尺寸、边距和段落间距保持一致，且禁用换行和自动适配，以保持比较的一致性。示例打印 `False: False` 和 `NotDefined: True`，随后保存为 “text_height_normalization.pptx”。

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

NullableBool settings[] = { NullableBool::False, NullableBool::NotDefined };

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 60 + i * 200, 660, 150);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(u"Hxgjpq ÅÉ 0123");
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_MarginTop(0);
    textFrame->get_TextFrameFormat()->set_MarginLeft(0);

    auto paragraph = textFrame->get_Paragraph(0);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceBefore(0);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(0);
    paragraph->get_ParagraphFormat()->set_SpaceWithin(100);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_NormaliseHeight(NullableBool::True);

    auto portion = paragraph->get_Portion(0);
    auto font = MakeObject<FontData>(u"Arial");
    portion->get_PortionFormat()->set_LatinFont(font);
    portion->get_PortionFormat()->set_FontHeight(54);
    portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    portion->get_PortionFormat()->set_NormaliseHeight(settings[i]);

    Console::WriteLine(u"{0}: {1}", settings[i], portion->get_PortionFormat()->GetEffective()->get_NormaliseHeight());
}

presentation->Save(u"text_height_normalization.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

下面的比较图来源于已保存的演示文稿。顶部行的归一化被禁用（`False`），底部行继承启用（`NotDefined` → `True`）。请保持 Arial 已安装以复现此外观。

![Arial 54 点文本，顶部归一化禁用，底部继承启用](text_height_normalization.png)

归一化会在不改变分配的 [IBasePortionFormat::get_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fontheight/)（指定字号）的前提下改变字符高度。段落的 [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) 控制行距，而文本框的 [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) 控制文本或其容器的自适应方式。这些设置各自服务于不同目的，可能独立影响整体布局。更多段落格式和继承信息，请参阅 [管理段落](/slides/zh/cpp/manage-paragraph/)。

## **应用和移除删除线**

在文本片段上使用 [IBasePortionFormat::set_StrikethroughType](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_strikethroughtype/) 可以显示更正、已取消的词语或以前的价格而不删除原始文本。将其设置为 [TextStrikethroughType::Single or Double](https://reference.aspose.com/slides/cpp/aspose.slides/textstrikethroughtype/) 可在文本上加单线或双线删除线。

要移除删除线，赋值 `TextStrikethroughType::None`。这会显式关闭该效果，即使周围的格式指定了删除线。相比之下，`TextStrikethroughType::NotDefined` 会保持本地设置未定义，允许片段继承例如段落的格式，并不保证删除线被移除。使用 [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) 可读取最终格式，包括继承的值。

下面的独立示例创建了三个价格对比。每个段落分别包含标签、原价和现价的片段，仅原价受删除线影响。第一行先应用后移除删除线；其余行保留单线和双线删除线。更改此属性可保持文本及其其他格式（包括粗体原价）不变。

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextStrikethroughType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

String labels[] = { u"None: ", u"Single: ", u"Double: " };

for (auto label : labels)
{
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(20);

    auto format = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    format->set_FontHeight(28);
    auto font = MakeObject<FontData>(u"Arial");
    format->set_LatinFont(font);
    format->get_FillFormat()->set_FillType(FillType::Solid);
    format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    auto labelPortion = MakeObject<Portion>(label);
    paragraph->get_Portions()->Add(labelPortion);

    auto previousPrice = MakeObject<Portion>(u"$100");
    previousPrice->get_PortionFormat()->set_FontBold(NullableBool::True);
    paragraph->get_Portions()->Add(previousPrice);
    auto currentPrice = MakeObject<Portion>(u" → $80");
    paragraph->get_Portions()->Add(currentPrice);

    textFrame->get_Paragraphs()->Add(paragraph);
}

// 应用删除线，然后显式地从第一个原价中移除。
auto firstPriceFormat = textFrame->get_Paragraph(0)->get_Portion(1)->get_PortionFormat();
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::Single);
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::None);

textFrame->get_Paragraph(1)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Single);
textFrame->get_Paragraph(2)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Double);

presentation->Save(u"strikethrough.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果（从上到下）：无删除线、单线删除线、双线删除线。

![无删除线、单线删除线和双线删除线的原价对比](strikethrough.png)


## **设置文本旋转**

使用 [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_textverticaltype/) 可在形状内设置预定义的文本方向。

下面的代码示例将形状内的文本方向设置为 [TextVerticalType::Vertical270](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/)，即文本 **逆时针旋转 90 度**：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![文本旋转](text_rotation.png)

## **为文本框设置自定义旋转角度**

使用 [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) 可为 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 设置自定义旋转角度。

下面的代码示例在形状内将文本框顺时针旋转 3 度：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![自定义文本旋转](custom_text_rotation.png)

## **设置段落的行距**

Aspose.Slides 提供 [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spaceafter/)、[IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacebefore/) 和 [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) 来控制段落间距。用法如下：

* 使用正值将行距指定为行高的百分比。
* 使用负值将行距指定为点数。

下面的示例将第一段落的内部间距设置为行高的 200%（双倍行距）：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![段落内部的行距](line_spacing.png)

## **控制换行规则**

段落换行规则在窄文本块以及混合拉丁文和东亚文字的演示文稿中很有用。以下方法属于 [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/)，因此适用于整个段落：

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) 控制拉丁文字的换行规则。在混合文本中，修改它也会影响相邻东亚文字和标点的换行位置。
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) 控制东亚文字的换行规则，包括行首和行尾字符的限制。

这些规则并不替代 [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/)，后者启用文本框内的自动换行。它们影响换行发生时的布局，而不插入换行符。显式换行会强制在段落内部另起一行，独立于可用宽度。

下面的独立示例创建一个包含中文和拉丁文的窄文本块，显式设置两种换行规则并保存为 “line_breaking.pptx”。要实验任一规则，只需更改对应 setter 的参数值，同时保持其他设置不变。示例使用 24 点 Arial 和 SimSun，框宽 160 点，水平文本框边距为 0。调用 [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) 并传入 [TextAutofitType::None](https://reference.aspose.com/slides/cpp/aspose.slides/textautofittype/) 以固定文本大小和框尺寸。

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 160.0f, 300.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"中文排版测试，PowerPoint 中文演示。");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
auto eastAsianFont = System::MakeObject<FontData>(u"SimSun");
portionFormat->set_EastAsianFont(eastAsianFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_LatinLineBreak(NullableBool::False);
format->set_EastAsianLineBreak(NullableBool::True);

presentation->Save(u"line_breaking.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **控制悬挂标点**

[IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) 允许符合条件的标点超出文本行的右边缘，而不是占用下一行。它作用于整个段落，区别于悬挂缩进。

下面的独立示例在宽度为 100 点的文本框中启用悬挂标点并保存为 “hanging_punctuation.pptx”。使用 24 点 Arial 且水平文本框边距为 0 时，句号仍在 “sentence” 之后，并超出右侧文本边缘。传入 [NullableBool::False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) 可进行对比：在该设置下，句号会占据单独一行。启用换行并禁用自动适配以保持可用宽度固定。

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 200.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"Simple text, next sentence.");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_HangingPunctuation(NullableBool::True);

presentation->Save(u"hanging_punctuation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

并非所有标点都能悬挂。上述 [字体和布局条件](#control-line-breaking) 同样适用于此比较：更改字体、可用宽度、边距或自动适配设置均可能消除可见差异。

## **为文本框设置自动适配类型**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) 决定文本超出容器边界时的行为。可用来控制文本是缩小、溢出还是自动调整形状大小。下面的示例将形状设置为随文本自动调整大小，并将结果保存为 “autofit_type.pptx”。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide> 
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto [...] 
```

要在自动换行后统计行数并查看文本或形状宽度的变化，请参阅 [统计渲染行数](/slides/zh/cpp/manage-paragraph/)。仅行数并不能表明文本是否溢出容器。

## **设置文本框锚点**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) 定义文本在形状内部的垂直定位方式，例如顶部、居中或底部。下面的示例将文本锚定到第一个形状的底部，并将结果保存为 “text_anchor.pptx”。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAnchorType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **设置制表位**

使用 [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) 和 [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_tabs/) 可在段落中配置制表位。下面的示例将默认制表间距设置为 100 点，并在 30 点处添加左对齐的制表位。这些设置会影响包含制表符的文本。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITabCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TabAlignment.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果：

![段落制表位](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供 [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/)，可为文本片段设置校对语言。校对语言决定在 PowerPoint 中进行拼写和语法检查时使用的语言。

下面的示例需要一个在第一张幻灯片第一张形状上为文本框的 “presentation.pptx”，且至少包含一个段落。它将第一段落的内容替换为 “1。”，将字体设为 SimSun，并分配简体中文校对语言 (`zh-CN`)。结果保存为 “proofing_language.pptx”：

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
auto portionFormat = textPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

// 设置校对语言为简体中文。
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **复制语言元数据**

在从模板复制多语言文本时，请同时使用 [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) 和 [IBasePortionFormat::set_AlternativeLanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_alternativelanguageid/) 保留两种语言标识符。下面的独立示例创建一个源片段，其语言为美式英语，备用语言为法语，并将文本及标识符复制到新演示文稿中的片段。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto source = System::MakeObject<Portion>(u"Hello! Bonjour!");
source->get_PortionFormat()->set_LanguageId(u"en-US");
source->get_PortionFormat()->set_AlternativeLanguageId(u"fr-FR");

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto destination = System::MakeObject<Portion>();
destination->set_Text(source->get_Text());
destination->get_PortionFormat()->set_LanguageId(source->get_PortionFormat()->get_LanguageId());
// 如果源没有备用语言，空字符串会清除目标值。
destination->get_PortionFormat()->set_AlternativeLanguageId(source->get_PortionFormat()->get_AlternativeLanguageId());
paragraph->get_Portions()->Add(destination);

presentation->Save(u"copied_language_metadata.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

若要尝试没有备用语言的源，只需省略 `u"fr-FR"` 的赋值。此时备用标识符为 null 字符串，同样的复制语句会保留其缺失状态，而不会引入默认值，即使目标先前已分配了备用语言。

这些标识符存储语言元数据。保留它们并不决定 PowerPoint 在拼写或语法检查时选择哪种词典。

## **设置默认语言**

使用 [LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) 可定义在加载或创建演示文稿时创建的文本的默认语言。下面的示例创建一个默认文本语言为美式英语的演示文稿，添加一个文本框，并输出其第一个文本片段的语言 `en-US`。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// 添加一个带文本的新矩形形状。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// 检查第一个片段的语言。
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用 [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_defaulttextstyle/)。

下面的示例将新演示文稿中顶层段落的默认样式设置为 14 点粗体字体，并保存为 “default_text_style.pptx”。除非更具体的格式覆盖，否则文本会继承这些默认值。

```cpp
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

// 获取顶层段落格式。
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    auto defaultPortionFormat = paragraphFormat->get_DefaultPortionFormat();
    defaultPortionFormat->set_FontHeight(14.0f);
    defaultPortionFormat->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **提取带全大写效果的文本**

在 PowerPoint 中，应用 **全大写** 字体效果会在幻灯片上显示为大写，即使原始输入为小写。当使用 Aspose.Slides 检索此类文本片段时，库会返回实际输入的文本。要匹配显示的文本，需要检查 [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) 并在值为 [TextCapType::All](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) 时将返回的字符串转换为大写。

此示例需要一个在第一张幻灯片第一张形状上为文本框的 “sample2.pptx”。其第一段落的第一个片段包含 “Hello, Aspose!” 并应用了全大写效果，如下所示。

![全大写效果](all_caps_effect.png)

下面的代码示例展示如何提取 **全大写** 效果已应用的文本：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextCapType.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

auto originalText = textPortion->get_Text();
System::Console::WriteLine(u"Original text: " + originalText);

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto uppercaseText = originalText.ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + uppercaseText);
}

presentation->Dispose();
```

输出：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常见问题**

**如何修改幻灯片上表格中的文本？**

要修改幻灯片上表格中的文本，请使用 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)。遍历单元格并通过 [ICell::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) 更新每个单元格，通过 [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) 更新段落格式。

**如何在 PowerPoint 幻灯片上的文本应用渐变颜色？**

要为文本应用渐变颜色，请使用 [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/)。将 [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) 设置为 [FillType::Gradient](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)，并配置渐变停止点、方向和透明度。

相关功能：[在幻灯片中格式化文本](/slides/zh/features/text-formatting/)。