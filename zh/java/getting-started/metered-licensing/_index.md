---
title: 计量授权
type: docs
weight: 100
url: /zh/java/metered-licensing/
keywords:
- 许可证
- 计量授权
- 许可证密钥
- 公钥
- 私钥
- 消耗数量
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 的计量授权如何让您灵活处理 PowerPoint 和 OpenDocument 文件，仅为实际使用的部分付费。"
---
## **介绍**

计量授权是一种可以与现有授权方法一起使用的授权机制。若希望根据使用 Aspose.Slides API 功能的情况计费，请选择计量授权。

## **应用计量密钥**

{{% alert color="info" %}} 

计量授权是一种可以与现有授权方法一起使用的授权机制。若希望根据使用 Aspose.Slides API 功能的情况计费，请选择计量授权。

购买计量授权后，您将获得密钥（而不是授权文件）。此计量密钥可通过 Aspose 为计量操作提供的 [Metered](https://reference.aspose.com/slides/zh/java/com.aspose.slides/metered/) 类进行应用。更多细节请参阅 [计量授权常见问题](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 

1. 创建 [Metered](https://reference.aspose.com/slides/zh/java/com.aspose.slides/metered/) 类的实例。

1. 将您的公钥和私钥传递给 [setMeteredKey](https://reference.aspose.com/slides/zh/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) 方法。

1. 执行一些处理（执行任务）。

1. 调用 `Metered` 类的 [getConsumptionQuantity](https://reference.aspose.com/slides/zh/java/com.aspose.slides/metered/#getConsumptionQuantity--) 方法。

您应该能够看到截至目前已消耗的 API 请求数量/额度。

以下示例代码展示了如何使用计量授权：

```java
// 创建 Metered 类的实例
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // 将公钥和私钥传递给 Metered 对象
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // 获取 API 调用前的已消耗数量值
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // 在此使用 Aspose.Slides API 进行一些操作
    // ...

    // 获取 API 调用后的已消耗数量值
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

使用计量授权时，需要稳定的互联网连接，因为授权机制会持续通过网络与我们的服务交互并进行计费计算。

{{% /alert %}} 

## **常见问题**

### 我可以在同一应用程序中同时使用计量授权和常规授权（永久或临时）吗？

可以。计量授权是一种可与现有 [授权方法](/slides/zh/java/licensing/) 同时使用的附加授权机制。您可以在应用程序启动时选择使用哪种机制。

### 在计量授权下，具体计费的是操作还是文件？

计费基于 API 使用量，即请求或操作的次数。您可以通过 [消耗跟踪方法](https://reference.aspose.com/slides/zh/java/com.aspose.slides/metered/) 获取当前的消耗量。

### 计量授权适用于实例频繁重启的微服务和无服务器环境吗？

适用。由于计费在 API 调用层面进行，只要网络能够稳定访问计量计算服务，即可兼容频繁的冷启动场景。

### 使用计量授权时，库的功能是否与永久授权有所不同？

没有。计量授权只影响授权和计费机制，产品的功能保持一致。

### 计量授权与试用版、临时授权有什么关系？

试用版有功能限制和水印，[临时授权](https://purchase.aspose.com/temporary-license/) 可在 30 天内解除限制，而计量授权则在解除限制的同时根据实际使用量计费。

### 我能否通过自动响应来控制预算，例如在超过消耗阈值时采取措施？

可以。常用做法是定期通过 [跟踪方法](https://reference.aspose.com/slides/zh/java/com.aspose.slides/metered/) 读取当前消耗量，并在应用程序或监控层面实现自定义的限制或警报。