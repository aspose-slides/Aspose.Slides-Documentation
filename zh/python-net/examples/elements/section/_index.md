---
title: 章节
type: docs
weight: 90
url: /zh/python-net/examples/elements/section/
keywords:
- 章节
- 幻灯片章节
- 添加章节
- 访问章节
- 删除章节
- 重命名章节
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中管理幻灯片章节：轻松创建、重命名、重新排序，移动幻灯片到不同章节，并控制 PPT、PPTX 和 ODP 的可见性。"
---
示例演示如何使用 **Aspose.Slides for Python via .NET** 以编程方式管理演示文稿的章节——添加、访问、删除和重命名。

## **添加章节**

创建一个从特定幻灯片开始的章节。

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 添加新章节并指定标记章节起始的幻灯片。
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **访问章节**

从演示文稿中获取章节。

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # 按索引访问章节。
        section = presentation.sections[0]
```

## **删除章节**

删除之前添加的章节。

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # 删除章节。
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **重命名章节**

更改现有章节的名称。

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # 重命名章节。
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```