---
title: Android でプレゼンテーション スライドにアクセス
linktitle: スライドにアクセス
type: docs
weight: 20
url: /ja/androidjava/access-slide-in-presentation/
keywords:
- スライドにアクセス
- スライド インデックス
- スライド ID
- スライド 位置
- 位置の変更
- スライド プロパティ
- スライド 番号
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、PowerPoint および OpenDocument プレゼンテーションのスライドにアクセスし管理する方法を学びます。Java コード例で生産性を向上させましょう。"
---

Aspose.Slides では、スライドにインデックスまたは ID の 2 つの方法でアクセスできます。

## **インデックスでスライドにアクセス**

プレゼンテーション内のすべてのスライドは、スライドの位置に基づいて 0 から始まる数値で配置されます。最初のスライドはインデックス 0 で、2 番目のスライドはインデックス 1 でアクセスできます。以下同様です。

Presentation クラスは、プレゼンテーション ファイルを表し、すべてのスライドを [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) コレクション（[ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) オブジェクトのコレクション）として公開します。この Java コードは、インデックスでスライドにアクセスする方法を示しています:
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("demo.pptx");
try {
    // スライドインデックスを使用してスライドにアクセスします
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **ID でスライドにアクセス**

プレゼンテーション内の各スライドには、固有の ID が割り当てられています。ID を対象にするには、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスで公開されている [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) メソッドを使用します。この Java コードは、有効なスライド ID を指定して [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) メソッドでスライドにアクセスする方法を示しています:
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("demo.pptx");
try {
    // スライド ID を取得します
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // ID を使用してスライドにアクセスします
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **スライドの位置を変更**

Aspose.Slides では、スライドの位置を変更できます。たとえば、最初のスライドを 2 番目のスライドにすることができます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスで、位置を変更したいスライドの参照を取得します。
1. [setSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#setSlideNumber-int-) プロパティを使用してスライドの新しい位置を設定します。
1. 変更されたプレゼンテーションを保存します。

この Java コードは、位置 1 のスライドを位置 2 に移動する操作を示しています: 
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 位置を変更するスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // スライドの新しい位置を設定します
    sld.setSlideNumber(2);
    
    // 変更されたプレゼンテーションを保存します
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


最初のスライドが 2 番目になり、2 番目のスライドが最初になりました。スライドの位置を変更すると、他のスライドは自動的に調整されます。

## **スライド番号の設定**

[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスで公開されている [setFirstSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) プロパティを使用すると、プレゼンテーションの最初のスライドに新しい番号を指定できます。この操作により、他のスライド番号が再計算されます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライド番号を取得します。
1. スライド番号を設定します。
1. 変更されたプレゼンテーションを保存します。

この Java コードは、最初のスライド番号を 10 に設定する操作を示しています: 
```java
// プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // スライド番号を取得します
    int firstSlideNumber = pres.getFirstSlideNumber();

    // スライド番号を設定します
    pres.setFirstSlideNumber(10);
	
    // 変更されたプレゼンテーションを保存します
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


最初のスライドをスキップしたい場合は、2 番目のスライドから番号付けを開始し（最初のスライドの番号は非表示に）次のようにできます:
```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // 最初のプレゼンテーション スライドの番号を設定します
    presentation.setFirstSlideNumber(0);

    // すべてのスライドのスライド番号を表示します
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // 最初のスライドのスライド番号を非表示にします
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // 変更されたプレゼンテーションを保存します
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**ユーザーが見るスライド番号は、コレクションのゼロベースインデックスと一致しますか？**

スライドに表示される番号は任意の値（例: 10）から開始でき、インデックスと一致する必要はありません。この関係は、プレゼンテーションの [first slide number](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) 設定によって制御されます。

**非表示スライドはインデックスに影響しますか？**

はい。非表示スライドはコレクション内に残り、インデックス計算に含まれます。「非表示」は表示上のことであり、コレクション内での位置には影響しません。

**他のスライドが追加または削除されたときに、スライドのインデックスは変わりますか？**

はい。インデックスは常にスライドの現在の順序を反映し、挿入、削除、移動操作が行われるたびに再計算されます。