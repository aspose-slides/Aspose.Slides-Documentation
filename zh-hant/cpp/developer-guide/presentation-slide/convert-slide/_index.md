---
title: 將簡報投影片轉換為 C++ 圖像
linktitle: 投影片轉影像
type: docs
weight: 41
url: /zh-hant/cpp/convert-slide/
keywords: 
- 轉換投影片
- 匯出投影片
- 投影片轉圖像
- 將投影片儲存為圖像
- 投影片轉 PNG
- 投影片轉 JPEG
- 投影片轉 Bitmap
- 投影片轉 TIFF
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將 PPT、PPTX 與 ODP 簡報投影片轉換為圖像——快速、高品質的渲染，並提供清晰的程式碼範例。"
---
## **簡介**

Aspose.Slides for C++ 讓您輕鬆將 PowerPoint 和 OpenDocument 簡報投影片轉換為各種影像格式，包括 BMP、PNG、JPG（JPEG）、GIF 等。

將投影片轉換為影像，請依照以下步驟：

1. 定義所需的轉換設定，並使用以下方式選取要匯出的投影片：
    - [ITiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/itiffoptions/) 介面，或
    - [IRenderingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/irenderingoptions/) 介面。
2. 呼叫 [GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage/) 方法產生投影片影像。

[Bitmap](https://reference.aspose.com/slides/zh-hant/cpp/system.drawing/bitmap/) 是一個允許您使用像素資料操作影像的物件。您可以使用此類別的實例將影像儲存為多種格式（BMP、JPG、PNG 等）。

## **將投影片轉換為 Bitmap 並以 PNG 儲存影像**

您可以將投影片轉換為 Bitmap 物件，直接在應用程式中使用。或者，您也可以先轉換為 Bitmap，然後將影像儲存為 JPEG 或其他喜好的格式。

以下 C++ 程式碼示範如何將簡報的第一張投影片轉換為 Bitmap 物件，並以 PNG 格式儲存影像：

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// 將簡報中的第一張投影片轉換為 bitmap。
auto image = presentation->get_Slide(0)->GetImage();

// 以 PNG 格式儲存影像。
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **將投影片轉換為自訂尺寸的影像**

有時您需要取得特定尺寸的影像。透過 [GetImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/getimage/) 的重載，您可以將投影片轉換為具有特定寬度與高度的影像。

以下範例程式碼示範如何實作：

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// 將簡報中的第一張投影片以指定尺寸轉換為 bitmap。
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// 以 JPEG 格式儲存影像。
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **將含備註與註解的投影片轉換為影像**

某些投影片可能包含備註與註解。

Aspose.Slides 提供兩個介面——[ITiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/itiffoptions/) 與 [IRenderingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/irenderingoptions/)——讓您在將簡報投影片轉換為影像時控制渲染行為。兩個介面皆包含 `set_SlidesLayoutOptions` 方法，讓您在轉換時設定備註與註解的渲染方式。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notescommentslayoutingoptions/) 類別，您可以指定備註與註解在最終影像中的位置。

以下 C++ 程式碼示範如何將含備註與註解的投影片轉換為影像：

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// 載入簡報檔案。
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // 設定備註的位置。
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // 設定註解的位置。
notesCommentsOptions->set_CommentsAreaWidth(500);                          // 設定註解區域的寬度。
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // 設定註解區域的顏色。

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
在任何投影片轉影像的過程中，[set_NotesPosition](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) 方法無法套用 `BottomFull`（指定備註位置），因為備註文字可能過長，無法容納在指定的影像大小內。
{{% /alert %}} 

## **使用 TIFF 選項將投影片轉換為影像**

[ITiffOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/itiffoptions/) 介面允許您透過設定尺寸、解析度、色彩調色盤等參數，更精細地控制最終的 TIFF 影像。

以下 C++ 程式碼示範如何使用 TIFF 選項輸出 300 DPI、尺寸為 2160 × 2800 的黑白影像：

```cpp 
// 載入簡報檔案。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 從簡報取得第一張投影片。
auto slide = presentation->get_Slide(0);

// 設定輸出 TIFF 影像的參數。
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // 設定影像尺寸。
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // 設定像素格式（黑白）。
tiffOptions->set_DpiX(300);                                         // 設定水平解析度。
tiffOptions->set_DpiY(300);                                         // 設定垂直解析度。

// 使用指定的選項將投影片轉換為影像。
auto image = slide->GetImage(tiffOptions);

// 以 TIFF 格式儲存影像。
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **將所有投影片轉換為影像**

Aspose.Slides 允許您將簡報中的所有投影片一次轉換為影像，等同於將整份簡報轉成一系列影像。

以下範例程式碼示範如何在 C++ 中將簡報的所有投影片轉換為影像：

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// 逐張投影片將簡報渲染為影像。
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

## **彩色表情符號渲染**

{{% alert title="Note" color="warning" %}} 
在將簡報投影片轉換為影像時，若要正確呈現彩色表情符號，簡報中使用的表情符號字型必須已安裝且可在執行轉換的系統上取得。例如，若簡報使用 **Segoe UI Emoji** 且此字型缺失，則輸出影像中的表情符號可能會以單色顯示。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援渲染含動畫的投影片？**

不支援，`GetImage` 方法僅儲存投影片的靜態影像，不會包含動畫。

**隱藏的投影片可以匯出為影像嗎？**

可以，隱藏的投影片可像一般投影片一樣處理，只要確保它們被納入處理迴圈即可。

**能否將影像儲存為帶有陰影和效果的版本？**

可以，Aspose.Slides 在將投影片儲存為影像時支援渲染陰影、透明度以及其他圖形效果。