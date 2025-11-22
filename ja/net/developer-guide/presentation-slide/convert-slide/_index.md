---
title: PowerPointスライドをC#で画像に変換
linktitle: スライドから画像へ
type: docs
weight: 41
url: /ja/net/convert-slide/
keywords:
- スライドを変換
- スライドを画像に変換
- スライドを画像としてエクスポート
- スライドを画像として保存
- スライドから画像へ
- スライドをPNGへ
- スライドをJPEGへ
- スライドをビットマップへ
- C#
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint および OpenDocument スライドをさまざまな形式に変換する方法を学びます。PPTX および ODP スライドを BMP、PNG、JPEG、TIFF など高品質でエクスポートできます。"
---

## **概要**

Aspose.Slides for .NET を使用すると、PowerPoint および OpenDocument のプレゼンテーション スライドを BMP、PNG、JPG（JPEG）、GIF などのさまざまな画像形式に簡単に変換できます。

スライドを画像に変換するには、次の手順に従います。

1. 必要な変換設定を定義し、エクスポートするスライドを次のいずれかで選択します。
    - [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) インターフェイス、または
    - [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/) インターフェイス。
2. [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) メソッドを呼び出してスライド画像を生成します。

.NET では、[Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) はピクセル データで定義された画像を操作できるオブジェクトです。このクラスのインスタンスを使用して、BMP、JPG、PNG などの幅広い形式で画像を保存できます。

## **スライドを Bitmap に変換し、PNG で画像を保存する**

スライドを Bitmap オブジェクトに変換してアプリケーションで直接使用できます。または、スライドを Bitmap に変換した後、JPEG などの任意の形式で画像を保存できます。

この C# コードは、プレゼンテーションの最初のスライドを Bitmap オブジェクトに変換し、PNG 形式で画像を保存する方法を示しています:
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


## **カスタム サイズでスライドを画像に変換する**

特定のサイズの画像が必要な場合があります。[GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) のオーバーロードを使用すると、幅と高さを指定してスライドを画像に変換できます。

このサンプルコードは、これを実行する方法を示しています:
```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // 指定したサイズでプレゼンテーションの最初のスライドをビットマップに変換します。
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // 画像を JPEG 形式で保存します。
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```


## **ノートとコメント付きスライドを画像に変換する**

スライドによってはノートやコメントが含まれていることがあります。

Aspose.Slides は、[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) と [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/) の 2 つのインターフェイスを提供し、プレゼンテーション スライドを画像にレンダリングする方法を制御できます。両インターフェイスには `SlidesLayoutOptions` プロパティが含まれ、スライドを画像に変換する際のノートとコメントのレンダリングを構成できます。

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用すると、生成された画像内でノートとコメントの位置を好きな場所に指定できます。

この C# コードは、ノートとコメントを含むスライドを変換する方法を示しています:
```cs
float scaleX = 2;
float scaleY = scaleX;

// プレゼンテーション ファイルを読み込みます。
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // レンダリング オプションを作成します。
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

スライドから画像への変換プロセスにおいて、[NotesPosition](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) プロパティを `BottomFull`（ノートの位置指定）に設定できません。ノートのテキストが大きすぎて、指定した画像サイズ内に収まらない可能性があるためです。

{{% /alert %}} 

## **TIFF オプションを使用してスライドを画像に変換する**

[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) インターフェイスは、サイズ、解像度、カラーパレットなどのパラメーターを指定でき、生成される TIFF 画像をより細かく制御できます。

この C# コードは、TIFF オプションを使用して 300 DPI の解像度で 2160 × 2800 のサイズの白黒画像を出力する変換プロセスを示しています:
```cs
// プレゼンテーション ファイルを読み込みます。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // プレゼンテーションから最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // 出力 TIFF 画像の設定を構成します。
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // 画像サイズを設定します。
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // ピクセル形式（黒と白）を設定します。
        DpiX = 300,                                        // 水平解像度を設定します。
        DpiY = 300                                         // 垂直解像度を設定します。
    };

    // 指定したオプションでスライドを画像に変換します。
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // 画像を TIFF 形式で保存します。
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```


## **すべてのスライドを画像に変換する**

Aspose.Slides を使用すると、プレゼンテーション内のすべてのスライドを画像に変換でき、プレゼンテーション全体を画像のシリーズに変換できます。

このサンプルコードは、C# でプレゼンテーションのすべてのスライドを画像に変換する方法を示しています:
```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // プレゼンテーションをスライドごとに画像にレンダリングします。
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

いいえ、`GetImage` メソッドはアニメーションなしの静止画像のみを保存します。

**2. 非表示スライドを画像としてエクスポートできますか？**

はい、非表示スライドも通常のスライドと同様に処理できます。処理ループに含めることを忘れないでください。

**3. 影やエフェクト付きで画像を保存できますか？**

はい、Aspose.Slides はスライドを画像として保存する際に、影、透明度、その他のグラフィック効果をレンダリングすることをサポートしています。