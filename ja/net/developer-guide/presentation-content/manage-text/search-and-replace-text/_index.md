---
title: .NET で PowerPoint プレゼンテーションのテキストを検索および置換
linktitle: テキストの検索と置換
type: docs
weight: 55
url: /ja/net/search-and-replace-text/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーション内のテキストを検索、ハイライト、置換し、すべてのマッチを収集します。"
---
## **概要**

Aspose.Slides for .NET は、個々のテキストフレームまたはプレゼンテーション全体でテキストの検索、ハイライト、置換を行うことができます。各操作は結果コールバックを介してマッチごとにアプリケーションに通知することも可能です。これにより、プレゼンテーションを更新しながら、マッチしたテキスト、そのコンテキスト、位置、テキストフレーム、スライド番号を含む監査トレイルを同時に構築できます。

これらの機能は、レビュー、情報削除、用語チェック、テンプレートのクリーンアップ、そして自動レポート作成ワークフローに役立ちます。

以下の最初の例では、最初のスライドに単一のテキストボックスが含まれ、次のテキストが入っている「sample.pptx」というファイルを使用します。

![サンプルテキスト](sample_text.png)

## **検索対象の選択**

[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) のメソッドを使用して操作を 1 つのテキストフレームに限定します。[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) のメソッドを使用すると、プレゼンテーション内のすべての該当テキストを処理できます。

| 操作 | 1つのテキストフレーム | プレゼンテーション全体 |
|---|---|---|
| リテラルテキストをハイライト | [ITextFrame.HighlightText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/highlighttext/) |
| 正規表現一致をハイライト | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/highlightregex/) |
| リテラルテキストを置換 | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/replacetext/) |
| 正規表現一致を置換 | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/replaceregex/) |

## **テキストマッチングの設定**

リテラルテキスト操作の場合は、[TextSearchOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/) を使用してマッチングを制御します。

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/wholewordsonly/) はマッチを完全な単語に限定します。  
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/casesensitive/) は文字の大文字小文字が一致する必要があるかどうかを制御します。  
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/includenotes/) はプレゼンテーションレベルの検索、置換、ハイライト操作にスライドノートを含めます。

正規表現操作は .NET の `Regex` を使用するため、ケースセンシティビティや単語境界などのマッチ規則は正規表現そのものとそのオプションで定義されます。

## **コールバックでマッチ情報を収集**

[IFindResultCallback](https://reference.aspose.com/slides/ja/net/aspose.slides/ifindresultcallback/) を実装して、マッチごとに通知を受け取ります。その [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/ja/net/aspose.slides/ifindresultcallback/foundresult/) メソッドは、対象テキストフレーム、元テキスト、マッチしたテキスト、およびマッチ位置を提供します。

コールバックはスライド番号を直接受け取らないため、下記実装では親スライドから番号を取得し、スライドノート内のテキストも処理します。nullable なスライド番号を使用することで、他のスライド種別に関連付けられたテキストでも同じ結果モデルを表現できます。

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

置換操作の場合、`FoundText` には元のマッチテキストが含まれるため、コールバックは正確にどの語句が置換されたかを記録できます。

## **テキストのハイライト**

[ITextFrame.HighlightText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlighttext/) メソッドを使用して、テキストフレーム内のリテラルテキストマッチをハイライトします。検索条件は [TextSearchOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/) で制御し、マッチ詳細はコールバックで収集します。

以下のコード例は文字列 **"try"** のすべての出現箇所をハイライトし、続いて完全な単語 **"to"** のみをハイライトします。両方の検索結果は同じコールバックに報告されます。

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Get the first shape from the first slide.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Highlight every occurrence of "try" in the text frame.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Highlight only the complete word "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

結果:

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlightregex/) メソッドは、正規表現で見つかったテキストマッチをテキストフレーム内でハイライトします。

以下のコードは、7 文字以上の単語すべてをハイライトし、各マッチを収集します。

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

結果:

![正規表現を使用したハイライトテキスト](highlighted_text_using_regex.png)

## **プレゼンテーション全体のテキストをハイライト**

[Presentation.HighlightText](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/highlighttext/) と [Presentation.HighlightRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/highlightregex/) を使用して、プレゼンテーション内のすべての該当テキストフレームを検索します。以下の例では、リテラル語句とすべてのメールアドレスをハイライトし、2 つの検索結果を別々のコレクションに保持します。

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **テキストフレーム内のテキスト置換**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replacetext/) はリテラルテキスト置換に、[ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replaceregex/) はパターンベース置換に使用します。これらのメソッドは既存のテキストフレーム内のマッチテキストだけを更新し、周囲の書式を保持したまま置換します。

以下の例は綴りのバリエーションを統一し、続いてバージョンラベルを置換します。同じコールバックが両方の操作でマッチした元語句を記録します。

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

1 つのマッチが異なる書式の部分にまたがる場合、出力を確認して置換テキストに適用すべき書式を判断してください。

## **プレゼンテーション全体のテキスト置換**

[Presentation.ReplaceText](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/replacetext/) と [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/replaceregex/) を使用して、プレゼンテーション全体に同じ操作を適用できます。テンプレートのクリーンアップ、用語の更新、情報削除に便利です。

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **レポート用にマッチをグループ化**

各結果はスライド番号とテキストフレームを保持しているため、アプリケーションは監査、レポート、またはレビューのワークフロー向けにマッチをスライド単位、さらにテキストフレーム単位でグループ化できます。以下の例は、収集した結果を最初にスライドで、次にテキストフレームでグループ化しています。

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **FAQ**

**プレゼンテーション全体ではなく、1つのテキストボックスだけを検索するには？**

シェイプのテキストフレームを取得し、そのテキストフレームに対して [ITextFrame.HighlightText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlighttext/)、[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlightregex/)、[ITextFrame.ReplaceText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replacetext/)、または [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replaceregex/) を呼び出します。プレゼンテーションレベルのメソッドはすべての該当テキストフレームを処理します。

**完全な単語を正しい大文字小文字でマッチさせるには？**

[TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/wholewordsonly/) と [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/casesensitive/) を `true` に設定し、リテラルテキストのハイライトまたは置換メソッドにオプションを渡します。正規表現を使用する場合は、.NET の `Regex` 自体で単語境界とケースセンシティビティを定義してください。

**検索および置換にスライドノートのテキストを含めることはできますか？**

はい。プレゼンテーションレベルのリテラルテキスト操作を使用する際に、[TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/includenotes/) を `true` に設定します。上記のコールバック実装は、ノートスライド内のマッチを親スライド番号にマッピングします。

**プレゼンテーションを再度走査せずにレポートを作成するには？**

ハイライトまたは置換操作に [IFindResultCallback](https://reference.aspose.com/slides/ja/net/aspose.slides/ifindresultcallback/) 実装を渡します。コールバックは操作実行中にすべてのマッチを受け取るため、アプリケーションは元テキスト、マッチテキスト、位置、テキストフレーム、導出したスライド番号を保存して、後でグループ化やエクスポートに利用できます。

**テキスト置換は書式を保持しますか？**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replacetext/) と [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replaceregex/) は既存のテキストフレーム内でマッチしたテキストだけを変更し、周囲の書式を保持します。マッチが異なる書式の部分にまたがる場合は、結果を確認して置換テキストが希望のスタイルになるようにしてください。