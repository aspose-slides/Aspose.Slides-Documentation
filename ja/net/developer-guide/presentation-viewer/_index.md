---
title: C#でプレゼンテーションビューアを作成する
linktitle: プレゼンテーションビューア
type: docs
weight: 50
url: /ja/net/presentation-viewer/
keywords:
- プレゼンテーションを表示
- プレゼンテーションビューア
- プレゼンテーションビューアを作成
- PPTを表示
- PPTXを表示
- ODPを表示
- PowerPoint
- OpenDocument
- C#
- Csharp
- Aspose.Slides for .NET
description: "Aspose.Slides を使用して .NET でカスタムのプレゼンテーションビューアを作成する方法を学びます。Microsoft PowerPoint やその他のオフィスソフトウェアを必要とせず、PowerPoint（PPTX、PPT）および OpenDocument（ODP）ファイルを簡単に表示できます。"
---

## **概要**

Aspose.Slides for .NET は、スライドを含むプレゼンテーション ファイルの作成に使用されます。これらのスライドは、たとえば Microsoft PowerPoint でプレゼンテーションを開くことで表示できます。ただし、開発者がスライドを好みの画像ビューアで画像として表示したり、独自のプレゼンテーション ビューアで使用したりする必要がある場合があります。そのようなケースでは、Aspose.Slides を使用して個々のスライドを画像としてエクスポートできます。本記事ではその手順を説明します。

## **スライドから SVG 画像を生成する**

Aspose.Slides を使用してプレゼンテーション スライドから SVG 画像を生成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. ファイルストリームを開きます。
1. スライドを SVG 画像としてファイルストリームに保存します。
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```


## **カスタム シェイプ ID を持つ SVG を生成する**

Aspose.Slides を使用して、カスタム シェイプ `ID` を持つスライドから [SVG](https://docs.fileformat.com/page-description-language/svg/) を生成できます。そのためには、[ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape) インターフェイスの Id プロパティを使用します。`CustomSvgShapeFormattingController` クラスを使用してシェイプ ID を設定できます。
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```


## **スライドのサムネイル画像を作成する**

Aspose.Slides はスライドのサムネイル画像の生成を支援します。Aspose.Slides を使用してスライドのサムネイルを生成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. 目的の倍率で参照したスライドのサムネイル画像を作成します。
1. 好みの画像形式でサムネイル画像を保存します。
```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **ユーザー定義サイズのスライド サムネイルを作成する**

ユーザーが指定したサイズでスライドのサムネイル画像を作成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. 指定したサイズで参照したスライドのサムネイル画像を生成します。
1. 好みの画像形式でサムネイル画像を保存します。
```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **スライドのサムネイルにスピーカーノートを付加する**

Aspose.Slides を使用してスピーカーノート付きのスライドサムネイルを生成するには、以下の手順に従います。

1. [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) クラスのインスタンスを作成します。
1. `RenderingOptions.SlidesLayoutOptions` プロパティを使用してスピーカーノートの位置を設定します。
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスでスライドへの参照を取得します。
1. レンダリング オプションを使用して参照したスライドのサムネイル画像を生成します。
1. 好みの画像形式でサムネイル画像を保存します。
```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```


## **ライブ例**

Aspose.Slides API を使用して実装できる内容を確認するには、無料アプリ **Aspose.Slides Viewer** をお試しください：

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**ASP.NET Web アプリケーションにプレゼンテーション ビューアを埋め込むことはできますか？**

はい。サーバー側で Aspose.Slides を使用してスライドを画像または HTML にレンダリングし、ブラウザーで表示できます。ナビゲーションやズーム機能は JavaScript で実装すれば、インタラクティブな体験が可能です。

**カスタム .NET ビューア内でスライドを表示する最適な方法は何ですか？**

推奨される方法は、各スライドを画像（例: PNG または SVG）としてレンダリングするか、Aspose.Slides で HTML に変換し、デスクトップの場合はピクチャーボックス、Web の場合は HTML コンテナに出力を表示することです。

**多数のスライドを含む大規模なプレゼンテーションはどう扱うべきですか？**

大容量のデッキの場合、スライドの遅延読み込みまたはオンデマンドレンダリングを検討してください。これは、ユーザーがスライドに移動したときにのみそのスライドのコンテンツを生成することで、メモリ使用量とロード時間を削減します。