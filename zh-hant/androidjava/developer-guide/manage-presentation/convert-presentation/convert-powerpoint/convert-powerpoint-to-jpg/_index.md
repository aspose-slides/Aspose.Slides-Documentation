---
title: 在 Android 上將 PPT 與 PPTX 轉換為 JPG
linktitle: PowerPoint 轉 JPG
type: docs
weight: 60
url: /zh-hant/androidjava/convert-powerpoint-to-jpg/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android，在 Java 中將 PowerPoint (PPT、PPTX) 投影片轉換為高品質 JPG 圖片，提供快速且可靠的程式碼範例。"
---
## **簡介**

將 PowerPoint 和 OpenDocument 簡報轉換為 JPG 圖片有助於分享投影片、優化效能，並將內容嵌入網站或應用程式。Aspose.Slides for Android via Java 允許您將 PPTX、PPT 和 ODP 檔案轉換為高品質 JPEG 圖片。本指南說明不同的轉換方法。

透過這些功能，您可以輕鬆實作自己的簡報檢視器，並為每張投影片建立縮圖。如果您想防止簡報投影片被抄襲或在唯讀模式下展示簡報，這會很有用。Aspose.Slides 允許您將整個簡報或特定投影片轉換為影像格式。

## **將簡報投影片轉換為 JPG 圖片**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。  
1. 從 [Presentation.getSlides()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSlides--) 方法返回的集合中取得類型為 [ISlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/) 的投影片物件。  
1. 使用 [ISlide.getImage(float,float)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#getImage-float-float-) 方法建立投影片的圖像。  
1. 在圖像物件上呼叫 [IImage.save(string,ImageFormat)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 方法。將輸出檔名和影像格式作為參數傳入。  

{{% alert color="primary" %}} 
**注意：** PPT、PPTX 或 ODP 轉換為 JPG 與在 Aspose.Slides Android via Java API 中轉換為其他格式不同。對於其他格式，通常使用 [IPresentation.save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法。然而，對於 JPG 轉換，必須使用 [IImage.save(string,ImageFormat)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 方法。  
{{% /alert %}} 

```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 建立指定比例的投影片影像。
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // 以 JPEG 格式將影像儲存至磁碟。
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **使用自訂尺寸將投影片轉換為 JPG**

若要變更輸出 JPG 圖片的尺寸，可在呼叫 [ISlide.getImage(Size)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) 時傳入圖像大小。這讓您能產生具有特定寬度和高度的圖像，確保輸出符合解析度與長寬比的需求。此彈性在為 Web 應用程式、報告或文件產生圖像時特別有用，因為需要精確的圖像尺寸。  

```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 建立指定尺寸的投影片影像。
        IImage slideImage = slide.getImage(imageSize);

        try {
            // 以 JPEG 格式將影像儲存至磁碟。
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **在將投影片儲存為影像時渲染註解**

Aspose.Slides for Android via Java 提供一項功能，允許您在將簡報投影片轉換為 JPG 圖片時渲染註解。此功能對於保留協作者在 PowerPoint 簡報中加入的標註、回饋或討論特別有用。啟用此選項後，註解會出現在產生的圖像中，便於在不開啟原始簡報檔的情況下檢閱與分享回饋。

假設我們有一個簡報檔案「sample.pptx」，其中有投影片包含註解：

![包含註解的投影片](slide_with_comments.png)

以下 Java 程式碼在保留註解的情況下，將投影片轉換為 JPG 圖片：

```java
int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(Color.rgb(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // 將第一張投影片轉換為影像。
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```

結果：

![包含註解的 JPG 圖片](image_with_comments.png)

## **其他參考**

- [將 PowerPoint 轉換為 GIF](/slides/zh-hant/androidjava/convert-powerpoint-to-animated-gif/)
- [將 PowerPoint 轉換為 PNG](/slides/zh-hant/androidjava/convert-powerpoint-to-png/)
- [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/androidjava/convert-powerpoint-to-tiff/)
- [將 PowerPoint 轉換為 SVG](/slides/zh-hant/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
若要了解 Aspose.Slides 如何將 PowerPoint 簡報轉換為 JPG 圖片，可試用以下免費線上轉換器：PowerPoint [PPTX 轉 JPG](https://products.aspose.app/slides/zh-hant/conversion/pptx-to-jpg) 和 [PPT 轉 JPG](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-jpg)。  
{{% /alert %}} 

![免費線上 PPTX 轉 JPG 轉換器](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}} 
Aspose 提供一個[免費拼貼網頁應用程式](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG 轉 JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 轉 PNG 圖片，建立[相片格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid)等。

使用本文所述的相同原則，您可以將圖像從一種格式轉換為另一種格式。欲了解更多資訊，請參閱以下頁面：轉換[圖像至 JPG](https://products.aspose.com/slides/zh-hant/java/conversion/image-to-jpg/); 轉換[JPG 至圖像](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-image/); 轉換[JPG 至 PNG](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-png/)，轉換[PNG 至 JPG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-jpg/); 轉換[PNG 至 SVG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-svg/)，轉換[SVG 至 PNG](https://products.aspose.com/slides/zh-hant/java/conversion/svg-to-png/)。  
{{% /alert %}}

## **常見問答**

**此方法是否支援批次轉換？**

是的，Aspose.Slides 允許在單一次操作中將多個投影片批次轉換為 JPG。

**轉換是否支援 SmartArt、圖表及其他複雜物件？**

是的，Aspose.Slides 會渲染所有內容，包括 SmartArt、圖表、表格、形狀等。然而，渲染的精確度與 PowerPoint 相比可能略有差異，特別是使用自訂或缺少的字型時。

**處理的投影片數量是否有任何限制？**

Aspose.Slides 本身未對可處理的投影片數量設定嚴格限制。但在處理大型簡報或高解析度圖像時，可能會遇到記憶體不足的錯誤。