---
title: 母片
type: docs
weight: 30
url: /zh-hant/nodejs-java/examples/elements/master-slide/
keywords:
- 程式碼範例
- 母片
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "探索 Aspose.Slides for Node.js 的母片範例：在 PPT、PPTX 與 ODP 中建立、編輯與樣式化母片、占位符和主題，並提供清晰的程式碼示範。"
---
母片構成 PowerPoint 投影片繼承層級的最高層級。**母片** 定義背景、標誌與文字格式等共同的設計元素。**版面母片** 繼承自母片，**普通投影片** 繼承自版面母片。

本文件說明如何使用 Aspose.Slides for Node.js via Java 來建立、修改與管理母片。

## **Add a Master Slide**

此範例示範如何透過複製預設母片來建立新母片，並藉由版面繼承將公司名稱橫幅加入所有投影片。

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // 複製預設母片。
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // 在母片頂部加入公司名稱橫幅。
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // 將新母片指派給版面母片。
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // 將版面母片指派給簡報中的第一張投影片。
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** 母片提供在所有投影片上套用一致品牌或共享設計元素的方式。對母片所做的任何變更會自動套用到相依的版面母片與普通投影片上。

> 💡 **Note 2:** 任何加入母片的圖形或格式化都會被版面母片繼承，進而被使用該版面的所有普通投影片繼承。  
> 下圖說明在母片上新增的文字方塊如何自動呈現在最終投影片上。

![Master Inheritance Example](master-slide-banner.png)

## **Access a Master Slide**

您可以透過簡報的母片集合來存取母片。以下說明如何擷取並使用它們：

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // 更改背景類型。
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Master Slide**

母片可以依索引或參照方式移除。

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // 依索引移除母片。
        presentation.getMasters().removeAt(0);

        // 依參照移除母片。
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove Unused Master Slides**

某些簡報可能包含未被使用的母片。移除這些母片可協助減少檔案大小。

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // 移除所有未使用的母片（即使已標記為保留）。
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```