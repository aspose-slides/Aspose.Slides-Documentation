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
description: "在 Aspose.Slides for C++ 中应用、管理和排除许可证问题。通过我们的分步授权指南，确保持续访问全部功能。"
---
## **概述**

Aspose.Slides 可以在评估模式或使用有效许可证的情况下使用。评估版提供与授权版相同的功能，但会在每个保存的演示文稿的每张幻灯片上添加评估水印，并截断代码从演示文稿读取的文本。

本文阐述了 Aspose.Slides 的授权机制以及在使用库之前如何应用许可证。可以使用 `License` 类从文件或流中加载许可证。文章还展示了如何验证许可证是否已正确应用。

## **评估 Aspose.Slides**

{{% alert color="info" title="Note" %}}
您可以从[其 NuGet 下载页面](https://www.nuget.org/packages/Aspose.Slides.Cpp/)或通过 ZIP 包从[下载页面](https://releases.aspose.com/slides/cpp/)下载 **Aspose.Slides for C++** 的评估版。评估版提供与授权产品相同的功能。实际上，评估包与购买的版本完全相同——只要在代码中添加几行以应用许可证，它就会变为授权版。

当您对 **Aspose.Slides** 的评估满意后，可[购买许可证](https://purchase.aspose.com/pricing/slides/cpp/)。我们建议您查看可用的订阅类型。如有任何疑问，欢迎联系 Aspose 销售团队。

每个 Aspose 许可证都包含一年免费升级订阅，期间的新版和错误修复均可免费获取。无论您使用的是授权版本还是评估版本，均可享受免费且无限制的技术支持。
{{% /alert %}} 

**评估版限制**

* 评估版（未指定许可证）提供完整的产品功能，但会在每个保存的演示文稿的每张幻灯片上添加评估水印文本框。
* 代码从演示文稿读取的文本会被截断为前几个字符，并附加评估限制的提示。代码写入的文本会完整保存。

{{% alert color="info" title="Note" %}}
要在无任何限制的情况下测试 Aspose.Slides，您可以请求 **30 天临时许可证**。更多信息请参阅[获取临时许可证的方法](https://purchase.aspose.com/temporary-license)页面。
{{% /alert %}}

## **Aspose.Slides 中的授权**

* 评估版在购买许可证并通过添加几行代码应用后即变为授权版。
* 许可证是一个纯文本 XML 文件，包含产品名称、授权的开发人员数量、订阅到期日期等详细信息。
* 许可证文件经过数字签名，禁止任何修改。即使是意外的更改——例如添加换行符——也会使文件失效。
* 当仅传递文件名而未指定文件夹时，Aspose.Slides for C++ 只会在当前工作目录中查找许可证文件。它不会搜索可执行文件所在文件夹或 Aspose.Slides 库所在文件夹，因此如果许可证文件存放在其他位置，请传递完整路径。
* 为避免评估版的限制，必须在使用 Aspose.Slides 之前设置许可证。每个应用程序或进程只需设置一次许可证。

## **应用许可证**

可以从**文件**或**流**加载许可证。

{{% alert color="info" title="Note" %}}
Aspose.Slides 提供用于授权操作的 [License](https://reference.aspose.com/slides/cpp/aspose.slides/license/) 类。
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
新许可证只能在 21.4 或更高版本的 Aspose.Slides 中激活。早期版本使用不同的授权系统，无法识别这些许可证。
{{% /alert %}}

### **文件**

在程序的工作目录中放置许可证文件并仅指定文件名（不带路径）是设置许可证的最简方式。否则请指定文件的完整路径。

以下 C++ 代码从程序的工作目录中应用许可证文件 *Aspose.Slides.lic*：

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

如果许可证有效，[License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) 将正常返回，程序结束且不输出任何信息；此后 Aspose.Slides 将不再受到评估限制。如果文件未位于工作目录，方法会抛出 [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) 并显示信息 *License "Aspose.Slides.lic" doesn't exist or access is restricted*。示例未捕获此异常，程序会停止。

{{% alert color="warning" title="Warning" %}}
如果将许可证文件放在其他目录，则在调用 [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) 方法时，指定的完整路径末尾的文件名必须与许可证文件的实际名称完全匹配。

例如，如果将许可证文件重命名为 *Aspose.Slides.lic.xml*，则必须在代码中将完整路径以 *Aspose.Slides.lic.xml* 结尾传递给 [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) 方法。
{{% /alert %}}

### **流**

当程序不以文件形式保存许可证（例如从数据库读取许可证）时，可从流中加载许可证。[License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) 接受任何包含许可证的 [Stream](https://reference.aspose.com/slides/cpp/system.io/stream/)。为保持示例简短，以下 C++ 代码使用 [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) 打开工作目录中的 *Aspose.Slides.lic* 并从该流中应用许可证：

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

有效的许可证会产生与文件示例相同的结果。如果文件不存在，[File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) 会在应用许可证之前抛出 [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/)，程序随即停止。

## **验证许可证**

要检查许可证是否已正确设置，请调用 [License::IsLicensed](https://reference.aspose.com/slides/cpp/aspose.slides/license/islicensed/)。只有在成功应用了有效许可证后它才返回 `true`，否则返回 `false`。以下 C++ 代码从工作目录应用许可证文件并随后进行检查：

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

使用有效许可证时，程序会打印 *License is good!*。如果文件缺失或不是许可证文件，[License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) 会在检查之前抛出异常，程序停止且不打印任何内容。如果文件是签名不匹配的许可证（例如被编辑过），SetLicense 会在没有错误的情况下返回，但 `IsLicensed` 返回 `false`，因此不会打印任何信息，Aspose.Slides 仍处于评估模式。

## **线程安全性**

{{% alert color="warning" title="Warning" %}}
[License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) 方法 **不是线程安全** 的。如果需要从多个线程同时调用此方法，建议使用同步原语（例如锁）以防止潜在问题。
{{% /alert %}}

## **FAQ**

### 我可以在完全离线的环境（无互联网连接）中应用许可证吗？

可以。许可证验证在本地使用许可证文件完成，无需互联网连接。

### 一年订阅到期后会怎样？库会停止工作吗？

不会。许可证是永久有效的：您可以继续使用订阅结束日期之前发布的版本，只是如果不续订将无法使用更高版本的发布。