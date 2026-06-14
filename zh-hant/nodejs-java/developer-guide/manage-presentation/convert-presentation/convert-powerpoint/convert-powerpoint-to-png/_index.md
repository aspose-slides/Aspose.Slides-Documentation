---
title: 在 JavaScript 中將 PowerPoint 投影片轉換為 PNG
linktitle: PowerPoint 轉 PNG
type: docs
weight: 30
url: /zh-hant/nodejs-java/convert-powerpoint-to-png/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 PNG
- 簡報轉 PNG
- 投影片轉 PNG
- PPT 轉 PNG
- PPTX 轉 PNG
- 儲存 PPT 為 PNG
- 儲存 PPTX 為 PNG
- 匯出 PPT 為 PNG
- 匯出 PPTX 為 PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中快速將 PowerPoint 簡報轉換為高品質 PNG 圖像，確保精確且自動化的結果。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 PNG 圖片。它展示了如何載入 PPT、PPTX 和 ODP 等格式的簡報檔案、將投影片渲染為圖像，並將結果儲存為 PNG 格式。

本文還示範了如何透過設定比例值或指定所需的寬度與高度來自訂產生的 PNG 圖片。

## **將 PowerPoint 轉換為 PNG**

依照以下步驟操作：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別。
2. 透過 [Presentation.getSlides()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getSlides--) 方法取得的集合，取得 [Slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Slide) 類別下的投影片物件。
3. 使用 [Slide.getImage()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Slide) 方法取得每張投影片的縮圖。
4. 使用 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/#save) 方法將投影片縮圖儲存為 PNG 格式。

以下 JavaScript 程式碼示範如何將 PowerPoint 簡報轉換為 PNG：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **使用自訂維度將 PowerPoint 轉換為 PNG**

如果您想取得特定比例的 PNG 檔案，可設定 `desiredX` 與 `desiredY` 的值，這兩個值決定產生縮圖的尺寸。

以下 JavaScript 程式碼示範上述操作：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **使用自訂大小將 PowerPoint 轉換為 PNG**

如果您想取得特定尺寸的 PNG 檔案，可為 `ImageSize` 傳入您偏好的 `width` 與 `height` 參數。

以下程式碼示範如何在指定圖像大小的情況下將 PowerPoint 轉換為 PNG：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**如何僅匯出特定圖形（例如圖表或圖片），而不是整張投影片？**

Aspose.Slides 支援[為單一圖形產生縮圖](/slides/zh-hant/nodejs-java/create-shape-thumbnails/)；您可以將圖形渲染為 PNG 圖像。

**伺服器上是否支援平行轉換？**

可以，但請[不要在執行緒間共享](/slides/zh-hant/nodejs-java/multithreading/)單一的簡報實例。每個執行緒或行程應使用獨立的實例。

**以 PNG 匯出時試用版有什麼限制？**

評估模式會在輸出圖像上加上浮水印，且會套用[其他限制](/slides/zh-hant/nodejs-java/licensing/)，直到套用授權為止。