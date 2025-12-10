---
title: ".NET で PPT と PPTX を JPG に変換"
linktitle: "PowerPoint を JPG に変換"
type: docs
weight: 60
url: /ja/net/convert-powerpoint-to-jpg/
keywords:
- PowerPoint を変換
- プレゼンテーション を変換
- スライド を変換
- PPT を変換
- PPTX を変換
- PowerPoint を JPG に変換
- プレゼンテーション を JPG に変換
- スライド を JPG に変換
- PPT を JPG に変換
- PPTX を JPG に変換
- PowerPoint を JPG として保存
- プレゼンテーション を JPG として保存
- スライド を JPG として保存
- PPT を JPG として保存
- PPTX を JPG として保存
- PPT を JPG にエクスポート
- PPTX を JPG にエクスポート
- .NET
- C#
- Aspose.Slides
description: "C# と Aspose.Slides for .NET を使用して、PowerPoint (PPT、PPTX) スライドを高速で信頼性の高いコード例により高品質な JPG 画像に変換します。"
---

## **概要**

PowerPoint および OpenDocument プレゼンテーションを JPG 画像に変換すると、スライドの共有、パフォーマンスの最適化、Web サイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides for .NET を使用すると、PPTX、PPT、ODP ファイルを高品質な JPEG 画像に変換できます。このガイドでは、変換のさまざまな方法を説明します。

これらの機能により、独自のプレゼンテーションビューアを実装し、各スライドのサムネイルを作成することが簡単になります。スライドのコピー防止や、読み取り専用モードでプレゼンテーションをデモする場合に役立ちます。Aspose.Slides を使用すると、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

## **プレゼンテーション スライドを JPG 画像に変換する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) コレクションから、[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) タイプのスライドオブジェクトを取得します。
3. [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) メソッドを使用してスライドの画像を作成します。
4. 画像オブジェクトで [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) メソッドを呼び出します。出力ファイル名と画像フォーマットを引数として渡します。

{{% alert color="primary" %}} 
**注:** PPT、PPTX、または ODP から JPG への変換は、Aspose.Slides .NET API における他の形式への変換とは異なります。他の形式では通常、[IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5) メソッドを使用します。ただし、JPG 変換の場合は、[IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) メソッドを使用する必要があります。
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
            // 画像を JPEG 形式でディスクに保存します。
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **カスタマイズされたサイズでスライドを JPG に変換する**

生成される JPG 画像のサイズを変更するには、[ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6) メソッドにサイズを渡して画像サイズを設定します。これにより、特定の幅と高さの値を持つ画像を生成でき、出力が解像度やアスペクト比の要件を満たすようにできます。この柔軟性は、ウェブアプリケーション、レポート、ドキュメント用の画像を生成する際に、正確な画像サイズが必要な場合に特に有用です。
```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 指定されたサイズでスライド画像を作成します。
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // 画像を JPEG 形式でディスクに保存します。
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **スライドを画像として保存する際にコメントをレンダリングする**

Aspose.Slides for .NET は、プレゼンテーションのスライドを JPG 画像に変換する際に、スライド上のコメントをレンダリングする機能を提供します。この機能は、PowerPoint プレゼンテーションに共同作業者が追加した注釈、フィードバック、ディスカッションを保持するのに特に有用です。このオプションを有効にすると、生成された画像にコメントが表示され、元のプレゼンテーションファイルを開かずにフィードバックを確認・共有しやすくなります。

例として、コメントが含まれたスライドを持つプレゼンテーション ファイル「sample.pptx」があるとします:
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

## **関連項目**

PPT、PPTX、または ODP を画像に変換する他のオプションとして、以下をご参照ください:

- [PowerPoint を GIF に変換](/slides/ja/net/convert-powerpoint-to-animated-gif/)
- [PowerPoint を PNG に変換](/slides/ja/net/convert-powerpoint-to-png/)
- [PowerPoint を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff/)
- [PowerPoint を SVG に変換](/slides/ja/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Aspose.Slides が PowerPoint を JPG 画像に変換する方法を見るには、以下の無料オンラインコンバータを試してください: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 
{{% /alert %}} 

![無料オンライン PPTX から JPG 変換ツール](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose は、[無料の Collage Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG の画像を結合したり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。

本記事で説明した同じ原理を使用して、画像をある形式から別の形式に変換できます。詳細については、以下のページをご覧ください: [画像を JPG に変換](https://products.aspose.com/slides/net/conversion/image-to-jpg/); [JPG を画像に変換](https://products.aspose.com/slides/net/conversion/jpg-to-image/); [JPG を PNG に変換](https://products.aspose.com/slides/net/conversion/jpg-to-png/)、[PNG を JPG に変換](https://products.aspose.com/slides/net/conversion/png-to-jpg/); [PNG を SVG に変換](https://products.aspose.com/slides/net/conversion/png-to-svg/)、[SVG を PNG に変換](https://products.aspose.com/slides/net/conversion/svg-to-png/)。
{{% /alert %}}

## **FAQ**

**この方法はバッチ変換をサポートしていますか？**

はい、Aspose.Slides は、