---
title: 以 C++ 格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/cpp/text-formatting/
keywords:
- 突顯文字
- 正規表達式
- 對齊段落
- 文字樣式
- 文字背景
- 文字透明度
- 字元間距
- 字型屬性
- 字型族
- 文字旋轉
- 旋轉角度
- 文字方塊
- 行距
- 自動調整屬性
- 文字方塊錨點
- 文字定位
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 與 OpenDocument 簡報中格式化與樣式化文字。自訂字型、顏色、對齊等多項設定。"
---
## **概述**

本文說明如何使用 Aspose.Slides for C++ 在 PowerPoint 與 OpenDocument 簡報中格式化文字。內容涵蓋突顯、背景顏色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點以及語言設定。

在以下範例中，我們將使用名為「sample.pptx」的檔案，該檔案在第一張投影片上包含一個文字方塊，文字如下：

![範例文字](sample_text.png)

## **突顯文字**

當需要突顯文字方塊中符合特定樣本的文字時，請使用 [ITextFrame.HighlightText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/highlighttext/) 方法。此方法會將突顯顏色套用於符合的文字片段，並可與 [ITextSearchOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextsearchoptions/) 結合，以控制搜尋方式，例如僅匹配完整單字。

以下程式碼範例先突顯所有 **"try"** 字元，然後僅突顯完整單字 **"to"**。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// 從第一張投影片取得第一個圖形。
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// 在圖形中突顯單字 "try"。
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// 在圖形中突顯單字 "to"。
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![已突顯的文字](highlighted_text.png)

## **使用正規表達式突顯文字**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/highlightregex/) 方法會突顯正規表達式找到的文字匹配項目。在 C++ 中，此 API 於 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 上公開。

以下程式碼範例突顯所有包含 **七個或以上字元** 的單字：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// Highlight all words with seven or more characters.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![使用正規表達式突顯的文字](highlighted_text_using_regex.png)

## **設定文字背景顏色**

使用 [IParagraphFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` 來設定段落的預設突顯顏色，或使用 [IPortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportionformat/)`.HighlightColor` 針對個別文字片段設定。

以下程式碼示範如何為 **整段文字** 設定背景顏色：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Set the highlight color for the entire paragraph.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼示範如何為 **粗體字型的文字片段** 設定背景顏色：

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
        // 設定文字片段的突顯顏色。
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![灰色文字片段](gray_text_portions.png)

## **對齊文字段落**

使用 [IParagraphFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/)`.Alignment` 設定文字方塊內段落的對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼示範如何將段落對齊至 **置中**：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// 設定段落的對齊方式為置中。
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![已對齊的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給 [IPortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportionformat/)`.FillFormat` 的顏色之 alpha 成分來控制。以下示例中，`alpha = 50` 為 0‑255 範圍內的 ARGB alpha 通道值，並非透明度百分比。

以下程式碼示範如何對 **整段文字** 套用透明度：

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// 設定文字的填充顏色為透明顏色。
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼示範如何對 **粗體字型的文字片段** 套用透明度：

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
        // 設定文字片段的透明度。
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![透明文字片段](transparent_text_portions.png)

## **設定文字字元間距**

使用 [IBasePortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibaseportionformat/)`.Spacing` 來擴大或收縮文字方塊中字元之間的間距。

以下 C++ 程式碼示範如何在 **整段文字** 中擴大字元間距：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// 注意: 使用負值壓縮字元間距。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼示範如何在 **粗體字型的文字片段** 中擴大字元間距：

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
        // 注意: 使用負值壓縮字元間距。
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![文字片段中的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距微調 (Kerning)**

在某些情況下，Aspose.Slides 所渲染的文字可能比 PowerPoint 中的相同文字稍為緊密。這可能是因為 PowerPoint 會忽略某些字型的字距微調資料，即使該字型包含有效的字距微調資訊且在 PowerPoint 設定中已啟用字距微調。

若要使渲染結果更接近 PowerPoint，可對使用受影響字型的文字片段停用字距微調。將 [IPortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` 設為遠大於實際字型大小的值：

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

此設定可防止對符合條件的文字片段套用字距微調，協助將 Aspose.Slides 的渲染結果與 PowerPoint 在受此 PowerPoint 特定行為影響的字型上達成視覺一致。

## **管理文字字型屬性**

字型屬性可以透過 [IParagraphFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` 在段落層級設定，或透過 [IPortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportionformat/) 在個別文字片段層級設定。

以下程式碼為整段文字設定字型與文字樣式：套用字型大小、粗體、斜體、點狀底線，以及 Times New Roman 字型至段落中的所有文字片段。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// 設定段落的字型屬性。
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![段落的字型屬性](font_properties_for_paragraph.png)

以下程式碼示範對 **粗體字型的文字片段** 套用相同的屬性：

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
        // 設定文字片段的字型屬性。
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![文字片段的字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` 可在形狀內設定預定義的文字方向。

以下程式碼將形狀內的文字方向設為 `Vertical270`，即將文字 **逆時針旋轉 90 度**：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![文字旋轉](text_rotation.png)

## **為文字方塊設定自訂旋轉角度**

使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/)`.RotationAngle` 可為 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 設定自訂旋轉角度。

以下程式碼在形狀內將文字方塊順時針旋轉 3 度：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落的行距**

Aspose.Slides 提供 [IParagraphFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`、`IParagraphFormat.SpaceBefore` 與 `IParagraphFormat.SpaceWithin` 以控制段落間距。這些屬性的用法如下：

* 使用正值以百分比指定行距（相對於行高）。
* 使用負值以點數指定行距。

以下程式碼示範如何在段落內指定行距：

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![段落內的行距](line_spacing.png)

## **設定文字方塊的自動調整類型**

[ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/)`.AutofitType` 決定文字超出容器邊界時的行為。使用它可控制文字是縮小、溢出，或自動調整形狀大小。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **設定文字方塊的錨點**

[ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframeformat/)`.AnchoringType` 定義文字在形狀內的垂直定位方式，例如置頂、置中或置底。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **設定文字定位點 (Tab)**

使用 [IParagraphFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` 與 `IParagraphFormat.Tabs` 來配置段落中的定位點。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![段落的定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [IPortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportionformat/)`.LanguageId`，可為文字片段設定校對語言。校對語言決定 PowerPoint 進行拼寫與文法檢查時使用的語言。

以下程式碼示範如何為文字片段設定校對語言：

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

// 設定校對語言的 Id.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **設定預設語言**

使用 [ILoadOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` 來定義載入或建立簡報時所建立文字的預設語言。

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

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [IPresentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle`。

以下程式碼示範如何在新簡報中為所有投影片的文字設定預設 **粗體、14 點** 的字型。

```cpp
auto presentation = System::MakeObject<Presentation>();

// 取得最高層級的段落格式。
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **擷取套用全大寫效果的文字**

在 PowerPoint 中，套用 **全大寫** 字體效果會讓文字在投影片上以大寫顯示，即使原始輸入為小寫。使用 Aspose.Slides 取得此類文字片段時，函式庫會返回原始輸入的文字。若要與顯示的文字相符，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textcaptype/) 並在值為 `All` 時將回傳的字串轉為大寫。

假設我們在 sample2.pptx 檔案的第一張投影片上有以下文字方塊。

![全大寫效果](all_caps_effect.png)

以下程式碼示範如何擷取套用 **全大寫** 效果的文字：

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

輸出：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常見問題**

**如何修改投影片中表格的文字？**

若要修改投影片中表格的文字，請使用 [ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/)。遍歷儲存格，並透過 [ICell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icell/)`.TextFrame` 以及透過 [IParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/)`.ParagraphFormat` 更新每個儲存格的段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**

若要為文字套用漸層顏色，請使用 [IPortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iportionformat/)`.FillFormat`。將 [IFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifillformat/)`.FillType` 設為 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/)`.Gradient`，並配置漸層停止點、方向與透明度。