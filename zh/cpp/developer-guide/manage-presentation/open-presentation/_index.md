---
title: 打开演示文稿 - C++ PowerPoint API
linktitle: 打开演示文稿
type: docs
weight: 20
url: /zh/cpp/open-presentation/
keywords: "打开 PowerPoint, PPTX, PPT, 打开演示文稿, 加载演示文稿, C++, CPP"
description: "在 C++ 中打开或加载演示文稿 PPT, PPTX, ODP"
---

除了从头创建 PowerPoint 演示文稿外，Aspose.Slides 还允许您打开现有演示文稿。加载演示文稿后，您可以获取有关演示文稿的信息，编辑演示文稿（幻灯片上的内容），添加新幻灯片或删除现有幻灯片等。

## 打开演示文稿

要打开现有的演示文稿，您只需实例化 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类并将文件路径（您要打开的演示文稿的路径）传递给其构造函数。

以下 C++ 代码演示了如何打开演示文稿并找出其中包含的幻灯片数量：

```c++
// 文档目录的路径。
String dataDir = u"";

// 实例化 Presentation 类并将文件路径传递给其构造函数
auto pres = System::MakeObject<Presentation>(dataDir + u"OpenPresentation.pptx");

// 打印演示文稿中幻灯片的总数
Console::WriteLine(Convert::ToString(pres->get_Slides()->get_Count()));
```

## **打开受密码保护的演示文稿**

当您需要打开一个受密码保护的演示文稿时，您可以通过 [get_Password()](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_password/) 属性（来自 [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) 类）传递密码，以解密演示文稿并加载它。以下 C++ 代码演示了该操作：

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
// 对解密后的演示文稿执行一些操作
```

## 打开大型演示文稿

Aspose.Slides 提供选项（特别是 [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) 属性）在 [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) 类下，允许您加载大型演示文稿。

以下 C++ 代码演示了加载一个大型演示文稿（例如 2GB 大小）的操作：

```c++
String pathToVeryLargePresentationFile = u"veryLargePresentation.pptx";

{
    SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    // 选择 KeepLocked 行为 - "veryLargePresentation.pptx" 将在演示文稿实例的生命周期内被锁定，
    // 但我们不需要将其加载到内存或复制到临时文件
    loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

    auto pres = System::MakeObject<Presentation>(pathToVeryLargePresentationFile, loadOptions);

    // 大型演示文稿已加载并可以使用，但内存消耗仍然很低。

    // 对演示文稿进行更改。
    pres->get_Slides()->idx_get(0)->set_Name(u"非常大的演示文稿");

    // 演示文稿将保存到其他文件。该操作期间内存消耗保持较低
    pres->Save(u"veryLargePresentation-copy.pptx", SaveFormat::Pptx);

    // 不能这样做！由于文件在 pres 对象存在时被锁定，将抛出 IO 异常
    File::Delete(pathToVeryLargePresentationFile);
}

// 在这里可以这样做。源文件不被 pres 对象锁定
File::Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="信息" %}}

为了绕过与流交互时的一些限制，Aspose.Slides 可能会复制流的内容。通过流加载大型演示文稿将导致演示文稿内容的复制并造成加载缓慢。因此，当您打算加载大型演示文稿时，我们强烈建议您使用演示文稿文件路径，而不是其流。

当您想要创建包含大型对象（视频、音频、大图像等）的演示文稿时，可以使用 [Blob 私册](https://docs.aspose.com/slides/cpp/manage-blob/) 来减少内存消耗。

{{%/alert %}} 

## 加载演示文稿

Aspose.Slides 提供 [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) 具有单个方法，使您能够管理外部资源。以下 C++ 代码演示了如何使用 `IResourceLoadingCallback` 接口：

```c++
// 文档目录的路径。
System::String dataDir = GetDataPath();

auto opts = System::MakeObject<LoadOptions>();
opts->set_ResourceLoadingCallback(System::MakeObject<ImageLoadingHandler>(dataDir));
auto presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", opts);
```

```c++
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ImageLoadingHandler(String dataDir)
        : m_dataDir(dataDir)
    {
    }

    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                System::ArrayPtr<uint8_t> imageBytes = File::ReadAllBytes(Path::Combine(m_dataDir, u"aspose-logo.jpg"));
                args->SetData(imageBytes);
                return ResourceLoadingAction::UserProvided;
            }
            catch (System::Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }

        if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // 设置替代网址
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // 跳过所有其他图像
        return ResourceLoadingAction::Skip;
    }
    
private:
    String m_dataDir;
};
```

<h2>打开和保存演示文稿</h2>

<a name="cplusplus-open-save-presentation"><strong>步骤：在 C++ 中打开和保存演示文稿</strong></a>

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例并传递您要打开的文件。

2. 保存演示文稿。

   ```c++
   	const String outPath = u"../out/SaveToFile_out.ppt";
   	
   	SharedPtr<Presentation> pres = MakeObject<Presentation>();
   
   	// pres->get_ProtectionManager()->Encrypt(u"pass");
   	// ...在这里执行一些工作..
   
   	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
   ```