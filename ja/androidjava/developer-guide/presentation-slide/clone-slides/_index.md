---
title: スライドをクローンする
type: docs
weight: 35
url: /androidjava/clone-slides/
---


## **プレゼンテーション内のスライドをクローンする**
クローンは、何かの正確なコピーまたはレプリカを作成するプロセスです。Aspose.Slides for Android via Javaを使用すると、任意のスライドのコピーまたはクローンを作成し、そのクローンされたスライドを現在のプレゼンテーションや他の開いているプレゼンテーションに挿入することが可能です。スライドクローンのプロセスは、新しいスライドを作成し、開発者が元のスライドを変更せずにそれを修正できるようにします。スライドをクローンする方法はいくつかあります：

- プレゼンテーション内の最後にクローンする。
- プレゼンテーション内の別の位置にクローンする。
- 別のプレゼンテーションの最後にクローンする。
- 別のプレゼンテーションの別の位置にクローンする。
- 別のプレゼンテーションの特定の位置にクローンする。

Aspose.Slides for Android via Javaでは、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)オブジェクトによって公開されている（[ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide)オブジェクトのコレクション）が、上記のタイプのスライドクローンを実行するために[addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)および[insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)メソッドを提供します。

## **プレゼンテーション内の最後にクローンする**
スライドをクローンし、既存のスライドの最後に同じプレゼンテーションファイル内で使用したい場合は、以下の手順に従って[addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドを使用します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)オブジェクトによって公開されたスライドコレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)オブジェクトによって公開されている[addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドを呼び出し、クローンされるスライドを[addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドのパラメーターとして渡します。
1. 修正されたプレゼンテーションファイルを書き込みます。

以下の例では、プレゼンテーションの最初の位置（ゼロインデックス）にあるスライドをプレゼンテーションの最後にクローンしました。

```java
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 同じプレゼンテーション内のスライドのコレクションの最後に目的のスライドをクローン
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 修正されたプレゼンテーションをディスクに保存
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **プレゼンテーション内の別の位置にクローンする**
スライドをクローンし、同じプレゼンテーションファイル内で別の位置に使用したい場合は、[insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)メソッドを使用します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)オブジェクトによって公開された[**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)コレクションを参照して、クラスをインスタンス化します。
1. [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)オブジェクトによって公開されている[insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)メソッドを呼び出し、新しい位置のインデックスとともにクローンされるスライドを[insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)メソッドにパラメーターとして渡します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、プレゼンテーションのゼロインデックス（位置1）にあるスライドをインデックス1（位置2）のプレゼンテーションにクローンしました。

```java
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 同じプレゼンテーション内のスライドのコレクションに目的のスライドをクローン
    ISlideCollection slds = pres.getSlides();

    // 同じプレゼンテーション内の指定されたインデックスに目的のスライドをクローン
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 修正されたプレゼンテーションをディスクに保存
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **別のプレゼンテーションの最後にクローンする**
一つのプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの既存のスライドの最後に使用する必要がある場合：

1. スライドをクローンする元のプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドを追加する宛先プレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 宛先プレゼンテーションのPresentationオブジェクトによって公開された[**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)クラスのインスタンスを作成します。
1. ソースプレゼンテーションからのスライドを[addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドのパラメーターとして渡し、[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)オブジェクトによって公開されている[addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドを呼び出します。
1. 修正された宛先プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションの最初のインデックスからスライドを宛先プレゼンテーションの最後にクローンしました。

```java
// ソースプレゼンテーションファイルを読み込むためにPresentationクラスをインスタンス化
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // スライドをクローンするための宛先PPTX用のPresentationクラスをインスタンス化
    Presentation destPres = new Presentation();
    try {
        // ソースプレゼンテーションからスライドをクローンするために、目的のスライドを宛先プレゼンテーションのスライドのコレクションの最後にクローン
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // 宛先プレゼンテーションをディスクに保存
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **別のプレゼンテーション内の別の位置にクローンする**
一つのプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイル内の特定の位置で使用する必要がある場合：

1. スライドをクローンする元のプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドが追加されるプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 宛先プレゼンテーションのPresentationオブジェクトによって公開されたスライドコレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)オブジェクトによって公開されている[insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)メソッドを呼び出し、ソースプレゼンテーションのスライドと一緒に希望する位置をパラメーターとして[insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)メソッドに渡します。
1. 修正された宛先プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションのゼロインデックスからスライドを宛先プレゼンテーションのインデックス1（位置2）にクローンしました。

```java
// ソースプレゼンテーションファイルを読み込むためにPresentationクラスをインスタンス化
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // スライドをクローンするための宛先PPTX用のPresentationクラスをインスタンス化
    Presentation destPres = new Presentation();
    try {
        // ソースプレゼンテーションからスライドを宛先プレゼンテーションのスライドのコレクションの最後にクローン
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // 宛先プレゼンテーションをディスクに保存
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **別のプレゼンテーションの特定の位置にクローンする**
マスター スライドを持つスライドをワンプレゼンテーションから別のプレゼンテーションにクローンする必要がある場合、最初にソースプレゼンテーションから宛先プレゼンテーションに目的のマスタースライドをクローンする必要があります。その後、そのマスタースライドを使用してマスタースライドを持つスライドをクローンできます。[**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)は、ソースプレゼンテーションからではなく、宛先プレゼンテーションからのマスタースライドを期待します。マスターを持つスライドをクローンするには、以下の手順に従ってください：

1. スライドをクローンする元のプレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. スライドがクローンされる宛先プレゼンテーションを含む[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. クローンされるスライドとマスタースライドにアクセスします。
1. 宛先プレゼンテーションの[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)オブジェクトによって公開されたマスター コレクションを参照して、[IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)クラスのインスタンスを作成します。
1. [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection)オブジェクトによって公開される[addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドを呼び出し、クローンするソースPPTXからのマスターを[addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドのパラメーターとして渡します。
1. 宛先プレゼンテーションオブジェクトのスライドコレクションを参照して[ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)オブジェクトによって公開される[addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドを呼び出し、ソースプレゼンテーションからのスライドとマスター スライドをパラメーターとして[addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)メソッドに渡します。
1. 修正された宛先プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションのゼロインデックスにあるマスターを持つスライドを宛先プレゼンテーションの最後にホストスライドを使用してクローンしました。

```java
// ソースプレゼンテーションファイルを読み込むためにPresentationクラスをインスタンス化
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // スライドをクローンするための宛先プレゼンテーション用のPresentationクラスをインスタンス化
    Presentation destPres = new Presentation();
    try {
        // ソースプレゼンテーションのスライドのコレクションからISlideをインスタンス化し、
        // マスタースライドも取得します
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // ソースプレゼンテーションから宛先プレゼンテーションのマスター コレクションにマスタースライドをクローン
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // ソースプレゼンテーションから宛先プレゼンテーションにマスタースライドをクローン
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // ソースプレゼンテーションから目的のマスターを持つスライドを宛先プレゼンテーションのスライドのコレクションの最後にクローン
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

## **指定したセクションの最後にクローンする**
スライドをクローンし、同じプレゼンテーションファイル内で別のセクションで使用したい場合は、[**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)メソッドを使用します。[**ISlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)インターフェースによって公開されたメソッドです。Aspose.Slides for Android via Javaにより、最初のセクションからスライドをクローンし、その後、同じプレゼンテーションの2番目のセクションにそのクローンされたスライドを挿入することが可能です。

以下のコードスニペットは、スライドをクローンして、指定されたセクションにクローンしたスライドを挿入する方法を示しています。

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// 宛先プレゼンテーションをディスクに保存
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```