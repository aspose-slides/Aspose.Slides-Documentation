---
title: PHP ile Sunumlarda Yazı Tiplerini Gömme
linktitle: Gömülü Yazı Tipleri
type: docs
weight: 40
url: /tr/php-java/embedded-font/
keywords:
- yazı tipi ekle
- yazı tipi gömme
- yazı tipi gömme
- gömülü yazı tipini al
- gömülü yazı tipi ekle
- gömülü yazı tipini kaldır
- gömülü yazı tipini sıkıştır
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Java aracılığıyla PHP için Aspose.Slides ile PowerPoint'te gömülü yazı tiplerini yönetin. Yazı tiplerini ekleyin, alın, kaldırın ve sıkıştırın; metin görünümünü koruyun ve dosya boyutunu azaltın."
---
## **Giriş**

Gömülü yazı tipleri, yazı tipi verilerini bir PowerPoint sunumunun içine depolar. Bir görüntüleyici gömülü yazı tiplerini desteklediğinde, hedef sistemde kurulu olmasalar bile bu yazı tipleriyle metni gösterebilir. Bu, satır sonlarını, metin aralığını ve slayt düzenini korumaya yardımcı olur.

Aspose.Slides for PHP via Java, [FontsManager] sınıfı aracılığıyla gömülü yazı tiplerini almanıza, eklemenize ve kaldırmanıza olanak tanır; bu sınıf [Presentation::getFontsManager] tarafından döndürülür. Ayrıca, sunumun kullanmadığı karakterleri kaldırarak gömülü yazı tipi verilerinin boyutunu azaltabilirsiniz.

Aşağıdaki örnekler PPTX dosyalarıyla çalışır. Bir yazı tipini gömmeden önce, yazı tipi verilerinin Aspose.Slides tarafından erişilebilir olduğundan ve lisansının gömme izni verdiğinden emin olun.

## **Gömülü Yazı Tiplerini Al ve Kaldır**

[FontsManager::getEmbeddedFonts] metodunu kullanarak bir sunumda depolanan yazı tiplerini listeleyin. Birini kaldırmak için, listeden bir yazı tipini [FontsManager::removeEmbeddedFont] metoduna gönderin ve ardından sunumu kaydedin.

Aşağıdaki örnek `EmbeddedFonts.pptx` dosyasındaki gömülü yazı tiplerini listeler ve Calibri mevcutsa kaldırır:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Gömülü bir yazı tipini kaldırmak, saklanan yazı tipi verilerini siler; bu, metne atanmış yazı tipini değiştirmez. Yazı tipi hedef sistemde kuruluysa, metin hâlâ onu kullanabilir. Aksi takdirde, renderlama [yazı tipi ikamesi](/slides/tr/php-java/font-substitution/) gerektirebilir ve bu, düzeni etkileyebilir.

## **Yazı Tipi Verilerini ve Gömme İzinlerini İncele**

[FontsManager] sınıfını kullanarak yazı tiplerini gömmeden önce inceleyin. Sunumda kullanılan yazı tiplerini almak için [FontsManager::getFonts] metodunu çağırın. Her bir yazı tipi için bir [FontData] nesnesi ve gerekli [FontStyleType] değerini [FontsManager::getFontBytes] metoduna geçirin. Metod, ilgili yazı tipi stilinin ikili verilerini döndürür; istenen yazı tipi veya stil mevcut değilse `null` döner. `null` sonuçunu [FontsManager::getFontEmbeddingLevel] metoduna geçirmeyin, çünkü bu metod bir bayt dizisi bekler.

[EmbeddingLevel] bir bayrak sınıflandırmasıdır ve yazı tipinde depolanan gömme kısıtlamalarını raporlar:

- `Installable` gömülmeye ve başka bir sistemde kalıcı olarak kurulmaya izin verir; bu, yazı tipi lisansına tabidir.
- `Restricted` yalnızca kullanım izni bayrağı olarak `Restricted` tek başına olduğunda, yazı tipinin yasal sahibinden izin alınmadıkça gömülmesini yasaklar.
- `PreviewPrint` görüntüleme ve yazdırma için geçici kullanıma izin verir; yazı tipini içeren belge yalnızca okuma iznine sahip olmalıdır.
- `Editable` geçici kullanıma izin verir ve belgenin düzenlenip kaydedilmesine olanak tanır.
- `NoSubsetting` ek bir kısıtlamadır; yalnızca karakter alt kümesi gömmeyi engeller. Bu bayrak mevcutsa tüm karakterler gömülür.
- `BitmapOnly` ek bir kısıtlamadır; yalnızca bitmap stillerinin gömülmesine izin verir, dış hat verileri değil. Yazı tipinde bitmap stilleri yoksa gömülemez.

İlk dört değer kullanım iznini tanımlar, `NoSubsetting` ve `BitmapOnly` ise bunlarla birleştirilebilir. Modifikasyonları bit düzeyinde işlemlerle kontrol edin. `Installable` sıfır olduğu için kullanım-izin bitlerini maskeleyin ve sonucu `Installable` ile karşılaştırın, bayrak olarak kontrol etmeyin. Mevcut yazı tipleri en fazla bir kullanım-izin biti ayarlamalıdır. Birden fazla izin biti ayarlayan eski yazı tipleriyle uyumluluk sağlamak için aşağıdaki yardımcı, en az kısıtlayıcı izni seçer: `Editable`, ardından `PreviewPrint`, ardından `Restricted`.

Aşağıdaki örnek, `FontsManager::getFonts` tarafından döndürülen her yazı tipi için normal, kalın, italic ve kalın-italic verilerini denetler. Kullanılamayan stilleri, kısıtlı yazı tiplerini, yalnızca bitmap olanları, önizleme ve yazdırma ile sınırlı olanları (çıkış hâlâ düzenlenebilir olduğu için) ve zaten gömülmüş olanları atlar. Kullanılabilir bir stil `NoSubsetting` içeriyorsa, o yazı tipi ailesi için tüm karakterler gömülür.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bu inceleme, her yazı tipi dosyasına kodlanmış kısıtlamaları raporlar. Lisans vermeyi, yazı tipini yasal olarak elde ettiğinizi kanıtlamayı veya gömülü bir kopya dağıtmadan önce yazı tipinin lisans anlaşmasını kontrol etmeyi yerine geçmez.

## **Gömülü Yazı Tiplerini Ekle**

[FontsManager::addEmbeddedFont] metodunu kullanarak bir yazı tipini gömebilirsiniz. Aşırı yüklemeleri, bir [FontData] nesnesi ya da yazı tipi verilerini içeren bir bayt dizisi alabilir. [EmbedFontCharacters] enumu, hangi karakterlerin dahil edileceğini kontrol eder:

- `All` fonttaki tüm karakterleri gömer. Alıcıların sunumu düzenlemesi ve yeni metin girmesi gerektiğinde bu seçeneği kullanın.
- `OnlyUsed` sadece sunumda kullanılan karakterleri gömer, dosya boyutunu azaltır. Öncelikle görüntüleme amaçlı tamamlanmış bir sunum için bu seçeneği tercih edin.

Aşağıdaki örnek, `Fonts.pptx` dosyasında kullanılan yazı tiplerini almak için [FontsManager::getFonts] metodunu kullanır ve henüz gömülmemiş olanları gömer. Eklenecek yazı tiplerinin kodu çalıştıran makinede bulunması gerekir. Mevcut gömülü yazı tipleri mevcut karakter kümelerini korur.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gömülü Yazı Tiplerini Sıkıştır**

[Compress::compressEmbeddedFonts] metodu, kullanılmayan karakterleri kaldırarak gömülü yazı tipi verilerini azaltır. Zaten gömülü olan yazı tipleri üzerinde çalışır, bu nedenle boyut azalması, sunumda ne kadar kullanılmayan yazı tipi verisi olduğuna bağlıdır.

Aşağıdaki örnek `EmbeddedFonts.pptx` dosyasındaki yazı tiplerini sıkıştırır ve sonucu ayrı bir dosya olarak kaydeder:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Alıcıların ileride metin eklemesi gerekebileceği durumlar için orijinal dosyayı saklayın. Sıkıştırma sırasında kaldırılan karakterler, gömülü yazı tipinde artık mevcut olmaz; başlangıçta tüm karakterleri gömmüş olsanız bile.

## **SSS**

**Bir gömülü yazı tipinin renderlama sırasında hâlâ ikame edilip edilmeyeceğini nasıl kontrol edebilirim?**

Sunumu renderladığınız ortamda [FontsManager::getSubstitutions] metodunu çağırarak Aspose.Slides'in hangi yazı tiplerini değiştireceğini görebilirsiniz. Ayrıca [yazı tipi ikamesi](/slides/tr/php-java/font-substitution/) ayarlarını ve [yazı tipi geri dönüşü](/slides/tr/php-java/fallback-font/) kurallarını kontrol edin. Geri dönüş, eksik karakterleri ele alır; bu nedenle bir yazı tipini gömmek, yazı tipinin kendisinde bulunmayan karakterleri çözmez.

**Arial ve Calibri gibi yaygın yazı tiplerini gömmeli miyim?**

Kararı hedef ortama göre verin. Gerekli yazı tipleri, sunumu açan veya renderlayan her makinede mevcutsa, gömmek gereksiz dosya boyutu ekleyebilir. Alıcıların veya sunucuların bu yazı tiplerine sahip olmayabileceği durumlarda, lisansları izin veriyorsa gömmek istenen görünümü korumaya yardımcı olur.