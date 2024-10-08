---
title: 应用保护到演示文稿
type: docs
weight: 60
url: /zh/php-java/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Aspose.Slides 的一个常见用途是创建、更新和保存 Microsoft PowerPoint 2007 (PPTX) 演示文稿，作为自动化工作流程的一部分。以这种方式使用 Aspose.Slides 的应用程序用户可以访问输出演示文稿。保护这些演示文稿不被编辑是一个常见问题。确保自动生成的演示文稿保留其原始格式和内容非常重要。

本文解释了 [演示文稿和幻灯片是如何构建的](/slides/zh/php-java/applying-protection-to-presentation/) 以及 Aspose.Slides for PHP via Java 如何 [应用保护到](/slides/zh/php-java/applying-protection-to-presentation/) 演示文稿中，然后 [将其移除](/slides/zh/php-java/applying-protection-to-presentation/)。此功能是 Aspose.Slides 所独有的，撰写时尚未在 Microsoft PowerPoint 中提供。它给开发者提供了一种控制其应用程序创建的演示文稿使用方式的方法。

{{% /alert %}} 
## **幻灯片的组成**
PPTX 幻灯片由多个组件组成，如自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接器以及用于构建演示文稿的各种其他元素。在 Aspose.Slides for PHP via Java 中，幻灯片上的每个元素都转换为 Shape 对象。换句话说，幻灯片上的每个元素都是一个 Shape 对象或从 Shape 对象派生的对象。PPTX 的结构复杂，因此不同于 PPT，后者可以对所有类型的形状使用通用锁，针对不同形状类型有不同的锁。BaseShapeLock 类是通用的 PPTX 锁定类。Aspose.Slides for PHP via Java 支持以下类型的 PPTX 锁定。

- AutoShapeLock 锁定自动形状。
- ConnectorLock 锁定连接形状。
- GraphicalObjectLock 锁定图形对象。
- GroupshapeLock 锁定组合形状。
- PictureFrameLock 锁定图片框。
  在演示文稿对象中的所有 Shape 对象上执行的任何操作都将应用于整个演示文稿。
## **应用和移除保护**
应用保护确保演示文稿不能被编辑。这是保护演示文稿内容的有用技术。
## **应用保护到 PPTX 形状**
Aspose.Slides for PHP via Java 提供 Shape 类来处理幻灯片上的形状。

如前所述，每个形状类都有一个相关的形状锁类来提供保护。本文集中于 NoSelect、NoMove 和 NoResize 锁。这些锁确保形状无法被选择（通过鼠标点击或其他选择方法），并且无法被移动或调整大小。

下面的代码示例应用保护到演示文稿中的所有形状类型。



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-ApplyProtection-ApplyProtection.java" >}}
## **移除保护**
使用 Aspose.Slides for .NET/Java 应用的保护只能通过 Aspose.Slides for .NET/Java 移除。要解锁形状，请将应用的锁的值设置为 false。以下代码示例展示了如何在一个被锁定的演示文稿中解锁形状。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RemoveProtection-RemoveProtection.java" >}}




## **总结**
{{% alert color="primary" %}} 

Aspose.Slides 提供了多种选择，用于对演示文稿中的形状应用保护。可以锁定特定形状，或循环遍历演示文稿中的所有形状并锁定它们，从而有效地锁定演示文稿。只有 Aspose.Slides for PHP via Java 可以从先前保护的演示文稿中移除保护。通过将锁的值设置为 false 来移除保护。

{{% /alert %}}