---
title: PHP'de Sunum Görüntüleyici Oluştur
linktitle: Sunum Görüntüleyici
type: docs
weight: 50
url: /tr/php-java/presentation-viewer/
keywords:
- sunumu görüntüle
- sunum görüntüleyici
- sunum görüntüleyici oluştur
- PPT görüntüle
- PPTX görüntüle
- ODP görüntüle
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak özel bir sunum görüntüleyici oluşturun. Microsoft PowerPoint olmadan PowerPoint ve OpenDocument dosyalarını kolayca görüntüleyin."
---
## **Giriş**

Aspose.Slides for PHP via Java, slaytlarla sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, örneğin Microsoft PowerPoint’te sunumları açarak görüntülenebilir. Ancak, bazen geliştiricilerin slaytları tercih ettikleri bir görüntüleyicide resim olarak görüntülemeleri veya kendi sunum görüntüleyicilerini oluşturmaları gerekebilir. Bu gibi durumlarda, Aspose.Slides tek bir slaytı resim olarak dışa aktarmanıza olanak tanır. Bu makale bunun nasıl yapılacağını açıklar.

## **Bir Slayttan SVG Görüntüsü Oluşturma**

Bir sunum slaytından SVG görüntüsü oluşturmak için Aspose.Slides ile aşağıdaki adımları izleyin:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) class.
1. Get the slide reference by its index.
1. Open a file stream.
1. Save the slide as an SVG image to the file stream.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **Özel Şekil Kimliği ile SVG Oluşturma**

Aspose.Slides, özel bir şekil kimliğiyle bir slayttan [SVG](https://docs.fileformat.com/page-description-language/svg/) oluşturmak için kullanılabilir. Bunu yapmak için [SvgShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgshape/) sınıfındaki `setId` metodunu kullanın. Şekil kimliğini ayarlamak için `CustomSvgShapeFormattingController` kullanılabilir.

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

## **Bir Slayt Küçük Resmi Oluşturma**

Aspose.Slides, slaytların küçük resimlerini oluşturmanıza yardımcı olur. Aspose.Slides kullanarak bir slaytın küçük resmini oluşturmak için aşağıdaki adımları izleyin:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) class.
1. Get the slide reference by its index.
1. Get the thumbnail image of the referenced slide at a defined scale.
1. Save the thumbnail image in any desired image format.

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

## **Kullanıcı Tanımlı Boyutlarla Slayt Küçük Resmi Oluşturma**

Kullanıcı tanımlı boyutlarla bir slayt küçük resmi oluşturmak için aşağıdaki adımları izleyin:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) class.
1. Get the slide reference by its index.
1. Get the thumbnail image of the referenced slide with the defined dimensions.
1. Save the thumbnail image in any desired image format.

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

## **Konuşmacı Notlarıyla Slayt Küçük Resmi Oluşturma**

Aspose.Slides kullanarak konuşmacı notlarıyla bir slaytın küçük resmini oluşturmak için aşağıdaki adımları izleyin:

1. Create an instance of the [RenderingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/renderingoptions/) class.
1. Use the `RenderingOptions.setSlidesLayoutOptions` method to set the position of speaker notes.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) class.
1. Get the slide reference by its index.
1. Get the thumbnail image of the referenced slide with the rendering options.
1. Save the thumbnail image in any desired image format.

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

## **Canlı Örnek**

Aspose.Slides API ile neler uygulayabileceğinizi görmek için ücretsiz [**Aspose.Slides Viewer**](https://products.aspose.app/slides/tr/viewer/) uygulamasını deneyebilirsiniz:

![Çevrimiçi PowerPoint Görüntüleyici](online-PowerPoint-viewer.png)

## **SSS**

**Bir web uygulamasına sunum görüntüleyici yerleştirebilir miyim?**

Evet. Sunumları sunucu tarafında görüntülemek için Aspose.Slides'ı kullanabilir, slaytları resim veya HTML olarak render edip tarayıcıda gösterebilirsiniz. Navigasyon ve yakınlaştırma özellikleri, etkileşimli bir deneyim için JavaScript ile uygulanabilir.

**Özel bir görüntüleyicide slaytları göstermek için en iyi yöntem nedir?**

Önerilen yöntem, her slaytı bir görüntü (ör. PNG veya SVG) olarak render etmek veya Aspose.Slides kullanarak HTML’ye dönüştürmek, ardından çıktıyı bir resim kutusunda (masaüstü için) veya bir HTML konteynerinde (web için) görüntülemektir.

**Birçok slaytı olan büyük sunumları nasıl yönetebilirim?**

Büyük sunumlar için, slaytların tembel yükleme (lazy-loading) veya isteğe bağlı render edilmesini düşünün. Bu, bir slaytın içeriğinin yalnızca kullanıcı ona gittiğinde oluşturulması anlamına gelir; böylece bellek ve yükleme süresi azalır.