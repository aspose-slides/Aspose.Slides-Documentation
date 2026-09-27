---
title: 用 C++ 创建演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/cpp/create-presentation/
keywords:
- 创建演示文稿
- 新建演示文稿
- 创建 PPT
- 新建 PPT
- 创建 PPTX
- 新建 PPTX
- 创建 ODP
- 新建 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中创建演示文稿——生成 PPT、PPTX 和 ODP 文件，受益于对 OpenDocument 的支持，并以编程方式保存以获得可靠的结果。"
---
## **概述**

本文展示了如何在 Aspose.Slides 中创建演示文稿、在其第一张幻灯片上添加文本框并将结果保存为文件。文末的简短 FAQ 覆盖了格式、模板、幻灯片尺寸、单位、内存使用、线程、授权、数字签名以及 VBA 支持等常见问题。

在开始之前，请将 Aspose.Slides 添加到项目中：在 Windows 上的 Visual Studio 项目中通过 NuGet，或在 Linux 上使用 CMake 从 ZIP 包安装。参见[安装](/slides/zh/cpp/installation/)。

## **创建 PowerPoint 演示文稿**

要创建演示文稿并在第一张幻灯片上放置文本框，请按以下步骤操作：

1. 创建[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类的实例。新演示文稿已经包含一个空幻灯片。
1. 使用[Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/)方法获取该幻灯片及其索引 0。
1. 使用[IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/)方法添加矩形，并使用[ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/)方法设置其文本。
1. 使用[Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)方法将演示文稿保存为 PPTX 文件。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

矩形的左上角距幻灯片左边缘和上边缘各 50 点，宽度为 400 点，高度为 100 点。程序将 *hello.pptx* 保存到工作目录，文件中只有一张包含该矩形及其文本的幻灯片。未授权时，Aspose.Slides 还会在每张保存的幻灯片上添加评估水印；参见[授权](/slides/zh/cpp/licensing/)。

## **常见问题**

### 可以将新演示文稿保存为什么格式？

您可以保存为[PPTX, PPT, and ODP](/slides/zh/cpp/save-presentation/)，并导出为[PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)、[XPS](/slides/zh/cpp/convert-powerpoint-to-xps/)、[HTML](/slides/zh/cpp/convert-powerpoint-to-html/)、[SVG](/slides/zh/cpp/render-a-slide-as-an-svg-image/)和[图像](/slides/zh/cpp/convert-powerpoint-to-png/)，等等。

### 我可以从模板 (POTX/POTM) 开始并保存为普通 PPTX 吗？

可以。加载模板后保存为所需格式；POTX/POTM/PPTM 等格式[受支持](/slides/zh/cpp/supported-file-formats/)。

### 创建演示文稿时如何控制幻灯片大小/宽高比？

设置[幻灯片大小](/slides/zh/cpp/slide-size/)（包括 4:3、16:9 等预设或自定义尺寸），并选择内容的缩放方式。

### 大小和坐标使用什么单位？

使用点（points）：1 英寸等于 72 个点。

### 如何处理包含大量媒体文件的超大演示文稿以降低内存使用？

使用[BLOB management strategies](/slides/zh/cpp/manage-blob/)，通过临时文件限制内存存储，并优先使用基于文件的工作流而非纯内存流。

### 能否并行创建/保存演示文稿？

不能在多个[多线程](/slides/zh/cpp/multithreading/)上操作同一个[Presentation]实例。每个线程或进程应使用独立的实例。

### 如何去除试用水印和限制？

在每个进程中[应用许可证](/slides/zh/cpp/licensing/)一次。许可证 XML 必须保持未修改，并在多线程环境下同步许可证设置。

### 我可以为创建的 PPTX 添加数字签名吗？

可以。支持演示文稿的[数字签名](/slides/zh/cpp/digital-signature-in-powerpoint/)（添加和验证）。

### 在创建的演示文稿中是否支持宏（VBA）？

可以。您可以[创建/编辑 VBA 项目](/slides/zh/cpp/presentation-via-vba/)并保存为支持宏的文件，例如 PPTM/PPSM。