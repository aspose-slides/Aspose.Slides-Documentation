---
title: Aspose.Slides for .NET 14.5.0 的公共 API 及向后不兼容的更改
linktitle: Aspose.Slides for .NET 14.5.0
type: docs
weight: 70
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出 Aspose.Slides for .NET 14.5.0 API 中新增的所有 [added](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) 类、方法、属性等，以及任何新的 [restrictions](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) 和其他 [changes](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)。

{{% /alert %}} 
## **Public API and Backwards Incompatible Changes**
### **Added Interfaces, Classes, Properties and Methods**
#### **Added the Aspose.Slides.IPresentationInfo Interface and PresentationInfo Class**
表示演示文稿的信息。

- 布尔属性 IsEncrypted 在演示文稿被加密时返回 True，否则返回 False。
- 属性 LoadFormat LoadFormat 获取演示文稿的类型。
#### **Added the Aspose.Slides.IShape.IsGrouped Property**
属性 Aspose.Slides.IShape.IsGrouped 确定形状是否已分组。
#### **Added the Aspose.Slides.IShape.ParentGroup Property**
属性 Aspose.Slides.IShape.ParentGroup 在形状已分组时返回父 GroupShape 对象，否则返回 null。
#### **Added the Aspose.Slides.IShapeCollection.AddGroupShape() Method**
方法 Aspose.Slides.IShapeCollection.AddGroupShape() 创建一个新的 GroupShape 并将其添加到集合末尾。
当添加新形状时，GroupShape 的框架大小和位置将适配内容。
#### **Added the Aspose.Slides.IShapeCollection.Clear() Method**
方法 Aspose.Slides.IShapeCollection.Clear() 删除集合中的所有形状。
#### **Added the Aspose.Slides.IShapeCollection.InsertGroupShape(int) Method**
方法 Aspose.Slides.IShapeCollection.InsertGroupShape(int) 创建一个新的 GroupShape 并在指定索引位置插入到集合中。
当添加新形状时，GroupShape 的框架大小和位置将适配内容。
#### **Added the IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) Methods**
这些方法允许在不完整加载演示文稿的情况下获取演示文稿文件或流的信息。
#### **Added the IPresentationFactory PresentationFactory.Instance Property**
此属性允许开发者在无需实例化的情况下使用工厂功能。
### **Restrictions**
#### **Restrictions to IShape.Frame**
已对使用未定义值的 IShape.Frame 添加限制。对 IShape.Frame 赋予未定义的框架在大多数情况下没有意义（尤其是父 GroupShape 嵌套在其他 {{GroupShape}} 中时）。例如：

``` csharp
 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

或

``` csharp
 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

此类代码可能导致不明确的情况。因此对使用未定义值的 IShape.Frame 添加了限制。x、y、width、height、flipH、flipV 和 rotationAngle 的值必须已定义（且不能设置为 float.NaN 或 NullableBool.NotDefined）。上述示例代码现在会抛出 ArgumentException 异常。
这适用于以下使用场景：

``` csharp
 IShape shape = ...;

shape.Frame = ...; // 不能未定义

IShapeCollection shapes = ...;

// x、y、width、height 参数不能为 float.NaN:
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

但 IShape.RawFrame 的框架属性可以未定义。当形状链接到占位符时，这种情况是合理的。此时未定义的形状框架值会从父占位符形状中继承。如果没有父占位符形状，则该形状在根据 IShape.RawFrame 计算有效框架时使用默认值。默认值为 x、y、width、height、flipH、flipV 和 rotationAngle 的 0 和 NullableBool.False。例如：

``` csharp
 IShape shape = ...; // shape is linked to placeholder
shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);
// now shape inherits x, y, height, flipH, flipV values form placeholder and overrides width=100 and rotationAngle=0.
``` 
### **Changed Properties**
#### **Changed the Aspose.Slides.IShapeCollection.Parent Property Name and Type**
- Aspose.Slides.IShapeCollection.Parent 属性的类型已从 ISlideComponent 更改为新的 IGroupShape 接口。IGroupShape 接口是 ISlideComponent 的派生接口，现有代码无需适配。
- Aspose.Slides.IShapeCollection.Parent 属性的名称已从 Parent 改为 ParentGroup。
#### **Changed the Aspose.Slides.IShapeFrame.FlipH, .FlipV Properties Types**
- Aspose.Slides.IShapeFrame.FlipH 属性的类型已从 bool 更改为 NullableBool。
- IShape.Frame 属性返回 IShapeFrame 的有效实例（所有属性均拥有定义好的有效值）。
- IShape.RawFrame 属性返回 IShapeFrame 的实例，其中每个属性都可以是未定义的值（尤其是 FlipH 或 FlipV 可以为 NullableBool.NotDefined）。