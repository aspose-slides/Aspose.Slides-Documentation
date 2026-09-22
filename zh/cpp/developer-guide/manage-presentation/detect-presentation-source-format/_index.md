---
title: 在 C++ 中确定原始演示文稿格式
linktitle: 源格式
type: docs
weight: 35
url: /zh/cpp/detect-presentation-source-format/
keywords:
- 源格式
- 检测演示文稿格式
- PowerPoint
- OpenDocument
- 演示文稿
- PPT
- PPTX
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 C++ 中读取已加载演示文稿的原始格式，比较检测 API，并处理文件、流和旧版格式。"
---
## **概述**

加载演示文稿后，调用 [Presentation::get_SourceFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_sourceformat/) 以确定其原始格式。该方法也可通过 [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_sourceformat/) 使用。当后续处理依赖于当前实例加载时的格式时，请使用它。

源格式不同于为输出文件选择的 [SaveFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/)。将文件另存为其他格式不会更改现有实例的源格式。

## **读取文件的源格式**

此示例需要一个现有的 `sample.pptx` 文件。它加载该文件并使用 [Presentation::get_SourceFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_sourceformat/) 选择应用程序处理策略，而不是根据文件名。修改输入路径可尝试其他格式。示例会打印所选策略；请将这些消息替换为您的应用逻辑。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **识别受支持的值**

[SourceFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sourceformat/) 枚举区分以下演示文稿格式。下列扩展名为常规扩展名，并非对原始文件名的还原。

| SourceFormat 值 | 扩展名 | 格式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 演示文稿 |
| `Pptx` | `.pptx` | Office Open XML 演示文稿 |
| `Pptm` | `.pptm` | 启用宏的 Office Open XML 演示文稿 |
| `Pps` | `.pps` | PowerPoint 97–2003 幻灯片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 幻灯片放映 |
| `Ppsm` | `.ppsm` | 启用宏的 Office Open XML 幻灯片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 模板 |
| `Potx` | `.potx` | Office Open XML 模板 |
| `Potm` | `.potm` | 启用宏的 Office Open XML 模板 |
| `Odp` | `.odp` | OpenDocument 演示文稿 |
| `Otp` | `.otp` | OpenDocument 演示文稿模板 |
| `Fodp` | `.fodp` | 平面 XML ODF 演示文稿 |
| `Xml` | `.xml` | PowerPoint XML 演示文稿 |

## **读取流的源格式**

此示例需要一个现有的 `sample.pps` 文件。将其字节读取到内存流中模拟没有文件名的输入，例如数据库值或上传的字节数组。[Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 构造函数仅接收流。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT、PPS 和 POT 使用相同的底层二进制格式。通过文件路径加载时，扩展名可以帮助区分幻灯片放映或模板。没有文件名时，老式的 PPS 和 POT 内容可能会报告为 `SourceFormat::Ppt`；上面的 PPS 示例报告 `Ppt`。

如果您的应用必须保留此区分，请单独保留原始文件名或子类型元数据。扩展名对这些老式子类型是有用的提示，但不应作为识别任意演示文稿内容的唯一依据。

## **在加载前后比较检测**

在需要在加载完整演示文稿对象模型之前检查文件时，请使用 [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentationfactory/getpresentationinfo/) 和 [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentationinfo/get_loadformat/)。当实例已经存在时，请使用 [Presentation::get_SourceFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_sourceformat/)。

此示例需要 `sample.pptx`，并在两次检查时均打印 `Pptx`。在生产环境中，请根据处理阶段选择合适的 API；已加载的演示文稿无需再次检查仅为获取其源格式。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

结果使用了不同的枚举类型：[LoadFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadformat/) 和 [SourceFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sourceformat/)。不要通过强制转换数值来比较它们，也不要假设每种格式的检测结果完全相同。PowerPoint XML 在加载前可能报告为 `LoadFormat::Unknown`，加载后报告为 `SourceFormat::Xml`。

## **保持源格式和输出格式分离**

此示例需要 `sample.pptx` 并写入 `converted.odp`。它在保存原始实例前后均打印 `Pptx`。只有从 ODP 输出加载的新实例报告 `Odp`。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

使用 `MakeObject<Presentation>()` 从头创建的演示文稿报告 `SourceFormat::Pptx`。它没有输入文件：这是新创建实例的默认值，并不表示加载了 PPTX 文件。如果区分是创建还是加载实例对您很重要，请单独跟踪此信息。

## **将源格式映射到扩展名**

以下示例需要 `sample.pptx`。它将每个当前支持的 [SourceFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/sourceformat/) 值映射到常规扩展名，而不解析输入文件名。回退机制避免对未识别的值静默分配扩展名。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

此映射不会转换文件或恢复在流加载期间丢失的老式 PPS/POT 子类型。实际保存时，请显式选择 [SaveFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/)，或使用 [在原始格式中保存演示文稿](/slides/zh/cpp/save-presentation/#save-presentations-in-their-original-format) 中展示的转换。

## **通过保存和重新打开验证格式**

此独立示例创建一个演示文稿并在工作目录中写入三个文件，若同名文件已存在则覆盖。它随后分别通过路径和内存流重新打开每个输出。对于 PPTX 和 ODP，两种方式都报告已保存的格式。对于 PPS，路径加载报告 `Pps`，而使用相同字节但无文件名的加载报告 `Ppt`。

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

以下表格总结了具有匹配扩展名的演示文稿的源格式识别情况：

| 已保存的格式 | 从文件路径获取的 SourceFormat | 从无名称流获取的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` 分别对应 | 与文件路径相同 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` 分别对应 | 与文件路径相同 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` 分别对应 | 与文件路径相同 |
| ODP, OTP | `Odp`, `Otp` 分别对应 | 与文件路径相同 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

老式 PPS/POT 内容在无名称流中会标准化为 `Ppt`。此表描述的是格式识别结果，并不保证在转换过程中保留每个演示文稿的所有特性。

## **常见问题**

**将演示文稿从 PPTX 保存为 ODP 时，会改变其源格式吗？**

不会。现有实例仍报告 `Pptx`。从保存的 ODP 文件加载的实例报告 `Odp`。

**流是否始终能够区分传统的演示文稿、幻灯片放映和模板？**

不能。PPT、PPS 和 POT 共享同一二进制格式。如果需要此区分，请单独保留文件名或子类型元数据。

**如果演示文稿已经加载，我应该使用哪个 API？**

读取 [Presentation::get_SourceFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_sourceformat/)。在加载之前进行检查时，请使用 [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentationfactory/getpresentationinfo/)。