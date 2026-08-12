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
- önceden tanımlı görünüm türü
- Sıkı Office Open XML Formatı
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak sunumları nasıl kaydedeceğinizi keşfedin — düzenleri, yazı tiplerini ve efektleri koruyarak PowerPoint ya da OpenDocument olarak dışa aktarın."
---
## **Genel Bakış**

[Open Presentations in PHP](/slides/tr/php-java/open-presentation/) sunumu açmak için [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının nasıl kullanılacağını açıkladı. Bu makale, sunumları nasıl oluşturup kaydedeceğinizi anlatır. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı bir sunumun içeriğini tutar. Sıfırdan bir sunum oluşturuyor ya da mevcut bir sunumu değiştiriyor olun, işiniz bittiğinde kaydetmek istersiniz. Aspose.Slides for PHP ile bir **dosyaya** ya da **akışa** kaydedebilirsiniz. Bu makale, bir sunumu kaydetmenin farklı yollarını açıklar.

## **Sunumları Dosyalara Kaydetme**

[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının `save` yöntemini çağırarak bir sunumu dosyaya kaydedin. Dosya adını ve kaydetme biçimini metoda geçin. Aşağıdaki örnek, Aspose.Slides ile bir sunumu nasıl kaydedeceğinizi gösterir.

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

## **Sunumları Akışlara Kaydetme**

[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının `save` yöntemine bir çıktı akışı geçirerek bir sunumu akışa kaydedebilirsiniz. Bir sunum birçok akış türüne yazılabilir. Aşağıdaki örnekte yeni bir sunum oluşturup bir dosya akışına kaydediyoruz.

```php
// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
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

## **Önceden Tanımlı Görünüm Türüyle Sunumları Kaydetme**

Aspose.Slides, oluşturulan sunum açıldığında PowerPoint'in kullandığı ilk görünümü [ViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/) sınıfı aracılığıyla ayarlamanıza izin verir. [ViewType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewtype/) enum değerlerinden birini kullanarak [setLastView](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/#setLastView) yöntemini çağırın.

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sıkı Office Open XML Biçiminde Sunumları Kaydetme**

Aspose.Slides, bir sunumu Sıkı Office Open XML biçiminde kaydetmenize olanak tanır. Kaydederken [PptxOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxoptions/) sınıfını kullanın ve `conformance` özelliğini ayarlayın. Eğer [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/tr/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) ayarlanırsa çıktı dosyası Sıkı Office Open XML biçiminde kaydedilir.

Aşağıdaki örnek bir sunum oluşturur ve Sıkı Office Open XML biçiminde kaydeder.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
$presentation = new Presentation();
try {
    // Sunumu Sıkı Office Open XML formatında kaydedin.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **ZIP64 Modunda Office Open XML Biçiminde Sunumları Kaydetme**

Office Open XML dosyası, sıkıştırılmamış dosya boyutu, sıkıştırılmış dosya boyutu ve arşiv toplam boyutu için 4 GB (2^32 bayt) sınırı getiren bir ZIP arşividir ve ayrıca arşivde 65 535 (2^16‑1) dosya sınırı vardır. ZIP64 biçim uzantıları bu sınırları 2^64’e çıkarır.

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxoptions/#setZip64Mode) yöntemi, Office Open XML dosyası kaydedilirken ZIP64 uzantılarının ne zaman kullanılacağını seçmenizi sağlar.

Bu yöntem aşağıdaki modlarla kullanılabilir:

- [IfNecessary](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zip64mode/#IfNecessary) yalnızca sunum yukarıdaki sınırlamaları aştığında ZIP64 uzantılarını kullanır. Varsayılan moddur.
- [Never](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zip64mode/#Never) ZIP64 uzantılarını asla kullanmaz.
- [Always](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zip64mode/#Always) her zaman ZIP64 uzantılarını kullanır.

Aşağıdaki kod, ZIP64 uzantıları etkinleştirilmiş bir PPTX dosyası olarak sunumu nasıl kaydedeceğinizi gösterir:

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

{{% alert title="NOT" color="warning" %}}
[Zip64Mode.Never](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zip64mode/#Never) ile kaydettiğinizde, sunum ZIP32 biçiminde kaydedilemezse bir [PptxException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxexception/) fırlatılır.
{{% /alert %}}

## **Sıkıştırma Seviyeleriyle Office Open XML Biçiminde Sunumları Kaydetme**

Büyük sunumlarla çalışırken dosya boyutu ile işlem süresi arasında denge kurmak için sıkıştırma seviyesini ayarlayabilirsiniz. Gereksinimlerinize bağlı olarak daha hızlı işlem ya da daha küçük çıktı dosyaları tercih edilebilir.

Aspose.Slides, Office Open XML biçiminde bir sunumu kaydederken kullanılacak sıkıştırma seviyesini belirlemenizi sağlayan [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxoptions/#setCompressionLevel) yöntemini sunar.

Mevcut sıkıştırma seviyeleri:

- [**None**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#None): Sıkıştırma uygulanmaz. Dosyalar olduğu gibi saklanır.
- [**Level1**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level1): En hızlı sıkıştırma, en düşük sıkıştırma oranı.
- [**Level2**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level2): **Level1**’e göre biraz daha iyi sıkıştırma, hâlâ hızlı.
- [**Level3**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level3): **Level2**’den daha iyi sıkıştırma, orta düzey işlem süresi.
- [**Level4**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level4): **Level3**’ten daha iyi sıkıştırma.
- [**Level5**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level5): **Level4**’e göre geliştirilmiş sıkıştırma, ek işlem süresi.
- [**Level6**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level6): Standart sıkıştırma, işlem hızı ve dosya boyutu arasında iyi bir denge. *Varsayılan sıkıştırma seviyesi* bu seviyedir.
- [**Level7**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level7): **Level6**’dan daha iyi sıkıştırma, daha yavaş işlem.
- [**Level8**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level8): **Level7**’den daha iyi sıkıştırma.
- [**Level9**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level9): En yüksek sıkıştırma. En küçük dosya boyutunu üretir, ancak en uzun işlem süresine sahiptir.

Aşağıdaki örnek, **sıkıştırma olmadan** bir PPTX dosyası olarak sunumu nasıl kaydedeceğinizi gösterir:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

Bu örnek, **maksimum sıkıştırma** ile bir PPTX dosyası olarak sunumu nasıl kaydedeceğinizi gösterir:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **Küçük Resmi Yenilemeden Sunumları Kaydetme**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) yöntemi, bir sunumu PPTX olarak kaydederken küçük resim oluşturulmasını kontrol eder:

- `true` ise kaydetme sırasında küçük resim yenilenir. Varsayılan değerdir.
- `false` ise mevcut küçük resim korunur. Sunumun küçük resmi yoksa hiç oluşturulmaz.

Aşağıdaki kod, sunumu küçük resmi yenilenmeden PPTX olarak kaydeder.

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

{{% alert title="Bilgi" color="info" %}}
Bu seçenek, PPTX biçiminde bir sunumu kaydetme süresini azaltmaya yardımcı olur.
{{% /alert %}}

## **Kaydetme İlerleme Yüzdesi Güncellemeleri**

Kaydetme sırasında ilerleme raporlaması, [SaveOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveoptions/) ve alt sınıfları üzerindeki [setProgressCallback](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveoptions/#setProgressCallback) yöntemiyle yapılandırılır. [IProgressCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprogresscallback/) arayüzünü uygulayan bir Java proxy sağlayın; dışa aktarım sırasında geri arama periyodik yüzde güncellemeleri alır.

Aşağıdaki kod parçacıkları, `IProgressCallback` kullanımını gösterir:

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // İlerleme yüzdesi değerini burada kullanın.
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

{{% alert title="Bilgi" color="info" %}}
Aspose, kendi API’siyle geliştirilmiş ücretsiz bir **PowerPoint Splitter** uygulaması sunar: https://products.aspose.app/slides/tr/splitter. Uygulama, seçilen slaytları yeni PPTX veya PPT dosyaları olarak kaydederek bir sunumu birden fazla dosyaya bölmenizi sağlar.
{{% /alert %}}

## **SSS**

**“Hızlı kaydetme” (artımlı kaydetme) destekleniyor mu, böylece yalnızca değişiklikler mi yazılıyor?**

Hayır. Kaydetme her seferinde tam hedef dosyayı oluşturur; artımlı “hızlı kaydetme” desteklenmez.

**Aynı Presentation örneğini birden çok iş parçacığından kaydetmek thread‑safe mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği **thread‑safe değildir** (/slides/tr/php-java/multithreading/); tek bir iş parçacığından kaydedin.

**Kaydederken köprüler ve harici bağlanan dosyalar ne oluyor?**

[Hyperlinks](/slides/tr/php-java/manage-hyperlinks/) korunur. Harici bağlanan dosyalar (ör. göreceli yollarla eklenen videolar) otomatik olarak kopyalanmaz—referans verilen yolların erişilebilir olduğundan emin olun.

**Belge meta verilerini (Yazar, Başlık, Şirket, Tarih) ayarlayıp/kaydedebilir miyim?**

Evet. Standart [document properties](/slides/tr/php-java/presentation-properties/) desteklenir ve kaydetme sırasında dosyaya yazılır.