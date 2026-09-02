---
title: Menerapkan Animasi Bentuk dalam Presentasi dengan Python
linktitle: Animasi Bentuk
type: docs
weight: 60
url: /id/python-net/shape-animation/
keywords:
- bentuk
- animasi
- efek
- bentuk teranimasi
- teks teranimasi
- tambahkan animasi
- dapatkan animasi
- ekstrak animasi
- tambahkan efek
- dapatkan efek
- ekstrak efek
- suara efek
- terapkan animasi
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menambahkan, memeriksa, dan menyesuaikan animasi bentuk, penjadwalan, suara, perilaku setelah animasi, dan teks teranimasi dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Aspose.Slides for Python via .NET merepresentasikan animasi slide sebagai efek dalam timeline slide. Sebuah efek memiliki bentuk target, tipe animasi dan subtipe, pemicu, pengaturan waktu, dan properti opsional seperti suara atau perilaku setelah animasi.

Timeline berisi dua jenis urutan:

- Urutan **utama** diputar saat slide maju.
- Urutan **interaktif** dimulai ketika bentuk pemicunya diklik.

Karena kotak teks, gambar, diagram, tabel, dan objek slide lainnya mengimplementasikan [IShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/ishape/), Anda menggunakan metode [Sequence.add_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/sequence/add_effect/) yang sama untuk sebagian besar konten slide. Efek yang tersedia tercantum dalam enumerasi [EffectType](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effecttype/).

## **Menambahkan Animasi Bentuk**

Untuk menambahkan animasi, dapatkan urutan utama slide dan panggil [Sequence.add_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/sequence/add_effect/) dengan bentuk target, tipe efek, subtipe, dan pemicu. Untuk efek yang dimulai ketika bentuk lain diklik, buat urutan interaktif dengan pemicu berupa bentuk lain tersebut.

Contoh berikut membuat kedua jenis animasi dan menyimpan hasilnya ke `shape-animations.pptx`.

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

Pemicu mengontrol kapan sebuah efek dimulai:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effecttriggertype/) menunggu klik dalam urutan utama, atau klik pada bentuk pemicu dalam urutan interaktif.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effecttriggertype/) dimulai bersamaan dengan efek sebelumnya.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effecttriggertype/) dimulai ketika efek sebelumnya selesai.

Untuk menganimasikan gambar, diagram, atau tipe bentuk lainnya, berikan objek tersebut ke [Sequence.add_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/sequence/add_effect/) alih-alih `target_shape`. Untuk opsi pengelompokan khusus diagram, lihat [Diagram Teranimasi](/slides/id/python-net/animated-charts/).

## **Membaca Animasi Bentuk**

Gunakan [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) ketika Anda mengetahui bentuk target. Untuk memeriksa setiap efek, iterasikan melalui urutan utama dan setiap urutan interaktif. Iterasi menghindari asumsi bahwa sebuah urutan berisi efek pada indeks `0`.

Contoh berikut membuat sebuah bentuk dengan efek urutan-utama dan interaktif, mendapatkan efek yang menargetkan bentuk tersebut, dan kemudian mengiterasi setiap urutan pada slide.

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

Jika Anda hanya memerlukan efek untuk satu bentuk, pertama identifikasi bentuk tersebut berdasarkan nama, tipe placeholder, atau properti stabil lainnya; kemudian panggil [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/sequence/get_effects_by_shape/). Jangan mengasumsikan bahwa bentuk pada indeks `0` selalu merupakan objek yang dimaksud.

## **Bekerja dengan Efek Placeholder yang Dwarisi**

Sebuah placeholder pada slide normal dapat mewarisi perilaku animasi dari placeholder yang bersesuaian pada slide tata letak dan slide master. [Shape.get_base_placeholder](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_base_placeholder/) mengembalikan placeholder induk tersebut, atau `None` bila tidak ada induk.

Dalam presentasi contoh berikut, footer memiliki **Random Bars** pada slide normal, **Split** pada slide tata letak, dan **Fly In** pada slide master.

![Efek animasi footer pada slide normal](slide-shape-animation.png)

![Efek animasi placeholder footer pada slide tata letak](layout-shape-animation.png)

![Efek animasi placeholder footer pada slide master](master-shape-animation.png)

Contoh berikut membangun hirarki placeholder itu sendiri. Ia menambahkan efek ke placeholder master, placeholder tata letak, dan placeholder yang bersesuaian pada slide normal. Setiap pemanggilan [Shape.get_base_placeholder](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_base_placeholder/) diperiksa sebelum bentuk yang dikembalikan digunakan.

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

## **Mengubah Waktu Animasi**

Dialog **Timing** PowerPoint memetakan ke properti [Timing](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/).

![Dialog Timing PowerPoint untuk efek animasi](shape-animation.png)

- **Mulai** memetakan ke [Timing.trigger_type](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/trigger_type/).
- **Durasi** memetakan ke [Timing.duration](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/duration/), dalam detik.
- **Delay** memetakan ke [Timing.trigger_delay_time](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/trigger_delay_time/), dalam detik.
- **Ulang** memetakan ke [Timing.repeat_count](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/repeat_until_next_click/), atau [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Putar kembali saat selesai** memetakan ke [Timing.rewind](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/rewind/).

Contoh independen ini menambahkan sebuah efek, mengubah waktunya melalui objek yang dikembalikan oleh [Sequence.add_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/sequence/add_effect/), dan menyimpan hasilnya. Menjaga referensi [Effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effect/) yang dikembalikan menghindari indeks koleksi yang tidak diperlukan.

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

Gunakan satu mode pengulangan dengan sengaja. Menggabungkan hitungan ulang dengan flag "until" dapat menghasilkan hasil yang membingungkan di berbagai penampil. Saat mengubah mode pengulangan, setel [Timing.repeat_until_next_click](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/repeat_until_next_click/) dan [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) sebelum [Timing.repeat_count](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/repeat_count/), karena mengatur salah satu flag juga mengubah mode pengulangan yang aktif.

## **Menambahkan dan Mengekstrak Suara Animasi**

Sebuah efek animasi dapat merujuk audio tersemat melalui [Effect.sound](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effect/sound/). [Effect.stop_previous_sound](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effect/stop_previous_sound/) memberi tahu efek untuk menghentikan audio yang dimulai oleh efek sebelumnya.

### **Menambahkan Suara ke Efek**

Contoh berikut mengharapkan file audio lokal bernama `animation-sound.wav`. Ia membuat dua efek, menyematkan file tersebut sebagai suara untuk efek pertama, dan mengonfigurasi efek kedua untuk menghentikan suara. Ia menggunakan objek yang dikembalikan oleh [Sequence.add_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/sequence/add_effect/), sehingga tidak diperlukan indeks urutan.

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

### **Mengekstrak Suara Efek Tersemat**

Contoh berikut mengharapkan presentasi lokal bernama `presentation-with-animation-sounds.pptx`. Ia memindai kedua urutan utama dan interaktif serta menulis setiap suara efek tersemat ke direktori `extracted-animation-sounds`. Ekstensi dipilih berdasarkan tipe MIME audio yang disediakan oleh [Audio.content_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/audio/content_type/).

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

Untuk objek audio besar, gunakan [Audio.get_stream](https://reference.aspose.com/slides/id/python-net/aspose.slides/audio/get_stream/) dan salin aliran ke file alih-alih memuat seluruh objek ke dalam array byte.

## **Mengatur Perilaku Setelah Animasi**

Pilihan **After animation** mengontrol apa yang terjadi pada sebuah bentuk setelah efeknya selesai.

![Dialog Opsi Efek PowerPoint menampilkan pengaturan After animation](shape-after-animation.png)

Enumerasi [AfterAnimationType](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/afteranimationtype/) mendukung membiarkan bentuk tidak berubah, mengubah warnanya, menyembunyikannya setelah animasi, atau menyembunyikannya pada klik berikutnya. Ketika tipenya adalah [AfterAnimationType.COLOR](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/afteranimationtype/), setel juga [Effect.after_animation_color](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effect/after_animation_color/).

Contoh independen ini membuat sebuah efek, mengatur perilaku after-animation melalui objek efek yang dikembalikan, dan menyimpan hasilnya.

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

Mengubah tipe dari [AfterAnimationType.COLOR](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/afteranimationtype/) akan menghapus pengaturan warna after-animation.

## **Menganimasikan Teks**

Animasi teks memiliki dua kontrol terkait:

- [TextAnimation.build_type](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/textanimation/build_type/) mengontrol apakah paragraf muncul bersamaan atau per tingkat paragraf.
- [Effect.animate_text_type](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effect/animate_text_type/) mengontrol apakah teks muncul sekaligus, per kata, atau per huruf. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effect/delay_between_text_parts/) mengatur jeda antara kata atau huruf. Nilai positif adalah persentase dari durasi efek; nilai negatif adalah jeda dalam detik.

Contoh independen berikut menganimasikan kata-kata dalam kotak teks. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/buildtype/) menonaktifkan pembangunan paragraf-per-paragraf sehingga pengaturan kata berlaku untuk seluruh bingkai teks.

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

Untuk membangun kotak teks per paragraf, setel [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/buildtype/) (atau level paragraf lainnya). Untuk menargetkan satu paragraf dengan efeknya sendiri, gunakan overload [Sequence.add_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/sequence/add_effect/) yang menerima sebuah [IParagraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/iparagraph/). Lihat [Teks Teranimasi](/slides/id/python-net/animated-text/) untuk contoh tingkat paragraf.

## **Catatan Ekspor dan Kompatibilitas**

- Menyimpan ke PPT atau PPTX mempertahankan model animasi, tetapi pemutaran akhir dikendalikan oleh penampil presentasi.
- PDF dan gambar statis tidak memutar animasi. Gunakan [Ekspor HTML5](/slides/id/python-net/export-to-html5/), GIF animasi, atau [konversi video](/slides/id/python-net/convert-powerpoint-to-video/) ketika output harus menampilkan gerakan.
- Untuk HTML5, aktifkan [Html5Options.animate_shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/html5options/animate_shapes/) dan, bila diperlukan, [Html5Options.animate_transitions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/html5options/animate_transitions/).
- Rendering video mendukung banyak efek masuk, penekanan, keluar, dan jalur gerak yang umum, tetapi tidak semua efek PowerPoint didukung. Periksa [animasi dan efek yang didukung](/slides/id/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) saat ini dan uji presentasi penting dengan versi Aspose.Slides target Anda.
- Efek khusus lanjutan dan efek yang diimpor dari format presentasi lain mungkin dipertahankan dalam file tetapi dirender berbeda di PowerPoint, HTML5, atau video. Validasi hasil ekspor daripada hanya mengandalkan nama efek.

## **FAQ**

**Mengapa sebuah animasi muncul di PowerPoint tetapi tidak di PDF?**

PDF adalah format statis, sehingga animasi dan transisi slide tidak diputar. Ekspor ke HTML5, GIF animasi, atau video ketika gerakan harus dipertahankan.

**Mengapa sebuah efek diputar berbeda dalam video?**

Ekspor video merender animasi daripada menyimpan perilaku asli PowerPoint. Beberapa efek lanjutan tidak didukung atau hanya diperkirakan. Tinjau tabel efek yang didukung dan uji presentasi sebenarnya sebelum penggunaan produksi.

**Apakah memindahkan bentuk ke depan atau belakang mengubah urutan animasinya?**

Tidak. Z-order bentuk mengontrol tumpang tindih, sementara urutan urutan dan pemicu mengontrol pemutaran animasi. Ubah timeline jika Anda memerlukan urutan pemutaran yang berbeda.