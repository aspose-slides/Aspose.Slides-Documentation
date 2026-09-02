---
title: 在 Android 上管理演示文稿主题
linktitle: 演示文稿主题
type: docs
weight: 10
url: /zh/androidjava/presentation-theme/
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
- Android
- Java
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for Android 中掌握演示文稿主题，以创建、定制和转换 PowerPoint 文件，实现一致的品牌形象。"
---
## **介绍**

演示文稿主题定义了一套协调的颜色、字体、背景样式、填充、线条和效果。支持主题的对象引用这些共享定义，而不是将每个视觉属性存为固定值，因此更改主题时可以一次性更新多个对象。

在 Aspose.Slides 中，可通过 [Presentation.getMasterTheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 获取演示文稿级别的主题。演示文稿还可以在更低层级包含主题覆盖。母版可以通过 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/masterthememanager/) 覆盖演示文稿主题，而布局或单个幻灯片可以通过 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/baseoverridethememanager/) 覆盖其继承的主题。实际情况下，幻灯片的有效主题通过以下继承链解析：演示文稿主题 → 母版覆盖 → 布局覆盖 → 幻灯片覆盖。

![主题组件：颜色、字体、背景样式和效果](theme-constituents.png)

下面的章节展示了最常见的主题工作流：检查主题、更改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mastertheme/) 对象通过 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mastertheme/) 和 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/mastertheme/) 暴露主题的配色方案、字体方案和格式方案。在更改之前检查这些集合尤其在演示文稿来自外部来源时有用，因为样式条目的数量和内容可能各不相同。

下面的示例读取主要主题属性并报告主题中存储了多少背景、填充、线条和效果样式：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

如果文件使用了多个母版，请不要假设每张幻灯片都有相同的有效主题。检查与幻灯片关联的母版，并在布局或幻灯片可能存在覆盖时使用本文后面展示的有效主题工作流。

## **更改主题颜色**

支持主题的填充、线条和文本可以引用来自 [SchemeColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/schemecolor/) 枚举的逻辑颜色。当你在 [IColorScheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icolorscheme/) 中更改相应条目时，所有仍然引用该主题颜色的对象都会解析为新的值。使用直接 RGB 颜色的对象不会受到主题颜色更新的影响。

下面的端到端示例创建一个使用 `Accent4` 的形状，将主题的 `Accent4` 颜色改为红色，保存演示文稿，重新打开后打印有效填充颜色：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

因为矩形仍然链接到 `Accent4`，在主题更改后其可见颜色会变为红色。如果在形状上用直接颜色替换了方案颜色，之后对 `Accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过对主题颜色应用颜色变换来生成更亮和更暗的变体。Aspose.Slides 通过 [ColorTransformOperation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/colortransformoperation/) 枚举公开这些变换。

![主主题颜色以及从附加调色板生成的更亮和更暗颜色](additional-palette-colors.png)

**1** - 主主题颜色。  
**2** - 基于主主题颜色生成的更亮和更暗变体。

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

这些变体仍然基于主题颜色。如果随后 `Accent4` 改变，变换后的颜色会根据新的 `Accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `IColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/schemecolor/) 枚举使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [IColorScheme](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icolorscheme/) 将相同的主题槽位暴露为 `Dark1`、`Light1`、`Dark2`、`Light2`。映射是固定的：

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

这些是同一主题槽位的别名；它们不是会在两种形式之间动态转换的值。

## **更改主题字体**

主题字体方案包含标题的主字体集和正文的次字体集。`[IFontScheme.getMajor`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontscheme/) 和 `[IFontScheme.getMinor`](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifontscheme/) 方法分别暴露这两个集合。

PowerPoint 兼容的主题字体标识符可以在文本格式化中使用：

* `+mn-lt` - 正文字体拉丁语（Minor Latin Font）  
* `+mj-lt` - 标题字体拉丁语（Major Latin Font）  
* `+mn-ea` - 正文字体东亚（Minor East Asian Font）  
* `+mj-ea` - 标题字体东亚（Major East Asian Font）

下面的示例创建一个使用主拉丁主题字体的标题和一个使用次拉丁主题字体的正文行，然后更改主题字体并保存结果：

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

标题遵循主字体，正文遵循次字体。使用显式字体名称而不是主题标识符的文本在主题字体方案更改时不会自动切换。

主字体和次字体集合还可以包含针对特定书写系统（如西里尔、阿拉伯、日语、格鲁吉亚和塔那）的字体映射。要检查、添加、替换或删除这些映射，请参阅 [Script-Specific Theme Fonts](/slides/zh/androidjava/script-specific-font-mappings/)。

{{% alert color="info" title="提示" %}}

有关演示文稿字体的更多信息，请参阅 [PowerPoint Fonts](/slides/zh/androidjava/powerpoint-fonts/)。

{{% /alert %}}

## **复制或应用主题**

下面的工作流解决不同的主题相关问题。

### **将外部主题应用于依赖于某母版的幻灯片**

当你拥有 PowerPoint 主题文件（`.thmx`）并希望重新样式化所有依赖于特定母版的幻灯片时，使用 [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasterslide/)。从 [Presentation.getMasters](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 集合中选择母版（该集合实现了 [IMasterSlideCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasterslidecollection/)），并将主题文件路径传入该方法。

该方法执行以下操作：

1. 基于所选母版创建一个新母版幻灯片。  
2. 将外部主题应用到新母版。  
3. 将新母版分配给先前依赖于所选母版的所有幻灯片。  
4. 返回新创建的 [IMasterSlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasterslide/)。

下面的示例将外部主题应用于依赖第一个母版的幻灯片，并保存演示文稿：

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

无效、损坏或不受支持的主题可能导致 [PptxReadException](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pptxreadexception/)。请验证用户提供的路径，处理文件系统访问失败，并仅在主题成功应用后保存演示文稿。

仅重新分配依赖所选母版的幻灯片。与其他母版关联的幻灯片保留其现有母版和主题。支持主题的颜色、字体、填充、线条、背景和效果会依据外部主题解析。直接分配的颜色、字体、填充等显式格式可能保持不变。布局级和幻灯片级的覆盖也可能优先于从新母版继承的值。

主题可能引用运行时环境中不存在的字体。为确保一致的渲染和导出，请安装所需字体、通过 [custom font sources](/slides/zh/androidjava/custom-font/) 提供，或配置 [font substitution](/slides/zh/androidjava/font-substitution/)。

这是一个直接的母版级工作流：方法接受 `.thmx` 文件路径，无需手动创建幻灯片级或布局级的主题覆盖。

### **在多母版演示文稿中应用不同的外部主题**

当事先不知道相关母版时，可通过 [ISlide.getLayoutSlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islide/) 与 [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilayoutslide/) 从代表性幻灯片获取母版。在应用任何主题之前存储原始母版引用，因为每次调用都会在演示文稿中创建另一个母版。

下面的示例使用两个章节的幻灯片定位它们的母版，并对每组应用不同的外部主题：

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

### **移动幻灯片时保留源主题**

如果希望将幻灯片移动到另一个演示文稿并保留其原始设计，可使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imasterslidecollection/) 将源母版克隆到目标演示文稿，然后使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islidecollection/) 将幻灯片连同克隆的母版一起克隆。这样会一起携带母版、其布局以及关联的主题。

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

在需要目标幻灯片在目标文件中保持相同外观时，这是首选工作流。仅将内容克隆到一个不相关的目标母版可能会改变主题驱动的颜色、字体、背景和效果。

### **将主题值应用于现有幻灯片**

如果目标幻灯片必须保留当前的母版和布局，可从源主题初始化幻灯片级覆盖。`[OverrideTheme.initColorSchemeFrom]`、`[OverrideTheme.initFontSchemeFrom]` 与 `[OverrideTheme.initFormatSchemeFrom]` 方法会将三大主题组件复制到覆盖中。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

此操作在不更改其他幻灯片继承主题的前提下修改该幻灯片使用的主题。若要移除本地覆盖并恢复继承值，请调用 `[OverrideTheme.clear]`。

### **将主题覆盖应用于布局**

布局级覆盖适用于使用该布局的幻灯片，除非特定幻灯片拥有自己的覆盖。相同的初始化方法可以通过 `[LayoutSlideThemeManager]` 使用：

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

当多个布局和幻灯片应共享相同基础设计时，使用母版或演示文稿级主题；当某一布局族需要不同样式时使用布局覆盖；仅在真正的例外情况下使用幻灯片覆盖。过多的幻灯片级覆盖会使后续全局主题更改难以预测。

## **更新主题背景样式**

主题的背景填充存储在 `[IFormatScheme.getBackgroundFillStyles]` 中。PowerPoint 在 UI 中可以呈现比此集合实际存储的填充定义更多的背景选项，因为 UI 可以将主题填充与主题颜色及其他样式引用组合使用。

![PowerPoint 演示文稿主题的背景样式库](presentation-design_8.png)

在使用背景样式之前，请检查存储的集合以及当前的 `[Background.getStyleIndex]`。索引为 `0` 表示没有主题填充；正数表示主题背景样式引用。这不同于直接使用 Java 集合的索引方式（`get_Item(0)` 表示第一项）。不要假设每个演示文稿都包含相同数量的背景填充样式。

下面的示例报告可用的背景填充计数，将主题背景引用分配给第一个母版，并保存演示文稿：

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

可见结果取决于母版引用的主题条目以及布局或幻灯片级的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要了解继承后最终背景时，请使用 `[Background.getEffective]`。

{{% alert color="warning" title="警告" %}}

不要把样式索引当作零基集合索引。同样避免硬编码来自某文件的样式编号并假设在另一文件中外观相同；主题样式定义是针对特定演示文稿的。

{{% /alert %}}

{{% alert color="info" title="提示" %}}

有关直接背景格式化和背景继承，请参阅 [Presentation Background](/slides/zh/androidjava/presentation-background/)。

{{% /alert %}}

## **更新主题效果**

主题格式方案包含通过 `[IFormatScheme.getFillStyles]`、`[IFormatScheme.getLineStyles]` 和 `[IFormatScheme.getEffectStyles]` 暴露的独立填充、线条和效果样式集合。典型的 Office 主题通常包含三条主要样式条目，分别对应微妙、适中和强烈的视觉效果，但代码应检查每个集合而不是假设固定数量。

![对同一形状应用的微妙、适中和强烈主题效果](presentation-design_10.png)

在 Java 中访问这些集合时，集合索引是从零开始的：`get_Item(0)` 为第一条存储的样式，`get_Item(2)` 为第三条。形状的样式引用索引是另一概念，由 `[IShapeStyle]` 暴露。修改主题样式会影响引用该主题样式的形状；具有直接格式化的形状可能保持不变。

下面的示例检查所需的样式条目是否存在，修改第一条线条样式、第三条填充样式，并在第三条效果样式中启用外阴影，随后保存结果：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

对于引用这些槽位的形状，第一条主题线条样式将变为红色，第三条主题填充样式将变为实心森林绿，第三条效果样式将获得距离为 10 点的外阴影。具体视觉结果仍取决于每个形状引用的样式槽位以及是否有直接格式化覆盖主题。

![更改线条、填充和阴影设置后主题效果样式的效果](presentation-design_11.png)

## **判断有效实心填充是否使用主题颜色**

填充可以直接存储在对象上，也可以继承自段落、布局、母版、主题样式或其他格式层级。调用 `[IFillFormat.getEffective]` 可将该层级解析为不可变的 `[IFillFormatEffectiveData]`。首先检查 `[IFillFormatEffectiveData.getFillType]`。仅当其为 `FillType.Solid` 时才读取实心填充属性。

对于实心填充，`[IFillFormatEffectiveData.getSolidFillColor]` 返回在继承、主题查找和颜色变换后渲染的最终 RGB 值。`[IFillFormatEffectiveData.getSolidFillSchemeColor]` 返回相应的逻辑 `[SchemeColor]` 槽位，如 `Text1` 或 `Accent6`。`SchemeColor.NotDefined` 表示有效实心填充并非基于方案颜色。在仅使用主题颜色或直接 RGB 颜色的工作流中，此值可标识直接 RGB 填充。

不要仅使用本地的 `[IColorFormat.getSchemeColor]` 值来分类填充。例如，文本片段本地可能没有定义方案颜色，其本地值为 `NotDefined`，但其有效填充可能继承自主题颜色并解析为 `Text1` 或 `Accent6`。相反，`getSolidFillSchemeColor` 告诉你哪个逻辑主题槽位产生了有效颜色，但不指明该槽位来源于对象、段落、布局、母版还是其他层级。

下面的示例加载演示文稿，审计形状填充和文本片段填充，打印每个最终 RGB 值及关联的方案颜色，并标记不会随主题颜色变化的实心填充：

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`NotDefined` 分支提供了一个审计列表，列出那些在主题颜色槽位更改时不会响应的实心填充。检查这些对象以确保演示文稿遵循新的品牌调色板。报告的 RGB 值仍显示当前外观，方案值说明该外观是否与主题相连。

有效格式对象是快照。更改演示文稿主题、主题覆盖或任何继承格式后，再次调用 `getEffective` 并读取新的 `IFillFormatEffectiveData` 对象后再进行比较或报告颜色。

## **读取有效主题值**

原始主题对象告诉你在特定层级定义了什么。有效值告诉你幻灯片或形状在继承和本地覆盖解析后实际使用了什么。对于幻灯片，调用 `[BaseOverrideThemeManager.createThemeEffective]`。对于背景，使用 `[Background.getEffective]`；对于填充，使用 `[FillFormat.getEffective]`。

下面的示例读取幻灯片的有效主题、背景以及第一形状的填充：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

使用有效数据进行渲染诊断、验证和比较。如果仅检查 `[Presentation.getMasterTheme]`，可能会错过改变最终外观的母版、布局、幻灯片或形状覆盖。

## **常见问题**

**将外部主题应用会影响演示文稿中的每张幻灯片吗？**

不会。`[IMasterSlide.applyExternalThemeToDependingSlides]` 只重新分配依赖所选母版的幻灯片。使用其他母版的幻灯片保留其现有主题。

**我可以只对单张幻灯片应用主题而不更改母版吗？**

可以。使用幻灯片的 `[SlideThemeManager]` 并初始化其覆盖主题。更改仅局部作用于该幻灯片，其他幻灯片继续继承各自的主题。

**将主题从一个演示文稿迁移到另一个的最安全方法是什么？**

在移动幻灯片并保留源外观时，先使用 `[IMasterSlideCollection.addClone]` 将源母版克隆到目标演示文稿，然后使用 `[ISlideCollection.addClone]` 将幻灯片连同该母版克隆。这会保持母版、布局和主题一起转移。

**如何查看继承和覆盖后的有效值？**

对幻灯片或布局主题使用 `[BaseOverrideThemeManager.createThemeEffective]`，对格式对象使用相应的有效数据方法，如 `[Background.getEffective]` 和 `[FillFormat.getEffective]`。这些 API 返回在继承和覆盖应用后的解析值。