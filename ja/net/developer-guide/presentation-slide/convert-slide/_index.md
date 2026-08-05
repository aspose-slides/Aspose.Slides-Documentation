---
title: プレゼンテーションスライドを .NET で画像に変換
linktitle: スライドを画像に変換
type: docs
weight: 41
url: /ja/net/convert-slide/
keywords:
- スライド変換
- スライドエクスポート
- スライドから画像へ
- スライドを画像として保存
- スライドを PNG に変換
- スライドを JPEG に変換
- スライドをビットマップに変換
- スライドを TIFF に変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、C# で PPT、PPTX、ODP のスライドを画像に変換します—高速で高品質なレンダリングと分かりやすいコード例を提供します。"
---
## **概要**

Aspose.Slides for .NET を使用すると、PowerPoint および OpenDocument のプレゼンテーションスライドを BMP、PNG、JPG（JPEG）、GIF などのさまざまな画像形式に簡単に変換できます。

スライドを画像に変換するには、次の手順を実行します。

1. 変換設定を定義し、エクスポートするスライドを次のインターフェイスを使用して選択します：
    - [ITiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/itiffoptions/) インターフェイス、または
    - [IRenderingOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/irenderingoptions/) インターフェイス。
2. [GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/getimage/) メソッドを呼び出してスライド画像を生成します。

.NET では、[Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) はピクセルデータで定義された画像を扱うことができるオブジェクトです。このクラスのインスタンスを使用して、BMP、JPG、PNG など幅広い形式で画像を保存できます。

## **スライドをビットマップに変換し、PNG で画像を保存**

スライドをビットマップオブジェクトに変換してアプリケーションで直接使用できます。または、スライドをビットマップに変換した後、JPEG やその他の任意の形式で画像を保存することも可能です。

この C# コードは、プレゼンテーションの最初のスライドをビットマップオブジェクトに変換し、PNG 形式で画像を保存する方法を示しています。

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // プレゼンテーションの最初のスライドをビットマップに変換します。
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // 画像を PNG 形式で保存します。
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **カスタムサイズでスライドを画像に変換**

特定のサイズの画像が必要になることがあります。[GetImage] のオーバーロードを使用すると、幅と高さを指定してスライドを画像に変換できます。

このサンプルコードは、その方法を示しています。

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // 指定されたサイズでプレゼンテーションの最初のスライドをビットマップに変換します。
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // 画像を JPEG 形式で保存します。
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **ノートとコメント付きスライドを画像に変換**

一部のスライドにはノートやコメントが含まれることがあります。

Aspose.Slides は、[ITiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/itiffoptions/) と [IRenderingOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/irenderingoptions/) の 2 つのインターフェイスを提供し、プレゼンテーションスライドの画像へのレンダリングを制御できます。両インターフェイスには `SlidesLayoutOptions` プロパティが含まれており、画像に変換する際のスライド上のノートやコメントのレンダリング方法を構成できます。

[NotesCommentsLayoutingOptions] クラスを使用すると、生成された画像内でノートとコメントの位置を任意に指定できます。

この C# コードは、ノートとコメントを含むスライドを画像に変換する方法を示しています。

```cs
float scaleX = 2;
float scaleY = scaleX;

// プレゼンテーションファイルをロードします。
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // レンダリングオプションを作成します。
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // ノートの位置を設定します。
            CommentsPosition = CommentsPositions.Right,      // コメントの位置を設定します。
            CommentsAreaWidth = 500,                         // コメント領域の幅を設定します。
            CommentsAreaColor = Color.AntiqueWhite           // コメント領域の色を設定します。
        }
    };

    // プレゼンテーションの最初のスライドを画像に変換します。
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // 画像を GIF 形式で保存します。
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 
スライド→画像変換プロセスでは、`BottomFull` に設定できる `NotesPosition` プロパティは使用できません。ノートのテキストが大きすぎて、指定された画像サイズに収まらなくなる可能性があるためです。
{{% /alert %}} 

## **TIFF オプションを使用してスライドを画像に変換**

[ITiffOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/itiffoptions/) インターフェイスを使用すると、サイズ、解像度、カラーパレットなどのパラメーターを指定でき、生成される TIFF 画像をより細かく制御できます。

この C# コードは、TIFF オプションを使用して 300 DPI の解像度、サイズ 2160 × 2800 の白黒画像を出力する変換プロセスを示しています。

```cs
// プレゼンテーションファイルをロードします。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // プレゼンテーションから最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // 出力 TIFF 画像の設定を構成します。
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // 画像サイズを設定します。
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // ピクセルフォーマットを設定します（白黒）。
        DpiX = 300,                                        // 水平解像度を設定します。
        DpiY = 300                                         // 垂直解像度を設定します。
    };

    // 指定されたオプションでスライドを画像に変換します。
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // 画像を TIFF 形式で保存します。
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **すべてのスライドを画像に変換**

Aspose.Slides を使用すると、プレゼンテーション内のすべてのスライドを画像に変換でき、プレゼンテーション全体を画像の連続に変換できます。

このサンプルコードは、C# でプレゼンテーション内のすべてのスライドを画像に変換する方法を示しています。

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // プレゼンテーションをスライドごとに画像へレンダリングします。
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // 非表示スライドを制御します（非表示スライドはレンダリングしません）。
        if (presentation.Slides[i].Hidden)
            continue;

        // スライドを画像に変換します。
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // 画像を JPEG 形式で保存します。
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **カラー絵文字のレンダリング**

{{% alert title="Note" color="warning" %}} 
プレゼンテーションスライドを画像に変換する際にカラー絵文字を正しくレンダリングするには、変換を実行するシステムにプレゼンテーションで使用されている絵文字フォントがインストールされ、利用可能である必要があります。たとえば、プレゼンテーションで **Segoe UI Emoji** が使用されているがこのフォントが欠落している場合、出力画像の絵文字はモノクロで表示される可能性があります。
{{% /alert %}} 

## **FAQ**

**Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ、`GetImage` メソッドはスライドの静止画像のみを保存し、アニメーションは含まれません。

**非表示のスライドを画像としてエクスポートできますか？**

はい、非表示のスライドも通常のスライドと同様に処理できます。処理ループに含めることを忘れないでください。

**画像を影や効果付きで保存できますか？**

はい、Aspose.Slides はスライドを画像として保存するときに影、透明度、その他のグラフィック効果のレンダリングをサポートしています。