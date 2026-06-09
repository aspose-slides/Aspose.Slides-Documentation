---
title: PHP'de Sunumları Kaydet
linktitle: Sunumu Kaydet
type: docs
weight: 80
url: /tr/php-java/save-presentation/
keywords:
- PowerPoint kaydet
- OpenDocument kaydet
- sunumu kaydet
- slaytı kaydet
- PPT kaydet
- PPTX kaydet
- ODP kaydet
- sunumu dosyaya
- sunumu akışa
- önyazılmış görünüm tipi
- Katı Office Open XML Biçimi
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP'i Java aracılığıyla kullanarak sunumları nasıl kaydedeceğinizi keşfedin — düzenleri, yazı tiplerini ve efektleri koruyarak PowerPoint veya OpenDocument olarak dışa aktarın."
---
## **Genel Bakış**

[PHP'de Sunumları Aç](/slides/tr/php-java/open-presentation/) bir sunumu açmak için [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının nasıl kullanılacağını gösterir. Bu makale, sunumları nasıl oluşturup kaydedeceğinizi açıklar. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı bir sunumun içeriğini tutar. Sıfırdan bir sunum oluşturuyor olun ya da mevcut bir tanesini değiştiriyor olun, bitirdiğinizde kaydetmek isteyeceksiniz. Aspose.Slides for PHP ile bir **dosyaya** veya **akışa** kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklar.

## **Sunumları Dosyalara Kaydet**

Bir sunumu dosyaya kaydetmek için [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının `save` metodunu çağırın. Metoda dosya adını ve kaydetme formatını geçirin. Aşağıdaki örnek, Aspose.Slides ile bir sunumu nasıl kaydedeceğinizi gösterir.

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // Burada bazı işlemler yapın...

    // Sunumu bir dosyaya kaydedin.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sunumları Akışlara Kaydet**

Bir sunumu bir akışa kaydetmek için [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının `save` metoduna bir çıktı akışı geçirebilirsiniz. Bir sunum birçok akış türüne yazılabilir. Aşağıdaki örnekte, yeni bir sunum oluşturuyor ve onu bir dosya akışına kaydediyoruz.

```php
// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Sunumu akışa kaydedin.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Önceden Tanımlı Görünüm Tipiyle Sunumları Kaydet**

Aspose.Slides, oluşturulan sunum açıldığında PowerPoint'in kullandığı ilk görünümü [ViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/) sınıfı aracılığıyla ayarlamanıza izin verir. [setLastView](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/#setLastView) metodunu, [ViewType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewtype/) enumarasyonundan bir değerle kullanın.

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sunumları Katı Office Open XML Biçiminde Kaydet**

Aspose.Slides, bir sunumu Katı Office Open XML biçiminde kaydetmenizi sağlar. Kaydederken [PptxOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxoptions/) sınıfını kullanın ve uyum özelliğini ayarlayın. [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/tr/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) ayarlarsanız, çıktı dosyası Katı Office Open XML biçiminde kaydedilir.

Aşağıdaki örnek bir sunum oluşturur ve Katı Office Open XML biçiminde kaydeder.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // Sunumu Katı Office Open XML biçiminde kaydedin.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Sunumları Office Open XML Biçiminde Zip64 Modunda Kaydet**

Office Open XML dosyası, herhangi bir dosyanın sıkıştırılmamış boyutu, sıkıştırılmış boyutu ve arşivin toplam boyutu üzerinde 4 GB (2^32 bayt) sınırları ve arşivin 65 535 (2^16‑1) dosya sınırı getiren bir ZIP arşividir. ZIP64 biçim uzantıları bu sınırları 2^64’e yükseltir.

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxoptions/#setZip64Mode) metodu, Office Open XML dosyası kaydedilirken ZIP64 biçim uzantılarının ne zaman kullanılacağını seçmenizi sağlar.

Bu metod aşağıdaki modlarla kullanılabilir:

- [IfNecessary](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zip64mode/#IfNecessary) yalnızca sunum yukarıdaki sınırlamaları aşarsa ZIP64 uzantılarını kullanır. Bu, varsayılan moddur.
- [Never](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zip64mode/#Never) ZIP64 uzantılarını asla kullanmaz.
- [Always](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zip64mode/#Always) ZIP64 uzantılarını her zaman kullanır.

Aşağıdaki kod, ZIP64 biçim uzantıları etkinleştirilmiş şekilde bir sunumu PPTX olarak kaydetmeyi gösterir:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
[Zip64Mode.Never](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zip64mode/#Never) ile kaydettiğinizde, sunum ZIP32 biçiminde kaydedilemezse bir [PptxException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxexception/) atılır.
{{% /alert %}}

## **Sunumları Küçük Resmi Yenilemeden Kaydet**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) metodu, bir sunumu PPTX olarak kaydederken küçük resim oluşturmayı kontrol eder:

- `true` olarak ayarlanırsa, kaydetme sırasında küçük resim yenilenir. Bu varsayılandır.
- `false` olarak ayarlanırsa, mevcut küçük resim korunur. Sunumun küçük resmi yoksa, hiç oluşturulmaz.

Aşağıdaki kodda sunum, küçük resmi yenilenmeden PPTX olarak kaydedilir.

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Bu seçenek, PPTX formatında bir sunumu kaydetme süresini azaltmaya yardımcı olur.
{{% /alert %}}

## **Kaydetme İlerleme Güncellemelerini Yüzde Olarak Al**

Kaydetme ilerleme raporlaması, [SaveOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveoptions/) ve alt sınıflarındaki [setProgressCallback](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveoptions/#setProgressCallback) metodu aracılığıyla yapılandırılır. İhracat sırasında periyodik yüzde güncellemeleri alan bir Java vekili sağlayarak [IProgressCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprogresscallback/) arabirimini uygulayın.

Aşağıdaki kod parçacıkları `IProgressCallback` kullanımını gösterir.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // İlerleme yüzde değerini burada kullanın.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose, kendi API'sını kullanarak ücretsiz bir [PowerPoint Splitter uygulaması](https://products.aspose.app/slides/tr/splitter) geliştirmiştir. Uygulama, seçilen slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden çok dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**“Hızlı kaydet” (artımlı kaydet) destekleniyor mu, yani yalnızca değişiklikler mi yazılıyor?**  
Hayır. Kaydetme her seferinde tam hedef dosyayı oluşturur; artımlı “hızlı kaydetme” desteklenmez.

**Aynı Presentation örneğini birden çok iş parçacığından kaydetmek güvenli mi?**  
Hayır. bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği [thread‑safe değildir](/slides/tr/php-java/multithreading/); tek bir iş parçacığından kaydedilmelidir.

**Kaydedilirken köprüler ve harici bağlı dosyalar ne olur?**  
[Hyperlinks](/slides/tr/php-java/manage-hyperlinks/) korunur. Harici bağlı dosyalar (örn. göreli yollarla gösterilen videolar) otomatik olarak kopyalanmaz—başvurulan yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayıp/kaydedebilir miyim?**  
Evet. Standart [document properties](/slides/tr/php-java/presentation-properties/) desteklenir ve kaydetme sırasında dosyaya yazılır.