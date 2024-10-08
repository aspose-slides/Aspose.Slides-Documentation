---
title: 对演示文稿应用保护
type: docs
weight: 10
url: /cpp/applying-protection-to-presentation/
---

{{% alert color="primary" %}}

Aspose.Slides 的一个常见用途是作为自动化工作流程的组成部分来创建、更新和保存 Microsoft PowerPoint 2007（PPTX）演示文稿。以这种方式使用 Aspose.Slides 的应用程序用户可以访问输出的演示文稿。保护这些演示文稿以免被编辑是一个常见的考虑。确保自动生成的演示文稿保留其原始格式和内容非常重要。

本文解释了 [演示文稿和幻灯片是如何构建的](/slides/cpp/applying-protection-to-presentation/)以及 Aspose.Slides for C++ 如何 [对演示文稿应用保护](/slides/cpp/applying-protection-to-presentation/)，然后 [从演示文稿中移除保护](/slides/cpp/applying-protection-to-presentation/)。此功能是 Aspose.Slides 所独有的，在撰写时，Microsoft PowerPoint 中并不存在此功能。它为开发者提供了一种控制其应用程序创建的演示文稿如何使用的方式。

{{% /alert %}} 
## **幻灯片的组成**
PPTX 幻灯片由许多组件组成，如自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接器以及构建演示文稿的其他各种元素。

在 Aspose.Slides for C++ 中，幻灯片上的每个元素都转换为 Shape 对象。换句话说，幻灯片上的每个元素都是一个 Shape 对象或从 Shape 对象派生的对象。

PPTX 的结构复杂，因此与 PPT 不同，后者可以对所有类型的形状使用通用锁，PPTX 为不同形状类型提供不同类型的锁。BaseShapeLock 类是通用的 PPTX 锁定类。Aspose.Slides for C++ 支持以下类型的锁用于 PPTX。

- AutoShapeLock 锁定自动形状。
- ConnectorLock 锁定连接器形状。
- GraphicalObjectLock 锁定图形对象。
- GroupshapeLock 锁定组合形状。
- PictureFrameLock 锁定图片框。

在演示文稿对象中对所有 Shape 对象执行的任何操作都将应用于整个演示文稿。
## **应用和移除保护**
应用保护可确保演示文稿无法被编辑。这是一种保护演示文稿内容的有用技术。
### **对 PPTX 形状应用保护**
Aspose.Slides for C++ 提供了 Shape 类来处理幻灯片上的形状。

如前所述，每个形状类都有一个关联的形状锁类以进行保护。本文重点介绍 NoSelect、NoMove 和 NoResize 锁。这些锁确保形状无法被选择（通过鼠标点击或其他选择方法），并且无法移动或调整大小。

以下代码示例对演示文稿中的所有形状类型应用保护。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ApplyProtection-ApplyProtection.cpp" >}}

### **移除保护**
使用 Aspose.Slides for C++ 应用的保护只能通过 Aspose.Slides for C++ 移除。要解锁形状，将应用锁的值设置为 false。以下代码示例展示了如何在锁定的演示文稿中解锁形状。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-RemoveProtection-RemoveProtection.cpp" >}}
## **总结**
{{% alert color="primary" %}}

Aspose.Slides 提供了多种选项来对演示文稿中的形状应用保护。可以锁定特定形状，或循环遍历演示文稿中的所有形状并锁定它们，以有效地锁定演示文稿。

只有 Aspose.Slides for C++ 能够从以前保护过的演示文稿中移除保护。通过将锁的值设置为 false 来移除保护。

{{% /alert %}} 
### **相关文档**
- [ShapeEx](http://docs.aspose.com/display/slidesnet/ShapeEx+Class) 类。
- [BaseShapeLockEx](http://docs.aspose.com/display/slidesnet/BaseShapeLockEx+Class) 类。