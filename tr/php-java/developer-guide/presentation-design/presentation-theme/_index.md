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
description: "Aspose.Slides for PHP via Java ile tutarlı marka kimliği sağlayarak PowerPoint dosyalarını oluşturmak, özelleştirmek ve dönüştürmek için ana sunum temalarını yönetin."
---
## **Giriş**

Bir sunum teması, koordineli bir renk, yazı tipi, arka plan stili, dolgu, çizgi ve efekt kümesini tanımlar. Tema‑bilinçli nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur; böylece bir tema değişikliği, birçok nesneyi aynı anda güncelleyebilir.

Aspose.Slides içinde, sunum seviyesindeki tema, [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) aracılığıyla erişilebilir. Bir sunum aynı zamanda daha alt seviyelerde tema geçersiz kılmaları içerebilir. Bir ana sayfa, [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterthememanager/) aracılığıyla sunum temasını geçersiz kılabilir; bir düzen ya da tek bir slayt ise [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseoverridethememanager/) aracılığıyla devralınan temayı geçersiz kılabilir. Uygulamada, bir slayt için etkili tema, şu kalıtım zinciri üzerinden çözülür: sunum teması, ana sayfa geçersiz kılması, düzen geçersiz kılması ve slayt geçersiz kılması.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler, en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ile geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mastertheme/) nesnesi, tema renk şemasını, yazı tipi şemasını ve format şemasını sırasıyla [MasterTheme.getColorScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mastertheme/) aracılığıyla ortaya koyar. Bu koleksiyonları değiştirmeden önce incelemek, dış bir kaynaktan gelen bir sunumun stil girişlerinin sayısı ve içeriği değişebildiği için özellikle faydalıdır.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada depolanan arka plan, dolgu, çizgi ve efekt stillerinin sayısını raporlar:

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

Bir dosya birden fazla ana sayfa kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkilendirilen ana sayfayı inceleyin ve düzen ya da slayt geçersiz kılmaları mevcut olduğunda bu makalede daha sonra gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema‑bilinçli dolgular, çizgiler ve metinler, [SchemeColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/schemecolor/) enum’undan mantıksal bir renge başvurabilir. [ColorScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/colorscheme/) içinde ilgili girdiyi değiştirdiğinizde, hâlâ bu tema rengini başvuran tüm nesneler yeni değere göre çözülür. Doğrudan bir RGB rengi kullanan nesneler, tema‑rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan uca örnek, `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili dolgu rengini yazdırır:

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

Dikdörtgen `Accent4` ile bağlı kaldığı için, tema değiştirildiğinde görünen rengi kırmızı olur. Şekilde şema rengini doğrudan bir renk ile değiştirirseniz, sonraki `Accent4` değişiklikleri artık o dolguyu etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar üretmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/colortransformoperation/) enum’u aracılığıyla ortaya koyar.

![Ana tema renkleri ve ek paletten oluşturulan daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** – Ana tema renkleri.

**2** – Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` bazlı altı dikdörtgen oluşturur, beşine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

Bu varyantlar tema rengine dayanır. `Accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `Accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `ColorScheme` Slotlarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/schemecolor/) enum’u `Text1`, `Background1`, `Text2` ve `Background2` değerlerini kullanırken, [ColorScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/colorscheme/) aynı tema slotlarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema slotlarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için bir ana (major) yazı tipi seti ve gövde metni için bir yan (minor) yazı tipi seti içerir. [FontScheme.getMajor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontscheme/) ve [FontScheme.getMinor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontscheme/) yöntemleri bu setleri ortaya koyar.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları, metin biçimlendirmede kullanılabilir:

* `+mn-lt` – Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj-lt` – Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn-ea` – Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj-ea` – Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

Aşağıdaki örnek, ana Latin tema yazı tipini kullanan bir başlık ve yan Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık ana yazı tipini, gövde metni ise yan yazı tipini izler. Açıkça bir yazı tipi adı belirtilen metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Ana ve yan yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script‑Specific Theme Fonts](/slides/tr/php-java/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="Tip" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/php-java/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları, farklı tema‑ilişkili sorunları çözer.

### **Bir Ana Sayfaya Bağlı Slaytlara Harici Tema Uygulama**

PowerPoint tema dosyası (`.thmx`) sahip olduğunuzda ve belirli bir ana sayfaya bağlı tüm slaytların stilini yeniden uygulamak istediğinizde [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) kullanın. [Presentation::getMasters](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) koleksiyonundan seçilen ana sayfayı alın (bu koleksiyon [MasterSlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) tarafından temsil edilir) ve tema dosya yolunu metoda aktarın.

Metot şu işlemleri gerçekleştirir:

1. Seçilen ana sayfaya dayanarak yeni bir ana slayt oluşturur.
1. Harici temayı yeni ana slayta uygular.
1. Yeni ana slaytı, daha önce seçilen ana sayfaya bağlı olan tüm slaytlara atar.
1. Yeni oluşturulan [MasterSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) nesnesini döndürür.

Aşağıdaki örnek, ilk ana sayfaya bağlı slaytlara harici bir tema uygular ve sunumu kaydeder:

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

Geçersiz, bozuk veya desteklenmeyen bir tema, [PptxReadException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxreadexception/) oluşturabilir. Kullanıcı tarafından sağlanan yolları doğrulayın, dosya sistemi erişim hatalarını yönetin ve temayı başarıyla uyguladıktan sonra sunumu kaydedin.

Yalnızca seçilen ana sayfaya bağlı slaytlar yeniden atanır. Diğer ana sayfalarla ilişkili slaytlar mevcut ana sayfa ve temalarını korur. Tema‑bilinçli renkler, yazı tipleri, dolgular, çizgiler, arka planlar ve efektler harici tema üzerinden çözülür. Doğrudan atanmış renkler, yazı tipleri, dolgular ve diğer açık biçimlendirmeler değişmemiş kalabilir. Düzen‑seviyesi ve slayt‑seviyesi geçersiz kılmalar, yeni ana sayfadan kalıtılan değerlere üstünlük sağlayabilir.

Tema, çalışma zamanında bulunmayan yazı tiplerine başvurabilir. Tutarlı render ve dışa aktarma için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/php-java/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikamesi](/slides/tr/php-java/font-substitution/) yapılandırın.

Bu doğrudan ana‑sayfa seviyeli bir iş akışıdır: metot bir `.thmx` dosya yolunu kabul eder ve slayt‑seviyesi veya düzen‑seviyesi tema geçersiz kılmaları oluşturmayı gerektirmez.

### **Çok‑Ana Sayfalı Sunumda Farklı Harici Temalar Uygulama**

İlgili ana sayfa önceden bilinmiyorsa, [Slide::getLayoutSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/) ve [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/) aracılığıyla temsilî bir slayttan elde edin. Her tema uygulaması sunumda yeni bir ana sayfa yarattığı için, tema uygulamadan önce orijinal ana sayfa referanslarını saklayın.

Aşağıdaki örnek, iki bölümden slaytları alır, ana sayfalarını bulur ve her grup için farklı bir harici tema uygular:

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

İlk çağrı yalnızca `$firstGroupMaster` bağlı slaytları etkiler, ikinci çağrı yalnızca `$secondGroupMaster` bağlı slaytları etkiler. Diğer ana sayfalara ait slaytlar yeniden stil almaz.

### **Slaytları Taşırken Kaynak Temasını Korumak**

Bir slaytı başka bir sunuma taşımak ve özgün tasarımını korumak istiyorsanız, kaynak ana sayfayı hedef sunuma [MasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) ile klonlayın, ardından o klonlanmış ana sayfa ile birlikte slaytı [SlideCollection.addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/) ile klonlayın. Böylece ana sayfa, düzenleri ve ilişkili tema birlikte taşınır.

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

Bu, kaynak slaytın hedefte aynı şekilde görünmesi gerektiğinde önerilen iş akışıdır. İçeriği bağımsız bir hedef ana sayfaya klonlamak, tema‑tabanlı renk, yazı tipi, arka plan ve efektlerde değişikliklere yol açabilir.

### **Mevcut Bir Slayta Tema Değerleri Uygulama**

Hedef slayt mevcut ana sayfa ve düzeni korumalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/overridetheme/) yöntemleri, üç ana tema bileşenini geçersiz kılmaya kopyalar.

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

Bu, diğer slaytların devraldığı temayı değiştirmeden o slaytın kullandığı temayı değiştirir. Yerel geçersiz kılmayı kaldırıp devralınan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/overridetheme/) çağırın.

### **Bir Düzeni Tema Geçersiz Kılamasıyla Uygulama**

Düzen‑seviyesi geçersiz kılma, o düzeni kullanan slaytlara uygulanır; tek bir slaytın kendi geçersiz kılması yoksa. Aynı başlatma yöntemleri, [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslidethememanager/) üzerinden de kullanılabilir:

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

Birden çok düzen ve slayt aynı temel tasarımı paylaşmalıysa ana‑sayfa veya sunum‑seviyesi tema kullanın; bir düzen ailesi farklı stil istiyorsa düzen geçersiz kılması, gerçek istisnalar için ise slayt geçersiz kılması tercih edin. Aşırı slayt‑seviyesi geçersiz kılmalar, sonraki küresel tema değişikliklerini öngörmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan dolguları, [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/formatscheme/) içinde depolanır. PowerPoint, UI’da temanın dolgu stillerini tema renkleri ve diğer stil referanslarıyla birleştirerek, fiziksel olarak bu koleksiyonda depolanan dolgu tanımlarından daha fazla arka plan seçeneği sunabilir.

![PowerPoint’te bir sunum temasının arka plan stil galerisi](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, saklanan koleksiyonu ve mevcut [Background.getStyleIndex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/background/) değerini inceleyin. `0` değeri temalı dolgu olmadığını, pozitif değerler ise tema arka plan‑stil referanslarını gösterir. Bu, PHP koleksiyonundaki indeksleme (`get_Item(0)` ilk depolanan öğeyi verir) ile aynı değildir. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, mevcut arka plan dolgu sayısını raporlar, ilk ana sayfaya temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, ana sayfa tarafından referans verilen tema girişi ve düzen ya da slayt seviyesindeki olası arka plan geçersiz kılmalarına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca ana sayfa arka planını değiştirmek o slaytı etkilemeyebilir. Kalıtım uygulanmış nihai arka planı öğrenmek için [Background.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/background/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
Stil indeksini sıfır tabanlı bir koleksiyon indeksi gibi değerlendirmeyin. Ayrıca bir dosyadan sabit bir stil numarası alıp başka bir dosyada aynı görünüme sahip olduğunu varsamaktan kaçının; tema stil tanımları sunuma özgüdür.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/php-java/presentation-background/) sayfasına bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Tema format şeması, ayrı dolgu, çizgi ve efekt stil koleksiyonlarına sahiptir ve bu koleksiyonlar [FormatScheme.getFillStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/formatscheme/) ve [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/formatscheme/) aracılığıyla ortaya konur. Tipik Office temaları genellikle görsel olarak hafif, orta ve yoğun biçimlendirmeye karşılık gelen üç ana stil girdisi içerir, ancak kod sabit bir sayıya varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

PHP’de bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır‑tabanlıdır: `get_Item(0)` ilk depolanan stili, `get_Item(2)` üçüncüsünü verir. Bir şeklin stil‑referans indeksleri farklı bir kavramdır ve [ShapeStyle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapestyle/) üzerinden ortaya konur. Bir tema stilini değiştirmek, o tema stiline başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girdilerinin mevcut olduğunu doğrular, ilk çizgi stilini, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu slotlara başvuran şekiller için, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puan uzaklıkta bir dış gölge alır. Kesin görsel sonuç, her şeklin hangi stil slotlarını referans aldığına ve doğrudan biçimlendirmelerin temayı geçersiz kılıp kılamadığına bağlıdır.

![Satır, dolgu ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri, belirli bir seviyede neyin tanımlandığını gösterir. Etkili değerler ise kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt ya da şeklin gerçekte ne kullandığını söyler. Bir slayt için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseoverridethememanager/) çağırın. Bir arka plan için [Background.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/background/), bir dolgu için ise [FillFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/) kullanın.

Aşağıdaki örnek, bir slayttan etkili temayı, arka planı ve ilk şekil dolgusunu okur:

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

Rendring teşhisleri, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) incelerseniz, bir ana sayfa, düzen, slayt veya şekil geçersiz kılmasının nihai görünümü değiştirdiğini kaçırabilirsiniz.

## **SSS**

**Harici bir tema uygulamak sunumdaki her slaytı etkiler mi?**

Hayır. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) yalnızca seçilen ana sayfaya bağlı slaytları yeniden atar. Diğer ana sayfaları kullanan slaytlar mevcut temalarını korur.

**Bir slayta ana sayfayı değiştirmeden tema uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik sadece o slayta yerel olarak uygulanır; diğer slaytlar mevcut temalarını devralmaya devam eder.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak ana sayfayı hedefe [MasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) ile klonlayın ve ardından slaytı aynı klonlanmış ana sayfayla [SlideCollection.addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/) ile klonlayın. Bu, ana sayfa, düzenler ve temayı birlikte tutar.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya düzen teması için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseoverridethememanager/) ve format nesneleri için [Background.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/background/) ve [FillFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/) gibi ilgili etkili‑veri yöntemlerini kullanın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözülmüş değerleri döndürür.