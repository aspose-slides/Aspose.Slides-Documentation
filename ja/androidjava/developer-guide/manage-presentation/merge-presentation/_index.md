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
description: "Aspose.Slides for Android via Java を使用して、PowerPoint (PPT、PPTX) および OpenDocument (ODP) プレゼンテーションを手軽にマージし、作業フローを効率化します。"
---

{{% alert  title="Tip" color="primary" %}} 

**Aspose 無料オンライン** [マージャー アプリ](https://products.aspose.app/slides/merger)。同じ形式の PowerPoint プレゼンテーションをマージでき（PPT から PPT、PPTX から PPTX など）、異なる形式でもマージできます（PPT から PPTX、PPTX から ODP など）。

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **プレゼンテーションのマージ**

プレゼンテーションを別のプレゼンテーションにマージすると、スライドを 1 つのプレゼンテーションに効果的に結合し、1 つのファイルが得られます。 

{{% alert title="Info" color="info" %}}

ほとんどのプレゼンテーション アプリケーション（PowerPoint や OpenOffice）には、このようにプレゼンテーションを結合する機能がありません。 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)、しかし、これを使用すれば、さまざまな方法でプレゼンテーションをマージできます。形状、スタイル、テキスト、書式設定、コメント、アニメーションなど、すべての要素を失うことなくプレゼンテーションをマージできます。

**参照**

[スライドのクローン](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **マージできるもの**

Aspose.Slides を使用すると、次のものをマージできます。

* プレゼンテーション全体。すべてのスライドが 1 つのプレゼンテーションにまとめられます
* 特定のスライド。選択したスライドが 1 つのプレゼンテーションにまとめられます
* 同一フォーマット（PPT から PPT、PPTX から PPTX など）および異なるフォーマット（PPT から PPTX、PPTX から ODP など）のプレゼンテーションを相互にマージできます。 

### **マージ オプション**

次の条件を決定するオプションを適用できます。

* 出力プレゼンテーションの各スライドが固有のスタイルを保持するか
* 特定のスタイルをすべてのスライドに適用するか。 

プレゼンテーションをマージするには、Aspose.Slides が [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッド（[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) インターフェイスから）を提供します。`AddClone` メソッドには、マージ プロセスのパラメーターを定義する複数の実装があります。各 Presentation オブジェクトは [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) コレクションを持つため、スライドをマージしたいプレゼンテーションから `AddClone` メソッドを呼び出すことができます。

`AddClone` メソッドは `ISlide` オブジェクトを返します。これは元のスライドのクローンです。出力プレゼンテーションのスライドは単に元スライドのコピーなので、結果のスライドに変更（例：スタイルや書式オプション、レイアウトの適用）を加えても、元のプレゼンテーションが影響を受けることはありません。 

## **プレゼンテーションのマージ** 

Aspose.Slides は、スライドのレイアウトとスタイルを保持したままスライドを結合できる [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを提供します（デフォルト パラメーター）。

この Java コードはプレゼンテーションのマージ方法を示しています:
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

Aspose.Slides は、スライドマスター プレゼンテーション テンプレートを適用しながらスライドを結合できる [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを提供します。この方法により、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。

このコードは、上記の操作を Java で示しています:
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

スライドマスターのスライド レイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`AddClone` メソッドの `allowCloneMissingLayout` ブール パラメーターが true に設定されていれば、元スライドのレイアウトが使用されます。それ以外の場合は、[PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException) がスローされます。

{{% /alert %}}

出力プレゼンテーションのスライドに異なるレイアウトを使用したい場合は、マージ時に代わりに [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) メソッドを使用してください。

## **プレゼンテーションから特定のスライドをマージ**

複数のプレゼンテーションから特定のスライドをマージすることは、カスタム スライド デッキを作成するのに便利です。Aspose.Slides for Android via Java を使用すると、必要なスライドだけを選択してインポートできます。API は元のスライドの書式設定、レイアウト、デザインを保持します。

次の Java コードは新しいプレゼンテーションを作成し、他の 2 つのプレゼンテーションからタイトル スライドを追加し、結果をファイルに保存します:
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

この Java コードは、好みのスライドレイアウトを適用しながらプレゼンテーションのスライドを結合し、1 つの出力プレゼンテーションを作成する方法を示しています:
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

異なるスライドサイズの 2 つのプレゼンテーションをマージするには、サイズが合うように片方のプレゼンテーションをリサイズする必要があります。

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


## **スライドをプレゼンテーションのセクションにマージ**

この Java コードは、特定のスライドをプレゼンテーションのセクションにマージする方法を示しています:
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

Aspose は [無料 Collage ウェブアプリ](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG の画像をマージしたり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。

{{% /alert %}}

## **FAQ**

**プレゼンテーションをマージする際のスライド数に制限はありますか？**

厳密な制限はありません。Aspose.Slides は大きなファイルを処理できますが、パフォーマンスはサイズとシステム リソースに依存します。非常に大きなプレゼンテーションの場合、64 ビット JVM を使用し、十分なヒープ メモリを割り当てることが推奨されます。

**埋め込み動画や音声があるプレゼンテーションをマージできますか？**

はい、Aspose.Slides はスライドに埋め込まれたマルチメディア コンテンツを保持しますが、最終的なプレゼンテーションはかなり大きくなる可能性があります。

**マージ時にフォントは保持されますか？**

はい。元のプレゼンテーションで使用されたフォントは、システムにインストールされているか [embedded](/slides/ja/androidjava/embedded-font/) であれば、出力ファイルに保持されます。