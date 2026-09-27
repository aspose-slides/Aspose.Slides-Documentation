---
title: 授权
type: docs
weight: 80
url: /zh/php-java/licensing/
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
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 中应用、管理和排除许可证问题。通过我们的分步授权指南，确保持续访问全部功能。"
---
## **介绍**

有时为了获得最佳的评估结果，可能需要动手实践。因此，Aspose.Slides 提供了不同的购买计划，并提供免费试用和 30 天临时许可证供评估使用。

{{% alert color="info" title="注意" %}}
请注意，有多项通用政策和实践指引您如何评估、正确授权以及购买我们的产品。您可以在["购买政策和常见问题"](https://purchase.aspose.com/policies) 部分找到这些内容。
{{% /alert %}}

## **评估 Aspose.Slides**
您可以轻松下载 Aspose.Slides 进行评估。评估包与购买包相同。仅需在代码中添加几行代码来应用许可证，评估版本即可转为授权版本。

## **评估版限制**
未指定许可证的 Aspose.Slides 评估版提供完整的产品功能，但有两项限制：

* 在每个演示文稿保存的每张幻灯片中部添加一个评估水印文本框。
* 代码从演示文稿读取的文本会被截断，只保留前几个字符，并附加评估限制的提示。代码写入的文本会完整保存。

{{% alert color="info" title="注意" %}}
如果希望在不受评估版限制的情况下测试 Aspose.Slides，您可以申请 **30 天临时许可证**。详情请参阅[如何获取临时许可证？](https://purchase.aspose.com/temporary-license)。
{{% /alert %}} 

## **关于许可证**
您可以通过其[下载页面](https://packagist.org/packages/aspose/slides)轻松下载 Aspose.Slides for PHP via Java 的评估版。评估版提供与授权版**完全相同的功能**。此外，购买许可证并在代码中添加几行代码后，评估版即可转为授权版本。

许可证是一个纯文本 XML 文件，包含产品名称、授权开发人员数量、订阅到期日期等详细信息。该文件已数字签名，请勿修改，即使是无意中添加额外的换行也会导致失效。

为避免评估版的限制，您需要在使用 **Aspose.Slides** 前设置许可证。每个应用程序或进程只需设置一次许可证。

{{% alert color="info" title="注意" %}}
您可能想了解[计量授权](/slides/zh/php-java/metered-licensing/)。
{{% /alert %}} 

## **已购买许可证**

购买后，您需要应用许可证文件或流。

{{% alert color="info" title="注意" %}}
您需要设置许可证：
* 每个应用程序域仅一次
* 在使用任何其他 Aspose.Slides 类之前
{{% /alert %}}

{{% alert color="info" title="注意" %}}
定价信息请参阅[“定价信息”](https://purchase.aspose.com/pricing/slides/family)页面。
{{% /alert %}}

### **在 Aspose.Slides for PHP via Java 中设置许可证**

可以从以下位置应用许可证：

* 显式路径
* 流
* 计量许可证 – 新的授权机制

{{% alert color="info" title="注意" %}}
使用 **setLicense** 方法为组件授权。

虽然多次调用 **setLicense** 不会造成错误，但会浪费资源（处理器）。
{{% /alert %}}

{{% alert color="warning" title="警告" %}}
新许可证只能在 21.4 及更高版本的 Aspose.Slides 中激活。早期版本使用不同的授权系统，无法识别这些许可证。
{{% /alert %}}

#### **使用文件应用许可证**

以下代码片段用于设置许可证文件：

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/zh/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

示例假设许可证文件与脚本位于同一目录，并传递其绝对路径：Aspose.Slides 在 Tomcat 中运行，无法根据脚本文件夹解析相对路径。调用 setLicense 方法时，许可证名称应与许可证文件名称相同。例如，您可以将许可证文件名改为 “Aspose.Slides.lic.xml”。随后，在代码中需将新许可证名 (Aspose.Slides.lic.xml) 传递给 setLicense 方法。

#### **从流中应用许可证**

以下代码片段用于从流中应用许可证：

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/zh/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **常见问题**

### 我可以在完全离线的环境（无互联网访问）中应用许可证吗？

可以。许可证验证在本地使用许可证文件完成，无需互联网连接。

### 订阅一年后会怎样？库会停止工作吗？

不会。许可证为永久有效：您可以继续使用订阅结束日期前发布的版本，只是若不续订，将无法使用更高版本的发布。