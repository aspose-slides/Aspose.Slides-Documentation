---
title: 在 C++ 中保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/cpp/save-presentation/
keywords:
- 保存 PowerPoint
- 保存 OpenDocument
- 保存演示文稿
- 保存幻灯片
- 保存 PPT
- 保存 PPTX
- 保存 ODP
- 演示文稿到文件
- 演示文稿到流
- 预定义视图类型
- 严格的 Office Open XML 格式
- Zip64 模式
- 刷新缩略图
- 保存进度
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 C++ 中保存演示文稿——导出为 PowerPoint 或 OpenDocument，同时保留布局、字体和效果。"
---
## **概述**

[在 C++ 中打开演示文稿](/slides/zh/cpp/open-presentation/) 介绍了如何使用 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类打开演示文稿。本文说明了如何创建和保存演示文稿。[Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类包含演示文稿的内容。无论是从头创建演示文稿还是修改现有演示文稿，完成后都需要保存。使用 Aspose.Slides for C++，您可以保存到 **文件** 或 **流**。本文解释了保存演示文稿的不同方式。

## **将演示文稿保存到文件**

通过调用 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的 `Save` 方法将演示文稿保存到文件。将文件名和保存格式传递给该方法。下面的示例演示了如何使用 Aspose.Slides 保存演示文稿。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

// 在此处执行一些操作...
// 将演示文稿保存到文件。
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **将演示文稿保存到流**

您可以通过将输出流传递给 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的 `Save` 方法，将演示文稿保存到流。演示文稿可以写入多种流类型。以下示例中，我们创建一个新演示文稿并将其保存到文件流。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// 将演示文稿保存到流中。
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **使用预定义视图类型保存演示文稿**

Aspose.Slides 通过 [ViewProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewproperties/) 类允许您设置生成的演示文稿打开时 PowerPoint 使用的初始视图。使用来自 [ViewType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewtype/) 枚举的值调用 [set_LastView](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewproperties/set_lastview/) 方法。

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **以严格的 Office Open XML 格式保存演示文稿**

Aspose.Slides 允许您以严格的 Office Open XML 格式保存演示文稿。保存时使用 [PptxOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/pptxoptions/) 类并设置其 conformance 属性。如果将其设为 `Conformance.Iso29500_2008_Strict`，输出文件将以严格的 Office Open XML 格式保存。

下面的示例创建一个演示文稿并以严格的 Office Open XML 格式保存。

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>();

// 以严格的 Office Open XML 格式保存演示文稿。
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **在 Zip64 模式下以 Office Open XML 格式保存演示文稿**

Office Open XML 文件是一个 ZIP 存档，对任意文件的未压缩大小、压缩大小以及存档的总大小都有 4 GB（2^32 字节）的限制，并且存档的文件数量限制为 65,535（2^16‑1）个。ZIP64 格式扩展将这些限制提升至 2^64。

[IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) 方法允许您在保存 Office Open XML 文件时选择何时使用 ZIP64 格式扩展。

此方法可以与以下模式一起使用：

- `IfNecessary` 仅在演示文稿超过上述限制时使用 ZIP64 格式扩展。这是默认模式。
- `Never` 永不使用 ZIP64 格式扩展。
- `Always` 始终使用 ZIP64 格式扩展。

以下代码演示了如何在启用 ZIP64 格式扩展的情况下将演示文稿保存为 PPTX 文件：

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
当您使用 `Zip64Mode.Never` 保存时，如果演示文稿无法以 ZIP32 格式保存，将抛出 [PptxException](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pptxexception/)。
{{% /alert %}}

## **在 Office Open XML 格式下使用压缩级别保存演示文稿**

处理大型演示文稿时，您可以调节压缩级别以在文件大小和处理时间之间取得平衡。根据需求，您可能更倾向于更快的处理速度或更小的输出文件。

Aspose.Slides 提供了 [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) 方法，允许您指定在以 Office Open XML 格式保存演示文稿时使用的压缩级别。

可用的压缩级别如下：

- **None**: 不进行压缩。文件保持原样存储。
- **Level1**: 最快的压缩，压缩比最低。
- **Level2**: 较快的压缩，压缩比略好于 **Level1**。
- **Level3**: 提供比 **Level2** 更好的压缩，处理时间有适度影响。
- **Level4**: 提供比 **Level3** 更好的压缩。
- **Level5**: 在 **Level4** 基础上进一步提升压缩，需额外的处理时间。
- **Level6**: 标准压缩，在处理速度和文件大小之间取得良好平衡。这是 *默认压缩级别*。
- **Level7**: 提供比 **Level6** 更好的压缩，但处理速度较慢。
- **Level8**: 提供比 **Level7** 更好的压缩。
- **Level9**: 最大压缩。能够生成最小的文件尺寸，但需要最长的处理时间。

以下示例演示如何将演示文稿保存为 *无压缩* 的 PPTX 文件：

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

此示例展示如何将演示文稿保存为 *最大压缩* 的 PPTX 文件：

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **保存演示文稿时不刷新缩略图**

[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) 方法控制将演示文稿保存为 PPTX 时的缩略图生成：

- 如果设置为 `true`，保存时将刷新缩略图。这是默认设置。
- 如果设置为 `false`，则保留当前缩略图。如果演示文稿没有缩略图，则不会生成。

以下代码将演示文稿保存为 PPTX，且不刷新其缩略图。

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
此选项有助于减少保存 PPTX 格式演示文稿所需的时间。
{{% /alert %}}

## **以百分比保存进度更新**

[IProgressCallback](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprogresscallback/) 接口通过 [ISaveOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/isaveoptions/) 接口和抽象的 [SaveOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveoptions/) 类公开的 `set_ProgressCallback` 方法使用。使用 `set_ProgressCallback` 分配一个 [IProgressCallback](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprogresscallback/) 实现，以接收以百分比表示的保存进度更新。

以下代码片段展示了如何使用 `IProgressCallback`。

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // 使用此处的进度百分比值。
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 上面定义的进度回调类。
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose 使用其自有 API开发了一个 [免费 PowerPoint 拆分器应用](https://products.aspose.app/slides/zh/splitter)。该应用可通过将选定的幻灯片另存为新的 PPTX 或 PPT 文件，将演示文稿拆分为多个文件。
{{% /alert %}}

## **常见问题**

**是否支持“快速保存”（增量保存）仅写入更改？**

不支持。每次保存都会重新创建完整的目标文件，不支持增量“快速保存”。

**从多个线程保存同一个 Presentation 实例是否线程安全？**

不安全。一个 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例 [不是线程安全的](/slides/zh/cpp/multithreading/)，请在单线程中进行保存。

**保存时超链接和外部链接文件会怎样？**

[超链接](/slides/zh/cpp/manage-hyperlinks/) 会被保留。外部链接的文件（例如使用相对路径的视频）不会自动复制—请确保引用的路径仍然可访问。

**我可以设置/保存文档元数据（作者、标题、公司、日期）吗？**

可以。支持标准的 [文档属性](/slides/zh/cpp/presentation-properties/)，并将在保存时写入文件。