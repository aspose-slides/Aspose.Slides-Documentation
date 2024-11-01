---
title: 演示文稿格式
type: docs
weight: 10
url: /zh/net/presentation-format/
---

Aspose.Slides for .NET 提供了 [**PresentationFactory** ](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory) 类，用于在加载之前获取演示文稿格式。

为了获取演示文稿格式，请遵循以下步骤：

1. 创建 [**IPresentationInfo** ](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo) 类的实例。
1. 获取有关演示文稿格式的信息。

在下面给出的示例中，我们获得了演示文稿格式：

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("HelloWorld.pptx");
switch (info.LoadFormat)
{
    case LoadFormat.Pptx:
        {
            break;
        }

    case LoadFormat.Unknown:
        {
            break;
        }
}
```