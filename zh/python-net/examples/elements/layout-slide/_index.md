---
title: 布局幻灯片
type: docs
weight: 20
url: /zh/python-net/examples/elements/layout-slide/
keywords:
- 布局幻灯片
- 添加布局幻灯片
- 访问布局幻灯片
- 删除布局幻灯片
- 未使用的布局幻灯片
- 克隆布局幻灯片
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Python 与 Aspose.Slides 管理布局幻灯片：在 PPT、PPTX 和 ODP 演示文稿中创建、应用、克隆、重命名和自定义占位符及主题。"
---
本文演示了如何在 Aspose.Slides for Python via .NET 中使用 **布局幻灯片**。布局幻灯片定义了普通幻灯片继承的设计和格式。您可以添加、访问、克隆和删除布局幻灯片，还可以清理未使用的布局幻灯片以减小演示文稿的大小。

## **添加布局幻灯片**

您可以创建自定义布局幻灯片以定义可重用的格式。

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # 使用指定的类型和名称创建布局幻灯片。
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **提示 1:** 布局幻灯片充当单个幻灯片的模板。您可以一次定义公共元素，并在众多幻灯片中重复使用它们。

> 💡 **提示 2:** 当您向布局幻灯片添加形状或文本时，所有基于该布局的幻灯片都会自动显示这些共享内容。下面的截图显示了两张幻灯片，它们各自继承了同一布局幻灯片中的文本框。

![幻灯片继承布局内容](layout-slide-result.png)

## **访问布局幻灯片**

可以通过索引或布局类型（例如 `Blank`、`Title`、`SectionHeader` 等）访问布局幻灯片。

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # 通过索引访问。
        first_layout_slide = presentation.layout_slides[0]

        # 通过布局类型访问。
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **删除布局幻灯片**

如果不再需要，您可以删除特定的布局幻灯片。

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # 按类型获取布局幻灯片并将其删除。
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **删除未使用的布局幻灯片**

为了减小演示文稿的大小，您可能需要删除未被任何普通幻灯片使用的布局幻灯片。

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # 自动删除所有未被任何幻灯片引用的布局幻灯片。
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **克隆布局幻灯片**

您可以使用 `AddClone` 方法复制布局幻灯片。

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # 获取指定类型的现有布局幻灯片。
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # 将布局幻灯片克隆到布局幻灯片集合的末尾。
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **摘要:** 布局幻灯片是管理跨幻灯片一致格式的强大工具。Aspose.Slides 允许全面控制布局幻灯片的创建、管理和优化。