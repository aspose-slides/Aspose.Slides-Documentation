---
title: 设置 OLE 图标的标题
type: docs
weight: 160
url: /python-net/set-caption-to-ole-icon/
---

一个新的属性 **SubstitutePictureTitle** 已经添加到 **IOleObjectFrame** 接口和 **OleObjectFrame** 类中。它允许获取、设置或更改 OLE 图标的标题。下面的代码片段展示了创建 Excel 对象并设置其标题的示例。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 向幻灯片添加 OLE 对象
    with open("oleSourceFile.xlsx", "rb") as ole_stream:
        data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.read(), "xlsx")

    ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

    # 将图像添加到演示文稿的图像集合中
    with slides.Images.from_file("oleIconFile.ico") as image:
        pp_image = presentation.images.add_image(image)

    # 将图像设置为 OLE 对象的图标
    ole_frame.is_object_icon = True
    ole_frame.substitute_picture_format.picture.image = pp_image

    # 设置 OLE 图标的标题
    ole_frame.substitute_picture_title = "标题示例"
```