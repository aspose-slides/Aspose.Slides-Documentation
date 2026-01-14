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
description: "使用 Aspose.Slides for Python via .NET 定制演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，提高工作效率。"
---

Aspose.Slides 支持从演示文稿中删除备注幻灯片。在本主题中，我们将介绍此新功能——删除备注以及从任意演示文稿中添加带样式的备注幻灯片。Aspose.Slides for Python via .NET 提供了删除任意幻灯片备注以及为现有备注添加样式的功能。开发人员可以通过以下方式删除备注：

- 删除演示文稿中特定幻灯片的备注。
- 删除演示文稿中所有幻灯片的备注。

## **从幻灯片中删除备注**
可以删除某个特定幻灯片的备注，如下例所示：
```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 删除第一张幻灯片的备注
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # 将演示文稿保存到磁盘
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **从所有幻灯片中删除备注**
可以删除演示文稿中所有幻灯片的备注，如下例所示：
```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 删除所有幻灯片的备注
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # 将演示文稿保存到磁盘
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **添加 NotesStyle**
已在[MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/)类中添加了[notes_style](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/notes_style/)属性。该属性指定备注文本的样式。下面的示例演示了其实现。
```py
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # 获取 MasterNotesSlide 文本样式
        notesStyle = notesMaster.notes_style

        # 为第一层段落设置符号项目符号
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # 将 PPTX 文件保存到磁盘
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**提供对特定幻灯片备注访问的 API 实体是哪个？**

备注通过幻灯片的备注管理器访问：该幻灯片具有一个[NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/)和一个返回备注对象的[property](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/)，如果没有备注则返回 `None`。

**库在不同 PowerPoint 版本中对备注的支持有差异吗？**

该库支持广泛的 Microsoft PowerPoint 格式（97 及更高版本）以及 ODP；在这些格式中均支持备注，且无需安装 PowerPoint。