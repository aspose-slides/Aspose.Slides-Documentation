---
title: 投影片
type: docs
weight: 10
url: /zh-hant/nodejs-java/examples/elements/slide/
keywords:
- 程式碼範例
- 投影片
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中控制投影片：建立、複製、重新排序、調整大小、設定背景，並為 PPT、PPTX 與 ODP 簡報套用轉場效果。"
---
本文提供了一系列示例，說明如何使用 **Aspose.Slides for Node.js via Java** 來操作投影片。您將學習如何使用 `Presentation` 類別新增、存取、複製、重新排序及移除投影片。

以下每個示例都包含一段簡要說明，後接 JavaScript 程式碼片段。

## **新增投影片**

若要新增投影片，必須先選擇版面配置。本範例使用 `Blank` 版面，並向簡報中加入一張空白投影片。

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意:** 每個投影片版面皆源自母片，母片定義了整體設計與佔位結構。下圖說明了 PowerPoint 中母片與其相關版面的組織方式。

![母片與版面關係](master-layout-slide.png)

## **依索引存取投影片**

您可以使用索引來存取投影片。此方式方便遍歷或修改特定投影片。

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // 依索引存取投影片。
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **複製投影片**

本範例示範如何複製現有的投影片。複製後的投影片會自動加入投影片集合的末端。

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **重新排序投影片**

您可以透過將投影片移動至新索引來變更其順序。在此範例中，我們將投影片移至第一個位置。

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // 透過將第二張投影片移至第一個位置來重新排序投影片。
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **移除投影片**

若要移除投影片，只需引用該投影片並呼叫 `remove`。本範例先新增第二張投影片，然後移除原始投影片，僅剩新加入的投影片。

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```