---
title: スライド
type: docs
weight: 10
url: /ja/androidjava/examples/elements/slide/
keywords:
- コード例
- スライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android でスライドを制御します：Java を使用して PPT、PPTX、ODP プレゼンテーションの作成、クローン作成、順序変更、サイズ変更、背景設定、トランジション適用を行います。"
---
この記事では、**Aspose.Slides for Android via Java** を使用してスライドを操作する方法を示す一連の例を提供します。`Presentation` クラスを使用して、スライドの追加、取得、クローン作成、順序変更、削除方法を学びます。

以下の各例は、簡単な説明とその後に続く Java のコードスニペットで構成されています。

## **スライドを追加**

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

> 💡 **注意:** 各スライドレイアウトはマスタースライドから派生しており、全体のデザインとプレースホルダーの構造が定義されています。下の画像は、PowerPoint におけるマスタースライドとそれに関連するレイアウトの構成を示しています。

![マスターとレイアウトの関係](master-layout-slide.png)

## **インデックスでスライドにアクセス**

スライドはインデックスを使用してアクセスでき、また参照からスライドのインデックスを取得することもできます。これは特定のスライドを反復処理したり、変更したりする際に便利です。

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

## **スライドをクローン**

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

## **スライドの順序を変更**

スライドの順序は、スライドを新しいインデックスに移動させることで変更できます。この例では、クローンしたスライドを先頭に移動します。

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

## **スライドを削除**

スライドを削除するには、対象を参照して `remove` を呼び出すだけです。この例では、2 番目のスライドを追加した後、元のスライドを削除し、結果として新しいスライドだけが残ります。

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