---
title: 在 Java 中创建和应用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh/java/wordart/
keywords:
- WordArt
- 创建 WordArt
- WordArt 模板
- WordArt 效果
- 阴影效果
- 显示效果
- 发光效果
- WordArt 变换
- 3D 效果
- 外部阴影效果
- 内部阴影效果
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中创建和定制 WordArt 效果。本分步指南帮助开发者使用 Java 为演示文稿添加专业文本。"
---
## **概述**

WordArt 效果可让您在 PowerPoint 演示文稿中添加视觉上悦目的、样式化的文字。使用 Aspose.Slides，开发人员可以像在 Microsoft PowerPoint 中一样以编程方式创建、定制和管理 WordArt，无需安装 Office。本文概览了 WordArt 的使用，包括如何对文本应用变换、填充样式、轮廓、阴影及其他格式选项，以使演示内容更具表现力和吸引力。WordArt 允许您将文本视为图形对象。它由对文本应用的效果或特殊修改组成，使其更具吸引力或突出。

## **创建简单的 WordArt 模板并将其应用于文本**

**使用 Aspose.Slides**

首先，使用以下 Java 代码创建一个简单的文本：

``` java
import com.aspose.slides.*;

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
现在，通过以下代码将文本的字体高度设置为更大，以便更明显地显示效果：

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}
```

**使用 Microsoft PowerPoint**

在 Microsoft PowerPoint 中打开 WordArt 效果菜单：

![todo:image_alt_text](image-20200930113926-1.png)

在右侧菜单中，您可以选择预定义的 WordArt 效果；在左侧菜单中，您可以为新 WordArt 指定设置。

以下是部分可用的参数或选项：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

这里，我们使用以下代码将 [SmallGrid](https://reference.aspose.com/slides/zh/java/com.aspose.slides/PatternStyle#SmallGrid) 图案颜色应用于文本，并添加 1 宽度的黑色文本边框：

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}
```

生成的文本：

![todo:image_alt_text](image-20200930114108-4.png)

## **应用其他 WordArt 效果**

**使用 Microsoft PowerPoint**

在程序界面中，您可以将这些效果应用于文本、文本块、形状或类似元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，阴影、反射和发光效果可应用于文本；3D 格式和 3D 旋转效果可应用于文本块；软边缘属性可应用于形状对象（即使未设置 3D 格式属性，也仍会生效）。

### **应用阴影效果**

此处我们仅针对文本设置属性。使用以下 Java 代码将阴影效果应用于文本：

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Aspose.Slides API 支持三种阴影类型：OuterShadow、InnerShadow 和 PresetShadow。

使用 PresetShadow，您可以为文本应用预设值的阴影。

**使用 Microsoft PowerPoint**

在 PowerPoint 中，您只能使用一种阴影类型。示例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 实际上允许您一次同时应用两种阴影：InnerShadow 和 PresetShadow。

**注意：**

- 当同时使用 OuterShadow 和 PresetShadow 时，仅会应用 OuterShadow 效果。
- 若同时使用 OuterShadow 和 InnerShadow，实际应用的效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中效果会叠加；而在 PowerPoint 2007 中仅应用 OuterShadow 效果。

### **为文本应用显示效果**

我们通过以下 Java 示例代码为文本添加显示效果：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

### **为文本应用发光效果**

使用以下代码为文本应用发光效果，使其闪耀或突出：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

操作结果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

您可以更改阴影、显示和发光的参数。这些效果的属性会分别设置在文本的每个部分。

{{% /alert %}} 

### **在 WordArt 中使用变换**

我们通过以下代码使用 Transform 属性（适用于整个文本块）：

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}
```

结果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

Microsoft PowerPoint 和 Aspose.Slides for Java 都提供若干预定义的变换类型。

{{% /alert %}} 

**使用 PowerPoint**

要访问预定义的变换类型，请依次选择：**格式** → **文字效果** → **变换**

**使用 Aspose.Slides**

要选择变换类型，请使用 TextShapeType 枚举。

### **为文本和形状应用 3D 效果**

我们使用以下示例代码为文本形状设置 3D 效果：

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

生成的文本及其形状：

![todo:image_alt_text](image-20200930114816-9.png)

我们使用以下 Java 代码为文本应用 3D 效果：

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

操作结果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

对文本或其形状应用 3D 效果以及效果之间的交互遵循一定规则。

考虑文本及其所在形状的场景。3D 效果包含 3D 对象表示以及对象所在的场景。

- 当形状和文本都设置了场景时，形状的场景优先级更高，文本的场景会被忽略。
- 当形状没有自己的场景但具有 3D 表示时，使用文本的场景。
- 否则——即形状本身没有 3D 效果——形状保持平面，3D 效果仅应用于文本。

这些描述与 ThreeDFormat.getLightRig() 和 ThreeDFormat.getCamera() 方法相关。

{{% /alert %}} 

## **为文本应用外部阴影效果**
Aspose.Slides for Java 提供了 [**IOuterShadow**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ioutershadow/) 和 [**IInnerShadow**](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iinnershadow/) 类，允许您对由 [TextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/textframe/) 承载的文本应用阴影效果。请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 实例。
2. 使用索引获取幻灯片引用。
3. 向幻灯片添加矩形类型的 AutoShape。
4. 访问与 AutoShape 关联的 TextFrame。
5. 将 AutoShape 的 FillType 设置为 NoFill。
6. 实例化 OuterShadow 类。
7. 设置阴影的 BlurRadius。
8. 设置阴影的 Direction。
9. 设置阴影的 Distance。
10. 将 RectanglelAlign 设置为 TopLeft。
11. 将阴影的 PresetColor 设置为 Black。
12. 将演示文稿保存为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下 Java 示例代码演示如何将外部阴影效果应用于文本：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // 获取幻灯片的引用
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加一个矩形类型的 AutoShape
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 向矩形添加 TextFrame
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

    //将演示文稿写入磁盘
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **为形状应用内部阴影效果**
请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation) 实例。
2. 获取幻灯片引用。
3. 添加矩形类型的 AutoShape。
4. 启用 InnerShadowEffect。
5. 设置所有必要的参数。
6. 将 ColorType 设置为 Scheme。
7. 设置 Scheme Color。
8. 将演示文稿保存为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下基于上述步骤的 Java 示例代码展示了如何在形状中的文本上应用内部阴影效果：

```java
import com.aspose.slides.*;

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

    // 启用内部阴影效果
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // 设置所有必要参数
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // 将 ColorType 设置为 Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // 设置方案颜色
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // 保存演示文稿
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常见问题**

### 能否在不同字体或文字系统（例如阿拉伯文、中文）中使用 WordArt 效果？

可以，Aspose.Slides 支持 Unicode，适用于所有主流字体和文字系统。阴影、填充、轮廓等 WordArt 效果均可在任何语言下使用，但字体可用性和渲染可能取决于系统字体。

### 能否将 WordArt 效果应用于母版幻灯片元素？

可以，您可以对母版幻灯片上的形状（包括标题占位符、页脚或背景文字）应用 WordArt 效果。对母版布局所做的更改会在所有使用该母版的幻灯片中生效。

### WordArt 效果会影响演示文稿文件大小吗？

会略有影响。阴影、发光和渐变填充等 WordArt 效果会增加少量格式元数据，从而略微增大文件大小，但差异通常可以忽略不计。

### 能否在不保存演示文稿的情况下预览 WordArt 效果的结果？

可以，您可以使用 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/) 或 [ISlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islide/) 接口的 `getImage` 方法将包含 WordArt 的幻灯片渲染为图像（如 PNG、JPEG），从而在内存或屏幕上预览效果，而无需保存或导出完整演示文稿。