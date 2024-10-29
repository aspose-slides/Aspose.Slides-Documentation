---
title: C#を使用してPowerPointプレゼンテーションPPT、PPTXを統合する
linktitle: プレゼンテーションの統合
type: docs
weight: 40
url: /ja/net/merge-presentation/
keywords: "PowerPointの統合, PPTX, PPT, PowerPointの結合, プレゼンテーションの統合, C#, Csharp, .NET"
description: "C#または.NETでPowerPointプレゼンテーションを統合または結合します"
---

{{% alert  title="ヒント" color="primary" %}} 

**Asposeの無料オンライン** [Mergerアプリ](https://products.aspose.app/slides/merger)をチェックしてみてください。同じ形式のPowerPointプレゼンテーションを統合すること（PPTからPPT、PPTXからPPTXなど）や、異なる形式のプレゼンテーションを統合すること（PPTからPPTX、PPTXからODPなど）が可能です。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **プレゼンテーションの統合**

[プレゼンテーションを別のプレゼンテーションに統合する](https://products.aspose.com/slides/net/merger/ppt/)際には、実際にスライドを単一のプレゼンテーションにまとめて1つのファイルを取得します。 

{{% alert title="情報" color="info" %}}

ほとんどのプレゼンテーションプログラム（PowerPointまたはOpenOffice）には、そのようにプレゼンテーションを組み合わせる機能が不足しています。 

しかし、[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/)を使用すれば、異なる方法でプレゼンテーションを統合できます。すべての図形、スタイル、テキスト、書式設定、コメント、アニメーションなどを気にせず、品質やデータの損失を心配することなく、プレゼンテーションを統合できます。 

**関連情報**

[スライドの複製](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **統合できるもの**

Aspose.Slidesを使用すると、次のことができます 

* プレゼンテーション全体。すべてのスライドが1つのプレゼンテーションにまとめられます
* 特定のスライド。選択したスライドが1つのプレゼンテーションにまとめられます
* 同じ形式のプレゼンテーション（PPTからPPT、PPTXからPPTXなど）や異なる形式のプレゼンテーション（PPTからPPTX、PPTXからODPなど）を互いに統合します。 

{{% alert title="注意" color="warning" %}} 

プレゼンテーションの他に、Aspose.Slidesを使用すると、他のファイルも統合できます：

* [画像](https://products.aspose.com/slides/net/merger/image-to-image/)、たとえば [JPGからJPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/)や [PNGからPNG](https://products.aspose.com/slides/net/merger/png-to-png/) 
* ドキュメント、たとえば [PDFからPDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/)や [HTMLからHTML](https://products.aspose.com/slides/net/merger/html-to-html/) 
* そして、[画像からPDF](https://products.aspose.com/slides/net/merger/image-to-pdf/)や [JPGからPDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/)、または [TIFFからPDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/)など、2つの異なるファイルも統合できます。

{{% /alert %}}

### **統合オプション**

出力プレゼンテーション内の各スライドがユニークなスタイルを保持するかどうか、または出力プレゼンテーション内のすべてのスライドに特定のスタイルを使用するかどうかを決定するオプションを適用できます。 

プレゼンテーションを統合するために、Aspose.Slidesは[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)メソッドを提供しています（[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)インターフェースから）。プレゼンテーションの統合プロセスのパラメータを定義するいくつかの実装の`AddClone`メソッドがあります。各プレゼンテーションオブジェクトには[Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)コレクションがあるため、スライドを統合したいプレゼンテーションから`AddClone`メソッドを呼び出すことができます。 

`AddClone`メソッドは、ソーススライドのクローンである`ISlide`オブジェクトを返します。出力プレゼンテーションのスライドは、ソースのスライドの単なるコピーです。したがって、ソースプレゼンテーションに影響を与えることを心配することなく、結果のスライドを変更（たとえば、スタイルや書式設定オプションやレイアウトを適用する）できます。 

## **プレゼンテーションを統合する** 

Aspose.Slidesは、スライドのレイアウトとスタイルを保持しながらスライドを統合できる[**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)メソッドを提供します（デフォルトのパラメータ）。 

このC#コードは、プレゼンテーションを統合する方法を示しています：

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **スライドマスターを使用したプレゼンテーションの統合**

Aspose.Slidesは、スライドマスタープレゼンテーションテンプレートを適用しながらスライドを統合できる[**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2)メソッドを提供します。この方法では、必要に応じて出力プレゼンテーション内のスライドスタイルを変更できます。 

このC#コードは、説明された操作を示しています：

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="注意" color="warning" %}} 

スライドマスターのスライドレイアウトは自動的に決定されます。適切なレイアウトを決定できない場合、`AddClone`メソッドの`allowCloneMissingLayout`ブールパラメータがtrueに設定されている場合、ソーススライドのレイアウトが使用されます。それ以外の場合、[PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception)がスローされます。 

{{% /alert %}}

出力プレゼンテーション内のスライドに異なるスライドレイアウトを持たせたい場合は、統合時に代わりに[AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1)メソッドを使用してください。 

## **プレゼンテーションから特定のスライドを統合する**

このC#コードは、異なるプレゼンテーションから特定のスライドを選択し、1つの出力プレゼンテーションとして結合する方法を示しています：

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **スライドレイアウトを適用してプレゼンテーションを統合する**

このC#コードは、プレゼンテーションからスライドを結合し、お好みのスライドレイアウトを適用して1つの出力プレゼンテーションを取得する方法を示しています：

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **異なるスライドサイズを持つプレゼンテーションを統合する**

{{% alert title="注意" color="warning" %}} 

異なるスライドサイズを持つプレゼンテーションを統合することはできません。 

{{% /alert %}}

異なるスライドサイズを持つ2つのプレゼンテーションを統合するには、1つのプレゼンテーションのサイズを変更して、もう1つのプレゼンテーションのサイズと一致させる必要があります。 

このサンプルコードは、説明された操作を示しています：

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **プレゼンテーションセクションにスライドを統合する**

このC#コードは、特定のスライドをプレゼンテーション内のセクションに統合する方法を示しています：

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

スライドはセクションの最後に追加されます。 

{{% alert title="ヒント" color="primary" %}}

Asposeは[無料のコラージュウェブアプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを使用して、[JPGからJPG](https://products.aspose.app/slides/collage/jpg)やPNGからPNG画像を統合したり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid)を作成したりできます。 

{{% /alert %}}