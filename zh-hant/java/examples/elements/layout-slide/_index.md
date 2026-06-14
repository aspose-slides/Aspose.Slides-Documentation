---
title: 版面投影片
type: docs
weight: 20
url: /zh-hant/java/examples/elements/layout-slide/
keywords:
- 程式碼範例
- 版面投影片
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中精通版面投影片：使用 Java 範例針對 PPT、PPTX 與 ODP 簡報選擇、套用與自訂投影片版面、占位符與母片。"
---
本文示範如何在 Aspose.Slides for Java 中使用 **Layout Slides**。版面投影片定義了普通投影片繼承的設計與格式。您可以新增、存取、複製與移除版面投影片，並清理未使用的版面投影片以減少簡報檔案大小。

## **新增版面投影片**

您可以建立自訂版面投影片以定義可重複使用的格式。例如，您可以新增一個文字方塊，使所有使用此版面的投影片皆顯示它。

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // 建立具有空白版面類型和自訂名稱的版面投影片。
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // 在版面投影片上新增文字方塊。
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // 使用此版面新增兩張投影片；兩者皆會繼承版面的文字。
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** 版面投影片充當各個投影片的範本。您可以一次定義共用元素，並在多個投影片中重複使用它們。

> 💡 **Note 2:** 當您在版面投影片上加入圖形或文字時，所有基於該版面的投影片都會自動顯示此共用內容。下方的螢幕截圖顯示兩張投影片，各自從相同的版面投影片繼承了一個文字方塊。

![繼承版面內容的投影片](layout-slide-result.png)

## **存取版面投影片**

版面投影片可以透過索引或版面類型（例如 `Blank`、`Title`、`SectionHeader` 等）存取。

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // 依索引存取版面投影片。
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // 依類型存取版面投影片。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **移除版面投影片**

如果不再需要，您可以移除特定的版面投影片。

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // 依類型取得版面投影片並將其移除。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **移除未使用的版面投影片**

為了減少簡報檔案大小，您可能想要移除所有普通投影片皆未使用的版面投影片。

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // 自動移除所有未被任何投影片參照的版面投影片。
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **複製版面投影片**

您可以使用 `addClone` 方法來複製版面投影片。

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // 取得現有的版面投影片（依類型）。
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // 將版面投影片複製至版面投影片集合的最後。
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Summary:** 版面投影片是管理投影片間一致格式的強大工具。Aspose.Slides 提供完整的控制權，讓您能建立、管理與最佳化版面投影片。