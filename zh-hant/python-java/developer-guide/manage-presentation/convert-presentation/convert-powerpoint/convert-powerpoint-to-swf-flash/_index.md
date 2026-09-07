---
title: 在 Python via Java 中將 PowerPoint 簡報轉換為 SWF Flash
linktitle: PowerPoint 轉換為 SWF
type: docs
weight: 80
url: /zh-hant/python-java/convert-powerpoint-to-swf-flash/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 SWF
- 簡報轉 SWF
- 投影片轉 SWF
- PPT 轉 SWF
- PPTX 轉 SWF
- PowerPoint 轉 Flash
- 簡報轉 Flash
- 投影片轉 Flash
- PPT 轉 Flash
- PPTX 轉 Flash
- 將 PPT 儲存為 SWF
- 將 PPTX 儲存為 SWF
- 匯出 PPT 為 SWF
- 匯出 PPTX 為 SWF
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中將 PowerPoint 簡報轉換為 SWF Flash。可設定檢視器、備註、隱藏投影片、壓縮以及字型。"
---
## **概觀**

Aspose.Slides for Python via Java 讓您在沒有 Microsoft PowerPoint 的情況下將 PowerPoint 簡報轉換為 SWF。使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 匯出簡報，並使用 [SwfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/swfoptions/) 設定檢視器選項、影像品質以及備註或評論的版面配置。

## **將簡報轉換為 Flash**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 載入來源檔案，設定 [SwfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/swfoptions/)，然後使用 [SaveFormat.Swf](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/#Swf) 儲存。

以下範例將 `presentation.pptx` 匯出為 `presentation.swf`。它透過 [setViewerIncluded](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/swfoptions/#setViewerIncluded) 停用嵌入式檢視器，並使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/) 在投影片下方加入講者備註。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, SwfOptions

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    swf_options = SwfOptions()
    swf_options.setViewerIncluded(False)
    swf_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation.swf", SaveFormat.Swf, swf_options)
finally:
    presentation.dispose()
```

在執行範例之前，請先[安裝 Aspose.Slides for Python via Java](/slides/zh-hant/python-java/installation/)，並將 `presentation.pptx` 放置於工作目錄中。JVM 會在每個 Python 行程啟動一次。

此範例透過 [setNotesPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 將 [NotesPositions.BottomFull](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notespositions/#BottomFull) 套用，並將版面配置傳遞給 [SwfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/swfoptions/#setSlidesLayoutOptions)。若同時想包含評論，請在匯出前設定 [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition)。

## **常見問題**

**我可以在 SWF 中包含隱藏投影片嗎？**

可以。呼叫 [SwfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/swfoptions/#setShowHiddenSlides) 並傳入 `True`。預設情況下，隱藏投影片不會被匯出。

**我該如何控制壓縮與最終的 SWF 大小？**

使用 [SwfOptions.setCompressed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/swfoptions/#setCompressed) 來啟用或停用壓縮，並使用 [SwfOptions.setJpegQuality](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/swfoptions/#setJpegQuality) 調整 JPEG 影像品質。降低 JPEG 品質可以減少檔案大小，但會犧牲影像細節。

**嵌入式檢視器的用途是什麼？何時應該停用它？**

[SwfOptions.setViewerIncluded](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/swfoptions/#setViewerIncluded) 控制產生的 SWF 是否包含檢視器。當您需要僅匯出投影片而不需要嵌入式檢視器時，請傳入 `False`，如上例所示。

**如果匯出機器缺少來源字型，會發生什麼情況？**

您可以透過 [setDefaultRegularFont](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) 為 [SwfOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/swfoptions/) 指定預設正文字型。選擇匯出程序可使用的字型；字型替代可能會改變文字外觀與版面配置。