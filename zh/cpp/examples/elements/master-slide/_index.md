---
title: 母版幻灯片
type: docs
weight: 30
url: /zh/cpp/examples/elements/master-slide/
keywords:
- 代码示例
- 母版幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "探索 Aspose.Slides for C++ 的母版幻灯片示例：在 PPT、PPTX 和 ODP 中创建、编辑和设置母版、占位符和主题，提供清晰的 C++ 代码。"
---
母版幻灯片构成 PowerPoint 中幻灯片继承层次结构的最高层。**母版幻灯片**定义诸如背景、徽标和文本格式等通用设计元素。**布局幻灯片**从母版幻灯片继承，**普通幻灯片**从布局幻灯片继承。

本文演示如何使用 Aspose.Slides for C++ 创建、修改和管理母版幻灯片。

## **添加母版幻灯片**

此示例展示如何通过克隆默认母版来创建新的母版幻灯片。随后通过布局继承向所有幻灯片添加公司名称横幅。

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 克隆默认的母版幻灯片。
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // 在母版幻灯片顶部添加带公司名称的横幅。
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // 将新母版幻灯片分配给布局幻灯片。
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // 将布局幻灯片分配给演示文稿中的第一页幻灯片。
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **注意 1：** 母版幻灯片提供了一种在所有幻灯片中应用统一品牌或共享设计元素的方式。对母版所做的任何更改将自动体现在依赖的布局和普通幻灯片上。

> 💡 **注意 2：** 添加到母版幻灯片的任何形状或格式都会被布局幻灯片继承，进而被使用这些布局的所有普通幻灯片继承。  
> 下图示例说明在母版幻灯片上添加的文本框如何自动呈现在最终幻灯片上。

![Master Inheritance Example](master-slide-banner.png)

## **访问母版幻灯片**

您可以使用演示文稿的母版集合来访问母版幻灯片。以下是检索和使用它们的方法：

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // 更改背景类型。
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **删除母版幻灯片**

可以通过索引或引用来删除母版幻灯片。

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // 按索引删除母版幻灯片。
    presentation->get_Masters()->RemoveAt(0);

    // 按引用删除母版幻灯片。
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **删除未使用的母版幻灯片**

某些演示文稿包含未使用的母版幻灯片。删除这些幻灯片可以帮助减小文件大小。

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 删除所有未使用的母版幻灯片（即使标记为 Preserve）。
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```