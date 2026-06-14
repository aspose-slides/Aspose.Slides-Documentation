---
title: 管理 Python 簡報的頁眉與頁腳
linktitle: 頁眉與頁腳
type: docs
weight: 140
url: /zh-hant/python-net/presentation-header-and-footer/
keywords:
- 頁眉
- 頁眉文字
- 頁腳
- 頁腳文字
- 設定頁眉
- 設定頁腳
- 講義
- 備註
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 透過 .NET，在 PowerPoint 與 OpenDocument 簡報中新增與自訂頁眉與頁腳，打造專業外觀。"
---
## **概觀**

Aspose.Slides for Python 讓您能夠在簡報中精確控制頁眉與頁腳佔位符的範圍。頁腳文字、日期/時間以及投影片編號由母片層級管理，且可全域套用或依個別投影片調整。頁眉在備註與講義上受支援，您可透過母備註投影片或個別備註投影片的專屬頁眉與頁腳管理器切換可見性，並設定頁眉、頁腳、日期/時間與頁碼的文字。本文件概述了更新這些佔位符並在您的簡報中一致傳遞變更的主要模式。

## **管理頁眉與頁腳文字**

在本節中，您將學習如何在簡報中管理頁眉與頁腳內容——啟用或修改頁腳、日期與時間以及投影片編號。我們將簡要說明套用這些設定的範圍（整個簡報、個別投影片，以及備註/講義檢視），並示範如何使用 Aspose.Slides API 迅速且一致地更新它們。

以下程式碼範例會開啟簡報、啟用並設定頁腳文字、更新母備註投影片上的頁眉文字，並儲存檔案。

```py
import aspose.slides as slides

# 設定頁眉文字的函式。
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Load the presentation.
with slides.Presentation("sample.pptx") as presentation:
    # 設定頁腳。
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # 存取並更新頁眉。
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # 儲存簡報。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **管理備註投影片的頁眉與頁腳**

在本節中，您將學習如何在 Aspose.Slides 中專門管理備註投影片的頁眉與頁腳。我們將說明如何啟用相關佔位符、設定頁腳、日期/時間與頁碼的文字，並在備註母片與各個備註頁面上持續套用這些變更。

請依照以下步驟操作：

1. 載入簡報檔案。
1. 取得母備註投影片及其[頁眉與頁腳管理器](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/masternotesslideheaderfootermanager/)。
1. 在母備註投影片上，為母片與所有子備註投影片啟用頁眉、頁腳、投影片編號與日期/時間的可見性。
1. 在母備註投影片上，為母片與所有子備註投影片設定頁眉、頁腳與日期/時間的文字。
1. 取得第一張投影片的備註投影片及其[頁眉與頁腳管理器](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/notesslideheaderfootermanager/)。
1. 僅對此第一張備註投影片，確保頁眉、頁腳、投影片編號與日期/時間皆為可見（將未啟用的項目打開）。
1. 僅對此第一張備註投影片，設定頁眉、頁腳與日期/時間的文字。
1. 以 PPTX 格式儲存簡報。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # 使母備註投影片以及所有子頁眉、頁腳、投影片編號與日期/時間佔位符可見。
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # 在母備註投影片以及所有子頁眉、頁腳與日期/時間佔位符上設定文字。
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # 僅為第一張備註投影片變更頁眉、頁腳、投影片編號與日期/時間設定。
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # 確保頁眉、頁腳、投影片編號與日期/時間佔位符為可見。
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # 在備註投影片的頁眉、頁腳與日期/時間佔位符上設定文字。
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # 儲存簡報。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**我可以在一般投影片上加入「頁眉」嗎？**

在 PowerPoint 中，頁眉僅存在於備註與講義；在一般投影片上，支援的元素只有頁腳、日期/時間與投影片編號。在 Aspose.Slides 中也遵循相同限制：頁眉僅適用於備註/講義，而投影片上則為頁腳/日期時間/投影片編號。

**如果版面配置沒有頁腳區域，我可以「開啟」其可見性嗎？**

可以。透過頁眉與頁腳管理器檢查可見性，若需要即可啟用。這些 API 指標與方法是針對佔位符缺失或被隱藏的情況而設計的。

**如何讓投影片編號從非 1 的值開始？**

設定簡報的[第一張投影片編號](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/first_slide_number/)，之後所有編號皆會重新計算。例如，您可以從 0 或 10 開始，並在標題投影片上隱藏編號。

**將簡報匯出為 PDF、影像或 HTML 時，頁眉/頁腳會發生什麼情況？**

它們會以簡報中的一般文字元素呈現。也就是說，若這些元素在投影片或備註頁面上可見，則在輸出格式中也會與其他內容一起顯示。