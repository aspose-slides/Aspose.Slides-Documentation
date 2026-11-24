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
description: "通过 Java 在 Aspose.Slides for Android 中掌控演示文稿主题，以创建、定制并转换具有一致品牌的 PowerPoint 文件。"
---
## **介绍**

演示文稿主题定义了一组协调的颜色、字体、背景样式、填充、线条和效果。支持主题的对象引用这些共享定义，而不是将每个视觉属性存储为固定值，因此更改主题可以一次性更新许多对象。

在 Aspose.Slides 中，可通过 [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 获取演示文稿级别的主题。演示文稿还可以在更低层级包含主题覆盖。母版可以通过 [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/) 覆盖演示文稿主题，而布局或单个幻灯片可以通过 [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) 覆盖其继承的主题。实际上，幻灯片的有效主题通过以下继承链解析：演示文稿主题 → 母版覆盖 → 布局覆盖 → 幻灯片覆盖。

![主题组件：颜色、字体、背景样式和效果](theme-constituents.png)

下面的章节展示了最常见的主题工作流：检查主题、更改颜色和字体、复制或应用主题、更新背景和效果样式，以及在继承和覆盖解析后读取有效值。

## **检查主题**

[MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) 对象通过 [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) 和 [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) 暴露主题的配色方案、字体方案和格式方案。在更改之前检查这些集合尤其有用，因为来自外部来源的演示文稿可能在样式条目数量和内容上有所不同。

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

支持主题的填充、线条和文本可以引用 [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) 枚举中的逻辑颜色。当您更改 [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) 中对应的条目时，所有仍引用该主题颜色的对象都会解析为新值。使用直接 RGB 颜色的对象不会受到主题颜色更新的影响。

下面的端到端示例创建一个使用 `Accent4` 的形状，将主题的 `Accent4` 颜色更改为红色，保存演示文稿，重新打开它，并打印有效填充颜色：

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

因为矩形仍然链接到 `Accent4`，主题更改后其可见颜色变为红色。如果您在形状上用直接颜色替换了方案颜色，则后续对 `Accent4` 的更改将不再影响该填充。

### **使用附加调色板中的颜色**

PowerPoint 通过对主题颜色应用颜色转换来生成更亮和更暗的变体。Aspose.Slides 通过 [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/) 枚举公开这些转换。

![主主题颜色以及从附加调色板生成的更亮和更暗颜色](additional-palette-colors.png)

**1** - 主主题颜色。

**2** - 基于主主题颜色生成的更亮和更暗变体。

下面的示例基于 `Accent4` 创建六个矩形，对其中五个应用亮度转换，并保存结果：

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

这些变体仍基于主题颜色。如果随后 `Accent4` 发生更改，转换后的颜色将根据新的 `Accent4` 值重新计算。

### **将 `SchemeColor` 值映射到 `IColorScheme` 槽位**

[SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) 枚举使用 `Text1`、`Background1`、`Text2`、`Background2`，而 [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) 将相同的主题槽位公开为 `Dark1`、`Light1`、`Dark2`、`Light2`。映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

这些是同一主题槽位的别名；它们不是会在不同形式之间动态转换的值。

## **更改主题字体**

主题字体方案包含用于标题的主字体集和用于正文的次字体集。[IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) 与 [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) 方法公开这些集合。

PowerPoint 兼容的主题字体标识符可用于文本格式化：

* `+mn-lt` - 正文字体 Latin（次 Latin 字体）
* `+mj-lt` - 标题字体 Latin（主 Latin 字体）
* `+mn-ea` - 正文字体 East Asian（次东亚字体）
* `+mj-ea` - 标题字体 East Asian（主东亚字体）
* `+mn-cs` - 正文字体 Complex Script（次复杂脚本字体）
* `+mj-cs` - 标题字体 Complex Script（主复杂脚本字体）

下面的示例创建一个使用主 Latin 主题字体的标题和一个使用次 Latin 主题字体的正文行。随后更改主题字体并保存结果：

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

标题遵循主字体，正文遵循次字体。具有显式字体名称而非主题标识符的文本在主题字体方案更改时不会自动切换。

主字体和次字体集合还可以包含针对特定书写系统（如西里尔文、阿拉伯文、日文、格鲁吉亚文和塔那文）的字体映射。要检查、添加、替换或删除这些映射，请参阅 [Script-Specific Theme Fonts](/slides/zh/androidjava/script-specific-font-mappings/)。

{{% alert color="info" title="Tip" %}}
有关演示文稿字体的更多信息，请参阅 [PowerPoint Fonts](/slides/zh/androidjava/powerpoint-fonts/)。
{{% /alert %}}

### **解析主题字体引用**

在检查文本时，[IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) 可能返回诸如 `+mn-lt` 的主题引用，而不是字体族名称。使用适当的 [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) 调用 [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) 来解析该引用。`+mj` 和 `+mn` 前缀选择主/次字体集；`-lt`、`-ea`、`-cs` 后缀分别选择其 Latin、East Asian 和 Complex Script 字体。

通过在适用文本的对象上调用 [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) 获取有效主题。对于普通幻灯片上的文本，在幻灯片上调用此方法，以便上下文包含该幻灯片的继承主题和本地覆盖。检查布局或母版本身时，使用其自身的有效主题。不要假设第一个母版的主题适用于每张幻灯片。

下面的示例创建一个显式引用次 Latin 字体的文本段落。它通过 [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) 初始化幻灯片字体方案，并将主、次 Latin 字体族设为 `Arial` 和 `Calibri`，使结果在没有输入文件的情况下可复现。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

输出为 `+mn-lt -> Calibri`，随后是 `Verdana -> Verdana`。存储的引用保持不变，而显式的族名称原样返回。如果段落使用 `+mj-lt`，则会在此主题中解析为 `Arial`。

解析主题引用仅标识主题指定的字体族。它不检查字体可用性，也不决定在渲染期间替换或字形回退后实际使用的字体文件。有关这些独立步骤，请参阅 [Font Selection Sequence](/slides/zh/androidjava/font-selection-sequence/) 和 [Font Substitution](/slides/zh/androidjava/font-substitution/)。

## **复制或应用主题**

下面的工作流解决不同的主题相关问题。

### **将外部主题应用于母版依赖的幻灯片**

当您拥有 PowerPoint 主题文件（`.thmx`）并希望重新样式化依赖特定母版的所有幻灯片时，请使用 [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/)。从 [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 集合中选择母版（该集合实现了 [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/)），并将主题文件路径传递给该方法。

该方法执行以下操作：

1. 基于所选母版创建一个新母版幻灯片。  
1. 将外部主题应用到新母版。  
1. 将新母版分配给先前依赖所选母版的所有幻灯片。  
1. 返回新创建的 [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/)。

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

无效、损坏或不受支持的主题可能导致 [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/)。请验证用户提供的路径，处理文件系统访问失败，并仅在主题成功应用后保存演示文稿。

仅重新分配依赖所选母版的幻灯片。与其他母版关联的幻灯片保留其现有母版和主题。支持主题的颜色、字体、填充、线条、背景和效果会相对于外部主题重新解析。直接分配的颜色、字体、填充和其他显式格式可能保持不变。布局级和幻灯片级覆盖也可能优先于从新母版继承的值。

主题可能引用在运行时环境中不可用的字体。为获得一致的渲染和导出，请安装所需字体，或通过 [custom font sources](/slides/zh/androidjava/custom-font/) 提供，或配置 [font substitution](/slides/zh/androidjava/font-substitution/)。

这是一种直接的母版级工作流：该方法接受 `.thmx` 文件路径，无需手动创建幻灯片级或布局级主题覆盖。

### **在多母版演示文稿中应用不同的外部主题**

当事先不知道相关母版时，可通过 [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) 和 [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/) 从代表性幻灯片获取母版。 在应用任何主题之前存储原始母版引用，因为每次调用都会在演示文稿中创建另一个母版。

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

### **在移动幻灯片时保留源主题**

如果您想将幻灯片移动到另一个演示文稿并保留其原始设计，请使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) 将源母版克隆到目标演示文稿，然后使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) 将幻灯片与克隆的母版一起克隆。这样会连同母版、其布局以及关联的主题一起转移。

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

当源幻灯片必须在目标中保持相同外观时，这是首选工作流。仅将内容克隆到不相关的目标母版可能会更改受主题驱动的颜色、字体、背景和效果。

### **将主题值应用于现有幻灯片**

如果目标幻灯片必须保持在当前母版和布局上，请从源主题初始化幻灯片级覆盖。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) 和 [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) 方法会将三个主要主题组件复制到覆盖中。

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

这会更改该幻灯片使用的主题，而不会更改其他幻灯片继承的主题。要删除本地覆盖并返回继承值，请调用 [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/)。

### **将主题覆盖应用于布局**

布局级覆盖适用于使用该布局的所有幻灯片，除非特定幻灯片有自己的覆盖。相同的初始化方法可通过 [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/) 使用：

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

当许多布局和幻灯片应共享相同的基础设计时使用母版或演示文稿级主题；当某个布局族需要不同样式时使用布局覆盖；仅在真正的例外情况下使用幻灯片覆盖。过度的幻灯片级覆盖会使后续全局主题更改的预测变得更加困难。

<!-- visual-explanation:presentation-theme:start -->
[![一个母版主题供两个布局使用；布局覆盖影响其幻灯片，除非幻灯片有更局部的覆盖。](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*布局覆盖适用于使用该布局的幻灯片，除非幻灯片提供了自己的覆盖。基于主题的值遵循其解析后的方案；显式格式化的对象可以保留其本地外观。请将覆盖范围限制在预期的设计例外范围内。*
<!-- visual-explanation:presentation-theme:end -->

## **更新主题背景样式**

主题的背景填充存储在 [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) 中。PowerPoint 在其 UI 中可以呈现比此集合实际存储的填充定义更多的背景选项，因为 UI 可以将主题填充与主题颜色和其他样式引用组合使用。

![PowerPoint 演示文稿主题的背景样式库](presentation-design_8.png)

在使用背景样式之前，检查存储的集合以及当前的 [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/)。`0` 表示没有主题填充；正值表示主题背景样式引用。这不同于直接对 Java 集合进行索引，其中 `get_Item(0)` 表示第一个存储项。不要假设每个演示文稿都有相同数量的背景填充样式。

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

可见结果取决于母版引用的主题条目以及布局或幻灯片级的任何背景覆盖。如果幻灯片使用了自己的背景，仅更改母版背景可能不会影响该幻灯片。需要了解继承后最终背景时，请使用 [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/)。

{{% alert color="warning" title="Warning" %}}
不要将样式索引当作零基集合索引。也避免硬编码某个文件的样式编号并假设在另一个文件中具有相同外观；主题样式定义是针对特定演示文稿的。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
有关直接背景格式化和背景继承，请参阅 [Presentation Background](/slides/zh/androidjava/presentation-background/)。
{{% /alert %}}

## **更新主题效果**

主题格式方案包含通过 [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) 和 [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) 公开的独立填充、线条和效果样式集合。典型的 Office 主题通常包含三个主要样式条目，视觉上对应于细微、适度和强烈的格式，但代码应检查每个集合，而不要假设固定数量。

![对同一形状应用的细微、适度和强烈主题效果](presentation-design_10.png)

在 Java 中访问这些集合时，集合索引是零基的：`get_Item(0)` 是第一个存储的样式，`get_Item(2)` 是第三个。形状的样式引用索引是另一个概念，由 [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/) 暴露。修改主题样式会影响引用该主题样式的形状；直接格式化的形状可能保持不变。

下面的示例检查所需的样式条目是否存在，修改第一条线条样式，修改第三条填充样式，在第三条效果样式中启用外部阴影，并保存结果：

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

对于引用这些槽位的形状，第一条主题线条样式会变为红色，第三条主题填充样式会变为实心森林绿，第三条效果样式会获得距离为 10 点的外部阴影。确切的视觉结果仍取决于每个形状引用的样式槽位以及是否有直接格式覆盖主题。

![更改线条、填充和阴影设置后的主题效果样式](presentation-design_11.png)

## **为形状选择主题填充和线条样式**

形状可以通过 [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) 和 [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-) 独立选择填充和轮廓。对于任一方法，索引 `1` 选择对应主题集合中的第一条条目（`get_Item(0)`），索引 `2` 选择第二条（`get_Item(1)`）。

下面的示例在新演示文稿的默认主题中设置两种填充样式（金色和天蓝色）和两种线条样式（深蓝色 6 pt 和深红色 12 pt）。它在三个阶段保存幻灯片，以便您在 PowerPoint 中比较结果。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 初始样式 | 更改右侧轮廓 | 编辑第一主题填充 |
|:---:|:---:|:---:|
| ![金色和天蓝色矩形，配有匹配的细深蓝轮廓](theme-style-initial.png) | ![天蓝色矩形现在具有粗深红轮廓](theme-style-line-changed.png) | ![左侧矩形现在为绿色，两个轮廓保持不变](theme-style-fill-changed.png) |

选择不同的线条样式仅更改右侧矩形的轮廓。编辑第一主题填充会更新使用该填充的所有形状，此例中仅左侧矩形变为绿色。

在已有形状上，本地填充颜色、线条颜色或线条宽度可以覆盖主题样式的相应部分。如果更改样式索引没有可见效果，请检查形状的 [direct formatting](/slides/zh/androidjava/shape-formatting/)。

## **判断有效实心填充是否使用主题颜色**

填充可以直接存储在对象上，或从段落、布局、母版、主题样式或其他格式层级继承。调用 [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) 将该层级解析为不可变的 [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/)。首先检查 [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/)。只有当返回 `FillType.Solid` 时才读取实心填充属性。

对于实心填充，[IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) 返回在继承、主题查找和颜色转换后最终渲染的 RGB 值。[IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) 返回对应的逻辑 [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) 槽位，如 `Text1` 或 `Accent6`。`SchemeColor.NotDefined` 表示有效实心填充并非基于方案颜色。在填充只能是主题颜色或直接 RGB 颜色的工作流中，该值标识直接 RGB 填充。

不要仅使用本地的 [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) 值来分类填充。例如，文本段落可能没有本地定义的方案颜色，其本地值为 `NotDefined`，但其有效填充继承自主题颜色并解析为 `Text1` 或 `Accent6`。相反，`getSolidFillSchemeColor` 告诉您是哪一个逻辑主题槽位产生了有效颜色，但它不说明该槽位来自对象、段落、布局、母版还是其他层级。

下面的示例加载演示文稿，审计形状填充和文本段落填充，打印每个最终 RGB 值及其关联的方案颜色，并标记不会跟随主题颜色更改的实心填充：

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

`NotDefined` 分支提供了一个审计列表，列出不会响应主题颜色槽位更改的实心填充。在需要遵循新品牌调色板的演示文稿中检查这些对象。报告的 RGB 值仍显示当前外观，而方案值解释了该外观是否与主题相连。

有效格式对象是快照。更改演示文稿主题、主题覆盖或任何继承格式后，请再次调用 `getEffective` 并读取新的 `IFillFormatEffectiveData` 对象后再进行比较或报告颜色。

## **读取有效主题值**

原始主题对象告诉您在特定层级上定义了什么。有效值告诉您在继承和本地覆盖解析后，幻灯片或形状实际使用了什么。对于幻灯片，请调用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/)。对于背景，使用 [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/)，对于填充，使用 [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/)。

下面的示例读取幻灯片的有效主题、背景和第一个形状填充：

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

使用有效数据进行渲染诊断、验证和比较。如果仅检查 [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)，可能会错过更改最终外观的母版、布局、幻灯片或形状覆盖。

## **常见问题**

**将外部主题应用于演示文稿是否会影响每张幻灯片？**

不会。[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) 仅重新分配依赖所选母版的幻灯片。使用其他母版的幻灯片保留其现有主题。

**我可以在不更改母版的情况下将主题应用于单张幻灯片吗？**

可以。使用幻灯片的 [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) 并初始化其覆盖主题。更改仅局限于该幻灯片；其他幻灯片继续继承其现有主题。

**将主题从一个演示文稿迁移到另一个演示文稿的最安全方式是什么？**

在移动幻灯片并保留源外观时，使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) 将源母版克隆到目标演示文稿，然后使用 [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) 将幻灯片与该母版一起克隆。这样可以一起保留母版、布局和主题。

**如何查看继承和覆盖后的有效值？**

对幻灯片或布局主题使用 [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/)，对格式对象（如 [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) 和 [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/)）使用相应的有效数据方法。这些 API 返回继承和覆盖应用后的解析值。