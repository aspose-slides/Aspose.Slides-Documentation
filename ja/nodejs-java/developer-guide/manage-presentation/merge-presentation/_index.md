---
title: JavaScriptでプレゼンテーションを効率的に結合
linktitle: プレゼンテーションの結合
type: docs
weight: 40
url: /ja/nodejs-java/merge-presentation/
keywords:
- PowerPoint を結合
- プレゼンテーションを結合
- スライドを結合
- PPT を結合
- PPTX を結合
- ODP を結合
- PowerPoint を組み合わせる
- プレゼンテーションを組み合わせる
- スライドを組み合わせる
- PPT を組み合わせる
- PPTX を組み合わせる
- ODP を組み合わせる
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、JavaScript で PowerPoint（PPT、PPTX）および OpenDocument（ODP）プレゼンテーションを簡単に結合し、作業フローを効率化します。"
---

## **プレゼンテーションの結合**

プレゼンテーションを別のプレゼンテーションに結合すると、スライドが単一のプレゼンテーションにまとめられ、1つのファイルになります。

{{% alert title="Info" color="info" %}}
ほとんどのプレゼンテーションソフト（PowerPoint や OpenOffice）には、ユーザーがこのようにプレゼンテーションを結合できる機能がありません。

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/) は、さまざまな方法でプレゼンテーションを結合できます。スライドの形状、スタイル、テキスト、書式設定、コメント、アニメーションなどを失うことなく、品質やデータを損なうことなく結合できます。
**参照**

[スライドのクローン作成](https://docs.aspose.com/slides/nodejs-java/clone-slides/).
{{% /alert %}}

### **結合できる対象**

Aspose.Slides を使用すると、次のものを結合できます。

* プレゼンテーション全体。すべてのスライドが 1 つのプレゼンテーションにまとめられます
* 特定のスライド。選択したスライドが 1 つのプレゼンテーションにまとめられます
* 同一フォーマット（PPT → PPT、PPTX → PPTX など）または異なるフォーマット（PPT → PPTX、PPTX → ODP など）のプレゼンテーション同士を相互に結合します。

### **結合オプション**

次の条件を決定するオプションを適用できます。

* 出力プレゼンテーションの各スライドが固有のスタイルを保持するか
* 出力プレゼンテーションのすべてのスライドで特定のスタイルを使用するか

プレゼンテーションを結合するには、Aspose.Slides は [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) メソッド（[SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) クラス）を提供します。`addClone` メソッドには、結合プロセスのパラメータを定義する複数の実装があります。各 Presentation オブジェクトは [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) コレクションを持っているため、結合先のプレゼンテーションから `addClone` メソッドを呼び出すことができます。

`addClone` メソッドは、元のスライドのクローンである `Slide` オブジェクトを返します。出力プレゼンテーションのスライドは、元のスライドのコピーに過ぎません。そのため、ソースプレゼンテーションに影響を与えることなく、結果のスライドに対してスタイルや書式設定、レイアウトの変更などを行うことができます。

## **プレゼンテーションの結合**

Aspose.Slides は、スライドのレイアウトとスタイルを保持したままスライドを結合できる [**AddClone(ISlide)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) メソッドを提供します（デフォルト パラメータ）。

この JavaScript コードは、プレゼンテーションを結合する方法を示しています:
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


## **スライドマスターを使用したプレゼンテーションの結合**

Aspose.Slides は、[**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) メソッドを提供し、スライドマスターテンプレートを適用しながらスライドを結合できます。この方法により、必要に応じて出力プレゼンテーション内のスライドのスタイルを変更できます。

この JavaScript コードは、上記の操作を実演します:
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
スライドマスターのレイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`addClone` メソッドの `allowCloneMissingLayout` ブール パラメータが true に設定されていれば、ソーススライドのレイアウトが使用されます。そうでない場合は、[PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException) がスローされます。
{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを適用したい場合は、結合時に [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) メソッドを使用してください。

## **プレゼンテーションから特定のスライドを結合**

複数のプレゼンテーションから特定のスライドを結合することは、カスタム スライド デッキを作成するのに便利です。Aspose.Slides for Node.js via Java を使用すると、必要なスライドだけを選択してインポートできます。API は元のスライドの書式設定、レイアウト、デザインを保持します。

次の JavaScript コードは、新しいプレゼンテーションを作成し、他の 2 つのプレゼンテーションからタイトルスライドを追加してファイルに保存します:
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


## **スライドレイアウトを指定したプレゼンテーションの結合**

この JavaScript コードは、プレゼンテーションからスライドを結合し、希望するスライドレイアウトを適用して 1 つの出力プレゼンテーションを作成する方法を示しています:
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


## **サイズが異なるスライドを持つプレゼンテーションの結合**

{{% alert title="Note" color="warning" %}} 
サイズが異なるスライドを持つプレゼンテーションは結合できません。 
{{% /alert %}}

サイズが異なるスライドを持つ 2 つのプレゼンテーションを結合するには、サイズが合うようにどちらかのプレゼンテーションをリサイズする必要があります。

このサンプルコードは、上記の操作を実演します:
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


## **スライドをプレゼンテーションのセクションに結合**

この JavaScript コードは、特定のスライドをプレゼンテーションのセクションに結合する方法を示しています:
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

はい。スライドをクローンすると、ノート、書式設定、アニメーションを含むすべてのスライド要素がコピーされます。

**コメントとその作成者は転送されますか？**

コメントはスライドコンテンツの一部としてコピーされ、コメント作成者のラベルは結果のプレゼンテーション内のコメントオブジェクトとして保持されます。

**ソースプレゼンテーションがパスワードで保護されている場合はどうなりますか？**

[LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setpassword/) を使用してパスワードで[開く](/slides/ja/nodejs-java/password-protected-presentation/) 必要があります。ロード後、これらのスライドは保護されていないターゲット ファイル（または保護されたファイル）に安全にクローンできます。

**マージ操作はスレッドセーフですか？**

同じ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) インスタンスを[複数スレッド](/slides/ja/nodejs-java/multithreading/)から使用しないでください。推奨ルールは「1 ドキュメント → 1 スレッド」です。別々のスレッドで異なるファイルを並行処理できます。

## **参照**

Aspose は、[FREE Online Collage Maker](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG への画像結合、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) の作成などが可能です。

[Aspose FREE Online Merger](https://products.aspose.app/slides/merger) をチェックしてください。PowerPoint プレゼンテーションを同一フォーマット（例：PPT → PPT、PPTX → PPTX）または異なるフォーマット（例：PPT → PPTX、PPTX → ODP）で結合できます。

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)