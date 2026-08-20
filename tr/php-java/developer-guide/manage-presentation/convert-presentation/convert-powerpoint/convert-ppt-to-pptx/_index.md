---
title: PHP'de PPT'yi PPTX'e Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/php-java/convert-ppt-to-pptx/
keywords:
- PowerPoint dönüştürme
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPT'den PPTX'e
- PPT'yi PPTX olarak kaydet
- PPT'yi PPTX'e dışa aktar
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm, hata yönetimi ve doğruluk notları için PHP örneklerini içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint formatıdır, PPTX ise daha yeni Open XML formatıdır. Aspose.Slides for PHP via Java, bir PPT dosyasını yükleyebilir ve Microsoft PowerPoint olmadan PPTX olarak kaydedebilir. Bu makale, tek bir dosyayı veya bir dizindeki dosyaları nasıl dönüştüreceğinizi gösterir ve dönüşüm sonrası neyin doğrulanması gerektiğini açıklar.

## **Bir PPT Dosyasını PPTX'e Dönüştürme**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı ile yükleyin, ardından [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) yöntemini [SaveFormat::Pptx](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/#Pptx) ile çağırın. `finally` bloğu sunumu serbest bırakır ve kaynaklarını serbest bırakır.

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

Dosya uzantısı tek başına çıktı formatını seçmez; bu seçim [SaveFormat::Pptx](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/#Pptx) parametresi tarafından yapılır. Orijinal PPT dosyasını korumanız gerekiyorsa giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştürme**

Aşağıdaki örnek, bir dizindeki her `.ppt` dosyasını dönüştürür. Her dosya bağımsız olarak işlenir, bu yüzden bir dönüştürme hatası bütün toplu işin durmasını engellemez.

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

Üretim yükleri için, tam istisna kaydını tutun, mevcut bir çıktı dosyasının üzerine yazılıp yazılamayacağına karar verin ve başarısız dosya adlarını bir yeniden deneme veya inceleme kuyruğuna yazın. Bozuk dosyalar, gerekli şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içerikler dönüşümün başarısız olmasına neden olabilir. Şifreli dosyaları yüklemek için [Password-Protected Presentations](/php-java/password-protected-presentation/) bölümüne bakın.

## **Doğruluk ve Eski Özellikler**

Dönüştürme genellikle slaytları, masterları, yerleşimleri, metni, şekilleri, görüntüleri, tabloları ve grafikleri korur. Ancak PPT ve PPTX, her özelliği tam olarak aynı şekilde temsil etmez. Kütüphane tarafından desteklenmeyen veya PPTX eşdeğeri olmayan bir eski özellik, normalleştirilebilir, göz ardı edilebilir veya farklı şekilde görüntülenebilir.

Dönüştürülmüş dosyayı animasyonlar, geçişler, gömülü veya bağlı OLE nesneleri, ActiveX denetimleri, gömülü medya, nadir fontlar veya VBA makroları içerdiğinde kontrol edin. Düz bir PPTX dosyası makro etkin bir format değildir, bu nedenle VBA'nın kullanılabilir olması gerektiğinde uygun makro etkin bir iş akışı kullanın. Ayrıca, dönüştürülmüş sunumun açılacağı veya oluşturulacağı ortamda gerekli fontların ve dış kaynakların mevcut olduğundan emin olun.

Önemli belgeler için, oluşturulan PPTX'i programlı olarak yeniden açın ve ana slayt sayısını ve içeriğini inceleyin, ardından görünümünü ve slayt gösterisi davranışını hedeflenen görüntüleyicide karşılaştırın. Başarılı bir [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) çağrısını, her eski özelliğin tam bir PPTX temsiline sahip olduğunun kanıtı olarak kabul etmeyin.

## **Ne Zaman PPTX Kullanmalı**

Sunum mevcut PowerPoint sürümlerinde düzenlenecek, Open XML paketleriyle çalışan sistemlerle değiş tokuş edilecek veya eski ikili PPT'ye göre incelenmesi ve kurtarılması daha kolay bir formatta saklanacaksa PPTX kullanın. Dönüştürülmüş sunum doğruluk kontrollerinizi geçtiğinde orijinal PPT'yi arşiv veya geri dönüş kopyası olarak tutun.

PDF, HTML, görüntüler, XPS veya başka bir çıktı türüne ihtiyaç duyuyorsanız, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruyacağını varsaymak yerine [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) bölümündeki formata özgü yönergeleri kullanın.

## **Çevrimiçi Dönüştürücü**

Ara sıra bir dosya veya hızlı bir karşılaştırma için [online PPT to PPTX converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) adresini kullanabilirsiniz. Tekrarlanabilir dönüşümler, toplu işlem veya uygulama seviyesinde hata yönetimi için PHP API'sini kullanın.

## **İlgili Makaleler**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [PHP'de Sunumları Kaydet](/php-java/save-presentation/)
- [Desteklenen Dosya Biçimleri](/php-java/supported-file-formats/)
- [PHP'de Sunumları Aç](/php-java/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for PHP via Java, sunum dosyalarını Microsoft PowerPoint gerektirmeden yükler ve kaydeder.

**PPT'den PPTX'e dönüşüm tüm içeriği tam olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski ya da desteklenmeyen özellik için tam doğruluk garanti edilmez. Makrolar, OLE veya ActiveX nesneleri, medya, özel animasyonlar veya nadir fontlar içerdiğinde oluşturulan dosyayı kontrol edin.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız. Eksik veya hatalı şifre, yükleme işleminin başarısız olmasına neden olur.

**Dönüşümden sonra PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i sizin için önemli olan görüntüleyiciler ve iş akışlarında doğrulayana kadar saklayın. Bu, bir eski özelliğin farklı dönüştürülmesi durumunda geri dönüş kopyası sağlar.