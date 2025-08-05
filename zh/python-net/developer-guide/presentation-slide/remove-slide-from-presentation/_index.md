---
title: 在 Python 中从演示文稿删除幻灯片
linktitle: 删除幻灯片
type: docs
weight: 30
url: /zh/python-net/remove-slide-from-presentation/
keywords:
- 移除幻灯片
- 删除幻灯片
- 移除未使用的幻灯片
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 轻松从 PowerPoint 和 OpenDocument 演示文稿中删除幻灯片。获取清晰的代码示例，提高您的工作流程效率。"
---

如果幻灯片（或其内容）变得多余，您可以删除它。Aspose.Slides 提供了 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类，该类封装了 [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)，这是演示文稿中所有幻灯片的存储库。通过已知的 [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 对象的指针（引用或索引），您可以指定要删除的幻灯片。

## **通过引用删除幻灯片**

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过其 ID 或索引获取要删除的幻灯片的引用。
1. 从演示文稿中删除引用的幻灯片。
1. 保存修改后的演示文稿。

以下 Python 代码展示了如何通过其引用删除幻灯片：

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "RemoveSlideUsingReference.pptx") as pres:
    # 通过在幻灯片集合中的索引访问幻灯片
    slide = pres.slides[0]

    # 通过其引用删除幻灯片
    pres.slides.remove(slide)

    # 保存修改后的演示文稿
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```


## **通过索引删除幻灯片**

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过其索引位置从演示文稿中删除幻灯片。
1. 保存修改后的演示文稿。

以下 Python 代码展示了如何通过其索引删除幻灯片：

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "RemoveSlideUsingIndex.pptx") as pres:
    # 通过其幻灯片索引删除幻灯片
    pres.slides.remove_at(0)

    # 保存修改后的演示文稿
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **删除未使用的布局幻灯片**

Aspose.Slides 提供了 `remove_unused_layout_slides(pres)` 方法（来自 [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) 类），使您能够删除不需要和未使用的布局幻灯片。以下 Python 代码展示了如何从 PowerPoint 演示文稿中删除布局幻灯片：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **删除未使用的母版幻灯片**

Aspose.Slides 提供了 `remove_unused_master_slides(pres)` 方法（来自 [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) 类），使您能够删除不需要和未使用的母版幻灯片。以下 Python 代码展示了如何从 PowerPoint 演示文稿中删除母版幻灯片：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```