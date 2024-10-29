---
title: 演示文稿格式
type: docs
weight: 10
url: /zh/python-net/presentation-format/
---

Aspose.Slides for Python via .NET 提供了 [**PresentationFactory**](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/) 类，用于在加载之前获取演示文稿格式。

为了获取演示文稿格式，请遵循以下步骤：

1. 创建 [**IPresentationInfo**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationinfo/) 类的实例。
1. 获取有关演示文稿格式的信息。

在下面给出的示例中，我们获得了演示文稿格式：

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info(path + "HelloWorld.pptx")
if info.load_format == slides.LoadFormat.PPTX:
    print("PPTX")
elif info.load_format == slides.LoadFormat.UNKNOWN:
    print("UNKNOWN")
```