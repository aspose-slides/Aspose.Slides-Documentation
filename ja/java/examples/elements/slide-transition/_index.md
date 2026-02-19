---
title: スライド遷移
type: docs
weight: 110
url: /ja/java/examples/elements/slide-transition/
keywords:
- コード例
- スライド遷移
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でスライド遷移をマスターしましょう。Java のサンプルを使用して、PPT、PPTX、ODP プレゼンテーションの効果と期間を追加、カスタマイズ、シーケンス設定できます。"
---
この記事では、**Aspose.Slides for Java** を使用したスライド遷移効果とタイミングの適用方法を示します。

## **スライド遷移の追加**

最初のスライドにフェード遷移効果を適用します。

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // フェード遷移を適用します。
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **スライド遷移へのアクセス**

スライドに現在割り当てられている遷移タイプを読み取ります。

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // 遷移タイプにアクセスします。
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **スライド遷移の削除**

`None` にタイプを設定して、すべての遷移効果を削除します。

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // none に設定して遷移を削除します。
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **遷移期間の設定**

スライドが自動的に次に進むまでの表示時間を指定します。

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // ミリ秒単位です。
    } finally {
        presentation.dispose();
    }
}
```