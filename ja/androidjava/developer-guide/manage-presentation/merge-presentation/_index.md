---
title: Android でプレゼンテーションを効率的にマージ
linktitle: プレゼンテーションをマージ
type: docs
weight: 40
url: /ja/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint (PPT, PPTX) と OpenDocument (ODP) のプレゼンテーションを手軽にマージし、ワークフローを効率化します。"
---
## **概要**

PowerPoint と OpenDocument のプレゼンテーションを結合することは、多くの Android アプリケーションで一般的な作業です。特にレポートの生成、異なるソースからのスライドの統合、またはプレゼンテーション ワークフローの自動化で役立ちます。Aspose.Slides は、Microsoft PowerPoint、LibreOffice、OpenOffice をインストールせずに、複数の PPT、PPTX、または ODP ファイルを単一のプレゼンテーションに結合するための強力で使いやすい API を提供します。

このガイドでは、数行のコードだけで PowerPoint と OpenDocument のプレゼンテーションを結合する方法を学びます。すぐに使用できるサンプルを提供し、結合プロセス中にスライドの書式設定、レイアウト、およびその他のプレゼンテーション要素を保持する方法を示します。

エンタープライズ規模のアプリケーションを構築する場合でも、シンプルな自動化ツールの場合でも、Aspose.Slides はプレゼンテーションの結合を高速かつ信頼性があり、スケーラブルに行えます。Aspose.Slides はさまざまな方法でプレゼンテーションを結合できます。形状、スタイル、テキスト、書式設定、コメント、アニメーションなど、すべての要素を失うことなく結合できます。

{{% alert color="info" %}}
こちらもご参照ください: [スライドの複製](https://docs.aspose.com/slides/ja/androidjava/clone-slides/)
{{% /alert %}}

### **マージできるもの**

* 全体のプレゼンテーション。すべてのスライドが 1 つのプレゼンテーションにまとめられます
* 特定のスライド。選択したスライドが 1 つのプレゼンテーションにまとめられます
* 同一フォーマットのプレゼンテーション (PPT から PPT、PPTX から PPTX など) および異なるフォーマット (PPT から PPTX、PPTX から ODP など) 間の結合

### **マージオプション**

以下のように、出力プレゼンテーションのスライドがどのようなスタイルになるかを決定するオプションを適用できます。

* 出力プレゼンテーションの各スライドが固有のスタイルを保持するか
* 出力プレゼンテーションのすべてのスライドに特定のスタイルを使用するか

プレゼンテーションをマージするには、Aspose.Slides は [AddClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッド ( [ISlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection) インターフェイス) を提供します。`AddClone` メソッドには、マージプロセスのパラメータを定義する複数の実装があります。すべての Presentation オブジェクトは [Slides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getSlides--) コレクションを持っているため、スライドをマージしたいプレゼンテーションから `AddClone` メソッドを呼び出すことができます。

`AddClone` メソッドは `ISlide` オブジェクトを返します。これは元のスライドのクローンです。出力プレゼンテーションのスライドは、元のスライドの単なるコピーです。そのため、元のプレゼンテーションに影響を与えることを心配せずに、結果のスライドに変更 (たとえば、スタイルや書式設定オプション、レイアウトの適用) を加えることができます。

## **プレゼンテーションのマージ**

Aspose.Slides は、スライドのレイアウトとスタイルを保持しながらスライドを結合できる [**AddClone(ISlide)**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを提供します (デフォルト パラメータ)。

この Java コードはプレゼンテーションのマージ方法を示します。

```java
import com.aspose.slides.*;

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

## **スライド マスタを使用したプレゼンテーションのマージ**

Aspose.Slides は、スライド マスタ プレゼンテーション テンプレートを適用しながらスライドを結合できる [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを提供します。この方法により、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。

この Java のコードは上記の操作を示しています。

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
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
スライド マスタのレイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`AddClone` メソッドの `allowCloneMissingLayout` ブールパラメータが true に設定されていれば、元のスライドのレイアウトが使用されます。そうでなければ、[PptxEditException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/PptxEditException) がスローされます。
{{% /alert %}}

出力プレゼンテーションのスライドに別のスライドレイアウトを使用したい場合は、マージ時に [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) メソッドを代わりに使用します。

## **プレゼンテーションから特定のスライドをマージ**

複数のプレゼンテーションから特定のスライドをマージすることは、カスタム スライド デックを作成する際に便利です。Aspose.Slides for Android via Java を使用すると、必要なスライドのみを選択してインポートできます。API は元のスライドの書式設定、レイアウト、デザインを保持します。

以下の Java コードは新しいプレゼンテーションを作成し、2 つの別のプレゼンテーションからタイトル スライドを追加して、結果をファイルに保存します。

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **スライド レイアウトを使用したプレゼンテーションのマージ**

この Java コードは、希望のスライドレイアウトを適用しながらプレゼンテーションからスライドを結合し、1 つの出力プレゼンテーションを作成する方法を示します。

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **異なるスライドサイズのプレゼンテーションをマージ**

{{% alert title="Note" color="warning" %}}
異なるスライドサイズのプレゼンテーションはマージできません。
{{% /alert %}}

異なるスライドサイズの 2 つのプレゼンテーションをマージするには、どちらかのプレゼンテーションのサイズをもう一方に合わせてリサイズする必要があります。

このサンプルコードは上記の操作を示しています。

```java
import com.aspose.slides.*;

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

この Java コードは、特定のスライドをプレゼンテーションのセクションにマージする方法を示します。

```java
import com.aspose.slides.*;

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

{{% alert title="Tip" color="info" %}}
Aspose は [無料 Collage Web アプリ](https://products.aspose.app/slides/ja/collage) を提供しています。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/ja/collage/jpg) または PNG から PNG 画像をマージしたり、[フォトグリッド](https://products.aspose.app/slides/ja/collage/photo-grid) を作成したりできます。
{{% /alert %}}

## **FAQ**

### プレゼンテーションをマージする際のスライド数に制限はありますか？

厳密な制限はありません。Aspose.Slides は大容量ファイルを処理できますが、パフォーマンスはファイルのサイズとシステムリソースに依存します。非常に大きなプレゼンテーションの場合は、64 ビット JVM を使用し、十分なヒープ メモリを割り当てることを推奨します。

### 埋め込みビデオまたはオーディオを含むプレゼンテーションをマージできますか？

はい、Aspose.Slides はスライドに埋め込まれたマルチメディア コンテンツを保持しますが、最終的なプレゼンテーションは大幅に大きくなる可能性があります。

### プレゼンテーションをマージするとフォントは保持されますか？

はい。元のプレゼンテーションで使用されたフォントは、システムにインストールされているか、[埋め込み](/slides/ja/androidjava/embedded-font/) されていることを前提として、出力ファイルに保持されます。