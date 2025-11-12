---
title: 计量授权
type: docs
weight: 100
url: /zh/nodejs-java/metered-licensing/
keywords:
- 授权
- 计量授权
- Node.js
- Java
- Aspose.Slides for Node.js via Java
---

## **应用计量密钥**

{{% alert color="primary" %}} 

计量授权是一种新的授权机制，可与现有授权方式一起使用。如果您希望根据对 Aspose.Slides API 功能的使用量计费，请选择计量授权。

购买计量授权后，您将获得密钥（而不是授权文件）。可以使用 Aspose 为计量操作提供的 [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) 类来应用此计量密钥。有关更多详情，请参阅 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 

1. 创建一个 [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) 类的实例。

2. 将您的公共密钥和私有密钥传递给 [setMeteredKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#setMeteredKey) 方法。

3. 执行一些处理（执行任务）。

4. 调用 `Metered` 类的 [getConsumptionQuantity](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) 方法。

您应该会看到截至目前已消耗的 API 请求数量/额度。

以下示例代码演示了如何使用计量授权：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 创建 Metered 类的实例
var metered = new aspose.slides.Metered();

// 将公共密钥和私有密钥传递给 Metered 对象
metered.setMeteredKey("<valid public key>", "<valid private key>");

// 在 API 调用前获取已消耗的数量值
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// 在此处使用 Aspose.Slides API 执行操作
// ...

// 在 API 调用后获取已消耗的数量值
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="注意"  %}} 

使用计量授权时，需要稳定的互联网连接，因为授权机制会通过互联网持续与我们的服务交互并进行计费计算。

{{% /alert %}} 

## **常见问题**

**我可以在同一应用程序中同时使用计量授权和常规授权（永久或临时）吗？**

可以。计量授权是一种可与现有 [授权方式](/slides/zh/nodejs-java/licensing/) 并行使用的附加授权机制。您可以在应用程序启动时选择使用哪种机制。

**在计量授权下，具体计费的对象是操作还是文件？**

计费基于 API 使用量，即请求或操作的次数。您可以通过 [消费跟踪方法](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) 获取当前的消费量。

**计量授权适用于实例经常重启的微服务和无服务器环境吗？**

适用。由于计费在 API 调用层面完成，频繁的冷启动场景是兼容的，只要能保持稳定的网络连接以进行计量计算。

**使用计量授权与使用永久授权时，库的功能是否有差异？**

没有。这仅涉及授权和计费机制，产品的功能保持一致。

**计量授权与试用版和临时授权有什么关系？**

试用版有功能限制和水印，[临时授权](https://purchase.aspose.com/temporary-license/) 可在 30 天内去除限制，计量授权则在去除限制的同时根据实际使用量计费。

**我可以通过自动响应消费阈值超过来控制预算吗？**

可以。常见做法是定期通过 [跟踪方法](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) 读取当前消费量，并在应用或监控层自行实现限制或警报。