---
title: 在 Java 中管理演示文稿幻灯片母版
linktitle: 幻灯片母版
type: docs
weight: 70
url: /zh/java/slide-master/
keywords:
- 幻灯片母版
- 母版幻灯片
- PPT 母版幻灯片
- 多个母版幻灯片
- 比较母版幻灯片
- 背景
- 占位符
- 克隆母版幻灯片
- 复制母版幻灯片
- 复制母版幻灯片
- 未使用的母版幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中管理幻灯片母版：访问、编辑、克隆、比较和删除 PowerPoint 及 OpenDocument 演示文稿中的母版幻灯片。"
---
## **概述**

**幻灯片母版** 定义了一组幻灯片的共享设计设置。它可以包含常用形状、徽标、背景、文本样式、主题设置和页脚设置。在 PowerPoint 中，编辑幻灯片母版是保持演示文稿一致性、避免在每张幻灯片上重复相同格式的常用方法。

Aspose.Slides for Java 支持相同的模型。一个演示文稿可以包含一个或多个母版幻灯片，每个母版幻灯片可以包含多个布局幻灯片。普通幻灯片通常不会直接引用母版幻灯片，而是使用布局幻灯片，该布局幻灯片属于某个母版幻灯片。

层次结构如下：

1. **幻灯片母版** - 定义共享的设计和主题。  
1. **布局幻灯片** - 定义占位符的具体排列以及布局级别的格式。  
1. **普通幻灯片** - 包含实际的演示内容并使用一个布局幻灯片。

![母版幻灯片、布局幻灯片和普通幻灯片的层次结构](slide-master_2.jpg)

在 Aspose.Slides 中，幻灯片母版由 [IMasterSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslide/) 接口表示。演示文稿中的所有母版幻灯片可以通过 [Presentation.getMasters](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getMasters--) 集合访问，该集合实现了 [IMasterSlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslidecollection/)。

{{% alert color="info" title="Inheritance" %}}

当同一属性在多个层级上定义时，越具体的层级优先。例如，如果母版幻灯片和布局幻灯片都定义了背景，则基于该布局的幻灯片使用布局背景。有关布局幻灯片的更多信息，请参阅 [Apply or Change Slide Layouts](/slides/zh/java/slide-layout/)。

{{% /alert %}}

## **访问幻灯片母版**

在 PowerPoint 中，您可以通过 **视图** > **幻灯片母版** 打开幻灯片母版视图。

![PowerPoint 视图选项卡上的 幻灯片母版 命令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters()` 集合访问母版幻灯片：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

您还可以通过普通幻灯片的布局获取其使用的母版幻灯片：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **幻灯片母版包含哪些内容**

母版幻灯片是类幻灯片对象。它实现了 [IBaseSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseslide/)，因此公开了许多普通幻灯片和布局幻灯片使用的相同属性。母版特有的成员列在 [IMasterSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslide/) API 页面上。

常用的母版幻灯片成员包括：

| 成员 | 作用 |
| --- | --- |
| `getBackground()` | 设置母版级别的幻灯片背景。 |
| `getShapes()` | 存储放置在母版上的形状，例如标志、图片框和共享文本。 |
| `getLayoutSlides()` | 存储属于该母版的布局幻灯片。 |
| `getThemeManager()` | 提供对母版主题 API 的访问。 |
| `getHeaderFooterManager()` | 控制母版及其子布局的页眉、页脚、日期和幻灯片编号。 |
| `getDependingSlides()` | 返回通过其布局依赖于该母版的普通幻灯片。 |

## **向幻灯片母版添加图像**

将图像添加到母版幻灯片后，使用该母版布局的所有幻灯片都会显示该图像。这对于徽标、水印、装饰条带等重复的视觉元素非常有用。

下面的示例向第一张母版幻灯片添加徽标：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

有关图片框的更多信息，请参阅 [Picture Frame](/slides/zh/java/picture-frame/)。

## **控制母版图形的可见性**

使用 [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) 可以隐藏继承自母版的图形（如徽标或装饰形状），而不会将它们从母版中删除。对需要省略这些图形的幻灯片调用 [Slide.setShowMasterShapes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) 并传入 `false`，在需要显示这些图形的幻灯片上保持 `true`。

下面的完整示例在母版上创建一个蓝色装饰条带，并在两个使用相同空白布局的幻灯片上演示其可见性：第一张幻灯片可见，第二张隐藏。无需输入演示文稿或图像。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

该示例使用新演示文稿自带的 **Blank** 布局，并删除了初始幻灯片的占位符。

### **选择设置的作用范围**

普通幻灯片通过 [ISlide.getLayoutSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islide/#getLayoutSlide--) 和 [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilayoutslide/#getMasterSlide--) 间接使用其母版。对单个幻灯片设置属性只影响该幻灯片本身。将 `false` 传递给 [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) 会隐藏使用该共享布局的所有幻灯片的母版图形，即使它们各自的设置为 `true`。若只想在一张幻灯片上隐藏图形，请修改该幻灯片的属性并保持共享布局不变。

该设置不支持在母版幻灯片本身上作为可见性控制使用。在母版上，[getShowMasterShapes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/masterslide/#getShowMasterShapes--) 始终返回 `false`，将 `true` 传递给 [setShowMasterShapes](https://reference.aspose.com/slides/zh/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) 会抛出异常。请将其应用于普通幻灯片或布局幻灯片。

### **将图形与背景区分开来**

| 操作 | 效果 |
| --- | --- |
| 隐藏母版图形 | 在不删除或更改幻灯片自身形状的情况下，控制继承的母版形状的可见性。 |
| 更改幻灯片背景填充 | 更改背景颜色、渐变或图像。母版图形是独立的形状，可保持在该背景之上可见。参见 [Presentation Background](/slides/zh/java/presentation-background/)。 |
| 删除母版中的形状 | 移除共享源形状，之后任何使用该母版的幻灯片都不再拥有该形状。 |

## **使用占位符**

占位符通常在布局幻灯片上定义。母版幻灯片提供共享的样式和主题，布局决定哪些占位符可用以及它们的位置。

在 PowerPoint 中，占位符命令位于幻灯片母版视图中。

![PowerPoint 幻灯片母版视图中的 插入占位符 命令](slide-master_5.png)

要使用 Aspose.Slides 添加新占位符，请操作属于母版的布局幻灯片：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

您也可以格式化已存在于母版幻灯片上的占位符形状。下面的示例找到标题占位符并应用线性渐变填充：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![普通幻灯片继承的已格式化标题占位符](slide-master_8.png)

有关占位符和文本格式化的更多选项，请参阅 [Set Prompt Text in Placeholder](/slides/zh/java/manage-placeholder/) 和 [Text Formatting](/slides/zh/java/text-formatting/)。

## **更改幻灯片母版背景**

母版背景会被布局和未覆盖它的幻灯片继承。下面的示例为第一张母版幻灯片设置纯色背景：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

相关主题请参见 [Presentation Background](/slides/zh/java/presentation-background/) 和 [Presentation Theme](/slides/zh/java/presentation-theme/)。

## **将幻灯片母版克隆到另一个演示文稿**

使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) 可以将母版幻灯片复制到另一演示文稿。复制后的母版即可被目标演示文稿中的布局和幻灯片使用。

```java
import com.aspose.slides.*;

Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

如果需要连同母版一起克隆普通幻灯片，请参阅 [Clone Slides](/slides/zh/java/clone-slides/)。

## **添加多个幻灯片母版**

一个演示文稿可以包含多个母版幻灯片。这在不同章节需要不同品牌、页面结构或主题设置时非常有用。

![PowerPoint 插入和管理母版幻灯片的命令](slide-master_9.jpg)

下面的示例克隆默认母版，给克隆的母版设置不同的背景，在该克隆母版下创建布局，并基于该布局添加新幻灯片：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **比较幻灯片母版**

可以使用从 [IBaseSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseslide/) 继承的 `equals` 方法比较母版幻灯片。比较会检查结构和静态内容，如形状、文本、格式、动画以及其他幻灯片设置。它不会比较唯一标识符（如幻灯片 ID）或动态占位符值（如当前日期）。

```java
import com.aspose.slides.*;

Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

更多信息请参阅 [Compare Presentation Slides](/slides/zh/java/compare-slides/)。

## **将幻灯片母版视图设为默认视图**

在 [ViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewproperties/) 上使用 `setLastView` 方法可以控制 PowerPoint 首次打开时的视图。下面的示例在幻灯片母版视图中打开演示文稿：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

有关更多视图设置，请参阅 [Save Presentation](/slides/zh/java/save-presentation/)。

## **删除未使用的母版幻灯片**

演示文稿有时会包含不再被任何普通幻灯片使用的母版幻灯片。删除未使用的母版可以减小文件大小并简化模板维护。

使用 `removeUnused` 可从 `getMasters()` 集合中删除未使用的母版：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

您也可以使用低代码的 [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 方法：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**幻灯片母版与布局幻灯片有什么区别？**

幻灯片母版定义了共享的设计设置，例如主题、背景、公共形状和文本样式。布局幻灯片属于母版并定义占位符的具体排列。普通幻灯片使用布局幻灯片，因此它既继承布局也继承母版的设置。

**一个演示文稿可以包含多个幻灯片母版吗？**

可以。演示文稿可以包含多个幻灯片母版。当不同章节需要不同的视觉体系或品牌时，请使用多个母版。

**应该在母版幻灯片还是布局幻灯片上添加占位符？**

大多数情况下，应在布局幻灯片上添加占位符。将共享的视觉元素和共享格式放在母版上，然后在普通幻灯片将使用的布局上放置内容占位符。

**我可以删除仍在使用中的母版幻灯片吗？**

不能。仍有从属幻灯片的母版幻灯片不能直接安全删除。请先将这些幻灯片移动到其他母版的布局下，或使用仅删除未使用母版的清理方法。