---
title: 在 .NET 中將 PowerPoint 投影片轉換為 PNG
linktitle: PowerPoint 轉 PNG
type: docs
weight: 30
url: /zh-hant/net/convert-powerpoint-to-png/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 PNG
- 簡報 轉 PNG
- 投影片 轉 PNG
- PPT 轉 PNG
- PPTX 轉 PNG
- 將 PPT 儲存為 PNG
- 將 PPTX 儲存為 PNG
- 匯出 PPT 為 PNG
- 匯出 PPTX 為 PNG
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 快速將 PowerPoint 簡報轉換為高品質 PNG 圖片，確保精確且自動化的結果。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 PNG 圖片。它展示了如何載入 PPT、PPTX、ODP 等格式的簡報檔案，將投影片渲染為圖像，並以 PNG 格式儲存結果。

本文亦示範如何透過設定比例值或指定所需的寬度與高度，來自訂產生的 PNG 圖片。

## **將 PowerPoint 轉換為 PNG**

遵循以下步驟：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別。
2. 從 [Presentation.Slides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/properties/slides) 集合中取得 [ISlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide) 介面的投影片物件。
3. 使用 [ISlide.GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/getimage/) 方法取得每張投影片的縮圖。
4. 使用 [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ipresentation/save/methods/5) 方法將投影片縮圖另存為 PNG 格式。

以下 C# 程式碼示範如何將 PowerPoint 簡報轉換為 PNG。Presentation 物件可以載入 PPT、PPTX、ODP 等，然後將簡報中的每張投影片轉換為 PNG 或其他圖像格式。

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **將 PowerPoint 轉換為 PNG（自訂尺寸）**

如果您希望取得具有特定比例的 PNG 檔案，可設定 `desiredX` 與 `desiredY` 的數值，以決定產生縮圖的尺寸。

以下 C# 程式碼示範上述操作：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **將 PowerPoint 轉換為 PNG（自訂大小）**

如果您希望取得具有特定大小的 PNG 檔案，可為 `imageSize` 傳入偏好的 `width` 與 `height` 參數。

以下程式碼示範在指定圖像大小的情況下，將 PowerPoint 轉換為 PNG：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **常見問題**

**如何僅匯出特定形狀（例如圖表或圖片），而不是整張投影片？**

Aspose.Slides 支援[產生單一形狀的縮圖](/slides/zh-hant/net/create-shape-thumbnails/); 您可以將形狀渲染為 PNG 圖像。

**伺服器上是否支援平行轉換？**

可以，但請[不要共享](/slides/zh-hant/net/multithreading/) 同一個簡報實例於多執行緒。每個執行緒或程序應使用獨立的實例。

**匯出 PNG 時試用版有限制嗎？**

評估模式會在輸出圖像上添加浮水印，並在套用授權之前實施[其他限制](/slides/zh-hant/net/licensing/)。