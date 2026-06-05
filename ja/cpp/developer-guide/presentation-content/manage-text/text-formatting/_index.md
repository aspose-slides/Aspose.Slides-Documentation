---
title: C++ でプレゼンテーションテキストをフォーマット
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/cpp/text-formatting/
keywords:
- テキストのハイライト
- 正規表現
- 段落の配置
- テキストスタイル
- テキストの背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- オートフィットプロパティ
- テキストフレームのアンカー
- テキストタブ設定
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、カラー、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for C++ を使用して PowerPoint および OpenDocument プレゼンテーションのテキストを書式設定する方法を示します。ハイライト、背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブストップ、言語設定などをカバーします。

以下の例では、最初のスライドに単一のテキストボックスがあり、次のテキストが含まれる「sample.pptx」ファイルを使用します。

![サンプルテキスト](sample_text.png)

## **テキストのハイライト**

テキストフレーム内で特定のサンプルに一致するテキストをハイライトする必要がある場合は、[ITextFrame.HighlightText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlighttext/) メソッドを使用します。このメソッドは一致するテキスト断片にハイライトカラーを適用し、[ITextSearchOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/) と組み合わせて検索方法を制御できます。たとえば、完全一致する単語のみを対象にできます。

以下のコード例は、文字列 **"try"** のすべての出現箇所をハイライトし、次に単語全体 **"to"** のみをハイライトします。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// 最初のスライドから最初のシェイプを取得します。
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// シェイプ内の単語 "try" をハイライトします。
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// シェイプ内の単語 "to" をハイライトします。
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlightregex/) メソッドは、正規表現で見つかったテキストの一致箇所をハイライトします。C++ では、この API は [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) 上で公開されています。

以下のコード例は、**7 文字以上の単語**すべてをハイライトします。

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

![正規表現を使用したハイライトされたテキスト](highlighted_text_using_regex.png)

## **テキストの背景色の設定**

段落全体のデフォルトハイライト色を設定するには [IParagraphFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` を使用し、個々のテキスト部分のハイライト色には [IPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformat/)`.HighlightColor` を使用します。

以下のコード例は、**段落全体**の背景色を設定する方法を示します。

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

![灰色の段落](gray_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**の背景色を設定する方法を示します。

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
        // テキスト部分のハイライトカラーを設定します。
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![灰色のテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

[IParagraphFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/)`.Alignment` を使用して、テキストフレーム内の段落配置を設定できます。値は中央揃え、左揃え、右揃え、両端揃えなどが使用可能です。

以下のコード例は、段落を **中央** に揃える方法を示します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// 段落の配置を中央に設定します。
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![揃えられた段落](aligned_paragraph.png)

## **テキストの透明度の設定**

テキストの透明度は、[IPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformat/)`.FillFormat` に割り当てる色のアルファ成分で制御します。以下の例では、`alpha = 50` は 0〜255 のスケールでの ARGB アルファチャンネル値であり、透明度のパーセンテージではありません。

以下のコード例は、**段落全体**に透明度を適用する方法を示します。

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// テキストの塗りつぶし色を透明色に設定します。
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![透明な段落](transparent_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**に透明度を適用する方法を示します。

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
        // テキスト部分の透明度を設定します。
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![透明なテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔の設定**

[IBasePortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/)`.Spacing` を使用して、テキストボックス内の文字間隔を拡大または縮小できます。

以下の C++ コードは、**段落全体**の文字間隔を拡大する方法を示します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// 注: 文字間隔を縮めるには負の値を使用します。
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**の文字間隔を拡大する方法を示します。

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
        // 注: 文字間隔を縮めるには負の値を使用します。
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニング無効化**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint で表示されるテキストよりわずかに詰まって見えることがあります。これは、PowerPoint が特定フォントのカーニングデータを無視するためです（フォントに有効なカーニング情報があっても、PowerPoint の設定でカーニングが有効になっていても同様です）。

このようなケースで PowerPoint に近い出力にするには、影響を受けるフォントを使用するテキスト部分のカーニングを無効にします。[IPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` を実際のフォントサイズよりはるかに大きい値に設定します。

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

この設定により、該当テキスト部分へのカーニング適用が防止され、PowerPoint 固有の動作の影響を受けるフォントでのレンダリングが PowerPoint のビジュアル出力に近づきます。

## **テキストフォントプロパティの管理**

フォントプロパティは、[IParagraphFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` を介して段落レベルで設定するか、[IPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformat/) を介して個々の部分で設定できます。

以下のコードは、段落全体のフォントとテキストスタイルを設定します。フォントサイズ、太字、斜体、点線下線、そして Times New Roman フォントを段落内のすべての部分に適用します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// 段落のフォントプロパティを設定します。
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![段落のフォントプロパティ](font_properties_for_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分**に同様のプロパティを適用します。

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
        // テキスト部分のフォントプロパティを設定します。
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

![テキスト部分のフォントプロパティ](font_properties_for_text_portions.png)

## **テキスト回転の設定**

[ITextFrameFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` を使用して、シェイプ内のテキストの事前定義された向きを設定できます。

以下のコード例は、シェイプ内のテキスト向きを `Vertical270` に設定し、テキストを **90 度反時計回り** に回転させます。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![テキスト回転](text_rotation.png)

## **テキストフレームのカスタム回転の設定**

[ITextFrameFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/)`.RotationAngle` を使用して、[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) のカスタム回転角度を設定できます。

以下のコード例は、シェイプ内でテキストフレームを時計回りに 3 度回転させます。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間設定**

Aspose.Slides は [IParagraphFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`、`IParagraphFormat.SpaceBefore`、`IParagraphFormat.SpaceWithin` を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値を使用して行間を行の高さのパーセンテージで指定します。
* 負の値を使用して行間をポイントで指定します。

以下のコード例は、段落内の行間を指定する方法を示します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![段落内の行間](line_spacing.png)

## **テキストフレームのオートフィットタイプの設定**

[ITextFrameFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/)`.AutofitType` は、テキストがコンテナの境界を超えたときの動作を決定します。テキストが縮小されるか、はみ出すか、シェイプが自動的にサイズ変更されるかを制御できます。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **テキストフレームのアンカー設定**

[ITextFrameFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/)`.AnchoringType` は、テキストがシェイプ内で垂直方向に配置される位置（上部、中央、下部など）を定義します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **テキストのタブ設定**

[IParagraphFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` と `IParagraphFormat.Tabs` を使用して、段落内のタブストップを構成できます。

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

![段落のタブ](paragraph_tabs.png)

## **校正言語の設定**

Aspose.Slides は [IPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformat/)`.LanguageId` を提供し、テキスト部分の校正言語を設定できます。校正言語は、PowerPoint でのスペルチェックおよび文法チェックに使用される言語を決定します。

以下のコード例は、テキスト部分の校正言語を設定する方法を示します。

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

## **既定言語の設定**

[ILoadOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` を使用して、プレゼンテーションの読み込みまたは作成時に生成されるテキストの既定言語を定義します。

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// テキスト付きの新しい矩形シェイプを追加します。
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// 最初のテキスト部分の言語を確認します。
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **デフォルトテキストスタイルの設定**

プレゼンテーションレベルでデフォルトのテキスト書式を適用するには、[IPresentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle` を使用します。

以下のコード例は、新しいプレゼンテーションのすべてのスライドで、サイズ 14 pt の太字フォントをデフォルトテキストスタイルとして設定する方法を示します。

```cpp
auto presentation = System::MakeObject<Presentation>();

// 最上位の段落フォーマットを取得します。
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **全大文字効果でテキストを抽出する**

PowerPoint では、**All Caps** フォント効果を適用すると、スライド上のテキストが大文字で表示されます（元の入力が小文字でも）。Aspose.Slides でそのテキスト部分を取得すると、ライブラリは入力時の文字列をそのまま返します。表示されているテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textcaptype/) を確認し、値が `All` の場合は返された文字列を大文字に変換します。

以下に、sample2.pptx の最初のスライドにあるテキストボックスを例として示します。

![全大文字効果](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します。

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

出力：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**スライド上のテーブル内のテキストを変更するには？**

テーブル内のテキストを変更するには、[ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) を使用します。セルを反復処理し、各セルを [ICell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icell/)`.TextFrame` と [IParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/)`.ParagraphFormat` で更新します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するには？**

テキストにグラデーションカラーを適用するには、[IPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportionformat/)`.FillFormat` を使用します。[IFillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifillformat/)`.FillType` を [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/)`.Gradient` に設定し、グラデーション ストップ、方向、透明度を構成します。