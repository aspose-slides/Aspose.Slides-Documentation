---
title: 授权
type: docs
weight: 120
url: /zh/cpp/licensing/
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
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中应用、管理和排除许可证问题。通过我们的分步授权指南，确保持续访问所有功能。"
---

## **评估 Aspose.Slides**

{{% alert color="primary" %}} 

您可以从[其 NuGet 下载页面](https://www.nuget.org/packages/Aspose.Slides.CPP/)下载 **Aspose.Slides for C++** 的评估版。评估版提供与正式授权产品相同的功能。事实上，评估包与购买的版本完全相同——只要在代码中添加几行代码应用许可证，它就会变为授权状态。

在您对 **Aspose.Slides** 的评估满意后，您可以[购买许可证](https://purchase.aspose.com/buy)。我们建议您查看可用的订阅类型。如有任何问题，请随时联系 Aspose 销售团队。

每个 Aspose 许可证均包含一年免费升级订阅，期间的新版和错误修复均可免费获取。无论是授权版还是评估版，您都可以获得免费且无限制的技术支持。

{{% /alert %}} 

**评估版本限制**

* 当未应用许可证时，Aspose.Slides 评估版提供完整的产品功能，但在打开和保存文档时会在文档顶部插入评估水印。
* 使用评估版时，文本提取仅限于单个幻灯片。

{{% alert color="primary" %}} 

如需在无功能限制的情况下测试 Aspose.Slides，您可以申请**30 天临时许可证**。更多信息请参阅[获取临时许可证方法](https://purchase.aspose.com/temporary-license)页面。

{{% /alert %}}

## **Aspose.Slides 的授权方式**

* 评估版在您购买并通过添加少量代码应用许可证后即可转为授权版。
* 许可证是一个纯文本 XML 文件，内含产品名称、授权开发人员数量、订阅到期日期等信息。
* 许可证文件经过数字签名，禁止任何修改。即使是意外的换行也会使文件失效。
* Aspose.Slides for C++ 通常会在以下位置查找许可证文件：
  * 代码中显式指定的路径
  * 包含组件 DLL 的文件夹（随 Aspose.Slides 提供）
  * 调用组件 DLL 的程序集所在的文件夹
* 为了避免评估版的限制，必须在使用 Aspose.Slides 之前设置许可证。每个应用程序或进程只需设置一次许可证。

## **应用许可证**

许可证可以从**文件**、**流**或**嵌入资源**加载。

{{% alert color="primary" %}}

Aspose.Slides 提供了用于授权操作的[License](https://reference.aspose.com/slides/cpp/class/aspose.slides.license/)类。

{{% /alert %}} 

{{% alert color="warning" %}}

新许可证只能在 21.4 及以后版本的 Aspose.Slides 中激活。早期版本使用不同的授权系统，无法识别这些许可证。

{{% /alert %}}

### **文件**

设置许可证的最简方式是将许可证文件放置在组件 DLL 所在的同一文件夹（随 Aspose.Slides 提供），仅指定文件名即可，无需路径。

以下 C++ 代码演示了如何设置许可证文件：
```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```


{{% alert color="warning" %}} 

如果将许可证文件放在其他目录，则在调用[License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/)方法时，指定的完整路径必须以许可证文件的实际名称结尾，且完全匹配。

例如，如果将许可证文件重命名为 *Aspose.Slides.lic.xml*，则必须在代码中将完整路径（以 *Aspose.Slides.lic.xml* 结尾）传递给[License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/)方法。

{{% /alert %}}

### **流**

您可以从流中加载许可证。以下 C++ 代码演示了如何从流应用许可证：
```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```


## **验证许可证**

要检查许可证是否已正确设置，您可以进行验证。以下 C++ 代码演示了如何验证许可证：
```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```


## **线程安全**

{{% alert title="Note" color="warning" %}} 

[License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) 方法**不具备线程安全**。如果需要在多个线程中同时调用此方法，建议使用同步原语（例如锁）来避免潜在问题。

{{% /alert %}}

## **常见问题**

**我可以在完全离线的环境（无网络）中应用许可证吗？**

可以。许可证验证完全在本地使用许可证文件完成，无需互联网连接。

**一年订阅到期后会怎样？库会停止工作吗？**

不会。许可证为永久有效：您仍可继续使用订阅结束前发布的版本，只是若想使用更新的版本则需续订。