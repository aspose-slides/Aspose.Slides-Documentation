---
title: 计量授权
type: docs
weight: 100
url: /zh/nodejs-java/metered-licensing/
keywords:
- 许可证
- 计量授权
- Node.js
- Java
- Aspose.Slides for Node.js via Java
---

## **应用计量密钥**

{{% alert color="primary" %}} 

计量授权是一种全新的授权机制，可与现有授权方式一起使用。如果您希望根据对 Aspose.Slides API 功能的使用情况计费，请选择计量授权。

购买计量授权后，您将获得密钥（而不是授权文件）。可以使用 Aspose 为计量操作提供的 [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) 类来应用此计量密钥。有关详细信息，请参阅 [计量授权常见问题](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 

1. 创建 [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) 类的实例。

1. 将您的公钥和私钥传递给 [setMeteredKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#setMeteredKey) 方法。

1. 执行一些处理（执行任务）。

1. 调用 `Metered` 类的 [getConsumptionQuantity](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) 方法。

您应该可以看到迄今为止已消耗的 API 请求数量/额度。

以下示例代码演示如何使用计量授权：
```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 创建 Metered 类的实例
var metered = new aspose.slides.Metered();

// 将公钥和私钥传递给 Metered 对象
metered.setMeteredKey("<valid public key>", "<valid private key>");

// 在 API 调用之前获取已消耗的数量值
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// 在此处使用 Aspose.Slides API 做一些操作
// ...

// 在 API 调用之后获取已消耗的数量值
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```


{{% alert color="warning" title="注意" %}} 

使用计量授权需要稳定的互联网连接，因为授权机制会通过互联网持续与我们的服务交互并进行计费计算。

{{% /alert %}} 

## **常见问题**

**我可以在同一应用程序中同时使用计量授权和常规授权（永久或临时）吗？**

可以。计量授权是一种可与现有 [授权方法](/slides/zh/nodejs-java/licensing/) 并行使用的附加授权机制。您可以在应用程序启动时选择使用哪种机制。

**计量授权的消耗到底是怎么计数的：操作还是文件？**

计量基于 API 使用量，即请求或操作的次数。您可以通过 [消耗跟踪方法](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) 获取当前消耗量。

**计量授权适用于实例频繁重启的微服务和无服务器环境吗？**

适用。由于计费是在 API 调用层面进行的，只要网络访问稳定以便进行计量计算，频繁的冷启动场景也兼容。

**使用计量授权时，库的功能与永久授权有区别吗？**

没有。这仅涉及授权和计费机制，产品功能保持不变。

**计量授权与试用版和临时授权有什么关系？**

试用版有功能限制和水印，[临时授权](https://purchase.aspose.com/temporary-license/) 可在 30 天内解除这些限制，而计量授权同样解除限制，但费用按实际使用量计收。

**我能否通过自动触发在超出消耗阈值时进行预算控制？**

可以。常见做法是定期通过 [跟踪方法](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) 读取当前消耗量，并在应用程序或监控层面实现自定义的限制或警报。