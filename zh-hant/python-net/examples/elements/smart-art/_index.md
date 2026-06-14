---
title: SmartArt
type: docs
weight: 140
url: /zh-hant/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- 新增 SmartArt
- 存取 SmartArt
- 移除 SmartArt
- SmartArt 版面
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中建立與編輯 SmartArt：新增節點、變更版面與樣式、精確轉換為形狀，並匯出為 PPT、PPTX 與 ODP。"
---
展示如何使用 **Aspose.Slides for Python via .NET** 新增 SmartArt 圖形、存取它們、移除它們，以及變更版面配置。

## **新增 SmartArt**

使用內建版面之一插入 SmartArt 圖形。

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **存取 SmartArt**

取得投影片上第一個 SmartArt 物件。

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # 存取第一個 SmartArt 形狀。
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **移除 SmartArt**

從投影片中刪除 SmartArt 形狀。

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是 SmartArt 物件。
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **變更 SmartArt 版面**

更新現有 SmartArt 圖形的版面類型。

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是 SmartArt 物件。
        smart_art = slide.shapes[0]

        # 變更 SmartArt 版面。
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```