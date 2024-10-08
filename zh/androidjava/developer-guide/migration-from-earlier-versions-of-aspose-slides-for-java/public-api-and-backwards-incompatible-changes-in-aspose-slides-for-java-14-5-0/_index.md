---
title: Aspose.Slides for Java 14.5.0 的公共 API 和向后不兼容的变化
type: docs
weight: 40
url: /zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

此页面列出所有 [新增](/slides/zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) 的类、方法、属性等，任何新的 [限制](/slides/zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) 和其他 [变更](/slides/zh/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) 在 Aspose.Slides for Java 14.5.0 API 中引入。

{{% /alert %}} 
## **公共 API 和向后不兼容的变化**
### **新增的类和方法**
#### **新增 Aspose.Slides.IPresentationInfo 接口和 PresentationInfo 类**
表示关于演示文稿的信息。

方法 Boolean isEncrypted() 如果演示文稿被加密则返回 True，否则返回 False。

方法 LoadFormat getLoadFormat() 获取演示文稿类型。
#### **新增 Aspose.Slides.IShape.isGrouped() 方法**
方法 Aspose.Slides.IShape.isGrouped() 确定形状是否被分组。
#### **新增 Aspose.Slides.IShape.getParentGroup() 方法**
方法 Aspose.Slides.IShape.getParentGroup() 如果形状是分组的则返回父 GroupShape 对象，否则返回 null。
#### **新增 Aspose.Slides.IShapeCollection.addGroupShape() 方法**
方法 Aspose.Slides.IShapeCollection.addGroupShape() 创建一个新的 GroupShape 并将其添加到集合的末尾。

当新的形状被添加到 GroupShape 时，GroupShape 的框架大小和位置将被调整以适应内容。
#### **新增 Aspose.Slides.IShapeCollection.clear() 方法**
方法 Aspose.Slides.IShapeCollection.clear() 从集合中移除所有形状。
#### **新增 Aspose.Slides.IShapeCollection.insertGroupShape(int) 方法**
方法 Aspose.Slides.IShapeCollection.insertGroupShape(int) 创建一个新的 GroupShape，并将其插入到指定索引的集合中。
当新的形状被添加到 GroupShape 时，GroupShape 的框架大小和位置将被调整以适应内容。
#### **新增 IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream) 方法**
这些方法允许开发人员在不完全加载演示文稿的情况下获取演示文稿文件/流的信息。
#### **新增 IPresentationFactory PresentationFactory.getInstance() 方法**
允许在不实例化的情况下使用工厂功能。
### **限制**
#### **对使用未定义值的 IShape.getFrame() 添加了限制**
尝试将未定义框架分配给 IShape.setFrame(IShapeFrame) 的代码在一般情况下是没有意义的（特别是在父 GroupShape 多重嵌套于其他 {{GroupShape}} 中）。例如：

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

或

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

这样的代码可能会导致不清楚的情况。因此，已对使用未定义值的 IShape.Frame 添加限制。x、y、宽度、高度、flipH、flipV 和 rotationAngle 的值必须被定义（不能是 Float.NaN 或 NullableBool.NotDefined）。上面的示例代码现在会抛出 ArgumentException 异常。
这适用于以下用例：

``` java

 IShape shape = ...;

shape.setFrame(...); // 不能是未定义的

IShapeCollection shapes = ...;

// x, y, width, height 参数不能是 Float.NaN：

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

但是 IShape.getRawFrame() 框架可以是未定义的。当形状链接到占位符时，这样做是合理的。然后未定义的形状框架值将从父占位符形状中覆盖。如果该形状没有父占位符形状，则在根据其 IShape.getRawFrame() 评估有效框架时，将使用默认值。默认值为 x、y、宽度、高度、flipH、flipV 和 rotationAngle 的默认值为 0 和 NullableBool.False。例如：

``` java

 IShape shape = ...; // shape 连接到占位符

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// 现在形状继承占位符的 x、y、高度、flipH、flipV 值，并覆盖宽度=100 和 rotationAngle=0。

```
### **更改的属性**
#### **改变了 Aspose.Slides.IShapeCollection.getParent() 方法的类型和名称**
Aspose.Slides.IShapeCollection.Parent 属性的类型已从 ISlideComponent 更改为新的 IGroupShape 接口。IGroupShape 接口是 ISlideComponent 的子类，因此现有代码无需调整。

Aspose.Slides.IShapeCollection.getParent() 方法的名称已从 getParent 更改为 getParentGroup()。
#### **改变 Aspose.Slides.IShapeFrame.getFlipH() 和 .getFlipV() 方法的类型**
Aspose.Slides.IShapeFrame.getFlipH() 方法的类型已从 bool 更改为 NullableBool。

IShape.getFrame() 方法返回 IShapeFrame 的有效实例（其所有属性都有定义的有效值）。

IShape.getRawFrame() 方法返回一个 IShapeFrame 实例，其每个属性可以有未定义的值（特别是 FlipH 或 FlipV 可以有值 NullableBool.NotDefined）。