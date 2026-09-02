---
title: 管理 JavaScript 中的演示文稿占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh/nodejs-java/manage-placeholder/
keywords:
- 占位符
- 文本占位符
- 图像占位符
- 图表占位符
- 内容占位符
- 提示文本
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "学习如何检查和编辑文本、图片、图表和内容占位符，并使用 Aspose.Slides for Node.js via Java 了解占位符继承。"
---
## **概述**

占位符是一种形状，用于在演示文稿模板中为特定类型的内容保留位置。常见示例包括标题、正文、图片、图表以及通用内容占位符。与普通形状不同，占位符可以从布局幻灯片或母版幻灯片继承其位置、大小、格式以及其他设置。

Aspose.Slides 通过 [Shape.getPlaceholder](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getPlaceholder) 方法公开占位符信息。该方法返回 [Placeholder](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/placeholder/) 对象，普通形状则返回 `null`。使用 [Placeholder.getType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/placeholder/#getType) 可以确定占位符预期包含的内容。

了解占位符类型后，形状类仍然很重要：

- 空的文本、图片、图表或内容占位符通常由 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/) 表示。
- 已填充的图片占位符可以由 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 表示。
- 已填充的图表占位符可以由 [Chart](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/) 表示。
- 内容占位符可以包含多种类型的内容。请同时检查 [Placeholder.getType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/placeholder/#getType) 和运行时形状类，而不要假设每个占位符都是 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)。

{{% alert color="warning" title="警告" %}}
[Placeholder.getType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/placeholder/#getType) 描述了占位符的作用；它并不保证形状的运行时类型。访问文本、图片、图表、表格或媒体特定成员之前，请始终进行类型检查。
{{% /alert %}}

## **了解占位符继承**

占位符形成层级结构：

1. 母版幻灯片定义可重用的样式，并在某些情况下包含母版级别的占位符。
2. 布局幻灯片定义供一个或多个普通幻灯片使用的布局，并可以从母版继承。
3. 普通幻灯片包含该幻灯片的占位符，并可以从其布局继承。

调用 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 可向上移动一层层级。普通幻灯片的占位符通常返回其布局占位符；布局占位符可以返回其母版占位符。当形状没有基占位符时，该方法返回 `null`。

以下示例列出第一张幻灯片上的占位符并报告它们的基占位符：

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

编辑普通幻灯片上的占位符会为该幻灯片创建或修改本地覆盖。编辑相关的布局或母版则会影响仍然继承该设置的所有幻灯片。本地普通形状没有基占位符，仅因为占据相同坐标而不会开始继承。

## **在占位符中更改文本**

标题、居中标题、子标题、正文和文本占位符通常支持文本。使用前请检查是否为 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/)，再调用其 [getTextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/#getTextFrame) 方法。

下面的示例更新第一张幻灯片上的第一个标题占位符并保存结果：

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

此模式避免将图片、图表、表格或媒体占位符误当作 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/) 对象处理。它还通过占位符的用途来识别，而不是依赖脆弱的形状索引。

## **在布局上设置提示文本**

提示文本是在空占位符中显示的设计时说明，例如 *单击以添加标题*。请在布局占位符上设置自定义提示文本，而不是通过普通幻灯片的形状集合去获取。通过 [Slide.getLayoutSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#getLayoutSlide) 访问布局，并遍历 [BaseSlide.getShapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslide/#getShapes) 返回的集合。

以下示例更改第一张幻灯片使用的布局上的标题和副标题提示：

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

提示文本不是普通幻灯片的内容。它仅用于 PowerPoint 等编辑应用中的空占位符。用户或程序提供真实内容后，提示将不再显示。更改提示也不会替换使用该布局的幻灯片上已有的文本。

## **更新图片占位符**

需要处理两种情况：

- 如果图片占位符已填充且由 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/) 表示，请通过 [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/#getPictureFormat)、[PictureFillFormat.getPicture](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picturefillformat/#getPicture) 和 [Picture.setImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/picture/#setImage) 替换图像。
- 如果仍是空占位符，请使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) 在占位符坐标处添加图片框，并删除空占位符。

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

为一个空占位符创建的替代对象是本地图片框，而非新占位符，因为 [Shape.getPlaceholder](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getPlaceholder) 并未提供设置器。它保留了预留位置，但不再继承占位符特定行为。如果必须保留占位符关系，请先在 PowerPoint 中准备并填充占位符，然后使用 Aspose.Slides 更新生成的 [PictureFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pictureframe/)。

有关图像透明度、裁剪以及其他图片特定效果，请参阅 [管理图片框](/slides/zh/nodejs-java/picture-frame/)。这些操作属于图片框或图片填充，而不是占位符元数据。

## **处理图表和内容占位符**

已填充的图表占位符可以由 [Chart](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/) 表示。下面的示例通过占位符类型和运行时类同时定位此类图表，修改其标题并保存文件：

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

通用内容占位符通常具有 [PlaceholderType.Object](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/placeholdertype/#Object)。在 PowerPoint 中，它充当多种内容类型的启动器，包括图表、表格、图示、图片和媒体。填充后，请检查实际的形状类以了解其包含的内容。专用布局还可以公开 [PlaceholderType.Chart](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/placeholdertype/#Chart)、[PlaceholderType.Table](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/placeholdertype/#Table)、[PlaceholderType.Picture](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/placeholdertype/#Picture)、[PlaceholderType.Media](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/placeholdertype/#Media) 或 [PlaceholderType.Diagram](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/placeholdertype/#Diagram)。

Aspose.Slides 不会仅通过更改 [Placeholder.getType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/placeholder/#getType) 将空的 [AutoShape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/autoshape/) 占位符转换为 [Chart](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/)；此类型不能通过对象修改。要以编程方式填充空的图表或内容区域，请在占位符坐标处添加所需对象，然后删除空占位符。下面的示例演示了对图表的实现：

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

添加的图表是普通的本地图表。它占据占位符区域，但不继承布局占位符的属性。需要替换其类别、序列或工作簿数据时，请使用专门的 [图表管理文章](/slides/zh/nodejs-java/powerpoint-charts/)。

## **完整示例：更新文本或图像内容**

下面的端到端示例打开一个模板，在第一张幻灯片中搜索标题或图片占位符，检查占位符和形状类型，更新相应内容并保存输出。示例刻意避免假设形状索引或将每个占位符视为同一类。

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

## **常见问题解答**

**什么是基占位符？**

基占位符是布局或母版上对应的形状，其他占位符从其继承。使用 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 可检索它。普通本地形状返回 `null`，因为它不属于占位符层级。

**我可以通过编辑布局占位符来更改所有幻灯片的标题吗？**

可以通过布局更改继承的格式或提示文本，但现有的标题内容存储在普通幻灯片上。要替换整个演示文稿的实际标题文本，需要遍历幻灯片并更新每个标题占位符。

**如何管理日期、幻灯片编号、页眉和页脚占位符？**

在相应的幻灯片、布局、母版、备注页或讲义范围使用页眉页脚管理器。请参阅 [管理演示文稿页眉和页脚](/slides/zh/nodejs-java/presentation-header-and-footer/) 获取完整示例。