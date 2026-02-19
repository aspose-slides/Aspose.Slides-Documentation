---
title: レイアウト スライド
type: docs
weight: 20
url: /ja/java/examples/elements/layout-slide/
keywords:
- コード例
- レイアウト スライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のマスターレイアウト スライド: PPT、PPTX、ODP プレゼンテーション向けの Java サンプルで、スライド レイアウト、プレースホルダー、マスターを選択、適用、カスタマイズできます。"
---
この記事では、Aspose.Slides for Java における **Layout Slides** の使用方法を示します。レイアウト スライドは、通常のスライドが継承するデザインと書式を定義します。レイアウト スライドを追加、アクセス、クローン、削除でき、未使用のレイアウト スライドをクリーンアップしてプレゼンテーションのサイズを削減することもできます。

## **レイアウト スライドを追加**

再利用可能な書式を定義するために、カスタム レイアウト スライドを作成できます。たとえば、このレイアウトを使用するすべてのスライドに表示されるテキスト ボックスを追加することができます。

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // 空白のレイアウトタイプとカスタム名でレイアウト スライドを作成します。
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // レイアウト スライドにテキスト ボックスを追加します。
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // このレイアウトを使用して 2 枚のスライドを追加します。両方ともレイアウトからテキストを継承します。
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** レイアウト スライドは個々のスライドのテンプレートとして機能します。共通要素を一度定義すれば、複数のスライドで再利用できます。

> 💡 **Note 2:** レイアウト スライドにシェイプやテキストを追加すると、そのレイアウトに基づくすべてのスライドがこの共有コンテンツを自動的に表示します。以下のスクリーンショットは、同じレイアウト スライドからテキスト ボックスを継承した 2 つのスライドを示しています。

![レイアウト コンテンツを継承するスライド](layout-slide-result.png)

## **レイアウト スライドにアクセス**

レイアウト スライドはインデックスまたはレイアウト タイプ（例: `Blank`、`Title`、`SectionHeader` など）でアクセスできます。

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // インデックスでレイアウト スライドにアクセスします。
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // タイプでレイアウト スライドにアクセスします。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **レイアウト スライドを削除**

不要になった特定のレイアウト スライドを削除できます。

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // タイプでレイアウト スライドを取得して削除します。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **未使用のレイアウト スライドを削除**

プレゼンテーションのサイズを削減するために、通常のスライドで使用されていないレイアウト スライドを削除したい場合があります。

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // 自動的に、どのスライドからも参照されていないすべてのレイアウト スライドを削除します。
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **レイアウト スライドをクローン**

`addClone` メソッドを使用してレイアウト スライドを複製できます。

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // タイプで既存のレイアウト スライドを取得します。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // レイアウト スライドをコレクションの末尾にクローンします。
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** レイアウト スライドは、スライド全体で一貫した書式を管理するための強力なツールです。Aspose.Slides は、レイアウト スライドの作成、管理、最適化を完全に制御できます。