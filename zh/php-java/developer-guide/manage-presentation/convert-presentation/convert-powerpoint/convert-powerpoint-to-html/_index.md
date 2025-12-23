---
title: 在 PHP 中将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/php-java/convert-powerpoint-to-html/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 HTML
- 演示文稿 转 HTML
- 幻灯片 转 HTML
- PPT 转 HTML
- PPTX 转 HTML
- 将 PowerPoint 保存为 HTML
- 将演示文稿保存为 HTML
- 将幻灯片保存为 HTML
- 将 PPT 保存为 HTML
- 将 PPTX 保存为 HTML
- 导出 PPT 为 HTML
- 导出 PPTX 为 HTML
- PHP
- Aspose.Slides
description: "在 PHP 中将 PowerPoint 演示文稿转换为响应式 HTML。使用 Aspose.Slides 转换指南，可保留布局、链接和图像，实现快速、完美的效果。"
---

## **概述**

本文介绍如何使用 PHP 将 PowerPoint 演示文稿转换为 HTML 格式。涵盖以下主题。

- 将 PowerPoint 转换为 HTML
- 将 PPT 转换为 HTML
- 将 PPTX 转换为 HTML
- 将 ODP 转换为 HTML
- 将 PowerPoint 幻灯片转换为 HTML

## **PowerPoint 转 HTML（PHP）**

有关将 PowerPoint 转换为 HTML 的 Java 示例代码，请参阅下面的章节，即[Convert PowerPoint to HTML](#convert-powerpoint-to-html)。该代码可以在 Presentation 对象中加载 PPT、PPTX 和 ODP 等多种格式，并将其保存为 HTML 格式。

## **关于 PowerPoint 转 HTML 转换**

使用[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/)，应用程序和开发者可以将 PowerPoint 演示文稿转换为 HTML：**PPTX 转 HTML** 或 **PPT 转 HTML**。

**Aspose.Slides** 提供了许多选项（主要来自[**HtmlOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions)类），用于定义 PowerPoint 到 HTML 的转换过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿媒体（图像、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。 
* 将 PowerPoint 演示文稿转换为包含或不包含备注的 HTML。 
* 将 PowerPoint 演示文稿转换为包含或不包含批注的 HTML。 
* 将 PowerPoint 演示文稿转换为使用原始字体或嵌入字体的 HTML。 
* 将 PowerPoint 演示文稿转换为使用新 CSS 样式的 HTML。 

{{% alert color="primary" %}} 

使用其自身 API，Aspose 开发了免费的[演示文稿转 HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)转换器： [PPT 转 HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX 转 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP 转 HTML](https://products.aspose.app/slides/conversion/odp-to-html) 等。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您可能还想查看其他[来自 Aspose 的免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

除了本文所述的转换过程，Aspose.Slides 还支持以下涉及 HTML 格式的转换操作： 

* [HTML 转图片](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}


## **将 PowerPoint 转换为 HTML**
使用 Aspose.Slides，您可以通过以下方式将整个 PowerPoint 演示文稿转换为 HTML：

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 使用[Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)方法将对象保存为 HTML 文件。

下面的代码示例演示了如何将 PowerPoint 转换为 HTML：
```php
// 实例化一个表示演示文稿文件的 Presentation 对象
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $htmlOpt = new HtmlOptions();
    $htmlOpt->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $htmlOpt->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false));
    # 将演示文稿保存为 HTML
    $pres->save("ConvertWholePresentationToHTML_out.html", SaveFormat::Html, $htmlOpt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **将 PowerPoint 转换为响应式 HTML**
Aspose.Slides 提供了[ResponsiveHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/ResponsiveHtmlController)类，允许生成响应式 HTML 文件。下面的代码示例演示了如何将 PowerPoint 演示文稿转换为响应式 HTML：
```php
// 实例化一个表示演示文稿文件的 Presentation 对象
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $controller = new ResponsiveHtmlController();
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    # 将演示文稿保存为 HTML
    $pres->save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, $htmlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **将 PowerPoint 转换为带备注的 HTML**
下面的代码示例演示了如何将 PowerPoint 转换为带备注的 HTML：
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $opt = new HtmlOptions();
    $options = $opt->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # 保存备注页面
    $pres->save("Output.html", SaveFormat::Html, $opt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **将 PowerPoint 转换为带原始字体的 HTML**

Aspose.Slides 提供了[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController)类，允许在将演示文稿转换为 HTML 时嵌入所有字体。

若要防止某些字体被嵌入，可向[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController)的带参数构造函数传递字体名称数组。常用字体（如 Calibri 或 Arial）在演示文稿中使用时无需嵌入，因为大多数系统已预装这些字体。嵌入这些字体会导致生成的 HTML 文档体积不必要地增大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController)类支持继承并提供[WriteFont](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-)方法，供子类重写。
```php
  $pres = new Presentation("input.pptx");
  try {
    # 排除默认演示文稿字体
    $fontNameExcludeList = array("Calibri", "Arial" );
    $embedFontsController = new EmbedAllFontsHtmlController($fontNameExcludeList);
    $htmlOptionsEmbed = new HtmlOptions();
    $htmlOptionsEmbed->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($embedFontsController));
    $pres->save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat::Html, $htmlOptionsEmbed);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **将 PowerPoint 转换为高质量图像的 HTML**

默认情况下，将 PowerPoint 转换为 HTML 时，Aspose.Slides 输出的 HTML 较小，图像分辨率为 72 DPI，且裁剪区域被删除。若要获取更高质量图像的 HTML 文件，需要将 `PicturesCompression`（来自 `HtmlOptions` 类）属性设置为 96（即 `PicturesCompression.Dpi96`）或更高的[值](https://reference.aspose.com/slides/php-java/aspose.slides/PicturesCompression)。

下面的 PHP 代码示例演示了如何在将 PowerPoint 演示文稿转换为 HTML 时获取 150 DPI 的高质量图像（即 `PicturesCompression.Dpi150`）：
```php
  $pres = new Presentation("InputDoc.pptx");
  try {
    $htmlOpts = new HtmlOptions();
    $htmlOpts->setPicturesCompression(PicturesCompression::Dpi150);
    $pres->save("OutputDoc-dpi150.html", SaveFormat::Html, $htmlOpts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


下面的代码示例演示了如何输出包含全质量图像的 HTML：
```php
  $pres = new Presentation("InputDoc.pptx");
  try {
    $htmlOpts = new HtmlOptions();
    $htmlOpts->setDeletePicturesCroppedAreas(false);
    $pres->save("Outputdoc-noCrop.html", SaveFormat::Html, $htmlOpts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **将幻灯片转换为 HTML**
要将 PowerPoint 中的特定幻灯片转换为 HTML，需要实例化与转换整个演示文稿相同的[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类，然后使用[Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)方法将文件保存为 HTML。可以使用[HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions)类来指定其他转换选项：

下面的 PHP 代码示例演示了如何将 PowerPoint 演示文稿中的幻灯片转换为 HTML：
```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;


class CustomFormattingController
{
    function writeDocumentStart($generator, $presentation) { }

    function writeDocumentEnd($generator, $presentation) { }

    function writeSlideStart($generator, $slide)
	{
        $generator->addHtml(sprintf(self::SlideHeader, $generator->getSlideIndex() + 1));
    }

    function writeSlideEnd($generator, $slide)
	{
        $generator->addHtml(self::SlideFooter);
    }

    function writeShapeStart($generator, $shape) { }

    function writeShapeEnd($generator, $shape) { }

    const SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide%d\">";
    const SlideFooter = "</div>";
}
  $pres = new Presentation("Individual-Slide.pptx");
  try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
	$formattingController= java_closure(new CustomFormattingController(), null, java("com.aspose.slides.IHtmlFormattingController"));
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($formattingController));
    # 保存文件
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $pres->save("Individual Slide" . ($i + 1) . "_out.html", array($i + 1 ), SaveFormat::Html, $htmlOptions);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **导出为 HTML 时保存 CSS 和图像**
使用新的 CSS 样式文件，您可以轻松更改 PowerPoint 转 HTML 过程生成的 HTML 文件的样式。

本示例中的 PHP 代码演示了如何使用可重写的方法创建带有 CSS 文件链接的自定义 HTML 文档：
```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;
use aspose\slides\EmbedAllFontsHtmlController;

class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController {
    const m_basePath = 0;

    # 自定义标题模板
    const Header = "<!DOCTYPE html>\n" .
            "<html>\n" .
            "<head>\n" .
            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" .
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" .
            "<link rel=\"stylesheet\" type=\"text/css\" href=\"%s\">\n" .
            "</head>";

    public $m_cssFileName;

    public function __construct($cssFileName)
    {
        parent::__construct();
		$this->m_cssFileName = $cssFileName;
	}

    public function writeDocumentStart($generator, $presentation)
    {
        $generator->addHtml(sprintf(self::Header, $m_cssFileName));
        $this->writeAllFonts($generator, $presentation);
    }

    public function writeAllFonts($generator, $presentation)
    {
        $generator->addHtml("<!-- Embedded fonts -->");
        parent::writeAllFonts($generator, $presentation);
    }
}

  $pres = new Presentation("pres.pptx");
  try {
    $options = new HtmlOptions();
    $options->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter(new CustomHeaderAndFontsController("styles.css")));
    $pres->save("pres.html", SaveFormat::Html, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **将演示文稿转换为 HTML 时链接所有字体**

如果不想嵌入字体（以避免增大生成的 HTML 大小），可以通过实现自己的 `LinkAllFontsHtmlController` 版本来链接所有字体。

下面的 PHP 代码示例演示了在链接所有字体且排除 “Calibri” 与 “Arial”（因为系统已存在）的情况下，将 PowerPoint 转换为 HTML：
```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;
use aspose\slides\EmbedAllFontsHtmlController;

class LinkAllFontsHtmlController extends EmbedAllFontsHtmlController
{
    private $m_basePath;

    public function __construct($fontNameExcludeList, $basePath)
    {
        parent::__construct($fontNameExcludeList);
        $this->m_basePath = $basePath;
    }

    function writeFont
    (
            $generator,
            $originalFont,
            $substitutedFont,
            $fontStyle,
            $fontWeight,
            $fontData)
    {
        try {
            $fontName = java_is_null($substitutedFont) ? $originalFont->getFontName() : $substitutedFont->getFontName();
            $path = $fontName . ".woff"; // 某些路径清理可能需要
			$fstr = new Java("java.io.FileOutputStream", $this->m_basePath . $path);
			$Array = new java_class("java.lang.reflect.Array");
			try {
				$fstr->write($fontData, 0, $Array->getLength($fontData));
			} finally {
				$fstr->close();
			}

            $generator->addHtml("<style>");
            $generator->addHtml("@font-face { ");
            $generator->addHtml("font-family: '" . $fontName . "'; ");
            $generator->addHtml("src: url('" . $path . "')");

            $generator->addHtml(" }");
            $generator->addHtml("</style>");
        } catch (JavaException $ex) {
        }
    }
}
    $pres = new Presentation("pres.pptx");
  try {
    # 排除默认演示文稿字体
	$fontNameExcludeList = array("Calibri", "Arial");
    $linkcont = new LinkAllFontsHtmlController($fontNameExcludeList, "C:/Windows/Fonts/");
    $htmlOptionsEmbed = new HtmlOptions();
    $htmlOptionsEmbed->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($linkcont));
    $pres->save("pres.html", SaveFormat::Html, $htmlOptionsEmbed);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **将 PowerPoint 转换为响应式 HTML**
下面的 PHP 代码示例演示了如何将 PowerPoint 演示文稿转换为响应式 HTML：
```php
  $pres = new Presentation("SomePresentation.pptx");
  try {
    $saveOptions = new HtmlOptions();
    $saveOptions->setSvgResponsiveLayout(true);
    $pres->save("SomePresentation-out.html", SaveFormat::Html, $saveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **导出媒体文件为 HTML**
使用 Aspose.Slides for PHP via Java，您可以按以下方式导出媒体文件：

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 获取对幻灯片的引用。
3. 向幻灯片添加视频。
4. 将演示文稿写入 HTML 文件。

下面的 PHP 代码示例演示了如何向演示文稿添加视频并将其保存为 HTML：
```php
// 加载演示文稿
  $pres = new Presentation();
  try {
    $path = "./out/";
    $fileName = "ExportMediaFiles_out.html";
    $baseUri = "http://www.example.com/";
    $file = new Java("java.io.File", "my_video.avi");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $videoData = $Array->newInstance($Byte, $Array->getLength($file));
    try {
        $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file));
        $dis->readFully($videoData);
    } finally {
        if (!java_is_null($dis)) $dis->close();
    }
    $video = $pres->getVideos()->addVideo($videoData);
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $controller = new VideoPlayerHtmlController($path, $fileName, $baseUri);
    # 设置 HTML 选项
    $htmlOptions = new HtmlOptions($controller);
    $svgOptions = new SVGOptions($controller);
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    $htmlOptions->setSlideImageFormat(SlideImageFormat::svg($svgOptions));
    # 保存文件
    $pres->save($fileName, SaveFormat::Html, $htmlOptions);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**Aspose.Slides 在将多个演示文稿转换为 HTML 时的性能如何？**

性能取决于演示文稿的大小和复杂程度。Aspose.Slides 在批量操作方面高效且可扩展。为在转换大量演示文稿时获得最佳性能，建议尽可能使用多线程或并行处理。

**Aspose.Slides 是否支持将超链接导出为 HTML？**

是的，Aspose.Slides 完全支持将嵌入的超链接导出为 HTML。将演示文稿转换为 HTML 格式时，超链接会自动保留并保持可点击。

**将演示文稿转换为 HTML 时，对幻灯片数量有任何限制吗？**

使用 Aspose.Slides 时对幻灯片数量没有限制。您可以转换任意大小的演示文稿。但对于包含极大量幻灯片的演示文稿，性能可能受服务器或系统可用资源的影响。