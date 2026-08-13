---
title: 在 Android 上將 PPT 與 PPTX 轉換為 JPG
linktitle: PowerPoint 轉 JPG
type: docs
weight: 60
url: /zh-hant/androidjava/convert-powerpoint-to-jpg/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 JPG
- 簡報 轉 JPG
- 投影片 轉 JPG
- PPT 轉 JPG
- PPTX 轉 JPG
- 將 PowerPoint 儲存為 JPG
- 將 簡報 儲存為 JPG
- 將 投影片 儲存為 JPG
- 將 PPT 儲存為 JPG
- 將 PPTX 儲存為 JPG
- 匯出 PPT 為 JPG
- 匯出 PPTX 為 JPG
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android，在 Java 中快速、可靠的程式範例將 PowerPoint (PPT、PPTX) 投影片轉換為高品質的 JPG 圖片。"
---
## **簡介**

將 PowerPoint 與 OpenDocument 簡報轉換為 JPG 圖片可協助分享投影片、優化效能，並將內容嵌入網站或應用程式中。Aspose.Slides for Android via Java 允許您將 PPTX、PPT 及 ODP 檔案轉換為高品質的 JPEG 圖片。本指南說明了不同的轉換方法。

透過這些功能，您可以輕鬆實作自己的簡報檢視器，並為每張投影片建立縮圖。若您想防止投影片被複製或以唯讀模式展示簡報，這會很有用。Aspose.Slides 允許您將整份簡報或特定投影片轉換為圖像格式。

## **將簡報投影片轉換為 JPG 圖片**

以下是將 PPT、PPTX 或 ODP 檔案轉換為 JPG 的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。  
2. 從由 [Presentation.getSlides()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#getSlides--) 方法回傳的集合中取得類型為 [ISlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/) 的投影片物件。  
3. 使用 [ISlide.getImage(float, float)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#getImage-float-float-) 方法建立投影片的圖像。  
4. 對圖像物件呼叫 [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 方法，並傳入輸出檔名與圖像格式作為參數。

{{% alert color="info" %}} 

**注意：** PPT、PPTX 或 ODP 轉換為 JPG 的方式與在 Aspose.Slides Android via Java API 中轉換為其他格式的方式不同。對於其他格式，通常會使用 [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法。然而，對於 JPG 轉換，您需要使用 [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 方法。

{{% /alert %}} 

```java
import com.aspose.slides.*;

int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 建立具有指定比例的投影片圖像。
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // 將圖像以 JPEG 格式儲存到磁碟。
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

若要變更產生的 JPG 圖片尺寸，您可以將尺寸傳遞給 [ISlide.getImage(Size)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) 方法，以設定圖像大小。這讓您能產生具有特定寬度與高度的圖像，確保輸出符合解析度與長寬比的需求。此彈性在為 Web 應用程式、報告或文件產生圖像，需要精確尺寸時特別有用。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 建立具有指定尺寸的投影片圖像。
        IImage slideImage = slide.getImage(imageSize);

        try {
            // 將圖像以 JPEG 格式儲存到磁碟。
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

## **儲存投影片為圖像時呈現註解**

Aspose.Slides for Android via Java 提供了一項功能，允許您在將簡報投影片轉換為 JPG 圖片時渲染註解。此功能對於保留在 PowerPoint 簡報中由協作者加入的標註、回饋或討論特別有用。啟用此選項後，註解會顯示在產生的圖像中，讓您在不必開啟原始簡報檔的情況下，更容易檢視與分享回饋。

假設我們有一個名為「sample.pptx」的簡報檔，其中有投影片包含註解：

![包含註解的投影片](slide_with_comments.png)

以下 Java 程式碼在保留註解的同時將投影片轉換為 JPG 圖片：

```java
import com.aspose.slides.*;
import java.awt.Color;

int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(new Color(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // 將第一張投影片轉換為圖像。
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

## **另見**

請參考其他將 PPT、PPTX 或 ODP 轉換為圖像的選項，例如：

- [將 PowerPoint 轉換為 GIF](/slides/zh-hant/androidjava/convert-powerpoint-to-animated-gif/)
- [將 PowerPoint 轉換為 PNG](/slides/zh-hant/androidjava/convert-powerpoint-to-png/)
- [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/androidjava/convert-powerpoint-to-tiff/)
- [將 PowerPoint 轉換為 SVG](/slides/zh-hant/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

若想了解 Aspose.Slides 如何將 PowerPoint 簡報轉換為 JPG 圖片，請試用以下免費線上轉換器：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/zh-hant/conversion/pptx-to-jpg) 與 [PPT to JPG](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-jpg)。 

{{% /alert %}} 

![免費線上 PPTX 轉 JPG 轉換器](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose 提供了免費的 Collage 網路應用程式。使用此線上服務，您可以合併 [JPG to JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 到 PNG 圖片，建立 [photo grids](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，等等。利用本文所述的相同原則，您可以將圖像從一種格式轉換為另一種格式。欲了解更多資訊，請參閱以下頁面：將 [image to JPG](https://products.aspose.com/slides/zh-hant/java/conversion/image-to-jpg/) 轉換；將 [JPG to image](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-image/) 轉換；將 [JPG to PNG](https://products.aspose.com/slides/zh-hant/java/conversion/jpg-to-png/) 轉換，將 [PNG to JPG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-jpg/) 轉換；將 [PNG to SVG](https://products.aspose.com/slides/zh-hant/java/conversion/png-to-svg/) 轉換，將 [SVG to PNG](https://products.aspose.com/slides/zh-hant/java/conversion/svg-to-png/) 轉換。

{{% /alert %}}

## **常見問題**

### 此方法是否支援批次轉換？

是的，Aspose.Slides 允許在單一操作中批次將多張投影片轉換為 JPG。

### 轉換是否支援 SmartArt、圖表和其他複雜物件？

是的，Aspose.Slides 會呈現所有內容，包括 SmartArt、圖表、表格、形狀等。然而，與 PowerPoint 相比，呈現精確度可能會因使用自訂或缺少的字型而略有差異。

### 處理的投影片數量是否有限制？

Aspose.Slides 本身不對可處理的投影片數量設置嚴格限制。然而，在處理大型簡報或高解析度圖像時，可能會遇到記憶體不足的錯誤。