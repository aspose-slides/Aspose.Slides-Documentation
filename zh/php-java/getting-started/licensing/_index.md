---
title: 许可
description: "Aspose.Slides for PHP via Java 提供不同的购买计划，或提供免费试用和 30 天临时许可证供评估使用授权和订阅政策。"
type: docs
weight: 80
url: /php-java/licensing/
---

有时，为了获得最佳的评估结果，可能需要动手实践。因此，Aspose.Slides 提供了不同的购买计划，并且还提供免费试用和 30 天临时许可证供评估。

{{% alert color="primary" %}}

请注意，有许多一般政策和实践指导您如何评估、正确授权和购买我们的产品。您可以在 ["购买政策和常见问题"](https://purchase.aspose.com/policies) 部分找到它们。

{{% /alert %}}

## **评估 Aspose.Slides**
您可以轻松下载 Aspose.Slides 进行评估。评估包与购买包相同。评估版本只需在您添加几行代码以应用许可证后即会被授权。

## **评估版本限制**
Aspose.Slides 的评估版本（未指定许可证）提供完整的产品功能，但在打开和保存文档时，会在文档顶部插入评估水印。您在从演示文稿中提取文本时，也限制为一张幻灯片。

{{% alert color="primary" %}} 

如果您想测试 Aspose.Slides 而没有评估版本的限制，您可以请求一个 **30 天临时许可证**。有关更多信息，请参阅 [如何获得临时许可证？](https://purchase.aspose.com/temporary-license)。

{{% /alert %}} 

## **关于许可证**
您可以轻松从其 [下载页面](https://packagist.org/packages/aspose/slides) 下载 Aspose.Slides for PHP via Java 的评估版本。评估版本提供与授权版本完全 **相同的功能**。此外，评估版本在您购买许可证并添加几行代码以应用许可证后，将直接被授权。

许可证是一个明文 XML 文件，包含产品名称、授权开发人员数量、订阅到期日期等详细信息。该文件经过数字签名，因此请勿修改文件。即使是不小心在文件内容中添加了额外的换行符，也会使其无效。

为了避免与评估版本相关的限制，您需要在使用 **Aspose.Slides** 之前设置许可证。您只需每个应用程序或进程设置一次许可证。

## 购买许可证

购买后，您需要应用许可证文件或流。

{{% alert color="primary" %}}

您需要设置许可证：
* 每个应用程序域仅设置一次
* 在使用其他任何 Aspose.Slides 类之前

{{% /alert %}}

{{% alert color="primary" %}}

您可以在 [“定价信息”](https://purchase.aspose.com/pricing/slides/family) 页面找到定价信息。

{{% /alert %}}

### **在 Aspose.Slides for PHP via Java 中设置许可证**

许可证可以从以下位置应用：

* 具体路径
* 流
* 作为计量许可证 – 一种新的授权机制

{{% alert color="primary" %}}

使用 **setLicense** 方法为组件授权。

虽然多次调用 **setLicense** 没有害处，但会浪费资源（处理器）。

{{% /alert %}}

#### **使用文件应用许可证**

此代码片段用于设置许可证文件：

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

在调用 setLicense 方法时，许可证名称应与许可证文件的名称相同。例如，您可以将许可证文件名更改为 "Aspose.Slides.lic.xml"。然后，在代码中，您必须将新许可证名称（Aspose.Slides.lic.xml）传递给 setLicense 方法。

#### **从流中应用许可证**

此代码片段用于从流中应用许可证：

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

#### 应用计量许可证

Aspose.Slides 允许开发人员应用计量密钥。这是一种新的授权机制。

新的授权机制将与现有的授权方法一起使用。希望根据 API 功能的使用量进行计费的客户，可以使用计量授权。

完成获取此类许可证所需的所有步骤后，您将收到密钥，而不是许可证文件。此计量密钥可以使用为此特别介绍的 **Metered** 类应用。

以下代码示例演示了如何设置计量公钥和私钥：

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Metered;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

# 创建 CAD Metered 类的实例
$metered = new Metered();

# 访问 set_metered_key 属性并将公钥和私钥作为参数传递
$metered->setMeteredKey("*****", "*****");

# 在调用 API 之前获取计量数据量
$amountbefore = Metered::getConsumptionQuantity();
# 显示信息
echo "<script>console.log('消费数量前: " . java_values($amountbefore) . "' );</script>";

# 从磁盘加载文档。
$pres = new Presentation();
# 获取文档的页面计数
echo "<script>console.log('消费数量后: " . java_values($pres->getSlides()->size()) . "' );</script>";
# 另存为 PDF
$pres->save("out_pdf.pdf", SaveFormat::Pdf);

# 在调用 API 之后获取计量数据量
$amountafter = Metered::getConsumptionQuantity();
# 显示信息
echo "<script>console.log('消费数量后: " . java_values($amountafter) . "' );</script>";
?>
```

{{% alert color="primary" %}}

请注意，您必须具有稳定的 Internet 连接以正确使用计量许可证，因为计量机制需要与我们的服务进行持续交互以进行正确的计算。有关更多详细信息，请参阅 [“计量许可证常见问题”](https://purchase.aspose.com/faqs/licensing/metered) 部分。

{{% /alert %}}