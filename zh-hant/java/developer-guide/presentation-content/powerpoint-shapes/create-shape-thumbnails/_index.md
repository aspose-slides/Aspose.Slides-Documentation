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
- 視覺邊界
- 形狀邊界
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 從 PowerPoint 投影片生成高品質的形狀縮圖——輕鬆建立並匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides for Java 可用於建立簡報檔案，其中每頁對應一張投影片。這些投影片可透過使用 Microsoft PowerPoint 開啟簡報檔案來檢視。然而，開發人員有時需要在圖像檢視器中單獨查看形狀的圖像。在此情況下，Aspose.Slides for Java 可協助產生投影片形狀的縮圖圖像。

本篇文章說明了如何以不同方式產生投影片縮圖：

- 在投影片內產生形狀縮圖。
- 以使用者自訂尺寸產生投影片形狀的縮圖。
- 在形狀外觀的範圍內產生縮圖。

## **從投影片產生形狀縮圖**

若要使用 Aspose.Slides for Java 從任意投影片產生形狀縮圖，請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的執行個體。
1. 使用其 ID 或索引取得任意投影片的參考。
1. 在預設比例下，取得參考投影片的[形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getImage--)。
1. 將縮圖影像儲存為您偏好的影像格式。

以下範例程式碼示範如何從投影片產生形狀縮圖：

```java
// 實例化表示簡報檔案的 Presentation 類別
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 建立全比例影像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // 以 PNG 格式將影像儲存至磁碟
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

若要使用 Aspose.Slides for Java 產生投影片形狀的縮圖，請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的執行個體。
1. 使用其 ID 或索引取得任意投影片的參考。
1. 取得參考投影片的[形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getImage-int-float-float-)，並使用使用者自訂的尺寸。
1. 將縮圖影像儲存為您偏好的影像格式。

以下範例程式碼示範如何依據自訂縮放因子產生形狀縮圖：

```java
// 實例化表示簡報檔案的 Presentation 類別
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 建立全比例影像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // 以 PNG 格式將影像儲存至磁碟
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

此建立形狀縮圖的方法讓開發人員能在形狀外觀的範圍內產生縮圖，並會考慮所有形狀效果。產生的形狀縮圖會受到投影片範圍的限制。若要在形狀外觀的範圍內產生投影片形狀的縮圖，請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的執行個體。
1. 使用其 ID 或索引取得任意投影片的參考。
1. 取得參考投影片的縮圖影像，形狀範圍作為外觀。
1. 將縮圖影像儲存為您偏好的影像格式。

以下範例程式碼依據上述步驟：

```java
// 實例化表示簡報檔案的 Presentation 類別
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 建立全比例影像
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // 以 PNG 格式將影像儲存至磁碟
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **取得形狀的實際視覺邊界**

[IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 的框架屬性——其 `getX()`、`getY()`、`getWidth()` 與 `getHeight()` 方法——描述了簡報模型中儲存的矩形。實際渲染的內容可能會超出該框架或佔用不同的軸對齊矩形。旋轉、外框、箭頭、文字版面配置與溢位、產生的 SmartArt 幾何形狀，以及其他渲染效果皆可能改變佔用的區域。

使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getVisualBounds--) 可在不建立影像的情況下計算該佔用區域。此方法傳回投影片座標系中的 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html)。傳回的矩形不會被裁切至投影片範圍內，若內容超出投影片原點，其座標可能為負值。

[Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getVisualBounds--) 目前未在 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/) 介面中宣告。因此，請將從投影片形狀集合取得的形狀保留為介面型別，僅在呼叫該方法時再進行型別轉換。

以下範例取得並比較框架與視覺邊界：

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

相同的 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) 可用於將相鄰形狀對齊至左、右、上或下邊緣；在產生的版面中保留足夠空間；或偵測超出允許區域的內容。視覺邊界在 SmartArt、文字方塊、箭頭、圖片、旋轉形狀以及群組形狀中特別有用，因為儲存的框架可能無法完全呈現最終渲染結果。

當您需要版面或驗證的座標且不需要位圖時，請使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getVisualBounds--)。若需要渲染形狀，則使用 [IShape.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getImage--)。使用 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shapethumbnailbounds/) 時，`ShapeThumbnailBounds.Shape` 會根據形狀邊界（包含外框設定）調整影像大小，而 `ShapeThumbnailBounds.Appearance` 則根據形狀的外觀調整，並將結果限制於投影片範圍。相較之下， [Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getVisualBounds--) 只傳回計算出的矩形，且不會裁切至投影片。

## **常見問題**

**保存形狀縮圖時可使用哪些影像格式？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imageformat/)，以及其他格式。形狀也可以透過將形狀內容另存為 SVG 來[匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。

**在渲染縮圖時，Shape 與 Appearance 範圍有何差異？**

`Shape` 使用形狀的幾何結構；`Appearance` 則會考慮[視覺效果](/slides/zh-hant/java/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏，會發生什麼情況？它仍會生成縮圖嗎？**

隱藏的形狀仍屬於模型的一部份，仍可被渲染；隱藏旗標僅影響投影片播放的顯示，並不會阻止產生形狀的影像。

**是否支援群組形狀、圖表、SmartArt 以及其他複雜物件？**

是的。任何以 [Shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/) 形式表示的物件（包括 [GroupShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chart/)、以及 [SmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/smartart/)）皆可儲存為縮圖或 SVG。

**系統安裝的字體會影響文字形狀縮圖的品質嗎？**

會。您應該[提供所需的字體](/slides/zh-hant/java/custom-font/)（或[設定字體替代](/slides/zh-hant/java/font-substitution/)），以避免不必要的備用字體與文字重新排版。