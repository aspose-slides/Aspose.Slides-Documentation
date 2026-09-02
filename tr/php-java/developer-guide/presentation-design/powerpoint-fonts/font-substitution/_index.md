---
title: PHP Kullanarak Sunumlarda Yazı Tipi İkamesini Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/php-java/font-substitution/
keywords:
- yazı tipi
- ikame yazı tipi
- yazı tipi ikamesi
- yazı tipini değiştirme
- yazı tipi değiştirme
- ikame kuralı
- değiştirme kuralı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını işleme veya dönüştürme sırasında, Java aracılığıyla PHP için Aspose.Slides içinde yazı tipi ikame kurallarını yapılandırın ve ikame edilen yazı tiplerini inceleyin."
---
## **Genel Bakış**

Yazı tipi ikamesi, Aspose.Slides'in bir sunum işlendiğinde veya dönüştürüldüğünde erişilemeyen bir yazı tipinin yerine kullanılabilir bir yazı tipini kullanmasına olanak tanır. İkame, işlenen çıktıyı etkiler; sunum içeriğine atanmış yazı tipini değiştirmez.

Belirli bir yazı tipi mevcut olmadığında kullanılacak yazı tipini tanımlayabilir ve Aspose.Slides'in işleme sırasında yapacağı ikameleri inceleyebilirsiniz. Bu, farklı yüklü yazı tiplerine sahip ortamlarda çıktının tutarlı kalmasına yardımcı olur.

## **Yazı Tipi İkamelerini Alın**

Sunum işlendiğinde hangi yazı tiplerinin ikame edileceğini belirlemek için [FontsManager::getSubstitutions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/getsubstitutions/) yöntemini kullanın. Yöntem, orijinal ve ikame edilen yazı tipi adlarını tanımlayan [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsubstitutioninfo/) nesnelerini döndürür.

Aşağıdaki PHP örneği, bir sunum için tüm yazı tipi ikamelerini listeler:

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

## **Seçili Slaytlar İçin Yazı Tipi İkamelerini Alın**

Yalnızca belirli slaytların işlenmesi için gerekli ikameleri incelemek üzere, `int[] slides` bağımsız değişkeniyle [FontsManager::getSubstitutions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/getsubstitutions/) aşırı yüklemesini kullanın. Bu, bir sunumun bir kısmını işlediğinizde, büyük bir sunumu art art kontrol ettiğinizde, erişilemeyen yazı tiplerine bağımlı slaytları bulmak istediğinizde, bir sunucu veya konteyner için minimum bir yazı tipi paketi hazırlarken veya ilişkili olmayan slaytları işlemeye gerek kalmadan işleme farklılıklarını teşhis ederken yararlıdır.

`slides` dizisi bir‑tabanlı slayt indeksleri içerir: `1` ilk slaytı gösterir. Buna karşıt olarak, [Presentation::getSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSlides) koleksiyon erişicisi sıfır‑tabanlı indeksleme kullanır; bu yüzden aynı slayt `$presentation->getSlides()->get_Item(0)` ile erişilir. Dizi oluştururken bu farkı aklınızda tutun, aksi takdirde bir‑bir eksik hata alabilirsiniz.

Aşırı yüklemeyi [Presentation::getFontsManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getFontsManager) yöntemiyle çağırın. Yalnızca seçili slaytlar işlenirken belirlenen ikameleri döndürür. Her sonuç, orijinal ve ikame edilen yazı tipi adlarını içeren bir [FontSubstitutionInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsubstitutioninfo/) nesnesidir. Sonuç, mevcut yazı tipi ortamını, yapılandırılmış yedekleme kurallarını, bir [FontSubstRuleCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsubstrulecollection/) içinde depolanan ikame kurallarını ve [harici yüklenmiş yazı tiplerini](/slides/tr/php-java/custom-font/) yansıtır.

Aynı ikame, birden fazla seçili slayt tarafından talep edilebilir. Bir yazı tipi envanteri veya ön kontrol raporu oluştururken sonuçları tekilleştirin. Aşağıdaki örnek, döndürülen her ikameyi raporlar ve ardından benzersiz yazı tipi eşlemelerinin sıralı bir listesini oluşturur:

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

[FontsManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/) sınıfı her iki aşırı yüklemeyi de sağlar. İşleme işleminin kapsamına göre birini seçin:

| Aşırı Yükleme | Ne Zaman Kullanılır |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/getsubstitutions/) argüman olmadan | Tüm sunum için ikameler gerekirken. |
| [getSubstitutions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/getsubstitutions/) `int[] slides` ile | Seçili bir aralık, art art kontrol veya kısmi dışa aktarım için ikameler gerekirken. |

## **Yazı Tipi İkame Kurallarını Ayarlayın**

Kaynak bir yazı tipi kullanılamadığında Aspose.Slides'in hangi yazı tipini kullanacağını belirtmek için:

1. Sunumu yükleyin.
2. Kaynak ve ikame yazı tipleri için yazı tipi tanımları oluşturun.
3. [WhenInaccessible](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsubstcondition/) koşuluyla bir [FontSubstRule](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsubstrule/) oluşturun.
4. Kuralı bir [FontSubstRuleCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsubstrulecollection/) içine ekleyin.
5. Koleksiyonu [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/) yöntemiyle atayın.
6. Sunumu işleyin veya dönüştürün.

Aşağıdaki PHP örneği, `SomeRareFont` kullanılamadığında `Arial` ile ikame eder ve ardından ilk slaytı işleyerek sonucu doğrular. İkame edilen yazı tipinin Aspose.Slides tarafından erişilebilir olması gerekir.

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
Sunum boyunca kullanılan yazı tiplerinde koşulsuz bir değişiklik için, [Yazı Tipi Değiştirme](/slides/tr/php-java/font-replacement/) bölümüne bakın.
{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri İçin Sınırlamalar**

Yazı tipi ikame kuralları, işleme ve dönüştürme sırasında kullanılan standart yazı tipi seçme sürecinin bir parçasıdır. Aspose.Slides bir erişilemeyen yazı tipini kuralda belirtilen kullanılabilir bir yazı tipiyle değiştirebildiğinde normal metin için çalışır.

Office Math denklemlerinin ek bir gereksinimi vardır. Bir denklem **Cambria Math** kullanıyorsa, Aspose.Slides denklemin yerleşimini hesaplamak ve işlemek için tam olarak bu yazı tipine ihtiyaç duyabilir. **STIX Two Math** gibi başka bir matematik yazı tipine ikame eden bir kural, bu amaçla **Cambria Math** yerine geçemez; işleme hâlâ **Cambria Math** gerektiğini raporlayabilir.

Böyle bir sunumu işlemek veya dönüştürmek için **Cambria Math**'i Aspose.Slides'e erişilebilir kılın. İşletim sistemine kurun veya bir [harici yazı tipi](/slides/tr/php-java/custom-font/) olarak yükleyin.

Bu sınırlama sadece denklem yerleşimini etkiler. Yukarıda açıklanan ikame kuralları normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Yazı tipi değiştirme ile yazı tipi ikamesi arasındaki fark nedir?**

[Font replacement](/slides/tr/php-java/font-replacement/) sunum genelinde bir yazı tipini bilinçli olarak başka birine değiştirir. Yazı tipi ikamesi, yapılandırılmış koşul karşılandığında (örneğin orijinal yazı tipi kullanılamadığında) işlenen çıktıya bir yazı tipi seçer.

**İkame kuralları ne zaman uygulanır?**

Kurallar, işleme ve dönüştürme sırasında [font selection sequence](/slides/tr/php-java/font-selection-sequence/) içinde yer alır. `WhenInaccessible` ile bir kural yalnızca Aspose.Slides kaynak yazı tipine erişemediğinde kullanılır.

**Bir yazı tipi eksik ve ikame kuralı yapılandırılmamışsa ne olur?**

Aspose.Slides, yazı tipi seçim sürecine göre en yakın kullanılabilir yazı tipini seçer. Sonuç, çalışma zaman ortamındaki mevcut yazı tiplerine bağlıdır.

**Harici yazı tipleri yükleyerek ikameleri önleyebilir miyim?**

Evet. Aspose.Slides'in işleme ve dönüştürme sırasında kullanabilmesi için [harici yazı tipleri yükleyebilirsiniz](/slides/tr/php-java/custom-font/).

**Aspose, kütüphane ile birlikte yazı tipleri dağıtıyor mu?**

Hayır. Yazı tiplerini sağlamak ve lisanslarına uymak sizin sorumluluğunuzdadır.

**İkame sonuçları Windows, Linux ve macOS arasında farklılık gösterebilir mi?**

Evet. Yüklü yazı tipleri ve yazı tipi arama konumları işletim sistemine göre değişir; bir makinede mevcut olan bir yazı tipi diğerinde ikame gerektirebilir.

**Toplu dönüştürmelerde yazı tipi seçimini tutarlı nasıl yapabilirim?**

Her makine veya konteynerde aynı yazı tipi dosyalarını ve sürümlerini kullanın, [gerekli harici yazı tiplerini yükleyin](/slides/tr/php-java/custom-font/) ve lisans izin veriyorsa [yazı tiplerini gömün](/slides/tr/php-java/embedded-font/). Ayrıca dışa aktarmadan önce beklenmedik ikameleri tespit etmek için [FontsManager::getSubstitutions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontsmanager/getsubstitutions/) metodunu çağırabilirsiniz.