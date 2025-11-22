---
title: 演示文稿查看器
type: docs
weight: 50
url: /zh/nodejs-java/presentation-viewer/
keywords:
- 查看演示文稿
- 演示文稿查看器
- 查看 PPT
- 查看 PPTX
- 查看 ODP
- PowerPoint
- OpenDocument
- Node.js
- Java
- Aspose.Slides for Node.js via Java
description: "JavaScript 中的 PowerPoint 演示文稿查看器"
---

Aspose.Slides for Node.js via Java 用于创建包含幻灯片的演示文稿文件。这些幻灯片可以通过在 Microsoft PowerPoint 等程序中打开演示文稿来查看。然而，有时开发人员可能需要在自己喜欢的图像查看器中查看幻灯片，或创建自己的演示文稿查看器。在这种情况下，Aspose.Slides 允许将单个幻灯片导出为图像。本文介绍了如何实现此操作。

## **从幻灯片生成 SVG 图像**

要使用 Aspose.Slides 从演示文稿幻灯片生成 SVG 图像，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片引用。
1. 打开文件流。
1. 将幻灯片保存为 SVG 图像到文件流中。
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **生成具有自定义形状 ID 的 SVG**

Aspose.Slides 可用于从幻灯片生成具有自定义形状 ID 的 [SVG](https://docs.fileformat.com/page-description-language/svg/)。为此，请使用来自 [SvgShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/) 的 `setId` 方法。`CustomSvgShapeFormattingController` 可用于设置形状 ID。
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```


## **创建幻灯片缩略图**

Aspose.Slides 帮助您生成幻灯片的缩略图。要使用 Aspose.Slides 生成幻灯片的缩略图，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片引用。
1. 按定义的比例获取引用幻灯片的缩略图。
1. 以任意所需的图像格式保存缩略图。
```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **使用用户自定义尺寸创建幻灯片缩略图**

要使用用户自定义尺寸创建幻灯片缩略图，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片引用。
1. 使用定义的尺寸获取引用幻灯片的缩略图。
1. 以任意所需的图像格式保存缩略图。
```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **使用演讲者备注创建幻灯片缩略图**

要使用 Aspose.Slides 生成带有演讲者备注的幻灯片缩略图，请按照以下步骤操作：

1. 创建 [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) 类的实例。
1. 使用 `RenderingOptions.setSlidesLayoutOptions` 方法设置演讲者备注的位置。
1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 按索引获取幻灯片引用。
1. 使用渲染选项获取引用幻灯片的缩略图。
1. 以任意所需的图像格式保存缩略图。
```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **实时示例**

您可以尝试使用免费应用 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) 来了解使用 Aspose.Slides API 可以实现的功能：

![在线 PowerPoint 查看器](online-PowerPoint-viewer.png)

## **常见问题**

**我可以在 Node.js Web 应用程序中嵌入演示文稿查看器吗？**

是的。您可以在服务器端使用 Aspose.Slides 将幻灯片渲染为图像或 HTML，并在浏览器中显示。可以使用 JavaScript 实现导航和缩放功能，以提供交互式体验。

**在自定义查看器中显示幻灯片的最佳方式是什么？**

推荐的方法是使用 Aspose.Slides 将每张幻灯片渲染为图像（例如 PNG 或 SVG）或转换为 HTML，然后将输出显示在图片框（桌面）或 HTML 容器（Web）中。

**如何处理包含大量幻灯片的大型演示文稿？**

对于大型演示文稿，建议采用懒加载或按需渲染幻灯片的方式。这意味着仅在用户导航到某张幻灯片时才生成其内容，从而减少内存占用和加载时间。