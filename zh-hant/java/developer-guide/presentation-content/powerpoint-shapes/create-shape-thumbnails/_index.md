---
title: 在 Java 中建立簡報形狀縮圖
linktitle: 形狀縮圖
type: docs
weight: 70
url: /zh-hant/java/create-shape-thumbnails/
keywords:
- 形狀縮圖
- 形狀圖像
- 渲染形狀
- 形狀渲染
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 從 PowerPoint 投影片產生高品質的形狀縮圖 – 輕鬆建立與匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides for Java 可用於建立簡報檔案，其中每頁對應一張投影片。投影片可透過 Microsoft PowerPoint 開啟檢視。然而，開發人員有時需要在圖像檢視器中分別檢視形狀的圖像。在此情況下，Aspose.Slides for Java 可協助產生投影片形狀的縮圖影像。

本文說明如何以不同方式產生投影片縮圖：

- 在投影片內產生形狀縮圖。
- 以使用者自訂尺寸產生投影片形狀的形狀縮圖。
- 在形狀外觀的範圍內產生形狀縮圖。

## **從投影片產生形狀縮圖**
要使用 Aspose.Slides for Java 從任何投影片產生形狀縮圖，請執行下列步驟：

1. 建立 [Presentation] 類別的執行個體。
1. 使用 ID 或索引取得任何投影片的參考。
1. 在預設縮放比例下，[取得形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape#getImage--)。
1. 將縮圖影像儲存為您偏好的圖像格式。

此範例程式碼示範如何從投影片產生形狀縮圖：

```java
// 實例化一個代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的影像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // 將影像以 PNG 格式儲存至磁碟
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **產生使用者自訂縮放因子縮圖**
要使用 Aspose.Slides for Java 產生投影片的形狀縮圖，請執行下列步驟：

1. 建立 [Presentation] 類別的執行個體。
1. 使用 ID 或索引取得任何投影片的參考。
1. 使用使用者自訂尺寸，從參考的投影片[取得形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape#getImage-int-float-float-)。
1. 將縮圖影像儲存為您偏好的圖像格式。

此範例程式碼示範如何根據定義的縮放因子產生形狀縮圖：

```java
// 實例化一個代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的影像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // 將影像以 PNG 格式儲存至磁碟
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **建立基於範圍的形狀外觀縮圖**
此方法可讓開發人員在形狀外觀的範圍內產生縮圖，會考慮所有形狀效果，且產生的形狀縮圖受投影片範圍限制。要在外觀範圍內產生投影片形狀的縮圖，請執行下列步驟：

1. 建立 [Presentation] 類別的執行個體。
1. 使用 ID 或索引取得任何投影片的參考。
1. 取得參考投影片的縮圖影像，使用形狀範圍作為外觀。
1. 將縮圖影像儲存為您偏好的圖像格式。

以下範例程式碼依上述步驟示範：

```java
// 實例化一個代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的影像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // 將影像以 PNG 格式儲存至磁碟
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**儲存形狀縮圖時可以使用哪些圖像格式？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imageformat/)，以及其他。形狀也可以透過將形狀內容儲存為 SVG 來[匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。

**在產生縮圖時，Shape 與 Appearance 範圍有何差異？**

`Shape` 使用形狀的幾何；`Appearance` 會考慮[視覺效果](/slides/zh-hant/java/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏，會發生什麼？它仍會產生縮圖嗎？**

隱藏的形狀仍然是模型的一部份，仍可被呈現；隱藏旗標只會影響投影片放映的顯示，卻不會阻止產生形狀影像。

**是否支援群組形狀、圖表、SmartArt 以及其他複雜物件？**

是的。任何以[Shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/) 表示的物件（包括[GroupShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/groupshape/)，[Chart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chart/)及[SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/smartart/)）都可以儲存為縮圖或 SVG。

**系統安裝的字型會影響文字形狀縮圖的品質嗎？**

會。您應該[提供必要的字型](/slides/zh-hant/java/custom-font/)（或[設定字型替換](/slides/zh-hant/java/font-substitution/)），以避免不期望的回退與文字重新排版。