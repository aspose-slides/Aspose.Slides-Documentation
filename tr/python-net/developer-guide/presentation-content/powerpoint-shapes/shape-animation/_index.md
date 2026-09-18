---
title: Python ile Sunumlarda Şekil Animasyonlarını Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/python-net/shape-animation/
keywords:
- şekil
- animasyon
- etki
- canlandırılmış şekil
- canlandırılmış metin
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile şekil animasyonlarını, zamanlamayı, sesleri, animasyon sonrası davranışı ve canlandırılmış metni ekleme, inceleme ve özelleştirme yöntemlerini öğrenin."
---
## **Genel Bakış**

Bir etki içinde bireysel davranışlarla çalışmak veya hareket yolu segmentlerini düzenlemek için, [Özel Animasyon](/slides/tr/python-net/custom-animation/) sayfasına bakın.

Aspose.Slides for Python via .NET, slayt animasyonlarını bir slayt zaman çizelgesindeki etkiler olarak temsil eder. Bir etki, hedef şekil, bir animasyon türü ve alt tür, bir tetikleyici, zamanlama ayarları ve ses ya da animasyon sonrası davranış gibi isteğe bağlı özelliklere sahiptir.

Zaman çizelgesi iki tür sıra içerir:

- **Ana sıra**, slayt ilerledikçe oynatılır.
- **Etkileşimli sıra**, tetikleyici şekli tıklandığında başlar.

Metin kutuları, resimler, grafikler, tablolar ve diğer slayt nesneleri [IShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ishape/) uygular, bu nedenle çoğu slayt içeriği için aynı [Sequence.add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) yöntemini kullanırsınız. Kullanılabilir etkiler [EffectType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttype/) sayımında listelenir.

## **Şekil Animasyonları Ekleme**

Bir animasyon eklemek için slaytın ana sırasını alın ve hedef şekil, etki türü, alt tür ve tetikleyici ile [Sequence.add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) yöntemini çağırın. Başka bir şekil tıklandığında başlayan bir etki için, tetikleyicisi o diğer şekil olan bir etkileşimli sıra oluşturun.

Aşağıdaki örnek her iki animasyon türünü oluşturur ve sonucu `shape-animations.pptx` dosyasına kaydeder.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

Tetikleyici, bir etkinin ne zaman başlayacağını kontrol eder:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttriggertype/) ana sırada bir tıklamayı veya etkileşimli sırada tetikleyici şeklin tıklanmasını bekler.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttriggertype/) önceki etkinin aynı anda başlamasını sağlar.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttriggertype/) önceki etkinin bitmesiyle başlamasını sağlar.

Bir resmi, grafiği ya da başka bir şekil türünü canlandırmak için, `target_shape` yerine o nesneyi [Sequence.add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) metoduna geçirin. Grafik‑özel gruplama seçenekleri için [Canlandırılmış Grafikler](/slides/tr/python-net/animated-charts/) bölümüne bakın.

## **Şekil Animasyonlarını Okuma**

Hedef şekli bildiğinizde [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) yöntemini kullanın. Tüm etkileri incelemek için ana sıra ve her etkileşimli sırayı yineleyin. İterasyon, bir sıranın `0` indeksinde bir etkinin olduğunu varsaymaktan kaçınır.

Aşağıdaki örnek bir şekil oluşturur, ana‑sıra ve etkileşimli etkiler ekler, şekli hedefleyen etkileri alır ve ardından slayttaki her sırayı iterasyonla dolaşır.

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

Yalnızca tek bir şekil için etkiler gerekiyorsa, önce şekli ad, yer tutucu türü ya da başka bir sabit özellik ile tanımlayın; ardından [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) yöntemini çağırın. `0` indeksindeki şeklin her zaman hedef nesne olduğunu varsamaktan kaçının.

## **Kalıtılmış Yer Tutucu Etkileriyle Çalışma**

Normal bir slayttaki bir yer tutucu, düzen slaytı ve ana slayttaki karşılık gelen yer tutucudan animasyon davranışı miras alabilir. [Shape.get_base_placeholder](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_base_placeholder/) bu üst yer tutucuyu döndürür; üst yoksa `None` döner.

Aşağıdaki örnek sunumda, alt bilgi normal slaytta **Rastgele Çubuklar**, düzen slaytta **Bölme**, ana slaytta ise **Uçuş** etkisine sahiptir.

![Normal slayttaki alt bilgi animasyon etkisi](slide-shape-animation.png)

![Düzen slayttaki alt bilgi yer tutucu animasyon etkisi](layout-shape-animation.png)

![Ana slayttaki alt bilgi yer tutucu animasyon etkisi](master-shape-animation.png)

Sonraki örnek yer tutucu hiyerarşisini kendisi oluşturur. Bir ana yer tutucu, bir düzen yer tutucu ve normal slayttaki karşılık gelen yer tutucuya etkiler ekler. Her [Shape.get_base_placeholder](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_base_placeholder/) çağrısı, döndürülen şekil kullanılmadan önce kontrol edilir.

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **Animasyon Zamanlamasını Değiştirme**

PowerPoint **Timing** iletişim kutusu, [Timing](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/) özelliklerine karşılık gelir.

![Bir animasyon etkisi için PowerPoint Zamanlama iletişim kutusu](shape-animation.png)

- **Start** → [Timing.trigger_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/trigger_type/).
- **Duration** → [Timing.duration](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/duration/), saniye cinsinden.
- **Delay** → [Timing.trigger_delay_time](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/trigger_delay_time/), saniye cinsinden.
- **Repeat** → [Timing.repeat_count](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_until_next_click/) veya [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Rewind when done playing** → [Timing.rewind](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/rewind/).

Bu bağımsız örnek bir etki ekler, zamanlamasını [Sequence.add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) tarafından döndürülen nesne aracılığıyla değiştirir ve sonucu kaydeder. Döndürülen [Effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/) referansını tutmak gereksiz bir koleksiyon indeksinden kaçınır.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

Tek bir tekrar modunu bilinçli olarak kullanın. Tekrar sayısını bir “kadar” bayrağıyla birleştirmek farklı görüntüleyicilerde kafa karıştırıcı sonuçlar doğurabilir. Tekrar modlarını değiştirirken, önce [Timing.repeat_until_next_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_until_next_click/) ve [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) ayarlayın, ardından [Timing.repeat_count](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_count/) ayarlayın; çünkü bu bayrakların ayarlanması aktif tekrar modunu da değiştirir.

## **Animasyon Seslerini Ekleme ve Çıkarma**

Bir animasyon etkisi, gömülü ses dosyasına [Effect.sound](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/sound/) aracılığıyla başvurabilir. [Effect.stop_previous_sound](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/stop_previous_sound/) bir etkinin, önceki bir etkinin başlattığı sesi durdurmasını söyler.

### **Bir Etkiye Ses Ekleme**

Aşağıdaki örnek, `animation-sound.wav` adlı yerel bir ses dosyası bekler. İki etki oluşturur, bu dosyayı ilk etki için ses olarak gömer ve ikinci etkinin sesi durdurmasını yapılandırır. [Sequence.add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) tarafından döndürülen nesneler kullanıldığı için sıra indeksi gerekmez.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **Gömülü Etki Seslerini Çıkarma**

Aşağıdaki örnek, `presentation-with-animation-sounds.pptx` adlı yerel bir sunum bekler. Hem ana hem de etkileşimli sıraları tarar ve tüm gömülü etki seslerini `extracted-animation-sounds` dizinine yazar. Uzantı, [Audio.content_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audio/content_type/) tarafından sağlanan ses MIME tipinden seçilir.

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

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
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

Büyük ses nesneleri için, bütün nesneyi bayt dizisine yüklemek yerine [Audio.get_stream](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audio/get_stream/) kullanıp akışı bir dosyaya kopyayın.

## **Animasyon Sonrası Davranışı Ayarlama**

**After animation** seçeneği, bir şeklin etkisi bittiğinde ne olacağını belirler.

![PowerPoint Etki Seçenekleri iletişim kutusunda After animation ayarları gösteriliyor](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/afteranimationtype/) sayımı, şekli değişmeden bırakma, rengini değiştirme, animasyondan sonra gizleme ya da bir sonraki tıklamada gizleme seçeneklerini destekler. Tür [AfterAnimationType.COLOR](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/afteranimationtype/) ise, ayrıca [Effect.after_animation_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/after_animation_color/) ayarlanmalıdır.

Bu bağımsız örnek bir etki oluşturur, döndürülen etki nesnesi üzerinden animasyon‑sonrası davranışı ayarlar ve sonucu kaydeder.

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

[AfterAnimationType.COLOR](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/afteranimationtype/) dışına başka bir tipe geçmek, animasyon‑sonrası renk ayarını temizler.

## **Metni Canlandırma**

Metin animasyonu iki ilgili kontrol içerir:

- [TextAnimation.build_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/textanimation/build_type/) paragraf düzeyinde mi yoksa tek bir nesne olarak mı görüneceğini kontrol eder.
- [Effect.animate_text_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/animate_text_type/) metnin bir kerede, kelime kelime ya da harf harf görünmesini kontrol eder. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/delay_between_text_parts/) kelimeler ya da harfler arasındaki gecikmeyi ayarlar. Pozitif değer, etkinin süresinin yüzdesi; negatif değer ise saniye cinsinden gecikmedir.

Aşağıdaki bağımsız örnek bir metin kutusundaki kelimeleri canlandırır. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/buildtype/) paragraf‑paragraf oluşturmayı devre dışı bırakır, böylece kelime ayarı tüm metin çerçevesine uygulanır.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

Metin kutusunu paragraf bazında oluşturmak için [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/buildtype/) (veya başka bir paragraf seviyesi) ayarlayın. Tek bir paragrafı kendi etkisiyle hedeflemek için, bir [IParagraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iparagraph/) kabul eden [Sequence.add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) aşırı yüklemesini kullanın. Paragraf‑seviyeli örnekler için [Canlandırılmış Metin](/slides/tr/python-net/animated-text/) bölümüne bakın.

## **Dışa Aktarma ve Uyumluluk Notları**

- PPT veya PPTX olarak kaydetmek animasyon modelini korur, ancak nihai oynatma sunum görüntüleyicisi tarafından kontrol edilir.
- PDF ve sabit görüntüler animasyonları oynatmaz. Çıkışın hareket göstermesi gerekiyorsa [HTML5 dışa aktarma](/slides/tr/python-net/export-to-html5/), canlandırılmış GIF ya da [video dönüşümü](/slides/tr/python-net/convert-powerpoint-to-video/) kullanın.
- HTML5 için, gerektiğinde [Html5Options.animate_shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/html5options/animate_shapes/) ve [Html5Options.animate_transitions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/html5options/animate_transitions/) etkinleştirin.
- Video işleme, birçok yaygın giriş, vurgu, çıkış ve hareket yolu etkisini destekler, ancak her PowerPoint etkisi desteklenmez. Mevcut [desteklenen animasyonlar ve etkiler](/slides/tr/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) sayfasını kontrol edin ve kritik sunumları hedef Aspose.Slides sürümünüzle test edin.
- Özel etkiler ve diğer sunum formatlarından içe aktarılan etkiler dosyada korunabilir, ancak PowerPoint, HTML5 veya videoda farklı şekilde işlenebilir. Etki adının yalnızca güvenilmesi yerine dışa aktarılan sonucu doğrulayın.

## **SSS**

**Bir animasyon PowerPoint’te görünürken PDF’te neden görünmüyor?**

PDF statik bir formattır, bu yüzden animasyonlar ve slayt geçişleri oynatılmaz. Hareketin korunması gerektiğinde HTML5, canlandırılmış GIF veya video olarak dışa aktarın.

**Bir etki video içinde farklı nasıl oynatılıyor?**

Video dışa aktarma, animasyonları render eder, orijinal PowerPoint davranışını saklamaz. Bazı gelişmiş etkiler desteklenmez veya tahmini olarak işlenir. Desteklenen‑etkiler tablosunu inceleyin ve üretim öncesi gerçek sunumu test edin.

**Bir şekli öne ya da geriye taşımak animasyon sırasını değiştirir mi?**

Hayır. Şeklin z‑order’ı üst üste binmeyi kontrol eder, sıra düzeni ve tetikleyiciler animasyon oynatımını kontrol eder. Farklı bir oynatma sırası gerekiyorsa zaman çizelgesini değiştirin.