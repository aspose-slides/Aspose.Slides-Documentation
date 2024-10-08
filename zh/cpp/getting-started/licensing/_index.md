---
title: 许可证
type: docs
weight: 120
url: /zh/cpp/licensing/
---

## **评估 Aspose.Slides**

{{% alert color="primary" %}} 

您可以从 [其 NuGet 下载页面](https://www.nuget.org/packages/Aspose.Slides.CPP/) 下载 **Aspose.Slides for C++** 的评估版本。评估版本提供与产品的许可证版本相同的功能。评估包与购买的包是一样的。评估版本在您添加几行代码（以应用许可证）后，就会变为有许可证的版本。

一旦您对 **Aspose.Slides** 的评估结果感到满意，您可以 [购买许可证](https://purchase.aspose.com/buy)。我们推荐您查看不同的订阅类型。如果您有任何问题，请与 Aspose 销售团队联系。

每个 Aspose 许可证都附带一年的订阅，用于免费升级到订阅期内发布的新版本或修复。拥有许可证产品或甚至评估版本的用户可以获得免费的无限技术支持。

{{% /alert %}} 

**评估版本限制**

* 虽然 Aspose.Slides 评估版本（未指定许可证）提供全部产品功能，但在打开和保存操作时，会在文档顶部插入评估水印。 
* 当从演示文稿幻灯片中提取文本时，您只能获取一张幻灯片。

{{% alert color="primary" %}} 

要在不受限制的情况下测试 Aspose.Slides，您可以申请 **30 天临时许可证**。有关更多信息，请参见 [如何获取临时许可证](https://purchase.aspose.com/temporary-license) 页面。

{{% /alert %}}

## **Aspose.Slides 中的许可证**

* 在您购买许可证并添加几行代码（以应用许可证）后，评估版本会变为有许可证的版本。
* 许可证是一个纯文本的 XML 文件，包含产品名称、授权的开发人员数量、订阅到期日期等详细信息。 
* 许可证文件是数字签名的，因此您不能修改该文件。即使是无意中向文件内容添加了额外的换行符，也会使其失效。
* Aspose.Slides for C++ 通常会在以下位置查找许可证：
  * 显式路径
  * 包含组件 DLL 的文件夹（包含在 Aspose.Slides 中）
  * 包含调用组件 DLL 的程序集的文件夹（包含在 Aspose.Slides 中）
* 为了避免与评估版本相关的限制，您需要在使用 Aspose.Slides 之前设置许可证。每个应用程序或过程只需设置一次许可证。

## **应用许可证**

许可证可以从 **文件**、**流**或 **嵌入资源** 加载。 

{{% alert color="primary" %}}

Aspose.Slides 提供 [License](https://reference.aspose.com/slides/cpp/class/aspose.slides.license/) 类来进行许可证操作。

{{% /alert %}} 

### **文件**

设置许可证的最简单方法是将许可证文件放在与组件的 DLL （包含在 Aspose.Slides 中）相同的文件夹中，并指定文件名而不带路径。

以下 C++ 代码示范了如何设置许可证文件：

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

lic->SetLicense(L"Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

如果您将许可证文件放在不同的目录中，则在调用 [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67) 方法时，指定的显式路径末尾的许可证文件名必须与您的许可证文件相同。

例如，您可以将许可证文件名更改为 *Aspose.Slides.lic.xml*。然后，在您的代码中，您必须将文件的路径（以 *Aspose.Slides.lic.xml* 结束）传递给 [License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67) 方法。

{{% /alert %}}

### **流**

您可以从流中加载许可证。以下 C++ 代码示范了如何从流中应用许可证：

```c++
SharedPtr<Aspose::Slides::License> lic = MakeObject<Aspose::Slides::License>();

System::SharedPtr<System::IO::FileStream> stream= System::IO::File::OpenRead(L"Aspose.Slides.lic");

lic->SetLicense(stream); 
```

## **验证许可证**

要检查许可证是否设置正确，您可以验证它。以下 C++ 代码示范了如何验证许可证：

```c++
System::SharedPtr<Aspose::Slides::License> license = System::MakeObject<Aspose::Slides::License>();
license->SetLicense(u"Aspose.Slides.lic");
if (license->IsLicensed())
{
    System::Console::WriteLine(u"许可证有效！");
    System::Console::Read();
}
```

## **线程安全性**

{{% alert title="注意" color="warning" %}} 

[License::SetLicense()](https://reference.aspose.com/slides/cpp/class/aspose.slides.license#a44102d1d52a5e45643345448b1814a67) 方法不是线程安全的。如果此方法需要在多个线程中同时调用，您可能需要使用同步原语（比如锁）来避免问题。 

{{% /alert %}}