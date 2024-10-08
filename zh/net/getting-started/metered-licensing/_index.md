---
title: 按需许可
type: docs
weight: 90
url: /zh/net/metered-licensing/
---

{{% alert color="primary" %}} 

按需许可是一种新的许可机制，可以与现有的许可方法一起使用。如果您希望根据对 Aspose.Slides API 功能的使用情况进行计费，则可以选择按需许可。

当您购买按需许可时，您将获得密钥（而不是许可证文件）。这个按需密钥可以使用 Aspose 提供的 [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) 类来应用于计量操作。有关更多详情，请参见 [按需许可常见问题解答](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 

1. 创建 [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) 类的实例。
1. 将您的公钥和私钥传递给 [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/) 方法。
1. 进行一些处理（执行任务）。
1. 调用 Metered 类的 [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) 方法。

   您应该看到到目前为止您已消耗的 API 请求数量/金额。

以下 C# 代码演示了如何设置按需公钥和私钥：

```c#
//  创建 Metered 类的实例
	Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

//  访问 SetMeteredKey 属性并将公钥和私钥作为参数传递
	metered.SetMeteredKey("*****", "*****");

//  在 API 调用之前获取按需数据数量
	decimal amountbefore = Aspose.Slides.Metered.GetConsumptionQuantity();

//  显示信息
	Console.WriteLine("调用前消耗量: " + amountbefore.ToString());

//  在 API 调用之后获取按需数据量
	decimal amountafter = Aspose.Slides.Metered.GetConsumptionQuantity();

//  显示信息
	Console.WriteLine("调用后消耗量: " + amountafter.ToString());
```

{{% alert color="warning" title="注意"  %}} 

要使用按需许可，您需要稳定的互联网连接，因为许可机制使用互联网与我们的服务进行持续交互并执行计算。

{{% /alert %}} 