---
title: .NET で PPT と PPTX を JPG に変換
linktitle: PowerPoint を JPG に変換
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
description: "Aspose.Slides for .NET を使用して、C# で PowerPoint (PPT、PPTX) スライドを高速かつ信頼性の高いコード例で高品質な JPG 画像に変換します。"
---

## **概要**

PowerPoint および OpenDocument プレゼンテーションを JPG 画像に変換すると、スライドの共有、パフォーマンスの最適化、ウェブサイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides for .NET を使用すると、PPTX、PPT、ODP ファイルを高品質な JPEG 画像に変換できます。このガイドでは、さまざまな変換方法について説明します。

これらの機能により、独自のプレゼンテーションビューアを実装したり、各スライドのサムネイルを作成したりすることが簡単になります。スライドのコピーを防止したり、読み取り専用モードでプレゼンテーションをデモンストレーションしたりしたい場合に便利です。Aspose.Slides を使用すると、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

## **プレゼンテーション スライドを JPG 画像に変換**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) コレクションから [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) タイプのスライドオブジェクトを取得します。
3. [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) メソッドを使用してスライドの画像を作成します。
4. 画像オブジェクトで [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) メソッドを呼び出します。出力ファイル名と画像形式を引数として渡します。

{{% alert color="primary" %}} 
**注:** PPT、PPTX、または ODP から JPG への変換は、Aspose.Slides .NET API の他の形式への変換とは異なります。他の形式の場合、通常は [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5) メソッドを使用します。ただし、JPG 変換の場合は [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) メソッドを使用する必要があります。
{{% /alert %}} 
```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 指定したスケールでスライド画像を作成します。
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // JPEG 形式で画像をディスクに保存します。
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **カスタマイズしたサイズでスライドを JPG に変換**

結果となる JPG 画像のサイズを変更するには、[ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6) メソッドにサイズを渡して画像サイズを設定できます。これにより、特定の幅と高さの値を持つ画像を生成でき、解像度やアスペクト比の要件を満たすことができます。この柔軟性は、Web アプリケーション、レポート、ドキュメント向けに正確な画像サイズが必要な場合に特に有用です。
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


## **画像としてスライドを保存する際にコメントをレンダリング**

Aspose.Slides for .NET は、プレゼンテーションのスライドを JPG 画像に変換する際にコメントをレンダリングする機能を提供します。この機能は、PowerPoint プレゼンテーションで共同作業者が追加した注釈、フィードバック、議論を保存するのに特に便利です。このオプションを有効にすると、生成された画像にコメントが表示されるため、元のプレゼンテーションファイルを開かずにフィードバックを確認・共有しやすくなります。

たとえば、コメントを含むスライドがあるプレゼンテーション ファイル "sample.pptx" があるとします:
![コメント付きスライド](slide_with_comments.png)

以下の C# コードは、コメントを保持したままスライドを JPG 画像に変換します:
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


結果:
![コメント付き JPG 画像](image_with_comments.png)

## **参照**

PPT、PPTX、または ODP を画像に変換する他のオプションとして、例えば以下が挙げられます:
- [PowerPoint を GIF に変換](/slides/ja/net/convert-powerpoint-to-animated-gif/)
- [PowerPoint を PNG に変換](/slides/ja/net/convert-powerpoint-to-png/)
- [PowerPoint を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff/)
- [PowerPoint を SVG に変換](/slides/ja/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Aspose.Slides が PowerPoint を JPG 画像に変換する方法を確認するには、以下の無料オンライン コンバータを試してください: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。
{{% /alert %}} 

![無料オンライン PPTX から JPG 変換ツール](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose は [FREE Collage web app](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG to JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG への画像を結合したり、[photo grids](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。

本記事で説明した同じ原則を使用すると、画像を別の形式に変換できます。詳細は以下のページをご覧ください: 変換 [画像を JPG に変換](https://products.aspose.com/slides/net/conversion/image-to-jpg/); 変換 [JPG から画像に変換](https://products.aspose.com/slides/net/conversion/jpg-to-image/); 変換 [JPG から PNG に変換](https://products.aspose.com/slides/net/conversion/jpg-to-png/); 変換 [PNG から JPG に変換](https://products.aspose.com/slides/net/conversion/png-to-jpg/); 変換 [PNG から SVG に変換](https://products.aspose.com/slides/net/conversion/png-to-svg/); 変換 [SVG から PNG に変換](https://products.aspose.com/slides/net/conversion/svg-to-png/)。
{{% /alert %}}

## **よくある質問**

**この方法はバッチ変換をサポートしていますか？**

はい、Aspose.Slides は単一の操作で