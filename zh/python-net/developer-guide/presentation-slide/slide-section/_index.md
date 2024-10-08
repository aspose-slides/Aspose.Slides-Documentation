---
title: 幻灯片部分
type: docs
weight: 100
url: /python-net/slide-section/
keywords: "创建部分, 添加部分, 编辑部分名称, PowerPoint 演示文稿, Python, Aspose.Slides"
description: "在 PowerPoint 演示文稿中添加和编辑部分，使用 Python"
---

通过 Aspose.Slides for Python via .NET，您可以将 PowerPoint 演示文稿组织成多个部分。您可以创建包含特定幻灯片的部分。

在以下情况下，您可能希望创建部分并使用它们来组织或将幻灯片划分为演示文稿的逻辑部分：

- 当您与其他人或团队一起处理大型演示文稿时——您需要将某些幻灯片分配给同事或团队成员。
- 当您处理包含许多幻灯片的演示文稿时——您很难一次管理或编辑其内容。

理想情况下，您应该创建一个包含相似幻灯片的部分——这些幻灯片有某种共同点，或者可以基于某个规则组成一个组——并给该部分一个描述其内部幻灯片的名称。

## 在演示文稿中创建部分

要添加一个将容纳幻灯片的部分，Aspose.Slides for Python via .NET 提供了 AddSection 方法，该方法允许您指定要创建的部分名称以及该部分开始的幻灯片。

以下示例代码演示了如何在 Python 中创建一个演示文稿的部分：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    defaultSlide = pres.slides[0]
    newSlide1 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide2 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide3 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide4 = pres.slides.add_empty_slide(pres.layout_slides[0])

    section1 = pres.sections.add_section("部分 1", newSlide1)
    # section1 将在 newSlide2 处结束，然后 section2 将开始
    section2 = pres.sections.add_section("部分 2", newSlide3) 
      
    
    pres.save("pres-sections.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.reorder_section_with_slides(section2, 0)
    pres.save("pres-sections-moved.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.remove_section_with_slides(section2)
    
    pres.sections.append_empty_section("最后一个空部分")
    
    pres.save("pres-section-with-empty.pptx",slides.export.SaveFormat.PPTX)
```

## 更改部分名称

在 PowerPoint 演示文稿中创建部分后，您可能决定更改其名称。

以下示例代码演示了如何使用 Aspose.Slides 在 Python 中更改演示文稿中部分的名称：

```py
import aspose.slides as slides

with slides.Presentation("pres-sections.pptx") as pres:
   section = pres.sections[0]
   section.name = "我的部分"
```