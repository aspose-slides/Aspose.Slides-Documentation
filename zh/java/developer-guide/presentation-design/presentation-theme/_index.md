---
title: 在 Java 中管理演示文稿主题
linktitle: 演示主题
type: docs
weight: 10
url: /zh/java/presentation-theme/
keywords:
- PowerPoint 主题
- 演示文稿主题
- 幻灯片主题
- 设置主题
- 更改主题
- 管理主题
- 主题颜色
- 附加调色板
- 主题字体
- 主题样式
- 主题效果
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中精通演示文稿主题，以创建、定制和转换具有一致品牌标识的 PowerPoint 文件。"
---
## **介绍**

演示主题定义了一套协调的颜色、字体、背景样式、填充、线条和效果。主题感知对象引用这些共享定义，而不是将每个视觉属性存储为固定值，因此更改主题可以一次性更新许多对象。

在 Aspose.Slides 中，演示级别的主题可通过[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)获取。演示还可以在更低级别包含主题覆盖。母版可以通过[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/masterthememanager/)覆盖演示主题，而布局或单个幻灯片可以通过[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseoverridethememanager/)覆盖其继承的主题。实际中，幻灯片的有效主题通过以下继承链解析：演示主题 → 母版覆盖 → 布局覆盖 → 幻灯片覆盖。

![主题组件：颜色、字体、背景样式和效果](theme-constituents.png)

以下章节展示最常见的主题工作流：检查主题、更改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mastertheme/)对象通过[MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mastertheme/)和[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mastertheme/)暴露主题的配色方案、字体方案和格式方案。在更改这些集合之前先检查它们尤其有用，因为来自外部来源的演示文稿的样式条目数量和内容可能会有所不同。

以下示例读取主要主题属性并报告主题中存储的背景、填充、线条和效果样式的数量：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

如果文件使用多个母版，请不要假设每张幻灯片具有相同的有效主题。检查与幻灯片关联的母版，并在可能存在布局或幻灯片覆盖时使用本文后面展示的有效主题工作流。

## **更改主题颜色**

主题感知的填充、线条和文本可以引用[SchemeColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/schemecolor/)枚举中的逻辑颜色。当您在[IColorScheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icolorscheme/)中更改相应条目时，所有仍引用该主题颜色的对象将解析为新值。使用直接 RGB 颜色的对象不会因主题颜色更新而更改。

以下端到端示例创建一个使用`Accent4`的形状，将主题的`Accent4`颜色更改为红色，保存演示文稿，重新打开并打印有效填充颜色：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

因为矩形仍链接到`Accent4`，主题更改后其可见颜色变为红色。如果您在形状上用直接颜色替换方案颜色，则之后对`Accent4`的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过应用颜色变换从主题颜色派生出更浅和更深的变体。Aspose.Slides 通过[ColorTransformOperation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/colortransformoperation/)枚举公开这些变换。

![主主题颜色以及由附加调色板生成的更浅更深颜色](additional-palette-colors.png)

**1** - 主主题颜色。

**2** - 基于主主题颜色生成的更浅和更深变体。

以下示例基于`Accent4`创建六个矩形，对其中五个应用亮度变换，并保存结果：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

这些变体仍基于主题颜色。如果随后`Accent4`更改，转换后的颜色将根据新的`Accent4`值重新计算。

### **将 `SchemeColor` 值映射到 `IColorScheme` 插槽**

[SchemeColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/schemecolor/)枚举使用`Text1`、`Background1`、`Text2`和`Background2`，而[IColorScheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icolorscheme/)将相同的主题插槽公开为`Dark1`、`Light1`、`Dark2`和`Light2`。映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

这些是同一主题插槽的别名；它们不是从一种形式动态转换为另一种形式的值。

## **更改主题字体**

主题字体方案包含标题的主要字体集和正文的次要字体集。[IFontScheme.getMajor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontscheme/)和[IFontScheme.getMinor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontscheme/)方法公开这些集合。

PowerPoint 兼容的主题字体标识符可用于文本格式化：

* `+mn-lt` - 正文字体 拉丁文（Minor Latin Font）
* `+mj-lt` - 标题字体 拉丁文（Major Latin Font）
* `+mn-ea` - 正文字体 东亚文（Minor East Asian Font）
* `+mj-ea` - 标题字体 东亚文（Major East Asian Font）

以下示例创建一个使用主要拉丁主题字体的标题和一个使用次要拉丁主题字体的正文行。随后更改主题字体并保存结果：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

标题遵循主要字体，正文遵循次要字体。使用显式字体名称而非主题标识符的文本在主题字体方案更改时不会自动切换。

{{% alert color="info" title="Tip" %}}

有关演示文稿字体的更多信息，请参阅[PowerPoint Fonts](/slides/zh/java/powerpoint-fonts/)。

{{% /alert %}}

## **复制或应用主题**

常见的两种工作流解决不同的问题。

### **在移动幻灯片时保留源主题**

如果要将幻灯片移动到另一个演示文稿并保留其原始设计，请使用[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslidecollection/)将源母版克隆到目标演示文稿中，然后使用[ISlideCollection.addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islidecollection/)和克隆的母版克隆幻灯片。这会将母版、其布局以及关联的主题一起携带。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

当源幻灯片必须在目标中保持相同外观时，这是首选工作流。仅将内容克隆到不相关的目标母版上可能会更改主题驱动的颜色、字体、背景和效果。

### **将主题值应用于现有幻灯片**

如果目标幻灯片必须保持其当前母版和布局，请从源主题初始化幻灯片级别的覆盖。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh/java/com.aspose.slides/overridetheme/)和[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh/java/com.aspose.slides/overridetheme/)方法将三个主要主题组件复制到覆盖中。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

这会更改该幻灯片使用的主题，而不更改其他幻灯片继承的主题。要移除本地覆盖并返回继承值，请调用[OverrideTheme.clear](https://reference.aspose.com/slides/zh/java/com.aspose.slides/overridetheme/)。

### **将主题覆盖应用于布局**

布局级别的覆盖适用于使用该布局的幻灯片，除非特定幻灯片有自己的覆盖。相同的初始化方法可通过[LayoutSlideThemeManager](https://reference.aspose.com/slides/zh/java/com.aspose.slides/layoutslidethememanager/)使用：

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

当许多布局和幻灯片应共享相同的基础设计时使用母版或演示级别的主题；当一个布局族需要不同样式时使用布局覆盖；仅在真正的例外情况下使用幻灯片覆盖。过多的幻灯片级别覆盖会使后续全局主题更改难以预测。

## **更新主题背景样式**

主题的背景填充存储在[IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iformatscheme/)中。PowerPoint 的 UI 可以呈现比此集合实际存储的填充定义更多的背景选项，因为 UI 能够将主题填充与主题颜色及其他样式引用组合使用。

![PowerPoint 演示主题的背景样式库](presentation-design_8.png)

在使用背景样式之前，检查存储的集合以及当前的[Background.getStyleIndex](https://reference.aspose.com/slides/zh/java/com.aspose.slides/background/)。`0` 表示没有主题填充；正值表示主题背景样式引用。这不同于直接对 Java 集合进行索引，其中`get_Item(0)`表示第一条存储项。不要假设每个演示文稿包含相同数量的背景填充样式。

以下示例报告可用的背景填充计数，将主题背景引用分配给第一个母版，并保存演示文稿：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

可见结果取决于母版引用的主题条目以及布局或幻灯片级别的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要获取继承后最终背景时，请使用[Background.getEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}

不要将样式索引视为零基集合索引。也避免在一个文件中硬编码样式编号并假设在另一个文件中具有相同外观；主题样式定义是演示特定的。

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

有关直接背景格式化和背景继承，请参阅[Presentation Background](/slides/zh/java/presentation-background/)。

{{% /alert %}}

## **更新主题效果**

主题格式方案包含通过[IFormatScheme.getFillStyles](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iformatscheme/)和[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iformatscheme/)公开的独立填充、线条和效果样式集合。典型的 Office 主题通常包含三个主要样式条目，视觉上对应细微、适中和强烈的格式，但代码应检查每个集合，而不是假设固定数量。

![对同一形状应用细微、适中和强烈主题效果](presentation-design_10.png)

在 Java 中访问这些集合时，集合索引是零基的：`get_Item(0)`是第一条存储的样式，`get_Item(2)`是第三条。形状的样式引用索引是另一个概念，通过[IShapeStyle](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapestyle/)公开。修改主题样式会影响引用该主题样式的形状；直接格式化的形状可能保持不变。

以下示例检查所需的样式条目是否存在，修改第一条线条样式，修改第三条填充样式，在第三条效果样式中启用外部阴影，并保存结果：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

对于引用这些插槽的形状，第一条主题线条样式将变为红色，第三条主题填充样式将变为实心森林绿，第三条效果样式将获得距离为 10 点的外部阴影。确切的视觉结果仍取决于每个形状引用的样式插槽以及是否有直接格式覆盖主题。

![更改线条、填充和阴影设置后主题效果样式](presentation-design_11.png)

## **读取有效主题值**

原始主题对象告诉您在特定层级定义了什么。有效值告诉您幻灯片或形状在继承和本地覆盖解析后实际使用的内容。对于幻灯片，调用[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseoverridethememanager/)。对于背景，使用[Background.getEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/background/)，对于填充，使用[FillFormat.getEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fillformat/)。

以下示例读取幻灯片的有效主题、背景以及第一形状的填充：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

使用有效数据进行渲染诊断、验证和比较。如果仅检查[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)，可能会错过更改最终外观的母版、布局、幻灯片或形状覆盖。

## **常见问题**

**我可以在不更改母版的情况下将主题应用于单个幻灯片吗？**

可以。使用幻灯片的[SlideThemeManager](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slidethememanager/)并初始化其覆盖主题。更改只在该幻灯片本地生效，其他幻灯片继续继承其现有主题。

**将主题从一个演示文稿迁移到另一个的最安全方法是什么？**

在移动幻灯片并保留其来源外观时，使用[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslidecollection/)将源母版克隆到目标，并使用[ISlideCollection.addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islidecollection/)克隆带有该母版的幻灯片。这样可保持母版、布局和主题一起。

**如何查看继承和覆盖后的有效值？**

对幻灯片或布局主题使用[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseoverridethememanager/)，并对格式对象如[Background.getEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/background/)和[FillFormat.getEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fillformat/)使用相应的有效数据方法。这些 API 返回在继承和覆盖应用后解析出的值。