---
title: Terapkan Animasi Bentuk dalam Presentasi Menggunakan Python via Java
linktitle: Animasi Bentuk
type: docs
weight: 60
url: /id/python-java/shape-animation/
keywords:
- bentuk
- animasi
- efek
- bentuk teranimasi
- teks teranimasi
- menambahkan animasi
- mendapatkan animasi
- mengekstrak animasi
- menambahkan efek
- mendapatkan efek
- mengekstrak efek
- suara efek
- menerapkan animasi
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara menambahkan, memeriksa, dan menyesuaikan animasi bentuk, penjadwalan, suara, perilaku setelah animasi, serta teks teranimasi dengan Aspose.Slides untuk Python via Java."
---
## **Ringkasan**

Aspose.Slides for Python via Java merepresentasikan animasi slide sebagai efek dalam timeline slide. Sebuah efek memiliki bentuk target, tipe dan subtipe animasi, pemicu, pengaturan waktu, dan properti opsional seperti suara atau perilaku setelah animasi.

Timeline berisi dua jenis urutan:

- **Urutan utama** diputar saat slide maju.
- **Urutan interaktif** dimulai ketika bentuk pemicunya diklik.

Karena kotak teks, gambar, diagram, tabel, dan objek slide lainnya diturunkan dari [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/), Anda menggunakan metode [Sequence.addEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/sequence/#addEffect) yang sama untuk kebanyakan konten slide. Efek yang tersedia terdaftar dalam kelas [EffectType](https://reference.aspose.com/slides/id/python-java/aspose.slides/effecttype/).

## **Menambahkan Animasi Bentuk**

Untuk menambahkan animasi, dapatkan urutan utama slide dan panggil [Sequence.addEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/sequence/#addEffect) dengan bentuk target, tipe efek, subtipe, dan pemicu. Untuk efek yang dimulai ketika bentuk lain diklik, buat urutan interaktif yang pemicunya adalah bentuk lain tersebut.

Contoh berikut membuat kedua jenis animasi dan menyimpan hasilnya ke `shape-animations.pptx`.

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

Pemicu mengontrol kapan sebuah efek dimulai:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/effecttriggertype/#OnClick) menunggu klik dalam urutan utama, atau klik pada bentuk pemicu dalam urutan interaktif.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/id/python-java/aspose.slides/effecttriggertype/#WithPrevious) memulai bersama efek sebelumnya.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/id/python-java/aspose.slides/effecttriggertype/#AfterPrevious) memulai ketika efek sebelumnya selesai.

Untuk menganimasikan gambar, diagram, atau tipe bentuk lain, berikan objek tersebut ke [Sequence.addEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/sequence/#addEffect) alih-alih `target_shape`. Untuk opsi pengelompokan khusus diagram, lihat [Animated Charts](/slides/id/python-java/animated-charts/).

## **Membaca Animasi Bentuk**

Gunakan [Sequence.getEffectsByShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/sequence/#getEffectsByShape) ketika Anda mengetahui bentuk target. Untuk memeriksa setiap efek, enumerasikan urutan utama dan setiap urutan interaktif. Enumerasi menghindari asumsi bahwa sebuah urutan berisi efek pada indeks `0`.

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

Jika Anda hanya memerlukan efek untuk satu bentuk, pertama identifikasi bentuk tersebut berdasarkan nama, tipe placeholder, atau properti stabil lainnya; kemudian panggil [Sequence.getEffectsByShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/sequence/#getEffectsByShape). Jangan menganggap bahwa [ShapeCollection.get_Item](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#get_Item) pada indeks `0` selalu merupakan objek yang dimaksud.

## **Bekerja dengan Efek Placeholder yang Dwariskan**

Sebuah placeholder pada slide biasa dapat mewarisi perilaku animasi dari placeholder yang bersesuaian pada slide tata letak dan slide master. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getBasePlaceholder) mengembalikan placeholder induk tersebut, atau `None` ketika tidak ada induk.

Pada presentasi contoh berikut, footer memiliki **Random Bars** pada slide biasa, **Split** pada slide tata letak, dan **Fly In** pada slide master.

![Efek animasi footer pada slide biasa](slide-shape-animation.png)

![Efek animasi placeholder footer pada slide tata letak](layout-shape-animation.png)

![Efek animasi placeholder footer pada slide master](master-shape-animation.png)

Contoh berikut menggunakan hierarki placeholder dari presentasi baru. Ia menambahkan efek ke placeholder master, placeholder tata letak, dan placeholder yang bersesuaian pada slide biasa. Setiap pemanggilan [Shape.getBasePlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getBasePlaceholder) diperiksa sebelum bentuk yang dikembalikan digunakan.

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

## **Mengubah Waktu Animasi**

Dialog **Timing** PowerPoint dipetakan ke properti [Timing](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/).

![Dialog Timing PowerPoint untuk efek animasi](shape-animation.png)

- **Mulai** memetakan ke [Timing.getTriggerType](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getTriggerType).
- **Durasi** memetakan ke [Timing.getDuration](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getDuration), dalam detik.
- **Tunda** memetakan ke [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getTriggerDelayTime), dalam detik.
- **Ulang** memetakan ke [Timing.getRepeatCount](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getRepeatUntilNextClick), atau [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Putar ulang saat selesai diputar** memetakan ke [Timing.getRewind](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getRewind).

Contoh independen ini menambahkan sebuah efek, mengubah waktunya melalui objek yang dikembalikan oleh [Sequence.addEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/sequence/#addEffect), dan menyimpan hasilnya. Menyimpan referensi [Effect](https://reference.aspose.com/slides/id/python-java/aspose.slides/effect/) yang dikembalikan menghindari indeks koleksi yang tidak perlu.

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

Gunakan satu mode pengulangan secara sengaja. Menggabungkan jumlah pengulangan dengan flag “until” dapat menghasilkan hasil yang membingungkan pada pemutar yang berbeda. Saat mengubah mode pengulangan, setel [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#setRepeatUntilNextClick) dan [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) sebelum [Timing.setRepeatCount](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#setRepeatCount), karena menyetel salah satu flag juga mengubah mode pengulangan yang aktif.

## **Menambahkan dan Mengekstrak Suara Animasi**

Sebuah efek animasi dapat merujuk audio tersemat melalui [Effect.getSound](https://reference.aspose.com/slides/id/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/id/python-java/aspose.slides/effect/#setStopPreviousSound) memberi tahu efek untuk menghentikan audio yang dimulai oleh efek sebelumnya.

### **Menambahkan Suara ke Efek**

Contoh berikut mengharapkan file audio lokal bernama `animation-sound.wav`. Ia membuat dua efek, menyematkan file tersebut sebagai suara untuk efek pertama, dan mengonfigurasi efek kedua agar menghentikan suara. Ia menggunakan objek yang dikembalikan oleh [Sequence.addEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/sequence/#addEffect), jadi tidak diperlukan indeks urutan.

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

### **Mengekstrak Suara Efek yang Tersemat**

Contoh berikut mengharapkan presentasi lokal bernama `presentation-with-animation-sounds.pptx`. Ia memindai baik urutan utama maupun interaktif dan menulis setiap suara efek tersemat ke direktori `extracted-animation-sounds`. Ekstensi dipilih dari tipe MIME audio yang diungkapkan oleh [Audio.getContentType](https://reference.aspose.com/slides/id/python-java/aspose.slides/audio/#getContentType).

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

Untuk objek audio berukuran besar, gunakan [Audio.getStream](https://reference.aspose.com/slides/id/python-java/aspose.slides/audio/#getStream) dan salin aliran ke file alih-alih memuat seluruh objek ke dalam array byte.

## **Mengatur Perilaku Setelah Animasi**

Opsi **After animation** mengontrol apa yang terjadi pada bentuk setelah efeknya selesai.

![Dialog Opsi Efek PowerPoint yang Menampilkan Pengaturan After animation](shape-after-animation.png)

Kelas [AfterAnimationType](https://reference.aspose.com/slides/id/python-java/aspose.slides/afteranimationtype/) mendukung membiarkan bentuk tidak berubah, mengubah warnanya, menyembunyikannya setelah animasi, atau menyembunyikannya pada klik berikutnya. Ketika tipe adalah [AfterAnimationType.Color](https://reference.aspose.com/slides/id/python-java/aspose.slides/afteranimationtype/#Color), setel juga [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/effect/#getAfterAnimationColor).

Contoh independen ini membuat sebuah efek, menetapkan perilaku setelah animasi melalui objek efek yang dikembalikan, dan menyimpan hasilnya.

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

Mengubah tipe dari [AfterAnimationType.Color](https://reference.aspose.com/slides/id/python-java/aspose.slides/afteranimationtype/#Color) menghapus pengaturan warna after‑animation.

## **Menganimasikan Teks**

Animasi teks memiliki dua kendali terkait:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/id/python-java/aspose.slides/textanimation/#getBuildType) mengontrol apakah paragraf muncul bersamaan atau per tingkat paragraf.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/id/python-java/aspose.slides/effect/#getAnimateTextType) mengontrol apakah teks muncul sekaligus, per kata, atau per huruf. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/id/python-java/aspose.slides/effect/#getDelayBetweenTextParts) mengatur jeda antara kata atau huruf. Nilai positif adalah persentase dari durasi efek; nilai negatif adalah jeda dalam detik.

Contoh independen berikut menganimasikan kata‑kata dalam sebuah kotak teks. [BuildType.AsOneObject](https://reference.aspose.com/slides/id/python-java/aspose.slides/buildtype/#AsOneObject) menonaktifkan pembangunan paragraf‑per‑paragraf sehingga pengaturan kata berlaku untuk seluruh bingkai teks.

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

Untuk membangun kotak teks per paragraf, setel [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/id/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (atau tingkat paragraf lain). Untuk menargetkan satu paragraf dengan efeknya sendiri, gunakan overload [Sequence.addEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/sequence/#addEffect) yang menerima sebuah [Paragraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/). Lihat [Animated Text](/slides/id/python-java/animated-text/) untuk contoh tingkat paragraf.

## **Catatan Ekspor dan Kompatibilitas**

- Menyimpan ke PPT atau PPTX mempertahankan model animasi, tetapi pemutaran akhir dikendalikan oleh penampil presentasi.
- PDF dan gambar statis tidak memutar animasi. Gunakan [HTML5 export](/slides/id/python-java/export-to-html5/), GIF animasi, atau [video conversion](/slides/id/python-java/convert-powerpoint-to-video/) ketika output harus menampilkan gerakan.
- Untuk HTML5, aktifkan [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/id/python-java/aspose.slides/html5options/#setAnimateShapes) dan, bila diperlukan, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/id/python-java/aspose.slides/html5options/#setAnimateTransitions).
- Rendering video mendukung banyak efek masuk, penekanan, keluar, dan jalur‑gerak yang umum, tetapi tidak semua efek PowerPoint didukung. Periksa [supported animations and effects](/slides/id/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) saat ini dan uji presentasi penting dengan versi Aspose.Slides target Anda.
- Efek kustom lanjutan dan efek yang diimpor dari format presentasi lain mungkin disimpan dalam file tetapi dirender berbeda di PowerPoint, HTML5, atau video. Validasi hasil ekspor daripada hanya mengandalkan nama efek.

## **FAQ**

**Mengapa animasi muncul di PowerPoint tetapi tidak di PDF?**

PDF adalah format statis, sehingga animasi dan transisi slide tidak diputar. Ekspor ke HTML5, GIF animasi, atau video ketika gerakan harus dipertahankan.

**Mengapa sebuah efek diputar berbeda dalam video?**

Ekspor video merender animasi daripada menyimpan perilaku PowerPoint asli. Beberapa efek lanjutan tidak didukung atau hanya diperkirakan. Tinjau tabel efek yang didukung dan uji presentasi sebenarnya sebelum penggunaan produksi.

**Apakah memindahkan sebuah bentuk ke depan atau ke belakang mengubah urutan animasinya?**

Tidak. Z‑order bentuk mengontrol tumpang tindih, sementara urutan urutan dan pemicu mengontrol pemutaran animasi. Ubah timeline jika Anda membutuhkan urutan pemutaran yang berbeda.