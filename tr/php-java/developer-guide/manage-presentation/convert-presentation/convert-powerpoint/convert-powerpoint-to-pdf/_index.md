---
title: PHP'de PPT ve PPTX'i PDF'ye Dönüştürün [Gelişmiş Özellikler Dahil]
linktitle: PowerPoint PDF'ye
type: docs
weight: 40
url: /tr/php-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- PowerPoint PDF'ye
- sunumu PDF'ye
- PPT PDF'ye
- PPT'yi PDF'ye dönüştür
- PPTX PDF'ye
- PPTX'i PDF'ye dönüştür
- PowerPoint'i PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'ye aktar
- PPTX'i PDF'ye aktar
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de PowerPoint PPT/PPTX'i yüksek kaliteli, aranabilir PDF'lere dönüştürün, hızlı kod örnekleri ve gelişmiş dönüşüm seçenekleriyle."
---
## **Genel Bakış**

PowerPoint sunumlarını (PPT, PPTX, ODP vb.) PHP'de PDF formatına dönüştürmek, farklı cihazlar arasında uyumluluk ve sunumunuzun düzeni ile biçimlendirmesini koruma gibi çeşitli avantajlar sunar. Bu kılavuz, sunumları PDF belgelerine nasıl dönüştüreceğinizi, görüntü kalitesini kontrol etmek için çeşitli seçenekleri nasıl kullanacağınızı, gizli slaytları dahil etmeyi, PDF dosyalarını şifrelemeyi, yazı tipi ikamelerini tespit etmeyi, dönüştürme için belirli slaytları seçmeyi ve çıktı belgelerine uyumluluk standartlarını uygulamayı gösterir.

## **PowerPoint'ten PDF'ye Dönüşümler**

Aspose.Slides kullanarak, aşağıdaki formatlardaki sunumları PDF'ye dönüştürebilirsiniz:

* **PPT**
* **PPTX**
* **ODP**

Bir sunumu PDF'ye dönüştürmek için, dosya adını [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfına argüman olarak geçirip ardından `save` yöntemiyle sunumu PDF olarak kaydedin. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfı, genellikle bir sunumu PDF'ye dönüştürmek için kullanılan `save` yöntemini ortaya çıkarır.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for PHP via Java, çıktı belgelerine API bilgisi ve sürüm numarasını ekler. Örneğin, bir sunumu PDF'ye dönüştürürken, Aspose.Slides Application alanını "*Aspose.Slides*" ve PDF Producer alanını "*Aspose.Slides v XX.XX*" biçiminde doldurur. **Note** bu bilgiyi çıktı belgelerinden değiştiremez veya kaldıramazsınız.

{{% /alert %}}

Aspose.Slides, şunları dönüştürmenize olanak tanır:

* Tüm sunumları PDF'ye
* Bir sunumdan belirli slaytları PDF'ye

Aspose.Slides, sunumları PDF'ye dışa aktarır ve ortaya çıkan PDF'lerin orijinal sunumlara yakın olmasını sağlar. Dönüşümde öğeler ve öznitelikler doğru bir şekilde işlenir, şunlar dahil:

* Görseller
* Metin kutuları ve şekiller
* Metin biçimlendirme
* Paragraf biçimlendirme
* Köprüler
* Üst bilgi ve alt bilgi
* Madde işaretleri
* Tablolar

## **PowerPoint'i PDF'ye Dönüştür**

Standart PowerPoint'ten PDF'ye dönüşüm süreci varsayılan seçenekleri kullanır. Bu durumda, Aspose.Slides sağlanan sunumu en yüksek kalite seviyelerinde optimum ayarlarla PDF'ye dönüştürmeye çalışır.

Bu kod, bir sunumu (PPT, PPTX, ODP vb.) PDF'ye nasıl dönüştüreceğinizi gösterir:

```php
# Bir PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Sunumu PDF olarak kaydedin.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose, sunumdan PDF'ye dönüşüm sürecini gösteren ücretsiz bir çevrimiçi [**PowerPoint to PDF converter**](https://products.aspose.app/slides/tr/conversion/ppt-to-pdf) sunar. Burada açıklanan prosedürün canlı bir uygulaması için bu dönüştürücü ile bir test yapabilirsiniz.

{{% /alert %}}

## **Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Aspose.Slides, oluşan PDF'yi özelleştirmenize, PDF'yi şifreyle kilitlemenize veya dönüşüm sürecinin nasıl ilerleyeceğini belirlemenize olanak tanıyan özel seçenekler—[PdfOptions] sınıfı altındaki özellikler—sağlar.

### **Özel Seçeneklerle PowerPoint'i PDF'ye Dönüştür**

Özel dönüşüm seçeneklerini kullanarak, raster görüntüler için tercih ettiğiniz kalite ayarını tanımlayabilir, metafile'ların nasıl işleneceğini belirleyebilir, metin için sıkıştırma seviyesini ayarlayabilir, görüntüler için DPI'yi yapılandırabilir ve daha fazlasını yapabilirsiniz.

Aşağıdaki kod örneği, bir PowerPoint sunumunu çeşitli özel seçeneklerle PDF'ye nasıl dönüştüreceğinizi gösterir.

```php
# PdfOptions sınıfını örnekleyin.
$pdfOptions = new PdfOptions();

# JPG görüntüleri için kaliteyi ayarlayın.
$pdfOptions->setJpegQuality(90);

# Görüntüler için DPI ayarlayın.
$pdfOptions->setSufficientResolution(300);

# Metafile'ların davranışını ayarlayın.
$pdfOptions->setSaveMetafilesAsPng(true);

# Metin içeriği için metin sıkıştırma seviyesini ayarlayın.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# PDF uyumluluk modunu tanımlayın.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Sunumu PDF belgesi olarak kaydedin.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Gizli Slaytlarla PowerPoint'i PDF'ye Dönüştür**

Bir sunum gizli slaytlar içeriyorsa, [PdfOptions] sınıfındaki [setShowHiddenSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) yöntemiyle gizli slaytları ortaya çıkan PDF'de sayfa olarak ekleyebilirsiniz.

Bu kod, gizli slaytların dahil edildiği bir PowerPoint sunumunu PDF'ye nasıl dönüştüreceğinizi gösterir:

```php
# Bir PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # PdfOptions sınıfını örnekleyin.
    $pdfOptions = new PdfOptions();

    # Gizli slaytları ekleyin.
    $pdfOptions->setShowHiddenSlides(true);

    # Sunumu PDF olarak kaydedin.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Şifre Koruması ile PowerPoint'i PDF'ye Dönüştür**

Bu kod, [PdfOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pdfoptions/) sınıfındaki koruma parametrelerini kullanarak bir PowerPoint sunumunu şifre korumalı PDF'ye nasıl dönüştüreceğinizi gösterir:

```php
# Bir PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # PdfOptions sınıfını örnekleyin.
    $pdfOptions = new PdfOptions();

    # PDF şifresi ve erişim izinlerini ayarlayın.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Sunumu PDF olarak kaydedin.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Yazı Tipi İkamelerini Algıla**

Aspose.Slides, sunumdan PDF'ye dönüşüm sürecinde yazı tipi ikamelerini algılamanızı sağlayan [PdfOptions] sınıfı altındaki [setWarningCallback](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveoptions/#setWarningCallback) yöntemini sunar.

Bu kod, yazı tipi ikamelerini nasıl tespit edeceğinizi gösterir:

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// PDF seçeneklerinde uyarı geri çağrısını ayarla.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekle.
$presentation = new Presentation("sample.pptx");
try {
    // Sunumu PDF olarak kaydet.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 

Yazı tipi ikameleri hakkında daha fazla bilgi için, [Font Substitution](/slides/tr/php-java/font-substitution/) makalesine bakın.

{{% /alert %}} 

## **PowerPoint'te Seçili Slaytları PDF'ye Dönüştür**

Bu kod, bir PowerPoint sunumundan yalnızca belirli slaytları PDF'ye nasıl dönüştüreceğinizi gösterir:

```php
# PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Slayt numaralarının dizisini ayarlayın.
    $slides = array(1, 3);

    # Sunumu PDF olarak kaydedin.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Özel Slayt Boyutu ile PowerPoint'i PDF'ye Dönüştür**

Bu kod, belirtilen bir slayt boyutuyla PowerPoint sunumunu PDF'ye nasıl dönüştüreceğini gösterir:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("SelectedSlides.pptx");

# Ayarlanmış slayt boyutuyla yeni bir sunum oluşturun.
$resizedPresentation = new Presentation();

try {
    # Özel slayt boyutunu ayarlayın.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Orijinal sunumdan ilk slaytı klonlayın.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Yeniden boyutlandırılmış sunumu notlarla birlikte PDF'ye kaydedin.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Not Slaytı Görünümünde PowerPoint'i PDF'ye Dönüştür**

Bu kod, notları içeren bir PDF'ye PowerPoint sunumunu nasıl dönüştüreceğini gösterir:

```php
# PowerPoint veya OpenDocument dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # PDF seçeneklerini Not Düzeni ile yapılandırın.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Sunumu notlarla birlikte PDF olarak kaydedin.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **PDF için Erişilebilirlik ve Uyumluluk Standartları**

Aspose.Slides, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ile uyumlu bir dönüşüm prosedürü kullanmanıza izin verir. PowerPoint belgesini PDF'ye, şu uyumluluk standartlarından herhangi birini kullanarak dışa aktarabilirsiniz: **PDF/A1a**, **PDF/A1b**, ve **PDF/UA**.

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides, PDF dönüştürme işlemlerini destekler ve PDF dosyalarını popüler dosya formatlarına dönüştürmenize olanak tanır. [PDF to HTML](https://products.aspose.com/slides/tr/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/tr/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/tr/php-java/conversion/pdf-to-jpg/), ve [PDF to PNG](https://products.aspose.com/slides/tr/php-java/conversion/pdf-to-png/) dönüşümlerini gerçekleştirebilirsiniz. Ayrıca, özel formatlara PDF dönüştürme işlemleri—[PDF to SVG](https://products.aspose.com/slides/tr/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/tr/php-java/conversion/pdf-to-tiff/), ve [PDF to XML](https://products.aspose.com/slides/tr/php-java/conversion/pdf-to-xml/)—da desteklenir.

{{% /alert %}}

> **Note:** PDF/UA'ya dışa aktarırken, Aspose.Slides SmartArt, grafikler ve formüller gibi karmaşık grafikleri tek bir şekil olarak ele alır. Tek tek yol öğeleri ayrı içerik olarak korunmaz ve artefakt olarak işaretlenebilir; alternatif metin yalnızca bütün şekil için sağlanır.

## **SSS**

**Birden fazla PowerPoint dosyasını toplu olarak PDF'ye dönüştürebilir miyim?**

Evet, Aspose.Slides, birden fazla PPT veya PPTX dosyasını PDF'ye toplu dönüştürmeyi destekler. Dosyalarınız üzerinden döngü kurarak dönüşüm sürecini programlı olarak uygulayabilirsiniz.

**Dönüştürülen PDF'yi şifreyle korumak mümkün mü?**

Kesinlikle. Dönüşüm sürecinde bir şifre belirlemek ve erişim izinlerini tanımlamak için [PdfOptions] sınıfını kullanın.

**PDF'ye gizli slaytları nasıl ekleyebilirim?**

PDF'de gizli slaytları dahil etmek için [PdfOptions] sınıfındaki `setShowHiddenSlides` yöntemini kullanın.

**Aspose.Slides PDF'de yüksek görüntü kalitesini koruyabilir mi?**

Evet, PDF'nizde yüksek kaliteli görüntüler sağlamak için [PdfOptions] sınıfındaki `setJpegQuality` ve `setSufficientResolution` gibi yöntemleri kullanarak görüntü kalitesini kontrol edebilirsiniz.

**Aspose.Slides PDF/A uyumluluk standartlarını destekliyor mu?**

Evet, Aspose.Slides, PDF/A1a, PDF/A1b ve PDF/UA gibi çeşitli standartlara uyumlu PDF'ler dışa aktarmanıza olanak tanır; böylece belgeleriniz erişilebilirlik ve arşivleme gereksinimlerini karşılar.

## **Ek Kaynaklar**

- [Aspose.Slides for PHP via Java Documentation](/slides/tr/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/tr/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/tr/conversion)