---
title: 將簡報投影片轉換為影像（C++）
linktitle: 投影片轉影像
type: docs
weight: 41
url: /zh-hant/cpp/convert-slide/
keywords:
- 轉換投影片
- 匯出投影片
- 投影片轉影像
- 將投影片儲存為影像
- 投影片轉 PNG
- 投影片轉 JPEG
- 投影片轉位圖
- 投影片轉 TIFF
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將 PPT、PPTX 與 ODP 投影片轉換為影像——快速、高品質的渲染，提供清晰的程式碼範例。"
---
## **簡介**

Aspose.Slides for C++ 讓您能輕鬆地將 PowerPoint 和 OpenDocument 簡報投影片轉換為各種影像格式，包括 BMP、PNG、JPG（JPEG）、GIF 等。

若要將投影片轉換為影像，請依照以下步驟：

1. 定義所需的轉換設定，並使用以下方式選取您想匯出的投影片：
    - [ITiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/itiffoptions/) 介面，或
    - [IRenderingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/irenderingoptions/) 介面。
2. 呼叫 [GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage/) 方法以產生投影片影像。

[Bitmap](https://reference.aspose.com/slides/zh-hant/cpp/system.drawing/bitmap/) 是一個允許您處理以像素資料定義的影像的物件。您可以使用此類別的實例將影像儲存為多種格式 (BMP、JPG、PNG 等)。

## **將投影片轉換為位圖並以 PNG 儲存影像**

您可以將投影片轉換為位圖物件，直接在應用程式中使用。或者，您也可以先將投影片轉換為位圖，然後以 JPEG 或其他您偏好的格式儲存影像。

以下 C++ 程式碼示範如何將簡報的第一張投影片轉換為位圖物件，並以 PNG 格式儲存影像：

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// 將簡報中的第一張投影片轉換為位圖。
auto image = presentation->get_Slide(0)->GetImage();

// 以 PNG 格式儲存影像。
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **以自訂尺寸將投影片轉換為影像**

您可能需要取得特定尺寸的影像。使用 [GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage/) 的多載，您可以將投影片轉換為具指定寬度與高度的影像。

以下範例程式碼示範如何操作：

```cpp
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// 將簡報中的第一張投影片轉換為指定大小的位圖。
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// 以 JPEG 格式儲存影像。
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **將包含註解與評論的投影片轉換為影像**

某些投影片可能包含註解與評論。

Aspose.Slides 提供兩個介面——[ITiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/itiffoptions/) 與 [IRenderingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/irenderingoptions/)——讓您能控制簡報投影片轉換為影像的渲染方式。兩個介面皆包含 `set_SlidesLayoutOptions` 方法，可在將投影片轉換為影像時，設定註解與評論的渲染方式。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notescommentslayoutingoptions/) 類別，您可以指定註解與評論在最終影像中的顯示位置。

以下 C++ 程式碼示範如何將含有註解與評論的投影片轉換為影像：

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// 載入簡報檔案。
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // 設定註解的位置。
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // 設定評論的位置。
notesCommentsOptions->set_CommentsAreaWidth(500);                          // 設定評論區域的寬度。
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // 設定評論區域的顏色。

// 建立渲染選項。
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// 將簡報的第一張投影片轉換為影像。
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// 以 GIF 格式儲存影像。
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
在任何投影片轉影像的轉換過程中，[set_NotesPosition](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) 方法無法套用 `BottomFull`（指定註解位置），因為註解文字可能過長，無法適應指定的影像尺寸。
{{% /alert %}} 

## **使用 TIFF 選項將投影片轉換為影像**

[ITiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/itiffoptions/) 介面提供更精細的控制，讓您能指定大小、解析度、色彩調色盤等參數，以產生符合需求的 TIFF 影像。

以下 C++ 程式碼示範使用 TIFF 選項輸出 300 DPI、尺寸為 2160 × 2800 的黑白影像的轉換過程：

```cpp 
// 載入簡報檔案。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 取得簡報的第一張投影片。
auto slide = presentation->get_Slide(0);

// 設定輸出 TIFF 影像的參數。
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // 設定影像大小。
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // 設定像素格式（黑白）。
tiffOptions->set_DpiX(300);                                         // 設定水平解析度。
tiffOptions->set_DpiY(300);                                         // 設定垂直解析度。

// 將投影片轉換為具有指定選項的影像。
auto image = slide->GetImage(tiffOptions);

// 以 TIFF 格式儲存影像。
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **將所有投影片轉換為影像**

Aspose.Slides 允許您將簡報中的所有投影片轉換為影像，從而將整個簡報轉換為一系列影像。

以下範例程式碼示範如何在 C++ 中將簡報的所有投影片轉換為影像：

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// 將簡報逐張投影片渲染為影像。
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // 控制隱藏投影片（不渲染隱藏投影片）。
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // 將投影片轉換為影像。
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // 以 JPEG 格式儲存影像。
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **常見問題**

**Aspose.Slides 是否支援渲染含有動畫的投影片？**

不會，`GetImage` 方法僅儲存投影片的靜態影像，不包含動畫。

**隱藏的投影片可以匯出為影像嗎？**

可以，隱藏的投影片可與一般投影片同樣處理。只需確保在處理迴圈中包含它們即可。

**影像可以儲存陰影與特效嗎？**

可以，Aspose.Slides 在將投影片儲存為影像時支援渲染陰影、透明度和其他圖形效果。