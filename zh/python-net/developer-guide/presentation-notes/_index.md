---
title: 在 Python 中管理演示文稿备注
linktitle: 演示文稿备注
type: docs
weight: 110
url: /zh/python-net/presentation-notes/
keywords:
- 备注
- 备注幻灯片
- 添加备注
- 删除备注
- 备注样式
- 主备注
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "通过 Aspose.Slides for Python via .NET 自定义演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，以提升工作效率。"
---

Aspose.Slides 支持从演示文稿中删除备注幻灯片。本文将介绍删除备注以及为任何演示文稿添加备注样式的全新功能。Aspose.Slides for Python via .NET 提供了删除任意幻灯片备注和为现有备注添加样式的功能。开发者可以通过以下方式删除备注：

- 删除演示文稿中特定幻灯片的备注。
- 删除演示文稿中所有幻灯片的备注。

## **从幻灯片删除备注**
可以按下面示例删除特定幻灯片的备注：

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 删除第一张幻灯片的备注
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # 保存演示文稿到磁盘
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **从所有幻灯片删除备注**
可以按下面示例删除演示文稿中所有幻灯片的备注：

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 删除所有幻灯片的备注
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # 保存演示文稿到磁盘
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **添加 NotesStyle**
`NotesStyle` 属性已分别添加到 `IMasterNotesSlide` 接口和 `MasterNotesSlide` 类中。此属性指定备注文本的样式。以下示例演示了具体实现：

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 类
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # 获取 MasterNotesSlide 文本样式
        notesStyle = notesMaster.notes_style

        # 为第一级段落设置符号项目符号
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # 将 PPTX 文件保存到磁盘
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**哪个 API 实体提供对特定幻灯片备注的访问？**

备注通过幻灯片的备注管理器访问：每张幻灯片都有一个 `NotesSlideManager`，以及返回备注对象的 `notes_slide` 属性，如果没有备注则返回 `None`。

**库在不同 PowerPoint 版本中的备注支持是否有所差异？**

该库面向广泛的 Microsoft PowerPoint 格式（97 版及以上）以及 ODP；在这些格式中均支持备注，无需依赖已安装的 PowerPoint 副本。