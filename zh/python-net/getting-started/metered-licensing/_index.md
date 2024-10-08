---
title: 按使用计费许可
type: docs
weight: 90
url: /python-net/metered-licensing/
---

{{% alert color="primary" %}} 

按使用计费许可是一种新的许可机制，可以与现有的许可方法一起使用。如果您希望根据使用 Aspose.Slides API 功能的情况进行计费，则可以选择按使用计费许可。

当您购买按使用计费的许可证时，您会获得密钥（而不是许可证文件）。这个按使用计费的密钥可以通过 Aspose 提供的 [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 类用于计量操作。有关更多详细信息，请参见 [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered)。

{{% /alert %}} 

1. 创建 [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) 类的实例。
1. 将您的公钥和私钥传递给 `set_metered_key` 方法。
1. 进行一些处理（执行任务）。
1. 调用 Metered 类的 `get_consumption_quantity()` 方法。

   您应该查看到您到目前为止消耗的 API 请求的数量。

以下 Python 代码演示了如何设置按使用计费的公钥和私钥：

```python
import aspose.slides as slides

# 创建 CAD Metered 类的实例
metered = slides.Metered()

# 访问 set_metered_key 属性并将公钥和私钥作为参数传递
metered.set_metered_key("*****", "*****")

# 调用 API 前获取计量数据的数量
amountbefore = slides.metered.get_consumption_quantity()
# 显示信息
print("调用前消耗的数量: " + str(amountbefore))

# 从磁盘加载文档。
with slides.Presentation("Presentation.pptx") as pres:
   # 获取文档的页面数
   print(len(pres.slides))
   # 保存为 PDF
   pres.save("out_pdf.pdf", slides.export.SaveFormat.PDF)

# 调用 API 后获取计量数据的数量
amountafter = slides.metered.get_consumption_quantity()
# 显示信息
print("调用后消耗的数量: " + str(amountafter))
```

{{% alert color="warning" title="注意"  %}} 

要使用按使用计费许可，您需要稳定的互联网连接，因为该许可机制使用互联网不断与我们的服务进行交互并执行计算。

{{% /alert %}} 