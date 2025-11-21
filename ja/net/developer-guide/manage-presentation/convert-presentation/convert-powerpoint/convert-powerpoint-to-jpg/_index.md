---
title: PPT と PPTX を .NET で JPG に変換
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
description: "Aspose.Slides for .NET を使用し、C# で PowerPoint (PPT、PPTX) のスライドを高速で信頼性の高いコード例を使って高品質な JPG 画像に変換します。"
---

## **概要**

PowerPoint と OpenDocument のプレゼンテーションを JPG 画像に変換すると、スライドの共有、パフォーマンスの最適化、ウェブサイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides for .NET を使用すると、PPTX、PPT、ODP ファイルを高品質な JPEG 画像に変換できます。本ガイドでは、さまざまな変換方法を説明します。

これらの機能を利用すれば、独自のプレゼンテーションビューアを実装したり、各スライドのサムネイルを作成したりできます。プレゼンテーションのスライドをコピーから保護したり、読み取り専用モードでデモンストレーションしたりする場合に便利です。Aspose.Slides では、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

## **プレゼンテーション スライドを JPG 画像に変換する**

PPT、PPTX、または ODP ファイルを JPG に変換する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) コレクションから [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 型のスライド オブジェクトを取得します。
1. [ISlide.GetImage(float,float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) メソッドを使用してスライドの画像を作成します。
1. 画像オブジェクトの [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) メソッドを呼び出します。出力ファイル名と画像形式を引数として渡します。

{{% alert color="primary" %}} 

**注:** PPT、PPTX、または ODP から JPG への変換は、Aspose.Slides .NET API の他の形式への変換とは異なります。その他の形式の場合、通常は [IPresentation.Save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5) メソッドを使用します。ただし、JPG 変換の場合は [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) メソッドを使用する必要があります。

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

結果の JPG 画像のサイズを変更するには、[ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6) メソッドにサイズを渡して画像サイズを指定できます。これにより、特定の幅と高さの値で画像を生成でき、解像度やアスペクト比の要件を満たすことができます。この柔軟性は、Web アプリケーション、レポート、ドキュメント向けに正確な画像サイズが必要な場合に特に便利です。
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


## **スライドを画像として保存する際にコメントをレンダリングする**

Aspose.Slides for .NET は、スライドを JPG 画像に変換する際にプレゼンテーションのコメントをレンダリングできる機能を提供します。この機能は、PowerPoint プレゼンテーションに共同作業者が追加した注釈、フィードバック、ディスカッションを保存したい場合に特に有用です。このオプションを有効にすると、生成された画像にコメントが表示され、元のプレゼンテーション ファイルを開かなくてもフィードバックの確認や共有が容易になります。

たとえば、コメントを含むスライドがあるプレゼンテーション ファイル「sample.pptx」があるとします。

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

PPT、PPTX、または ODP を画像に変換する他のオプションをご覧ください。

- [PowerPoint を GIF に変換](/slides/ja/net/convert-powerpoint-to-animated-gif/)
- [PowerPoint を PNG に変換](/slides/ja/net/convert-powerpoint-to-png/)
- [PowerPoint を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff/)
- [PowerPoint を SVG に変換](/slides/ja/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Aspose.Slides が PowerPoint を JPG 画像に変換する様子を確認するには、次の無料オンライン コンバータをご利用ください: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) および [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 

{{% /alert %}} 

![無料オンライン PPTX to JPG コンバータ](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose は [無料のコラージュ Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンライン サービスを使って、[JPG to JPG](https://products.aspose.app/slides/collage/jpg) や PNG to PNG の画像を結合したり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。 

本記事で説明した同じ原則を使用して、画像を別の形式に変換できます。詳細は次のページをご参照ください: 画像を [JPG に変換](https://products.aspose.com/slides/net/conversion/image-to-jpg/)；[JPG を画像に変換](https://products.aspose.com/slides/net/conversion/jpg-to-image/)；[JPG を PNG に変換](https://products.aspose.com/slides/net/conversion/jpg-to-png/)、[PNG を JPG に変換](https://products.aspose.com/slides/net/conversion/png-to-jpg/)；[PNG を SVG に変換](https://products.aspose.com/slides/net/conversion/png-to-svg/)、[SVG を PNG に変換](https://products.aspose.com/slides/net/conversion/svg-to-png/)。

{{% /alert %}}

## **FAQ**

**この方法はバッチ変換をサポートしていますか？**

はい、Aspose.Slides は複数のスライドを一括で JPG に変換できます。

**変換は SmartArt、チャート、その他の複雑なオブジェクトをサポートしていますか？**

はい、Aspose.Slides は SmartArt、チャート、テーブル、シェイプなどすべてのコンテンツをレンダリングします。ただし、カスタム フォントや欠損フォントを使用した場合、PowerPoint と比べて若干の精度差が生じることがあります。

**処理できるスライド数に制限はありますか？**

Aspose.Slides 自体にはスライド数の厳格な上限はありません。ただし、サイズの大きいプレゼンテーションや高解像度画像を扱う場合、メモリ不足エラーが発生する可能性があります。