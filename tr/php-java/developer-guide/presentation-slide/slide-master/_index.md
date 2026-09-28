---
title: PHP'de Sunum Slide Master'larını Yönet
linktitle: Slayt Master
type: docs
weight: 70
url: /tr/php-java/slide-master/
keywords:
- slayt master
- master slayt
- PPT master slaytı
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
description: "Aspose.Slides for PHP via Java içinde slayt master'larını yönetin: PowerPoint ve OpenDocument sunumlarındaki master slaytları erişin, düzenleyin, klonlayın, karşılaştırın ve kaldırın."
---
## **Genel Bakış**

Bir **slide master**, bir grup slayt için ortak tasarım ayarlarını tanımlar. Ortak şekiller, logolar, arka planlar, metin stilleri, tema ayarları ve alt bilgi ayarlarını içerebilir. PowerPoint'te, bir slide master'ı düzenlemek, aynı biçimlendirmeyi her slaytta tekrarlamadan sunumu tutarlı tutmanın yaygın yoludur.

Aspose.Slides for PHP via Java aynı modeli destekler. Bir sunum bir veya daha fazla master slayt içerebilir ve her master slayt birkaç layout slayt içerebilir. Normal slaytlar genellikle bir master slayta doğrudan başvurmaz. Bunun yerine, bir normal slayt bir layout slaytını kullanır ve bu layout slayt bir master slayta aittir.

Hiyerarşi şöyledir:

1. **Slide master** – ortak tasarımı ve temayı tanımlar.  
1. **Layout slayt** – yer tutucuların ve düzen seviyesindeki biçimlendirmelerin belirli bir düzenini tanımlar.  
1. **Normal slayt** – gerçek sunum içeriğini içerir ve bir layout slaytını kullanır.

![master slaytların, layout slaytların ve normal slaytların hiyerarşisi](slide-master_2.jpg)

Aspose.Slides'te bir slide master, [MasterSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) sınıfı ile temsil edilir. Bir sunumdaki tüm master slaytlar, [Presentation.getMasters](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getMasters) yöntemi aracılığıyla erişilebilir ve bu yöntem bir [MasterSlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) nesnesi döndürür.

{{% alert color="info" title="Kalıtım" %}}
Birden fazla seviyede aynı özellik tanımlandığında, daha spesifik seviye geçerli olur. Örneğin, bir master slayt ve bir layout slayt her ikisi de bir arka plan tanımlarsa, bu düzen üzerine kurulu slaytlar layout arka planını kullanır. Layout slaytları hakkında daha fazla bilgi için [Uygula veya Slayt Düzenlerini Değiştir](/slides/tr/php-java/slide-layout/) bölümüne bakın.
{{% /alert %}}

## **Slide Master'lara Erişim**

PowerPoint'te **Görünüm** > **Slide Master** menüsünden Slide Master görünümünü açabilirsiniz.

![PowerPoint Görünüm sekmesindeki Slide Master komutu](slide-master_3.jpg)

Aspose.Slides'te master slaytlara erişmek için `getMasters` yöntemini kullanın:

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

Ayrıca bir normal slaytın kullandığı layout üzerinden master slaytı alabilirsiniz:

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

## **Bir Slide Master Ne İçerir**

Bir master slayt, slayt benzeri bir nesnedir. [BaseSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/) sınıfını genişletir, dolayısıyla normal ve layout slaytlar tarafından kullanılan birçok slayt özelliğine sahiptir. Master‑özel üyeler [MasterSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/) API sayfasında listelenir.

Genellikle kullanılan master slayt üyeleri şunlardır:

| Üye | Amaç |
| --- | --- |
| `getBackground` | master‑seviyesindeki slayt arka planını ayarlar. |
| `getShapes` | logolar, resim çerçeveleri ve ortak metin gibi master üzerine yerleştirilen şekilleri tutar. |
| `getLayoutSlides` | master’a ait layout slaytlarını tutar. |
| `getThemeManager` | master tema API'lerine erişim sağlar. |
| `getHeaderFooterManager` | master ve ona bağlı layout'lar için üst bilgi, alt bilgi, tarih ve slayt numaralarını kontrol eder. |
| `getDependingSlides` | layout'ları aracılığıyla master'a bağımlı olan normal slaytları döndürür. |

## **Slide Master'a Görüntü Ekleme**

Bir master slayta bir görüntü eklerseniz, o master’dan layout kullanan slaytlarda görüntülenir. Logo, filigran, dekoratif bant ve diğer tekrarlanan görsel öğeler için faydalıdır.

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

Resim çerçeveleri hakkında daha fazla bilgi için [Picture Frame](/slides/tr/php-java/picture-frame/) sayfasına bakın.

## **Master Grafiklerinin Görünürlüğünü Kontrol Etme**

Miras alınan master grafiklerini (ör. logolar veya dekoratif şekiller) silmeden gizlemek için [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/#setShowMasterShapes) yöntemini kullanın. Bu grafikleri gizlemek istediğiniz slaytta [Slide::setShowMasterShapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#setShowMasterShapes) metoduna `false` gönderin ve görüntülenmesini istediğiniz slaytlarda `true` tutun.

Aşağıdaki bağımsız örnek, bir master’da mavi bir dekoratif bant oluşturur ve aynı boş layout’u kullanan iki slaytta farklı görünürlük ayarları uygular. Bant ilk slaytta görünür, ikincisinde gizlidir. Herhangi bir giriş sunumu veya resim gerekmez.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bu örnek yeni bir sunumda sağlanan **Blank** layout'unu kullanır ve ilk slayttaki yer tutucuları kaldırır.

### **Ayarın Kapsamını Seçme**

Normal bir slayt, master'ına [Slide::getLayoutSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#getLayoutSlide) ve [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#getMasterSlide) aracılığıyla ulaşır. Özelliği bireysel bir slaytta ayarlamak sadece o slaytı etkiler. [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/layoutslide/#setShowMasterShapes) metoduna `false` göndererek, paylaşılmış layout'u kullanan tüm slaytlarda master grafiklerini gizlersiniz; kendi ayarları `true` olsa bile. Tek bir slaytta grafikleri gizlemek için sadece slayt özelliğini değiştirin, paylaşılan layout'u bozmadan bırakın.

Bu ayar, master slayt üzerinde bir görünürlük kontrolü olarak desteklenmez. Bir master’da [getShowMasterShapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/#getShowMasterShapes) her zaman `false` döndürür ve [setShowMasterShapes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslide/#setShowMasterShapes) metoduna `true` gönderildiğinde istisna fırlatır. Bu yöntemi normal bir slayt veya layout üzerinde uygulayın.

### **Grafikleri Arka Plandan Ayırma**

| İşlem | Etki |
| --- | --- |
| Master grafiklerini gizle | Master’dan miras alınan şekilleri silmeden görünürlüğünü kontrol eder. |
| Slayt arka plan doldurmasını değiştir | Arka plan rengini, degradeyi veya resmi değiştirir. Master grafikleri ayrı şekiller olduğundan arka planın üzerindeyken görünür kalabilir. [Presentation Background](/slides/tr/php-java/presentation-background/) bölümüne bakın. |
| Master'dan bir şekli sil | Paylaşılan kaynak şekli kaldırır; bu şekil artık o master'ı kullanan hiçbir slaytta bulunmaz. |

## **Yer Tutucularla Çalışma**

Yer tutucular genellikle layout slaytlarda tanımlanır. Master slayt, bu layoutların miras aldığı ortak stil ve temayı sağlar; her layout ise hangi yer tutucuların mevcut olduğunu ve nerede konumlandırılacağını belirler.

PowerPoint'te, yer tutucu komutları Slide Master görünümünde bulunur.

![PowerPoint Slide Master görünümünde Yer Tutucu Ekle komutu](slide-master_5.png)

Aspose.Slides ile yeni yer tutucular eklemek için master'a ait layout slaytıyla çalışın:

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

Ayrıca master slaytta zaten var olan yer tutucu şekillerini biçimlendirebilirsiniz. Aşağıdaki örnek, başlık yer tutucusunu bulur ve lineer degrade doldurma uygular:

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

Bir master arka planı, üzerine yazılmadığı sürece layout ve slaytlar tarafından miras alınır. Aşağıdaki örnek, ilk master slayt için katı bir arka plan rengi ayarlar:

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

İlgili konular için [Presentation Background](/slides/tr/php-java/presentation-background/) ve [Presentation Theme](/slides/tr/php-java/presentation-theme/) bölümlerine bakın.

## **Bir Slide Master'ı Başka Bir Sunuma Kopyalama**

[MasterSlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) üzerinden `addClone` metodunu kullanarak bir master slaytı başka bir sunuma kopyalayabilirsiniz. Kopyalanan master, hedef sunumdaki layout ve slaytlar tarafından kullanılabilir.

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

Normal slaytları ve onların masterlarını da kopyalamanız gerekiyorsa, [Clone Slides](/slides/tr/php-java/clone-slides/) bölümüne bakın.

## **Birden Fazla Slide Master Ekleme**

Bir sunum birden çok master slayt içerebilir. Bu, farklı bölümlerin farklı marka kimliği, sayfa yapısı veya tema ayarları gerektirdiği durumlar için yararlıdır.

![PowerPoint'te master slayt ekleme ve yönetme komutları](slide-master_9.jpg)

Aşağıdaki örnek, varsayılan master'ı klonlar, klona farklı bir arka plan verir, o klonlanan master altında bir layout oluşturur ve bu layout üzerine yeni bir slayt ekler:

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

## **Slide Master'ları Karşılaştırma**

Master slaytlar, [BaseSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/) sınıfından kalıtılan `equals` yöntemiyle karşılaştırılabilir. Karşılaştırma, şekiller, metin, biçimlendirme, animasyonlar ve diğer slayt ayarları gibi yapı ve statik içeriği kontrol eder. Slayt kimlikleri gibi benzersiz tanımlayıcılar veya geçerli tarih gibi dinamik yer tutucu değerleri karşılaştırılmaz.

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

[ViewProperties](https://reference.aspose.com/slides/tr/php-java/aspose.slides/viewproperties/) üzerindeki `setLastView` yöntemi, PowerPoint'in ilk açtığında hangi görünümde olacağını kontrol eder. Aşağıdaki örnek, sunumu Slide Master görünümünde açar:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Daha fazla görünüm ayarı için [Save Presentation](/slides/tr/php-java/save-presentation/) bölümüne bakın.

## **Kullanılmayan Master Slaytları Kaldırma**

Bazen sunumlar, hiçbir normal slayt tarafından kullanılmayan master slaytlar içerir. Kullanılmayan master’ları kaldırmak dosya boyutunu azaltabilir ve şablon bakımını basitleştirir.

`removeUnused` metodunu [MasterSlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/masterslidecollection/) üzerinden kullanarak `getMasters` koleksiyonundan kullanılmayan master slaytları kaldırın:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ayrıca [Compress](https://reference.aspose.com/slides/tr/php-java/aspose.slides/compress/) sınıfındaki düşük‑kodlu `removeUnusedMasterSlides` metodunu da kullanabilirsiniz:

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

Slide master, tema, arka plan, ortak şekiller ve metin stilleri gibi ortak tasarım ayarlarını tanımlar. Layout slayt, bir master slayta ait olup yer tutucuların belirli bir düzenini tanımlar. Normal bir slayt bir layout slayt kullanır, bu yüzden hem layout hem de master'dan miras alır.

**Bir sunum birden çok slide master içerebilir mi?**

Evet. Bir sunum birden çok slide master içerebilir. Farklı bölümlerin farklı görsel sistemlere veya markalaşmaya ihtiyacı olduğunda birden fazla master kullanın.

**Yer tutucuları bir master slayta mı yoksa bir layout slayta mı eklemeliyim?**

Çoğu durumda yer tutucuları layout slaytlara ekleyin. Ortak görsel öğeleri ve ortak biçimlendirmeyi master slayta, içerik yer tutucularını ise normal slaytların kullanacağı layout slaytlara yerleştirin.

**Kullanımda olan bir master slaytı silebilir miyim?**

Hayır. Bağımlı slaytları olan bir master slayt doğrudan güvenli bir şekilde kaldırılamaz. Önce bu slaytları başka bir master altında layoutlara taşıyın veya yalnızca kullanılmayan master slaytları temizleyen bir yöntem kullanın.