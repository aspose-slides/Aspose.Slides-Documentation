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
description: "在 Aspose.Slides for Node.js via Java 中管理幻灯片母版：访问、编辑、克隆、比较和删除 PowerPoint 与 OpenDocument 演示文稿中的母版幻灯片。"
---
## **概述**

**幻灯片母版**定义了一组幻灯片的共享设计设置。它可以包含通用形状、徽标、背景、文本样式、主题设置和页脚设置。在 PowerPoint 中，编辑幻灯片母版是保持演示文稿一致性的常用方式，无需在每张幻灯片上重复相同的格式。

Aspose.Slides for Node.js via Java 支持相同的模型。一个演示文稿可以包含一个或多个母版幻灯片，每个母版幻灯片可以包含多个版式幻灯片。普通幻灯片通常不会直接引用母版幻灯片，而是使用版式幻灯片，而该版式幻灯片属于某个母版幻灯片。

层次结构如下：

1. **Slide master** - 定义共享的设计和主题。  
2. **Layout slide** - 定义占位符的具体排列以及版式级别的格式。  
3. **Normal slide** - 包含实际的演示内容并使用一个版式幻灯片。

![母版幻灯片、版式幻灯片和普通幻灯片的层次结构](slide-master_2.jpg)

在 Aspose.Slides 中，幻灯片母版由 [MasterSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslide/) 类表示。演示文稿中的所有母版幻灯片可通过 `Presentation.getMasters()` 集合获取。

{{% alert color="info" title="Inheritance" %}}
当同一属性在多个层级上定义时，层级更具体的会覆盖更通用的。例如，如果母版幻灯片和版式幻灯片都定义了背景，则基于该版式的幻灯片使用版式背景。有关版式幻灯片的更多信息，请参阅 [Apply or Change Slide Layouts](/nodejs-java/slide-layout/)。
{{% /alert %}}

## **访问幻灯片母版**

在 PowerPoint 中，您可以通过 **视图** > **幻灯片母版** 打开幻灯片母版视图。

![PowerPoint“视图”选项卡上的幻灯片母版命令](slide-master_3.jpg)

在 Aspose.Slides 中，使用 `getMasters()` 集合访问母版幻灯片：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

您还可以通过普通幻灯片的版式获取其使用的母版幻灯片：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

母版幻灯片是类似幻灯片的对象。它从 [BaseSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslide/) 继承通用幻灯片行为，因此暴露了许多普通幻灯片和版式幻灯片使用的相同属性。特定于母版的成员列在 [MasterSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslide/) API 页面上。

常用的母版幻灯片成员包括：

| 成员 | 用途 |
| --- | --- |
| `getBackground()` | 设置母版级别的幻灯片背景。 |
| `getShapes()` | 存储放置在母版上的形状，如徽标、图片框和共享文本。 |
| `getLayoutSlides()` | 存储属于该母版的版式幻灯片。 |
| `getThemeManager()` | 提供对母版主题 API 的访问。 |
| `getHeaderFooterManager()` | 控制母版及其子版式的页眉、页脚、日期和幻灯片编号。 |
| `getDependingSlides()` | 返回通过其版式依赖于该母版的普通幻灯片。 |

## **向幻灯片母版添加图像**

向母版幻灯片添加图像后，使用该母版的版式的幻灯片都会显示该图像。这对于徽标、水印、装饰条以及其他重复的视觉元素非常有用。

以下示例向第一张母版幻灯片添加徽标：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **控制母版图形的可见性**

使用 [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) 可以隐藏继承自母版的图形（如徽标或装饰形状），而无需从母版中删除它们。对需要省略这些图形的幻灯片调用 [Slide.setShowMasterShapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#setShowMasterShapes) 并传入 `false`，在需要显示的幻灯片上保持 `true`。

以下自包含示例在母版上创建一个蓝色装饰条，并在两个使用相同空白版式的幻灯片上展示：第一张幻灯片可见，第二张隐藏。无需输入演示文稿或图像。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

该示例使用新演示文稿自带的 **Blank** 版式，并移除初始幻灯片自身的占位符。

### **选择设置的作用范围**

普通幻灯片通过 [Slide.getLayoutSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#getLayoutSlide) 和 [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslide/#getMasterSlide) 使用其母版。对单个幻灯片设置属性只影响该幻灯片。对 [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) 传入 `false` 会隐藏使用该共享版式的所有幻灯片的母版图形，即使它们各自的设置为 `true`。若仅想在一张幻灯片上隐藏图形，请更改该幻灯片的属性，而保持共享版式不变。

此设置不支持在母版本身上作为可见性控制。对母版调用 [getShowMasterShapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) 始终返回 `false`，而对 [setShowMasterShapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) 传入 `true` 会抛出异常。请在普通幻灯片或版式上使用该功能。

### **区分图形与背景**

| 操作 | 影响 |
| --- | --- |
| 隐藏母版图形 | 在不删除或更改幻灯片自身形状的前提下控制继承的母版形状的可见性。 |
| 更改幻灯片背景填充 | 更改背景颜色、渐变或图像。母版图形是独立的形状，可保持在该背景之上可见。参见 [Presentation Background](/slides/zh/nodejs-java/presentation-background/)。 |
| 删除母版上的形状 | 移除共享源形状，导致使用该母版的任何幻灯片都不再拥有该形状。 |

## **使用占位符**

占位符通常在版式幻灯片上定义。母版提供共享的样式和主题，版式继承这些设置，同时决定哪些占位符可用以及它们的位置。

在 PowerPoint 中，占位符命令位于幻灯片母版视图中。

![PowerPoint 幻灯片母版视图中的“插入占位符”命令](slide-master_5.png)

要使用 Aspose.Slides 添加新占位符，请操作属于母版的版式幻灯片：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

您也可以格式化母版幻灯片上已存在的占位符形状。以下示例查找标题占位符并应用线性渐变填充：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![继承自母版的已格式化标题占位符在普通幻灯片中显示](slide-master_8.png)

有关占位符和文本格式的更多选项，请参阅 [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) 和 [Text Formatting](/nodejs-java/text-formatting/)。

## **更改幻灯片母版背景**

母版背景会被版式和未覆盖该背景的幻灯片继承。以下示例为第一张母版幻灯片设置纯色背景：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **将幻灯片母版克隆到其他演示文稿**

使用 `MasterSlideCollection.addClone` 可将母版幻灯片复制到另一个演示文稿中。复制后的母版随后可供目标演示文稿中的版式和幻灯片使用。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

![PowerPoint 插入和管理母版幻灯片的命令](slide-master_9.jpg)

以下示例克隆默认母版，为克隆设置不同的背景，在该克隆母版下创建版式，并基于该版式添加新幻灯片：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

母版幻灯片可以使用从 [BaseSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslide/) 继承的 `equals` 方法进行比较。比较检查结构和静态内容，如形状、文本、格式、动画以及其他幻灯片设置；不比较唯一标识符（如幻灯片 ID）或动态占位符值（如当前日期）。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

更多信息请参阅 [Compare Presentation Slides](/slides/zh/nodejs-java/compare-slides/)。

## **将幻灯片母版视图设为默认视图**

在 [ViewProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewproperties/) 上使用 `setLastView` 方法可控制 PowerPoint 首次打开的视图。以下示例在幻灯片母版视图中打开演示文稿：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

更多视图设置请参阅 [Save Presentation](/slides/zh/nodejs-java/save-presentation/)。

## **删除未使用的母版幻灯片**

演示文稿有时会包含不再被任何普通幻灯片使用的母版幻灯片。删除未使用的母版可以减小文件大小并简化模板维护。

使用 `removeUnused` 从 `getMasters()` 集合中删除未使用的母版：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

您也可以使用低代码的 `Compress.removeUnusedMasterSlides` 方法：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题解答**

**幻灯片母版和版式幻灯片有什么区别？**  
幻灯片母版定义共享的设计设置，如主题、背景、通用形状和文本样式。版式幻灯片属于某个母版，定义占位符的具体排列。普通幻灯片使用版式幻灯片，因此同时继承版式和母版的设置。

**一个演示文稿可以包含多个幻灯片母版吗？**  
可以。一个演示文稿可以包含多个幻灯片母版。在不同章节需要不同视觉体系或品牌时，请使用多个母版。

**应该在母版幻灯片还是版式幻灯片上添加占位符？**  
大多数情况下，应在版式幻灯片上添加占位符。将共享的视觉元素和共享格式放在母版上，然后在普通幻灯片使用的版式上放置内容占位符。

**我可以删除仍在使用的母版幻灯片吗？**  
不能。仍有依赖幻灯片的母版不能直接安全删除。请先将这些幻灯片移动到另一个母版的版式下，或使用仅删除未使用母版的清理方法。