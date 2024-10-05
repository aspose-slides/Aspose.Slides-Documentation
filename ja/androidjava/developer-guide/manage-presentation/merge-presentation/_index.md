---
title: プレゼンテーションの統合
type: docs
weight: 40
url: /androidjava/merge-presentation/
keywords: "PowerPoint 統合, PPTX, PPT, PowerPoint 結合, プレゼンテーション 統合, Java"
description: "JavaでPowerPointプレゼンテーションを統合または結合する"
---


{{% alert title="ヒント" color="primary" %}} 

**Asposeの無料オンライン** [Mergerアプリ](https://products.aspose.app/slides/merger)をチェックしてみてください。このアプリを使用すると、同じフォーマット（PPTからPPT、PPTXからPPTXなど）でPowerPointプレゼンテーションを統合したり、異なるフォーマット（PPTからPPTX、PPTXからODPなど）でプレゼンテーションを統合したりできます。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **プレゼンテーションの統合**

1つのプレゼンテーションを別のプレゼンテーションに統合する際、実質的にはそのスライドを1つのプレゼンテーションに結合して1つのファイルを取得することになります。 

{{% alert title="情報" color="info" %}}

ほとんどのプレゼンテーションプログラム（PowerPointやOpenOffice）には、ユーザーがそのようにプレゼンテーションを結合する機能が欠けています。 

しかし、[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)を使用すると、さまざまな方法でプレゼンテーションを統合できます。すべての形状、スタイル、テキスト、書式設定、コメント、アニメーションなどを損失の心配なしに統合できます。

**関連情報**

[スライドのクローン](https://docs.aspose.com/slides/androidjava/clone-slides/)を参照してください。

{{% /alert %}}

### **統合できるもの**

Aspose.Slidesを使用すると、以下を統合できます。

* 完全なプレゼンテーション。プレゼンテーションのすべてのスライドが1つのプレゼンテーションに収まります。
* 特定のスライド。選択したスライドが1つのプレゼンテーションに収まります。
* 1つのフォーマット（PPTからPPT、PPTXからPPTXなど）または異なるフォーマット（PPTからPPTX、PPTXからODPなど）のプレゼンテーションを互いに統合できます。 

{{% alert title="注意" color="warning" %}} 

プレゼンテーションに加えて、Aspose.Slidesは他のファイルを統合することも可能です。

* [画像](https://products.aspose.com/slides/androidjava/merger/image-to-image/)、例えば [JPGからJPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) や [PNGからPNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* 文書、例えば [PDFからPDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) や [HTMLからHTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* そして、[画像からPDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/)や[JPGからPDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/)、または[TIFFからPDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/)などの異なる2つのファイル。

{{% /alert %}}

### **統合オプション**

出力プレゼンテーション内の各スライドがユニークなスタイルを保持するかどうか、あるいは出力プレゼンテーション内のすべてのスライドに特定のスタイルが適用されるかどうかを決定するオプションを適用できます。 

プレゼンテーションを統合するために、Aspose.Slidesでは[AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッド（[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)インターフェースから）を提供しています。プレゼンテーション統合プロセスのパラメータを定義する`AddClone`メソッドの実装がいくつかあります。すべてのPresentationオブジェクトには[Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)コレクションがあるため、スライドを統合したいプレゼンテーションから`AddClone`メソッドを呼び出すことができます。

`AddClone`メソッドは、ソーススライドのクローンである`ISlide`オブジェクトを返します。出力プレゼンテーションのスライドは、単にソースのスライドのコピーです。したがって、ソースプレゼンテーションに影響を与える心配なく、結果のスライドを変更（例えば、スタイルや書式設定オプションやレイアウトを適用する）できます。 

## **プレゼンテーションの統合** 

Aspose.Slidesは、スライドがデフォルトのパラメータでレイアウトとスタイルを保持したまま統合することを可能にする[**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドを提供します。

このJavaコードは、プレゼンテーションを統合する方法を示しています：

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

## **スライドマスターを使用したプレゼンテーションの統合**

Aspose.Slidesは、スライドマスタープレゼンテーションテンプレートを適用しながらスライドを統合することを可能にする[**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)メソッドを提供します。この方法で、必要に応じて出力プレゼンテーション内のスライドのスタイルを変更することができます。

このJavaコードは、前述の操作を示しています：

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

スライドマスターのスライドレイアウトは、自動的に決定されます。適切なレイアウトが決定できない場合は、`AddClone`メソッドの`allowCloneMissingLayout`ブールパラメータがtrueに設定されていると、ソーススライドのレイアウトが使用されます。そうでない場合、[PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException)がスローされます。

{{% /alert %}}

出力プレゼンテーション内のスライドに異なるスライドレイアウトを持たせたい場合は、統合時に[AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)メソッドを使用してください。

## **プレゼンテーションから特定のスライドを統合する**

このJavaコードは、異なるプレゼンテーションから特定のスライドを選択して統合し、1つの出力プレゼンテーションを得る方法を示しています：

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

## **スライドレイアウトを使用したプレゼンテーションの統合**

このJavaコードは、プレゼンテーションからスライドを統合し、好みのスライドレイアウトを適用して1つの出力プレゼンテーションを得る方法を示しています：

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

## **異なるスライドサイズを持つプレゼンテーションの統合**

{{% alert title="注意" color="warning" %}} 

異なるスライドサイズを持つプレゼンテーションを統合することはできません。 

{{% /alert %}}

異なるスライドサイズの2つのプレゼンテーションを統合するには、1つのプレゼンテーションのサイズを別のプレゼンテーションのサイズに合わせてリサイズする必要があります。 

このサンプルコードは、前述の操作を示しています：

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

## **プレゼンテーションセクションへのスライドの統合**

このJavaコードは、特定のスライドをプレゼンテーションのセクションに統合する方法を示しています：

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

Asposeは、[無料のコラージュWebアプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを使用すると、[JPGからJPG](https://products.aspose.app/slides/collage/jpg)またはPNGからPNG画像を統合したり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid)を作成したりできます。 

{{% /alert %}}