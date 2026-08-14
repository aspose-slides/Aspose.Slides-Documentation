---
title: Python ile Sunumlarda Şekil Animasyonlarını Uygula
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/python-net/shape-animation/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile şekil animasyonlarını, zamanlamayı, sesleri, animasyon sonrası davranışı ve animasyonlu metni ekleme, inceleme ve özelleştirme konusunda bilgi edinin."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, slayt animasyonlarını bir slayt zaman çizelgesindeki efektler olarak temsil eder. Bir efektin hedef şekli, bir animasyon türü ve alt türü, bir tetikleyicisi, zamanlama ayarları ve ses veya animasyon sonrası davranış gibi isteğe bağlı özellikleri vardır.

Zaman çizelgesi iki tür dizi içerir:

- **Ana dizi** slayt ilerledikçe oynatılır.
- **Etkileşimli dizi**, tetikleyici şekli tıklandığında başlar.

Metin kutuları, resimler, grafikler, tablolar ve diğer slayt nesneleri [IShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ishape/) uyguladığından, çoğu slayt içeriği için aynı [Sequence.add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) yöntemini kullanırsınız. Mevcut efektler [EffectType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttype/) enumerable'ında listelenir.

## **Şekil Animasyonları Ekle**

Bir animasyon eklemek için slaytın ana dizisini alın ve [Sequence.add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) metodunu hedef şekil, efekt türü, alt tür ve tetikleyiciyle çağırın. Başka bir şekil tıklandığında başlayan bir efekt için, tetikleyicisi o diğer şekil olan bir etkileşimli dizi oluşturun.

Aşağıdaki örnek her iki tür animasyonu oluşturur ve sonucu `shape-animations.pptx` dosyasına kaydeder.

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

Tetikleyici, bir efektin ne zaman başlayacağını kontrol eder:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttriggertype/) ana dizide bir tıklama ya da etkileşimli dizide tetikleyici şekle bir tıklama bekler.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttriggertype/) önceki efektle birlikte başlar.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effecttriggertype/) önceki efekt bittiğinde başlar.

Bir resmi, grafiği veya başka bir şekil türünü animasyonlamak için, `target_shape` yerine o nesneyi [Sequence.add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) metoduna aktarın. Grafiklere özgü gruplama seçenekleri için [Animated Charts](/slides/tr/python-net/animated-charts/) bölümüne bakın.

## **Şekil Animasyonlarını Oku**

Hedef şekli bildiğinizde [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) kullanın. Her bir efekti incelemek için ana dizi ve tüm etkileşimli dizileri döngüyle gezinin. Döngü, bir dizinin `0` indeksinde bir efekt olduğu varsayımını önler.

Aşağıdaki örnek, ana-dizi ve etkileşimli efektlere sahip bir şekil oluşturur, şekli hedefleyen efektleri alır ve ardından slayttaki her diziyi döngüyle gezerek inceler.

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

Yalnızca tek bir şeklin efektlerine ihtiyacınız varsa, önce şekli ad, yer tutucu türü veya başka bir sabit özellik ile tanımlayın; ardından [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) çağırın. `0` indeksindeki şeklin her zaman istenen nesne olduğunu varsaymayın.

## **Kalıtımlı Yer Tutucu Efektleriyle Çalışma**

Normal bir slayttaki yer tutucu, düzen slaytı ve ana slayt üzerindeki karşılık gelen yer tutucudan animasyon davranışını devralabilir. [Shape.get_base_placeholder](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_base_placeholder/) bu üst yer tutucusunu döndürür; üst yoksa `None` döner.

Aşağıdaki örnek sunumda, altbilgi normal slaytta **Random Bars**, düzen slaytta **Split** ve ana slaytta **Fly In** efektine sahiptir.

![Normal slayttaki altbilgi animasyon efekti](slide-shape-animation.png)

![Düzen slayttaki altbilgi yer tutucu animasyon efekti](layout-shape-animation.png)

![Ana slayttaki altbilgi yer tutucu animasyon efekti](master-shape-animation.png)

Sonraki örnek, yer tutucu hiyerarşisini kendisi oluşturur. Bir ana yer tutucu, bir düzen yer tutucu ve normal bir slayttaki karşılık gelen yer tutucuya efektler ekler. Döndürülen şekil kullanılmadan önce her [Shape.get_base_placeholder](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_base_placeholder/) çağrısı kontrol edilir.

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

## **Animasyon Zamanlamasını Değiştir**

PowerPoint **Timing** (Zamanlama) iletişim kutusu, [Timing](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/) özelliklerine eşlenir.

![Bir animasyon efekti için PowerPoint Zamanlama iletişim kutusu](shape-animation.png)

- **Başlat** [Timing.trigger_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/trigger_type/) eşlenir.
- **Süre** [Timing.duration](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/duration/) eşlenir, saniye cinsinden.
- **Gecikme** [Timing.trigger_delay_time](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/trigger_delay_time/) eşlenir, saniye cinsinden.
- **Tekrarlama** [Timing.repeat_count](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_until_next_click/), veya [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) eşlenir.
- **Oynatma bittiğinde geri sar** [Timing.rewind](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/rewind/) eşlenir.

Bu bağımsız örnek bir efekt ekler, zamanlamasını [Sequence.add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) tarafından döndürülen nesne aracılığıyla değiştirir ve sonucu kaydeder. Döndürülen [Effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/) referansını tutmak, gereksiz bir koleksiyon indeksinden kaçınır.

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

Tek bir tekrar modunu amaçlı olarak kullanın. Tekrar sayısını bir “until” bayrağıyla birleştirmek, farklı görüntüleyicilerde kafa karıştırıcı sonuçlar üretebilir. Tekrar modlarını değiştirirken, [Timing.repeat_until_next_click](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_until_next_click/) ve [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) ayarlarını [Timing.repeat_count](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/timing/repeat_count/) öncesinde yapın; çünkü bu bayraklardan birini ayarlamak aynı zamanda aktif tekrar modunu değiştirir.

## **Animasyon Seslerini Ekle ve Çıkar**

Bir animasyon efekti, gömülü sesleri [Effect.sound](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/sound/) aracılığıyla referans alabilir. [Effect.stop_previous_sound](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/stop_previous_sound/) bir efekti, önceki bir efekt tarafından başlatılan sesi durdurması için söyler.

### **Bir Efekte Ses Ekle**

Aşağıdaki örnek, `animation-sound.wav` adlı yerel bir ses dosyası bekler. İki efekt oluşturur, bu dosyayı birinci efektin sesi olarak gömer ve ikinci efekti sesi durduracak şekilde yapılandırır. [Sequence.add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) tarafından döndürülen nesneleri kullandığı için bir dizi indeksi gerekmez.

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

### **Gömülü Efekt Seslerini Çıkar**

Aşağıdaki örnek, `presentation-with-animation-sounds.pptx` adlı yerel bir sunum bekler. Hem ana hem de etkileşimli dizileri tarar ve her gömülü efekt sesini `extracted-animation-sounds` dizinine yazar. Uzantı, [Audio.content_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audio/content_type/) tarafından sağlanan ses MIME tipinden seçilir.

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

Büyük ses nesneleri için, nesneyi bir bayt dizisine yüklemek yerine [Audio.get_stream](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audio/get_stream/) kullanın ve akışı bir dosyaya kopyalayın.

## **Animasyon Sonrası Davranışı Ayarla**

**After animation** (Animasyon Sonrası) seçeneği, bir şeklin efekti bittiğinde ne olacağını kontrol eder.

![PowerPoint Efekt Seçenekleri iletişim kutusu, Animasyon Sonrası ayarlarını gösterir](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/afteranimationtype/) enum'ı, şekli aynı bırakmayı, rengini değiştirmeyi, animasyon sonrası gizlemeyi veya bir sonraki tıklamada gizlemeyi destekler. Tür [AfterAnimationType.COLOR] ise, ayrıca [Effect.after_animation_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/after_animation_color/) ayarlanmalıdır.

Bu bağımsız örnek bir efekt oluşturur, döndürülen efekt nesnesi aracılığıyla animasyon sonrası davranışını ayarlar ve sonucu kaydeder.

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

[AfterAnimationType.COLOR] dışına bir tür değiştirildiğinde, animasyon sonrası renk ayarı temizlenir.

## **Metni Animasyonla**

Metin animasyonu iki ilgili kontrole sahiptir:

- [TextAnimation.build_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/textanimation/build_type/) paragrafın birlikte mi yoksa paragraf düzeyinde mi görüneceğini kontrol eder.
- [Effect.animate_text_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/animate_text_type/) metnin bir kerede mi, kelime kelime mi yoksa harf harf mi görüneceğini belirler. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/effect/delay_between_text_parts/) kelimeler veya harfler arasındaki gecikmeyi ayarlar. Pozitif değer, efekt süresinin yüzdesi; negatif değer ise saniye cinsinden gecikmedir.

Aşağıdaki bağımsız örnek bir metin kutusundaki kelimeleri animasyonlar. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/buildtype/) paragraf‑paragraf oluşturmayı devre dışı bırakır, böylece kelime ayarı tüm metin çerçevesine uygulanır.

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

Bir metin kutusunu paragraf bazında oluşturmak için [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/buildtype/) (veya başka bir paragraf seviyesi) ayarlayın. Tek bir paragrafı kendi efektiyle hedeflemek için, bir [IParagraph] kabul eden [Sequence.add_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.animation/sequence/add_effect/) aşırı yüklemesini kullanın. Paragraf‑seviye örnekleri için [Animated Text](/slides/tr/python-net/animated-text/) bölümüne bakın.

## **Dışa Aktarma ve Uyumluluk Notları**

- PPT veya PPTX olarak kaydetmek animasyon modelini korur, ancak nihai oynatma sunum görüntüleyicisi tarafından kontrol edilir.
- PDF ve statik görseller animasyonları oynatmaz. Çıktının hareket göstermesi gerektiğinde [HTML5 export](/slides/tr/python-net/export-to-html5/), animasyonlu GIF veya [video conversion](/slides/tr/python-net/convert-powerpoint-to-video/) kullanın.
- HTML5 için, [Html5Options.animate_shapes](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/html5options/animate_shapes/) etkinleştirin ve gerektiğinde [Html5Options.animate_transitions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/html5options/animate_transitions/) ayarlayın.
- Video işleme, birçok yaygın giriş, vurgu, çıkış ve hareket yolu efektini destekler, ancak her PowerPoint efekti desteklenmez. Mevcut [supported animations and effects](/slides/tr/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) kontrol edin ve kritik sunumları hedef Aspose.Slides sürümünüzde test edin.
- Gelişmiş özel efektler ve diğer sunum formatlarından içe aktarılan efektler dosyada korunabilir ancak PowerPoint, HTML5 veya video içinde farklı render edilebilir. Yalnızca efekt adına güvenmek yerine dışa aktarılan sonucu doğrulayın.

## **SSS**

**Neden bir animasyon PowerPoint'te görünür ama PDF'de görünmez?**

PDF statik bir formattır, bu yüzden animasyonlar ve slayt geçişleri oynatılmaz. Hareketin korunması gerektiğinde HTML5, animasyonlu GIF veya video olarak dışa aktarın.

**Neden bir efekt video içinde farklı oynatılır?**

Video dışa aktarımı, animasyonları render eder, orijinal PowerPoint davranışını depolamaz. Bazı gelişmiş efektler desteklenmez veya yaklaşık olarak uygulanır. Desteklenen efektler tablosunu inceleyin ve üretim öncesi gerçek sunumu test edin.

**Bir şekli öne veya arkaya taşımak animasyon sırasını değiştirir mi?**

Hayır. Şeklin z-sırası üst üste binmeyi kontrol eder, dizi sırası ve tetikleyiciler animasyon oynatımını kontrol eder. Farklı bir oynatma sırası gerekiyorsa zaman çizelgesini değiştirin.