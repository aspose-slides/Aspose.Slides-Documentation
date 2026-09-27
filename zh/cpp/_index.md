---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /zh/cpp/
keywords:
- 文档
- 演示文稿处理
- 演示文稿转换
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "从这里开始：安装 Aspose.Slides for C++，创建第一个演示文稿，并查找常见任务指南、API 参考和支持。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ 是一个原生 C++ 库，用于创建、读取、编辑和转换 PowerPoint 和 OpenDocument 演示文稿，无需 Microsoft PowerPoint 或 Office 自动化。

它支持加载和保存 PPT、PPTX、PPS、POT 和 ODP，包括带宏的和模板变体，并可导出为 PDF、XPS、HTML、SVG、TIFF、Markdown 和图像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>快速入门</b></p>
<hr>
<p>入门</p>
<ul>
<li><a href="/slides/zh/cpp/installation/">安装</a></li>
<li><a href="/slides/zh/cpp/create-presentation/">创建您的第一个演示文稿</a></li>
<li><a href="/slides/zh/cpp/getting-started/">入门指南</a></li>
</ul>
<p>评估</p>
<ul>
<li><a href="/slides/zh/cpp/supported-file-formats/">支持的文件格式</a></li>
<li><a href="/slides/zh/cpp/evaluate-aspose-slides/">试用限制</a></li>
<li><a href="/slides/zh/cpp/licensing/">授权许可</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 构建</b></p>
<hr>
<p>常见任务</p>
<ul>
<li><a href="/slides/zh/cpp/open-presentation/">打开演示文稿</a></li>
<li><a href="/slides/zh/cpp/save-presentation/">保存演示文稿</a></li>
<li><a href="/slides/zh/cpp/convert-powerpoint-to-pdf/">转换为 PDF</a></li>
<li><a href="/slides/zh/cpp/convert-slide/">将幻灯片渲染为图像</a></li>
<li><a href="/slides/zh/cpp/manage-text/">编辑文本和形状</a></li>
</ul>
<p>Slides 工作流</p>
<ul>
<li><a href="/slides/zh/cpp/powerpoint-charts/">图表</a></li>
<li><a href="/slides/zh/cpp/powerpoint-animation/">动画</a></li>
<li><a href="/slides/zh/cpp/manage-media-files/">音频和视频</a></li>
<li><a href="/slides/zh/cpp/presentation-design/">幻灯片设计</a></li>
<li><a href="/slides/zh/cpp/merge-presentation/">合并演示文稿</a></li>
</ul>
<p>示例</p>
<ul>
<li><a href="/slides/zh/cpp/examples/">按幻灯片元素的示例</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">GitHub 上的示例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>参考 &amp; 支持</b></p>
<hr>
<p>参考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">API 参考</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">发布说明</a></li>
<li><a href="/slides/zh/cpp/known-issues/">已知问题</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">下载</a></li>
</ul>
<p>支持</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">免费支持论坛</a></li>
<li><a href="https://helpdesk.aspose.com/">付费支持帮助台</a></li>
</ul>
</div>
</div>

------

## **您的第一个演示文稿**

在 Windows 上，使用 Visual Studio 创建一个 C++ **Console App** 项目，并在包管理器控制台中安装 NuGet 包（**工具** > **NuGet 包管理器** > **包管理器控制台**）：

```powershell
Install-Package Aspose.Slides.Cpp
```

在 Linux 上，下载 Linux ZIP 包并按照 [Installation](/slides/zh/cpp/installation/#linux) 中描述的方式设置 CMake 项目。

然后将以下代码用作程序的主源文件。它会创建一个包含一个文本框的演示文稿并保存它：

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

要在 Windows 上运行它，请在工具栏中选择 **x64** 平台并按 **Ctrl+F5**。在 Linux 上，将其保存为项目文件夹中的 *main.cpp*，然后在该环境中构建并运行：

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

程序会将 *hello.pptx*（包含一个带文本框的幻灯片）保存下来。若未授权，保存的文件会带有评估水印 — 请参阅 [Licensing](/slides/zh/cpp/licensing/)。欲了解更多创建和填充演示文稿的方法，请参阅 [Create Presentations](/slides/zh/cpp/create-presentation/)。