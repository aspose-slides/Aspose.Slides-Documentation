---
title: 使用 Python 在簡報中調整形狀大小
linktitle: 調整形狀大小
type: docs
weight: 130
url: /zh-hant/python-net/re-sizing-shapes-on-slide/
keywords:
- 重新調整形狀
- 變更形狀大小
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 .NET 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面配置調整，提升生產力。"
---
## **概覽**

Aspose.Slides for Python 的客戶中最常見的問題之一是如何調整形狀大小，以免在變更投影片尺寸時資料被裁切。這篇簡短的技術文章說明了如何做到這一點。

## **調整形狀大小**

為了避免投影片尺寸變更時形狀錯位，請更新每個形狀的位置與尺寸，使其符合新的投影片版面配置。

```py
import aspose.slides as slides

# 載入簡報檔案。
with slides.Presentation("sample.pptx") as presentation:
    # 取得原始投影片大小。
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # 在不縮放現有形狀的情況下變更投影片大小。
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # 取得新的投影片大小。
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # 在每張投影片上重新調整形狀大小並重新定位。
    for slide in presentation.slides:
        for shape in slide.shapes:
            # 縮放形狀大小。
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # 縮放形狀位置。
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
如果投影片中包含表格，上述程式碼將無法正確運作。此時必須調整表格中每個儲存格的大小。
{{% /alert %}} 

在您的環境中使用以下程式碼來調整包含表格的投影片。對於表格而言，設定寬度或高度屬於特殊情況：必須調整各列高度和欄寬，才能改變表格的整體大小。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 取得原始投影片大小。
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # 在不縮放現有形狀的情況下變更投影片大小。
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # 取得新的投影片大小。
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # 縮放形狀大小。
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # 縮放形狀位置。
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # 縮放形狀大小。
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # 縮放形狀位置。
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # 縮放形狀大小。
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # 縮放形狀位置。
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**在調整投影片大小後，為什麼形狀會變形或被裁切？**

在調整投影片時，形狀會保留原始位置與尺寸，除非明確修改比例。這可能導致內容被裁切或形狀錯位。

**提供的程式碼適用於所有形狀類型嗎？**

基本範例適用於大多數形狀類型（文字方塊、圖像、圖表等）。但對於表格，需要分別處理列與欄，因為表格的高度與寬度是由各儲存格的尺寸決定的。

**在調整投影片時，如何調整表格大小？**

必須遍歷表格的所有列與欄，按比例調整它們的高度與寬度，如第二段程式碼所示。

**此調整方式適用於母片與佈局投影片嗎？**

是的，但也應該遍歷[Masters](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/masters/)和[Layout slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/layout_slides/)，對它們的形狀套用相同的比例邏輯，以確保整個簡報的一致性。

**我可以在調整大小的同時改變投影片的方向（直式/橫式）嗎？**

可以。您可以使用[presentation.slide_size.orientation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/islidesize/orientation/)來變更方向。請確保相應調整比例邏輯，以保留版面配置。

**投影片尺寸有設定上限嗎？**

Aspose.Slides 支援自訂尺寸，但過大的尺寸可能會影響效能或與某些 PowerPoint 版本的相容性。

**如何防止固定長寬比的形狀變形？**

在縮放之前，先檢查形狀的`aspect_ratio_locked`屬性。如果已鎖定，請比例調整寬度或高度，而非分別單獨縮放。