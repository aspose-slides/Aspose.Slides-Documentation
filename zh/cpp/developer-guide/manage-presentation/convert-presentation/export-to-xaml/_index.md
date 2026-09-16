---
title: 在 C++ 中将演示文稿导出为 XAML
linktitle: 演示文稿到 XAML
type: docs
weight: 30
url: /zh/cpp/export-to-xaml/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出 演示文稿
- 转换 PowerPoint
- 转换 OpenDocument
- 转换 演示文稿
- PowerPoint 转 XAML
- OpenDocument 转 XAML
- 演示文稿 转 XAML
- PPT 转 XAML
- PPTX 转 XAML
- ODP 转 XAML
- 将 PPT 保存为 XAML
- 将 PPTX 保存为 XAML
- 将 ODP 保存为 XAML
- 导出 PPT 为 XAML
- 导出 PPTX 为 XAML
- 导出 ODP 为 XAML
- C++
- Aspose.Slides
description: "在 C++ 中使用 Aspose.Slides 将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML——快速、无需 Office 的解决方案，保持布局完整。"
---
## **概述**

本文说明如何使用 Aspose.Slides 将 PowerPoint 演示文稿导出为 XAML。它包括对 XAML 的简要介绍，展示如何使用默认设置将演示文稿保存为 XAML，并演示如何通过 [XamlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export.xaml/xamloptions/) 自定义导出，包括导出隐藏幻灯片。文章还回答了一些常见问题，涉及回退字体、XAML 堆栈兼容性以及隐藏幻灯片导出行为。

## **关于 XAML**

XAML 是一种基于 XML 的标记语言，用于在 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin.Forms 等框架中描述用户界面。

您可以在可视化设计器中使用 XAML 文件，也可以直接编写和编辑标记。

## **使用默认选项将演示文稿导出为 XAML**

以下 C++ 示例展示了如何使用默认设置将演示文稿导出为 XAML：

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

默认情况下，导出的幻灯片保存在进程当前工作目录的 `pres` 子文件夹中，目录由 [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/zh/cpp/system.io/directory/getcurrentdirectory/) 返回。该文件夹会自动创建，所需的图像也会保存到该文件夹中。

输出文件夹名称取自源文件名（不含扩展名）。对于 `pres.pptx`，输出文件命名为 `pres/Slide_1.xaml`、`pres/Slide_2.xaml` 等。即使为输入演示文稿传入绝对路径，输出文件夹也相对于当前工作目录创建，而不是与输入文件放在同一位置。

## **使用自定义选项将演示文稿导出为 XAML**

使用 [IXamlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export.xaml/ixamloptions/) 接口来控制 Aspose.Slides 将演示文稿导出为 XAML 的方式。

要将输出保存到自定义位置，请实现 [IXamlOutputSaver](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export.xaml/ixamloutputsaver/) 并将您的实现实例传递给 [XamlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export.xaml/xamloptions/) 的 [set_OutputSaver](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) 方法。

要在 XAML 输出中包含隐藏幻灯片，请向 [set_ExportHiddenSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) 方法传递 `true`，如下 C++ 示例所示：

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **捕获所有生成的 XAML 工件**

XAML 导出可以为每个导出的幻灯片生成一个 XAML 文档，并生成单独的图像和支持资源。将自定义的 [IXamlOutputSaver](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export.xaml/ixamloutputsaver/) 传递给 [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/)，即可接收这些工件，而不是使用默认的文件系统保存器。使用接受 XAML 选项的 XAML 特定的 [Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 重载启动导出。

### **了解回调生命周期**

导出器会为每个生成的工件分别调用 [IXamlOutputSaver::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/)：

- `path` 标识工件，可能包含相对目录。请保留此信息，因为 XAML 可能使用相对路径引用资源。
- `data` 包含工件的字节。图像和其他二进制资源不能被解码为文本。
- 保存器负责在返回前保留或持久化数据。示例中将每个字节数组复制到应用程序拥有的内存中。
- 仅当演示文稿保存操作返回且每个回调均成功完成时，才视导出为成功。不要吞掉存储错误或启动未监视的后台写入。如果持久化在之后进行，则仅在该步骤也成功后才报告整体成功。

[XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) 同样适用于自定义保存器。默认设置为 `false`，会排除隐藏幻灯片的 XAML 文档。将其设为 `true` 则会包含它们以及导出所需的所有资源。资源数量取决于演示文稿；不要假设每个幻灯片对应一个回调或回调顺序固定。

### **导出到内存并检查工件**

此完整示例加载 `pres.pptx`，在一个 [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/zh/cpp/system.collections.generic/dictionary/) 中收集所有工件，并打印其名称、类型和字节数。它完全保留提供的名称。重复名称会导致收集失败，而不是静默覆盖工件。

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // 仅在需要文本检查时解码 XAML。
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

在您的应用程序中调用 `InMemoryXamlExample::Run`。扩展检查对于检查很有帮助；保留所有工件，包括不熟悉的资源类型。存储或传输时保持字节不变。仅在需要对 XAML 进行文本处理时，使用 UTF-8 编码的 [Encoding::GetString](https://reference.aspose.com/slides/zh/cpp/system.text/encoding/getstring/)。

### **将收集的工件打包为 ZIP 存档**

此独立示例收集导出内容，验证其名称，并将原始字节写入 ZIP 存档。唯一的存档名称用于区分并发的导出作业。ZIP 条目使用正斜杠并保留相对目录。危险名称或规范化后冲突的名称会在写入之前拒绝整个包。

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // 保存会完成 ZIP 目录的写入；在报告成功之前关闭文件。
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

在您的应用程序中调用 `ZipXamlExample::Run`。示例使用 C++ 运行时的 `Aspose::Zip::ZipFile` 写入本地存档；导出器本身不写入松散的 XAML 或图像文件。对于远程存储，请将写入存档的阶段替换为对收集的字节数组的上传。可以使用导出作业标识符加完整相对工件名称作为 Blob 键，或将作业标识符、相对名称和二进制数据存储在数据库行中。仅在所有上传完成或数据库事务提交后才发布作业。如果持久化失败，清理部分输出。

对于大型演示文稿，自定义保存器可以将每个工件直接持久化到应用存储，从而避免在应用内存中保留整个导出的额外副本。导出器仍会在调用保存器之前在内存中收集所有生成的工件。请确保每个回调从导出器的角度是同步的：仅在目标接受字节后返回，并让失败传递给调用方。

### **保留资源名称并验证引用**

- 当目标需要时归一化路径分隔符，但保留相对目录。除非已知每个生成的名称都是唯一的且资源引用保持有效，否则不要仅使用 [Path::GetFileName](https://reference.aspose.com/slides/zh/cpp/system.io/path/getfilename/)。
- 应用目标特定的名称验证。写入松散文件时，拒绝根路径和遍历段，使用 [Path::GetFullPath](https://reference.aspose.com/slides/zh/cpp/system.io/path/getfullpath/) 解析目标，并验证其保持在预期的导出目录之下，包括在包含检查中使用目录分隔符。使用没有可能重定向写入的符号链接的应用程序受控目录。
- 为每个导出作业使用单独的保存器和存储命名空间。根据分隔符归一化后以及目标的大小写敏感规则检测冲突。
- 在发布之前，将每个 XAML 文档解析为 XML，并检查其基于文件的资源引用，如图像的 `Source` 或 `ImageSource` 属性。根据包含该 XAML 工件的目录解析每个相对 URI，归一化得到的存储名称，并确认对应的字典键、ZIP 条目或存储对象是否存在。将外部 URI 和 XAML 标记表达式与相对文件名分开处理。

例如，如果 `pres/Slide_1.xaml` 引用了 `images/image1.png`，则存储的资源必须以 `pres/images/image1.png` 的形式存在。仅保留 `image1.png` 会破坏该关系。对于对象存储，需在作业前缀下保留相同的布局，并使这些资源 URL 对 XAML 使用者可访问。重新打开已完成的 ZIP，验证条目名称和资源字节，并在目标 XAML 环境中加载代表性幻灯片，以确认图像能够正确解析。

## **常见问题**

**如果原始字体在机器上不可用，如何确保可预测的字体？**

在 [XamlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export.xaml/xamloptions/) 中使用 [set_DefaultRegularFont](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) — 当原始字体缺失时，它将在导出期间作为回退字体使用。这并不保证生成的 XAML 会引用回退字体，或该字体在目标机器上可用。请确保 XAML 引用的字体在显示环境中可用。

**导出的 XAML 仅面向 WPF，还是也可以用于其他 XAML 堆栈？**

Aspose.Slides 通过其公共 API 导出 WPF XAML。对其他 XAML 堆栈（如 UWP 和 Xamarin.Forms）的兼容性不作保证。请在目标环境中测试生成的标记。

**是否支持隐藏幻灯片，如何防止它们默认被导出？**

默认情况下，隐藏幻灯片不会被包含。您可以通过 [XamlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export.xaml/xamloptions/) 中的 [set_ExportHiddenSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) 来控制此行为——如果不需要导出隐藏幻灯片，请保持其禁用状态。