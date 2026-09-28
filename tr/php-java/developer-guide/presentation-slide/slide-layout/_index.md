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
- yalnızca başlık
- boş düzen
- başlıklı içerik
- başlıklı resim
- başlık ve dikey metin
- dikey başlık ve metin
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile slayt düzenlerini uygulayın, oluşturun ve değiştirin, yer tutucular ekleyin, kullanılmayan düzenleri kaldırın ve altbilgi görünürlüğünü kontrol edin."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzen uygulamak, slaytlara tutarlı bir yapı verir ve her slaytın kendi içeriğini içermesine izin verir.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusu içerir.
- **Boş**: İçerik yer tutucusu içermez ve her şeklin manuel olarak konumlandırılacağı durumlarda kullanışlıdır.

## **Düzen Kalıtımını Anlayın**

Bir sunum üç ilgili seviyeye sahiptir:

1. Bir [master slayt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) temayı, ortak biçimlendirmeyi, arka planları ve ortak nesneleri tanımlar.
1. Bir [düzen slaytı](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/) bir master’a aittir ve yer tutucuların belirli bir düzenini tanımlar.
1. Bir [normal slayt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/) bir düzen kullanır ve o slayt için girilen içeriği depolar.

Bir normal slayt temayı ve biçimlendirmeyi düzeninden devralır ve düzen master’dan devralır. Normal bir slaytta doğrudan ayarlanan bir değer, o seviyedeki devralınmış değeri geçersiz kılar. Bir normal slayt oluşturulduğunda, yer tutucu şekilleri seçilen düzen üzerinden oluşturulur, bu yer tutuculara girilen içerik ise normal slayta aittir.

Kaydırmalardan önce bir düzene gerekli yer tutucuları ekleyin. Bir düzene daha sonra başka bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişki iki önemli sonuca sahiptir:

- Bir düzen üzerindeki devralınmış biçimlendirmeyi veya mevcut yer tutucu geometrisini değiştirmek, ona bağlı tüm slaytları güncelleyebilir. Zaten kullanımda olan bir düzeni düzenlemeden önce, ona bağlı slaytları inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt tarafından hâlâ kullanılan bir düzen silinemez. Önce bağlı slaytlarını başka bir düzene atayın veya yalnızca kullanılmayan düzenleri kaldırın.

Bu hiyerarşinin üst seviyesi hakkında daha fazla bilgi için, [Slide Master](/slides/tr/php-java/slide-master/) bölümüne bakın.

Bir slaytta veya ortak bir düzen üzerinden devralınmış logoları ya da süsleme master şekillerini gizlemek için, [Control the Visibility of Master Graphics](/slides/tr/php-java/slide-master/) bölümüne bakın. Örnek aynı master’ı kullanan iki slaytı karşılaştırır.

## **Bir Slayt Düzeni Seçme ve Uygulama**

Sunum standart PowerPoint düzen tanımlarını izlediğinde bir düzen türü kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu yüzden ad temelli seçim, kaynak şablonu kontrol etmediğiniz sürece daha az güvenilirdir.

Aşağıdaki örnek, ilk master’da **Başlık ve İçerik** düzenini arar. Bu düzen bulunamazsa, bilerek **Boş**a geri döner. İkinci null kontrolü, bir sunumun yalnızca özel düzenler içerebilmesi nedeniyle gereklidir. Seçilen düzen daha sonra [Slide.setLayoutSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#setLayoutSlide) yöntemiyle ilk normal slayta uygulanır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bir slaytın düzenini değiştirmek, slayta doğrudan eklenen sıradan şekilleri kaldırmaz. Ancak, yer tutucu konumları, devralınmış biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki eşleşme değişebilir, bu yüzden önemli ölçüde farklı düzenler arasında geçiş yaparken çıktıyı inceleyin.

## **Bir Düzen Slaytı Ekle**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; bir tane oluşturmaz. Bir düzen oluşturmak için, hedef masterın düzen koleksiyonunda [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterlayoutslidecollection/#add) metodunu çağırın.

Aşağıdaki örnek her zaman `Report Title and Content` adlı yeni bir **Başlık ve İçerik** düzeni ekler, ardından ona dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyduğunda bir düzen ekleyin. Uygun bir düzen zaten varsa, bir kopya oluşturmaktansa onu seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucular Ekle**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#getPlaceholderManager) yöntemi, bir düzene yer tutucu şekilleri eklemek için bir [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/) sağlar.

| PowerPoint Yer Tutucu              | `LayoutPlaceholderManager` Metodu |
| ----------------------------------- | --------------------------------- |
| ![İçerik](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![İçerik (Dikey)](contentV.png)    | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Metin](text.png)                 | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Metin (Dikey)](textV.png)        | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Resim](picture.png)              | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Grafik](chart.png)               | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tablo](table.png)                | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)          | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Medya](media.png)                | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Çevrimiçi Görüntü](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Aşağıdaki örnek **Boş** düzeninin mevcut olduğunu doğrular, ona dört yer tutucu ekler ve ardından değiştirilen düzeni kullanan bir normal slayt oluşturur. Sıra kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slaytta ilgili yer tutucu şekillerini oluşturabilir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sonuç:

![Düzen slaydındaki yer tutucular](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Devralınmış biçimlendirmeyi veya mevcut düzen yer tutucularının geometrisini değiştirmek, bağımlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu mevcut normal slaytlara geriye doğru doldurulmaz. Düzen değişikliklerini sunumun bir kopyası üzerinde test edin ve her bağımlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldır**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) metodunu, hiçbir normal slaytın referans göstermediği düzenleri kaldırmak için kullanın. Metod, hâlâ kullanımda olan düzenleri olduğu gibi bırakır.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Belirli bir düzeni kaldırmak için önce onun [hasDependingSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#hasDependingSlides) veya [getDependingSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#getDependingSlides) metodunu kullanın. [LayoutSlide.remove](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#remove) metodunu çağırmadan önce bağımlı slaytları yeniden atayın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxeditexception/) hatası oluşturur.

## **Bir Düzen Slaytında Altbilgi Görünürlüğünü Kontrol Et**

Bir düzenin kendi altbilgisi, slayt numarası ve tarih‑saat yer tutucuları vardır. Bu yer tutucuları bir düzen için kontrol etmek üzere [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) metodunu kullanın. Bu, örneğin içerik düzenlerinin altbilgi göstermesi, başlık düzenlerinin ise göstermemesi gerektiğinde faydalıdır.

Aşağıdaki örnek bir düzeni güvenli bir şekilde seçer ve altbilgi öğelerini görünür kılar:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bir Master ve Çocuk Düzenlerinde Altbilgi Görünürlüğünü Kontrol Et**

Bir master hiyerarşisi boyunca tutarlı altbilgi ayarları uygulamak için [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/#getHeaderFooterManager) metodunu kullanın. [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslideheaderfootermanager/) sınıfının yayılım metodları, master ve ona bağlı düzen slaytları ve normal slaytlar üzerinde çalışır; yalnızca tek bir normal slaytı hedeflemez.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Master Slayt ile Layout Slayt Arasındaki Fark Nedir?**

Bir master slayt, sunumun temasını ve ortak biçimlendirmeyi tanımlar. Bir layout slayt bir master’a aittir ve yer tutucuların yeniden kullanılabilir bir düzenini tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği depolar.

**Bir Layout Slaytı bir Sunumdan Diğerine Kopyalayabilir miyim?**

Evet. Hedef koleksiyona bir kopyasını [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/globallayoutslidecollection/#addClone) yöntemiyle ekleyin. Sunumlar arasında kopyalama yaparken, kaynak düzenin kullandığı fontları, temaları, görselleri ve diğer kaynakları da doğrulayın.

**Zaten Kullanımda Olan Bir Düzeni Değiştirdiğimde Ne Olur?**

Bağımlı slaytlar, yerel olarak etkilenmiş biçimlendirmeyi veya nesneleri geçersiz kılmadıkça, düzen değişikliklerini devralır. Yer tutucu geometrisi ve devralınan stil bu nedenle birden çok slaytta aynı anda değişebilir. Düzeni düzenlemeden önce etkilenen slaytları belirlemek için [getDependingSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#getDependingSlides) yöntemini kullanın.

**Hâlâ Kullanımda Olan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxeditexception/) hatası fırlatır. Önce bağımlı slaytları yeniden atayın veya yalnızca referans verilmeyen düzenleri kaldırmak için [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini kullanın.