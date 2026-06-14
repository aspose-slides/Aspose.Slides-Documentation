---
title: 使用 Python 自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/python-net/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 語言 ID
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中自動化 PowerPoint 與 OpenDocument 投影片本地化，提供實用程式碼範例與技巧，加速全球部署。"
---
## **概述**

本文說明如何使用 Aspose.Slides 為簡報中的文字設定 `language_id`。它示範如何開啟簡報、加入含文字的圖形、為文字片段指派語言識別碼，並將結果另存為 PPTX 檔案。

## **變更簡報與圖形文字的語言**
- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
- 使用索引取得投影片的參照。
- 在投影片上加入矩形類型的 AutoShape。
- 在 TextFrame 中加入文字。
- 為文字設定 Language Id。
- 將簡報寫出為 PPTX 檔案。

以下示例示範了上述步驟的實作。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**語言 ID 會觸發自動文字翻譯嗎？**

不會。Aspose.Slides 中的 [language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/language_id/) 會儲存用於拼寫檢查和文法校對的語言，但不會翻譯或變更文字內容。它是 PowerPoint 用於校對的中繼資料。

**語言 ID 會影響呈現時的斷字與換行嗎？**

在 Aspose.Slides 中，[language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/language_id/) 用於校對。斷字品質與換行主要取決於 [適當的字型](/slides/zh-hant/python-net/powerpoint-fonts/) 是否可用，以及書寫系統的版面配置/換行設定。若要確保正確呈現，請確保所需字型可用、設定 [字型替代規則](/slides/zh-hant/python-net/font-substitution/)，或將 [嵌入字型](/slides/zh-hant/python-net/embedded-font/) 內嵌於簡報中。

**我可以在同一段落內設定不同語言嗎？**

可以。[language_id](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portionformat/language_id/) 作用於文字片段層級，因此同一段落可以混合多種語言並使用不同的校對設定。