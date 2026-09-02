---
title: PowerPoint プレゼンテーションにおけるテキストの検索と置換 (C++)
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
- テキスト フレーム
- 監査レポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーションのテキストを検索、ハイライト、置換し、すべての一致を収集します。"
---
## **概要**

Aspose.Slides for C++ は、個々のテキスト フレームまたはプレゼンテーション全体でテキストの検索、ハイライト、置換を行うことができます。各操作は、結果コールバックを通じてマッチごとにアプリケーションに通知することも可能です。これにより、プレゼンテーションを更新しながら、マッチしたテキスト、そのコンテキスト、位置、テキスト フレーム、スライド番号を含む監査トレイルを同時に構築できます。

これらの機能は、レビュー、編集、用語チェック、テンプレートのクリーンアップ、そして自動レポート作成ワークフローに役立ちます。

以下の最初の例では、1 枚目のスライドに単一のテキスト ボックスが含まれ、次のテキストが入っている「sample.pptx」ファイルを使用します。

![サンプルテキスト](sample_text.png)

## **検索対象の範囲を選択する**

[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) のメソッドを使用して操作を単一のテキスト フレームに限定し、[IPresentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/) のメソッドを使用してプレゼンテーション全体の対象テキストを処理します。

| 操作 | 単一テキスト フレーム | プレゼンテーション全体 |
|---|---|---|
| リテラル文字列のハイライト | [ITextFrame::HighlightText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/highlighttext/) |
| 正規表現マッチのハイライト | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/highlightregex/) |
| リテラル文字列の置換 | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/replacetext/) |
| 正規表現マッチの置換 | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/replaceregex/) |

## **テキスト一致条件の設定**

リテラル文字列操作の場合は、[ITextSearchOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/) を使用して一致条件を制御します。

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) は完全な単語に限定して一致させます。  
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) は大文字小文字を区別するかどうかを制御します。  
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/set_includenotes/) は、プレゼンテーションレベルの検索、置換、ハイライト操作にスライド ノートを含めます。

正規表現操作は `System::Text::RegularExpressions::Regex` を使用するため、大小文字の区別や単語境界などの一致規則は正規表現そのものとオプションで定義されます。

## **テキスト フレームの所有者を特定する**

汎用的なテキスト処理ワークフローでは、検索・置換・検証・エクスポート時に [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) を受け取ることがよくあります。テキスト フレームがどのプレゼンテーション オブジェクトに属しているかは、[ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentshape/) と [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentcell/) を使用して判定します。

所有者に応じた期待値は次の通りです。

| テキスト フレームの所有者 | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| AutoShape またはテキストを含む他のシェイプ | 所有する [IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) | `nullptr` |
| 表のセル | `nullptr` | 所有する [ICell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icell/) |

両メソッドは読み取り専用のナビゲーションを提供します。呼び出してもテキスト フレームは移動せず、所有者も変更されません。汎用コードでは両方の値が `nullptr` かどうかを確認し、所有者が存在しない可能性にも対応すべきです。

以下の例は [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/ja/cpp/aspose.slides.util/slideutil/getalltextframes/) を使用してプレゼンテーション内のテキスト フレームを列挙します。シェイプの場合はシェイプ名、C++ ランタイム型、所属スライドを報告し、表のセルの場合は 0 基底の列・行座標と所属スライドを報告します。

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using Aspose::Slides::Presentation;
using Aspose::Slides::Util::SlideUtil;
using System::AsCast;
using System::Console;
using System::MakeObject;
using System::String;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto textFrames = SlideUtil::GetAllTextFrames(presentation, false);

for (const auto& textFrame : textFrames)
{
    auto ownerShape = textFrame->get_ParentShape();
    if (ownerShape != nullptr)
    {
        auto shapeName = String::IsNullOrEmpty(ownerShape->get_Name()) ? u"(unnamed)" : ownerShape->get_Name();
        auto shapeType = ownerShape->GetType().get_Name();
        auto baseSlide = ownerShape->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Shape: {0}; type: {1}; {2}", shapeName, shapeType, slideLabel);
        continue;
    }

    auto ownerCell = textFrame->get_ParentCell();
    if (ownerCell != nullptr)
    {
        auto baseSlide = ownerCell->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Table cell: column {0}, row {1}; {2}", ownerCell->get_FirstColumnIndex(), ownerCell->get_FirstRowIndex(), slideLabel);
        continue;
    }

    Console::WriteLine(u"The text frame owner is not available as a shape or table cell.");
}
```

SmartArt のコンテンツについては、[ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) でシェイプを列挙し、各シェイプの [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) にアクセスします。テキスト フレームは [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentshape/) で関連シェイプにたどり着き、[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentcell/) は `nullptr` を返します。したがって、例のシェイプ分岐は SmartArt ノードからのテキストも扱います。

## **コールバックで一致情報を収集する**

[IFindResultCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifindresultcallback/) を実装して、すべての一致に対する通知を受け取ります。その [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifindresultcallback/foundresult/) メソッドは、対象テキスト フレーム、元テキスト、マッチしたテキスト、マッチ位置を提供します。

コールバックは直接スライド番号を受け取らないため、下記実装では [ISlideComponent::get_Slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecomponent/get_slide/) から取得し、ノート スライドのテキストに対しては [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/inotesslide/get_parentslide/) を利用しています。スライド番号が nullable であることで、他のスライド種別に属するテキストも同じ結果モデルで表現できます。

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
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
        auto parentShape = textFrame->get_ParentShape();
        auto parentCell = textFrame->get_ParentCell();
        SharedPtr<IBaseSlide> baseSlide;

        if (parentShape != nullptr)
        {
            baseSlide = parentShape->get_Slide();
        }
        else if (parentCell != nullptr)
        {
            baseSlide = parentCell->get_Slide();
        }
        else
        {
            baseSlide = textFrame->get_Slide();
        }

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

置換操作の場合、`FoundText` には元のマッチテキストが含まれるため、コールバックは正確にどの語句が置換されたかを記録できます。

## **テキストのハイライト**

[ITextFrame::HighlightText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlighttext/) メソッドを使用して、テキスト フレーム内のリテラル文字列マッチをハイライトします。検索条件は [ITextSearchOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/) で制御し、マッチの詳細はコールバックで収集します。

以下のコード例は文字列 **"try"** のすべての出現箇所をハイライトし、続いて完全一致単語 **"to"** のみをハイライトします。両検索とも同一コールバックに結果を報告します。

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

// 最初のスライドから最初のシェイプを取得します。
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// テキスト フレーム内の "try" のすべての出現箇所をハイライトします。
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// 完全な単語 "to" のみをハイライトします。
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

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlightregex/) メソッドは、正規表現で見つかったテキスト マッチをテキスト フレーム内でハイライトします。

以下のコードは 7 文字以上の単語すべてをハイライトし、各マッチを収集します。

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

![正規表現でハイライトされたテキスト](highlighted_text_using_regex.png)

## **プレゼンテーション全体でテキストをハイライトする**

[IPresentation::HighlightText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/highlighttext/) と [IPresentation::HighlightRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/highlightregex/) を使用して、プレゼンテーション内のすべての対象テキスト フレームを検索・ハイライトします。以下の例はリテラル語句とすべてのメール アドレスをハイライトし、2 つの検索結果を別々のコレクションに保持します。

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

## **テキスト フレーム内のテキストを置換する**

リテラル文字列の置換には [ITextFrame::ReplaceText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replacetext/)、パターンベースの置換には [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replaceregex/) を使用します。これらのメソッドは既存のテキスト フレーム内のマッチしたテキストだけを更新し、周囲の書式を保持したまま置換を行います（プレーン文字列でフレーム全体を作り直すわけではありません）。

以下の例は綴りの揺れを統一し、続いてバージョン ラベルを置換します。同一コールバックが両操作でマッチした元語句を記録します。

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

1 つのマッチが異なる書式の部分にまたがる場合は、置換後のテキストに適用すべき書式を確認してください。

## **プレゼンテーション全体でテキストを置換する**

[IPresentation::ReplaceText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/replacetext/) と [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/replaceregex/) を使用して、プレゼンテーション全体に同じ置換操作を適用します。テンプレートのクリーンアップ、用語の更新、編集削除に便利です。

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

## **レポート作成のためにマッチをグループ化する**

各結果はスライド番号とテキスト フレームを保持しているため、アプリケーションは監査、レポート、レビューのワークフロー向けにマッチをグループ化できます。以下の例は収集された結果をまずスライドごと、次にテキスト フレームごとにグループ化します。

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

**テキスト ボックス 1 つだけを検索し、プレゼンテーション全体は対象にしたくない場合はどうすればよいですか？**

対象シェイプのテキスト フレームを取得し、そのテキスト フレームに対して [ITextFrame::HighlightText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlighttext/)、[ITextFrame::HighlightRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/highlightregex/)、[ITextFrame::ReplaceText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replacetext/)、[ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replaceregex/) を呼び出します。プレゼンテーションレベルのメソッドはすべての対象テキスト フレームを処理します。

**完全な単語かつ正しい大文字小文字で一致させるには？**

[ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) と [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) に `true` を設定し、リテラル文字列のハイライトまたは置換メソッドにオプションを渡します。正規表現の場合は、`System::Text::RegularExpressions::Regex` 自体で単語境界と大文字小文字の設定を行います。

**検索と置換にスライド ノートのテキストも含められますか？**

はい。プレゼンテーションレベルのリテラル文字列操作を使用する際、[ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextsearchoptions/set_includenotes/) に `true` を設定してください。上記のコールバック実装は、ノート スライド内のマッチを親スライド番号にマッピングします。

**プレゼンテーションを再度走査せずにレポートを作成するには？**

ハイライトまたは置換操作に [IFindResultCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifindresultcallback/) 実装を渡します。コールバックは操作中にすべてのマッチを受け取り、元テキスト、マッチテキスト、位置、テキスト フレーム、導出されたスライド番号を保存できるため、後でグループ化やエクスポートに利用できます。

**テキストを置換しても書式は保持されますか？**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replacetext/) と [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/replaceregex/) は既存のテキスト フレーム内でマッチしたテキストだけを変更し、周囲の書式を保持します。マッチが異なる書式の部分にまたがる場合は、置換後のテキストが期待するスタイルになっているか確認してください。