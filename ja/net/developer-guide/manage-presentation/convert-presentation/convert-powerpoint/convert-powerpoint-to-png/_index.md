---
title: PowerPoint スライドを .NET で PNG に変換
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。"
---

## **概要**

この記事では、C# を使用して PowerPoint プレゼンテーションを PNG 形式に変換する方法を説明します。以下のトピックを取り上げます。

- [PowerPoint を PNG に変換（C#）](#convert-powerpoint-to-png)
- [PPT を PNG に変換（C#）](#convert-powerpoint-to-png)
- [PPTX を PNG に変換（C#）](#convert-powerpoint-to-png)
- [ODP を PNG に変換（C#）](#convert-powerpoint-to-png)
- [PowerPoint スライドを画像に変換（C#）](#convert-powerpoint-to-png)

## **C# PowerPoint to PNG**

C# のサンプルコードで PowerPoint を PNG に変換する方法は、以下のセクション「[PowerPoint を PNG に変換](#convert-powerpoint-to-png)」をご覧ください。コードは PPT、PPTX、ODP などの形式を Presentation オブジェクトで読み込み、スライドのサムネイルを PNG 形式で保存します。JPG、BMP、TIFF、SVG など、同様の画像形式への変換については、以下の記事で紹介しています。

- [C# PowerPoint to JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint to BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint to TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint to SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **PowerPoint を PNG に変換する概要**

PNG（Portable Network Graphics）形式は JPEG（Joint Photographic Experts Group）ほど一般的ではありませんが、依然として広く使用されています。

**使用例:** 複雑な画像でサイズが問題とならない場合、PNG は JPEG より適した画像形式です。

{{% alert title="Tip" color="primary" %}}Aspose が提供する無料の **PowerPoint to PNG コンバータ** を試してみてください: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらは本ページで説明したプロセスの実装例です。{{% /alert %}}

## **PowerPoint を PNG に変換**

以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを生成します。  
2. [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) インターフェイスの下にある [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) コレクションからスライドオブジェクトを取得します。  
3. 各スライドのサムネイルを取得するために [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) メソッドを使用します。  
4. [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) メソッドでスライドのサムネイルを PNG 形式で保存します。  

この C# コードは、PowerPoint プレゼンテーションを PNG に変換する方法を示しています。Presentation オブジェクトは PPT、PPTX、ODP などを読み込み、プレゼンテーション内の各スライドを PNG 形式や他の画像形式に変換します。
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

特定のスケールで PNG ファイルを取得したい場合は、結果のサムネイルの寸法を決定する `desiredX` と `desiredY` の値を設定できます。

以下の C# コードが上記操作を示しています:
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

特定のサイズで PNG ファイルを取得したい場合は、`imageSize` に対して希望の `width` と `height` を渡します。

以下のコードは、画像サイズを指定して PowerPoint を PNG に変換する方法を示しています:
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

**特定の図形（例: グラフや画像）だけをエクスポートしたい場合、スライド全体ではなくどうすればよいですか？**

Aspose.Slides は [個々の図形のサムネイル生成](/slides/ja/net/create-shape-thumbnails/) をサポートしており、図形を PNG 画像としてレンダリングできます。

**サーバー上で並列変換はサポートされていますか？**

はい、ただしスレッド間で単一の Presentation インスタンスを共有しないでください。スレッドまたはプロセスごとに別々のインスタンスを使用します。

**PNG にエクスポートする際の評価版の制限は何ですか？**

評価モードでは出力画像に透かしが追加され、ライセンスが適用されるまで [その他の制限](/slides/ja/net/licensing/) が適用されます。