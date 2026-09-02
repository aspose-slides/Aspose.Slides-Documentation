---
title: 在 .NET 中將簡報投影片轉換為影像
linktitle: 投影片轉影像
type: docs
weight: 41
url: /zh-hant/net/convert-slide/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 C# 中將 PPT、PPTX 和 ODP 投影片轉換為影像——快速、高品質渲染，並提供清晰的程式碼範例。"
---
## **簡介**

Aspose.Slides for .NET 讓您輕鬆將 PowerPoint 和 OpenDocument 簡報投影片轉換為各種影像格式，包括 BMP、PNG、JPG（JPEG）、GIF 等。

若要將投影片轉換為影像，請遵循以下步驟：

1. 使用以下方式定義所需的轉換設定並選取要匯出的投影片：
    - 使用 [ITiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/itiffoptions/) 介面，或
    - 使用 [IRenderingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/irenderingoptions/) 介面。
2. 呼叫 [GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/getimage/) 方法以產生投影片影像。

在 .NET 中，[Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) 是一個允許您處理以像素資料定義之影像的物件。您可以使用此類別的實例將影像儲存為多種格式（BMP、JPG、PNG 等）。

## **將投影片轉換為位圖並以 PNG 儲存影像**

您可以將投影片轉換為位圖物件，直接在應用程式中使用。或者，您也可以先將投影片轉換為位圖，然後以 JPEG 或其他您偏好的格式儲存影像。

以下 C# 程式碼示範如何將簡報的第一張投影片轉換為位圖物件，並以 PNG 格式儲存影像：

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // 將簡報中的第一張投影片轉換為位圖。
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // 以 PNG 格式儲存影像。
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **將投影片轉換為自訂尺寸的影像**

您可能需要獲取特定尺寸的影像。使用 [GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/getimage/) 的重載，您可以將投影片轉換為具有特定寬度和高度的影像。

以下範例程式碼示範如何執行此操作：

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // 將簡報中的第一張投影片以指定尺寸轉換為位圖。
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // 以 JPEG 格式儲存影像。
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **將含有備註與評論的投影片轉換為影像**

某些投影片可能包含備註與評論。

Aspose.Slides 提供兩個介面——[ITiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/itiffoptions/) 與 [IRenderingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/irenderingoptions/)，讓您能控制簡報投影片轉換為影像的渲染方式。這兩個介面皆包含 `SlidesLayoutOptions` 屬性，您可藉此在將投影片轉換為影像時配置備註與評論的渲染方式。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/notescommentslayoutingoptions/) 類別，您可以指定備註與評論在最終影像中的偏好位置。

以下 C# 程式碼示範如何將含有備註與評論的投影片轉換為影像：

```cs
float scaleX = 2;
float scaleY = scaleX;

// 載入簡報檔案。
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // 建立渲染選項。
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // 設定備註的位置。
            CommentsPosition = CommentsPositions.Right,      // 設定評論的位置。
            CommentsAreaWidth = 500,                         // 設定評論區域的寬度。
            CommentsAreaColor = Color.AntiqueWhite           // 設定評論區域的顏色。
        }
    };

    // 將簡報的第一張投影片轉換為影像。
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // 以 GIF 格式儲存影像。
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 
在任何投影片轉影像的過程中，[NotesPosition](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) 屬性不能設定為 `BottomFull`（指定備註的位置），因為備註文字可能過長，無法容納於指定的影像尺寸內。
{{% /alert %}} 

## **使用 TIFF 選項將投影片轉換為影像**

[ITiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/itiffoptions/) 介面允許您指定尺寸、解析度、色彩調色盤等參數，從而更精細地控制最終的 TIFF 影像。

以下 C# 程式碼示範使用 TIFF 選項輸出 300 DPI 解析度、尺寸為 2160 × 2800 的黑白影像的轉換過程：

```cs
// 載入簡報檔案。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 取得簡報的第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 設定輸出 TIFF 影像的參數。
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // 設定影像尺寸。
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // 設定像素格式（黑白）。
        DpiX = 300,                                        // 設定水平解析度。
        DpiY = 300                                         // 設定垂直解析度。
    };

    // 使用指定的選項將投影片轉換為影像。
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // 以 TIFF 格式儲存影像。
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **將所有投影片轉換為影像**

Aspose.Slides 讓您將簡報中的所有投影片轉換為影像，實際上是把整個簡報轉換成一系列的影像。

以下範例程式碼示範如何在 C# 中將簡報的所有投影片轉換為影像：

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // 將簡報逐張投影片渲染為影像。
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // 控制隱藏的投影片（不渲染隱藏的投影片）。
        if (presentation.Slides[i].Hidden)
            continue;

        // 將投影片轉換為影像。
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // 以 JPEG 格式儲存影像。
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **彩色表情符號渲染**

{{% alert title="Note" color="warning" %}} 
在將簡報投影片轉換為影像時正確呈現彩色表情符號，必須在執行轉換的系統上安裝並提供簡報中使用的表情符號字型。例如，若簡報使用 **Segoe UI Emoji**，但此字型缺失，則輸出影像中的表情符號可能會以單色顯示。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 支援渲染包含動畫的投影片嗎？**

不支援，`GetImage` 方法僅儲存投影片的靜態影像，且不包含動畫。

**隱藏的投影片可以匯出為影像嗎？**

可以，隱藏的投影片可像一般投影片一樣處理。只需確保它們已包含在處理迴圈中。

**影像可以儲存陰影與效果嗎？**

可以，Aspose.Slides 支援在將投影片儲存為影像時渲染陰影、透明度以及其他圖形效果。