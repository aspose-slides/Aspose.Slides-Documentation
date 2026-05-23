---
title: 用 Java 管理演示文稿幻灯片母版
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
- 复制作母版幻灯片
- 未使用的母版幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 中管理幻灯片母版：访问、编辑、克隆、比较和移除 PowerPoint 与 OpenDocument 演示文稿中的母版幻灯片。"
---
## **概述**

**幻灯片母版** 定义了一组幻灯片的共享设计设置。它可以包含通用形状、徽标、背景、文字样式、主题设置以及页脚设置。在 PowerPoint 中，编辑幻灯片母版是保持演示文稿一致性的常用方法，无需在每张幻灯片上重复相同的格式。

Aspose.Slides for Java 支持相同的模型。一个演示文稿可以包含一个或多个母版幻灯片，每个母版幻灯片可以包含若干版式幻灯片。普通幻灯片通常不会直接引用母版幻灯片，而是使用版式幻灯片，而该版式幻灯片属于某个母版幻灯片。

层次结构如下：

1. **幻灯片母版** - 定义共享的设计和主题。  
2. **版式幻灯片** - 定义占位符的具体排列和版式层级的格式。  
3. **普通幻灯片** - 包含实际的演示内容，并使用一个版式幻灯片。

![母版幻灯片、版式幻灯片和普通幻灯片的层次结构](slide-master_2.jpg)

在 Aspose.Slides 中，幻灯片母版由 [IMasterSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslide/) 接口表示。演示文稿中的所有母版幻灯片可通过 [Presentation.getMasters](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getMasters--) 集合获取，该集合实现了 [IMasterSlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslidecollection/)。

{{% alert color="info" title="Inheritance" %}}
当同一属性在多个层级上都有定义时，层级更具体的设置会覆盖更通用的设置。例如，如果母版幻灯片和版式幻灯片都定义了背景，则基于该版式的幻灯片使用版式背景。有关版式幻灯片的更多信息，请参阅 [Apply or Change Slide Layouts](/slides/zh/java/slide-layout/)。
{{% /alert %}}

## **访问幻灯片母版**

在 PowerPoint 中，可以通过 **视图** > **幻灯片母版** 打开幻灯片母版视图。

![PowerPoint“视图”选项卡上的幻灯片母版命令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters()` 集合访问母版幻灯片：

```java
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

也可以通过普通幻灯片的版式获取其使用的母版幻灯片：

```java
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

## **幻灯片母版包含的内容**

母版幻灯片是类似幻灯片的对象。它实现了 [IBaseSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseslide/)，因此公开了与普通幻灯片和版式幻灯片相同的许多属性。母版特有的成员列在 [IMasterSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslide/) API 页面上。

常用的母版幻灯片成员包括：

| 成员 | 用途 |
| --- | --- |
| `getBackground()` | 设置母版层级的幻灯片背景。 |
| `getShapes()` | 存储放置在母版上的形状，例如徽标、图片框和共享文字。 |
| `getLayoutSlides()` | 存储属于该母版的版式幻灯片。 |
| `getThemeManager()` | 提供对母版主题 API 的访问。 |
| `getHeaderFooterManager()` | 控制母版及其子版式的页眉、页脚、日期和页码。 |
| `getDependingSlides()` | 返回通过其版式依赖于该母版的普通幻灯片。 |

## **向幻灯片母版添加图片**

向母版幻灯片添加图片后，使用该母版版式的所有幻灯片都会显示该图片。这对于徽标、浮水印、装饰条以及其他重复的视觉元素非常有用。

下面的示例向第一张母版幻灯片添加徽标：

```java
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

## **使用占位符**

占位符通常在版式幻灯片上定义。母版提供共享的样式和主题，版式继承这些设置，同时每个版式决定哪些占位符可用以及它们的位置。

在 PowerPoint 中，占位符命令位于幻灯片母版视图中。

![PowerPoint 幻灯片母版视图中的“插入占位符”命令](slide-master_5.png)

使用 Aspose.Slides 向母版添加新占位符时，需要操作属于该母版的版式幻灯片：

```java
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

也可以对已经存在于母版上的占位符形状进行格式化。下面的示例查找标题占位符并应用线性渐变填充：

```java
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![普通幻灯片继承的已格式化标题占位符](slide-master_8.png)

有关占位符和文字格式化的更多选项，请参阅 [Set Prompt Text in Placeholder](/slides/zh/java/manage-placeholder/) 和 [Text Formatting](/slides/zh/java/text-formatting/)。

## **更改幻灯片母版背景**

母版背景会被版式和未覆盖该背景的幻灯片继承。下面的示例为第一张母版幻灯片设置纯色背景：

```java
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

相关主题请参阅 [Presentation Background](/slides/zh/java/presentation-background/) 和 [Presentation Theme](/slides/zh/java/presentation-theme/)。

## **将幻灯片母版克隆到另一个演示文稿**

使用 [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) 可将母版幻灯片复制到另一份演示文稿中。复制后的母版可供目标演示文稿中的版式和幻灯片使用。

```java
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

一个演示文稿可以包含多个母版幻灯片。当不同章节需要不同的品牌、页面结构或主题设置时，这非常有用。

![PowerPoint 插入和管理母版幻灯片的命令](slide-master_9.jpg)

下面的示例克隆默认母版，为克隆母版设置不同的背景，在该克隆母版下创建版式，并基于该版式添加新幻灯片：

```java
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

可以使用从 [IBaseSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseslide/) 继承的 `equals` 方法比较母版幻灯片。比较检查结构和静态内容，如形状、文字、格式、动画以及其他幻灯片设置。它不比较唯一标识符（如幻灯片 ID）或动态占位符值（如当前日期）。

```java
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

在 [ViewProperties](https://reference.aspose.com/slides/zh/java/com.aspose.slides/viewproperties/) 上使用 `setLastView` 方法可控制 PowerPoint 首次打开的视图。下面的示例在幻灯片母版视图中打开演示文稿：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

有关更多视图设置，请参阅 [Save Presentation](/slides/zh/java/save-presentation/)。

## **移除未使用的母版幻灯片**

演示文稿有时会包含不再被任何普通幻灯片使用的母版幻灯片。移除未使用的母版可以减小文件大小并简化模板维护。

使用 `removeUnused` 可从 `getMasters()` 集合中移除未使用的母版：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

也可以使用低代码的 [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 方法：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题解答**

**幻灯片母版和版式幻灯片有什么区别？**

幻灯片母版定义共享的设计设置，如主题、背景、通用形状和文字样式。版式幻灯片属于某个母版，定义占位符的具体排列。普通幻灯片使用版式幻灯片，因此同时继承版式和母版的设置。

**一个演示文稿可以包含多个幻灯片母版吗？**

可以。演示文稿可以包含多个母版幻灯片。当不同章节需要不同的视觉体系或品牌时，请使用多个母版。

**应该在母版幻灯片还是版式幻灯片上添加占位符？**

大多数情况下，将占位符添加到版式幻灯片上。将共享的视觉元素和共享格式放在母版上，然后在普通幻灯片使用的版式上放置内容占位符。

**我可以删除仍在使用的母版幻灯片吗？**

不能。仍有依赖幻灯片的母版无法直接安全删除。请先将这些幻灯片移动到其他母版的版式下，或使用仅删除未使用母版的清理方法。