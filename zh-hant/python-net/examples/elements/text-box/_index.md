---
title: 文字方塊
type: docs
weight: 40
url: /zh-hant/python-net/examples/elements/text-box/
keywords:
- 文字方塊
- 新增文字方塊
- 存取文字方塊
- 移除文字方塊
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中建立與格式化文字方塊：設定字型、對齊、換行、自動調整大小，並加入連結，以完善 PowerPoint 與 OpenDocument 的投影片。"
---
在 Aspose.Slides 中，**文字方塊** 由 `AutoShape` 表示。幾乎所有的圖形都可以包含文字，但典型的文字方塊沒有填充或邊框，僅顯示文字。

本指南說明如何以程式方式新增、存取和移除文字方塊。

## **新增文字方塊**

文字方塊只是沒有填充或邊框且包含一些格式化文字的 `AutoShape`。以下說明如何建立一個：

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 建立一個矩形形狀（預設為填充且有邊框，且沒有文字）。
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # 移除填充和邊框，使其看起來像典型的文字方塊。
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # 設定文字格式。
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # 指定實際的文字內容。
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **注意：** 任何包含非空 `TextFrame` 的 `AutoShape` 都可以作為文字方塊使用。

## **依內容存取文字方塊**

若要找出所有包含特定關鍵字（例如「Slide」）的文字方塊，請遍歷圖形並檢查其文字：

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # 只有 AutoShape 能包含可編輯的文字。
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # 對符合的文字方塊執行操作。
                    pass
```

## **依內容移除文字方塊**

此範例會找出並刪除第一張投影片中所有包含特定關鍵字的文字方塊：

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # 找出要移除的形狀，這些形狀是包含字詞「Slide」的 AutoShape。
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # 從投影片中移除每個符合的形狀。
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **提示：** 在 **迭代** 時修改形狀集合之前，請始終先建立其副本，以避免集合修改錯誤。