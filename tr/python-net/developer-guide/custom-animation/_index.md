---
title: Python'da Özel Animasyon Davranışlarını Oluşturma ve Değiştirme
linktitle: Özel Animasyon
type: docs
weight: 151
url: /tr/python-net/custom-animation/
keywords:
- özel animasyon
- animasyon davranışı
- hareket yolu
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint sunumlarında özel animasyon davranışlarını ve düzenlenebilir hareket yollarını oluşturun, inceleyin ve değiştirin."
---
## **Genel Bakış**

Özel animasyon davranışları, bir renk değişikliği, bir şeklin döndürülmesi veya düzenlenebilir bir hareket yolu takip edilmesi gibi bir animasyon efektindeki bireysel işlemleri kontrol etmenizi sağlar. Bu kılavuz, davranışların nasıl oluşturulacağını ve birleştirileceğini, zamanlamalarının nasıl yapılandırılacağını, mevcut animasyonların nasıl inceleneceğini ve değiştirileceğini ve özelliklerinin bir sunumu kaydedip yeniden açtıktan sonra da korunup korunmadığını gösterir.

Önceden tanımlanmış efektler ve tıklama tetikleyicileri için, [Şekil Animasyonu](/slides/tr/python-net/shape-animation/) sayfasına bakın.

## **Animasyon Modelini Anlamak**

Bir animasyon **Timeline → Sequence → Effect → Behaviors** olarak düzenlenir:

- Slaytın [timeline](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseslide/timeline/) ana sekansını ve etkileşimli sekansları içerir.
- [Sequence](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/) efektleri içerir ve potansiyel olarak farklı şekilleri hedefleyebilir.
- [Effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/) hedef şekli, ön ayarı, alt türü ve efekt zamanlamasını tanımlar.
- [Effect.behaviors](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/behaviors/) efekti uygulayan işlemleri içerir: rengin değiştirilmesi, hareket, döndürme, bir özelliğin ayarlanması vb.

## **Bireysel Davranışlar Oluşturma**

[Sequence.add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) çağırarak bir efekt oluşturabilir ve onun [behaviors](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/behaviors/) koleksiyonuna erişebilirsiniz. Bir ön ayar bu koleksiyonu otomatik olarak doldurabilir. Ön ayarı genişletirken işlemlerini koruyun veya kasıtlı olarak değiştirmek istediğinizde [clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorcollection/clear/) yöntemini kullanın.

[BehaviorFactory](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorfactory/) aşağıda gösterilen sekiz davranış tipini oluşturur. Hareket, [Bir Hareket Yolu Oluşturma](#build-a-motion-path) bölümünde ele alınmıştır. Her oluşturma örneği eksiksiz bir programdır; sonraki düzenleme örnekleri hangi çıktı dosyasını kullandıklarını belirtir.

### **Döndürme**

Döndürme oluşturmak için [create_rotation_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) kullanın. [by](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/rotationeffect/by/) derece cinsinden göreceli bir açı belirtir; [from_address](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/rotationeffect/from_address/) ve [to](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/rotationeffect/to/) uç noktaları tanımlar.

Örnek, bir Spin etkisiyle başlar, ön ayar işlemlerini tek bir döndürme davranışıyla değiştirir ve bu işleme iki saniyelik bir süre verir. 90 derece göreceli açı, şeklin başlangıç yönelmesinden bir çeyrek dönüşü ifade eder, bu yüzden açık bir başlangıç açısına gerek yoktur.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` bir şekil ve bir döndürme davranışı içerir. Aşağıdaki koleksiyon, zamanlama ve döndürme düzenleme örnekleri bu dosyayı kullanır.

### **Ölçekleme**

X/Y yüzdeleriyle [create_scale_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) kullanın: [from_address](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/scaleeffect/from_address/) ve [to](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/scaleeffect/to/) başlangıç ve bitiş boyutlarını tanımlar, [by](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/scaleeffect/by/) ise göreceli bir değişikliği açıklar. Burada, 100 orijinal boyutu ifade eder.

Örnek, iki saniye içinde her iki boyutu %100'den %125'e büyütür. Yatay ve dikey yüzde değerlerinin eşit olması şeklin oranlarını korur; farklı yüzde değerleri bir boyutu diğerine göre daha fazla uzatır.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **Renk**

Dolgu rengini mavi'den turuncuya değiştirmek için [create_color_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) kullanın. [from_address](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/coloreffect/from_address/) ve [to](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/coloreffect/to/) renklerdir; [by](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/coloreffect/by/) bir renk ofsetidir. [Behavior.properties](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behavior/properties/) animasyon yapılan özelliği tanımlar.

Şeklin katı dolgu rengi animasyonun başlangıç rengiyle eşleşecek şekilde mavi olarak başlatılır. Dolgu rengi özelliğini seçmek, davranışa şeklin hangi kısmının değişeceğini söyler; sadece renk uç noktaları bu özelliği tanımlamaz. Kaydedilen efekt, iki saniyelik bir turuncuya geçişi tanımlar.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **Filtre**

Bir silme efekti seçmek için [create_filter_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) kullanın. [type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/filtereffect/subtype/), ve [reveal](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/filtereffect/reveal/) filtreyi, yönü ve şeklin gösterilip gizleneceğini belirtir.

Bu örnek, sağ yön alt türünü kullanarak şekli iki saniyelik bir silme ile ortaya çıkarır. Filtre ayarları, efekt içindeki davranışa aittir, bu yüzden ön ayarın orijinal işlemleri kaldırıldıktan sonra yapılandırılır.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **Özellik**

Saydamlığı canlandırmak için [create_property_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) kullanın. [from_address](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/propertyeffect/to/), ve [by](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/propertyeffect/by/) [value_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/propertyeffect/value_type/) ve [calc_mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/propertyeffect/calc_mode/) kullanılarak yorumlanan metinlerdir. Üçünü de rastgele ayarlamak yerine uç noktaları ya da göreceli bir offseti seçin.

Burada, seçilen özellik saydamlıktır ve sayısal metinler %25 saydamlıktan tam saydamlığa bir değişimi temsil eder. Doğrusal ara değerleme bu değerler arasında kademeli bir değişimi tanımlar. Bu örneği başka bir özelliğe uyarlarken, o özelliğe uygun bir değer tipi ve uç değerler seçin.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **Ayarla**

Görünürlüğü [to](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/seteffect/to/) aracılığıyla atamak için [create_set_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) kullanın. Bir ayarla davranışı uç noktalar arasında ara değerleme yapmaz.

Örnek, görünürlük özelliğini seçer ve davranış çalıştığında `visible` metnini atar. Bu minimal sunumda dikdörtgen zaten görünür olduğundan atama tek başına belirgin bir görsel değişiklik üretmeyebilir. Bu tür bir işlem, şeklin ne zaman gizleneceğini veya görüneceğini kontrol eden daha büyük bir etkinin parçası olarak faydalıdır.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **Komut**

[create_command_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) kullanın ve [type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/commandeffect/command_string/), ve [shape_target](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/commandeffect/shape_target/) ayarlarını yapın. Çalışma dizinine `sample.wav` adlı bir WAV kaydı yerleştirin. Bu örnek, kaydı [add_audio_frame_embedded](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) ile gömerek ses çerçevesine bir oynatma komutu ekler.

Ses çerçevesi hem efektin hem de komutun hedefidir. Bu, oynatma isteğini gömülü kayda bağlar; yalnızca bir komut dizesi hangi medya nesnesinin kontrol edileceğini belirtmez. Efekt, slayt gösterisi sırasında bir tıklamayla başlaması için yapılandırılır.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

Kaydetme, komutu `command.pptx` içinde saklar; kaydı oynatmaz. Oynatma, komutu ve onun medya hedefini destekleyen bir slayt gösterisi oynatıcı gerektirir.

## **Davranış Koleksiyonunu Yönetme**

[BehaviorCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorcollection/) [add](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorcollection/remove/), ve [remove_at](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorcollection/remove_at/) yöntemlerini destekler. Bu örnek `rotation.pptx` dosyasını açar, ölçekleme ekler, döndürmeden önce yerleştirir ve döndürmeyi kaldırır. Aynı nesneyi kaldırıp tekrar eklemek, kopya oluşturmadan depolanan konumunu değiştirir.

Düzenleme sırası koleksiyonu döndürme‑ölçekleme’den ölçekleme‑döndürmeye, ardından sadece ölçeklemeye değiştirir. İndeksler mevcut koleksiyona referans verir, bu yüzden kaldırma, yeniden sıralamadan sonra döndürmenin yeni indeksini kullanır. Son sayım, hangi davranışın kaydedileceğini doğrular.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

Çıktı `ScaleEffect`'tir: sadece ölçekleme kalır. Koleksiyon sırası, tek başına davranışları art arda zamanlamaz. Tüm işlemlerini değiştirdiğinizde koleksiyonu temizleyin.

## **Davranış Zamanlamasını Yapılandırma**

[Behavior.timing](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behavior/timing/) [Timing](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/) nesnesini ortaya çıkarır ve bu, [Effect.timing](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/timing/) independent olarak çalışır. Efekt zamanlaması kapsayıcı efekti zamanlar; davranış zamanlaması ise içindeki bir işlemi tanımlar.

### **Süre, Gecikme, Tekrar ve Hızlanma Ayarlama**

`rotation.pptx` dosyasını açın ve [duration](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/duration/) ve [trigger_delay_time](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/trigger_delay_time/) saniye cinsinden ayarlayın, ardından [repeat_count](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_count/) yapılandırın. [accelerate](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/accelerate/) ve [decelerate](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/decelerate/) sürenin kesirleridir; toplamlarının en fazla 1 olmasına dikkat edin.

Girdi dosyası, döndürme örneğinde oluşturulan ve ilk davranışın bir döndürme olduğu bilinen dosyadır. Bu örnek yalnızca bu davranışın zamanlamasını değiştirir; 90 derece açı aynı kalır. Açıyı ve zamanlamayı ayrı tutmak, animasyonu yeniden oluşturmak zorunda kalmadan hızı ayarlamayı kolaylaştırır.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

Davranış iki saniyelik bir süre, yarım saniyelik gecikme ve 3 tekrar sayısı kullanır. Süresinin ilk ve son %20'si hızlanma ve yavaşlama için ayrılmıştır.

Diğer tekrar politikaları [repeat_duration](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), ve [repeat_until_next_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_until_next_click/) içerir; hepsini aynı anda etkinleştirmek yerine bir politikayı seçin. [auto_reverse](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/auto_reverse/) animasyonu ileri geçişten sonra tersine oynatır. Hızlanma ve yavaşlama, kesikli atamalar veya komutlar yerine sürekli değişikliklere uygulanır.

## **Bir Hareket Yolu Oluşturma**

Hareket oluşturmak için [create_motion_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) kullanın. Its [from_address](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motioneffect/to/), ve [by](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motioneffect/by/) yüzde tabanlı koordinatlar veya ofsetleri tanımlar. Düzenlenebilir bir rota için bir [MotionPath](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motionpath/) oluşturun ve bunu [MotionEffect.path](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motioneffect/path/)’e atayın. [MotionPath](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motionpath/) yol komutlarını depolar.

| Komut | Nokta Sayısı | Anlam |
| --- | --- | --- |
| MOVE_TO | Bir | Başlangıç konumunu ayarlar. |
| LINE_TO | Bir | Düz bir segment boyunca son noktasına hareket eder. |
| CURVE_TO | Üç | İki denetim noktası ve bir bitiş noktası tarafından tanımlanan kübik bir eğriyi izler. |
| CLOSE_LOOP | Yok | Başlangıç konumuna geri döner. |
| END | Yok | Yolu tamamlar. |

[MotionPathPointsType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motionpathpointstype/) nokta düzenleme özelliklerini, köşe veya pürüzsüz noktalar gibi, tanımlar. Komut tipinin yerini almaz. Aşağıdaki eğri örneği için bir eğri nokta tipini, düz segmentler için ise bir köşe nokta tipini kullanın.

Yol koordinatları slayt boyutlarına göre normalize edilir: 0.25 X kayması slayt genişliğinin dörtte birini temsil eder, 0.25 puanı değil. Pozitif Y aşağı doğru ilerler. Mutlak komutlar yol koordinat sisteminde konumları belirtir; göreceli komutlar mevcut konumdan ofsetleri tanımlar. Bu, yolu referans çerçevesi seçen [origin](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motioneffect/origin/), ve şekil hareket ettiğinde yolun nasıl hareket ettiğini kontrol eden [path_edit_mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motioneffect/path_edit_mode/) parametresinden ayrı bir şeydir.

### **Düz Bir Yol Oluşturma**

Başlangıç noktası, bir düz segment ve bir bitiş komutu içeren bir hareket davranışı oluşturun. [MotionPath.add](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motionpath/add/) komut tipini, noktalarını, nokta tipini ve göreceli koordinat bayrağını alır.

Başlangıç komutu (0,0) konumunu belirler ve çizgi (0.25,0) noktasında sona erer, bu da rotaya slayt genişliğinin çeyrek büyüklüğünde bir yatay kayma verir. Bitiş komutunun koordinat noktası yoktur. Yol atandıktan sonra, hareket davranışını efekt'e eklemek bu rotayı dikdörtgene bağlar.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` bir hareket davranışı ve üç yol komutu içerir. Aşağıdaki dosya düzenleme örnekleri bu bilinen yapıyı kullanır.

### **Mutlak ve Göreceli Koordinatları Karşılaştırma**

Bu iki yol nesnesi aynı rotayı tanımlar. Mutlak komut (0.3,0.1) noktasında biter; göreceli komut mevcut konuma (0.1,0.1) ekler, yani (0.2,0).

Her iki yol da aynı konumda başlar. Göreceli çizgi için, X ve Y ofsetlerini mevcut konuma ekleyerek son noktayı elde edin; mutlak çizgi için, son noktayı doğrudan okuyun. Koordinatları dönüştürmeden bayrağı değiştirirseniz farklı bir rota tanımlanır.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

Sunumda kullanmak için herhangi bir yolu hareket davranışına atayın. Son Boolean argüman, o komut için göreceli koordinatları seçer.

### **Bir Çizgiyi Eğriyle Değiştirme**

`motion.pptx` dosyasını açın ve çizgi komutunu bir kübik eğriyle değiştirin. İlk olarak iki denetim noktasını, ardından bitiş noktasını sağlayın.

Başlangıç konumu önceki komut tarafından sağlanır. İlk iki nokta eğriyi şekillendirir, üçüncüsü ise hedefidir; bunlar üç ardışık hedef değildir. Komut tipini, nokta düzenleme tipini ve nokta dizisini birlikte güncellemek, segmenti yeni geometrisiyle tutarlı tutar.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

`curve.pptx` içindeki yol hâlâ üç komuta sahiptir; orta komutu artık bir eğri tanımlar.

## **Kaydedilmiş Bir Yolu İnceleme ve Düzenleme**

Her bir [MotionCmdPath](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motioncmdpath/) [points], [command_type], [points_type] ve [is_relative] bilgilerini ortaya çıkarır. Aşağıdaki örnekler `motion.pptx` içindeki bilinen üç komutlu yolu kullanır. Rastgele bir giriş için, öncelikle hedef efekti bulun ve indeksle düzenlemeden önce komut tiplerini ve nokta sayılarını kontrol edin.

### **Komutları ve Koordinatları Okuma**

Yolu değiştirmeden okuyun. Bitiş ve döngüyü kapatma komutlarının noktalara ihtiyacı yoktur, bu yüzden `None` bir nokta dizisine izin verin.

Çıktı, her komutu noktalarını listelemeden önce göreceli koordinat bayrağıyla eşleştirir. Bu, yolu değiştirmeden önce bir son noktayı bir ofsetten ayırmanıza olanak tanır. Bir eğri üç nokta listelerken, bu dosyadaki düz çizgi yalnızca bir nokta listeler.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

Liste, bir başlangıç noktası, (0.25,0) noktasında biten mutlak bir çizgi ve bir bitiş komutu içerir.

### **Bir Son Noktayı Değiştirme**

`motion.pptx` dosyasını açın ve çizginin nokta dizisini değiştirerek son noktasını taşıyın.

Girdi dosyasında, indeks 0 başlangıç komutudur ve indeks 1 çizgidir. Çizginin tek noktasını değiştirmek, komut tipini, zamanlamasını veya koleksiyondaki konumunu değiştirmeden hedefini değiştirir. Komut mutlak koordinatlar kullandığı için yeni çift bir konumu tanımlar, ek bir ofset değil.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

`motion-endpoint.pptx` içindeki çizgi (0.4,0.1) noktasında biter; orijinal dosya değişmemiştir.

### **Bir Segmenti Değiştirme**

Çizgiyi `motion.pptx` içinde değiştirmek için [insert](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motionpath/insert/) ve [remove_at](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/motionpath/remove_at/) kullanın. Ekleme, eski çizgiyi indeks 2'ye kaydırır.

Bu, mevcut koordinatlarını düzenlemek yerine bir komut nesnesini değiştirmeyi gösterir. Eklemeden sonra, koleksiyon geçici olarak başlangıç komutu, yeni çizgi, eski çizgi ve bitiş komutunu içerir. İndeks 2'yi kaldırmak eski çizgiyi siler ve yeni rotayı yerinde bırakır.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

Kaydedilen yol hâlâ üç komuta sahiptir; yeni çizgi (0.2,0.1) noktasında biter ve bitiş komutu en sonda yer alır.

## **Mevcut Bir Davranışı Değiştirme ve Doğrulama**

Davranışın indeksi bilinmiyorsa, türüne göre seçin. Bu örnek `rotation.pptx` dosyasını açar, onun [RotationEffect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/rotationeffect/) bulur, açıyı değiştirir ve yeniden açtıktan sonra kaydedilen değeri kontrol eder.

Tür kontrolü, döndürme olmayan davranışların döngüde atlanmasını sağlar. İkinci yükleme, kaydedilen dosyayı ayrı bir sunum nesnesine okur; böylece karşılaştırma bellekte hâlâ tutulan değeri değil, kalıcı veriyi kontrol eder. Bu örnek hâlâ bilinen etkinin ana sekansın ilkinde olduğunu varsayar; türüne göre bir davranış seçmek, rastgele bir sunumda doğru efekti bulmayabilir.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

Çıktı `Rotation preserved: True` olur. Aynı tür kontrol desenini diğer davranışlara da uygulayın. Tam bir koruma kontrolü için hedef şekli, efekti, davranış türlerini ve sırasını, zamanlamayı ve yol komutlarını karşılaştırın. Ondalıklı sayılar için sayısal bir tolerans kullanın. Bilinmeyen bir animasyon düzenine sahip bir sunum için, ana ve etkileşimli sekansların dolaşımı hakkında [Şekil Animasyonlarını Oku](/slides/tr/python-net/shape-animation/#read-shape-animations) sayfasına bakın.

## **Davranış Sırası, Ön Ayarlar ve Oynatma**

[BehaviorCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behaviorcollection/) içindeki sıra, bir efektin işlemlerinin depolanmış sırasıdır. Bu, her davranışın otomatik olarak bir öncekinin bitmesini beklediği bir çalma listesi değildir. Zamanlama ve kapsayıcı efekt zamanlamayı belirler. Davranışlar çakışabilir ve aynı özelliğe yapılan işlemler [additive](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behavior/additive/) ve [accumulate](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/behavior/accumulate/) aracılığıyla etkileşebilir. Sadece koleksiyon sırasını değiştirerek “hareket, ardından döndür” zamanlamasını planlamaya çalışmayın; açık zamanlamalar veya ayrı etkiler kullanın; bu, [Şekil Animasyonu](/slides/tr/python-net/shape-animation/) bölümünde açıklanmıştır.

Efektin [type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/type/) ve [subtype](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/subtype/) ön ayarını tanımlar. Bunlar düzenlenmiş bir davranış ağacının tam bir açıklaması değildir. Davranışları özelleştirmeden önce ön ayarı ve alt türü seçin: ön ayarı değiştirmek koleksiyonu yeniden oluşturabilir ve özel işlemlerinizi silebilir. Örneğin, özelleştirilmiş bir Spin efektini Fade'e değiştirmek, döndürme davranışını ayar ve filtre davranışlarıyla değiştirebilir. Ön ayar veya alt tür değiştirildikten sonra koleksiyonu tekrar inceleyin. Ön ayar davranışlarını temizlemek, ön ayarın ihtiyaç duyduğu görünürlük veya başlatma işlemlerini de kaldırabilir. Örnekler bilerek görünür şekiller kullanır ve davranışları değiştirir; her ön ayarın uygulamasını yeniden oluşturmazlar.

## **Biçim Uyumluluğu**

Korunan bir davranış ağacı, her görüntüleyicide veya dışa aktarma motorunda aynı oynatımı garanti etmez. Kaydedilen veriyi ve üretilen çıktıyı ayrı ayrı kontrol edin.

| Format veya çıktı | Ne kontrol edilmeli |
| --- | --- |
| PPTX | Bu örnekler için birincil format olarak kullanın. Düzenlenebilir davranış ağacını doğrulamak için yeniden açın, ardından hedef PowerPoint sürümünde oynatmayı kontrol edin. |
| PPT | Eski ikili temsil PPTX'ten farklı olabilir. Ayrı bir kaydet‑ve‑yeniden‑aç döngüsü ve oynatma testi yapın; başarılı PPTX çıktısından tüm özel kombinasyonların desteklendiğini varsaymayın. |
| PDF, PNG, JPEG, ve diğer statik slayt görüntüleri | Statik bir slayt temsili içerir, oynatılabilir bir davranış zaman çizelgesi veya garantili bir son animasyon çerçevesi değildir. |
| [HTML5](/slides/tr/python-net/export-to-html5/) | Dışa aktarma seçeneklerinde şekil animasyonu etkinleştirildiğinde desteklenen animasyonları oynatabilir. Tarayıcıda özel kombinasyonları test edin. |
| [Animated GIF](/slides/tr/python-net/convert-powerpoint-to-animated-gif/) | Render edilmiş kareleri depolar, düzenlenebilir davranışları veya tıklama‑tetiklenen etkileşimi içermez. Gerçek render edilmiş hareketi kontrol edin. |
| [Video](/slides/tr/python-net/convert-powerpoint-to-video/) | Animasyon karelerini render eder ve video olarak kodlar. Destek, renderlayıcının [desteklenen animasyonlar ve efektler](/slides/tr/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) ile sınırlıdır; komutlar ve etkileşimli olaylar düzenlenebilir bir zaman çizelgesine dönüşmez. |

## **SSS**

**Neden efektimde herhangi bir şey eklemeden önce davranışlar var?**

Önceden tanımlı bir efekt oluşturmak, altında yatan işlemleri yaratabilir. Ön ayarı genişletmek mi yoksa davranışlarını değiştirmek mi istediğinize karar vermeden önce bunları inceleyin.

**Bir davranışı başa taşımak onu önce oynatır mı?**

Zorunlu değildir. Koleksiyon sırası, zamanlamanın yerini tutmaz. Gecikmeleri, süreleri ve aynı özellik üzerindeki işlemlerin etkileşimlerini kontrol edin.

**Neden bir bitiş komutunun noktaları yok?**

Yolun sonunu işaret eder ve koordinatlara gerek duymaz. Dosyadan okunan bir yolu incelerken `None` nokta dizisi olup olmadığını kontrol edin.

**Başarılı bir dönüş dolaşımı oynatımı doğrulamak için yeterli mi?**

Hayır. Yeniden açmak, kontrol ettiğiniz özelliklerin korunmasını teyit eder. Görsel davranışı onaylamak için slayt gösterisi oynatıcıyı veya animasyonlu dışa aktarmayı ayrı ayrı test edin.