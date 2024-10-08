---
title: 授权
description: "Aspose.Slides for Python via .NET 提供不同的购买计划，或提供免费试用和30天临时许可证以便使用许可和订阅政策进行评估。"
type: docs
weight: 80
url: /python-net/licensing/
---

## **评估 Aspose.Slides**

{{% alert color="primary" %}} 

您可以从其 [下载页面](https://pypi.org/project/Aspose.Slides/) 下载 **Aspose.Slides for Python via .NET** 的评估版本。评估版本提供与授权版本相同的功能。评估包与购买的包是相同的。评估版本在您添加几行代码（应用许可证）后即可变为授权版本。

一旦您对 **Aspose.Slides** 的评估满意，您可以 [购买许可证](https://purchase.aspose.com/buy)。我们建议您查看不同的订阅类型。如有疑问，请联系 Aspose 销售团队。

每个 Aspose 许可证都附带一年订阅，可免费升级到新版本或在订阅期内发布的修复版本。拥有授权产品或甚至评估版本的用户可获得免费和无限的技术支持。

{{% /alert %}} 

**评估版本的限制**

* 虽然 Aspose.Slides 的评估版本（未指定许可证）提供完整的产品功能，但在打开和保存操作时会在文档顶部插入评估水印。
* 在从演示文稿幻灯片提取文本时，您仅限于一张幻灯片。

{{% alert color="primary" %}} 

要无限制地测试 Aspose.Slides，您可以申请 **30天临时许可证**。有关更多信息，请查看 [如何获取临时许可证](https://purchase.aspose.com/temporary-license) 页面。

{{% /alert %}}

## **Aspose.Slides 中的授权**

* 评估版本在您购买许可证并向其添加几行代码（以应用许可证）后便成为授权版本。
* 许可证是一个纯文本 XML 文件，包含如产品名称、被授权开发人员数量、订阅到期日期等详细信息。
* 许可证文件是数字签名的，因此您不得修改该文件。即使是意外添加的额外换行也会使其失效。
* Aspose.Slides for Python via .NET 通常会在以下位置查找许可证：
  * 显式路径
  * 包含调用 Aspose.Slides for Python via .NET 的 Python 脚本的文件夹
* 为了避免与评估版本相关的限制，您需要在使用 Aspose.Slides 之前设置许可证。每个应用程序或进程只需设置一次许可证。

{{% alert color="primary" %}} 

您可能想查看 [计量许可证](/slides/python-net/metered-licensing/)。

{{% /alert %}} 

## **应用许可证**

许可证可以从 **文件**、**流**或 **嵌入资源** 中加载。

{{% alert color="primary" %}}

Aspose.Slides 提供 [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) 类用于许可操作。

{{% /alert %}} 

### **文件**

设置许可证的最简单方法是将许可证文件放在包含组件 DLL 的相同文件夹中（包含在 Aspose.Slides 中），并在不带路径的情况下指定文件名。

该 Python 代码演示了如何设置许可证文件：

``` python
import aspose.slides as slides

# 实例化 License 类 
license = slides.License()

# 设置许可证文件路径
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}} 

如果您将许可证文件放在不同的目录中，当您调用 [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/) 方法时，指定的显式路径末尾的许可证文件名必须与您的许可证文件相同。

例如，您可以将许可证文件名更改为 *Aspose.Slides.lic.xml*。然后，在您的代码中，您必须将路径传递到文件（以 *Aspose.Slides.lic.xml* 结尾）传递给 [License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/) 方法。

{{% /alert %}}

### **流**

您可以从流中加载许可证。该 Python 代码演示了如何从流中应用许可证：

``` python
import aspose.slides as slides

# 实例化 License 类 
license = slides.License()

# 通过流设置许可证
license.set_license(stream)
```

## **验证许可证**

要检查许可证是否设置正确，您可以验证它。该 Python 代码演示了如何验证许可证：

```python
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("许可证有效！")
```

## **线程安全性**

{{% alert title="注意" color="warning" %}} 

[License.set_license()](https://reference.aspose.com/slides/python-net/aspose.slides/license/) 方法不是线程安全的。如果该方法必须从多个线程同时调用，您可能需要使用同步原语（如锁）来避免问题。

{{% /alert %}}