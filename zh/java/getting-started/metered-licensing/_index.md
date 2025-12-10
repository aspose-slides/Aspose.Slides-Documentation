---
title: 计量授权
type: docs
weight: 100
url: /zh/java/metered-licensing/
keywords:
- 许可证
- 计量许可证
- 许可证密钥
- 公钥
- 私钥
- 消耗数量
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 计量授权如何让您灵活处理 PowerPoint 和 OpenDocument 文件，仅为实际使用付费。"
---

## **应用计量密钥**

{{% alert color="primary" %}} 

计量授权是一种可以与现有授权方式一起使用的新授权机制。如果您希望根据使用 Aspose.Slides API 功能的情况计费，则选择计量授权。

购买计量授权后，您将获得密钥（而不是授权文件）。此计量密钥可以使用 Aspose 提供的用于计量操作的 [计量](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) 类来应用。更多详情，请参阅 [计量授权常见问题](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 

1. 创建 [计量](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) 类的实例。

2. 将您的公钥和私钥传递给 [setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) 方法。

3. 执行一些处理（执行任务）。

4. 调用 `Metered` 类的 [getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--) 方法。

您应该可以看到截至目前已消耗的 API 请求的数量/额度。

下面的示例代码展示了如何使用计量授权：

```java
// Creates an instance of the Metered class
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Passes the public and private keys to the Metered object
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Gets the consumed quantity value before API calls
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Do something with Aspose.Slides API here
    // ...

    // Gets the consumed quantity value after API calls
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

使用计量授权时，需要可靠的互联网连接，因为授权机制会持续通过互联网与我们的服务交互并进行计费计算。

{{% /alert %}} 

## **常见问题**

**我可以在同一应用程序中同时使用计量授权和常规授权（永久或临时）吗？**

可以。计量是一种可与现有 [授权方式](/slides/zh/java/licensing/) 并存的附加授权机制。您可以在应用启动时选择使用哪种机制。

**在计量授权下，具体计费依据是什么：操作次数还是文件数量？**

计费依据是 API 使用量，即请求次数或操作次数。您可以通过 [消耗跟踪方法](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) 获取当前消耗量。

**计量授权适用于实例经常重启的微服务和无服务器环境吗？**

适用。由于计费在 API 调用层面进行，只要网络稳定，能够进行计量计算，即可兼容频繁的冷启动场景。

**使用计量授权时，库的功能是否会与永久授权有所不同？**

不会。计量授权仅影响授权和计费机制，产品功能保持一致。

**计量授权与试用版和临时授权有什么关系？**

试用版有功能限制和水印，[临时授权](https://purchase.aspose.com/temporary-license/) 可在 30 天内解除限制，计量授权则在解除限制的同时根据实际使用量计费。

**我可以通过自动响应消耗阈值超限来控制预算吗？**

可以。常见做法是定期通过 [跟踪方法](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) 读取当前消耗量，并在应用或监控层面实现自定义的限制或告警。