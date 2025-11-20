---
title: 授权
type: docs
weight: 80
url: /zh/python-net/licensing/
keywords:
- 许可证
- 临时许可证
- 设置许可证
- 使用许可证
- 验证许可证
- 许可证文件
- 评估版
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中应用、管理和排除许可证问题。通过我们的分步授权指南，确保持续访问全部功能。"
---

## **评估 Aspose.Slides**

您可以从其[下载页面](https://pypi.org/project/Aspose.Slides/)下载 **Aspose.Slides for Python via .NET** 的评估版。评估版提供与授权产品相同的功能。评估包与购买的包完全相同，添加几行代码以应用许可证后即可获得授权。

当您对 **Aspose.Slides** 的评估满意后，您可以[购买许可证](https://purchase.aspose.com/buy)。我们建议查看可用的订阅选项。如有疑问，请联系 Aspose 销售团队。

每个 Aspose 许可证均包含一年订阅，期间可免费升级到新版本并获取修复。授权用户和评估用户均可获得免费、无限的技术支持。

**评估版的限制**

* 虽然 Aspose.Slides 评估版（未应用许可证时）提供完整功能，但在每次打开或保存文档时会在文档顶部添加评估水印。
* 从演示文稿中提取文本时，仅限提取一张幻灯片的内容。

{{% alert color="primary" %}}
要在不受限制的情况下测试 Aspose.Slides，您可以申请 **30 天临时许可证**。详情请参阅[如何获取临时许可证](https://purchase.aspose.com/temporary-license) 页面。
{{% /alert %}}

## **Aspose.Slides 的授权**

* 评估版在购买许可证并添加几行代码以应用后即可获得授权。
* 许可证是一个纯文本 XML 文件，包含产品名称、覆盖的开发人员数量、订阅到期日期等详细信息。
* 许可证文件经过数字签名，禁止修改。即使添加一个换行符也会使其失效。
* Aspose.Slides for Python via .NET 通常在以下位置查找许可证：
  * 您提供的显式路径
  * 包含调用 Aspose.Slides for Python via .NET 的 Python 脚本的文件夹
* 为避免评估限制，请在使用 Aspose.Slides 前设置许可证。每个应用程序或进程只需设置一次。

{{% alert color="primary" %}}
您可能还想查看[计量授权](/slides/zh/python-net/metered-licensing/)。
{{% /alert %}}

## **应用许可证**

许可证可以从 **文件**、**流**或**嵌入式资源**加载。

{{% alert color="primary" %}}
Aspose.Slides 提供 [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) 类来处理授权。
{{% /alert %}}

{{% alert color="warning" %}}
新许可证只能在 21.4 或更高版本的 Aspose.Slides 中激活。早期版本使用不同的授权系统，无法识别这些许可证。
{{% /alert %}}

### **文件**

设置许可证的最简单方法是将许可证文件放在组件 DLL 相同的文件夹中，并仅指定文件名（不含路径）。

以下 Python 代码展示了如何设置许可证文件：
```py
import aspose.slides as slides

# 实例化 License 类。 
license = slides.License()

# 设置许可证文件路径。
license.set_license("Aspose.Slides.lic")
```


{{% alert color="warning" %}}
如果将许可证文件放在其他目录，在调用 [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) 时，显式路径末尾的文件名必须与许可证文件的名称匹配。

例如，您可以将许可证文件重命名为 *Aspose.Slides.lic.xml*。随后，在代码中将该文件的完整路径（以 Aspose.Slides.lic.xml 结尾）传递给 [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str) 方法。
{{% /alert %}}

### **流**

您可以从流中加载许可证。下面的 Python 示例演示如何从流中应用许可证：
```py
import aspose.slides as slides

# 实例化 License 类。
license = slides.License()

# 从流中设置许可证。
license.set_license(stream)
```


## **验证许可证**

要验证许可证是否正确应用，您可以进行验证。以下 Python 代码演示如何验证许可证：
```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspise.Slides.lic")

if license.is_licensed():
    print("License is good!")
```


## **线程安全**

{{% alert title="Note" color="warning" %}}
[License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/) 方法不是线程安全的。如果需要在多个线程中并发调用，请使用同步原语（例如 `threading.Lock`）以避免问题。
{{% /alert %}}

## **常见问题**

**我可以在完全离线的环境（无互联网访问）中应用许可证吗？**

可以。许可证验证在本地使用许可证文件完成，无需互联网连接。

**一年订阅到期后会怎样？库会停止工作吗？**

不会。许可证是永久的：您可以继续使用订阅结束日期之前发布的版本；但若不续订，则无法使用更高版本的发布。