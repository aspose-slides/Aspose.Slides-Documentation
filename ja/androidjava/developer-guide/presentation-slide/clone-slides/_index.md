---
title: Android でプレゼンテーションスライドをクローン
linktitle: スライドをクローン
type: docs
weight: 35
url: /ja/androidjava/clone-slides/
keywords:
- スライドをクローン
- スライドをコピー
- スライドを保存
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して PowerPoint スライドを複製します。明確な Java コード例に従い、数秒で PPT 作成を自動化し、手作業を排除しましょう。"
---

## **プレゼンテーション内のスライドのクローン作成**
クローンとは、対象を正確にコピーまたは複製するプロセスです。Aspose.Slides for Android via Java を使用すると、任意のスライドのコピーまたはクローンを作成し、現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することができます。スライドのクローン作成により、元のスライドを変更せずに新しいスライドを作成でき、開発者が自由に変更できます。スライドをクローンする方法はいくつかあります。

- プレゼンテーション内の末尾にクローン作成。
- プレゼンテーション内の別の位置にクローン作成。
- 別のプレゼンテーションの末尾にクローン作成。
- 別のプレゼンテーションの別の位置にクローン作成。
- 別のプレゼンテーションの特定の位置にクローン作成。

Aspose.Slides for Android via Java では、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトが公開する (ISlide オブジェクトのコレクション) が、[addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) および [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを提供し、上記のスライドクローン作成を実行できます。

## **プレゼンテーションの末尾にスライドをクローン作成**
同一プレゼンテーション内で既存のスライドの末尾にクローンを作成して使用したい場合は、以下の手順に従って [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを使用してください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) クラスのインスタンスを取得します。  
3. [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、クローン対象のスライドをパラメーターとして渡します。  
4. 変更後のプレゼンテーションファイルを書き出します。

以下の例では、プレゼンテーションの先頭位置（インデックス 0）にあるスライドを末尾にクローンしました。
```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンス化
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 同じプレゼンテーション内でスライドコレクションの末尾に目的のスライドをクローン
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 変更されたプレゼンテーションをディスクに保存
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **プレゼンテーション内の別の位置にスライドをクローン作成**
同一プレゼンテーション内で別の位置にスライドをクローンして使用したい場合は、[insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを使用してください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトが公開する **Slides** コレクションを参照して、クラスのインスタンスを取得します。  
3. [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) オブジェクトが公開する [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを呼び出し、クローン対象のスライドと新しい位置のインデックスをパラメーターとして渡します。  
4. 変更後のプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションのインデックス 0（位置 1）にあるスライドをインデックス 1（位置 2）にクローンしました。
```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンス化
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 同じプレゼンテーション内でスライドコレクションの末尾に目的のスライドをクローン
    ISlideCollection slds = pres.getSlides();

    // 同じプレゼンテーション内で指定したインデックスに目的のスライドをクローン
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 変更されたプレゼンテーションをディスクに保存
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **別のプレゼンテーションの末尾にスライドをクローン作成**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションの既存スライドの末尾に挿入したい場合は、次の手順を実行します。

1. クローン元プレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. クローン先プレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
3. 先行プレゼンテーションの [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトが公開する **Slides** コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) クラスのインスタンスを取得します。  
4. [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、ソースプレゼンテーションから取得したスライドをパラメーターとして渡します。  
5. 変更後の先行プレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションの先頭インデックスにあるスライドを先行プレゼンテーションの末尾にクローンしました。
```java
// ソースプレゼンテーションファイルをロードするために Presentation クラスをインスタンス化
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化
    Presentation destPres = new Presentation();
    try {
        // ソースプレゼンテーションから目的のスライドを取得し、先のプレゼンテーションのスライドコレクションの末尾にクローン
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // 先のプレゼンテーションをディスクに保存
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **別のプレゼンテーションの別の位置にスライドをクローン作成**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションの特定位置に挿入したい場合は、次の手順を実行します。

1. ソースプレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. 目的プレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
3. 目的プレゼンテーションの [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) クラスのインスタンスを取得します。  
4. [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) オブジェクトが公開する [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを呼び出し、ソースプレゼンテーションから取得したスライドと目的の位置インデックスをパラメーターとして渡します。  
5. 変更後の目的プレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのインデックス 0（位置 1）にあるスライドを目的プレゼンテーションのインデックス 1（位置 2）にクローンしました。
```java
// ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化
    Presentation destPres = new Presentation();
    try {
        // ソースプレゼンテーションから目的のスライドを取得し、先のプレゼンテーションのスライドコレクションの末尾にクローン
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // 先のプレゼンテーションをディスクに保存
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **別のプレゼンテーションの特定位置にスライドをクローン作成（マスタースライド付き）**
マスタースライドを持つスライドを別のプレゼンテーションにクローンするには、まずソースプレゼンテーションから目的プレゼンテーションへマスタースライドをクローンし、次にそのマスタースライドを使用してスライドをクローンします。[addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) は、ソースではなく目的プレゼンテーションのマスタースライドを受け取ります。以下の手順に従ってください。

1. ソースプレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. 目的プレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
3. クローン対象となるスライドとそのマスタースライドにアクセスします。  
4. 目的プレゼンテーションの [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトが公開する Masters コレクションを参照して、[IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) クラスのインスタンスを取得します。  
5. [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、ソース PPTX からクローンするマスターをパラメーターとして渡します。  
6. 目的プレゼンテーションの [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) クラスのインスタンスを取得します。  
7. [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、ソースプレゼンテーションから取得したスライドとクローンしたマスタースライドをパラメーターとして渡します。  
8. 変更後の目的プレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのインデックス 0 にあるマスタースライド付きスライドを、ソーススライドのマスターを使用して目的プレゼンテーションの末尾にクローンしました。
```java
// ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // スライドをクローンする先のプレゼンテーション用に Presentation クラスをインスタンス化
    Presentation destPres = new Presentation();
    try {
        // ソースプレゼンテーションのスライドコレクションから ISlide を取得し、
        // マスタースライドも取得
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // ソースプレゼンテーションから目的のマスタースライドを取得し、
        // 目的プレゼンテーションのマスターコレクションへ追加
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // ソースプレゼンテーションから目的のマスタースライドを取得し、
        // 目的プレゼンテーションのマスターコレクションへ追加
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // ソースプレゼンテーションから目的のスライドを、指定したマスターと共に、末尾に
        // 目的プレゼンテーションのスライドコレクションへクローン
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // 目的プレゼンテーションをディスクに保存
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **指定セクションの末尾にスライドをクローン作成**
同一プレゼンテーション内で別セクションにスライドをクローンして使用したい場合は、[addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) メソッドを使用します。Aspose.Slides for Android via Java を使用すると、最初のセクションからスライドをクローンし、同じプレゼンテーションの第二セクションに挿入できます。

以下のコードスニペットは、スライドをクローンして指定セクションに挿入する方法を示しています。
```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// ディスクに目的のプレゼンテーションを保存
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**スピーカーノートやレビューコメントもクローンされますか？**

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に[削除してください](/slides/ja/androidjava/presentation-notes/)。

**チャートおよびデータソースはどのように処理されますか？**

チャートオブジェクト、書式設定、埋め込みデータはコピーされます。チャートが外部ソース（例: OLE 埋め込みブック）にリンクされている場合、そのリンクは[OLE オブジェクト](/slides/ja/androidjava/manage-ole/)として保持されます。ファイル間で移動した後は、データの可用性とリフレッシュ動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。特定のスライドインデックスにクローンを挿入し、選択した[セクション](/slides/ja/androidjava/slide-section/)に配置できます。対象セクションが存在しない場合は、先に作成してからスライドを移動してください。