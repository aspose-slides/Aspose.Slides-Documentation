---
title: 在 .NET 中將 PPT 和 PPTX 轉換為 JPG
linktitle: PowerPoint 轉 JPG
type: docs
weight: 60
url: /zh-hant/net/convert-powerpoint-to-jpg/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 於 C# 中將 PowerPoint (PPT、PPTX) 投影片轉換為高品質 JPG 影像，並提供快速、可靠的程式碼範例。"
---
## **簡介**

將 PowerPoint 與 OpenDocument 簡報轉換為 JPG 影像有助於共享投影片、提升效能，以及將內容嵌入網站或應用程式中。Aspose.Slides for .NET 允許您將 PPTX、PPT 與 ODP 檔案轉換為高品質 JPEG 影像。本指南說明不同的轉換方法。

有了這些功能，您可以輕鬆實作自己的簡報檢視器，並為每張投影片建立縮圖。若您想保護投影片不被複製或以唯讀模式展示簡報，這將非常有用。Aspose.Slides 允許您將整份簡報或特定投影片轉換為影像格式。

## **將簡報投影片轉換為 JPG 影像**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 從 [Presentation.Slides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/properties/slides) 集合中取得 [ISlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide) 類型的投影片物件。
3. 使用 [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/getimage/#getimage_5) 方法建立投影片的影像。
4. 在影像物件上呼叫 [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/save/#save_3) 方法，並傳入輸出檔名與影像格式作為參數。

{{% alert color="primary" %}} 
**注意:** PPT、PPTX 或 ODP 轉換為 JPG 與 Aspose.Slides .NET API 中轉換為其他格式的方式不同。對於其他格式，通常使用 [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/save/#save_5) 方法。然而，轉換為 JPG 時，必須使用 [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/save/#save_3) 方法。
{{% /alert %}} 

```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 建立具有指定比例的投影片影像。
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // 以 JPEG 格式將影像儲存到磁碟。
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **使用自訂尺寸將投影片轉換為 JPG**

若要變更產生的 JPG 影像尺寸，您可以在呼叫 [ISlide.GetImage(Size)](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/getimage/#getimage_6) 方法時傳入圖片大小。這使您能夠產生具有特定寬度與高度的影像，確保輸出符合解析度與長寬比的需求。此彈性在為 Web 應用程式、報告或文件產生影像，且需要精確尺寸時，特別有用。

```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 建立具有指定大小的投影片影像。
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // 以 JPEG 格式將影像儲存到磁碟。
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **儲存投影片為影像時呈現註解**

Aspose.Slides for .NET 提供一項功能，讓您在將簡報投影片轉換為 JPG 影像時，能夠呈現註解。此功能對於保留協作者在 PowerPoint 簡報中加入的標註、回饋或討論特別有用。啟用此選項後，註解會顯示在產生的影像中，讓您無需開啟原始簡報檔案即可檢視與分享回饋。

假設我們有一個簡報檔案「sample.pptx」，其中有一張投影片包含註解：

![帶有註解的投影片](slide_with_comments.png)

以下 C# 程式碼在保留註解的同時將投影片轉換為 JPG 影像：

```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // 設定投影片註解的選項。
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // 將第一張投影片轉換為影像。
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

結果：

![帶有註解的 JPG 影像](image_with_comments.png)

## **另請參閱**

請參考其他將 PPT、PPTX 或 ODP 轉換為影像的選項，例如：

- [將 PowerPoint 轉換為 GIF](/slides/zh-hant/net/convert-powerpoint-to-animated-gif/)
- [將 PowerPoint 轉換為 PNG](/slides/zh-hant/net/convert-powerpoint-to-png/)
- [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/net/convert-powerpoint-to-tiff/)
- [將 PowerPoint 轉換為 SVG](/slides/zh-hant/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
要了解 Aspose.Slides 如何將 PowerPoint 轉換為 JPG 影像，請嘗試以下免費線上轉換工具：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/zh-hant/conversion/pptx-to-jpg) 與 [PPT to JPG](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-jpg)。
{{% /alert %}} 

![免費線上 PPTX 轉 JPG 轉換器](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose 提供一個 [FREE Collage web app](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG to JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 到 PNG 的影像，建立 [photo grids](https://products.aspose.app/slides/zh-hant/collage/photo-grid) 等等。

使用本文所述的相同原理，您可以將影像從一種格式轉換為另一種格式。欲了解更多資訊，請參閱以下頁面：轉換 [image to JPG](https://products.aspose.com/slides/zh-hant/net/conversion/image-to-jpg/)、轉換 [JPG to image](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-image/)、轉換 [JPG to PNG](https://products.aspose.com/slides/zh-hant/net/conversion/jpg-to-png/)、轉換 [PNG to JPG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-jpg/)、轉換 [PNG to SVG](https://products.aspose.com/slides/zh-hant/net/conversion/png-to-svg/)、轉換 [SVG to PNG](https://products.aspose.com/slides/zh-hant/net/conversion/svg-to-png/)。
{{% /alert %}}

## **常見問題**

**此方法是否支援批次轉換？**  
是，Aspose.Slides 允許在單一次操作中批次將多張投影片轉換為 JPG。

**轉換是否支援 SmartArt、圖表和其他複雜物件？**  
是，Aspose.Slides 會渲染所有內容，包括 SmartArt、圖表、表格、形狀等。然而，與 PowerPoint 相比，渲染的準確度可能會稍有差異，特別是在使用自訂或缺少的字型時。

**處理的投影片數量是否有限制？**  
Aspose.Slides 本身並未對可處理的投影片數量設定嚴格限制。然而，處理大型簡報或高解析度影像時，可能會遇到記憶體不足的錯誤。