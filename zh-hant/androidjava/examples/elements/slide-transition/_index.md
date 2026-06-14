---
title: 投影片過渡
type: docs
weight: 110
url: /zh-hant/androidjava/examples/elements/slide-transition/
keywords:
- 程式碼範例
- 投影片過渡
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中精通投影片過渡：使用 Java 範例為 PPT、PPTX 與 ODP 簡報新增、客製化及排程效果與持續時間。"
---
本文示範如何在 **Aspose.Slides for Android via Java** 中套用投影片過渡效果和時間設定。

## **新增投影片過渡**

對第一張投影片套用淡入淡出過渡效果。

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 套用淡入淡出過渡。
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **存取投影片過渡**

讀取目前指派給投影片的過渡類型。

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // 取得過渡類型。
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **移除投影片過渡**

將類型設定為 `None` 以清除任何過渡效果。

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // 透過設定為 None 來移除過渡。
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **設定過渡持續時間**

指定投影片在自動前進前顯示的持續時間。

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