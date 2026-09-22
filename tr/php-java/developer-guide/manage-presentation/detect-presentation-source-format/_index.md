---
title: PHP'de Orijinal Sunum Formatını Belirleme
linktitle: Kaynak Format
type: docs
weight: 35
url: /tr/php-java/detect-presentation-source-format/
keywords:
- kaynak format
- sunum formatını tespit et
- PowerPoint
- OpenDocument
- sunum
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile yüklü bir sunumun orijinal formatını okuyun, algılama API'lerini karşılaştırın ve dosyaları, akışları ve eski formatları yönetin."
---
## **Genel Bakış**

Bir sunumu yükledikten sonra, orijinal formatını belirlemek için [Presentation::getSourceFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSourceFormat) yöntemini çağırın. Mevcut örneğin yüklendiği formata bağlı sonraki işlemler gerektiğinde bunu kullanın.

Kaynak format, bir çıktı dosyası için seçilen [SaveFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/) formatından farklıdır. Başka bir formata kaydetmek, mevcut örneğin kaynak formatını değiştirmez.

## **Bir Dosyanın Kaynak Formatını Okuma**

Bu örnek mevcut bir `sample.pptx` dosyası gerektirir. Dosyayı yükler ve dosya adını kullanmak yerine [Presentation::getSourceFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSourceFormat) kullanarak bir uygulama işleme politikasını seçer. Başka formatları denemek için giriş yolunu değiştirin. Örnek seçilen politikayı yazdırır; mesajları uygulamanızın mantığıyla değiştirin.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **Desteklenen Değerleri Tanıma**

[SourceFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sourceformat/) sınıfı aşağıdaki sunum formatlarını ayırt eden tamsayı sabitlerini tanımlar. Aşağıdaki uzantılar geleneksel uzantılardır, orijinal dosya adının yeniden oluşturulması değildir.

| SourceFormat değeri | Uzantı | Biçim |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 sunumu |
| `Pptx` | `.pptx` | Office Open XML sunumu |
| `Pptm` | `.pptm` | Makrolu Office Open XML sunumu |
| `Pps` | `.pps` | PowerPoint 97–2003 slayt gösterisi |
| `Ppsx` | `.ppsx` | Office Open XML slayt gösterisi |
| `Ppsm` | `.ppsm` | Makrolu Office Open XML slayt gösterisi |
| `Pot` | `.pot` | PowerPoint 97–2003 şablonu |
| `Potx` | `.potx` | Office Open XML şablonu |
| `Potm` | `.potm` | Makrolu Office Open XML şablonu |
| `Odp` | `.odp` | OpenDocument sunumu |
| `Otp` | `.otp` | OpenDocument sunum şablonu |
| `Fodp` | `.fodp` | Düz XML ODF sunumu |
| `Xml` | `.xml` | PowerPoint XML sunumu |

## **Bir Akışın Kaynak Formatını Okuma**

Bu örnek mevcut bir `sample.pps` dosyası gerektirir. Baytlarını bir bellek akışına okuma, dosya adı olmadan alınan girişleri, örneğin bir veritabanı değeri veya yüklenmiş bayt dizisini modellenir. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) yapıcısı yalnızca akışı alır.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT, PPS ve POT aynı temel ikili formatı kullanır. Dosya yolu ile yüklerken uzantı bir slayt gösterisi veya şablonu ayırt etmeye yardımcı olabilir. Dosya adı olmadan eski PPS ve POT içeriği `SourceFormat::Ppt` olarak raporlanabilir; yukarıdaki PPS örneği `SourceFormat::Ppt` tamsayı değerini yazdırır.

Uygulamanızın bu ayrımı koruması gerekiyorsa, orijinal dosya adını veya alt tip meta verisini ayrı tutun. Uzantı bu eski alt tipler için faydalı bir ipucu olsa da, rastgele bir sunum içeriğini tanımlamanın tek temeli olmamalıdır.

## **Yüklemeden Önce ve Sonra Algılamayı Karşılaştırma**

Bir dosyayı tam sunum nesne modeline yüklemeden önce incelemeniz gerektiğinde [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) ve [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationinfo/#getLoadFormat) kullanın. Örnek zaten mevcutsa [Presentation::getSourceFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSourceFormat) kullanın.

Bu örnek `sample.pptx` gerektirir ve sırasıyla `LoadFormat::Pptx` ve `SourceFormat::Pptx` tamsayı değerlerini yazdırır. Üretimde, işlem aşamanıza uygun API'yi seçin; zaten yüklenmiş bir sunum, sadece kaynak formatını elde etmek için ikinci bir inceleme gerektirmez.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Sonuçlar farklı sınıflardan gelen sabitleri kullanır: [LoadFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadformat/) ve [SourceFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sourceformat/). Sayısal değerlerini karşılaştırmayın veya her formatın aynı algılamaya sahip olduğunu varsaymayın. PowerPoint XML, yüklemeden önce `LoadFormat::Unknown` ve yüklendikten sonra `SourceFormat::Xml` olarak raporlanabilir.

## **Kaynak ve Çıktı Formatlarını Ayrı Tutma**

Bu örnek `sample.pptx` gerektirir ve `converted.odp` yazar. Orijinal örneği kaydetmeden önce ve sonra `SourceFormat::Pptx` tamsayı değerini yazdırır. ODP çıktısından yüklenen yeni örnek yalnızca `Odp` raporlar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

`new Presentation()` ile sıfırdan oluşturulan bir sunum `SourceFormat::Pptx` rapor eder. Giriş dosyası yoktur: bu yeni oluşturulan bir örnek için varsayılan değerdir, bir PPTX dosyasının yüklendiğinin kanıtı değildir. Bu ayrım önemliyse, uygulamanızın örneği oluşturup oluşturmadığını ayrı olarak izleyin.

## **Bir Kaynak Formatını Uzantıya Eşleme**

Aşağıdaki örnek `sample.pptx` gerektirir. Mevcut desteklenen her [SourceFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sourceformat/) değerini giriş dosya adını ayrıştırmadan geleneksel bir uzantıya eşler. Yedekleme, tanınmayan bir değere sessizce uzantı atanmasını önler.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Bu eşleme bir dosyayı dönüştürmez veya akış yüklemesi sırasında kaybolan eski bir PPS/POT alt tipini geri getirmez. Gerçek kaydetme için bir [SaveFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/) seçin veya [Sunumları Orijinal Formatlarında Kaydet](/slides/tr/php-java/save-presentation/#save-presentations-in-their-original-format) bölümünde gösterilen dönüşümü kullanın.

## **Kaydedip Tekrar Açarak Formatları Doğrulama**

Bu bağımsız örnek bir sunum oluşturur ve çalışma dizininde üç dosya yazar; aynı adlardaki dosyaları üzerine yazar. Her çıktıyı hem yol ile hem de bellek akışı aracılığıyla yeniden açar. PPTX ve ODP için her iki yol da kaydedilen formatı rapor eder. PPS için yol ile yükleme `Pps` rapor ederken, aynı baytlar dosya adı olmadan yüklendiğinde `Ppt` rapor eder.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Aşağıdaki tablo, aynı uzantılara sahip sunumlar için kaynak formatı tanımlamasını özetler. İsimler sabitleri gösterir; PHP örnekleri tamsayı değerlerini yazdırır:

| Kaydedilen format | Dosya yolundan SourceFormat | İsimsiz akıştan SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` sırasıyla | Dosya yolu ile aynı |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` sırasıyla | Dosya yolu ile aynı |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` sırasıyla | Dosya yolu ile aynı |
| ODP, OTP | `Odp`, `Otp` sırasıyla | Dosya yolu ile aynı |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT içeriği, isimsiz akışlar için `Ppt` olarak tanımlanır. Tablo, format tanımlamasını açıklar, dönüşüm sırasında her sunum özelliğinin korunmasını değil.

## **SSS**

**PPTX'ten yüklenen bir sunumun ODP'ye kaydedilmesi kaynak formatı değiştirir mi?**  
Hayır. Mevcut örnek hâlâ `Pptx` rapor eder. Kaydedilen ODP dosyasından yüklenen bir örnek `Odp` rapor eder.

**Bir akış her zaman eski bir sunumu, slayt gösterisini ve şablonu ayırt edebilir mi?**  
Hayır. PPT, PPS ve POT aynı ikili formatı paylaşır. Bu ayrım gerektiğinde dosya adını veya alt tip meta verisini ayrı tutun.

**Sunum zaten yüklendiyse hangi API'yi kullanmalıyım?**  
[Presentation::getSourceFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSourceFormat) metodunu okuyun. Yüklemeden önce inceleme için [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentationfactory/#getPresentationInfo) kullanın.