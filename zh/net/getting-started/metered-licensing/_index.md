---
title: 计量授权
type: docs
weight: 90
url: /zh/net/metered-licensing/
keywords:
- 许可证
- 计量许可证
- 许可证密钥
- 公钥
- 私钥
- 消耗量
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 的计量授权如何让您灵活处理 PowerPoint 和 OpenDocument 文件，仅为实际使用付费。"
---

## **应用计量密钥**

{{% alert color="primary" %}} 

计量授权是一种可与现有授权方式并行使用的新授权机制。如果您希望根据使用 Aspose.Slides API 功能的情况计费，则可以选择计量授权。

购买计量许可证后，您将获得密钥（而不是许可证文件）。此计量密钥可通过 Aspose 提供的用于计量操作的 [计量](https://reference.aspose.com/slides/net/aspose.slides/metered/) 类进行应用。更多详情，请参阅 [计量授权 FAQ](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 

1. 创建 [计量](https://reference.aspose.com/slides/net/aspose.slides/metered/) 类的实例。  
1. 将您的公钥和私钥传递给 [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/) 方法。  
1. 执行一些处理（执行任务）。  
1. 调用 `Metered` 类的 [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) 方法。  

您应该可以看到迄今为止已消耗的 API 请求数量/额度。

下面的示例代码演示了如何使用计量授权：

```cs
// Creates an instance of the Metered class
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Passes the public and private keys to the Metered object
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Gets the metered data quantity before API call
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Do something with Aspose.Slides API here
// ...

// Gets the metered data amount after API call
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 

要使用计量授权，您需要稳定的互联网连接，因为授权机制会通过互联网不断与我们的服务交互并进行计算。

{{% /alert %}} 

## **常见问题**

**我可以在同一应用程序中同时使用计量许可证和常规许可证（永久或临时）吗？**

可以。计量是一种可与现有 [授权方式](/slides/zh/net/licensing/) 并行使用的额外授权机制。您可以在应用程序启动时选择使用哪种机制。

**在计量许可证下，究竟是计数操作还是文件作为消耗？**

计量的是 API 使用量，即请求或操作的次数。您可以通过 [消耗跟踪方法](https://reference.aspose.com/slides/net/aspose.slides/metered/) 获取当前消耗量。

**计量适用于实例频繁重启的微服务和无服务器环境吗？**

可以。由于计费在 API 调用层面进行，频繁冷启动的场景是兼容的，只要能够保持稳定的网络访问以进行计量计算。

**使用计量许可证与永久许可证时，库的功能是否有所不同？**

否。这仅涉及授权和计费机制，产品的功能保持不变。

**计量与试用版和临时许可证有什么关系？**

试用版有功能限制和水印，[临时许可证](https://purchase.aspose.com/temporary-license/) 可在 30 天内解除限制，计量则解除限制并根据实际使用量计费。

**我可以通过在消耗阈值超出时自动响应来控制预算吗？**

可以。常见做法是定期通过 [跟踪方法](https://reference.aspose.com/slides/net/aspose.slides/metered/) 读取当前消耗量，并在应用程序或监控层面实现自定义的限制或警报。