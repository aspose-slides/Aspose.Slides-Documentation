---
title: PowerPointをHTMLに変換
linktitle: PowerPointをHTMLに変換
type: docs
weight: 30
url: /ja/php-java/convert-powerpoint-to-html/
keywords: "PHP  PowerPointをHTMLに変換, PowerPointプレゼンテーションを変換, PPTX, PPT, PPTをHTMLに, PPTXをHTMLに, PowerPointをHTMLに, PowerPointをHTMLとして保存, PPTをHTMLとして保存, PPTXをHTMLとして保存, Java, Aspose.Slides, HTMLエクスポート"
description: "PowerPointをHTMLに変換: PPTXまたはPPTをHTMLとして保存。スライドをHTMLとして保存"
---

## **概要**

この記事では、PHPを使用してPowerPointプレゼンテーションをHTML形式に変換する方法を説明します。以下のトピックをカバーしています。

- PowerPointをHTMLに変換
- PPTをHTMLに変換
- PPTXをHTMLに変換
- ODPをHTMLに変換
- PowerPointスライドをHTMLに変換

## **Java PowerPointをHTMLに変換**

PowerPointをHTMLに変換するためのJavaサンプルコードについては、以下のセクションを参照してください。すなわち、[PowerPointをHTMLに変換](#convert-powerpoint-to-html)。このコードは、プレゼンテーションオブジェクトにPPT、PPTX、ODPなどのフォーマットをロードし、HTML形式に保存できます。

## **PowerPointをHTMLに変換するについて**
[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/)を使用することで、アプリケーションや開発者はPowerPointプレゼンテーションをHTMLに変換できます：**PPTXをHTMLに**または**PPTをHTMLに**。

**Aspose.Slides**は、PowerPointをHTMLに変換するプロセスを定義する多くのオプションを提供します（主に[**HtmlOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions)クラスから）：

* PowerPointプレゼンテーション全体をHTMLに変換する。
* PowerPointプレゼンテーションの特定のスライドをHTMLに変換する。
* プレゼンテーションメディア（画像、動画など）をHTMLに変換する。
* PowerPointプレゼンテーションをレスポンシブHTMLに変換する。 
* スピーカーノートを含めるまたは除外する形でPowerPointプレゼンテーションをHTMLに変換する。 
* コメントを含めるまたは除外する形でPowerPointプレゼンテーションをHTMLに変換する。 
* 元のフォントまたは埋め込みフォントを使ってPowerPointプレゼンテーションをHTMLに変換する。 
* 新しいCSSスタイルを使用しながらPowerPointプレゼンテーションをHTMLに変換する。 

{{% alert color="primary" %}} 

独自のAPIを使用して、Asposeは無料の[プレゼンテーションをHTMLに変換](https://products.aspose.app/slides/conversion/powerpoint-to-html)コンバータを開発しました： [PPTをHTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTXをHTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODPをHTML](https://products.aspose.app/slides/conversion/odp-to-html)など。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の[Asposeの無料コンバータ](https://products.aspose.app/slides/conversion)もチェックしてみてください。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

ここで説明した変換プロセスに加えて、Aspose.Slidesは以下のHTMLフォーマットに関する変換操作もサポートしています： 

* [HTMLを画像に](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTMLをJPGに](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTMLをXMLに](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTMLをTIFFに](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPointをHTMLに変換**
Aspose.Slidesを使用すると、PowerPointプレゼンテーション全体を以下のようにしてHTMLに変換できます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成する。
1. [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用してオブジェクトをHTMLファイルとして保存します。

このコードは、PowerPointをHTMLに変換する方法を示しています：

```php
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $htmlOpt = new HtmlOptions();
    $htmlOpt->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $htmlOpt->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false));
    # プレゼンテーションをHTMLとして保存
    $pres->save("ConvertWholePresentationToHTML_out.html", SaveFormat::Html, $htmlOpt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **PowerPointをレスポンシブHTMLに変換**
Aspose.Slidesは、レスポンシブHTMLファイルを生成するための[ResponsiveHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/ResponsiveHtmlController)クラスを提供しています。このコードは、PowerPointプレゼンテーションをレスポンシブHTMLに変換する方法を示しています：

```php
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $controller = new ResponsiveHtmlController();
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    # プレゼンテーションをHTMLとして保存
    $pres->save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, $htmlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ノート付きでPowerPointをHTMLに変換**
このコードは、ノート付きでPowerPointをHTMLに変換する方法を示しています：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $opt = new HtmlOptions();
    $options = $opt->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # ノートページを保存
    $pres->save("Output.html", SaveFormat::Html, $opt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **元のフォント付きでPowerPointをHTMLに変換**

Aspose.Slidesは、プレゼンテーションをHTMLに変換する際にすべてのフォントを埋め込むことができる[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController)クラスを提供しています。

特定のフォントの埋め込みを防ぐために、フォント名の配列を[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController)クラスのパラメータ化されたコンストラクタに渡すことができます。プレゼンテーションで使用される一般的なフォント（例：CalibriやArial）は、ほとんどのシステムにすでに存在するため、埋め込む必要はありません。これらのフォントが埋め込まれた場合、生成されるHTMLドキュメントは不必要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController)クラスは継承をサポートし、[WriteFont](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-)メソッドを提供しており、これを上書きすることができます。

```php
  $pres = new Presentation("input.pptx");
  try {
    # デフォルトのプレゼンテーションフォントを除外
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

## **高品質の画像でPowerPointをHTMLに変換**

デフォルトでは、PowerPointをHTMLに変換すると、Aspose.Slidesは72 DPIの小さなHTMLに画像を出力し、切り取られた領域を削除します。より高品質の画像を持つHTMLファイルを取得するには、`PicturesCompression`プロパティ（`HtmlOptions`クラスのもの）を96（すなわち、`PicturesCompression.Dpi96`）またはそれ以上の[値](https://reference.aspose.com/slides/php-java/aspose.slides/PicturesCompression)に設定する必要があります。

このPHPコードは、150 DPI（すなわち、`PicturesCompression.Dpi150`）で高品質の画像を取得しながらPowerPointプレゼンテーションをHTMLに変換する方法を示しています：

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

このコードは、フルクオリティの画像でHTMLを出力する方法を示しています：

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

## **スライドをHTMLに変換**
PowerPointの特定のスライドをHTMLに変換するには、（全体のプレゼンテーションをHTMLに変換するために使用される）同じ[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスをインスタンス化し、その後[Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを使用してファイルをHTMLとして保存する必要があります。 [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions)クラスを使用して追加の変換オプションを指定できます：

このPHPコードは、PowerPointプレゼンテーションのスライドをHTMLに変換する方法を示しています：

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
    # ファイルを保存
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $pres->save("Individual Slide" . ($i + 1) . "_out.html", array($i + 1 ), SaveFormat::Html, $htmlOptions);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **HTMLにエクスポートする際にCSSと画像を保存**
新しいCSSスタイルファイルを使用して、PowerPointをHTMLに変換するプロセスから生成されるHTMLファイルのスタイルを簡単に変更できます。 

この例のPHPコードは、オーバーライド可能なメソッドを使用してCSSファイルへのリンクを持つカスタムHTMLドキュメントを作成する方法を示しています：

```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;
use aspose\slides\EmbedAllFontsHtmlController;

class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController {
    const m_basePath = 0;

    # カスタムヘッダーテンプレート
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
        $generator->addHtml("<!-- 埋め込まれたフォント -->");
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

## **プレゼンテーションをHTMLに変換する際にフォントをリンクとして指定**

フォントを埋め込まない場合（生成するHTMLのサイズを増加させないため）、独自の`LinkAllFontsHtmlController`バージョンを実装することで、すべてのフォントをリンクとして指定できます。 

このPHPコードは、"Calibri"と"Arial"を除外しながらPowerPointをHTMLに変換し、すべてのフォントをリンクとして指定する方法を示しています：

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
            $path = $fontName . ".woff"; // いくつかのパスのサニタイズが必要かもしれません
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
    # デフォルトのプレゼンテーションフォントを除外
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

## **PowerPointをレスポンシブHTMLに変換**
このPHPコードは、PowerPointプレゼンテーションをレスポンシブHTMLに変換する方法を示しています：

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


## **メディアファイルをHTMLにエクスポート**
Aspose.Slides for PHP via Javaを使用して、次のようにメディアファイルをエクスポートできます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成する。
1. スライドへの参照を取得する。
1. スライドに動画を追加する。
1. プレゼンテーションをHTMLファイルとして書き込む。

このPHPコードは、プレゼンテーションにビデオを追加し、HTMLとして保存する方法を示しています：

```php
// プレゼンテーションを読み込む
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
    # HTMLオプションの設定
    $htmlOptions = new HtmlOptions($controller);
    $svgOptions = new SVGOptions($controller);
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    $htmlOptions->setSlideImageFormat(SlideImageFormat::svg($svgOptions));
    # ファイルを保存
    $pres->save($fileName, SaveFormat::Html, $htmlOptions);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```