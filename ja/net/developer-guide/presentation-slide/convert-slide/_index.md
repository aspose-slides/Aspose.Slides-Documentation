---
title: .NET でプレゼンテーションスライドを画像に変換
linktitle: スライドを画像に変換
type: docs
weight: 41
url: /ja/net/convert-slide/
keywords:
- スライドを変換
- スライドをエクスポート
- スライドを画像に変換
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
description: "Aspose.Slides for .NET を使用して C# で PPT、PPTX、ODP のスライドを画像に変換します—高速で高品質なレンダリングと分かりやすいコード例を提供。"
---

## **概要**

Aspose.Slides for .NET を使用すると、PowerPoint および OpenDocument のプレゼンテーション スライドを BMP、PNG、JPG（JPEG）、GIF などのさまざまな画像形式に簡単に変換できます。

スライドを画像に変換する手順は以下のとおりです。

1. 変換設定を定義し、エクスポートするスライドを選択します。使用できるインターフェイスは次のとおりです。
    - [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) インターフェイス、または
    - [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/) インターフェイス。
2. [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) メソッドを呼び出してスライド画像を生成します。

.NET では、[Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) はピクセル データで定義された画像を扱えるオブジェクトです。このクラスのインスタンスを使って、BMP、JPG、PNG などの多数の形式で画像を保存できます。

## **スライドをビットマップに変換し、PNG で画像を保存**

スライドをビットマップ オブジェクトに変換してそのままアプリケーションで使用できます。または、スライドをビットマップに変換した後、JPEG など任意の形式で画像を保存することも可能です。

次の C# コードは、プレゼンテーションの最初のスライドをビットマップ オブジェクトに変換し、PNG 形式で保存する方法を示しています。
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

特定のサイズの画像が必要な場合があります。[GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) のオーバーロードを使用すると、幅と高さを指定してスライドを画像に変換できます。

このサンプルコードはその手順を示しています。
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

スライドにノートやコメントが含まれていることがあります。

Aspose.Slides は、[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) と [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/) の 2 つのインターフェイスを提供し、プレゼンテーション スライドを画像にレンダリングする際の設定を制御できます。両インターフェイスには `SlidesLayoutOptions` プロパティがあり、画像変換時にノートやコメントのレンダリング方法を構成できます。

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用すると、生成される画像内でノートとコメントの位置を好きな場所に設定できます。

次の C# コードは、ノートとコメント付きスライドを画像に変換する例です。
```cs
float scaleX = 2;
float scaleY = scaleX;

// プレゼンテーションファイルを読み込む。
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // レンダリングオプションを作成する。
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // ノートの位置を設定する。
            CommentsPosition = CommentsPositions.Right,      // コメントの位置を設定する。
            CommentsAreaWidth = 500,                         // コメント領域の幅を設定する。
            CommentsAreaColor = Color.AntiqueWhite           // コメント領域の色を設定する。
        }
    };

    // プレゼンテーションの最初のスライドを画像に変換する。
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // 画像を GIF 形式で保存する。
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```


{{% alert title="Note" color="warning" %}} 

スライドから画像への変換処理では、[NotesPosition](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) プロパティを `BottomFull` に設定できません（ノートのテキストが大きすぎて、指定した画像サイズに収まらなくなる可能性があるため）。 
{{% /alert %}} 

## **TIFF オプションを使用してスライドを画像に変換**

[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) インターフェイスを使用すると、サイズ、解像度、カラーパレットなどのパラメータを指定して、生成される TIFF 画像を細かく制御できます。

この C# コードは、TIFF オプションを利用して 300 DPI の解像度、サイズ 2160 × 2800 の白黒画像を出力する変換プロセスを示しています。
```cs
// プレゼンテーションファイルを読み込む。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // プレゼンテーションから最初のスライドを取得する。
    ISlide slide = presentation.Slides[0];

    // 出力 TIFF 画像の設定を構成する。
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // 画像サイズを設定する。
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // ピクセル形式を設定する（黒と白）。
        DpiX = 300,                                        // 水平解像度を設定する。
        DpiY = 300                                         // 垂直解像度を設定する。
    };

    // 指定したオプションでスライドを画像に変換する。
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // 画像を TIFF 形式で保存する。
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```


## **すべてのスライドを画像に変換**

Aspose.Slides を使えば、プレゼンテーション内のすべてのスライドを画像に変換でき、プレゼンテーション全体を画像の連続として出力できます。

次のサンプルコードは、C# でプレゼンテーションのすべてのスライドを画像に変換する方法を示しています。
```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // プレゼンテーションをスライド単位で画像にレンダリングします。
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


## **FAQ**

**1. Aspose.Slides はアニメーション付きスライドのレンダリングをサポートしていますか？**

いいえ、`GetImage` メソッドはスライドの静止画像のみを保存し、アニメーションは含まれません。

**2. 非表示スライドを画像としてエクスポートできますか？**

はい、非表示スライドも通常のスライドと同様に処理できます。処理ループに含めることを忘れないでください。

**3. 画像を影やエフェクト付きで保存できますか？**

はい、Aspose.Slides はスライドを画像として保存する際に、影、透明度、その他のグラフィック効果のレンダリングをサポートしています。