---
title: 投影片
type: docs
weight: 10
url: /zh-hant/androidjava/examples/elements/slide/
keywords:
- 程式碼範例
- 投影片
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中控制投影片：使用 Java 建立、複製、重新排序、調整大小、設定背景，並對 PPT、PPTX 與 ODP 簡報套用過渡效果。"
---
本文章提供了一系列範例，示範如何使用 **Aspose.Slides for Android via Java** 來操作投影片。您將學習如何使用 `Presentation` 類別新增、存取、複製、重新排序以及移除投影片。

下面的每個範例都包含簡短說明，並附有 Java 程式碼片段。

## **新增投影片**

若要新增投影片，必須先選擇版面配置。本範例使用 `Blank` 版面，並在簡報中加入一張空白投影片。

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

> 💡 **注意:** 每個投影片版面都是來源於母片，母片定義了整體設計與占位符結構。下圖說明了母片與其相關版面在 PowerPoint 中的組織方式。

![母片與版面關係](master-layout-slide.png)

## **依索引存取投影片**

您可以透過索引存取投影片，或依據參考取得投影片的索引位置。此功能在遍歷或修改特定投影片時很有用。

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // 新增另一張空白投影片。
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // 依索引存取投影片。
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // 從參考取得投影片索引，然後依索引存取它。
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **複製投影片**

此範例示範如何複製現有的投影片。複製後的投影片會自動加入投影片集合的末端。

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

## **重新排序投影片**

您可以透過將投影片移動至新索引來變更排序。在此範例中，我們將複製的投影片移至第一個位置。

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

## **移除投影片**

若要移除投影片，只需參考該投影片並呼叫 `remove`。本範例先新增第二張投影片，然後移除原始的投影片，僅留下新加入的那張。

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