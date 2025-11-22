---
title: 幻灯片章节
type: docs
weight: 100
url: /zh/net/slide-section/
keywords: "创建章节, 添加章节, 编辑章节名称, PowerPoint 演示文稿, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 或 .NET 中添加和编辑 PowerPoint 演示文稿的章节"
---

使用 Aspose.Slides for .NET，您可以将 PowerPoint 演示文稿组织为章节。您可以创建包含特定幻灯片的章节。

在以下情况下，您可能希望创建章节并使用它们将演示文稿中的幻灯片组织或划分为逻辑部分：

- 当您与其他人或团队共同处理大型演示文稿时——需要将特定幻灯片分配给同事或团队成员。  
- 当演示文稿包含大量幻灯片时——您难以一次性管理或编辑其内容。

理想情况下，您应创建一个包含相似幻灯片的章节——这些幻灯片具有共同点或可根据规则归为一组——并为该章节命名，以描述其中的幻灯片。

## **在演示文稿中创建章节**

要在演示文稿中添加用于容纳幻灯片的章节，Aspose.Slides for .NET 提供了 AddSection 方法，可让您指定要创建的章节名称以及章节起始的幻灯片。

以下示例代码演示如何在 C# 中创建演示文稿的章节：
```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 将在 newSlide2 结束，随后 section2 将开始   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```


## **更改章节名称**

在 PowerPoint 演示文稿中创建章节后，您可能决定更改其名称。

以下示例代码演示如何在 C# 中使用 Aspose.Slides 更改演示文稿章节的名称：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```


## **常见问题**

**将文件保存为 PPT（PowerPoint 97–2003）格式时，章节会被保留吗？**

不会。PPT 格式不支持章节元数据，保存为 .ppt 时章节分组会丢失。

**可以将整个章节设为“隐藏”吗？**

不能。只能隐藏单个幻灯片。章节本身没有“隐藏”状态。

**我能否通过幻灯片快速找到所属章节，反之亦然，找到章节的第一张幻灯片？**

可以。章节由其起始幻灯片唯一确定；给定一张幻灯片即可判断其所属章节，而对于章节也可以获取其第一张幻灯片。