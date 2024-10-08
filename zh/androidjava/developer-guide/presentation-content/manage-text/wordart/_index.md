---
title: 字体艺术
type: docs
weight: 110
url: /androidjava/wordart/
---


## **关于字体艺术？**
字体艺术是一项允许您对文本应用效果以使其突出显示的功能。例如，您可以为文本添加轮廓或填充颜色（或渐变），为其添加3D效果等。您还可以扭曲、弯曲和拉伸文本形状。

{{% alert color="primary" %}} 

字体艺术使您可以将文本视为图形对象。一般来说，字体艺术由对文本进行的效果或特殊修改组成，以使其更具吸引力或更容易被注意到。

{{% /alert %}} 

**在 Microsoft PowerPoint 中使用字体艺术**

要在 Microsoft PowerPoint 中使用字体艺术，您必须选择预定义的字体艺术模板。字体艺术模板是一组应用于文本或其形状的效果。

**在 Aspose.Slides 中使用字体艺术**

在 Aspose.Slides for Android via Java 20.10 中，我们实现了对字体艺术的支持，并在后续的 Aspose.Slides for Android via Java 版本中对该功能进行了改进。

使用 Aspose.Slides for Android via Java，您可以轻松地在 Java 中创建自己的字体艺术模板（一个效果或效果组合）并将其应用于文本。

## 创建一个简单的字体艺术模板并将其应用于文本

**使用 Aspose.Slides** 

首先，我们使用以下 Java 代码创建一个简单的文本：

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
现在，我们将文本的字体高度设置为更大的值，以使效果更加明显：

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**使用 Microsoft PowerPoint**

转到 Microsoft PowerPoint 中的字体艺术效果菜单：

![todo:image_alt_text](image-20200930113926-1.png)

在右侧的菜单中，您可以选择预定义的字体艺术效果。在左侧菜单中，您可以指定新字体艺术的设置。

以下是一些可用的参数或选项：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

在这里，我们使用以下代码将 [SmallGrid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid) 图案颜色应用于文本，并添加 1 像素宽的黑色文本边框：

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

结果文本：

![todo:image_alt_text](image-20200930114108-4.png)

## 应用其他字体艺术效果

**使用 Microsoft PowerPoint**

在程序的界面中，您可以将这些效果应用于文本、文本块、形状或类似元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，可以将阴影、反射和光晕效果应用于文本；可以将 3D 格式和 3D 旋转效果应用于文本块；软边缘属性可以应用于形状对象（当未设置 3D 格式属性时仍然有效）。 

### 应用阴影效果

在这里，我们仅打算设置与文本相关的属性。我们使用以下 Java 代码将阴影效果应用于文本：

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

Aspose.Slides API 支持三种类型的阴影：外阴影、内阴影和预设阴影。 

使用预设阴影，您可以为文本应用阴影（使用预设值）。 

**使用 Microsoft PowerPoint**

在 PowerPoint 中，您可以使用一种类型的阴影。以下是一个示例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 实际上允许您同时应用两种类型的阴影：内阴影和预设阴影。

**注意：**

- 当同时使用外阴影和预设阴影时，仅应用外阴影效果。 
- 如果同时使用外阴影和内阴影，结果或应用的效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果会加倍。但在 PowerPoint 2007 中，应用外阴影效果。 

### 将显示应用于文本

我们通过以下 Java 代码示例为文本添加显示：

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

### 将光晕效果应用于文本

我们使用以下代码为文本应用光晕效果，以使其闪耀或突出：

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

操作结果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

您可以更改阴影、显示和光晕的参数。效果的属性在文本的每个部分上单独设置。 

{{% /alert %}} 

### 在字体艺术中使用变换

我们通过以下代码使用整体文本块中的 Transform 属性：
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

结果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint 和 Aspose.Slides for Android via Java 提供了一定数量的预定义变换类型。

{{% /alert %}} 

**使用 PowerPoint**

要访问预定义的变换类型，请转到：**格式** -> **文本效果** -> **变换**

**使用 Aspose.Slides**

要选择变换类型，请使用 TextShapeType 枚举。 

### 将 3D 效果应用于文本和形状

我们使用以下示例代码为文本形状设置 3D 效果：

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

结果文本及其形状：

![todo:image_alt_text](image-20200930114816-9.png)

我们使用以下 Java 代码为文本应用 3D 效果：

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

操作结果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

将 3D 效果应用于文本或其形状以及效果之间的相互作用基于某些规则。

考虑一个包含文本的形状的场景。3D 效果包含 3D 对象表示和对象放置的场景。

- 当为图形和文本设置场景时，图形场景具有更高的优先级—文本场景会被忽略。 
- 当图形缺乏自己的场景但具有 3D 表示时，使用文本场景。 
- 否则—当形状原本没有 3D 效果时—形状是平坦的，3D 效果仅适用于文本。 

这些描述与 ThreeDFormat.getLightRig() 和 ThreeDFormat.getCamera() 方法相关。

{{% /alert %}} 

## **将外阴影效果应用于文本**
Aspose.Slides for Android via Java 提供 [**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IOuterShadow) 和 [**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IInnerShadow) 类，使您能够将阴影效果应用于通过 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) 处理的文本。请遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
2. 通过使用索引获取幻灯片的引用。
3. 向幻灯片添加一个矩形类型的 AutoShape。
4. 访问与 AutoShape 相关联的 TextFrame。
5. 将 AutoShape 的 FillType 设置为 NoFill。
6. 实例化 OuterShadow 类。
7. 设置阴影的 BlurRadius。
8. 设置阴影的 Direction。
9. 设置阴影的 Distance。
10. 将 RectangleAlign 设置为 TopLeft。
11. 将阴影的 PresetColor 设置为 Black。
12. 将演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下 Java 示例代码是上述步骤的实现，演示如何将外阴影效果应用于文本：

```java
Presentation pres = new Presentation();
try {
    // 获取幻灯片的引用
    ISlide sld = pres.getSlides().get_Item(0);

    // 向幻灯片添加一个矩形类型的 AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 向矩形添加 TextFrame
    ashp.addTextFrame("Aspose TextBox");

    // 禁用形状填充，以便获取文本阴影
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 添加外阴影并设置所有必要参数
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

## **将内阴影效果应用于形状**
请遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
2. 获取幻灯片的引用。
3. 添加一个矩形类型的 AutoShape。
4. 启用 InnerShadowEffect。
5. 设置所有必要参数。
6. 将 ColorType 设置为Scheme。
7. 设置 Scheme 颜色。
8. 将演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下示例代码（基于上述步骤）演示了如何在 Java 中为两个形状之间添加连接器：

```java
Presentation pres = new Presentation();
try {
    // 获取幻灯片的引用
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加一个矩形类型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 向矩形添加 TextFrame
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // 启用 InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // 设置所有必要参数
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // 将 ColorType 设置为 Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // 设置 Scheme 颜色
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // 保存演示文稿
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```