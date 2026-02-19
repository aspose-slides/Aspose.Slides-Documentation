---
title: スライド トランジション
type: docs
weight: 110
url: /ja/androidjava/examples/elements/slide-transition/
keywords:
- コード例
- スライド トランジション
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android でスライド トランジションをマスターしましょう。Java の例を使用して、PPT、PPTX、ODP プレゼンテーション向けに効果と期間の追加、カスタマイズ、シーケンス設定ができます。"
---
この記事では、**Aspose.Slides for Android via Java** を使用したスライドのトランジション効果とタイミングの適用方法を示します。

## **スライド トランジションの追加**

最初のスライドにフェード トランジション効果を適用します。

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // フェード トランジションを適用します。
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **スライド トランジションの取得**

スライドに現在割り当てられているトランジションの種類を取得します。

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // トランジションの種類を取得します。
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **スライド トランジションの削除**

タイプを `None` に設定して、すべてのトランジション効果をクリアします。

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // none に設定してトランジションを削除します。
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **トランジション期間の設定**

スライドが自動的に進むまでの表示時間を指定します。

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // ミリ秒です。
    } finally {
        presentation.dispose();
    }
}
```