---
title: 在 PHP 中创建演示文稿查看器
linktitle: 演示文稿查看器
type: docs
weight: 50
url: /zh/php-java/presentation-viewer/
keywords:
- 查看演示文稿
- 演示文稿查看器
- 创建演示文稿查看器
- 查看 PPT
- 查看 PPTX
- 查看 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 创建自定义演示文稿查看器。无需 Microsoft PowerPoint，即可轻松显示 PowerPoint 和 OpenDocument 文件。"
---

Aspose.Slides for PHP via Java 用于创建包含幻灯片的演示文稿文件。这些幻灯片可以通过在 Microsoft PowerPoint 等程序中打开演示文稿来查看。然而，有时开发人员可能需要在自己喜欢的图像查看器中将幻灯片以图像形式查看，或创建自己的演示文稿查看器。在这种情况下，Aspose.Slides 允许您将单个幻灯片导出为图像。本文介绍了具体操作方法。

## **从幻灯片生成 SVG 图像**

要使用 Aspose.Slides 从演示文稿幻灯片生成 SVG 图像，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片引用。  
1. 打开文件流。  
1. 将幻灯片以 SVG 图像保存到文件流。  
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```


## **使用自定义形状 ID 生成 SVG**

Aspose.Slides 可用于使用自定义形状 ID 从幻灯片生成 [SVG](https://docs.fileformat.com/page-description-language/svg/)。为此，请使用来自 [SvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/) 的 `setId` 方法。`CustomSvgShapeFormattingController` 可用于设置形状 ID。  
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
  
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```


## **创建幻灯片缩略图**

Aspose.Slides 帮助您生成幻灯片的缩略图。要使用 Aspose.Slides 生成幻灯片的缩略图，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片引用。  
1. 以定义的比例获取所引用幻灯片的缩略图。  
1. 以任意所需的图像格式保存缩略图。  
```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **使用用户定义尺寸创建幻灯片缩略图**

要使用用户定义的尺寸创建幻灯片缩略图，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片引用。  
1. 使用定义的尺寸获取所引用幻灯片的缩略图。  
1. 以任意所需的图像格式保存缩略图。  
```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **使用讲稿创建幻灯片缩略图**

要使用 Aspose.Slides 生成带有讲稿的幻灯片缩略图，请按照以下步骤操作：

1. 创建 [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) 类的实例。  
1. 使用 `RenderingOptions.setSlidesLayoutOptions` 方法设置讲稿位置。  
1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例。  
1. 按索引获取幻灯片引用。  
1. 使用渲染选项获取所引用幻灯片的缩略图。  
1. 以任意所需的图像格式保存缩略图。  
```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```


## **实时示例**

您可以尝试免费使用 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) 应用程序，了解使用 Aspose.Slides API 可以实现的功能：

![在线 PowerPoint 查看器](online-PowerPoint-viewer.png)

## **常见问题**

**我可以在网页应用程序中嵌入演示文稿查看器吗？**

是的。您可以在服务器端使用 Aspose.Slides 将幻灯片渲染为图像或 HTML，并在浏览器中显示它们。可以使用 JavaScript 实现导航和缩放功能，以提供交互式体验。

**在自定义查看器中显示幻灯片的最佳方式是什么？**

推荐的做法是将每一张幻灯片渲染为图像（例如 PNG 或 SVG），或使用 Aspose.Slides 将其转换为 HTML，然后在图片框（桌面应用）或 HTML 容器（网页）中显示输出。

**如何处理包含大量幻灯片的大型演示文稿？**

对于大型演示文稿，建议采用懒加载或按需渲染幻灯片的方式。这意味着仅在用户导航到相应幻灯片时才生成其内容，从而降低内存占用和加载时间。