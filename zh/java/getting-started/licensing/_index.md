---
title: 许可
type: docs
weight: 90
url: /zh/java/licensing/
---

## **评估 Aspose.Slides**

{{% alert color="primary" %}} 

您可以从其 [下载页面](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) 下载 **Aspose.Slides for Java** 的评估版本。评估版本提供与产品的许可版本相同的功能。评估包与购买的包相同。评估版本在您添加几行代码之后（以应用许可证）便会变为许可版本。

一旦您对 **Aspose.Slides** 的评估结果感到满意，您可以 [购买许可证](https://purchase.aspose.com/buy)。我们建议您了解不同的订阅类型。如果您有任何疑问，请联系 Aspose 销售团队。

每个 Aspose 许可证都附带一年免费升级新版本或修复的订阅，这些版本或修复是在订阅期内发布的。拥有许可产品（甚至评估版本）的用户将获得免费的无限技术支持。

{{% /alert %}} 

**评估版本的限制**

* 虽然 Aspose.Slides 评估版本（未指定许可证）提供完整的产品功能，但在打开和保存操作时，它会在文档顶部插入评估水印。 
* 从演示幻灯片中提取文本时，您只能限制为一张幻灯片。

{{% alert color="primary" %}} 

要测试没有限制的 Aspose.Slides，您可以申请 **30 天临时许可证**。有关更多信息，请参见 [如何获取临时许可证](https://purchase.aspose.com/temporary-license) 页面。

{{% /alert %}}

## **Aspose.Slides 的许可**

* 评估版本在您购买许可证并添加几行代码（以应用许可证）后变为许可版本。
* 许可证是一个明文 XML 文件，包含产品名称、许可的开发人员数量、订阅到期日期等详细信息。 
* 许可证文件经过数字签名，因此您不得修改该文件。即使是不小心添加的额外换行符也会使其无效。
* Aspose.Slides for Java 通常尝试在这些位置查找许可证：
  * 显式路径
  * 包含 Aspose.Slides.jar 的文件夹
* 要避免与评估版本相关的限制，您需要在使用 **Aspose.Slides** 之前设置许可证。您只需在每个应用程序或进程中设置一次许可证即可。

{{% alert color="primary" %}} 

您可能想查看 [计量许可](/slides/zh/java/metered-licensing/)。

{{% /alert %}} 


## **应用许可证**

许可证可以从 **文件** 或 **流** 中加载。

{{% alert color="primary" %}}

Aspose.Slides 提供用于许可操作的 [License](https://reference.aspose.com/slides/java/com.aspose.slides/License) 类。

{{% /alert %}} 

### **文件**

设置许可证的最简单方法是将许可证文件放置在包含 Aspose.Slides.jar 或您应用程序的 jar 的文件夹中。

以下 Java 代码演示了如何设置许可证文件：

``` java
// 实例化 License 类
com.aspose.slides.License license = new com.aspose.slides.License();

// 设置许可证文件路径
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

如果您将许可证文件放在不同目录中，当您调用 [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-) 方法时，指定的路径末尾的许可证文件名必须与您的许可证文件相同。

例如，您可以将许可证文件名更改为 *Aspose.Slides.Java.lic.xml*。然后在您的代码中，您必须将以 *Aspose.Slides.Java.lic.xml* 结尾的文件路径传递给 [SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.lang.String-) 方法。

{{% /alert %}}

### **流**

您可以从流中加载许可证。以下 Java 代码演示了如何从流中应用许可证：

``` java
// 实例化 License 类
com.aspose.slides.License license = new com.aspose.slides.License();

// 通过流设置许可证
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java 桥接**

如果您通过 Java 使用 Aspose.Slides for PHP，您可以通过 PHP/Java 桥接设置许可证。此桥接允许您在 PHP 语法中使用 Java 类。有关更多信息，请参见 [PHP 中的许可证](/slides/zh/php-java/licensing/)。

## **验证许可证**

要检查许可证是否已正确设置，您可以进行验证。以下 Java 代码演示了如何验证许可证：

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("许可证有效！");
}
```

## **线程安全性**

{{% alert title="注意" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/java/com.aspose.slides/License#setLicense-java.io.InputStream-) 方法不是线程安全的。如果此方法必须同时从多个线程调用，您可能需要使用同步原语（例如锁）来避免问题。 

{{% /alert %}}