---
title: JavaScript でプレゼンテーション スライドをクローンする
linktitle: スライドをクローン
type: docs
weight: 35
url: /ja/nodejs-java/clone-slides/
keywords:
- スライドをクローン
- スライドをコピー
- スライドを保存
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して PowerPoint スライドを迅速に複製します。コード例に従って数秒で PPT 作成を自動化し、手作業を排除しましょう。"
---
## **はじめに**

クローンとは、何かを正確にコピーまたは複製するプロセスです。Aspose.Slides for Node.js via Java を使用すると、任意のスライドのコピーまたはクローンを作成し、そのクローン化されたスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することも可能です。スライドのクローン作成プロセスにより、元のスライドを変更することなく開発者が変更できる新しいスライドが作成されます。スライドをクローンする方法はいくつかあります。

- プレゼンテーション内の末尾にクローンを作成。
- プレゼンテーション内の別の位置にクローンを作成。
- 別のプレゼンテーションの末尾にクローンを作成。
- 別のプレゼンテーションの別の位置にクローンを作成。
- 別のプレゼンテーションの特定の位置にクローンを作成。

Aspose.Slides for Node.js via Java では、[Slide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Slide) オブジェクトのコレクションである [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) オブジェクトが [addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) および [insertClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) メソッドを提供し、上記のスライドクローンの種類を実行できます。

## **プレゼンテーション内の末尾にクローン**
同じプレゼンテーションファイル内の既存スライドの末尾にクローンしたスライドを使用したい場合は、以下の手順に従って [addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) オブジェクトが公開する Slides コレクションを参照して、[SlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation#getSlides--) クラスをインスタンス化します。  
1. [SlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation#getSlides--) オブジェクトが提供する [addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) メソッドを呼び出し、クローン対象のスライドをパラメーターとして渡します。  
1. 変更されたプレゼンテーションファイルを書き込みます。

以下の例では、プレゼンテーションの最初の位置（インデックス 0）にあるスライドをプレゼンテーションの末尾にクローンしています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローン
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // 変更されたプレゼンテーションをディスクに書き込む
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **プレゼンテーション内の別の位置にクローン**
同じプレゼンテーションファイル内の別の位置にクローンしたスライドを使用したい場合は、[insertClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) オブジェクトが公開する **Slides** コレクションを参照してクラスをインスタンス化します。  
1. [SlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation#getSlides--) オブジェクトが提供する [insertClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) メソッドを呼び出し、クローン対象のスライドと新しい位置のインデックスをパラメーターとして渡します。  
1. 変更されたプレゼンテーションを書き出し、PPTX ファイルとして保存します。

以下の例では、プレゼンテーションのインデックス 1（位置 2）にあるスライドをインデックス 2（位置 3）にクローンしています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローン
    var slds = pres.getSlides();
    // 同じプレゼンテーション内の指定インデックスに目的のスライドをクローン
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // 変更されたプレゼンテーションをディスクに書き込む
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **別のプレゼンテーションの末尾にクローン**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの既存スライドの末尾に追加したい場合:

1. スライドをクローン元とするプレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. スライドを追加する先のプレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. 目的プレゼンテーションの [Presentation] オブジェクトが公開する **Slides** コレクションを参照して、[SlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SlideCollection) クラスをインスタンス化します。  
1. [SlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation#getSlides--) オブジェクトが提供する [addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) メソッドを呼び出し、ソースプレゼンテーションからのスライドをパラメーターとして渡します。  
1. 変更された目的プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションの最初のインデックスにあるスライドを目的プレゼンテーションの末尾にクローンしています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// ソース プレゼンテーション ファイルをロードするための Presentation クラスをインスタンス化
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化
    var destPres = new aspose.slides.Presentation();
    try {
        // ソース プレゼンテーションから目的のスライドを取得し、目的プレゼンテーションのスライドコレクションの末尾にクローン
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // 目的プレゼンテーションをディスクに書き込む
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **別のプレゼンテーションの別の位置にクローン**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの特定の位置に使用したい場合:

1. スライドをクローン元とするプレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. スライドを追加する先のプレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. 目的プレゼンテーションの [Presentation] オブジェクトが公開する Slides コレクションを参照して、[SlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation#getSlides--) クラスをインスタンス化します。  
1. [SlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation#getSlides--) オブジェクトが提供する [insertClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) メソッドを呼び出し、ソースプレゼンテーションからのスライドと目的の位置をパラメーターとして渡します。  
1. 変更された目的プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションのインデックス 0 のスライドを目的プレゼンテーションのインデックス 1（位置 2）にクローンしています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// ソース プレゼンテーション ファイルをロードするために Presentation クラスをインスタンス化
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化
    var destPres = new aspose.slides.Presentation();
    try {
        // ソース プレゼンテーションから目的のスライドを取得し、目的プレゼンテーションのスライドコレクションの末尾にクローン
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // 目的プレゼンテーションをディスクに書き込む
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **別のプレゼンテーションの特定の位置にクローン（マスタースライド付き）**
あるプレゼンテーションからマスタースライド付きのスライドをクローンし、別のプレゼンテーションで使用したい場合は、まずソースプレゼンテーションから目的プレゼンテーションへマスタースライドをクローンする必要があります。その後、そのマスタースライドを使用してスライドをクローンします。`addClone(ISlide, IMasterSlide, boolean)` は、ソースではなく目的プレゼンテーションのマスタースライドを受け取ります。マスタースライド付きのスライドをクローンする手順は以下の通りです。

1. スライドをクローン元とするプレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. スライドをクローン先とする目的プレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. クローン対象のスライドとそのマスタースライドにアクセスします。  
1. 目的プレゼンテーションの [Presentation] オブジェクトが公開する Masters コレクションを参照して、[MasterSlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/MasterSlideCollection) クラスをインスタンス化します。  
1. [MasterSlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/MasterSlideCollection) オブジェクトが提供する [addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) メソッドを呼び出し、ソース PPTX からクローンするマスターをパラメーターとして渡します。  
1. 目的プレゼンテーションの [Presentation] オブジェクトが公開する Slides コレクションを参照して、[SlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation#getSlides--) クラスをインスタンス化します。  
1. [SlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation#getSlides--) オブジェクトが提供する [addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) メソッドを呼び出し、ソースプレゼンテーションからのスライドとクローンしたマスタースライドをパラメーターとして渡します。  
1. 変更された目的プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションのインデックス 0 にあるマスタースライド付きスライドを、ソーススライドのマスターを使用して目的プレゼンテーションの末尾にクローンしています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// ソース プレゼンテーション ファイルをロードするために Presentation クラスをインスタンス化
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // スライドをクローンする先のプレゼンテーション用に Presentation クラスをインスタンス化
    var destPres = new aspose.slides.Presentation();
    try {
        // ソース プレゼンテーションのスライド コレクションから ISlide をインスタンス化し、
        // マスタースライド
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // ソース プレゼンテーションから目的のマスタースライドを取得し、 
        // 目的プレゼンテーションのマスター コレクションにクローン
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // ソース プレゼンテーションの目的スライドを、指定したマスターと共に、目的プレゼンテーションのスライド コレクションの末尾にクローン
        // 目的プレゼンテーションのスライド コレクション
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // 目的プレゼンテーションをディスクに保存
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **指定セクションの末尾にクローン**
同じプレゼンテーションファイル内で別のセクションにクローンしたスライドを使用したい場合は、[SlideCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SlideCollection) クラスが提供する **addClone**([addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-)) メソッドを使用します。Aspose.Slides for Node.js via Java は、最初のセクションからスライドをクローンし、同じプレゼンテーションの第二セクションにそのクローンを挿入することを可能にします。

以下のコードスニペットは、スライドをクローンして指定セクションに挿入する方法を示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // 目的のプレゼンテーションをディスクに保存
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **スライドサイズの一致を確認**

スライドを別のプレゼンテーションにクローンする場合、目的プレゼンテーションのスライドサイズがソースと同じであることを確認してください。スライドサイズが異なると、Aspose.Slides はクローンされたシェイプのサイズを自動的に再スケーリングせず、元の座標と寸法が保持されるため、コンテンツがずれたりスライド境界を超えて表示されたりする可能性があります。

マスターとスライドをクローンする前に、目的プレゼンテーションのスライドサイズをソースに合わせて設定できます:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

この操作は、マスターとスライドをクローンする前に実行してください。

## **FAQ**

**スピーカーノートやレビューコメントもクローンされますか？**

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に[削除してください](/slides/ja/nodejs-java/presentation-notes/)。

**チャートとそのデータソースはどのように扱われますか？**

チャートオブジェクト、書式設定、埋め込みデータはコピーされます。チャートが外部ソース（例: OLE 埋め込みワークブック）にリンクされている場合、そのリンクは[OLE オブジェクト](/slides/ja/nodejs-java/manage-ole/)として保持されます。ファイル間で移動した後は、データの可用性と更新動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。特定のスライドインデックスにクローンを挿入し、選択した[セクション](/slides/ja/nodejs-java/slide-section/)に配置できます。対象セクションが存在しない場合は、先に作成してからスライドを移動してください。