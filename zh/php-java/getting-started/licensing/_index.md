---
title: 授权
type: docs
weight: 80
url: /zh/php-java/licensing/
keywords:
- 许可
- 临时许可
- 设置许可
- 使用许可
- 验证许可
- 许可文件
- 评估版
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 中应用、管理和排除许可故障。通过我们的分步授权指南，确保持续访问全部功能。"
---

有时，为了获得最佳的评估结果，可能需要动手操作。因此，Aspose.Slides 提供了不同的购买计划，还提供免费试用和 30 天临时许可证用于评估。

{{% alert color="primary" %}}
请注意，有一些通用的政策和实践指引您如何评估、正确授权以及购买我们的产品。您可以在["购买政策和常见问题"](https://purchase.aspose.com/policies)部分找到它们。
{{% /alert %}}

## **评估 Aspose.Slides**
您可以轻松下载 Aspose.Slides 进行评估。评估包与购买的包相同。只需添加几行代码应用许可证，评估版即可变为授权版。

## **评估版限制**
Aspose.Slides 的评估版（未指定许可证）提供完整的产品功能，但在打开和保存文档时会在文档顶部插入评估水印。提取演示文稿文本时也仅限于一张幻灯片。

{{% alert color="primary" %}} 
如果您想在不受评估版限制的情况下测试 Aspose.Slides，可以申请 **30 天临时许可证**。有关更多信息，请参阅[如何获取临时许可证？](https://purchase.aspose.com/temporary-license)。
{{% /alert %}} 

## **关于许可证**
您可以通过 Java 从其[下载页面](https://packagist.org/packages/aspose/slides)轻松下载 Aspose.Slides for PHP 的评估版。评估版提供的功能与授权版完全**相同**。此外，购买许可证并添加几行代码后，评估版即可直接转为授权版。

许可证是一个纯文本 XML 文件，包含产品名称、授权的开发人员数量、订阅截止日期等详细信息。该文件经过数字签名，请勿修改文件。即使不小心在文件内容中添加额外的换行也会导致其无效。

为避免评估版的限制，您需要在使用 **Aspose.Slides** 之前设置许可证。每个应用程序或进程只需设置一次许可证。

{{% alert color="primary" %}} 
您可能想了解[计量授权](https://docs.aspose.com/slides/php-java/metered-licensing/)。
{{% /alert %}} 

## **购买的许可证**
购买后，您需要应用许可证文件或流。

{{% alert color="primary" %}}
您需要设置许可证：
* 每个应用程序域只需一次
* 在使用任何其他 Aspose.Slides 类之前
{{% /alert %}}

{{% alert color="primary" %}}
您可以在["定价信息"](https://purchase.aspose.com/pricing/slides/family)页面找到定价信息。
{{% /alert %}}

### **在 Aspose.Slides for PHP via Java 中设置许可证**
许可证可以从以下位置应用：
* 显式路径
* 流
* 计量授权 – 一种新授权机制

{{% alert color="primary" %}}
使用 **setLicense** 方法为组件授权。

虽然多次调用 **setLicense** 不会有害，但会浪费资源（处理器）。
{{% /alert %}}

{{% alert color="warning" %}}
新许可证只能在 21.4 或更高版本的 Aspose.Slides 中激活。早期版本使用不同的授权系统，无法识别这些许可证。
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


调用 setLicense 方法时，许可证名称应与许可证文件的名称相同。例如，您可以将许可证文件名更改为 "Aspose.Slides.lic.xml"。随后，在代码中需要将新的许可证名称 (Aspose.Slides.lic.xml) 传递给 setLicense 方法。

#### **从流应用许可证**
此代码片段用于从流应用许可证：
```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```


## **FAQ**

**我可以在完全离线的环境（无互联网连接）中应用许可证吗？**
可以。许可证验证在本地使用许可证文件完成，无需互联网连接。

**一年订阅到期后会怎样？库会停止工作吗？**
不会。许可证是永久有效的：您可以继续使用订阅结束日期之前发布的版本，只是若不续订，则无法使用更新的版本。