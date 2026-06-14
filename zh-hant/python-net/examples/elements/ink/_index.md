---
title: 墨跡
type: docs
weight: 180
url: /zh-hant/python-net/examples/elements/ink/
keywords:
- 墨跡
- 存取墨跡
- 移除墨跡
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中處理投影片上的數位墨跡：新增筆畫、編輯路徑、設定顏色與寬度，並將結果匯出為 PowerPoint 與 OpenDocument。"
---
提供使用 **Aspose.Slides for Python via .NET** 存取現有墨跡形狀並將其移除的範例。

> ❗ **注意：** 墨跡形狀代表來自專用裝置的使用者輸入。Aspose.Slides 無法以程式方式建立新的墨跡筆畫，但您可以讀取並修改現有的墨跡。

## **存取墨跡**

取得投影片中的第一個墨跡形狀。

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **移除墨跡**

從投影片中刪除墨跡形狀。

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是 Ink 物件。
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```