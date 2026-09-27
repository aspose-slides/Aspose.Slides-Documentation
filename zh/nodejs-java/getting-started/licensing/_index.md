---
title: 许可
type: docs
weight: 80
url: /zh/nodejs-java/licensing/
keywords:
- 许可证
- 临时许可证
- 设置许可证
- 使用许可证
- 验证许可证
- 许可证文件
- 评估版本
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中应用、管理和排除许可证问题。通过我们的分步授权指南，确保持续访问全部功能。"
---
## **简介**

有时，为了获得最佳评估结果，可能需要动手实践。为此，Aspose.Slides 提供了多种购买方案，并提供免费试用和 30 天临时许可证用于评估。

{{% alert color="info" title="Note" %}}
请注意，有许多通用政策和实践指引您如何评估、正确授权以及购买我们的产品。您可以在[“购买政策与常见问答”](https://purchase.aspose.com/policies) 部分找到它们。
{{% /alert %}}

## **评估 Aspose.Slides**
您可以轻松下载 Aspose.Slides 进行评估。评估包与购买包相同。只需添加几行代码来应用许可证，评估版即可转为已授权。

## **评估版本的限制**
Aspose.Slides 的评估版本（未指定许可证）提供完整的产品功能，但有两项限制：

* 它会在每个保存的演示文稿的每张幻灯片上添加一个评估水印文本框。
* 从演示文稿读取的文本若超过五个字符，会被截断为前五个字符，并附加 `... text has been truncated due to evaluation version limitation.`；五个字符或以下的文本保持不变，代码写入的文本则完整保存。

{{% alert color="info" title="Note" %}}
如果您想在不受评估版本限制的情况下测试 Aspose.Slides，可以申请 **30 天临时许可证**。有关更多信息，请参阅[如何获取临时许可证？](https://purchase.aspose.com/temporary-license)。
{{% /alert %}}

## **关于许可证**
您可以从其[下载页面](https://releases.aspose.com/slides/nodejs-java/)轻松下载 Aspose.Slides for Node.js via Java 的评估版本。该评估版本具备与授权版本相同的功能，只是存在上述限制。除此之外，购买许可证并添加几行代码来应用许可证后，评估版本即可转为已授权。

许可证是一个纯文本 XML 文件，包含产品名称、授权开发者数量、订阅到期日期等信息。文件经过数字签名，请勿修改文件。即使意外在文件内容中添加额外的换行也会导致其失效。

为避免评估版本的限制，您需要在使用 **Aspose.Slides** 之前设置许可证。每个应用程序或进程只需设置一次许可证。

{{% alert color="info" title="Note" %}}
您可能想查看[计量授权](/slides/zh/nodejs-java/metered-licensing/)。
{{% /alert %}}

## **已购许可证**

购买后，您需要应用许可证文件或流。

{{% alert color="info" title="Note" %}}
您需要设置许可证：
* 每个进程仅一次
* 在使用任何其他 Aspose.Slides 类之前
{{% /alert %}}

{{% alert color="info" title="Note" %}}
您可以在[“定价信息”](https://purchase.aspose.com/pricing/slides/family) 页面找到定价信息。
{{% /alert %}}

### **在 Aspose.Slides for Node.js via Java 中设置许可证**

许可证可从以下位置应用：

* 显式路径
* 流
* 作为计量许可证 – 一种新的授权机制

{{% alert color="info" title="Note" %}}
使用 **setLicense** 方法为组件授权。

虽然多次调用 **setLicense** 并不会造成错误，但会浪费资源（处理器）。
{{% /alert %}}

#### **使用文件应用许可证**

以下代码片段用于设置许可证文件：

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides 在保持 Node.js 运行的 Java 虚拟机中运行，因此需要显式结束进程。
process.exit(0);
```

调用 setLicense 方法时，许可证名称应与许可证文件的名称相同。例如，您可以将许可证文件名更改为 "Aspose.Slides.lic.xml"。随后，在代码中必须将新许可证名 (Aspose.Slides.lic.xml) 传递给 setLicense 方法。如果文件缺失或不包含有效的许可证，[setLicense](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/) 将抛出异常，导致脚本错误结束。

#### **从流中应用许可证**

要从流中应用许可证，请将 [License](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/) 对象和可读流传递给静态的 [setLicenseFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/) 方法。该流会异步读取，如果流中不包含有效许可证，回调将收到错误：

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides 在保持 Node.js 运行的 Java 虚拟机中运行，因此需要显式结束进程。
    process.exit(0);
});
```

许可证会在整个流读取完毕后、回调执行前应用，因此请在回调中开始其他 Aspose.Slides 的工作。

两个示例在完成后调用 `process.exit(0)`，因为运行 Aspose.Slides 的 Java 虚拟机会保持 Node.js 运行。在实际应用中，请继续执行您的 Aspose.Slides 代码，而不是结束进程。

## **常见问题**

### 我可以在完全离线的环境（无互联网访问）中应用许可证吗？

可以。许可证验证在本地使用许可证文件完成，无需互联网连接。

### 一年订阅到期后会怎样？库会停止工作吗？

不会。许可证是永久的：您可以继续使用在订阅结束日期之前发布的版本；仅在未续订的情况下，无法使用更新的版本。