---
title: 使用 C++ 管理演示文稿中的文本片段
linktitle: 文本片段
type: docs
weight: 70
url: /zh/cpp/portion/
keywords:
- 文本片段
- 文本部分
- 文本坐标
- 文本位置
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中管理文本片段，从而提升性能和自定义能力。"
---

## **获取文本片段的坐标**
**GetCoordinates()** 方法已添加到 IPortion 和 Portion 类，允许检索片段起始位置的坐标：
``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```


## **常见问题**
**我可以仅在单个段落的文本的一部分上应用超链接吗？**

是的，您可以[分配超链接](/slides/zh/cpp/manage-hyperlinks/)给单个片段；只有该片段可点击，而不是整个段落。

**样式继承如何工作：Portion 会覆盖什么，哪些来自 Paragraph/TextFrame？**

片段级属性具有最高优先级。如果属性未在[Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)上设置，引擎会从[Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/)获取；如果那里也未设置，则从[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/theme/)样式中获取。

**如果在目标机器/服务器上缺少为 Portion 指定的字体会怎样？**

会应用[字体替换规则](/slides/zh/cpp/font-selection-sequence/)。文本可能会重排：度量、连字和宽度可能会变化，这会影响精确定位。

**我可以为特定的 Portion 设置文本填充透明度或渐变，而不影响段落的其他部分吗？**

是的，[Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)级别的文本颜色、填充和透明度可以与相邻片段不同。