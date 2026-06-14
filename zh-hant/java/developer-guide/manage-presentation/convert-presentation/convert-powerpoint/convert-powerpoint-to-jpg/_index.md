---
title: 在 Java 中將 PPT 和 PPTX 轉換為 JPG
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
- 簡報轉 JPG
- 投影片轉 JPG
- PPT 轉 JPG
- PPTX 轉 JPG
- 將 PowerPoint 儲存為 JPG
- 將簡報儲存為 JPG
- 將投影片儲存為 JPG
- 將 PPT 儲存為 JPG
- 將 PPTX 儲存為 JPG
- 將 PPT 匯出為 JPG
- 將 PPTX 匯出為 JPG
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 於 Java 中將 PowerPoint（PPT、PPTX）投影片轉換為高品質 JPG 圖像，提供快速且可靠的程式碼範例。"
---
## **簡介**

將 PowerPoint 和 OpenDocument 簡報轉換為 JPG 圖像有助於共享投影片、優化效能，以及將內容嵌入網站或應用程式。Aspose.Slides 允許您將 PPTX、PPT 和 ODP 檔案轉換為高品質的 JPEG 圖像。本指南說明了不同的轉換方法。

藉由這些功能，您可以輕鬆實作自己的簡報檢視器，並為每張投影片建立縮圖。若您希望防止投影片被複製或以唯讀模式展示簡報，這將相當有用。Aspose.Slides 允許您將整個簡報或特定投影片轉換為圖像格式。

## **將 PowerPoint PPT/PPTX 轉換為 JPG**

以下是將 PPT/PPTX 轉換為 JPG 的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類型的實例。
2. 從 [Presentation.getSlides()](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--) 集合中取得 [ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide) 類型的投影片物件。
3. 建立每張投影片的縮圖，然後將其轉換為 JPG。[**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide#getImage-float-float-) 方法用於取得投影片的縮圖，會回傳 [Images](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Images) 物件。必須在所需的 [ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide) 物件上呼叫 [getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) 方法，並將縮圖的比例傳入該方法。
4. 取得投影片縮圖後，從縮圖物件呼叫 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) 方法。將產生的檔案名稱與圖像格式傳入該方法。

{{% alert color="primary" %}}
**Note**: PPT/PPTX 轉 JPG 的轉換方式與 Aspose.Slides API 中其他類型的轉換不同。對於其他類型，通常使用 [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法，但此處需要使用 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) 方法。
{{% /alert %}}

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // 建立完整比例的圖像
        IImage slideImage = sld.getImage(1f, 1f);

        // 將圖像以 JPEG 格式儲存至磁碟
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

## **將 PowerPoint PPT/PPTX 轉換為 JPG 並自訂尺寸**

若要變更產生的縮圖與 JPG 圖像的尺寸，您可以在呼叫 [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlide#getImage-float-float-) 方法時傳入 *ScaleX* 與 *ScaleY* 值：

```java
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
        // 建立完整比例的圖像
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // 将图像以 JPEG 格式儲存至磁碟
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

## **在將投影片儲存為圖像時渲染註解**

Aspose.Slides for Java 提供了在將投影片轉換為圖像時渲染簡報註解的功能。以下 Java 程式碼示範此操作：

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

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

{{% alert title="Tip" color="primary" %}}
Aspose 提供一個 [免費的 Collage 網頁應用程式](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG 到 JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 到 PNG 圖像，建立 [照片格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid) 等。

依照本篇文章中描述的相同原理，您可以將圖像由一種格式轉換為另一種格式。更多資訊請參閱以下頁面：將 [image 轉換為 JPG](https://products.aspose.com/slides/zh-hant/java/conversion/image-to-jpg/); 將 [JPG 轉換為 image](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-image/); 將 [JPG 轉換為 PNG](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-png/), 將 [PNG 轉換為 JPG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-jpg/); 將 [PNG 轉換為 SVG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-svg/), 將 [SVG 轉換為 PNG](https://products.aspose.com/slides/zh-hant/java/conversion/svg-to-png/)。
{{% /alert %}}

## **常見問題**

**此方法是否支援批次轉換？**

是，Aspose.Slides 允許在單一操作中將多張投影片批次轉換為 JPG。

**轉換是否支援 SmartArt、圖表及其他複雜物件？**

是，Aspose.Slides 會渲染所有內容，包括 SmartArt、圖表、表格、形狀等。但與 PowerPoint 相比，渲染精確度可能略有差異，特別是使用自訂或缺少的字型時。

**處理的投影片數量有任何限制嗎？**

Aspose.Slides 本身並未對可處理的投影片數量設定嚴格限制。但在處理大型簡報或高解析度圖像時，可能會遇到記憶體不足的錯誤。

## **另請參閱**

另請參考其他將 PPT/PPTX 轉換為圖像的選項，例如：

- [PPT/PPTX 轉換為 SVG](/slides/zh-hant/java/render-a-slide-as-an-svg-image/)。