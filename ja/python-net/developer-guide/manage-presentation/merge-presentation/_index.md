---
title: Python でプレゼンテーションを効率的にマージする
linktitle: プレゼンテーションをマージ
type: docs
weight: 40
url: /ja/python-net/merge-presentation/
keywords:
- PowerPoint をマージ
- プレゼンテーションをマージ
- スライドをマージ
- PPT をマージ
- PPTX をマージ
- ODP をマージ
- PowerPoint を結合
- プレゼンテーションを結合
- スライドを結合
- PPT を結合
- PPTX を結合
- ODP を結合
- Python
- Aspose.Slides
- description: "Aspose.Slides for Python via .NET を使用して、PowerPoint (PPT、PPTX) および OpenDocument (ODP) プレゼンテーションを手間なくマージし、ワークフローを効率化します。"
---

{{% alert  title="ヒント" color="primary" %}} 

**Aspose無料オンライン** [マージアプリ](https://products.aspose.app/slides/merger)をチェックしてみるといいでしょう。同じ形式のPowerPointプレゼンテーションを結合（PPTからPPT、PPTXからPPTXなど）したり、異なる形式のプレゼンテーション（PPTからPPTX、PPTXからODPなど）を結合したりすることができます。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **プレゼンテーションの結合**

あるプレゼンテーションを別のプレゼンテーションに結合すると、そのスライドを単一のプレゼンテーションに統合して1つのファイルを取得することになります。 

{{% alert title="情報" color="info" %}}

ほとんどのプレゼンテーションプログラム（PowerPointやOpenOffice）には、そのようにプレゼンテーションを結合する機能が欠けています。 

[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/) は、プレゼンテーションを異なる方法で結合することを可能にします。全ての形状、スタイル、テキスト、フォーマット、コメント、アニメーションなどを失うことなくプレゼンテーションを結合することができます。 

**関連情報**

[スライドのクローン](https://docs.aspose.com/slides/python-net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **結合できるもの**

Aspose.Slidesを使用すると、次のことができます。

* 全体のプレゼンテーション。プレゼンテーションのすべてのスライドが1つのプレゼンテーションに収まります。
* 特定のスライド。選択したスライドが1つのプレゼンテーションに収まります。
* 1つの形式（PPTからPPT、PPTXからPPTXなど）または異なる形式（PPTからPPTX、PPTXからODPなど）のプレゼンテーションを互いに結合します。

{{% alert title="注意" color="warning" %}} 

プレゼンテーションの他に、Aspose.Slidesは他のファイルも結合できます：

* [画像](https://products.aspose.com/slides/python-net/merger/image-to-image/)、例えば [JPGからJPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) や [PNGからPNG](https://products.aspose.com/slides/python-net/merger/png-to-png/)
* 文書、例えば [PDFからPDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) や [HTMLからHTML](https://products.aspose.com/slides/python-net/merger/html-to-html/)
* そして、[画像からPDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/) や [JPGからPDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/) または [TIFFからPDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/)のような2つの異なるファイル。

{{% /alert %}}

### **結合オプション**

出力プレゼンテーションの各スライドがユニークなスタイルを保持するかどうか、または特定のスタイルが出力プレゼンテーションのすべてのスライドに使用されるかどうかを決定するオプションを適用できます。 

プレゼンテーションを結合するために、Aspose.Slidesは [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) メソッド（[ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) インターフェースから）を提供します。 `add_clone` メソッドには、プレゼンテーションの結合プロセスパラメータを定義するためのいくつかの実装があります。各Presentationオブジェクトには、[slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) コレクションがあるため、スライドを結合したいプレゼンテーションから `add_clone` メソッドを呼び出すことができます。 

`add_clone` メソッドは、ソーススライドのクローンである `ISlide` オブジェクトを返します。出力プレゼンテーションのスライドは、単にソースのスライドのコピーです。したがって、ソースプレゼンテーションに影響を与えないように、結果のスライド（例えば、スタイルやフォーマットオプションやレイアウトを適用するなど）を変更できます。 

## **プレゼンテーションの結合** 

Aspose.Slidesは、スライドのレイアウトとスタイルを保持しながらスライドを結合することができる [**AddClone (ISlide)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) メソッドを提供します（デフォルトパラメータ）。 

このPythonコードは、プレゼンテーションを結合する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドマスターを使用したプレゼンテーションの結合**

Aspose.Slidesは、スライドマスター プレゼンテーション テンプレートを適用しながらスライドを結合できる [**add_clone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) メソッドを提供します。この方法を使用すると、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。 

このPythonコードは、説明した操作を示しています：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.masters[0], allow_clone_missing_layout = True)
        pres1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="注意" color="warning" %}} 

スライドマスターのスライドレイアウトは自動的に決定されます。適切なレイアウトを判断できない場合、`add_clone` メソッドの `allowCloneMissingLayout`ブールパラメータがtrueに設定されていると、ソーススライドのレイアウトが使用されます。それ以外の場合は、[PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) がスローされます。 

{{% /alert %}}

出力プレゼンテーションに異なるスライドレイアウトを持たせたい場合は、代わりに [add_clone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) メソッドを使用して結合してください。 

## **プレゼンテーションから特定のスライドを結合する**

このPythonコードは、異なるプレゼンテーションから特定のスライドを選択して結合し、1つの出力プレゼンテーションを得る方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.layout_slides[0])
        pres1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **スライドレイアウトでプレゼンテーションを結合する**

このPythonコードは、プレゼンテーションからスライドを結合し、お好みのスライドレイアウトを適用して1つの出力プレゼンテーションを得る方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.layout_slides[0])
        pres1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **異なるスライドサイズのプレゼンテーションを結合する**

{{% alert title="注意" color="warning" %}} 

異なるスライドサイズのプレゼンテーションを結合することはできません。 

{{% /alert %}}

異なるスライドサイズの2つのプレゼンテーションを結合するには、1つのプレゼンテーションのサイズを変更して、もう一方のプレゼンテーションのサイズに合わせる必要があります。 

このサンプルコードは、説明した操作を示します：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        pres2.slide_size.set_size(pres1.slide_size.size.width, pres1.slide_size.size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **セクションにスライドを結合する**

このPythonコードは、プレゼンテーションのセクションに特定のスライドを結合する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.sections[0])
        pres1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

スライドはセクションの最後に追加されます。 

{{% alert title="ヒント" color="primary" %}}

Asposeは、[無料のコラージュWebアプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを使用すると、[JPGからJPG](https://products.aspose.app/slides/collage/jpg) やPNGからPNGの画像を結合したり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid)を作成したりできます。 

{{% /alert %}}