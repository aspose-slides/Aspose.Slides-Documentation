---
title: 在 C++ 中打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /zh/cpp/open-presentation/
keywords:
- 打开 PowerPoint
- 打开 OpenDocument
- 打开演示文稿
- 打开 PPTX
- 打开 PPT
- 打开 ODP
- 加载演示文稿
- 加载 PPTX
- 加载 PPT
- 加载 ODP
- 受保护的演示文稿
- 大型演示文稿
- 外部资源
- 二进制对象
- C++
- Aspose.Slides
description: "了解如何在 C++ 中使用 Aspose.Slides for C++ 打开 PowerPoint 和 OpenDocument 演示文稿，提供打开密码，控制资源加载，并减少内存使用。"
---
## **介绍**

[Aspose.Slides for C++](https://products.aspose.com/slides/zh/cpp/) 可以从文件和流中加载 PowerPoint 和 OpenDocument 演示文稿。加载演示文稿后，您可以检查其结构、编辑幻灯片、管理资源，并以原始格式或其他受支持的格式保存。

可以通过 [LoadOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/) 类自定义加载行为。例如，您可以提供打开密码、将大型二进制对象保留在内存之外、控制外部资源或省略嵌入的二进制数据。

## **打开演示文稿**

要打开已有的演示文稿，请将其文件路径传递给 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 构造函数。使用完毕后请释放演示文稿，以便及时关闭文件句柄、释放临时数据和其他资源。

下面的 C++ 示例演示了如何打开演示文稿并获取幻灯片数量：

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **打开受密码保护的演示文稿**

打开密码会对演示文稿内容进行加密。要加载完整的演示文稿，请将正确的密码传递给 [LoadOptions::set_Password](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_password/)，并将该选项传递给 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 构造函数。若密码缺失或不正确，加载将失败。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

有关密码检测、验证和加密工作流，请参阅[密码保护演示文稿](/slides/zh/cpp/password-protected-presentation/)。如果加密的演示文稿在保存时刻意保留了公共文档属性，则这些属性可以在不提供密码的情况下读取；请参阅[管理演示文稿属性](/slides/zh/cpp/presentation-properties/)。

## **打开大型演示文稿**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) 控制 Aspose.Slides 如何处理图像、音频和视频等二进制大对象。您可以保持源文件锁定、允许使用临时文件，并限制保留在内存中的 BLOB 数据量。

下面的 C++ 代码演示了加载大型演示文稿（例如 2 GB）：

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

使用 `PresentationLockingBehavior::KeepLocked` 时，源文件会保持锁定状态，直至 `Presentation` 对象被释放。对象存活期间，请勿移动、覆盖或删除源文件。

Aspose.Slides 可能在加载时复制输入流的内容。对于大型演示文稿，文件路径通常比流更高效。有关更多存储和内存管理选项，请参阅[管理 BLOB](/slides/zh/cpp/manage-blob/)。

{{% /alert %}}

## **控制外部资源**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) 接受一个 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iresourceloadingcallback/) 实现。回调可以提供替代数据、重定向资源、使用默认加载器，或跳过该资源。当演示文稿包含必须根据应用程序特定安全或存储规则解析的外部图像时，此功能非常有用。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **加载不带嵌入二进制对象的演示文稿**

演示文稿可能包含应用程序不需要或不想保留的嵌入二进制数据。示例包括：

- VBA 项目，可通过 [IPresentation::get_VbaProject](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_vbaproject/) 获取；
- 嵌入的 OLE 数据，可通过 [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) 获取；
- ActiveX 控件数据，可通过 [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) 获取。

将 `true` 传递给 [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) 可在加载时删除这些二进制数据。将加载后的演示文稿保存，以保留已清理的结果。

此选项可降低意外嵌入负载的风险，但它并非完整的恶意软件检测或内容清理系统。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **常见问题**

**如何判断文件已损坏且无法打开？**

Aspose.Slides 在加载期间会抛出解析或格式异常。请将此类失败与密码错误的错误分开处理，以便应用程序能够准确报告具体原因。

**如果缺少必需的字体会怎样？**

演示文稿仍可加载，但渲染和导出时可能会替换字体。您可以[配置字体替换](/slides/zh/cpp/font-substitution/)或[提供自定义字体](/slides/zh/cpp/custom-font/)以使输出更可预测。

**加载演示文稿时是否也会加载其嵌入的媒体？**

嵌入的音频和视频会通过演示文稿对象模型提供。外部资源会依据已配置的资源加载行为进行解析；如果无法访问其位置，则可能不可用。