---
title: PHP'de Betik-Özgü Tema Yazı Tiplerini Yönet
linktitle: Betik-Özgü Tema Yazı Tipleri
type: docs
weight: 15
url: /tr/php-java/script-specific-font-mappings/
keywords:
- betik özgü yazı tipi
- tema yazı tipi eşlemesi
- çok dilli sunum
- yazı sistemi
- Kiril yazı tipi
- Arapça yazı tipi
- Japonca yazı tipi
- Gürcüce yazı tipi
- Thaana yazı tipi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PHP için Java aracılığıyla Aspose.Slides kullanarak PowerPoint temalarında betik-özel yazı tipi eşlemelerini inceleyin, ekleyin, değiştirin ve kaldırın."
---
## **Genel Bakış**

Bir sunum teması, farklı yazı sistemleri için farklı yazı tipi aileleri seçebilir. Bu, hâlâ tema yazı tiplerini kullanan çok dilli metnin, Kiril, Arapça, Japonca, Gürcüce, Thaana ve diğer betikler için uygun yazı tiplerini kullanırken tek bir koordineli yazı tipi şeması izleyebilmesini sağlar.

Tema’nın [FontScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontscheme/) içinde genellikle başlıklar için kullanılan bir ana yazı tipi koleksiyonu ve genellikle gövde metin için kullanılan bir ikincil yazı tipi koleksiyonu bulunur. Latin ve Doğu Asya yazı tipi ayarlarına ek olarak, her iki [Fonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fonts/) koleksiyonu da yazı‑sistemi etiketlerinden yazı tipi aile adı eşlemelerine izin verir.

Bu makale, sunumun ana temasındaki bu eşlemeleri nasıl inceleyeceğinizi ve değiştireceğinizi, ardından değişikliklerin kaydedilip yeniden yüklendikten sonra da korunup korunmadığını gösterir.

## **Betik Etiketlerini Anlama**

Betik yazı tipi yöntemleri, yazı sistemlerini tanımlamak için dört harfli BCP 47 betik alt etiketlerini kullanır. Yaygın değerler şunlardır:

| Betik etiketi | Yazı sistemi |
|---|---|
| `Cyrl` | Kiril |
| `Arab` | Arapça |
| `Hans` | Basitleştirilmiş Çince |
| `Jpan` | Japonca |
| `Geor` | Gürcüce |
| `Thaa` | Thaana |

Bu eşlemeler tema yazı tipi şemasına aittir, tek tek metin bölümlerine değil. Bir sunum, ana ve ikincil koleksiyonlar için farklı eşlemeler tanımlayabilir ve bazı betikler için eşleme bırakmayabilir.

## **Betik Yazı Tipi Eşlemelerine Erişme ve İnceleme**

Sunum seviyesindeki temaya erişmek için [Presentation::getMasterTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getMasterTheme) kullanın. [MasterTheme::getFontScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontscheme/#getMajor) ve [FontScheme::getMinor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontscheme/#getMinor) yöntemleri iki [Fonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fonts/) koleksiyonuna erişim sağlar.

Bir koleksiyondaki tüm eşlemeleri almak için [Fonts::getScriptFontMap](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fonts/#getScriptFontMap) çağırın. Tek bir yazı sistemini bulmak için ise betik etiketiyle [Fonts::getScriptFont](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fonts/#getScriptFont) kullanın. İstenen eşleme tanımlı değilse `Fonts::getScriptFont` `null` döndürür.

## **Eşlemeleri Değiştirip Kalıcılığını Doğrulama**

Bir eşleme oluşturmak veya mevcut yazı tipi ailesini değiştirmek için [Fonts::setScriptFont](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fonts/#setScriptFont) kullanın. Bir eşlemeyi kaldırmak için [Fonts::removeScriptFont](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fonts/#removeScriptFont) kullanın.

Aşağıdaki uçtan‑uza örnek, mevcut tüm ana ve ikincil eşlemeleri okur, Japonca ana yazı tipini bulur, Kiril ana yazı tipini değiştirir, Thaana ikincil eşlemesini kaldırır, sunumu kaydeder ve ardından her iki değişikliği de doğrulamak için yeniden açar. Kaldırma adımının başlangıç temasından bağımsız olmasını sağlamak için örnek, bir Thaana eşlemesi zaten tanımlı değilse yalnızca o zaman bir eşleme oluşturur.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

Doğrulama, sıradan bir arama ile aynı `null` davranışını kullanır: kaldırma kaydedildikten sonra `Fonts::getScriptFont("Thaa")` ikincil koleksiyon için `null` döndürür.

## **Tema Eşlemelerini Diğer Yazı Tipi Ayarlarından Ayırma**

Betik‑özelliği tema eşlemeleri yazı tipi seçiminde yer alır, ancak doğrudan metin biçimlendirme, ikame ve geri dönüş gibi farklı sorunları çözer:

| Mekanizma | Amaç | Tema eşlemesinin değiştirilmesinin etkisi |
|---|---|---|
| Betik‑özelliği tema yazı tipi eşlemesi | Bir yazı sistemi için ana ya da ikincil tema yazı tipini seçer. | İlgili tema yazı tipini hâlâ kullanan metin, yeni eşlenen aileye yönlendirilebilir. |
| Bir metin bölümüne açıkça atanmış yazı tipi | Tema yerine o bölüme istenen yazı tipi ailesini sabitler. | Bu bölüm, doğrudan biçimlendirmesi tema seçimini geçersiz kıldığı için değişmemiş kalabilir. |
| Yazı tipi ikamesi | İstenen yazı tipi mevcut olmadığında veya bir ikame kuralı uygulandığında onu değiştirir. | Yazı tipi istendikten sonra devreye girer; temanın betik eşlemesini yeniden tanımlamaz. |
| Yazı tipi geri dönüşü | Seçilen yazı tipinin içermediği glifleri, genellikle belirli Unicode aralıkları için sağlar. | Eksik glif kapsamını doldurur; saklanan tema eşlemesini değiştirmez. |

Son iki mekanizma hakkında daha fazla bilgi için [Font Substitution](/slides/tr/php-java/font-substitution/) ve [Fallback Fonts](/slides/tr/php-java/fallback-font/) sayfalarına bakın.

[Presentation::getMasterTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getMasterTheme) içindeki bir eşlemeyi değiştirmek, yalnızca etkili biçimlendirmesi hâlâ o temeye bağlı olan içerikleri etkiler. Metin, bir master, düzen veya slayt üzerinden bir tema geçersiz kılma alabilir ya da açıkça atanmış bir yazı tipi kullanabilir. Görünür sonuç temanın sunum‑seviyesindeki eşlemesini takip etmiyorsa bu katmanları inceleyin.

## **Eşlenen Yazı Tiplerini Kullanılabilir Hale Getirme ve Sonucu Doğrulama**

Betik eşlemesi yalnızca bir yazı tipi ailesi adını saklar; ilgili yazı tipi dosyasını kurmaz veya yüklemez. Tutarlı render ve dışa aktarma için, her eşlenen yazı tipinin ortamda kurulu olması ya da Aspose.Slides’a [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsloader/#loadExternalFonts) veya [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) gibi bir özel kaynak aracılığıyla sağlanması gerekir. Kullanılabilir yükleme seçenekleri için [Custom Fonts](/slides/tr/php-java/custom-font/) sayfasına bakın.

Kaydedilen eşlemenin doğrulanması yalnızca tema tanımının korunduğunu gösterir. Yazı tipinin mevcut olduğunu, gerekli bütün glifleri içerdiğini veya istenen düzeni ürettiğini kanıtlamaz. Her gerekli yazı sistemine ait temsilci metni bir resim ya da PDF’ye render edip çıktıyı inceleyin. Bu, eksik yazı tiplerini, yetersiz glif kapsamını, geri dönüş davranışını ve düzen değişikliklerini sunum dağıtılmadan önce yakalar. Render ve dışa aktarma örnekleri için [Convert PowerPoint Presentations](/slides/tr/php-java/convert-powerpoint/) sayfasına bakın.

## **SSS**

**`Fonts::getScriptFont` bir betik eşlenmediğinde ne döndürür?**

[Fonts::getScriptFont](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fonts/#getScriptFont) istenen betik eşlemesi o ana ya da ikincil koleksiyonda tanımlı değilse `null` döndürür.

**`Fonts::setScriptFont` betik zaten varsa ikinci bir eşleme ekler mi?**

Hayır. [Fonts::setScriptFont](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fonts/#setScriptFont) eksik olduğunda eşlemeyi oluşturur ve aynı betik etiketi zaten mevcutsa eşlenen yazı tipi ailesini değiştirir.

**Neden bir tema eşlemesi bazı metinleri etkilemedi?**

Metin, açıkça atanmış bir yazı tipine sahip olabilir, bir geçersiz kılma üzerinden farklı bir tema miras alabilir ya da render sırasında ikame ya da geri dönüşten etkileniyor olabilir. Sunum‑seviyesindeki betik eşlemesi yalnızca etkili biçimlendirmesi hâlâ o tema yazı tipi koleksiyonuna başvurduğunda metni kontrol eder.

**Kaydedip yeniden açmak çok dilli çıktıyı doğrulamak için yeterli mi?**

Hayır. Yeniden açma, tema verisinin kalıcılığını doğrular. Ayrıca her gerekli yazı sisteminden temsilci metni render edip eşlenen yazı tiplerinin mevcut ve gerekli glifleri içerdiğini onaylayın.