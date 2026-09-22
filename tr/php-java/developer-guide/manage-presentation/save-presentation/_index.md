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
- dosyaya sunum
- akışa sunum
- önceden tanımlı görünüm türü
- Katı Office Open XML Formatı
- Zip64 modu
- küçük resmi yenileme
- kaydetme ilerlemesi
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de PowerPoint ve OpenDocument sunumlarını dosyalara veya akışlara kaydedin ve PPTX çıktısını ve ilerleme raporlamasını yapılandırın."
---
## **Genel Bakış**

Bir sunum oluşturduktan veya [mevcut bir sunumu açtıktan](/slides/tr/php-java/open-presentation/), sonucu yazmak için [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) yöntemini kullanın. Aspose.Slides for PHP via Java, bir sunumu PowerPoint, OpenDocument, PDF ve diğer formatlarda dosya veya akışa kaydedebilir. Aşağıdaki bölümler standart kaydetme işlemlerini ve PPTX çıktısı için mevcut seçenekleri kapsar.

## **Sunumları Dosyalara Kaydet**

Bir sunumu dosyaya kaydetmek için, çıktı yolunu ve bir [SaveFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/) değerini [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) yöntemine iletin. Format değeri, Aspose.Slides'ın oluşturacağı dosya türünü belirler.

Aşağıdaki örnek bir sunum oluşturur ve PPTX dosyası olarak kaydeder:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Burada sunum içeriğini ekleyin veya değiştirin.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sunumları Orijinal Formatlarında Kaydet**

Dosya ve akış tespiti örnekleri, yeni oluşturulan sunumların davranışı ve kaynak ile çıktı formatları arasındaki ayrım için [Determine the Original Presentation Format](/slides/tr/php-java/detect-presentation-source-format/) bölümüne bakın.

Toplu işleme uygulamasında, giriş formatı önceden bilinmeyebilir. Bir dosya yüklendikten sonra, orijinal formatı [Presentation::getSourceFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSourceFormat) yönteminden okuyun. Elde edilen [SourceFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sourceformat/) değerini [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideutil/#toSaveFormat) yöntemine geçirerek karşılık gelen [SaveFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/) değerini alın ve ardından [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) yöntemiyle değiştirilmiş sunumu yazın.

Aşağıdaki tam örnek, bir giriş dizinindeki her dosyayı işler, başlığını günceller ve yüklendiği formatta bir çıktı dizinine kaydeder:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideutil/#toSaveFormat) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP ve PowerPoint XML dosyalarını ilgili sunum kaydetme formatlarına eşler. Yalnızca sunum kaynak formatlarını eşler; PDF, HTML, TIFF ya da görüntü gibi dışa aktarım formatlarını seçmek için kullanılmaz. Desteklenmeyen veya geçersiz bir [SourceFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sourceformat/) değeri geçirilirse bir [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) oluşur.

Legacy PPT, PPS ve POT dosyaları aynı ikili kapsayıcıyı kullanır. Böyle bir sunum, dosya uzantısı olmadan bir akıştan yüklendiğinde bir PPS ya da POT dosyası PPT olarak tanımlanabilir. Bu eski alt tipleri korumanız gerekiyorsa, orijinal dosya adını veya format meta verisini ayrı olarak tutun ve çıktı dosya adı ve formatını seçerken kullanın.

## **Sunumları Akışlara Kaydet**

Bir sunumu son bir dosya yoluna bağımlı olmadan yazmak için, write‑able bir akış ve bir [SaveFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/) değerini [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) yöntemine iletin. Bu yaklaşım, çıktının bir web servisinden döndürülmesi, bir veritabanında saklanması veya bellekte işlenmesi gerektiğinde kullanışlıdır.

Aşağıdaki örnek yeni bir sunumu bir dosya akışına kaydeder:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Önceden Tanımlı Görünüm Türüyle Sunumları Kaydet**

PowerPoint'in kaydedilen bir sunumu ilk açtığında hangi görünümde açılacağını belirtebilirsiniz. Kaydetmeden önce bir [ViewType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewtype/) değeriyle [ViewProperties::setLastView](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/#setLastView) yöntemini kullanın.

Aşağıdaki örnek Slide Master görünümünü başlangıç görünümü olarak ayarlar:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Katı Office Open XML Formatında Sunumları Kaydet**

Katı Office Open XML profiline uygun bir PPTX dosyası oluşturmak için bir [PptxOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxoptions/) örneği oluşturun ve [PptxOptions::setConformance](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxoptions/#setConformance) yöntemini [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/tr/php-java/aspose.slides/conformance/#Iso29500-2008-Strict) değeriyle kullanın. Ardından seçenekleri [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) yöntemine iletin.

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **ZIP64 Modunda Office Open XML Formatında Sunumları Kaydet**

Standart ZIP arşivi, her girişin sıkıştırılmış ve sıkıştırılmamış boyutunu, toplam arşiv boyutunu ve giriş sayısını sınırlar. PPTX dosyası bir ZIP arşivi olduğundan, çok büyük bir sunum bu sınırlamaları aşabilir. ZIP64 uzantıları uygulanabilir boyut ve giriş sayısı limitlerini artırır.

[PptxOptions::setZip64Mode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxoptions/#setZip64Mode) yöntemiyle Aspose.Slides'ın ZIP64 uzantılarını yazıp yazmayacağını kontrol edin:

- [IfNecessary](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zip64mode/#IfNecessary) sunum standart ZIP limitlerini aştığında yalnızca ZIP64 kullanır. Bu varsayılan moddur.
- [Never](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zip64mode/#Never) ZIP64 uzantılarını devre dışı bırakır.
- [Always](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zip64mode/#Always) her zaman ZIP64 uzantılarını yazar.

Aşağıdaki örnek, çıktı sunumu için ZIP64 uzantılarını her zaman etkinleştirir:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Uyarı" %}}
[Zip64Mode::Never](https://reference.aspose.com/slides/tr/php-java/aspose.slides/zip64mode/#Never) kullanılır ve sunum standart ZIP limitlerine sığmazsa, kaydetme işlemi bir [PptxException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxexception/) fırlatır.
{{% /alert %}}

## **Sıkıştırma Seviyeleriyle Office Open XML Formatında Sunumları Kaydet**

PPTX çıktısı için, [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxoptions/#setCompressionLevel) yöntemini kullanarak kaydetme hızını dosya boyutuyla dengeleyebilirsiniz. [CompressionLevel](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/) sınıfı şu değerleri sağlar:

- [None](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#None) veriyi sıkıştırmadan depolar.
- [Level1](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level1) en hızlı sıkıştırmayı ve en büyük sıkıştırılmış çıktıyı verir.
- [Level2](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level2)‑[Level5](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level5) daha küçük çıktıyı kaydetme hızı pahasına tercih eder.
- [Level6](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level6) kaydetme hızı ve dosya boyutunu dengeler. Bu varsayılan seviyedir.
- [Level7](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level7) ve [Level8](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level8) daha küçük çıktıyı kaydetme hızı pahasına daha da öne çıkar.
- [Level9](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compressionlevel/#Level9) en güçlü sıkıştırmayı sağlar ve en çok işlem süresi gerektirir.

Aşağıdaki örnek sıkıştırma olmadan bir sunum kaydeder:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

Aşağıdaki örnek en yüksek sıkıştırma seviyesini kullanır:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Küçük Resmi Yenilemeksizin Sunumları Kaydet**

Bir sunum PPTX olarak kaydedildiğinde, [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) yöntemi belge küçük resmini kontrol eder:

- `true` kaydetme sırasında küçük resmi yeniden oluşturur. Bu varsayılan değerdir.
- `false` mevcut küçük resmi korur. Sunumun küçük resmi yoksa Aspose.Slides bir tane oluşturmaz.

Aşağıdaki örnek küçük resmi yenilemeksizin bir sunum kaydeder:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Not" %}}
Küçük resim yenilemeyi devre dışı bırakmak, bir PPTX dosyasının kaydedilme süresini azaltabilir.
{{% /alert %}}

## **Kaydetme İlerleyişini Yüzde Olarak Güncelle**

Bir kaydetme işlemini izlemek için, [IProgressCallback](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprogresscallback/) arayüzünü uygulayan bir Java vekil nesnesi sağlayın ve bu vekili [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveoptions/#setProgressCallback) yöntemine geçirin. Aspose.Slides, dışa aktarım sırasında ilerleme değerlerini [IProgressCallback::reporting](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iprogresscallback/#reporting-double-) yöntemiyle çağırır.

Aşağıdaki örnek bir PDF dışa aktarmasının ilerlemesini konsola raporlar:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Not" %}}
Aspose, Aspose.Slides API'sı ile oluşturulmuş ücretsiz bir [PowerPoint Splitter](https://products.aspose.app/slides/tr/splitter) sunar. Bu araç, bir sunumdan seçilen slaytları ayrı PPT veya PPTX dosyaları olarak kaydeder.
{{% /alert %}}

## **SSS**

**Aspose.Slides artımlı veya “hızlı kaydetme”yi destekliyor mu?**

Hayır. Her kaydetme işlemi, sadece değişen bölümleri güncellemek yerine tam bir çıktı dosyası yazar.

**Birden fazla iş parçacığı aynı Presentation örneğini kaydedebilir mi?**

Hayır. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği [thread‑safe değildir](/slides/tr/php-java/multithreading/). Her örneğe aynı anda yalnızca bir iş parçacığından erişin ve kaydedin.

**Bir sunumu kaydettiğimde hiper bağlantılar ve harici bağlı dosyalar ne olur?**

[Hyperlinks](/slides/tr/php-java/manage-hyperlinks/) sunumda kalır. Aspose.Slides harici bağlı dosyaları kopyalamaz, bu nedenle kaydedilen sunum hâlâ bunların konumlarına erişebilmelidir.

**Yazar, başlık, şirket ve oluşturma tarihi gibi belge meta verilerini kaydedebilir miyim?**

Evet. Kaydetmeden önce uygun [document properties](/slides/tr/php-java/presentation-properties/) ayarını yapın; Aspose.Slides bunları çıktı dosyasına yazar.