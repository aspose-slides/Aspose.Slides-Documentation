---
title: Android'de Özel Animasyon Davranışlarını Oluşturma ve Değiştirme
linktitle: Özel Animasyon
type: docs
weight: 151
url: /tr/androidjava/custom-animation/
keywords:
- özel animasyon
- animasyon davranışı
- hareket yolu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Android için Java aracılığıyla Aspose.Slides ile PowerPoint sunumlarında özel animasyon davranışlarını ve düzenlenebilir hareket yollarını oluşturun, inceleyin ve değiştirin."
---
## **Genel Bakış**

Özel animasyon davranışları, bir renk değişikliği, bir şeklin döndürülmesi veya düzenlenebilir bir hareket yolu izlenmesi gibi bir animasyon etkisi içinde bireysel operasyonları kontrol etmenizi sağlar. Bu kılavuz, davranışların nasıl oluşturulup birleştirileceğini, zamanlamalarının nasıl yapılandırılacağını, mevcut animasyonların nasıl inceleneceğini ve değiştirileceğini ve bu özelliklerin bir sunumu kaydedip yeniden açtığınızda korunup korunmadığını gösterir.

Önceden tanımlanmış efektler ve tıklama tetikleyicileri için [Şekil Animasyonu](/slides/tr/androidjava/shape-animation/) bölümüne bakın.

## **Animasyon Modelini Anlayın**

Bir animasyon **Zaman Çizelgesi → Dizi → Etki → Davranışlar** şeklinde düzenlenir:

- [getTimeline](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) yöntemi, ana dizisini ve etkileşimli dizilerini içeren slayt zaman çizelgesini döndürür.
- Bir [ISequence](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isequence/) farklı şekilleri hedefleyebilen efektleri içerir.
- Bir [IEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/) hedef şekli, ön ayarı, alt tipini ve etki zamanlamasını tanımlar.
- [IEffect.getBehaviors](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#getBehaviors--) tarafından döndürülen koleksiyon, rengi değiştirme, hareket ettirme, döndürme, bir özelliği ayarlama gibi etkiyi uygulayan operasyonları içerir.

## **Bireysel Davranışlar Oluşturun**

Bir etki oluşturmak ve [getBehaviors](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#getBehaviors--) koleksiyonuna erişmek için [ISequence.addEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) yöntemini çağırın. Bir ön ayar bu koleksiyonu otomatik olarak doldurabilir. Ön ayarı genişletirken işlemlerini koruyun veya kasıtlı olarak değiştirmek istediğinizde [clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) yöntemini kullanın.

[IBehaviorFactory](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorfactory/) aşağıda gösterilen sekiz davranış türünü oluşturur. Hareket, [Hareket Yolu Oluşturma](#build-a-motion-path) bölümünde ele alınır. Her kod parçacığı gerekli içe aktarmaları içerir; yürütülebilir ifadeleri bir metoda yerleştirin. Sonraki düzenleme örneklerinde kullanılan çıktı dosyası belirtilir. Android’de örnek dosya adlarını uygulamanın erişebileceği bir dizine, örneğin uygulamanızın dosyalar dizinine tam yol olarak değiştirin.

### **Döndürme**

Bir döndürme oluşturmak için [createRotationEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) yöntemini kullanın. [getBy](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/irotationeffect/#getBy--) göreceli açıyi derece cinsinden belirtir; [getFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/irotationeffect/#getFrom--) ve [getTo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/irotationeffect/#getTo--) uç noktaları tanımlar.

Örnek, bir Spin etkisiyle başlar, ön ayar işlemlerini tek bir döndürme davranışıyla değiştirir ve bu işleme iki saniyelik bir süre verir. 90 derecelik bir göreceli açı, şeklin başlangıç yönünden çeyrek dönüş anlamına gelir; bu nedenle açık bir başlangıç açısına ihtiyaç yoktur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` bir şekil ve bir döndürme davranışı içerir. Aşağıdaki koleksiyon, zamanlama ve döndürme‑düzenleme örnekleri bu dosyayı kullanır.

### **Ölçeklendirme**

[X/Y yüzdeleriyle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) bir ölçek efekti oluşturmak için [createScaleEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) yöntemini kullanın: [getFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) ve [getTo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iscaleeffect/#getTo--) başlangıç ve bitiş boyutunu, [getBy](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iscaleeffect/#getBy--) ise göreceli değişikliği tanımlar. Burada 100, özgün boyutu ifade eder.

Örnek, iki saniye içinde her iki boyutu %100’den %125’e artırır. Yatay ve dikey yüzde değerlerinin eşit olması şeklin oranını korur; farklı yüzde değerleri bir boyutu diğerine göre daha fazla uzatır.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Renk**

Dolgu rengini mavi’den turuncuya değiştirmek için [createColorEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) yöntemini kullanın. [getFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icoloreffect/#getFrom--) ve [getTo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icoloreffect/#getTo--) renklerdir; [getBy](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icoloreffect/#getBy--) renk ofsetidir. [IBehavior.getProperties](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehavior/#getProperties--) hangi niteliğin animasyonlandığını belirler.

Şeklin katı dolgusu başlangıçta mavidir ve animasyonun başlangıç rengiyle eşleşir. Dolgu‑renk niteliğini seçmek, davranışa şeklin hangi kısmının değişeceğini söyler; sadece renk uç noktaları bu niteliği tanımlamaz. Kaydedilen etki, iki saniyelik bir turuncuya geçişi açıklar.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtre**

Bir silme (wipe) filtresi seçmek için [createFilterEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) yöntemini kullanın. [getType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--), ve [getReveal](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) filtreyi, yönü ve şeklin ortaya çıkarılıp gizleneceğini belirtir.

Bu örnek, sağ yön alt‑tipiyle şekli ortaya çıkaran iki saniyelik bir silme efekti yapılandırır. Filtre ayarları, etki içindeki davranışa aittir; bu nedenle ön ayarın orijinal işlemleri kaldırıldıktan sonra yapılandırılır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Özellik**

Saydamlığı (opacity) animasyonlamak için [createPropertyEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) yöntemini kullanın. [getFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipropertyeffect/#getTo--), ve [getBy](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) dizgileri, [getValueType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) ve [getCalcMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--) aracılığıyla yorumlanır. Üçünü de rastgele ayarlamak yerine uç noktaları ya da göreceli bir ofseti seçin.

Burada seçilen nitelik saydamlıktır ve sayısal dizgiler %25 saydamlıktan %100 saydamlığa bir değişikliği temsil eder. Doğrusal ara değerleme, bu iki değer arasındaki yumuşak geçişi tanımlar. Bu örneği başka bir niteliğe uyarlarken, o nitelik için uygun bir değer türü ve uç değerler seçin.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Atama (Set)**

[Görünürlük](`visible`) atamak için [createSetEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) yöntemini kullanın ve [getTo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iseteffect/#getTo--) ile değeri belirleyin. Bir set davranışı uç noktalar arasında ara değerleme yapmaz.

Örnek, görünürlük niteliğini seçer ve davranış çalıştığında `visible` dizgisini atar. Bu minimal sunumda dikdörtgen zaten görünür olduğundan, atama tek başına belirgin bir görsel değişiklik yaratmayabilir. Böyle bir işlem, şeklin ne zaman gizleneceği ya da görüneceği kontrol eden daha büyük bir etkinin parçası olarak faydalıdır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Komut**

[createCommandEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) yöntemini kullanın ve [getType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icommandeffect/#getCommandString--), ve [getShapeTarget](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--) özelliklerini yapılandırın. Çalışma dizinine `sample.wav` adlı bir WAV kaydı koyun. Bu örnek, [addAudioFrameEmbedded](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) ile dosyaya gömülür ve ses çerçevesine bir oynatma komutu ekler.

Ses çerçevesi hem etkinin hedefi hem de komutun hedefi olur. Bu, oynatma isteğini gömülü kayda bağlar; yalnız bir komut dizgisi hangi ortam nesnesinin kontrol edileceğini belirtmez. Etki, slayt gösterisi sırasında bir tıklama ile başlaması için yapılandırılır.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

Kaydetme, komutu `command.pptx` içinde saklar; kaydı oynatmaz. Oynatma, komutu ve medya hedefini destekleyen bir slayt gösterisi oynatıcısı gerektirir.

## **Davranış Koleksiyonunu Yönetme**

[IBehaviorCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorcollection/) [add](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), ve [removeAt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-) yöntemlerini destekler. Bu örnek `rotation.pptx` dosyasını açar, ölçeklendirme ekler, döndürmeden önce yerleştirir ve döndürmeyi kaldırır. Aynı nesneyi kaldırıp yeniden eklemek, bir kopya oluşturmadan depolanmış konumunu değiştirir.

Düzenleme sırası koleksiyonu döndürme‑ölçeklemeden ölçek‑döndürmeye, ardından yalnız ölçeğe çevirir. İndeksler mevcut koleksiyona yöneliktir; kaldırma, yeniden sıralamadan sonra döndürmenin yeni indeksini kullanır. Son enum, kaydedilecek davranışı doğrular.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Çıktı `ScaleEffect` olacaktır: yalnız ölçekleme kalır. Koleksiyon sırası tek başına davranışları art arda zamanlamaz. Tüm işlemlerini değiştirdiğinizde koleksiyonu temizleyin.

## **Davranış Zamanlamasını Yapılandırma**

[IBehavior.getTiming](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehavior/#getTiming--) , [IEffect.getTiming](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#getTiming--) bağımsız olarak [ITiming](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/) nesnesini ortaya çıkarır. Etki zamanlaması, kapsayan etkinin zamanlamasını belirler; davranış zamanlaması ise içinde yer alan bir operasyonu tanımlar.

### **Süre, Gecikme, Tekrar ve Hızlandırma Ayarlama**

`rotation.pptx` dosyasını açın ve saniye cinsinden süre ([getDuration](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getDuration--)) ve tetikleme gecikmesi ([getTriggerDelayTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) ayarlayın, ardından [setRepeatCount](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) ile tekrar sayısını belirleyin. [getAccelerate](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getAccelerate--) ve [getDecelerate](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getDecelerate--) sürenin kesirleridir; toplamlarının en fazla 1 olmasına dikkat edin.

Giriş dosyası, döndürme örneğinde oluşturulan dosyadır; ilk davranışın bir döndürme olduğu bilinir. Bu örnek yalnız bu davranışın zamanlamasını değiştirir; 90‑derecelik açı aynı kalır. Açıyı ve zamanlamayı ayrı tutmak, animasyonu yeniden oluşturmak zorunda kalmadan hızı ayarlamayı kolaylaştırır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Davranış iki saniyelik bir süre, yarım saniyelik bir gecikme ve 3 tekrar sayısı kullanır. Süresinin ilk ve son %20’si hızlandırma ve yavaşlatma için ayrılmıştır.

Diğer tekrar politikaları arasında [getRepeatDuration](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), ve [getRepeatUntilNextClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--) bulunur; hepsini aynı anda etkinleştirmek yerine birini seçin. [getAutoReverse](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getAutoReverse--) ileri geçişten sonra animasyonu tersine oynatır. Hızlandırma ve yavaşlatma, sürekli değişikliklere uygulanır; ayrık atamalara veya komutlara uygulanmaz.

## **Hareket Yolu Oluşturma**

Hareket oluşturmak için [createMotionEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) yöntemini kullanın. [getFrom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotioneffect/#getTo--), ve [getBy](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotioneffect/#getBy--) yüzde‑tabanlı koordinatları veya ofsetleri tanımlar. Düzenlenebilir bir rota için bir [MotionPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/motionpath/) oluşturun ve [IMotionEffect.setPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-) ile atayın. [IMotionPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotionpath/) yol komutlarını depolar.

[MotionCommandPathType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/motioncommandpathtype/) işlemi seçer:

| Komut | Nokta Sayısı | Anlam |
| --- | --- | --- |
| MoveTo | Bir | Başlangıç konumunu ayarlar. |
| LineTo | Bir | Doğrudan bir segment boyunca son noktasına hareket eder. |
| CurveTo | Üç | İki kontrol noktası ve bir son nokta ile tanımlanan kübik eğriyi izler. |
| CloseLoop | Yok | Başlangıç konumuna döner. |
| End | Yok | Yolu tamamlar. |

[MotionPathPointsType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/motionpathpointstype/) nokta‑düzenleme özelliklerini (köşe veya yumuşak nokta gibi) tanımlar; komut tipini değiştirmez. Aşağıdaki eğri örneği için eğri nokta tipini, düz segmentler için köşe nokta tipini kullanın.

Yol koordinatları slayt boyutlarına göre normalleştirilir: X 0.25 birim, slayt genişliğinin çeyreği anlamına gelir, 0.25 puan anlamına gelmez. Pozitif Y aşağı doğru gider. Mutlak komutlar yol koordinat sisteminde konumları belirtir; göreceli komutlar mevcut konuma ofset ekler. Bu, [getOrigin](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotioneffect/#getOrigin--) ile seçilen referans çerçevesinden ve [getPathEditMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--) ile şekil hareket ettiğinde yolun nasıl hareket edeceğinden ayrı bir konudur.

### **Düz Bir Yol Oluşturma**

Başlangıç noktası, bir düz segment ve bir son komut içeren bir hareket davranışı oluşturun. [IMotionPath.add](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) komut tipini, noktalarını, nokta tipini ve göreceli‑koordinat bayrağını alır.

Başlangıç komutu (0, 0) konumunu kurar ve çizgi (0.25, 0)’a kadar uzanarak yolun yatay olarak slayt genişliğinin çeyreği kadar kaymasını sağlar. Son komutun koordinat noktası yoktur. Yol atandıktan sonra hareket davranışı efekti eklemek, bu yolu dikdörtgene bağlar.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` bir hareket davranışı ve üç yol komutu içerir. Aşağıdaki dosya‑düzenleme örnekleri bu yapıyı varsayar.

### **Mutlak ve Göreceli Koordinatları Karşılaştırma**

Bu iki yol nesnesi aynı rotayı tanımlar. Mutlak komut (0.3, 0.1)’de biter; göreceli komut (0.1, 0.1)’i mevcut konuma ekler, sonuç (0.2, 0) olur.

Her iki yol da aynı konumda başlar. Göreceli çizgi için X ve Y ofsetlerini mevcut konuma ekleyerek son noktayı elde edin; mutlak çizgi için son noktayı doğrudan okuyun. Bayrağı dönüştürmeden koordinatları değiştirmek farklı bir rota tanımlamaya yol açar.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Her iki yolu da bir hareket davranışına atayarak sunumda kullanın. Son Boolean argüman, o komut için göreceli koordinatları seçer.

### **Bir Çizgiyi Eğriyle Değiştirme**

`motion.pptx` dosyasını açın ve çizgi komutunu bir kübik eğriyle değiştirin. İlk olarak iki kontrol noktasını, ardından son noktayı sağlayın.

Başlangıç konumu, önceki komut tarafından belirlenir. İlk iki nokta eğriyi şekillendirir, üçüncü nokta ise hedef noktadır; bunlar üç ardışık hedef değildir. Komut tipini, nokta‑düzenleme tipini ve nokta dizisini birlikte güncellemek, segmentin yeni geometriyle tutarlı kalmasını sağlar.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`curve.pptx` içindeki yol hâlâ üç komut içerir; ortadaki komut artık bir eğriyi tanımlar.

## **Kaydedilmiş Bir Yolu İnceleme ve Düzenleme**

Her [IMotionCmdPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotioncmdpath/) [getPoints](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), ve [isRelative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--) yöntemlerini ortaya çıkarır. Aşağıdaki örnekler `motion.pptx` içinde bilinen üç‑komutluk yolu kullanır. Keyfi bir giriş için, düzenleme öncesinde etkidenin bulunup komut tipleri ve nokta sayıları kontrol edilmelidir.

### **Komutları ve Koordinatları Okuma**

Yolu değiştirmeden okuyun. Son ve kapatma‑döngü komutları noktaya ihtiyaç duymaz; bu nedenle null nokta dizisine izin verin.

Çıktı, her sayısal komut tipini göreceli‑koordinat bayrağıyla birlikte listeler, ardından noktalarını gösterir. Bu, bir noktanın uç nokta mı yoksa ofset mi olduğunu değişiklik yapmadan ayırt etmenizi sağlar. Bu dosyada düz bir çizgi yalnız bir nokta listeler, eğri üç nokta listeler.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Liste, bir başlangıç noktası, (0.25, 0)’da biten mutlak bir çizgi ve bir son komut içerir.

### **Bir Uç Noktayı Değiştirme**

`motion.pptx` dosyasını açın ve çizginin nokta dizisini değiştirerek uç noktasını taşıyın.

Giriş dosyasında indeks 0 başlangıç komutu, indeks 1 çizgidir. Çizginin tek noktasını değiştirmek, komut tipini, zamanlamasını veya koleksiyondaki konumunu etkilemeden hedefi değiştirir. Komut mutlak koordinatlar kullandığından, yeni çift bir konumu temsil eder, ek bir ofset değil.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion-endpoint.pptx` içindeki çizgi (0.4, 0.1)’de biter; orijinal dosya değişmemiştir.

### **Bir Segmenti Değiştirme**

[insert](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) ve [removeAt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) kullanarak `motion.pptx` içindeki çizgiyi değiştirin. Ekleme, eski çizgiyi indeks 2’ye kaydırır.

Bu, mevcut koordinatları düzenlemek yerine bir komut nesnesini değiştirmeyi gösterir. Eklemeden sonra koleksiyon geçici olarak başlangıç komutu, yeni çizgi, eski çizgi ve son komutu içerir. İndeks 2’yi kaldırmak eski çizgiyi atar ve yeni rotayı bırakır.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kaydedilen yol hâlâ üç komut içerir; yeni çizgi (0.2, 0.1)’de biter ve son komut en sonda yer alır.

## **Mevcut Bir Davranışı Değiştirip Doğrulama**

Davranışın indeksi bilinmiyorsa, tipiyle seçin. Bu örnek `rotation.pptx` dosyasını açar, [IRotationEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/irotationeffect/) bulur, açıyı değiştirir ve yeniden açtıktan sonra kaydedilen değeri kontrol eder.

Tip kontrolü, döndürme olmayan davranışların döngüden atlanmasını sağlar. İkinci yükleme, kaydedilen dosyayı ayrı bir sunum nesnesine okur; böylece karşılaştırma, bellekte hâlâ tutulan değerden ziyade kalıcı veriyi doğrular. Bu örnek hâlâ bilinen etkinin ana dizide ilk olduğuna dayanır; tip‑temelli seçim rastgele bir sunumda doğru etkinin bulunmasını garanti etmez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Çıktı `Rotation preserved: true` olacaktır. Aynı tip‑kontrol desenini diğer davranışlara da uygulayın. Tam bir koruma kontrolü için hedef şekil, etki, davranış tipleri ve sırası, zamanlama ve yol komutları karşılaştırılmalıdır. Sayısal değerler için bir tolerans kullanın. Animasyon düzeni bilinmeyen bir sunum için [Şekil Animasyonlarını Okuma](/slides/tr/androidjava/shape-animation/#read-shape-animations) bölümüne bakın.

## **Davranış Sırası, Ön Ayarlar ve Oynatma**

[IBehaviorCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehaviorcollection/) içindeki sıra, bir etkinin işlemlerinin depolanan sırasıdır. Bu, her davranışın otomatik olarak bir öncekinin bitmesini beklediği bir çalma listesi değildir. Zamanlama ve kapsayan etki planlamayı belirler. Davranışlar çakışabilir ve aynı özelliğe yönelik işlemler [getAdditive](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehavior/#getAdditive--) ve [getAccumulate](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ibehavior/#getAccumulate--) aracılığıyla etkileşebilir. “Taşı, sonra döndür” gibi bir zamanlama elde etmek için yalnızca koleksiyon sırasını değiştirmeyin; [Şekil Animasyonu](/slides/tr/androidjava/shape-animation/) bölümünde açıklandığı gibi açık zamanlamalar veya ayrı etkiler kullanın.

Etkinin [getType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#getType--) ve [getSubtype](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#getSubtype--) ön ayarını tanımlar. Bu, düzenlenmiş bir davranış ağacının tam bir tanımı değildir. Davranışları özelleştirmeden önce ön ayar ve alt tip seçin: ön ayarı değiştirmek koleksiyonu yeniden oluşturur ve özelleştirilmiş işlemlerinizi silebilir. Örneğin, özel bir Spin etkisini Fade’a değiştirirseniz, döndürme davranışı set ve filter davranışlarıyla değiştirilebilir. Ön ayar tipini veya alt tipini değiştirdikten sonra koleksiyonu tekrar inceleyin. Ön ayar davranışlarını temizlemek, ön ayarın gerektirdiği görünürlük veya başlatma işlemlerini de kaldırabilir. Örnekler, görünür şekiller kullanır ve davranışları değiştirir; her ön ayarın tüm uygulamasını yeniden inşa etmez.

## **Biçim Uyumluluğu**

Korunmuş bir davranış ağacı, her görüntüleyici veya dışa aktarım motorunda aynı oynatımı garanti etmez. Kaydedilen veriyi ve oluşturulan çıktıyı ayrı ayrı kontrol edin.

| Biçim veya çıktı | Kontrol Edilecekler |
| --- | --- |
| PPTX | Bu örneklerde birincil biçim olarak kullanın. Düzenlenebilir davranış ağacını doğrulamak için yeniden açın, ardından hedef PowerPoint sürümünde oynatmayı test edin. |
| PPT | Eski ikili temsili PPTX’ten farklı olabilir. Ayrı bir kaydet‑ve‑yeniden‑aç döngüsü ve oynatma testi yapın; PPTX çıktısının başarılı olması, tüm özel kombinasyonların desteklendiğini göstermez. |
| PDF, PNG, JPEG ve diğer statik slayt görselleri | Statik slayt temsili sunar; oynatılabilir bir davranış zaman çizelgesi veya garantili bir son animasyon karesi içermez. |
| [HTML5](/slides/tr/androidjava/export-to-html5/) | Dışa aktarım seçeneklerinde şekil animasyonu etkinleştirildiğinde desteklenen animasyonları oynatabilir. Tarayıcıda özel kombinasyonları test edin. |
| [Animasyonlu GIF](/slides/tr/androidjava/convert-powerpoint-to-animated-gif/) | Oluşturulan kareleri saklar; düzenlenebilir davranışları veya tıklama‑tetiklenen etkileşimi içermez. Gerçek hareketi kontrol edin. |
| [Video](/slides/tr/androidjava/convert-powerpoint-to-video/) | Animasyon karelerini renderlar ve video olarak kodlar. Destek, renderlayıcının [desteklenen animasyon ve efektleri](/slides/tr/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) ile sınırlıdır; komutlar ve etkileşimli olaylar düzenlenebilir bir zaman çizelgesine dönüşmez. |

## **SSS**

**Neden bir etki, herhangi bir davranış eklemeden önce davranışlar içeriyor?**

Önceden tanımlanmış bir etki oluşturmak, temel işlemlerini de oluşturabilir. Ön ayarı genişletmek mi yoksa davranışlarını değiştirmek mi istediğinize karar vermeden önce bunları inceleyin.

**Bir davranışı başa taşıyarak önce oynatılması sağlanır mı?**

Zorunlu değil. Koleksiyon sırası, zamanlamanın yerini tutmaz. Gecikmeleri, süreleri ve aynı özellik üzerine yapılan işlemlerin etkileşimini kontrol edin.

**Neden bir end (son) komutunun noktası yok?**

Bu komut, yolun sonunu işaret eder ve koordinata ihtiyaç duymaz. Dosyadan okunan bir yolu incelerken null nokta dizisine bakın.

**Başarılı bir tur (round‑trip) oynatmayı kanıtlar mı?**

Hayır. Yeniden açma, kontrol ettiğiniz özelliklerin korunup korunmadığını gösterir. Görsel davranışı teyit etmek için slayt gösterisi oynatıcı veya animasyonlu dışa aktarımı ayrı olarak test edin.