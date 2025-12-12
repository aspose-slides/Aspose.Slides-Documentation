---
title: 在 Android 上创建和应用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh/androidjava/wordart/
keywords:
- WordArt
- 创建 WordArt
- WordArt 模板
- WordArt 效果
- 阴影效果
- 显示效果
- 发光效果
- WordArt 变形
- 3D 效果
- 外部阴影效果
- 内部阴影效果
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中创建和自定义 WordArt 效果。本分步指南帮助开发者使用 Java 在演示文稿中添加专业文本。"
---

## **关于 WordArt？**
WordArt 或 Word Art 是一种功能，可对文本应用效果，使其更加突出。例如，通过 WordArt，您可以为文本描边或填充颜色（或渐变），为其添加 3D 效果等。您还可以倾斜、弯曲和拉伸文本的形状。

{{% alert color="primary" %}} 

WordArt 允许您像对待图形对象一样处理文本。通常，WordArt 包含对文本进行的效果或特殊修改，以使其更具吸引力或更明显。 

{{% /alert %}} 

**Microsoft PowerPoint 中的 WordArt**

要在 Microsoft PowerPoint 中使用 WordArt，您必须选择预定义的 WordArt 模板之一。WordArt 模板是一组会应用于文本或其形状的效果。

**Aspose.Slides 中的 WordArt**

在 Aspose.Slides for Android via Java 20.10 中，我们实现了对 WordArt 的支持，并在后续的 Aspose.Slides for Android via Java 版本中对该功能进行了改进。

使用 Aspose.Slides for Android via Java，您可以在 Java 中轻松创建自己的 WordArt 模板（单个效果或多个效果的组合），并将其应用于文本。

## **创建简单的 WordArt 模板并将其应用于文本**

**使用 Aspose.Slides** 

首先，使用以下 Java 代码创建一个简单的文本： 
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

现在，通过下面的代码将文本的字体高度设置为较大的值，以便更明显地看到效果：
``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```


**使用 Microsoft PowerPoint**

在 Microsoft PowerPoint 中进入 WordArt 效果菜单：

![todo:image_alt_text](image-20200930113926-1.png)

在右侧菜单中，您可以选择预定义的 WordArt 效果；在左侧菜单中，您可以为新 WordArt 指定设置。

以下是一些可用的参数或选项：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

在此示例中，我们使用 [SmallGrid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PatternStyle#SmallGrid) 图案颜色填充文本，并通过以下代码为文本添加 1 宽度的黑色边框：
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

## **应用其他 WordArt 效果**

**使用 Microsoft PowerPoint**

在程序界面中，您可以将这些效果应用于文本、文本块、形状或类似的元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，可将阴影、反射和发光效果应用于文本；将三维格式和三维旋转效果应用于文本块；将柔化边缘属性应用于形状对象（即使未设置三维格式属性也会生效）。

### **应用阴影效果**

此处我们仅针对文本设置属性。使用以下 Java 代码为文本应用阴影效果：
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


Aspose.Slides API 支持三种阴影类型：OuterShadow、InnerShadow 和 PresetShadow。

使用 PresetShadow，您可以使用预设值为文本应用阴影。

**使用 Microsoft PowerPoint**

在 PowerPoint 中只能使用一种阴影类型。示例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 实际上允许一次同时应用两种阴影：InnerShadow 和 PresetShadow。

**注意：**

- 当同时使用 OuterShadow 和 PresetShadow 时，仅会应用 OuterShadow 效果。  
- 若同时使用 OuterShadow 和 InnerShadow，实际应用的效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中会出现双重阴影；而在 PowerPoint 2007 中仅应用 OuterShadow 效果。 

### **将反射效果应用于文本**

使用以下 Java 示例代码向文本添加反射效果：
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


### **将发光效果应用于文本**

使用下面的代码为文本应用发光效果，使其更加光亮或突出：
``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```


操作结果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

您可以更改阴影、反射和发光的参数。效果属性会分别设置在文本的每一部分。 

{{% /alert %}} 

### **在 WordArt 中使用变形**

通过以下代码使用 Transform 属性（作用于整个文本块）：
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```


结果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint 和 Aspose.Slides for Android via Java 都提供了一定数量的预定义变形类型。

{{% /alert %}} 

**使用 PowerPoint**

进入预定义变形类型的路径为：**格式** → **文本效果** → **变形**。

**使用 Aspose.Slides**

要选择变形类型，请使用 TextShapeType 枚举。

### **将 3D 效果应用于文本和形状**

使用以下示例代码为文本形状设置 3D 效果：
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

使用下面的 Java 代码为文本本身应用 3D 效果：
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

将 3D 效果应用于文本或其形状以及效果之间的交互遵循一定规则。

考虑文本及其所在形状的场景。3D 效果包含 3D 对象的表示以及放置该对象的场景。

- 当图形和文本都设置了场景时，图形场景优先——文本场景被忽略。  
- 当图形没有自己的场景但具有 3D 表示时，使用文本场景。  
- 否则——即图形本身没有 3D 效果时，图形保持平面，仅对文本应用 3D 效果。  

这些说明与 ThreeDFormat.getLightRig() 和 ThreeDFormat.getCamera() 方法相关。

{{% /alert %}} 

## **将外部阴影效果应用于文本**
Aspose.Slides for Android via Java 提供了 [**IOuterShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IOuterShadow) 和 [**IInnerShadow**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IInnerShadow) 接口，可对由 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/TextFrame) 承载的文本应用阴影效果。请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。  
2. 使用索引获取幻灯片的引用。  
3. 向幻灯片添加矩形类型的 AutoShape。  
4. 访问该 AutoShape 关联的 TextFrame。  
5. 将 AutoShape 的 FillType 设置为 NoFill。  
6. 实例化 OuterShadow 类。  
7. 设置阴影的 BlurRadius。  
8. 设置阴影的 Direction。  
9. 设置阴影的 Distance。  
10. 将 RectanglelAlign 设置为 TopLeft。  
11. 将阴影的 PresetColor 设置为 Black。  
12. 将演示文稿保存为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

下面的 Java 示例代码演示了上述步骤，展示了如何对文本应用外部阴影效果：
```java
Presentation pres = new Presentation();
try {
    // 获取幻灯片的引用
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加矩形类型的 AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 在矩形中添加 TextFrame
    ashp.addTextFrame("Aspose TextBox");

    // 禁用形状填充，以便获取文本的阴影
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

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。  
2. 获取幻灯片的引用。  
3. 添加矩形类型的 AutoShape。  
4. 启用 InnerShadowEffect。  
5. 设置所有必要的参数。  
6. 将 ColorType 设置为 Scheme。  
7. 设置 Scheme Color。  
8. 将演示文稿保存为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

下面的 Java 示例代码（基于上述步骤）展示了如何在两形状之间添加连接器：
```java
Presentation pres = new Presentation();
try {
    // 获取幻灯片的引用
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加矩形类型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // 在矩形中添加 TextFrame
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

    // 设置 Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // 保存演示文稿
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**我可以在不同的字体或脚本（如阿拉伯语、中文）上使用 WordArt 效果吗？**

可以，Aspose.Slides 支持 Unicode，能够与所有主流字体和脚本配合使用。阴影、填充和描边等 WordArt 效果均可在任意语言下应用，只是具体的字体可用性和渲染效果取决于系统安装的字体。

**我可以将 WordArt 效果应用于母版幻灯片元素吗？**

可以，您可以在母版幻灯片上的形状（包括标题占位符、页脚或背景文字）上应用 WordArt 效果。对母版布局所做的更改会在所有使用该母版的幻灯片中生效。

**WordArt 效果会影响演示文稿的文件大小吗？**

会有轻微影响。阴影、发光和渐变填充等效果会因额外的格式元数据而略微增大文件体积，但通常影响可以忽略不计。

**我可以在不保存演示文稿的情况下预览 WordArt 效果的结果吗？**

可以，您可以使用 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 或 [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) 接口的 `getImage` 方法将包含 WordArt 的幻灯片渲染为图像（如 PNG、JPEG），从而在内存或屏幕上预览效果，而无需先保存完整的演示文稿。