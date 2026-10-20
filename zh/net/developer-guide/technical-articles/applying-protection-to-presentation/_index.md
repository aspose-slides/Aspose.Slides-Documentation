---
title: 在 .NET 中使用形状锁定限制演示文稿编辑
linktitle: 限制演示文稿编辑
type: docs
weight: 70
url: /zh/net/applying-protection-to-presentation/
keywords:
- 防止编辑
- 防止修改
- 锁定形状
- 锁定位置
- 锁定选择
- 锁定大小调整
- 锁定分组
- PowerPoint
- PPTX
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PPTX 演示文稿中锁定和解锁形状，以限制选择、移动、大小调整和分组。"
---
## **背景**

Aspose.Slides for .NET 的常见用例是作为自动化工作流的一部分创建、更新和保存 PowerPoint (PPTX) 演示文稿。当用户收到这些演示文稿时，限制对形状的更改可以帮助保留预期的布局和内容。

本文说明了形状在幻灯片上的组织方式以及如何在 PPTX 演示文稿中应用和移除形状锁定。这些锁定让您能够限制对单个形状的特定编辑操作。

## **幻灯片的组成**

演示文稿的幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接器以及用于构建演示文稿的其他元素等组件组成。在 Aspose.Slides for .NET 中，幻灯片上的每个元素都由实现 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 接口或继承自实现该接口的类的对象表示。

不同的形状类型提供不同的锁定选项。[IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) 接口是形状锁定的基础接口。Aspose.Slides for .NET 提供以下锁定接口：

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) 锁定自动形状。  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) 锁定连接器形状。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) 锁定图形对象。  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) 锁定组合形状。  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 锁定图片框。  

要在整个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 中应用锁定，遍历其幻灯片并对每个受支持的形状设置相应的锁定。

## **应用和移除保护**

形状锁定限制选择、移动和调整大小等操作。它们并不会使整个演示文稿不可编辑。

### **对 PPTX 形状应用保护**

Aspose.Slides for .NET 提供 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 接口，以便在幻灯片上处理形状。

示例为自动形状将 [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/)、[PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) 和 [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) 设置为 `true`，并对组合形状、连接器和图片框使用等效的锁定。连接器使用 [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) 来移动；组合形状还使用 [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) 来限制分组。

示例加载现有的 PPTX 演示文稿，检查每个幻灯片的形状集合，并保存一个应用了这些限制的副本。四种已处理类型之外的形状保持不变。循环不会遍历组内部的子形状。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **移除保护**

要移除形状锁定，将其值设为 `false`。下面的示例加载一个带有形状锁定的演示文稿，并通过 [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) 和 [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 清除选择、移动和调整大小的限制。它还会清除 [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) 并保存演示文稿的副本。其他锁定设置保持不变。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **结论**

Aspose.Slides for .NET 允许您对单个形状限制特定的编辑操作，或在整个幻灯片中应用相同的限制。选择每种形状类型支持的锁定，并在需要移除这些限制时将其值设为 `false`。

## **常见问题**

**我可以在同一演示文稿中同时使用形状锁定和密码保护吗？**

可以。形状锁定限制特定的编辑操作，而 [password protection](/slides/zh/net/password-protected-presentation/) 可以限制打开或修改演示文稿。您可以在同一个文件中同时使用这两者。

**我可以仅对特定幻灯片进行编辑限制而不影响其他幻灯片吗？**

可以。只对选定幻灯片上的形状应用锁定。这不会更改其他幻灯片的锁定设置。

**如何对组内的单个形状应用锁定？**

遍历组的 [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) 集合，对每个子形状应用相应的锁定。对任何嵌套组重复此操作。上述示例仅处理幻灯片的形状集合，因此未对单个组成员设置锁定。