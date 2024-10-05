---
title: プレゼンテーションのマージ
type: docs
weight: 40
url: /java/merge-presentation/
keywords: "PowerPointのマージ, PPTX, PPT, PowerPointの結合, プレゼンテーションのマージ, プレゼンテーションの結合, Java"
description: "JavaでPowerPointプレゼンテーションをマージまたは結合する"
---


{{% alert title="ヒント" color="primary" %}} 

**Aspose無料オンライン** [Mergerアプリ](https://products.aspose.app/slides/merger)をチェックしてみてください。これにより、同じ形式のPowerPointプレゼンテーション（PPTからPPT、PPTXからPPTXなど）のマージや、異なる形式のプレゼンテーション（PPTからPPTX、PPTXからODPなど）のマージができます。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **プレゼンテーションのマージ**

1つのプレゼンテーションを別のプレゼンテーションにマージすると、そのスライドを1つのプレゼンテーションにまとめて、1つのファイルを取得することになります。 

{{% alert title="情報" color="info" %}}

ほとんどのプレゼンテーションプログラム（PowerPointまたはOpenOffice）には、そのようにプレゼンテーションを結合するための機能が欠けています。 

しかし、[**Aspose.Slides for Java**](https://products.aspose.com/slides/java/)を使用すると、さまざまな方法でプレゼンテーションをマージできます。すべての形状、スタイル、テキスト、書式、コメント、アニメーションなどを持つプレゼンテーションを、品質やデータの損失を気にすることなくマージできます。 

**参照**

[スライドのクローン](https://docs.aspose.com/slides/java/clone-slides/)。 

{{% /alert %}}

### **マージできるもの**

Aspose.Slidesを使用すると、以下をマージできます。

* 完全なプレゼンテーション。プレゼンテーションのすべてのスライドが1つのプレゼンテーションにまとめられます。
* 特定のスライド。選択されたスライドが1つのプレゼンテーションにまとめられます。
* 同じ形式のプレゼンテーション（PPTからPPT、PPTXからPPTXなど）および異なる形式のプレゼンテーション（PPTからPPTX、PPTXからODPなど）を互いに結合します。

{{% alert title="注意" color="warning" %}} 

プレゼンテーションの他に、Aspose.Slidesを使用すると、以下のファイルをマージできます：

* [画像](https://products.aspose.com/slides/java/merger/image-to-image/)、例えば [JPGからJPG](https://products.aspose.com/slides/java/merger/jpg-to-jpg/)や [PNGからPNG](https://products.aspose.com/slides/java/merger/png-to-png/)
* 文書、例えば [PDFからPDF](https://products.aspose.com/slides/java/merger/pdf-to-pdf/)や [HTMLからHTML](https://products.aspose.com/slides/java/merger/html-to-html/)
* そして、[画像からPDF](https://products.aspose.com/slides/java/merger/image-to-pdf/)や [JPGからPDF](https://products.aspose.com/slides/java/merger/jpg-to-pdf/)や [TIFFからPDF](https://products.aspose.com/slides/java/merger/tiff-to-pdf/)などの異なる2つのファイル。

{{% /alert %}}

### **マージオプション**

次のことを決定するオプションを適用できます：

* 出力プレゼンテーションの各スライドがユニークなスタイルを保持するかどうか
* 出力プレゼンテーションのすべてのスライドに特定のスタイルが使用されるかどうか。 

プレゼンテーションをマージするために、Aspose.Slidesは[AddClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッド（[ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection)インターフェースから）を提供します。`AddClone`メソッドのいくつかの実装がプレゼンテーションマージプロセスのパラメータを定義します。すべてのPresentationオブジェクトには[Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)コレクションがあるため、スライドをマージしたいプレゼンテーションから`AddClone`メソッドを呼び出すことができます。 

`AddClone`メソッドは、ソーススライドのクローンである`ISlide`オブジェクトを返します。出力プレゼンテーションのスライドは、ソースからのスライドの単なるコピーです。したがって、ソースプレゼンテーションに影響を与えることを心配せずに、結果のスライドに変更を加えること（例えば、スタイルや書式オプション、レイアウトを適用する）を行うことができます。 

## **プレゼンテーションをマージする** 

Aspose.Slidesは、スライドのレイアウトやスタイルを保持しながらスライドを結合できる[**AddClone(ISlide)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドを提供します（デフォルトのパラメータ）。 

このJavaコードは、プレゼンテーションをマージする方法を示しています：

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **スライドマスターを使用してプレゼンテーションをマージする**

Aspose.Slidesは、スライドマスター プレゼンテーション テンプレートを適用しながらスライドを結合できる[**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)メソッドを提供します。この方法により、必要に応じて出力プレゼンテーション内のスライドのスタイルを変更できます。 

このJavaコードは、説明された操作を示しています：

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

スライドマスターのスライドレイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`AddClone`メソッドの`allowCloneMissingLayout`ブーリアンパラメータがtrueに設定されていると、ソーススライドのレイアウトが使用されます。そうでない場合は、[PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException)がスローされます。 

{{% /alert %}}

出力プレゼンテーション内のスライドに別のスライドレイアウトを持たせたい場合は、マージ時に[AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)メソッドを使用してください。 

## **プレゼンテーションから特定のスライドをマージする**

このJavaコードは、異なるプレゼンテーションから特定のスライドを選択して結合し、1つの出力プレゼンテーションを取得する方法を示しています：

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **スライドレイアウトを使ってプレゼンテーションをマージする**

このJavaコードは、プレゼンテーションからスライドを結合し、それに希望するスライドレイアウトを適用して1つの出力プレゼンテーションを取得する方法を示しています：

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **異なるスライドサイズのプレゼンテーションをマージする**

{{% alert title="注意" color="warning" %}} 

異なるスライドサイズのプレゼンテーションをマージすることはできません。 

{{% /alert %}}

スライドサイズが異なる2つのプレゼンテーションをマージするには、1つのプレゼンテーションのサイズを他のプレゼンテーションのサイズに合わせてリサイズする必要があります。 

このサンプルコードは、説明された操作を示しています：

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **スライドをプレゼンテーションセクションにマージする**

このJavaコードは、特定のスライドをプレゼンテーションのセクションにマージする方法を示しています：

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

スライドはセクションの最後に追加されます。 

{{% alert title="ヒント" color="primary" %}}

Asposeは[無料のコラージュWebアプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを使用すると、[JPGからJPG](https://products.aspose.app/slides/collage/jpg)やPNGからPNG画像をマージしたり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid)を作成したりすることができます。 

{{% /alert %}}