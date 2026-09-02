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
- başlıkla içerik
- başlıkla resim
- başlık ve dikey metin
- dikey başlık ve metin
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da slayt düzenlerini uygulayın, oluşturun ve değiştirin, yer tutucular ekleyin, kullanılmayan düzenleri kaldırın ve altbilgi görünürlüğünü kontrol edin."
---
## **Genel Bakış**

Bir slayt düzeni, başlıklar, metin, resimler, grafikler ve tablolar gibi yer tutucuların konumlarını ve biçimlendirmesini tanımlar. Bir düzen uygulamak, slaytlara tutarlı bir yapı kazandırırken her slaytın kendi içeriğini içermesine olanak tanır.

En yaygın düzenler şunlardır:

- **Başlık Slaytı**: Başlık ve alt başlık yer tutucularını içerir.
- **Başlık ve İçerik**: Bir başlık yer tutucusu ve genel amaçlı bir içerik yer tutucusu içerir.
- **Boş**: İçerik yer tutucusu içermez ve her şeklin manuel olarak konumlandırılacağı durumlarda yararlıdır.

## **Düzen Kalıtımını Anlamak**

Bir sunum üç ilgili seviyeye sahiptir:

1. Bir [master slayt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) tema, ortak biçimlendirme, arka planlar ve ortak nesneleri tanımlar.
2. Bir [düzen slaytı](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/) bir master'a aittir ve yer tutucuların belirli bir düzenini tanımlar.
3. Bir [normal slayt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/) bir düzen kullanır ve o slayt için girilen içeriği depolar.

Bir normal slayt temayı ve biçimlendirmeyi düzeninden devralır ve düzen de master’dan devralır. Normal bir slaytta doğrudan ayarlanan bir değer, o seviyedeki devralınan değeri geçersiz kılar. Bir normal slayt oluşturulduğunda, yer tutucu şekilleri seçilen düzen üzerinden oluşturulur, bu yer tutuculara girilen içerik ise normal slayta aittir.

Bir slayt oluşturmadan önce gerekli yer tutucuları bir düzene ekleyin. Daha sonra bir düzene başka bir yer tutucu eklemek, mevcut normal slaytlara otomatik olarak karşılık gelen bir yer tutucu şekli eklemez.

Bu ilişkinin iki önemli sonucu vardır:

- Bir düzende devralınan biçimlendirmeyi veya mevcut yer tutucu geometrisini değiştirmek, ona bağımlı tüm slaytları güncelleyebilir. Zaten kullanımdaki bir düzeni düzenlemeden önce, bağımlı slaytlarını inceleyin ve ortaya çıkan sunumu gözden geçirin.
- Bir slayt tarafından hâlâ kullanılan bir düzen kaldırılamaz. Önce bağlı slaytlarını başka bir düzenle yeniden atayın ya da yalnızca kullanılmayan düzenleri kaldırın.

Daha fazla bilgi için hiyerarşinin üst seviyesine bakın: [Slide Master](/slides/tr/php-java/slide-master/).

## **Bir Slayt Düzeni Seçme ve Uygulama**

Sunum standart PowerPoint düzen tanımlarını izlediğinde bir düzen türü kullanın. Düzen adları kullanıcı tarafından düzenlenebilir ve yerelleştirilebilir, bu yüzden ad temelli seçim, kaynak şablonun kontrolü elinizde değilse daha az güvenilirdir.

İşte sonraki örnek, ilk master’da **Title and Content** düzenini arar. Bu düzen bulunamazsa, kasıtlı olarak **Blank** düzenine geri döner. İkinci null kontrolü, bir sunumun yalnızca özel düzenler içerebileceği için gereklidir. Seçilen düzen, ardından [Slide.setLayoutSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#setLayoutSlide) yöntemiyle ilk normal slayta uygulanır.

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

Bir slaytın düzenini değiştirmek, slayta doğrudan eklenen normal şekilleri kaldırmaz. Ancak, yer tutucu konumları, devralınan biçimlendirme ve mevcut yer tutucular ile yeni düzen arasındaki eşleşme değişebilir; bu yüzden önemli ölçüde farklı düzenler arasında geçiş yaparken çıktıyı inceleyin.

## **Bir Düzen Slaytı Ekleme**

Seçim ve oluşturma ayrı işlemlerdir. Önceki örnek mevcut bir düzeni seçer; bir tane oluşturmaz. Bir düzen oluşturmak için, hedef master’ın düzen koleksiyonunda [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterlayoutslidecollection/#add) yöntemini çağırın.

Aşağıdaki örnek her zaman `Report Title and Content` adlı yeni bir **Title and Content** düzeni ekler, ardından buna dayalı bir normal slayt ekler. Düzen adları koleksiyon içinde benzersiz olmalıdır.

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

Şablon gerçekten başka bir yeniden kullanılabilir yapıya ihtiyaç duyduğunda yalnızca bir düzen ekleyin. Uygun bir düzen zaten varsa, bir kopya oluşturmaktan ziyade onu seçip yeniden kullanın.

## **Bir Düzen Slaytına Yer Tutucu Ekleme**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#getPlaceholderManager) yöntemi, bir düzene yer tutucu şekilleri eklemek için bir [LayoutPlaceholderManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutplaceholdermanager/) sunar.

| PowerPoint Yer Tutucu              | `LayoutPlaceholderManager` Method |
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

Aşağıdaki örnek **Blank** düzeninin mevcut olduğunu doğrular, ona dört yer tutucu ekler ve ardından değiştirilmiş düzeni kullanan bir normal slayt oluşturur. Sıra kasıtlıdır: yer tutucular normal slayt oluşturulmadan önce eklenir, böylece Aspose.Slides o slaytta ilgili yer tutucu şekilleri oluşturabilir.

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

![Düzen slaytındaki yer tutucular](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Devralınan biçimlendirmenin veya mevcut düzen yer tutucularının geometrisinin değiştirilmesi, bağımlı slaytları etkileyebilir. Yeni eklenen bir düzen yer tutucusu mevcut normal slaytlara otomatik olarak eklenmez. Düzen değişikliklerini bir sunum kopyası üzerinde test edin ve her bağımlı slaytı inceleyin.
{{% /alert %}}

## **Kullanılmayan Düzen Slaytlarını Kaldırma**

Hiçbir normal slaytın referans vermediği düzenleri kaldırmak için [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) yöntemini kullanın. Yöntem hâlâ kullanılan düzenleri olduğu gibi bırakır.

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

Belirli bir düzeni kaldırmak için önce onun [hasDependingSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#hasDependingSlides) veya [getDependingSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#getDependingSlides) yöntemini kullanın. [LayoutSlide.remove](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#remove) çağırmadan önce bağımlı slaytları yeniden atayın. Kullanılan bir düzeni kaldırmaya çalışmak bir [PptxEditException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxeditexception/) istisnası fırlatır.

## **Bir Düzen Slaytında Altbilgi Görünürlüğünü Kontrol Etme**

Bir düzenin kendi altbilgi, slayt numarası ve tarih-saat yer tutucuları vardır. Bu yer tutucuları bir düzen için kontrol etmek üzere [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) yöntemini kullanın. Bu, örneğin içerik düzenlerinin altbilgi göstermesi, başlık düzenlerinin ise göstermemesi gerektiğinde faydalıdır.

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

## **Bir Master ve Çocuk Düzenlerinde Altbilgi Görünürlüğünü Kontrol Etme**

Bir master hiyerarşisi boyunca tutarlı altbilgi ayarları uygulamak için [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/#getHeaderFooterManager) yöntemini kullanın. [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslideheaderfootermanager/) yayma yöntemleri master, ona bağlı düzen slaytları ve normal slaytlar üzerinde çalışır; yalnızca tek bir normal slaytı hedef almaz.

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

## **FAQ**

**Master Slaytı ile Layout Slaytı Arasındaki Fark Nedir?**

Bir master slayt, sunumun temasını ve ortak biçimlendirmesini tanımlar. Bir layout slaytı bir master’a aittir ve yer tutucuların yeniden kullanılabilir bir düzenini tanımlar. Normal slaytlar bu düzenleri kullanır ve slayta özgü içeriği depolar.

**Bir Layout Slaytı bir Sunumdan Başka Bir Sunuma Kopyalayabilir miyim?**

Evet. [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/globallayoutslidecollection/#addClone) yöntemiyle hedef koleksiyona bir kopya ekleyin. Sunumlar arasında kopyalarken, kaynak düzenin kullandığı yazı tiplerini, temaları, görselleri ve diğer kaynakları da doğrulayın.

**Zaten Kullanımdaki Bir Düzeni Değiştirirsem Ne Olur?**

Bağımlı slaytlar, yerel olarak etkilenen biçimlendirmeyi veya nesneleri geçersiz kılmadıkları sürece düzen değişikliklerini devralır. Bu nedenle yer tutucu geometrisi ve devralınan stil birçok slaytta aynı anda değişebilir. Düzeni düzenlemeden önce etkilenen slaytları belirlemek için [getDependingSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#getDependingSlides) kullanın.

**Hâlâ Kullanımda Olan Bir Düzeni Kaldırırsam Ne Olur?**

Aspose.Slides bir [PptxEditException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxeditexception/) istisnası fırlatır. Önce bağımlı slaytları yeniden atayın ya da yalnızca başvurulmamış düzenleri kaldırmak için [removeUnusedLayoutSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) kullanın.