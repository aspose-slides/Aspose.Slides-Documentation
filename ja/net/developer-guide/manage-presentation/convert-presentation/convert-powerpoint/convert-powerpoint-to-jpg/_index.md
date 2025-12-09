---
title: .NETでPPTとPPTXをJPGに変換
linktitle: PowerPointをJPGに変換
type: docs
weight: 60
url: /ja/net/convert-powerpoint-to-jpg/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を JPG に変換
- プレゼンテーションを JPG に変換
- スライドを JPG に変換
- PPT を JPG に変換
- PPTX を JPG に変換
- PowerPoint を JPG として保存
- プレゼンテーションを JPG として保存
- スライドを JPG として保存
- PPT を JPG として保存
- PPTX を JPG として保存
- PPT を JPG にエクスポート
- PPTX を JPG にエクスポート
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用し、C# で高速かつ信頼性の高いコード例を用いて PowerPoint（PPT、PPTX）スライドを高品質な JPG 画像に変換します。"
---

## **概要**

PowerPoint および OpenDocument のプレゼンテーションを JPG 画像に変換すると、スライドの共有、パフォーマンスの最適化、Web サイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides for .NET を使用すると、PPTX、PPT、ODP ファイルを高品質な JPEG 画像に変換できます。このガイドでは、さまざまな変換方法について説明します。

これらの機能により、独自のプレゼンテーションビューアを実装し、すべてのスライドのサムネイルを作成することが簡単になります。スライドのコピーを防止したり、読み取り専用モードでプレゼンテーションをデモ表示したりする場合に便利です。Aspose.Slides では、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

## **プレゼンテーション スライドを JPG 画像に変換**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) コレクションから [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 型のスライドオブジェクトを取得します。
3. [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) メソッドを使用してスライドの画像を作成します。
4. 画像オブジェクトに対して [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) メソッドを呼び出します。出力ファイル名と画像形式を引数として渡します。

{{% alert color="primary" %}} 
**注:** PPT、PPTX、または ODP から JPG への変換は、Aspose.Slides .NET API における他の形式への変換とは異なります。その他の形式の場合、通常は [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5) メソッドを使用します。ただし、JPG 変換の場合は [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) メソッドを使用する必要があります。
{{% /alert %}} 
```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 指定されたスケールでスライド画像を作成します。
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // JPEG 形式で画像をディスクに保存します。
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **カスタマイズされたサイズでスライドを JPG に変換**

生成される JPG 画像のサイズを変更するには、[ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6) メソッドにサイズを渡して画像サイズを設定できます。これにより、特定の幅と高さの値で画像を生成でき、解像度やアスペクト比の要件を満たす出力が得られます。この柔軟性は、Web アプリケーション、レポート、ドキュメント向けに正確な画像サイズが必要な場合に特に有用です。
```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 指定されたサイズでスライド画像を作成します。
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // JPEG 形式で画像をディスクに保存します。
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **スライドを画像として保存する際にコメントを描画**

Aspose.Slides for .NET は、プレゼンテーションのスライドを JPG 画像に変換する際にコメントを描画できる機能を提供します。この機能は、PowerPoint プレゼンテーションで共同作業者が追加した注釈、フィードバック、議論を保持するのに特に有用です。このオプションを有効にすると、生成された画像にコメントが表示され、元のプレゼンテーションファイルを開かずにフィードバックをレビューおよび共有しやすくなります。

例として、コメントが含まれるスライドを持つプレゼンテーション ファイル "sample.pptx" があるとします：

![コメント付きスライド](slide_with_comments.png)

次の C# コードは、スライドを JPG 画像に変換し、コメントを保持します：

```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // スライドコメントのオプションを設定します。
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // 最初のスライドを画像に変換します。
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```


結果：

![コメント付き JPG 画像](image_with_comments.png)

## **関連項目**

PPT、PPTX、または ODP を画像に変換する他のオプションとして、以下をご覧ください：

- [PowerPoint を GIF に変換](/slides/ja/net/convert-powerpoint-to-animated-gif/)
- [PowerPoint を PNG に変換](/slides/ja/net/convert-powerpoint-to-png/)
- [PowerPoint を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff/)
- [PowerPoint を SVG に変換](/slides/ja/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Aspose.Slides が PowerPoint を JPG 画像に変換する方法を確認するには、以下の無料オンラインコンバータを試してください：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 
{{% /alert %}} 

![無料オンライン PPTX から JPG へのコンバータ](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose は [FREE Collage web app](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG to JPG](https://products.aspose.app/slides/collage/jpg) や PNG to PNG 画像を結合したり、[photo grids](https://products.aspose.app/slides/collage/photo-grid) を作成したりすることができます。 

この記事で説明した同じ原則を使用して、画像を別の形式に変換できます。詳細については、次のページをご覧ください：convert [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/); convert [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/); convert [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/)。
{{% /alert %}}

## **よくある質問**

**この方法はバッチ変換をサポートしますか？**

はい、Aspose.Slides は単一の操作で