---
title: 在 .NET 中調整簡報投影片上的形狀大小
type: docs
weight: 130
url: /zh-hant/net/re-sizing-shapes-on-slide/
keywords:
- 調整形狀
- 更改形狀大小
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面調整，提高工作效率。"
---
## **概述**

Aspose.Slides for .NET 客戶最常問的問題之一是如何調整形狀大小，以便在投影片尺寸變更時，內容不會被截斷。本文將簡要說明如何實現此功能。

## **調整形狀大小**

為了避免投影片尺寸變更時形狀位置錯位，請更新每個形狀的位置和尺寸，使其符合新的投影片版面配置。

```c#
// 載入簡報檔案。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 取得原始投影片尺寸。
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // 變更投影片尺寸而不縮放現有形狀。
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // 取得新投影片尺寸。
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // 重新調整大小並重新定位每張投影片上的形狀。
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // 縮放形狀大小。
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

{{% alert color="primary" %}}
如果投影片中包含表格，上述程式碼將無法正確運作。在此情況下，必須調整表格中每個儲存格的大小。
{{% /alert %}}

在包含表格的投影片上使用以下程式碼進行調整。對於表格，設定寬度或高度屬於特殊情況：必須調整各列高度和欄寬，以改變表格的整體大小。

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 取得原始投影片尺寸。
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // 在不縮放現有形狀的情況下變更投影片尺寸。
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // 取得新投影片尺寸。
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // 縮放形狀大小。
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
                // 縮放形狀大小。
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
            // 縮放形狀大小。
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // 縮放形狀位置。
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
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
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**調整投影片大小後，為什麼形狀會變形或被截斷？**

在調整投影片大小時，形狀會保留原始位置和尺寸，除非明確更改比例。這可能導致內容被裁切或形狀錯位。

**提供的程式碼適用於所有形狀類型嗎？**

基本範例適用於大多數形狀類型（文字方塊、圖片、圖表等）。然而，對於表格，必須分別處理列與欄，因為表格的寬高由各儲存格的尺寸決定。

**調整投影片時，如何調整表格大小？**

需要遍歷表格的所有列和欄，按比例調整它們的高度和寬度，如第二段程式碼所示。

**此調整方式是否適用於母版投影片和版面投影片？**

是的，但也應遍歷 [Masters](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/masters/) 與 [LayoutSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/layoutslides/)，對它們的形狀套用相同的比例邏輯，以確保整個簡報的一致性。

**我可以在調整大小的同時變更投影片方向（直向/橫向）嗎？**

可以。您可設定 [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidesize/orientation/) 來變更方向，並相應調整比例邏輯以維持版面配置。

**投影片大小有設定上限嗎？**

Aspose.Slides 支援自訂尺寸，但過大的尺寸可能會影響效能或與某些 PowerPoint 版本的相容性。

**如何防止固定長寬比的形狀變形？**

在縮放之前，先檢查形狀的 `AspectRatioLocked` 屬性。如果已鎖定，應比例調整寬度或高度，而非分別縮放。