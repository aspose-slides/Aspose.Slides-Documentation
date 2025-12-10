---
title: .NET で PowerPoint スライドを PNG に変換
linktitle: PowerPoint を PNG に変換
type: docs
weight: 30
url: /ja/net/convert-powerpoint-to-png/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を PNG に変換
- プレゼンテーションを PNG に変換
- スライドを PNG に変換
- PPT を PNG に変換
- PPTX を PNG に変換
- PPT を PNG として保存
- PPTX を PNG として保存
- PPT を PNG にエクスポート
- PPTX を PNG にエクスポート
- .NET
- C#
- Aspose.Slides
description: Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。
---

## **概要**

この記事では、C# を使用して PowerPoint プレゼンテーションを PNG 形式に変換する方法を説明します。以下のトピックをカバーしています。

- [C# で PowerPoint を PNG に変換](#convert-powerpoint-to-png)
- [C# で PPT を PNG に変換](#convert-powerpoint-to-png)
- [C# で PPTX を PNG に変換](#convert-powerpoint-to-png)
- [C# で ODP を PNG に変換](#convert-powerpoint-to-png)
- [C# で PowerPoint スライドを画像に変換](#convert-powerpoint-to-png)

## **.NET での PowerPoint から PNG への変換**

C# のサンプルコードで PowerPoint を PNG に変換する方法については、以下のセクション [PowerPoint を PNG に変換](#convert-powerpoint-to-png) を参照してください。コードは PPT、PPTX、ODP など複数の形式を Presentation オブジェクトで読み込み、スライドのサムネイルを PNG 形式で保存できます。他の類似した画像形式への変換（JPG、BMP、TIFF、SVG）については、以下の記事で解説しています。

- [C# PowerPoint を JPG に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint を BMP に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint を TIFF に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint を SVG に変換](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **PowerPoint を PNG に変換することについて**

PNG（Portable Network Graphics）形式は JPEG（Joint Photographic Experts Group）ほど一般的ではありませんが、依然として非常に広く利用されています。

**使用例:** 複雑な画像でサイズが問題とならない場合、PNG は JPEG よりも適した画像形式です。

{{% alert title="Tip" color="primary" %}} Aspose の無料 **PowerPoint から PNG へのコンバータ** をチェックしてください: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) および [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらは本ページで説明したプロセスの実装例です。 {{% /alert %}}

## **PowerPoint を PNG に変換**

以下の手順を実行します:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) インターフェイスを通じて、[Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) コレクションからスライド オブジェクトを取得します。
3. 各スライドのサムネイルを取得するために、[ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) メソッドを使用します。
4. スライドのサムネイルを PNG 形式で保存するために、[IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) メソッドを使用します。

この C# コードは、PowerPoint プレゼンテーションを PNG に変換する方法を示しています。Presentation オブジェクトは PPT、PPTX、ODP などを読み込み、プレゼンテーション内の各スライドを PNG 形式または他の画像形式に変換します。
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```


## **カスタム寸法で PowerPoint を PNG に変換**

特定のスケールで PNG ファイルを取得したい場合は、`desiredX` と `desiredY` の値を設定します。これらは生成されるサムネイルの寸法を決定します。

以下の C# コードは上記の操作を示しています:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```


## **カスタムサイズで PowerPoint を PNG に変換**

特定のサイズで PNG ファイルを取得したい場合は、`imageSize` に対して好みの `width` と `height` 引数を渡すことができます。

以下のコードは、画像サイズを指定しながら PowerPoint を PNG に変換する方法を示しています: 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```


## **FAQ**

**特定のシェイプ（例: グラフや画像）だけをエクスポートしたい場合、スライド全体ではなくシェイプだけを PNG に出力できますか？**

Aspose.Slides は [個別シェイプのサムネイル生成](/slides/ja/net/create-shape-thumbnails/) をサポートしており、シェイプを PNG 画像としてレンダリングできます。

**サーバー上で並列変換はサポートされていますか？**

はい、ただしスレッド間で単一の Presentation インスタンスを共有しないでください。スレッドまたはプロセスごとに別々のインスタンスを使用します。([共有しない](/slides/ja/net/multithreading/))

**PNG エクスポート時の評価版の制限は何ですか？**

評価モードでは出力画像に透かしが追加され、ライセンスが適用されるまで [その他の制限](/slides/ja/net/licensing/) が適用されます。