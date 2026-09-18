---
title: PHP'de Özel Animasyon Davranışlarını Oluşturma ve Değiştirme
linktitle: Özel Animasyon
type: docs
weight: 151
url: /tr/php-java/custom-animation/
keywords:
- özel animasyon
- animasyon davranışı
- hareket yolu
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarında özel animasyon davranışlarını ve düzenlenebilir hareket yollarını oluşturun, inceleyin ve değiştirin."
---
## **Genel Bakış**

Özel animasyon davranışları, bir renk değişikliği, bir şeklin döndürülmesi veya düzenlenebilir bir hareket yolu izlenmesi gibi bir animasyon etkisinin bireysel işlemlerini kontrol etmenizi sağlar. Bu kılavuz, davranışları oluşturma ve birleştirme, zamanlamalarını yapılandırma, mevcut animasyonları inceleme ve değiştirme ve özelliklerinin bir sunum kaydedilip tekrar açıldıktan sonra korunup korunmadığını doğrulama konularını gösterir.

Önceden tanımlanmış etkiler ve tıklama tetikleyicileri için, **[Şekil Animasyonu](/slides/tr/php-java/shape-animation/)** bölümüne bakın.

## **Animasyon Modelini Anlama**

Bir animasyon, **Zaman Çizelgesi → Dizi → Etki → Davranışlar** şeklinde düzenlenir:

- Her slayt, ana dizisini ve etkileşimli dizilerini içeren bir zaman çizelgesine sahiptir.
- Bir [Sequence](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sequence/) birden çok şekle yönelik etkiler içerir.
- Bir [Effect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/) hedef şekli, ön ayarı, alt tipini ve etki zamanlamasını tanımlar.
- [Effect::getBehaviors](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/getbehaviors/) tarafından döndürülen koleksiyon, rengi değiştirme, hareket ettirme, döndürme, bir özelliği ayarlama vb. gibi etkiyi uygulayan işlemleri içerir.

## **Bireysel Davranışlar Oluşturma**

Bir etki oluşturmak ve [getBehaviors](https://reference.aspose.com/slides/tr/php-java/aspose.slides/effect/getbehaviors/) koleksiyonuna erişmek için [Sequence::addEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/sequence/addeffect/) yöntemini çağırın. Bir ön ayar bu koleksiyonu otomatik olarak doldurabilir. Ön ayarı genişletirken işlemlerini koruyun veya kasıtlı olarak değiştirmek istediğinizde [clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behaviorcollection/clear/) kullanın.

[BehaviorFactory](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behaviorfactory/) aşağıda gösterilen sekiz davranış türünü oluşturur. Hareket, **[Bir Hareket Yolu Oluştur](#build-a-motion-path)** bölümünde ele alınır. Her alıntı, gerekli importları içerir ve PHP/Java Bridge ile Aspose.Slides PHP kitaplığının yüklendiğini varsayar. Sonraki düzenleme örnekleri hangi çıktı dosyasını kullandıklarını belirtir.

### **Dönme**

Bir dönüş oluşturmak için [createRotationEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behaviorfactory/createrotationeffect/) yöntemini kullanın. [getBy](https://reference.aspose.com/slides/tr/php-java/aspose.slides/rotationeffect/getby/) derece cinsinden göreli bir açı belirler; [getFrom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/rotationeffect/getfrom/) ve [getTo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/rotationeffect/getto/) uç noktaları tanımlar.

Örnek, bir Spin etkisiyle başlar, ön ayar işlemlerini tek bir dönüş davranışıyla değiştirir ve bu işleme iki saniyelik bir süre verir. 90 derecelik bir göreli açı, şeklin başlangıç yönünden bir çeyrek dönüş anlamına gelir; bu yüzden açık bir başlangıç açısına gerek yoktur.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` bir şekil ve bir dönüş davranışı içerir. Aşağıdaki koleksiyon, zamanlama ve dönüş‑düzenleme örnekleri bu dosyayı kullanır.

### **Ölçeklendirme**

X/Y yüzde değerleriyle [createScaleEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behaviorfactory/createscaleeffect/) kullanın: [getFrom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/scaleeffect/getfrom/) ve [getTo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/scaleeffect/getto/) başlangıç ve bitiş boyutlarını tanımlarken, [getBy](https://reference.aspose.com/slides/tr/php-java/aspose.slides/scaleeffect/getby/) göreli bir değişikliği belirtir. Burada 100, orijinal boyutu ifade eder.

Örnek, iki saniye içinde her iki ekseni de %100’den %125’e kadar büyütür. Yatay ve dikey yüzde değerleri eşit olduğunda şeklin oranı korunur; farklı yüzde değerleri bir ekseni diğerinden daha fazla uzatır.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Renk**

Dolgu rengini mavi’den turuncuya değiştirmek için [createColorEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behaviorfactory/createcoloreffect/) kullanın. [getFrom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/coloreffect/getfrom/) ve [getTo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/coloreffect/getto/) renklerdir; [getBy](https://reference.aspose.com/slides/tr/php-java/aspose.slides/coloreffect/getby/) bir renk ofsetidir. Davranışın [BehaviorPropertyCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behaviorpropertycollection/) animasyonu yapılan özelliği tanımlar.

Şeklin katı dolgusu başlangıçta mavi olarak ayarlanır; bu, animasyonun başlangıç rengine eşdeğerdir. Dolgu‑renk özelliğini seçmek, davranışa şeklin hangi kısmının değişeceğini söyler; yalnızca renk uç noktaları bu özelliği tanımlamaz. Kaydedilen etki, turuncuya iki saniyelik bir geçişi tanımlar.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Filtre**

Bir silme (wipe) seçmek için [createFilterEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behaviorfactory/createfiltereffect/) kullanın. [getType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filtereffect/getsubtype/) ve [getReveal](https://reference.aspose.com/slides/tr/php-java/aspose.slides/filtereffect/getreveal/) sırasıyla filtreyi, yönü ve şeklin gösterilip gizleneceğini belirler.

Bu örnek, sağ‑yön alt tipini kullanarak şekli gösteren iki saniyelik bir silme etkisi ayarlar. Filtre ayarları, etki içindeki davranışa aittir; bu nedenle ön ayarın orijinal işlemleri kaldırıldıktan sonra yapılandırılır.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Özellik**

Şeffaflığı (opacity) animasyonlamak için [createPropertyEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) kullanın. [getFrom](https://reference.aspose.com/slides/tr/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/propertyeffect/getto/) ve [getBy](https://reference.aspose.com/slides/tr/php-java/aspose.slides/propertyeffect/getby/) dizgileri, [getValueType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/propertyeffect/getvaluetype/) ve [getCalcMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/propertyeffect/getcalcmode/) ile yorumlanır. Üçünü de rastgele ayarlamaktan kaçının; uç noktaları ya da göreli bir ofseti seçin.

Burada seçilen özellik şeffaflıktır ve sayısal dizgiler %25 şeffaflıktan tam şeffaflığa bir değişikliği gösterir. Doğrusal ara değerleme (linear interpolation), bu değerler arasında kademeli bir değişim tanımlar. Başka bir özellik için bu örneği uyarlarken, uygun bir değer türü ve uç değerler seçin.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ayarla (Set)**

Görünürlüğü atamak için [createSetEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behaviorfactory/createseteffect/) ve [getTo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/seteffect/getto/) kullanın. Bir set davranışı uç noktalar arasında ara değerleme yapmaz.

Örnek, görünürlük özelliğini seçer ve davranış çalıştığında `visible` dizgisini atar. Bu minimal sunumda dikdörtgen zaten görünür olduğundan atama tek başına belirgin bir görsel değişim oluşturmayabilir. Bu tür bir işlem, şeklin ne zaman gizleneceği veya gösterileceği kontrol eden daha büyük bir etkinin parçası olarak yararlıdır.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Komut**

[createCommandEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behaviorfactory/createcommandeffect/) kullanın ve [getType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commandeffect/getcommandstring/) ve [getShapeTarget](https://reference.aspose.com/slides/tr/php-java/aspose.slides/commandeffect/getshapetarget/) ayarlarını yapın. Çalışma dizinine `sample.wav` adlı bir WAV kaydı koyun. Bu örnek, [addAudioFrameEmbedded](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addaudioframeembedded/) ile kaydı ekler ve ses çerçevesine bir oynatma komutu ekler.

Ses çerçevesi hem etkinin hem de komutun hedefidir. Bu, oynatma isteğini gömülü kayda bağlar; yalnız bir komut dizgisi, hangi medya nesnesinin kontrol edileceğini belirtmez. Etki, slayt gösterisi sırasında bir tıklamayla başlaması için ayarlanmıştır.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Kaydetme, komutu `command.pptx` dosyasına yazar; kaydı otomatik olarak çalmaz. Oynatma, komutu ve medya hedefini destekleyen bir slayt gösterisi oynatıcı gerektirir.

## **Davranış Koleksiyonunu Yönetme**

[BehaviorCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behaviorcollection/) **add**, **insert**, **remove** ve **removeAt** yöntemlerini destekler. Bu örnek `rotation.pptx` dosyasını açar, ölçeklendirme ekler, döndürmeden önce konumlandırır ve döndürmeyi kaldırır. Aynı nesneyi kaldırıp yeniden eklemek, kopya oluşturmadan depolanan konumu değiştirir.

Düzenleme sırası koleksiyonu **döndürme‑ölçekleme** → **ölçekleme‑döndürme** → **yalnız ölçekleme** şeklinde değiştirir. İndeksler mevcut koleksiyona göre değerlendirilir; kaldırma işlemi yeniden sıralamadan sonra döndürmenin yeni indeksini kullanır. Son sayım, hangi davranışın kaydedileceğini gösterir.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Çıktı `ScaleEffect` olur: yalnız ölçeklendirme kalır. Koleksiyon sırası tek başına davranışları ard arda zamanlamaz. Tüm işlemleri değiştirmek istediğinizde koleksiyonu **clear** edin.

## **Davranış Zamanlamasını Yapılandırma**

Bir davranışın **Timing** nesnesi, **Effect::getTiming** tarafından döndürülen zamanlamadan bağımsızdır. Etki zamanlaması, kapsayıcı etkiyi planlarken; davranış zamanlaması, içindeki bir işlemi tanımlar.

### **Süre, Gecikme, Tekrar ve Hızlanma Ayarlama**

`rotation.pptx` dosyasını açın ve **getDuration** ile saniye cinsinden süreyi, **getTriggerDelayTime** ile tetikleme gecikmesini ayarlayın. Tekrar sayısını **setRepeatCount** ile belirleyin. **getAccelerate** ve **getDecelerate** değerleri sürenin kesirleridir; toplamları en fazla 1 olmalıdır.

Girdi dosyası, dönme davranışı içeren örnek rotasyon dosyasıdır. Bu örnek sadece o davranışın zamanlamasını değiştirir; 90 derece açı aynı kalır. Açıyı ve zamanlamayı ayrı tutmak, animasyonu yeniden oluşturmadan hızı ayarlamayı kolaylaştırır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Davranış iki saniyelik bir süre, yarım saniyelik bir gecikme ve 3 tekrar sayısı kullanır. Sürenin ilk ve son %20’si hızlanma ve yavaşlama için ayrılmıştır.

Diğer tekrar politikaları **getRepeatDuration**, **getRepeatUntilEndSlide**, **getRepeatUntilNextClick** gibi yöntemlerle seçilir; hepsini aynı anda etkinleştirmek yerine birini tercih edin. **getAutoReverse** ileri geçişten sonra animasyonu tersine oynatır. Hızlanma ve yavaşlama yalnız sürekli değişimlerde geçerlidir; kesikli atamalar ya da komutlar etkilenmez.

## **Bir Hareket Yolu Oluşturma**

[createMotionEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behaviorfactory/createmotioneffect/) ile hareket oluşturun. **getFrom**, **getTo** ve **getBy** yüzde tabanlı koordinatları veya ofsetleri tanımlar. Düzenlenebilir bir rota için bir [MotionPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/motionpath/) oluşturun ve **MotionEffect::setPath** ile atayın. **MotionPath** yol komutlarını depolar.

[MotionCommandPathType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/motioncommandpathtype/) işlemi seçer:

| Komut | Nokta Sayısı | Anlam |
| --- | --- | --- |
| MoveTo | One | Başlangıç konumunu ayarlar. |
| LineTo | One | Düz bir segment boyunca uç noktasına hareket eder. |
| CurveTo | Three | İki kontrol noktası ve bir uç nokta ile tanımlanan kübik eğriyi izler. |
| CloseLoop | None | Başlangıç konumuna döner. |
| End | None | Yolu sonlandırır. |

[MotionPathPointsType](https://reference.aspose.com/slides/tr/php-java/aspose.slides/motionpathpointstype/) köşe ya da yumuşak noktalar gibi nokta‑düzenleme özelliklerini tanımlar; komut tipini değiştirmez. Eğri örneği için eğri nokta tipini, düz segmentler için köşe nokta tipini kullanın.

Yol koordinatları slayt boyutlarına göre normalize edilmiştir: X = 0.25, slayt genişliğinin çeyreğini temsil eder, 0.25 puan değildir. Pozitif Y aşağı doğru gider. Mutlak komutlar yol koordinat sisteminde pozisyon belirler; göreli komutlar geçerli konumdan ofset ekler. Bu, **getOrigin** (yolun referans çerçevesi) ve **getPathEditMode** (şekil taşındığında yolun nasıl hareket edeceği) ayarlarından ayrı bir kavramdır.

### **Düz Bir Yol Oluşturma**

Başlangıç noktası, bir düz segment ve bir bitiş komutu içeren bir hareket davranışı yaratın. **MotionPath::add** komut tipini, noktaları, nokta tipini ve göreli‑koordinat bayrağını alır.

Başlangıç komutu (0, 0) oluşturur; çizgi (0.25, 0)’da sona erer, bu da slayt genişliğinin çeyreği kadar yatay bir kayma demektir. Bitiş komutunun koordinat noktası yoktur. Yol atandıktan sonra, hareket davranışı efekti rectangle’a bağlar.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` üç yol komutu içeren bir hareket davranışı barındırır. Aşağıdaki dosya‑düzenleme örnekleri bu yapıyı temel alır.

### **Mutlak ve Göreli Koordinatları Karşılaştırma**

Bu iki yol nesnesi aynı rotayı tanımlar. Mutlak komut (0.3, 0.1)’de biter; göreli komut (0.1, 0.1) ofsetini mevcut konuma ekler, böylece (0.2, 0) elde edilir.

Her iki yol da aynı konumda başlar. Göreli çizgi için, X ve Y ofsetlerini mevcut konuma ekleyerek uç noktayı bulursunuz; mutlak çizgi için doğrudan uç noktayı okursunuz. Bayrağı dönüştürmeden koordinatları değiştirmek farklı bir rota tanımlar.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

Bu yolları bir hareket davranışına atayarak sunumda kullanabilirsiniz. Son Boolean argüman, o komut için göreli koordinatları seçer.

### **Bir Çizgiyi Eğriyle Değiştirme**

`motion.pptx` dosyasını açın ve çizgi komutunu bir kübik eğriyle değiştirin. İki kontrol noktasını, ardından uç noktayı verin.

Başlangıç konumu, önceki komut tarafından sağlanır. İlk iki nokta eğriyi şekillendirirken, üçüncü nokta hedefi belirler; üçü de ardışık hedefler değildir. Komut tipini, nokta‑düzenleme tipini ve nokta dizisini birlikte güncellemek, segmentin yeni geometrisiyle tutarlı kalmasını sağlar.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`curve.pptx` hâlâ üç komuta sahiptir; orta komut artık bir eğriyi tanımlar.

## **Kaydedilmiş Bir Yolu İnceleme ve Düzenleme**

Her [MotionCmdPath](https://reference.aspose.com/slides/tr/php-java/aspose.slides/motioncmdpath/) **getPoints**, **getCommandType**, **getPointsType** ve **isRelative** metodlarını sunar. Aşağıdaki örnekler, `motion.pptx` içindeki üç‑komutluk yolu kullanır. Rastgele bir girdi dosyasıyla çalışırken, önce ilgili efekti bulun, komut tiplerini ve nokta sayılarını indekslemeden önce kontrol edin.

### **Komutları ve Koordinatları Okuma**

Yolu değiştirmeden okuyun. Bitiş ve kapama‑döngü komutlarının noktası olmadığından, null bir nokta dizisine izin verin.

Çıktı, her sayısal komut tipini göreli‑koordinat bayrağıyla eşleştirir, ardından noktalarını listeler. Bu, yolu değiştirmeden önce bir ofset ile bir uç noktayı ayırt etmenizi sağlar. Eğri üç nokta listeler; bu dosyadaki düz çizgi sadece bir nokta listeler.

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Liste, bir başlangıç noktası, (0.25, 0)’da biten mutlak bir çizgi ve bir bitiş komutu içerir.

### **Bir Uç Noktayı Değiştirme**

`motion.pptx` dosyasını açın ve çizginin nokta dizisini değiştirerek uç noktasını taşıyın.

Girdi dosyasında, indeks 0 başlangıç komutu, indeks 1 çizgidir. Çizginin tek noktasını değiştirmek, komut tipini, zamanlamasını veya koleksiyondaki konumunu etkilemeden hedef konumu değiştirir. Komut mutlak koordinat kullandığı için yeni çift bir konum tanımlar; ofset eklemez.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion-endpoint.pptx` dosyasındaki çizgi (0.4, 0.1)’de biter; orijinal dosya değişmemiştir.

### **Bir Segmenti Değiştirme**

[insert](https://reference.aspose.com/slides/tr/php-java/aspose.slides/motionpath/insert/) ve [removeAt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/motionpath/removeat/) kullanarak `motion.pptx` içindeki çizgiyi değiştirin. Ekleme, eski çizgiyi indeks 2’ye kaydırır.

Bu, mevcut koordinatları düzenlemek yerine bir komut nesnesini değiştirmenin örneğidir. Eklemeden sonra koleksiyon geçici olarak: başlangıç komutu, yeni çizgi, eski çizgi ve bitiş komutu içerir. İndeks 2’yi kaldırmak eski çizgiyi siler ve yeni rotayı bırakır.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kaydedilen yol hâlâ üç komuta sahiptir; yeni çizgi (0.2, 0.1)’de biter ve bitiş komutu son konumdadır.

## **Mevcut Bir Davranışı Değiştirme ve Doğrulama**

Davranış indeksi bilinmiyorsa, türüne göre seçin. Bu örnek `rotation.pptx` dosyasını açar, [RotationEffect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/rotationeffect/) bulur, açıyı değiştirir ve yeniden açtıktan sonra kaydedilen değeri kontrol eder.

Tür kontrolü, döndürme olmayan davranışların döngüde atlanmasını sağlar. İkinci yükleme, kaydedilen dosyayı ayrı bir sunum nesnesine okur; böylece karşılaştırma, hafızada tutulan değer yerine kalıcı veriyi test eder. Bu örnek, bilinen etkinin ana dizide ilk olduğunu varsayar; tür‑bazlı seçim, rastgele bir sunumda doğru etkiyi bulmayabilir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Çıktı `Rotation preserved: true` olur. Aynı tür‑kontrol desenini diğer davranışlar için de uygulayın. Tam bir korunma kontrolü için hedef şekil, etki, davranış türleri ve sırası, zamanlama ve yol komutları karşılaştırılmalıdır. Nokta‑sayısı değerleri için kayan‑nokta toleransı kullanın. Animasyon düzeni bilinmeyen bir sunum için, **[Şekil Animasyonlarını Oku](/slides/tr/php-java/shape-animation/#read-shape-animations)** bölümüne bakın.

## **Davranış Sırası, Ön Ayarlar ve Oynatma**

[BehaviorCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behaviorcollection/) içindeki sıra, bir etkinin işlemlerinin depolanma sırasıdır. Bu, her davranışın otomatik olarak öncekini beklediği bir çalma listesi değildir; zamanlama ve kapsayıcı etki planlamayı belirler. Davranışlar çakışabilir ve aynı özelliğe yönelik işlemler, **[additive](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behavioradditivetype/)** ve **[accumulation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/behavioraccumulatetype/)** ayarlarıyla etkileşime girebilir. “Taşı, sonra döndür” gibi bir sıralamayı yalnız koleksiyon yeniden düzenlemesiyle yapmayın; açık zamanlama veya ayrı etkiler kullanın (bkz. **[Şekil Animasyonu](/slides/tr/php-java/shape-animation/)**).

Etkinin **getType** ve **getSubtype** ön ayarını tanımlar; bu, düzenlenmiş bir davranış ağacının tam tanımı değildir. Davranışları özelleştirmeden önce ön ayar ve alt tipi seçin: ön ayarı değiştirmek koleksiyonu yeniden oluşturur ve özel işlemlerinizi silebilir. Örneğin, özelleştirilmiş bir Spin etkisini Fade’a değiştirmek, döndürme davranışını set ve filter davranışlarıyla değiştirebilir. Bir ön ayar veya alt tipi değiştirdikten sonra koleksiyonu yeniden inceleyin. Ön ayar davranışlarını temizlemek, ön ayarın ihtiyaç duyduğu görünürlük ya da başlatma işlemlerini de kaldırabilir. Örneklerde görünür şekiller kullanılmakta ve davranışlar değiştirilmekte; her ön ayarın iç uygulaması yeniden inşa edilmemiştir.

## **Biçim Uyumluluğu**

Korunmuş bir davranış ağacı, her görüntüleyici ya da dışa aktarma render’ında aynı oynatımı garanti etmez. Kaydedilen verileri ve render edilen çıktıyı ayrı ayrı kontrol edin.

| Biçim veya çıktı | Kontrol Edilecekler |
| --- | --- |
| PPTX | Bu örneklerde birincil biçim olarak kullanın. Açıp düzenlenebilir davranış ağacını doğruladıktan sonra hedef PowerPoint sürümünde oynatımı test edin. |
| PPT | Eski ikili temsil PPTX’ten farklı olabilir. Ayrı bir kaydet‑aç‑oynat döngüsü yapın; PPTX başarısını tüm özel kombinasyonların desteklenmesi olarak yorumlamayın. |
| PDF, PNG, JPEG ve diğer statik slayt görüntüleri | Statik slayt temsili içerir; oynatılabilir bir davranış zaman çizelgesi ya da kesin bir animasyon karesi sağlamaz. |
| [HTML5](/slides/tr/php-java/export-to-html5/) | Dışa aktarma seçeneklerinde şekil animasyonu etkinleştirildiğinde desteklenen animasyonları oynatabilir. Tarayıcıda özel kombinasyonları test edin. |
| [Animasyonlu GIF](/slides/tr/php-java/convert-powerpoint-to-animated-gif/) | İşlenmiş kareleri saklar; düzenlenebilir davranışlar ya da tıklama‑tetiklenen etkileşimler içermez. Gerçekleşen hareketi kontrol edin. |
| [Video](/slides/tr/php-java/convert-powerpoint-to-video/) | Animasyon karelerini render eder ve video olarak kodlar. Destek, render’ın **[desteklenen animasyon ve efektleri](/slides/tr/php-java/convert-powerpoint-to-video/#supported-animations-and-effects)** ile sınırlıdır; komutlar ve etkileşimli olaylar düzenlenebilir bir zaman çizelgesine dönüşmez. |

## **SSS**

**Neden bir etki eklemeden önce davranışlar içeriyor?**

Önceden tanımlı bir etki, altında yatan işlemleri oluşturabilir. Ön ayarı genişletmek mi yoksa davranışları değiştirmek mi istediğinize karar vermeden önce bunları inceleyin.

**Bir davranışı başa taşıdığımda önce mi oynatılır?**

Zorunlu değildir. Koleksiyon sırası zamanlama yerine geçmez. Gecikmeleri, süreleri ve aynı özelliğe yönelik işlemlerin etkileşimini kontrol edin.

**Neden bir bitiş komutunun noktası yok?**

Yolun sonunu işaret eder ve koordinat gerekmez. Dosyadan okunan bir yolu incelerken nokta dizisinin null olup olmadığını kontrol edin.

**Başarılı bir yuvarlak dönüş (round‑trip) oynatımı onaylamak için yeterli mi?**

Hayır. Yeniden açma, kontrol ettiğiniz özelliklerin korunmasını kanıtlar. Görsel davranışı doğrulamak için slayt gösterisi oynatıcı ya da animasyonlu dışa aktarımı ayrı ayrı test edin.