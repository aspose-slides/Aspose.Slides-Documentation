---
title: 应用保护到演示文稿
type: docs
weight: 60
url: /zh/java/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Aspose.Slides 的一个常见用法是创建、更新和保存 Microsoft PowerPoint 2007 (PPTX) 演示文稿，作为自动化工作流程的一部分。以这种方式使用 Aspose.Slides 的应用程序用户可以访问输出演示文稿。保护它们不被编辑是一个常见的关注点。自动生成的演示文稿保留其原始格式和内容是很重要的。

本文解释了[演示文稿和幻灯片是如何构建的](/slides/zh/java/applying-protection-to-presentation/)，以及 Aspose.Slides for Java 如何[应用保护到](/slides/zh/java/applying-protection-to-presentation/)演示文稿，然后[从中移除](/slides/zh/java/applying-protection-to-presentation/)保护。此功能是 Aspose.Slides 所独有的，并且在撰写时尚未在 Microsoft PowerPoint 中提供。它为开发人员提供了一种控制其应用程序创建的演示文稿使用方式的方法。

{{% /alert %}} 
## **幻灯片的组成**
PPTX 幻灯片由多个组件组成，如自动图形、表格、OLE 对象、分组形状、图框、视频框、连接器以及可用于构建演示文稿的各种其他元素。在 Aspose.Slides for Java 中，幻灯片上的每个元素都被转化为 Shape 对象。换句话说，幻灯片上的每个元素要么是 Shape 对象，要么是从 Shape 对象派生的对象。PPTX 的结构复杂，所以与 PPT 不同，后者可以对所有类型的形状使用通用锁，PPTX 对于不同类型的形状有不同的锁。BaseShapeLock 类是通用的 PPTX 锁定类。Aspose.Slides for Java 支持以下类型的锁：

- AutoShapeLock 锁定自动图形。
- ConnectorLock 锁定连接器形状。
- GraphicalObjectLock 锁定图形对象。
- GroupshapeLock 锁定组合形状。
- PictureFrameLock 锁定图框。
  在一个演示文稿对象中对所有 Shape 对象执行的任何操作都适用于整个演示文稿。
## **应用和移除保护**
应用保护确保演示文稿无法被编辑。这是保护演示文稿内容的一个有用技术。
## **将保护应用于 PPTX 形状**
Aspose.Slides for Java 提供了 Shape 类来处理幻灯片上的形状。

如前所述，每个形状类都有一个相关的形状锁类用于保护。本文重点介绍 NoSelect、NoMove 和 NoResize 锁。这些锁确保形状无法被选择（通过鼠标点击或其他选择方法），并且无法移动或调整大小。

以下代码示例将保护应用于演示文稿中的所有形状类型。



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-ApplyProtection-ApplyProtection.java" >}}
## **移除保护**
使用 Aspose.Slides for .NET/Java 应用的保护只能通过 Aspose.Slides for .NET/Java 移除。要解锁形状，请将分配的锁的值设置为 false。以下代码示例演示了如何在被锁定的演示文稿中解锁形状。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RemoveProtection-RemoveProtection.java" >}}

## **总结**
{{% alert color="primary" %}} 

Aspose.Slides 提供了多种选项，用于在演示文稿中应用保护。可以锁定特定形状，或者遍历演示文稿中的所有形状并锁定它们，从而有效地锁定演示文稿。只有 Aspose.Slides for Java 可以从以前保护的演示文稿中移除保护。通过将锁的值设置为 false 来移除保护。

{{% /alert %}}
```