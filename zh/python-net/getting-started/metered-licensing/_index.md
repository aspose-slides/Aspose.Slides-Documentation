---
title: 计量授权
type: docs
weight: 90
url: /zh/python-net/metered-licensing/
keywords:
- 许可证
- 计量许可证
- 许可证密钥
- 公钥
- 私钥
- 消耗量
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 计量授权如何让您灵活处理 PowerPoint 和 OpenDocument 文件，并仅为实际使用付费。"
---

## **应用计量密钥**

{{% alert color="primary" %}} 

计量授权是一种全新的授权机制，可与现有授权方式一起使用。如果您希望根据对 Aspose.Slides API 功能的使用量计费，请选择计量授权。

购买计量授权后，您会得到密钥（而非授权文件）。此计量密钥可通过 Aspose 提供的用于计量操作的 [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 类进行应用。更多详情请参阅 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 

1. 创建 [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 类的实例。
2. 将您的公钥和私钥传递给 [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str) 方法。
3. 执行一些处理（执行任务）。
4. 调用 `Metered` 类的 [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) 方法。

您应该会看到截至目前已消耗的 API 请求数量/金额。

以下示例代码展示了如何使用计量授权：

```python
import aspose.slides as slides

# Creates an instance of the Metered class
metered = slides.Metered()

# Passes the public and private keys to the Metered object
metered.set_metered_key("<valid public key>", "<valid private key>")

# Gets the consumed quantity value before API calls
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Do something with Aspose.Slides API here
# ...

# Gets the consumed quantity value after API calls
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="注意"  %}} 

要使用计量授权，您需要稳定的互联网连接，因为授权机制会通过互联网持续与我们的服务交互并进行计算。

{{% /alert %}} 

## **常见问题**

**我可以在同一应用程序中同时使用计量许可证和常规（永久或临时）许可证吗？**

是的。计量是一种可与现有 [licensing methods](/slides/zh/python-net/licensing/) 并行使用的额外授权机制。您可以在应用程序启动时选择使用哪种机制。

**在计量许可证下，究竟是操作还是文件计入消耗？**

计量的是 API 使用量，即请求或操作的次数。您可以通过 [consumption‑tracking methods](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 获取当前消耗量。

**计量授权适用于实例频繁重启的微服务和无服务器环境吗？**

可以。由于计量在每次 API 调用层面完成计数，频繁的冷启动场景是兼容的，只要能够保持稳定的网络访问以进行计量计算。

**使用计量许可证与永久许可证时，库的功能是否有所不同？**

没有。计量授权仅涉及授权和计费机制，产品的功能保持完全一致。

**计量授权与试用版和临时许可证有什么关系？**

试用版存在功能限制和水印，[临时许可证](https://purchase.aspose.com/temporary-license/) 可在 30 天内解除限制，而计量授权则取消限制并根据实际使用量计费。

**我能否在超出消耗阈值时自动做出响应来控制预算？**

可以。常见做法是定期通过 [tracking methods](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 读取当前消耗量，并在应用程序或监控层面实现自定义的限制或警报。