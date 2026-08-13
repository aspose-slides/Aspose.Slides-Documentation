---
title: 在 Java 中將 PPT 與 PPTX 轉換為 JPG
linktitle: PowerPoint 轉 JPG
type: docs
weight: 60
url: /zh-hant/java/convert-powerpoint-to-jpg/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 JPG
- 簡報 轉 JPG
- 投影片 轉 JPG
- PPT 轉 JPG
- PPTX 轉 JPG
- 將 PowerPoint 儲存為 JPG
- 將簡報儲存為 JPG
- 將投影片儲存為 JPG
- 將 PPT 儲存為 JPG
- 將 PPTX 儲存為 JPG
- 匯出 PPT 為 JPG
- 匯出 PPTX 為 JPG
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides for Java，透過快速且可靠的程式碼範例，將 PowerPoint（PPT、PPTX）投影片轉換為高品質的 JPG 圖像。"
---
## **簡介**

將 PowerPoint 與 OpenDocument 簡報轉換為 JPG 圖像有助於分享投影片、優化效能，並將內容嵌入網站或應用程式中。Aspose.Slides 讓您能將 PPTX、PPT 與 ODP 檔案轉換為高品質的 JPEG 圖像。本指南說明了不同的轉換方法。

有了這些功能，您可以輕鬆實作自己的簡報檢視器，並為每張投影片產生縮圖。這在您想保護簡報投影片免於被複製，或以唯讀模式展示簡報時非常有用。Aspose.Slides 支援將整個簡報或特定投影片轉換為圖像格式。

## **將 PowerPoint PPT/PPTX 轉換為 JPG**

以下是將 PPT/PPTX 轉換為 JPG 的步驟：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類型的實例。  
2. 從 [Presentation.getSlides()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 集合中取得 [ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide) 類型的投影片物件。  
3. 為每張投影片建立縮圖，然後將其轉換為 JPG。使用 [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide#getImage-float-float-) 方法取得投影片的縮圖，該方法會回傳 [Images](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Images) 物件。必須從所需的 [ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide) 物件呼叫 [getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) 方法，並將縮圖的比例傳入。  
4. 取得投影片縮圖後，從縮圖物件呼叫 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) 方法。將產生的檔名與圖像格式傳入即可。  

{{% alert color="info" %}}

**注意**：PPT/PPTX 轉 JPG 的轉換方式與 Aspose.Slides API 中其他類型的轉換不同。對於其他類型，通常使用 [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法，但此處需要使用 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) 方法。

{{% /alert %}} 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // 建立完整比例的影像
        IImage slideImage = sld.getImage(1f, 1f);

        // 將影像以 JPEG 格式儲存至磁碟
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **將 PowerPoint PPT/PPTX 轉換為具自訂尺寸的 JPG**

若要變更產生的縮圖與 JPG 圖像的尺寸，可在呼叫 [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide#getImage-float-float-) 方法時傳入 *ScaleX* 與 *ScaleY* 值：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // 定義尺寸
    int desiredX = 1200;
    int desiredY = 800;
    // 取得 X 與 Y 的縮放值
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // 建立完整比例的影像
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // 將影像以 JPEG 格式儲存至磁碟
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **儲存投影片為圖像時渲染批註**

Aspose.Slides for Java 提供了在將投影片轉換為圖像時渲染批註的功能。以下 Java 程式碼示範了此操作：

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);
    notesOptions.setCommentsPosition(CommentsPositions.Right);
    notesOptions.setCommentsAreaWidth(200);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Aspose 提供一個 [FREE Collage 網頁應用程式](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG to JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG to PNG 圖像，建立 [photo grids](https://products.aspose.app/slides/zh-hant/collage/photo-grid) 等。  

遵循本文所述的相同原理，您也可以將圖像從一種格式轉換為另一種格式。更多資訊請參考以下頁面：轉換 [image to JPG](https://products.aspose.com/slides/zh-hant/java/conversion/image-to-jpg/)；轉換 [JPG to image](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-image/)；轉換 [JPG to PNG](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-png/)、轉換 [PNG to JPG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-jpg/)；轉換 [PNG to SVG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-svg/)、轉換 [SVG to PNG](https://products.aspose.com/slides/zh-hant/java/conversion/svg-to-png/)。

{{% /alert %}}

## **常見問題**

### 此方法支援批次轉換嗎？

是的，Aspose.Slides 允許在單次操作中將多張投影片批次轉換為 JPG。

### 轉換是否支援 SmartArt、圖表及其他複雜物件？

是的，Aspose.Slides 會渲染所有內容，包括 SmartArt、圖表、表格、圖形等。但與 PowerPoint 相比，渲染精確度可能會因使用自訂或缺少的字型而略有差異。

### 處理投影片的數量有任何限制嗎？

Aspose.Slides 本身對可處理的投影片數量沒有嚴格限制。然而，在處理大型簡報或高解析度圖像時，可能會遇到記憶體不足的錯誤。

## **相關參考**

請參考其他將 PPT/PPTX 轉換為圖像的選項，例如：

- [PPT/PPTX to SVG conversion](/slides/zh-hant/java/render-a-slide-as-an-svg-image/)