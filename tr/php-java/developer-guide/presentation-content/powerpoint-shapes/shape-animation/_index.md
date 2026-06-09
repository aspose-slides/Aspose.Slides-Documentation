---
title: PHP Kullanarak Sunumlarda Şekil Animasyonları Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/php-java/shape-animation/
keywords:
- şekil
- animasyon
- efekt
- canlandırılmış şekil
- canlandırılmış metin
- animasyon ekle
- animasyon al
- animasyonu çıkar
- efekt ekle
- efekt al
- efekti çıkar
- efekt sesi
- animasyon uygula
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint sunumlarında şekil animasyonları oluşturmayı ve özelleştirmeyi keşfedin. Öne çıkın!"
---
## **Giriş**

Animasyonlar, metinlere, görüntülere, şekillere veya [charts](https://docs.aspose.com/slides/tr/php-java/animated-charts/) uygulanabilen görsel efektlerdir. Sunumlara veya bileşenlerine hayat verir.

## **Sunumlarda Animasyon Kullanmanın Nedenleri?**

Animasyonları kullanarak

* bilgi akışını kontrol edebilirsiniz
* önemli noktaları vurgulayabilirsiniz
* izleyicilerinizin ilgisini veya katılımını artırabilirsiniz
* içeriği daha kolay okuyabilir, sindirebilir veya işleyebilirsiniz
* izleyicilerinizin dikkatini sunumdaki önemli bölümlere yönlendirebilirsiniz

PowerPoint, **giriş**, **çıkış**, **vurgulama** ve **hareket yolları** kategorilerinde animasyonlar ve animasyon efektleri için birçok seçenek ve araç sağlar. 

## **Aspose.Slides'ta Animasyonlar**

* Aspose.Slides, animasyonlarla çalışmak için ihtiyaç duyduğunuz sınıfları ve tipleri `Aspose.Slides.Animation` ad alanı altında sağlar,
* Aspose.Slides, [EffectType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effecttype) sayımı altında **150'den fazla animasyon efekti** sunar. Bu efektler, temelde PowerPoint'te kullanılan aynı (veya eşdeğer) efektlerdir.

## **Bir Metin Kutusuna Animasyon Uygulama**

Aspose.Slides for PHP via Java, bir şeklin içindeki metne animasyon uygulamanıza olanak tanır.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayt referansı elde edin.
3. Bir dikdörtgen [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. `AutoShape`'ın [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/#getTextFrame) öğesine metin ekleyin.
5. Efektlerin ana dizisini alın.
6. [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/)’a bir animasyon efekti ekleyin.
7. `TextAnimation.setBuildType` metodunu ve `BuildType` sayımından gelen değeri kullanın.
8. Sunumu bir PPTX dosyası olarak diske yazın.

Bu PHP kodu, `Fade` efektini AutoShape'e nasıl uygulayacağınızı ve metin animasyonunu *By 1st Level Paragraphs* değerine nasıl ayarlayacağınızı gösterir:

```php
  # Sunum dosyasını temsil eden bir sunum sınıfı örneklenir.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Metinli yeni bir AutoShape ekler
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Slaytın ana dizisini alır.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Şekle Fade animasyon efekti ekler
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Şekil metnini 1. seviye paragraflara göre canlandırır
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # PPTX dosyasını diske kaydeder
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

Metne animasyon uygulamanın yanı sıra, tek bir [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) üzerine de animasyon uygulayabilirsiniz. Bakınız [**Animated Text**](/slides/tr/php-java/animated-text/).

{{% /alert %}} 

## **Bir PictureFrame'e Animasyon Uygulama**

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayt referansı elde edin.
3. Slayta bir [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe) ekleyin veya alın.
4. Efektlerin ana dizisini alın.
5. [PictureFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pictureframe)’e bir animasyon efekti ekleyin.
6. Sunumu bir PPTX dosyası olarak diske yazın.

Bu PHP kodu, bir picture frame’e `Fly` efektini nasıl uygulayacağınızı gösterir:

```php
  # Sunum dosyasını temsil eden bir sunum sınıfı örneklenir.
  $pres = new Presentation();
  try {
    # Sunum görüntü koleksiyonuna eklenecek görüntüyü yükler
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Slayta resim çerçevesi ekler
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Slaytın ana dizisini alır.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Resim çerçevesine Sol taraftan Uçuş animasyon efekti ekler
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # PPTX dosyasını diske kaydeder
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Şekle Animasyon Uygulama**

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayt referansı elde edin.
3. Bir dikdörtgen [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
4. Bir köşe (bevel) [AutoShape] ekleyin (bu nesne tıklandığında animasyon oynatılır).
5. Köşe (bevel) şekli üzerinde bir efekt dizisi oluşturun.
6. Özel bir `UserPath` oluşturun.
7. `UserPath`'e hareket komutları ekleyin.
8. Sunumu bir PPTX dosyası olarak diske yazın.

Bu PHP kodu, bir şekle `PathFootball` (path football) efektini nasıl uygulayacağınızı gösterir:

```php
  # PPTX dosyasını temsil eden bir Presentation sınıfı örneklenir.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Mevcut şekil için sıfırdan PathFootball efekti oluşturur.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # PathFootBall animasyon efekti ekler
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Bir tür "buton" oluşturur.
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Bu buton için bir efekt dizisi oluşturur.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Özel bir kullanıcı yolu oluşturur. Nesnemiz sadece butona tıklandıktan sonra hareket ettirilecektir.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Oluşturulan yol boş olduğu için hareket komutları ekler.
    $motionBvh = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBvh->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBvh->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBvh->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # PPTX dosyasını diske yazar
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bir Şekle Uygulanan Animasyon Efektlerini Al**

Aşağıdaki örnekler, bir şekle uygulanan tüm animasyon efektlerini almak için [Sequence](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sequence/) sınıfındaki `getEffectsByShape` metodunu nasıl kullanacağınızı gösterir.

**Örnek 1: Normal bir slaytta bir şekle uygulanan animasyon efektlerini alın**

Daha önce PowerPoint sunumlarında şekillere animasyon efektleri eklemeyi öğrenmiştiniz. Aşağıdaki örnek kod, `AnimExample_out.pptx` sunumundaki ilk normal slayttaki ilk şekle uygulanan efektleri nasıl alacağınızı gösterir:

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Slaytın ana animasyon dizisini alır.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # İlk slayttaki ilk şekli alır.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Şekle uygulanan animasyon efektlerini alır.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

**Örnek 2: Yer tutuculardan devralınanlar dahil olmak üzere tüm animasyon efektlerini alın**

Normal bir slayttaki bir şeklin yer tutucuları, düzen slaytı ve/veya ana slaytta bulunuyorsa ve bu yer tutuculara animasyon efektleri eklenmişse, slayt gösterisi sırasında şeklin tüm efektleri, yer tutuculardan devralınanlar da dahil olmak üzere oynatılır.

Diyelim ki `sample.pptx` adlı bir PowerPoint sunum dosyamız var ve bir slaytta yalnızca "Made with Aspose.Slides" metnini içeren bir altbilgi şekli bulunuyor ve **Random Bars** efekti bu şekle uygulanmış.

![Slayt şekil animasyon efekti](slide-shape-animation.png)

Ayrıca, **Split** efektinin **layout** slaydındaki altbilgi yer tutucusuna uygulandığını varsayalım.

![Düzen şekil animasyon efekti](layout-shape-animation.png)

Ve sonunda, **Fly In** efektinin **master** slaydındaki altbilgi yer tutucusuna uygulandığını varsayalım.

![Master şekil animasyon efekti](master-shape-animation.png)

Aşağıdaki örnek kod, [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) sınıfındaki `getBasePlaceholder` metodunu kullanarak şekil yer tutucularına erişmenizi ve altbilgi şekline uygulanan animasyon efektlerini, düzen ve ana slaytlarda bulunan yer tutuculardan devralınanlar dahil olmak üzere almanızı gösterir:

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Normal slayttaki şeklin animasyon efektlerini al.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Düzen slaydındaki yer tutucunun animasyon efektlerini al.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Ana slaydındaki yer tutucunun animasyon efektlerini al.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```
```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Fly, Bottom
Type: 134, subtype: 45            // Split, VerticalIn
Type: 126, subtype: 22            // RandomBars, Horizontal
```

## **Animasyon Efekti Zamanlama Yöntemlerini Değiştirme**

Aspose.Slides for PHP via Java, bir animasyon efektinin Zamanlama özelliklerini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint’teki Animasyon Zamanlama bölmesidir:

![Animasyon Zamanlama bölmesi](shape-animation.png)

PowerPoint Zamanlaması ile [Effect Timing](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/#getTiming) özellikleri arasındaki eşleşmeler:

- PowerPoint Zamanlaması **Start** açılır listesi, [Timing::getTriggerType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/#getTriggerType) metoduna karşılık gelir.
- PowerPoint Zamanlaması **Duration**, [Timing::getDuration](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/#getDuration) metoduna karşılık gelir. Bir animasyonun süresi (saniye) bir döngünün tamamlanması için gereken toplam süredir.
- PowerPoint Zamanlaması **Delay**, [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/tr/php-java/aspose.slides/timing/#getTriggerDelayTime) metoduna karşılık gelir.

Effect Timing özelliklerini şu şekilde değiştirebilirsiniz:

1. [Şekle animasyon uygulama](#apply-animation-to-shape) bölümünden animasyon efektini uygulayın veya alın.
2. [Effect::getTiming](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/#getTiming) metodunu kullanarak ihtiyacınız olan yeni değerleri ayarlayın.
3. Değiştirilmiş PPTX dosyasını kaydedin.

Bu PHP kodu işlemi gösterir:

```php
  # Sunum dosyasını temsil eden bir sunum sınıfı örnekler.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Slaytın ana dizisini alır.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Ana dizinin ilk efektini alır.
    $effect = $sequence->get_Item(0);
    # Efektin TriggerType'ını tıklamayla başlatacak şekilde değiştirir
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Efektin süresini değiştirir
    $effect->getTiming()->setDuration(3.0);
    # Efektin TriggerDelayTime'ını değiştirir
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # PPTX dosyasını diske kaydeder
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animasyon Efekti Sesi**

Aspose.Slides, animasyon efektlerinde sesle çalışmanıza olanak tanıyan aşağıdaki metodları sağlar:

- [setSound(IAudio value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Animasyon Efekti Sesi Ekle**

Bu PHP kodu, bir animasyon efekti sesini nasıl ekleyeceğinizi ve bir sonraki efekt başladığında sesi nasıl durduracağınızı gösterir:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Sunuma ses ekler (ses koleksiyonuna)
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # Slaytın ana dizisini alır.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Ana dizinin ilk efektini alır
    $firstEffect = $sequence->get_Item(0);
    # Etkiyi "No Sound" için kontrol eder
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # İlk etki için ses ekler
      $firstEffect->setSound($effectSound);
    }
    # Slaytın ilk etkileşimli dizisini alır.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Etkinin "Stop previous sound" bayrağını ayarlar
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # PPTX dosyasını diske yazar
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Animasyon Efekti Sesini Çıkar**

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeksine göre bir slayt referansı elde edin. 
3. Efektlerin ana dizisini alın. 
4. Her animasyon efektine gömülmüş olan [setSound(IAudio value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) metodunu çıkarın.

Bu PHP kodu, bir animasyon etkisine gömülü sesi nasıl çıkaracağınızı gösterir:

```php
  # Sunum dosyasını temsil eden bir sunum sınıfı örnekler.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Slaytın ana dizisini alır.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Efekt sesini bayt dizisi olarak çıkarır
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Animasyondan Sonra**

Aspose.Slides for PHP via Java, bir animasyon efektinin After animation (Animasyondan Sonra) özelliğini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint’teki Animasyon Efekti bölmesi ve genişletilmiş menüdür:

![Animasyon Efekti bölmesi](shape-after-animation.png)

PowerPoint Effect **After animation** açılır listesi aşağıdaki metodlara karşılık gelir:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/#setAfterAnimationType) metodu After animation tipini tanımlar:
  * PowerPoint **More Colors** seçeneği, [AfterAnimationType::Color](https://reference.aspose.com/slides/tr/php-java/aspose.slides/afteranimationtype/#Color) tipine karşılık gelir;
  * PowerPoint **Don't Dim** seçeneği, [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/tr/php-java/aspose.slides/afteranimationtype/#DoNotDim) tipine (varsayılan) karşılık gelir;
  * PowerPoint **Hide After Animation** seçeneği, [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation) tipine karşılık gelir;
  * PowerPoint **Hide on Next Mouse Click** seçeneği, [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/tr/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) tipine karşılık gelir;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/#setAfterAnimationColor) metodu bir animasyondan sonraki renk formatını tanımlar. Bu metod, [AfterAnimationType::Color](https://reference.aspose.com/slides/tr/php-java/aspose.slides/afteranimationtype/#Color) tipiyle birlikte çalışır. Tipi başka bir değere değiştirirseniz, animasyondan sonraki renk temizlenir.

Bu PHP kodu bir animasyondan sonraki efekti nasıl değiştireceğinizi gösterir:

```php
  # Bir sunum dosyasını temsil eden bir Presentation sınıfı örnekler.
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Ana dizinin ilk efektini alır.
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Animasyondan sonraki türü Renk olarak değiştirir.
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Animasyondan sonraki karartma rengini ayarlar.
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # PPTX dosyasını diske yazar.
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Metni Canlandırma**

Aspose.Slides, bir animasyon efektinin *Animate text* (Metni Canlandır) bloğu ile çalışmanıza olanak tanıyan aşağıdaki metodları sağlar:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/#setAnimateTextType) metodu, efektin metni canlandırma tipini tanımlar. Şekil metni şu şekillerde canlandırılabilir:
  - Hepsi birden ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/tr/php-java/aspose.slides/animatetexttype/#AllAtOnce) tipi)
  - Kelime kelime ([AnimateTextType::ByWord](https://reference.aspose.com/slides/tr/php-java/aspose.slides/animatetexttype/#ByWord) tipi)
  - Harf harf ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/animatetexttype/#ByLetter) tipi)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/#setDelayBetweenTextParts) metodu, canlandırılan metin bölümleri (kelimeler veya harfler) arasındaki gecikmeyi ayarlar. Pozitif bir değer, efekt süresinin yüzdesini belirtir. Negatif bir değer ise saniye cinsinden gecikmeyi belirtir.

Effect Animate text özelliklerini şu şekilde değiştirebilirsiniz:

1. [Şekle animasyon uygulama](#apply-animation-to-shape) bölümünden animasyon efektini uygulayın veya alın.
2. `setBuildType(int value)` metodunu ve [BuildType::AsOneObject](https://reference.aspose.com/slides/tr/php-java/aspose.slides/buildtype/#AsOneObject) değerini kullanarak *By Paragraphs* animasyon modunu kapatın.
3. Yeni değerleri [setAnimateTextType(int value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/#setAnimateTextType) ve [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/#setDelayBetweenTextParts) metodlarıyla ayarlayın.
4. Değiştirilmiş PPTX dosyasını kaydedin.

Bu PHP kodu işlemi gösterir:

```php
  # Sunum dosyasını temsil eden bir Presentation sınıfı örnekler.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Ana dizinin ilk efektini alır
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Etkinin Metin animasyonu tipini "As One Object" olarak değiştirir
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Etkinin Metin canlandırma tipini "By word" olarak değiştirir
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Kelimeler arasındaki gecikmeyi efekt süresinin %20'si olarak ayarlar
    $firstEffect->setDelayBetweenTextParts(20.0);
    # PPTX dosyasını diske kaydeder
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Sunumu web’e yayınlarken animasyonların korunmasını nasıl sağlayabilirim?**

[Export to HTML5](/slides/tr/php-java/export-to-html5/) seçeneğini kullanın ve [shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/html5options/setanimateshapes/) ve [transition](https://reference.aspose.com/slides/tr/php-java/aspose.slides/html5options/setanimatetransitions/) animasyonlarından sorumlu seçenekleri etkinleştirin. Düz HTML slayt animasyonlarını oynatmaz, HTML5 ise oynatır.

**Şekillerin z-order (katman sırası) değiştirilmesi animasyonu nasıl etkiler?**

Animasyon ve çizim sırası bağımsızdır: bir efekt, görünme/gizlenme zamanlamasını ve tipini kontrol ederken, [z-order](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getzorderposition/) hangi öğenin diğerini örtüp örtmediğini belirler. Görünür sonuç, ikisinin birleşimiyle tanımlanır. (Bu, genel PowerPoint davranışıdır; Aspose.Slides efekt‑ve‑şekil modeli aynı mantığı izler.)

**Belirli efektler için animasyonları videoya dönüştürürken sınırlamalar var mı?**

Genel olarak, [animasyonlar desteklenir](/slides/tr/php-java/convert-powerpoint-to-video/), ancak nadir durumlarda veya belirli efektlerde farklı render sonuçları ortaya çıkabilir. Kullandığınız efektleri ve kütüphane sürümünü test etmeniz önerilir.