---
title: PHP'de Sunum Temalarını Yönetme
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/php-java/presentation-theme/
keywords:
- PowerPoint teması
- sunum teması
- slayt teması
- tema ayarla
- tema değiştir
- tema yönet
- harici tema
- THMX
- tema rengi
- ek palet
- tema yazı tipi
- tema stili
- tema efekti
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Java aracılığıyla PHP için Aspose.Slides'te ana sunum temalarını kullanarak PowerPoint dosyalarını tutarlı marka kimliğiyle oluşturma, özelleştirme ve dönüştürme."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, doldurmalar, çizgiler ve efektlerden oluşan koordineli bir küme tanımlar. Tema farkında nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu paylaşılan tanımlara başvurur, böylece bir tema değişikliği birçok nesneyi aynı anda güncelleyebilir.

Aspose.Slides'ta, sunum seviyesindeki tema, [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) aracılığıyla kullanılabilir. Bir sunum ayrıca daha alt seviyelerde tema geçersiz kılmaları içerebilir. Bir master, sunum temasını [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/) ile geçersiz kılabilir, bir yerleşim veya tek bir slayt ise kalıtılmış temasını [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) ile geçersiz kılabilir. Pratikte, bir slayt için etkili tema bu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersiz kılma, yerleşim geçersiz kılma ve slayt geçersiz kılma.

![Tema öğeleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı incelemek, renk ve yazı tiplerini değiştirmek, bir temayı kopyalamak veya uygulamak, arka plan ve efekt stillerini güncellemek ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okumak.

## **Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) nesnesi, temanın renk şemasını, yazı tipi şemasını ve format şemasını [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) ve [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) aracılığıyla ortaya koyar. Bu koleksiyonları değiştirmeden önce incelemek, sunum dış bir kaynaktan geldiğinde stil girişlerinin sayısı ve içeriği değişebileceği için özellikle faydalıdır.

Aşağıdaki örnek ana tema özelliklerini okur ve temada kaç tane arka plan, doldurma, çizgi ve efekt stilinin saklandığını raporlar:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();

    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Bir dosya birden fazla master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkili masterı inceleyin ve yerleşim veya slayt geçersiz kılmaları mevcut olduğunda bu makalenin ilerleyen kısmında gösterilen etkili tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema farkında doldurmalar, çizgiler ve metin, [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) enum'undan mantıksal bir renge başvurabilir. [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/)'deki ilgili girişi değiştirirseniz, hâlâ o tema rengini başvuran tüm nesneler yeni değere göre çözülür. Doğrudan bir RGB rengi kullanan nesneler bir tema rengi güncellemesiyle değişmez.

Aşağıdaki uçtan uca örnek `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili doldurma rengini yazdırır:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);

    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Dikdiköşe `Accent4`e bağlı kalmaya devam ettiğinden, tema değiştirildiğinde görünür rengi kırmızı olur. Şekilde şema rengini doğrudan bir renkle değiştirirseniz, `Accent4`teki sonraki değişiklikler artık o doldurmayı etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar türetmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/) enum'ı aracılığıyla açığa çıkarır.

![Ana tema renkleri ve ek paletten üretilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.

**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek `Accent4` temelli altı dikdörtgen oluşturur, beş tanesine parlaklık dönüşümleri uygular ve sonucu kaydeder:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bu varyantlar tema rengine dayalı kalır. `Accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `Accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `ColorScheme` Yuvalarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) enum'ı `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için bir ana yazı tipi seti ve gövde metni için bir yan (minor) yazı tipi seti içerir. [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) ve [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) yöntemleri bu setleri ortaya koyar.

PowerPoint uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` - Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj-lt` - Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn-ea` - Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj-ea` - Başlık Yazı Tipi Doğu Asya (Major East Asian Font)
* `+mn-cs` - Gövde Yazı Tipi Karmaşık Betik (Minor Complex Script Font)
* `+mj-cs` - Başlık Yazı Tipi Karmaşık Betik (Major Complex Script Font)

Aşağıdaki örnek bir başlık oluşturur; bu başlık büyük Latin tema yazı tipini, bir gövde satırı ise küçük Latin tema yazı tipini kullanır. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Başlık büyük (major) yazı tipini, gövde metni ise küçük (minor) yazı tipini izler. Açık bir yazı tipi adı içeren metin, tema tanımlayıcısı yerine, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Büyük ve küçük yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script-Specific Theme Fonts](/slides/tr/php-java/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="Tip" %}}

Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/php-java/powerpoint-fonts/) bölümüne bakın.

{{% /alert %}}

### **Tema Yazı Tipi Referanslarını Çözümleme**

Metni incelerken, [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) bir tema referansı (ör. `+mn-lt`) yerine bir yazı tipi adı döndürebilir. Bu referansı çözümlemek için uygun etkili tema verisiyle [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) çağırın. `+mj` ve `+mn` ön ekleri büyük ve küçük yazı tipi setlerini seçerken, `-lt`, `-ea` ve `-cs` sonekleri bunların Latin, Doğu Asya ve Karmaşık Betik yazı tiplerini seçer.

Etkili temayı, temanın uygulandığı nesnenin üzerinden [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) ile alın. Normal bir slayttaki metin için bu yöntemi slayt üzerinde çağırın; böylece bağlam slaydın kalıtılmış temasını ve yerel geçersiz kılmalarını içerir. Bir yerleşim veya master kendisini incelerken kendi etkili temasını kullanın. İlk masterın temasının her slayta uygulandığını varsaymayın.

Aşağıdaki örnek, açıkça küçük Latin yazı tipine referans veren bir metin bölümü oluşturur. [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) aracılığıyla bir slayt yazı tipi şeması başlatır ve büyük ve küçük Latin ailelerini `Arial` ve `Calibri` olarak ayarlar; böylece girdi dosyası olmadan sonuç tekrarlanabilir.

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Çıktı `+mn-lt -> Calibri` ardından `Verdana -> Verdana` şeklindedir. Saklanan referans değişmezken, açık bir aile adı olduğu gibi döndürülür. Bölüm `+mj-lt` kullanmış olsaydı bu tema içinde `Arial` olarak çözülürdü.

Tema referansını çözümlemek, tema tarafından belirtilen yazı tipi ailesini tanımlar. Bu, yazı tipi kullanılabilirliğini kontrol etmez veya render sırasında ikame ya da glif geri dönüşü sonrası kullanılan yazı tipi dosyasını belirlemez. Bu ayrı adımlar için [Font Selection Sequence](/slides/tr/php-java/font-selection-sequence/) ve [Font Substitution](/slides/tr/php-java/font-substitution/) bölümlerine bakın.

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları farklı tema ile ilgili problemleri çözer.

### **Harici Bir Temayı Master’a Bağlı Slaytlara Uygulama**

Bir PowerPoint tema dosyanız (`.thmx`) varsa ve belirli bir mastera bağlı tüm slaytlara yeni stil vermek istiyorsanız, [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) kullanın. [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) koleksiyonundan masterı seçin; bu koleksiyon [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) ile temsil edilir ve tema dosyasının yolu metoda aktarılır.

Yöntem aşağıdaki işlemleri yapar:

1. Seçilen mastera dayanarak yeni bir master slayt oluşturur.
1. Harici temayı yeni mastera uygular.
1. Daha önce seçilen mastera bağlı tüm slaytlara yeni masterı atar.
1. Yeni oluşturulan [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)'ı döndürür.

Aşağıdaki örnek, ilk mastera bağlı slaytlara harici bir tema uygular ve sunumu kaydeder:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;

    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Geçersiz, bozuk veya desteklenmeyen bir tema, [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/) oluşturabilir. Kullanıcıların sağladığı yolları doğrulayın, dosya sistemi erişim hatalarını yönetin ve temayı başarıyla uyguladıktan sonra sunumu kaydedin.

Sadece seçilen mastera bağlı slaytlar yeniden atanır. Diğer masterlara bağlı slaytlar mevcut masterlarını ve temalarını korur. Tema farkında renkler, yazı tipleri, doldurmalar, çizgiler, arka planlar ve efektler harici tema karşısında çözülür. Doğrudan atanmış renkler, yazı tipleri, doldurmalar ve diğer açık biçimlendirmeler değişmemiş kalabilir. Yerleşim‑seviyesindeki ve slayt‑seviyesindeki geçersiz kılmalar da yeni masterdan kalıtılan değerlerin üzerine geçebilir.

Tema, çalışma zamanında mevcut olmayan yazı tiplerine referans verebilir. Tutarlı render ve dışa aktarım için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/php-java/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikamesi](/slides/tr/php-java/font-substitution/) yapılandırın.

Bu doğrudan master‑seviyesi bir iş akışıdır: yöntem bir `.thmx` dosyasının yolunu alır ve slayt‑seviyesi ya da yerleşim‑seviyesi tema geçersiz kılmalarını manuel olarak oluşturmayı gerektirmez.

### **Çok‑Masterlı Bir Sunumda Farklı Harici Temalar Uygulama**

İlgili master önceden bilinmiyorsa, onu bir temsilci slayttan [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) ve [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) aracılığıyla alın. Her temayı uygulamadan önce orijinal master referanslarını saklayın; çünkü her çağrı sunumda yeni bir master oluşturur.

Aşağıdaki örnek iki bölümden slaytları alır, masterlarını bulur ve her grup için farklı bir harici tema uygular:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;

            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

İlk çağrı sadece `$firstGroupMaster`e bağlı slaytları etkiler, ikinci çağrı sadece `$secondGroupMaster`e bağlı slaytları etkiler. Diğer masterlara bağlı slaytlar yeniden tasarlanmaz.

### **Slaytları Taşırken Kaynak Temasını Korumak**

Bir slaytı başka bir sunuma taşımak ve orijinal tasarımını korumak istiyorsanız, kaynak masterı hedef sunuma [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) ile kopyalayın, ardından slaytı ve kopyalanan masterı [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) ile klonlayın. Bu, masterı, yerleşimlerini ve ilişkili temayı birlikte taşır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);

        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);

        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);

        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Bu, kaynak slaytın hedefte aynı görünmesini istediğinizde tercih edilen iş akışıdır. İçeriği bağımsız bir hedef mastera klonlamak tema‑tabanlı renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygulama**

Hedef slayt mevcut master ve yerleşimde kalmalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) ve [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) yöntemleri üç ana tema bileşenini geçersiz kılmaya kopyalar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);

        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());

        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Bu, o slaytın kullandığı temayı diğer slaytların kalıtım teması değiştirilmeden değiştirir. Yerel geçersiz kılmayı kaldırmak ve kalıtılan değerlere geri dönmek için [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) çağırın.

### **Bir Yerleşime Tema Geçersiz Kılması Uygulama**

Yerleşim‑seviyesi bir geçersiz kılma, o yerleşimi kullanan slaytlara uygulanır; yalnızca belirli bir slayt kendi geçersiz kılmasını yapmazsa. Aynı başlatma yöntemleri [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/) aracılığıyla kullanılabilir:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());

        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Birden çok yerleşim ve slayt aynı temel tasarımı paylaşmalıysa master veya sunum‑seviyesi tema kullanın; bir yerleşim ailesi farklı bir stil gerektiriyorsa yerleşim geçersiz kılmasını; yalnızca gerçek istisnalar için slayt geçersiz kılmasını tercih edin. Aşırı slayt‑seviyesi geçersiz kılmalar, sonraki küresel tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan doldurmaları [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) içinde saklanır. PowerPoint, UI’da temanın doldurmalarını tema renkleri ve diğer stil referanslarıyla birleştirerek, bu koleksiyonda fiziksel olarak saklanan doldurma tanımlarından daha fazla arka plan seçeneği sunabilir.

![PowerPoint arka plan stil galerisinde bir sunum teması](presentation-design_8.png)

Bir arka plan stili kullanmadan önce, saklanan koleksiyonu ve geçerli [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/) değerini inceleyin. `0` stil indeksi temalı bir doldurma olmadığını, pozitif değerler tema arka plan‑stil referanslarını gösterir. Bu, PHP koleksiyonunu doğrudan indekslemekten (ör. `get_Item(0)` ilk saklanan öğe) farklıdır. Her sunumun aynı sayıdaki arka plan doldurma stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek mevcut arka plan doldurma sayısını raporlar, ilk mastera temalı bir arka plan referansı atar ve sunumu kaydeder:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);

    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Görünür sonuç, masterın referans verdiği tema girişine ve yerleşim ya da slayt seviyesindeki olası arka plan geçersiz kılmalarına bağlıdır. Sadece master arka planını değiştirirseniz, kendi arka planını kullanan bir slayt değişmeyebilir. Kalıtım uygulandıktan sonra nihai arka planı öğrenmek için [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) kullanın.

{{% alert color="warning" title="Uyarı" %}}

Stil indeksini sıfır‑tabanlı bir koleksiyon indeksi gibi kullanmayın. Ayrıca bir dosyadan alınan bir stil numarasını diğer bir dosyada aynı görünüme sahip olduğunu varsaymayın; tema stil tanımları sunuma özgüdür.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/php-java/presentation-background/) bölümüne bakın.

{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Tema format şeması, [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) ve [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) aracılığıyla sunulan ayrı doldurma, çizgi ve efekt stil koleksiyonlarını içerir. Tipik Office temaları genellikle görsel olarak ince, orta ve yoğun biçimlendirmelere karşılık gelen üç ana stil girdisi içerir; ancak kod, sabit bir sayıya varsayımda bulunmak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanmış ince, orta ve yoğun tema efektleri](presentation-design_10.png)

PHP’de bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır‑tabanlıdır: `get_Item(0)` ilk saklanan stili, `get_Item(2)` üçüncüyü gösterir. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/) aracılığıyla açığa çıkar. Bir tema stilini değiştirmek, o tema stiline başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girişlerinin mevcut olduğunu doğrular, ilk çizgi stilini değiştirir, üçüncü doldurma stilini değiştirir, üçüncü efekt stiline bir dış gölge ekler ve sonucu kaydeder:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);

    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bu stil yuvalarına başvuran şekillerde, ilk tema çizgi stili kırmızı, üçüncü tema doldurma stili katı orman yeşili ve üçüncü efekt stili 10 puan uzaklıkta bir dış gölge kazanır. Tam görsel sonuç, her şeklin hangi stil yuvasına başvurduğuna ve doğrudan biçimlendirme temasının üzerine yazıp yazmadığına bağlıdır.

![Satır, doldurma ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Bir Şekil İçin Tema Doldurma ve Çizgi Stillerini Seçme**

Bir şekil, doldurma ve kenarını bağımsız olarak [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) ve [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex) ile seçebilir. Her iki yöntemde de indeks `1` ilgili tema koleksiyonundaki ilk girişi (`get_Item(0)`) seçerken, indeks `2` ikinci girişi (`get_Item(1)`) seçer.

Aşağıdaki örnek, yeni bir sunumun varsayılan temasında iki doldurma stili (altın ve gökyüzü mavisi) ve iki çizgi stili (6 pt koyu mavi ve 12 pt koyu kırmızı) ayarlar. Sonucu üç aşamada kaydeder, böylece PowerPoint’te sonuçları karşılaştırabilirsiniz.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| İlk stiller | Sağ kenarı değiştir | İlk tema doldurmasını düzenle |
|:---:|:---:|:---:|
| ![Altın ve gökyüzü-mavi dikdörtgenler, eşleşen ince koyu mavi kenarlıklar](theme-style-initial.png) | ![Gökyüzü-mavi dikdörtgen şimdi kalın koyu kırmızı bir kenarlığa sahip](theme-style-line-changed.png) | ![Sol dikdörtgen şimdi yeşil ve her iki kenarlık da değişmedi](theme-style-fill-changed.png) |

Farklı bir çizgi stili seçmek sadece sağ dikdörtgenin kenarlığını değiştirir. İlk tema doldurmasını düzenlemek, onu kullanan her şekli günceller; bu örnekte sadece sol dikdörtgen yeşile döner.

Mevcut bir şekil üzerinde, yerel bir doldurma rengi, çizgi rengi veya çizgi kalınlığı, tema stilinin o kısmını geçersiz kılabilir. Stil indeksi değişikliği görünür bir etki yaratmazsa, şeklin [direct formatting](/slides/tr/php-java/shape-formatting/) kısmını kontrol edin.

## **Etkili Katı Doldurmanın Tema Rengini Kullandığını Belirleme**

Bir doldurma, nesne üzerinde doğrudan depolanabilir ya da bir paragraftan, yerleşimden, masterdan, tema stilinden veya başka bir biçimlendirme seviyesinden kalıtılabilir. Bu hiyerarşiyi değiştirilemez bir etkili doldurma verisine dönüştürmek için [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) çağırın. İlk olarak `getFillType` sonucunu kontrol edin. Yalnızca `FillType::Solid` olduğunda katı doldurma özelliklerini okuyun.

Katı bir doldurma için `getSolidFillColor` kalıtım, tema araması ve renk dönüşümleri uygulandıktan sonraki nihai RGB değerini döndürür. `getSolidFillSchemeColor` yöntemi, ilgili mantıksal [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) yuvasını (ör. `Text1` veya `Accent6`) verir. `SchemeColor::NotDefined` değeri, etkili katı doldurmanın bir şema rengine dayanmadığını gösterir. Tema renkleri yerine doğrudan RGB renkleri kullanan bir iş akışında bu değer, doğrudan RGB doldurmayı tanımlar.

Yalnızca yerel [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) değerine dayanarak bir doldurmayı sınıflandırmayın. Örneğin, bir metin bölümü yerel olarak bir şema rengi tanımlamamış olabilir; bu nedenle yerel değeri `NotDefined` iken etkili doldurma bir tema rengini miras alıp `Text1` ya da `Accent6` olarak çözümlenebilir. Öte yandan, `getSolidFillSchemeColor` hangi mantıksal tema yuvasının etkili rengi ürettiğini söyler, ancak bu yuvanın nesneden, paragraftan, yerleşimden, masterdan ya da başka bir seviyeden geldiğini söylemez.

Aşağıdaki örnek bir sunumu yükler, şekil doldurmalarını ve metin‑parça doldurmalarını denetler, her birinin son RGB değerini ve ilişkili şema rengini yazdırır ve tema rengi değişikliklerini takip etmeyecek katı doldurmaları işaretler:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

`NotDefined` dalı, tema rengi yuvalarındaki değişikliklere yanıt vermeyecek katı doldurmaların bir denetim listesini verir. Sunumun yeni bir marka paletine uyması gerektiğinde bu nesneleri gözden geçirin. Raporlanan RGB değeri hâlâ mevcut görünümü gösterirken, şema değeri bu görünümün tema ile bağlantılı olup olmadığını açıklar.

Etkili‑format nesneleri bir anlık görüntüdür. Sunum temasını, bir tema geçersiz kılmasını ya da kalıtılmış herhangi bir biçimlendirmeyi değiştirdikten sonra `getEffective` yeniden çağırın ve yeni etkili doldurma verilerini okuyun; böylece renkleri karşılaştırıp raporlayabilirsiniz.

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri belirli bir seviyede neyin tanımlandığını gösterir. Etkili değerler, kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt ya da şeklin gerçekte ne kullandığını söyler. Bir slayt için [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) çağırın. Arka plan için [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), doldurma için ise [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) kullanın.

Aşağıdaki örnek bir slayttan etkili temayı, arka planı ve ilk şekil doldurmasını okur:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();

    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;

    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Render tanılamaları, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) incelerseniz, master, yerleşim, slayt veya şekil geçersiz kılmalarını kaçırabilirsiniz; bunlar nihai görünümü değiştirir.

## **SSS**

**Harici bir temayı uygulamak sunumdaki her slaytı etkiler mi?**

Hayır. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) sadece seçilen mastera bağlı slaytları yeniden atar. Diğer masterları kullanan slaytlar mevcut temalarını korur.

**Masterı değiştirmeden tek bir slayta tema uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik sadece o slayta yerel kalır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

Bir slaytı taşırken ve kaynağının görünümünü korurken, kaynak masterı hedefe klonlayın ve ardından slaytı bu masterla birlikte [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) ve [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) kullanarak klonlayın. Bu, masterı, yerleşimleri ve temayı birlikte tutar.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya yerleşim teması için [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) ve format nesneleri için ilgili etkili‑veri yöntemlerini (ör. [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) ve [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/)) kullanın. Bu API’ler kalıtım ve geçersiz kılmalar uygulandıktan sonraki çözülmüş değerleri döndürür.