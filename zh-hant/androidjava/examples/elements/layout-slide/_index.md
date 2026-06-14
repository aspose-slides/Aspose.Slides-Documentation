---
title: 佈局投影片
type: docs
weight: 20
url: /zh-hant/androidjava/examples/elements/layout-slide/
keywords:
- 程式碼範例
- 佈局投影片
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中主控版面投影片：使用 Java 範例選擇、套用並自訂投影片版面、占位符與母片，支援 PPT、PPTX 與 ODP 簡報。"
---
本文說明如何在 Aspose.Slides for Android via Java 中使用 **Layout Slides**。佈局投影片定義了普通投影片所繼承的設計和格式。您可以新增、存取、克隆與移除佈局投影片，並清理未使用的佈局以減少簡報大小。

## **新增佈局投影片**

您可以建立自訂的佈局投影片以定義可重複使用的格式。例如，您可以新增一個文字方塊，使所有使用此佈局的投影片皆顯示該文字方塊。

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // 建立具有空白版面類型與自訂名稱的佈局投影片。
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // 在佈局投影片中加入文字方塊。
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // 使用此佈局新增兩張投影片；兩者皆會繼承佈局中的文字。
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **註解 1:** 佈局投影片充當單一投影片的範本。您可以一次定義共用元素，並在多張投影片中重複使用。

> 💡 **註解 2:** 當您在佈局投影片上新增形狀或文字時，所有基於該佈局的投影片會自動顯示此共用內容。下方的螢幕截圖顯示兩張投影片，各自從相同的佈局投影片繼承文字方塊。

![繼承佈局內容的投影片](layout-slide-result.png)

## **存取佈局投影片**

佈局投影片可以透過索引或佈局類型（例如 `Blank`、`Title`、`SectionHeader` 等）存取。

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // 依索引存取佈局投影片。
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // 依類型存取佈局投影片。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **移除佈局投影片**

如果不再需要，您可以移除特定的佈局投影片。

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // 依類型取得佈局投影片並移除它。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **移除未使用的佈局投影片**

為了減少簡報大小，您可能想要移除未被任何普通投影片使用的佈局投影片。

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // 自動移除所有未被任何投影片參照的佈局投影片。
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **克隆佈局投影片**

您可以使用 `addClone` 方法複製佈局投影片。

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // 依類型取得現有的佈局投影片。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // 複製佈局投影片至佈局投影片集合的末尾。
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **摘要:** 佈局投影片是管理投影片間一致格式的強大工具。Aspose.Slides 提供完整的建立、管理與最佳化佈局投影片的控制功能。