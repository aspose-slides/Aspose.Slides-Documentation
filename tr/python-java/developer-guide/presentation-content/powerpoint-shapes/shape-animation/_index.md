---
title: Python ile Java Üzerinden Sunumlarda Şekil Animasyonlarını Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/python-java/shape-animation/
keywords:
- şekil
- animasyon
- efekt
- animasyonlu şekil
- animasyonlu metin
- animasyon ekle
- animasyon al
- animasyon çıkar
- efekt ekle
- efekt al
- efekt çıkar
- efekt sesi
- animasyon uygula
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile şekil animasyonlarını, zamanlamayı, sesleri, animasyon sonrası davranışı ve animasyonlu metni ekleme, inceleme ve özelleştirme yöntemlerini öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, slayt animasyonlarını bir slayt zaman çizelgesindeki efektler olarak temsil eder. Bir efekt, hedef şekil, animasyon türü ve alt türü, bir tetikleyici, zamanlama ayarları ve ses veya animasyon sonrası davranış gibi isteğe bağlı özelliklere sahiptir.

Zaman çizelgesi iki tür dizi içerir:

- **ana dizi** slayt ilerledikçe oynatılır.
- **etkileşimli dizi** tetikleyici şekli tıklandığında başlar.

Metin kutuları, resimler, grafikler, tablolar ve diğer slayt nesneleri [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) sınıfından türediği için, çoğu slayt içeriği için aynı [Sequence.addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) yöntemini kullanırsınız. Kullanılabilir efektler [EffectType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effecttype/) sınıfında listelenmiştir.

## **Şekil Animasyonları Ekleme**

Bir animasyon eklemek için slaydın ana dizisini alın ve hedef şekil, efekt türü, alt tür ve tetikleyici ile [Sequence.addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) metodunu çağırın. Başka bir şekil tıklandığında başlayan bir efekt için, tetikleyicisi o diğer şekil olan bir etkileşimli dizi oluşturun.

Aşağıdaki örnek her iki animasyon tipini oluşturur ve sonucu `shape-animations.pptx` dosyasına kaydeder.

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

Tetikleyici, bir efektin ne zaman başlayacağını kontrol eder:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effecttriggertype/#OnClick) ana dizide bir tıklamayı, veya etkileşimli dizide tetikleyici şekli tıklamayı bekler.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effecttriggertype/#WithPrevious) önceki efektle birlikte başlar.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effecttriggertype/#AfterPrevious) önceki efekt tamamlandığında başlar.

Bir resim, grafik veya başka bir şekil türünü animasyonlamak için, `target_shape` yerine o nesneyi [Sequence.addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) metoduna gönderin. Grafiklere özgü grup seçenekleri için [Animated Charts](/slides/tr/python-java/animated-charts/) bölümüne bakın.

## **Şekil Animasyonlarını Okuma**

Hedef şekli bildiğinizde [Sequence.getEffectsByShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#getEffectsByShape) metodunu kullanın. Her bir efekti incelemek için ana diziyi ve tüm etkileşimli dizileri döngüye alın. Dizi içinde bir efektin `0` indeksinde olduğuna varsayımda bulunmaktan kaçının.

Aşağıdaki örnek bir şekil oluşturur, ana dizi ve etkileşimli efektler ekler, şekli hedefleyen efektleri alır ve ardından slayttaki tüm dizileri döngüye alır.

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

Yalnızca bir şekil için efektlere ihtiyacınız varsa, önce şekli ad, yer tutucu türü veya başka bir sabit özellik ile tanımlayın; ardından [Sequence.getEffectsByShape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#getEffectsByShape) metodunu çağırın. [ShapeCollection.get_Item](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#get_Item) metodunun `0` indeksindeki öğesinin her zaman istediğiniz nesne olduğunu varsamamalısınız.

## **Miras Alınan Yer Tutucu Efektleriyle Çalışma**

Normal bir slayttaki bir yer tutucu, düzen slaytı ve ana slayttaki karşılık gelen yer tutucudan animasyon davranışını devralabilir. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getBasePlaceholder) bu üst yer tutucusunu döndürür; hiçbir üst yoksa `None` döner.

Aşağıdaki örnek sunumda, alt bilgi normal slaytta **Random Bars**, düzen slaytta **Split** ve ana slaytta **Fly In** efektine sahiptir.

![Normal slayttaki alt bilgi animasyon efekti](slide-shape-animation.png)

![Düzen slaytındaki alt bilgi yer tutucu animasyon efekti](layout-shape-animation.png)

![Ana slayttaki alt bilgi yer tutucu animasyon efekti](master-shape-animation.png)

Sonraki örnek yeni bir sunumdan bir yer tutucu hiyerarşisi kullanır. Bir ana yer tutucu, bir düzen yer tutucu ve normal slayttaki karşılık gelen yer tutucuya efekt ekler. Her [Shape.getBasePlaceholder](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getBasePlaceholder) çağrısı, döndürülen şekil kullanılmadan önce kontrol edilir.

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

## **Animasyon Zamanlamasını Değiştirme**

PowerPoint **Timing** iletişim kutusu, [Timing](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/) özelliklerine karşılık gelir.

![Bir animasyon efekti için PowerPoint Zamanlama iletişim kutusu](shape-animation.png)

- **Start** [Timing.getTriggerType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getTriggerType) ile eşlenir.
- **Duration** [Timing.getDuration](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getDuration) ile saniye cinsinden eşlenir.
- **Delay** [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getTriggerDelayTime) ile saniye cinsinden eşlenir.
- **Repeat** [Timing.getRepeatCount](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getRepeatUntilNextClick) veya [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) ile eşlenir.
- **Rewind when done playing** [Timing.getRewind](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#getRewind) ile eşlenir.

Bu bağımsız örnek bir efekt ekler, zamanlamasını [Sequence.addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) tarafından döndürülen nesne üzerinden değiştirir ve sonucu kaydeder. Döndürülen [Effect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effect/) referansını tutmak, gereksiz bir dizi indeksinden kaçınır.

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

Tek bir tekrarlama modunu kasten kullanın. Tekrar sayısını bir "until" bayrağı ile birleştirmek, farklı izleyicilerde kafa karıştırıcı sonuçlar üretebilir. Tekrarlama modlarını değiştirirken, önce [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#setRepeatUntilNextClick) ve [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) ayarlayın, ardından [Timing.setRepeatCount](https://reference.aspose.com/slides/tr/python-java/aspose.slides/timing/#setRepeatCount) metodunu çağırın; çünkü bu bayrakların ayarlanması aktif tekrarlama modunu da değiştirir.

## **Animasyon Seslerini Ekleme ve Çıkarma**

Bir animasyon efekti, gömülü ses referansı içerebilir; bu, [Effect.getSound](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effect/#getSound) ile alınır. [Effect.setStopPreviousSound](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effect/#setStopPreviousSound) bir efektin önceki bir efekt tarafından başlatılan sesi durdurmasını sağlar.

### **Bir Efekte Ses Ekleme**

Aşağıdaki örnek, `animation-sound.wav` adlı yerel bir ses dosyası bekler. İki efekt oluşturur, bu dosyayı ilk efektin sesi olarak gömer ve ikinci efektin sesi durdurmasını yapılandırır. [Sequence.addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) tarafından döndürülen nesneler kullanıldığından bir dizi indeksine ihtiyaç yoktur.

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

### **Gömülü Efekt Seslerini Çıkarma**

Aşağıdaki örnek, `presentation-with-animation-sounds.pptx` adlı yerel bir sunum bekler. Hem ana hem de etkileşimli dizileri tarar ve her gömülü efekt sesini `extracted-animation-sounds` dizinine yazar. Uzantı, [Audio.getContentType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audio/#getContentType) tarafından döndürülen ses MIME türünden seçilir.

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

Büyük ses nesneleri için, [Audio.getStream](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audio/#getStream) kullanın ve akışı bir dosyaya kopyalayın; nesneyi bir bayt dizisine tamamen yüklemek yerine.

## **Animasyon Sonrası Davranışı Ayarlama**

**After animation** seçeneği, bir şeklin efekt bitiminde ne olacağını kontrol eder.

![After animation ayarlarını gösteren PowerPoint Efekt Seçenekleri iletişim kutusu](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/afteranimationtype/) sınıfı, şeklin değişmeden bırakılması, renginin değiştirilmesi, animasyondan sonra gizlenmesi veya bir sonraki tıklamada gizlenmesi gibi seçenekleri destekler. Tür [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/python-java/aspose.slides/afteranimationtype/#Color) ise, ayrıca [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effect/#getAfterAnimationColor) ayarlanmalıdır.

Bu bağımsız örnek bir efekt oluşturur, döndürülen efekt nesnesi üzerinden animasyon sonrası davranışı ayarlar ve sonucu kaydeder.

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

[AfterAnimationType.Color](https://reference.aspose.com/slides/tr/python-java/aspose.slides/afteranimationtype/#Color) dışına bir tür değiştirildiğinde, animasyon sonrası renk ayarı temizlenir.

## **Metin Animasyonu**

Metin animasyonunda iki ilgili kontrol bulunur:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textanimation/#getBuildType), paragrafların birlikte mi yoksa paragraf seviyesinde mi görüneceğini denetler.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effect/#getAnimateTextType), metnin bir kerede, kelime bazında veya harf bazında görünmesini denetler. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/tr/python-java/aspose.slides/effect/#getDelayBetweenTextParts), kelimeler veya harfler arasındaki gecikmeyi ayarlar. Pozitif bir değer, efekt süresinin yüzdesi; negatif bir değer saniye cinsinden gecikmedir.

Aşağıdaki bağımsız örnek bir metin kutusundaki kelimeleri animasyonlar. [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/python-java/aspose.slides/buildtype/#AsOneObject), paragraf‑paragraf oluşturmayı devre dışı bırakır, böylece kelime ayarı tüm metin çerçevesine uygulanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

Bir metin kutusunu paragraf bazında oluşturmak için [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/tr/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (veya başka bir paragraf seviyesi) ayarlayın. Tek bir paragrafı kendi efektiyle hedeflemek için, bir [Paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/) kabul eden [Sequence.addEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/sequence/#addEffect) aşırı yüklemesini kullanın. Paragraf‑seviyesi örnekleri için [Animated Text](/slides/tr/python-java/animated-text/) bölümüne bakın.

## **Dışa Aktarma ve Uyumluluk Notları**

- PPT veya PPTX olarak kaydetmek animasyon modelini korur, ancak nihai oynatma sunum görüntüleyicisi tarafından kontrol edilir.
- PDF ve statik görüntüler animasyonları oynatmaz. Çıktının hareket göstermesi gerektiğinde [HTML5 export](/slides/tr/python-java/export-to-html5/), animasyonlu GIF veya [video conversion](/slides/tr/python-java/convert-powerpoint-to-video/) kullanın.
- HTML5 için, [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/tr/python-java/aspose.slides/html5options/#setAnimateShapes) etkinleştirin ve gerektiğinde [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/html5options/#setAnimateTransitions) kullanın.
- Video işleme, birçok yaygın giriş, vurgulama, çıkış ve hareket‑yolu efektini destekler, ancak her PowerPoint efekti desteklenmez. Mevcut [supported animations and effects](/slides/tr/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) sayfasını kontrol edin ve kritik sunumları hedef Aspose.Slides sürümünüzle test edin.
- Gelişmiş özel efektler ve diğer sunum formatlarından içe aktarılan efektler dosyada korunabilir ancak PowerPoint, HTML5 veya video içinde farklı şekilde render edilebilir. Yalnızca efekt adına güvenmek yerine dışa aktarılan sonucu doğrulayın.

## **SSS**

**Bir animasyon PowerPoint'te görünürken PDF'de neden görünmüyor?**

PDF statik bir formattır; bu yüzden animasyonlar ve slayt geçişleri oynatılmaz. Hareketin korunması gerektiğinde HTML5, animasyonlu GIF veya video olarak dışa aktarın.

**Bir efekt video içinde neden farklı oynatılıyor?**

Video dışa aktarımı animasyonları render eder, orijinal PowerPoint davranışını saklamaz. Bazı gelişmiş efektler desteklenmez veya yaklaşık olarak işlenir. Desteklenen efektler tablosunu inceleyin ve üretim öncesi gerçek sunumu test edin.

**Bir şekli öne ya da arkaya taşımak animasyon sırasını değiştirir mi?**

Hayır. Şeklin z‑order'ı üst üste binmeyi kontrol eder, dizi sırası ve tetikleyiciler ise animasyon oynatımını kontrol eder. Farklı bir oynatma sırası gerekiyorsa zaman çizelgesini değiştirin.