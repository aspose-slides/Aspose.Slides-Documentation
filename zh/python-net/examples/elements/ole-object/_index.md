---
title: OLE对象
type: docs
weight: 210
url: /zh/python-net/examples/elements/ole-object/
keywords:
- OLE对象
- 添加 OLE对象
- 访问 OLE对象
- 移除 OLE对象
- 更新 OLE对象
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中处理 OLE 对象：插入或更新嵌入的文件，设置图标或链接，提取内容，控制 PPT、PPTX 和 ODP 的行为。"
---
演示如何将文件嵌入为 OLE 对象并使用 **Aspose.Slides for Python via .NET** 更新其数据。

## **添加 OLE 对象**

将 PDF 文件嵌入演示文稿。

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 加载要嵌入的 PDF 数据。
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # 向幻灯片添加 OLE 对象框架。
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **访问 OLE 对象**

检索幻灯片上的第一个 OLE 对象框架。

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # 获取幻灯片上的第一个 OLE 对象框架。
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **移除 OLE 对象**

从幻灯片中删除嵌入的 OLE 对象。

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是 OleObjectFrame 对象。
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **更新 OLE 对象数据**

替换已存在 OLE 对象中嵌入的数据。

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # 假设第一个形状是 OleObjectFrame 对象。
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # 使用新嵌入的数据更新 OLE 对象。
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```