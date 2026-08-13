---
title: Aspose.Slides for Java 14.5.0 中的公共 API 及向后不兼容的更改
linktitle: Aspose.Slides for Java 14.5.0
type: docs
weight: 40
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审阅 Aspose.Slides for Java 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出所有 [added](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) 类、方法、属性等，任何新的 [restrictions](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) 和其他 [changes](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)，这些都是在 Aspose.Slides for Java 14.5.0 API 中引入的。

{{% /alert %}} 
## **公共 API 及向后不兼容的更改**
### **已添加的类和方法**
#### **已添加 Aspose.Slides.IPresentationInfo 接口和 PresentationInfo 类**
表示关于演示文稿的信息。

Method Boolean isEncrypted() 在演示文稿被加密时返回 True，否则返回 False。

Method LoadFormat getLoadFormat() 获取演示文稿的类型。
#### **已添加 Aspose.Slides.IShape.isGrouped() 方法**
Aspose.Slides.IShape.isGrouped() 方法确定形状是否已分组。
#### **已添加 Aspose.Slides.IShape.getParentGroup() 方法**
Aspose.Slides.IShape.getParentGroup() 方法在形状已分组时返回父 GroupShape 对象，否则返回 null。
#### **已添加 Aspose.Slides.IShapeCollection.addGroupShape() 方法**
Aspose.Slides.IShapeCollection.addGroupShape() 方法创建一个新的 GroupShape 并将其添加到集合末尾。

当向 GroupShape 中添加新形状时，GroupShape 的帧大小和位置将适配内容。
#### **已添加 Aspose.Slides.IShapeCollection.clear() 方法**
Aspose.Slides.IShapeCollection.clear() 方法移除集合中的全部形状。
#### **已添加 Aspose.Slides.IShapeCollection.insertGroupShape(int) 方法**
Aspose.Slides.IShapeCollection.insertGroupShape(int) 方法创建一个新的 GroupShape 并在指定索引处插入到集合中。

当向 GroupShape 中添加新形状时，GroupShape 的帧大小和位置将适配内容。
#### **已添加 IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream) 方法**
这些方法允许开发人员在不完整加载演示文稿的情况下获取演示文稿文件/流的信息。
#### **已添加 IPresentationFactory PresentationFactory.getInstance() 方法**
允许在无需实例化的情况下使用工厂功能。
### **限制**
#### **已为 IShape.getFrame() 使用未定义值添加限制**
尝试将未定义的帧赋给 IShape.setFrame(IShapeFrame) 的代码在一般情况下没有意义（尤其是当父 GroupShape 多层嵌套在其他 {{GroupShape}} 中时）。例如：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // 抛出 ArgumentException：框架值必须已定义。
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

或

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // 抛出 ArgumentException：x、y、width 和 height 值必须已定义。
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

此类代码可能导致不明确的情况。因此为使用 IShape.Frame 的未定义值添加了限制。x、y、width、height、flipH、flipV 和 rotationAngle 的值必须已定义（不能为 Float.NaN 或 NullableBool.NotDefined）。上述示例代码现在会抛出 ArgumentException 异常。
这适用于以下使用场景：

``` java
// 传递给 IShape.setFrame(IShapeFrame) 的框架不能包含未定义的值.

// 以下 IShapeCollection 方法的 x、y、width 和 height 参数
// 也不能为 Float.NaN：
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

但 IShape.getRawFrame() 的帧可以是未定义的。当形状链接到占位符时，这种情况是合理的。此时未定义的形状帧值会从父占位符形状覆盖。如果该形状没有父占位符形状，则在基于其 IShape.getRawFrame() 计算有效帧时使用默认值。默认值为 x、y、width、height、flipH、flipV 和 rotationAngle 的 0 和 NullableBool.False。例如：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // 该形状链接到占位符.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // 现在该形状从占位符继承 x, y, height, flipH 和 flipV 值
    // 并将 width = 100 和 rotationAngle = 0 覆盖.
} finally {
    if (pres != null) pres.dispose();
}
```
### **已更改的属性**
#### **已更改 Aspose.Slides.IShapeCollection.getParent() 方法的类型和名称**
Aspose.Slides.IShapeCollection.Parent 属性的类型已从 ISlideComponent 更改为新的 IGroupShape 接口。IGroupShape 接口是 ISlideComponent 的子接口，现有代码无需适配。

Aspose.Slides.IShapeCollection.getParent() 方法的名称已从 getParent 更改为 getParentGroup()。
#### **更改 Aspose.Slides.IShapeFrame.getFlipH() 和 .getFlipV() 方法的类型**
Aspose.Slides.IShapeFrame.getFlipH() 方法的类型已从 bool 更改为 NullableBool。

IShape.getFrame() 方法返回 IShapeFrame 的有效实例（其所有属性都有已定义的有效值）。

IShape.getRawFrame() 方法返回 IShapeFrame 实例，其中每个属性都可能是未定义的（尤其是 FlipH 或 FlipV 可以是 NullableBool.NotDefined）。