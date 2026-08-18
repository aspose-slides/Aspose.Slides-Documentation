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
description: "Aspose.Slides for Android を使用して PowerPoint スライドを複製します。明確な Java コード例に従い、数秒で PPT 作成を自動化し、手作業を排除します。"
---
## **はじめに**

クローンとは、何かを正確にコピーまたは複製するプロセスです。Aspose.Slides for Android via Java でも、任意のスライドをコピー（クローン）して、現在のプレゼンテーションまたは別の開いているプレゼンテーションに挿入することが可能です。スライドのクローン作成により、元のスライドを変更せずに開発者が操作できる新しいスライドが生成されます。スライドをクローンする方法にはいくつかのバリエーションがあります。

- プレゼンテーションの末尾にクローンを作成する。
- プレゼンテーション内の別の位置にクローンを作成する。
- 別のプレゼンテーションの末尾にクローンを作成する。
- 別のプレゼンテーションの別の位置にクローンを作成する。
- 別のプレゼンテーションの特定の位置にクローンを作成する。

Aspose.Slides for Android via Java では、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) オブジェクトが公開する (ISlide) オブジェクトのコレクションから、[addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) および [insertClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを使用して、上記のスライドクローン操作を実行できます。

## **プレゼンテーションの末尾にスライドをクローンする**
同じプレゼンテーション内で、既存のスライドの末尾にクローンを作成して使用したい場合は、以下の手順に従って [addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getSlides--) クラスのインスタンスを取得します。  
3. [ISlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getSlides--) オブジェクトが提供する [addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、クローン対象のスライドをパラメータとして渡します。  
4. 変更したプレゼンテーションファイルを書き出します。

以下の例では、プレゼンテーションの先頭（インデックス 0）にあるスライドをプレゼンテーションの末尾にクローンしています。

```java
import com.aspose.slides.*;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローン
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 変更されたプレゼンテーションをディスクに保存
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **プレゼンテーション内の別の位置にスライドをクローンする**
同じプレゼンテーション内の異なる位置にスライドをクローンしたい場合は、[insertClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) オブジェクトが公開する **Slides** コレクションを参照してクラスをインスタンス化します。  
3. [ISlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getSlides--) オブジェクトが提供する [insertClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを呼び出し、クローン対象のスライドと新しい位置のインデックスをパラメータとして渡します。  
4. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションのインデックス 1（位置 2）にあるスライドをインデックス 2（位置 3）へクローンしています。

```java
import com.aspose.slides.*;

// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 同じプレゼンテーション内のスライドコレクションを取得
    ISlideCollection slds = pres.getSlides();

    // 同じプレゼンテーション内の指定インデックスに目的のスライドをクローン
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 変更されたプレゼンテーションをディスクに保存
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **別のプレゼンテーションの末尾にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションの既存スライドの末尾に追加したい場合の手順です。

1. クローン元となるプレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. クローン先となるプレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
3. 目的プレゼンテーションの [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) オブジェクトが公開する **Slides** コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection) クラスのインスタンスを取得します。  
4. [ISlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getSlides--) オブジェクトが提供する [addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、元プレゼンテーションからのスライドをパラメータとして渡します。  
5. 変更した目的プレゼンテーションファイルを書き出します。

以下の例では、元プレゼンテーションの先頭インデックスにあるスライドを目的プレゼンテーションの末尾にクローンしています。

```java
import com.aspose.slides.*;

// ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
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

## **別のプレゼンテーションの別の位置にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションの特定位置に配置したい場合の手順です。

1. クローン元プレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. クローン先プレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
3. 目的プレゼンテーションの Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getSlides--) クラスのインスタンスを取得します。  
4. [ISlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getSlides--) オブジェクトが提供する [insertClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを呼び出し、元プレゼンテーションのスライドと目的インデックスをパラメータとして渡します。  
5. 変更した目的プレゼンテーションファイルを書き出します。

以下の例では、元プレゼンテーションのインデックス 0 にあるスライドを目的プレゼンテーションのインデックス 1（位置 2）へクローンしています。

```java
import com.aspose.slides.*;

// ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化
    Presentation destPres = new Presentation();
    try {
        // ソースプレゼンテーションから目的のスライドを取得し、先のプレゼンテーションの指定インデックスにクローン
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // 先のプレゼンテーションをディスクに保存
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **別のプレゼンテーションの特定位置にマスタースライド付きスライドをクローンする**
マスタースライドを持つスライドを別のプレゼンテーションへクローンする場合、まずソースプレゼンテーションから目的プレゼンテーションへマスタースライド自体をクローンする必要があります。その後、目的プレゼンテーションのマスタースライドを使用してスライドをクローンします。メソッド **addClone(ISlide, IMasterSlide, boolean)** は、ソースではなく目的プレゼンテーションのマスタースライドを受け取ります。以下の手順で実行してください。

1. ソースプレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. 目的プレゼンテーションを保持する [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
3. クローン対象のスライドとそのマスタースライドにアクセスします。  
4. 目的プレゼンテーションの [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) オブジェクトが公開する Masters コレクションを参照して、[IMasterSlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IMasterSlideCollection) クラスのインスタンスを取得します。  
5. [IMasterSlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IMasterSlideCollection) オブジェクトが提供する [addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、ソース PPTX からクローンするマスターをパラメータとして渡します。  
6. 目的プレゼンテーションの Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getSlides--) クラスのインスタンスを取得します。  
7. [ISlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation#getSlides--) オブジェクトが提供する [addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、ソースプレゼンテーションのスライドと先ほどクローンしたマスタースライドをパラメータとして渡します。  
8. 変更した目的プレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのインデックス 0 にあるマスタースライド付きスライドを、ソーススライドのマスターを使用して目的プレゼンテーションの末尾にクローンしています。

```java
import com.aspose.slides.*;

// ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // スライドをクローンする先のプレゼンテーション用に Presentation クラスをインスタンス化（スライドをクローンする場所）
    Presentation destPres = new Presentation();
    try {
        // ソースプレゼンテーションのスライドコレクションから ISlide を取得し、
        // マスタースライドも取得
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // ソースプレゼンテーションから目的のマスタースライドを取得し、
        // 先のプレゼンテーションのマスターコレクションにクローン
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // ソースプレゼンテーションから目的のスライドを取得し、目的のマスターと共に
        // 先のプレゼンテーションのスライドコレクションの末尾にクローン
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // 先のプレゼンテーションをディスクに保存
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **指定セクションの末尾にスライドをクローンする**
同一プレゼンテーション内で別セクションにスライドをクローンしたい場合は、[**addClone**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) メソッド（[**ISlideCollection**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlideCollection) インターフェイスが公開）を使用します。Aspose.Slides for Android via Java では、最初のセクションからスライドをクローンし、同じプレゼンテーションの第2セクションに挿入することが可能です。

次のコードスニペットは、スライドをクローンして指定セクションに挿入する方法を示しています。

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// 先のプレゼンテーションをディスクに保存
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **スライドサイズの一致を確認する**

別のプレゼンテーションにスライドをクローンする場合、目的プレゼンテーションのスライドサイズがソースと同じであることを確認してください。サイズが異なると、Aspose.Slides はクローンされたシェイプのサイズや位置を自動的に再スケーリングせず、元の座標と寸法のまま保持されます。その結果、コンテンツがずれたりスライドの境界を超えて表示されることがあります。

クローンする前に、マスターとスライドのサイズを合わせるには次のように設定します。

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

マスターとスライドをクローンする前に実行してください。

## **FAQ**

**スピーカーノートやレビュコメントもクローンされますか？**

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は挿入後に [削除してください](/slides/ja/androidjava/presentation-notes/)。

**グラフおよびデータソースはどのように扱われますか？**

グラフオブジェクト、書式設定、埋め込みデータはすべてコピーされます。外部ソース（例: OLE 埋め込みブック）にリンクされている場合、そのリンクは [OLE オブジェクト](/slides/ja/androidjava/manage-ole/) として保持されます。ファイル間で移動した後は、データの可用性と更新動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。特定のスライドインデックスにクローンを挿入し、任意の [セクション](/slides/ja/androidjava/slide-section/) に配置できます。対象セクションが存在しない場合は、先に作成してからスライドを移動してください。