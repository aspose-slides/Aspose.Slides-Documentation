---
title: 计量许可
type: docs
weight: 100
url: /java/metered-licensing/
---

{{% alert color="primary" %}} 

计量许可是一种新的许可机制，可以与现有的许可方法一起使用。如果您希望根据对 Aspose.Slides API 功能的使用情况进行计费，则选择计量许可。

当您购买计量许可证时，您会获得密钥（而不是许可证文件）。这个计量密钥可以使用 Aspose 提供的 [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) 类进行计量操作。有关更多详细信息，请参阅 [计量许可 FAQ](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 
1. 创建 [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) 类的实例。

1. 将您的公钥和私钥传递给 [setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) 方法。

1. 进行一些处理（执行任务）。

1. 调用 Metered 类的 [getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--) 方法。

   您应该能够看到您迄今为止消耗的 API 请求的数量。

以下 Java 代码向您展示了如何设置计量公钥和私钥：

```java
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();
try {
    // 访问 setMeteredKey 属性并传递公钥和私钥作为参数
    metered.setMeteredKey("<valid pablic key>", "<valid private key>");

    // 在访问 API 之前获取消耗的数量值
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("消耗数量" + quantityOld);


    // 在访问 API 之后获取消耗的数量值
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("消耗数量" + quantity);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="注意"  %}} 

要使用计量许可，您需要稳定的互联网连接，因为许可机制使用互联网持续与我们的服务互动并进行计算。

{{% /alert %}} 
