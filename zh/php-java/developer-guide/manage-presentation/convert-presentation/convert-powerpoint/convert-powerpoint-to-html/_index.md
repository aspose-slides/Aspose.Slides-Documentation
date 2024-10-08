---
title: 将 PowerPoint 转换为 HTML
linktitle: 将 PowerPoint 转换为 HTML
type: docs
weight: 30
url: /php-java/convert-powerpoint-to-html/
keywords: "PHP PowerPoint 转 HTML, 转换 PowerPoint 演示文稿, PPTX, PPT, PPT 转 HTML, PPTX 转 HTML, PowerPoint 转 HTML, 将 PowerPoint 保存为 HTML, 将 PPT 保存为 HTML, 将 PPTX 保存为 HTML, Java, Aspose.Slides, HTML 导出"
description: "将 PowerPoint 转换为 HTML: 将 PPTX 或 PPT 保存为 HTML。将幻灯片保存为 HTML"
---

## **概述**

本文解释了如何使用 PHP 将 PowerPoint 演示文稿转换为 HTML 格式。涵盖以下主题。

- 将 PowerPoint 转换为 HTML
- 将 PPT 转换为 HTML
- 将 PPTX 转换为 HTML
- 将 ODP 转换为 HTML
- 将 PowerPoint 幻灯片转换为 HTML

## **Java PowerPoint 转 HTML**

有关将 PowerPoint 转换为 HTML 的 Java 示例代码，请参见下面的部分，即 [将 PowerPoint 转换为 HTML](#convert-powerpoint-to-html)。该代码可以加载多个格式（如 PPT、PPTX 和 ODP）到 Presentation 对象中并保存为 HTML 格式。

## **关于 PowerPoint 转 HTML 转换**

使用 [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/)，应用程序和开发人员可以将 PowerPoint 演示文稿转换为 HTML: **PPTX 转 HTML** 或 **PPT 转 HTML**。

**Aspose.Slides** 提供了许多选项（主要来自 [**HtmlOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions) 类），用于定义 PowerPoint 转 HTML 转换过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿中的媒体（图像、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。
* 将 PowerPoint 演示文稿转换为包含或不包含发言者注释的 HTML。
* 将 PowerPoint 演示文稿转换为包含或不包含评论的 HTML。
* 将 PowerPoint 演示文稿转换为包含原始或嵌入字体的 HTML。
* 将 PowerPoint 演示文稿转换为使用新 CSS 样式的 HTML。

{{% alert color="primary" %}} 

利用其自己的 API，Aspose 开发了免费的 [演示文稿转 HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) 转换器：[PPT 转 HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX 转 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP 转 HTML](https://products.aspose.app/slides/conversion/odp-to-html)等。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您可能想查看其他 [Aspose 的免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

除了此处描述的转换过程外，Aspose.Slides 还支持涉及 HTML 格式的转换操作：

* [HTML 转图像](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}

## **将 PowerPoint 转换为 HTML**

使用 Aspose.Slides，您可以这样将整个 PowerPoint 演示文稿转换为 HTML：

1. 创建一个表示演示文稿文件的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 使用 [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法将对象保存为 HTML 文件。

此代码演示了如何将 PowerPoint 转换为 HTML :

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

Aspose.Slides 提供 [ResponsiveHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/ResponsiveHtmlController) 类，允许您生成响应式 HTML 文件。此代码演示了如何将 PowerPoint 演示文稿转换为响应式 HTML :

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

## **将 PowerPoint 转换为带注释的 HTML**

此代码演示了如何将 PowerPoint 转换为带注释的 HTML :

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $opt = new HtmlOptions();
    $options = $opt->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # 保存注释页面
    $pres->save("Output.html", SaveFormat::Html, $opt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **将 PowerPoint 转换为带原始字体的 HTML**

Aspose.Slides 提供 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) 类，允许您在将演示文稿转换为 HTML 时嵌入所有字体。

为了防止某些字体被嵌入，您可以将字体名称数组传递给 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) 类的参数化构造函数。诸如 Calibri 或 Arial 等流行字体在演示文稿中使用时，不必嵌入，因为大多数系统已经包含这些字体。当这些字体被嵌入时，生成的 HTML 文档会变得不必要地大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) 类支持继承，并提供 [WriteFont](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) 方法，该方法可以被重写。

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

## **将 PowerPoint 转换为带高质量图像的 HTML**

默认情况下，当您将 PowerPoint 转换为 HTML 时，Aspose.Slides 会输出小的 HTML，其中图像以 72 DPI 输出并删除了剪裁区域。为了获得更高质量的图像 HTML 文件，您必须将 `PicturesCompression` 属性（来自 `HtmlOptions` 类）设置为 96（即 `PicturesCompression.Dpi96`）或更高的 [值](https://reference.aspose.com/slides/php-java/aspose.slides/PicturesCompression)。

此 PHP 代码演示了如何将 PowerPoint 演示文稿转换为 HTML，同时获得 150 DPI（即 `PicturesCompression.Dpi150`）的高质量图像：

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

此代码演示了如何输出带有高质量图像的 HTML：

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

要将 PowerPoint 中的特定幻灯片转换为 HTML，您必须实例化同一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类（用于将整个演示文稿转换为 HTML），然后使用 [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法将文件保存为 HTML。[HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions) 类可以用于指定其他转换选项：

此 PHP 代码演示了如何将 PowerPoint 演示文稿中的幻灯片转换为 HTML：

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

## **导出 HTML 时保存 CSS 和图像**

使用新的 CSS 样式文件，您可以轻松更改由 PowerPoint 转 HTML 转换过程生成的 HTML 文件的样式。

此示例中的 PHP 代码演示了如何使用可重写的方法创建一个链接到 CSS 文件的自定义 HTML 文档：

```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;
use aspose\slides\EmbedAllFontsHtmlController;

class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController {
    const m_basePath = 0;

    # 自定义头部模板
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
        $generator->addHtml("<!-- 嵌入的字体 -->");
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

## **在将演示文稿转换为 HTML 时链接所有字体**

如果您不想嵌入字体（以避免增加生成的 HTML 的大小），您可以通过实现自己的 `LinkAllFontsHtmlController` 版本来链接所有字体。

此 PHP 代码演示了如何将 PowerPoint 转换为 HTML，同时链接所有字体，并排除 "Calibri" 和 "Arial"（因为它们已经存在于系统中）：

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
            $path = $fontName . ".woff"; // 可能需要某些路径清理
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

此 PHP 代码演示了如何将 PowerPoint 演示文稿转换为响应式 HTML：

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

## **导出媒体文件到 HTML**

使用 Aspose.Slides for PHP via Java，您可以以这种方式导出媒体文件：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 获取幻灯片的引用。
1. 向幻灯片添加视频。
1. 将演示文稿写入 HTML 文件。

此 PHP 代码演示了如何向演示文稿中添加视频，然后将其保存为 HTML：

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