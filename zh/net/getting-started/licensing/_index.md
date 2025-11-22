---
title: 授权
type: docs
weight: 80
url: /zh/net/licensing/
---

## **评估 Aspose.Slides**

{{% alert color="primary" %}} 

您可以从[其NuGet下载页面](https://www.nuget.org/packages/Aspose.Slides.NET/)下载 **Aspose.Slides for NET** 的评估版。评估版提供与产品授权版相同的功能。评估包与购买的包相同。只需添加几行代码（以应用许可证），评估版即可转为授权版。

当您对 **Aspose.Slides** 的评估满意后，可以[购买许可证](https://purchase.aspose.com/buy)。我们建议您了解不同的订阅类型。如有疑问，请联系 Aspose 销售团队。

每个 Aspose 许可证均附带一年订阅，可免费升级至订阅期内发布的新版本或修复。持有授权产品或甚至评估版的用户均可获得免费且无限制的技术支持。

{{% /alert %}} 

**评估版限制**

* 虽然 Aspose.Slides 评估版（未指定许可证）提供完整的产品功能，但在打开和保存操作时会在文档顶部插入评估水印。
* 从演示文稿幻灯片提取文本时仅限于一张幻灯片。

{{% alert color="primary" %}} 

要在无任何限制的情况下测试 Aspose.Slides，您可以申请 **30 天临时许可证**。有关更多信息，请参阅[获取临时许可证方法](https://purchase.aspose.com/temporary-license)页面。

{{% /alert %}}

## **Aspose.Slides 的授权**
* 购买许可证并在代码中添加几行（以应用许可证）后，评估版将转为授权版。
* 许可证是一个纯文本 XML 文件，包含产品名称、授权开发者数量、订阅到期日期等信息。
* 许可证文件已数字签名，必须不要修改文件。即使无意中在文件内容中添加额外的换行也会导致失效。
* Aspose.Slides for .NET 通常会在以下位置查找许可证：
  * 显式路径
  * 组件 DLL 所在文件夹（包含在 Aspose.Slides 中）
  * 调用组件 DLL 的程序集所在文件夹（包含在 Aspose.Slides 中）
  * 入口程序集所在文件夹（您的 .exe）
  * 调用组件 DLL 的程序集中的嵌入资源（包含在 Aspose.Slides 中）。
* 为避免评估版的限制，需要在使用 Aspose.Slides 之前设置许可证。每个应用程序或进程只需设置一次许可证。

{{% alert color="primary" %}} 

您可能想查看[计量授权](https://docs.aspose.com/slides/net/metered-licensing/)。

{{% /alert %}} 

## **应用许可证**
许可证可以从 **文件**、**流**或**嵌入资源**加载。

{{% alert color="primary" %}}

Aspose.Slides 提供用于授权操作的[License](https://reference.aspose.com/slides/net/aspose.slides/license)类。

{{% /alert %}} 

{{% alert color="warning" %}} 

新许可证只能在 21.4 或更高版本的 Aspose.Slides 中激活。较早版本使用不同的授权系统，无法识别这些许可证。

{{% /alert %}}

### **文件**
设置许可证的最简单方法是将许可证文件放在包含组件 DLL 的同一文件夹（包含在 Aspose.Slides 中），并只指定文件名而不带路径。

以下 C# 代码演示如何设置许可证文件：
``` csharp
// 实例化 License 类 
Aspose.Slides.License license = new Aspose.Slides.License();

// 设置许可证文件路径
license.SetLicense("Aspose.Slides.lic");
```


{{% alert color="warning" %}} 

如果将许可证文件放在其他目录，在调用[SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1)方法时，指定的显式路径结尾的许可证文件名必须与实际的许可证文件名相同。

例如，您可以将许可证文件名更改为 *Aspose.Slides.lic.xml*。然后，在代码中，需要将指向该文件（以 *Aspose.Slides.lic.xml* 结尾）的路径传递给[SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/#setlicense_1)方法。

{{% /alert %}}

### **流**
您可以从流中加载许可证。以下 C# 代码演示如何从流应用许可证：
``` csharp
// 实例化 License 类 
Aspose.Slides.License license = new Aspose.Slides.License();

// 通过流设置许可证
license.SetLicense(myStream);
```


### **嵌入资源**
您可以将许可证作为嵌入资源添加到调用组件 DLL 的任一程序集（包含在 Aspose.Slides 中），从而随应用程序一起打包（防止丢失）。

1. 在 Visual Studio 中，以以下方式将许可证（.lic）文件添加到项目：依次点击 **文件** > **添加现有项** > **添加**。 
2. 在 **解决方案资源管理器** 中选中该文件。 
3. 在 **属性** 窗口，将 **生成操作** 设置为 **嵌入的资源**。 
4. 为访问嵌入在程序集中的许可证，需将许可证文件作为嵌入资源添加到项目中，然后将许可证文件名传递给 `SetLicense` 方法。 

`License` 类会自动在嵌入资源中查找许可证文件。无需在 Microsoft .NET Framework 中调用 `System.Reflection.Assembly` 类的 `GetExecutingAssembly` 和 `GetManifestResourceStream` 方法。

以下 C# 代码演示如何将许可证设置为嵌入资源：
``` csharp
// 实例化 License 类
Aspose.Slides.License license = new Aspose.Slides.License();

// 将嵌入在程序集中的许可证文件名传递
license.SetLicense("Aspose.Slides.lic");
```


## **验证许可证**

要检查许可证是否已正确设置，可以对其进行验证。以下 C# 代码演示如何验证许可证：
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

[license.SetLicense](https://reference.aspose.com/slides/net/aspose.slides/license/setlicense/) 方法不是线程安全的。如果需要在多个线程中同时调用此方法，建议使用同步原语（如 lock）以避免问题。 

{{% /alert %}}

## **常见问题**

**我可以在完全离线的环境（无互联网访问）中应用许可证吗？**

可以。许可证验证在本地使用许可证文件完成，无需互联网连接。

**一年订阅到期后会怎样？库会停止工作吗？**

不会。许可证是永久有效的：您可以继续使用在订阅结束日期之前发布的版本，只是如果不续订，将无法使用更新的版本。