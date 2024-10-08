---
title: 许可
description: "Aspose.Slides for Python via Java 提供不同的购买计划，或者提供免费试用和 30 天临时许可证以供使用许可和订阅政策进行评估。"
type: docs
weight: 80
url: /zh/python-java/licensing/
---

有时，为了获得最佳的评估结果，可能需要一种实践的方法。因此，Aspose.Slides 提供不同的购买计划，同时也提供免费试用和 30 天临时许可证进行评估。

{{% alert color="primary" %}}

请注意，有一些一般政策和实践指导您如何评估、正确授权和购买我们的产品。您可以在 ["购买政策和常见问题"](https://purchase.aspose.com/policies) 部分找到它们。

{{% /alert %}}

## **评估 Aspose.Slides**
您可以轻松下载 Aspose.Slides 进行评估。评估包与购买的包是相同的。评估版本仅在您添加几行代码以应用许可证后变为授权版本。

## **评估版本限制**
不指定许可证的 Aspose.Slides 评估版本提供完整的产品功能，但在打开和保存文档时会插入评估水印。在从演示幻灯片提取文本时，您也仅限使用一张幻灯片。

{{% alert color="primary" %}} 

如果您想在没有评估版本限制的情况下测试 Aspose.Slides，您可以申请 **30 天临时许可证**。有关更多信息，请参阅 [如何获取临时许可证？](https://purchase.aspose.com/temporary-license)。

{{% /alert %}} 

## **关于许可证**
您可以轻松从 Aspose.Slides for Python via Java 的 [下载页面](https://releases.aspose.com/slides/python-java/) 下载评估版本。评估版本提供与 Aspose.Slides 的授权版本完全 **相同的功能**。此外，评估版本在您购买许可证并添加几行代码以应用许可证后仅需变为授权版本。

许可证是一个纯文本的 XML 文件，其中包含诸如产品名称、授权开发人员数量、订阅到期日期等详细信息。该文件经过数字签名，因此请勿修改该文件。即使是不小心在文件内容中添加额外的换行符也会使其无效。

为了避免与评估版本相关的限制，您需要在使用 **Aspose.Slides** 之前设置许可证。您只需在每个应用程序或进程中设置一次许可证。

## 购买许可证

购买后，您需要应用许可证文件或流。

{{% alert color="primary" %}}

您需要设置许可证：
* 仅在每个应用程序域中设置一次
* 在使用任何其他 Aspose.Slides 类之前

{{% /alert %}}

{{% alert color="primary" %}}

您可以在 [“定价信息”](https://purchase.aspose.com/pricing/slides/family) 页面找到定价信息。

{{% /alert %}}

### **在 Aspose.Slides for Python via Java 中设置许可证**

许可证可以从以下位置应用：

* 显式路径
* 流
* 作为计量许可证 – 一种新的许可机制

{{% alert color="primary" %}}

使用 **setLicense** 方法为组件授权。

尽管多次调用 **setLicense** 并无害，但这会浪费资源（处理器）。

{{% /alert %}}

#### **使用文件应用许可证**

此代码片段用于设置许可证文件：

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

调用 setLicense 方法时，许可证名称应与您的许可证文件相同。例如，您可以将许可证文件名称更改为 "Aspose.Slides.lic.xml"。然后，在代码中，您需要将新的许可证名称（Aspose.Slides.lic.xml）传递给 setLicense 方法。

#### **从字节应用许可证**

此代码片段用于从字节应用许可证：

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### 应用计量许可证

Aspose.Slides 允许开发人员应用计量密钥。这是一种新的许可证机制。

新的许可证机制将与现有的许可证方法一起使用。希望根据 API 功能使用情况进行计费的客户可以使用计量许可。

完成获取此类型许可证的所有必要步骤后，您将收到密钥，而不是许可证文件。此计量密钥可以使用为此专门引入的 **Metered** 类应用。

以下代码示例显示如何设置计量的公钥和私钥：

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# 创建 CAD Metered 类的实例
metered = Metered();

# 访问 set_metered_key 属性并将公钥和私钥作为参数传递
metered.setMeteredKey("*****", "*****");

# 在调用 API 之前获取计量数据量
amountbefore = Metered.getConsumptionQuantity()

# 显示信息
print("使用量之前: \"" + amountbefore + "\"" )

# 从磁盘加载文档。
pres = Presentation();

# 获取文档的页数
print("使用量之后: \"" + str(pres.getSlides().size()) + "\"" )

# 保存为 PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# 在调用 API 之后获取计量数据量
amountafter = Metered.getConsumptionQuantity()

# 显示信息
print("使用量之后: \"" + amountafter + "\"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}

请注意，您必须保持稳定的互联网连接，以正确使用计量许可证，因为计量机制要求与我们的服务进行持续交互以进行准确计算。有关更多详细信息，请参阅 [“计量许可常见问题”](https://purchase.aspose.com/faqs/licensing/metered) 部分。

{{% /alert %}}