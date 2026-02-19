---
title: 文本框
type: docs
weight: 40
url: /zh/cpp/examples/elements/text-box/
keywords:
- 代码示例
- 文本框
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中使用文本框：使用 C++ 为 PPT、PPTX 和 ODP 演示文稿添加、格式化、对齐、换行、自动适应并设置文本样式。"
---
在 Aspose.Slides 中，**文本框** 由 `AutoShape` 表示。几乎任何形状都可以包含文本，但典型的文本框没有填充或边框，只显示文本。

本指南说明如何以编程方式添加、访问和删除文本框。

## **Add a Text Box**

文本框就是没有填充或边框且包含格式化文本的 `AutoShape`。以下是创建方法：

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 创建一个矩形形状（默认填充且有边框且没有文本）。
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // 移除填充和边框，使其看起来像典型的文本框。
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // 设置文本格式。
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // 分配实际的文本内容。
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Note:** 任何包含非空 `TextFrame` 的 `AutoShape` 都可以作为文本框使用。

## **Access Text Boxes by Content**

要查找包含特定关键字（例如 “Slide”）的所有文本框，遍历形状并检查其文本：

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // 只有 AutoShape 能包含可编辑文本。
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // 对匹配的文本框执行相应操作。
            }
        }
    }

    presentation->Dispose();
}
```

## **Remove Text Boxes by Content**

以下示例查找并删除第一张幻灯片上包含特定关键字的所有文本框：

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **Tip:** 在迭代期间修改形状集合前，始终先创建该集合的副本，以避免集合修改错误。