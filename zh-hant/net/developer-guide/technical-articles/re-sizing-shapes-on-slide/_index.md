---
title: 在 .NET 中調整投影片上形狀的大小
type: docs
weight: 130
url: /zh-hant/net/re-sizing-shapes-on-slide/
keywords:
- 調整形狀
- 變更形狀尺寸
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面調整，提高生產力。"
---
## **概述**

Aspose.Slides for .NET 客戶最常問的問題之一是如何調整形狀大小，以便在投影片尺寸變更時，資料不會被截斷。本文短篇技術說明將示範如何完成此操作。

## **調整形狀大小**

為防止投影片尺寸變更時形狀錯位，請更新每個形狀的位置和尺寸，使其符合新的投影片版面配置。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 載入簡報檔案。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 取得原始投影片大小。
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // 在不縮放現有形狀的情況下變更投影片大小。
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // 取得新的投影片大小。
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // 調整每張投影片上形狀的大小與位置。
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // 縮放形狀尺寸。
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // 縮放形狀位置。
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
如果投影片中包含表格，上述程式碼將無法正確運作。在此情況下，必須調整表格中每個儲存格的大小。
{{% /alert %}}

請在您的程式中使用下列程式碼來調整包含表格的投影片大小。對於表格，請僅縮放各列高度與欄寬，而非形狀的寬度與高度——同時縮放兩者會使表格被放大兩次，導致表格移出投影片。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 取得原始投影片大小。
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // 在不縮放現有形狀的情況下變更投影片大小。
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // 設定投影片方向為直向。

    // 取得新的投影片大小。
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // 縮放形狀尺寸。
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // 縮放形狀位置。
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // 縮放形狀尺寸。
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // 縮放形狀位置。
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // 透過列與欄縮放表格大小。
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
            else
            {
                // 縮放形狀尺寸。
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // 縮放形狀位置。
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

### 為什麼在調整投影片大小後，形狀會變形或被截斷？

在調整投影片大小時，形狀會保留原本的位置與尺寸，除非明確變更比例。這可能導致內容被裁切或形狀錯位。

### 提供的程式碼是否適用於所有形狀類型？

基本範例適用於大多數形狀類型（文字方塊、圖片、圖表等）。然而，對於表格，必須分別處理列與欄，因為表格的高度與寬度是由各儲存格的尺寸決定的。

### 在調整投影片大小時，如何調整表格尺寸？

您需要遍歷表格的所有列與欄，並按比例調整它們的高度與寬度，如第二個程式碼範例所示。

### 此調整方式是否適用於母片投影片與版面投影片？

是的，但您也應遍歷 [Masters](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/masters/) 與 [LayoutSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/layoutslides/)，對其形狀套用相同的縮放邏輯，以確保整個簡報的一致性。

### 我可以在調整大小的同時變更投影片的方向（直向/橫向）嗎？

可以。您可以設定 [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidesize/orientation/) 以變更方向。請確保相應地調整縮放邏輯，以保留版面配置。

### 我可以設定的投影片尺寸是否有限制？

Aspose.Slides 支援自訂尺寸，但過大的尺寸可能會影響效能或與某些 PowerPoint 版本的相容性。

### 如何防止固定長寬比的形狀變形？

在縮放前，您可以檢查形狀的 `AspectRatioLocked` 屬性。若該屬性被鎖定，請成比例調整寬度或高度，而非分別縮放。