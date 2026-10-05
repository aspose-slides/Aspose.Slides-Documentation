---
title: PHP'de PPT ve PPTX'yi PDF'ye Dönüştür [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint'ten PDF'ye
type: docs
weight: 40
url: /tr/php-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- PowerPoint'ten PDF'ye
- sunumu PDF'ye
- PPT'den PDF'ye
- PPT'yi PDF'ye dönüştür
- PPTX'den PDF'ye
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
description: "Aspose.Slides kullanarak PHP'de PowerPoint PPT/PPTX dosyalarını yüksek kaliteli, aranabilir PDF'lere dönüştürün; hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleri ile."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) PHP'de PDF formatına dönüştürmek, farklı cihazlarda uyumluluk ve sunumunuzun düzeni ile biçimlendirmesinin korunması gibi çeşitli avantajlar sağlar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını şifre korumalı hale getirmeyi, yazı tipi ikamelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF Dönüşümleri**

Aspose.Slides kullanarak, aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için, dosya adını [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından sunumu bir [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) yöntemi kullanarak PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) yöntemini sunar.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java, çıktı belgelerine API bilgilerini ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken, Aspose.Slides Application (Uygulama) alanını "*Aspose.Slides*" ve PDF Producer (PDF Üreticisi) alanını "*Aspose.Slides v XX.XX*" şeklinde bir değerle doldurur. **Not** bu bilgiyi çıktı belgelerinden değiştirmek veya kaldırmak için Aspose.Slides'e talimat veremezsiniz.
{{% /alert %}}

Aspose.Slides size şunları dönüştürme imkanı verir:

* Tam sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides sunumları PDF'ye dışa aktarır ve oluşan PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru bir şekilde işlenir, şunlar dahil:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üstbilgi ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'ten PDF'ye Dönüştür**

Standart PowerPoint'ten PDF'ye dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek bir sunumu yükler ve tüm görünür slaytları varsayılan dışa aktarma ayarlarını kullanarak PDF olarak kaydeder.

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
Aspose, sunumdan PDF'ye dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint'ten PDF dönüştürücü**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulaması için bu dönüştürücüyle bir test çalıştırabilirsiniz.
{{% /alert %}}

## **Seçeneklerle PowerPoint'ten PDF'ye Dönüştür**

Aspose.Slides, oluşturulan PDF'yi özelleştirmenize, PDF'yi bir şifre ile kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirtmenize olanak tanıyan özel seçenekler—[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfının özellikleri—sağlar.

### **Özel Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Özel dönüşüm seçeneklerini kullanarak raster görüntüler için tercih ettiğiniz kalite ayarını belirleyebilir, metafile'ların nasıl işleneceğini söyleyebilir, metin için sıkıştırma düzeyini ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki örnek, JPEG kalitesi %90, görüntü çözünürlüğü 300 DPI, metafile'ların PNG olarak kaydedildiği ve Flate metin sıkıştırması kullanılan bir PDF 1.5'e bir sunumu dışa aktarır.

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

Bir sunumda gömülü bir Excel çalışma kitabı varsa, PDF alıcılarının hem çalışma kitabının verilerine erişmesini hem de slaytları görmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ek olarak korumak için [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) yöntemini `true` ile çağırın.

Varsayılan değer `false`tır: OLE nesnesinin ön izleme resmi veya simgesi PDF sayfasında render edilir, ancak gömülü dosya ek olarak dahil edilmez. Seçeneği `true` olarak ayarlamak dosya verisini ayrıca ekler. Ön izleme görsel bir temsil olarak kalır; ek, alıcıların gömülü dosyayı ayrı ayrı açmasına veya kaydetmesine izin verir. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, içinde zaten gömülü bir Excel çalışma kitabı bulunan bir sunumu yükler ve çalışma kitabını ekli olarak PDF'ye dışa aktarır.

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

1. PDF'yi dosya eklerini destekleyen bir görüntüleyicide, örneğin Adobe Acrobat Reader'da açın.
2. Görüntüleyicinin **Attachments** panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve Excel'de açarak verilerini inceleyin veya görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme ekten ayrı bir öğedir.

{{% alert color="info" title="Note" %}}
PDF/A standartları eklerle ilgili kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 Excel çalışma kitapları dahil diğer dosya tiplerine izin verir. Bunlar standartların gereklilikleridir, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarmasını göstermez.
{{% /alert %}}

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştür**

Bir sunum gizli slaytlar içeriyorsa, gizli slaytları sonuç PDF'de sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfından [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) yöntemini kullanabilirsiniz.

Aşağıdaki örnek, gizli slaytlar dahil olmak üzere bir sunumu PDF'ye dışa aktarır.

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

### **Şifre Korумalı PDF Olarak PowerPoint'i Dönüştür**

Aşağıdaki örnek, açılması için `password` şifresini gerektiren bir PDF'ye bir sunumu dışa aktarır. Erişim izinleri, yüksek kaliteli baskı dahil bastırmaya izin verir.

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

Aspose.Slides, sunumdan PDF'ye dönüşüm sürecinde yazı tipi ikamelerini tespit etmenizi sağlayan [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfının altında bulunan [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) yöntemini sunar.

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır ve font ikame uyarılarını konsola yazdırır. Bir uyarı yalnızca kullanılabilir olmayan bir font dışa aktarım sırasında ikame edildiğinde yazdırılır.

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
Yazı tipi ikameleri hakkında daha fazla bilgi için [Font Substitution](/slides/tr/php-java/font-substitution/) makalesine bakın.
{{% /alert %}} 

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumdan 1 ve 3 numaralı slaytları PDF'ye dışa aktarır. Bu dizideki slayt numaraları 1 tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

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

## **Özel Slayt Boyutuyla PowerPoint'i PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumun ilk slaytını 612 × 792 puan (8,5 × 11 inç) boyutunda bir yeni sunuma kopyalar. Slayt içeriğini sığdıracak şekilde ölçekler ve tek slaytı PDF'ye dışa aktarır.

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

    // Yeni oluşturulan sunumda oluşan boş slaytı kaldır.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Not Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştür**

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır, her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

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

## **PDF İçin Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) standartlarına uygun bir dönüşüm prosedürü kullanmanıza izin verir. Bir PowerPoint belgesini PDF'ye şu uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b** ve **PDF/UA**.

Bu kod, farklı uyumluluk standartlarına dayalı birden fazla PDF üreten bir PowerPoint'ten PDF'ye dönüşüm sürecini gösterir:

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
Aspose.Slides, PDF dönüşüm işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenize olanak tanır. [PDF'den HTML'ye](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF'den görsele](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF'den JPG'ye](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) ve [PDF'den PNG'ye](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. [PDF'den SVG'ye](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF'den TIFF'e](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), ve [PDF'den XML'e](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) gibi özel formatlara dönüşüm işlemleri de desteklenmektedir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir figür olarak ele alır. Bireysel yol elemanları ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün figür için sağlanır.

## **SSS**

**Birden çok PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides birden fazla PPT veya PPTX dosyasının toplu olarak PDF'ye dönüştürülmesini destekler. Dosyalarınızın üzerinden programatik olarak geçerek dönüşüm sürecini uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifre korumalı yapmak mümkün mü?**

Evet. Dönüşüm sürecinde bir şifre belirlemek ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfını kullanabilirsiniz.

**Gizli slaytları PDF'ye nasıl ekleyebilirim?**

Gizli slaytları sonuç PDF'ye eklemek için [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) yöntemini `true` ile çağırın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfındaki [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) ve [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) gibi yöntemleri kullanarak PDF'nizde yüksek kaliteli görüntüler elde edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere [çeşitli standartlara](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) uyumlu PDF'ler dışa aktarmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for PHP via Java Dokümantasyonu](/slides/tr/php-java/)
- [Aspose.Slides for PHP via Java API Referansı](https://reference.aspose.com/slides/php-java/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)