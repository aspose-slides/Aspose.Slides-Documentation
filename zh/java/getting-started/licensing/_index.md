---
title: 授权
type: docs
weight: 90
url: /zh/java/licensing/
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中应用、管理和排除许可证故障。通过我们的分步授权指南，确保持续访问全部功能。"
---
## **概述**

Aspose.Slides 可以在评估模式或使用有效许可证的情况下使用。评估版提供与授权版相同的功能，但会在每个演示文稿保存的每张幻灯片上添加评估水印，并截断通过 API 读取的文本。

本文说明了 Aspose.Slides 中的许可证机制以及在使用库之前如何应用许可证。可以使用 `License` 类从文件、流或嵌入资源加载许可证。本文还展示了如何验证许可证是否已正确应用。

## **评估 Aspose.Slides**

{{% alert color="info" title="注意" %}}

您可以从其[下载页面](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)下载 **Aspose.Slides for Java** 的评估版。评估版提供与授权版相同的功能。评估包与购买的包相同，只需在代码中添加几行（以应用许可证），评估版即可转为授权版。

在您对 **Aspose.Slides** 的评估满意后，可以[购买许可证](https://purchase.aspose.com/pricing/slides/java/)。我们建议您了解不同的订阅类型。如有疑问，请联系 Aspose 销售团队。

每个 Aspose 许可证均附带一年免费升级订阅，可在订阅期间获取新版本或修复。拥有许可证的用户（甚至是评估版用户）均可免费获得无限技术支持。

{{% /alert %}} 

**评估版限制**

* 未指定许可证的评估版提供完整功能，但会在每个演示文稿保存的每张幻灯片上添加评估水印文本框。
* 通过 API 读取的文本（包括刚设置的文本）会被截断为前几个字符，并附加评估限制说明。写入的文本会完整保存。

{{% alert color="info" title="注意" %}}

要在无任何限制的情况下测试 Aspose.Slides，您可以申请**30 天临时许可证**。更多信息请参阅[如何获取临时许可证](https://purchase.aspose.com/temporary-license)页面。

{{% /alert %}}

## **Aspose.Slides 中的许可证**

* 评估版在您购买许可证并在代码中添加几行（以应用许可证）后即可转为授权版。
* 许可证是包含产品名称、授权开发人员数量、订阅到期日期等信息的纯文本 XML 文件。
* 许可证文件经过数字签名，禁止修改。即使是无意的换行也会使其失效。
* Aspose.Slides for Java 通常会在以下位置查找许可证：
  * 显式路径
  * 包含 Aspose.Slides.jar 的文件夹
* 为避免评估版的限制，您需要在使用 **Aspose.Slides** 之前设置许可证。每个应用程序或进程只需设置一次许可证。

{{% alert color="info" title="注意" %}}

您可能想查看[计量许可](/slides/zh/java/metered-licensing/)。

{{% /alert %}} 


## **应用许可证**

许可证可以从**文件**或**流**加载。

{{% alert color="info" title="注意" %}}

Aspose.Slides 提供用于授权操作的[License](https://reference.aspose.com/slides/java/com.aspose.slides/license/)类。

{{% /alert %}} 

{{% alert color="warning" title="警告" %}}

新许可证只能在 21.4 或更高版本的 Aspose.Slides 中激活。早期版本使用不同的授权系统，无法识别这些许可证。

{{% /alert %}}

### **文件**

设置许可证的最简方法是将许可证文件放在包含 Aspose.Slides.jar 或您应用程序的 jar 的文件夹中。

以下 Java 代码演示如何设置许可证文件：

``` java
// 实例化 License 类
com.aspose.slides.License license = new com.aspose.slides.License();

// 设置许可证文件路径
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="警告" %}}

如果将许可证文件放在其他目录中，在调用[setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-)方法时，指定路径末尾的许可证文件名必须与实际文件名相同。

例如，您可以将许可证文件名改为 *Aspose.Slides.Java.lic.xml*。此时在代码中需要将路径（以 *Aspose.Slides.Java.lic.xml* 结尾）传递给[setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-)方法。

{{% /alert %}}

### **流**

您可以从流加载许可证。以下 Java 代码演示如何从流应用许可证：

``` java
// 实例化 License 类
com.aspose.slides.License license = new com.aspose.slides.License();

// 通过流设置许可证
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

如果通过 Java 使用 Aspose.Slides for PHP，可以通过 PHP/Java 桥设置许可证。该桥允许在 PHP 语法中使用 Java 类。更多信息请参阅[License in PHP](/slides/zh/php-java/licensing/)。

## **验证许可证**

要检查许可证是否已正确设置，可以对其进行验证。以下 Java 代码演示如何验证许可证：

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **线程安全性**

{{% alert color="warning" title="警告" %}}

[setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.io.InputStream-)方法不是线程安全的。如果需要在多个线程中同时调用此方法，建议使用同步原语（如锁）以避免问题。

{{% /alert %}}

## **常见问题**

### 我可以在完全离线的环境（无互联网访问）中应用许可证吗？

可以。许可证验证在本地使用许可证文件完成，无需互联网连接。

### 一年订阅到期后会怎样？库会停止工作吗？

不会。许可证是永久有效的：您可以继续使用订阅结束日期前发布的版本，只是若不续订，将无法使用更高版本的发布。