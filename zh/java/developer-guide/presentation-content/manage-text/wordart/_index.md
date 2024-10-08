---
title: WordArt
type: docs
weight: 110
url: /java/wordart/
---


## **关于WordArt?**
WordArt或文字艺术是一个功能，允许您对文本应用效果以使其更加突出。例如，通过WordArt，您可以给文本添加轮廓或用颜色（或渐变）填充，添加3D效果等。您还可以扭曲、弯曲和拉伸文本的形状。

{{% alert color="primary" %}} 

WordArt允许您将文本视为图形对象。通常，WordArt包含对文本进行的效果或特殊修改，以使其更具吸引力或更显眼。

{{% /alert %}} 

**Microsoft PowerPoint中的WordArt**

要在Microsoft PowerPoint中使用WordArt，您必须选择预定义的WordArt模板之一。WordArt模板是一组应用于文本或其形状的效果。

**Aspose.Slides中的WordArt**

在Aspose.Slides for Java 20.10中，我们实现了对WordArt的支持，并在后续的Aspose.Slides for Java版本中改进了该功能。

使用Aspose.Slides for Java，您可以轻松创建自己的WordArt模板（一个效果或效果的组合）并将其应用于文本。

## 创建简单的WordArt模板并应用于文本

**使用Aspose.Slides** 

首先，我们使用以下Java代码创建简单的文本：

``` java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
现在，我们设置文本的字体高度为更大的值，以通过以下代码使效果更加明显：

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**使用Microsoft PowerPoint**

在Microsoft PowerPoint中打开WordArt效果菜单：

![todo:image_alt_text](image-20200930113926-1.png)

从右侧菜单中，您可以选择预定义的WordArt效果。在左侧菜单中，您可以指定新WordArt的设置。

以下是一些可用的参数或选项：

![todo:image_alt_text](image-20200930114015-3.png)

**使用Aspose.Slides**

在这里，我们使用以下代码将[SmallGrid](https://reference.aspose.com/slides/java/com.aspose.slides/PatternStyle#SmallGrid)模式颜色应用于文本，并添加一个 1 宽的黑色文本边框：

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

生成的文本：

![todo:image_alt_text](image-20200930114108-4.png)

## 应用其他WordArt效果

**使用Microsoft PowerPoint**

从程序接口中，您可以将这些效果应用于文本、文本块、形状或类似元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，可以将阴影、反射和发光效果应用于文本；3D格式和3D旋转效果可以应用于文本块；软边缘属性可以应用于形状对象（即使没有设置3D格式属性，它仍然有效）。

### 应用阴影效果

在这里，我们打算仅设置与文本相关的属性。我们使用Java中的以下代码将阴影效果应用于文本：

``` java
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
```

Aspose.Slides API支持三种类型的阴影：OuterShadow、InnerShadow和PresetShadow。

使用PresetShadow，您可以为文本应用阴影（使用预设值）。

**使用Microsoft PowerPoint**

在PowerPoint中，您可以使用一种类型的阴影。以下是一个示例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用Aspose.Slides**

Aspose.Slides实际上允许您同时应用两种类型的阴影：InnerShadow和PresetShadow。

**注意：**

- 当OuterShadow和PresetShadow一起使用时，仅应用OuterShadow效果。
- 如果同时使用OuterShadow和InnerShadow，则结果效果依赖于PowerPoint版本。例如，在PowerPoint 2013中，效果会加倍。但在PowerPoint 2007中，应用的是OuterShadow效果。

### 应用文本显示

我们通过以下Java代码示例向文本添加显示：

``` java
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);   
```

### 应用文本的发光效果

我们使用以下代码为文本应用发光效果，使其闪耀或突出：

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

操作的结果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

您可以更改阴影、显示和发光的参数。效果的属性在每个文本部分上单独设置。

{{% /alert %}} 

### 在WordArt中使用变换

我们通过以下代码使用Transform属性（存在于整个文本块中）：

``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

结果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint和Aspose.Slides for Java提供了一定数量的预定义变换类型。

{{% /alert %}} 

**使用PowerPoint**

要访问预定义的变换类型，请通过：**格式** -> **文本效果** -> **变换**

**使用Aspose.Slides**

要选择变换类型，请使用TextShapeType枚举。

### 将3D效果应用于文本和形状

我们使用以下示例代码为文本形状设置3D效果：

``` java
autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);

autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
autoShape.getThreeDFormat().setExtrusionHeight(6);

autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
autoShape.getThreeDFormat().setContourWidth(1.5);

autoShape.getThreeDFormat().setDepth(3);

autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

生成的文本及其形状：

![todo:image_alt_text](image-20200930114816-9.png)

我们使用以下Java代码为文本应用3D效果：

``` java
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

操作的结果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

将3D效果应用于文本或其形状的过程以及效果之间的相互作用基于某些规则。

考虑一个文本的场景和包含该文本的形状。3D效果包含3D对象的表示和放置对象的场景。

- 当为图形和文本设置场景时，图形场景具有更高的优先级——文本场景被忽略。
- 当图形没有自己的场景但具有3D表示时，使用文本场景。
- 否则——当形状最初没有3D效果时，形状是平面的，3D效果仅应用于文本。

这些描述与ThreeDFormat.getLightRig()和ThreeDFormat.getCamera()方法相关。

{{% /alert %}} 

## **将外阴影效果应用于文本**
Aspose.Slides for Java提供了[**IOuterShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IOuterShadow)和[**IInnerShadow**](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IInnerShadow)类，允许您将阴影效果应用于由[TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame)承载的文本。请按以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)类的实例。
2. 使用索引获取幻灯片的引用。
3. 向幻灯片添加一个矩形类型的AutoShape。
4. 访问与AutoShape关联的TextFrame。
5. 将AutoShape的FillType设置为NoFill。
6. 实例化OuterShadow类。
7. 设置阴影的BlurRadius。
8. 设置阴影方向。
9. 设置阴影距离。
10. 将RectangleAlign设置为TopLeft。
11. 将阴影的PresetColor设置为黑色。
12. 将演示文稿写为[PPTX](https://docs.fileformat.com/presentation/pptx/)文件。

以下Java代码示例—以上步骤的实现—展示了如何将外阴影效果应用于文本：

```java
Presentation pres = new Presentation();
try {
    // 获取幻灯片的引用
    ISlide sld = pres.getSlides().get_Item(0);

    // 向幻灯片添加一个矩形类型的AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 将TextFrame添加到矩形中
    ashp.addTextFrame("Aspose TextBox");

    // 禁用形状填充以获取文本的阴影
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 添加外部阴影并设置所有必要参数
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // 将演示文稿写入磁盘
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **将内部阴影效果应用于形状**
请按以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)类的实例。
2. 获取幻灯片的引用。
3. 添加一个矩形类型的AutoShape。
4. 启用InnerShadowEffect。
5. 设置所有必要参数。
6. 将ColorType设置为Scheme。
7. 设置Scheme颜色。
8. 将演示文稿写为[PPTX](https://docs.fileformat.com/presentation/pptx/)文件。

以下Java代码示例（基于上述步骤）展示了如何在Java中在两个形状之间添加连接器：

```java
Presentation pres = new Presentation();
try {
    // 获取幻灯片的引用
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加一个矩形类型的AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 将TextFrame添加到矩形中
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // 启用InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // 设置所有必要参数
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // 将ColorType设置为Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // 设置Scheme颜色
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // 保存演示文稿
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```