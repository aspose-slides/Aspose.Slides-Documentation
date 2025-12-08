---
title: C# におけるプレゼンテーションからの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/net/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからテキスト抽出
- プレゼンテーションからテキスト抽出
- PowerPointからテキスト抽出
- PPTからテキスト抽出
- PPTXからテキスト抽出
- ODPからテキスト抽出
- C#
- .NET
- Aspose.Slides
description: ".NET 用 Aspose.Slides を使用して、PowerPoint プレゼンテーションからテキストを迅速かつ簡単に抽出する方法を学びます。シンプルなステップバイステップのガイドに従うことで、時間を節約し、アプリケーションでスライドコンテンツに効率的にアクセスできます。"
---

## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的でありながら重要な作業です。Microsoft PowerPoint の PPT または PPTX 形式、あるいは OpenDocument プレゼンテーション（ODP）を対象とする場合でも、テキストデータへのアクセスと取得は、分析、Automation、インデックス作成、またはコンテンツ移行の目的で重要になることがあります。

本記事では、Aspose.Slides for .NET を使用して PPT、PPTX、ODP などのさまざまなプレゼンテーション形式からテキストを効率的に抽出する方法を包括的に解説します。プレゼンテーション要素を体系的に反復処理し、必要なテキストコンテンツを正確に取得する方法を学びます。

## **スライドからテキストを抽出する**

Aspose.Slides for .NET は、[Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/) 名前空間を提供し、その中に [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) クラスがあります。このクラスは、プレゼンテーションまたはスライド全体からテキストを抽出するための、複数のオーバーロードされた静的メソッドを公開しています。プレゼンテーション内のスライドからテキストを抽出するには、[GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextboxes/) メソッドを使用します。このメソッドは、[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) 型のオブジェクトをパラメータとして受け取ります。実行すると、メソッドはスライド全体を走査してテキストを検索し、[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキストの書式情報を保持します。

以下のコードスニペットは、プレゼンテーションの最初のスライドからすべてのテキストを抽出します。
```cs
int slideIndex = 0;

// プレゼンテーションファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("demo.pptx");

// スライドへの参照を取得します。
ISlide slide = presentation.Slides[slideIndex];

// スライドからテキストフレームの配列を取得します。
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

// テキストフレームの配列をループ処理します。
for (int i = 0; i < textFrames.Length; i++)
{
    // 現在のテキストフレーム内の段落をループ処理します。
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // 現在の段落内のテキスト部分をループ処理します。
        foreach (IPortion portion in paragraph.Portions)
        {
            // 現在のテキスト部分のテキストを表示します。
            Console.WriteLine(portion.Text);

            // テキストのフォント高さを表示します。
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // テキストのフォント名を表示します。
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **プレゼンテーションからテキストを抽出する**

プレゼンテーション全体のテキストを走査するには、[SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) クラスが提供する [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextframes/) 静的メソッドを使用します。このメソッドは 2 つのパラメータを受け取ります。

1. 最初に、テキストを抽出する対象となる PowerPoint または OpenDocument プレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) オブジェクト。
2. 次に、プレゼンテーションのテキストを走査する際にマスタースライドを含めるかどうかを示す `Boolean` 値。

このメソッドは、書式情報を含む [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 型オブジェクトの配列を返します。以下のコードは、プレゼンテーション全体（マスタースライドを含む）のテキストと書式情報を走査します。
```cs
// プレゼンテーションファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("demo.pptx");

// プレゼンテーション内のすべてのスライドからテキストフレームの配列を取得します。
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

// テキストフレームの配列をループ処理します。
for (int i = 0; i < textFrames.Length; i++)
{
    // 現在のテキストフレーム内の段落をループ処理します。
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // 現在の段落内のテキスト部分をループ処理します。
        foreach (IPortion portion in paragraph.Portions)
        {
            // 現在のテキスト部分のテキストを表示します。
            Console.WriteLine(portion.Text);

            // テキストのフォント高さを表示します。
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // テキストのフォント名を表示します。
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **カテゴリ別かつ高速なテキスト抽出**

[PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) クラスも、プレゼンテーションからすべてのテキストを抽出する静的メソッドを提供します。
``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```


`[TextExtractionArrangingMode](https://reference.aspose.com/slides/net/aspose.slides/textextractionarrangingmode/)` 列挙体の引数は、テキスト抽出結果の整理方法を示し、以下の値に設定できます。
- `Unarranged` - スライド上の位置を考慮しない生テキスト。
- `Arranged` - スライド上の順序と同じ順序でテキストが配置されます。

速度が重要な場合は `Unarranged` モードを使用できます。`Arranged` モードよりも高速です。

`[IPresentationText](https://reference.aspose.com/slides/net/aspose.slides/ipresentationtext/)` は、プレゼンテーションから抽出された生テキストを表します。`[Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/)` 名前空間の `SlidesText` プロパティを介して取得でき、`[ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/)` 型オブジェクトの配列を返します。各オブジェクトは対応するスライド上のテキストを表します。`[ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/)` 型のオブジェクトは以下のプロパティを持ちます。

- `Text` - スライドのシェイプ内のテキスト。
- `MasterText` - 該当スライドに関連付けられたマスタースライドのシェイプ内のテキスト。
- `LayoutText` - 該当スライドに関連付けられたレイアウトスライドのシェイプ内のテキスト。
- `NotesText` - 該当スライドのノートスライドのシェイプ内のテキスト。
- `CommentsText` - 該当スライドに付随するコメント内のテキスト。
```cs
IPresentationText text = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text.SlidesText[0].Text);
Console.WriteLine(text.SlidesText[0].LayoutText);
Console.WriteLine(text.SlidesText[0].MasterText);
Console.WriteLine(text.SlidesText[0].NotesText);
Console.WriteLine(text.SlidesText[0].CommentsText);
```


## **FAQ**

**Aspose.Slides はテキスト抽出時に大規模なプレゼンテーションをどれくらい高速に処理できますか？**

Aspose.Slides は高性能に最適化されており、大規模なプレゼンテーションでも効率的に処理できるため、リアルタイムやバルク処理のシナリオに適しています。

**Aspose.Slides はプレゼンテーション内の表やチャートからテキストを抽出できますか？**

はい、Aspose.Slides は表、チャート、その他の複雑なスライド要素からテキストを抽出する機能を完全にサポートしており、すべてのテキストコンテンツに簡単にアクセスして分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスは必要ですか？**

無料試用版でもテキスト抽出は可能ですが、処理できるスライド数に制限があります。制限なく大規模なプレゼンテーションを扱うには、フルライセンスの購入を推奨します。