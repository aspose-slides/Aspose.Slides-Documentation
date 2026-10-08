---
title: PHP Kullanarak Sunumlarda Yazı Tipi İkamesi Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/php-java/font-substitution/
keywords:
- yazı tipi
- ikame yazı tipi
- yazı tipi ikamesi
- yazı tipini değiştir
- yazı tipi değişimi
- ikame kuralı
- değişim kuralı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını render ederken veya dönüştürürken, PHP için Aspose.Slides'te yazı tipi ikamesi kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'in bir sunum render edildiğinde veya dönüştürüldüğünde erişilemeyen bir yazı tipinin yerinde kullanılabilir bir yazı tipini kullanmasını sağlar. İkame, oluşturulan çıktıyı etkiler; sunum içeriğine atanmış yazı tipini değiştirmez.

Belirli bir yazı tipi mevcut olmadığında kullanılacak yazı tipini tanımlayabilir ve Aspose.Slides'in render sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü yazı tiplerine sahip ortamlar arasında çıktının tutarlı kalmasına yardımcı olur.

[Özel Kalın Yazı Tipi Olmayan Yazı Tiplerinin İşlenmesi](/slides/tr/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Bu bölüm, PDF dışa aktarımı sırasında etkilenen metnin nasıl rasterleştirileceğini ve metin seçimi, arama ve ölçeklendirme üzerindeki sonuçları açıklar.

## **Yazı Tipi İkame İşlemlerini Al**

Sunum render edildiğinde hangi yazı tiplerinin ikame edileceğini belirlemek için [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) metodunu kullanın. Metod, orijinal ve ikame edilen yazı tipi adlarını belirten [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

Aşağıdaki PHP örneği bir sunum için tüm yazı tipi ikamelerini listeler:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Seçili Slaytlar İçin Yazı Tipi İkame İşlemlerini Al**

Belirli slaytları render etmek için gerekli ikameleri yalnızca incelemek amacıyla `int[] slides` argümanıyla birlikte [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) aşırı yüklemesini kullanın. Bu, bir sunumun bir bölümünü render ederken veya dışa aktarırken, büyük bir sunumu artımlı olarak kontrol ederken, mevcut olmayan yazı tiplerine bağımlı slaytları bulurken, bir sunucu veya konteyner için minimal bir yazı tipi paketi hazırlarken veya ilişkili olmayan slaytları işlemeksizin render farklarını teşhis ederken yararlıdır.

`slides` dizisi tek tabanlı slayt indeksleri içerir: `1` ilk slaytı tanımlar. Buna karşılık, [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) koleksiyon erişicisi sıfır tabanlı indeksleme kullanır; bu nedenle aynı slayt `$presentation->getSlides()->get_Item(0)` şeklinde erişilir. Dizi oluştururken bu farkı aklınızda bulundurun ve bir‑off‑by‑one hatasından kaçının.

Aşırı yüklemeyi [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/) metodu aracılığıyla çağırın. Metod, seçili slaytlar render edilirken belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame edilen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, geçerli yazı tipi ortamını, yapılandırılmış geri dönüş kurallarını, bir [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) içinde depolanan ikame kurallarını ve [harici yüklenmiş yazı tiplerini](/slides/tr/php-java/custom-font/) yansıtır.

Aynı ikame birden fazla seçili slayt tarafından istenebilir. Bir yazı tipi envanteri veya ön uç raporu oluştururken sonuçları tekrar edenleri ayıklayın. Aşağıdaki örnek her döndürülen ikameyi raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) sınıfı her iki aşırı yüklemeyi de sağlar. Render işleminin kapsamına göre birini seçin:

| Aşırı Yükleme | Ne zaman kullanılmalı |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Tüm sunum için ikameler gerekir. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | Seçili bir aralık, artımlı kontrol veya kısmi dışa aktarım için ikameler gerekir. |

## **Yazı Tipi İkame Kurallarını Ayarla**

Bir kaynak yazı tipi mevcut olmadığında Aspose.Slides'in kullanması gereken yazı tipini belirtmek için:

1. Sunumu yükleyin.
2. Kaynak ve ikame yazı tipleri için yazı tipi tanımları oluşturun.
3. Bir [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) nesnesini [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/) koşulu ile oluşturun.
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/) koleksiyonuna ekleyin.
5. Koleksiyonu, [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) metodunu kullanarak atayın.
6. Sunumu render edin veya dönüştürün.

Aşağıdaki PHP örneği, `SomeRareFont` mevcut olmadığında `Arial` ile ikame eder ve ardından sonucu doğrulamak için ilk slaytı render eder. İkame yazı tipi Aspose.Slides tarafından erişilebilir olmalıdır.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Bir sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik için, [Yazı Tipi Değiştirme](/slides/tr/php-java/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri İçin Sınırlamalar**

Yazı tipi ikame kuralları, render ve dönüşüm sırasında kullanılan standart yazı tipi seçim sürecinin bir parçasıdır. Aspose.Slides, erişilemeyen bir yazı tipini kural tarafından belirtilen mevcut bir yazı tipine değiştirebildiğinde normal metin için çalışırlar.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides denklemin düzenini hesaplamak ve render etmek için tam olarak bu yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipini ikame eden bir kural, bu amaçla **Cambria Math**'ı değiştiremez ve render hâlâ **Cambria Math**'ın gerekli olduğunu bildirebilir.

Böyle bir sunumu render etmek veya dönüştürmek için **Cambria Math**'ı Aspose.Slides'a erişilebilir hâle getirin. İşletim sistemine kurun veya bir [harici yazı tipi](/slides/tr/php-java/custom-font/) olarak yükleyin.

Bu sınırlama denklemin düzeni için geçerlidir. Yukarıda açıklanan ikame kuralları normal sunum metni için hâlâ geçerlidir.

## **Sık Sorulan Sorular**

**Yazı Tipi Değiştirme ile Yazı Tipi İkamesi arasındaki fark nedir?**

[Yazı Tipi Değiştirme](/slides/tr/php-java/font-replacement/) kasıtlı olarak bir sunum boyunca bir yazı tipini diğerine değiştirir. Yazı tipi ikamesi, orijinal yazı tipi mevcut olmadığında gibi yapılandırılmış koşul karşılandığında render edilen çıktı için bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**

Kurallar, render ve dönüşüm sırasında [yazı tipi seçim dizisi](/slides/tr/php-java/font-selection-sequence/) sürecine katılır. `WhenInaccessible` ile, bir kural yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde kullanılır.

**Bir yazı tipi eksik olduğunda ve hiçbir ikame kuralı yapılandırılmadığında ne olur?**

Aspose.Slides, yazı tipi seçim sürecine göre en yakın mevcut yazı tipini seçer. Sonuç, çalışma zamanı ortamında mevcut olan yazı tiplerine bağlıdır.

**İkameyi önlemek için harici yazı tipleri yükleyebilir miyim?**

Evet. Aspose.Slides'in render ve dönüşüm sırasında kullanabilmesi için [harici yazı tiplerini yükleyin](/slides/tr/php-java/custom-font/).

**Aspose kütüphane ile birlikte yazı tiplerini dağıtıyor mu?**

Hayır. Yazı tiplerini sağlamak ve lisanslarına uymak sizin sorumluluğunuzdadır.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**

Evet. Yüklü yazı tipleri ve yazı tipi arama konumları işletim sistemine göre farklılık gösterir; bir makinede mevcut bir yazı tipi, başka bir makinede ikame gerektirebilir.

**Toplu dönüştürmelerde yazı tipi seçiminde tutarlılığı nasıl sağlayabilirim?**

Her makine veya konteynerde aynı yazı tipi dosyalarını ve sürümlerini kullanın, [gerekli harici yazı tiplerini yükleyin](/slides/tr/php-java/custom-font/) ve lisans izin veriyorsa [yazı tiplerini gömün](/slides/tr/php-java/embedded-font/). Ayrıca dışa aktarmadan önce beklenmedik ikameleri belirlemek için [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) metodunu çağırabilirsiniz.