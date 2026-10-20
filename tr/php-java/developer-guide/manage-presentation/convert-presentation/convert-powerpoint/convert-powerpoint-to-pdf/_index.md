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
- PPTX'ten PDF'ye
- PPTX'yi PDF'ye dönüştür
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
description: "Aspose.Slides kullanarak PHP'de PowerPoint PPT/PPTX dosyalarını yüksek kaliteli, aranabilir PDF'lere dönüştürün, hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) PHP'de PDF formatına dönüştürmek, farklı cihazlarda uyumluluk ve sunumunuzun düzeni ile biçimlendirmesini koruma gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını parola korumayı, yazı tipi ikamelerini tespit etmeyi, dönüşüm için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak, aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için, dosya adını [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfına argüman olarak geçirin ve ardından bir [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) yöntemi kullanarak sunumu PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfı, tipik olarak bir sunumu PDF'ye dönüştürmek için kullanılan [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) yöntemini sunar.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java, çıktıya API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken, Aspose.Slides Application (Uygulama) alanını "*Aspose.Slides*" ve PDF Producer (Üretici) alanını "*Aspose.Slides v XX.XX*" biçiminde doldurur. **Not** bu bilgiyi Aspose.Slides ile değiştiremeyeceğinizi veya çıkış belgelerinden kaldıramayacağınızı unutmayın.
{{% /alert %}}

Aspose.Slides aşağıdakileri dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides sunumları PDF'ye dışa aktarır ve oluşan PDF'lerin orijinal sunumlarla yakından eşleşmesini sağlar. Dönüşüm sırasında öğeler ve öznitelikler doğru bir şekilde işlenir, şunlar dahil:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirmesi
* Paragraf biçimlendirmesi
* Köprüler
* Başlık ve altbilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint'ten PDF'ye dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimal ayarlarla PDF'ye dönüştürmeye çalışır.

Aşağıdaki örnek bir sunumu yükler ve tüm görünür slaytları varsayılan dışa aktarma ayarlarıyla PDF olarak kaydeder.

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
Aspose, sunumdan PDF'ye dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulamasını test etmek için bu dönüştürücüyü kullanabilirsiniz.
{{% /alert %}}

## **PowerPoint'i PDF'ye Seçeneklerle Dönüştür**

Aspose.Slides, sonuç PDF'yi özelleştirmenize, PDF'yi parola ile kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirtmenize olanak tanıyan özel seçenekler—[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfı altındaki özellikler—sağlar.

### **PowerPoint'i PDF'ye Özel Seçeneklerle Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını belirleyebilir, metafile'ların nasıl işleneceğini belirtebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki örnek, bir sunumu PDF 1.5 olarak dışa aktarır; JPEG kalitesi %90, görüntü çözünürlüğü 300 DPI, metafile'lar PNG olarak kaydedilir ve Flate metin sıkıştırması kullanılır.

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

### **Görüntü Sıkıştırmasını Otomatik Olarak Seç**

Sunumda çok sayıda fotoğraf veya ekran görüntüsü olduğunda, dışa aktarılan PDF'in boyutunu küçültmek e-posta gönderimini veya indirmeyi kolaylaştırabilir. PDF dışa aktarımı sırasında her görüntü için en uygun sıkıştırma algoritmasını otomatik olarak seçmek için [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) yöntemini `true` ile çağırın.

Aşağıdaki örnek mevcut bir sunumu yükler, otomatik görüntü sıkıştırma seçimini etkinleştirir ve PDF belge olarak kaydeder. Diğer tüm PDF dışa aktarma ayarları varsayılan değerlerini korur.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Bu seçenek her görüntü için bir sıkıştırma algoritması seçer. [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) yöntemine verilen değeri düşürmek JPEG görüntü kalitesini azaltırken, [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) yöntemine verilen değeri düşürmek görüntülerin daha düşük bir çözünürlüğe düşürülmesini sağlar; bu, ayrıntıyı azaltabilir. Otomatik sıkıştırma seçimini etkinleştirmek bu ayarların kendisini düşürmez.

Görüntü sıkıştırma algoritmalarını seçmek ekstra işlem süresi ve bellek gerektirir. Boyut azaltması, sunumdaki görüntülere ve dışa aktarma ayarlarına bağlıdır; her sunum için sabit bir azaltma garantilenmez.

### **Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru**

Eğer bir sunum gömülü bir Excel çalışma kitabı içeriyorsa, PDF alıcılarının yalnızca slaytları görüntülemekle kalmayıp aynı zamanda çalışma kitabının verilerine erişmesini isteyebilirsiniz. Gömülü OLE dosyalarını sonuç PDF'de ekler olarak korumak için [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) yöntemini `true` ile çağırın.

Varsayılan değer `false`'tur: OLE nesnesinin ön izleme resmi veya simgesi PDF sayfasında gösterilir, ancak gömülü dosya ek olarak eklenmez. Seçeneği `true` olarak ayarlamak dosya verilerini ek olarak da ekler. Ön izleme görsel bir temsil olarak kalır; ek, alıcıların gömülü dosyayı ayrı ayrı açmasına veya kaydetmesine olanak tanır. OLE nesnesi PDF sayfasında etkileşimli bir Excel çalışma sayfasına dönüşmez.

Aşağıdaki örnek, içinde gömülü bir Excel çalışma kitabı bulunan bir sunumu yükler ve çalışma kitabı ekli olarak PDF'ye dışa aktarır.

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

1. Adobe Acrobat Reader gibi dosya eklerini destekleyen bir görüntüleyicide dışa aktarılan PDF'i açın.
2. Görüntüleyicinin **Attachments** panelini açın ve gömülü çalışma kitabını bulun.
3. Ek'i kaydedin ve verilerini incelemek için Excel'de açın ya da görüntüleyici izin veriyorsa doğrudan açın. PDF sayfasındaki ön izleme, eklentiden ayrı bir unsurdur.

{{% alert color="info" title="Note" %}}
PDF/A standartları eklerle ilgili kısıtlamalar getirir: PDF/A-1 gömülü dosyaları yasaklar, PDF/A-2 yalnızca PDF/A eklerine izin verir ve PDF/A-3 Excel çalışma kitapları dahil diğer dosya türlerine izin verir. Bunlar standartların gereklilikleridir, Aspose.Slides'e özgü kısıtlamalar değildir. Bu örnek varsayılan PDF uyumluluk ayarını kullanır ve PDF/A dışa aktarmasını göstermemektedir.
{{% /alert %}}

### **PowerPoint'i Gizli Slaytlarla PDF'ye Dönüştür**

Eğer bir sunum gizli slaytlar içeriyorsa, sonuç PDF'de gizli slaytları sayfa olarak eklemek için [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) yöntemini kullanabilirsiniz.

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

### **PowerPoint'i Parola Koruması Olan PDF'ye Dönüştür**

Aşağıdaki örnek, açmak için `password` parolasını gerektiren bir PDF olarak sunumu dışa aktarır. Erişim izinleri, yüksek kaliteli baskı dahil olmak üzere yazdırmaya izin verir.

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

### **Yazı Tipi İkamelerini Tespit Et**

Aspose.Slides, sunumdan PDF'ye dönüşüm sürecinde yazı tipi ikamelerini tespit etmenizi sağlayan [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfı altında [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) yöntemini sunar.

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır ve yazı tipi ikameleriyle ilgili uyarıları konsola yazdırır. Uyarı, dışa aktarma sırasında bulunamayan bir yazı tipi ikame edildiğinde yalnızca o zaman görüntülenir.

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

### **Ayrı Bir Kalın Yazı Tipi Olmayan Yazı Tiplerini İşle**

Bir sunum, fontunun ayrı bir kalın tipi olmasa bile metne kalın biçimlendirme uygulayabilir. Metin, sentetik kalınlaştırma ile hâlâ kalın görünebilir; bu, normal glifleri yapay olarak kalınlaştırır. Metin PDF'de çok ağır görünüyor ya da istenen görünümden farklıysa, [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) yöntemini `true` ile çağırmayı deneyin. Bu seçenek, etkilenmiş metni PDF dışa aktarımı sırasında bitmap olarak işler ve belirli fontlar için görünümünü iyileştirebilir. Varsayılan değeri `false`'tur.

Örnek sunum iki metin kutusu içerir: biri normal metin, diğeri aynı fontta (ayrı bir kalın tip olmadan) kalın biçimlendirme uygulanmış. Aşağıdaki örnek sunumu yükler, desteklenmeyen font stillerinin rasterleştirilmesini etkinleştirir ve PDF'ye dışa aktarır:

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

Aşağıdaki ön izlemeler, seçeneği devre dışı bırakılmış ve etkinleştirilmiş çıktıyı gösterir. Bu örnekte, seçenek devre dışıyken kalın metnin çizgileri daha kalındır. Seçenek etkin olduğunda çizgileri daha hafiftir; normal metin değişmez. Sunumunuz için ayarı seçmeden önce sonuçları karşılaştırın.

| Seçenek devre dışı (`false`, varsayılan) | Seçenek etkin (`true`) |
|---|---|
| ![PDF, desteklenmeyen font stili rasterleştirme devre dışı](unsupported-bold-disabled.png) | ![PDF, desteklenmeyen font stili rasterleştirme etkin](unsupported-bold-enabled.png) |

Bu örnekte, seçeneği etkinleştirmek yalnızca kalın metni bitmap'e dönüştürür: OCR olmadan seçilemez, kopyalanamaz veya metin olarak aranamaz ve kenarları %800 yakınlaştırmada daha yumuşak görünür. Normal metin aranabilir kalır. Seçenek devre dışı bırakıldığında, her iki dize de metin olarak kalır.

Bu seçenek, fontun ayrı bir kalın tipi olmadığında kalın olarak biçimlendirilmiş metni rasterleştirir. [Font substitution](/slides/tr/php-java/font-substitution/) ise orijinal mevcut değilse başka bir font seçer.

## **PowerPoint'ten Seçili Slaytları PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumdan slayt 1 ve 3'ü PDF'ye dışa aktarır. Bu dizideki slayt numaraları 1 tabanlıdır ve giriş sunumu en az üç slayt içermelidir.

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

## **PowerPoint'i Özel Slayt Boyutu ile PDF'ye Dönüştür**

Aşağıdaki örnek, bir sunumun ilk slaytını 612 × 792 puan (8.5 × 11 inç) boyutunda bir yeni sunuma kopyalar. Slayt içeriğini sığacak şekilde ölçeklendirir ve tek slaytı PDF'ye dışa aktarır.

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

    // Yeni oluşturulan sunumun boş slaytını kaldır.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **PowerPoint'i Not Slaytı Görünümünde PDF'ye Dönüştür**

Aşağıdaki örnek bir sunumu PDF'ye dışa aktarır ve her slaytın konuşmacı notlarını slaytın altına yerleştirir. Sonucu görmek için konuşmacı notları içeren bir sunum kullanın.

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

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza olanak tanır. Bir PowerPoint belgesini PDF'ye, **PDF/A1a**, **PDF/A1b** ve **PDF/UA** gibi uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz.

Bu kod, farklı uyumluluk standartlarına göre birden fazla PDF üreten bir PowerPoint'ten PDF'ye dönüşüm sürecini gösterir:

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
Aspose.Slides, PDF dönüştürme işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenizi sağlar. [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) ve [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. [PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/) ve [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) gibi özel formatlara yönelik diğer PDF dönüşüm işlemleri de desteklenmektedir.
{{% /alert %}}

> **Not:** PDF/UA'ya dışa aktarırken, Aspose.Slides karmaşık grafikler (SmartArt, grafikler ve formüller) gibi içeriği tek bir şekil olarak ele alır. Bireysel yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **FAQ**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**  
Evet, Aspose.Slides birden çok PPT veya PPTX dosyasını PDF'ye toplu dönüştürmeyi destekler. Dosyalarınızı döngü içinde işleyebilir ve dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi parola korumalı yapmak mümkün mü?**  
Evet. Dönüşüm sırasında bir parola ayarlamak ve erişim izinlerini tanımlamak için [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfını kullanın.

**Gizli slaytları PDF'ye nasıl dahil ederim?**  
[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) yöntemini `true` ile çağırarak sonuç PDF'de gizli slaytları dahil edin.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**  
Evet, [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) sınıfındaki [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) ve [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) gibi yöntemleri kullanarak PDF'nizde yüksek kaliteli görüntüler elde edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**  
Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA dahil olmak üzere [various standards](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) ile uyumlu PDF'ler dışa aktarmanıza olanak tanır, böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for PHP via Java Belgeleri](/slides/tr/php-java/)
- [Aspose.Slides for PHP via Java API Referansı](https://reference.aspose.com/slides/php-java/)
- [Aspose Ücretsiz Çevrimiçi Dönüştürücüler](https://products.aspose.app/slides/conversion)