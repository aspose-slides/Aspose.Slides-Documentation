---
title: 在演示文稿中访问幻灯片
type: docs
weight: 20
url: /zh/python-net/access-slide-in-presentation/
keywords: "访问 PowerPoint 演示文稿，访问幻灯片，编辑幻灯片属性，改变幻灯片位置，设置幻灯片编号，索引，ID，位置 Python，Aspose.Slides"
description: "通过索引、ID 或位置在 Python 中访问 PowerPoint 幻灯片。编辑幻灯片属性"
---

Aspose.Slides 允许您通过两种方式访问幻灯片：通过索引和通过 ID。

## **按索引访问幻灯片**

演示文稿中的所有幻灯片按幻灯片位置的数字顺序排列，从 0 开始。第一张幻灯片通过索引 0 访问；第二张幻灯片通过索引 1 访问；以此类推。

表示演示文稿文件的 Presentation 类将所有幻灯片暴露为 [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) 集合（[ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 对象的集合）。以下 Python 代码展示了如何通过其索引访问一张幻灯片：

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 通过索引获取幻灯片的引用
    slide = presentation.slides[0]
```

## **按 ID 访问幻灯片**

演示文稿中的每张幻灯片都有一个唯一的 ID 与之关联。您可以使用 `get_slide_by_id(id)` 方法（由 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类暴露）来定位该 ID。以下 Python 代码展示了如何提供有效的幻灯片 ID 并通过 `get_slide_by_id(id)` 方法访问该幻灯片：

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 获取幻灯片 ID
    id = presentation.slides[0].slide_id
    # 通过其 ID 访问幻灯片
    slide = presentation.get_slide_by_id(id)
```

## **改变幻灯片位置**

Aspose.Slides 允许您改变幻灯片的位置。例如，您可以指定第一张幻灯片应成为第二张幻灯片。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过索引获取要改变位置的幻灯片的引用。
1. 通过 `slide_number` 属性设置幻灯片的新位置。
1. 保存修改后的演示文稿。

以下 Python 代码演示了一个操作，其中位置为 1 的幻灯片被移动到位置 2：

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "ChangePosition.pptx") as pres:
    # 获取将要改变位置的幻灯片
    sld = pres.slides[0]
    # 设置幻灯片的新位置
    sld.slide_number = 2
    # 保存修改后的演示文稿
    pres.save("Aspose_out.pptx", slides.export.SaveFormat.PPTX)
```

第一张幻灯片成为了第二张；第二张幻灯片成为了第一张。当您改变幻灯片位置时，其他幻灯片会自动调整。

## **设置幻灯片编号**

通过 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类暴露的 `first_slide_number` 属性，您可以为演示文稿中的第一张幻灯片指定一个新编号。此操作会导致其他幻灯片编号重新计算。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 获取幻灯片编号。
1. 设置幻灯片编号。
1. 保存修改后的演示文稿。

以下 Python 代码演示了一个操作，其中第一张幻灯片的编号被设置为 10：

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # 获取幻灯片编号
    firstSlideNumber = presentation.first_slide_number
    # 设置幻灯片编号
    presentation.first_slide_number = 10
    # 保存修改后的演示文稿
    presentation.save("Set_Slide_Number_out.pptx", slides.export.SaveFormat.PPTX)
```

如果您想跳过第一张幻灯片，可以从第二张幻灯片开始编号（并隐藏第一张幻灯片的编号），可以这样实现：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # 设置演示文稿第一张幻灯片的编号
    presentation.first_slide_number = 0

    # 显示所有幻灯片的编号
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # 隐藏第一张幻灯片的编号
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # 保存修改后的演示文稿
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```