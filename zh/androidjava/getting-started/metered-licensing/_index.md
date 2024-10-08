---
title: 按需许可
type: docs
weight: 100
url: /androidjava/metered-licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides 允许开发者应用按需密钥。这是一种新的许可机制。新的许可机制将与现有的许可方法共同使用。希望根据其 API 功能使用情况进行计费的客户，可以使用按需许可。有关更多详情，请参阅 [按需许可常见问题解答](https://purchase.aspose.com/faqs/licensing/metered) 部分。

{{% /alert %}} 
## **按需许可**
按照以下简单步骤使用 Metered 类：

1. 创建 Metered 类的实例。

1. 将公钥和私钥传递给 setMeteredKey 方法。

1. 进行处理（执行任务）。

1. 调用 Metered 类的 getConsumptionQuantity 方法。

   这将返回您迄今为止消耗的 API 请求数量。

以下示例代码展示了如何设置按需公钥和私钥：

```java
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();
try {
    // 访问 setMeteredKey 属性，并将公钥和私钥作为参数传递
    metered.setMeteredKey("<有效的公钥>", "<有效的私钥>");

    // 在访问 API 之前获取消耗数量值
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("消耗数量" + quantityOld);


    // 在访问 API 之后获取消耗数量值
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("消耗数量" + quantity);


} catch (Exception ex) {
    ex.printStackTrace();
}
```