---
title: 在 C++ 中將 PPT 和 PPTX 轉換為 JPG
linktitle: PowerPoint 轉 JPG
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
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint（PPT、PPTX）投影片轉換為高品質 JPG 圖像，提供快速且可靠的程式碼範例。"
---
## **簡介**

將 PowerPoint 和 OpenDocument 簡報轉換為 JPG 圖像有助於共享投影片、優化效能，以及將內容嵌入網站或應用程式中。Aspose.Slides for C++ 允許您將 PPTX、PPT 和 ODP 檔案轉換為高品質的 JPEG 圖像。本指南說明了不同的轉換方法。

藉由這些功能，您可以輕鬆實作自己的簡報檢視器，並為每張投影片建立縮圖。若您想保護投影片免於被複製或以唯讀模式展示簡報，這會非常有用。Aspose.Slides 允許您將整個簡報或特定投影片轉換為圖像格式。

## **將簡報投影片轉換為 JPG 圖像**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 從簡報的投影片集合中取得 [ISlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/) 類型的投影片物件。
3. 使用 [ISlide.GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage/) 方法建立投影片的圖像。
4. 在圖像物件上呼叫 [IImage.Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/save/) 方法，並將輸出檔案名稱與圖像格式作為參數傳入。

{{% alert color="info" %}} 
**注意：** PPT、PPTX 或 ODP 轉換為 JPG 與 Aspose.Slides for C++ API 中轉換為其他格式的方式不同。對於其他格式，通常使用 [IPresentation.Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/save/) 方法。然而，對於 JPG 轉換，您必須使用 [IImage.Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/save/) 方法。
{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // 建立指定比例的投影片圖像。
    auto image = slide->GetImage(scaleX, scaleY);

    // 以 JPEG 格式將圖像儲存至磁碟。
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **將投影片轉換為自訂尺寸的 JPG**

若要更改產生的 JPG 圖像的尺寸，您可以在呼叫 [ISlide.GetImage(Size)](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) 方法時傳入圖像大小。這讓您能產生具有特定寬度與高度的圖像，確保輸出符合您對解析度與長寬比的需求。此彈性特別適用於為 Web 應用程式、報告或文件產生圖像時，需要精確的圖像尺寸。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // 建立指定大小的投影片圖像。
    auto image = slide->GetImage(imageSize);

    // 以 JPEG 格式將圖像儲存至磁碟。
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **在將投影片另存為圖像時呈現批註**

Aspose.Slides for C++ 提供一項功能，可在將簡報投影片轉換為 JPG 圖像時呈現批註。此功能對於保留協作者在 PowerPoint 簡報中加入的註解、回饋或討論特別有用。啟用此選項後，批註會顯示在產生的圖像中，讓您在不需開啟原始簡報檔案的情況下，更輕鬆檢閱與分享回饋。

假設我們有一個簡報檔案「sample.pptx」，其中有投影片包含批註：

![包含批註的投影片](slide_with_comments.png)

以下的 C++ 程式碼會在保留批註的同時將投影片轉換為 JPG 圖像：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // 設定投影片批註的選項。
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

![包含批註的 JPG 圖像](image_with_comments.png)

## **另見**

請參考其他將 PPT、PPTX 或 ODP 轉換為圖像的選項，例如：

- [將 PowerPoint 轉換為 GIF](/slides/zh-hant/cpp/convert-powerpoint-to-animated-gif/)
- [將 PowerPoint 轉換為 PNG](/slides/zh-hant/cpp/convert-powerpoint-to-png/)
- [將 PowerPoint 轉換為 TIFF](/slides/zh-hant/cpp/convert-powerpoint-to-tiff/)
- [將 PowerPoint 轉換為 SVG](/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
欲了解 Aspose.Slides 如何將 PowerPoint 轉換為 JPG 圖像，請試用以下免費線上轉換器：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/zh-hant/conversion/pptx-to-jpg) 與 [PPT to JPG](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-jpg)。
{{% /alert %}}

![免費線上 PPTX 轉 JPG 轉換器](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}
Aspose 提供一個 [FREE Collage web app](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG to JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 到 PNG 圖像，建立 [photo grids](https://products.aspose.app/slides/zh-hant/collage/photo-grid) 等。

依照本文件中描述的相同原理，您可以將圖像從一種格式轉換為另一種格式。欲取得更多資訊，請參閱以下頁面：convert [image to JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/image-to-jpg/)；convert [JPG to image](https://products.aspose.com/slides/zh-hant/cpp/conversion/jpg-to-image/)；convert [JPG to PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/jpg-to-png/)、convert [PNG to JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/png-to-jpg/)；convert [PNG to SVG](https://products.aspose.com/slides/zh-hant/cpp/conversion/png-to-svg/)、convert [SVG to PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/svg-to-png/)。
{{% /alert %}}

## **常見問題**

### 此方法是否支援批次轉換？

是的，Aspose.Slides 允許在單一次操作中批次將多張投影片轉換為 JPG。

### 轉換是否支援 SmartArt、圖表及其他複雜物件？

是的，Aspose.Slides 會呈現所有內容，包括 SmartArt、圖表、表格、形狀等。然而，與 PowerPoint 相比，渲染精確度可能略有差異，特別是在使用自訂或缺少的字型時。

### 處理投影片的數量是否有任何限制？

Aspose.Slides 本身並未對可處理的投影片數量設置嚴格限制。但在處理大型簡報或高解析度圖像時，可能會遇到記憶體不足的錯誤。