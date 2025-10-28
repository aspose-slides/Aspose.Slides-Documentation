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
description: "通过 Aspose.Slides for Python via .NET 自定义演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，提升工作效率。"
---

Aspose.Slides 支持从演示文稿中删除备注幻灯片。在本主题中，我们将介绍删除备注以及向任意演示文稿添加备注样式的新功能。Aspose.Slides for Python via .NET 提供了删除任意幻灯片的备注以及为现有备注添加样式的功能。开发者可以通过以下方式删除备注：

- 删除演示文稿中特定幻灯片的备注。
- 删除演示文稿中所有幻灯片的备注。
## **从幻灯片删除备注**
可以按照下面示例删除某个特定幻灯片的备注：

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of first slide
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # save presentation to disk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **从所有幻灯片删除备注**
可以按照下面示例删除演示文稿中所有幻灯片的备注：

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of all slides
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # save presentation to disk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **添加 NotesStyle**
`NotesStyle` 属性已分别添加到 [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) 接口和 [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) 类中。该属性指定备注文本的样式。下面的示例演示了其实现。

```py
import aspose.slides as slides

# Instantiate Presentation class that represents the presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Get MasterNotesSlide text style
        notesStyle = notesMaster.notes_style

        #Set symbol bullet for the first level paragraphs
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # save the PPTX file to the Disk
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**哪个 API 实体提供对特定幻灯片备注的访问？**

备注通过幻灯片的备注管理器访问：幻灯片拥有一个 [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) 和一个返回备注对象的 [property](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/)，如果没有备注则返回 `None`。

**库对不同 PowerPoint 版本的备注支持有什么差异吗？**

该库面向广泛的 Microsoft PowerPoint 格式（97 版至更新版）和 ODP；在这些格式中均支持备注，而不依赖已安装的 PowerPoint 副本。