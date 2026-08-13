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
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を実現します。"
---
## **概要**

本記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションを PNG 画像に変換する方法を説明します。PPT、PPTX、ODP などの形式のプレゼンテーション ファイルの読み込み、スライドを画像としてレンダリング、そして結果を PNG 形式で保存する方法を示します。

また、スケール値を設定したり、希望する幅と高さを指定したりすることで、生成された PNG 画像をカスタマイズする方法も示しています。

## **PowerPoint を PNG に変換**

次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [ISlide](https://reference.aspose.com/slides/ja/net/aspose.slides/islide) インターフェイスの下にある [Presentation.Slides](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/properties/slides) コレクションからスライド オブジェクトを取得します。
3. 必要なスケールで各スライドをレンダリングするには、[ISlide.GetImage(float, float)](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/getimage/) メソッドを使用します。
4. スライドのサムネイルを PNG 形式で保存するには、[IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.ipresentation/save/methods/5) メソッドを使用します。

この C# コードは、PowerPoint プレゼンテーションを PNG に変換する方法を示しています。Presentation オブジェクトは PPT、PPTX、ODP などを読み込むことができ、プレゼンテーション オブジェクト内の各スライドは PNG 形式または他の画像形式に変換されます。

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**注意:** スケール引数 `1f, 1f` は各スライドをフルサイズでレンダリングするため、720×540 pt のスライドは 720×540 px の画像になります。パラメータなしの [GetImage()](https://reference.aspose.com/slides/ja/net/aspose.slides/islide/getimage/) オーバーロードは、代わりにはるかに小さいプレビューサムネイルを返します。
{{% /alert %}} 

## **カスタム寸法で PowerPoint を PNG に変換**

特定のスケールで PNG ファイルを取得したい場合は、結果のサムネイルの寸法を決定する `desiredX` と `desiredY` の値を設定できます。

この C# のコードは、上記の操作を示しています。

```c#
using Aspose.Slides;

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

特定のサイズで PNG ファイルを取得したい場合は、`imageSize` 用に希望する `width` と `height` の引数を渡すことができます。

このコードは、画像のサイズを指定しながら PowerPoint を PNG に変換する方法を示しています。

```c#
using System.Drawing;
using Aspose.Slides;

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

## **よくある質問**

### スライド全体ではなく、特定の図形（例: チャートや画像）だけをエクスポートするにはどうすればよいですか？

Aspose.Slides は、[個々の図形のサムネイル生成](/slides/ja/net/create-shape-thumbnails/) をサポートしており、図形を PNG 画像としてレンダリングできます。

### サーバーでの並列変換はサポートされていますか？

はい、ただし、スレッド間で単一の Presentation インスタンスを共有しないでください。[共有しない](/slides/ja/net/multithreading/)ことが必要です。スレッドまたはプロセスごとに別々のインスタンスを使用してください。

### PNG へのエクスポート時のトライアル版の制限は何ですか？

評価モードでは、出力画像に透かしが追加され、ライセンスが適用されるまで [その他の制限](/slides/ja/net/licensing/) が適用されます。