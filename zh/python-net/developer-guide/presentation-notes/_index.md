---
title: 演示文稿笔记
type: docs
weight: 110
url: /python-net/presentation-notes/
keywords: "笔记, PowerPoint 笔记, 添加笔记, 删除笔记, PowerPoint 演示, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中添加和删除 PowerPoint 演示文稿中的笔记"
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