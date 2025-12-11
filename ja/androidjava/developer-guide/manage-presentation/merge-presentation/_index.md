---
title: Android でプレゼンテーションを効率的にマージ
linktitle: プレゼンテーションのマージ
type: docs
weight: 40
url: /ja/androidjava/merge-presentation/
keywords:
- PowerPoint のマージ
- プレゼンテーションのマージ
- スライドのマージ
- PPT のマージ
- PPTX のマージ
- ODP のマージ
- PowerPoint の結合
- プレゼンテーションの結合
- スライドの結合
- PPT の結合
- PPTX の結合
- ODP の結合
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint (PPT, PPTX) および OpenDocument (ODP) プレゼンテーションを手間なくマージし、ワークフローを効率化します。"
---

{{% alert  title="Tip" color="primary" %}} 

**Aspose 無料オンライン** [Merger app](https://products.aspose.app/slides/merger)。同じ形式（PPT から PPT、PPTX から PPTX など）の PowerPoint プレゼンテーションをマージしたり、異なる形式（PPT から PPTX、PPTX から ODP など）のプレゼンテーションをマージしたりできます。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **プレゼンテーションの結合**

プレゼンテーションをマージすると、実質的にスライドを単一のプレゼンテーションに結合し、1 つのファイルとして取得します。 

{{% alert title="Info" color="info" %}}

ほとんどのプレゼンテーションプログラム（PowerPoint や OpenOffice）には、このようにプレゼンテーションを結合する機能がありません。 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)、しかし、さまざまな方法でプレゼンテーションをマージできます。形状、スタイル、テキスト、書式設定、コメント、アニメーションなど、すべての要素を失うことなくプレゼンテーションをマージできます。

**こちらも参照**

[Clone Slides](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **マージできるもの**

Aspose.Slides を使用すると、次のものをマージできます

* プレゼンテーション全体。すべてのスライドが 1 つのプレゼンテーションにまとめられます
* 特定のスライド。選択したスライドが 1 つのプレゼンテーションにまとめられます
* 同一形式（PPT から PPT、PPTX から PPTX など）および異なる形式（PPT から PPTX、PPTX から ODP など）のプレゼンテーションを相互にマージできます。 

{{% alert title="Note" color="warning" %}} 

プレゼンテーションに加えて、Aspose.Slides は他のファイルもマージできます。

* [画像](https://products.aspose.com/slides/androidjava/merger/image-to-image/)、例えば [JPG to JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) または [PNG to PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* 文書、例えば [PDF to PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) または [HTML to HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* 異なる形式のファイル同士も、例えば [image to PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/) や [JPG to PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) 、[TIFF to PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/) のようにマージできます。

{{% /alert %}}

### **マージオプション**

次の条件を決定するオプションを適用できます。

* 出力プレゼンテーションの各スライドが固有のスタイルを保持するか
* 出力プレゼンテーションのすべてのスライドに特定のスタイルを使用するか 

プレゼンテーションをマージするには、Aspose.Slides は [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッド（[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) インターフェイスから）を提供します。`AddClone` メソッドには、プレゼンテーションのマージ処理パラメータを定義する複数の実装があります。すべての Presentation オブジェクトは [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) コレクションを持っているため、スライドをマージしたいプレゼンテーションから `AddClone` メソッドを呼び出すことができます。

`AddClone` メソッドは `ISlide` オブジェクトを返します。これはソーススライドのクローンです。出力プレゼンテーションのスライドは単にソースのスライドのコピーです。そのため、元のプレゼンテーションに影響を与えることを心配せずに、結果のスライドに変更（例：スタイルや書式設定オプション、レイアウトの適用）を加えることができます。 

## **プレゼンテーションのマージ** 

Aspose.Slides はスライドのレイアウトとスタイルを保持したままスライドを結合できる [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッド（デフォルト パラメータ）を提供します。

この Java コードはプレゼンテーションをマージする方法を示します:
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


## **スライドマスターを使用したプレゼンテーションのマージ**

Aspose.Slides は、スライドマスターのプレゼンテーションテンプレートを適用しながらスライドを結合できる [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを提供します。必要に応じて、出力プレゼンテーションのスライドのスタイルを変更できます。

このコードは Java で上記の操作を示しています:
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


{{% alert title="Note" color="warning" %}} 

スライドマスターのスライドレイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`AddClone` メソッドの `allowCloneMissingLayout` ブールパラメータが true に設定されていれば、ソーススライドのレイアウトが使用されます。そうでなければ、[PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException) がスローされます。

{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを使用したい場合は、マージ時に [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) メソッドを代わりに使用してください。

## **プレゼンテーションから特定のスライドをマージ**

複数のプレゼンテーションから特定のスライドをマージすることは、カスタムスライドデッキを作成するのに便利です。Aspose.Slides for Android via Java を使用すると、必要なスライドだけを選択してインポートできます。API は元のスライドの書式設定、レイアウト、デザインを保持します。

次の Java コードは新しいプレゼンテーションを作成し、他の 2 つのプレゼンテーションからタイトルスライドを追加し、結果をファイルに保存します:
```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```


## **スライドレイアウトを使用したプレゼンテーションのマージ**

この Java コードは、好みのスライドレイアウトを適用しながらプレゼンテーションからスライドを結合し、1 つの出力プレゼンテーションを取得する方法を示します:
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


## **異なるスライドサイズのプレゼンテーションのマージ**

{{% alert title="Note" color="warning" %}} 

異なるスライドサイズのプレゼンテーションはマージできません。

{{% /alert %}}

異なるスライドサイズの 2 つのプレゼンテーションをマージするには、サイズを合わせるためにいずれかのプレゼンテーションのサイズを変更する必要があります。

このサンプルコードは上記の操作を示しています:
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


## **プレゼンテーション セクションへのスライドのマージ**

この Java コードは、プレゼンテーションのセクションに特定のスライドをマージする方法を示します:
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


スライドはセクションの末尾に追加されます。 

{{% alert title="Tip" color="primary" %}}

Aspose は [FREE Collage web app](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG to JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG への画像のマージ、[photo grids](https://products.aspose.app/slides/collage/photo-grid) の作成などができます。 

{{% /alert %}}

## **FAQ**

**プレゼンテーションをマージする際のスライド数に制限はありますか？**

厳密な制限はありません。Aspose.Slides は大きなファイルを処理できますが、パフォーマンスはサイズとシステムリソースに依存します。非常に大きなプレゼンテーションの場合は、64 ビット JVM を使用し、十分なヒープメモリを割り当てることを推奨します。

**埋め込みビデオやオーディオがあるプレゼンテーションをマージできますか？**

はい、Aspose.Slides はスライドに埋め込まれたマルチメディアコンテンツを保持しますが、最終的なプレゼンテーションは大幅に大きくなる可能性があります。

**プレゼンテーションをマージするとフォントは保持されますか？**

はい。ソースプレゼンテーションで使用されたフォントは、システムにインストールされているか、[埋め込まれている](/slides/ja/androidjava/embedded-font/) 場合、出力ファイルに保持されます。