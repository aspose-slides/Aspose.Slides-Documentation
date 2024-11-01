---
title: 使用 Aspose.Slides 的 Hello World 应用程序
type: docs
weight: 80
url: /zh/cpp/hello-world-application-using-aspose-slides/
---

## **创建 Hello World 应用程序的步骤**
在这个简单的应用程序中，我们将创建一个包含 **Hello World** 文本的 PowerPoint 演示文稿，该文本位于幻灯片的指定位置。请按照以下步骤使用 Aspose.Slides for C++ API 创建 **Hello World** 应用程序：

- 创建 Presentation 类的实例
- 获取在 Presentation 实例化时创建的演示文稿中的第一张幻灯片的引用。
- 在幻灯片的指定位置添加一个形状类型为矩形的 AutoShape。
- 向 AutoShape 添加一个 TextFrame，包含默认文本 Hello World
- 将文本颜色更改为黑色，因为默认是白色，在白色背景的幻灯片上不可见
- 将形状的线条颜色更改为白色，以隐藏形状边框
- 删除形状的默认填充格式
- 最后，使用 Presentation 对象将演示文稿写入所需的文件格式

上述步骤的实现如下所示：

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

    // 添加一个矩形类型的 AutoShape
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // 向矩形添加 TextFrame
    shape->AddTextFrame(u"Hello World");

    // 将文本颜色更改为黑色（默认是白色）
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // 将矩形的线条颜色更改为白色
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // 删除形状中的任何填充格式
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // 将演示文稿保存到磁盘
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```