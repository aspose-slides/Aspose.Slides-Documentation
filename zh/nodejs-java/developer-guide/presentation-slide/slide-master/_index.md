---
title: 在 JavaScript 中管理演示文稿幻灯片母版
linktitle: 幻灯片母版
type: docs
weight: 70
url: /zh/nodejs-java/slide-master/
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
- 重复母版幻灯片
- 未使用的母版幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js via Java 中管理幻灯片母版：访问、编辑、克隆、比较并删除 PowerPoint 和 OpenDocument 演示文稿中的母版幻灯片。"
---
## **概述**

**幻灯片母版** 定义了一组幻灯片的共享设计设置。它可以包含通用形状、徽标、背景、文字样式、主题设置和页脚设置。在 PowerPoint 中，编辑幻灯片母版是保持演示文稿一致性的常用方式，无需在每张幻灯片上重复相同的格式。

Aspose.Slides for Node.js via Java 支持相同的模型。一个演示文稿可以包含一个或多个母版幻灯片，每个母版幻灯片可以包含若干版式幻灯片。普通幻灯片通常不会直接引用母版幻灯片，而是使用版式幻灯片，而该版式幻灯片属于某个母版幻灯片。

层级结构为：

1. **幻灯片母版** – 定义共享的设计和主题。  
1. **版式幻灯片** – 定义占位符的具体排列以及版式级别的格式。  
1. **普通幻灯片** – 包含实际的演示内容并使用一个版式幻灯片。

![母版幻灯片、版式幻灯片和普通幻灯片的层级结构](slide-master_2.jpg)

在 Aspose.Slides 中，幻灯片母版由 [MasterSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslide/) 类表示。演示文稿中的所有母版幻灯片可以通过 `Presentation.getMasters()` 集合获取。

{{% alert color="info" title="Inheritance" %}}

当同一属性在多个层级上定义时，层级更具体的会覆盖更上层的。例如，如果母版幻灯片和版式幻灯片都定义了背景，则基于该版式的幻灯片使用版式背景。有关版式幻灯片的更多信息，请参阅 [Apply or Change Slide Layouts](/nodejs-java/slide-layout/)。

{{% /alert %}}

## **访问幻灯片母版**

在 PowerPoint 中，可以通过 **视图** > **幻灯片母版** 打开幻灯片母版视图。

![PowerPoint “视图”选项卡上的幻灯片母版命令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters()` 集合访问母版幻灯片：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

也可以通过普通幻灯片的版式获取其使用的母版幻灯片：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **幻灯片母版包含的内容**

母版幻灯片是类似幻灯片的对象。它从 [BaseSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslide/) 继承通用幻灯片行为，因此公开了许多普通幻灯片和版式幻灯片使用的相同属性。母版专有成员列在 [MasterSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslide/) API 页面。

常用的母版幻灯片成员包括：

| 成员 | 用途 |
| --- | --- |
| `getBackground()` | 设置母版级别的幻灯片背景。 |
| `getShapes()` | 存储放置在母版上的形状，例如徽标、图片框和共享文字。 |
| `getLayoutSlides()` | 存储属于该母版的版式幻灯片。 |
| `getThemeManager()` | 提供对母版主题 API 的访问。 |
| `getHeaderFooterManager()` | 控制母版及其子版式的页眉、页脚、日期和页码。 |
| `getDependingSlides()` | 返回通过版式依赖于该母版的普通幻灯片。 |

## **向幻灯片母版添加图片**

向母版幻灯片添加图片后，使用该母版版式的所有幻灯片都会显示该图片。这对徽标、水印、装饰条以及其他重复的视觉元素非常有用。

下面的示例向第一张母版幻灯片添加徽标：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

有关图片框的更多信息，请参阅 [Picture Frame](/nodejs-java/picture-frame/)。

## **使用占位符**

占位符通常在版式幻灯片上定义。母版幻灯片提供共享的样式和主题，版式幻灯片继承这些样式，而每个版式决定哪些占位符可用以及它们的位置。

在 PowerPoint 中，占位符命令可在幻灯片母版视图中使用。

![PowerPoint 幻灯片母版视图中的“插入占位符”命令](slide-master_5.png)

要在 Aspose.Slides 中添加新的占位符，请操作属于母版的版式幻灯片：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

也可以格式化已存在于母版上的占位符形状。下面的示例查找标题占位符并应用线性渐变填充：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![普通幻灯片继承的已格式化标题占位符](slide-master_8.png)

有关占位符和文本格式的更多选项，请参阅 [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) 和 [Text Formatting](/nodejs-java/text-formatting/)。

## **更改幻灯片母版背景**

母版背景会被版式和未覆盖它的幻灯片继承。下面的示例为第一张母版幻灯片设置纯色背景：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

相关主题请参阅 [Presentation Background](/nodejs-java/presentation-background/) 和 [Presentation Theme](/nodejs-java/presentation-theme/)。

## **将幻灯片母版克隆到另一演示文稿**

使用 `MasterSlideCollection.addClone` 可将母版幻灯片复制到另一演示文稿中。复制后的母版随后可被目标演示文稿中的版式和幻灯片使用。

```javascript
let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

如果需要连同母版一起克隆普通幻灯片，请参阅 [Clone Slides](/nodejs-java/clone-slides/)。

## **添加多个幻灯片母版**

一个演示文稿可以包含多个母版幻灯片。当不同章节需要不同的品牌、页面结构或主题设置时，这非常有用。

![PowerPoint 中插入和管理母版幻灯片的命令](slide-master_9.jpg)

下面的示例克隆默认母版，为克隆副本设置不同的背景，在该克隆母版下创建版式，并基于该版式添加新幻灯片：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **比较幻灯片母版**

母版幻灯片可以使用从 [BaseSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslide/) 继承的 `equals` 方法进行比较。比较检查结构和静态内容，如形状、文本、格式、动画以及其他幻灯片设置。它不比较唯一标识符（例如幻灯片 ID）或动态占位符值（例如当前日期）。

```javascript
let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

更多信息请参阅 [Compare Presentation Slides](/nodejs-java/compare-slides/)。

## **将幻灯片母版视图设为默认视图**

在 [ViewProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewproperties/) 上使用 `setLastView` 方法可控制 PowerPoint 首次打开的视图。下面的示例在幻灯片母版视图中打开演示文稿：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

有关更多视图设置，请参阅 [Save Presentation](/nodejs-java/save-presentation/)。

## **删除未使用的母版幻灯片**

有时演示文稿会包含已不再被任何普通幻灯片使用的母版幻灯片。删除未使用的母版可以减小文件大小并简化模板维护。

使用 `removeUnused` 从 `getMasters()` 集合中删除未使用的母版：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

也可以使用低代码的 `Compress.removeUnusedMasterSlides` 方法：

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问答**

**幻灯片母版和版式幻灯片有什么区别？**

幻灯片母版定义共享的设计设置，如主题、背景、通用形状和文字样式。版式幻灯片属于某个母版，定义占位符的具体排列。普通幻灯片使用版式幻灯片，从而同时继承版式和母版的设置。

**一个演示文稿可以包含多个幻灯片母版吗？**

可以。演示文稿可以包含多个母版。当不同章节需要不同的视觉系统或品牌时，请使用多个母版。

**应该在母版幻灯片还是版式幻灯片上添加占位符？**

大多数情况下，在版式幻灯片上添加占位符。将共享的视觉元素和共享格式放在母版上，然后在普通幻灯片使用的版式上放置内容占位符。

**我可以删除仍在使用的母版幻灯片吗？**

不能。仍有依赖幻灯片的母版不能直接安全删除。请先将这些幻灯片移动到其他母版的版式下，或使用仅删除未使用母版的清理方法。