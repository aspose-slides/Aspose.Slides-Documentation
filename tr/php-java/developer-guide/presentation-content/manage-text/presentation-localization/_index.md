---
title: PHP'de Sunum Yerelleştirmesini Otomatikleştirme
linktitle: Sunum Yerelleştirme
type: docs
weight: 100
url: /tr/php-java/presentation-localization/
keywords:
- dil değiştir
- imla denetimi
- imla denetimini devre dışı bırak
- düzeltme dili
- dil kimliği
- çok dilli metin
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PHP'de Aspose.Slides ile PowerPoint ve OpenDocument sunum metni için düzeltme dillerini ayarlayın, varsayılanlar ve çok dilli paragraflar dahil."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java, bireysel metin bölümleri için düzeltme meta verilerini yapılandırmanıza olanak tanır. Düzeltme dilini belirlemek için [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLanguageId) kullanın, imla denetimini izin vermek veya engellemek için [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setSpellCheck) kullanın ve daha geniş kanıtlamama durumunu kontrol etmek için [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setProofDisabled) kullanın. Bu ayarlar bölüm seviyesinde uygulandığından, bir paragraf birden çok dil ve farklı düzeltme kuralları içerebilir.

Bu makale, belirli bir metne dil atamayı, yeni metin için varsayılan dili [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) ile ayarlamayı, çok dilli paragraflar oluşturmayı, `SpellCheck` ve `ProofDisabled` arasında seçim yapmayı ve [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) kullanırken istenen ayarların korunmasını açıklar. Bu özellikler, sunum uygulamaları için meta veri depolar; metni çevirmez, sözlük tabanlı imla denetimi yapmaz veya hatalı sözcükleri döndürmez.

## **Metin için Düzeltme Dilini Ayarlama**

Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) oluşturun veya yükleyin, gerekli metin bölümüne [Portion::getPortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#getPortionFormat) aracılığıyla erişin ve dil tanımlayıcısını atayın. Aşağıdaki örnek bir şekil oluşturur, İngiliz İngilizcesini düzeltme dili olarak ayarlar ve sonucu [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#save) ile kaydeder:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Yeni Metin için Varsayılan Dili Ayarlama**

[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) kullanarak Aspose.Slides’in yeni oluşturulan metne atayacağı düzeltme dilini belirleyin. Bu ayar, bir sunumdaki çoğu veya tüm yeni metnin aynı dili kullandığında faydalıdır. Zaten açıkça bir dil belirtilmiş metnin dil meta verisini değiştirmez.

Aşağıdaki örnek, yeni metnin Almanca düzeltme kurallarını kullanmasını sağlar:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bir Paragrafta Birden Çok Dil Kullanma**

Bir [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) metin bölümlerinin bir koleksiyonunu içerir. Her dil için ayrı bir [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) oluşturun ve `LanguageId` değerini bağımsız olarak ayarlayın.

Bu örnek, İngilizce ve Fransızca bölümler içeren tek bir paragraf oluşturur:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bireysel Bölümler için İmla Denetimini Etkinleştirme veya Kapatma**

[PortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portionformat/) , [BasePortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/) tarafından tanımlanan ortak metin özelliklerini devralır. Bir bölümü [Portion::getPortionFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/#getPortionFormat) aracılığıyla formatına erişin ve [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setSpellCheck) kullanarak sunum uygulamasının o bölümde imla denetimi yapıp yapmayacağını kontrol edin. Varsayılan değer `false`’tır: `true` imla denetimine izin verir, `false` ise engeller.

Ayar, bireysel metin bölümlerine uygulanır. Aynı paragraftaki farklı bölümler bu nedenle farklı değerler kullanabilir. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLanguageId) ve `setSpellCheck` tamamlayıcı amaçlara hizmet eder: `setLanguageId` düzeltme dilini tanımlar, `setSpellCheck` ise bölüm için imla denetiminin izinli olup olmadığını belirler.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setProofDisabled) da düzeltmeyi kontrol eder, ancak daha geniş “kanıtlamama” durumunu bir [NullableBool](https://reference.aspose.com/slides/tr/php-java/aspose.slides/nullablebool/) olarak temsil eder. Yalnızca imla denetimi için doğrudan bir Boolean geçişine ihtiyacınız varsa `setSpellCheck` kullanın. Sunumun kanıtlamama meta verisini, `NotDefined` durumunu da dahil ederek korumak veya açıkça kontrol etmek istiyorsanız `setProofDisabled` kullanın. Her iki özelliği de ayarlarsanız değerlerin tutarlı olmasını sağlayın; `setSpellCheck(true)` ile `setProofDisabled(NullableBool::True)` birlikte kullanılmasın.

Bu özellikler, PowerPoint ve diğer sunum uygulamaları tarafından kullanılan düzeltme meta verisini yapılandırır. Aspose.Slides, bu bilgileri sözlük tabanlı imla denetimi yapmak veya hatalı sözcüklerin bir listesini döndürmek için kullanmaz.

Aşağıdaki tam örnek, bir giriş sunumu oluşturur, yükler, aynı paragraftaki iki bölüme farklı imla denetimi ayarları ve düzeltme dilleri atar, sonucu kaydeder, yeniden açar ve depolanan değerleri doğrular:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) aynı biçimlendirmeye sahip ardışık bölümleri birleştirir. Sadece `SpellCheck` farkı, bu bölümlerin ayrı kalmasını sağlamaz; birleştirildikten sonra elde edilen bölüm, ilk bölümün `SpellCheck` değerini korur. Bölümlerin farklı imla denetimi ayarlarına ihtiyacı varsa, bu ayarları atamadan önce `joinPortionsWithSameFormatting` çağırın veya oluşan bölüm sınırlarını inceleyerek ayarları sonradan yeniden uygulayın. Farklı `LanguageId` değerlerine sahip bölümler, düzeltme‑dili biçimlendirmeleri farklı olduğu için ayrı kalır.

## **SSS**

**Bir dil kimliği metni çevirir mi?**

Hayır. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLanguageId) imla ve dilbilgisi için düzeltme meta verisini depolar; metin içeriğini değiştirmez. Metni ayrı olarak çevirin ve ardından her çevrilen bölüm için uygun dil tanımlayıcısını ayarlayın.

**Düzeltme dili yazı tiplerini, heceleme ya da satır kaydırmayı kontrol eder mi?**

Hayır. Dil kimliği sadece düzeltme içindir. Metin görüntüleme ve düzenleme öncelikle mevcut [fonts](/slides/tr/php-java/powerpoint-fonts/), yazı sistemi ve metin‑çerçeve ayarlarına bağlıdır. Tutarlı görüntüleme için gerekli yazı tiplerini sağlayın, [font substitution](/slides/tr/php-java/font-substitution/) yapılandırın veya sunuma [embed fonts](/slides/tr/php-java/embedded-font/) ekleyin.

**Bir paragraf birkaç düzeltme dili kullanabilir mi?**

Evet. Her dili ayrı bir bölüme atayın; çok dilli paragraf örneğinde gösterildiği gibi.

**`setDefaultTextLanguage` mı yoksa `setLanguageId` mi kullanmalıyım?**

Yeni oluşturulan metin için bir varsayılan istiyorsanız [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) kullanın. Belirli bir bölümün açık bir düzeltme diline ihtiyacı varsa veya bir paragrafta birden çok dil varsa [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLanguageId) kullanın.