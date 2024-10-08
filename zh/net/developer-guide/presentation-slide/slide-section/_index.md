---
title: 幻灯片部分
type: docs
weight: 100
url: /net/slide-section/
keywords: "创建部分, 添加部分, 编辑部分名称, PowerPoint 演示文稿, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 或 .NET 中添加和编辑 PowerPoint 演示文稿中的部分"
---

使用 Aspose.Slides for .NET，您可以将 PowerPoint 演示文稿组织成多个部分。您可以创建包含特定幻灯片的部分。

在以下情况下，您可能希望创建部分并使用它们来组织或划分演示文稿中的幻灯片，以形成逻辑部分：

- 当您与其他人或团队一起工作在一个大演示文稿时—您需要将某些幻灯片分配给同事或某些团队成员。
- 当您处理一个包含许多幻灯片的演示文稿时—您很难同时管理或编辑其内容。

理想情况下，您应该创建一个包含相似幻灯片的部分—这些幻灯片有某些共同点或者可以根据某个规则组成一个组—并给该部分一个描述其内部幻灯片的名称。

## 在演示文稿中创建部分

要添加一个将容纳幻灯片的部分，Aspose.Slides for .NET 提供了 AddSection 方法，允许您指定要创建的部分名称及其开始的幻灯片。

以下示例代码展示了如何在 C# 中创建演示文稿中的部分：

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("部分 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("部分 2", newSlide3); // section1 会在 newSlide2 处结束，然后 section2 将开始

    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("最后一个空部分");
    
    pres.Save("pres-section-with-empty.pptx", SaveFormat.Pptx);
}
```

## 更改部分名称

在 PowerPoint 演示文稿中创建部分后，您可能决定更改其名称。

以下示例代码展示了如何使用 Aspose.Slides 在 C# 中更改演示文稿中部分的名称：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "我的部分";
}
```