---
title: C++でPowerPointプレゼンテーションのテキストを検索および置換
linktitle: テキストの検索と置換
type: docs
weight: 55
url: /ja/cpp/search-and-replace-text/
keywords:
- テキスト検索
- テキストハイライト
- テキスト置換
- 正規表現
- 結果コールバック
- テキストフレーム
- 監査レポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーション内のテキストを検索、ハイライト、置換し、すべての一致を収集します。"
---
## **概要**

Aspose.Slides for C++ は、個々のテキストフレームまたはプレゼンテーション全体でテキストの検索、ハイライト、置換を行うことができます。各操作は結果コールバックを通じて一致ごとにアプリケーションに通知できるため、プレゼンテーションを更新しながら、一致したテキスト、そのコンテキスト、位置、テキストフレーム、スライド番号を含む監査トレイルを同時に作成できます。

これらの機能は、レビュー、編集、用語チェック、テンプレートのクリーンアップ、そして自動レポート作成ワークフローに役立ちます。

以下の最初の例では、最初のスライドに単一のテキストボックスがあり、次のテキストが含まれる「sample.pptx」ファイルを使用します。

![Sample text](sample_text.png)

## **検索対象の選択**

テキストフレーム単位の操作を制限するには[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) のメソッドを使用します。プレゼンテーション全体のテキストを処理するには[IPresentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/) のメソッドを使用します。

| 操作 | 単一テキストフレーム | プレゼンテーション全体 |
|---|---|---|
| リテラルテキストをハイライト | [ITextFrame::HighlightText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/highlighttext/) |
| 正規表現マッチをハイライト | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/highlightregex/) |
| リテラルテキストを置換 | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/replacetext/) |
| 正規表現マッチを置換 | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/replaceregex/) |

## **テキストマッチングの設定**

リテラルテキスト操作の場合、[ITextSearchOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/) を使用してマッチングを制御します。

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) は完全一致する単語に限定します。
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) は文字ケースの一致が必要かどうかを制御します。
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/set_includenotes/) はスライドノートをプレゼンテーションレベルの検索、置換、ハイライト操作に含めます。

正規表現操作は `System::Text::RegularExpressions::Regex` を使用するため、ケースセンシティブや単語境界などのマッチルールは正規表現自体とそのオプションで定義されます。

## **コールバックで一致情報を取得**

[IFindResultCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifindresultcallback/) を実装して、すべての一致に対する通知を受け取ります。その[IFindResultCallback::FoundResult](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifindresultcallback/foundresult/) メソッドは、対象のテキストフレーム、元テキスト、一致したテキスト、そして一致位置を提供します。

コールバックはスライド番号を直接受け取りません。以下の実装は[ISlideComponent::get_Slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecomponent/get_slide/) から取得し、[INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/inotesslide/get_parentslide/) を通じてノートスライド内のテキストも処理します。スライド番号を nullable にしておくことで、他のスライド種別に紐付くテキストにも同一の結果モデルを使用できます。

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using System::AsCast;
using System::MakeObject;
using System::Nullable;
using System::SharedPtr;
using System::String;
using System::Collections::Generic::List;

class TextMatch : public System::Object
{
public:
    TextMatch(SharedPtr<ITextFrame> textFrame, String sourceText, String foundText,
        int32_t textPosition, Nullable<int32_t> slideNumber)
        : TextFrame(textFrame), SourceText(sourceText), FoundText(foundText),
          TextPosition(textPosition), SlideNumber(slideNumber)
    {
    }

    SharedPtr<ITextFrame> TextFrame;
    String SourceText;
    String FoundText;
    int32_t TextPosition;
    Nullable<int32_t> SlideNumber;
};

class TextSearchCallback : public IFindResultCallback
{
public:
    TextSearchCallback()
        : Results(MakeObject<List<SharedPtr<TextMatch>>>())
    {
    }

    void FoundResult(SharedPtr<ITextFrame> textFrame, String sourceText,
        String foundText, int32_t textPosition) override
    {
        auto slideNumber = GetSlideNumber(textFrame);
        auto result = MakeObject<TextMatch>(textFrame, sourceText, foundText,
            textPosition, slideNumber);

        Results->Add(result);
    }

    SharedPtr<List<SharedPtr<TextMatch>>> Results;

private:
    static Nullable<int32_t> GetSlideNumber(SharedPtr<ITextFrame> textFrame)
    {
        SharedPtr<IBaseSlide> baseSlide = textFrame->get_Slide();
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            return slide->get_SlideNumber();
        }

        auto notesSlide = AsCast<INotesSlide>(baseSlide);
        if (notesSlide != nullptr)
        {
            auto parentSlide = notesSlide->get_ParentSlide();
            return parentSlide->get_SlideNumber();
        }

        return nullptr;
    }
};
```

置換操作の場合、`FoundText` には元の一致テキストが含まれるため、コールバックはどの用語が置換されたかを正確に記録できます。

## **テキストをハイライト**

[ITextFrame::HighlightText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlighttext/) メソッドを使用して、テキストフレーム内のリテラルテキスト一致をハイライトします。検索制御には[ITextSearchOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/) を、結果収集にはコールバックを渡します。

以下のコード例は文字列 **"try"** のすべての出現をハイライトし、その後完全一致する単語 **"to"** のみをハイライトします。どちらの検索も同じコールバックに一致情報を報告します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Get the first shape from the first slide.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Highlight every occurrence of "try" in the text frame.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Highlight only the complete word "to".
shape->get_TextFrame()->HighlightText(
    u"to", System::Drawing::Color::get_Violet(), wholeWordSearchOptions, callback);

for (auto&& result : callback->Results)
{
    auto slideLabel = result->SlideNumber.get_HasValue()
        ? System::String::Format(u"{0}", result->SlideNumber.get_Value())
        : u"Other";

    System::Console::WriteLine(u"Found '{0}' at position {1} on slide {2}.",
        result->FoundText, result->TextPosition, slideLabel);
}

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![The highlighted text](highlighted_text.png)

## **正規表現でテキストをハイライト**

[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlightregex/) メソッドは、正規表現で見つかったテキストマッチをテキストフレーム内でハイライトします。

次のコードは、7文字以上の単語すべてをハイライトし、各一致を収集します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto regex = MakeObject<Regex>(u"\\b[^\\s]{7,}\\b");

shape->get_TextFrame()->HighlightRegex(
    regex, System::Drawing::Color::get_Yellow(), callback);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **プレゼンテーション全体でテキストをハイライト**

[IPresentation::HighlightText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/highlighttext/) と[IPresentation::HighlightRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/highlightregex/) を使用して、プレゼンテーション内のすべての対象テキストフレームを検索します。以下の例では、リテラル語句とすべてのメールアドレスをハイライトし、2つの検索結果を別々のコレクションに保持します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto termCallback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

presentation->HighlightText(
    u"confidential", System::Drawing::Color::get_Orange(), searchOptions, termCallback);

auto emailCallback = MakeObject<TextSearchCallback>();
auto emailRegex = MakeObject<Regex>(
    u"\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", RegexOptions::IgnoreCase);

presentation->HighlightRegex(
    emailRegex, System::Drawing::Color::get_Yellow(), emailCallback);

presentation->Save(u"highlighted_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **テキストフレーム内のテキストを置換**

リテラルテキストの置換には[ITextFrame::ReplaceText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replacetext/) を、パターンベースの置換には[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replaceregex/) を使用します。これらのメソッドは既存のテキストフレーム内の一致テキストだけを更新し、周囲の書式は保持したまま置換を行います。

以下の例はスペリングのバリエーションを統一し、続いてバージョンラベルを置換します。同じコールバックが 2 つの操作で一致した元の用語を記録します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

shape->get_TextFrame()->ReplaceText(u"colour", u"color", searchOptions, callback);

auto versionRegex = MakeObject<Regex>(
    u"\\bv\\d+(?:\\.\\d+)*\\b", RegexOptions::IgnoreCase);
shape->get_TextFrame()->ReplaceRegex(versionRegex, u"current version", callback);

presentation->Save(u"updated_text_frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

一致が異なる書式の領域にまたがる場合は、置換後の書式が期待通りか出力を確認してください。

## **プレゼンテーション全体でテキストを置換**

[IPresentation::ReplaceText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/replacetext/) と[IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/replaceregex/) を使用して、プレゼンテーション全体に同じ操作を適用します。これはテンプレートのクリーンアップ、用語の更新、編集削除に便利です。

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);

presentation->ReplaceText(u"Contoso", u"Example Corp", searchOptions, callback);

auto accountNumberRegex = MakeObject<Regex>(u"\\bACCT-\\d{6}\\b");
presentation->ReplaceRegex(accountNumberRegex, u"ACCT-REDACTED", callback);

presentation->Save(u"updated_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **レポート作成のために一致をグループ化**

各結果がスライド番号とテキストフレームを保持しているため、アプリケーションは監査、レポート、またはレビューのワークフロー向けに一致をグループ化できます。以下の例は、まずスライドごと、次にテキストフレームごとに収集結果をグループ化します。

```cpp
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/string.h>
#include <map>
#include <vector>

std::map<int32_t, std::map<Aspose::Slides::ITextFrame*,
    std::vector<System::SharedPtr<TextMatch>>>> matchesBySlide;

for (auto&& result : callback->Results)
{
    int32_t slideKey = result->SlideNumber.get_HasValue()
        ? result->SlideNumber.get_Value()
        : 0;
    auto textFrameKey = result->TextFrame.get();

    matchesBySlide[slideKey][textFrameKey].push_back(result);
}

for (const auto& slideGroup : matchesBySlide)
{
    auto slideLabel = slideGroup.first == 0
        ? System::String(u"Other")
        : System::String::Format(u"{0}", slideGroup.first);
    System::Console::WriteLine(u"Slide: {0}", slideLabel);

    for (const auto& textFrameGroup : slideGroup.second)
    {
        auto textFrameText = textFrameGroup.first->get_Text();
        System::Console::WriteLine(u"  Text frame: {0}", textFrameText);

        for (const auto& result : textFrameGroup.second)
        {
            System::Console::WriteLine(
                u"    '{0}' at position {1}; context: '{2}'",
                result->FoundText, result->TextPosition, result->SourceText);
        }
    }
}
```

## **FAQ**

**特定のテキストボックスだけを検索したい場合はどうすればよいですか？**

シェイプのテキストフレームを取得し、そのテキストフレームに対して[ITextFrame::HighlightText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlighttext/)、[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlightregex/)、[ITextFrame::ReplaceText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replacetext/)、または[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replaceregex/) を呼び出します。プレゼンテーションレベルのメソッドはすべての対象テキストフレームを処理します。

**完全な単語で大文字小文字を区別してマッチさせるには？**

[ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) と[ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) に `true` を設定し、リテラルテキストのハイライトまたは置換メソッドにオプションを渡します。正規表現の場合は、`System::Text::RegularExpressions::Regex` 自体で単語境界とケースセンシティブを定義します。

**スライドノート内のテキストも検索・置換の対象にできますか？**

はい。プレゼンテーションレベルのリテラルテキスト操作を使用する際に、[ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/set_includenotes/) を `true` に設定してください。上記のコールバック実装は、ノートスライド内の一致を親スライド番号にマッピングします。

**プレゼンテーションを再度スキャンせずにレポートを作成するには？**

ハイライトまたは置換操作に[IFindResultCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifindresultcallback/) 実装を渡します。コールバックは操作中にすべての一致を受け取るため、アプリケーションは元テキスト、一致テキスト、位置、テキストフレーム、派生したスライド番号を保存し、後でグループ化またはエクスポートできます。

**テキストを置換しても書式は保持されますか？**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replacetext/) と[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replaceregex/) は既存のテキストフレーム内の一致テキストを変更し、周囲の書式を保持します。もし一致が異なる書式の領域にまたがる場合は、置換後のテキストが期待通りのスタイルになっているか確認してください。