---
title: C# で PPT、PPTX、ODP を JPG に変換
linktitle: スライドを JPG 画像に変換
type: docs
weight: 60
url: /ja/net/convert-powerpoint-to-jpg/
keywords:
- PowerPoint を JPG に変換
- プレゼンテーションを JPG に変換
- スライドを JPG に変換
- PPT を JPG に変換
- PPTX を JPG に変換
- ODP を JPG に変換
- PowerPoint を JPG に変換
- プレゼンテーションを JPG に変換
- スライドを JPG に変換
- PPT を JPG に変換
- PPTX を JPG に変換
- ODP を JPG に変換
- PowerPoint を JPEG に変換
- プレゼンテーションを JPEG に変換
- スライドを JPEG に変換
- PPT を JPEG に変換
- PPTX を JPEG に変換
- ODP を JPEG に変換
- PowerPoint を JPEG に変換
- プレゼンテーションを JPEG に変換
- スライドを JPEG に変換
- PPT を JPEG に変換
- PPTX を JPEG に変換
- ODP を JPEG に変換
- C#
- C#
- .NET
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションのスライドを、数行のコードで高品質な JPEG 画像に変換する方法を学びましょう。ウェブでの使用、共有、アーカイブのためにプレゼンテーションを最適化できます。今すぐ完全ガイドをご覧ください！"
---

## **概要**

PowerPoint および OpenDocument のプレゼンテーションを JPG 画像に変換することで、スライドの共有、パフォーマンスの最適化、ウェブサイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides for .NET を使用すると、PPTX、PPT、ODP ファイルを高品質な JPEG 画像に変換できます。このガイドでは、さまざまな変換方法を説明します。

これらの機能を使用すれば、独自のプレゼンテーションビューアを実装し、各スライドのサムネイルを作成することが簡単になります。スライドのコピーから保護したい場合や、読み取り専用モードでプレゼンテーションをデモする場合に便利です。Aspose.Slides は、プレゼンテーション全体または特定のスライドを画像形式に変換することができます。

## **プレゼンテーション スライドを JPG 画像に変換**

1. Presentation クラスのインスタンスを作成します。
1. Presentation.Slides コレクションから ISlide 型のスライドオブジェクトを取得します。
1. ISlide.GetImage(float, float) メソッドを使用してスライドの画像を作成します。
1. 画像オブジェクトで IImage.Save(string, ImageFormat) メソッドを呼び出します。出力ファイル名と画像フォーマットを引数として渡します。

{{% alert color="primary" %}} 
**注:** PPT、PPTX、ODP から JPG への変換は、Aspose.Slides .NET API で他のフォーマットへの変換とは異なります。他のフォーマットでは通常、IPresentation.Save(String, SaveFormat, ISaveOptions) メソッドを使用します。しかし、JPG 変換の場合は IImage.Save(string, ImageFormat) メソッドを使用する必要があります。
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


## **カスタム寸法でスライドを JPG に変換**

生成される JPG 画像のサイズを変更するには、ISlide.GetImage(Size) メソッドにサイズを渡して画像サイズを設定できます。これにより、特定の幅と高さの値で画像を生成でき、解像度やアスペクト比の要件を満たす出力が得られます。この柔軟性は、ウェブアプリケーション、レポート、ドキュメント向けに正確な画像サイズが必要な場合に特に有用です。
```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 指定したサイズでスライド画像を作成します。
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // 画像を JPEG 形式でディスクに保存します。
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **スライドを画像として保存する際にコメントをレンダリング**

Aspose.Slides for .NET には、プレゼンテーションのスライドを JPG 画像に変換する際にコメントをレンダリングできる機能があります。この機能は、PowerPoint プレゼンテーションで共同作業者が追加した注釈、フィードバック、ディスカッションを保持するのに特に有用です。このオプションを有効にすると、生成された画像にコメントが表示されるため、元のプレゼンテーションファイルを開かずにフィードバックの確認や共有が容易になります。

たとえば、コメントを含むスライドがあるプレゼンテーションファイル「sample.pptx」があるとします。

![コメント付きスライド](slide_with_comments.png)

次の C# コードは、コメントを保持したままスライドを JPG 画像に変換します。
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

PPT、PPTX、ODP を画像に変換する他のオプションを次に示します。

- [PowerPoint を GIF に変換](/slides/ja/net/convert-powerpoint-to-animated-gif/)
- [PowerPoint を PNG に変換](/slides/ja/net/convert-powerpoint-to-png/)
- [PowerPoint を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff/)
- [PowerPoint を SVG に変換](/slides/ja/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Aspose.Slides が PowerPoint を JPG 画像に変換する方法を確認するには、次の無料オンラインコンバータを試してください。PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。
{{% /alert %}} 

![無料オンライン PPTX から JPG へのコンバータ](ppt-to-jpg.png)

{{% alert title="ヒント" color="primary" %}}

Aspose は、[無料の Collage Web アプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを使用すると、JPG から JPG や PNG から PNG の画像を結合したり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid)を作成したりすることができます。

この記事で説明した同じ原則を使用して、画像をあるフォーマットから別のフォーマットに変換できます。詳細については、次のページをご参照ください：[画像を JPG に変換](https://products.aspose.com/slides/net/conversion/image-to-jpg/)；[JPG を画像に変換](https://products.aspose.com/slides/net/conversion/jpg-to-image/)；[JPG を PNG に変換](https://products.aspose.com/slides/net/conversion/jpg-to-png/)、[PNG を JPG に変換](https://products.aspose.com/slides/net/conversion/png-to-jpg/)、[PNG を SVG に変換](https://products.aspose.com/slides/net/conversion/png-to-svg/)、[SVG を PNG に変換](https://products.aspose.com/slides/net/conversion/svg-to-png/)。

{{% /alert %}}

## **よくある質問**

**この方法はバッチ変換をサポートしていますか？**

はい、Aspose.Slides は、