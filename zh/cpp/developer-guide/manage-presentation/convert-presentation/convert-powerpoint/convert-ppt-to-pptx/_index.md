---
title: 在 C++ 中将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/cpp/convert-ppt-to-pptx/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- PPT 转 PPTX
- 将 PPT 保存为 PPTX
- 导出 PPT 为 PPTX
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中将传统 PPT 文件转换为 PPTX。包括单文件和批量转换的 C++ 示例、错误处理以及保真度说明。"
---
## **概述**

PPT 是传统的二进制 PowerPoint 格式，而 PPTX 是更新的 Open XML 格式。Aspose.Slides for C++ 可以在没有 Microsoft PowerPoint 的情况下加载 PPT 文件并将其保存为 PPTX。本文展示如何转换单个文件或整个文件夹，并说明转换后需要检查的事项。

## **将 PPT 文件转换为 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类加载源文件，然后调用 [Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 并传入 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/) 参数。完成后请释放 Presentation 以释放资源。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

文件扩展名本身不会决定输出格式；是 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/) 参数起作用。如果需要保留原始 PPT 文件，请确保输入路径和输出路径不同。

## **批量转换 PPT 文件**

以下示例将目录中的每个 `.ppt` 文件转换。每个文件独立处理，单个转换失败不会导致批次中止。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

对于生产环境，请记录完整异常，决定是否可以覆盖已有的输出文件，并将失败的文件名写入重试或审查队列。文件损坏、未提供密码的受密码保护文件、路径不可访问以及不受支持的内容都可能导致转换失败。有关加载加密文件，请参阅 [Password-Protected Presentations](/slides/zh/cpp/password-protected-presentation/)。

## **保真度和遗留特性**

转换通常会保留幻灯片、母版、版式、文本、形状、图像、表格和图表。但 PPT 与 PPTX 并非在所有特性上完全对应。没有 PPTX 等价实现的遗留特性，或库不支持的特性，可能会被规范化、忽略或以不同方式显示。

当转换后的文件包含动画、转场、嵌入或链接的 OLE 对象、ActiveX 控件、嵌入媒体、非常规字体或 VBA 宏时，请检查文件。纯 PPTX 文件不是宏启用格式，若必须保留 VBA，请使用相应的宏启用工作流。同时验证目标环境中是否存在所需的字体和外部资源。

对于重要文档，建议以编程方式重新打开生成的 PPTX，检查关键幻灯片数量和内容，然后在目标查看器中比较外观和放映行为。不要将成功的 [Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 调用视为每个遗留特性都有精确 PPTX 表示的依据。

## **何时使用 PPTX**

当演示文稿将在当前版本的 PowerPoint 中编辑、需要与支持 Open XML 包的系统交换，或希望以比传统二进制 PPT 更易检查和恢复的格式存储时，请使用 PPTX。在转换后通过保真度检查之前，保留原始 PPT 作为归档或回滚副本。

如果需要 PDF、HTML、图像、XPS 或其他输出类型，请参阅 [Convert Presentations to Multiple Formats](/slides/zh/cpp/convert-presentation/) 中的针对特定格式的指南，而不要假设所有目标都保留可编辑的 PowerPoint 特性。

## **在线转换器**

对于偶尔的文件或快速对比，可以使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx)。若需可重复的转换、批量处理或应用层错误处理，请使用 C++ API。

## **相关文章**

- [Save Presentations in C++](/slides/zh/cpp/save-presentation/)
- [Supported File Formats](/slides/zh/cpp/supported-file-formats/)
- [Open Presentations in C++](/slides/zh/cpp/open-presentation/)

## **FAQ**

**是否可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX？**

可以。Aspose.Slides for C++ 在不依赖 Microsoft PowerPoint 的情况下加载和保存演示文稿文件。

**PPT 到 PPTX 的转换能完全保留所有内容吗？**

它会保留常见的演示文稿内容，但对每个遗留或不受支持的特性并不能保证完全保真。当文件包含宏、OLE 或 ActiveX 对象、媒体、专门的动画或非常规字体时，请审查生成的文件。

**可以转换受密码保护的 PPT 文件吗？**

可以，只需在加载文件时提供正确的密码。缺少或错误的密码会导致加载失败。

**转换后是否应该删除 PPT 文件？**

请保留原始文件，直到在您关注的查看器和工作流中验证了 PPTX。这可以在出现遗留特性转换异常时提供回滚副本。