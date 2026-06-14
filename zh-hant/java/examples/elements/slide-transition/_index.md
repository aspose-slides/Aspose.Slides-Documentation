---
title: 投影片轉場
type: docs
weight: 110
url: /zh-hant/java/examples/elements/slide-transition/
keywords:
- 程式碼範例
- 投影片轉場
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中精通投影片轉場：加入、客製化及排序效果與持續時間，並提供 PPT、PPTX 與 ODP 簡報的 Java 範例。"
---
本文示範如何在 **Aspose.Slides for Java** 中套用投影片轉場效果與時間設定。

## **新增投影片轉場**
對第一張投影片套用淡入淡出轉場效果。

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 套用淡入淡出轉場。
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **存取投影片轉場**
讀取目前指派給投影片的轉場類型。

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // 取得轉場類型。
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **移除投影片轉場**
透過將類型設定為 `None` 來清除所有轉場效果。

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // 移除轉場，設定為 None。
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **設定轉場持續時間**
指定投影片在自動前進前的顯示時間長度。

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // 以毫秒為單位。
    } finally {
        presentation.dispose();
    }
}
```