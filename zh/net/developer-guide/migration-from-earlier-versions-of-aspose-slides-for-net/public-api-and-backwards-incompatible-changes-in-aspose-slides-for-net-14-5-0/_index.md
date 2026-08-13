---
title: Aspose.Slides for .NET 14.5.0 中的公共 API 与向后不兼容的更改
linktitle: Aspose.Slides for .NET 14.5.0
type: docs
weight: 70
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- 迁移
- 旧代码
- 现代代码
- 旧方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

本页面列出所有[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) 类、方法、属性等，以及任何新的[限制](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) 和其他[更改](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)，这些均是随 Aspose.Slides for .NET 14.5.0 API 引入的。

{{% /alert %}} 
## **公共 API 和向后不兼容的更改**
### **已添加的接口、类、属性和方法**
#### **已添加 Aspose.Slides.IPresentationInfo 接口和 PresentationInfo 类**
表示演示文稿信息。

- 布尔属性 IsEncrypted 如果演示文稿已加密则返回 True，否则返回 False。
- 属性 LoadFormat 获取演示文稿的类型。
#### **已添加 Aspose.Slides.IShape.IsGrouped 属性**
属性 Aspose.Slides.IShape.IsGrouped 用于确定形状是否已分组。
#### **已添加 Aspose.Slides.IShape.ParentGroup 属性**
属性 Aspose.Slides.IShape.ParentGroup 在形状已分组时返回其父 GroupShape 对象，否则返回 null。
#### **已添加 Aspose.Slides.IShapeCollection.AddGroupShape() 方法**
方法 Aspose.Slides.IShapeCollection.AddGroupShape() 创建一个新的 GroupShape 并将其添加到集合的末尾。
当添加新形状时，GroupShape 的框架大小和位置将适配内容。
#### **已添加 Aspose.Slides.IShapeCollection.Clear() 方法**
方法 Aspose.Slides.IShapeCollection.Clear() 移除集合中的所有形状。
#### **已添加 Aspose.Slides.IShapeCollection.InsertGroupShape(int) 方法**
方法 Aspose.Slides.IShapeCollection.InsertGroupShape(int) 创建一个新的 GroupShape 并将其插入到集合中指定的索引位置。
当添加新形状时，GroupShape 的框架大小和位置将适配内容。
#### **已添加 IPresentationFactory.GetPresentationInfo(string file)、IPresentatoinFactory.GetPresentationInfo(Stream stream) 方法**
这些方法允许在不完全加载演示文稿的情况下获取演示文稿文件或流的信息。
#### **已添加 IPresentationFactory PresentationFactory.Instance 属性**
此属性允许开发者在无需实例化的情况下使用工厂功能。
### **限制**
#### **对 IShape.Frame 的限制**
已添加对 IShape.Frame 使用未定义值的限制。尝试将未定义的框架分配给 IShape.Frame 的代码在大多数情况下没有意义（尤其是当父 GroupShape 嵌套在其他 {{GroupShape}} 中时）。例如：

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// 抛出 ArgumentException：框架值必须已定义。
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

或

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// 抛出 ArgumentException：x、y、width 和 height 必须已定义。
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

此类代码可能导致不明确的情况。因此已添加对 IShape.Frame 使用未定义值的限制。x、y、width、height、flipH、flipV 和 rotationAngle 的值必须已定义（且不能设为 float.NaN 或 NullableBool.NotDefined）。上述示例代码现在会抛出 ArgumentException 异常。
此限制适用于以下使用情况：

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// x、y、width 和 height 参数不能为 float.NaN，且 flipH、flipV
// 不能为 NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// 同样的限制适用于所有创建形状的方法：
// AddAudioFrameCD、AddAudioFrameEmbedded、AddAudioFrameLinked、AddAutoShape、AddChart、
// AddConnector、AddOleObjectFrame、AddPictureFrame、AddSmartArt、AddTable、AddVideoFrame、
// InsertAudioFrameEmbedded、InsertAudioFrameLinked、InsertAutoShape、InsertChart、
// InsertConnector、InsertOleObjectFrame、InsertPictureFrame、InsertTable、InsertVideoFrame。
``` 

但 IShape.RawFrame 框架属性可以是未定义的。当形状链接到占位符时，这种情况是合理的。此时未定义的形状框架值会从父占位符形状中覆盖。如果没有父占位符形状，则该形状在基于其 IShape.RawFrame 计算有效框架时使用默认值。默认值为 x、y、width、height、flipH、flipV 和 rotationAngle 的 0 和 NullableBool.False。例如：

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 形状已链接到占位符
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // 现在形状从占位符继承 x、y、height、flipH、flipV 值，并覆盖 width=100 和 rotationAngle=0.
}
``` 
### **已更改的属性**
#### **已更改 Aspose.Slides.IShapeCollection.Parent 属性的名称和类型**
- Aspose.Slides.IShapeCollection.Parent 属性的类型已从 ISlideComponent 更改为新的 IGroupShape 接口。IGroupShape 接口是 ISlideComponent 的子接口，因此现有代码无需进行适配。
- Aspose.Slides.IShapeCollection.Parent 属性的名称已从 Parent 更改为 ParentGroup。
#### **已更改 Aspose.Slides.IShapeFrame.FlipH、FlipV 属性的类型**
- Aspose.Slides.IShapeFrame.FlipH 属性的类型已从 bool 更改为 NullableBool。
- IShape.Frame 属性返回 IShapeFrame 的有效实例（其中所有属性均具有已定义的有效值）。
- IShape.RawFrame 属性返回 IShapeFrame 的实例，其每个属性都可以是未定义值（尤其是 FlipH 或 FlipV 可以为 NullableBool.NotDefined）。