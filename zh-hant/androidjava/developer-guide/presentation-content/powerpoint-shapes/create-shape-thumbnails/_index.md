---
title: 在 Android 上建立簡報形狀的縮圖
linktitle: 形狀縮圖
type: docs
weight: 70
url: /zh-hant/androidjava/create-shape-thumbnails/
keywords:
- 形狀縮圖
- 形狀影像
- 渲染形狀
- 形狀渲染
- 可視邊界
- 形狀邊界
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，從 PowerPoint 投影片生成高品質的形狀縮圖——輕鬆建立並匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides for Android via Java 可用於建立每一頁對應投影片的簡報檔案。這些投影片可透過 Microsoft PowerPoint 開啟檔案來檢視。然而，開發人員有時需要在影像檢視器中單獨檢視形狀的圖像。在此情況下，Aspose.Slides for Android via Java 可協助產生投影片形狀的縮圖影像。

在本主題中，我們將示範如何在不同情況下產生投影片縮圖：

- 在投影片內產生形狀縮圖。
- 為投影片形狀產生具有使用者自訂尺寸的形狀縮圖。
- 在形狀外觀的邊界內產生形狀縮圖。

## **從投影片產生形狀縮圖**
若要使用 Aspose.Slides for Android via Java 從任何投影片產生形狀縮圖，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
2. 使用 ID 或索引取得任意投影片的參考。
3. [取得參考投影片的形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShape#getImage--)（預設比例）。
4. 將縮圖影像儲存為您偏好的圖像格式。

以下範例程式碼示範如何從投影片產生形狀縮圖：

```java
// 實例化一個代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的影像
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
若要使用 Aspose.Slides for Android via Java 產生投影片的形狀縮圖，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
2. 使用 ID 或索引取得任意投影片的參考。
3. [取得參考投影片的形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShape#getImage-int-float-float-)（使用者自訂尺寸）。
4. 將縮圖影像儲存為您偏好的圖像格式。

以下範例程式碼示範如何根據定義的縮放因子產生形狀縮圖：

```java
// 實例化一個代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的影像
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

## **建立基於邊界的形狀外觀縮圖**
此方法可讓開發人員在形狀外觀的邊界內產生縮圖。它會考慮所有形狀效果。產生的形狀縮圖會受投影片邊界限制。若要在外觀邊界內產生投影片形狀的縮圖，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
2. 使用 ID 或索引取得任意投影片的參考。
3. 取得參考投影片的縮圖影像，將形狀邊界視為外觀。
4. 將縮圖影像儲存為您偏好的圖像格式。

以下範例程式碼依照上述步驟：

```java
// 實例化一個代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // 建立完整比例的影像
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

## **取得形狀的實際可視邊界**
IShape（[IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/)）的框架屬性——其 `getX()`、`getY()`、`getWidth()` 與 `getHeight()` 方法——描述了儲存在簡報模型中的矩形。實際渲染的內容可能會超出該框架或佔據不同的軸對齊矩形。旋轉、輪廓、箭頭、文字排版與溢位、產生的 SmartArt 幾何形狀以及其他渲染效果，都可能改變佔用的區域。

使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getVisualBounds--) 可在不建立影像的情況下計算該佔用區域。此方法會以投影片座標返回一個 [RectF](https://developer.android.com/reference/android/graphics/RectF)。返回的矩形不會被裁剪至投影片內，因此當內容延伸超過投影片原點時，其座標可能為負值。

[Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getVisualBounds--) 目前未在 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 介面中宣告。因此，請將從投影片形狀集合取得的形狀保留為介面型別，僅在呼叫此方法時才進行轉型。

以下範例取得並比較框架與可視邊界：

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

相同的 [RectF](https://developer.android.com/reference/android/graphics/RectF) 可用於將相鄰形狀對齊至其左、右、上或下邊緣；在產生的版面配置中保留足夠空間；或偵測超出允許區域的內容。可視邊界對於 SmartArt、文字方塊、箭頭、圖片、旋轉的形狀以及群組形狀特別有用，因為儲存的框架可能無法呈現完整的渲染結果。

當您需要版面配置或驗證的座標且不需要位圖時，請使用 [Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getVisualBounds--)。若需要渲染形狀，則使用 [IShape.getImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getImage--)。透過 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shapethumbnailbounds/)，`ShapeThumbnailBounds.Shape` 會根據形狀邊界（包括輪廓設定）調整影像大小，而 `ShapeThumbnailBounds.Appearance` 則根據形狀的外觀調整，且將結果限制在投影片邊界內。相較之下，[Shape.getVisualBounds](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getVisualBounds--) 只返回計算出的矩形，且不會裁剪至投影片。

## **常見問題**

**儲存形狀縮圖時可以使用哪些圖像格式？**

[PNG、JPEG、BMP、GIF、TIFF](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imageformat/)，以及其他格式。形狀也可以透過將其內容儲存為 SVG，[匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。

**在渲染縮圖時，Shape 與 Appearance 邊界有何差異？**

`Shape` 使用形狀的幾何結構；`Appearance` 則會考慮[視覺效果](/slides/zh-hant/androidjava/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏，會發生什麼情況？它仍會被渲染為縮圖嗎？**

隱藏的形狀仍屬於模型的一部份且可以被渲染；隱藏標記僅影響投影片放映的顯示，並不會阻止產生形狀的影像。

**是否支援群組形狀、圖表、SmartArt 以及其他複雜物件？**

是的。任何以 [Shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/) 表示的物件（包括 [GroupShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chart/) 與 [SmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/smartart/)），皆可儲存為縮圖或 SVG。

**系統安裝的字型會影響文字形狀縮圖的品質嗎？**

會。您應該[提供所需的字型](/slides/zh-hant/androidjava/custom-font/)（或[設定字型替換](/slides/zh-hant/androidjava/font-substitution/)），以避免不必要的備用字型與文字重排。