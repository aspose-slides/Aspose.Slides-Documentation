---
title: 许可
description: "Aspose.Slides for Node.js via Java 提供多种购买计划，或提供免费试用和 30 天临时许可，以通过许可和订阅政策进行评估。"
type: docs
weight: 80
url: /zh/nodejs-java/licensing/
---

有时，为了获得最佳评估结果，可能需要亲自操作。因此，Aspose.Slides 提供多种购买计划，并提供免费试用和 30 天临时许可进行评估。

{{% alert color="primary" %}}
请注意，有许多通用政策和实践可指导您如何评估、正确授权以及购买我们的产品。您可以在[购买政策和常见问答](https://purchase.aspose.com/policies)章节中找到它们。
{{% /alert %}}

## **评估 Aspose.Slides**
您可以轻松下载 Aspose.Slides 进行评估。评估包与已购包相同。只需添加几行代码应用许可，评估版本即自动获得授权。

## **评估版本限制**
Aspose.Slides（未指定许可）的评估版本提供完整功能，但在打开和保存文档时会在文档顶部插入评估水印。提取演示文稿文字时也仅限于一张幻灯片。

{{% alert color="primary" %}} 
如果您想在没有评估版本限制的情况下测试 Aspose.Slides，可以请求 **30 天临时许可**。请参阅[如何获取临时许可？](https://purchase.aspose.com/temporary-license)了解更多信息。
{{% /alert %}} 

## **关于许可**
您可以从其[下载页面](https://releases.aspose.com/slides/nodejs-java/)轻松下载 Aspose.Slides for Node.js via Java 的评估版。评估版提供与授权版 **完全相同的功能**。此外，购买许可并添加少量代码后，评估版即可获得授权。

许可是一个纯文本 XML 文件，包含产品名称、授权的开发者数量、订阅到期日期等详细信息。该文件已数字签名，请勿修改文件内容。即使是无意中添加额外的换行也会导致文件失效。

为避免评估版的限制，您需要在使用 **Aspose.Slides** 前设置许可。每个应用程序或进程只需设置一次许可。

{{% alert color="primary" %}} 
您可能想查看[计量许可](https://docs.aspose.com/slides/nodejs-java/metered-licensing/)。
{{% /alert %}} 

## **已购买许可**

购买后，您需要应用许可文件或流。

{{% alert color="primary" %}}
您需要设置许可：
* 每个应用程序域仅一次
* 在使用任何其他 Aspose.Slides 类之前
{{% /alert %}}

{{% alert color="primary" %}}
您可以在[“定价信息”](https://purchase.aspose.com/pricing/slides/family)页面查看定价信息。
{{% /alert %}}

### **在 Aspose.Slides for Node.js via Java 中设置许可**

可以从以下位置应用许可：

* 明确路径
* 流
* 计量许可——一种新许可机制

{{% alert color="primary" %}}
使用 **setLicense** 方法对组件进行授权。

多次调用 **setLicense** 并不会造成错误，但会浪费资源（处理器）。
{{% /alert %}}

{{% alert color="warning" %}}
新许可仅能在 21.4 版本或更高版本的 Aspose.Slides 中激活。早期版本使用不同的许可系统，无法识别这些许可。
{{% /alert %}}

#### **使用文件应用许可**

以下代码片段用于设置许可文件：

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

调用 setLicense 方法时，许可名称应与您的许可文件名称相同。例如，您可以将许可文件名改为 "Aspose.Slides.lic.xml"。随后，在代码中必须将新许可名称 (Aspose.Slides.lic.xml) 传递给 setLicense 方法。

#### **从流应用许可**

以下代码片段用于从流应用许可：

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

**我可以在完全离线的环境（无互联网访问）下应用许可吗？**

可以。许可验证在本地使用许可文件完成，无需互联网连接。

**一年订阅到期后会怎样？库会停止工作吗？**

不会。许可是永久的：您可以继续使用订阅结束日期之前发布的版本；只是如果不续订，则无法使用更高版本的发布。