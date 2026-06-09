---
title: PHP'de Sunumlardan Gelişmiş Metin Çıkarma
linktitle: Metin Çıkar
type: docs
weight: 90
url: /tr/php-java/extract-text-from-presentation/
keywords:
- metin çıkar
- slayttan metin çıkar
- sunumdan metin çıkar
- PowerPoint'tan metin çıkar
- OpenDocument'ten metin çıkar
- PPT'den metin çıkar
- PPTX'den metin çıkar
- ODP'den metin çıkar
- metin al
- slayttan metin al
- sunumdan metin al
- PowerPoint'tan metin al
- OpenDocument'ten metin al
- PPT'den metin al
- PPTX'den metin al
- ODP'den metin al
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument sunumlardan hızlı bir şekilde metin çıkarın. Zamandan tasarruf etmek için basit, adım adım kılavuzumuzu takip edin."
---
## **Genel Bakış**

Sunumlardan metin çıkarma, slayt içeriğiyle çalışan geliştiriciler için yaygın ancak hayati bir görevdir. Microsoft PowerPoint dosyaları PPT veya PPTX formatında olsun ya da OpenDocument sunumları (ODP) olsun, metinsel veriye erişmek ve geri almak, analiz, otomasyon, indeksleme veya içerik göçü amaçları için kritik olabilir.

Bu makale, Aspose.Slides for PHP via Java kullanarak PPT, PPTX ve ODP dahil olmak üzere çeşitli sunum biçimlerinden metni verimli bir şekilde çıkarmak için kapsamlı bir rehber sunar. Sunum öğeleri üzerinden sistematik olarak döngü yapmayı öğrenerek ihtiyacınız olan metin içeriğini doğru bir şekilde alacaksınız.

## **Bir Slayttan Metin Çıkarma**

Aspose.Slides for PHP via Java, [SlideUtil](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideutil/) sınıfını sağlar. Bu sınıf, bir sunum veya slayttan tüm metni çıkarmak için birkaç aşırı yüklü statik metot sunar. Bir sunumdaki bir slayttan metin çıkarmak için [getAllTextBoxes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideutil/#getAllTextBoxes) metodunu kullanın. Bu metot, parametre olarak [BaseSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/) tipinde bir nesne alır. Çalıştırıldığında, metod tüm slaytı metin için tarar ve metin biçimlendirmesini koruyarak [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) tipinde nesneler içeren bir dizi döndürür.

Aşağıdaki kod parçacığı, sunumun ilk slaytındaki tüm metni çıkarır:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Bir Sunumdan Metin Çıkarma**

Sunumun tamamındaki metni taramak için, [SlideUtil](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideutil/) sınıfının sunduğu [getAllTextFrames](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideutil/#getAllTextFrames) statik metodunu kullanın. Bu metot iki parametre alır:

1. İlk olarak, metnin çıkarılacağı PowerPoint veya OpenDocument sunumunu temsil eden bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) nesnesi.
1. İkinci olarak, sunumdan metin taranırken ana slaytların (master slides) dahil edilip edilmeyeceğini belirten bir `boolean` değeri.

Metot, [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) tipinde nesneler içeren bir dizi döndürür ve metin biçimlendirme bilgilerini içerir. Aşağıdaki kod, ana slaytlar dahil olmak üzere bir sunumdan metin ve biçimlendirme ayrıntılarını tarar.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Kategorize Edilmiş ve Hızlı Metin Çıkarma**

[PresentationFactory](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/) sınıfı da sunumlardan tüm metni çıkarmak için metodlar sağlar:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textextractionarrangingmode/) enum argümanı, metin çıkarma sonucunun düzenlenme modunu gösterir ve aşağıdaki değerlere ayarlanabilir:
- `Unarranged` - Slayttaki konumuna bakılmaksızın ham metin.
- `Arranged` - Metin, slayttaki aynı sırada düzenlenir.

Hızın kritik olduğu durumlarda düzenlenmemiş (unarranged) mod kullanılabilir; bu mod, düzenlenmiş (arranged) moddan daha hızlıdır.

[PresentationText](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationtext/) sunumdan çıkarılan ham metni temsil eder. `getSlidesText` metodu, her nesnenin ilgili slayttaki metni temsil ettiği bir nesne dizisi döndürür. Döndürülen her nesnenin aşağıdaki metodları vardır:
- `getText` - Slayt şekilleri içindeki metin.
- `getMasterText` - Bu slaytla ilişkili ana slayt (master slide) şekilleri içindeki metin.
- `getLayoutText` - Bu slaytla ilişkili düzen slaytı (layout slide) şekilleri içindeki metin.
- `getNotesText` - Bu slaytla ilişkili not slaytı (notes slide) şekilleri içindeki metin.
- `getCommentsText` - Bu slaytla ilişkili yorumlar içindeki metin.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **SSS**

**Aspose.Slides büyük sunumları metin çıkarma sırasında ne kadar hızlı işler?**

Aspose.Slides yüksek performans için optimize edilmiştir ve [büyük sunumları](/slides/tr/php-java/open-presentation/) işleyebilir, bu da gerçek zamanlı veya toplu işleme senaryoları için uygundur.

**Aspose.Slides, sunumlardaki tablolar ve grafikler gibi birçok slayt öğesinden metin çıkarabilir mi?**

Evet. Aspose.Slides, tablolar ve grafiklerle ilgili nesneler dahil birçok slayt öğesinden metin çıkarabilir; böylece yaygın sunum yapılarındaki metinsel içeriğe erişebilir ve analiz edebilirsiniz.

**Sunumlardan metin çıkarmak için özel bir Aspose.Slides lisansına ihtiyacım var mı?**

Metin çıkarmak için Aspose.Slides'ın ücretsiz deneme sürümünü kullanabilirsiniz, ancak bu sürüm [belirli sınırlamalara](/slides/tr/php-java/licensing/) sahiptir; örneğin yalnızca sınırlı sayıda slaytı işleyebilir. Sınırsız kullanım ve daha büyük sunumları işlemek için tam bir lisans satın almanız önerilir.