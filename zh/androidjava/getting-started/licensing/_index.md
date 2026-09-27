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
description: "在 Aspose.Slides for Android via Java 中应用、管理和排除许可证问题。通过我们的授权指南确保持续访问完整功能。"
---
## **概述**

Aspose.Slides 可以在评估模式或使用有效许可证的情况下使用。评估版本提供与授权版本相同的功能，但它会在每个演示文稿的每张幻灯片上添加评估水印，并截断代码从演示文稿读取的文本。

本文阐述了 Aspose.Slides 中的授权机制以及在使用库之前如何应用许可证。可以使用 [许可证](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/license/) 类从文件、流或嵌入资源加载许可证。本文还展示了如何验证许可证是否已正确应用。

## **评估 Aspose.Slides**

{{% alert color="info" title="Note" %}}
您可以从其 [下载页面](https://releases.aspose.com/slides/zh/androidjava/) 下载 **Aspose.Slides for Android via Java** 的评估版。评估版提供与产品授权版相同的功能。评估包与已购买的包相同。只需在代码中添加几行以应用许可证，评估版即可转为授权版。

当您对 **Aspose.Slides** 的评估满意后，可以 [购买许可证](https://purchase.aspose.com/pricing/slides/zh/android-java/)。我们建议您了解不同的订阅类型。如有疑问，请联系 Aspose 销售团队。

每个 Aspose 许可证都附带一年订阅，可免费升级至订阅期内发布的新版本或修复程序。拥有授权产品（甚至评估版）的用户可获得免费且无限制的技术支持。
{{% /alert %}} 

**评估版限制**

* 评估版（未指定许可证）提供完整的产品功能，但会在每个演示文稿的每张幻灯片上添加评估水印文本框。
* 代码从演示文稿读取的文本会被截断为前几个字符，并附加评估限制的提示。代码写入的文本会完整保存。

{{% alert color="info" title="Note" %}}
要在没有限制的情况下测试 Aspose.Slides，您可以申请 **30 天临时许可证**。更多信息请参阅 [如何获取临时许可证](https://purchase.aspose.com/temporary-license) 页面。
{{% /alert %}}

## **Aspose.Slides 授权**

* 购买许可证并在代码中添加几行以应用许可证后，评估版即转为授权版。
* 许可证是包含产品名称、授权开发者数量、订阅到期日期等细节的纯文本 XML 文件。
* 许可证文件经过数字签名，必须保持原样。即使不小心在文件内容中添加额外的换行也会导致其失效。
* Aspose.Slides for Android via Java 通常会在以下位置查找许可证：
  * 明确的路径
  * 包含 Aspose.Slides.jar 的文件夹
* 为避免评估版的限制，需在使用 **Aspose.Slides** 前设置许可证。每个应用或进程只需设置一次许可证。

## **应用许可证**

可以从 **文件** 或 **流** 加载许可证。

{{% alert color="info" title="Note" %}}
Aspose.Slides 提供了用于授权操作的 [许可证](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/license/) 类。
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
新许可证只能在 21.4 或更高版本的 Aspose.Slides 中激活。更早版本使用不同的授权系统，无法识别这些许可证。
{{% /alert %}}

### **文件**

设置许可证的最简方法是将许可证文件放置在包含 Aspose.Slides.jar 或您应用的 jar 的文件夹中。

{{% alert color="info" title="Note" %}}
在 Android 上，库和应用会打包成 APK，因此不存在包含库的 JAR 文件的文件夹，类似 *Aspose.Slides.Android.via.Java.lic* 的相对路径并不会指向应用中的文件。请将许可证文件添加到应用的 assets 中，并从流加载，如 [从应用资产加载流](#stream-from-app-assets) 所示。
{{% /alert %}}

以下 Java 代码演示如何设置许可证文件：

``` java
// 实例化 License 类
com.aspose.slides.License license = new com.aspose.slides.License();

// 设置许可证文件路径
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
如果将许可证文件放在其他目录，在调用 [setLicense](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) 方法时，指定路径末尾的许可证文件名必须与实际许可证文件名一致。

例如，您可以将许可证文件名改为 *Aspose.Slides.Android.via.Java.lic.xml*。随后在代码中，需要将指向该文件的路径（以 *Aspose.Slides.Android.via.Java.lic.xml* 结尾）传递给 [setLicense](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) 方法。
{{% /alert %}}

### **流**

可以从流加载许可证。以下 Java 代码演示如何从流应用许可证：

``` java
// 实例化 License 类
com.aspose.slides.License license = new com.aspose.slides.License();

// 通过流设置许可证
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **从应用资产加载流**

在 Android 应用中，将许可证文件放置于应用模块的 *assets* 文件夹，即 *app/src/main/assets*，以便随 APK 打包。使用 [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) 方法打开文件并将流传递给 [setLicense](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) 方法。该代码在 `Activity` 中运行，例如在其 `onCreate` 方法中，在应用使用 Aspose.Slides 之前：

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

传递给 [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) 方法的文件名是相对于 *assets* 文件夹的。如果文件不存在，代码会记录错误，Aspose.Slides 将保持评估模式。要检查许可证是否已应用，请参阅 [验证许可证](#validating-a-license)。

## **验证许可证**

要检查许可证是否已正确设置，可对其进行验证。以下 Java 代码演示如何验证许可证：

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **线程安全**

{{% alert color="warning" title="Warning" %}}
[setLicense](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) 方法不是线程安全的。如果该方法需要被多个线程同时调用，建议使用同步原语（例如锁）以避免问题。
{{% /alert %}}

## **常见问题**

### 我可以在完全离线的环境（无互联网访问）中应用许可证吗？

可以。许可证验证在本地使用许可证文件完成，无需互联网连接。

### 一年订阅到期后会怎样？库会停止工作吗？

不会。许可证为永久授权：您可以继续使用订阅结束日期之前发布的版本，只是如果不续订，将无法使用更高版本的发布。