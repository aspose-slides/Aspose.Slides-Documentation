---
title: 按需授权
type: docs
weight: 100
url: /php-java/metered-licensing/
---

{{% alert color="primary" %}} 

按需授权是一种新的授权机制，可以与现有的授权方法一起使用。如果您希望根据使用Aspose.Slides API功能的情况进行计费，请选择按需授权。

当您购买按需许可证时，您将获得密钥（而不是许可证文件）。此按需密钥可以通过Aspose提供的用于计量操作的[Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/)类进行应用。有关更多详细信息，请参见[按需授权常见问题解答](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 
1. 创建[Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/)类的实例。

1. 将您的公钥和私钥传递给[setMeteredKey](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-)方法。

1. 进行一些处理（执行任务）。

1. 调用Metered类的[getConsumptionQuantity](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#getConsumptionQuantity--)方法。

   您应该看到您迄今为止消耗的API请求的数量/金额。

以下PHP代码向您展示了如何设置按需公钥和私钥：

```php
  $metered = new Metered();
  try {
    // 访问setMeteredKey属性并将公钥和私钥作为参数传递
    $metered->setMeteredKey("<有效的公钥>", "<有效的私钥>");
    // 在访问API之前获取消耗数量值
    $quantityOld = Metered->getConsumptionQuantity();
    echo("消耗数量" . $quantityOld);
    // 在访问API之后获取消耗数量值
    $quantity = Metered->getConsumptionQuantity();
    echo("消耗数量" . $quantity);
  } catch (JavaException $ex) {
    $ex->printStackTrace();
  }
```

{{% alert color="warning" title="注意"  %}} 

要使用按需授权，您需要稳定的互联网连接，因为授权机制需要互联网与我们的服务不断交互并执行计算。

{{% /alert %}} 