---
title: 许可
type: docs
weight: 80
url: /zh/net/licensing/
keywords:
- 许可证
- 临时许可证
- 设置许可证
- 使用许可证
- 验证许可证
- 许可证文件
- 评估版
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中应用、管理和排除许可证问题。通过我们的分步授权指南，确保持续访问完整功能。"
---
## **概述**

Aspose.Slides 可以在评估模式或使用有效许可证的情况下使用。评估版提供与授权版相同的功能，但会在每个演示文稿保存的每张幻灯片上添加评估水印，并截断代码从演示文稿读取的文本。

本文说明了 Aspose.Slides 中的许可证机制以及在使用库之前如何应用许可证。可以使用 `License` 类从文件、流或嵌入式资源加载许可证。本文还展示了如何验证许可证是否已正确应用。

## **评估 Aspose.Slides**

{{% alert color="info" title="Note" %}}

您可以从[其 NuGet 下载页面](https://www.nuget.org/packages/Aspose.Slides.NET/)下载 **Aspose.Slides for .NET** 的评估版本。评估版提供与产品授权版相同的功能。评估包与购买的包相同。只需在代码中添加几行（以应用许可证），评估版即可转为授权版。

在您对 **Aspose.Slides** 的评估满意后，可以[购买许可证](https://purchase.aspose.com/pricing/slides/zh/net/)。我们建议您了解不同的订阅类型。如有疑问，请联系 Aspose 销售团队。

每个 Aspose 许可证都包含一年免费升级订阅，期间可获取新版本或补丁。拥有授权产品或甚至评估版的用户均可获得免费且无限制的技术支持。

{{% /alert %}} 

**评估版限制**

* 未指定许可证的评估版提供完整的产品功能，但会在每个演示文稿保存的每张幻灯片上添加评估水印文本框。
* 代码从演示文稿读取的文本会被截断为前几个字符，并附加评估限制的通知。代码写入的文本会完整保存。

{{% alert color="info" title="Note" %}}

要在无限制的情况下测试 Aspose.Slides，您可以申请 **30 天临时许可证**。请参阅[获取临时许可证](https://purchase.aspose.com/temporary-license)页面了解更多信息。

{{% /alert %}}

## **Aspose.Slides 中的许可证**
* 评估版在购买许可证并在代码中添加几行（以应用许可证）后即可转为授权版。
* 许可证是一个纯文本 XML 文件，包含产品名称、授权开发人员数量、订阅到期日期等细节。
* 许可证文件已数字签名，禁止修改。即使不小心在文件内容中添加额外的换行也会导致失效。
* Aspose.Slides for .NET 通常会在以下位置查找许可证：
  * 明确指定的路径
  * 包含组件 DLL 的文件夹（在 Aspose.Slides 中）
  * 调用组件 DLL 的程序集所在的文件夹（在 Aspose.Slides 中）
  * 主入口程序集的文件夹（您的 .exe 所在目录）
  * 调用组件 DLL 的程序集中的嵌入式资源（在 Aspose.Slides 中）
* 为避免评估版的限制，您需要在使用 Aspose.Slides 前设置许可证。每个应用程序或进程只需设置一次许可证。

{{% alert color="info" title="Note" %}}

您可能想查看[计量授权](/slides/zh/net/metered-licensing/)。

{{% /alert %}} 


## **应用许可证**
许可证可以从**文件**、**流**或**嵌入式资源**加载。

{{% alert color="info" title="Note" %}}

Aspose.Slides 提供用于授权操作的[License](https://reference.aspose.com/slides/zh/net/aspose.slides/license)类。

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

新许可证仅在 21.4 及更高版本的 Aspose.Slides 中有效。早期版本使用不同的授权系统，无法识别这些许可证。

{{% /alert %}}

### **文件**
设置许可证的最简单方法是将许可证文件放在包含组件 DLL 的同一文件夹（在 Aspose.Slides 中），并仅指定文件名而不带路径。

以下 C# 代码演示了如何设置许可证文件：

``` csharp
// 实例化 License 类
Aspose.Slides.License license = new Aspose.Slides.License();

// 设置许可证文件路径
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Warning" %}}

如果将许可证文件放在其他目录中，调用[SetLicense](https://reference.aspose.com/slides/zh/net/aspose.slides/license/setlicense/#setlicense_1)方法时，指定路径末尾的许可证文件名必须与实际许可证文件名完全相同。

例如，您可以将许可证文件名改为 *Aspose.Slides.lic.xml*。此时，在代码中必须将路径（以 *Aspose.Slides.lic.xml* 结尾）传递给[SetLicense](https://reference.aspose.com/slides/zh/net/aspose.slides/license/setlicense/#setlicense_1)方法。

{{% /alert %}}

### **流**
您可以从流中加载许可证。以下 C# 代码演示了如何从流中应用许可证：

``` csharp
// 实例化 License 类
Aspose.Slides.License license = new Aspose.Slides.License();

// 以流的方式打开许可证文件
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// 通过流设置许可证
license.SetLicense(licenseStream);
```

### **嵌入式资源**
您可以将许可证打包到应用程序中（避免丢失），方法是将许可证添加为调用组件 DLL 的程序集的嵌入式资源（在 Aspose.Slides 中）。

以下步骤展示了如何将许可证文件添加为嵌入式资源：

1. 在 Visual Studio 中，通过 **文件 > 添加现有项 > 添加** 将许可证（.lic）文件添加到项目。 
2. 在 **解决方案资源管理器** 中选中该文件。 
3. 在 **属性** 窗口中，将 **生成操作** 设置为 **嵌入的资源**。 
4. 为访问嵌入在程序集中的许可证，需将许可证文件添加为嵌入式资源，然后将许可证文件名传递给 `SetLicense` 方法。 

`License` 类会自动在嵌入式资源中查找许可证文件。无需在 Microsoft .NET Framework 中调用 `System.Reflection.Assembly` 类的 `GetExecutingAssembly` 和 `GetManifestResourceStream` 方法。

以下 C# 代码演示了如何将许可证设置为嵌入式资源：

``` csharp
// 实例化 License 类
Aspose.Slides.License license = new Aspose.Slides.License();

// 传递嵌入程序集中的许可证文件名
license.SetLicense("Aspose.Slides.lic");
```

## **验证许可证**

要检查许可证是否已正确设置，可以对其进行验证。以下 C# 代码演示了如何验证许可证：

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **线程安全**

{{% alert color="warning" title="Warning" %}}

`license.SetLicense` 方法不是线程安全的。如果需要在多个线程中同时调用此方法，建议使用同步原语（如 lock）来避免问题。

{{% /alert %}}

## **常见问题解答**

### 能否在完全离线的环境（无互联网访问）下应用许可证？

可以。许可证验证在本地使用许可证文件完成，无需互联网连接。

### 一年订阅到期后会怎样？库会停止工作吗？

不会。许可证是永久性的：您可以继续使用订阅结束日期之前发布的版本，只是如果不续订，将无法使用更高版本的发布。