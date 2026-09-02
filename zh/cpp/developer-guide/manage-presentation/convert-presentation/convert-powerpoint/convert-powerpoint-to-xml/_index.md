---
title: 在 C++ 中将 PowerPoint 演示文稿转换为 XML
linktitle: PowerPoint 转 XML
type: docs
weight: 145
url: /zh/cpp/convert-powerpoint-to-xml/
keywords:
- 将 PowerPoint 转换为 XML
- 将演示文稿转换为 XML
- PPT 转 XML
- PPTX 转 XML
- ODP 转 XML
- PowerPoint XML 演示文稿
- SaveFormat::Xml
- 将演示文稿保存为 XML
- 将演示文稿导出为 XML
- XML 流
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 将 PowerPoint 和 OpenDocument 演示文稿转换为 PowerPoint XML 文件或流（C++）。"
---
## **概览**

Aspose.Slides for C++ 可以将 PowerPoint 演示文稿转换为 PowerPoint XML 演示文稿格式。XML 输出在需要文本形式的表示以检查演示文稿结构、排查生成的文档、在自动化测试中比较输出，或在需要使用 XML 而非演示文稿包的工作流中集成时非常有用。

使用 [Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 方法，并使用来自 [SaveFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/) 枚举的 `Xml` 值。您可以直接将结果写入文件或流。

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` 创建 PowerPoint XML 演示文稿。它不会提取 PPTX 包中存储的单个 Office Open XML 部分。如果您需要确切的 PPTX 包部分，例如 `ppt/presentation.xml` 或单个幻灯片的 XML 文件，请检查 PPTX 包本身。
{{% /alert %}}

## **将演示文稿转换为 XML 文件**

使用 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类加载源演示文稿，然后将输出路径和 `SaveFormat::Xml` 传递给 [Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/)。源可以是任何受支持的加载格式，如 PPT、PPTX 或 ODP。

以下示例将 PPTX 演示文稿转换为 XML 文件：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **将 XML 输出写入流**

当 XML 必须保留在内存中或传递给其他组件（如 Web 服务、存储提供程序或 XML 处理管道）时，请使用 [Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 的流重载。以下示例将结果写入 [MemoryStream](https://reference.aspose.com/slides/zh/cpp/system.io/memorystream/) 并将其倒回以供后续读取：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// 将 xmlStream 传递给工作流中的下一个组件。
```

## **将 XML 与演示文稿和导出格式进行比较**

根据结果的使用方式选择输出格式：

| 格式 | 输出 | 典型使用 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 演示文稿 | 检查结构、排查问题、比较生成的输出以及基于 XML 的集成 |
| PPT (`.ppt`) | 传统的二进制演示文稿文件 | 与旧版 PowerPoint 工作流的兼容性 |
| PPTX (`.pptx`) | 包含多个部分的 Office Open XML 包 | 常规的 PowerPoint 编辑和演示文稿交换 |
| PDF 或 TIFF | 固定布局页面或多页图像 | 查看、打印和归档 |
| PNG、JPEG 或 SVG | 单个幻灯片的渲染表示 | 缩略图、预览和图像资源 |
| HTML 或 HTML5 | 面向 Web 的演示输出 | 浏览器查看和网络发布 |

与 PPT 和 PPTX 不同，XML 输出主要用于检查和面向数据的工作流。与 PDF、TIFF、HTML 和幻灯片图像格式不同，它表示演示文稿数据，而不是将幻灯片渲染为页面或视觉资源。[supported file formats](/slides/zh/cpp/supported-file-formats/) 表列出了 PowerPoint XML 演示文稿为仅保存格式，因此当工作流需要将导出的文件加载回 Aspose.Slides 以继续编辑时，请勿使用它。

## **常见问题**

**`SaveFormat::Xml` 与保存 PPTX 文件是否相同？**  
否。PPTX 是包含多个 Office Open XML 部分的包装，而 `SaveFormat::Xml` 创建的是 PowerPoint XML 演示文稿文件。

**是否可以在不在磁盘上创建文件的情况下保存 XML 输出？**  
可以。将可写流传递给 [Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/)。例如，使用 [MemoryStream](https://reference.aspose.com/slides/zh/cpp/system.io/memorystream/) 进行内存内处理。

**Aspose.Slides 能再次加载导出的 XML 文件吗？**  
否。目前仅支持将 PowerPoint XML 演示文稿保存，尚不支持加载。需要往返编辑时，请使用 PPTX 或其他受支持的演示文稿格式。

**XML 转换是否将每张幻灯片渲染为页面或图像？**  
否。XML 转换仅写入结构化的演示文稿数据。如需面向页面的输出，请使用 PDF 或 TIFF；如需单张幻灯片图像，请使用 PNG、JPEG 或 SVG。