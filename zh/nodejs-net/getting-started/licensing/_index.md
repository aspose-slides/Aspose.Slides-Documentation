---
title: 许可信息
description: "Aspose.Slides for Node.js via .NET 提供不同的购买计划，或提供免费试用和 30 天临时许可证以供评估，遵循许可和订阅政策。"
type: docs
weight: 80
url: /zh/nodejs-net/licensing/
---

有时，为获得最佳评估结果，可能需要动手实践。因此，Aspose.Slides 提供不同的购买计划，同时也提供免费试用和 30 天临时许可证以供评估。

{{% alert color="primary" %}}

请注意，有一些一般政策和实践指导您如何评估、正确许可和购买我们的产品。您可以在 ["购买政策和常见问题"](https://purchase.aspose.com/policies) 部分找到它们。

{{% /alert %}}

## **评估 Aspose.Slides**
您可以轻松下载 Aspose.Slides 进行评估。评估包与购买的包相同。评估版本在您添加几行代码以应用许可证后，便会变为已许可版本。

## **评估版本限制**
Aspose.Slides 的评估版本（未指定许可证）提供完整的产品功能，但在打开和保存文档时，会在文档顶部插入评估水印。您在从演示文稿中提取文本时也仅限于一张幻灯片。

{{% alert color="primary" %}} 

如果您想在没有评估版本限制的情况下测试 Aspose.Slides，可以申请 **30 天临时许可证**。有关更多信息，请参阅 [如何获取临时许可证？](https://purchase.aspose.com/temporary-license)。

{{% /alert %}} 

## **关于许可证**
您可以轻松从其 [下载页面](https://releases.aspose.com/slides/nodejs-net/) 下载 Aspose.Slides 的评估版本。评估版本提供与 Aspose.Slides 的已许可版本绝对相同的功能。此外，评估版本在您购买许可证并添加几行代码以应用许可证后便会变为已许可版本。

许可证是一个纯文本 XML 文件，其中包含产品名称、许可给的开发者数量、订阅到期日期等详细信息。该文件是经过数字签名的，因此请勿修改该文件。即使不小心向文件内容中添加额外的换行符也会使其无效。

为了避免与评估版本相关的限制，您需要在使用 **Aspose.Slides** 之前设置许可证。每个应用程序或进程只需设置一次许可证。

## 已购买许可证

购买后，您需要应用许可证文件或流。

{{% alert color="primary" %}}

您需要设置许可证：
* 每个应用程序域仅设置一次
* 在使用任何其他 Aspose.Slides 类之前

{{% /alert %}}

{{% alert color="primary" %}}

您可以在 [“定价信息”](https://purchase.aspose.com/pricing/slides/family) 页面找到定价信息。

{{% /alert %}}

### **在 Aspose.Slides for Node.js via .NET 中设置许可证**

许可证可以从以下位置应用：

* 显式路径
* 流
* 作为计量许可证 – 一种新的许可机制

{{% alert color="primary" %}}

使用 **setLicense** 方法为组件设置许可证。

虽然多次调用 **setLicense** 不会造成危害，但会浪费资源（处理器）。

{{% /alert %}}

#### **使用文件应用许可证**

以下代码片段用于设置许可证文件：

**Node.js**

```javascript
// 导入用于 PowerPoint 文件操作的 Aspose.Slides 模块
const asposeSlides = require('aspose.slides.via.net');

// 此函数设置 Aspose.Slides 库的许可证
function setupAsposeSlidesLicense() {
	
    // 从 Aspose.Slides 模块初始化许可证类
    var license = new asposeSlides.License();
    
    // 从文件应用许可证
    // 将 "your_license_file.lic" 替换为您实际许可证文件的路径
    license.setLicense("your_license_file.lic");
}

// 执行函数以设置 Aspose.Slides 的许可证
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}

在调用 setLicense 方法时，许可证名称应与您的许可证文件名称相同。例如，您可以将许可证文件名称更改为 "Aspose.Slides.lic.xml"。然后，在您的代码中，您必须将新的许可证名称（Aspose.Slides.lic.xml）传递给 setLicense 方法。

{{% /alert %}}