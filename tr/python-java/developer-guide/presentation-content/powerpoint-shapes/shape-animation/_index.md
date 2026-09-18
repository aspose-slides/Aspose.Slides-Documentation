---
title: Python via Java kullanarak Sunumlarda Şekil Animasyonlarını Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/python-java/shape-animation/
keywords:
- şekil
- animasyon
- etki
- animasyonlu şekil
- animasyonlu metin
- animasyon ekle
- animasyon al
- animasyon çıkar
- etki ekle
- etki al
- etki çıkar
- etki sesi
- animasyon uygula
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile şekil animasyonlarını, zamanlamayı, sesleri, animasyon sonrası davranışı ve animasyonlu metni nasıl ekleyeceğinizi, inceleyeceğinizi ve özelleştireceğinizi öğrenin."
---
## **Genel Bakış**

Bir etkinin içindeki bireysel davranışlarla çalışmak veya hareket yolu bölümlerini düzenlemek için [Custom Animation](/slides/tr/python-java/custom-animation/) sayfasına bakın.

Aspose.Slides for Python via Java, slayt animasyonlarını bir slayt zaman çizelgesindeki etkiler olarak temsil eder. Bir etki bir hedef şekle, bir animasyon türüne ve alt türüne, bir tetikleyiciye, zamanlama ayarlarına ve isteğe bağlı olarak ses ya da animasyon sonrası davranış gibi özelliklere sahiptir.

Zaman çizelgesi iki tür sıralama içerir:

- **ana sıra**, slayt ilerledikçe çalar.
- **etkileşimli sıra**, tetikleyici şekli tıklandığında başlar.

Metin kutuları, resimler, grafikler, tablolar ve diğer slayt nesneleri [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) sınıfından türediği için, çoğu slayt içeriği için aynı [Sequence.addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) yöntemini kullanırsınız. Kullanılabilir etkiler [EffectType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effecttype/) sınıfında listelenir.

## **Şekil Animasyonlarını Ekle**

Bir animasyon eklemek için slaytın ana sırasını alın ve hedef şekil, etki türü, alt tür ve tetikleyici ile [Sequence.addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) metodunu çağırın. Başka bir şekil tıklandığında başlayan bir etki için, tetikleyicisi o diğer şekil olan bir etkileşimli sıra oluşturun.

Aşağıdaki örnek her iki tür animasyonu oluşturur ve sonucu `shape-animations.pptx` dosyasına kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tetikleyici, bir etkinin ne zaman başlayacağını kontrol eder:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effecttriggertype/#OnClick) ana sırada bir tıklama veya etkileşimli sırada tetikleyici şekle bir tıklama bekler.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effecttriggertype/#WithPrevious) önceki etkinin aynı anda başlamasını sağlar.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effecttriggertype/#AfterPrevious) önceki etkinin bitmesiyle başlamasını sağlar.

Bir resmi, grafiği veya başka bir şekil türünü canlandırmak için `target_shape` yerine o nesneyi [Sequence.addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) metoduna geçirin. Grafik‑özel grup seçenekleri için [Animated Charts](/slides/tr/python-java/animated-charts/) sayfasına bakın.

## **Şekil Animasyonlarını Oku**

Hedef şekli bildiğinizde [Sequence.getEffectsByShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#getEffectsByShape) yöntemini kullanın. Her bir etkinin incelenmesi için ana sırayı ve tüm etkileşimli sıraları döngüyle gezinin. Döngü, bir sıralamanın `0` indeksinde bir etkinin olduğu varsayımını önler.

Aşağıdaki örnek bir şekle ana‑sıra ve etkileşimli efektler ekler, şekli hedefleyen efektleri alır ve ardından slayttaki tüm sıraları döngüyle listeler.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

Sadece bir şekil için efektlere ihtiyacınız varsa, önce şekli ad, yer tutucu türü veya başka bir stabil özellik ile tanımlayın; ardından [Sequence.getEffectsByShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#getEffectsByShape) metodunu çağırın. [ShapeCollection.get_Item](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#get_Item) metodunun `0` indeksindeki öğenin her zaman istediğiniz nesne olduğunu varsaymayın.

## **Miras Alınan Yer Tutucu Efektleriyle Çalışma**

Normal bir slayttaki bir yer tutucu, düzen slaytındaki ve ana slayttaki karşılık gelen yer tutucudan animasyon davranışı miras alabilir. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getBasePlaceholder) bu üst yer tutucuyu döndürür; üst yoksa `None` döner.

Aşağıdaki örnek sunumda altbilgi, normal slaytta **Random Bars**, düzen slaytta **Split**, ana slaytta ise **Fly In** efektine sahiptir.

![Normal slayttaki altbilgi animasyon efekti](slide-shape-animation.png)

![Düzen slayttaki altbilgi yer tutucu animasyon efekti](layout-shape-animation.png)

![Ana slayttaki altbilgi yer tutucu animasyon efekti](master-shape-animation.png)

Sonraki örnek, yeni bir sunumdaki yer tutucu hiyerarşisini kullanır. Ana slayt yer tutucusuna, düzen yer tutucusuna ve normal slayttaki karşılık gelen yer tutucuya efektler ekler. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getBasePlaceholder) çağrısı, döndürülen şekil kullanılmadan önce kontrol edilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animasyon Zamanlamasını Değiştir**

PowerPoint **Timing** iletişim kutusu, [Timing](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/) sınıfının özelliklerine karşılık gelir.

![Bir animasyon etkisi için PowerPoint Zamanlama iletişim kutusu](shape-animation.png)

- **Start** [Timing.getTriggerType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getTriggerType) ile eşleşir.
- **Duration** [Timing.getDuration](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getDuration) ile eşleşir, saniye cinsindendir.
- **Delay** [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getTriggerDelayTime) ile eşleşir, saniye cinsindendir.
- **Repeat** [Timing.getRepeatCount](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getRepeatUntilNextClick) veya [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) ile eşleşir.
- **Rewind when done playing** [Timing.getRewind](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getRewind) ile eşleşir.

Bu bağımsız örnek bir etki ekler, [Sequence.addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) tarafından döndürülen nesneyle zamanlamasını değiştirir ve sonucu kaydeder. Döndürülen [Effect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effect/) referansının tutulması gereksiz bir koleksiyon indeksinden kaçınır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tek bir tekrar modunu kasıtlı olarak kullanın. Bir tekrar sayısını “until” bayrağı ile birleştirmek, farklı izleyicilerde karışık sonuçlar üretebilir. Tekrar modlarını değiştirirken, [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#setRepeatUntilNextClick) ve [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) metodlarını [Timing.setRepeatCount](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#setRepeatCount) çağırmadan önce ayarlayın; çünkü bayrakların ayarlanması aynı zamanda aktif tekrar modunu değiştirir.

## **Animasyon Seslerini Ekle ve Çıkar**

Bir animasyon etkisi, gömülü ses dosyasına [Effect.getSound](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effect/#getSound) aracılığıyla başvurabilir. [Effect.setStopPreviousSound](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effect/#setStopPreviousSound) bir etkinin, önceki bir etkinin başlattığı sesi durdurmasını sağlar.

### **Bir Etkiye Ses Ekle**

Aşağıdaki örnek, `animation-sound.wav` adlı yerel bir ses dosyası bekler. İki etki oluşturur, bu dosyayı birinci etkinin sesi olarak gömer ve ikinci etkinin sesi durdurmasını yapılandırır. [Sequence.addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) tarafından döndürülen nesneler kullanıldığından sıralama indeksi gerekmez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Gömülü Etki Seslerini Çıkar**

Aşağıdaki örnek, `presentation-with-animation-sounds.pptx` adlı yerel bir sunum bekler. Hem ana hem de etkileşimli sıraları tarar ve her gömülü etki sesini `extracted-animation-sounds` klasörüne yazar. Uzantı, [Audio.getContentType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audio/#getContentType) tarafından sağlanan ses MIME türünden seçilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"
    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

Büyük ses nesneleri için, tüm nesneyi bir bayt dizisine yüklemek yerine [Audio.getStream](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audio/#getStream) kullanın ve akışı bir dosyaya kopyalayın.

## **Animasyon Sonrası Davranışı Ayarla**

**After animation** seçeneği, bir şeklin etkisi bittiğinde ne olacağını belirler.

![PowerPoint Etki Seçenekleri iletişim kutusunda After animation ayarlarını gösteren görüntü](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/afteranimationtype/) sınıfı, şekli değiştirmeden bırakma, rengini değiştirme, animasyondan sonra gizleme veya bir sonraki tıklamada gizleme seçeneklerini destekler. Tür [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/python-java/aspose.slides/afteranimationtype/#Color) olduğunda, ayrıca [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effect/#getAfterAnimationColor) ayarlanmalıdır.

Bu bağımsız örnek bir etki oluşturur, döndürülen etki nesnesi aracılığıyla animasyon sonrası davranışı ayarlar ve sonucu kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/tr/python-java/aspose.slides/afteranimationtype/#Color) dışına bir tür seçildiğinde animasyon sonrası renk ayarı temizlenir.

## **Metni Canlandır**

Metin animasyonunda iki ilişkili kontrol bulunur:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textanimation/#getBuildType) paragrafların birlikte mi yoksa paragraf seviyesinde mi görüneceğini denetler.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effect/#getAnimateTextType) metnin tüm olarak, kelime bazında veya harf bazında görünmesini denetler. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effect/#getDelayBetweenTextParts) kelimeler ya da harfler arasındaki gecikmeyi ayarlar. Pozitif değer, etkinin süresinin yüzdesi; negatif değer ise saniye cinsinden gecikmedir.

Aşağıdaki bağımsız örnek, bir metin kutusundaki kelimeleri canlandırır. [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/python-java/aspose.slides/buildtype/#AsOneObject) paragraf‑paragraf oluşturmayı devre dışı bırakır; böylece kelime ayarı tüm metin çerçevesine uygulanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpace.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metin kutusunu paragraf bazında oluşturmak için [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/tr/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (veya başka bir paragraf seviyesi) ayarlayın. Tek bir paragrafı kendi etkisiyle hedeflemek için, bir [Paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) kabul eden [Sequence.addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) aşırı yüklemesini kullanın. Paragraf‑seviyesi örnekler için [Animated Text](/slides/tr/python-java/animated-text/) sayfasına bakın.

## **Dışa Aktarma ve Uyum Notları**

- PPT veya PPTX olarak kaydetmek animasyon modelini korur, ancak nihai oynatma sunum görüntüleyicisi tarafından kontrol edilir.
- PDF ve statik görüntüler animasyonları oynatmaz. Çıktının hareket göstermesi gerektiğinde [HTML5 export](/slides/tr/python-java/export-to-html5/), animasyonlu GIF veya [video conversion](/slides/tr/python-java/convert-powerpoint-to-video/) kullanın.
- HTML5 için, [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/html5options/#setAnimateShapes) etkinleştirin ve gerektiğinde [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/html5options/#setAnimateTransitions) ayarlayın.
- Video işleme, birçok yaygın giriş, vurgu, çıkış ve hareket‑yolu etkisini destekler, ancak her PowerPoint etkisi desteklenmez. Mevcut [supported animations and effects](/slides/tr/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) sayfasını kontrol edin ve kritik sunumları hedef Aspose.Slides sürümünüzle test edin.
- Gelişmiş özel etkiler ve diğer sunum formatlarından içe aktarılan etkiler dosyada korunabilir ancak PowerPoint, HTML5 veya videoda farklı render edilebilir. Yalnızca etki adına dayanmak yerine dışa aktarılan sonucu doğrulayın.

## **SSS**

**Bir animasyon PowerPoint’te görünüyor ama PDF’de neden görünmüyor?**

PDF statik bir formattır; bu nedenle animasyonlar ve slayt geçişleri oynatılmaz. Hareketin korunması gerektiğinde HTML5, animasyonlu GIF veya video olarak dışa aktarın.

**Bir etki video formatında farklı neden oynatılıyor?**

Video dışa aktarımı, animasyonları orijinal PowerPoint davranışı yerine render eder. Bazı gelişmiş etkiler desteklenmez veya yaklaşık olarak uygulanır. Desteklenen etkiler tablosunu inceleyin ve üretime geçmeden önce gerçek sunumu test edin.

**Bir şekli öne ya da arkaya taşıdığınızda animasyon sırası değişir mi?**

Hayır. Şeklin z‑order’ı üst üste gelmeyi kontrol eder, sıralama ve tetikleyiciler ise animasyon oynatımını belirler. Farklı bir oynatma sırası gerekiyorsa zaman çizelgesini değiştirin.