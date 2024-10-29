---
title: プレゼンテーションのスライドにアクセスする
type: docs
weight: 20
url: /ja/java/access-slide-in-presentation/
keywords: "PowerPointプレゼンテーションにアクセス, スライドにアクセス, スライドプロパティを編集, スライド位置を変更, スライド番号を設定, インデックス, ID, 位置 Java, Aspose.Slides"
description: "Javaでインデックス、ID、または位置によってPowerPointスライドにアクセスします。スライドプロパティを編集します"
---

Aspose.Slidesを使用すると、インデックスまたはIDによってスライドにアクセスできます。

## **インデックスによるスライドにアクセス**

プレゼンテーション内のすべてのスライドは、0から始まるスライドの位置に基づいて数値的に配置されています。最初のスライドはインデックス0でアクセスでき、2番目のスライドはインデックス1で、などとなります。

プレゼンテーションファイルを表すPresentationクラスは、すべてのスライドを[ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/)コレクション（[ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/)オブジェクトのコレクション）として公開しています。このJavaコードは、インデックスを使用してスライドにアクセスする方法を示しています:

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
Presentation pres = new Presentation("demo.pptx");
try {
    // スライドインデックスを使用してスライドにアクセスします
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **IDによるスライドにアクセス**

プレゼンテーション内の各スライドには、関連付けられたユニークなIDがあります。[getSlideById](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideById-long-)メソッド（[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスによって公開）を使用して、そのIDをターゲットにできます。このJavaコードは、有効なスライドIDを提供し、[getSlideById](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideById-long-)メソッドを通じてそのスライドにアクセスする方法を示しています:

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
Presentation pres = new Presentation("demo.pptx");
try {
    // スライドIDを取得します
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // IDを通じてスライドにアクセスします
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **スライドの位置を変更する**

Aspose.Slidesを使用すると、スライドの位置を変更できます。たとえば、最初のスライドを2番目のスライドにすることができます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを使用して位置を変更したいスライドの参照を取得します。
1. [setSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#setSlideNumber-int-)プロパティを通じてスライドの新しい位置を設定します。
1. 修正されたプレゼンテーションを保存します。

このJavaコードは、位置1のスライドが位置2に移動される操作を示しています:

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
Presentation pres = new Presentation("Presentation.pptx");
try {
    // 位置が変更されるスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // スライドの新しい位置を設定します
    sld.setSlideNumber(2);
    
    // 修正されたプレゼンテーションを保存します
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

最初のスライドが2番目になり、2番目のスライドが1番目になりました。スライドの位置を変更すると、他のスライドは自動的に調整されます。

## **スライド番号を設定する**

[setFirstSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-)プロパティ（[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスによって公開）を使用すると、プレゼンテーションの最初のスライドに新しい番号を指定できます。この操作により、他のスライド番号が再計算されます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成します。
1. スライド番号を取得します。
1. スライド番号を設定します。
1. 修正されたプレゼンテーションを保存します。

このJavaコードは、最初のスライド番号を10に設定する操作を示しています:

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // スライド番号を取得します
    int firstSlideNumber = pres.getFirstSlideNumber();

    // スライド番号を設定します
    pres.setFirstSlideNumber(10);
	
    // 修正されたプレゼンテーションを保存します
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

最初のスライドをスキップしたい場合は、2番目のスライドから番号付けを開始できます（最初のスライドの番号付けを非表示にする）:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // プレゼンテーションの最初のスライドの番号を設定します
    presentation.setFirstSlideNumber(0);

    // すべてのスライドのスライド番号を表示します
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // 最初のスライドのスライド番号を非表示にします
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // 修正されたプレゼンテーションを保存します
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```