---
title: 应用保护到演示文稿
type: docs
weight: 70
url: /net/applying-protection-to-presentation/
---

{{% alert color="primary" %}}

Aspose.Slides 的一个常见用途是创建、更新和保存 Microsoft PowerPoint 2007 (PPTX) 演示文稿，作为自动化工作流的一部分。以这种方式使用 Aspose.Slides 的应用程序用户可以访问输出演示文稿。对其进行编辑保护是一个常见的问题。自动生成的演示文稿保持其原始格式和内容是很重要的。

本文解释了 [演示文稿和幻灯片是如何构建的](/slides/net/applying-protection-to-presentation/)，以及 Aspose.Slides for .NET 如何 [应用保护到](/slides/net/applying-protection-to-presentation/) 演示文稿，然后 [从中移除保护](/slides/net/applying-protection-to-presentation/)。该功能是 Aspose.Slides 独有的，在撰写时，Microsoft PowerPoint 中尚不可用。它为开发者提供了一种控制他们的应用程序创建的演示文稿如何使用的方式。

{{% /alert %}} 
## **幻灯片的组成**
PPTX 幻灯片由多个组件组成，如自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接器以及用于构建演示文稿的各种其他元素。

在 Aspose.Slides for .NET 中，幻灯片上的每个元素都转化为 Shape 对象。换句话说，幻灯片上每个元素都是一个 Shape 对象或一个从 Shape 对象派生的对象。

PPTX 的结构比较复杂，因此，与 PPT 不同，PPT 中可以对所有类型的形状使用通用锁，而不同类型的形状有不同类型的锁。BaseShapeLock 类是通用的 PPTX 锁定类。Aspose.Slides for .NET 支持以下类型的锁定，以用于 PPTX。

- AutoShapeLock 锁定自动形状。
- ConnectorLock 锁定连接器形状。
- GraphicalObjectLock 锁定图形对象。
- GroupshapeLock 锁定组合形状。
- PictureFrameLock 锁定图片框。

在 Presentation 对象上执行的任何操作都会应用于整个演示文稿。
## **应用和移除保护**
应用保护确保演示文稿无法被编辑。这是一种保护演示文稿内容的有效技术。
### **应用保护到 PPTX 形状**
Aspose.Slides for .NET 提供 Shape 类来处理幻灯片上的形状。

如前所述，每个形状类都有一个关联的形状锁类来进行保护。本文重点介绍 NoSelect、NoMove 和 NoResize 锁。这些锁确保形状无法被选择（通过鼠标点击或其他选择方法），也无法被移动或调整大小。

下面的代码示例将保护应用于演示文稿中的所有形状类型。

```c#
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pTemplate = new Presentation("RectPicFrame.pptx");

// ISlide 对象用于访问演示文稿中的幻灯片
ISlide slide = pTemplate.Slides[0];

// IShape 对象用于临时存储形状
IShape shape;

// 遍历演示文稿中的所有幻灯片
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    // 遍历幻灯片中的所有形状
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        // 如果形状是自动形状
        if (shape is IAutoShape)
        {
            // 类型转换为自动形状并获取自动形状锁
            IAutoShape Ashp = shape as IAutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            // 应用形状锁
            AutoShapeLock.PositionLocked = true;
            AutoShapeLock.SelectLocked = true;
            AutoShapeLock.SizeLocked = true;
        }

        // 如果形状是组合形状
        else if (shape is IGroupShape)
        {
            // 类型转换为组合形状并获取组合形状锁
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            // 应用形状锁
            groupShapeLock.GroupingLocked = true;
            groupShapeLock.PositionLocked = true;
            groupShapeLock.SelectLocked = true;
            groupShapeLock.SizeLocked = true;
        }

        // 如果形状是连接器
        else if (shape is IConnector)
        {
            // 类型转换为连接器形状并获取连接器形状锁
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            // 应用形状锁
            ConnLock.PositionMove = true;
            ConnLock.SelectLocked = true;
            ConnLock.SizeLocked = true;
        }

        // 如果形状是图片框
        else if (shape is IPictureFrame)
        {
            // 类型转换为图片框并获取图片框形状锁
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            // 应用形状锁
            PicLock.PositionLocked = true;
            PicLock.SelectLocked = true;
            PicLock.SizeLocked = true;
        }
    }

}
// 保存演示文稿文件
pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **移除保护**
使用 Aspose.Slides for .NET 应用的保护只能通过使用 Aspose.Slides for .NET 移除。要解锁形状，请将应用的锁的值设置为 false。下面的代码示例展示了如何在锁定的演示文稿中解锁形状。

```c#
// 打开所需的演示文稿
Presentation pTemplate = new Presentation("ProtectedSample.pptx");

// ISlide 对象用于访问演示文稿中的幻灯片
ISlide slide = pTemplate.Slides[0];

// IShape 对象用于临时存储形状
IShape shape;

// 遍历演示文稿中的所有幻灯片
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    // 遍历幻灯片中的所有形状
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        // 如果形状是自动形状
        if (shape is IAutoShape)
        {
            // 类型转换为自动形状并获取自动形状锁
            IAutoShape Ashp = shape as AutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            // 应用形状锁
            AutoShapeLock.PositionLocked = false;
            AutoShapeLock.SelectLocked = false;
            AutoShapeLock.SizeLocked = false;
        }

        // 如果形状是组合形状
        else if (shape is IGroupShape)
        {
            // 类型转换为组合形状并获取组合形状锁
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            // 应用形状锁
            groupShapeLock.GroupingLocked = false;
            groupShapeLock.PositionLocked = false;
            groupShapeLock.SelectLocked = false;
            groupShapeLock.SizeLocked = false;
        }

        // 如果形状是连接器
        else if (shape is IConnector)
        {
            // 类型转换为连接器并获取连接器锁
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            // 应用形状锁
            ConnLock.PositionMove = false;
            ConnLock.SelectLocked = false;
            ConnLock.SizeLocked = false;
        }

        // 如果形状是图片框
        else if (shape is IPictureFrame)
        {
            // 类型转换为图片框并获取图片框锁
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            // 应用形状锁
            PicLock.PositionLocked = false;
            PicLock.SelectLocked = false;
            PicLock.SizeLocked = false;
        }
    }

}
// 保存演示文稿文件
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **总结**
{{% alert color="primary" %}}

Aspose.Slides 提供了多种选项来对演示文稿中的形状应用保护。可以锁定特定形状，或遍历演示文稿中的所有形状并将其全部锁定，从而有效锁定演示文稿。

只有 Aspose.Slides for .NET 可以从先前保护的演示文稿中移除保护。通过将锁的值设置为 false 来移除保护。

{{% /alert %}}