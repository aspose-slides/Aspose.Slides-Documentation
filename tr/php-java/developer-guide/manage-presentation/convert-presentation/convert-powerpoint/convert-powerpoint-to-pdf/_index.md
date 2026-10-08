---
title: PHP'de PPT ve PPTX'i PDF'ye Dönüştürün [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/php-java/convert-powerpoint-to-pdf/
keywords:
  - PowerPoint dönüştür
  - sunumu dönüştür
  - PowerPoint PDF'ye
  - sunum PDF'ye
  - PPT PDF'ye
  - PPT'yi PDF'ye dönüştür
  - PPTX PDF'ye
  - PPTX'i PDF'ye dönüştür
  - PowerPoint'i PDF olarak kaydet
  - PPT'yi PDF olarak kaydet
  - PPTX'i PDF olarak kaydet
  - PPT'yi PDF'ye dışa aktar
  - PPTX'i PDF'ye dışa aktar
  - ek
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - PHP
  - Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de PowerPoint PPT/PPTX dosyalarını yüksek kalitede, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PHP'de PowerPoint sunumlarını (PPT, PPTX, ODP vb.) PDF formatına dönüştürmek, farklı cihazlarla uyumluluk ve sunumunuzun düzeni ve biçimlendirmesinin korunması gibi çeşitli avantajlar sunar. Bu rehber, sunumları PDF belgelerine dönüştürmeyi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri kullanmayı, gizli slaytları dahil etmeyi, PDF dosyalarını parola ile korumayı, yazı tipi ikamelerini tespit etmeyi, belirli slaytları dönüştürmek için seçmeyi ve çıktıya uyumluluk standartları uygulamayı göstermektedir.

## **PowerPoint'tan PDF Dönüşümleri**

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için, dosya adını bir argüman olarak [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfına geçirin ve ardından sunumu PDF olarak bir [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) yöntemiyle kaydedin. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) yöntemini ortaya çıkarır.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java, API bilgilerini ve sürüm numarasını çıktı belgelerine ekler. Örneğin, bir sunumu PDF'ye dönüştürürken, Aspose.Slides Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde bir değerle doldurur. **Note** Aspose.Slides'in bu bilgiyi çıktı belgelerinden değiştirmesini veya kaldırmasını sağlayamazsınız.
{{% /alert %}}

Aspose.Slides, şunları dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Belirli slaytları bir sunumdan PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktarırken, oluşturulan PDF'lerin orijinal sunumlara olabildiğince yakın olmasını sağlar. Dönüşüm sırasında aşağıdaki öğeler ve nitelikler doğru bir şekilde işlenir:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirmesi
* Paragraf biçimlendirmesi
* Hipermetin bağlantıları
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint'tan PDF'ye dönüştürme işlemi varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides sağlanan sunumu maksimum kalite seviyelerinde optimum ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek bir sunumu yükler ve varsayılan dışa aktarma ayarlarını kullanarak tüm görünen slaytları PDF olarak kaydeder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose, sunumdan PDF'ye dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint'tan PDF dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulaması için bu dönüştürücüyle bir test çalıştırabilirsiniz.
{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, sonuç PDF'yi özelleştirmenize, PDF'yi bir parola ile kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanıyan [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfı altındaki özel seçenekler—özellikler—sunar.

### **PowerPoint'i PDF'ye Özel Seçeneklerle Dönüştür**

Aşağıdaki örnek bir sunumu PDF 1.5 formatında, JPEG kalitesi %90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilmiş ve Flate metin sıkıştırması uygulanmış olarak dışa aktarır.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru**

Bir sunum gömülü bir Excel çalışma kitabı içeriyorsa, PDF alıcılarının çalışma kitabının verilerine erişmesini ve slaytları görüntülemesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak korumak için [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) yöntemini `true` ile çağırın.

Varsayılan değer `false`'tır: OLE nesnesinin önizleme görseli veya simgesi PDF sayfasında görüntülenir, ancak gömülü dosya ek olarak dahil edilmez. Seçenek `true` olarak ayarlandığında dosya verileri eklenir. Önizleme görsel bir temsil olarak kalır; ek, alıcıların gömülü dosyayı ayrı ayrı açıp kaydetmesini sağlar. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, zaten gömülü bir Excel çalışma kitabı içeren bir sunumu yükler ve çalışma kitabı ekli olarak PDF'ye dışa aktarır.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Sonucu kontrol etmek için:

1. Export edilen PDF'i ekleri destekleyen bir görüntüleyicide, örneğin Adobe Acrobat Reader'da açın.
2. Görüntüleyicinin **Attachments** panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve verilerini incelemek için Excel'de açın, ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki önizleme ek'ten ayrı bir öğedir.

{{% alert color="info" title="Note" %}}
PDF/A standartları ekler üzerinde kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 sadece PDF/A eklerine izin verir, ve PDF/A-3 diğer dosya türlerini, Excel çalışma kitapları dahil, izin verir. Bunlar standartların gereksinimleridir, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarmasını göstermemektedir.
{{% /alert %}}

### **PowerPoint'i Gizli Slaytlarla PDF'ye Dönüştür**

Bir sunum gizli slaytlar içeriyorsa, gizli slaytları sonuç PDF'de sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) yöntemini kullanabilirsiniz.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **PowerPoint'i Parola Korumalı PDF'ye Dönüştür**

Aşağıdaki örnek, açmak için `password` parolasını gerektiren bir PDF olarak sunumu dışa aktarır. Erişim izinleri, yüksek kaliteli baskı da dahil olmak üzere yazdırmaya izin verir.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Yazı Tipi İkamelerini Algıla**

Aspose.Slides, sunumdan PDF'ye dönüşüm sırasında yazı tipi ikamelerini algılamanızı sağlayan [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfı altındaki [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) yöntemini sunar.

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır ve yazı tipi ikameleri uyarılarını konsola yazar. Bir uyarı yalnızca mevcut olmayan bir yazı tipi dışa aktarım sırasında ikame edildiğinde görüntülenir.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Yazı tipi ikameleri hakkında daha fazla bilgi için, [Font Substitution](/slides/tr/php-java/font-substitution/) makalesine bakın.
{{% /alert %}}

### **Ayrı Bir Bold Yazı Tipi Olmayan Yazı Tiplerini İşle**

Bir sunum, ayrı bir bold yazı tipi olmayan bir yazı tipine bold biçimlendirme uygulayabilir. Metin, normal glifleri yapay olarak kalınlaştırarak bold görünebilir. Bu metin PDF'de çok ağır ya da beklenen görünümden farklıysa, [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) yöntemini `true` ile çağırmayı deneyin. Bu seçenek, PDF dışa aktarımı sırasında ilgili metni bitmap olarak işler ve belirli yazı tipleri için görünümünü iyileştirebilir. Varsayılan değeri `false`'tır.

Örnek sunum iki metin kutusu içerir: biri normal metin, diğeri aynı yazı tipine bold biçimlendirme uygulanmış ancak ayrı bir bold yazı tipine sahip olmayan metin. Aşağıdaki örnek sunumu yükler, desteklenmeyen font stillerinin rasterleştirilmesini etkinleştirir ve PDF'ye dışa aktarır:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Aşağıdaki ön izlemeler devre dışı ve etkin çıktıyı gösterir. Bu örnekte, seçenek devre dışı bırakıldığında bold metnin çizgileri daha kalın görünür. Seçenek etkin olduğunda çizgileri daha hafiftir; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`false`, varsayılan) | Seçenek etkin (`true`) |
|---|---|
| ![Desteklenmeyen yazı tipi stili rasterleştirme devre dışı bırakılmış PDF](unsupported-bold-disabled.png) | ![Desteklenmeyen yazı tipi stili rasterleştirme etkin PDF](unsupported-bold-enabled.png) |

Bu örnekte, seçenek etkinleştirildiğinde yalnızca bold metin bitmap olur: OCR olmadan seçilemez, kopyalanamaz veya metin olarak aranamaz ve kenarları %800 yakınlaştırmada daha yumuşak görünür. Normal metin araştırılabilir kalır. Seçenek devre dışı olduğunda, iki dize de metin olarak kalır.

Bu seçenek, ayrı bir bold yazı tipi olmayan yazı tiplerinde bold olarak biçimlendirilmiş metni bitmap'e dönüştürür. [Font Substitution](/slides/tr/php-java/font-substitution/) ise orijinal yazı tipi mevcut değilse başka bir font seçer.

## **PowerPoint'tan Seçili Slaytları PDF'ye Dönüştür**

Aşağıdaki örnek bir sunumdan 1 ve 3 numaralı slaytları PDF'ye dışa aktarır. Bu dizideki slayt numaraları 1 tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **PowerPoint'i Özel Slayt Boyutuyla PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumun ilk slaytını 612 × 792 puan (8,5 × 11 inç) slayt boyutuna sahip yeni bir sunuma kopyalar. Slayt içeriğini sığdıracak şekilde ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Yeni oluşturulan sunumdaki boş slaytı kaldır.
    
    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Not Slayt Görünümünde PowerPoint'i PDF'ye Dönüştür**

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır; her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. PowerPoint belgesini PDF'ye, **PDF/A1a**, **PDF/A1b** ve **PDF/UA** gibi uyumluluk standartlarından birini kullanarak dışa aktarabilirsiniz.

Bu kod, farklı uyumluluk standartlarına göre birden fazla PDF üretmek üzere bir PowerPoint‑to‑PDF dönüşüm sürecini gösterir:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides, PDF dönüşüm işlemlerini destekler; PDF dosyalarını popüler dosya formatlarına dönüştürmenize izin verir. [PDF'den HTML'e](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF'den görüntüye](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF'den JPG'e](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) ve [PDF'den PNG'e](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) dönüşümleri yapabilirsiniz. Diğer PDF dönüşüm işlemleri—[PDF'den SVG'ye](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF'den TIFF'e](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), ve [PDF'den XML'e](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—da desteklenir.
{{% /alert %}}

> **Not:** PDF/UA olarak dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir figür olarak işler. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün figür için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides, birden fazla PPT veya PPTX dosyasını PDF’ye toplu olarak dönüştürmeyi destekler. Dosyalarınızı döngü içinde işleyerek programatik olarak dönüşüm sürecini uygularsınız.

**Dönüştürülen PDF'yi parola ile koruyabilir miyim?**

Evet. Dönüşüm sırasında bir parola belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfını kullanabilirsiniz.

**Gizli slaytları PDF'ye nasıl dahil edebilirim?**

Gizli slaytları sonuç PDF'ye eklemek için [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) yöntemini `true` olarak ayarlayın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, PDF'nizde yüksek kaliteli görüntüler sağlamak için [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfındaki [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) ve [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) gibi yöntemleri kullanarak görüntü kalitesini kontrol edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, belgelerinizin erişilebilirlik ve arşiv gereksinimlerini karşılamasını sağlayan **PDF/A1a**, **PDF/A1b** ve **PDF/UA** gibi [çeşitli standartlara](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) uygun PDF'ler dışa aktarmanıza izin verir.

## **Ek Kaynaklar**

- [Aspose.Slides for PHP via Java Dokümantasyonu](/slides/tr/php-java/)
- [Aspose.Slides for PHP via Java API Referansı](https://reference.aspose.com/slides/php-java/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)