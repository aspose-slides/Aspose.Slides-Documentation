---
title: 许可
description: "Aspose.Slides for Node.js via Java 提供多种购买计划，或提供免费试用和 30 天临时许可证，用于根据许可和订阅策略进行评估。"
type: docs
weight: 80
url: /zh/nodejs-java/licensing/
---

有时，为了获得最佳评估结果，可能需要亲自操作。为此，Aspose.Slides 提供了不同的购买计划，并提供免费试用和 30 天临时许可证供评估。

{{% alert color="primary" %}}
请注意，有多项通用政策和实践指导您如何评估、正确授权以及购买我们的产品。您可以在["Purchase Policies and FAQ"](https://purchase.aspose.com/policies) 部分找到它们。
{{% /alert %}}

## **评估 Aspose.Slides**
您可以轻松下载 Aspose.Slides 进行评估。评估包与购买的包相同。只要添加几行代码来应用许可证，评估版就会变为已授权。

## **评估版限制**
Aspose.Slides 的评估版（未指定许可证）提供完整的产品功能，但在打开和保存文档时会在文档顶部插入评估水印。提取演示文稿文本时也仅限于一张幻灯片。

{{% alert color="primary" %}}
如果您想在不受评估版限制的情况下测试 Aspose.Slides，可以申请 **30 天临时许可证**。详情请参阅[How to get a Temporary License?](https://purchase.aspose.com/temporary-license)。
{{% /alert %}}

## **关于许可证**
您可以通过 Java 从其[download page](https://releases.aspose.com/slides/nodejs-java/)轻松下载 Aspose.Slides for Node.js 的评估版。评估版提供与授权版完全 **相同的功能**。此外，在购买许可证并添加几行代码以应用许可证后，评估版即可转为已授权。

许可证是一个纯文本 XML 文件，包含产品名称、授权给的开发人员数量、订阅到期日期等详细信息。该文件经过数字签名，请勿修改。即使无意中在文件内容中添加额外的换行也会导致其无效。

为避免评估版的限制，您需要在使用 **Aspose.Slides** 之前设置许可证。每个应用程序或进程只需设置一次许可证。

{{% alert color="primary" %}}
您可能想了解[Metered Licensing](https://docs.aspose.com/slides/nodejs-java/metered-licensing/)。
{{% /alert %}}

## **已购许可证**

购买后，您需要应用许可证文件或流。

{{% alert color="primary" %}}
您需要设置许可证：
* 每个应用程序域仅一次
* 在使用任何其他 Aspose.Slides 类之前
{{% /alert %}}

{{% alert color="primary" %}}
您可以在[“Pricing Information”](https://purchase.aspose.com/pricing/slides/family)页面找到定价信息。
{{% /alert %}}

### **在 Aspose.Slides for Node.js via Java 中设置许可证**

许可证可以从以下位置应用：

* 明确路径
* 流
* 作为计量许可证 – 一种新授权机制

{{% alert color="primary" %}}
使用 **setLicense** 方法为组件授权。

多次调用 **setLicense** 并不会造成危害，但会浪费资源（处理器）。
{{% /alert %}}

{{% alert color="warning" %}}
新许可证只能在 21.4 版或更高版本激活 Aspose.Slides。早期版本使用不同的授权系统，无法识别这些许可证。
{{% /alert %}}

#### **使用文件应用许可证**

此代码片段用于设置许可证文件：

**Node.js**
```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```


调用 setLicense 方法时，许可证名称应与许可证文件的名称相同。例如，您可以将许可证文件名更改为 "Aspose.Slides.lic.xml"。然后，在代码中，需要将新的许可证名称 (Aspose.Slides.lic.xml) 传递给 setLicense 方法。

#### **通过流应用许可证**

此代码片段用于从流中应用许可证：

**Node.js**
```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```


## **常见问题**

**我能在完全离线的环境（无互联网访问）中应用许可证吗？**

可以。许可证验证在本地使用许可证文件完成，无需互联网连接。

**订阅一年后会怎样？库会停止工作吗？**

不会。许可证是永久有效的：您可以继续使用在订阅结束日期之前发布的版本，只是如果不续订，将无法使用更新的版本。