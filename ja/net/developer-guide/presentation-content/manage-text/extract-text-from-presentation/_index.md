---
title: .NET におけるプレゼンテーションの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/net/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからのテキスト抽出
- プレゼンテーションからのテキスト抽出
- PowerPoint からのテキスト抽出
- OpenDocument からのテキスト抽出
- PPT からのテキスト抽出
- PPTX からのテキスト抽出
- ODP からのテキスト抽出
- テキスト取得
- スライドからのテキスト取得
- プレゼンテーションからのテキスト取得
- PowerPoint からのテキスト取得
- OpenDocument からのテキスト取得
- PPT からのテキスト取得
- PPTX からのテキスト取得
- ODP からのテキスト取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides を使用して、PowerPoint および OpenDocument のプレゼンテーションからテキストを素早く抽出します。シンプルで段階的なガイドに従い、時間を節約しましょう。"
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的かつ重要な作業です。Microsoft PowerPoint の PPT や PPTX 形式、あるいは OpenDocument プレゼンテーション（ODP）を扱う場合でも、テキスト データへのアクセスと取得は、分析、Automation、インデックス作成、コンテンツ移行などの目的で極めて重要です。

本記事では、Aspose.Slides for .NET を使用して PPT、PPTX、ODP などさまざまなプレゼンテーション形式からテキストを効率的に抽出する方法を包括的に解説します。プレゼンテーション要素を体系的に反復処理し、必要なテキスト コンテンツを正確に取得する方法を学べます。

## **スライドからテキストを抽出する**

Aspose.Slides for .NET は [Aspose.Slides.Util](https://reference.aspose.com/slides/ja/net/aspose.slides.util/) 名前空間を提供し、その中に [SlideUtil](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/) クラスがあります。このクラスはプレゼンテーションまたはスライドからすべてのテキストを抽出するための、複数のオーバーロードされた static メソッドを公開しています。プレゼンテーション内のスライドからテキストを抽出するには、[GetAllTextBoxes](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/getalltextboxes/) メソッドを使用します。このメソッドは [IBaseSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/) 型のオブジェクトをパラメーターとして受け取ります。実行時にメソッドはスライド全体を走査し、テキストを検出して [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) 型のオブジェクト配列として返し、テキストの書式情報を保持します。

以下のコード スニペットは、プレゼンテーションの最初のスライドからすべてのテキストを抽出します。

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **プレゼンテーション全体からテキストを抽出する**

プレゼンテーション全体のテキストを走査するには、[SlideUtil](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/) クラスが提供する [GetAllTextFrames](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/getalltextframes/) static メソッドを使用します。このメソッドは 2 つのパラメーターを受け取ります。

1. 最初に、テキストを抽出する対象の PowerPoint または OpenDocument プレゼンテーションを表す [IPresentation](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/) オブジェクト。
2. 2 番目に、マスタースライドを走査対象に含めるかどうかを示す `Boolean` 値。

メソッドは [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) 型オブジェクトの配列を返し、テキストの書式情報も含まれます。以下のコードは、プレゼンテーション（マスタースライドを含む）からテキストと書式の詳細を走査します。

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **分類された高速テキスト抽出**

[PresentationFactory](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationfactory/) クラスも、プレゼンテーションからすべてのテキストを抽出するメソッドを提供しています。

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

`TextExtractionArrangingMode` (https://reference.aspose.com/slides/ja/net/aspose.slides/textextractionarrangingmode/) 列挙体の引数は、テキスト抽出結果の整理方法を示し、次の値に設定できます。
- `Unarranged` - スライド上の位置に関係なく、テキストをそのままの形で取得します。
- `Arranged` - スライド上の順序と同じ順序でテキストが整理されます。

速度が重要な場合は、`Unarranged` モードを使用できます。こちらの方が `Arranged` モードより高速です。

[IPresentationText](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationtext/) は、プレゼンテーションから抽出された生のテキストを表します。その `SlidesText` プロパティは [ISlideText](https://reference.aspose.com/slides/ja/net/aspose.slides/islidetext/) 型オブジェクトの配列を返します。各オブジェクトは対応するスライド上のテキストを表します。`ISlideText` 型オブジェクトは次のプロパティを持ちます。

- `Text` - スライド上のシェイプに含まれるテキスト。
- `MasterText` - 当該スライドに関連付けられたマスタースライドのシェイプに含まれるテキスト。
- `LayoutText` - 当該スライドに関連付けられたレイアウトスライドのシェイプに含まれるテキスト。
- `NotesText` - 当該スライドのノートスライドに含まれるテキスト。
- `CommentsText` - 当該スライドに付随するコメントに含まれるテキスト。

{{7428ca5a