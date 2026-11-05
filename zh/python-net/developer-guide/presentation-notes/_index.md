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
- 母版备注
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "通过 Aspose.Slides for Python via .NET 定制演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，提升工作效率。"
---
## **概述**

Aspose.Slides 支持从演示文稿中删除备注幻灯片。本文将介绍此功能，包括如何删除备注以及如何在演示文稿中对备注幻灯片应用样式。Aspose.Slides 允许您删除任意幻灯片的备注，也可以对现有备注应用样式。开发人员可以通过以下方式删除备注：

- 从演示文稿的特定幻灯片中删除备注。
- 从演示文稿的所有幻灯片中删除备注。

要读取或更改备注页面尺寸、切换方向以及检查导出行为，请参阅 [Notes Page Size](/slides/zh/python-net/notes-size/)。

## **从幻灯片中删除备注**
可以按下面示例从特定幻灯片中删除备注：

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # 删除第一张幻灯片的备注
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # 将演示文稿保存到磁盘
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **从所有幻灯片中删除备注**
可以按下面示例从演示文稿的所有幻灯片中删除备注：

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # 删除所有幻灯片的备注
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # 将演示文稿保存到磁盘
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **应用备注样式**
已在 [MasterNotesSlide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masternotesslide/) 类中添加了 [notes_style](https://reference.aspose.com/slides/zh/python-net/aspose.slides/masternotesslide/notes_style/) 属性。此属性指定备注文本的样式。下面的示例演示了实现方式。

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # 获取 MasterNotesSlide 文本样式
        notesStyle = notesMaster.notes_style

        #为一级段落设置符号项目符号
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # 将 PPTX 文件保存到磁盘
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问答**

**哪个 API 实体提供对特定幻灯片备注的访问？**

备注通过幻灯片的备注管理器访问：幻灯片具有 [NotesSlideManager](https://reference.aspose.com/slides/zh/python-net/aspose.slides/notesslidemanager/) 和一个返回备注对象的 [property](https://reference.aspose.com/slides/zh/python-net/aspose.slides/notesslidemanager/notes_slide/)，如果没有备注则返回 `None`。

**库对不同 PowerPoint 版本的备注支持是否有差异？**

该库面向广泛的 Microsoft PowerPoint 格式（97 版及更高）和 ODP；在这些格式中支持备注，而不依赖于已安装的 PowerPoint 副本。