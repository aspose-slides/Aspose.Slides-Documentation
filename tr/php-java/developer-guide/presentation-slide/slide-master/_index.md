---
title: PHP'de Sunum Slide Master'larını Yönet
linktitle: Slayt Master
type: docs
weight: 70
url: /tr/php-java/slide-master/
keywords:
- slayt master
- master slayt
- PPT master slayt
- birden fazla master slayt
- master slaytları karşılaştır
- arka plan
- yer tutucu
- master slaytı klonla
- master slaytı kopyala
- master slaytı çoğalt
- kullanılmayan master slayt
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da slayt master'larını yönetin: PowerPoint ve OpenDocument sunumlarındaki master slaytları erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slide master**, bir grup slayt için ortak tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve alt bilgi ayarları içerebilir. PowerPoint’te bir slide master’ı düzenlemek, aynı biçimlendirmeyi her slaytta tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for PHP via Java aynı modeli destekler. Bir sunum bir veya daha fazla master slayt içerebilir ve her master slayt birden çok layout slaytına sahip olabilir. Normal slaytlar genellikle doğrudan bir master slayta başvurmaz. Bunun yerine bir normal slayt bir layout slaytı kullanır ve bu layout slayt bir master slayta aittir.

Hiyerarşi şöyledir:

1. **Slide master** – ortak tasarım ve temayı tanımlar.  
1. **Layout slide** – yer tutucuların ve layout‑seviyesi biçimlendirmelerin belirli bir düzenini tanımlar.  
1. **Normal slide** – gerçek sunum içeriğini barındırır ve bir layout slaytını kullanır.

![Master slaytların, layout slaytların ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides’ta bir slide master, [MasterSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) sınıfı ile temsil edilir. Bir sunumdaki tüm master slaytlar, [Presentation.getMasters](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getMasters) yöntemiyle elde edilen bir [MasterSlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) nesnesi aracılığıyla kullanılabilir.

{{% alert color="info" title="Kalıtım" %}}

Birden fazla seviyede aynı özellik tanımlandığında, daha spesifik seviye geçerli olur. Örneğin bir master slayt ve bir layout slayt aynı arka planı tanımlıyorsa, o layout’a dayalı slaytlar layout arka planını kullanır. Layout slaytları hakkında daha fazla bilgi için [Apply or Change Slide Layouts](/slides/tr/php-java/slide-layout/) bölümüne bakın.

{{% /alert %}}

## **Slide Master’lara Erişim**

PowerPoint’te **View** > **Slide Master** yoluyla Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides’ta master slaytlara erişmek için `getMasters` yöntemini kullanın:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Bir normal slaytın kullandığı master slaytı, layout’u aracılığıyla da alabilirsiniz:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Bir Slide Master’da Ne Bulunur**

Bir master slayt, slayt benzeri bir nesnedir. [BaseSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/) sınıfını genişlettiği için normal ve layout slaytlarda kullanılan birçok slayt özelliğine sahiptir. Master‑özel üyeler [MasterSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) API sayfasında listelenir.

Sık kullanılan master slayt üyeleri şunlardır:

| Üye | Amaç |
| --- | --- |
| `getBackground` | Master‑seviyesindeki slayt arka planını ayarlar. |
| `getShapes` | Logolar, resim çerçeveleri ve ortak metin gibi master üzerine yerleştirilen şekilleri depolar. |
| `getLayoutSlides` | Master’a ait layout slaytları saklar. |
| `getThemeManager` | Master tema API’lerine erişim sağlar. |
| `getHeaderFooterManager` | Master ve ona bağlı layout’lar için başlık, alt bilgi, tarih ve slayt numaralarını kontrol eder. |
| `getDependingSlides` | Layoutları aracılığıyla master’a bağımlı olan normal slaytları döndürür. |

## **Slide Master’a Bir Resim Ekleme**

Bir master slayta bir resim eklendiğinde, o master’ın layoutlarını kullanan slaytlarda görüntülenir. Bu, logolar, filigranlar, dekoratif bantlar ve diğer tekrar eden görsel öğeler için kullanışlıdır.

Aşağıdaki örnek, ilk master slayta bir logo ekler:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resim çerçeveleri hakkında daha fazla bilgi için [Picture Frame](/slides/tr/php-java/picture-frame/) bölümüne bakın.

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle layout slaytlarda tanımlanır. Master slayt, bu layoutların miras alacağı ortak stil ve temayı sağlar; her layout ise hangi yer tutucuların bulunacağını ve nerede yer alacağını belirler.

PowerPoint’te yer tutucu komutları Slide Master görünümünde bulunur.

![PowerPoint Slide Master görünümündeki Insert Placeholder komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için master’a ait layout slaytıyla çalışın:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ayrıca master slaytta zaten bulunan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve doğrusal bir degrade doldurma uygular:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Normal slaytlar tarafından miras alınan biçimlendirilmiş başlık yer tutucusu](slide-master_8.png)

Daha fazla yer tutucu ve metin biçimlendirme seçeneği için [Set Prompt Text in Placeholder](/slides/tr/php-java/manage-placeholder/) ve [Text Formatting](/slides/tr/php-java/text-formatting/) bölümlerine bakın.

## **Slide Master Arka Planını Değiştirme**

Bir master arka planı, üzerine yazılmayan layout ve slaytlar tarafından miras alınır. Aşağıdaki örnek, ilk master slayt için katı bir arka plan rengi ayarlar:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

İlgili konular için [Presentation Background](/slides/tr/php-java/presentation-background/) ve [Presentation Theme](/slides/tr/php-java/presentation-theme/) bölümlerine göz atın.

## **Bir Slide Master’ı Başka Bir Sunuma Kopyalama**

[MasterSlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) üzerindeki `addClone` yöntemi, bir master slaytı başka bir sunuma kopyalamanızı sağlar. Kopyalanan master, hedef sunumdaki layout ve slaytlar tarafından kullanılabilir.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

Normal slaytları masterlarıyla birlikte klonlamak için [Clone Slides](/slides/tr/php-java/clone-slides/) bölümüne bakın.

## **Birden Çok Slide Master Ekleme**

Bir sunum birden çok master slayt içerebilir. Bu, farklı bölümlerin farklı marka kimliği, sayfa yapısı veya tema ayarları gerektirdiği durumlarda faydalıdır.

![Master slayt ekleme ve yönetme PowerPoint komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan master’ı klonlar, klona farklı bir arka plan verir, bu klonlanmış master altında bir layout oluşturur ve o layout temelinde yeni bir slayt ekler:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Slide Master’ları Karşılaştırma**

Master slaytlar, [BaseSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/) sınıfından devralınan `equals` yöntemiyle karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği kontrol eder. Slayt kimlikleri gibi benzersiz tanımlayıcıları veya geçerli tarih gibi dinamik yer tutucu değerlerini karşılaştırmaz.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

Daha fazla bilgi için [Compare Presentation Slides](/slides/tr/php-java/compare-slides/) bölümüne bakın.

## **Slide Master Görünümünü Varsayılan Görünüm Olarak Ayarlama**

[ViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/) üzerindeki `setLastView` yöntemi, PowerPoint’in ilk olarak açtığı görünümü kontrol eder. Aşağıdaki örnek sunumu Slide Master görünümünde açar:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Daha fazla görünüm ayarı için [Save Presentation](/slides/tr/php-java/save-presentation/) bölümüne göz atın.

## **Kullanılmayan Master Slaytları Kaldırma**

Bazen bir sunum, normal slaytlar tarafından artık kullanılmayan master slaytlar içerir. Kullanılmayan masterları kaldırmak dosya boyutunu azaltabilir ve şablon bakımını basitleştirebilir.

[MasterSlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) üzerindeki `removeUnused` yöntemiyle `getMasters` koleksiyonundaki kullanılmayan masterlar kaldırılabilir:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ayrıca [Compress](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/) sınıfındaki düşük‑kodlu `removeUnusedMasterSlides` yöntemi de kullanılabilir:

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Slide master ile layout slayt arasındaki fark nedir?**

Slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi ortak tasarım ayarlarını tanımlar. Layout slayt, bir master slayta aittir ve yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir layout slayt kullanır, böylece hem layout hem de master’dan miras alır.

**Bir sunum birden fazla slide master içerebilir mi?**

Evet. Bir sunum birden çok slide master içerebilir. Farklı bölümlerin farklı görsel sistemler veya marka kimliği gerektirdiği durumlarda birden fazla master kullanın.

**Yer tutucuları master slayta mı yoksa layout slayta mı eklemeliyim?**

Çoğu durumda yer tutucuları layout slaytlara ekleyin. Ortak görsel öğeleri ve ortak biçimlendirmeyi master slayta, içerik yer tutucularını ise normal slaytların kullanacağı layout slaytlara yerleştirin.

**Kullanımda olan bir master slaytı silebilir miyim?**

Hayır. Bağımlı slaytları olan bir master slaytı doğrudan güvenli bir şekilde kaldırılamaz. Önce bu slaytları başka bir master altındaki layoutlara taşıyın veya yalnızca kullanılmayan masterları kaldıran bir temizlik yöntemi kullanın.