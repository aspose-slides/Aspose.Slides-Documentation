---
title: .NET におけるプレゼンテーションの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/net/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからテキスト抽出
- プレゼンテーションからテキスト抽出
- PowerPoint からテキスト抽出
- OpenDocument からテキスト抽出
- PPT からテキスト抽出
- PPTX からテキスト抽出
- ODP からテキスト抽出
- テキスト取得
- スライドからテキスト取得
- プレゼンテーションからテキスト取得
- PowerPoint からテキスト取得
- OpenDocument からテキスト取得
- PPT からテキスト取得
- PPTX からテキスト取得
- ODP からテキスト取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint と OpenDocument のプレゼンテーションからテキストを迅速に抽出します。シンプルなステップバイステップガイドに従って、時間を節約しましょう。"
---

## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的でありながら重要な作業です。Microsoft PowerPoint の PPT または PPTX 形式、あるいは OpenDocument プレゼンテーション（ODP）を扱う場合でも、テキストデータへのアクセスと取得は、分析、 automation、インデックス作成、コンテンツ移行などの目的で重要です。

この記事では、Aspose.Slides for .NET を使用して、PPT、PPTX、ODP のさまざまなプレゼンテーション形式からテキストを効率的に抽出する方法を包括的に解説します。プレゼンテーション要素を体系的に走査し、必要なテキストコンテンツを正確に取得する方法を学べます。

## **スライドからテキストを抽出する**

Aspose.Slides for .NET は、[Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/) 名前空間を提供し、その中に [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) クラスがあります。このクラスは、プレゼンテーションまたはスライドからすべてのテキストを抽出するための多数のオーバーロードされた static メソッドを公開しています。プレゼンテーション内のスライドからテキストを抽出するには、[GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextboxes/) メソッドを使用します。このメソッドは、[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) 型のオブジェクトをパラメーターとして受け取ります。実行されると、メソッドはスライド全体を走査してテキストを検出し、[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキストの書式情報を保持します。

以下のコードスニペットは、プレゼンテーションの最初のスライドからすべてのテキストを抽出します:
```cs
int slideIndex = 0;

// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("demo.pptx");

// Get a reference to the slide.
ISlide slide = presentation.Slides[slideIndex];

// Get an array of text frames from the slide.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

// Loop through the array of the text frames.
for (int i = 0; i < textFrames.Length; i++)
{
    // 現在のテキスト フレーム内の段落をループ処理します。
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // 現在の段落内のテキスト部分をループ処理します。
        foreach (IPortion portion in paragraph.Portions)
        {
            // 現在のテキスト部分の文字列を表示します。
            Console.WriteLine(portion.Text);

            // テキストのフォントサイズを表示します。
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // テキストのフォント名を表示します。
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **プレゼンテーション全体からテキストを抽出する**

プレゼンテーション全体のテキストを走査するには、[SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) クラスが提供する [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextframes/) static メソッドを使用します。このメソッドは 2 つのパラメーターを受け取ります。

1. 最初に、テキストを抽出する対象となる PowerPoint または OpenDocument プレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) オブジェクト。  
2. 2 番目は、プレゼンテーションのテキストを走査する際にマスタースライドを含めるかどうかを示す `Boolean` 値。

メソッドは、[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキストの書式情報も含みます。以下のコードは、プレゼンテーション（マスタースライドを含む）からテキストと書式の詳細を走査します:
```cs
// プレゼンテーション ファイル (PPT、PPTX、ODP など) を表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("demo.pptx");

// プレゼンテーション内のすべてのスライドからテキスト フレームの配列を取得します。
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

// テキスト フレームの配列をループ処理します。
for (int i = 0; i < textFrames.Length; i++)
{
    // 現在のテキスト フレーム内の段落をループ処理します。
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // 現在の段落内のテキスト部分をループ処理します。
        foreach (IPortion portion in paragraph.Portions)
        {
            // 現在のテキスト部分の文字列を表示します。
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


## **分類された高速テキスト抽出**

[PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) クラスも、プレゼンテーションからすべてのテキストを抽出する static メソッドを提供しています:
``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```


[TextExtractionArrangingMode](https://reference.aspose.com/slides/net/aspose.slides/textextractionarrangingmode/) enum 引数は、テキスト抽出結果の整理方法を表し、次の値に設定できます。
- `Unarranged` - スライド上の位置を考慮しない生テキスト。  
- `Arranged` - スライド上の順序と同じ順序でテキストが整理されます。

速度が重要な場合は `Unarranged` モードを使用できます。`Arranged` モードよりも高速です。

[IPresentationText](https://reference.aspose.com/slides/net/aspose.slides/ipresentationtext/) はプレゼンテーションから抽出された生テキストを表します。これは [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/) 名前空間の [SlidesText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) プロパティを含み、[ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) 型のオブジェクト配列を返します。各オブジェクトは対応するスライド上のテキストを表します。[ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) 型のオブジェクトは次のプロパティを持ちます。

- `Text` - スライドのシェイプ内のテキスト。  
- `MasterText` - 当該スライドに関連付けられたマスタースライドのシェイプ内のテキスト。  
- `LayoutText` - 当該スライドに関連付けられたレイアウトスライドのシェイプ内のテキスト。  
- `NotesText` - 当該スライドのノートスライドのシェイプ内のテキスト。  
- `CommentsText` - 当該スライドに付随するコメントのテキスト。  
```cs
IPresentationText text = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text.SlidesText[0].Text);
Console.WriteLine(text.SlidesText[0].LayoutText);
Console.WriteLine(text.SlidesText[0].MasterText);
Console.WriteLine(text.SlidesText[0].NotesText);
Console.WriteLine(text.SlidesText[0].CommentsText);
```


## **FAQ**

**Aspose.Slides は大規模なプレゼンテーションのテキスト抽出をどの程度高速に処理できますか？**

Aspose.Slides は高性能に最適化されており、非常に大きなプレゼンテーションでも効率的に処理できるため、リアルタイムやバルク処理シナリオに適しています。

**Aspose.Slides はプレゼンテーション内のテーブルやチャートからテキストを抽出できますか？**

はい、Aspose.Slides はテーブル、チャート、その他の複雑なスライド要素からのテキスト抽出を完全にサポートしており、すべてのテキストコンテンツに容易にアクセスして分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスが必要ですか？**

無料評価版でもテキスト抽出は可能ですが、スライド数に制限があるなどの制約があります。制限なく使用し、より大規模なプレゼンテーションを処理したい場合は、フルライセンスの購入が推奨されます。