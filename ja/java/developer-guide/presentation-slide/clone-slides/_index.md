---
title: Java でプレゼンテーション スライドをクローンする
linktitle: スライドをクローン
type: docs
weight: 35
url: /ja/java/clone-slides/
keywords:
- スライドをクローンする
- スライドをコピーする
- スライドを保存する
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint スライドを迅速に複製します。明確なコード例に従って、数秒で PPT 作成を自動化し、手作業を削減します。"
---
## **はじめに**

クローンとは、何かを完全に同一のコピーまたは複製として作成するプロセスです。Aspose.Slides for Java は、任意のスライドのコピーまたはクローンを作成し、そのクローン化されたスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入できるようにします。スライドのクローン作成プロセスは、新しいスライドを生成し、元のスライドを変更せずに開発者が修正できるようにします。スライドをクローンする方法はいくつかあります。

- プレゼンテーション内の末尾にクローンする。
- プレゼンテーション内の別の位置にクローンする。
- 別のプレゼンテーションの末尾にクローンする。
- 別のプレゼンテーションの別の位置にクローンする。
- マスタースライドと共に別のプレゼンテーションにクローンする。

Aspose.Slides for Java では、[Presentation] オブジェクトが公開する ([ISlide] オブジェクトのコレクション) が、上記のスライドクローンの種類を実行するための [addClone] と [insertClone] メソッドを提供します。

## **プレゼンテーションの末尾にスライドをクローンする**
同じプレゼンテーションファイル内で既存のスライドの末尾にスライドをクローンして使用したい場合は、以下の手順に従って [addClone] メソッドを使用します。

1. [Presentation] クラスのインスタンスを作成します。
1. [Presentation] オブジェクトが公開する Slides コレクションを参照して [ISlideCollection] クラスのインスタンスを作成します。
1. [ISlideCollection] オブジェクトが公開する [addClone] メソッドを呼び出し、クローン対象のスライドをパラメーターとして渡します。
1. 変更されたプレゼンテーションファイルを書き出します。

以下の例では、プレゼンテーションの最初の位置（ゼロインデックス）にあるスライドをプレゼンテーションの末尾にクローンしました。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローンします
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 変更されたプレゼンテーションをディスクに保存します
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **プレゼンテーション内の別の位置にスライドをクローンする**
同じプレゼンテーションファイル内で別の位置にスライドをクローンして使用したい場合は、[insertClone] メソッドを使用します。

1. [Presentation] クラスのインスタンスを作成します。
1. [Presentation] オブジェクトが公開する **Slides** コレクションを参照してクラスのインスタンスを作成します。
1. [ISlideCollection] オブジェクトが公開する [insertClone] メソッドを呼び出し、クローン対象のスライドと新しい位置のインデックスをパラメーターとして渡します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションのインデックス 1（位置 2）にあるスライドをインデックス 2（位置 3）にクローンしました。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // プレゼンテーション内のスライド コレクションを取得します
    ISlideCollection slds = pres.getSlides();

    // 同じプレゼンテーション内の指定インデックスに目的のスライドをクローンします
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 変更されたプレゼンテーションをディスクに保存します
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **別のプレゼンテーションの末尾にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの既存スライドの末尾に使用する必要がある場合は、以下を実行します。

1. スライドをクローン元とするプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
1. スライドを追加する先のプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
1. 目的のプレゼンテーションの [Presentation] オブジェクトが公開する **Slides** コレクションを参照して [ISlideCollection] クラスのインスタンスを作成します。
1. [ISlideCollection] オブジェクトが公開する [addClone] メソッドを呼び出し、元プレゼンテーションからのスライドをパラメーターとして渡します。
1. 変更された目的のプレゼンテーションファイルを書き出します。

以下の例では、元プレゼンテーションの最初のインデックスにあるスライドを目的のプレゼンテーションの末尾にクローンしました。

```java
import com.aspose.slides.*;

// ソース プレゼンテーション ファイルを読み込むための Presentation クラスのインスタンスを作成します
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // スライドをクローンする先の PPTX 用に Presentation クラスのインスタンスを作成します
    Presentation destPres = new Presentation();
    try {
        // ソース プレゼンテーションから目的のスライドを取得し、宛先プレゼンテーションのスライドコレクションの末尾にクローンします
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // 宛先プレゼンテーションをディスクに保存します
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **別のプレゼンテーションの別の位置にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの特定の位置に使用する必要がある場合は、以下を実行します。

1. スライドをクローン元とするプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
1. スライドを追加する先のプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
1. 目的のプレゼンテーションの [Presentation] オブジェクトが公開する Slides コレクションを参照して [ISlideCollection] クラスのインスタンスを作成します。
1. [ISlideCollection] オブジェクトが公開する [insertClone] メソッドを呼び出し、元プレゼンテーションからのスライドと目的の位置をパラメーターとして渡します。
1. 変更された目的のプレゼンテーションファイルを書き出します。

以下の例では、元プレゼンテーションのゼロインデックスにあるスライドを目的のプレゼンテーションのインデックス 1（位置 2）にクローンしました。

```java
import com.aspose.slides.*;

// ソース プレゼンテーション ファイルを読み込むために Presentation クラスのインスタンスを作成します
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // スライドをクローンする先の PPTX 用に Presentation クラスのインスタンスを作成します
    Presentation destPres = new Presentation();
    try {
        // ソース プレゼンテーションから目的のスライドを取得し、宛先プレゼンテーションの指定インデックスにクローンします
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // 宛先プレゼンテーションをディスクに保存します
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **マスタースライド付きのスライドを別のプレゼンテーションにクローンする**
あるプレゼンテーションからスライドとマスタースライドをクローンし、別のプレゼンテーションで使用するには、まず元プレゼンテーションから目的のマスタースライドを目的のプレゼンテーションにクローンする必要があります。その後、そのマスタースライドを使用してスライドをクローンします。 [**addClone(ISlide, IMasterSlide, boolean)**] は、元プレゼンテーションではなく目的のプレゼンテーションのマスタースライドを受け取ります。マスタースライド付きでスライドをクローンするには、以下の手順に従ってください。

1. スライドをクローン元とするプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
1. スライドをクローン先とするプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
1. クローン対象のスライドとそのマスタースライドにアクセスします。
1. 目的のプレゼンテーションの [Presentation] オブジェクトが公開する Masters コレクションを参照して [IMasterSlideCollection] クラスのインスタンスを作成します。
1. [IMasterSlideCollection] オブジェクトが公開する [addClone] メソッドを呼び出し、元 PPTX からクローンするマスターをパラメーターとして渡します。
1. 目的のプレゼンテーションの [Presentation] オブジェクトが公開する Slides コレクションを参照して [ISlideCollection] クラスのインスタンスを作成します。
1. [ISlideCollection] オブジェクトが公開する [addClone] メソッドを呼び出し、元プレゼンテーションからのスライドとマスタースライドをパラメーターとして渡します。
1. 変更された目的のプレゼンテーションファイルを書き出します。

以下の例では、元プレゼンテーションのゼロインデックスにあるスライドとマスターを、目的のプレゼンテーションの末尾にクローンしました。

```java
import com.aspose.slides.*;

// ソース プレゼンテーション ファイルを読み込むために Presentation クラスのインスタンスを作成します
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // スライドをクローンする先のプレゼンテーション用に Presentation クラスのインスタンスを作成します
    Presentation destPres = new Presentation();
    try {
        // ソース プレゼンテーションのスライド コレクションから ISlide を取得し、
        // マスタースライドも取得します
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // ソース プレゼンテーションから目的のマスタースライドを取得し、宛先プレゼンテーションのマスター コレクションにクローンします
        // 宛先プレゼンテーションへ
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // ソース プレゼンテーションの目的スライドを、取得したマスターと共に、宛先プレゼンテーションのスライド コレクションの末尾にクローンします
        // 宛先プレゼンテーションのスライド コレクションへ
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

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
同じプレゼンテーションファイル内で別のセクションにスライドをクローンして使用したい場合は、[**addClone**] メソッドを [**ISlideCollection**] インターフェイスが提供します。Aspose.Slides for Java は、最初のセクションからスライドをクローンし、同じプレゼンテーションの第二セクションに挿入できるようにします。

以下のコードスニペットは、スライドをクローンして指定セクションに挿入する方法を示します。

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // 宛先プレゼンテーションをディスクに保存します
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **スライドサイズの一致を保証する**

別のプレゼンテーションにスライドをクローンする際は、宛先プレゼンテーションのスライドサイズが元プレゼンテーションと同じであることを確認してください。サイズが異なる場合、Aspose.Slides はクローンされた形状のサイズを自動的に再スケーリングせず、元の座標と寸法が保持されるため、内容がずれたりスライド境界を超えて表示される可能性があります。

マスターとスライドをクローンする前に、宛先プレゼンテーションのスライドサイズを元に合わせて設定できます。

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

マスターとスライドをクローンする前にこれを実行してください。

## **FAQ**

**スピーカーノートとレビュアーコメントはクローンされますか？**

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に [remove them](/slides/ja/java/presentation-notes/) を実行してください。

**チャートとそのデータソースはどう処理されますか？**

チャートオブジェクト、書式設定、埋め込みデータはコピーされます。チャートが外部ソース（例: OLE 埋め込みワークブック）にリンクされている場合、そのリンクは [OLE object](/slides/ja/java/manage-ole/) として保持されます。ファイル間で移動した後は、データの可用性とリフレッシュ動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。特定のスライドインデックスにクローンを挿入し、選択した [section](/slides/ja/java/slide-section/) に配置できます。対象セクションが存在しない場合は、まず作成し、その後スライドを移動してください。