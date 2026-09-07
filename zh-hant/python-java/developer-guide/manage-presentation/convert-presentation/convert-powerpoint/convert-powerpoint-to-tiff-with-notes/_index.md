---
title: 在 Python 中將 PowerPoint 簡報轉換為含備註的 TIFF
linktitle: PowerPoint 轉 TIFF（含備註）
type: docs
weight: 100
url: /zh-hant/python-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 TIFF
- 簡報轉 TIFF
- 投影片轉 TIFF
- PPT 轉 TIFF
- PPTX 轉 TIFF
- 將 PPT 儲存為 TIFF
- 將 PPTX 儲存為 TIFF
- 匯出 PPT 為 TIFF
- 匯出 PPTX 為 TIFF
- 含備註的 PowerPoint
- 含備註的簡報
- 含備註的投影片
- 含備註的 PPT
- 含備註的 PPTX
- 含備註的 TIFF
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，將 PowerPoint 簡報轉換為含備註的 TIFF。了解如何有效匯出帶有講者備註的投影片。"
---
## **簡介**

Aspose.Slides for Python via Java 提供一個簡單的解決方案，可將含有備註的 PowerPoint 和 OpenDocument 簡報（PPT、PPTX 與 ODP）轉換為 TIFF 格式。此格式廣泛用於高品質影像儲存、列印與文件歸檔。使用 [儲存](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法搭配 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別，將投影片及其講者備註匯出為單一多頁 TIFF 檔案。

## **將簡報轉換為含備註的 TIFF**

使用 Aspose.Slides for Python via Java 將 PowerPoint 或 OpenDocument 簡報儲存為含備註的 TIFF 需依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例：載入 PowerPoint 或 OpenDocument 檔案。  
1. 設定輸出版面配置選項：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/) 類別指定備註與評論的顯示方式。  
1. 將簡報儲存為 TIFF：將已設定的選項傳遞給 [儲存](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法。

假設我們有一個名為「speaker_notes.pptx」的檔案，其投影片如下：

![簡報投影片與講者備註](slide_with_notes.png)

以下程式碼片段示範如何使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) 方法，將簡報以備註投影片檢視方式轉換為 TIFF 影像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffOptions

presentation = Presentation("speaker_notes.pptx")
try:
    # 在每張投影片下方顯示完整的講者備註。
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    # 設定 TIFF 解析度與備註版面配置。
    tiff_options = TiffOptions()
    tiff_options.setDpiX(300)
    tiff_options.setDpiY(300)
    tiff_options.setSlidesLayoutOptions(notes_options)

    # 儲存簡報為含講者備註的 TIFF。
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

產生的結果：

![含有講者備註的 TIFF 影像](TIFF_with_notes.png)

{{% alert title="提示" color="success" %}}
了解 Aspose 的 [免費 PowerPoint 轉海報轉換工具](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問題**

**我可以控制產生的 TIFF 中備註區域的位置嗎？**

可以。使用 [setNotesPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 搭配 [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notespositions/#BottomTruncated) 讓備註排在同一頁上（可能被截斷），或使用 [NotesPositions.BottomFull](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/notespositions/#BottomFull) 在需要時使用額外頁面顯示全部備註。若要匯出不含備註的投影片，請如 [Convert PowerPoint to TIFF](/slides/zh-hant/python-java/convert-powerpoint-to-tiff/) 中所示，省略備註版面配置。

**如何在不犧牲影像品質的前提下降低含備註的 TIFF 檔案大小？**

透過 [setCompressionType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/#setCompressionType) 使用無損的 [LZW 壓縮](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffcompressiontypes/#LZW)。降低解析度或色彩深度亦可減少檔案大小，但可能影響影像品質與備註可讀性。更多選項請參閱 [TIFF 匯出設定](/slides/zh-hant/python-java/convert-powerpoint-to-tiff/)。

**如果系統上缺少原始字型，備註中的字體會影響最終結果嗎？**

會。缺少的字型會觸發 [字型替代](/slides/zh-hant/python-java/font-selection-sequence/)，可能改變文字度量與外觀。請 [提供所需字型](/slides/zh-hant/python-java/custom-font/) 以保留預期的字型樣式。