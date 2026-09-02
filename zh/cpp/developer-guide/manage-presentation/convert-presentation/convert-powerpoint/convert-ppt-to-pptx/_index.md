---
title: 将 PPT 转换为 C++ 中的 PPTX
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
- 将 PPT 保存 为 PPTX
- 导出 PPT 为 PPTX
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "在 C++ 中使用 Aspose.Slides 将传统 PPT 文件转换为 PPTX。包括单文件和批量转换的 C++ 示例、错误处理和保真度说明。"
---
## **概述**

PPT 是传统的二进制 PowerPoint 格式，而 PPTX 是更新的 Open XML 格式。Aspose.Slides for C++ 可以在无需 Microsoft PowerPoint 的情况下加载 PPT 文件并将其保存为 PPTX。本文展示如何转换单个文件或整个目录的文件，并说明转换后需要验证的内容。

## **将 PPT 文件转换为 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类加载源文件，然后使用 [Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 并传入 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/) 参数进行保存。完成后释放演示文稿以释放资源。

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

文件扩展名本身并不会决定输出格式；决定因素是 [SaveFormat::Pptx](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/) 参数。如果需要保留原始 PPT 文件，请确保输入路径和输出路径不同。

## **批量转换 PPT 文件**

下面的示例将目录中每个 `.ppt` 文件进行转换。每个文件独立处理，单个转换失败不会阻止其余批次继续。

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

对于生产环境，请记录完整的异常信息，决定是否可以覆盖已有的输出文件，并将失败的文件名写入重试或审查队列。损坏的文件、未提供正确密码的受密码保护文件、无法访问的路径以及不受支持的内容都可能导致转换失败。有关加载加密文件，请参阅 [Password-Protected Presentations](/cpp/password-protected-presentation/)。

## **保真度和遗留功能**

转换通常会保留幻灯片、母版、版式、文本、形状、图像、表格和图表。然而，PPT 与 PPTX 并未以完全相同的方式表示所有功能。没有 PPTX 等价的遗留功能或库不支持的功能可能会被标准化、忽略或以不同方式显示。

当文件包含动画、转场、嵌入或链接的 OLE 对象、ActiveX 控件、嵌入媒体、非常用字体或 VBA 宏时，请检查转换后的文件。普通 PPTX 文件不是宏启用格式，因此在必须保留 VBA 时请使用相应的宏启用工作流。同时验证在将要打开或渲染转换后演示文稿的环境中，所需的字体和外部资源是否可用。

对于重要文档，建议以编程方式重新打开生成的 PPTX，检查关键幻灯片数量和内容，然后在目标查看器中比较其外观和放映行为。不要把成功调用 [Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 当作所有遗留功能都有精确 PPTX 表示的证明。

## **何时使用 PPTX**

当演示文稿将在当前 PowerPoint 版本中编辑、需要与使用 Open XML 包的系统交换，或希望以比传统二进制 PPT 更易检查和恢复的格式存储时，请使用 PPTX。保留原始 PPT 作为归档或回滚副本，直至转换后的演示文稿通过您的保真度检查。

如果需要 PDF、HTML、图像、XPS 或其他输出类型，请参阅 [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) 中的针对性指导，而不是假设所有目标都能保留可编辑的 PowerPoint 功能。

## **在线转换器**

对于偶尔的文件或快速比较，您可以使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx)。对于可重复的转换、批处理或应用层错误处理，请使用 C++ API。

## **相关文章**

- [在 C++ 中保存演示文稿](/cpp/save-presentation/)
- [受支持的文件格式](/cpp/supported-file-formats/)
- [在 C++ 中打开演示文稿](/cpp/open-presentation/)

## **常见问答**

**我可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX 吗？**

可以。Aspose.Slides for C++ 在不需要 Microsoft PowerPoint 的情况下加载和保存演示文稿文件。

**PPT 转 PPTX 转换能完全保留所有内容吗？**

它会保留常见的演示文稿内容，但对每个遗留或不受支持的功能并不保证完全保真。当文件包含宏、OLE 或 ActiveX 对象、媒体、特化动画或非常用字体时，请审查生成的文件。

**我可以转换受密码保护的 PPT 文件吗？**

可以，在加载文件时提供正确的密码。缺少或错误的密码会导致加载操作失败。

**转换后我应该删除 PPT 文件吗？**

在您验证 PPTX 在相关查看器和工作流中的表现之前，请保留原始文件。这为遗留功能转换异常提供了回滚副本。