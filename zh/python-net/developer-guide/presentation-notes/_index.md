---
title: 在 Python 中管理演示文稿批注
linktitle: 演示文稿批注
type: docs
weight: 110
url: /zh/python-net/presentation-notes/
keywords:
- 批注
- 批注幻灯片
- 添加批注
- 删除批注
- 批注样式
- 母版批注
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 自定义演示文稿批注。无缝处理 PowerPoint 和 OpenDocument 批注，提高工作效率。"
---

Aspose.Slides 支持从演示文稿中删除批注幻灯片。在本主题中，我们将介绍删除批注以及从任意演示文稿添加批注样式幻灯片的这一新功能。Aspose.Slides for Python via .NET 提供了删除任意幻灯片的批注以及为现有批注添加样式的功能。开发人员可以通过以下方式删除批注：

- 删除演示文稿中特定幻灯片的批注。
- 删除演示文稿中所有幻灯片的批注。

## **从幻灯片中删除批注**
可以删除某些特定幻灯片的批注，如下面示例所示：
```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 删除第一张幻灯片的批注
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # 将演示文稿保存到磁盘
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **删除所有幻灯片的批注**
可以删除演示文稿中所有幻灯片的批注，如下面示例所示：
```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 删除所有幻灯片的批注
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # 将演示文稿保存到磁盘
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **添加 NotesStyle**
已将 NotesStyle 属性添加到[IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/)接口和[MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/)类。此属性指定批注文本的样式。下面的示例演示了实现方式。
```py
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # 获取 MasterNotesSlide 文本样式
        notesStyle = notesMaster.notes_style

        #Set 符号项目符号用于第一级段落
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # 将 PPTX 文件保存到磁盘
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**哪个 API 实体提供对特定幻灯片批注的访问？**
批注通过幻灯片的批注管理器访问：该幻灯片具有一个[NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/)，以及一个返回批注对象的[property](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/)，如果没有批注则返回 `None`。

**在库支持的 PowerPoint 版本之间，批注支持是否存在差异？**
该库面向广泛的 Microsoft PowerPoint 格式（97 版及更高）和 ODP；这些格式均支持批注，且无需依赖已安装的 PowerPoint。