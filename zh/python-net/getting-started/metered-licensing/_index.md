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
- 消耗数量
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 计量授权如何灵活处理 PowerPoint 和 OpenDocument 文件，仅为实际使用付费。"
---

## **应用计量密钥**

{{% alert color="primary" %}} 

计量许可证是一种新的授权机制，可与现有的授权方式一起使用。如果您希望根据对 Aspose.Slides API 功能的使用量计费，请选择计量授权。

购买计量许可证后，您将获得密钥（而非许可证文件）。可以使用 Aspose 为计量操作提供的 [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 类来应用此计量密钥。更多详情请参阅 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 

1. 创建 [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 类的实例。
1. 将您的公钥和私钥传递给 [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str) 方法。
1. 执行一些处理（执行任务）。
1. 调用 `Metered` 类的 [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) 方法。

您应该能够看到迄今为止已消耗的 API 请求数量/金额。

以下示例代码展示了如何使用计量授权：
```python
import aspose.slides as slides

# 创建 Metered 类的实例
metered = slides.Metered()

# 将公钥和私钥传递给 Metered 对象
metered.set_metered_key("<valid public key>", "<valid private key>")

# 在 API 调用之前获取已消耗的数量值
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# 在此使用 Aspose.Slides API 执行操作
# ...

# 在 API 调用之后获取已消耗的数量值
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```


{{% alert color="warning" title="注意" %}} 

使用计量授权时，需要保持稳定的互联网连接，因为授权机制会通过互联网不断与我们的服务交互并进行计费计算。

{{% /alert %}} 

## **常见问题**

**我可以在同一个应用程序中同时使用计量许可证和常规许可证（永久或临时）吗？**

可以。计量是一种可以与现有 [licensing methods](/slides/zh/python-net/licensing/) 一起使用的额外授权机制。您可以在应用启动时选择使用哪种机制。

**计量许可证的消耗具体指什么：操作还是文件？**

计量基于 API 使用量，即请求或操作的次数。您可以通过 [consumption‑tracking methods](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 获取当前的消耗情况。

**计量许可证适用于实例经常重启的微服务和无服务器环境吗？**

适用。由于计费在每次 API 调用层面完成，频繁的冷启动场景是兼容的，只要能够保持稳定的网络访问以进行计量计算。

**使用计量许可证时，库的功能是否与永久许可证不同？**

不不同。这仅涉及授权和计费机制，产品的功能保持一致。

**计量许可证与试用版和临时许可证有什么关系？**

试用版会有限制并添加水印，[temporary license](https://purchase.aspose.com/temporary-license/) 可在 30 天内解除限制，而计量许可证则在解除限制的同时根据实际使用量计费。

**我可以通过自动响应消费阈值来控制预算吗？**

可以。常见做法是定期通过 [tracking methods](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 读取当前消耗，并在应用或监控层面实现自定义的限制或警报。