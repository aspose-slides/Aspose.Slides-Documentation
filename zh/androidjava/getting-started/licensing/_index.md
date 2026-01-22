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
description: "在 Aspose.Slides for Android via Java 中应用、管理和排除许可证问题。通过我们的授权指南，确保持续访问完整功能。"
---

## **评估 Aspose.Slides**

{{% alert color="primary" %}} 

您可以从其[下载页面](https://releases.aspose.com/slides/androidjava/)下载 **Aspose.Slides for Android via Java** 的评估版。评估版提供与产品的授权版相同的功能。评估包与购买的包相同。只需在评估版中添加几行代码（以应用许可证），评估版即可转换为授权版。

当您对 **Aspose.Slides** 的评估满意后，您可以[购买许可证](https://purchase.aspose.com/buy)。我们建议您了解不同的订阅类型。如有疑问，请联系 Aspose 销售团队。

每个 Aspose 许可证均包括一年订阅，可免费升级到订阅期间发布的新版本或修复程序。拥有授权产品（甚至评估版）的用户可获得免费且无限制的技术支持。

{{% /alert %}} 

**评估版限制**

* 虽然 Aspose.Slides 评估版（未指定许可证）提供完整的产品功能，但在打开和保存操作时会在文档顶部插入评估水印。 
* 在从演示文稿幻灯片提取文本时，仅限于一张幻灯片。

{{% alert color="primary" %}} 

要在无限制的情况下测试 Aspose.Slides，您可以申请 **30 天临时许可证**。有关更多信息，请参阅[获取临时许可证方式](https://purchase.aspose.com/temporary-license)页面。

{{% /alert %}}

## **Aspose.Slides 授权**

* 评估版在您购买许可证并添加几行代码（以应用许可证）后即可转为授权版。 
* 许可证是一个纯文本 XML 文件，包含产品名称、授权的开发者数量、订阅到期日期等详细信息。 
* 许可证文件经过数字签名，因此不得修改文件。即使不小心在文件内容中添加额外的换行也会导致许可证失效。 
* Aspose.Slides for Android via Java 通常尝试在以下位置查找许可证：
  * 明确的路径
  * 包含 Aspose.Slides.jar 的文件夹
* 为避免评估版的限制，您需要在使用 **Aspose.Slides** 之前设置许可证。每个应用程序或进程只需设置一次许可证。

## **应用许可证**

许可证可以从 **文件** 或 **流** 加载。

{{% alert color="primary" %}}

Aspose.Slides 提供用于授权操作的[License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) 类。

{{% /alert %}} 

{{% alert color="warning" %}}

新的许可证只能在 21.4 版或更高版本激活 Aspose.Slides。早期版本使用不同的授权系统，无法识别这些许可证。

{{% /alert %}}

### **文件**

设置许可证的最简方法是将许可证文件放置在包含 Aspose.Slides.jar 的文件夹或您应用程序的 jar 中。

以下 Java 代码展示了如何设置许可证文件：
``` java
// 实例化 License 类
com.aspose.slides.License license = new com.aspose.slides.License();

// 设置许可文件路径
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```


{{% alert color="warning" %}} 

如果您将许可证文件放在其他目录中，在调用[SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) 方法时，指定的显式路径末尾的许可证文件名必须与您的许可证文件相同。

例如，您可以将许可证文件名更改为 *Aspose.Slides.Android.via.Java.lic.xml*。然后，在代码中，必须将指向该文件的路径（以 *Aspose.Slides.Android.via.Java.lic.xml* 结尾）传递给 [SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) 方法。

{{% /alert %}}

### **流**

您可以从流中加载许可证。以下 Java 代码展示了如何从流中应用许可证：
``` java
// 实例化 License 类
com.aspose.slides.License license = new com.aspose.slides.License();

// 通过流设置许可证
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```


## **验证许可证**

要检查许可证是否已正确设置，您可以对其进行验证。以下 Java 代码展示了如何验证许可证：
```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```


## **线程安全**

{{% alert title="Note" color="warning" %}} 

[SetLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) 方法不是线程安全的。如果需要在多个线程中同时调用此方法，建议使用同步原语（例如锁）以避免问题。 

{{% /alert %}}

## **常见问题**

**我可以在完全离线的环境（没有互联网访问）中应用许可证吗？**

可以。许可证验证在本地使用许可证文件完成，无需互联网连接。

**一年订阅到期后会怎样？库会停止工作吗？**

不会。许可证是永久有效的：您仍然可以使用订阅结束日期之前发布的版本，只是如果不续订则无法使用更新的版本。