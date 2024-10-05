---
title: スライドのクローン
type: docs
weight: 35
url: /java/clone-slides/
---


## **プレゼンテーション内のスライドのクローン**
クローンとは、何かの正確なコピーまたはレプリカを作成するプロセスです。Aspose.Slides for Javaでは、任意のスライドのコピーまたはクローンを作成し、そのクローンを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することが可能です。スライドのクローン作成プロセスでは、新しいスライドが作成され、開発者が元のスライドを変更することなく修正できるようになります。スライドをクローンする方法はいくつかあります：

- プレゼンテーションの最後にクローン。
- プレゼンテーション内の別の位置にクローン。
- 別のプレゼンテーションの最後にクローン。
- 別のプレゼンテーションの別の位置にクローン。
- 別のプレゼンテーションの特定の位置にクローン。

Aspose.Slides for Javaでは、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)オブジェクトによって公開される[ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)オブジェクトのコレクション（ISlideCollection）が、上記のタイプのスライドクローン作成を実行するために[addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドおよび[insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)メソッドを提供します。

## **プレゼンテーション内の最後にクローン**
スライドをクローンし、既存のスライドの最後に同じプレゼンテーションファイル内で使用したい場合は、以下の手順に従って[addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドを使用してください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)オブジェクトによって公開されるスライドコレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)クラスをインスタンス化します。
1. [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)オブジェクトによって公開される[addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドを呼び出し、クローンするスライドを[addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドへのパラメータとして渡します。
1. 修正したプレゼンテーションファイルを書き込みます。

以下の例では、プレゼンテーションの最初の位置（ゼロインデックス）にあるスライドをプレゼンテーションの最後にクローンしました。

```java
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 同じプレゼンテーション内のスライドのコレクションの最後に目的のスライドをクローン
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 修正したプレゼンテーションをディスクに書き込み
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **プレゼンテーション内の別の位置にクローン**
スライドをクローンし、同じプレゼンテーションファイル内の別の位置で使用したい場合は、[insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)メソッドを使用します：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)オブジェクトによって公開される[**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)コレクションを参照してクラスをインスタンス化します。
1. [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)オブジェクトによって公開される[insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)メソッドを呼び出し、クローンするスライドと新しい位置のインデックスを[insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)メソッドへのパラメータとして渡します。
1. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、プレゼンテーションのゼロインデックス（位置1）にあるスライドをインデックス1（位置2）にクローンしました。

```java
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 同じプレゼンテーション内のスライドのコレクションの最後に目的のスライドをクローン
    ISlideCollection slds = pres.getSlides();

    // 指定されたインデックスに同じプレゼンテーション内で目的のスライドをクローン
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 修正したプレゼンテーションをディスクに書き込み
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **別のプレゼンテーションの最後にクローン**
スライドを1つのプレゼンテーションから別のプレゼンテーションファイルにクローンし、既存のスライドの最後に使用したい場合：

1. スライドをクローンするプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドが追加される宛先プレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 宛先プレゼンテーションのPresentationオブジェクトによって公開される[**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)コレクションを参照して[ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection)クラスをインスタンス化します。
1. [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)オブジェクトによって公開される[addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドを呼び出し、ソースプレゼンテーションから取得したスライドを[addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドへのパラメータとして渡します。
1. 修正した宛先プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションの最初のインデックスからスライドを宛先プレゼンテーションの最後にクローンしました。

```java
// ソースプレゼンテーションファイルを読み込むためのPresentationクラスをインスタンス化
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // クローン先のPPTX用のPresentationクラスをインスタンス化（ここにスライドをクローン）
    Presentation destPres = new Presentation();
    try {
        // ソースプレゼンテーションから目的のスライドを宛先プレゼンテーション内のスライドのコレクションの最後にクローン
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // 宛先プレゼンテーションをディスクに書き込み
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **別のプレゼンテーションの別の位置にクローン**
スライドを1つのプレゼンテーションから別のプレゼンテーションファイルにクローンし、特定の位置で使用したい場合：

1. スライドをクローンするソースプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドを追加するプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 宛先プレゼンテーションのPresentationオブジェクトによって公開されるSlidesコレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)クラスをインスタンス化します。
1. [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)オブジェクトによって公開される[insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)メソッドを呼び出し、ソースプレゼンテーションからのスライドと必要な位置を[insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)メソッドへのパラメータとして渡します。
1. 修正した宛先プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションのゼロインデックスからスライドを宛先プレゼンテーションのインデックス1（位置2）にクローンしました。

```java
// ソースプレゼンテーションファイルを読み込むためのPresentationクラスをインスタンス化
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // クローン先のPPTX用のPresentationクラスをインスタンス化（ここにスライドをクローン）
    Presentation destPres = new Presentation();
    try {
        // ソースプレゼンテーションから宛先プレゼンテーション内のスライドのコレクションの終了に目的のスライドをクローン
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // 宛先プレゼンテーションをディスクに書き込み
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **別のプレゼンテーションの特定の位置にクローン**
スライドをマスタースライドと共に1つのプレゼンテーションから別のプレゼンテーションにクローンし使用する必要がある場合、最初にソースプレゼンテーションから目的のマスタースライドを宛先プレゼンテーションにクローンする必要があります。その後、そのマスタースライドを使用してマスタースライド付きのスライドをクローンする必要があります。[**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)は、ソースプレゼンテーションではなく宛先プレゼンテーションからのマスタースライドを期待します。マスターを持つスライドをクローンするには、以下の手順に従ってください：

1. スライドをクローンするソースプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドをクローンする宛先プレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. クローンするスライドとマスタースライドにアクセスします。
1. 宛先プレゼンテーションの[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)オブジェクトによって公開されるマスターコレクションを参照して、[IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)クラスをインスタンス化します。
1. [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)オブジェクトによって公開される[addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドを呼び出し、クローンするためのソースPPTXのマスターを[addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドへのパラメータとして渡します。
1. 宛先プレゼンテーションのPresentationオブジェクトによって公開されるSlidesコレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)クラスをインスタンス化します。
1. [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)オブジェクトによって公開される[addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドを呼び出し、クローンするためのソースプレゼンテーションのスライドとマスタースライドを[addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドへのパラメータとして渡します。
1. 修正した宛先プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションのゼロインデックスにあるマスタースライド付きのスライドを宛先プレゼンテーションの最後にソーススライドのマスターを使用してクローンしました。

```java
// ソースプレゼンテーションファイルを読み込むためのPresentationクラスをインスタンス化
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // クローン先のプレゼンテーション（ここにスライドをクローン）用のPresentationクラスをインスタンス化
    Presentation destPres = new Presentation();
    try {
        // ソースプレゼンテーションのスライドコレクションからISlideをインスタンス化し、マスタースライドと共に取得
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // ソースプレゼンテーションから宛先プレゼンテーションのマスターのコレクションへの目的のマスタースライドをクローン
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // ソースプレゼンテーションのマスタースライドを宛先プレゼンテーションのマスターのコレクションにクローン
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // ソースプレゼンテーションの目的のスライドを宛先プレゼンテーションのスライドのコレクションの最後にクローン
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // 宛先プレゼンテーションをディスクに保存
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **指定されたセクションの最後にクローン**
スライドをクローンし、同じプレゼンテーションファイル内で異なるセクションで使用したい場合は、[**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)メソッドを使用します。[**ISlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection)インターフェースによって公開されるメソッドを使用して、Aspose.Slides for Javaでは最初のセクションからスライドをクローンし、そのクローンを同じプレゼンテーションの2番目のセクションに挿入することができます。

以下のコードスニペットでは、スライドをクローンしてクローンしたスライドを指定されたセクションに挿入する方法を示します。

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("セクション 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("セクション 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// 宛先プレゼンテーションをディスクに保存
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```