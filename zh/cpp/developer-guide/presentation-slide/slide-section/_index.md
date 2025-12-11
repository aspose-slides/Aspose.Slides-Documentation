---
title: 使用 C++ 管理演示文稿中的幻灯片章节
linktitle: 幻灯片章节
type: docs
weight: 100
url: /zh/cpp/slide-section/
keywords:
- 创建章节
- 添加章节
- 编辑章节
- 更改章节
- 章节名称
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 简化 PowerPoint 和 OpenDocument 中的幻灯片章节 —— 切分、重命名和重新排序，以优化 PPTX 和 ODP 工作流。"
---

使用 Aspose.Slides for C++，您可以将 PowerPoint 演示文稿组织为章节。您可以创建包含特定幻灯片的章节。

在以下情况下，您可能希望创建章节并使用它们将演示文稿中的幻灯片组织或划分为逻辑部分：

- 当您与其他人或团队合作处理大型演示文稿且需要将特定幻灯片分配给同事或团队成员时。
- 当演示文稿包含大量幻灯片且您难以一次性管理或编辑其内容时。

理想情况下，您应创建一个包含相似幻灯片的章节——这些幻灯片具有共同点或可以基于某规则归为一组——并为该章节赋予能描述内部幻灯片的名称。

## **在演示文稿中创建章节**

要在演示文稿中添加用于容纳幻灯片的章节，Aspose.Slides for C++ 提供了 AddSection 方法，允许您指定要创建的章节名称以及章节开始的幻灯片。

以下示例代码展示如何在 C++ 中的演示文稿里创建章节：
``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 将在 newSlide2 结束，随后 section2 将开始   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```


## **更改章节名称**

在 PowerPoint 演示文稿中创建章节后，您可能会决定更改其名称。

以下示例代码展示如何使用 Aspose.Slides 在 C++ 中的演示文稿里更改章节名称：
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```


## **常见问题**

**将 PPT（PowerPoint 97–2003）格式保存时，章节会被保留吗？**

否。PPT 格式不支持章节元数据，因此保存为 .ppt 时章节分组会丢失。

**整个章节可以被“隐藏”吗？**

否。只能隐藏单个幻灯片。章节作为实体没有“隐藏”状态。

**我能否通过幻灯片快速找到所属章节，反之亦然，找到章节的第一张幻灯片？**

可以。章节由其起始幻灯片唯一定义；给定一张幻灯片即可确定它所属的章节，对于章节也可以访问其第一张幻灯片。