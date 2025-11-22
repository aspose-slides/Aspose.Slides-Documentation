---
title: 计量授权
type: docs
weight: 90
url: /zh/net/metered-licensing/
keywords:
- 许可证
- 计量授权
- C#
- Aspose.Slides for .NET
---

## **应用计量密钥**

{{% alert color="primary" %}} 

计量授权是一种全新的授权机制，可与现有授权方式一起使用。如果您希望根据对 Aspose.Slides API 功能的使用情况计费，请选择计量授权。

购买计量授权后，您将获得密钥（而不是授权文件）。可以使用 Aspose 为计量操作提供的 [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) 类来应用此计量密钥。更多详情请参阅 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 

1. 创建一个 [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) 类的实例。  
1. 将您的公钥和私钥传递给 [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/) 方法。  
1. 进行一些处理（执行任务）。  
1. 调用 `Metered` 类的 [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) 方法。

您应该可以看到截至目前已消耗的 API 请求数量/额度。

以下示例代码展示了如何使用计量授权：

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

使用计量授权时，需要稳定的互联网连接，因为授权机制需要通过互联网持续与我们的服务交互并进行计算。

{{% /alert %}} 

## **常见问题**

**我可以在同一个应用程序中同时使用计量授权和常规授权（永久或临时）吗？**

可以。计量授权是一种可与现有 [licensing methods](/slides/zh/net/licensing/) 并行使用的额外授权机制。您可以在应用程序启动时选择使用哪种机制。

**计量授权下的消耗到底是指操作次数还是文件数量？**

计量的是 API 使用次数，即请求或操作的数量。您可以通过 [consumption‑tracking methods](https://reference.aspose.com/slides/net/aspose.slides/metered/) 获取当前消耗情况。

**计量授权适用于实例经常重启的微服务和无服务器环境吗？**

适用。由于计量是在每次 API 调用层面进行的，只要网络访问稳定，频繁的冷启动也不会有问题。

**使用计量授权时，库的功能是否与永久授权有所不同？**

没有。计量授权仅影响授权和计费机制，产品的功能保持一致。

**计量授权与试用版和临时授权有什么关系？**

试用版有功能限制和水印，[临时授权](https://purchase.aspose.com/temporary-license/) 在 30 天内移除限制，而计量授权则在移除限制的同时依据实际使用量计费。

**我能否通过自动响应消耗阈值超限来控制预算？**

可以。常见做法是定期通过 [tracking methods](https://reference.aspose.com/slides/net/aspose.slides/metered/) 读取当前消耗，然后在应用程序或监控层面实现自定义的限制或警报。