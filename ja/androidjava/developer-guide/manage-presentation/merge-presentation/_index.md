---
title: Android で効率的にプレゼンテーションを結合
linktitle: プレゼンテーションの結合
type: docs
weight: 40
url: /ja/androidjava/merge-presentation/
keywords:
- PowerPoint の結合
- プレゼンテーションの結合
- スライドの結合
- PPT の結合
- PPTX の結合
- ODP の結合
- PowerPoint の統合
- プレゼンテーションの統合
- スライドの統合
- PPT の統合
- PPTX の統合
- ODP の統合
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint（PPT、PPTX）および OpenDocument（ODP）プレゼンテーションを手間なく結合し、作業フローを効率化します。"
---

{{% alert  title="Tip" color="primary" %}} 

**Aspose 無料オンライン** [Merger アプリ](https://products.aspose.app/slides/merger). PowerPoint プレゼンテーションを同じ形式（PPT から PPT、PPTX から PPTX など）で結合したり、異なる形式（PPT から PPTX、PPTX から ODP など）で結合することができます。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **プレゼンテーションの結合**

プレゼンテーションを別のプレゼンテーションに結合すると、実質的にスライドを単一のプレゼンテーションにまとめて 1 つのファイルを作成することになります。 

{{% alert title="Info" color="info" %}}

多くのプレゼンテーションプログラム（PowerPoint や OpenOffice）には、ユーザーがこのようにプレゼンテーションを結合できる機能がありません。 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)、ただし、さまざまな方法でプレゼンテーションを結合できます。すべての形状、スタイル、テキスト、書式設定、コメント、アニメーションなどを失うことなく、プレゼンテーションを結合できます。

**こちらも参照**

[スライドのクローン](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **結合できるもの**

Aspose.Slides を使用すると、次のものを結合できます  

* プレゼンテーション全体。すべてのスライドが 1 つのプレゼンテーションにまとめられます
* 特定のスライド。選択したスライドが 1 つのプレゼンテーションにまとめられます
* 同じ形式（PPT から PPT、PPTX から PPTX など）および異なる形式（PPT から PPTX、PPTX から ODP など）のプレゼンテーションを相互に結合します。 

{{% alert title="Note" color="warning" %}} 

プレゼンテーションに加えて、Aspose.Slides は他のファイルの結合もサポートします：

* [画像](https://products.aspose.com/slides/androidjava/merger/image-to-image/)、たとえば [JPG から JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) や [PNG から PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* ドキュメント、たとえば [PDF から PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) や [HTML から HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* 画像と PDF のように異なる 2 種類のファイル、たとえば [画像から PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/) や [JPG から PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/)、[TIFF から PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/)

{{% /alert %}}

### **結合オプション**

次の点を決定するオプションを適用できます  

* 出力プレゼンテーションの各スライドが固有のスタイルを保持するか
* 出力プレゼンテーションのすべてのスライドに同一のスタイルを使用するか  

プレゼンテーションを結合するには、Aspose.Slides が提供する [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッド（[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) インターフェイス）を使用します。`AddClone` メソッドには、プレゼンテーション結合プロセスのパラメータを定義する複数の実装があります。すべての Presentation オブジェクトは [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) コレクションを持っているため、スライドを結合したいプレゼンテーションから `AddClone` メソッドを呼び出すことができます。

`AddClone` メソッドはソーススライドのクローンである `ISlide` オブジェクトを返します。出力プレゼンテーションのスライドは単にソーススライドのコピーです。したがって、ソースプレゼンテーションに影響を与えることなく、結果のスライドを変更（たとえばスタイルや書式設定オプション、レイアウトを適用）できます。 

## **プレゼンテーションの結合** 

Aspose.Slides は、スライドがレイアウトとスタイルを保持したまま結合できる [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを提供します（デフォルト パラメータ）。

この Java コードはプレゼンテーションの結合方法を示しています：
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


## **スライドマスターを使用したプレゼンテーションの結合** 

Aspose.Slides は、スライドマスターテンプレートを適用しながらスライドを結合できる [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを提供します。これにより、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。

この Java コードは上記の操作を示しています：
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

スライドマスターのレイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`AddClone` メソッドの `allowCloneMissingLayout` ブールパラメータが true に設定されていれば、ソーススライドのレイアウトが使用されます。そうでなければ、[PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException) がスローされます。

{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを使用したい場合は、結合時に [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) メソッドを使用してください。

## **プレゼンテーションから特定のスライドを結合** 

複数のプレゼンテーションから特定のスライドを結合することは、カスタム スライド デッキを作成する際に便利です。Aspose.Slides for Android via Java は、必要なスライドだけを選択してインポートできます。API は元のスライドの書式設定、レイアウト、デザインを保持します。

この Java コードは新しいプレゼンテーションを作成し、2 つの別のプレゼンテーションからタイトル スライドを追加して結果をファイルに保存します：
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


## **スライドレイアウトを使用したプレゼンテーションの結合** 

この Java コードは、好みのスライドレイアウトを適用しながらプレゼンテーションからスライドを結合し、1 つの出力プレゼンテーションを作成する方法を示しています：
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


## **異なるスライドサイズのプレゼンテーションの結合** 

{{% alert title="Note" color="warning" %}} 

異なるスライドサイズのプレゼンテーションは結合できません。 

{{% /alert %}}

サイズが異なる 2 つのプレゼンテーションを結合するには、片方のプレゼンテーションのサイズをもう一方に合わせてリサイズする必要があります。 

このサンプルコードは上記の操作を示しています：
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


## **プレゼンテーション セクションへのスライド結合** 

この Java コードは、特定のスライドをプレゼンテーションのセクションに結合する方法を示しています：
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

Aspose は **無料** の Collage ウェブアプリを提供しています（https://products.aspose.app/slides/collage）。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG 画像の結合、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) の作成などが可能です。 

{{% /alert %}}

## **よくある質問** 

**プレゼンテーションを結合する際にスライド数に制限はありますか？**  

厳密な制限はありません。Aspose.Slides は大きなファイルを処理できますが、パフォーマンスはファイルサイズとシステムリソースに依存します。非常に大きなプレゼンテーションの場合は、64 ビット JVM を使用し、十分なヒープメモリを割り当てることを推奨します。

**埋め込み動画や音声を含むプレゼンテーションを結合できますか？**  

はい。Aspose.Slides はスライドに埋め込まれたマルチメディア コンテンツを保持しますが、最終的なプレゼンテーションはかなり大きくなる可能性があります。

**結合時にフォントは保持されますか？**  

はい。ソースプレゼンテーションで使用されているフォントは、システムにインストールされているか[埋め込み](/slides/ja/androidjava/embedded-font/) されている限り、出力ファイルに保持されます。