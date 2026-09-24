---
title: C++ でプレゼンテーションテキストを整形
linktitle: テキストの書式設定
type: docs
weight: 50
url: /ja/cpp/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキスト背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリー
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- オートフィットプロパティ
- テキストフレームのアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストを整形およびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for C++ を使用して PowerPoint および OpenDocument プレゼンテーションのテキストを書式設定する方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブストップ、言語設定について解説します。

以下の例では、最初のスライドに単一のテキストボックスがあり、次のテキストが含まれる "sample.pptx" というファイルを使用します。

![サンプルテキスト](sample_text.png)

文字列や正規表現の一致を検索してハイライトする方法は、[Search and Replace Text](/slides/ja/cpp/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定する**

段落全体のハイライト色を設定するには [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) を使用し、個別のテキスト部分のハイライト色を設定するには [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) を使用します。

以下のコード例は **段落全体** の背景色を設定する方法を示しています。

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

結果:

![灰色の段落](gray_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** の背景色を設定する方法を示しています。

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

結果:

![灰色のテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

テキストフレーム内の段落配置を設定するには [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_alignment/) を使用します。値は中央揃え、左揃え、右揃え、両端揃えなどがあります。

以下のコード例は段落を **中央** に揃える方法を示しています。

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

結果:

![揃えられた段落](aligned_paragraph.png)

## **テキストの透明度を設定する**

テキストの透明度は [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/get_fillformat/) で設定した色のアルファ成分で制御します。以下の例では `alpha = 50` は 0〜255 のスケールの ARGB アルファチャネル値であり、透明度パーセンテージではありません。

以下のコード例は **段落全体** に透明度を適用する方法を示しています。

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

結果:

![透明な段落](transparent_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** に透明度を適用する方法を示しています。

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

結果:

![透明なテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔を設定する**

テキストボックス内の文字間隔を拡大または縮小するには [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_spacing/) を使用します。

以下の C++ コードは **段落全体** の文字間隔を拡大する方法を示しています。

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

// 注: 文字間隔を縮めるには負の値を使用します。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // 文字間隔を広げます。

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![段落の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** の文字間隔を拡大する方法を示しています。

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
        // 注: 文字間隔を縮めるには負の値を使用します。
        portionFormat->set_Spacing(3.0f); // 文字間隔を広げます。
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides が描画するテキストが PowerPoint の表示よりわずかに詰まって見えることがあります。これは PowerPoint が特定フォントのカーニング情報を無視するためです（フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効でも同様です）。

このような場合、影響を受けるフォントを使用するテキスト部分のカーニングを無効にできます。[IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) を使用して、実際のフォントサイズよりはるかに大きな値を設定します。

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

この設定により、該当するテキスト部分にカーニングが適用されず、PowerPoint 特有の挙動によるフォントの表示差異を軽減できます。

## **テキストフォントプロパティを管理する**

フォントプロパティは [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) で段落レベルに、または各部分に対しては [IPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformat/) で設定できます。

以下のコードは段落全体のフォントとテキストスタイルを設定します。フォントサイズ、太字、斜体、点線下線、そして Times New Roman フォントがすべての部分に適用されます。

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

結果:

![段落のフォントプロパティ](font_properties_for_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** に同様のプロパティを適用します。

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

結果:

![テキスト部分のフォントプロパティ](font_properties_for_text_portions.png)

## **テキストの回転を設定する**

テキストの向きを事前定義されたものに設定するには [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_textverticaltype/) を使用します。

以下のコード例はテキストの向きを [TextVerticalType::Vertical270](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textverticaltype/) に設定し、テキストを **90 度左回転** させます。

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

結果:

![テキストの回転](text_rotation.png)

## **テキストフレームのカスタム回転を設定する**

[ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_rotationangle/) を使用して、[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) のカスタム回転角度を設定できます。

以下のコード例はシェイプ内のテキストフレームを時計回りに 3 度回転させます。

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

結果:

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間を設定する**

Aspose.Slides は [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_spaceafter/)、[IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_spacebefore/)、および [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_spacewithin/) を提供し、段落間隔を制御します。使用方法は次のとおりです。

* 正の値は行高のパーセンテージとして行間を指定します。  
* 負の値はポイント単位で行間を指定します。

以下のコード例は段落内の行間を指定する方法を示しています。

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

結果:

![段落内の行間](line_spacing.png)

## **テキストフレームのオートフィットタイプを設定する**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_autofittype/) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小、はみ出し、またはシェイプを自動的にリサイズするかを制御できます。

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

自動折り返し後の行数やテキスト・シェイプ幅の変化を確認したい場合は、[Count Rendered Lines](/slides/ja/cpp/manage-paragraph/) を参照してください。行数だけではテキストがコンテナを超えているかどうかは判断できません。

## **テキストフレームのアンカーを設定する**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_anchoringtype/) は、シェイプ内でテキストを垂直方向にどこに配置するか（上部、中央、下部など）を定義します。

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

段落のタブストップを構成するには、[IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) と [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/get_tabs/) を使用します。

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

結果:

![段落のタブ](paragraph_tabs.png)

## **校正言語を設定する**

[IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_languageid/) を使用すると、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックや文法チェックに使用される言語を決定します。

以下のコード例はテキスト部分の校正言語を設定する方法を示しています。

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

// 校正言語の Id を設定します。
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **デフォルト言語を設定する**

[ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) を使用して、プレゼンテーションのロードまたは作成時に新規テキストに適用されるデフォルト言語を定義します。

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

// Add a new rectangle shape with text.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Check the first portion language.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **デフォルトテキストスタイルを設定する**

プレゼンテーションレベルでデフォルトのテキスト書式を適用するには、[IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_defaulttextstyle/) を使用します。

以下のコード例は、新しいプレゼンテーションのすべてのスライドで、14 pt の太字フォントをデフォルトとして設定する方法を示しています。

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

// 上位レベルの段落書式を取得します。
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

## **全大文字効果でテキストを抽出する**

PowerPoint では **All Caps** フォント効果を適用すると、スライド上では大文字で表示されますが、実際に入力された文字列は元の小文字のままです。Aspose.Slides でそのテキスト部分を取得すると、入力された通りの文字列が返ります。表示されているテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textcaptype/) を確認し、値が [TextCapType::All](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textcaptype/) の場合は返された文字列を大文字に変換します。

例として、sample2.pptx の最初のスライドに次のテキストボックスがあるとします。

![全大文字効果](all_caps_effect.png)

以下のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示しています。

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

出力:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**スライド上のテーブル内のテキストを変更するには？**

テーブル内のテキストを変更するには、[ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) を使用します。セルを反復処理し、各セルを [ICell::get_TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icell/get_textframe/) で取得し、段落書式は [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/get_paragraphformat/) で更新します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するには？**

テキストにグラデーションカラーを適用するには、[IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/get_fillformat/) を使用します。[IFillFormat::set_FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifillformat/set_filltype/) を [FillType::Gradient](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) に設定し、グラデーションストップ、方向、透明度を構成します。