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
description: "使用 Aspose.Slides for C++ 轻松打开 PowerPoint（.pptx、.ppt）和 OpenDocument（.odp）演示文稿——快速、可靠、功能齐全。"
---

## **概述**

除了从头创建 PowerPoint 演示文稿外，Aspose.Slides 还可以打开已有的演示文稿。加载演示文稿后，您可以获取其信息，编辑幻灯片内容，添加新幻灯片，删除已有幻灯片等。

## **打开演示文稿**

要打开已有的演示文稿，实例化 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类并将文件路径传递给其构造函数。

以下 C++ 示例演示如何打开演示文稿并获取幻灯片计数：
```cpp
// 实例化 Presentation 类并将文件路径传递给其构造函数。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// 打印演示文稿中的幻灯片总数。
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```


## **打开受密码保护的演示文稿**

当需要打开受密码保护的演示文稿时，通过 [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) 类的 [set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) 方法传入密码，以解密并加载它。以下 C++ 代码演示此操作：
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// 对已解密的演示文稿执行操作。

presentation->Dispose();
```


## **打开大型演示文稿**

Aspose.Slides 提供选项 —— 特别是 [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) 类中的 [get_BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) 方法来帮助您加载大型演示文稿。

以下 C++ 代码演示加载大型演示文稿（例如 2 GB）：
```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// 选择 KeepLocked 行为——演示文稿文件将在整个生命周期内保持锁定
// Presentation 实例，但无需将其加载到内存或复制到临时文件。
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// 大型演示文稿已加载，可使用，同时内存消耗保持较低.

// 对演示文稿进行修改。
presentation->get_Slide(0)->set_Name(u"Large presentation");

// 将演示文稿保存到另一个文件。此操作期间内存消耗保持较低。
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// 不要这么做！因为文件被锁定，直到演示文稿对象被释放之前，会抛出 I/O 异常。
File::Delete(filePath);

presentation->Dispose();

// 此处可以安全删除。源文件已不再被演示文稿对象锁定。
File::Delete(filePath);
```


{{% alert color="info" title="信息" %}}
为了解决使用流时的某些限制，Aspose.Slides 可能会复制流的内容。从流加载大型演示文稿会导致演示文稿被复制，从而降低加载速度。因此，在需要加载大型演示文稿时，我们强烈建议使用演示文稿文件路径而不是流。

在创建包含大型对象（视频、音频、高分辨率图像等）的演示文稿时，您可以使用 [BLOB 管理](/slides/zh/cpp/manage-blob/) 来降低内存消耗。
{{%/alert %}}

## **控制外部资源**

Aspose.Slides 提供 [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) 接口，允许您管理外部资源。以下 C++ 代码展示如何使用 `IResourceLoadingCallback` 接口：
```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // 加载替代图像。
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // 设置替代 URL。
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // 跳过所有其他图像。
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```


## **加载不包含嵌入式二进制对象的演示文稿**

PowerPoint 演示文稿可能包含以下类型的嵌入式二进制对象：

- VBA 项目（可通过 [IPresentation::get_VbaProject](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_vbaproject/) 访问）；
- OLE 对象嵌入数据（可通过 [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) 访问）；
- ActiveX 控件二进制数据（可通过 [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) 访问）。

使用 [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) 方法，您可以在加载演示文稿时剔除所有嵌入式二进制对象。

此方法有助于移除潜在的恶意二进制内容。以下 C++ 代码演示如何在不加载任何嵌入式二进制内容的情况下加载演示文稿：
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Perform operations on the presentation.

presentation->Dispose();
```


## **常见问题**

**如何判断文件已损坏且无法打开？**

在加载期间会抛出解析/格式验证异常。此类错误通常提到 ZIP 结构无效或 PowerPoint 记录损坏。

**打开时缺少必需的字体会怎样？**

文件仍会打开，但后续的 [渲染/导出](/slides/zh/cpp/convert-presentation/) 可能会替换字体。请在运行时环境中 [配置字体替换](/slides/zh/cpp/font-substitution/) 或 [添加所需字体](/slides/zh/cpp/custom-font/)。

**打开时嵌入的媒体（视频/音频）会怎样？**

它们会作为演示文稿资源可用。如果媒体通过外部路径引用，请确保这些路径在您的环境中可访问；否则在 [渲染/导出](/slides/zh/cpp/convert-presentation/) 时可能会省略这些媒体。