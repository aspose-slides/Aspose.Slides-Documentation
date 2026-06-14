---
title: 用 JavaScript 建立簡報形狀縮圖
linktitle: 形狀縮圖
type: docs
weight: 70
url: /zh-hant/nodejs-java/create-shape-thumbnails/
keywords:
- 形狀縮圖
- 形狀圖像
- 呈現形狀
- 形狀渲染
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 以及 Aspose.Slides for Node.js 從 PowerPoint 投影片產生高品質的形狀縮圖——輕鬆建立與匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides 用於建立每頁皆為投影片的簡報檔案。這些投影片可透過 Microsoft PowerPoint 開啟檢視。但有時開發人員可能需要在圖像檢視器中單獨檢視形狀的圖像。此時，Aspose.Slides 可協助您產生投影片形狀的縮圖影像。本文說明如何使用此功能。  
本文說明了以不同方式產生投影片縮圖的做法：

- 在投影片內產生形狀縮圖。
- 使用使用者自訂尺寸為投影片形狀產生縮圖。
- 在形狀外觀的邊界內產生縮圖。

## **從投影片產生形狀縮圖**
若要使用 Aspose.Slides for Node.js via Java 從任意投影片產生形狀縮圖，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。
2. 使用 ID 或索引取得任意投影片的參考。
3. 以預設比例[取得形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#getImage--) 於參考投影片。
4. 將縮圖影像儲存為您偏好的圖像格式。

以下範例程式碼示範如何從投影片產生形狀縮圖：

```javascript
// 實例化一個代表簡報檔案的 Presentation 類別
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的圖像
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // 將圖像以 PNG 格式儲存到磁碟
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **使用使用者自訂比例因子產生形狀縮圖**
若要使用 Aspose.Slides for Node.js via Java 為投影片產生形狀縮圖，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。
2. 使用 ID 或索引取得任意投影片的參考。
3. 取得參考投影片的形狀縮圖影像[取得形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#getImage-int-float-float-)（使用者自訂尺寸）。
4. 將縮圖影像儲存為您偏好的圖像格式。

以下範例程式碼示範如何根據自訂比例因子產生形狀縮圖：

```javascript
// 實例化一個代表簡報檔案的 Presentation 類別
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的圖像
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // 將圖像以 PNG 格式儲存到磁碟
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **產生形狀邊界的縮圖**
此方法可讓開發人員在形狀外觀的邊界內產生縮圖，會考慮所有形狀效果。產生的形狀縮圖受投影片邊界限制。若要在外觀邊界內產生投影片形狀的縮圖，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。
2. 使用 ID 或索引取得任意投影片的參考。
3. 取得參考投影片的縮圖影像，使用形狀邊界作為外觀。
4. 將縮圖影像儲存為您偏好的圖像格式。

以下範例程式碼基於上述步驟：

```javascript
// 實例化一個代表簡報檔案的 Presentation 類別
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的圖像
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // 將圖像以 PNG 格式儲存到磁碟
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**儲存形狀縮圖時可以使用哪些影像格式？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imageformat/)，以及其他格式。形狀也可以透過將形狀內容儲存為 SVG，[匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/writeassvg/)。

**在渲染縮圖時，Shape 與 Appearance 邊界有何差異？**

`Shape` 使用形狀的幾何；`Appearance` 會考慮[視覺效果](/slides/zh-hant/nodejs-java/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏，會發生什麼情況？它仍會被渲染為縮圖嗎？**

隱藏的形狀仍屬於模型的一部份且可被渲染；隱藏旗標僅影響投影片播放時的顯示，並不會阻止產生形狀的影像。

**是否支援群組形狀、圖表、SmartArt 以及其他複雜物件？**

是的。任何以[Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 形式呈現的物件（包括[GroupShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/) 與[SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartart/)）皆可儲存為縮圖或 SVG。

**系統安裝的字型會影響文字形狀縮圖的品質嗎？**

會的。您應該[提供必要的字型](/slides/zh-hant/nodejs-java/custom-font/)（或[設定字型替代](/slides/zh-hant/nodejs-java/font-substitution/)），以避免不必要的回退與文字重新排版。