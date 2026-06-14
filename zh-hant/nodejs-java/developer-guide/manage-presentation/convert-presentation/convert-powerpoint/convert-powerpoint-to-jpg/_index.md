---
title: 在 JavaScript 中將 PPT 與 PPTX 轉換為 JPG
linktitle: PowerPoint 轉 JPG
type: docs
weight: 60
url: /zh-hant/nodejs-java/convert-powerpoint-to-jpg/
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
- 將簡報儲存為 JPG
- 將投影片儲存為 JPG
- 將 PPT 儲存為 JPG
- 將 PPTX 儲存為 JPG
- 匯出 PPT 為 JPG
- 匯出 PPTX 為 JPG
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides for Node.js via Java，透過快速且可靠的程式碼範例，將 PowerPoint（PPT、PPTX）投影片轉換為高品質 JPG 圖像。"
---
## **簡介**

將 PowerPoint 與 OpenDocument 簡報轉換為 JPG 影像有助於共享投影片、優化效能，並將內容嵌入網站或應用程式中。Aspose.Slides 允許您將 PPTX、PPT 與 ODP 檔案轉換為高品質的 JPEG 影像。本指南說明了不同的轉換方法。

有了這些功能，您可以輕鬆實作自己的簡報檢視器，並為每張投影片建立縮圖。如果您想防止投影片被複製或以唯讀模式展示簡報，這將非常有用。Aspose.Slides 支援將整個簡報或特定投影片轉換為影像格式。

## **將 PowerPoint PPT/PPTX 轉換為 JPG**
以下是將 PPT/PPTX 轉換為 JPG 的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類型的實例。
2. 從 [Presentation.getSlides()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getSlides--) 集合中取得 [Slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Slide) 類型的投影片物件。
3. 為每張投影片建立縮圖，然後將其轉換為 JPG。使用 [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Slide#getImage-float-float-) 方法取得投影片的縮圖，該方法會回傳 [Imagess](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Images) 物件。必須在所需的 [Slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Slide) 類型投影片上呼叫 [getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) 方法，並將縮圖的比例參數傳入該方法。
4. 取得投影片縮圖後，從縮圖物件呼叫 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/#save) 方法，並傳入檔案名稱與影像格式。

{{% alert color="primary" %}}
**注意**：PPT/PPTX 轉換為 JPG 與 Aspose.Slides API 中轉換為其他類型的方式不同。對於其他類型，通常使用 [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) 方法，但此處需要使用 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/iimage/#save) 方法。
{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // 建立完整比例的影像
        var slideImage = sld.getImage(1.0, 1.0);
        // 將影像以 JPEG 格式儲存至磁碟
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將 PowerPoint PPT/PPTX 轉換為具有自訂尺寸的 JPG**
若要變更產生的縮圖與 JPG 影像的尺寸，您可以在呼叫 [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Slide#getImage-float-float-) 方法時傳入 *ScaleX* 與 *ScaleY* 值：

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // 定義尺寸
    var desiredX = 1200;
    var desiredY = 800;
    // 取得 X 與 Y 的比例值
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // 建立完整比例的影像
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // 將影像以 JPEG 格式儲存至磁碟
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在將簡報儲存為影像時呈現註解**
Aspose.Slides for Node.js via Java 提供一項功能，可在將投影片轉換為影像時呈現簡報中的註解。以下 JavaScript 程式碼示範此操作：

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}
Aspose 提供一個 [免費的 Collage 網路應用程式](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG 到 JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 到 PNG 影像，建立 [相片格線](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，等等。 
{{% /alert %}}

## **另請參閱**

其他將 PPT/PPTX 轉換為影像的選項包括：

- [PPT/PPTX 轉換為 SVG](/slides/zh-hant/nodejs-java/render-a-slide-as-an-svg-image/)。

## **常見問題**

**此方法是否支援批次轉換？**

是的，Aspose.Slides 允許在一次操作中將多張投影片批次轉換為 JPG。

**轉換是否支援 SmartArt、圖表和其他複雜物件？**

是的，Aspose.Slides 會呈現所有內容，包括 SmartArt、圖表、表格、形狀等。但與 PowerPoint 相比，渲染精確度可能會略有差異，特別是在使用自訂或缺少的字型時。

**處理的投影片數量有任何限制嗎？**

Aspose.Slides 本身並未對可處理的投影片數量設置嚴格限制。但在處理大型簡報或高解析度影像時，可能會遇到記憶體不足的錯誤。