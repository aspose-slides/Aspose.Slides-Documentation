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
- tema değiştir
- tema yönet
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
description: "Aspose.Slides for PHP via Java ile tutarlı marka kimliği sağlamak için PowerPoint dosyalarını oluşturma, özelleştirme ve dönüştürme amaçlı ana sunum temaları."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, dolgu, çizgi ve efektlerden oluşan koordineli bir küme tanımlar. Tema‑bilincine sahip nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur; böylece bir tema değişikliği, birden fazla nesneyi aynı anda güncelleyebilir.

Aspose.Slides içinde, sunum seviyesindeki tema [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) aracılığıyla kullanılabilir. Bir sunum ayrıca daha alt seviyelerde tema geçersiz kılmaları içerebilir. Bir master, [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterthememanager/) ile sunum temasını geçersiz kılabilir; bir layout ya da tek bir slayt ise [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseoverridethememanager/) ile devralınan temayı geçersiz kılabilir. Pratikte, bir slayd için geçerli tema, şu kalıtım zinciri aracılığıyla çözülür: sunum teması, master geçersiz kılma, layout geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleyin**

[MasterTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mastertheme/) nesnesi, temanın renk şemasını, yazı tipi şemasını ve biçim şemasını sırasıyla [MasterTheme.getColorScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mastertheme/) ve [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mastertheme/) aracılığıyla sunar. Bu koleksiyonları değiştirmeden önce incelemek, dış bir kaynaktan gelen bir sunumun stil girişlerinin sayısı ve içeriği değişebileceği için özellikle yararlıdır.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç tane arka plan, dolgu, çizgi ve efekt stilinin depolandığını raporlar:

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

Bir dosya birden fazla master kullanıyorsa, her slaydın aynı etkili temaya sahip olduğunu varsaymayın. Slaytla ilişkili master’ı inceleyin ve layout veya slayt geçersiz kılmaları mevcut olduğunda bu makalenin ilerleyen kısmında gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirin**

Tema‑bilincine sahip dolgu, çizgi ve metinler, [SchemeColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/schemecolor/) enum’undan mantıksal bir renge başvurabilir. [ColorScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/colorscheme/) içinde ilgili girdiyi değiştirdiğinizde, hâlâ o tema rengini referans alan tüm nesneler yeni değere göre çözümlenir. Doğrudan RGB rengi kullanan nesneler tema‑renk güncellemesinden etkilenmez.

Aşağıdaki uçtan uca örnek, `Accent4` kullanan bir şekil oluşturur, temanın `Accent4` rengini kırmızıya değiştirir, sunumu kaydeder, tekrar açar ve etkili dolgu rengini yazdırır:

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

Dikdörtgen `Accent4`e bağlı kaldığından, tema değiştirildiğinde görünen rengi kırmızı olur. Şekilde şema rengini doğrudan bir renkle değiştirirseniz, sonraki `Accent4` değişiklikleri o dolguyu etkilemez.

### **Ek Paletten Renk Kullanımı**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar üretmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/colortransformoperation/) enum’u aracılığıyla sunar.

![Ek paletten oluşturulan ana tema renkleri ve daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** – Ana tema renkleri.

**2** – Ana tema renklerinden türetilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `Accent4` temelli altı dikdörtgen oluşturur, beş tanesine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

[SchemeColor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/schemecolor/) enum’u `Text1`, `Background1`, `Text2` ve `Background2` değerlerini kullanırken, [ColorScheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/colorscheme/) aynı tema yuvalarını `Dark1`, `Light1`, `Dark2` ve `Light2` olarak sunar. Eşleme sabittir:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirin**

Bir tema yazı tipi şeması, başlıklar için bir ana (major) yazı tipi seti ve gövde metni için bir yan (minor) yazı tipi seti içerir. [FontScheme.getMajor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontscheme/) ve [FontScheme.getMinor](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontscheme/) metodları bu setleri ortaya çıkarır.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

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

Başlık ana yazı tipini, gövde metni ise yan yazı tipini izler. Tema kimliği yerine açık bir yazı tipi adı kullanılan metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

{{% alert color="info" title="İpucu" %}}
Daha fazla sunum yazı tipi bilgisi için [PowerPoint Fonts](/slides/tr/php-java/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

## **Bir Temayı Kopyalayın veya Uygulayın**

İki yaygın iş akışı vardır ve farklı sorunları çözer.

### **Kaynak Temayı Slayt Taşırken Koruyun**

Bir slaytı başka bir sunuma taşıyıp orijinal tasarımını korumak istiyorsanız, kaynak master’ı [MasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) ile hedef sunuma kopyalayın, ardından kopyalanmış master ile slaytı [SlideCollection.addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/) ile klonlayın. Bu, master’ı, layout’ları ve ilişkili temayı birlikte taşır.

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

Bu, kaynak slaydın hedefte aynı görünmesi gerektiğinde tercih edilen iş akışıdır. İçeriği bağımsız bir hedef master’a klonlamak, tema‑türü renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygulayın**

Hedef slayt mevcut master ve layout’unda kalmalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/overridetheme/) ve [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/overridetheme/) metodları, üç ana tema bileşenini geçersiz kılamaya kopyalar.

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

Bu, diğer slaytların devraldığı temayı etkilemeden yalnızca o slaydın temasını değiştirir. Yerel geçersiz kılmayı kaldırıp devralınan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/overridetheme/) çağırın.

### **Bir Layout’a Tema Geçersiz Kılma Uygulayın**

Layout‑seviyesi bir geçersiz kılma, o layout’ı kullanan slaytlara uygulanır; belirli bir slaydın kendi geçersiz kılma ayarı yoksa. Aynı başlatma metodları, [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslidethememanager/) üzerinden kullanılabilir:

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

Birden çok layout ve slayt aynı temel tasarımı paylaşmalıysa master veya sunum‑seviyesi tema kullanın; bir layout ailesi farklı stil gerektiriyorsa layout geçersiz kılması; yalnızca gerçek istisnalar için slayt geçersiz kılması tercih edin. Aşırı slayt‑seviyesi geçersiz kılımlar, sonraki genel tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleyin**

Temanın arka plan dolgu stilleri, [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/formatscheme/) içinde depolanır. PowerPoint, UI’da temalı dolguları tema renkleri ve diğer stil referanslarıyla birleştirerek, bu koleksiyonda fiziksel olarak tanımlı dolgu sayısından daha fazla arka plan seçeneği sunabilir.

![Sunum teması için PowerPoint arka plan stil galerisii](presentation-design_8.png)

Bir arka plan stili kullanmadan önce, depolanmış koleksiyonu ve mevcut [Background.getStyleIndex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/background/) değerini inceleyin. `0` stil indeksi, temalı bir dolgu olmadığını; pozitif değerler ise tema arka plan‑stil referanslarını gösterir. Bu, PHP koleksiyonuna doğrudan indeksleme (`get_Item(0)` ilk depolanmış öğeyi gösterir) ile aynı şey değildir. Her sunumun aynı sayıda arka plan dolgu stili içerdiğini varsaymayın.

Aşağıdaki örnek, mevcut arka plan dolgu sayısını raporlar, ilk master’a temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünüm, master’ın referans verdiği tema girdisine ve layout ya da slayt seviyesindeki olası arka plan geçersiz kılmalarına bağlıdır. Sadece master arka planını değiştirirseniz, kendi arka planını kullanan bir slayt etkilenmeyebilir. Kalıtım uygulanmış nihai arka planı öğrenmek için [Background.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/background/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
Stil indeksini sıfır‑tabanlı bir koleksiyon indeksi olarak yorumlamayın. Ayrıca bir dosyadan stil numarasını sabit kodlayıp başka bir dosyada aynı görünüm olduğunu varsamayın; tema stil tanımları sunuma özgüdür.
{{% /alert %}}

{{% alert color="info" title="İpucu" %}}
Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/php-java/presentation-background/) bölümüne bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleyin**

Bir tema biçim şeması, [FormatScheme.getFillStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/formatscheme/) ve [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/tr/php-java/aspose.slides/formatscheme/) aracılığıyla sunulan ayrı dolgu, çizgi ve efekt stil koleksiyonları içerir. Tipik Office temaları, görsel olarak hafif, orta ve yoğun biçimlendirmeye karşılık gelen üç ana stil girdisi içerir, ancak kod sabit bir sayıyı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

PHP’da bu koleksiyonlara erişirken, koleksiyon indeksi sıfır‑tabanlıdır: `get_Item(0)` ilk depolanmış stil, `get_Item(2)` ise üçüncüdür. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [ShapeStyle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapestyle/) aracılığıyla ortaya çıkar. Bir tema stilini değiştirmek, o stil referansını kullanan şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

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

Bu yuvalara başvuran şekiller için, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puan uzaklıkta dış gölge kazanır. Kesin görsel sonuç yine hangi stil yuvalarının hangi şekiller tarafından referans alındığına ve doğrudan biçimlendirmenin temayı geçersiz kılıp kıldığına bağlıdır.

![Satır, dolgu ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Etkili Tema Değerlerini Okuyun**

Ham tema nesneleri, belirli bir seviyede ne tanımlandığını gösterir. Etkili değerler ise, kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt ya da şeklin gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseoverridethememanager/) çağırın. Bir arka plan için [Background.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/background/), bir dolgu için ise [FillFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/) kullanın.

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

Render teşhisleri, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation.getMasterTheme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) incelerseniz, final görünümü değiştiren bir master, layout, slayt veya şekil geçersiz kılmasını kaçırabilirsiniz.

## **SSS**

**Bir slayda master’ı değiştirmeden tema uygulayabilir miyim?**

Evet. Slaydın [SlideThemeManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidethememanager/) aracılığıyla geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayda yerel olarak uygulanır; diğer slaytlar mevcut temalarını devralmaya devam eder.

**Bir temayı bir sunumdan diğerine taşırken en güvenli yol nedir?**

Slaytı taşıyıp orijinal görünümünü korumak istediğinizde, kaynak master’ı hedefte klonlayın ve ardından slaytı bu master ile [MasterSlideCollection.addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) ve [SlideCollection.addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/) kullanarak klonlayın. Bu, master, layout’lar ve temayı birlikte tutar.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya layout teması için [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseoverridethememanager/), ve format nesneleri için ilgili etkili‑veri metodlarını (ör. [Background.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/background/) ve [FillFormat.getEffective](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/)) kullanın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözümlenmiş değerleri döndürür.