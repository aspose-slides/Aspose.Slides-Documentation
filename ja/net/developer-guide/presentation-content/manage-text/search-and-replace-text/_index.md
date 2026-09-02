---
title: ".NET で PowerPoint プレゼンテーションのテキストを検索・置換"
linktitle: "テキストの検索と置換"
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

Aspose.Slides for .NET は、個々のテキスト フレームまたはプレゼンテーション全体でテキストの検索、ハイライト、置換を行うことができます。各操作は結果コールバックを通じてマッチごとにアプリケーションに通知することも可能です。これにより、プレゼンテーションを更新しながら、マッチしたテキスト、そのコンテキスト、位置、テキスト フレーム、スライド番号を含む監査トレイルを同時に構築できます。

これらの機能は、レビュー、編集（レダクション）、用語チェック、テンプレートのクリーンアップ、そして自動化されたレポート作成ワークフローに役立ちます。

以下の最初の例では、"sample.pptx" というファイルを使用します。このファイルは、最初のスライドに 1 つのテキスト ボックスがあり、次のテキストが含まれています。

![サンプルテキスト](sample_text.png)

## **検索範囲の選択**

[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) のメソッドを使用して操作を単一のテキスト フレームに限定できます。[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) のメソッドを使用すると、プレゼンテーション内の対象となるすべてのテキストを処理できます。

| 操作 | 単一テキストフレーム | プレゼンテーション全体 |
|---|---|---|
| リテラルテキストのハイライト | [ITextFrame.HighlightText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/highlighttext/) |
| 正規表現マッチのハイライト | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/highlightregex/) |
| リテラルテキストの置換 | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/replacetext/) |
| 正規表現マッチの置換 | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/replaceregex/) |

## **テキストマッチングの構成**

リテラルテキスト操作では、[TextSearchOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/) を使用してマッチングを制御します。

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/wholewordsonly/) は、完全な単語へのマッチに限定します。
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/casesensitive/) は、文字の大文字小文字が一致する必要があるかどうかを制御します。
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/includenotes/) は、プレゼンテーションレベルの検索、置換、ハイライト操作にスライドノートを含めます。

正規表現操作は .NET の `Regex` を使用するため、大小文字の区別や単語境界などのマッチング規則は式そのものとオプションで定義されます。

## **テキストフレームの所有者を特定する**

一般的なテキスト処理ワークフローでは、検索、置換、検証、またはエクスポート時に [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) を受け取ることがよくあります。[ITextFrame.ParentShape](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/parentshape/) と [ITextFrame.ParentCell](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/parentcell/) を使用して、テキストフレームの所有者がどのプレゼンテーション オブジェクトかを判断します。

所有者に応じて期待される値は以下の通りです：

| テキストフレームの所有者 | `ParentShape` | `ParentCell` |
|---|---|---|
| AutoShape または他のテキスト含むシェイプ | 所有する[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) | `null` |
| テーブルセル | `null` | 所有する[ICell](https://reference.aspose.com/slides/ja/net/aspose.slides/icell/) |

両プロパティは読み取り専用のナビゲーションプロパティです。取得してもテキストフレームは移動せず、所有者も変更されません。汎用コードでは両方の値が `null` かどうかを確認し、所有者が取得できない可能性に対応すべきです。

以下の例は [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/getalltextframes/) を使用してプレゼンテーション内のテキストフレームを列挙します。シェイプの場合はシェイプ名、シェイプタイプ、所属スライドを報告し、テーブルセルの場合は 0 ベースの列・行座標と所属スライドを報告します。

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

SmartArt のコンテンツについては、[ISmartArtNode.Shapes](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/ismartartnode/shapes/) でシェイプを列挙し、各 [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/ismartartshape/textframe/) にアクセスします。テキストフレームは [ITextFrame.ParentShape](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/parentshape/) で対応するシェイプに追跡でき、[ITextFrame.ParentCell](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/parentcell/) は `null` です。そのため、例のシェイプ分岐は SmartArt ノードからのテキストも処理します。

## **コールバックでマッチ情報を収集する**

[IFindResultCallback](https://reference.aspose.com/slides/ja/net/aspose.slides/ifindresultcallback/) を実装して、マッチごとに通知を受け取ります。 its [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/ja/net/aspose.slides/ifindresultcallback/foundresult/) メソッドは、関連するテキストフレーム、元テキスト、マッチしたテキスト、およびマッチ位置を提供します。

コールバックはスライド番号を直接受け取りません。以下の実装は親スライドから番号を導出し、スライドノート内のテキストにも対応します。スライド番号を nullable にすることで、他のスライド種別に紐づくテキストも同じ結果モデルで表現できます。

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

置換操作の場合、`FoundText` には元のマッチテキストが含まれるため、コールバックは置換された正確な語句を記録できます。

## **テキストのハイライト**

[ITextFrame.HighlightText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlighttext/) メソッドを使用して、テキストフレーム内のリテラルテキストマッチをハイライトします。[TextSearchOptions] を渡して検索条件を制御し、マッチ詳細を収集するコールバックを指定します。

以下のコード例は文字列 **"try"** のすべての出現をハイライトし、続いて完全な単語 **"to"** のみをハイライトします。両方の検索は同じコールバックにマッチを報告します。

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// 最初のスライドから最初のシェイプを取得します。
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// テキストフレーム内の "try" のすべての出現箇所をハイライトします。
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// 完全な単語 "to" のみをハイライトします。
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

結果：

![ハイライトされたテキスト](highlighted_text.png)

## **正規表現を使用したテキストのハイライト**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlightregex/) メソッドは、正規表現で検出されたテキストマッチをテキストフレーム内でハイライトします。

以下のコードは 7 文字以上の単語すべてをハイライトし、各マッチを収集します。

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

結果：

![正規表現を使用したハイライトテキスト](highlighted_text_using_regex.png)

## **プレゼンテーション全体のテキストハイライト**

[Presentation.HighlightText](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/highlighttext/) と [Presentation.HighlightRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/highlightregex/) を使用して、プレゼンテーション内のすべての対象テキストフレームを検索します。以下の例はリテラル語句とすべてのメールアドレスをハイライトし、2 つの検索結果を別々のコレクションに保持します。

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

リテラルテキストには [ITextFrame.ReplaceText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replacetext/) を、パターンベースの置換には [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replaceregex/) を使用します。これらのメソッドは既存のテキストフレーム内のマッチしたテキストを更新し、プレーン文字列からフレーム全体を再構築するのではなく、周囲の書式を保持します。

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

マッチが異なる書式の部分にまたがる場合は、出力を確認して置換テキストに適用すべき書式を判断してください。

## **プレゼンテーション全体のテキスト置換**

[Presentation.ReplaceText](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/replacetext/) と [Presentation.ReplaceRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/replaceregex/) を使用して、プレゼンテーション全体に同じ操作を適用します。テンプレートのクリーンアップ、用語の更新、レダクションに便利です。

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

## **レポート用のマッチのグループ化**

各結果はスライド番号とテキストフレームを保持しているため、アプリケーションは監査、レポート、レビューのワークフロー向けにマッチをグループ化できます。以下の例は収集した結果をまずスライドごとに、次にテキストフレームごとにグループ化します。

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

## **よくある質問**

**プレゼンテーション全体ではなく、特定のテキストボックスだけを検索するにはどうすればよいですか？**

対象シェイプのテキストフレームを取得し、そのテキストフレームに対して [ITextFrame.HighlightText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlighttext/)、[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlightregex/)、[ITextFrame.ReplaceText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replacetext/)、または [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replaceregex/) を呼び出します。プレゼンテーションレベルのメソッドはすべての対象テキストフレームを処理します。

**完全な単語を正しい大文字小文字で一致させるには？**

[TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/wholewordsonly/) と [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/casesensitive/) を `true` に設定し、リテラルテキストのハイライトまたは置換メソッドにオプションを渡します。正規表現の場合は、.NET の `Regex` 自体で単語境界と大文字小文字の設定を行います。

**検索および置換にスライドノートのテキストを含めることはできますか？**

はい。プレゼンテーションレベルのリテラルテキスト操作を行う際に、[TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/includenotes/) を `true` に設定します。上記のコールバック実装は、ノートスライド内のマッチを親スライド番号にマッピングします。

**プレゼンテーションを再度スキャンせずにレポートを作成するには？**

ハイライトまたは置換操作に [IFindResultCallback](https://reference.aspose.com/slides/ja/net/aspose.slides/ifindresultcallback/) 実装を渡します。コールバックは操作実行中にすべてのマッチを受け取るため、アプリケーションはソーステキスト、マッチテキスト、位置、テキストフレーム、導出したスライド番号を保存し、後でグループ化またはエクスポートできます。

**テキスト置換は書式を保持しますか？**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replacetext/) と [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/replaceregex/) は既存のテキストフレーム内のマッチしたテキストを変更し、周囲の書式を保持します。マッチが異なる書式の部分にまたがる場合は、置換後のテキストが期待したスタイルになっているか結果を確認してください。