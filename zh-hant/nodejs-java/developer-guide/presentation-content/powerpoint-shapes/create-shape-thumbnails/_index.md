---
title: 使用 JavaScript 建立簡報形狀縮圖
linktitle: 形狀縮圖
type: docs
weight: 70
url: /zh-hant/nodejs-java/create-shape-thumbnails/
keywords:
- 形狀縮圖
- 形狀影像
- 渲染形狀
- 形狀渲染
- 可視範圍
- 形狀範圍
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 以及 Aspose.Slides for Node.js，從 PowerPoint 投影片產生高品質的形狀縮圖──輕鬆建立與匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides 用於建立每頁皆為投影片的簡報檔。這些投影片可透過使用 Microsoft PowerPoint 開啟簡報檔來檢視。但有時開發人員可能需要在圖像檢視器中單獨檢視形狀的圖像。在此情況下，Aspose.Slides 可協助您產生投影片形狀的縮圖影像。如何使用此功能請參考本文。  
本文說明了以不同方式產生投影片縮圖的方法：

- 在投影片內產生形狀縮圖。
- 使用使用者自訂尺寸為投影片形狀產生縮圖。
- 在形狀外觀的範圍內產生縮圖。

## **從投影片產生形狀縮圖**

使用 Aspose.Slides for Node.js via Java 從任意投影片產生形狀縮圖，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的執行個體。
1. 使用投影片的 ID 或索引取得任意投影片的參考。
1. [取得形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#getImage--)（使用預設比例）
1. 將縮圖影像儲存為您偏好的影像格式。

以下範例程式碼示範如何從投影片產生形狀縮圖：

```javascript
// 實例化一個代表簡報檔的 Presentation 類別
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的影像
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // 將影像以 PNG 格式儲存至磁碟
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

## **使用使用者自訂縮放比例產生形狀縮圖**

使用 Aspose.Slides for Node.js via Java 為投影片產生形狀縮圖，請依以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的執行個體。
1. 使用投影片的 ID 或索引取得任意投影片的參考。
1. [取得形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#getImage-int-float-float-)（使用使用者自訂尺寸）
1. 將縮圖影像儲存為您偏好的影像格式。

以下範例程式碼示範如何根據自訂的縮放比例產生形狀縮圖：

```javascript
// 實例化代表簡報檔的 Presentation 類別
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的影像
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // 將影像以 PNG 格式儲存至磁碟
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

## **產生形狀邊界縮圖**

此建立形狀縮圖的方法讓開發人員能在形狀外觀的範圍內產生縮圖，會考慮所有形狀效果。產生的形狀縮圖會受投影片邊界限制。若要在外觀的範圍內產生投影片形狀的縮圖，請依以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的執行個體。
1. 使用投影片的 ID 或索引取得任意投影片的參考。
1. 取得參考投影片的縮圖影像，使用形狀邊界作為外觀。
1. 將縮圖影像儲存為您偏好的影像格式。

以下範例程式碼基於上述步驟：

```javascript
// 實例化代表簡報檔的 Presentation 類別
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的影像
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // 將影像以 PNG 格式儲存至磁碟
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

## **取得形狀的實際可視範圍**

[Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 的框架屬性——其 `getX()`、`getY()`、`getWidth()` 與 `getHeight()` 方法——描述了儲存在簡報模型中的矩形。實際渲染的內容可能會超出此框架或佔據不同的軸對齊矩形。旋轉、輪廓、箭頭頭部、文字版面配置與溢位、產生的 SmartArt 幾何形狀及其他渲染效果都可能改變佔用的區域。  
使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getVisualBounds--) 可在不建立影像的情況下計算該佔用區域。此方法會回傳以投影片座標表示的 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) 物件。回傳的矩形不會被裁切至投影片範圍內，若內容超出投影片原點，其座標可能為負值。  
以下範例取得並比較框架與可視範圍：

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

相同的矩形可用於將鄰近形狀對齊至其左、右、上或下邊緣；在產生的版面配置中保留足夠空間；或偵測超出允許區域的內容。可視範圍對於 SmartArt、文字方塊、箭頭、圖片、旋轉形狀與群組形狀特別有用，因為儲存的框架可能無法完整代表渲染結果。  
當您需要版面配置或驗證的座標且不需要點陣圖時，請使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getVisualBounds--)。當您需要渲染形狀時，請使用 [Shape.getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getImage--)。使用 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapethumbnailbounds/)，`ShapeThumbnailBounds.Shape` 會根據形狀邊界（包括輪廓設定）調整影像大小，而 `ShapeThumbnailBounds.Appearance` 則根據形狀的外觀調整，並將結果限制在投影片邊界內。相比之下，[Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getVisualBounds--) 只回傳計算出的矩形，且不會裁切至投影片。

## **常見問題**

**儲存形狀縮圖時可以使用哪些影像格式？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imageformat/) 等格式皆可使用。形狀亦可透過將其內容另存為 SVG 來[匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/writeassvg/)。

**在渲染縮圖時 Shape 與 Appearance 範圍有何差異？**

`Shape` 使用形狀的幾何；`Appearance` 則會考慮[視覺效果](/slides/zh-hant/nodejs-java/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏會發生什麼情況？它仍會被渲染為縮圖嗎？**

即使形狀被標記為隱藏，它仍是模型的一部份且可被渲染；隱藏標記僅影響投影片播放時的顯示，並不會阻止產生形狀影像。

**是否支援群組形狀、圖表、SmartArt 與其他複雜物件？**

是。任何以 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 表示的物件（包括 [GroupShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/) 與 [SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartart/)）皆可儲存為縮圖或 SVG。

**系統安裝的字型會影響文字形狀縮圖的品質嗎？**

會。您應該[提供所需的字型](/slides/zh-hant/nodejs-java/custom-font/)（或[設定字型替代](/slides/zh-hant/nodejs-java/font-substitution/)），以避免不必要的備援字型與文字重新排列。