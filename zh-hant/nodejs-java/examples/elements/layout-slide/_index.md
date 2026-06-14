---
title: 版面投影片
type: docs
weight: 20
url: /zh-hant/nodejs-java/examples/elements/layout-slide/
keywords:
- 程式碼範例
- 版面投影片
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中掌握版面投影片：選擇、套用並自訂投影片版面、占位符與母片，並提供 PPT、PPTX 與 ODP 簡報的範例。"
---
本文示範如何在 Aspose.Slides for Node.js via Java 中使用 **Layout Slides**。版面投影片定義了普通投影片繼承的設計與格式。您可以新增、存取、克隆和移除版面投影片，亦可清理未使用的投影片以減少簡報大小。

## **新增版面投影片**

您可以建立自訂版面投影片，以定義可重複使用的格式。

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // 建立一個版面投影片，使用空白版面類型並指定自訂名稱。
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意 1：** 版面投影片充當個別投影片的範本。您可以一次定義共用元素，並在多張投影片間重複使用它們。

> 💡 **注意 2：** 當您在版面投影片上新增形狀或文字時，所有以該版面為基礎的投影片都會自動顯示此共用內容。  
> 以下螢幕截圖顯示兩張投影片，各自從相同的版面投影片繼承文字方塊。

![投影片繼承版面內容](layout-slide-result.png)

## **存取版面投影片**

可以透過索引或版面類型（例如 `Blank`、`Title`、`SectionHeader` 等）存取版面投影片。

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // 依索引存取版面投影片。
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // 依類型存取版面投影片。
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **移除版面投影片**

若不再需要，您可以移除特定的版面投影片。

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // 依類型取得版面投影片並將其移除。
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **移除未使用的版面投影片**

為了減少簡報大小，您可能想要移除未被任何普通投影片使用的版面投影片。

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // 自動移除所有未被任何投影片引用的版面投影片。
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **克隆版面投影片**

您可以使用 `addClone` 方法複製版面投影片。

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // 依類型取得現有的版面投影片。
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // 將版面投影片複製到版面投影片集合的末端。
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **總結：** 版面投影片是管理投影片間一致格式的強大工具。Aspose.Slides 提供完整的建立、管理與最佳化版面投影片的控制功能。