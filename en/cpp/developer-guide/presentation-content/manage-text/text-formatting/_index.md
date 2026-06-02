---
title: Format Presentation Text in C++
linktitle: Text Formatting
type: docs
weight: 50
url: /cpp/text-formatting/
keywords:
- highlight text
- regular expression
- align paragraph
- text style
- text background
- text transparency
- character spacing
- font properties
- font family
- text rotation
- rotation angle
- text frame
- line spacing
- autofit property
- text frame anchor
- text tabulation
- default language
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Format and style text in PowerPoint and OpenDocument presentations using Aspose.Slides for C++. Customize fonts, colors, alignment, and more."
---

## **Overview**

This article shows how to format text in PowerPoint and OpenDocument presentations using Aspose.Slides for C++. It covers highlighting, background colors, transparency, character spacing, font properties, rotation, paragraph spacing, autofit behavior, text anchoring, tab stops, and language settings.

In the examples below, we'll use a file named "sample.pptx", which contains a single text box on the first slide with the following text:

![Sample text](sample_text.png)

## **Highlight Text**

Use the [ITextFrame.HighlightText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/highlighttext/) method when you need to highlight text that matches a specific sample within a text frame. The method applies a highlight color to matching text fragments and can be used with [ITextSearchOptions](https://reference.aspose.com/slides/cpp/aspose.slides/itextsearchoptions/) to control how the search is performed, for example, to match only whole words.

The code example below highlights all occurrences of the characters **"try"** and then highlights only the full word **"to"**.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// Get the first shape from the first slide.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Highlight the word "try" in the shape.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// Highlight the word "to" in the shape.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The highlighted text](highlighted_text.png)

## **Highlight Text Using Regular Expressions**

The [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/highlightregex/) method highlights text matches found by a regular expression. In C++, this API is exposed on [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).

The code example below highlights all words that contain **seven or more characters**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Set Text Background Color**

Use [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` to set the default highlight color for a paragraph, or use [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/)`.HighlightColor` for individual text portions.

The following code example shows how to set the background color for the **entire paragraph**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Set the highlight color for the entire paragraph.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The gray paragraph](gray_paragraph.png)

The code example below demonstrates how to set the background color for **text portions with a bold font**:

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
        // Set the highlight color for the text portion.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The gray text portions](gray_text_portions.png)

## **Align Text Paragraphs**

Use [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/)`.Alignment` to set paragraph alignment within a text frame. The value can be centered, left-aligned, right-aligned, justified, and so on.

The following code example shows how to align the paragraph to the **center**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Set the alignment of the paragraph to center.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The aligned paragraph](aligned_paragraph.png)

## **Set Transparency for Text**

Text transparency is controlled through the alpha component of the color assigned to [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/)`.FillFormat`. In the examples below, `alpha = 50` is an ARGB alpha-channel value on the 0-255 scale, not a transparency percentage.

The code example below shows how to apply transparency to the **entire paragraph**:

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

The result:

![The transparent paragraph](transparent_paragraph.png)

The following code example shows how to apply transparency to **text portions with a bold font**:

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
        // Set the transparency of the text portion.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The transparent text portions](transparent_text_portions.png)

## **Set Character Spacing for Text**

Use [IBasePortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/)`.Spacing` to expand or condense spacing between characters in a text box.

The following C++ code shows how to expand the character spacing in the **entire paragraph**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Note: Use negative values to compress the character spacing.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

The code example below shows how to expand the character spacing in **text portions with a bold font**:

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
        // Note: Use negative values to compress the character spacing.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Disable Kerning for Specific Fonts**

In some cases, text rendered by Aspose.Slides may look slightly tighter than the same text displayed in PowerPoint. This can happen because PowerPoint may ignore kerning data for certain fonts, even when the font contains valid kerning information and kerning is enabled in PowerPoint settings.

To make the rendered output closer to PowerPoint in such cases, you can disable kerning for text portions that use the affected font. Set [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` to a value significantly larger than the actual font size:

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

This setting prevents kerning from being applied to matching text portions and can help align Aspose.Slides rendering with PowerPoint's visual output for fonts affected by this PowerPoint-specific behavior.

## **Manage Text Font Properties**

Font properties can be set at the paragraph level through [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` or on individual portions through [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/).

The following code sets the font and text style for the entire paragraph: it applies font size, bold, italic, dotted underline, and the Times New Roman font to all portions in the paragraph.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// Set the font properties for the paragraph.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The font properties for the paragraph](font_properties_for_paragraph.png)

The code example below applies similar properties to **text portions with a bold font**:

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
        // Set the font properties for the text portion.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Set Text Rotation**

Use [ITextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` to set a predefined text orientation within a shape.

The following code example sets the text orientation in the shape to `Vertical270`, which rotates the text **90 degrees counterclockwise**:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The text rotation](text_rotation.png)

## **Set Custom Rotation for Text Frames**

Use [ITextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/)`.RotationAngle` to set a custom rotation angle for an [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).

The code example below rotates the text frame by 3 degrees clockwise within the shape:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The custom text rotation](custom_text_rotation.png)

## **Set Line Spacing of Paragraphs**

Aspose.Slides provides [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`, `IParagraphFormat.SpaceBefore`, and `IParagraphFormat.SpaceWithin` to control paragraph spacing. These properties are used as follows:

* Use a positive value to specify line spacing as a percentage of the line height.
* Use a negative value to specify line spacing in points.

The following code example shows how to specify the line spacing within the paragraph:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The line spacing within the paragraph](line_spacing.png)

## **Set Autofit Type for Text Frames**

[ITextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/)`.AutofitType` determines how text behaves when it exceeds the boundaries of its container. Use it to control whether the text shrinks, overflows, or resizes the shape automatically.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Set Anchor of Text Frames**

[ITextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/)`.AnchoringType` defines how text is positioned vertically inside a shape, for example at the top, middle, or bottom.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Set Text Tabulation**

Use [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` and `IParagraphFormat.Tabs` to configure tab stops in a paragraph.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The paragraph tabs](paragraph_tabs.png)

## **Set Proofing Language**

Aspose.Slides provides [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/)`.LanguageId`, which allows you to set the proofing language for a text portion. The proofing language determines the language used for spelling and grammar checks in PowerPoint.

The following code example shows how to set the proofing language for a text portion:

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

// Set the Id of a proofing language.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Set Default Language**

Use [ILoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` to define the default language for text created while loading or creating a presentation.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// Add a new rectangle shape with text.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Check the first portion language.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **Set Default Text Style**

To apply default text formatting at the presentation level, use [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`.

The following code example shows how to set a default bold font with a 14 pt size for all text across slides in a new presentation.

```cpp
auto presentation = System::MakeObject<Presentation>();

// Get the top level paragraph format.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Extract Text with the All-Caps Effect**

In PowerPoint, applying the **All Caps** font effect makes text appear in uppercase on the slide even when it was originally typed in lowercase. When you retrieve such a text portion with Aspose.Slides, the library returns the text exactly as it was entered. To match the displayed text, check [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) and convert the returned string to uppercase when the value is `All`.

Let's say we have the following text box on the first slide of the sample2.pptx file.

![The All Caps effect](all_caps_effect.png)

The code example below shows how to extract the text with the **All Caps** effect applied:

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

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**How to modify text in a table on a slide?**

To modify text in a table on a slide, use [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Iterate through the cells and update each cell through [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)`.TextFrame` and paragraph formatting through [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/)`.ParagraphFormat`.

**How to apply gradient color to text in a PowerPoint slide?**

To apply a gradient color to text, use [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/)`.FillFormat`. Set [IFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/)`.FillType` to [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/)`.Gradient` and configure the gradient stops, direction, and transparency.
