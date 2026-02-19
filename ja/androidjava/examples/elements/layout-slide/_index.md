---
title: レイアウト スライド
type: docs
weight: 20
url: /ja/androidjava/examples/elements/layout-slide/
keywords:
- コード例
- レイアウト スライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides のマスターレイアウト スライド: Java のサンプルを使用して、PPT、PPTX、ODP プレゼンテーション向けにスライド レイアウト、プレースホルダー、マスターを選択、適用、カスタマイズします。"
---
この記事では、Java 経由で Android 用 Aspose.Slides の **Layout Slides** の操作方法を示します。レイアウト スライドは、通常のスライドが継承するデザインと書式を定義します。レイアウト スライドを追加、アクセス、クローン、削除でき、未使用のレイアウト スライドをクリーンアップしてプレゼンテーションのサイズを縮小することもできます。

## **レイアウト スライドの追加**

再利用可能な書式を定義するカスタム レイアウト スライドを作成できます。たとえば、このレイアウトを使用するすべてのスライドに表示されるテキスト ボックスを追加することができます。

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // 空白のレイアウトタイプとカスタム名でレイアウトスライドを作成します。
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // レイアウトスライドにテキストボックスを追加します。
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // このレイアウトを使用してスライドを 2 枚追加します。両方ともレイアウトからテキストを継承します。
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** レイアウト スライドは個々のスライドのテンプレートとして機能します。共通要素を一度定義すれば、複数のスライドで再利用できます。

> 💡 **Note 2:** レイアウト スライドに図形やテキストを追加すると、そのレイアウトに基づくすべてのスライドがこの共有コンテンツを自動的に表示します。
> 以下のスクリーンショットは、同じレイアウト スライドからテキスト ボックスを継承した 2 つのスライドを示しています。

![レイアウト コンテンツを継承するスライド](layout-slide-result.png)

## **レイアウト スライドへのアクセス**

レイアウト スライドはインデックスまたはレイアウト タイプ（例: `Blank`, `Title`, `SectionHeader` など）でアクセスできます。

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // インデックスでレイアウトスライドにアクセスします。
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // タイプでレイアウトスライドにアクセスします。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **レイアウト スライドの削除**

必要なくなった特定のレイアウト スライドを削除できます。

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // タイプでレイアウトスライドを取得し、削除します。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **未使用レイアウト スライドの削除**

プレゼンテーションのサイズを縮小するため、通常のスライドで使用されていないレイアウト スライドを削除したい場合があります。

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // 参照されていないすべてのレイアウトスライドを自動的に削除します。
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **レイアウト スライドのクローン**

`addClone` メソッドを使用してレイアウト スライドを複製できます。

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // タイプで既存のレイアウトスライドを取得します。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // レイアウトスライドをコレクションの末尾にクローンします。
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** レイアウト スライドはスライド全体の一貫した書式管理に役立つ強力なツールです。Aspose.Slides はレイアウト スライドの作成、管理、最適化を完全にコントロールできます。