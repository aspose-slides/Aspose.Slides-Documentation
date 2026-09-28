---
title: C++ でプレゼンテーションテキストをフォーマット
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/cpp/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキストの背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリー
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションでテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for C++ を使用して PowerPoint および OpenDocument プレゼンテーションのテキストの書式設定方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカー設定、タブ位置、言語設定などを取り上げます。

特に記載がない限り、例は [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキストボックスで、最初の段落に以下に示すテキストが含まれています。スライドとシェイプのインデックスはゼロベースです。太字部分を選択する例は、継承された太字書式を含む実効書式を使用します：

![Sample text](sample_text.png)

リテラルテキストや正規表現の一致箇所を検索してハイライトする方法については、[Search and Replace Text](/slides/ja/cpp/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定**

[IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) を使用して段落のデフォルトハイライト色を設定し、個々のテキスト部分には [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) を使用します。

以下の例は、最初の段落のデフォルトとして薄いグレーのハイライトを設定します。個々の部分で明示的に設定したハイライト色はこのデフォルトより優先されます：

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

// 段落全体のハイライト色を設定します。
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The gray paragraph](gray_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**の背景色を設定する方法を示します：

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
        // テキスト部分のハイライト色を設定します。
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The gray text portions](gray_text_portions.png)

## **テキスト段落の配置**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_alignment/) を使用してテキストフレーム内の段落配置を設定できます。値は中央揃え、左揃え、右揃え、両端揃えなどが指定可能です。

以下のコード例は、段落を **中央** に揃える方法を示します：

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

// 段落の配置を中央に設定します。
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The aligned paragraph](aligned_paragraph.png)

## **テキストの透明度を設定**

テキストの透明度は、[IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/get_fillformat/) で取得できる色のアルファ成分で制御します。以下の例では `alpha = 50` は 0〜255 のスケールの ARGB アルファチャネル値であり、透明率ではありません。

以下のコード例は、**段落全体**に透明度を適用する方法を示します：

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

// テキストの塗りつぶし色を透明色に設定します。
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The transparent paragraph](transparent_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**に透明度を適用する方法を示します：

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
        // テキスト部分の透明度を設定します。
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The transparent text portions](transparent_text_portions.png)

## **テキストの文字間隔を設定**

[IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_spacing/) を使用してテキストボックス内の文字間隔を拡大または縮小できます。例では 3 ポイントの間隔を追加しています。負の値を指定すると文字が詰まります。

以下の C++ コードは、**段落全体**の文字間隔を拡大する方法を示します：

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

// 注: 文字間隔を圧縮するには負の値を使用します。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // 文字間隔を拡大します。

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**の文字間隔を拡大する方法を示します：

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
        // 注: 文字間隔を圧縮するには負の値を使用します。
        portionFormat->set_Spacing(3.0f); // 文字間隔を拡大します。
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効化**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint の表示よりわずかに詰まって見えることがあります。これは、PowerPoint が特定フォントのカーニング情報を無視するためです。

このような場合、影響を受けるフォントを使用しているテキスト部分のカーニングを無効化できます。[IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) で実際のフォントサイズより大きな値を設定します。この例は、最初のスライドの最初のシェイプがテキストボックスである「presentation.pptx」を前提とし、継承フォントを含む実効フォント名をチェックし、Roboto を使用している部分に対して 100 ポイントの閾値を設定します。これにより、100 ポイント未満のフォントサイズの該当部分のカーニングが無効化されます：

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

この設定は、閾値以下の該当テキストのカーニングを防ぎ、PowerPoint の特定動作による差異を Aspose.Slides の描画結果と一致させるのに役立ちます。

## **テキストのフォントプロパティを管理**

フォントプロパティは、[IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) で段落レベルに、[IPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformat/) で個々の部分に設定できます。

以下の例は、最初の段落のデフォルトフォントを 12 ポイントの Times New Roman に設定し、太字・イタリック・点線下線を適用します。個別部分の明示的な書式設定はこれらのデフォルトより優先されます：

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

// 段落のフォントプロパティを設定します。
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The font properties for the paragraph](font_properties_for_paragraph.png)

以下の例は、実効書式が太字である部分に対して 13 ポイントの Times New Roman、イタリック、点線下線を適用します：

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
            // テキスト部分のフォントプロパティを設定します。
            portionFormat->set_FontHeight(13.0f);
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
            portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The font properties for text portions](font_properties_for_text_portions.png)

## **テキストの回転を設定**

[ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_textverticaltype/) を使用してシェイプ内のテキスト向きを事前定義できます。

以下のコード例は、シェイプ内のテキスト向きを [TextVerticalType::Vertical270](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textverticaltype/) に設定し、テキストを **時計回り 90 度** 回転させます：

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

結果：

![The text rotation](text_rotation.png)

## **テキストフレームのカスタム回転を設定**

[ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_rotationangle/) を使用して [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) の任意の回転角度を設定できます。

以下のコード例は、シェイプ内のテキストフレームを時計回りに 3 度回転させます：

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

結果：

![The custom text rotation](custom_text_rotation.png)

## **段落の行間を設定**

Aspose.Slides は [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_spaceafter/)、[IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_spacebefore/)、[IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_spacewithin/) を提供し、段落間隔を制御します。使用方法は次のとおりです。

* 正の値は行の高さのパーセンテージとして行間を指定します。
* 負の値はポイント単位で行間を指定します。

以下の例は、最初の段落の行間を行高さの 200%（倍行間）に設定します：

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

結果：

![The line spacing within the paragraph](line_spacing.png)

## **改行の制御**

段落の改行規則は、狭いテキストブロックやラテン文字と東アジア文字が混在するプレゼンテーションで有用です。以下のメソッドはすべて [IParagraphFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/) に属し、段落全体に適用されます。

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) はラテン文字の改行規則を制御します。混在テキストでは、隣接する東アジア文字や句読点の折り返し位置にも影響します。
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) は東アジア文字の改行規則を制御し、行頭・行末の文字制限などを設定します。

これらの規則は、テキストフレーム内で自動折り返しを有効にする [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_wraptext/) を置き換えるものではありません。折り返しが発生した際のレイアウトに影響を与えますが、改行文字を挿入するわけではありません。明示的な改行は、幅に関係なく段落内で新しい行を強制します。

以下のセルフコンテインド例は、中文とラテン文字を含む狭いテキストブロックを作成し、両方の改行規則を明示的に設定して「line_breaking.pptx」として保存します。どちらか一方の規則だけを試したい場合は、対応するセッターに渡す値を変更し、もう一方はそのままにします。例では 24 ポイントの Arial と SimSun を使用し、フレーム幅 160 ポイント、水平テキストフレーム余白は 0 に設定しています。[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_autofittype/) には [TextAutofitType::None](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textautofittype/) を指定し、テキストサイズとフレーム寸法を固定しています。

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

## **ハンギング句読点の制御**

[IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) を使用すると、対象となる句読点がテキスト行の右端を超えて表示され、次の行を占有しなくなります。段落全体に適用され、ハンギングインデントとは異なります。

以下のセルフコンテインド例は、幅 100 ポイントのテキストフレームでハンギング句読点を有効にし、「hanging_punctuation.pptx」として保存します。24 ポイントの Arial、水平余白 0 の設定で、最後のピリオドは「sentence」の後に残り、右端を超えて表示されます。比較のために [NullableBool::False](https://reference.aspose.com/slides/ja/cpp/aspose.slides/nullablebool/) を渡すと、ピリオドが別行に配置されます。折り返しは有効、オートフィットは無効にして幅を固定しています。

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

すべての句読点がハンギングできるわけではありません。可視結果はフォントやレイアウトに依存し、フォントや幅、余白、オートフィット設定を変更すると差異が消えることがあります。

## **テキストフレームのオートフィットタイプを設定**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_autofittype/) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、シェイプを自動的にリサイズするかを制御できます。以下の例は、シェイプがテキストに合わせてリサイズされるように設定し、結果を「autofit_type.pptx」として保存します。

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

自動折り返し後の行数をカウントし、テキストまたはシェイプ幅の変化が結果に与える影響を確認する方法については、[Count Rendered Lines](/slides/ja/cpp/manage-paragraph/) を参照してください。行数だけではテキストがコンテナをはみ出しているかどうかは判断できません。

## **テキストフレームのアンカーを設定**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_anchoringtype/) は、シェイプ内でテキストを垂直方向に配置する方法（上部、中央、下部など）を定義します。以下の例は、最初のシェイプのテキストを下部に固定し、結果を「text_anchor.pptx」として保存します。

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

## **テキストのタブ設定**

[IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) と [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/get_tabs/) を使用して段落のタブ位置を構成できます。以下の例は、デフォルトタブ間隔を 100 ポイントに設定し、30 ポイント位置に左揃えタブを追加します。これらの設定はタブ文字を含むテキストに影響します。

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

結果：

![The paragraph tabs](paragraph_tabs.png)

## **校正言語を設定**

[IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_languageid/) を使用すると、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックや文法チェックに使用される言語を決定します。

以下の例は、最初のスライドの最初のシェイプがテキストボックスである「presentation.pptx」を前提とし、最初の段落の内容を「1。」に置き換え、フォントを SimSun、校正言語を簡体字中国語 (`zh-CN`) に設定し、結果を「proofing_language.pptx」として保存します。

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

// 校正言語を簡体字中国語に設定します。
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **デフォルト言語を設定**

[LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) を使用すると、プレゼンテーションのロードまたは作成時に作成されるテキストのデフォルト言語を定義できます。以下の例は、デフォルトテキスト言語を米国英語に設定したプレゼンテーションを作成し、テキストボックスを追加して最初のテキスト部分の言語コードとして `en-US` を出力します。

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

// 新しい長方形シェイプをテキスト付きで追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// 最初のテキスト部分の言語を確認します。
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **デフォルトテキストスタイルを設定**

プレゼンテーション全体のデフォルトテキスト書式を適用するには、[IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_defaulttextstyle/) を使用します。

以下の例は、新規プレゼンテーションのトップレベル段落に対して 14 ポイントの太字フォントをデフォルトとして設定し、結果を「default_text_style.pptx」として保存します。テキストはこれらのデフォルトを継承しますが、より具体的な書式設定が上書きします。

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

// トップレベルの段落書式を取得します。
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

## **オールキャップ効果付きテキストの抽出**

PowerPoint では、**All Caps** フォント効果を適用すると、スライド上では大文字で表示されますが、元の入力は小文字のままです。Aspose.Slides でそのテキスト部分を取得すると、元のままの文字列が返されます。表示通りに取得するには、[TextCapType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textcaptype/) を確認し、値が [TextCapType::All](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textcaptype/) の場合は文字列を大文字に変換します。

この例は、最初のスライドの最初のシェイプがテキストボックスである「sample2.pptx」を前提とし、最初の段落の最初の部分に All Caps 効果が適用された「Hello, Aspose!」が含まれています。

![The All Caps effect](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します：

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

出力：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**スライド上の表のテキストを変更するにはどうすればよいですか？**

スライド上の表のテキストを変更するには、[ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) を使用します。セルを列挙し、各セルを [ICell::get_TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icell/get_textframe/) で取得してテキストフレームを更新し、[IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/get_paragraphformat/) で段落書式を設定します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するにはどうすればよいですか？**

テキストにグラデーションカラーを適用するには、[IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/get_fillformat/) を使用します。[IFillFormat::set_FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifillformat/set_filltype/) に [FillType::Gradient](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を設定し、グラデーション ストップ、方向、透明度を構成します。