---
title: 使用形状锁防止演示文稿编辑
linktitle: 防止演示文稿编辑
type: docs
weight: 70
url: /zh/net/applying-protection-to-presentation/
keywords:
- 防止编辑
- 防止被编辑
- 锁定形状
- 锁定位置
- 锁定选择
- 锁定大小
- 锁定分组
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 如何在 PPT、PPTX 和 ODP 文件中锁定或解锁形状，保护演示文稿的安全，同时允许受控编辑并加快交付速度。"
---

## **背景**

Aspose.Slides 的常见用途是作为自动化工作流的一部分，创建、更新和保存 Microsoft PowerPoint (PPTX) 演示文稿。以这种方式使用 Aspose.Slides 的应用程序的用户可以访问生成的演示文稿，因此保护它们不被编辑是一个常见的关注点。确保自动生成的演示文稿保留其原始格式和内容非常重要。

本文说明了演示文稿和幻灯片的结构以及 Aspose.Slides for .NET 如何对演示文稿应用保护并随后移除保护。它为开发人员提供了一种控制其应用程序生成的演示文稿使用方式的方法。

## **幻灯片的组成**

演示文稿幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接器以及用于构建演示文稿的其他元素等组件组成。在 Aspose.Slides for .NET 中，幻灯片上的每个元素都由实现了 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 接口或继承自实现该接口的类的对象表示。

PPTX 的结构相当复杂，因此不同于 PPT（在 PPT 中可以对所有类型的形状使用通用锁），不同的形状类型需要不同的锁。[IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) 接口是 PPTX 的通用锁定类。Aspose.Slides for .NET 在 PPTX 中支持以下类型的锁定：

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) 锁定自动形状。  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) 锁定连接器形状。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) 锁定图形对象。  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) 锁定组合形状。  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 锁定图片框。  

对 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 对象中所有形状对象执行的任何操作都会应用于整个演示文稿。

## **应用和移除保护**

应用保护可确保演示文稿无法被编辑。这是保护演示文稿内容的有效技术。

### **对 PPTX 形状应用保护**

Aspose.Slides for .NET 提供了用于处理幻灯片上形状的 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 接口。

如前所述，每个形状类都有相应的形状锁定类用于保护。本文重点介绍 NoSelect、NoMove 和 NoResize 锁。这些锁确保形状无法被选中（通过鼠标点击或其他选择方式），且无法移动或调整大小。

下面的代码示例对演示文稿中的所有形状类型应用保护。
```cs
// 实例化表示 PPTX 文件的 Presentation 类。
using Presentation presentation = new Presentation("Sample.pptx");

// Traversing all the slides in the presentation.
    // 遍历演示文稿中的所有幻灯片。
    foreach (ISlide slide in presentation.Slides)
    {
        // Traversing all the shapes in the slide.
        // 遍历幻灯片中的所有形状。
        foreach (IShape shape in slide.Shapes)
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

// Saving the presentation file.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```


### **移除保护**

要解锁形状，请将已应用锁的值设为 `false`。以下代码示例展示了如何在已锁定的演示文稿中解锁形状。
```cs
// 实例化表示 PPTX 文件的 Presentation 类。
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// 遍历演示文稿中的所有幻灯片。
foreach (ISlide slide in presentation.Slides)
{
    // 遍历幻灯片中的所有形状。
    foreach (IShape shape in slide.Shapes)
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

// 保存演示文稿文件。
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```


### **结论**

Aspose.Slides 提供了多种保护演示文稿中形状的选项。您可以锁定单个形状，或遍历演示文稿中的所有形状并逐一锁定，从而有效地保护整个文件。通过将锁的值设为 `false` 可以移除保护。

## **常见问题**

**我可以在同一演示文稿中同时使用形状锁和密码保护吗？**

是的。锁定限制文件内对象的编辑，而 [password protection](/slides/zh/net/password-protected-presentation/) 控制打开和/或保存更改的访问权限。这两种机制相辅相成，共同工作。

**我可以只限制特定幻灯片的编辑，而不影响其他幻灯片吗？**

是的。对所选幻灯片上的形状应用锁定；其余幻灯片仍保持可编辑。

**形状锁是否适用于组合对象和连接器？**

是的。针对组合、连接器、图形对象以及其他形状类型均支持专用的锁定类型。