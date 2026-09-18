---
title: JavaScript'te Özel Animasyon Davranışları Oluşturma ve Değiştirme
linktitle: Özel Animasyon
type: docs
weight: 151
url: /tr/nodejs-java/custom-animation/
keywords:
- özel animasyon
- animasyon davranışı
- hareket yolu
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint sunumlarında özel animasyon davranışları ve düzenlenebilir hareket yolları oluşturun, inceleyin ve değiştirin."
---
## **Genel Bakış**

Özel animasyon davranışları, bir renk değiştirme, bir şekli döndürme veya düzenlenebilir bir hareket yolu izleme gibi bir animasyon etkisi içindeki bireysel işlemleri kontrol etmenizi sağlar. Bu kılavuz, davranışların nasıl oluşturulup birleştirileceğini, zamanlamalarının nasıl yapılandırılacağını, mevcut animasyonların nasıl inceleneceğini ve değiştirileceğini ve özelliklerin bir sunumu kaydedip yeniden açtıktan sonra korunup korunmadığını nasıl doğrulayacağınızı gösterir.

Önceden tanımlı efektler ve tıklama tetikleyicileri için, [Şekil Animasyonu](/slides/tr/nodejs-java/shape-animation/) sayfasına bakın.

## **Animasyon Modelini Anlamak**

Bir animasyon **Zaman Çizelgesi → Sıra → Efekt → Davranışlar** şeklinde düzenlenir:

- [getTimeline](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/baseslide/#getTimeline) yöntemi, ana sırasını ve etkileşimli sıraları içeren slayt zaman çizelgesini döndürür.
- [Sequence](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/) etkileri içerir ve potansiyel olarak farklı şekilleri hedefleyebilir.
- [Effect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/) hedef şekli, ön ayarı, alt türü ve efekt zamanlamasını tanımlar.
- [Effect.getBehaviors](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#getBehaviors) tarafından döndürülen koleksiyon, efekti uygulayan işlemleri içerir: renk değiştirme, taşıma, döndürme, bir özelliği ayarlama vb.

## **Bireysel Davranışlar Oluşturma**

Bir efekt oluşturmak ve [getBehaviors](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#getBehaviors) koleksiyonuna erişmek için [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) çağrın. Bir ön ayar bu koleksiyonu otomatik olarak doldurabilir. Ön ayarı genişletirken işlemlerini koruyun veya bilerek değiştirmek istediğinizde [clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorcollection/#clear) kullanın.

[BehaviorFactory](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorfactory/) aşağıda gösterilen sekiz davranış türünü oluşturur. Hareket, [Bir Hareket Yolu Oluşturma](#build-a-motion-path) bölümünde ele alınmıştır. Her snippet, modül içe aktarmalarını içerir ve `aspose.slides.via.java` ve `java` paketleri kurulu olduğunda bir Node.js betiği olarak çalıştırılabilir. Çıktı dosyalarını okuyan örneklerden önce dosya‑oluşturma örneklerini çalıştırın. Daha sonraki düzenleme örnekleri hangi çıktı dosyasını kullandıklarını belirtir.

### **Dönme**

[createRotationEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) kullanarak bir dönme oluşturun. [getBy](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/rotationeffect/#getBy) derece cinsinden relatif bir açı belirler; [getFrom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/rotationeffect/#getFrom) ve [getTo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/rotationeffect/#getTo) ise uç noktaları belirtir.

Örnek bir Spin efektiyle başlar, ön ayar işlemlerini tek bir döndürme davranışıyla değiştirir ve bu işleme iki saniyelik bir süre verir. 90 derece lik bir relatif açı, şeklin başlangıç yönünden çeyrek dönüş anlamına gelir, bu yüzden açık bir başlangıç açısına gerek yoktur.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` bir şekil ve bir döndürme davranışı içerir. Aşağıdaki koleksiyon, zamanlama ve döndürme‑düzenleme örnekleri bu dosyayı kullanır.

### **Ölçekleme**

[createScaleEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) X/Y yüzde değerleriyle kullanın: [getFrom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/scaleeffect/#getFrom) ve [getTo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/scaleeffect/#getTo) başlangıç ve bitiş boyutlarını tanımlar, [getBy](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/scaleeffect/#getBy) ise relatif bir değişikliği açıklar. Burada 100, özgün boyutu ifade eder.

Örnek, iki saniye içinde her iki boyutu da %100'den %125'e yükseltir. Yatay ve dikey yüzde değerlerinin eşit olması şeklin oranlarını korur; farklı yüzde değerleri bir boyutu diğerine göre daha fazla uzatır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Renk**

[createColorEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) kullanarak dolguyu maviden turuncuya değiştirin. [getFrom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/coloreffect/#getFrom) ve [getTo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/coloreffect/#getTo) renklerdir; [getBy](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/coloreffect/#getBy) bir renk kaymasıdır. [Behavior.getProperties](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behavior/#getProperties) animasyonu yapılan özelliği belirler.

Şeklin katı dolgusu, animasyonun başlangıç rengine uygun olarak mavi olarak başlatılır. Doldurma‑renk özelliğini seçmek, davranışa şeklin hangi kısmının değişeceğini söyler; yalnızca renk uç noktaları bu özelliği tanımlamaz. Kaydedilen efekt, iki saniyelik bir turuncuya geçişi tanımlar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtre**

[createFilterEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) kullanarak bir silme (wipe) seçin. [getType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filtereffect/#getSubtype) ve [getReveal](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filtereffect/#getReveal) filtreyi, yönü ve şekli gösterme ya da gizleme durumunu belirler.

Bu örnek, sağ yön alt türünü kullanarak şekli gösteren iki saniyelik bir silme ayarlar. Filtre ayarları, efekt içindeki davranışa aittir, bu yüzden ön ayarın orijinal işlemleri kaldırıldıktan sonra yapılandırılır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Özellik**

[createPropertyEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) kullanarak saydamlığı (opacity) canlandırın. [getFrom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/propertyeffect/#getTo) ve [getBy](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/propertyeffect/#getBy) [getValueType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/propertyeffect/#getValueType) ve [getCalcMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/propertyeffect/#getCalcMode) kullanılarak yorumlanan dizeslerdir. Üçünü de rastgele ayarlamak yerine uç noktaları ya da bir relatif kaymayı seçin.

Burada seçilen özellik saydamlıktır ve sayısal dizeler %25 saydamlıktan tam saydamlığa bir değişikliği temsil eder. Lineer enterpolasyon, bu değerler arasında kademeli bir geçişi tanımlar. Bu örneği başka bir özelliğe uyarlarken, o özellik için uygun bir değer türü ve uç değerler seçin.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ayarla**

[createSetEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) kullanarak [getTo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/seteffect/#getTo) aracılığıyla görünürlüğü atayın. Bir ayar (set) davranışı uç noktalar arasında enterpolasyon yapmaz.

Örnek, görünürlük özelliğini seçer ve davranış çalıştığında `visible` dizesini atar. Bu minimal sunumda dikdörtgen zaten görünür olduğundan, atama tek başına belirgin bir görsel değişiklik yaratmayabilir. Bu tür bir işlem, şeklin ne zaman gizleneceğini veya görünür hale geleceğini kontrol eden daha büyük bir efektin parçası olarak faydalıdır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Komut**

[createCommandEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) kullanın ve [getType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/commandeffect/#getCommandString) ve [getShapeTarget](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/commandeffect/#getShapeTarget) yapılandırın. Çalışma dizinine `sample.wav` adlı bir WAV kaydı koyun. Bu örnek, kaydı [addAudioFrameEmbedded](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) ile gömer ve ses çerçevesine bir oynatma komutu ekler.

Ses çerçevesi, hem efektin hem de komutun hedefidir. Bu, oynatma isteğini gömülü kayda bağlar; yalnızca komut dizesi hangi medya nesnesinin kontrol edileceğini belirtmez. Efekt, slayt gösterisi sırasında bir tıklamayla başlaması için yapılandırılmıştır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

Kaydetme, komutu `command.pptx` içinde saklar; kaydı oynatmaz. Oynatma, komutu ve onun medya hedefini destekleyen bir slayt gösterisi oynatıcı gerektirir.

## **Davranış Koleksiyonunu Yönetme**

[BehaviorCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorcollection/) [add](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorcollection/#remove) ve [removeAt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorcollection/#removeAt) yöntemlerini destekler. Bu örnek `rotation.pptx` dosyasını açar, ölçeklemeyi ekler, döndürmeden önce hareket ettirir ve döndürmeyi kaldırır. Aynı nesneyi kaldırıp yeniden eklemek, bir kopya oluşturmadan depolanan konumunu değiştirir.

Edit sırası koleksiyonu dönüş‑ölçekten ölçek‑dönüşe, ardından yalnızca ölçeğe değiştirir. Dizinler mevcut koleksiyona referans eder, bu yüzden kaldırma, yeniden düzenlemeden sonra dönüşün yeni indeksini kullanır. Son sayım, hangi davranışın kaydedileceğini doğrular.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Çıktı `ScaleEffect`'tir: yalnızca ölçekleme kalır. Koleksiyon sırası, tek başına davranışları birbiri ardına zamanlamaz. Tüm işlemlerini değiştirdiğinizde koleksiyonu temizleyin.

## **Davranış Zamanlamasını Yapılandırma**

[Behavior.getTiming](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behavior/#getTiming), [Effect.getTiming](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#getTiming) bağımsız olarak [Timing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/) nesnesini ortaya çıkarır. Efekt zamanlaması, kapsayan efekti zamanlar; davranış zamanlaması ise içindeki bir işlemi tanımlar.

### **Süre, Gecikme, Tekrarlama ve Hızlanmayı Ayarlama**

`rotation.pptx` dosyasını açın ve süresini ([getDuration](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getDuration)) ve tetikleme gecikmesini ([getTriggerDelayTime](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) saniye cinsinden ayarlayın, ardından tekrarlama sayısını [setRepeatCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#setRepeatCount) ile yapılandırın. [getAccelerate](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getAccelerate) ve [getDecelerate](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getDecelerate), sürenin kesirleridir; toplamlarının en fazla 1 olmasına dikkat edin.

Girdi dosyası, ilk davranışın bir döndürme olduğu bilinen döndürme örneğinde oluşturulan dosyadır. Bu örnek yalnızca o davranışın zamanlamasını değiştirir; 90 derecelik açısı aynı kalır. Açıyı ve zamanlamayı ayrı tutmak, animasyonu yeniden inşa etmeden hızı ayarlamayı kolaylaştırır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Davranış iki saniyelik bir süre, yarım saniyelik bir gecikme ve 3 tekrarlama sayısı kullanır. Süresinin ilk ve son %20'si hızlanma ve yavaşlama için ayrılmıştır.

Diğer tekrarlama politikaları arasında [getRepeatDuration](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) ve [getRepeatUntilNextClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) bulunur; hepsini aynı anda etkinleştirmek yerine bir politikayı seçin. [getAutoReverse](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getAutoReverse), ileri geçişten sonra animasyonu tersine oynatır. Hızlanma ve yavaşlama, kesintisiz değişikliklere, ayrık atamalara veya komutlara uygulanmaz.

## **Bir Hareket Yolu Oluşturma**

[createMotionEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) kullanarak hareket oluşturun. [getFrom](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motioneffect/#getTo) ve [getBy](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motioneffect/#getBy) yüzde‑tabanlı koordinatları veya offsetleri tanımlar. Düzenlenebilir bir rota için bir [MotionPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motionpath/) oluşturun ve [MotionEffect.setPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motioneffect/#setPath) ile atayın. [MotionPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motionpath/) yol komutlarını saklar.

| Komut | Nokta Sayısı | Anlam |
| --- | --- | --- |
| MoveTo | Bir | Başlangıç konumunu ayarlar. |
| LineTo | Bir | Düz bir segment boyunca ucuna hareket eder. |
| CurveTo | Üç | İki kontrol noktası ve bir uç nokta ile tanımlanan kübik bir eğriyi takip eder. |
| CloseLoop | Yok | Başlangıç konumuna geri döner. |
| End | Yok | Yolu sonlandırır. |

[MotionPathPointsType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motionpathpointstype/) köşe veya yumuşak noktalar gibi nokta‑düzenleme özelliklerini tanımlar. Bu, komut tipinin yerini almaz. Aşağıdaki eğri örneği için bir eğri nokta tipi, düz segmentler için ise bir köşe nokta tipi kullanın.

Yol koordinatları slayt boyutlarına göre normalize edilir: 0.25 X kayması, slayt genişliğinin çeyreğini temsil eder, 0.25 puan değildir. Pozitif Y aşağı doğru ilerler. Mutlak komutlar, yol koordinat sistemindeki konumları belirtirken; relatif komutlar mevcut konumdan offsetleri belirler. Bu, yolu referans çerçevesi seçen [getOrigin](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motioneffect/#getOrigin) ve şekil hareket ettirildiğinde yolun nasıl hareket edeceğini kontrol eden [getPathEditMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motioneffect/#getPathEditMode) işlevlerinden ayrı bir durumdur.

### **Düz Bir Yol Oluşturma**

Başlangıç noktası, bir düz segment ve bir bitiş komutu içeren bir hareket davranışı oluşturun. [MotionPath.add](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motionpath/#add) komut tipini, noktalarını, nokta tipini ve relatif‑koordinat bayrağını alır.

Başlangıç komutu (0, 0) konumunu belirler ve çizgi (0.25, 0) noktasında sona erer; bu, rotaya slayt genişliğinin çeyreği kadar yatay bir kayma verir. Bitiş komutunun koordinat noktası yoktur. Yol atandıktan sonra, hareket davranışını efekte eklemek bu rotayı dikdörtgene bağlar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` üç yol komutlu bir hareket davranışı içerir. Aşağıdaki dosya‑düzenleme örnekleri bu bilinen yapıyı kullanır.

### **Mutlak ve Relatif Koordinatları Karşılaştırma**

Bu iki yol nesnesi aynı rotayı tanımlar. Mutlak komut (0.3, 0.1) noktasında sona ererken; relatif komut mevcut konuma (0.1, 0.1) ekleyerek (0.2, 0) noktasına ulaşır.

Her iki yol da aynı konumda başlar. Relatif çizgi için, uç noktayı elde etmek amacıyla X ve Y offsetlerini mevcut konuma ekleyin; mutlak çizgi için ise uç noktayı doğrudan okuyun. Koordinatları dönüştürmeden bayrağı değiştirmek farklı bir rota tanımlamaz.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

Her iki yolu da bir hareket davranışına atayarak sunumda kullanabilirsiniz. Son Boolean argüman, o komut için relatif koordinatları seçer.

### **Bir Çizgiyi Eğriyle Değiştirme**

`motion.pptx` dosyasını açın ve çizgi komutunu bir kübik eğriyle değiştirin. Önce iki kontrol noktasını, ardından uç noktayı sağlayın.

Başlangıç konumu, önceki komut tarafından sağlanır. İlk iki nokta eğriyi şekillendirirken üçüncüsü hedefidir; bunlar üç ardışık hedef değildir. Komut tipini, nokta‑düzenleme tipini ve nokta dizisini birlikte güncellemek, segmenti yeni geometrisiyle tutarlı tutar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx` içindeki yol hâlâ üç komuta sahiptir; orta komut artık bir eğri tanımlar.

## **Kaydedilmiş Bir Yolu İnceleme ve Düzenleme**

Her bir [MotionCmdPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motioncmdpath/) [getPoints](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) ve [isRelative](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motioncmdpath/#isRelative) metodlarını sunar. Aşağıdaki örnekler `motion.pptx` içindeki bilinen üç‑komutlu yolu kullanır. Rastgele bir girdi için, düzenlemeden önce hedef efekti bulun ve komut tiplerini ve nokta sayılarını indeksle kontrol edin.

### **Komutları ve Koordinatları Okuma**

Yolu değiştirmeden okuyun. End ve close‑loop komutları nokta gerektirmez, bu yüzden null bir nokta dizisine izin verin.

Çıktı, her sayısal komut tipini nokta listelenmeden önce relatif‑koordinat bayrağıyla eşleştirir. Bu, yolu değiştirmeden önce bir uç noktayı bir offsetten ayırmanıza olanak tanır. Eğri üç nokta listelerken, bu dosyadaki düz çizgi yalnızca bir nokta listeler.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Listeleme bir başlangıç noktası, (0.25, 0) konumunda sona eren mutlak bir çizgi ve bir end komutu içerir.

### **Uç Noktayı Değiştirme**

`motion.pptx` dosyasını açın ve çizginin nokta dizisini değiştirerek uç noktasını taşıyın.

Girdi dosyasında, indeks 0 başlangıç komutu, indeks 1 ise çizgidir. Çizginin tek noktasını değiştirmek, destinasyonunu komut tipini, zamanlamasını veya koleksiyondaki konumunu değiştirmeden değiştirir. Komut mutlak koordinatlar kullandığı için, yeni çift bir konum belirtir, ek bir offset değil.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` içindeki çizgi (0.4, 0.1) noktasında sona erer; özgün dosya değişmemiştir.

### **Bir Segmenti Değiştirme**

`motion.pptx` içindeki çizgiyi değiştirmek için [insert](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motionpath/#insert) ve [removeAt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/motionpath/#removeAt) kullanın. Ekleme, eski çizgiyi indeks 2'ye kaydırır.

Bu, mevcut koordinatları düzenlemek yerine bir komut nesnesini değiştirmeyi gösterir. Eklemeden sonra koleksiyon, geçici olarak başlangıç komutu, yeni çizgi, eski çizgi ve end komutunu içerir. İndeks 2'yi kaldırmak eski çizgiyi atar ve yeni rotayı yerinde bırakır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kaydedilen yol hâlâ üç komuta sahiptir; yeni çizgi (0.2, 0.1) noktasında sona erer ve end komutu en sonda bulunur.

## **Mevcut Bir Davranışı Değiştirme ve Doğrulama**

Davranışın indeksi bilinmiyorsa, tipine göre seçin. Bu örnek `rotation.pptx` dosyasını açar, [RotationEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/rotationeffect/) bulur, açıyı değiştirir ve yeniden açtıktan sonra kaydedilen değeri kontrol eder.

Tip kontrolü, döndürme olmayan davranışları döngünün atlamasını sağlar. İkinci yükleme, kaydedilen dosyayı ayrı bir sunum nesnesine okur, böylece karşılaştırma bellekte hâlâ tutulan değeri değil, kalıcı veriyi kontrol eder. Bu örnek, bilinen etkinin ana sırada ilk olduğunu varsayar; tipine göre davranış seçmek, rastgele bir sunumda doğru efekti bulmayabilir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Çıktı `Rotation preserved: true` dir. Aynı tip‑kontrol desenini diğer davranışlara da uygulayın. Tam bir koruma kontrolü için hedef şekli, efekti, davranış tiplerini ve sırasını, zamanlamayı ve yol komutlarını karşılaştırın. Ondalıklı sayılar için sayısal bir tolerans kullanın. Bilinmeyen bir animasyon düzenine sahip bir sunum için, ana ve etkileşimli sıraların dolaşımı hakkında [Şekil Animasyonlarını Okuma](/slides/tr/nodejs-java/shape-animation/#read-shape-animations) sayfasına bakın.

## **Davranış Sırası, Ön Ayarlar ve Oynatma**

[BehaviorCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behaviorcollection/) içindeki sıra, bir efektin işlemlerinin depolanmış sırasıdır. Her davranışın kendiliğinden önceki davranışı beklediği bir çalma listesi değildir. Zamanlama ve kapsayan efekt, zamanlamayı belirler. Davranışlar örtüşebilir ve aynı özelliğe yönelik işlemler [getAdditive](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behavior/#getAdditive) ve [getAccumulate](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/behavior/#getAccumulate) aracılığıyla etkileşebilir. “Taşı, ardından döndür” zamanlamasını yalnızca koleksiyon yeniden sıralamasıyla sağlamaya çalışmayın; bunun yerine açık zamanlama veya ayrı efektler kullanın; bunlar [Şekil Animasyonu](/slides/tr/nodejs-java/shape-animation/) içinde açıklanmıştır.

Efektin [getType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#getType) ve [getSubtype](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#getSubtype) ön ayarını tanımlar. Bunlar, düzenlenmiş bir davranış ağacının tam bir açıklaması değildir. Davranışları özelleştirmeden önce ön ayarı ve alt türünü seçin; ön ayarı değiştirmek koleksiyonu yeniden oluşturabilir ve özel işlemlerinizi ortadan kaldırabilir. Örneğin, özelleştirilmiş bir Spin efektini Fade’e değiştirmek, döndürme davranışını set ve filter davranışlarıyla değiştirebilir. Ön ayarı veya alt türü değiştirdikten sonra koleksiyonu yeniden inceleyin. Ön ayar davranışlarını temizlemek, ön ayarın ihtiyaç duyduğu görünürlük veya başlatma işlemlerini de kaldırabilir. Örnekler bilerek görünür şekiller kullanır ve davranışları değiştirir; her ön ayarın uygulamasını yeniden inşa etmezler.

## **Biçim Uyumluluğu**

Korumalı bir davranış ağacı, her görüntüleyici veya dışa aktarma motorunda aynı oynatımı garantilemez. Kaydedilen veriyi ve oluşturulan çıktıyı ayrı ayrı kontrol edin.

| Biçim veya çıktı | Kontrol Edilecek |
| --- | --- |
| PPTX | Bu örnekler için birincil format olarak kullanın. Düzenlenebilir davranış ağacını doğrulamak için dosyayı yeniden açın, ardından hedef PowerPoint sürümünde oynatımı kontrol edin. |
| PPT | Eski ikili temsili PPTX'ten farklı olabilir. Ayrı bir kaydet‑ve‑yeniden‑aç döngüsü ve oynatma test edin; başarılı PPTX çıktısından her özel kombinasyonun desteklendiğini varsaymayın. |
| PDF, PNG, JPEG ve diğer statik slayt görüntüleri | Oynatılabilir bir davranış zaman çizelgesi veya garantili bir son animasyon çerçevesi içermez, sadece statik bir slayt temsili sunar. |
| [HTML5](/slides/tr/nodejs-java/export-to-html5/) | Dışa aktarım seçeneklerinde şekil animasyonu etkinleştirildiğinde desteklenen animasyonları oynatabilir. Tarayıcıda özel kombinasyonları test edin. |
| [Animated GIF](/slides/tr/nodejs-java/convert-powerpoint-to-animated-gif/) | Render edilmiş kareleri depolar, düzenlenebilir davranışları veya tıklama‑tetiklenmiş etkileşimi içermez. Gerçek render edilmiş hareketi kontrol edin. |
| [Video](/slides/tr/nodejs-java/convert-powerpoint-to-video/) | Animasyon karelerini render eder ve video olarak kodlar. Destek, renderlayıcının [desteklenen animasyon ve efektleri](/slides/tr/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) ile sınırlıdır; komutlar ve etkileşimli olaylar düzenlenebilir bir zaman çizelgesine dönüşmez. |

## **SSS**

**Neden etkimin içinde, herhangi bir şey eklemeden önce davranışlar var?**

Önceden tanımlı bir efekt oluşturmak, altında yatan işlemleri de oluşturabilir. Ön ayarı genişletmeyi mi yoksa davranışlarını değiştirmeyi mi karar vermeden önce bunları inceleyin.

**Bir davranışı başa taşımak, önce oynatılmasını sağlar mı?**

Zorunlu değildir. Koleksiyon sırası zamanlamanın yerini tutmaz. Gecikmeleri, süreleri ve aynı özellik üzerindeki işlemlerin etkileşimlerini kontrol edin.

**Neden bir end komutunun noktası yok?**

Yolun sonunu işaret eder ve koordinata ihtiyaç duymaz. Bir dosyadan okunan yolu incelerken null bir nokta dizisi olup olmadığını kontrol edin.

**Başarılı bir çift yönlü (round‑trip) oynatımı doğrulamak için yeterli mi?**

Hayır. Yeniden açmak, kontrol ettiğiniz özelliklerin korunmasını doğrular. Görsel davranışı onaylamak için slayt gösterisi oynatıcıyı veya animasyonlu dışa aktarmayı ayrı ayrı test edin.