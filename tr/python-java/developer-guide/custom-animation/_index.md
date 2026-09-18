---
title: Python üzerinden Java ile Özel Animasyon Davranışlarını Oluşturma ve Değiştirme
linktitle: Özel Animasyon
type: docs
weight: 151
url: /tr/python-java/custom-animation/
keywords:
- özel animasyon
- animasyon davranışı
- hareket yolu
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PowerPoint sunumlarındaki özel animasyon davranışlarını ve düzenlenebilir hareket yollarını oluşturun, inceleyin ve değiştirin."
---
## **Genel Bakış**

Özel animasyon davranışları, bir animasyon efektindeki ayrı ayrı işlemleri, örneğin bir rengi değiştirmek, bir şekli döndürmek veya düzenlenebilir bir hareket yolu izlemek gibi, kontrol etmenizi sağlar. Bu kılavuz, davranışları nasıl oluşturup birleştireceğinizi, zamanlamalarını nasıl yapılandıracağınızı, mevcut animasyonları nasıl inceleyip değiştirebileceğinizi ve bu özelliklerin bir sunumu kaydedip yeniden açtığınızda korunup korunmadığını nasıl doğrulayacağınızı gösterir.

Öntanımlı efektler ve tıklama tetikleyicileri için, [Şekil Animasyonu](/slides/tr/python-java/shape-animation/) sayfasına bakın.

## **Animasyon Modelini Anlamak**

Bir animasyon, **Timeline → Sequence → Effect → Behaviors** biçiminde düzenlenir:

- [getTimeline] metodu, ana sekans ve etkileşimli sekansları içeren slayt zaman çizelgesini döndürür.
- Bir [Sequence] efektleri içerir; bunlar farklı şekilleri hedef alabilir.
- Bir [Effect] hedef şekli, ön ayarı, alt türü ve efekt zamanlamasını belirler.
- [Effect.getBehaviors] tarafından döndürülen koleksiyon, efekti uygulayan işlemleri içerir: renk değiştirme, taşıma, döndürme, bir özelliği ayarlama vb.

## **Bireysel Davranışları Oluşturma**

Bir efekt oluşturmak ve [getBehaviors] koleksiyonuna erişmek için [Sequence.addEffect] metodunu çağırın. Bir ön ayar bu koleksiyonu otomatik olarak doldurabilir. Ön ayarı genişletirken işlemlerini koruyun veya kasıtlı olarak değiştirdiğinizde [clear] metodunu kullanın.

[BehaviorFactory] sekiz davranış türünü aşağıda gösterildiği gibi oluşturur. Hareket, [Build a Motion Path]#build-a-motion-path bölümünde ele alınmıştır. Her örnek, gerekli olduğunda importları ve JVM başlatmayı içerir. Java nokta nesneleri ve dizileri, API'nin talep ettiği yerlerde JPype aracılığıyla oluşturulur. Sonraki düzenleme örnekleri hangi çıktı dosyasını kullandıklarını belirtir.

### **Döndürme**

Bir döndürme efekti oluşturmak için [createRotationEffect] kullanın. [getBy] derecelerde bir göreli açı belirler; [getFrom] ve [getTo] uç noktaları belirler.

Örnek, bir Spin efekti ile başlar, ön ayar işlemlerini bir döndürme davranışıyla değiştirir ve bu işleme iki saniyelik bir süre verir. 90 derecelik bir göreli açı, şeklin başlangıç yönünden çeyrek dönüş anlamına gelir; bu nedenle açık bir başlangıç açısına gerek yoktur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` bir şekil ve bir döndürme davranışı içerir. Aşağıdaki koleksiyon, zamanlama ve döndürme düzenleme örnekleri bu dosyayı kullanır.

### **Ölçekleme**

X/Y yüzde değerleriyle [createScaleEffect] kullanın: [getFrom] ve [getTo] başlangıç ve bitiş boyutunu, [getBy] ise göreli değişikliği tanımlar. Burada 100, orijinal boyutu ifade eder.

Örnek, iki saniye boyunca her iki boyutu da %100'den %125'e büyütür. Yatay ve dikey yüzde değerlerinin eşit olması şeklin oranını korur; farklı yüzde değerleri bir boyutu diğerinden daha fazla uzatır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Renk**

Renk dolgusunu maviden turuncuya değiştirmek için [createColorEffect] kullanın. [getFrom] ve [getTo] renklerdir; [getBy] bir renk ofsetidir. [Behavior.getProperties] animasyonu yapılan özelliği tanımlar.

Şeklin katı dolgusu mavi olarak başlatılır, bu da animasyonun başlangıç rengiyle eşleşir. Dolgu rengi özelliğini seçmek, davranışa şeklin hangi kısmının değişeceğini söyler; yalnızca renk uç noktaları bu özelliği tanımlamaz. Kaydedilen efekt, iki saniyelik bir turuncuya geçişi tanımlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Filtre**

Bir silme (wipe) seçmek için [createFilterEffect] kullanın. [getType], [getSubtype] ve [getReveal] sırasıyla filtreyi, yönü ve şekli ortaya çıkarıp gizleyeceğini belirler.

Bu örnek, sağ yön alt türünü kullanarak şekli ortaya çıkaran iki saniyelik bir silmeyi yapılandırır. Filtre ayarları, efekt içindeki davranışa aittir; bu yüzden ön ayarın orijinal işlemleri kaldırıldıktan sonra yapılandırılır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Özellik**

Saydamlığı animasyonlamak için [createPropertyEffect] kullanın. [getFrom], [getTo] ve [getBy] dize olup, [getValueType] ve [getCalcMode] ile yorumlanır. Üçünü de rastgele ayarlamak yerine uç noktaları veya göreli bir ofseti seçin.

Burada seçilen özellik saydamlıktır ve sayısal dizeler %25 saydamlıktan tam saydamlığa değişimi temsil eder. Doğrusal ara değerleme, bu değerler arasında kademeli bir değişim tanımlar. Bu örneği başka bir özelliğe uyarlarken, uygun bir değer türü ve ilgili uç değerler seçin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ayarlama**

Görünürlüğü [getTo] aracılığıyla atamak için [createSetEffect] kullanın. Bir ayar davranışı uç noktalar arasında ara değerleme yapmaz.

Örnek, görünürlük özelliğini seçer ve davranış çalıştığında `visible` dizesini atar. Dikdörtgen bu minimal sunumda zaten görünür olduğundan, atama tek başına belirgin bir görsel değişiklik üretmeyebilir. Bu işlem, şeklin ne zaman gizleneceğini veya görünür olacağını da kontrol eden daha büyük bir efektin parçası olarak faydalıdır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Komut**

[createCommandEffect] kullanın ve [getType], [getCommandString] ve [getShapeTarget] ayarlarını yapılandırın. Çalışma dizinine `sample.wav` adlı bir WAV kaydı yerleştirin. Bu örnek, kaydı [addAudioFrameEmbedded] ile gömer ve ses çerçevesine bir oynatma komutu ekler.

Ses çerçevesi hem efektin hem de komutun hedefidir. Bu, oynatma isteğini gömülü kayda bağlar; yalnızca bir komut dizesi hangi medya nesnesinin kontrol edileceğini göstermez. Efekt, slayt gösterisi sırasında bir tıklamayla başlaması için yapılandırılmıştır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kaydetme, komutu `command.pptx` içinde saklar; kaydı oynatmaz. Oynatım, komutu ve medya hedefini destekleyen bir slayt gösterisi oynatıcı gerektirir.

## **Davranış Koleksiyonunu Yönetme**

[BehaviorCollection] [add], [insert], [remove] ve [removeAt] metodlarını destekler. Bu örnek `rotation.pptx` dosyasını açar, ölçekleme ekler, döndürmeden önce konumlandırır ve döndürmeyi kaldırır. Aynı nesneyi kaldırıp tekrar eklemek, kopya oluşturmadan depolanan konumunu değiştirir.

Edit sırası koleksiyonu döndürme–ölçeklemeden ölçekleme–döndürmeye, ardından yalnızca ölçeklemeye değiştirir. İndeksler mevcut koleksiyona atıfta bulunur, bu nedenle kaldırma, yeniden sıralamadan sonra döndürmenin yeni indeksini kullanır. Son sayma, hangi davranışın kaydedileceğini teyit eder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Çıktı `ScaleEffect` dir: sadece ölçekleme kalır. Koleksiyon sırası tek başına davranışları birbiri ardına zamanlamaz. Tüm işlemleri değiştirdiğinizde koleksiyonu temizleyin.

## **Davranış Zamanlamasını Yapılandırma**

[Behavior.getTiming], [Effect.getTiming]’den bağımsız olarak [Timing] nesnesini ortaya çıkarır. Efekt zamanlaması kapsayan efekti zamanlarken, davranış zamanlaması içindeki bir işlemi tanımlar.

### **Süre, Gecikme, Tekrar ve Hızlanma Ayarlama**

`rotation.pptx` dosyasını açın ve süreyi ([getDuration]), tetikleme gecikmesini ([getTriggerDelayTime]) saniye cinsinden ayarlayın, ardından tekrar sayısını [setRepeatCount] ile yapılandırın. [getAccelerate] ve [getDecelerate] süreye oran olarak verilir; toplamları en fazla 1 olmalıdır.

Girdi dosyası, döndürme örneğinde oluşturulan dosyadır; ilk davranışın bir döndürme olduğu bilinmektedir. Bu örnek sadece o davranışın zamanlamasını değiştirir; 90 derecelik açı aynı kalır. Açıyı ve zamanlamayı ayrı tutmak, animasyonu yeniden inşa etmeden temposunu ayarlamayı kolaylaştırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bu davranış iki saniyelik bir süre, yarım saniyelik bir gecikme ve 3 tekrar sayısı kullanır. Süresinin ilk ve son %20’si hızlanma ve yavaşlama için ayrılmıştır.

Diğer tekrar politikaları arasında [getRepeatDuration], [getRepeatUntilEndSlide] ve [getRepeatUntilNextClick] bulunur; hepsini aynı anda etkinleştirmek yerine birini seçin. [getAutoReverse] ileri geçişten sonra animasyonu ters oynatır. Hızlanma ve yavaşlama sürekli değişikliklere, kesikli atamalara veya komutlara uygulanmaz.

## **Bir Hareket Yolu Oluşturma**

[createMotionEffect] kullanarak hareket oluşturun. [getFrom], [getTo] ve [getBy] yüzde temelli koordinatları veya ofsetleri tanımlar. Düzenlenebilir bir rota için bir [MotionPath] oluşturun ve onu [MotionEffect.setPath] ile atayın. [MotionPath] yol komutlarını saklar.

[MotionCommandPathType] kod, nokta sayısı ve anlam açıklamaları:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Başlangıç konumunu ayarlar. |
| LineTo | One | Doğrusal bir segment boyunca uç noktasına hareket eder. |
| CurveTo | Three | İki kontrol noktası ve bir uç nokta ile tanımlanan kübik bir eğriyi takip eder. |
| CloseLoop | None | Başlangıç konumuna geri döner. |
| End | None | Yolu bitirir. |

[MotionPathPointsType], köşe ya da pürüzsüz noktalar gibi nokta düzenleme özelliklerini tanımlar. Komut tipinin yerini almaz. Aşağıdaki eğri örneği için bir curve point tipini, düz segmentler için ise bir corner point tipini kullanın.

Yol koordinatları slayt boyutlarına göre normalize edilir: X eksenindeki 0.25 kayma, slayt genişliğinin dörtte birini temsil eder, 0.25 puanı değil. Pozitif Y aşağı doğru ilerler. Mutlak komutlar, yol koordinat sistemindeki konumları belirtirken, göreli komutlar geçerli konumdan ofseti belirtir. Bu, yolu referans çerçevesi olarak seçen [getOrigin] ve şekil hareket ettiğinde yolun nasıl hareket edeceğini kontrol eden [getPathEditMode]’dan ayrı bir kavramdır.

### **Düz Bir Yol Oluşturma**

Başlangıç noktası, bir düz segment ve bir bitiş komutu içeren bir hareket davranışı oluşturun. [MotionPath.add], komut tipini, noktalarını, nokta tipini ve göreli koordinat bayrağını alır.

Başlangıç komutu (0,0) konumunu belirler ve çizgi (0.25,0) noktasında sona erer; bu, rotaya slayt genişliğinin dörtte birini yatay kaydırma verir. Bitiş komutunun koordinat noktası yoktur. Yol atandıktan sonra, hareket davranışı efekte eklendiğinde bu rota dikdörtgene bağlanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` bir hareket davranışı ve üç yol komutu içerir. Aşağıdaki dosya düzenleme örnekleri bu bilinen yapıyı kullanır.

### **Mutlak ve Göreli Koordinatları Karşılaştırma**

Bu iki yol nesnesi aynı rotayı tanımlar. Mutlak komut (0.3,0.1)’de sona ererken, göreli komut (0.1,0.1)’i geçerli konuma (0.2,0) ekler.

Her iki yol da aynı konumda başlar. Göreli çizgi için, X ve Y ofsetlerini geçerli konuma ekleyerek uç noktayı elde edersiniz; mutlak çizgi için ise uç noktayı doğrudan okursunuz. Bayrağı koordinatları dönüştürmeden değiştirirseniz farklı bir rota tanımlanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

Her iki yolu da bir hareket davranışına atayarak sunumda kullanabilirsiniz. Son Boolean argüman, o komut için göreli koordinatları seçer.

### **Bir Çizgiyi Eğriyle Değiştirme**

`motion.pptx` dosyasını açın ve çizgi komutunu bir kübik eğriyle değiştirin. İlk olarak iki kontrol noktasını, ardından uç noktayı sağlayın.

Başlangıç konumu önceki komut tarafından sağlanır. İlk iki nokta eğriyi şekillendirirken, üçüncü nokta hedefidir; bunlar üç ardışık hedef değildir. Komut tipini, nokta düzenleme tipini ve nokta dizisini birlikte güncellemek, segmenti yeni geometrisiyle tutarlı tutar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`curve.pptx` içindeki yol hâlâ üç komuta sahiptir; orta komut artık bir eğri tanımlar.

## **Kaydedilmiş Bir Yolu İnceleme ve Düzenleme**

Her bir [MotionCmdPath], [getPoints], [getCommandType], [getPointsType] ve [isRelative] metodlarını sunar. Aşağıdaki örnekler `motion.pptx` içinde bilinen üç komutlu yolu kullanır. Rastgele bir girdi için, düzenlemeden önce hedef efekti bulup komut tiplerini ve nokta sayılarını indeksle kontrol edin.

### **Komutları ve Koordinatları Okuma**

Yolu değiştirmeden okuyun. End ve close-loop komutları nokta gerektirmez; bu nedenle null bir nokta dizisine izin verin.

Çıktı, her sayısal komut tipini nokta listelenmeden önce göreli koordinat bayrağıyla eşleştirir. Bu, yolu değiştirmeden önce bir uç noktayı bir ofsetten ayırmanıza olanak tanır. Bir eğri üç nokta listelerken, bu dosyadaki düz çizgi yalnızca bir nokta listeler.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

Liste, bir başlangıç noktasını, (0.25,0)’da sona eren mutlak bir çizgiyi ve bir end komutunu içerir.

### **Bir Uç Noktayı Değiştirme**

`motion.pptx` dosyasını açın ve çizginin nokta dizisini değiştirerek uç noktasını taşıyın.

Girdi dosyasında, indeks 0 başlangıç komutu, indeks 1 ise çizgidir. Çizginin tek noktasını değiştirmek, komut tipini, zamanlamasını veya koleksiyondaki konumunu değiştirmeden hedefini değiştirir. Komut mutlak koordinatlar kullandığından, yeni çift bir ek ofset yerine bir konum belirler.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion-endpoint.pptx` içindeki çizgi (0.4,0.1)’de sona erer; orijinal dosya değişmemiştir.

### **Bir Segmenti Değiştirme**

`motion.pptx` içindeki çizgiyi değiştirmek için [insert] ve [removeAt] kullanın. Ekleme, eski çizgiyi indeks 2’ye kaydırır.

Bu, mevcut koordinatları düzenlemek yerine bir komut nesnesini değiştirmenin örneğidir. Eklemeden sonra koleksiyon geçici olarak başlangıç komutu, yeni çizgi, eski çizgi ve end komutunu içerir. İndeks 2’yi kaldırmak eski çizgiyi atar ve yeni rotayı yerde bırakır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kaydedilen yol hâlâ üç komuta sahiptir; yeni çizgi (0.2,0.1)’de sona erer ve end komutu en son sıradadır.

## **Mevcut Bir Davranışı Değiştirme ve Doğrulama**

Behavının indeksi bilinmediğinde, tipine göre seçin. Bu örnek `rotation.pptx` dosyasını açar, [RotationEffect] bulunur, açıyı değiştirir ve yeniden açtıktan sonra kaydedilen değeri kontrol eder.

Tip kontrolü, döngünün döndürme olmayan davranışları atlamasını sağlar. İkinci yükleme, kaydedilen dosyayı ayrı bir sunum nesnesine okur; böylece karşılaştırma bellekteki değeri değil, kalıcı veriyi kontrol eder. Bu örnek, bilinen etkinin ana sekansın ilkinde olduğunu varsayar; tipine göre davranış seçmek, rastgele bir sunumda doğru efekti bulmayı garanti etmez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Çıktı `Rotation preserved: True` olur. Aynı tip kontrol desenini diğer davranışlara da uygulayın. Tam bir koruma kontrolü için hedef şekli, efekti, davranış tiplerini ve sırasını, zamanlamayı ve yol komutlarını karşılaştırın. Ondalıklı değerler için sayısal bir tolerans kullanın. Animasyon düzeni bilinmeyen bir sunum için, ana ve etkileşimli sekansların gezintisi hakkında [Read Shape Animations](/slides/tr/python-java/shape-animation/#read-shape-animations) bölümüne bakın.

## **Davranış Sırası, Ön Ayarlar ve Oynatma**

[BehaviorCollection] içindeki sıra, bir efektin işlemlerinin depolanan sırasıdır. Önceki davranışı otomatik olarak bekleyen bir çalma listesi değildir. Zamanlama ve kapsayan efekt planlamayı belirler. Davranışlar çakışabilir ve aynı özelliğe yönelik işlemler [getAdditive] ve [getAccumulate] aracılığıyla etkileşebilir. “Taşı, ardından döndür” gibi bir sıralamayı yalnızca koleksiyon sırasını değiştirerek sağlamayın; açık zamanlama veya ayrı etkileri, [Shape Animation] bölümünde açıklandığı gibi kullanın.

Efektin [getType] ve [getSubtype] ön ayarını tanımlar. Bu, düzenlenmiş bir davranış ağacının tam bir açıklaması değildir. Özelleştirilmiş davranışları özelleştirmeden önce ön ayar ve alt türü seçin: ön ayarı değiştirerek koleksiyon yeniden oluşturulabilir ve özel işlemleriniz silinebilir. Örneğin, özelleştirilmiş bir Spin efektini Fade’a değiştirmek, döndürme davranışını set ve filter davranışlarıyla değiştirir. Bir ön ayar veya alt tür değiştirildikten sonra koleksiyonu yeniden inceleyin. Ön ayar davranışlarını temizlemek, ön ayarın ihtiyaç duyduğu görünürlük veya başlatma işlemlerini de kaldırabilir. Örnekler, görünür şekiller kullanır ve davranışları değiştirir; her ön ayarın tüm uygulamasını yeniden oluşturmaz.

## **Biçim Uyumluluğu**

Korunan bir davranış ağacı, her görüntüleyicide veya dışa aktarma render'ında aynı oynatımı garantilemez. Kaydedilen veriyi ve işlenen çıktıyı ayrı ayrı kontrol edin.

| Biçim veya çıktı | Ne kontrol edilmeli |
| --- | --- |
| PPTX | Bu örneklerde birincil biçim olarak kullanın. Düzenlenebilir davranış ağacını doğrulamak için yeniden açın, ardından hedef PowerPoint sürümünde oynatımı kontrol edin. |
| PPT | Eski ikili temsili PPTX’ten farklı olabilir. Ayrı bir kaydet‑aç‑yeniden oynatma döngüsü ve oynatımı test edin; başarılı PPTX çıktısından tüm özel kombinasyonların desteklendiğini çıkarım yapmayın. |
| PDF, PNG, JPEG ve diğer statik slayt görüntüleri | Statik slayt temsili içerir, oynatılabilir bir davranış zaman çizelgesi veya garantili son animasyon çerçevesi yoktur. |
| [HTML5](/slides/tr/python-java/export-to-html5/) | Dışa aktarma seçeneklerinde şekil animasyonu etkinleştirildiğinde desteklenen animasyonları oynatabilir. Tarayıcıda özel kombinasyonları test edin. |
| [Animated GIF](/slides/tr/python-java/convert-powerpoint-to-animated-gif/) | İşlenmiş kareleri saklar, düzenlenebilir davranışları veya tıklama tetiklemeli etkileşimi içermez. Gerçek render edilen hareketi kontrol edin. |
| [Video](/slides/tr/python-java/convert-powerpoint-to-video/) | Animasyon karelerini render eder ve videoya kodlar. Destek, render’ın [supported animations and effects](/slides/tr/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) ile sınırlıdır; komutlar ve etkileşimli olaylar düzenlenebilir zaman çizelgesi haline gelmez. |

## **SSS**

**Neden bir efektim, herhangi bir şey eklemeden önce davranışlar içeriyor?**  
Öntanımlı bir efekt oluşturmak, temel işlemlerini yaratabilir. Ön ayarı genişletmek mi yoksa davranışlarını değiştirmek mi istediğinize karar vermeden önce bunları inceleyin.

**Bir davranışı başa taşımak onu ilk oynatır mı?**  
Mutlaka olmaz. Koleksiyon sırası zamanlamanın yerini tutmaz. Gecikmeleri, süreleri ve aynı özelliğe yönelik işlemlerin etkileşimini kontrol edin.

**Neden bir end komutunun noktaları yok?**  
Bu, yolun sonunu işaret eder ve koordinat gerektirmez. Bir dosyadan okunan yolu incelerken null bir nokta dizisi olup olmadığını kontrol edin.

**Başarılı bir döngü (save‑open) oynatımı onaylamak için yeterli mi?**  
Hayır. Yeniden açmak, kontrol ettiğiniz özelliklerin korunup korunmadığını teyit eder. Görsel davranışını doğrulamak için slayt gösterisi oynatıcısını veya animasyonlu dışa aktarmayı ayrı ayrı test edin.