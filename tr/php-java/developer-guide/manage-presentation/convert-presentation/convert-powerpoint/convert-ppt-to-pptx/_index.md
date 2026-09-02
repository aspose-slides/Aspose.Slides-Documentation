---
title: PHP'de PPT'yi PPTX'e Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/php-java/convert-ppt-to-pptx/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPT'den PPTX'e
- PPT'yi PPTX olarak kaydet
- PPT'yi PPTX'e dışa aktar
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm, hata yönetimi ve doğruluk notaları için PHP örnekleri içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint biçimidir, PPTX ise daha yeni Open XML biçimidir. Aspose.Slides for PHP via Java, bir PPT dosyasını Microsoft PowerPoint olmadan yükleyebilir ve PPTX olarak kaydedebilir. Bu makale, tek bir dosya ya da bir dizin içindeki dosyaları nasıl dönüştüreceğinizi gösterir ve dönüşümden sonra neyin doğrulanması gerektiğini açıklar.

## **PPT Dosyasını PPTX'e Dönüştürme**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı ile yükleyin, ardından [SaveFormat::Pptx](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/#Pptx) ile [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) yöntemini çağırın. `finally` bloğu sunumu temizler ve kaynaklarını serbest bırakır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Eski PPT sunumunu yükle.
$presentation = new Presentation("presentation.ppt");
try {
    // Sunumu PPTX formatında kaydet.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dosya uzantısı tek başına çıktı formatını seçmez; bunu [SaveFormat::Pptx](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/#Pptx) argümanı yapar. Orijinal PPT dosyasını korumanız gerekiyorsa giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştürme**

Aşağıdaki örnek, bir dizindeki her `.ppt` dosyasını dönüştürür. Her dosya bağımsız olarak işlenir, böylece bir dönüşüm hatası diğer toplu işlemleri durdurmaz.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

Üretim iş yükleri için, tam istisna kaydını tutun, mevcut bir çıktı dosyasının üzerine yazılıp yazılamayacağını belirleyin ve başarısız dosya adlarını yeniden deneme ya da inceleme kuyruğuna yazın. Bozuk dosyalar, gerekli şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içerik dönüşümün başarısız olmasına neden olabilir. Şifreli dosyaları yüklemek için [Password-Protected Presentations](/slides/tr/php-java/password-protected-presentation/) bölümüne bakın.

## **Doğruluk ve Eski Özellikler**

Dönüştürme genellikle slaytları, ana şablonları, yerleşimleri, metni, şekilleri, resimleri, tabloları ve grafikleri korur. Ancak, PPT ve PPTX her özelliği tam olarak aynı şekilde temsil etmez. Kütüphane tarafından desteklenmeyen veya PPTX karşılığı olmayan bir eski özellik, normalleştirilebilir, atlanabilir veya farklı gösterilebilir.

Dönüştürülmüş dosyayı, animasyonlar, geçişler, gömülü veya bağlanmış OLE nesneleri, ActiveX denetimleri, gömülü medya, yaygın olmayan yazı tipleri veya VBA makroları içerdiğinde kontrol edin. Düz bir PPTX dosyası makro destekli bir format değildir; VBA'nın mevcut olması gerektiğinde uygun bir makro‑destekli iş akışı kullanın. Ayrıca, dönüştürülmüş sunumun açılacağı veya işleneceği ortamda gerekli yazı tiplerinin ve dış kaynakların bulunduğunu doğrulayın.

Önemli belgeler için, oluşturulan PPTX'i programlı olarak yeniden açın ve ana slayt sayısı ile içeriğini inceleyin, ardından istenen görüntüleyicide görünümünü ve slayt gösterisi davranışını karşılaştırın. Başarılı bir [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) çağrısını, her eski özelliğin tam bir PPTX temsiline sahip olduğunun kanıtı olarak değerlendirmeyin.

## **PPTX Ne Zaman Kullanılmalı**

Sunum, güncel PowerPoint sürümlerinde düzenlenecek, Open XML paketleriyle çalışan sistemlerle değiş tokuş edilecek veya eski ikili PPT'ye göre incelemesi ve geri kazanması daha kolay bir formatta saklanacaksa PPTX kullanın. Dönüştürülmüş sunum doğruluk kontrollerinizi geçene kadar orijinal PPT'yi arşiv veya geri dönüş kopyası olarak tutun.

PDF, HTML, resimler, XPS veya başka bir çıktı türüne ihtiyacınız varsa, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruyacağını varsaymak yerine [Convert Presentations to Multiple Formats](/slides/tr/php-java/convert-presentation/) bölümündeki biçim‑özel yönlendirmeyi kullanın.

## **Çevrimiçi Dönüştürücü**

Ara sıra bir dosya veya hızlı bir karşılaştırma için [online PPT to PPTX converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) kullanabilirsiniz. Tekrarlanabilir dönüşümler, toplu işleme veya uygulama‑seviyesinde hata yönetimi için PHP API'yi kullanın.

## **İlgili Makaleler**

- [PPT vs PPTX](/slides/tr/php-java/ppt-vs-pptx/)
- [PHP'de Sunumları Kaydet](/slides/tr/php-java/save-presentation/)
- [Desteklenen Dosya Biçimleri](/slides/tr/php-java/supported-file-formats/)
- [PHP'de Sunumları Aç](/slides/tr/php-java/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for PHP via Java, Microsoft PowerPoint gerektirmeden sunum dosyalarını yükler ve kaydeder.

**PPT'den PPTX'e dönüşüm tüm içeriği tam olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski veya desteklenmeyen özellik için tam doğruluk garanti edilmez. Oluşturulan dosyayı, makrolar, OLE veya ActiveX nesneleri, medya, özelleşmiş animasyonlar veya yaygın olmayan yazı tipleri içerdiğinde gözden geçirin.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız. Eksik veya hatalı şifre, yükleme işleminin başarısız olmasına neden olur.

**Dönüşümden sonra PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i sizin için önemli olan görüntüleyicilerde ve iş akışlarında doğrulayana kadar tutun. Bu, bir eski özelliğin farklı dönüştürülmesi durumunda geri dönüş kopyası sağlar.