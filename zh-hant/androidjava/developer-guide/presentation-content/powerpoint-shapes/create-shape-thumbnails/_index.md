---
title: 在 Android 上建立簡報形狀縮圖
linktitle: 形狀縮圖
type: docs
weight: 70
url: /zh-hant/androidjava/create-shape-thumbnails/
keywords:
- 形狀縮圖
- 形狀圖像
- 呈現形狀
- 形狀渲染
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 從 PowerPoint 投影片產生高品質的形狀縮圖，輕鬆建立與匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides for Android via Java 可用於建立每一頁對應投影片的簡報檔案。可以使用 Microsoft PowerPoint 開啟簡報檔案來檢視投影片。然而，開發人員有時需要在影像檢視器中單獨查看形狀的圖像。在此情況下，Aspose.Slides for Android via Java 可協助產生投影片形狀的縮圖影像。

在本主題中，我們將說明如何在不同情況下產生投影片縮圖：

- 產生投影片內形狀的縮圖。
- 產生使用者自行定義尺寸的投影片形狀縮圖。
- 產生符合形狀外觀邊界的縮圖。

## **從投影片產生形狀縮圖**
如需使用 Aspose.Slides for Android via Java 從任意投影片產生形狀縮圖，請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
2. 取得任意投影片的參考，可使用其 ID 或索引。
3. 以預設比例[取得形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShape#getImage--)。
4. 將縮圖影像保存為您偏好的影像格式。

下面的範例程式碼示範如何從投影片產生形狀縮圖：

```java
// 實例化表示簡報檔案的 Presentation 類別
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的圖像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // 將圖像以 PNG 格式儲存到磁碟
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **產生使用者自訂縮放比例的縮圖**
如需使用 Aspose.Slides for Android via Java 產生投影片形狀的縮圖，請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
2. 取得任意投影片的參考，可使用其 ID 或索引。
3. 使用使用者自訂尺寸[取得形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShape#getImage-int-float-float-)。
4. 將縮圖影像保存為您偏好的影像格式。

下面的範例程式碼示範如何根據自訂縮放比例產生形狀縮圖：

```java
// 實例化表示簡報檔案的 Presentation 類別
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的圖像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // 將圖像以 PNG 格式儲存到磁碟
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **建立基於邊界的形狀外觀縮圖**
此方法讓開發人員在形狀外觀的邊界內產生縮圖，會考慮所有形狀效果。產生的形狀縮圖受投影片邊界限制。若要在形狀外觀的邊界內產生投影片形狀的縮圖，請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
2. 取得任意投影片的參考，可使用其 ID 或索引。
3. 以形狀外觀邊界取得參考投影片的縮圖影像。
4. 將縮圖影像保存為您偏好的影像格式。

以下程式碼依上述步驟示範：

```java
// 實例化表示簡報檔案的 Presentation 類別
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的圖像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // 將圖像以 PNG 格式儲存到磁碟
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

**儲存形狀縮圖時可以使用哪些影像格式？**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imageformat/)，以及其他格式。形狀也可以透過將內容保存為 SVG 來[匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。

**在渲染縮圖時，Shape 與 Appearance 邊界有什麼差異？**  
`Shape` 使用形狀的幾何資訊；`Appearance` 會考慮[視覺效果](/slides/zh-hant/androidjava/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏，會仍然產生縮圖嗎？**  
隱藏的形狀仍屬於模型的一部分，可被渲染；隱藏旗標僅影響投影片放映時的顯示，並不阻止產生形狀圖像。

**是否支援群組形狀、圖表、SmartArt 及其他複雜物件？**  
支援。任何以 [Shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/) 表示的物件（包括 [GroupShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chart/) 與 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/smartart/)）都能保存為縮圖或 SVG。

**系統安裝的字型會影響文字形狀縮圖的品質嗎？**  
會。您應該[提供必要的字型](/slides/zh-hant/androidjava/custom-font/)（或[設定字型替換](/slides/zh-hant/androidjava/font-substitution/)），以避免不必要的回退與文字重新換行。