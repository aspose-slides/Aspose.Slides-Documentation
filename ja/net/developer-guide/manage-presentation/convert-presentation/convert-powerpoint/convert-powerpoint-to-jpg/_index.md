---
title: PPT と PPTX を .NET で JPG に変換する
linktitle: PowerPoint から JPG へ
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
description: "Aspose.Slides for .NET を使用し、C# で高速かつ信頼性の高いコード例を用いて、PowerPoint（PPT、PPTX）のスライドを高品質な JPG 画像に変換します。"
---
## **はじめに**

PowerPoint および OpenDocument プレゼンテーションを JPG 画像に変換すると、スライドの共有、パフォーマンスの最適化、Web サイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides for .NET を使用すると、PPTX、PPT、ODP ファイルを高品質な JPEG 画像に変換できます。本ガイドでは、さまざまな変換方法を説明します。

これらの機能を使用すれば、独自のプレゼンテーション ビューアを実装したり、各スライドのサムネイルを作成したりするのが簡単です。スライドのコピーを防止したり、読み取り専用モードでプレゼンテーションをデモしたりしたい場合に便利です。Aspose.Slides を使用すると、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

## **プレゼンテーション スライドを JPG 画像に変換する**

PPT、PPTX、または ODP ファイルを JPG に変換する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [Presentation.Slides](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/properties/slides) コレクションから [ISlide](https://reference.aspose.com/slides/ja/net/aspose.slides/islide) 型のスライド オブジェクトを取得します。
3. [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/getimage/#getimage_5) メソッドを使用してスライドの画像を作成します。
4. 画像オブジェクトの [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/save/#save_3) メソッドを呼び出します。出力ファイル名と画像フォーマットを引数として渡します。

{{% alert color="info" %}} 
**注:** PPT、PPTX、または ODP から JPG への変換は、Aspose.Slides .NET API の他の形式への変換とは異なります。他の形式の場合、通常は [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/save/#save_5) メソッドを使用します。ただし、JPG 変換の場合は、[IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/save/#save_3) メソッドを使用する必要があります。
{{% /alert %}} 

```c#
using Aspose.Slides;

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

結果となる JPG 画像のサイズを変更するには、[ISlide.GetImage(Size)](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/getimage/#getimage_6) メソッドにサイズを渡します。これにより、特定の幅と高さの画像を生成でき、解像度やアスペクト比の要件を満たすことができます。この柔軟性は、Web アプリケーション、レポート、ドキュメント向けに正確な画像サイズが必要な場合に特に有用です。

```c#
using System.Drawing;
using Aspose.Slides;

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

## **画像としてスライドを保存する際にコメントを描画する**

Aspose.Slides for .NET は、スライドを JPG 画像に変換する際にプレゼンテーションのコメントを描画できる機能を提供します。この機能は、PowerPoint プレゼンテーションに共同作業者が追加した注釈、フィードバック、ディスカッションを保持したい場合に特に便利です。このオプションを有効にすると、生成された画像にコメントが表示され、元のプレゼンテーション ファイルを開かずにフィードバックを確認・共有できます。

たとえば、コメントが含まれるスライドを持つプレゼンテーション ファイル「sample.pptx」があるとします。

![コメント付きスライド](slide_with_comments.png)

次の C# コードは、コメントを保持しながらスライドを JPG 画像に変換します:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // スライドのコメント用にオプションを設定します。
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

PPT、PPTX、または ODP を画像に変換する他のオプションを参照してください。

- [PowerPoint を GIF に変換](/slides/ja/net/convert-powerpoint-to-animated-gif/)
- [PowerPoint を PNG に変換](/slides/ja/net/convert-powerpoint-to-png/)
- [PowerPoint を TIFF に変換](/slides/ja/net/convert-powerpoint-to-tiff/)
- [PowerPoint を SVG に変換](/slides/ja/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
Aspose.Slides が PowerPoint を JPG 画像に変換する方法を確認するには、次の無料オンライン コンバータを試してください: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/ja/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/ja/conversion/ppt-to-jpg)。
{{% /alert %}} 

![無料オンライン PPTX to JPG コンバータ](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose は、[無料の Collage Web アプリ](https://products.aspose.app/slides/ja/collage) を提供しています。このオンライン サービスを使用すると、[JPG to JPG](https://products.aspose.app/slides/ja/collage/jpg) や PNG to PNG 画像のマージ、[フォト グリッド](https://products.aspose.app/slides/ja/collage/photo-grid) の作成などが可能です。

本稿で説明したのと同じ原則を使用して、画像を別の形式に変換できます。詳しくは次のページをご覧ください: 変換 [image to JPG](https://products.aspose.com/slides/ja/net/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/ja/net/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/ja/net/conversion/jpg-to-png/)、変換 [PNG to JPG](https://products.aspose.com/slides/ja/net/conversion/png-to-jpg/); 変換 [PNG to SVG](https://products.aspose.com/slides/ja/net/conversion/png-to-svg/)、変換 [SVG to PNG](https://products.aspose.com/slides/ja/net/conversion/svg-to-png/)。
{{% /alert %}}

## **FAQ**

### この方法はバッチ変換をサポートしていますか？

はい、Aspose.Slides は複数のスライドを一括で JPG に変換するバッチ変換をサポートしています。

### 変換は SmartArt、チャート、その他の複雑なオブジェクトをサポートしていますか？

はい、Aspose.Slides は SmartArt、チャート、テーブル、シェイプなどすべてのコンテンツを描画します。ただし、カスタムフォントや欠落フォントを使用した場合、描画精度が PowerPoint と若干異なることがあります。

### 処理できるスライド数に制限はありますか？

Aspose.Slides 自体にはスライド数に厳密な制限はありません。ただし、大規模なプレゼンテーションや高解像度画像を扱う際に、メモリ不足エラーが発生する可能性があります。