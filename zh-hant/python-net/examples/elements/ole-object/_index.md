---
title: Ole 物件
type: docs
weight: 210
url: /zh-hant/python-net/examples/elements/ole-object/
keywords:
- OLE 物件
- 新增 OLE 物件
- 存取 OLE 物件
- 移除 OLE 物件
- 更新 OLE 物件
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中操作 OLE 物件：插入或更新嵌入的檔案，設定圖示或連結，提取內容，控制 PPT、PPTX 與 ODP 的行為。"
---
示範如何將檔案嵌入為 OLE 物件，並使用 **Aspose.Slides for Python via .NET** 更新其資料。

## **新增 OLE 物件**

將 PDF 檔案嵌入簡報中。

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 載入 PDF 資料以嵌入。
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # 在投影片上新增 OLE 物件框架。
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **存取 OLE 物件**

取得投影片上第一個 OLE 物件框架。

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # 取得投影片上的第一個 OLE 物件框架。
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **移除 OLE 物件**

從投影片中刪除嵌入的 OLE 物件。

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是 OleObjectFrame 物件。
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **更新 OLE 物件資料**

取代已存在 OLE 物件中嵌入的資料。

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # 假設第一個形狀是 OleObjectFrame 物件。
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # 使用新的嵌入資料更新 OLE 物件。
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```