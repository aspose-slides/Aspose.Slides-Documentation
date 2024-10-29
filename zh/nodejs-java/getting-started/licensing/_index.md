---
title: 许可证
description: "Aspose.Slides for Node.js via Java 提供不同的购买计划，或者提供免费试用和 30 天临时许可证供评估使用许可和订阅政策。"
type: docs
weight: 80
url: /zh/nodejs-java/licensing/
---

有时，为了获得最佳的评估结果，可能需要亲手操作。因此，Aspose.Slides 提供了不同的购买计划，并且还提供免费试用和 30 天临时许可证用于评估。

{{% alert color="primary" %}}

请注意，有一些通用政策和实践可以指导您如何评估、正确授权和购买我们的产品。您可以在 ["购买政策和常见问题解答"](https://purchase.aspose.com/policies) 部分找到它们。

{{% /alert %}}

## **评估 Aspose.Slides**
您可以轻松下载 Aspose.Slides 进行评估。评估包与购买包相同。评估版本在您添加几行代码以应用许可证后，简单地变为已授权。

## **评估版本限制**
Aspose.Slides 的评估版本（未指定许可证）提供完整的产品功能，但在打开和保存文档时会在文件顶部插入评估水印。您在提取演示文稿幻灯片的文本时也限制为一张幻灯片。

{{% alert color="primary" %}} 

如果您希望在没有评估版本限制的情况下测试 Aspose.Slides，您可以申请 **30 天临时许可证**。有关更多信息，请参阅 [如何获得临时许可证？](https://purchase.aspose.com/temporary-license)。

{{% /alert %}} 

## **关于许可证**
您可以轻松从 [下载页面](https://releases.aspose.com/slides/nodejs-java/) 下载 Aspose.Slides for Node.js via Java 的评估版本。评估版本提供与 Aspose.Slides 的许可版本**完全相同的功能**。此外，评估版本在您购买许可证并添加几行代码以应用许可证后，简单地变为已授权。

许可证是一个纯文本 XML 文件，包含产品名称、授权开发人员数量、订阅过期日期等详细信息。该文件是数字签名的，因此请勿修改该文件。即便是不经意地在文件内容中添加额外的换行符也会使其失效。

要避免与评估版本相关的限制，您需要在使用 **Aspose.Slides** 之前设置许可证。每个应用程序或进程只需设置一次许可证。

## 购买许可证

购买后，您需要应用许可证文件或流。

{{% alert color="primary" %}}

您需要设置许可证：
* 每个应用程序域仅一次
* 在使用任何其他 Aspose.Slides 类之前

{{% /alert %}}

{{% alert color="primary" %}}

您可以在 [“定价信息”](https://purchase.aspose.com/pricing/slides/family) 页面上找到定价信息。

{{% /alert %}}

### **在 Aspose.Slides for Node.js via Java 中设置许可证**

可以从以下位置应用许可证：

* 显式路径
* 流
* 作为计量许可证–一种新的许可机制

{{% alert color="primary" %}}

使用 **setLicense** 方法来给组件授权。

虽然多次调用 **setLicense** 没有害处，但会浪费资源（处理器）。

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

调用 setLicense 方法时，许可证名称应与许可证文件的名称相同。例如，您可以将许可证文件名更改为 "Aspose.Slides.lic.xml"。然后，在您的代码中，必须将新的许可证名称（Aspose.Slides.lic.xml）传递给 setLicense 方法。

#### **从流应用许可证**

此代码片段用于从流应用许可证：

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

#### 应用计量许可证

Aspose.Slides 允许开发人员应用计量密钥。这是一种新的许可机制。

新的许可机制将与现有的许可方法一起使用。希望根据 API 功能使用情况计费的客户可以使用计量许可证。

完成所有获取此类型许可证的必要步骤后，您将收到密钥，而不是许可证文件。此计量密钥可以使用专门为此目的引入的 **Metered** 类进行应用。

以下代码示例展示了如何设置计量的公开和私有密钥：

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

# 创建 CAD Metered 类的实例
var metered = new aspose.slides.Metered();

# 访问 set_metered_key 属性，并将公开和私有密钥作为参数传递
metered.setMeteredKey("*****", "*****");

# 在调用 API 之前获取计量数据量
var amountbefore = aspose.slides.Metered.getConsumptionQuantity();
# 显示信息
console.log('使用量在之前: " + amountbefore + "' );

# 从磁盘加载文档
var pres = new aspose.slides.Presentation();
# 获取文档的页数
console.log('使用量在之后: " +  pres.getSlides().size()) + "' );
# 保存为 PDF
pres.save("out_pdf.pdf", aspose.slides.SaveFormat.Pdf);

# 在调用 API 之后获取计量数据量
var amountafter = aspose.slides.Metered.getConsumptionQuantity();
# 显示信息
console.log('使用量在之后: " + amountafter + "' );
```

{{% alert color="primary" %}}

请注意，您必须拥有稳定的互联网连接，以便正确使用计量许可证，因为计量机制需要与我们的服务进行持续交互以进行正确计算。有关更多详细信息，请参见 [“计量许可证常见问题解答”](https://purchase.aspose.com/faqs/licensing/metered) 部分。

{{% /alert %}}