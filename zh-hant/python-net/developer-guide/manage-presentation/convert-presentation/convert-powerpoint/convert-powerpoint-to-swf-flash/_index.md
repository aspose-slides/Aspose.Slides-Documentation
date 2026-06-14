---
title: 在 Python 中將 PowerPoint 簡報轉換為 SWF Flash
linktitle: PowerPoint 轉 SWF Flash
type: docs
weight: 80
url: /zh-hant/python-net/convert-powerpoint-to-swf-flash/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- PowerPoint 轉 SWF
- 簡報 轉 SWF
- 投影片 轉 SWF
- PPT 轉 SWF
- PPTX 轉 SWF
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 將 PowerPoint (PPT/PPTX) 轉換為 SWF Flash。逐步程式碼範例，快速高品質輸出，無需 PowerPoint 自動化。"
---
## **概述**

本篇文章說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 SWF。它展示如何使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 方法將簡報儲存為 SWF 檔案，並說明如何使用 [SwfOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/swfoptions/) 來設定匯出選項，包括檢視器設定以及備註或評論的版面配置。

## **將簡報轉換為 Flash**

[save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/save/) 方法由 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別提供，可用於將整個簡報轉換為 SWF 文件。您也可以透過使用 [SWFOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/swfoptions/) 類別和 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/notescommentslayoutingoptions/) 類別在產生的 SWF 中包含評論。以下範例示範如何使用 SWFOptions 類別提供的選項將簡報轉換為 SWF 文件。

```py
import aspose.slides as slides

# 建立一個代表簡報檔案的 Presentation 物件
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# 儲存簡報與備註頁面
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **常見問題**

**我可以在 SWF 中包含隱藏的投影片嗎？**

可以。於 [SwfOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/swfoptions/) 中啟用 [show_hidden_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) 選項。預設情況下，隱藏的投影片不會被匯出。

**我該如何控制壓縮與最終的 SWF 大小？**

使用 [compressed](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/swfoptions/compressed/) 旗標（預設已啟用），並調整 [jpeg_quality](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/swfoptions/jpeg_quality/) 以在檔案大小與影像品質之間取得平衡。

**viewer_included 的功能是什麼，何時應該停用它？**

[viewer_included](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/swfoptions/viewer_included/) 會在 SWF 中加入嵌入式播放器 UI（導航控制、面板、搜尋）。如果您打算使用自己的播放器或需要沒有 UI 的純粹 SWF 框架，請將其停用。

**如果匯出機器缺少來源字型會發生什麼情況？**

Aspose.Slides 會使用您在 [SwfOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/swfoptions/) 的 [default_regular_font](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/swfoptions/default_regular_font/) 中指定的字型進行替換，以避免意外的回退。