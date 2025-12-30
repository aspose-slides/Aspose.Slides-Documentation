---
title: 计量授权
type: docs
weight: 100
url: /zh/php-java/metered-licensing/
keywords:
- 许可
- 计量许可
- 许可密钥
- 公钥
- 私钥
- 消耗数量
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP 通过 Java 计量授权如何让您灵活处理 PowerPoint 和 OpenDocument 文件，仅为实际使用的部分付费。"
---

## **应用计量密钥**

{{% alert color="primary" %}} 
计量授权是一种全新的授权机制，可与现有授权方式一起使用。如果您希望根据对 Aspose.Slides API 功能的使用情况计费，请选择计量授权。

购买计量授权时，您将获得密钥（而不是授权文件）。此计量密钥可通过 Aspose 提供的用于计量操作的 [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) 类进行应用。有关更多详细信息，请参阅 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)。
{{% /alert %}} 

1. 创建 [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) 类的实例。

2. 将您的公钥和私钥传递给 [setMeteredKey](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) 方法。

3. 执行一些处理（执行任务）。

4. 调用 `Metered` 类的 [getConsumptionQuantity](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#getConsumptionQuantity--) 方法。

您应该能够看到截至目前已消耗的 API 请求数量/额度。

以下示例代码展示了如何使用计量授权：
```php
// 创建 Metered 类的实例
$metered = new Metered();

try {
    // 将公钥和私钥传递给 Metered 对象
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // 获取 API 调用前的消耗数量值
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // 在此使用 Aspose.Slides API 执行操作
    // ...

    // 获取 API 调用后的消耗数量值
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```


{{% alert color="warning" title="NOTE"  %}} 
要使用计量授权，您需要稳定的互联网连接，因为授权机制会通过互联网不断与我们的服务交互并进行计算。
{{% /alert %}} 

## **常见问题**

**我可以在同一个应用程序中同时使用计量授权和常规授权（永久或临时）吗？**

可以。计量是一种可与现有 [licensing methods](/slides/zh/php-java/licensing/) 一起使用的补充授权机制。您可以在应用程序启动时选择使用哪种机制。

**计量授权下的消耗具体计算什么：是操作次数还是文件数量？**

计量的是 API 使用量，即请求或操作的次数。您可以通过 [consumption‑tracking methods](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) 获取当前消耗量。

**计量授权适用于实例经常重启的微服务和无服务器环境吗？**

可以。由于计量是在 API 调用级别完成的，会计因此与频繁的冷启动兼容，只要有稳定的网络访问用于计量计算。

**使用计量授权与使用永久授权时，库的功能是否有区别？**

没有。这仅涉及授权和计费机制，产品功能保持一致。

**计量授权与试用版和临时授权有什么关系？**

试用版有功能限制和水印，[temporary license](https://purchase.aspose.com/temporary-license/) 可在 30 天内移除限制，计量授权则在移除限制的同时依据实际使用量计费。

**我能否通过在超出消耗阈值时自动做出响应来控制预算？**

可以。常见做法是定期读取当前消耗量，通过 [tracking methods](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) 在应用或监控层面实现自己的限制或警报。