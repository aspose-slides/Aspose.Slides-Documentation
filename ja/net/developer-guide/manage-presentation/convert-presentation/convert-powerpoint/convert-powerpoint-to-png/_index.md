---
title: C#でPowerPointをPNGに変換
linktitle: PowerPointをPNGに変換
type: docs
weight: 30
url: /ja/net/convert-powerpoint-to-png/
keywords:
- PowerPoint を PNG に変換
- ppt を PNG に変換
- pptx を PNG に変換
- odp を PNG に変換
- PowerPoint を PNG に変換
- PPT を PNG に変換
- PPTX を PNG に変換
- ODP を PNG に変換
- C#
- Csharp
- Aspose.Slides for .NET
description: C#でPowerPointプレゼンテーションをPNGに変換します。C#でPPTをPNGに変換します。C#でPPTXをPNGに変換します。C#でODPをPNGに変換します。
---

## **概要**

この記事では、C# を使用して PowerPoint プレゼンテーションを PNG 形式に変換する方法を説明します。以下のトピックを取り上げます。

- [C# で PowerPoint を PNG に変換](#convert-powerpoint-to-png)
- [C# で PPT を PNG に変換](#convert-powerpoint-to-png)
- [C# で PPTX を PNG に変換](#convert-powerpoint-to-png)
- [C# で ODP を PNG に変換](#convert-powerpoint-to-png)
- [C# で PowerPoint スライドを画像に変換](#convert-powerpoint-to-png)

## **C# PowerPoint を PNG に変換**

PowerPoint を PNG に変換する C# のサンプルコードについては、下記のセクション、すなわち [PowerPoint を PNG に変換](#convert-powerpoint-to-png) を参照してください。コードは PPT、PPTX、ODP などのさまざまな形式を Presentation オブジェクトで読み込み、スライドのサムネイルを PNG 形式で保存できます。他の PowerPoint から画像への変換（JPG、BMP、TIFF、SVG など）については、以下の記事をご覧ください。

- [C# PowerPoint を JPG に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint を BMP に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint を TIFF に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint を SVG に変換](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **PowerPoint を PNG に変換する概要**

PNG（Portable Network Graphics）形式は JPEG（Joint Photographic Experts Group）ほど一般的ではありませんが、依然として非常に人気があります。

**使用例:** 画像が複雑でサイズが問題とならない場合、PNG は JPEG よりも優れた画像形式です。

{{% alert title="Tip" color="primary" %}} Aspose の無料 **PowerPoint to PNG コンバータ** をご確認ください: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。このページで説明したプロセスの実装例です。 {{% /alert %}}

## **PowerPoint を PNG に変換**

以下の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスをインスタンス化します。
2. [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) インターフェイス下の [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) コレクションからスライドオブジェクトを取得します。
3. [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) メソッドを使用して各スライドのサムネイルを取得します。
4. [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) メソッドを使用してスライドのサムネイルを PNG 形式で保存します。

この C# コードは、PowerPoint プレゼンテーションを PNG に変換する方法を示しています。Presentation オブジェクトは PPT、PPTX、ODP などを読み込むことができ、プレゼンテーション内の各スライドを PNG 形式または他の画像形式に変換します。
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

特定のスケールで PNG ファイルを取得したい場合、結果のサムネイルのサイズを決定する `desiredX` と `desiredY` の値を設定できます。

この C# のコードは上記の操作を示しています：
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

特定のサイズで PNG ファイルを取得したい場合、`imageSize` の `width` と `height` 引数に希望の値を渡すことができます。

このコードは、画像のサイズを指定して PowerPoint を PNG に変換する方法を示しています：
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

**特定のシェイプ（例: グラフや画像）だけをエクスポートし、スライド全体をエクスポートしないにはどうすればよいですか？**  
Aspose.Slides は [個々のシェイプのサムネイル生成](/slides/ja/net/create-shape-thumbnails/) をサポートしており、シェイプを PNG 画像としてレンダリングできます。

**サーバー上での並列変換はサポートされていますか？**  
はい、ただしスレッド間で単一の Presentation インスタンスを共有しないでください。スレッドまたはプロセスごとに別々のインスタンスを使用してください。[共有しない](/slides/ja/net/multithreading/)。

**PNG にエクスポートする際の試用版の制限は何ですか？**  
評価モードでは出力画像に透かしが追加され、ライセンスが適用されるまで [他の制限](/slides/ja/net/licensing/) が適用されます。