---
title: PHP で PowerPoint プレゼンテーションを HTML に変換
linktitle: PowerPoint を HTML に変換
type: docs
weight: 30
url: /ja/php-java/convert-powerpoint-to-html/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を HTML に変換
- プレゼンテーションを HTML に変換
- スライドを HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- PowerPoint を HTML として保存
- プレゼンテーションを HTML として保存
- スライドを HTML として保存
- PPT を HTML として保存
- PPTX を HTML として保存
- PPT を HTML にエクスポート
- PPTX を HTML にエクスポート
- PHP
- Aspose.Slides
description: "PHP で PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。レイアウト、リンク、画像を保持し、Aspose.Slides の変換ガイドで高速かつ完璧な結果を実現します。"
---

## **概要**

この記事では、PHP を使用して PowerPoint プレゼンテーションを HTML 形式に変換する方法を説明します。以下のトピックを取り上げます。

- PowerPoint を HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- ODP を HTML に変換
- PowerPoint スライドを HTML に変換

## **PHP での PowerPoint → HTML 変換**

PowerPoint を HTML に変換する Java のサンプルコードについては、以下のセクション [PowerPoint を HTML に変換](#convert-powerpoint-to-html) を参照してください。このコードは、Presentation オブジェクトで PPT、PPTX、ODP などの多数の形式を読み込み、HTML 形式で保存できます。

## **PowerPoint → HTML 変換について**
[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/) を使用すると、アプリケーションや開発者は PowerPoint プレゼンテーションを HTML に変換できます: **PPTX を HTML に** または **PPT を HTML に**。

**Aspose.Slides** は、PowerPoint を HTML に変換するプロセスを定義する多数のオプション（主に [**HtmlOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions) クラス）を提供します：

* PowerPoint プレゼンテーション全体を HTML に変換します。
* PowerPoint プレゼンテーション内の特定のスライドを HTML に変換します。
* プレゼンテーションのメディア（画像、動画など）を HTML に変換します。
* PowerPoint プレゼンテーションをレスポンシブ HTML に変換します。
* スピーカーノートを含めるか除外した状態で PowerPoint プレゼンテーションを HTML に変換します。
* コメントを含めるか除外した状態で PowerPoint プレゼンテーションを HTML に変換します。
* 元のフォントまたは埋め込みフォントで PowerPoint プレゼンテーションを HTML に変換します。
* 新しい CSS スタイルを使用して PowerPoint プレゼンテーションを HTML に変換します。

{{% alert color="primary" %}} 

Aspose は独自の API を使用して、無料の [プレゼンテーション to HTML] コンバータを開発しました: [PPT to HTML]、[PPTX to HTML]、[ODP to HTML] など。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

他の [Aspose の無料コンバータ] もご確認ください。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

ここで説明した変換プロセスに加えて、Aspose.Slides は HTML 形式に関連する以下の変換操作もサポートしています：

* [HTML から画像へ](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML から JPG へ](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML から XML へ](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML から TIFF へ](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPoint を HTML に変換**
Aspose.Slides を使用すると、次の手順で PowerPoint プレゼンテーション全体を HTML に変換できます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドを使用してオブジェクトを HTML ファイルとして保存します。

このコードは PowerPoint を HTML に変換する方法を示しています：
```php
// プレゼンテーション ファイルを表す Presentation オブジェクトを作成します
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $htmlOpt = new HtmlOptions();
    $htmlOpt->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $htmlOpt->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false));
    # プレゼンテーションを HTML に保存
    $pres->save("ConvertWholePresentationToHTML_out.html", SaveFormat::Html, $htmlOpt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **PowerPoint をレスポンシブ HTML に変換**
Aspose.Slides は [ResponsiveHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/ResponsiveHtmlController) クラスを提供し、レスポンシブ HTML ファイルを生成できます。このコードは PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています：
```php
// プレゼンテーション ファイルを表す Presentation オブジェクトを作成します
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $controller = new ResponsiveHtmlController();
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    # プレゼンテーションを HTML に保存
    $pres->save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, $htmlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **PowerPoint をノート付き HTML に変換**
このコードはノート付きで PowerPoint を HTML に変換する方法を示しています：
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


## **PowerPoint を元フォント付き HTML に変換**

Aspose.Slides は [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) クラスを提供し、プレゼンテーションを HTML に変換する際にすべてのフォントを埋め込むことができます。

特定のフォントを埋め込みたくない場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) のパラメータ付きコンストラクタにフォント名の配列を渡すことができます。Calibri や Arial のような一般的なフォントは、ほとんどのシステムに既にインストールされているため埋め込む必要はありません。これらのフォントを埋め込むと、生成された HTML 文書が不要に大きくなります。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) クラスは継承をサポートし、[WriteFont](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) メソッドを提供します。このメソッドはオーバーライド対象です。
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


## **PowerPoint を高品質画像付き HTML に変換**

既定では、PowerPoint を HTML に変換すると Aspose.Slides は 72 DPI の画像と削除されたトリミング領域を含む小さな HTML を出力します。より高品質な画像を含む HTML ファイルを取得するには、`HtmlOptions` クラスの `PicturesCompression` プロパティを 96（すなわち `PicturesCompression.Dpi96`）以上の値に設定する必要があります。詳細は [PicturesCompression 列挙体](https://reference.aspose.com/slides/php-java/aspose.slides/PicturesCompression) を参照してください。

この PHP コードは、150 DPI（`PicturesCompression.Dpi150`）の高品質画像を取得しながら PowerPoint プレゼンテーションを HTML に変換する方法を示しています：
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


このコードはフルクオリティ画像で HTML を出力する方法を示しています：
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


## **スライドを HTML に変換**
PowerPoint の特定のスライドを HTML に変換するには、全体プレゼンテーションを HTML に変換する際に使用したのと同じ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成し、[Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) メソッドで HTML として保存します。追加の変換オプションは [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions) クラスで指定できます。

この PHP コードは PowerPoint プレゼンテーション内のスライドを HTML に変換する方法を示しています：
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


## **HTML エクスポート時に CSS と画像を保存**
新しい CSS スタイルファイルを使用すると、PowerPoint から HTML への変換プロセスで生成される HTML ファイルのスタイルを簡単に変更できます。

この例の PHP コードは、オーバーライド可能なメソッドを使用して CSS ファイルへのリンクを含むカスタム HTML ドキュメントを作成する方法を示しています：
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


## **プレゼンテーションを HTML に変換する際にすべてのフォントをリンク**

フォントを埋め込まず（生成された HTML のサイズ増加を防ぐため）すべてのフォントをリンクしたい場合は、独自の `LinkAllFontsHtmlController` 実装を作成できます。

この PHP コードは、フォントを埋め込まずにすべてのフォントをリンクし、システムに既に存在する「Calibri」および「Arial」を除外して PowerPoint を HTML に変換する方法を示しています：
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
            $path = $fontName . ".woff"; // パスのサニタイズが必要になる場合があります
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


## **PowerPoint をレスポンシブ HTML に変換**
この PHP コードは PowerPoint プレゼンテーションをレスポンシブ HTML に変換する方法を示しています：
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



## **メディアファイルを HTML にエクスポート**
Aspose.Slides for PHP via Java を使用すると、次の手順でメディアファイルをエクスポートできます：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドへの参照を取得します。
3. スライドにビデオを追加します。
4. プレゼンテーションを HTML ファイルとして書き出します。

この PHP コードはプレゼンテーションにビデオを追加し、HTML として保存する方法を示しています：
```php
// プレゼンテーションの読み込み
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
    # HTML オプションの設定
    $htmlOptions = new HtmlOptions($controller);
    $svgOptions = new SVGOptions($controller);
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    $htmlOptions->setSlideImageFormat(SlideImageFormat::svg($svgOptions));
    # ファイルの保存
    $pres->save($fileName, SaveFormat::Html, $htmlOptions);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**複数のプレゼンテーションを HTML に変換する際の Aspose.Slides のパフォーマンスはどうですか？**

パフォーマンスはプレゼンテーションのサイズと複雑さに依存します。Aspose.Slides はバッチ処理に対して非常に効率的でスケーラブルです。多数のプレゼンテーションを変換する場合は、可能な限りマルチスレッドまたは並列処理を使用することが推奨されます。

**Aspose.Slides はハイパーリンクの HTML へのエクスポートをサポートしていますか？**

はい、Aspose.Slides は埋め込みハイパーリンクの HTML へのエクスポートを完全にサポートしています。プレゼンテーションを HTML 形式に変換すると、ハイパーリンクは自動的に保持され、クリック可能なままです。

**プレゼンテーションを HTML に変換する際、スライド数に制限はありますか？**

Aspose.Slides にはスライド数の制限はありません。任意のサイズのプレゼンテーションを変換できます。ただし、非常に大量のスライドを含むプレゼンテーションの場合、サーバーまたはシステムの利用可能なリソースに応じてパフォーマンスが影響を受ける可能性があります。