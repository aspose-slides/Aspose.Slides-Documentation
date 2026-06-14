---
title: 投影片
type: docs
weight: 10
url: /zh-hant/java/examples/elements/slide/
keywords:
- 程式碼範例
- 投影片
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中控制投影片：使用 Java 為 PPT、PPTX 與 ODP 簡報建立、複製、重新排序、調整大小、設定背景，並套用轉場效果。"
---
本文提供了一系列範例，示範如何使用 **Aspose.Slides for Java** 來操作投影片。您將學習如何使用 `Presentation` 類別新增、存取、複製、重新排序與移除投影片。

以下每個範例都包含簡短說明，並附有 Java 程式碼片段。

## **新增投影片**

若要新增投影片，必須先選擇版面配置。本範例中，我們使用 `Blank` 版面，並在簡報中加入一張空白投影片。

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

> 💡 **注意：** 每個投影片版面配置皆衍生自母片，母片定義了整體設計與佔位元結構。下圖說明了母片與其相關版面在 PowerPoint 中的組織方式。

![Master and Layout Relationship](master-layout-slide.png)

## **按索引存取投影片**

您可以透過索引存取投影片，或根據參照取得投影片的索引。此功能在遍歷或修改特定投影片時非常有用。

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

        // 從參照取得投影片索引，然後依索引存取。
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **複製投影片**

本範例示範如何複製現有的投影片。複製後的投影片會自動加入投影片集合的末端。

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

您可以透過將投影片移動至新索引來變更順序。在此例中，我們將複製的投影片移至第一個位置。

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

若要移除投影片，只需參照該投影片並呼叫 `remove`。本範例先新增第二張投影片，然後移除原本的投影片，僅留下新的投影片。

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