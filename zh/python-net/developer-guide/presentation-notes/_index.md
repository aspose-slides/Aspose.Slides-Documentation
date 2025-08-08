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
- 备注母版
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 自定义演示文稿备注。与 PowerPoint 和 OpenDocument 备注无缝协作，提升工作效率。"
---

Aspose.Slides 支持从演示文稿中移除笔记幻灯片。在本主题中，我们将介绍此新功能，即移除笔记以及从任何演示文稿中添加笔记样式幻灯片。Aspose.Slides for Python via .NET 提供了移除任何幻灯片的笔记以及为现有笔记添加样式的功能。开发人员可以通过以下方式移除笔记：

- 移除演示文稿中特定幻灯片的笔记。
- 移除演示文稿中所有幻灯片的笔记。
## **从幻灯片中移除笔记**
可以按如下示例中所示移除某些特定幻灯片的笔记：

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 移除第一张幻灯片的笔记
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # 保存演示文稿到磁盘
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **从所有幻灯片中移除笔记**
可以按如下示例中所示移除演示文稿中所有幻灯片的笔记：

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 移除所有幻灯片的笔记
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # 保存演示文稿到磁盘
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **添加 NotesStyle**
NotesStyle 属性已添加到 [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) 接口和 [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) 类中。 该属性指定笔记文本的样式。 在下面的示例中演示了实现。

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