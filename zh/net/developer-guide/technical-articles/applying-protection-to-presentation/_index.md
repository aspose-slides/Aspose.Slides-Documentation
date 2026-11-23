---
title: 使用形状锁在 .NET 中限制演示文稿编辑
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

Aspose.Slides for .NET 的常见用例是创建、更新并保存 PowerPoint（PPTX）演示文稿，作为自动化工作流的一部分。当用户收到这些演示文稿时，限制对形状的更改可以帮助保持预期的布局和内容。

本文说明了形状在幻灯片上的组织方式以及如何在 PPTX 演示文稿中应用和移除形状锁。这些锁可让您限制对单个形状的特定编辑操作。

## **幻灯片的组成**

演示文稿幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及用于构建演示文稿的其他元素等组件组成。在 Aspose.Slides for .NET 中，幻灯片上的每个元素都由实现了[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)接口或继承自实现该接口的类的对象表示。

不同的形状类型提供不同的锁定选项。[IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/)接口是形状锁的基接口。Aspose.Slides for .NET 提供以下锁定接口：

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) 锁定自动形状。  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) 锁定连接线形状。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) 锁定图形对象。  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) 锁定组合形状。  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 锁定图片框。  

要在整个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)上应用锁定，遍历其幻灯片并对每个受支持的形状设置相应的锁。

## **应用和移除保护**

兼容的演示文稿编辑器使用形状锁来限制单个编辑操作。文件加密和文档级写保护是单独的[presentation protection settings](/slides/zh/net/password-protected-presentation/)。

### **对 PPTX 形状应用保护**

Aspose.Slides for .NET 提供[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)接口，以便在幻灯片上处理形状。

示例将[SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/)、[PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/)和[SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/)设置为 `true`，用于自动形状；对组合形状、连接线和图片框也设置相应的锁。连接线使用[PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/)控制移动；组合还使用[GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/)限制分组。

示例加载现有 PPTX 演示文稿，检查每个幻灯片的形状集合，并保存一个已应用这些限制的副本。未列入四种处理类型的形状保持不变。循环不会遍历组合内部的子形状。

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

要移除形状锁，只需将其值设为 `false`。下面的示例加载包含形状锁的演示文稿，并通过[IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/)和[IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/)清除选择、移动和大小调整的限制。它还会清除[IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/)，并保存演示文稿的副本。其他锁定设置保持不变。

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

### **保留图片裁剪**

将在工作目录中放置名为 `photo.jpg` 的照片。示例从左侧裁剪 12%，从右侧裁剪 8%，然后在图片框上设置[CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/)。此标志限制进一步裁剪并保留现有裁剪。

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` 将裁剪锁存为 `true`。在 PowerPoint 中，选中照片时 **Crop** 命令被禁用。

### **保持图表分组**

示例将一个矩形和一条箭头组合，然后在该组合本身上设置[UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/)，以保持图表的各组件在一起。其他编辑操作，如移动组合或更改组件填充，仍然可用。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` 将解除组合锁存为 `true`。在 PowerPoint 中，选中整个图表时 **Ungroup** 命令被禁用。

### **结论**

Aspose.Slides for .NET 让您可以限制对单个形状的特定编辑操作，或在所有幻灯片上应用相同的限制。请选择每种形状类型支持的锁，并在需要移除限制时将其值设为 `false`。

## **常见问题**

**我可以在同一演示文稿中同时使用形状锁和密码保护吗？**

是的。形状锁限制特定的编辑操作，而[password protection](/slides/zh/net/password-protected-presentation/)可以限制打开或修改演示文稿。您可以在同一文件中同时使用两者。

**我可以仅对特定幻灯片进行编辑限制而不影响其他幻灯片吗？**

是的。只对所选幻灯片上的形状应用锁定。这不会更改其他幻灯片的锁定设置。

**如何对组内的单个形状应用锁定？**

遍历组的[Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)集合，对每个子形状应用相应的锁定。对任何嵌套的组重复此操作。上述示例仅处理幻灯片的形状集合，因此不会对组内的单个成员设置锁定。