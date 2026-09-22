---
title: 在 C++ 中保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/cpp/save-presentation/
keywords:
- 保存 PowerPoint
- 保存 OpenDocument
- 保存 演示文稿
- 保存 幻灯片
- 保存 PPT
- 保存 PPTX
- 保存 ODP
- 演示文稿 到 文件
- 演示文稿 到 流
- 预定义 视图 类型
- 严格 Office Open XML 格式
- Zip64 模式
- 刷新 缩略图
- 保存 进度
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中将 PowerPoint 和 OpenDocument 演示文稿保存为文件或流，并配置 PPTX 输出和进度报告。"
---
## **概述**

创建演示文稿或[打开现有演示文稿](/slides/zh/cpp/open-presentation/)后，使用[Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/)方法写入结果。Aspose.Slides for C++ 可以将演示文稿保存为文件或流，支持 PowerPoint、OpenDocument、PDF 等格式。以下章节介绍标准保存操作以及 PPTX 输出可用的选项。

## **将演示文稿保存到文件**

要将演示文稿保存到文件，向[Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/)方法传递输出路径和一个[SaveFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/)值。该格式值决定 Aspose.Slides 创建的文件类型。

以下示例创建一个演示文稿并将其保存为 PPTX 文件：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// 在此添加或修改演示文稿内容。

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **按原始格式保存演示文稿**

有关文件和流检测示例、新建演示文稿的行为以及源格式与输出格式的区别，请参阅[确定原始演示文稿格式](/slides/zh/cpp/detect-presentation-source-format/)。

在批处理应用程序中，输入格式可能事先未知。加载文件后，可使用[IPresentation::get_SourceFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_sourceformat/)读取其原始格式。将得到的[SourceFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sourceformat/)值传递给[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/slideutil/tosaveformat/)，以获取对应的[SaveFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/)值，然后使用[Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/)写入修改后的演示文稿。

以下完整示例遍历输入目录中的每个文件，更新其标题，并以加载时的格式保存到输出目录：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.util/slideutil/tosaveformat/)将 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 以及 PowerPoint XML 映射到相应的演示文稿保存格式。它仅映射演示文稿源格式；并不用于选择 PDF、HTML、TIFF 或图像等导出格式。传入不受支持或无效的[SourceFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sourceformat/)值会导致[ArgumentException](https://reference.aspose.com/slides/zh/cpp/system/argumentexception/)。

旧版 PPT、PPS 和 POT 文件使用相同的二进制容器。当此类演示文稿从没有文件扩展名的流中加载时，PPS 或 POT 文件可能被识别为 PPT。如果需要保留这些旧子类型，请单独保留原始文件名或格式元数据，并在选择输出文件名和格式时使用它们。

## **将演示文稿保存到流**

若不依赖最终文件路径写入演示文稿，可向[Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/)方法传递可写的[Stream](https://reference.aspose.com/slides/zh/cpp/system.io/stream/)和[SaveFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/)值。这在需要从 Web 服务返回输出、存储到数据库或在内存中处理时非常有用。

以下示例将新演示文稿保存到文件流：

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **使用预定义视图类型保存演示文稿**

可以指定 PowerPoint 打开已保存演示文稿时的默认视图。保存前，调用[ViewProperties::set_LastView](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewproperties/set_lastview/)并传入[ViewType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewtype/)值。

以下示例将母版视图设为初始视图：

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

## **以 Strict Office Open XML 格式保存演示文稿**

若要创建符合 Office Open XML Strict 配置文件的 PPTX 文件，实例化[PptxOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/pptxoptions/)，并使用`Conformance::Iso29500_2008_Strict`调用[PptxOptions::set_Conformance](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/pptxoptions/set_conformance/)。随后将该选项传递给[Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/)方法。

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **以 Zip64 模式保存 Office Open XML 格式的演示文稿**

标准 ZIP 存档对每个条目的压缩和未压缩大小、整个存档大小以及条目数量都有限制。由于 PPTX 文件本质上是 ZIP 存档，极大的演示文稿可能超出这些限制。ZIP64 扩展可以提升相应的大小和条目计数限制。

使用[PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/pptxoptions/set_zip64mode/)来控制 Aspose.Slides 是否写入 ZIP64 扩展：

- `IfNecessary` 仅在演示文稿超出标准 ZIP 限制时使用 ZIP64，这是默认模式。
- `Never` 禁用 ZIP64 扩展。
- `Always` 始终写入 ZIP64 扩展。

以下示例始终为输出演示文稿启用 ZIP64 扩展：

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
如果将 `Zip64Mode` 设置为 `Never` 且演示文稿无法在标准 ZIP 限制内容纳，保存操作将抛出[PptxException](https://reference.aspose.com/slides/zh/cpp/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以不同压缩级别保存 Office Open XML 格式的演示文稿**

对于 PPTX 输出，可以通过调用[PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) 在保存速度和文件大小之间取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/compressionlevel/) 枚举提供以下值：

- `None` 不进行压缩直接存储数据。
- `Level1` 提供最快的压缩速度，但生成的压缩文件最大。
- `Level2` 到 `Level5` 逐步倾向于更小的输出，而牺牲保存速度。
- `Level6` 在保存速度和文件大小之间取得平衡，这是默认级别。
- `Level7` 和 `Level8` 进一步倾向于更小的输出，进一步降低保存速度。
- `Level9` 提供最强的压缩，需要最长的处理时间。

以下示例在不进行压缩的情况下保存演示文稿：

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

以下示例使用最高压缩级别：

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **保存演示文稿时不刷新缩略图**

当演示文稿以 PPTX 保存时，[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) 控制文档缩略图的生成：

- `true` 在保存过程中重新生成缩略图，这是默认值。
- `false` 保留现有缩略图。如果演示文稿没有缩略图，Aspose.Slides 不会生成新的。

以下示例在保存时不刷新缩略图：

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
禁用缩略图刷新可以缩短 PPTX 文件的保存时间。
{{% /alert %}}

## **以百分比形式显示保存进度**

要监控保存过程，实现[IProgressCallback](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprogresscallback/) 接口并将实现传递给[ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/isaveoptions/set_progresscallback/)。Aspose.Slides 将在导出期间调用[IProgressCallback::Reporting](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprogresscallback/reporting/) 并提供进度值。

以下示例将 PDF 导出的进度报告到控制台：

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose 提供了基于 Aspose.Slides API 的免费[PowerPoint Splitter](https://products.aspose.app/slides/zh/splitter)，可将演示文稿的选定幻灯片保存为单独的 PPT 或 PPTX 文件。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持增量或“快速保存”？**

不支持。每次保存都会写入完整的输出文件，而不是仅更新已更改的部分。

**多个线程可以同时保存同一个 Presentation 实例吗？**

不可以。`Presentation` 实例[不是线程安全的](/slides/zh/cpp/multithreading/)。每次只能由单个线程访问并保存该实例。

**保存演示文稿时，超链接和外部链接的文件会怎样？**

[超链接](/slides/zh/cpp/manage-hyperlinks/)仍然保留在演示文稿中。Aspose.Slides 不会复制外部链接的文件，因此保存后的演示文稿仍需能够访问这些文件的位置。

**我可以保存文档元数据（如作者、标题、公司和创建日期）吗？**

可以。在保存之前设置相应的[文档属性](/slides/zh/cpp/presentation-properties/)，Aspose.Slides 会将它们写入输出文件。