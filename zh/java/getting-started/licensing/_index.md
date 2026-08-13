---
title: 许可
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
description: "在 Aspose.Slides for Java 中应用、管理和排除许可证问题。通过我们的分步许可指南，确保持续访问全部功能。"
---
## **概述**

Aspose.Slides 可以在评估模式或使用有效许可证的情况下使用。评估版本提供与授权版本相同的功能，但在打开或保存演示文稿时会添加评估水印，并将文本提取限制为一张幻灯片。

本文介绍了 Aspose.Slides 中的许可工作原理，以及在使用库之前如何应用许可证。许可证可以通过 `License` 类从文件、流或嵌入资源中加载。文章还展示了如何验证许可证是否已正确应用。

## **评估 Aspose.Slides**

{{% alert color="info" %}} 

您可以从其[下载页面](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)下载 **Aspose.Slides for Java** 的评估版本。评估版本提供与产品授权版本相同的功能。评估包与购买的包相同。只需在代码中添加几行（以应用许可证），评估版本即可转为授权版本。

当您对 **Aspose.Slides** 的评估满意后，您可以[购买许可证](https://purchase.aspose.com/buy)。我们建议您了解不同的订阅类型。如有疑问，请联系 Aspose 销售团队。

每个 Aspose 许可证都附带一年免费升级订阅，可在订阅期间获取新版本或修复程序。拥有授权产品（甚至评估版本）的用户可获得免费且无限的技术支持。

{{% /alert %}} 

**评估版本限制**

* 虽然 Aspose.Slides 评估版本（未指定许可证）提供完整的产品功能，但在打开和保存操作时会在文档顶部插入评估水印。 
* 在从演示文稿幻灯片提取文本时，仅限一张幻灯片。

{{% alert color="info" %}} 

要在无任何限制的情况下测试 Aspose.Slides，您可以申请 **30 天临时许可证**。有关详细信息，请参阅[如何获取临时许可证](https://purchase.aspose.com/temporary-license)页面。

{{% /alert %}}

## **Aspose.Slides 中的许可**

* 评估版本在您购买许可证并在代码中添加几行（以应用许可证）后即可转为授权版本。
* 许可证是一个纯文本 XML 文件，包含产品名称、授权开发者数量、订阅到期日期等信息。 
* 许可证文件经过数字签名，不能修改。即使不小心在文件内容中添加额外的换行，也会导致许可证失效。
* Aspose.Slides for Java 通常在以下位置查找许可证：
  * 明确指定的路径
  * 包含 Aspose.Slides.jar 的文件夹
* 为了避免评估版本的限制，您需要在使用 **Aspose.Slides** 之前设置许可证。每个应用程序或进程只需设置一次许可证。

{{% alert color="info" %}} 

您可能想查看[计量许可](/slides/zh/java/metered-licensing/)。

{{% /alert %}} 


## **应用许可证**

许可证可以从**文件**或**流**加载。

{{% alert color="info" %}}

Aspose.Slides 提供了用于许可操作的[License](https://reference.aspose.com/slides/zh/java/com.aspose.slides/License)类。

{{% /alert %}} 

{{% alert color="warning" %}}

新许可证只能在 21.4 版或更高版本的 Aspose.Slides 中激活。早期版本使用不同的许可系统，无法识别这些许可证。

{{% /alert %}}

### **文件**

设置许可证的最简单方法是将许可证文件放置在包含 Aspose.Slides.jar 的文件夹或您的应用程序 JAR 中。

下面的 Java 代码演示了如何设置许可证文件：

``` java
// 实例化 License 类
com.aspose.slides.License license = new com.aspose.slides.License();

// 设置许可证文件路径
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

如果您将许可证文件放在其他目录中，在调用[SetLicense](https://reference.aspose.com/slides/zh/java/com.aspose.slides/License#setLicense-java.lang.String-)方法时，指定的显式路径末尾的许可证文件名必须与您的许可证文件相同。

例如，您可以将许可证文件名改为 *Aspose.Slides.Java.lic.xml*。然后，在代码中必须将指向该文件（以 *Aspose.Slides.Java.lic.xml* 结尾）的路径传递给[SetLicense](https://reference.aspose.com/slides/zh/java/com.aspose.slides/License#setLicense-java.lang.String-)方法。

{{% /alert %}}

### **流**

您可以从流中加载许可证。下面的 Java 代码演示了如何从流中应用许可证：

``` java
// 实例化 License 类
com.aspose.slides.License license = new com.aspose.slides.License();

// 通过流设置许可证
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

如果您通过 Java 使用 Aspose.Slides for PHP，可以通过 PHP/Java 桥设置许可证。此桥允许您在 PHP 语法中使用 Java 类。更多信息，请参阅[PHP 中的许可证](/slides/zh/php-java/licensing/)。

## **验证许可证**

要检查许可证是否已正确设置，您可以进行验证。下面的 Java 代码演示了如何验证许可证：

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **线程安全**

{{% alert title="注意" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/zh/java/com.aspose.slides/License#setLicense-java.io.InputStream-) 方法线程不安全。如果需要从多个线程同时调用此方法，建议使用同步原语（如锁）以避免问题。 

{{% /alert %}}

## **常见问题**

### 我可以在完全离线的环境（无互联网访问）中应用许可证吗？

可以。许可证验证在本地使用许可证文件完成，无需互联网连接。

### 一年订阅期满后会怎样？库会停止工作吗？

不会。许可证是永久性的：您可以继续使用订阅结束日期之前发布的版本，只是如果不续订，则无法使用更高版本的发布。