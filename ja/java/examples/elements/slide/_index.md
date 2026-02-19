---
title: スライド
type: docs
weight: 10
url: /ja/java/examples/elements/slide/
keywords:
- コード例
- スライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でスライドを制御: PPT、PPTX、ODP プレゼンテーション用に、作成、クローン、並び替え、サイズ変更、背景設定、トランジション適用を Java で行う。"
---
この記事では、**Aspose.Slides for Java** を使用してスライドを操作する方法を示す一連の例を提供します。`Presentation` クラスを使用してスライドの追加、アクセス、クローン作成、並び替え、削除を学びます。

以下の各例は、簡単な説明と Java のコードスニペットで構成されています。

## **スライドの追加**

新しいスライドを追加するには、まずレイアウトを選択する必要があります。この例では `Blank` レイアウトを使用し、プレゼンテーションに空のスライドを追加します。

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注:** 各スライドレイアウトはマスタースライドから派生しており、全体のデザインとプレースホルダー構造を定義します。下の画像は、PowerPoint におけるマスタースライドとそれに関連付けられたレイアウトの構成を示しています。

![マスタとレイアウトの関係](master-layout-slide.png)

## **インデックスでスライドにアクセス**

インデックスを使用してスライドにアクセスしたり、参照からスライドのインデックスを取得したりできます。これは、特定のスライドを反復処理したり変更したりする際に便利です。

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // 別の空のスライドを追加します。
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // インデックスでスライドにアクセスします。
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // 参照からスライドのインデックスを取得し、インデックスでアクセスします。
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **スライドのクローン作成**

この例では、既存のスライドをクローンする方法を示します。クローンされたスライドは自動的にスライドコレクションの末尾に追加されます。

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **スライドの順序変更**

スライドの順序を変更するには、スライドを新しいインデックスに移動します。この例では、クローンしたスライドを最初の位置に移動します。

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **スライドの削除**

スライドを削除するには、そのスライドを参照して `remove` を呼び出すだけです。この例では、2 番目のスライドを追加した後、元のスライドを削除し、新しいスライドだけが残ります。

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```