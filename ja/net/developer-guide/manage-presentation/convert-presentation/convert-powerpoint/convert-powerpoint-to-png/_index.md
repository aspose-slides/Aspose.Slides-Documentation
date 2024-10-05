---
title: PowerPointをC#でPNGに変換
linktitle: PowerPointをPNGに変換
type: docs
weight: 30
url: /net/convert-powerpoint-to-png/
keywords:
- PowerPoint to png
- ppt to png
- pptx to png
- odp to png
- PowerPoint to PNG
- PPT to PNG
- PPTX to PNG
- ODP to PNG
- C#
- Csharp
- Aspose.Slides for .NET
description: C#でPowerPointプレゼンテーションをPNGに変換します。C#でPPTをPNGに変換します。C#でPPTXをPNGに変換します。C#でODPをPNGに変換します。
---

## **概要**

この記事では、C#を使用してPowerPointプレゼンテーションをPNG形式に変換する方法を説明します。以下のトピックをカバーしています。

- [C#でPowerPointをPNGに変換](#convert-powerpoint-to-png)
- [C#でPPTをPNGに変換](#convert-powerpoint-to-png)
- [C#でPPTXをPNGに変換](#convert-powerpoint-to-png)
- [C#でODPをPNGに変換](#convert-powerpoint-to-png)
- [C#でPowerPointスライドを画像に変換](#convert-powerpoint-to-png)

## **C# PowerPointをPNGに変換**

PowerPointをPNGに変換するためのC#サンプルコードについては、以下のセクション、つまり[C#でPowerPointをPNGに変換](#convert-powerpoint-to-png)を参照してください。このコードは、PresentationオブジェクトにPPT、PPTX、ODPなどの形式をロードし、スライドのサムネイルをPNG形式で保存します。他のPowerPointから画像への変換については、JPG、BMP、TIFF、SVGなど、これらの記事で説明しています。

- [C# PowerPointをJPGに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPointをBMPに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPointをTIFFに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPointをSVGに変換](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **PowerPointをPNGに変換するについて**

PNG（Portable Network Graphics）形式はJPEG（Joint Photographic Experts Group）ほど一般的ではありませんが、それでも非常に人気です。

**使用例:** 複雑な画像があり、サイズが問題でない場合は、PNGはJPEGよりも優れた画像形式です。

{{% alert title="ヒント" color="primary" %}} Asposeの無料**PowerPoint to PNGコンバーター**をチェックしたいかもしれません: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png)および[PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらは、このページで説明されているプロセスのライブ実装です。 {{% /alert %}}

## **PowerPointをPNGに変換する**

これらの手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスをインスタンス化します。
2. [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)インターフェイスの下にある[Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)コレクションからスライドオブジェクトを取得します。
3. [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/)メソッドを使用して、各スライドのサムネイルを取得します。
4. [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5)メソッドを使用して、スライドのサムネイルをPNG形式で保存します。

このC#コードは、PowerPointプレゼンテーションをPNGに変換する方法を示しています。PresentationオブジェクトはPPT、PPTX、ODPなどをロードでき、プレゼンテーションオブジェクト内の各スライドはPNG形式または他の画像形式に変換されます。

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

## **カスタム寸法でPowerPointをPNGに変換する**

特定のスケールに合わせたPNGファイルを取得したい場合は、結果のサムネイルの寸法を決定する`desiredX`および`desiredY`の値を設定できます。

このC#のコードは、説明された操作を示しています：

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

## **カスタムサイズでPowerPointをPNGに変換する**

特定のサイズに合わせたPNGファイルを取得したい場合は、`imageSize`のために希望する`width`および`height`引数を渡すことができます。

このコードは、画像のサイズを指定してPowerPointをPNGに変換する方法を示しています：

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