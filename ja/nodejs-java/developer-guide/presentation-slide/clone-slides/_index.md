---
title: スライドのクローン
type: docs
weight: 35
url: /ja/nodejs-java/clone-slides/
---

## **プレゼンテーション内のスライドのクローン**
クローン作成とは、あるものの正確なコピーまたはレプリカを作るプロセスです。Aspose.Slides for Node.js via Java を使用すると、任意のスライドのコピーまたはクローンを作成し、そのクローンしたスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することが可能です。スライドのクローン作成プロセスにより、元のスライドを変更せずに新しいスライドが作成され、開発者がそれを修正できます。スライドをクローンする方法はいくつかあります:

- プレゼンテーション内の末尾にクローン。
- プレゼンテーション内の別の位置にクローン。
- 別のプレゼンテーションの末尾にクローン。
- 別のプレゼンテーションの別の位置にクローン。
- 別のプレゼンテーションの特定の位置にクローン。

In Aspose.Slides for Node.js via Java, (a collection of [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) objects) exposed by the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) object provides the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) and [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) methods to perform the above types of slide cloning

## **プレゼンテーション内の末尾にクローン**
同じプレゼンテーションファイル内の既存スライドの末尾にスライドをクローンして使用したい場合は、以下の手順に従って [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) メソッドを使用します:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. Instantiate the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) クラスを、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) オブジェクトが公開する Slides コレクションを参照して作成します。
1. Call the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method exposed by the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) オブジェクトを呼び出し、クローン対象のスライドをパラメータとして渡します。
1. Write the modified presentation file. 変更されたプレゼンテーションファイルを書き出します。

In the example given below, we have cloned a slide (lying at the first position – zero index – of the presentation) to the end of the presentation.  
```javascript
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 同じプレゼンテーション内のスライド コレクションの末尾に目的のスライドをクローンする
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // 変更されたプレゼンテーションをディスクに保存する
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **プレゼンテーション内の別の位置にクローン**
同じプレゼンテーションファイル内の別の位置にスライドをクローンして使用したい場合は、[insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) メソッドを使用します:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. Instantiate the class by referencing the [**Slides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) collection exposed by the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) object. [Presentation] オブジェクトが公開する **Slides** コレクションを参照してクラスをインスタンス化します。
1. Call the [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) method exposed by the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) オブジェクトを呼び出し、クローン対象のスライドと新しい位置のインデックスをパラメータとして渡します。
1. Write the modified presentation as a PPTX file. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

In the example given below, we have cloned a slide (lying at the zero index – position 1 – of the presentation) to index 1 – Position 2 – of the presentation.  
```javascript
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成する
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // 同じプレゼンテーション内のスライド コレクションの末尾に目的のスライドをクローンする
    var slds = pres.getSlides();
    // 同じプレゼンテーション内の指定インデックスに目的のスライドをクローンする
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // 変更されたプレゼンテーションをディスクに保存する
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **別のプレゼンテーションの末尾にクローン**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの既存スライドの末尾に挿入したい場合:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class containing the presentation the slide will be cloned from. クローン元プレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class containing the destination presentation that the slide will be added to. 挿入先プレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
1. Instantiate the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) class by referencing the [**Slides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) collection exposed by the Presentation object of the destination presentation. 挿入先プレゼンテーションの [Presentation] オブジェクトが公開する **Slides** コレクションを参照して [SlideCollection] クラスをインスタンス化します。
1. Call the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method exposed by the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) object and pass the slide from the source presentation as a parameter to the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method. ソースプレゼンテーションのスライドをパラメータとして渡し、[addClone] メソッドを呼び出します。
1. Write the modified destination presentation file. 変更された挿入先プレゼンテーションファイルを書き出します。

In the example given below, we have cloned a slide (from the first index of the source presentation) to the end of the destination presentation.  
```javascript
// ソース プレゼンテーション ファイルを読み込むために Presentation クラスをインスタンス化する
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // スライドがクローンされる先の PPTX 用に Presentation クラスをインスタンス化する
    var destPres = new aspose.slides.Presentation();
    try {
        // ソース プレゼンテーションから目的のスライドを取得し、先方 プレゼンテーションのスライド コレクションの末尾にクローンする
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // 先方 プレゼンテーションをディスクに保存する
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **別のプレゼンテーションの別の位置にクローン**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの特定の位置に挿入したい場合:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class containing the source presentation the slide will be cloned from. ソースプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class containing the presentation the slide will be added to. 挿入先プレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
1. Instantiate the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) class by referencing the Slides collection exposed by the Presentation object of the destination presentation. 挿入先プレゼンテーションの [Presentation] オブジェクトが公開する Slides コレクションを参照して [SlideCollection] クラスをインスタンス化します。
1. Call the [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) method exposed by the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) object and pass the slide from the source presentation along with the desired position as a parameter to the [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) method. ソースプレゼンテーションのスライドと希望する位置をパラメータとして渡し、[insertClone] メソッドを呼び出します。
1. Write the modified destination presentation file. 変更された挿入先プレゼンテーションファイルを書き出します。

In the example given below, we have cloned a slide (from the zero index of the source presentation) to index 1 (position 2) of the destination presentation.  
```javascript
// ソース プレゼンテーション ファイルを読み込むために Presentation クラスをインスタンス化する
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // スライドがクローンされる先の PPTX 用に Presentation クラスをインスタンス化する
    var destPres = new aspose.slides.Presentation();
    try {
        // ソース プレゼンテーションから目的のスライドを先方 プレゼンテーションのスライド コレクションの末尾にクローンする
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // 先方 プレゼンテーションをディスクに保存する
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **別のプレゼンテーションの特定の位置にクローン**
マスタースライドを持つスライドをあるプレゼンテーションから別のプレゼンテーションへクローンしたい場合、まずソースプレゼンテーションから目的のマスタースライドを挿入先プレゼンテーションにクローンする必要があります。その後、そのマスタースライドを使用してスライドをクローンします。[**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) は、ソースプレゼンテーションではなく挿入先プレゼンテーションのマスタースライドを期待します。マスタースライド付きでスライドをクローンする手順は以下の通りです:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class containing the source presentation the slide will be cloned from. ソースプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class containing the destination presentation the slide will be cloned to. 挿入先プレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
1. Access the slide to be cloned along with the master slide. クローン対象のスライドとマスタースライドにアクセスします。
1. Instantiate the [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) class by referencing the Masters collection exposed by the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) object of the destination presentation. 挿入先プレゼンテーションの [Presentation] オブジェクトが公開する Masters コレクションを参照して [MasterSlideCollection] クラスをインスタンス化します。
1. Call the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method exposed by the [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) object and pass the master from the source PPTX to be cloned as a parameter to the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method. ソース PPTX からクローンするマスターをパラメータとして渡し、[addClone] メソッドを呼び出します。
1. Instantiate the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) class by setting the reference to the Slides collection exposed by the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) object of the destination presentation. 挿入先プレゼンテーションの [Presentation] オブジェクトが公開する Slides コレクションへの参照を設定して [SlideCollection] クラスをインスタンス化します。
1. Call the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method exposed by the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) object and pass the slide from the source presentation to be cloned and master slide as a parameter to the [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) method. ソースプレゼンテーションのスライドとマスタースライドをパラメータとして渡し、[addClone] メソッドを呼び出します。
1. Write the modified destination presentation file. 変更された挿入先プレゼンテーションファイルを書き出します。

In the example given below, we have cloned a slide with a master (lying at the zero index of the source presentation) to the end of the destination presentation using a master from source slide.  
```javascript
// ソース プレゼンテーション ファイルを読み込むために Presentation クラスをインスタンス化する
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // スライドがクローンされる先のプレゼンテーション用に Presentation クラスをインスタンス化する
    var destPres = new aspose.slides.Presentation();
    try {
        // ソース プレゼンテーションのスライド コレクションから ISlide を取得し、マスタースライドも取得する
        // マスタースライド
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // ソース プレゼンテーションから目的のマスタースライドを取得し、宛先プレゼンテーションのマスター コレクションにクローンする
        // 宛先プレゼンテーション
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // ソース プレゼンテーションから目的のマスタースライドを取得し、宛先プレゼンテーションのマスター コレクションにクローンする
        // 宛先プレゼンテーション
        var iSlide = masters.addClone(SourceMaster);
        // ソース プレゼンテーションのスライドを、目的のマスターと共に宛先プレゼンテーションのスライド コレクションの末尾にクローンする
        // 宛先プレゼンテーションのスライド コレクション
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // 宛先プレゼンテーションをディスクに保存する
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **指定されたセクションの末尾にクローン**
同じプレゼンテーションファイル内で別のセクションにスライドをクローンして使用したい場合は、[**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) メソッドを使用します。Aspose.Slides for Node.js via Java は、最初のセクションからスライドをクローンし、同じプレゼンテーションの第二セクションに挿入することを可能にします。

The following code snippet shows you how to clone a slide and insert the cloned slide into a specified section.  
```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // 宛先プレゼンテーションをディスクに保存する
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **よくある質問**

**スピーカーノートとレビュアーコメントはクローンされますか？**

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に [remove them](/slides/ja/nodejs-java/presentation-notes/) してください。

**チャートとそのデータソースはどのように扱われますか？**

チャートオブジェクト、書式設定、埋め込みデータはすべてコピーされます。チャートが外部ソース（例: OLE 埋め込みブック）にリンクされている場合、そのリンクは [OLE object](/slides/ja/nodejs-java/manage-ole/) として保持されます。ファイル間で移動した後、データの可用性とリフレッシュ動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。特定のスライドインデックスにクローンを挿入し、選択した [section](/slides/ja/nodejs-java/slide-section/) に配置できます。対象セクションが存在しない場合は、まず作成してからスライドを移動してください。