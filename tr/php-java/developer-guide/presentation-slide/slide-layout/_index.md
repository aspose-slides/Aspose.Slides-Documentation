---
title: PHP'de Slayt Düzenlerini Uygulama veya Değiştirme
linktitle: Slayt Düzeni
type: docs
weight: 60
url: /tr/php-java/slide-layout/
keywords:
- slayt düzeni
- içerik düzeni
- yer tutucu
- sunum tasarımı
- slayt tasarımı
- kullanılmayan düzen
- altbilgi görünürlüğü
- başlık slaytı
- başlık ve içerik
- bölüm başlığı
- iki içerik
- karşılaştırma
- sadece başlık
- boş düzen
- altyazılı içerik
- altyazılı resim
- başlık ve dikey metin
- dikey başlık ve metin
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile slayt düzenlerini yönetin ve özelleştirin. Düzen türlerini, yer tutucu kontrolünü ve altbilgi görünürlüğünü kod örnekleriyle keşfedin."
---
## **Giriş**

Bir slayt düzeni, bir slayttaki yer tutucu kutuların yerleşimini ve içeriğin biçimlendirmesini tanımlar. Hangi yer tutucuların mevcut olduğunu ve nerede görüneceklerini kontrol eder. Slayt düzenleri, ister basit ister karmaşık bir şey oluşturuyor olun, sunumları hızlı ve tutarlı bir şekilde tasarlamanıza yardımcı olur. PowerPoint'te en yaygın slayt düzenlerinden bazıları şunlardır:

**Başlık Slaytı düzeni** – Başlık ve alt başlık için iki metin yer tutucusu içerir.

**Başlık ve İçerik düzeni** – Üstte daha küçük bir başlık yer tutucusu ve altında metin, madde işaretleri, grafikler, resimler ve daha fazlası gibi ana içerik için daha büyük bir yer tutucu bulunur.

**Boş düzen** – Hiç yer tutucu bulunmaz, slaytı sıfırdan tasarlamak için tam kontrol sağlar.

Slayt düzenleri, sunumun düzen stillerini tanımlayan üst düzey slayt olan slayt ana temasının bir parçasıdır. Düzen slaytlarına slayt ana temasından tip, ad veya benzersiz kimlikleriyle erişebilir ve onları değiştirebilirsiniz. Alternatif olarak, belirli bir düzen slaytını doğrudan sunum içinde düzenleyebilirsiniz.

Aspose.Slides for PHP'de slayt düzenleriyle çalışmak için şu öğeleri kullanabilirsiniz:

- [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı altında bulunan [getLayoutSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getLayoutSlides) ve [getMasters](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getMasters) gibi yöntemler
- [LayoutSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/) ve [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslideheaderfootermanager/) gibi türler

{{% alert title="Info" color="info" %}}
Ana slaytlarla çalışmak hakkında daha fazla bilgi edinmek için [Slide Master](/slides/tr/php-java/slide-master/) makalesine göz atın.
{{% /alert %}}

## **Sunumlara Slayt Düzenleri Ekleme**

Slaytlarınızın görünümünü ve yapısını özelleştirmek için bir sunuma yeni düzen slaytları eklemeniz gerekebilir. Aspose.Slides for PHP, belirli bir düzenin zaten var olup olmadığını kontrol etmenizi, gerekirse yeni bir düzen eklemenizi ve bu düzeni temel alarak slayt eklemenizi sağlar.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. [MasterLayoutSlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterlayoutslidecollection/) öğesine erişin.  
1. İstenen düzen slaytı koleksiyonda zaten var mı kontrol edin. Yoksa ihtiyacınız olan düzen slaytını ekleyin.  
1. Yeni düzen slaytına dayalı boş bir slayt ekleyin.  
1. Sunumu kaydedin.

Aşağıdaki PHP kodu, bir PowerPoint sunumuna slayt düzeni eklemenin nasıl yapılacağını gösterir:

```php
// PowerPoint dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("Sample.pptx");
try {
    // Bir düzen slaytı seçmek için düzen slaytı türleri arasında geçiş yapın.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Sunumun tüm düzen türlerini içermediği bir durum.
        // Sunum dosyası yalnızca Boş ve Özel düzen türlerini içerir.
        // Ancak, özel türlere sahip düzen slaytları tanınabilir adlara sahip olabilir,
        // örneğin "Title", "Title and Content" vb., bu adlar düzen slaytı seçimi için kullanılabilir.
        // Ayrıca bir dizi yer tutucu şekil türüne dayanabilirsiniz.
        // Örneğin, bir Başlık slaytı yalnızca Başlık yer tutucu türüne sahip olmalıdır, vb.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Eklenen düzen slaytını kullanarak boş bir slayt ekleyin.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Sunumu diske kaydedin.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

Aspose.Slides, istenmeyen ve kullanılmayan düzen slaytlarını silmenizi sağlayan [Compress](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/) sınıfındaki [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini sunar.

Aşağıdaki PHP kodu, bir PowerPoint sunumundan bir düzen slaytının nasıl kaldırılacağını gösterir:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Düzen Slaytlarına Yer Tutucu Ekleme**

Aspose.Slides, bir düzen slaytına yeni yer tutucular eklemenizi sağlayan [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#getPlaceholderManager) yöntemini sunar.

Bu yönetici, aşağıdaki yer tutucu türleri için yöntemler içerir:

| PowerPoint Yer Tutucu               | [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/) Yöntemi |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Aşağıdaki PHP kodu, Boş düzen slaytına yeni yer tutucu şekilleri nasıl ekleyeceğinizi gösterir:

```php
$presentation = new Presentation();
try {
    // Boş düzen slaytını alın.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Düzen slaytının yer tutucu yöneticisini alın.
    $placeholderManager = $layout->getPlaceholderManager();

    // Boş düzen slaytına farklı yer tutucular ekleyin.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Boş düzen ile yeni bir slayt ekleyin.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![The placeholders on the layout slide](add_placeholders.png)

## **Bir Düzen Slaytı için Altbilgi Görünürlüğünü Ayarlama**

PowerPoint sunumlarında tarih, slayt numarası ve özel metin gibi altbilgi öğeleri, slayt düzenine bağlı olarak gösterilebilir veya gizlenebilir. Aspose.Slides for PHP, bu altbilgi yer tutucularının görünürlüğünü kontrol etmenizi sağlar. Bu, bazı düzenlerin altbilgi bilgilerini gösterirken diğerlerinin temiz ve sade kalmasını istediğinizde kullanışlıdır.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksiyle bir düzen slaytı referansı alın.  
1. Slayt altbilgi yer tutucusunu görünür olarak ayarlayın.  
1. Slayt numarası yer tutucusunu görünür olarak ayarlayın.  
1. Tarih‑zaman yer tutucusunu görünür olarak ayarlayın.  
1. Sunumu kaydedin.

Aşağıdaki PHP kodu, bir slayt altbilgisinin görünürlüğünü nasıl ayarlayacağınızı ve ilgili görevleri nasıl gerçekleştireceğinizi gösterir:

```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

## **Bir Slayt İçin Alt Çocuk Altbilgi Görünürlüğünü Ayarlama**

PowerPoint sunumlarında tarih, slayt numarası ve özel metin gibi altbilgi öğeleri, tüm düzen slaytlarında tutarlılığı sağlamak amacıyla ana slayt seviyesinde kontrol edilebilir. Aspose.Slides for PHP, bu altbilgi yer tutucularının görünürlüğünü ve içeriğini ana slaytta belirlemenize ve bu ayarları tüm çocuk düzen slaytlarına yaymanıza olanak tanır. Bu yaklaşım, sunumunuz boyunca tutarlı altbilgi bilgilerinin olmasını garantiler.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksiyle ana slayta bir referans alın.  
1. Ana slaytın ve tüm çocuk altbilgi yer tutucularının görünürlüğünü ayarlayın.  
1. Ana slaytın ve tüm çocuk slayt numarası yer tutucularının görünürlüğünü ayarlayın.  
1. Ana slaytın ve tüm çocuk tarih‑zaman yer tutucularının görünürlüğünü ayarlayın.  
1. Sunumu kaydedin.

Aşağıdaki PHP kodu bu işlemi gösterir:

```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Bir ana slayt ile bir düzen slaytı arasındaki fark nedir?**

Ana slayt genel temayı ve varsayılan biçimlendirmeyi tanımlarken, düzen slaytları farklı içerik türleri için yer tutucuların belirli düzenlemelerini tanımlar.

**Bir düzen slaytını bir sunumdan başka bir sunuma kopyalayabilir miyim?**

Evet, bir sunumun düzen slayt koleksiyonundan ( [getLayoutSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getLayoutSlides) yöntemiyle erişilebilir) bir düzen slaytını klonlayabilir ve `addClone` yöntemiyle başka bir sunuma ekleyebilirsiniz.

**Bir slayt tarafından hâlâ kullanılan bir düzen slaytını silersem ne olur?**

Eğer bir düzen slaytı, sunumdaki en az bir slayt tarafından hâlâ referans ediliyorsa, Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxeditexception/) fırlatır. Bunu önlemek için, yalnızca kullanılmayan düzen slaytlarını güvenle kaldıran [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini kullanın.