---
title: 用 Python 管理簡報中的文字段
linktitle: 文字段
type: docs
weight: 70
url: /zh-hant/python-net/portion/
keywords:
- 文字段落
- 文字部分
- 文字座標
- 文字位置
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 與 OpenDocument 簡報中管理文字段，提升效能與自訂性。"
---
## **Introduction**

文字段表示段落內的特定文字片段，讓您可以獨立於周圍內容處理該片段。 在 Aspose.Slides 中，當您需要取得文字片段的位置、僅對段落的一部分套用格式，或在更細緻的層級控制文字行為時，可使用 Portion。

## **Get Coordinates of Text Portions**

已在 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 類別中加入了 [get_coordinates](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/get_coordinates/) 方法，該方法允許取得文字段的座標：

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **FAQ**

**我可以只對單一段落中的部份文字套用超連結嗎？**

是的，您可以對單一段落的個別 Portion [指派超連結](/slides/zh-hant/python-net/manage-hyperlinks/)；只有該片段會成為可點擊的，整段不會被連結。

**樣式繼承如何運作：Portion 會覆寫什麼，什麼又是從 Paragraph/TextFrame 繼承的？**

Portion 級別的屬性具有最高優先權。若屬性未在 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 上設定，系統會從 [Paragraph](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/paragraph/) 取得；若該處也未設定，則會從 [TextFrame](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/textframe/) 或 [theme](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.theme/theme/) 樣式取得。

**如果在目標機器/伺服器上缺少為 Portion 指定的字型，會發生什麼情況？**

[字型替代規則](/slides/zh-hant/python-net/font-selection-sequence/) 會生效。文字可能重新換行：度量、斷字與寬度都可能改變，這會影響精確的定位。

**我可以為單一 Portion 設定文字填充透明度或漸層，而不影響段落的其他部分嗎？**

可以，位於 [Portion](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/portion/) 級別的文字顏色、填充與透明度可以與相鄰的片段不同。