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
description: 了解如何通过 .NET 计量授权使用 Aspose.Slides for Python 灵活处理 PowerPoint 和 OpenDocument 文件，并仅为实际使用的部分付费。
---

## **应用计量密钥**

{{% alert color="primary" %}} 

计量授权是一种全新的授权机制，可与现有授权方式一起使用。如果您希望根据对 Aspose.Slides API 功能的使用量计费，请选择计量授权。

购买计量授权后，您将获得密钥（而不是授权文件）。此计量密钥可通过 Aspose 提供的用于计量操作的 [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 类进行应用。更多详情，请参阅 [计量授权常见问题](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 

1. 创建 [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 类的实例。
2. 将您的公钥和私钥传递给 [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str) 方法。
3. 执行一些处理（执行任务）。
4. 调用 `Metered` 类的 [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) 方法。

您应该可以看到迄今为止已消耗的 API 请求数量/金额。

以下示例代码展示了如何使用计量授权：

```python
import aspose.slides as slides

# 创建 Metered 类的实例
metered = slides.Metered()

# 将公钥和私钥传递给 Metered 对象
metered.set_metered_key("<valid public key>", "<valid private key>")

# 在 API 调用前获取已消耗的数量值
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# 在此处使用 Aspose.Slides API 做一些操作
# ...

# 在 API 调用后获取已消耗的数量值
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

使用计量授权需要稳定的互联网连接，因为授权机制会通过互联网持续与我们的服务交互并进行计费计算。

{{% /alert %}} 

## **常见问题**

**我可以在同一个应用程序中同时使用计量授权和常规授权（永久或临时）吗？**

可以。计量授权是一种可与现有 [授权方法](/slides/zh/python-net/licensing/) 并行使用的额外授权机制。您可以在应用程序启动时选择使用哪种机制。

**计量授权下的消费到底是按操作计数还是按文件计数？**

计量依据 API 使用量，即请求或操作的次数。您可以通过 [消费跟踪方法](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 获取当前的消费情况。

**计量授权适用于实例频繁重启的微服务和无服务器环境吗？**

可以。由于计费是在 API 调用层面进行的，频繁冷启动的场景也是兼容的，前提是拥有稳定的网络以进行计量计算。

**使用计量授权与永久授权时，库的功能是否有差异？**

没有。这仅涉及授权和计费机制，产品功能保持不变。

**计量授权与试用版和临时授权有什么关联？**

试用版有功能限制和水印，[临时授权](https://purchase.aspose.com/temporary-license/) 可在 30 天内消除限制，而计量授权则去除限制并根据实际使用量计费。

**我能否在消费阈值超过时自动响应以控制预算？**

可以。常见做法是定期通过 [消费跟踪方法](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 读取当前消费情况，并在应用程序或监控层面自行设置限制或警报。