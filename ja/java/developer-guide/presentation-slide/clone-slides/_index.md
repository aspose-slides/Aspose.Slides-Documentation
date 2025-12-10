---
title: Javaでプレゼンテーションスライドをクローン
linktitle: スライドをクローン
type: docs
weight: 35
url: /ja/java/clone-slides/
keywords:
- スライドをクローン
- スライドをコピー
- スライドを保存
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint スライドを迅速に複製します。明確なコード例に従って、数秒で PPT の作成を自動化し、手作業を排除しましょう。"
---

## **プレゼンテーション内のスライドのクローン作成**
クローンとは、何かの正確なコピーまたはレプリカを作るプロセスです。Aspose.Slides for Java では、任意のスライドのコピーまたはクローンを作成し、そのクローンしたスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することが可能です。スライドのクローン作成プロセスにより、元のスライドを変更せずに開発者が新しいスライドを修正できます。スライドをクローンする方法はいくつかあります。

- プレゼンテーション内の末尾にクローンする。
- プレゼンテーション内の別の位置にクローンする。
- 別のプレゼンテーションの末尾にクローンする。
- 別のプレゼンテーションの別の位置にクローンする。
- 別のプレゼンテーションの特定の位置にクローンする。

Aspose.Slides for Java では、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) オブジェクトが公開する (ISlide のコレクション) が、上記のスライドクローンの種類を実行するための [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) および [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを提供します。

## **プレゼンテーションの末尾にスライドをクローンする**
既存のスライドの末尾に同一プレゼンテーションファイル内でスライドをクローンして使用したい場合は、以下の手順に従って [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) オブジェクトが公開する Slides コレクションを参照して [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、クローンするスライドをパラメータとして渡します。
1. 変更されたプレゼンテーションファイルを書き込みます。

以下の例では、プレゼンテーションの最初の位置（ゼロインデックス）にあるスライドをプレゼンテーションの末尾にクローンしました。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローンします
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 変更されたプレゼンテーションをディスクに書き込みます
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **プレゼンテーション内の別の位置にスライドをクローンする**
同一プレゼンテーションファイル内で別の位置にスライドをクローンして使用したい場合は、[insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) オブジェクトが公開する [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) コレクションを参照してクラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) オブジェクトが公開する [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを呼び出し、クローンするスライドと新しい位置のインデックスをパラメータとして渡します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き込みます。

以下の例では、プレゼンテーションのゼロインデックス（位置 1）にあるスライドをインデックス 1（位置 2）にクローンしました。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローンします
    ISlideCollection slds = pres.getSlides();

    // 同じプレゼンテーション内の指定インデックスに目的のスライドをクローンします
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 変更されたプレゼンテーションをディスクに書き込みます
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **別のプレゼンテーションの末尾にスライドをクローンする**
別のプレゼンテーションファイルにスライドをクローンし、既存のスライドの末尾に追加したい場合は、次の手順で行います。

1. クローン元となるプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドを追加する宛先プレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 宛先プレゼンテーションの [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) コレクションを参照して [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、ソースプレゼンテーションからのスライドをパラメータとして渡します。
1. 変更された宛先プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションの最初のインデックスにあるスライドを宛先プレゼンテーションの末尾にクローンしました。
```java
// ソースプレゼンテーション ファイルを読み込むために Presentation クラスのインスタンスを作成します
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // スライドをクローンする先の PPTX 用に Presentation クラスのインスタンスを作成します
    Presentation destPres = new Presentation();
    try {
        // ソースプレゼンテーションから目的のスライドを取得し、宛先プレゼンテーションのスライドコレクションの末尾にクローンします
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // 宛先プレゼンテーションをディスクに書き込みます
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **別のプレゼンテーションの別の位置にスライドをクローンする**
別のプレゼンテーションファイルにスライドをクローンし、特定の位置に配置したい場合は、次の手順で行います。

1. クローン元となるプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドを追加するプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 宛先プレゼンテーションの Slides コレクションを参照して [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) クラスのインスタンスを作成します。
1. [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) オブジェクトが公開する [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを呼び出し、ソースプレゼンテーションからのスライドと目的の位置をパラメータとして渡します。
1. 変更された宛先プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションのゼロインデックスにあるスライドを宛先プレゼンテーションのインデックス 1（位置 2）にクローンしました。
```java
// ソースプレゼンテーション ファイルを読み込むために Presentation クラスのインスタンスを作成します
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // スライドをクローンする宛先 PPTX 用に Presentation クラスのインスタンスを作成します
    Presentation destPres = new Presentation();
    try {
        // ソースプレゼンテーションから目的のスライドを取得し、宛先プレゼンテーションのスライドコレクションの末尾にクローンします
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // 宛先プレゼンテーションをディスクに書き込みます
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **別のプレゼンテーションの特定の位置にスライドをクローンする**
マスタースライドを持つスライドを別のプレゼンテーションにクローンする場合は、まずソースプレゼンテーションから宛先プレゼンテーションへ目的のマスタースライドをクローンする必要があります。その後、マスタースライドを使用してスライドをクローンします。[**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) は宛先プレゼンテーションのマスタースライドを受け取ります。マスタースライド付きでスライドをクローンする手順は以下の通りです。

1. クローン元となるプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. クローン先となるプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. クローン対象のスライドとそのマスタースライドにアクセスします。
1. 宛先プレゼンテーションの [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) オブジェクトが公開する Masters コレクションを参照して [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) クラスをインスタンス化します。
1. [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、ソース PPTX からクローンするマスターをパラメータとして渡します。
1. 宛先プレゼンテーションの [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) オブジェクトが公開する Slides コレクションを参照して [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) クラスをインスタンス化します。
1. [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、ソースプレゼンテーションからのスライドとマスタースライドをパラメータとして渡します。
1. 変更された宛先プレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションのゼロインデックスにあるマスター付きスライドを、ソーススライドのマスターを使用して宛先プレゼンテーションの末尾にクローンしました。
```java
    // ソースプレゼンテーション ファイルを読み込むために Presentation クラスのインスタンスを作成します
    Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
    try {
        // スライドをクローンする宛先プレゼンテーション用に Presentation クラスのインスタンスを作成します（スライドをクローンする場所）
        Presentation destPres = new Presentation();
        try {
            // ソースプレゼンテーションのスライドコレクションから ISlide を取得し、
            // マスタースライド
            ISlide SourceSlide = srcPres.getSlides().get_Item(0);
            IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

            // ソースプレゼンテーションから目的のマスタースライドを取得し、
            // 宛先プレゼンテーションのマスターコレクションにクローンします
            IMasterSlideCollection masters = destPres.getMasters();
            IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

            // ソースプレゼンテーションから目的のマスタースライドを取得し、
            // 宛先プレゼンテーションのマスターコレクションにクローンします
            IMasterSlide iSlide = masters.addClone(SourceMaster);

            // ソースプレゼンテーションのスライドを、指定したマスタースライドとともに、
            // 宛先プレゼンテーションのスライドコレクションの末尾にクローンします
            ISlideCollection slds = destPres.getSlides();
            slds.addClone(SourceSlide, iSlide, true);

            // 宛先プレゼンテーションをディスクに保存します
            destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
        } finally {
            destPres.dispose();
        }
    } finally {
        srcPres.dispose();
    }
```


## **指定セクションの末尾にスライドをクローンする**
同一プレゼンテーション内で別のセクションの末尾にスライドをクローンしたい場合は、[**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) メソッドを使用します。Aspose.Slides for Java は、最初のセクションからスライドをクローンし、そのクローンしたスライドを同じプレゼンテーションの第2セクションに挿入することを可能にします。

以下のコードスニペットは、スライドをクローンし、指定されたセクションにクローンしたスライドを挿入する方法を示しています。
```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// ディスクに宛先プレゼンテーションを保存します
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**スピーカーノートやレビュアーコメントもクローンされますか？**

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に[削除する](/slides/ja/java/presentation-notes/)してください。

**チャートとそのデータソースはどのように扱われますか？**

チャートオブジェクト、書式設定、埋め込みデータはコピーされます。チャートが外部ソース（例: OLE 埋め込みワークブック）にリンクされている場合、そのリンクは[OLE object](/slides/ja/java/manage-ole/)として保持されます。ファイル間で移動した後は、データの可用性と更新動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。スライドのインデックスを指定してクローンを挿入し、選択した[section](/slides/ja/java/slide-section/)に配置できます。対象セクションが存在しない場合は、先に作成してからスライドを移動してください。