---
title: プレゼンテーションの結合
type: docs
weight: 40
url: /ja/nodejs-java/merge-presentation/
keywords: "PowerPoint を結合, PPTX, PPT, PowerPoint を統合, プレゼンテーションを結合, プレゼンテーションを統合, Java"
description: "JavaScript で PowerPoint プレゼンテーションを結合または統合"
---

## **プレゼンテーションの結合**

1つのプレゼンテーションを別のプレゼンテーションに結合すると、実質的にスライドを単一のプレゼンテーションにまとめて1つのファイルにします。 

{{% alert title="Info" color="info" %}}

ほとんどのプレゼンテーションプログラム（PowerPointやOpenOffice）は、このようにプレゼンテーションを結合する機能を備えていません。 

ただし、[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/) を使用すると、さまざまな方法でプレゼンテーションを結合できます。形状、スタイル、テキスト、書式設定、コメント、アニメーションなど、すべての要素を品質やデータの損失を心配せずに結合できます。

**参照**

[スライドのクローン作成](https://docs.aspose.com/slides/nodejs-java/clone-slides/)。

{{% /alert %}}

### **マージできるもの**

Aspose.Slides を使用すると、次のものをマージできます。

* プレゼンテーション全体。プレゼンテーションのすべてのスライドが 1 つのプレゼンテーションにまとめられます
* 特定のスライド。選択したスライドが 1 つのプレゼンテーションにまとめられます
* 同一形式のプレゼンテーション（PPT から PPT、PPTX から PPTX など）および異なる形式のプレゼンテーション（PPT から PPTX、PPTX から ODP など）を相互に結合します。 

{{% alert title="Note" color="warning" %}} 

プレゼンテーションに加えて、Aspose.Slides は他のファイルもマージできます。

* [画像](https://products.aspose.com/slides/nodejs-java/merger/image-to-image/)、たとえば [JPG から JPG](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-jpg/) や [PNG から PNG](https://products.aspose.com/slides/nodejs-java/merger/png-to-png/)
* 文書、たとえば [PDF から PDF](https://products.aspose.com/slides/nodejs-java/merger/pdf-to-pdf/) や [HTML から HTML](https://products.aspose.com/slides/nodejs-java/merger/html-to-html/)
* 画像と PDF の組み合わせなど、たとえば [画像から PDF](https://products.aspose.com/slides/nodejs-java/merger/image-to-pdf/) や [JPG から PDF](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-pdf/) や [TIFF から PDF](https://products.aspose.com/slides/nodejs-java/merger/tiff-to-pdf/)

{{% /alert %}}

### **マージ オプション**

次の点を決定するオプションを適用できます。

* 出力プレゼンテーションの各スライドが固有のスタイルを保持するか
* 出力プレゼンテーションのすべてのスライドに同じスタイルを使用するか

プレゼンテーションをマージするには、Aspose.Slides は [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) メソッド（[SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) クラス）を提供します。`addClone` メソッドにはさまざまな実装があり、プレゼンテーションのマージ処理パラメータを定義します。すべての Presentation オブジェクトは [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) コレクションを持つため、スライドをマージしたいプレゼンテーションから `addClone` メソッドを呼び出すことができます。

`addClone` メソッドは `Slide` オブジェクトを返します。これは元のスライドのクローンです。出力プレゼンテーションのスライドは単に元スライドのコピーなので、ソースプレゼンテーションに影響を与えることなく、結果のスライドに対してスタイルや書式設定、レイアウトの変更などを行うことができます。 

## **プレゼンテーションのマージ** 

Aspose.Slides は、スライドがレイアウトとスタイルを保持したままスライドを結合できる [**AddClone(ISlide)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) メソッドを提供します（デフォルトパラメータ）。

この JavaScript コードはプレゼンテーションのマージ方法を示しています:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **スライド マスタ付きプレゼンテーションのマージ** 

Aspose.Slides は、スライド マスタ プレゼンテーション テンプレートを適用してスライドを結合できる [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) メソッドを提供します。これにより、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。

この JavaScript コードは上記の操作を示しています:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 

スライド マスタのレイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`addClone` メソッドの `allowCloneMissingLayout` ブール パラメータを true に設定すると、ソーススライドのレイアウトが使用されます。設定しない場合は [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException) がスローされます。

{{% /alert %}}

出力プレゼンテーションのスライドに異なるレイアウトを使用したい場合は、マージ時に [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) メソッドを使用してください。

## **プレゼンテーションから特定のスライドをマージ** 

複数のプレゼンテーションから特定のスライドをマージすると、カスタム スライド デッキを作成できます。Aspose.Slides for Node.js via Java を使用すると、必要なスライドだけを選択してインポートできます。API は元のスライドの書式設定、レイアウト、デザインを保持します。

次の JavaScript コードは新しいプレゼンテーションを作成し、2 つの別のプレゼンテーションからタイトル スライドを追加して結果をファイルに保存します:
```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```

```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```


## **スライド レイアウト付きプレゼンテーションのマージ** 

この JavaScript コードは、スライドに希望のレイアウトを適用しながらプレゼンテーションからスライドを結合し、1 つの出力プレゼンテーションを作成する方法を示します:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **異なるスライド サイズのプレゼンテーションのマージ** 

{{% alert title="Note" color="warning" %}} 

異なるスライド サイズのプレゼンテーションはマージできません。 

{{% /alert %}}

異なるスライド サイズの 2 つのプレゼンテーションをマージするには、サイズが合うようにどちらかのプレゼンテーションのサイズを変更する必要があります。 

このサンプルコードは上記の操作を示しています:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **スライドをプレゼンテーション セクションにマージ** 

この JavaScript コードは、特定のスライドをプレゼンテーションのセクションにマージする方法を示します:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


スライドはセクションの末尾に追加されます。 

## **FAQ**

**マージ時にスピーカーノートは保持されますか？**

はい。スライドをクローンすると、ノート、書式設定、アニメーションを含むすべてのスライド要素が引き継がれます。

**コメントと作成者は転送されますか？**

コメントはスライドコンテンツの一部としてスライドと共にコピーされます。コメント作成者のラベルは結果のプレゼンテーション内のコメントオブジェクトとして保持されます。

**ソース プレゼンテーションがパスワードで保護されている場合はどうなりますか？**

[LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setpassword/) を使用して [パスワードで保護されたプレゼンテーション](/slides/ja/nodejs-java/password-protected-presentation/) を開く必要があります。読み込んだ後、そのスライドは保護されていないターゲット ファイル（または保護されたファイル）に安全にクローンできます。

**マージ操作はどれくらいスレッドセーフですか？**

同じ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) インスタンスを [複数のスレッド](/slides/ja/nodejs-java/multithreading/) から使用しないでください。推奨ルールは「1 ドキュメント – 1 スレッド」です。別々のファイルは別スレッドで並行処理できます。

## **参照**

Aspose は、[無料オンライン コラージュ メーカー](https://products.aspose.app/slides/collage) を提供しています。このオンライン サービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG の画像を結合したり、[フォト グリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。

[Aspose 無料オンライン マージャー](https://products.aspose.app/slides/merger) もご利用ください。これにより、同じ形式（例: PPT から PPT、PPTX から PPTX）または異なる形式（例: PPT から PPTX、PPTX から ODP）の PowerPoint プレゼンテーションを結合できます。

[![Aspose 無料オンライン マージャー](slides-merger.png)](https://products.aspose.app/slides/merger)