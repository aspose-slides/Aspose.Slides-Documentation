---
title: PHP'de Sunum Temalarını Yönet
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/php-java/presentation-theme/
keywords:
- PowerPoint teması
- sunum teması
- slayt teması
- tema ayarla
- temayı değiştir
- temayı yönet
- harici tema
- THMX
- tema rengi
- ekstra palet
- tema yazı tipi
- tema stili
- tema efekti
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Java aracılığıyla PHP için Aspose.Slides'te ana sunum temalarını oluşturmak, özelleştirmek ve tutarlı marka kimliği ile PowerPoint dosyalarını dönüştürmek."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, doldurmalar, çizgiler ve efektlerden oluşan koordineli bir küme tanımlar. Tema farkında nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur, bu sayede bir tema değişikliği birden fazla nesneyi aynı anda güncelleyebilir.

Aspose.Slides içinde, sunum seviyesindeki tema, [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) aracılığıyla kullanılabilir. Bir sunum ayrıca alt seviyelerde tema geçersiz kılmaları içerebilir. Bir master, [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterthememanager/) ile sunum temasını geçersiz kılabilir, bir layout veya bireysel slayt ise [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseoverridethememanager/) ile devralınan temayı geçersiz kılabilir. Pratikte, bir slayt için geçerli tema, bu kalıtım zinciri boyunca çözülür: sunum teması, master geçersiz kılma, layout geçersiz kılma ve slayt geçersiz kılma.

![Tema öğeleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler, en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra geçerli değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mastertheme/) nesnesi, tema renk şemasını, yazı tipi şemasını ve format şemasını sırasıyla [MasterTheme.getColorScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mastertheme/) aracılığıyla sunar. Bu koleksiyonları değiştirmeden önce incelemek, özellikle bir sunum dış bir kaynaktan geldiğinde stil girdilerinin sayısı ve içeriği değişebileceği için faydalıdır.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç tane arka plan, doldurma, çizgi ve efekt stilinin depolandığını raporlar:

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

Bir dosya birden fazla master kullanıyorsa, her slaytın aynı geçerli temaya sahip olduğunu varsamamalısınız. Slayt ile ilişkili masterı inceleyin ve layout veya slayt geçersiz kılmaları mevcut olduğunda bu makalede daha sonra gösterilen geçerli tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema farkında doldurmalar, çizgiler ve metin, [SchemeColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/schemecolor/) enum'undan mantıksal bir renge başvurabilir. [ColorScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/colorscheme/) içindeki ilgili girdiyi değiştirirseniz, hâlâ o tema rengini referans eden tüm nesneler yeni değere göre çözülür. Doğrudan RGB rengi kullanan nesneler tema rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan uca örnek, `Accent4` kullanan bir şekil oluşturur, temadaki `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve geçerli doldurma rengini yazdırır:

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

Dikdörtgen `Accent4` ile bağlı kaldığı için, tema değiştirildiğinde görünür rengi kırmızı olur. Şekilde şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri bu doldurmayı etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar üretmek için renk dönüşümleri uygular. Aspose.Slides, bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/colortransformoperation/) enum'ı aracılığıyla sunar.

![Ana tema renkleri ve ek paletten üretilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** – Ana tema renkleri.  
**2** – Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` tabanlı altı dikdörtgen oluşturur, beşine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

### **`SchemeColor` Değerlerini `ColorScheme` Yuvalarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/schemecolor/) enum'ı `Text1`, `Background1`, `Text2` ve `Background2` kullanırken, [ColorScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/colorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için bir ana (major) yazı tipi seti ve gövde metni için bir yan (minor) yazı tipi seti içerir. [FontScheme.getMajor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontscheme/) ve [FontScheme.getMinor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontscheme/) yöntemleri bu setleri ortaya çıkarır.

PowerPoint uyumlu tema yazı tipi tanımlayıcıları, metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

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

Başlık ana yazı tipini, gövde metni ise yan yazı tipini izler. Tema kimliği yerine açık bir yazı tipi adı varsa, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Ana ve yan yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script-Specific Theme Fonts](/slides/tr/php-java/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="Tip" %}}

Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/php-java/powerpoint-fonts/) sayfasına bakın.

{{% /alert %}}

## **Bir Temayı Kopyalama veya Uygulama**

Aşağıdaki iş akışları, farklı tema ile ilgili problemleri çözer.

### **Bir Master’a Bağlı Slaytlara Harici Tema Uygulama**

Bir PowerPoint tema dosyanız (`.thmx`) varsa ve belirli bir master’a bağlı tüm slaytların stilini yeniden uygulamak istiyorsanız, [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) yöntemini kullanın. [Presentation::getMasters](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) koleksiyonundan masterı seçin (bu koleksiyon [MasterSlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) tarafından temsil edilir) ve tema dosya yolunu metoda iletin.

Metot şu işlemleri gerçekleştirir:

1. Seçilen master’a dayanarak yeni bir master slaytı oluşturur.  
1. Harici temayı yeni master’a uygular.  
1. Önceden seçilen master’a bağımlı tüm slaytlara yeni masterı atar.  
1. Yeni oluşturulan [MasterSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) nesnesini döndürür.

Aşağıdaki örnek, ilk master’a bağımlı slaytlara harici bir tema uygular ve sunumu kaydeder:

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

Geçersiz, bozuk veya desteklenmeyen bir tema, [PptxReadException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pptxreadexception/) oluşturabilir. Kullanıcıların sağladığı yolları doğrulayın, dosya sistemi erişim hatalarını yönetin ve temayı başarılı bir şekilde uyguladıktan sonra sunumu kaydedin.

Yalnızca seçilen master’a bağımlı slaytlar yeniden atanır. Diğer masterlarla ilişkili slaytlar mevcut master ve temalarını korur. Tema farkında renkler, yazı tipleri, doldurmalar, çizgiler, arka planlar ve efektler harici temaya göre çözülür. Doğrudan atanmış renkler, yazı tipleri, doldurmalar ve diğer açık biçimlendirmeler değişmeden kalabilir. Layout seviyesindeki ve slayt seviyesindeki geçersiz kılmalar da yeni master’dan devralınan değerlere göre öncelik kazanabilir.

Tema, çalışma zaman ortamında bulunmayan yazı tiplerine başvurabilir. Tutarlı render ve dışa aktarım için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/php-java/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikamesi](/slides/tr/php-java/font-substitution/) yapılandırın.

Bu doğrudan master seviyesindeki bir iş akışıdır: Metot bir `.thmx` dosya yolu alır ve slayt veya layout seviyesinde manuel olarak tema geçersiz kılmaları oluşturmayı gerektirmez.

### **Çok‑Masterlı Bir Sunumda Farklı Harici Temalar Uygulama**

İlgili master önceden bilinmiyorsa, [Slide::getLayoutSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/) ve [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/) aracılığıyla temsilci bir slayttan elde edin. Her çağrı sunuma yeni bir master eklediği için temaları uygulamadan önce orijinal master referanslarını saklayın.

Aşağıdaki örnek, iki bölümden slaytları alır, masterlarını bulur ve her grup için farklı bir harici tema uygular:

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

İlk çağrı yalnızca `$firstGroupMaster`’a bağımlı slaytlara etki eder, ikinci çağrı yalnızca `$secondGroupMaster`’a bağımlı slaytlara etki eder. Başka bir master’a ait slaytlar yeniden stil almaz.

### **Slaytları Taşırken Kaynak Temasını Koruma**

Bir slaytı başka bir sunuma taşımak ve özgün tasarımını korumak istiyorsanız, kaynak masterı hedef sunuma [MasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) ile klonlayın, ardından slaytı klonlayarak [SlideCollection.addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/) ve klonlanan masterı kullanın. Bu, masterı, layoutlarını ve ilişkili temayı bir arada taşır.

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

Bu, kaynak slaytın hedefte aynı şekilde görünmesi gereken durumlarda tercih edilen iş akışıdır. İçeriği bağımsız bir hedef master üzerine klonlamak, tema kaynaklı renk, yazı tipi, arka plan ve efekt değişikliklerine yol açabilir.

### **Mevcut Bir Slayta Tema Değerleri Uygulama**

Hedef slayt mevcut master ve layout üzerinde kalmalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/overridetheme/) yöntemleri, üç ana tema bileşenini geçersiz kılmaya kopyalar.

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

Bu, diğer slaytların devraldığı temayı etkilemeden o slaytın temasını değiştirir. Yerel geçersiz kılmayı kaldırıp devralınan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/overridetheme/) metodunu çağırın.

### **Bir Layout’a Tema Geçersiz Kılma Uygulama**

Layout‑seviyesi bir geçersiz kılma, o layout’u kullanan slaytlara uygulanır; ancak belirli bir slayt kendi geçersiz kılmasına sahipse o geçerli olur. Aynı başlatma yöntemleri, [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslidethememanager/) üzerinden kullanılabilir:

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

Birden çok layout ve slayt aynı temel tasarımı paylaşmalıysa master veya sunum‑seviyesi tema kullanın; bir layout ailesi farklı stil gerektiriyorsa layout geçersiz kılma, yalnızca istisnai durumlar için slayt geçersiz kılma tercih edin. Aşırı slayt‑seviyesi geçersiz kılmalar, sonraki küresel tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stilini Güncelleme**

Temanın arka plan doldurmaları, [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/formatscheme/) içinde depolanır. PowerPoint, UI’da temalı doldurmaları tema renkleri ve diğer stil referanslarıyla birleştirerek, bu koleksiyonda fiziksel olarak tanımlı doldurma sayısından daha fazla arka plan seçeneği sunabilir.

![PowerPoint sunum teması için arka plan stil galerisii](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, depolanmış koleksiyonu ve geçerli [Background.getStyleIndex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/background/) değerini inceleyin. `0` stil indeksi, temalı bir doldurma olmadığını gösterir; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, PHP koleksiyonunu doğrudan indekslemekten (`get_Item(0)` ilk depolanmış öğeyi ifade eder) farklıdır. Her sunumun aynı sayıda arka plan doldurma stiline sahip olduğunu varsamamalısınız.

Aşağıdaki örnek, kullanılabilir arka plan doldurma sayısını raporlar, ilk master’a temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, master tarafından başvurulan tema girdisine ve layout ya da slayt seviyesindeki olası arka plan geçersiz kılmalarına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemez. Kalıtım uygulandıktan sonra nihai arka planı öğrenmek için [Background.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/background/) kullanın.

{{% alert color="warning" title="Warning" %}}

Stil indeksini sıfır‑tabanlı koleksiyon indeksi gibi davranmayın. Ayrıca bir dosyadan stil numarasını sabit kodlayıp başka bir dosyada aynı görünüm olacağını varsamaktan kaçının; tema stil tanımları sunuma özgüdür.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Doğrudan arka plan biçimlendirmesi ve arka plan kalıtımı için [Presentation Background](/slides/tr/php-java/presentation-background/) sayfasına bakın.

{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema format şeması, ayrı doldurma, çizgi ve efekt stil koleksiyonlarını [FormatScheme.getFillStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/formatscheme/) ve [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/formatscheme/) aracılığıyla sunar. Tipik Office temaları genellikle görsel olarak hafif, orta ve yoğun biçimlendirmelere karşılık gelen üç ana stil girdisi içerir, ancak kod sabit bir sayıyı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

PHP’de bu koleksiyonlara erişirken, koleksiyon indeksi sıfır‑tabanlıdır: `get_Item(0)` ilk depolanmış stil, `get_Item(2)` üçüncü stildir. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [ShapeStyle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapestyle/) aracılığıyla ortaya çıkar. Bir tema stilini değiştirmek, o temayı referans eden şekilleri etkiler; doğrudan biçimlendirme uygulanmış şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girdilerinin mevcut olduğunu doğrular, ilk çizgi stilini, üçüncü doldurma stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu yuvalara başvuran şekillerde, ilk tema çizgi stili kırmızı, üçüncü tema doldurma stili katı orman yeşili ve üçüncü efekt stili 10 puan mesafeli bir dış gölge alır. Tam görsel sonuç, her şeklin hangi yuvalara başvurduğuna ve doğrudan biçimlendirme temayı geçersiz kılıp kılmadığına bağlıdır.

![Çizgi, doldurma ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Geçerli Katı Doldurmanın Tema Rengi Kullanıp Kullanmadığını Belirleme**

Bir doldurma, doğrudan bir nesneye atanabilir veya paragraf, layout, master, tema stili veya başka bir biçimlendirme seviyesinden kalıtılabilir. Bu hiyerarşiyi değişmez geçerli doldurma verisine çözmek için [FillFormat::getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/) çağırın. Öncelikle `getFillType` sonucunu kontrol edin. Yalnızca `FillType::Solid` olduğunda katı‑doldurma özelliklerini okuyun.

Katı doldurma için `getSolidFillColor`, kalıtım, tema araması ve renk dönüşümleri uygulandıktan sonra ortaya çıkan son RGB değerini döndürür. `getSolidFillSchemeColor` yöntemi, `Text1` veya `Accent6` gibi karşılık gelen mantıksal [SchemeColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/schemecolor/) yuvasını verir. `SchemeColor::NotDefined` değeri, geçerli katı doldurmanın bir şema rengine dayanmadığını gösterir. Tema renkleri ya da doğrudan RGB renkleri kullanılan bir iş akışında, bu değer doğrudan RGB doldurmayı işaret eder.

Yerel [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/colorformat/) değerine yalnızca bakarak bir doldurmayı sınıflandırmayın. Örneğin, bir metin bölümü yerel olarak şema rengi tanımlamamış olabilir, bu yüzden yerel değeri `NotDefined` olur, ancak geçerli doldurması bir tema rengine kalıtılmış ve `Text1` veya `Accent6` olarak çözümlenebilir. Öte yandan, `getSolidFillSchemeColor` hangi mantıksal tema yuvasının geçerli rengi ürettiğini söyler, ancak bu yavanın nesneden, paragraftan, layout’tan, master’dan veya başka bir seviyeden geldiğini göstermez.

Aşağıdaki örnek bir sunumu yükler, şekil doldurmalarını ve metin‑parça doldurmalarını denetler, her bir son RGB değerini ve ilişkili şema rengini yazar ve tema rengi değişikliklerini takip etmeyecek katı doldurmaları işaretler:

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

`NotDefined` dalı, tema rengi yuvalarındaki değişikliklere yanıt vermeyecek katı doldurmaların bir denetim listesi sağlar. Sunumun yeni bir marka paletine uyması gerektiğinde bu nesneleri gözden geçirin. Raporlanan RGB değeri hâlâ mevcut görünümü gösterirken, şema değeri bu görünümün tema ile bağlantılı olup olmadığını açıklar.

Geçerli‑format nesneleri anlık görüntüdür. Sunum temasını, bir tema geçersiz kılmasını veya herhangi bir kalıtılmış biçimlendirmeyi değiştirdikten sonra, `getEffective` metodunu yeniden çağırın ve karşılaştırma ya da raporlama yapmadan önce yeni geçerli doldurma verisini okuyun.

## **Geçerli Tema Değerlerini Okuma**

Ham tema nesneleri, belirli bir seviyede neyin tanımlandığını gösterir. Geçerli değerler ise kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt veya şeklin aslında ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseoverridethememanager/) çağırın. Arka plan için [Background.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/background/), doldurma için ise [FillFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/) kullanın.

Aşağıdaki örnek bir slayttan geçerli temayı, arka planı ve ilk şekil doldurmasını okur:

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

İşleme yönelik teşhis, doğrulama ve karşılaştırmalar için geçerli verileri kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) incelerseniz, tema, layout, slayt veya şekil geçersiz kılmalarını kaçırabilirsiniz.

## **SSS**

**Harici bir tema uygulamak sunumdaki her slaytı etkiler mi?**

Hayır. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) yalnızca seçilen master’a bağımlı slaytları yeniden atar. Diğer masterları kullanan slaytlar mevcut temalarını korur.

**Master’ı değiştirmeden tek bir slayta tema uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayta lokal kalır; diğer slaytlar mevcut temalarını devralmaya devam eder.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak masterı hedefe klonlayın ve ardından slaytı o master ile birlikte [MasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) ve [SlideCollection.addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/) kullanarak klonlayın. Böylece master, layout’lar ve tema birlikte taşınır.

**Kalıtım ve geçersiz kılmalardan sonra geçerli değerleri nasıl görebilirim?**

Bir slayt veya layout teması için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseoverridethememanager/) ve format nesneleri için ilgili geçerli‑veri metodlarını (ör. [Background.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/background/) ve [FillFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/)) kullanın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözümlenmiş değerleri döndürür.