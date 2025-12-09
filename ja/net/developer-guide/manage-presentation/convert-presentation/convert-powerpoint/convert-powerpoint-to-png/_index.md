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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。"
---

## **概要**

この記事では、C# を使用して PowerPoint プレゼンテーションを PNG 形式に変換する方法を説明します。以下のトピックを取り上げます。

- [C# で PowerPoint を PNG に変換](#convert-powerpoint-to-png)
- [C# で PPT を PNG に変換](#convert-powerpoint-to-png)
- [C# で PPTX を PNG に変換](#convert-powerpoint-to-png)
- [C# で ODP を PNG に変換](#convert-powerpoint-to-png)
- [C# で PowerPoint スライドを画像に変換](#convert-powerpoint-to-png)

## **C# PowerPoint を PNG に変換**

PowerPoint を PNG に変換する C# のサンプルコードについては、以下のセクション、つまり [Convert PowerPoint to PNG](#convert-powerpoint-to-png) を参照してください。コードは PPT、PPTX、ODP などのさまざまな形式を Presentation オブジェクトで読み込み、スライドのサムネイルを PNG 形式で保存できます。JPG、BMP、TIFF、SVG など、同様の PowerPoint から画像への変換については、以下の記事で説明しています。

- [C# PowerPoint を JPG に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint を BMP に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint を TIFF に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint を SVG に変換](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **PowerPoint を PNG に変換する概要**

PNG (Portable Network Graphics) 形式は JPEG (Joint Photographic Experts Group) ほど一般的ではありませんが、依然として非常に人気があります。

**使用例:** 複雑な画像でサイズが問題とならない場合、PNG は JPEG よりも優れた画像形式です。

{{% alert title="Tip" color="primary" %}}無料の Aspose **PowerPoint to PNG コンバータ** を確認したいかもしれません: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) および [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。これらはこのページで説明したプロセスの実際の実装です。{{% /alert %}}

## **PowerPoint を PNG に変換**

以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) インターフェイスの下にある [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) コレクションからスライドオブジェクトを取得します。
3. 各スライドのサムネイルを取得するために [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) メソッドを使用します。
4. スライドのサムネイルを PNG 形式で保存するために [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) メソッドを使用します。

この C# コードは PowerPoint プレゼンテーションを PNG に変換する方法を示しています。Presentation オブジェクトは PPT、PPTX、ODP などを読み込むことができ、プレゼンテーション内の各スライドは PNG 形式または他の画像形式に変換されます。
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

この C# のコードは上述の操作を示しています：
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

特定のサイズで PNG ファイルを取得したい場合は、`imageSize` 用に希望する `width` と `height` の引数を渡すことができます。

このコードは、画像のサイズを指定しながら PowerPoint を PNG に変換する方法を示しています：
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


## **よくある質問**

**スライド全体ではなく、特定のシェイプ（例: チャートや画像）だけをエクスポートするにはどうすればよいですか？**  
Aspose.Slides は [個々のシェイプのサムネイル生成](/slides/ja/net/create-shape-thumbnails/) をサポートしており、シェイプを PNG 画像としてレンダリングできます。

**サーバー上での並列変換はサポートされていますか？**  
はい、ただしスレッド間で単一のプレゼンテーション インスタンスを [共有しない](/slides/ja/net/multithreading/) でください。スレッドまたはプロセスごとに別々のインスタンスを使用します。

**PNG にエクスポートする際の体験版の制限は何ですか？**  
評価モードでは出力画像に透かしが追加され、ライセンスが適用されるまで [その他の制限](/slides/ja/net/licensing/) が適用されます。