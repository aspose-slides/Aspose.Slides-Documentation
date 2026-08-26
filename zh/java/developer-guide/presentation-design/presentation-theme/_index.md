---
title: 在 Java 中管理演示文稿主题
linktitle: 演示文稿主题
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
- 外部主题
- THMX
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
description: "在 Aspose.Slides for Java 中使用主演示文稿主题创建、定制和转换具有一致品牌的 PowerPoint 文件。"
---
## **介绍**

演示文稿主题定义了一套协同的颜色、字体、背景样式、填充、线条和效果。支持主题的对象引用这些共享定义，而不是将每个视觉属性存为固定值，这样更改主题即可一次性更新大量对象。

在 Aspose.Slides 中，可通过[Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)获取演示文稿级别的主题。演示文稿还可以在更低层级包含主题覆盖。母版可通过[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/masterthememanager/)覆盖演示文稿主题，而布局或单个幻灯片可通过[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseoverridethememanager/)覆盖其继承的主题。实际情况下，幻灯片的有效主题通过以下继承链解析：演示文稿主题 → 母版覆盖 → 布局覆盖 → 幻灯片覆盖。

![主题组件：颜色、字体、背景样式和效果](theme-constituents.png)

下面的章节展示最常见的主题工作流：检查主题、修改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mastertheme/)对象通过[MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mastertheme/)和[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/mastertheme/)分别公开主题的配色方案、字体方案和格式方案。在更改之前检查这些集合尤其有用，因为来自外部来源的演示文稿其样式条目数量和内容可能各不相同。

以下示例读取主要主题属性，并报告主题中存储的背景、填充、线条和效果样式的数量：

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

如果文件使用了多个母版，切勿假设每张幻灯片都有相同的有效主题。检查与幻灯片关联的母版，并在布局或幻灯片可能存在覆盖时使用本文后续展示的有效主题工作流。

## **更改主题颜色**

支持主题的填充、线条和文本可以引用[SchemeColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/schemecolor/)枚举中的逻辑颜色。当你在[IColorScheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icolorscheme/)中更改相应条目时，所有仍引用该主题颜色的对象将解析为新值。直接使用 RGB 颜色的对象不会受到主题颜色更新的影响。

下面的端到端示例创建一个使用 `Accent4` 的形状，将主题的 `Accent4` 颜色更改为红色，保存演示文稿，重新打开后打印有效填充颜色：

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

因为矩形仍链接到 `Accent4`，主题更改后其可见颜色变为红色。如果在形状上用直接颜色替换了方案颜色，则后续对 `Accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过对主题颜色应用颜色变换生成更亮和更暗的变体。Aspose.Slides 通过[ColorTransformOperation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/colortransformoperation/)枚举公开这些变换。

![主主题颜色以及从附加调色板生成的更亮和更暗的颜色](additional-palette-colors.png)

**1** - 主主题颜色。

**2** - 基于主主题颜色生成的更亮和更暗的变体。

下面的示例基于 `Accent4` 创建六个矩形，对其中五个应用亮度变换，并保存结果：

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

这些变体仍基于主题颜色。如果随后 `Accent4` 发生改变，变换后的颜色会根据新的 `Accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `IColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/schemecolor/)枚举使用 `Text1`、`Background1`、`Text2`、`Background2`，而[IColorScheme](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icolorscheme/)将相同的主题槽位暴露为 `Dark1`、`Light1`、`Dark2`、`Light2`。映射固定如下：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

这些是同一主题槽位的别名；并非动态转换的值。

## **更改主题字体**

主题字体方案包含标题的主字体集和正文的次字体集。`[IFontScheme.getMajor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontscheme/)`和`[IFontScheme.getMinor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifontscheme/)`方法公开这两个集合。

PowerPoint 兼容的主题字体标识符可在文本格式化中使用：

* `+mn-lt` - 正文字体 拉丁文（Minor Latin Font）
* `+mj-lt` - 标题字体 拉丁文（Major Latin Font）
* `+mn-ea` - 正文字体 东亚（Minor East Asian Font）
* `+mj-ea` - 标题字体 东亚（Major East Asian Font）

以下示例创建一个使用主拉丁文字体的标题和一个使用次拉丁文字体的正文行。随后更改主题字体并保存结果：

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

标题遵循主字体，正文遵循次字体。若文本使用显式字体名称而非主题标识符，则在主题字体方案更改时不会自动切换。

主字体和次字体集合还可以包含针对特定书写系统的字体映射，如西里尔、阿拉伯、日语、格鲁吉亚和塔纳。要检查、添加、替换或删除这些映射，请参阅[脚本特定主题字体](/slides/zh/java/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
有关演示文稿字体的更多信息，请参阅[PowerPoint 字体](/slides/zh/java/powerpoint-fonts/)。
{{% /alert %}}

## **复制或应用主题**

以下工作流解决不同的主题相关问题。

### **将外部主题应用于依赖特定母版的幻灯片**

当你拥有 PowerPoint 主题文件（`.thmx`）并希望重新样式化所有依赖于特定母版的幻灯片时，请使用[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslide/)。从[Presentation.getMasters](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/)集合中选择母版（该集合实现了[IMasterSlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslidecollection/)），并将主题文件路径传给该方法。

该方法执行以下操作：

1. 基于选定的母版创建一个新母版幻灯片。
2. 将外部主题应用于新母版。
3. 将所有先前依赖选定母版的幻灯片指派给新母版。
4. 返回新创建的[IMasterSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslide/)。

以下示例将外部主题应用于依赖第一个母版的幻灯片，并保存演示文稿：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

无效、损坏或不受支持的主题可能导致[PptxReadException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/pptxreadexception/)。请验证用户提供的路径，处理文件系统访问失败，并仅在主题成功应用后保存演示文稿。

只有依赖选定母版的幻灯片会被重新指派。与其他母版关联的幻灯片保留其现有母版和主题。支持主题的颜色、字体、填充、线条、背景和效果会根据外部主题解析。直接分配的颜色、字体、填充等显式格式可能保持不变。布局级和幻灯片级覆盖也可能优先于新母版继承的值。

主题可能引用运行时环境中不存在的字体。为确保一致的渲染和导出，请安装所需字体、通过[自定义字体源](/slides/zh/java/custom-font/)提供，或配置[字体替换](/slides/zh/java/font-substitution/)。

这是直接的母版级工作流：该方法接受 `.thmx` 文件路径，无需手动创建幻灯片级或布局级主题覆盖。

### **在多母版演示文稿中应用不同的外部主题**

当无法提前确定相关母版时，可通过[ISlide.getLayoutSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islide/)和[ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilayoutslide/)从代表性幻灯片获取母版。在应用任何主题之前先保存原始母版引用，因为每次调用都会在演示文稿中创建另一个母版。

以下示例使用两个章节的幻灯片定位它们的母版，并对每个组应用不同的外部主题：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

第一次调用仅影响依赖 `firstGroupMaster` 的幻灯片，第二次调用仅影响依赖 `secondGroupMaster` 的幻灯片。属于其他母版的幻灯片不会被重新样式化。

### **在移动幻灯片时保留源主题**

如果希望将幻灯片移动到另一份演示文稿并保留其原始设计，可使用[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslidecollection/)将源母版克隆到目标演示文稿，然后使用[ISlideCollection.addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islidecollection/)连同克隆的母版一起克隆幻灯片。这样会将母版、其布局以及关联的主题一起携带。

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

当源幻灯片必须在目标中保持相同外观时，这是首选工作流。仅将内容克隆到不相关的目标母版上可能导致主题驱动的颜色、字体、背景和效果发生变化。

### **将主题值应用于现有幻灯片**

如果目标幻灯片必须保留当前母版和布局，可从源主题初始化幻灯片级覆盖。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/zh/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/zh/java/com.aspose.slides/overridetheme/)和[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/zh/java/com.aspose.slides/overridetheme/)方法会将三个主要主题组件复制到覆盖中。

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

此操作会更改该幻灯片使用的主题，而不影响其他幻灯片继承的主题。要移除本地覆盖并恢复继承值，请调用[OverrideTheme.clear](https://reference.aspose.com/slides/zh/java/com.aspose.slides/overridetheme/)。

### **将主题覆盖应用于布局**

布局级覆盖适用于使用该布局的幻灯片，除非特定幻灯片拥有自己的覆盖。相同的初始化方法可以通过[LayoutSlideThemeManager](https://reference.aspose.com/slides/zh/java/com.aspose.slides/layoutslidethememanager/)使用：

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

当许多布局和幻灯片应共享相同的基础设计时，使用母版或演示文稿级主题；当某一布局族需要不同样式时使用布局覆盖；仅在真正例外时使用幻灯片覆盖。过多的幻灯片级覆盖会使后续全局主题更改难以预测。

## **更新主题背景样式**

主题的背景填充存储在[IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iformatscheme/)中。PowerPoint 在 UI 中提供的背景选项常常多于此集合实际存储的填充定义，因为 UI 可以将主题填充与主题颜色及其他样式引用组合使用。

![演示文稿主题的 PowerPoint 背景样式库](presentation-design_8.png)

在使用背景样式之前，请检查存储的集合以及当前的[Background.getStyleIndex](https://reference.aspose.com/slides/zh/java/com.aspose.slides/background/)。样式索引 `0` 表示无主题填充；正数表示主题背景样式引用。这不同于直接对 Java 集合进行索引时 `get_Item(0)` 表示第一个存储项。不要假设每个演示文稿都有相同数量的背景填充样式。

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

可见结果取决于母版引用的主题条目以及布局或幻灯片级的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要获取继承后最终背景时，请使用[Background.getEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
不要将样式索引视为零基集合索引。也避免硬编码某个文件的样式编号并假设在另一个文件中具有相同外观；主题样式定义是针对特定演示文稿的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有关直接背景格式化和背景继承，请参阅[演示文稿背景](/slides/zh/java/presentation-background/)。
{{% /alert %}}

## **更新主题效果**

主题格式方案通过[IFormatScheme.getFillStyles](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iformatscheme/)和[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iformatscheme/)分别公开填充、线条和效果样式集合。典型的 Office 主题通常包含三个主要样式条目，对应于细致、适中和强烈的视觉效果，但代码应检查每个集合而非假设固定数量。

![细致、适中和强烈的主题效果应用于同一形状](presentation-design_10.png)

在 Java 中访问这些集合时，集合索引是零基的：`get_Item(0)` 为第一个存储的样式，`get_Item(2)` 为第三个。形状的样式引用索引是另一个概念，通过[IShapeStyle](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapestyle/)公开。修改主题样式会影响引用该主题样式的形状；直接格式化的形状可能保持不变。

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

对于引用这些槽位的形状，第一条主题线条样式将变为红色，第三条主题填充样式将变为实心森林绿，第三条效果样式将获得距离为 10 点的外部阴影。具体视觉结果仍取决于每个形状引用的样式槽位以及是否有直接格式覆盖主题。

![更改线条、填充和阴影设置后主题效果样式的效果](presentation-design_11.png)

## **读取有效主题值**

原始主题对象告诉你在特定层级上定义了什么。有效值告诉你在继承和本地覆盖解析后，幻灯片或形状实际使用了什么。对于幻灯片，调用[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseoverridethememanager/)。对于背景，使用[Background.getEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/background/)，对于填充，使用[FillFormat.getEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fillformat/)。

以下示例读取幻灯片的有效主题、背景以及第一个形状的填充：

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

**将外部主题应用于演示文稿会影响每张幻灯片吗？**

不会。[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslide/)仅重新指派依赖所选母版的幻灯片。使用其他母版的幻灯片保留其现有主题。

**我可以在不更改母版的情况下将主题应用于单个幻灯片吗？**

可以。使用幻灯片的[SlideThemeManager](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slidethememanager/)并初始化其覆盖主题。更改仅局限于该幻灯片，其他幻灯片继续继承其现有主题。

**将主题从一个演示文稿携带到另一个演示文稿的最安全方式是什么？**

在移动幻灯片并保留其源外观时，先使用[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslidecollection/)将源母版克隆到目标演示文稿，然后使用[ISlideCollection.addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islidecollection/)克隆幻灯片并关联克隆的母版。这样可保持母版、布局和主题一起。

**如何查看继承和覆盖后的有效值？**

对幻灯片或布局主题使用[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseoverridethememanager/)，对格式对象使用相应的有效数据方法，如[Background.getEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/background/)和[FillFormat.getEffective](https://reference.aspose.com/slides/zh/java/com.aspose.slides/fillformat/)。这些 API 返回继承和覆盖应用后的解析值。