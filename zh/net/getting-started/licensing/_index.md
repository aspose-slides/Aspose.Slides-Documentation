---
title: 许可
type: docs
weight: 80
url: /net/licensing/
---

## **评估 Aspose.Slides**

{{% alert color="primary" %}} 

您可以从 [它的 NuGet 下载页面](https://www.nuget.org/packages/Aspose.Slides.NET/) 下载 **Aspose.Slides for NET** 的评估版本。评估版本提供与产品的许可证版本相同的功能。评估包与购买的包相同。评估版本在您添加几行代码后（以应用许可证）即可变为许可证版本。

一旦您对 **Aspose.Slides** 的评估感到满意，您可以 [购买许可证](https://purchase.aspose.com/buy)。我们建议您浏览不同的订阅类型。如果您有任何问题，请联系 Aspose 销售团队。

每个 Aspose 许可证都附带一年期的免费升级订阅，适用于在订阅期间发布的新版本或修复。拥有许可证产品或甚至评估版本的用户可获得免费的无限技术支持。

{{% /alert %}} 

**评估版本限制**

* 虽然 Aspose.Slides 的评估版本（未指定许可证）提供完整的产品功能，但在打开和保存操作时会在文档顶部插入评估水印。 
* 从演示幻灯片中提取文本时，您只能使用一张幻灯片。

{{% alert color="primary" %}} 

要在没有限制的情况下测试 Aspose.Slides，您可以申请 **30 天临时许可证**。有关更多信息，请参见 [如何获取临时许可证](https://purchase.aspose.com/temporary-license) 页面。

{{% /alert %}}

## **Aspose.Slides 中的许可证**
* 评估版本在您购买许可证并添加几行代码（以应用许可证）后变为许可证版本。
* 许可证是一个纯文本 XML 文件，包含产品名称、许可开发人员数量、订阅到期日期等详细信息。
* 许可证文件经过数字签名，因此您必须不修改该文件。即使无意中向文件内容添加一行额外的换行符也会使其无效。
* Aspose.Slides for .NET 通常会在以下位置寻找许可证：
  * 明确路径
  * 包含组件 DLL 的文件夹（包含在 Aspose.Slides 中）
  * 包含调用组件 DLL 的程序集的文件夹（包含在 Aspose.Slides 中）
  * 包含入口程序集（您的 .exe）的文件夹
  * 在调用组件 DLL 的程序集中的嵌入资源（包含在 Aspose.Slides 中）。
* 要避免与评估版本相关的限制，您需要在使用 Aspose.Slides 之前设置许可证。每个应用程序或过程只需设置一次许可证。

{{% alert color="primary" %}} 

您可能想查看 [计量许可证](https://docs.aspose.com/slides/net/metered-licensing/)。

{{% /alert %}} 


## **应用许可证**
许可证可以从 **文件**、**流**或 **嵌入资源** 中加载。 

{{% alert color="primary" %}}

Aspose.Slides 提供 [License](https://reference.aspose.com/slides/net/aspose.slides/license) 类用于许可操作。

{{% /alert %}} 

### **文件**
设置许可证的最简单方法是将许可证文件放置在包含组件 DLL 的同一文件夹中（包含在 Aspose.Slides 中），并仅指定文件名而不带路径。

以下 C# 代码演示了如何设置许可证文件：

``` csharp
// 实例化 License 类 
Aspose.Slides.License license = new Aspose.Slides.License();

// 设置许可证文件路径
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

如果您将许可证文件放置在不同的目录中，当您调用 [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) 方法时，指定的明确路径末尾的许可证文件名必须与您的许可证文件相同。

例如，您可以将许可证文件名更改为 *Aspose.Slides.lic.xml*。然后，在您的代码中，您必须将文件路径（以 *Aspose.Slides.lic.xml* 结尾）传递给 [SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1) 方法。

{{% /alert %}}

### **流**
您可以从流中加载许可证。以下 C# 代码演示了如何从流中应用许可证：

``` csharp
// 实例化 License 类 
Aspose.Slides.License license = new Aspose.Slides.License();

// 通过流设置许可证
license.SetLicense(myStream);
```

### **嵌入资源**
您可以通过将许可证作为嵌入资源添加到调用组件 DLL 的程序集之一中，将许可证与您的应用程序集成（以避免丢失它）。 

以下是如何将许可证文件添加为嵌入资源：

1. 在 Visual Studio 中，以这种方式将许可证（.lic）文件添加到项目：通过 **文件** > **添加现有项** > **添加**。 
2. 在 **解决方案资源管理器** 中选择该文件。
3. 在 **属性** 窗口中，将 **生成操作** 设置为 **嵌入资源**。
4. 要访问嵌入在程序集中的许可证，将许可证文件作为嵌入资源添加到项目中，然后将许可证文件名称传递给 `SetLicense` 方法。 


`License` 类会自动在嵌入资源中查找许可证文件。您不需要调用 Microsoft .NET Framework 中 `System.Reflection.Assembly` 类的 `GetExecutingAssembly` 和 `GetManifestResourceStream` 方法。

以下 C# 代码演示了如何将许可证设置为嵌入资源：

``` csharp
// 实例化 License 类
Aspose.Slides.License license = new Aspose.Slides.License();

// 传递嵌入在程序集中的许可证文件名
license.SetLicense("Aspose.Slides.lic");
```

## **验证许可证**

要检查许可证是否已正确设置，您可以验证它。以下 C# 代码显示了如何验证许可证：

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("许可证有效！");
    Console.Read();
}
```

## **线程安全**

{{% alert title="注意" color="warning" %}} 

[license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) 方法不是线程安全的。如果此方法必须同时从多个线程调用，则您可能希望使用同步原语（如锁定）以避免问题。 

{{% /alert %}}