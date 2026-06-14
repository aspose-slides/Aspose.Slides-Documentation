---
title: 在 C++ 中將 PPT 與 PPTX 轉換為 JPG
linktitle: PowerPoint 轉換為 JPG
type: docs
weight: 60
url: /zh-hant/cpp/convert-powerpoint-to-jpg/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint (PPT、PPTX) 投影片轉換為高品質 JPG 圖像，提供快速且可靠的程式範例。"
---
## **簡介**

將 PowerPoint 與 OpenDocument 簡報轉換為 JPG 圖像可協助共享投影片、優化效能，以及將內容嵌入網站或應用程式。Aspose.Slides for C++ 允許您將 PPTX、PPT 與 ODP 檔案轉換為高品質的 JPEG 圖像。本指南說明了不同的轉換方法。

有了這些功能，您可以輕鬆實作自己的簡報檢視器，並為每張投影片建立縮圖。若要防止投影片被複製或以唯讀模式展示簡報，此功能非常實用。Aspose.Slides 可將整個簡報或特定投影片轉換為圖像格式。

## **將簡報投影片轉換為 JPG 圖像**

以下是將 PPT、PPTX 或 ODP 檔案轉換為 JPG 的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
2. 從簡報的投影片集合中取得 [ISlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/) 型別的投影片物件。  
3. 使用 [ISlide.GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage/) 方法建立投影片的圖像。  
4. 在圖像物件上呼叫 [IImage.Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/save/) 方法，將輸出檔名與圖像格式作為參數傳遞。

{{% alert color="primary" %}} 

**注意：** PPT、PPTX 或 ODP 轉換為 JPG 與在 Aspose.Slides for C++ API 中轉換為其他格式的方式不同。對於其他格式，通常使用 [IPresentation.Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/save/) 方法。然而，對於 JPG 轉換，必須使用 [IImage.Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/save/) 方法。

{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // 建立指定比例的投影片圖像。
    auto image = slide->GetImage(scaleX, scaleY);

    // 將圖像以 JPEG 格式儲存至磁碟。
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **使用自訂尺寸將投影片轉換為 JPG**

若要變更產生的 JPG 圖像尺寸，可在呼叫 [ISlide.GetImage(Size)](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) 方法時傳入圖像大小。這讓您能以特定的寬度與高度產生圖像，確保輸出符合解析度與長寬比的需求。此彈性在為網頁應用程式、報告或文件產生精確尺寸的圖像時尤為有用。

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // 建立指定尺寸的投影片圖像。
    auto image = slide->GetImage(imageSize);

    // 將圖像以 JPEG 格式儲存至磁碟。
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **儲存投影片為圖像時呈現註解**

Aspose.Slides for C++ 提供在將簡報投影片轉換為 JPG 圖像時呈現註解的功能。此功能對於保留 PowerPoint 簡報中協作者加入的標註、回饋或討論特別有用。啟用此選項後，註解將顯示在產生的圖像中，方便在不開啟原始簡報檔的情況下檢閱與分享回饋。

假設我們有一個名為「sample.pptx」的簡報檔案，其中包含帶有註解的投影片：

![含註解的投影片](slide_with_comments.png)

以下 C++ 程式碼在轉換投影片為 JPG 圖像的同時保留了註解：

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // 設定投影片註解的選項。
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // 將第一張投影片轉換為圖像。
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

結果：

![含註解的 JPG 圖像](image_with_comments.png)

## **相關參考**

請參閱其他將 PPT、PPTX 或 ODP 轉換為圖像的選項，例如：

- [將 PowerPoint 轉換為 GIF](/slides/zh-hant/cpp/convert-powerpoint-to-animated-gif/)  
- [將 PowerPoint 轉換為 PNG](/slides/zh-hant/cpp/convert-powerpoint-to-png/)  
- [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/cpp/convert-powerpoint-to-tiff/)  
- [將 PowerPoint 轉換為 SVG](/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

想了解 Aspose.Slides 如何將 PowerPoint 轉換為 JPG 圖像，請試試以下免費線上轉換工具：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/zh-hant/conversion/pptx-to-jpg) 與 [PPT to JPG](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-jpg)。 

{{% /alert %}}

![免費線上 PPTX 轉 JPG 轉換器](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose 提供免費的 [Collage 網路應用程式](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG to JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG to PNG 圖像，建立 [photo grids](https://products.aspose.app/slides/zh-hant/collage/photo-grid) 等。

依照本文所述的相同原則，您可以將圖像從一種格式轉換為另一種格式。更多資訊請參閱以下頁面：轉換 [image to JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/image-to-jpg/)；轉換 [JPG to image](https://products.aspose.com/slides/zh-hant/cpp/conversion/jpg-to-image/)；轉換 [JPG to PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/jpg-to-png/)，轉換 [PNG to JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/png-to-jpg/)；轉換 [PNG to SVG](https://products.aspose.com/slides/zh-hant/cpp/conversion/png-to-svg/)，轉換 [SVG to PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/svg-to-png/)。

{{% /alert %}}

## **常見問題**

**此方法支援批次轉換嗎？**

是的，Aspose.Slides 可在單一操作中批次將多張投影片轉換為 JPG。

**轉換是否支援 SmartArt、圖表及其他複雜物件？**

是的，Aspose.Slides 會渲染所有內容，包括 SmartArt、圖表、表格、圖形等。但相較於 PowerPoint，渲染精確度可能因使用自訂或缺少的字型而略有差異。

**處理的投影片數量有任何限制嗎？**

Aspose.Slides 本身對可處理的投影片數量沒有嚴格限制。然而，對於大型簡報或高解析度圖像，可能會遇到記憶體不足的錯誤。