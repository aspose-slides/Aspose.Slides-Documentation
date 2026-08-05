---
title: ".NET におけるプレゼンテーションの高度なテキスト抽出"
linktitle: "テキスト抽出"
type: docs
weight: 90
url: /ja/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/ja/
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
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションからテキストを迅速に抽出できます。シンプルなステップバイステップガイドに従い、時間を節約しましょう。"
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的かつ重要な作業です。Microsoft PowerPoint の PPT または PPTX 形式、あるいは OpenDocument プレゼンテーション (ODP) を扱う場合でも、テキストデータへのアクセスと取得は、分析、Automation、インデックス付け、コンテンツ移行などの目的で重要です。

本記事では、Aspose.Slides for .NET を使用して PPT、PPTX、ODP などさまざまなプレゼンテーション形式からテキストを効率的に抽出するための包括的なガイドを提供します。プレゼンテーション要素を体系的に走査し、必要なテキストコンテンツを正確に取得する方法を学びます。

## **スライドからテキストを抽出する**

Aspose.Slides for .NET は、[Aspose.Slides.Util](https://reference.aspose.com/slides/ja/net/aspose.slides.util/) 名前空間を提供し、その中に [SlideUtil](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/) クラスがあります。このクラスは、プレゼンテーションまたはスライドからすべてのテキストを抽出するためのオーバーロードされた静的メソッドを複数提供しています。プレゼンテーション内のスライドからテキストを抽出するには、[GetAllTextBoxes](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/getalltextboxes/) メソッドを使用します。このメソッドは [IBaseSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseslide/) 型のオブジェクトをパラメータとして受け取ります。実行すると、メソッドはスライド全体を走査してテキストを検出し、[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキストの書式情報を保持します。

以下のコードスニペットは、プレゼンテーションの最初のスライドからすべてのテキストを抽出します。

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

プレゼンテーション全体のテキストを走査するには、[SlideUtil](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/) クラスが提供する [GetAllTextFrames](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/getalltextframes/) 静的メソッドを使用します。 このメソッドは 2 つのパラメータを受け取ります。

1. PowerPoint または OpenDocument のプレゼンテーションを表す [IPresentation](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/) オブジェクト。  
2. プレゼンテーションのテキスト走査時にマスタースライドを含めるかどうかを示す `Boolean` 値。

メソッドは [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) 型のオブジェクト配列を返し、テキストの書式情報も含まれます。以下のコードは、プレゼンテーション（マスタースライドを含む）からテキストと書式情報を走査します。

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

## **カテゴリ別かつ高速なテキスト抽出**

[PresentationFactory](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationfactory/) クラスも、プレゼンテーションからすべてのテキストを抽出するメソッドを提供します。

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ja/net/aspose.slides/textextractionarrangingmode/) 列挙体の引数は、テキスト抽出結果の整理方法を示し、次の値に設定できます。
- `Unarranged` - スライド上の位置を考慮しない生のテキスト。  
- `Arranged` - スライド上の順序と同じ順序でテキストが整理される。

速度が重要な場合は、整理されていないモード (`Unarranged`) を使用すると、整理されたモード (`Arranged`) よりも高速になります。

[IPresentationText](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationtext/) はプレゼンテーションから抽出された生のテキストを表します。その `SlidesText` プロパティは [ISlideText](https://reference.aspose.com/slides/ja/net/aspose.slides/islidetext/) 型のオブジェクト配列を返します。各オブジェクトは対応するスライドのテキストを表します。 [ISlideText](https://reference.aspose.com/slides/ja/net/aspose.slides/islidetext/) 型のオブジェクトは以下のプロパティを持ちます。

- `Text` - スライド内のシェイプに含まれるテキスト。  
- `MasterText` - このスライドに関連付けられたマスタースライドのシェイプに含まれるテキスト。  
- `LayoutText` - このスライドに関連付けられたレイアウトスライドのシェイプに含まれるテキスト。  
- `NotesText` - このスライドのノートスライドのシェイプに含まれるテキスト。  
- `CommentsText` - このスライドに付随するコメントのテキスト。

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **FAQ**

**Aspose.Slides は大規模なプレゼンテーションのテキスト抽出をどの程度高速に処理できますか？**

Aspose.Slides は高性能に最適化されており、[大規模なプレゼンテーション](/slides/ja/net/open-presentation/) でもリアルタイムまたはバルク処理シナリオに適した速度で処理できます。

**Aspose.Slides はプレゼンテーション内の表やチャートからテキストを抽出できますか？**

はい。Aspose.Slides はテーブルやチャート関連オブジェクトを含む多くのスライド要素からテキストを抽出できるため、一般的なプレゼンテーション構造内のテキストコンテンツにアクセスして分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスは必要ですか？**

無料試用版でもテキスト抽出は可能ですが、[特定の制限](/slides/ja/net/licensing/)（例: スライド数の上限）があり、制限なく大規模なプレゼンテーションを扱うにはフルライセンスの購入が推奨されます。