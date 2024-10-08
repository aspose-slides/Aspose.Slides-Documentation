---
title: Aspose.Slides for .NET 14.5.0 的公共 API 和向后不兼容更改
type: docs
weight: 70
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
---

{{% alert color="primary" %}} 

此页面列出了与 Aspose.Slides for .NET 14.5.0 API 相关的所有 [添加的](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) 类、方法、属性等，以及任何新的 [限制](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) 和其他 [更改](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)。

{{% /alert %}} 
## **公共 API 和向后不兼容更改**
### **添加的接口、类、属性和方法**
#### **添加了 Aspose.Slides.IPresentationInfo 接口和 PresentationInfo 类**
表示演示文稿的信息。

- 如果一个演示文稿被加密，则布尔属性 IsEncrypted 返回 True，否则返回 False。
- 属性 LoadFormat 获取演示文稿的类型。
#### **添加了 Aspose.Slides.IShape.IsGrouped 属性**
属性 Aspose.Slides.IShape.IsGrouped 确定一个形状是否被分组。
#### **添加了 Aspose.Slides.IShape.ParentGroup 属性**
属性 Aspose.Slides.IShape.ParentGroup 在形状被分组的情况下返回父 GroupShape 对象。否则返回 null。
#### **添加了 Aspose.Slides.IShapeCollection.AddGroupShape() 方法**
方法 Aspose.Slides.IShapeCollection.AddGroupShape() 创建一个新的 GroupShape 并将其添加到集合的末尾。
当添加新形状时，GroupShape 框架的大小和位置将适应内容。
#### **添加了 Aspose.Slides.IShapeCollection.Clear() 方法**
方法 Aspose.Slides.IShapeCollection.Clear() 从集合中删除所有形状。
#### **添加了 Aspose.Slides.IShapeCollection.InsertGroupShape(int) 方法**
方法 Aspose.Slides.IShapeCollection.InsertGroupShape(int) 创建一个新的 GroupShape 并将其插入到集合的指定索引位置。
当添加新形状时，GroupShape 框架的大小和位置将适应内容。
#### **添加了 IPresentationFactory.GetPresentationInfo(string file)、IPresentationFactory.GetPresentationInfo(Stream stream) 方法**
这些方法允许在不完全加载演示文稿的情况下获取有关演示文稿文件或流的信息。
#### **添加了 IPresentationFactory PresentationFactory.Instance 属性**
该属性允许开发人员在无需实例化的情况下使用工厂功能。
### **限制**
#### **对 IShape.Frame 的限制**
对使用未定义的值作为 IShape.Frame 新增了限制。代码在大多数情况下尝试将未定义帧分配给 IShape.Frame 是没有意义的（特别是在父 GroupShape 嵌套多层的情况下）。例如：

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

或者

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

这样的代码可能导致不清晰的情况。因此对使用未定义值作为 IShape.Frame 增加了限制。x、y、宽度、高度、flipH、flipV 和 rotationAngle 的值必须被定义（并且不能设置为 float.NaN 或 NullableBool.NotDefined）。上述示例代码现在会抛出 ArgumentException 异常。
这适用于以下用例：

``` csharp

 IShape shape = ...;

shape.Frame = ...; // 不能未定义

IShapeCollection shapes = ...;

// x, y, width, height 参数不能为 float.NaN：

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

但是 IShape.RawFrame 框架属性可以未定义。这在形状链接到占位符时是有意义的。此时，未定义的形状框架值将从父占位符形状中覆盖。如果没有父占位符形状，则该形状在根据其 IShape.RawFrame 评估有效框架时使用默认值。默认值为 0 和 NullableBool.False，适用于 x、y、宽度、高度、flipH、flipV 和 rotationAngle。例如：

``` csharp

 IShape shape = ...; // shape 链接到占位符

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// 现在形状从占位符继承 x、y、高度、flipH、flipV 值，并覆盖 width=100 和 rotationAngle=0。

``` 
### **更改的属性**
#### **更改了 Aspose.Slides.IShapeCollection.Parent 属性的名称和类型**
- Aspose.Slides.IShapeCollection.Parent 属性的类型已从 ISlideComponent 更改为新的 IGroupShape 接口。IGroupShape 接口是 ISlideComponent 的子类，因此现有代码无需适配。
- Aspose.Slides.IShapeCollection.Parent 属性的名称已从 Parent 更改为 ParentGroup。
#### **更改了 Aspose.Slides.IShapeFrame.FlipH、.FlipV 属性的类型**
- Aspose.Slides.IShapeFrame.FlipH 属性的类型已从 bool 更改为 NullableBool。
- IShape.Frame 属性返回 IShapeFrame 的有效实例（所有属性都有定义的有效值）。
- IShape.RawFrame 属性返回一个 IShapeFrame 的实例，其中每个属性可以具有未定义值（特别是 FlipH 或 FlipV 可能具有值 NullableBool.NotDefined）。