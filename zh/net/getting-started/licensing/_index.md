---
title: 授权
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
description: "在 Aspose.Slides for .NET 中应用、管理和排除许可证问题。通过我们的分步授权指南，确保持续访问全部功能。"
---

## **评估 Aspose.Slides**

{{% alert color="primary" %}} 
您可以从[其 NuGet 下载页面](https://www.nuget.org/packages/Aspose.Slides.NET/)下载 **Aspose.Slides for NET** 的评估版。评估版提供与授权版本相同的功能，评估包与购买的包相同。只需添加几行代码（以应用授权），评估版即可转为授权版。

在您满意 **Aspose.Slides** 的评估后，可以[购买授权](https://purchase.aspose.com/buy)。建议您了解不同的订阅类型。如有疑问，请联系 Aspose 销售团队。

每个 Aspose 授权都包含一年免费升级订阅，可在订阅期间免费获取新版本或修复。持有授权产品或评估版的用户均可获得免费且无限的技术支持。
{{% /alert %}} 

**评估版限制**

* 虽然 Aspose.Slides 评估版（未指定授权）提供完整的产品功能，但在打开和保存操作时会在文档顶部插入评估水印。 
* 在从演示文稿幻灯片中提取文本时，仅限提取一张幻灯片。

{{% alert color="primary" %}} 
要在不受限制的情况下测试 Aspose.Slides，您可以申请 **30 天临时授权**。详情请参阅[获取临时授权](https://purchase.aspose.com/temporary-license)页面。
{{% /alert %}}

## **Aspose.Slides 的授权**
* 评估版在您购买授权并添加几行代码后即可转为授权版。
* 授权是一个纯文本 XML 文件，包含产品名称、授权的开发人数、订阅到期日期等信息。 
* 授权文件已数字签名，切勿修改文件。即使无意添加额外的换行也会导致授权失效。
* Aspose.Slides for .NET 通常会在以下位置查找授权：
  * 显式路径
  * 组件 DLL 所在的文件夹（包含在 Aspose.Slides）
  * 调用组件 DLL 的程序集所在的文件夹（包含在 Aspose.Slides）
  * 入口程序集所在的文件夹（您的 .exe）
  * 调用组件 DLL 的程序集中的嵌入资源（包含在 Aspose.Slides）
* 为避免评估版的限制，您需要在使用 Aspose.Slides 前设置授权。每个应用程序或进程只需设置一次授权。

{{% alert color="primary" %}} 
您可能想查看[计量授权](https://docs.aspose.com/slides/net/metered-licensing/)。
{{% /alert %}} 


## **应用授权**
授权可以从**文件**、**流**或**嵌入资源**加载。 

{{% alert color="primary" %}}
Aspose.Slides 提供用于授权操作的[License](https://reference.aspose.com/slides/net/aspose.slides/license)类。
{{% /alert %}} 

{{% alert color="warning" %}} 
新授权仅在 21.4 版或更高版本中可激活 Aspose.Slides。更早的版本使用不同的授权系统，无法识别这些授权。
{{% /alert %}}

### **文件**
设置授权的最简方法是将授权文件放置在组件 DLL 所在的同一文件夹（包含在 Aspose.Slides）中，并仅指定文件名而不包含路径。

以下 C# 代码演示如何设置授权文件：
``` csharp
// 实例化 License 类 
Aspose.Slides.License license = new Aspose.Slides.License();

// 设置许可证文件路径
license.SetLicense("Aspose.Slides.lic");
```


{{% alert color="warning" %}} 
如果将授权文件放在其他目录，调用[SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1)方法时，显式指定的文件名必须与实际授权文件名完全一致。

例如，您可以将授权文件名改为 *Aspose.Slides.lic.xml*。此时在代码中必须将路径（以 *Aspose.Slides.lic.xml* 结尾）传递给[SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1)方法。
{{% /alert %}}

### **流**
您可以从流加载授权。以下 C# 代码演示如何从流应用授权：
``` csharp
// 实例化 License 类 
Aspose.Slides.License license = new Aspose.Slides.License();

// 通过流设置许可证
license.SetLicense(myStream);
```


### **嵌入资源**
您可以将授权文件作为嵌入资源添加到调用组件 DLL 的程序集之一，以防止授权文件丢失。 

添加授权文件为嵌入资源的步骤：

1. 在 Visual Studio 中，通过 **File** > **Add Existing Item** > **Add** 将授权（.lic）文件添加到项目。 
2. 在 **Solution Explorer** 中选中该文件。 
3. 在 **Properties** 窗口，将 **Build Action** 设置为 **Embedded Resource**。 
4. 要访问嵌入在程序集中的授权，直接将授权文件名传递给 `SetLicense` 方法。

`License` 类会自动在嵌入资源中查找授权文件。无需在 Microsoft .NET Framework 中调用 `System.Reflection.Assembly` 的 `GetExecutingAssembly` 和 `GetManifestResourceStream` 方法。

以下 C# 代码演示如何将授权设置为嵌入资源：
``` csharp
// 实例化 License 类
Aspose.Slides.License license = new Aspose.Slides.License();

// 传递嵌入在程序集中的许可证文件名
license.SetLicense("Aspose.Slides.lic");
```


## **验证授权**

要检查授权是否正确设置，可以进行验证。以下 C# 代码演示如何验证授权：
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

{{% alert title="Note" color="warning" %}} 
`license.SetLicense` 方法不是线程安全的。如果该方法需要在多个线程中同时调用，建议使用同步原语（如 lock）以避免问题。 
{{% /alert %}}

## **FAQ**

**我可以在完全离线的环境（无互联网访问）中应用授权吗？**

可以。授权验证在本地使用授权文件完成；不需要互联网连接。

**一年订阅到期后会怎样？库会停止工作吗？**

不会。授权是永久性的：您可以继续使用订阅结束日期之前发布的版本；只是不续订的话无法使用更新的版本。