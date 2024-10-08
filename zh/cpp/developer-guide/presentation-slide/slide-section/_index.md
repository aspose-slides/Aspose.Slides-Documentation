---
title: 幻灯片部分
type: docs
weight: 100
url: /cpp/slide-section/
---

使用 Aspose.Slides for C++，您可以将 PowerPoint 演示文稿组织成部分。您可以创建包含特定幻灯片的部分。

在以下情况下，您可能希望创建部分并使用它们来组织或将演示文稿中的幻灯片分成逻辑部分：

- 当您与其他人或团队一起处理大型演示文稿时—并且您需要将某些幻灯片分配给同事或一些团队成员。
- 当您处理包含许多幻灯片的演示文稿时—并且您在一次性管理或编辑其内容时遇到困难。

理想情况下，您应该创建一个包含相似幻灯片的部分—这些幻灯片有某些共同点，或者可以根据某个规则存在于一个组中—并给该部分命名，以描述其中的幻灯片。

## 在演示文稿中创建部分

要添加一个包含幻灯片的部分，Aspose.Slides for C++ 提供了 AddSection 方法，允许您指定要创建的部分的名称以及部分开始的幻灯片。

以下示例代码演示了如何在 C++ 中创建演示文稿的部分：

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"部分 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"部分 2", newSlide3);
// section1 将在 newSlide2 处结束，然后 section2 将开始   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"最后一个空部分");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## 更改部分名称

在 PowerPoint 演示文稿中创建部分后，您可能决定更改其名称。

以下示例代码演示了如何在 C++ 中使用 Aspose.Slides 更改演示文稿中部分的名称：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"我的部分");
```