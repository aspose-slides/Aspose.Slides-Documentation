---
title: 使用形状锁限制 .NET 中的演示文稿编辑
linktitle: 限制演示文稿编辑
type: docs
weight: 70
url: /zh/net/applying-protection-to-presentation/
keywords:
- 防止编辑
- 防止被编辑
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
description: "了解如何使用 Aspose.Slides for .NET 在 PPTX 演示文稿中锁定和解锁形状，以限制选择、移动、大小调整和分组."
---
## **背景**

Aspose.Slides for .NET 的常见用途是作为自动化工作流的一部分创建、更新和保存 PowerPoint (PPTX) 演示文稿。当用户收到这些演示文稿时，限制对形状的更改可以帮助保持预期的布局和内容。

本文解释了形状在幻灯片上的组织方式以及如何在 PPTX 演示文稿中应用和移除形状锁。这些锁可让您限制对单个形状的特定编辑操作。

## **幻灯片的组成**

演示文稿幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及用于构建演示文稿的其他元素等组件组成。在 Aspose.Slides for .NET 中，幻灯片上的每个元素都由实现 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 接口或继承自实现该接口的类的对象表示。

不同的形状类型提供不同的锁定选项。[IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) 接口是形状锁的基础接口。Aspose.Slides for .NET 提供以下锁定接口：

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) 锁定自动形状。  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) 锁定连接线形状。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) 锁定图形对象。  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) 锁定组合形状。  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 锁定图片框。  

要在整个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 中应用锁定，请遍历其幻灯片并在每个受支持的形状上设置相应的锁。

## **应用和移除保护**

兼容的演示文稿编辑器使用形状锁来限制单个编辑操作。文件加密和文档级写入保护是独立的 [演示文稿保护设置](/slides/zh/net/password-protected-presentation/)。

### **对 PPTX 形状应用保护**

Aspose.Slides for .NET 提供了 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 接口，用于在幻灯片上操作形状。

示例将 [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/)、[PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/)、和 [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) 设置为 `true`，用于自动形状，并对组合形状、连接线和图片框使用等效的锁。连接线使用 [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) 来移动；组合还使用 [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) 来限制分组。

示例加载现有的 PPTX 演示文稿，检查每张幻灯片的形状集合中的形状，并保存一个应用了这些限制的副本。四种处理类型之外的形状保持不变。循环不会遍历组内部的子形状。

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

要移除形状锁，只需将其值设为 `false`。下面的示例加载一个带有形状锁的演示文稿，并通过 [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/)、和 [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) 清除选择、移动和大小调整的限制。同时清除 [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) 并保存演示文稿的副本。其他锁定设置保持不变。

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

在工作目录中放置一张名为 `photo.jpg` 的照片。示例对左侧裁剪 12%，右侧裁剪 8%，然后在图片框上设置 [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/)。此标志限制进一步裁剪并保留现有裁剪。

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

`PictureLocked.pptx` 将裁剪锁存为 `true`。在 PowerPoint 中，选择照片时 **Crop** 命令被禁用。

### **保持图表分组**

示例将矩形和箭头组合在一起，然后在该组本身上设置 [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/)，以保持图表的组件在一起。其他编辑操作，如移动组或更改组件填充，仍然可用。

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

`DiagramLocked.pptx` 将取消分组锁存为 `true`。在 PowerPoint 中，选择整个图表时 **Ungroup** 命令被禁用。

### **报告现有形状锁**

要审查模板，打开它并读取每个形状的锁对象。当该对象的所有标志均为禁用时，[NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) 为 `true`，只要有一个标志启用则为 `false`。组及其子形状有各自的锁对象，因此即使组没有锁，也要检查子形状。

此示例检查自动形状、图片框和组的移动，图片的裁剪，以及组的取消分组。它报告所识别的标志，并标记未检查的形状类型。

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

假设 `Sample.pptx` 的第 1 张幻灯片包含一个名为 `Layout`、已锁定取消分组的组，其中的图片 `Photo` 已锁定裁剪，另有一个未锁定的矩形 `Free`。报告会跳过 `Free`，并打印以下两行：

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

报告读取已存储的形状级编辑标志，但不更改它们或保存演示文稿。文档级写入保护是另一个设置，每个标志的强制执行取决于编辑器。

### **结论**

Aspose.Slides for .NET 允许您限制对单个形状的特定编辑操作，或在整个幻灯片中应用相同的限制。请选择每种形状类型支持的锁，并在需要移除这些限制时将其值设为 `false`。

## **常见问题**

**我可以在同一个演示文稿中同时使用形状锁和密码保护吗？**

可以。形状锁限制特定的编辑操作，而 [密码保护](/slides/zh/net/password-protected-presentation/) 可以限制打开或修改演示文稿。您可以在同一个文件中同时使用两者。

**我可以仅限制特定幻灯片的编辑而不影响其他幻灯片吗？**

可以。仅对选定幻灯片上的形状应用锁定。这不会更改其他幻灯片的锁定设置。

**如何对组内的单个形状应用锁？**

遍历组的 [形状集合](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)，对每个子形状应用相应的锁。对任何嵌套组重复此操作，遵循报告示例中的遍历方式。