---
title: 授权
type: docs
weight: 90
url: /zh/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android via Java 中应用、管理和排除许可证问题。通过我们的授权指南，确保对全部功能的持续访问。"
---

## **评估 Aspose.Slides**

{{% alert color="primary" %}} 

您可以从其[下载页面](https://releases.aspose.com/slides/androidjava/)下载 **Aspose.Slides for Android via Java** 的评估版。评估版提供与产品授权版相同的功能。评估包与购买的包相同。仅需在代码中添加几行（以应用许可证），评估版即可转为授权版。

一旦您对 **Aspose.Slides** 的评估满意，就可以[购买许可证](https://purchase.aspose.com/buy)。我们建议您了解不同的订阅类型。如有疑问，请联系 Aspose 销售团队。

每个 Aspose 许可证均附带一年订阅，可免费升级到订阅期间发布的新版本或修复程序。拥有授权产品（甚至评估版）的用户可获得免费且无限制的技术支持。

{{% /alert %}} 

**评估版限制**

* 虽然 Aspose.Slides 评估版（未指定许可证）提供全部产品功能，但在打开和保存文档时会在文档顶部插入评估水印。 
* 在从演示文稿幻灯片提取文本时，仅限提取一张幻灯片。

{{% alert color="primary" %}} 

要在不受限制的情况下测试 Aspose.Slides，您可以申请**30 天临时许可证**。有关详细信息，请参阅[如何获取临时许可证](https://purchase.aspose.com/temporary-license)页面。

{{% /alert %}}

## **Aspose.Slides 的授权模式**

* 购买许可证并在代码中添加几行（以应用许可证）后，评估版将转为授权版。
* 许可证是包含产品名称、授权开发人员数量、订阅到期日期等信息的纯文本 XML 文件。 
* 许可证文件经过数字签名，您不得修改文件。即使不小心在文件内容中添加额外的换行也会导致无效。
* Aspose.Slides for Android via Java 通常会在以下位置查找许可证：
  * 明确指定的路径
  * 包含 Aspose.Slides.jar 的文件夹
* 为避免评估版的限制，您需要在使用 **Aspose.Slides** 之前设置许可证。每个应用或进程只需设置一次许可证。

{{% alert color="primary" %}} 

您可能想了解[计量授权](/slides/zh/androidjava/metered-licensing/)。

{{% /alert %}} 


## **应用许可证**

许可证可以从**文件**或**流**加载。

{{% alert color="primary" %}}

Aspose.Slides 提供用于授权操作的[License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/)类。

{{% /alert %}} 

{{% alert color="warning" %}}

新许可证只能在 21.4 版或更高版本的 Aspose.Slides 中激活。早期版本使用不同的授权系统，无法识别这些许可证。

{{% /alert %}}

### **文件**

设置许可证的最简方法是将许可证文件放在包含 Aspose.Slides.jar 或您应用的 jar 的文件夹中。

下面的 Java 代码演示如何设置许可证文件：
``` java
// 实例化 License 类
com.aspose.slides.License license = new com.aspose.slides.License();

// 设置许可证文件路径
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```


{{% alert color="warning" %}} 

如果将许可证文件放在其他目录中，当调用[SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)方法时，指定的显式路径末尾的许可证文件名必须与您的许可证文件相同。

例如，您可以将许可证文件名更改为 *Aspose.Slides.Android.via.Java.lic.xml*。然后，在代码中，需将路径（以 *Aspose.Slides.Android.via.Java.lic.xml* 结尾）传递给[SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-)方法。

{{% /alert %}}

### **流**

您可以从流加载许可证。以下 Java 代码演示如何从流应用许可证：
``` java
// 实例化 License 类
com.aspose.slides.License license = new com.aspose.slides.License();

// 通过流设置许可证
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```


## **验证许可证**

要检查许可证是否已正确设置，您可以进行验证。下面的 Java 代码演示如何验证许可证：
```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```


## **线程安全性**

{{% alert title="Note" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) 方法不是线程安全的。如果需要在多个线程中同时调用此方法，建议使用同步原语（如锁）来避免问题。 

{{% /alert %}}

## **常见问题**

**我可以在完全离线的环境（无互联网访问）中应用许可证吗？**

是的。许可证验证在本地使用许可证文件完成，无需互联网连接。

**一年订阅到期后会怎样？库会停止工作吗？**

不会。许可证是永久性的：您可以继续使用订阅结束日期前发布的版本，只是如果不续订，则无法使用更新的版本。