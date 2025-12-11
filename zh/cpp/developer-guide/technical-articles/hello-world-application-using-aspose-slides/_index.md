---
title: 使用 Aspose.Slides for C++ 的 Hello World 应用程序
type: docs
weight: 80
url: /zh/cpp/hello-world-application-using-aspose-slides/
keywords:
- 你好世界
- 应用程序
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 创建您的第一个 C++ 应用程序，这是一个简单的 Hello World 示例，可帮助您准备自动化 PPT、PPTX 和 ODP 演示文稿。"
---

## **创建 Hello World 应用程序的步骤**
在此简单示例中，我们将在幻灯片的指定位置创建包含 **Hello World** 文本的 PowerPoint 演示文稿。请按照以下步骤使用 Aspose.Slides for C++ API 创建 **Hello World** 应用程序：

- 创建一个 Presentation 类的实例
- 获取演示文稿中第一张幻灯片的引用（该幻灯片在实例化 Presentation 时创建）
- 在幻灯片的指定位置添加一个 ShapeType 为 Rectangle 的 AutoShape
- 向 AutoShape 添加一个 TextFrame，默认文本为 Hello World
- 将文本颜色更改为 Black，因为默认是白色，在白色背景的幻灯片上不可见
- 将形状的线条颜色更改为白色，以隐藏形状边框
- 移除形状的默认 Fill Format
- 最后，使用 Presentation 对象将演示文稿写入所需的文件格式

下面的示例演示了上述步骤的实现。
``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // 获取第一张幻灯片
    auto slide = pres->get_Slides()->idx_get(0);

    // 添加一个 Rectangle 类型的 AutoShape
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // 向矩形添加 TextFrame
    shape->AddTextFrame(u"Hello World");

    // 将文本颜色更改为 Black（默认是 White）
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // 将矩形的线条颜色更改为 White
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // 移除形状的任何填充格式
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // 将演示文稿保存到磁盘
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```
