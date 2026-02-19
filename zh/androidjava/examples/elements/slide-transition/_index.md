---
title: 幻灯片切换
type: docs
weight: 110
url: /zh/androidjava/examples/elements/slide-transition/
keywords:
- 代码示例
- 幻灯片切换
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中掌握幻灯片切换：使用 Java 示例为 PPT、PPTX 和 ODP 演示文稿添加、定制和排列效果及持续时间。"
---
本文演示了如何在 **Aspose.Slides for Android via Java** 中应用幻灯片切换效果及时间设置。

## **添加幻灯片切换**

对第一张幻灯片应用淡入淡出切换效果。

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 应用淡入淡出切换。
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **访问幻灯片切换**

读取当前分配给幻灯片的切换类型。

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // 访问切换类型。
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **移除幻灯片切换**

通过将类型设置为 `None` 来清除所有切换效果。

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // 通过设置为 None 来移除切换。
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **设置切换持续时间**

指定幻灯片在自动前进之前显示的时长。

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // 以毫秒为单位。
    } finally {
        presentation.dispose();
    }
}
```