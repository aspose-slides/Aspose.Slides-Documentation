---
title: 在 JavaScript 中管理演示文稿占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh/nodejs-java/manage-placeholder/
keywords:
- 占位符
- 文本占位符
- 图片占位符
- 图表占位符
- 内容占位符
- 提示文本
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何检查和编辑文本、图片、图表和内容占位符，并使用 Aspose.Slides for Node.js（通过 Java）理解占位符继承。"
---
## **概述**

占位符是一种形状，用于在演示文稿模板中为特定类型的内容保留位置。常见示例包括标题、正文、图片、图表以及通用内容占位符。与普通形状不同，占位符可以从版式幻灯片或母版幻灯片继承其位置、大小、格式以及其他设置。

Aspose.Slides 通过 [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) 方法公开占位符信息。该方法返回一个 [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) 对象，普通形状则返回 `null`。使用 [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) 来确定占位符预期包含的内容。

了解占位符类型后，形状类仍然很重要：

- 空的文本、图片、图表或内容占位符通常由 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) 表示。
- 已填充的图片占位符可以用 [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) 表示。
- 已填充的图表占位符可以用 [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) 表示。
- 内容占位符可以包含多种内容。请同时检查 [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) 和运行时形状类，而不要假设每个占位符都是 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)。

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) 描述了占位符的作用；它并不能保证形状的运行时类型。在访问文本、图片、图表、表格或媒体特定成员之前，请始终进行类型检查。
{{% /alert %}}

## **了解占位符继承**

占位符形成层次结构：

1. 母版幻灯片定义可重用的样式，并在某些情况下定义母版级别的占位符。
2. 版式幻灯片定义一个或多个普通幻灯片使用的布局，并且可以继承自母版。
3. 普通幻灯片包含该幻灯片的占位符，并且可以继承其版式。

调用 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 可在此层次结构中向上移动一级。幻灯片占位符通常返回其版式占位符；版式占位符可以返回其母版占位符。当形状没有基础占位符时，方法返回 `null`。

以下示例列出第一张幻灯片上的占位符并报告它们的基础占位符：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

在普通幻灯片上编辑占位符会为该幻灯片创建或更改本地覆盖。编辑相关的版式或母版可以影响仍然继承该设置的所有幻灯片。本地普通形状没有基础占位符，仅因占据相同坐标而不会开始继承。

## **移除占位符状态**

在适配模板时，使用 [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) 可将现有对象保持为普通形状。其 [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) 方法返回 `null`，但形状仍保留在幻灯片的集合中。相对地， [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) 会从该集合中删除形状。

以下示例要求 `template.pptx` 至少包含一张幻灯片，并且第一张幻灯片上有非空的文本占位符。使用从其版式或母版继承格式的占位符，以观察移除该关系的效果。示例检查同一形状仍然存在，再次对现在的普通形状调用该方法，并保存结果。

{{% alert color="warning" title="Warning" %}}
移除占位符状态不会自动保留继承的外观设置。下例刻意保持这些设置不变，因此输出可能看起来不同。完全继承位置和大小的形状在调用后可能会出现坐标和尺寸为零，从而在集合中仍然存在但不可见。
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // 对普通形状调用此方法没有任何效果。
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

对于匹配的占位符，所有三项检查都会打印 `true`。文本保持不变，但在移除占位符关系后，继承的位置信息、大小、旋转、字体、段落对齐、文本框边距、垂直锚点、填充和线条设置可能会改变。例如，继承的标题格式可能会回退为普通文本格式。有关版式的更多信息，请参阅 [Slide Layout](/slides/zh/nodejs-java/slide-layout/)。

要保留预期外观，请在调用前捕获已解析的位置、大小和旋转，并将所需的有效格式值复制到单独的变量中。通过 [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective)、[ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective)、[TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective)、[FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) 和 [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective) 检索这些值。不要仅依赖有效格式对象，因为在关系被移除后，它们的文本格式值可能会改变。随后显式将捕获的值应用于普通形状，包括字体族、大小、样式、颜色、段落设置、文本框设置、填充和线条等模板使用的属性。

继承的形状几何也可能需要通过 [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType) 明确设置。对于矩形文本占位符，这意味着分配 [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle)；仅恢复填充和线条可能无法恢复可见的矩形。带有额外效果或更复杂格式的模板也需要相应处理这些设置。

## **更改占位符中的文本**

标题、居中标题、副标题、正文和文本占位符通常支持文本。在使用其 [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) 方法之前，请检查是否为 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)。

此示例更新第一张幻灯片上的第一个标题占位符并保存结果：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此模式避免将图片、图表、表格或媒体占位符当作 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) 对象处理。它还通过用途而不是依赖脆弱的形状索引来识别占位符。

## **在版式上设置提示文本**

提示文本是显示在空占位符中的设计时说明，例如 *Click to add title*。应在版式占位符上设置自定义提示文本，而不是尝试通过普通幻灯片的形状集合访问它。通过 [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) 访问版式，并遍历 [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) 返回的集合。

以下示例更改第一张幻灯片使用的版式上的标题和副标题提示：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

提示文本不是普通幻灯片内容。它旨在供 PowerPoint 等编辑应用程序在空占位符中显示。一旦用户或程序提供了真实内容，提示将不再显示。更改提示也不会替换使用该版式的幻灯片上已有的文本。

## **更新图片占位符**

需要处理两种情况：

- 如果图片占位符已经被填充并由 [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) 表示，使用 [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat)、[PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) 和 [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage) 替换图像。
- 如果仍是空占位符，使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) 在占位符坐标处添加图片框，并删除空占位符。

下面的示例同时支持这两种情况并保存演示文稿：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

为一个空占位符创建的替代对象是本地图片框，而不是新占位符，因为 [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) 没有提供设置器。它保留了预留位置，但不再继承占位符特定行为。如果保持占位符关系至关重要，请先在 PowerPoint 中准备并填充占位符，然后使用 Aspose.Slides 更新生成的 [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)。

有关图像透明度、裁剪和其他图片专用效果，请参阅 [Manage Picture Frames](/slides/zh/nodejs-java/picture-frame/)。这些操作属于图片框或图片填充，而不是占位符元数据。

## **使用图表和内容占位符**

已填充的图表占位符可以用 [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) 表示。以下示例通过占位符类型和运行时类同时定位此类图表，修改其标题并保存文件：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

一般内容占位符通常具有 [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object)。在 PowerPoint 中，它充当多个内容类型的启动器，包括图表、表格、图示、图片和媒体。填充后，请检查实际的形状类以了解其包含的内容。专用版式也可能公开 [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart)、[PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table)、[PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture)、[PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) 或 [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram)。

Aspose.Slides 并不会仅通过更改 [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) 将空的 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) 占位符转换为 [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/)；类型无法通过对象进行更改。若要以编程方式填充空图表或内容区域，请在占位符坐标处添加所需对象，然后删除空占位符。以下示例对图表执行此操作：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

添加的图表是普通本地图表。它占据占位符的区域，但不继承自版式占位符。需要替换其类别、系列或工作簿数据时，请使用专门的 [chart management articles](/slides/zh/nodejs-java/powerpoint-charts/)。

## **完整示例：更新文本或图像内容**

以下端到端示例打开模板，搜索第一张幻灯片上的标题或图片占位符，检查占位符和形状类型，更新相应内容并保存输出。示例刻意避免假设形状索引或将每个占位符视为相同类。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**什么是基础占位符？**

基础占位符是版式或母版上对应的形状，其他占位符从该形状继承。使用 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 获取它。普通本地形状返回 `null`，因为它不属于占位符层级。

**我可以通过编辑版式占位符来更改所有幻灯片的标题吗？**

可以通过版式更改继承的格式或提示文本，但实际的标题内容存储在普通幻灯片上。若要在整个演示文稿中替换真实的标题文本，需要遍历幻灯片并更新每个标题占位符。

**如何管理日期、页码、页眉和页脚占位符？**

在相应的幻灯片、版式、母版、备注或讲义范围内使用页眉页脚管理器。请参阅 [Manage Presentation Header and Footer](/slides/zh/nodejs-java/presentation-header-and-footer/) 获取完整示例。