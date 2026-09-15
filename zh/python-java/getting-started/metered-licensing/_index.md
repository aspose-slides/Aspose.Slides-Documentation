---
title: 计量授权
type: docs
weight: 100
url: /zh/python-java/metered-licensing/
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
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 的计量授权如何让您灵活处理 PowerPoint 和 OpenDocument 文件，仅为实际使用的部分付费。"
---
## **介绍**

计量授权是一种可与现有授权方式一起使用的授权机制。如果您希望根据对 Aspose.Slides API 功能的使用量计费，请选择计量授权。

## **应用计量密钥**

{{% alert color="info" title="注意" %}}

计量授权是一种可与现有授权方式一起使用的授权机制。如果您希望根据对 Aspose.Slides API 功能的使用量计费，请选择计量授权。

购买计量授权后，您将获得密钥（而非授权文件）。可以使用 Aspose 提供的 [Metered](https://reference.aspose.com/slides/zh/python-java/aspose.slides/metered/) 类来应用此计量密钥。更多详情，请参阅 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}}

1. 创建 [Metered](https://reference.aspose.com/slides/zh/python-java/aspose.slides/metered/) 类的实例。

1. 将您的公钥和私钥传递给 [setMeteredKey](https://reference.aspose.com/slides/zh/python-java/aspose.slides/metered/#setMeteredKey) 方法。

1. 执行一些处理（执行任务）。

1. 调用 [Metered](https://reference.aspose.com/slides/zh/python-java/aspose.slides/metered/) 类的 [getConsumptionQuantity](https://reference.aspose.com/slides/zh/python-java/aspose.slides/metered/#getConsumptionQuantity) 方法。

您应该会看到迄今为止已消耗的 API 请求数量/额度。

以下示例代码演示了如何使用计量授权：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# 创建 Metered 类的实例。
metered = Metered()

try:
    # 将公钥和私钥传递给 Metered 对象。
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # 在 API 调用之前获取已消耗的数量。
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # 在此使用 Aspose.Slides API 执行某些操作。
    # ...

    # 在 API 调用之后获取已消耗的数量。
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="警告"  %}}

要使用计量授权，您需要稳定的互联网连接，因为授权机制会通过互联网不断与我们的服务交互并执行计费计算。

{{% /alert %}}

## **常见问题**

**我可以在同一个应用程序中同时使用计量授权和常规授权（永久或临时）吗？**

可以。计量授权是可与现有授权方式一起使用的额外授权机制。您可以在应用启动时选择使用哪种机制。

**计量授权下的消耗具体是指什么：操作还是文件？**

计量的是 API 使用量，即请求或操作的次数。您可以通过消耗跟踪方法获取当前的消耗情况。

**计量授权适用于实例频繁重启的微服务和无服务器环境吗？**

可以。由于计费是在 API 调用层面进行的，频繁冷启动的场景是兼容的，只要有稳定的网络访问以进行计量计算。

**与永久授权相比，使用计量授权时库的功能是否会不同？**

不会。这仅涉及授权和计费机制，产品的功能保持不变。

**计量授权与试用版和临时授权有什么关系？**

试用版存在功能限制和水印，临时授权在 30 天内移除限制，而计量授权则在移除限制的同时根据实际使用量计费。

**我可以通过在消耗阈值超出时自动响应来控制预算吗？**

可以。常见做法是定期通过跟踪方法读取当前消耗量，并在应用或监控层面实现自定义的限制或警报。