---
title: 母版幻灯片
type: docs
weight: 30
url: /zh/python-net/examples/elements/master-slide/
keywords:
- 母版幻灯片
- 添加母版幻灯片
- 访问母版幻灯片
- 删除母版幻灯片
- 未使用的母版幻灯片
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中管理母版幻灯片：创建、编辑、克隆并格式化主题、背景、占位符，以统一 PowerPoint 和 OpenDocument 中的幻灯片。"
---
母版幻灯片构成 PowerPoint 幻灯片继承层级的顶层。**母版幻灯片**定义公共设计元素，例如背景、徽标和文本格式。**版式幻灯片**从母版幻灯片继承，**普通幻灯片**从版式幻灯片继承。

本文演示如何使用 Aspose.Slides for Python via .NET 创建、修改和管理母版幻灯片。

## **添加母版幻灯片**

此示例展示如何通过克隆默认母版创建新的母版幻灯片。

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # 克隆默认母版幻灯片。
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **提示 1:** 母版幻灯片提供了一种在所有幻灯片中应用一致品牌或共享设计元素的方法。对母版所做的任何更改都会自动反映在依赖的版式和普通幻灯片上。

> 💡 **提示 2:** 添加到母版幻灯片的任何形状或格式都会被版式幻灯片继承，进而被使用这些版式的所有普通幻灯片继承。下面的图片展示了在母版幻灯片上添加的文本框如何自动呈现在最终幻灯片上。

![母版继承示例](master-slide-banner.png)

## **访问母版幻灯片**

您可以使用 `Presentation.masters` 集合访问母版幻灯片。以下示例演示如何检索和使用它们：

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # 访问第一个母版幻灯片。
        first_master_slide = presentation.masters[0]
```

## **删除母版幻灯片**

母版幻灯片可以通过索引或引用的方式删除。

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # 按索引删除。
        presentation.masters.remove_at(0)

        # 或按引用删除。
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **删除未使用的母版幻灯片**

某些演示文稿包含未使用的母版幻灯片。删除这些幻灯片可以帮助减小文件大小。

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # 删除所有未使用的母版幻灯片（即使它们被标记为 Preserve）。
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **提示:** 使用 `remove_unused(True)` 清理未使用的母版幻灯片并最小化演示文稿大小。