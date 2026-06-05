---
title: 在 C++ 中格式化演示文稿文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/cpp/text-formatting/
keywords:
- 高亮文本
- 正则表达式
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
- 文本制表位
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 演示文稿中格式化和美化文本。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 演示文稿中格式化文本。内容包括高亮、背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚定、制表位以及语言设置。

在下面的示例中，我们将使用名为“sample.pptx”的文件，该文件在第一张幻灯片上包含一个文本框，里面包含以下文本：

![示例文本](sample_text.png)

## **高亮文本**

当您需要在文本框中高亮匹配特定样本的文本时，请使用[ITextFrame.HighlightText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlighttext/) 方法。该方法会对匹配的文本片段应用高亮颜色，并可结合[ITextSearchOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextsearchoptions/) 来控制搜索方式，例如仅匹配完整单词。

下面的代码示例先高亮所有字符 **"try"** 的出现，然后仅高亮完整单词 **"to"**。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// 获取第一张幻灯片上的第一个形状。
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// 在形状中高亮单词 "try"。
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// 在形状中高亮单词 "to"。
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![已高亮的文本](highlighted_text.png)

## **使用正则表达式高亮文本**

使用[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/highlightregex/) 方法可以高亮正则表达式匹配的文本。在 C++ 中，此 API 在[ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 上公开。

下面的代码示例高亮所有包含 **七个或以上字符** 的单词：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![使用正则表达式高亮的文本](highlighted_text_using_regex.png)

## **设置文本背景颜色**

使用[IParagraphFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` 来设置段落的默认高亮颜色，或使用[IPortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformat/)`.HighlightColor` 为单个文本片段设置颜色。

以下代码示例演示如何为 **整个段落** 设置背景颜色：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// 设置整个段落的高亮颜色。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![灰色段落](gray_paragraph.png)

以下代码示例演示如何为 **加粗字体的文本片段** 设置背景颜色：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // 设置文本片段的高亮颜色。
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![灰色文本片段](gray_text_portions.png)

## **对齐文本段落**

使用[IParagraphFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/)`.Alignment` 可设置文本框内段落的对齐方式。该属性可以设为居中、左对齐、右对齐、两端对齐等。

以下代码示例展示如何将段落对齐至 **居中**：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// 将段落的对齐方式设置为居中。
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![已对齐的段落](aligned_paragraph.png)

## **设置文本透明度**

文本透明度通过分配给[IPortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformat/)`.FillFormat` 的颜色的 alpha 分量来控制。在下面的示例中，`alpha = 50` 是 0-255 范围内的 ARGB alpha 通道值，而不是透明度百分比。

以下代码示例展示如何为 **整个段落** 应用透明度：

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Set the fill color of the text to transparent color.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![透明段落](transparent_paragraph.png)

以下代码示例展示如何为 **加粗字体的文本片段** 应用透明度：

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // 设置文本片段的透明度。
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![透明文本片段](transparent_text_portions.png)

## **设置文本字符间距**

使用[IBasePortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseportionformat/)`.Spacing` 可在文本框中扩大或缩小字符之间的间距。

以下 C++ 代码展示如何在 **整个段落** 中扩展字符间距：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// 注意：使用负值来压缩字符间距。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![段落中的字符间距](character_spacing_in_paragraph.png)

以下代码示例展示如何在 **加粗字体的文本片段** 中扩展字符间距：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // 注意：使用负值来压缩字符间距。
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![文本片段中的字符间距](character_spacing_in_text_portions.png)

### **为特定字体禁用字距调整**

在某些情况下，Aspose.Slides 渲染的文本可能看起来比 PowerPoint 中显示的相同文本略紧。这可能是因为 PowerPoint 会忽略某些字体的字距信息，即使该字体包含有效的字距数据且在 PowerPoint 设置中已启用字距。

为使渲染输出更接近 PowerPoint，可针对使用受影响字体的文本片段禁用字距。将[IPortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` 设置为明显大于实际字体大小的值：

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
System::String targetFont = u"Roboto";
auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = paragraphs->idx_get(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = portions->idx_get(portionIndex);
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

此设置可阻止对匹配的文本片段应用字距调整，有助于使 Aspose.Slides 的渲染在受此 PowerPoint 特定行为影响的字体上与 PowerPoint 的视觉输出保持一致。

## **管理文本字体属性**

字体属性可以通过[IParagraphFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` 在段落级别设置，或通过[IPortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformat/) 在单个文本片段上设置。

以下代码为整个段落设置字体和文本样式：它对段落中的所有片段应用字体大小、粗体、斜体、点状下划线以及 Times New Roman 字体。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// 为段落设置字体属性。
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![段落的字体属性](font_properties_for_paragraph.png)

以下代码示例将相似属性应用于 **加粗字体的文本片段**：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // 为文本片段设置字体属性。
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![文本片段的字体属性](font_properties_for_text_portions.png)

## **设置文本旋转**

使用[ITextFrameFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` 可在形状内设置预定义的文本方向。

以下代码示例将形状内的文本方向设置为 `Vertical270`，这会使文本 **逆时针旋转 90 度**：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![文本旋转](text_rotation.png)

## **为文本框设置自定义旋转**

使用[ITextFrameFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/)`.RotationAngle` 可为[ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/) 设置自定义旋转角度。

以下代码示例在形状内将文本框顺时针旋转 3 度：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![自定义文本旋转](custom_text_rotation.png)

## **设置段落行距**

Aspose.Slides 提供[IParagraphFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`、`IParagraphFormat.SpaceBefore` 和 `IParagraphFormat.SpaceWithin` 来控制段落间距。使用方式如下：

* 使用正值指定行距为行高的百分比。
* 使用负值指定行距的磅值。

以下代码示例展示如何在段落内指定行距：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![段落内的行距](line_spacing.png)

## **设置文本框的自动适应类型**

[ITextFrameFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/)`.AutofitType` 确定文本超出容器边界时的行为。使用它可以控制文本是收缩、溢出还是自动调整形状大小。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **设置文本框锚点**

[ITextFrameFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframeformat/)`.AnchoringType` 定义文本在形状内部的垂直位置，例如顶部、居中或底部。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **设置文本制表位**

使用[IParagraphFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` 和 `IParagraphFormat.Tabs` 可在段落中配置制表位。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![段落制表位](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供[IPortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformat/)`.LanguageId`，可为文本片段设置校对语言。校对语言决定 PowerPoint 在拼写和语法检查时使用的语言。

以下代码示例展示如何为文本片段设置校对语言：

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
textPortion->get_PortionFormat()->set_ComplexScriptFont(font);
textPortion->get_PortionFormat()->set_EastAsianFont(font);
textPortion->get_PortionFormat()->set_LatinFont(font);

// 设置校对语言的 Id.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **设置默认语言**

使用[ILoadOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` 可定义在加载或创建演示文稿时创建的文本的默认语言。

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// 添加一个带文本的新矩形形状。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// 检查第一个文本片段的语言。
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，可使用[IPresentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`。

以下代码示例展示如何在新演示文稿中为所有幻灯片的文本设置默认的粗体、14 磅大小的字体。

```cpp
auto presentation = System::MakeObject<Presentation>();

// 获取顶级段落格式。
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **提取全大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会使文本在幻灯片上显示为大写，即使原始输入为小写。使用 Aspose.Slides 检索此类文本片段时，库会返回原始输入的文本。要匹配显示的文本，需要检查[TextCapType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/textcaptype/) 并在其值为 `All` 时将返回的字符串转换为大写。

假设在 sample2.pptx 文件的第一张幻灯片上有如下文本框。

![全大写效果](all_caps_effect.png)

以下代码示例展示如何提取已应用 **All Caps** 效果的文本：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

System::Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```

```text
原始文本: Hello, Aspose!
全大写效果: HELLO, ASPOSE!
```

## **常见问题**

**如何在幻灯片的表格中修改文本？**

要在幻灯片的表格中修改文本，可使用[ITable](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itable/)。遍历单元格，并通过[ICell](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icell/)`.TextFrame` 更新每个单元格，以及通过[IParagraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iparagraph/)`.ParagraphFormat` 更新段落格式。

**如何在 PowerPoint 幻灯片的文本上应用渐变颜色？**

要对文本应用渐变颜色，可使用[IPortionFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iportionformat/)`.FillFormat`。将[IFillFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ifillformat/)`.FillType` 设置为[FillType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/filltype/)`.Gradient`，并配置渐变停止点、方向和透明度。