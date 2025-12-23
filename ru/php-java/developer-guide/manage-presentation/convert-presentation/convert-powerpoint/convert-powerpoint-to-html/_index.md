---
title: Конвертировать презентации PowerPoint в HTML на PHP
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/php-java/convert-powerpoint-to-html/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в HTML
- презентация в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- сохранить PowerPoint как HTML
- сохранить презентацию как HTML
- сохранить слайд как HTML
- сохранить PPT как HTML
- сохранить PPTX как HTML
- экспортировать PPT в HTML
- экспортировать PPTX в HTML
- PHP
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в адаптивный HTML на PHP. Сохраняйте макет, ссылки и изображения с помощью руководства по конвертации Aspose.Slides для быстрых и безошибочных результатов."
---

## **Обзор**

Эта статья объясняет, как конвертировать презентацию PowerPoint в формат HTML с помощью PHP. Рассматриваются следующие темы.

- Конвертация PowerPoint в HTML
- Конвертация PPT в HTML
- Конвертация PPTX в HTML
- Конвертация ODP в HTML
- Конвертация слайда PowerPoint в HTML

## **PowerPoint в HTML на PHP**

Для примера кода на Java по конвертации PowerPoint в HTML см. раздел ниже, то есть [Convert PowerPoint to HTML](#convert-powerpoint-to-html). Код может загружать различные форматы, такие как PPT, PPTX и ODP, в объект Presentation и сохранять его в формате HTML.

## **О конвертации PowerPoint в HTML**
С помощью [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/) приложения и разработчики могут конвертировать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**.

**Aspose.Slides** предоставляет множество параметров (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions)), определяющих процесс конвертации PowerPoint в HTML:

* Конвертировать всю презентацию PowerPoint в HTML.
* Конвертировать конкретный слайд презентации PowerPoint в HTML.
* Конвертировать медиа‑презентацию (изображения, видео и т.д.) в HTML.
* Конвертировать презентацию PowerPoint в адаптивный HTML. 
* Конвертировать презентацию PowerPoint в HTML с включенными или исключёнными заметками докладчика. 
* Конвертировать презентацию PowerPoint в HTML с включенными или исключёнными комментариями. 
* Конвертировать презентацию PowerPoint в HTML с оригинальными или встроенными шрифтами. 
* Конвертировать презентацию PowerPoint в HTML, используя новый стиль CSS. 

{{% alert color="primary" %}} 

Используя собственный API, Aspose разработала бесплатные конвертеры [презентация в HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP в HTML](https://products.aspose.app/slides/conversion/odp-to-html) и др. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Вы также можете ознакомиться с другими [бесплатными конвертерами от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Помимо перечисленных процессов конвертации, Aspose.Slides также поддерживает следующие операции, связанные с форматом HTML: 

* [HTML в изображение](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}


## **Конвертировать PowerPoint в HTML**
С помощью Aspose.Slides вы можете конвертировать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). 
1. Вызовите метод [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) для сохранения объекта в HTML‑файл.

Этот код демонстрирует, как конвертировать PowerPoint в HTML :
```php
// Instantiate a Presentation object that represents a presentation file
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $htmlOpt = new HtmlOptions();
    $htmlOpt->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $htmlOpt->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false));
    # Saving the presentation to HTML
    $pres->save("ConvertWholePresentationToHTML_out.html", SaveFormat::Html, $htmlOpt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **Конвертировать PowerPoint в адаптивный HTML**
Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/ResponsiveHtmlController), позволяющий создавать адаптивные HTML‑файлы. Этот код показывает, как конвертировать презентацию PowerPoint в адаптивный HTML :
```php
// Создайте объект Presentation, который представляет файл презентации
  $pres = new Presentation("Convert_HTML.pptx");
  try {
    $controller = new ResponsiveHtmlController();
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    # Сохранение презентации в HTML
    $pres->save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat::Html, $htmlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Конвертировать PowerPoint в HTML с заметками**
Этот код показывает, как конвертировать PowerPoint в HTML с заметками :
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $opt = new HtmlOptions();
    $options = $opt->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # Сохранение страниц заметок
    $pres->save("Output.html", SaveFormat::Html, $opt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Конвертировать PowerPoint в HTML с оригинальными шрифтами**

Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController), позволяющий внедрять все шрифты презентации при конвертации её в HTML.

Чтобы исключить внедрение определённых шрифтов, вы можете передать массив имён шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController). Популярные шрифты, такие как Calibri или Arial, используемые в презентации, не обязаны внедряться, поскольку большинство систем уже содержат их. Если такие шрифты внедряются, получаемый HTML‑документ становится излишне большим.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController) поддерживает наследование и предоставляет метод [WriteFont](https://reference.aspose.com/slides/php-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-), который следует переопределить.
```php
  $pres = new Presentation("input.pptx");
  try {
    # исключить шрифты презентации по умолчанию
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


## **Конвертировать PowerPoint в HTML с изображениями высокого качества**

По умолчанию при конвертации PowerPoint в HTML Aspose.Slides выводит небольшие HTML‑файлы с изображениями в 72 DPI и удалёнными обрезанными областями. Чтобы получить HTML‑файлы с изображениями более высокого качества, необходимо задать свойство `PicturesCompression` (из класса `HtmlOptions`) со значением 96 (т. е. `PicturesCompression.Dpi96`) или более высоким [значением](https://reference.aspose.com/slides/php-java/aspose.slides/PicturesCompression).

Этот PHP‑код показывает, как конвертировать презентацию PowerPoint в HTML, получая изображения высшего качества с разрешением 150 DPI (т. е. `PicturesCompression.Dpi150`):
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


Этот код показывает, как вывести HTML с изображениями полной качества:
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


## **Конвертировать слайд в HTML**
Чтобы конвертировать конкретный слайд PowerPoint в HTML, необходимо создать экземпляр того же класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), используемого для конвертации всей презентации в HTML, и затем вызвать метод [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) для сохранения файла в HTML. Класс [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/HtmlOptions) можно использовать для указания дополнительных параметров конвертации:

Этот PHP‑код демонстрирует, как конвертировать слайд презентации PowerPoint в HTML:
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
    # Сохранение файла
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $pres->save("Individual Slide" . ($i + 1) . "_out.html", array($i + 1 ), SaveFormat::Html, $htmlOptions);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Сохранить CSS и изображения при экспорте в HTML**
Используя файлы стилей CSS нового формата, вы можете легко изменить внешний вид HTML‑файла, полученного в результате конвертации PowerPoint в HTML. 

PHP‑код в этом примере показывает, как с помощью переопределяемых методов создать пользовательский HTML‑документ со ссылкой на файл CSS:
```php
use aspose\slides\Presentation;
use aspose\slides\HtmlOptions;
use aspose\slides\NotesPositions;
use aspose\slides\SaveFormat;
use aspose\slides\EmbedAllFontsHtmlController;

class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController {
    const m_basePath = 0;

    # Пользовательский шаблон заголовка
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


## **Ссылка на все шрифты при конвертации презентации в HTML**

Если вы не хотите внедрять шрифты (чтобы не увеличивать размер получаемого HTML), вы можете ссылаться на все шрифты, реализовав собственную версию `LinkAllFontsHtmlController`. 

Этот PHP‑код показывает, как конвертировать PowerPoint в HTML, ссылаясь на все шрифты и исключая «Calibri» и «Arial» (поскольку они уже присутствуют в системе):
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
            $path = $fontName . ".woff"; // может потребоваться очистка пути
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
    # исключить шрифты презентации по умолчанию
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


## **Конвертировать PowerPoint в адаптивный HTML**
Этот PHP‑код показывает, как конвертировать презентацию PowerPoint в адаптивный HTML:
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



## **Экспорт медиа‑файлов в HTML**
С помощью Aspose.Slides for PHP via Java вы можете экспортировать медиа‑файлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). 
1. Получите ссылку на слайд. 
1. Добавьте видео на слайд. 
1. Запишите презентацию в HTML‑файл.

Этот PHP‑код демонстрирует, как добавить видео в презентацию и затем сохранить её в HTML:
```php
// Загрузка презентации
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
    # Настройка параметров HTML
    $htmlOptions = new HtmlOptions($controller);
    $svgOptions = new SVGOptions($controller);
    $htmlOptions->setHtmlFormatter(java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller));
    $htmlOptions->setSlideImageFormat(SlideImageFormat::svg($svgOptions));
    # Сохранение файла
    $pres->save($fileName, SaveFormat::Html, $htmlOptions);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Какова производительность Aspose.Slides при конвертации нескольких презентаций в HTML?**

Производительность зависит от размера и сложности презентаций. Aspose.Slides обладает высокой эффективностью и масштабируемостью для пакетных операций. Для достижения оптимальной производительности при конвертации большого количества презентаций рекомендуется использовать многопоточность или параллельную обработку, когда это возможно.

**Поддерживает ли Aspose.Slides экспорт гиперссылок в HTML?**

Да, Aspose.Slides полностью поддерживает экспорт встроенных гиперссылок в HTML. При конвертации презентаций в формат HTML гиперссылки сохраняются автоматически и остаются кликабельными.

**Есть ли ограничение на количество слайдов при конвертации презентаций в HTML?**

Ограничения на количество слайдов при использовании Aspose.Slides нет. Вы можете конвертировать презентации любого размера. Однако для презентаций с очень большим количеством слайдов производительность может зависеть от доступных ресурсов вашего сервера или системы.