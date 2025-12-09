---
title: Aspose.Slides for .NET 14.5.0 中的公共 API 与向后不兼容的更改
linktitle: Aspose.Slides for .NET 14.5.0
type: docs
weight: 70
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审查 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出所有[新增](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)类、方法、属性等，任何新的[限制](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)以及其他[更改](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)，这些都是在 Aspose.Slides for .NET 14.5.0 API 中引入的。

{{% /alert %}} 
## **公共 API 与向后不兼容的更改**
### **新增的接口、类、属性和方法**
#### **新增 Aspose.Slides.IPresentationInfo 接口和 PresentationInfo 类**
表示关于演示文稿的信息。

- Boolean 属性 IsEncrypted 在演示文稿被加密时返回 True，否则返回 False。
- 属性 LoadFormat 获取演示文稿的类型。

#### **新增 Aspose.Slides.IShape.IsGrouped 属性**
Aspose.Slides.IShape.IsGrouped 属性确定形状是否已分组。

#### **新增 Aspose.Slides.IShape.ParentGroup 属性**
Aspose.Slides.IShape.ParentGroup 属性在形状已分组时返回父 GroupShape 对象；否则返回 null。

#### **新增 Aspose.Slides.IShapeCollection.AddGroupShape() 方法**
Aspose.Slides.IShapeCollection.AddGroupShape() 方法创建一个新的 GroupShape 并将其添加到集合的末尾。
当添加新形状时，GroupShape 的框架大小和位置将适配内容。

#### **新增 Aspose.Slides.IShapeCollection.Clear() 方法**
Aspose.Slides.IShapeCollection.Clear() 方法从集合中移除所有形状。

#### **新增 Aspose.Slides.IShapeCollection.InsertGroupShape(int) 方法**
Aspose.Slides.IShapeCollection.InsertGroupShape(int) 方法创建一个新的 GroupShape 并在指定的索引位置插入到集合中。
当添加新形状时，GroupShape 的框架大小和位置将适配内容。

#### **新增 IPresentationFactory.GetPresentationInfo(string file)、IPresentatoinFactory.GetPresentationInfo(Stream stream) 方法**
这些方法允许在不完整加载演示文稿的情况下获取演示文稿文件或流的信息。

#### **新增 IPresentationFactory PresentationFactory.Instance 属性**
此属性允许开发者在无需实例化的情况下使用工厂功能。

### **限制**
#### **对 IShape.Frame 的限制**
已对 IShape.Frame 使用未定义值添加了限制。尝试为 IShape.Frame 赋予未定义框架的代码在大多数情况下没有意义（特别是当父 GroupShape 多次嵌套在其他 {{GroupShape}} 中时）。例如：

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

或

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

此类代码可能导致不明确的情况。因此对 IShape.Frame 使用未定义值添加了限制。x、y、width、height、flipH、flipV 和 rotationAngle 的值必须已定义（且不能设为 float.NaN 或 NullableBool.NotDefined）。上述示例代码现在会抛出 ArgumentException 异常。此规则适用于以下使用情况：

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Cannot be undefined

IShapeCollection shapes = ...;

// x, y, width, height parameters cannot be float.NaN:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}


``` 

但是 IShape.RawFrame 的框架属性可以是未定义的。当形状链接到占位符时，这样是有意义的。未定义的形状框架值将从父占位符形状覆盖。如果不存在父占位符形状，则该形状在基于其 IShape.RawFrame 计算有效框架时使用默认值。默认值为 x、y、width、height、flipH、flipV 和 rotationAngle 的 0 和 NullableBool.False。例如：

``` csharp

 IShape shape = ...; // shape is linked to placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// now shape inherits x, y, height, flipH, flipV values form placeholder and overrides width=100 and rotationAngle=0.

``` 
### **已更改的属性**
#### **更改了 Aspose.Slides.IShapeCollection.Parent 属性的名称和类型**
- Aspose.Slides.IShapeCollection.Parent 属性的类型已从 ISlideComponent 更改为新的 IGroupShape 接口。IGroupShape 接口是 ISlideComponent 的派生接口，现有代码无需适配。
- Aspose.Slides.IShapeCollection.Parent 属性的名称已从 Parent 更改为 ParentGroup。

#### **更改了 Aspose.Slides.IShapeFrame.FlipH、.FlipV 属性的类型**
- Aspose.Slides.IShapeFrame.FlipH 属性的类型已从 bool 更改为 NullableBool。
- IShape.Frame 属性返回一个有效的 IShapeFrame 实例（其中所有属性都有已定义的有效值）。
- IShape.RawFrame 属性返回一个 IShapeFrame 实例，其每个属性都可以是未定义的（特别是 FlipH 或 FlipV 可以是 NullableBool.NotDefined）。