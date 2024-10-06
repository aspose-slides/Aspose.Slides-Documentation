---
title: スライドの変換
type: docs
weight: 41
url: /ja/net/convert-slide/
keywords: 
- スライドを画像に変換
- スライドを画像としてエクスポート
- スライドを画像として保存
- スライドから画像へ
- スライドをPNGへ
- スライドをJPEGへ
- スライドをビットマップへ
- C#
- Csharp
- .NET
- Aspose.Slides for .NET
description: "C#または.NETを使ってPowerPointスライドを画像（ビットマップ、PNG、またはJPG）に変換します"
---

Aspose.Slides for .NETを使用すると、スライド（プレゼンテーション内の）を画像に変換できます。サポートされている画像形式は次のとおりです: BMP、PNG、JPG（JPEG）、GIF、およびその他。

スライドを画像に変換するには、次のようにします：

1. まず、変換パラメータと変換するスライドオブジェクトを設定します:
   * [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions)インターフェースを使用するか、
   * [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions)インターフェースを使用します。

2. 次に、[GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/)メソッドを使用してスライドを画像に変換します。

## **ビットマップおよびその他の画像形式について**

.NETにおける[Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0)は、ピクセルデータによって定義された画像を操作するオブジェクトです。このクラスのインスタンスを使用して、幅広い形式（BMP、JPG、PNGなど）で画像を保存できます。

{{% alert title="情報" color="info" %}}

Asposeは最近、オンラインの[Text to GIF](https://products.aspose.app/slides/text-to-gif)変換ツールを開発しました。

{{% /alert %}}

## **スライドをビットマップに変換し、PNG形式で画像を保存する**

このC#コードは、プレゼンテーションの最初のスライドをビットマップオブジェクトに変換し、次に画像をPNG形式で保存する方法を示しています。

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // プレゼンテーションの最初のスライドをビットマップオブジェクトに変換
    using (IImage image = pres.Slides[0].GetImage())
    {
        // PNG形式で画像を保存
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert title="ヒント" color="primary" %}} 

スライドをビットマップオブジェクトに変換し、そのオブジェクトをどこかで直接使用することができます。また、スライドをビットマップに変換し、JPEGまたはその他の好みの形式で画像を保存することもできます。

{{% /alert %}}  

## **カスタムサイズの画像にスライドを変換する**

特定のサイズの画像が必要な場合があります。[GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/)のオーバーロードを使用すると、特定の寸法（長さと幅）を持つ画像にスライドを変換できます。

このサンプルコードは、C#での[GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/)メソッドを使用した提案された変換を示しています：

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // プレゼンテーションの最初のスライドを指定サイズのビットマップに変換
    using (IImage image = pres.Slides[0].GetImage(new Size(1820, 1040)))
    {
        // JPEG形式で画像を保存
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **ノートとコメントを含むスライドを画像に変換する**

一部のスライドにはノートとコメントが含まれています。

Aspose.Slidesは、プレゼンテーションスライドを画像にレンダリングするための制御を可能にする[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions)と[IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions)の2つのインターフェースを提供します。両インターフェースには、スライドを画像に変換するときにノートとコメントを追加するための[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions)インターフェースが含まれています。

{{% alert title="情報" color="info" %}} 

[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions)インターフェースを使用すると、結果として得られる画像内のノートとコメントの好ましい位置を指定できます。

{{% /alert %}} 

このC#コードは、ノートとコメントを持つスライドの変換プロセスを示しています：

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // レンダリングオプションを作成
    IRenderingOptions options = new RenderingOptions();

    // ページ内のノートの位置を設定
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // ページ内のコメントの位置を設定 
    options.NotesCommentsLayouting.CommentsPosition = CommentsPositions.Right;

    // コメント出力エリアの幅を設定
    options.NotesCommentsLayouting.CommentsAreaWidth = 500;

    // コメントエリアの色を設定
    options.NotesCommentsLayouting.CommentsAreaColor = Color.AntiqueWhite;

    // プレゼンテーションの最初のスライドをビットマップオブジェクトに変換
    using (IImage image = pres.Slides[0].GetImage(options, 2f, 2f))
    {
        // GIF形式で画像を保存
        image.Save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="注意" color="warning" %}} 

スライドから画像への変換プロセスでは、[NotesPositions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/properties/notesposition)プロパティをBottomFullに設定することはできません（ノートの位置を指定するため）。なぜなら、ノートのテキストが大きい場合、指定された画像サイズに収まらない可能性があるからです。

{{% /alert %}} 

## **ITiffOptionsを使用してスライドを画像に変換する**

[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions)インターフェースを使用すると、結果として得られる画像に対して（パラメータの観点から）より多くの制御が可能になります。このインターフェースを使用すると、結果として得られる画像のサイズ、解像度、カラーパレット、および他のパラメータを指定できます。

このC#コードは、ITiffOptionsを使用して300dpiの解像度と2160 × 2800のサイズで白黒画像を出力する変換プロセスを示しています：

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // インデックスを使ってスライドを取得
    ISlide slide = pres.Slides[0];

    // TiffOptionsオブジェクトを作成
    TiffOptions options = new TiffOptions() { ImageSize = new Size(2160, 2880) };

    // ソースフォントが見つからない場合に使用するフォントを設定
    options.DefaultRegularFont = "Arial Black";

    // ページ内のノートの位置を設定 
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // ピクセル形式を設定（白黒）
    options.PixelFormat = ImagePixelFormat.Format1bppIndexed;

    // 解像度を設定
    options.DpiX = 300;
    options.DpiY = 300;

    // スライドをビットマップオブジェクトに変換
    using (IImage image = slide.GetImage(options))
    {
        // BMP形式で画像を保存
        image.Save("PresentationNotesComments.tiff", ImageFormat.Tiff);
    }
}  
```

## **すべてのスライドを画像に変換する**

Aspose.Slidesを使用すると、単一のプレゼンテーション内のすべてのスライドを画像に変換できます。基本的に、プレゼンテーション全体を画像に変換することができます。

このサンプルコードは、C#でプレゼンテーション内のすべてのスライドを画像に変換する方法を示しています：

```csharp
// 出力ディレクトリのパスを指定
string outputDir = @"D:\PresentationImages";

using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // プレゼンテーションをスライドごとに画像にレンダリング
    for (int i = 0; i < pres.Slides.Count; i++)
    {
        // 非表示スライドの設定を指定（非表示スライドはレンダリングしない）
        if (pres.Slides[i].Hidden)
            continue;

        // スライドをビットマップオブジェクトに変換
        using (IImage image = pres.Slides[i].GetImage(2f, 2f))
        {
            // 画像のファイル名を作成
            string outputFilePath = Path.Combine(outputDir, "Slide_" + i + ".jpg");

            // JPEG形式で画像を保存
            image.Save(outputFilePath, ImageFormat.Jpeg);
        }
    }
}
```