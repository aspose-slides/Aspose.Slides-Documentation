---
title: PHP'de Not Sayfası Boyutunu ve Yönünü Değiştir
linktitle: Not Sayfası Boyutu
type: docs
weight: 10
url: /tr/php-java/notes-size/
keywords:
- not sayfası boyutu
- not yönü
- yatay notlar
- dikey notlar
- el ilanı boyutu
- PowerPoint
- sunum
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da not sayfası boyutlarını okuyun ve değiştirin, yönü değiştirin, kaydedilen boyutları doğrulayın ve notları ya da el ilanlarını PDF ve görsellere dışa aktarın."
---
## **Genel Bakış**

Sunumun not sayfası ayarlarına erişmek için [Presentation::getNotesSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getnotessize/) kullanın. Bu, sayfa boyutlarını ayarlayan [setSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notessize/setsize/) metoduna sahip bir [NotesSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notessize/) nesnesi döndürür. Ayar nesnesi kendisi değiştirilemezken, bu metod aracılığıyla yeni boyutlar atanabilir.

Genişlik ve yükseklik **nokta** cinsinden belirtilir; inç başına 72 nokta vardır. Örneğin, 900 × 600 nokta 12,5 × 8⅓ inçtir. Bu ayarlar, bir slaytın notlarından ziyade sunuma uygulanır.

| Ayar | Amaç |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getnotessize/) | Not sayfası boyutlarını ve el ilanı dışa aktarımında kullanılan sayfa boyutlarını kontrol eder. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getslidesize/) | Normal sunum slaytı boyutlarını [SlideSize](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidesize/) aracılığıyla kontrol eder. |

Bu ayarlardan birini değiştirmek diğerini otomatik olarak değiştirmez. Not sayfası yönünü değiştirmek de normal slaytları döndürmez. Normal slaytları yeniden boyutlandırmak için [Slide Size](/slides/tr/php-java/slide-size/) sayfasına bakın.

Aşağıdaki örnekler mevcut bir `sample.pptx` dosyasını kullanır. Dışa aktarım örnekleri için en az bir slaytta konuşmacı notları bulunan bir sunum kullanın. Her örnek, PHP/Java Bridge ve Aspose.Slides PHP sarmalayıcısı yüklendikten sonra bağımsız olarak çalıştırılabilir. Java tarafından döndürülen sayısal değerler, karşılaştırma veya hesaplama öncesinde `java_values` ile PHP değerlerine dönüştürülür.

## **Not Sayfası Boyutunu ve Yönünü Okuma**

Genişliği ve yüksekliği okuyup karşılaştırarak yönü belirleyin: daha geniş bir sayfa yatay (landscape), daha uzun bir sayfa dikey (portrait) ve eşit boyutlar kare bir sayfayı tanımlar. Bu örnek, standart bir kağıt boyutu varsaymadan gerçek boyutları nokta cinsinden yazdırır.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Kağıt Boyutunu Değiştirmeden Yatay Konuma Geçiş**

Yalnızca yönü değiştirmek için mevcut genişlik ve yüksekliği değiştirin. Bu, özel bir kağıt boyutu da dahil olmak üzere her iki kenarın uzunluğunu korur. Aşağıdaki koşul, zaten yatay bir sayfanın tekrar dikeye dönmesini engeller ve kare bir sayfayı değiştirmez.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dikey yön için aynı atamayı `java_values($size->getWidth()) > java_values($size->getHeight())` durumunda kullanın. Kağıt boyutunu da değiştirmek istemiyorsanız A4 veya Letter boyutlarını değiştirmeyin.

## **Özel Not Sayfası Boyutunu Ayarlama ve Doğrulama**

Her iki boyutu birden atayın, ardından sunumu kaydetmek için [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/save/) kullanın. Bu örnek, 900 × 600 nokta yatay bir sayfa ayarlar, PPTX olarak kaydeder ve kaydedilen dosyayı tekrar açarak kalıcı değerleri kontrol eder. Karşılaştırma, kayan nokta değerleri için 0,01 nokta toleransına izin verir; bu, her dosya formatı için kesinlik garantisi değildir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Beklenen sonuç `900 x 600 points` ve `Size preserved: true` dır. Yeni açılan bir sunumu kontrol etmek, yalnızca bellek içi ayarları değil, kaydedilmiş dosyayı da doğrular.

## **Notları ve El İlanlarını Dışa Aktarma**

Sayfa boyutları, notlar veya el ilanı düzenleri için kullanılabilir alanı tanımlar. Bu düzenleri yalnızca sayfa boyutlarıyla etkinleştirmez; dışa aktarım seçeneklerini de yapılandırmanız gerekir. Normal slayt dışa aktarımı, slayt boyutlarını kullanmaya devam eder.

### **Notları PDF ve PNG Olarak Dışa Aktarma**

Notları PDF’e eklemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notescommentslayoutingoptions/) nesnesini [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) ile atayın. Bu örnek ayrıca ilk slaytı notlarıyla birlikte PNG’ye render eder; bunu [Slide::getImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getImage) ve [RenderingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/renderingoptions/) kullanarak yapar.

[BottomTruncated](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notespositions/) modu, notları tek bir sayfada tutar; sığmayan notlar kırpılabilir. PDF, 900 × 600 nokta sayfalar kullanır. Aşağıda kullanılan 1 × 1 görüntü ölçeğinde PNG 900 × 600 piksel olur. Noktalar sayfa geometrisini, pikseller ise raster çıktıyı tanımlar; piksel boyutları ayrıca render ölçeğine bağlıdır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Uzun notlarla PDF dışa aktarımı için [BottomFull](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notespositions/) ek sayfalar eklenmesine izin verir. Yukarıdaki tek‑slayt görüntü çağrısı bu modu desteklemediği için kullanmayın. Boyutları yeniden ayarladıktan sonra kırpılmış notlar ve mevcut notes‑master nesnelerinin yerleşimini inceleyin; sadece sayfa boyutlarını değiştirmek, tüm içeriğin sığacağını garanti etmez. Not dışa aktarımı hakkında daha fazla bilgi için [Convert PowerPoint to PDF with Notes](/slides/tr/php-java/convert-powerpoint-to-pdf-with-notes/) sayfasına bakın.

### **El İlanlarını PDF Olarak Dışa Aktarma**

Bir sayfada birden çok slayt küçük resmi oluşturmak için [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/handoutlayoutingoptions/) kullanın. Aşağıdaki örnek, 900 × 600 nokta bir sayfa ayarlar ve bir sayfada dört slayta kadar yerleştirmek için [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/tr/php-java/aspose.slides/handouttype/) kullanır. Yatay ön ayar slayt sıralamasını kontrol eder; sayfa yönü genişlik ve yükseklik değerlerinden gelir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Sayfa boyutunu değiştirmek, kaynak slaytların boyutunu etkilemeden el ilanı ızgarası için kullanılabilir alanı değiştirir. El ilanı görüntüleri için el ilanı düzeniyle birlikte [Presentation::getImages](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getimages/) kullanın; bireysel bir slaytın image metodu el ilanı sayfası üretmez. Aspose.Slides'ta sunum‑seviyesi el ilanı render’ı not sayfası boyutlarını kullanırken, bireysel slayt görüntüsü bu sayfa boyutlarını dikkate almaz. Düzen seçenekleri için [Handout Mode](/slides/tr/php-java/convert-powerpoint-in-handout-mode/) sayfasına bakın.

## **Görüntüleyicilerde, Dışa Aktarmada ve Yazdırmada Sayfa Boyutu**

Kayıtlı sunum boyutu, dışa aktarılan sayfa boyutu ve yazdırılan kağıt boyutu ayrı tutulmalıdır:

- **Sunum görüntüleyicileri:** Bir görüntüleyici, notları kendi düzen kurallarıyla gösterebilir veya yazdırabilir. Başka bir uygulama dosyayı kaydederse, yeniden açın ve boyutları tekrar kontrol edin; o uygulamanın format dönüşümü değerleri normalleştirebilir.
- **Dışa aktarım biçimleri:** Yukarıdaki not ve el ilanı PDF örnekleri, yapılandırılmış sayfa boyutlarını kullanır. Raster görüntüler tamsayı piksel boyutları ve render ölçeği kullanır; bu nedenle kesirli nokta değerleri görüntü çıktısında yuvarlanabilir. Normal slaytların dışa aktarımı not sayfası boyutunu uygulamaz.
- **Yazıcı sürücüleri:** Kağıt seçimi, otomatik döndürme ve sayfaya sığdırma ayarları, sunumda veya PDF’de depolanan boyutları değiştirmeden fiziksel çıktıyı değiştirebilir. Belirli bir kağıt boyutu için, yazıcı ayarlarıyla eşleştirin ve yazdırma ön izlemesini inceleyin.

## **SSS**

**Sadece bir slayt için not boyutunu ayarlayabilir miyim?**

Not sayfası boyutu, sunum‑seviyesi bir ayardır. Bireysel slaytların farklı not içerikleri olabilir, ancak bu özellik her slayt için ayrı bir sayfa boyutu sağlamaz.

**Neden not yönünü değiştirdiğimde slaytlarım değişmedi?**

Not sayfaları ve normal slaytlar bağımsız boyutlara sahiptir. Slaytların kendisini yeniden boyutlandırmak istediğinizde, normal slayt boyutu ayarlarını kullanın.

**Kaydedilen veya yazdırılan sonuç farklı bir boyutta neden görünüyor?**

Önce kaydedilen sunumu yeniden açıp not boyutlarını karşılaştırın. Eğer bu değerler değiştiyse, dosyayı başka bir uygulamada kaydetmenin veya dönüştürmenin sayfa ayarlarını değiştirmiş olabileceğini kontrol edin. Değişmedi ise dışa aktarım düzenini, görüntü ölçeğini, görüntüleyici ayarlarını ve yazıcı kağıt seçimini inceleyin.