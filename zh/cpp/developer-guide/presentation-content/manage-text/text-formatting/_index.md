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
- 字体族
- 文本旋转
- 旋转角度
- 文本框
- 行距
- 自动适应属性
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

本文展示了如何使用 Aspose.Slides for C++ 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化。内容涵盖背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚点、制表位以及语言设置。

在下面的示例中，我们将使用名为 **sample.pptx** 的文件，该文件在第一张幻灯片上包含一个单独的文本框，文本内容如下：

![示例文本](sample_text.png)

要查找并突出显示文字字面量或正则表达式匹配项，请参阅[搜索并替换文本](/slides/zh/cpp/search-and-replace-text/)。

## **设置文本背景颜色**

使用[IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/)可为段落设置默认的高亮颜色，或使用[IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/)为单独的文本片段设置颜色。

以下代码示例展示了如何为**整个段落**设置背景颜色：

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

// Set the highlight color for the entire paragraph.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果如下：

![灰色段落](gray_paragraph.png)

下面的代码示例演示了如何为**加粗字体的文本片段**设置背景颜色：

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
        // 为文本片段设置高亮颜色。
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果如下：

![灰色文本片段](gray_text_portions.png)

## **对齐文本段落**

使用[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_alignment/)可在文本框内设置段落对齐方式。可选值包括居中、左对齐、右对齐、两端对齐等。

以下代码示例展示了如何将段落对齐到**居中**：

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

结果如下：

![对齐的段落](aligned_paragraph.png)

## **设置文本透明度**

文本透明度通过[IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/get_fillformat/)分配的颜色的 Alpha 分量来控制。下面示例中的 `alpha = 50` 是 0-255 范围的 ARGB Alpha 通道值，而非透明度百分比。

以下代码示例展示了如何为**整个段落**应用透明度：

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

结果如下：

![透明段落](transparent_paragraph.png)

以下代码示例展示了如何为**加粗字体的文本片段**应用透明度：

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

结果如下：

![透明文本片段](transparent_text_portions.png)

## **设置文本字符间距**

使用[IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/set_spacing/)可在文本框中扩展或压缩字符之间的间距。

以下 C++ 代码展示了如何在**整个段落**中扩大字符间距：

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

// 注意：使用负值来压缩字符间距。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // 扩展字符间距。

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果如下：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例展示了如何在**加粗字体的文本片段**中扩大字符间距：

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
        // 注意：使用负值来压缩字符间距。
        portionFormat->set_Spacing(3.0f); // 扩展字符间距。
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果如下：

![文本片段中的字符间距](character_spacing_in_text_portions.png)

### **为特定字体禁用字距调整**

在某些情况下，Aspose.Slides 渲染的文本可能比 PowerPoint 中的相同文本显得更紧密。这可能是因为 PowerPoint 对某些字体会忽略字距调整数据，即使该字体包含有效的字距信息且在 PowerPoint 设置中已启用字距调整。

为使渲染结果更接近 PowerPoint，您可以对使用受影响字体的文本片段禁用字距调整。使用[IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/)设置一个显著大于实际字体大小的值：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
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
        auto latinFont = portionFormat->get_LatinFont();
        auto eastAsianFont = portionFormat->get_EastAsianFont();
        auto complexScriptFont = portionFormat->get_ComplexScriptFont();

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

此设置阻止对匹配的文本片段应用字距调整，帮助 Aspose.Slides 的渲染效果与受此 PowerPoint 特定行为影响的字体的视觉输出保持一致。

## **管理文本字体属性**

可以通过[IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/)在段落层面设置字体属性，或通过[IPortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformat/)在单独的片段上设置。

以下代码为整个段落设置字体和文本样式：为段落中的所有片段应用字体大小、加粗、斜体、点状下划线以及 Times New Roman 字体。

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

// 为段落设置字体属性。
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

结果如下：

![段落的字体属性](font_properties_for_paragraph.png)

下面的代码示例对**加粗字体的文本片段**应用了相同的属性：

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

结果如下：

![文本片段的字体属性](font_properties_for_text_portions.png)

## **设置文本旋转**

使用[ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/set_textverticaltype/)可在形状内设置预定义的文本方向。

以下代码示例将形状内的文本方向设置为[TextVerticalType::Vertical270](https://reference.aspose.com/slides/zh/cpp/aspose.slides/textverticaltype/)，这会使文本**逆时针旋转90度**：

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

结果如下：

![文本旋转](text_rotation.png)

## **为文本框设置自定义旋转**

使用[ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/set_rotationangle/)可为[ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)设置自定义旋转角度。

下面的代码示例将在形状内将文本框顺时针旋转 3 度：

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

结果如下：

![自定义文本旋转](custom_text_rotation.png)

## **设置段落行距**

Aspose.Slides 提供[IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_spaceafter/)、[IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_spacebefore/)和[IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_spacewithin/)来控制段落间距。使用方式如下：

* 使用正值可将行距指定为行高的百分比。
* 使用负值可将行距指定为磅值。

以下代码示例展示了如何在段落内部指定行距：

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

结果如下：

![段落内的行距](line_spacing.png)

## **设置文本框的自动适应类型**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/set_autofittype/)决定当文本超出容器边界时的行为。可用于控制文本是缩小、溢出还是自动调整形状大小。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto firstShape = presentation->get_Slide(0)->get_Shape(0);
auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **设置文本框锚点**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/set_anchoringtype/)定义文本在形状内部的垂直定位方式，例如顶部、居中或底部。

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

## **设置文本制表**

使用[IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/)和[IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/get_tabs/)可在段落中配置制表位。

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

结果如下：

![段落制表](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供[IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/set_languageid/)，可为文本片段设置校对语言。校对语言决定在 PowerPoint 中进行拼写和语法检查时使用的语言。

以下代码示例展示了如何为文本片段设置校对语言：

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

// 设置校对语言的 Id。
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **设置默认语言**

使用[ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/)可定义在加载或创建演示文稿时创建的文本的默认语言。

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

// 检查第一个文本片段的语言。
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，可使用[IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_defaulttextstyle/)。

以下代码示例展示了如何在新演示文稿的所有幻灯片中为所有文本设置默认的 **14 磅加粗字体**：

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

// 获取顶级段落格式。
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

## **提取全大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会让文本在幻灯片上显示为大写，即使原始输入是小写。当使用 Aspose.Slides 检索此类文本片段时，库会返回原始输入的文本。要使显示的文本保持一致，需要检查[TextCapType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/textcaptype/)并在值为[TextCapType::All](https://reference.aspose.com/slides/zh/cpp/aspose.slides/textcaptype/)时将返回的字符串转换为大写。

假设我们在 sample2.pptx 文件的第一张幻灯片上有如下文本框：

![全大写效果](all_caps_effect.png)

下面的代码示例展示了如何提取已应用 **All Caps** 效果的文本：

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

**如何在幻灯片的表格中修改文本？**

要在幻灯片的表格中修改文本，请使用[ITable](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itable/)。遍历单元格并通过[ICell::get_TextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icell/get_textframe/)以及通过[IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/get_paragraphformat/)更新每个单元格的段落格式。

**如何在 PowerPoint 幻灯片的文本中应用渐变颜色？**

要对文本应用渐变颜色，请使用[IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/get_fillformat/)。将[IFillFormat::set_FillType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifillformat/set_filltype/)设置为[FillType::Gradient](https://reference.aspose.com/slides/zh/cpp/aspose.slides/filltype/)，并配置渐变停靠点、方向和透明度。