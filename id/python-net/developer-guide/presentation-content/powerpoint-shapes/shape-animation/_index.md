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
  - bentuk animasi
  - teks animasi
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
description: "Temukan cara membuat dan menyesuaikan animasi bentuk dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via .NET. Membuat Anda menonjol!"
---
## **Pendahuluan**

Animasi adalah efek visual yang dapat diterapkan pada teks, gambar, bentuk, atau [diagram](/slides/id/python-net/animated-charts/). Mereka memberikan kehidupan pada presentasi atau komponennya. 

## **Mengapa Menggunakan Animasi dalam Presentasi?**

Menggunakan animasi, Anda dapat 

* mengendalikan alur informasi
* menekankan poin penting
* meningkatkan minat atau partisipasi di antara audiens Anda
* mempermudah konten untuk dibaca, dipahami, atau diproses
* menarik perhatian pembaca atau penonton ke bagian penting dalam sebuah presentasi

PowerPoint menyediakan banyak pilihan dan alat untuk animasi serta efek animasi pada kategori **entrance**, **exit**, **emphasis**, dan **motion paths**. 

## **Animasi di Aspose.Slides**

* Aspose.Slides menyediakan kelas dan tipe yang Anda perlukan untuk bekerja dengan animasi di dalam namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/), 
* Aspose.Slides menyediakan lebih dari **150 efek animasi** di dalam enumerasi [EffectType](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effecttype/). Efek-efek ini pada dasarnya sama (atau setara) dengan efek yang digunakan di PowerPoint.

## **Menerapkan Animasi ke TextBox**

Aspose.Slides untuk Python via .NET memungkinkan Anda menerapkan animasi pada teks dalam sebuah bentuk. 

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan sebuah `rectangle` [IAutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/iautoshape/). 
4. Tambahkan teks ke `IAutoShape.TextFrame`.
5. Dapatkan urutan utama efek.
6. Tambahkan efek animasi ke [IAutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/iautoshape/). 
7. Setel properti `TextAnimation.BuildType` ke nilai dari enumerasi `BuildType`.
8. Tuliskan presentasi ke disk sebagai file PPTX.

Kode Python ini menunjukkan cara menerapkan efek `Fade` ke AutoShape dan mengatur animasi teks ke nilai *By 1st Level Paragraphs*:

```python
import aspose.slides as slides

# Membuat instance kelas presentasi yang mewakili file presentasi.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Menambahkan AutoShape baru dengan teks
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Mendapatkan urutan utama slide.
    sequence = sld.timeline.main_sequence

    # Menambahkan efek animasi Fade ke shape
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Menganimasikan teks shape berdasarkan paragraf level pertama
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Menyimpan file PPTX ke disk
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 
Selain menerapkan animasi pada teks, Anda juga dapat menerapkan animasi pada satu [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/iparagraph/). Lihat [**Animated Text**](/slides/id/python-net/animated-text/).
{{% /alert %}} 

## **Menerapkan Animasi ke PictureFrame**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan atau dapatkan sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) pada slide. 
4. Dapatkan urutan utama efek.
5. Tambahkan efek animasi ke [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/).
6. Tuliskan presentasi ke disk sebagai file PPTX.

Kode Python ini menunjukkan cara menerapkan efek `Fly` ke sebuah picture frame:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Membuat instance kelas presentasi yang mewakili file presentasi.
with slides.Presentation() as pres:
    # Memuat gambar yang akan ditambahkan ke koleksi gambar presentasi
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Menambahkan picture frame ke slide
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Mendapatkan urutan utama slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Menambahkan efek animasi Fly dari Kiri ke picture frame
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Menyimpan file PPTX ke disk
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Menerapkan Animasi ke Shape**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya.
3. Tambahkan sebuah `rectangle` [IAutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/iautoshape/). 
4. Tambahkan sebuah `Bevel` [IAutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/iautoshape/) (ketika objek ini diklik, animasi akan diputar).
5. Buat urutan efek pada bentuk bevel.
6. Buat `UserPath` khusus.
7. Tambahkan perintah untuk bergerak ke `UserPath`.
8. Tuliskan presentasi ke disk sebagai file PPTX.

Kode Python ini menunjukkan cara menerapkan efek `PathFootball` (path football) ke sebuah shape:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Prseetation yang mewakili file PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Membuat efek PathFootball untuk shape yang ada dari awal.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Menambahkan efek animasi PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Membuat semacam "tombol".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Membuat urutan efek untuk tombol.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Membuat jalur pengguna khusus. Objek kami akan dipindahkan hanya setelah tombol diklik.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Menambahkan perintah untuk bergerak karena jalur yang dibuat kosong.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Menulis file PPTX ke disk
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mendapatkan Efek Animasi yang Diterapkan pada Shape**

Contoh berikut menunjukkan cara menggunakan metode `get_effects_by_shape` dari kelas [Sequence](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/sequence/) untuk mendapatkan semua efek animasi yang diterapkan pada sebuah shape.

**Contoh 1: Dapatkan efek animasi yang diterapkan pada sebuah shape di slide normal**

Sebelumnya, Anda telah mempelajari cara menambahkan efek animasi ke shape dalam presentasi PowerPoint. Kode contoh berikut menunjukkan cara mendapatkan efek yang diterapkan pada shape pertama di slide normal pertama dalam presentasi `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Mendapatkan urutan animasi utama slide.
    sequence = first_slide.timeline.main_sequence

    # Mendapatkan shape pertama pada slide pertama.
    shape = first_slide.shapes[0]

    # Mendapatkan efek animasi yang diterapkan pada shape.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Contoh 2: Dapatkan semua efek animasi, termasuk yang diwarisi dari placeholder**

Jika sebuah shape pada slide normal memiliki placeholder yang berada pada slide tata letak dan/atau slide master, dan efek animasi telah ditambahkan ke placeholder tersebut, maka semua efek pada shape akan diputar selama pertunjukan slide, termasuk yang diwarisi dari placeholder.

Kita misalkan memiliki file presentasi PowerPoint `sample.pptx` dengan satu slide yang hanya berisi shape footer dengan teks "Made with Aspose.Slides" dan efek **Random Bars** diterapkan pada shape tersebut.

![Efek animasi shape slide](slide-shape-animation.png)

Kita juga berasumsi bahwa efek **Split** diterapkan pada placeholder footer di slide **layout**.

![Efek animasi shape layout](layout-shape-animation.png)

Dan akhirnya, efek **Fly In** diterapkan pada placeholder footer di slide **master**.

![Efek animasi shape master](master-shape-animation.png)

Kode contoh berikut menunjukkan cara menggunakan metode `get_base_placeholder` dari kelas [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) untuk mengakses placeholder shape dan mendapatkan efek animasi yang diterapkan pada shape footer, termasuk yang diwarisi dari placeholder yang berada pada slide layout dan master.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Dapatkan efek animasi dari shape pada slide normal.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Dapatkan efek animasi dari placeholder pada slide layout.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Dapatkan efek animasi dari placeholder pada slide master.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Ubah Properti Waktu Efek Animasi**

Aspose.Slides untuk Python via .NET memungkinkan Anda mengubah properti Timing dari sebuah efek animasi.

Berikut adalah panel Animation Timing di Microsoft PowerPoint:

![example1_image](shape-animation.png)

Berikut adalah kesesuaian antara PowerPoint Timing dan properti `Effect.Timing`:

- Daftar drop-down **Start** pada PowerPoint Timing cocok dengan properti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effecttriggertype/). 
- **Duration** pada PowerPoint Timing cocok dengan properti `Effect.Timing.Duration`. Durasi sebuah animasi (dalam detik) adalah total waktu yang dibutuhkan animasi untuk menyelesaikan satu siklus. 
- **Delay** pada PowerPoint Timing cocok dengan properti `Effect.Timing.TriggerDelayTime`. 

Berikut cara mengubah properti Effect Timing:

1. [Terapkan](#apply-animation-to-shape) atau dapatkan efek animasi.
2. Setel nilai baru untuk properti `Effect.Timing` yang Anda butuhkan. 
3. Simpan file PPTX yang telah dimodifikasi.

Kode Python ini mendemonstrasikan operasi:

```python
import aspose.slides as slides

# Membuat instance kelas presentasi yang mewakili file presentasi.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Mendapatkan urutan utama slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Mendapatkan efek pertama dari urutan utama.
    effect = sequence[0]

    # Mengubah TriggerType efek menjadi mulai saat klik
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Mengubah Duration efek
    effect.timing.duration = 3

    # Mengubah TriggerDelayTime efek
    effect.timing.trigger_delay_time = 0.5

    # Menyimpan file PPTX ke disk
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Suara Efek Animasi**

Aspose.Slides menyediakan properti berikut untuk memungkinkan Anda bekerja dengan suara dalam efek animasi: 

- `sound`
- `stop_previous_sound`

### **Menambahkan Suara Efek Animasi**

Kode Python ini menunjukkan cara menambahkan suara efek animasi dan menghentikannya ketika efek berikutnya dimulai:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Menambahkan audio ke koleksi audio presentasi
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Mendapatkan urutan utama slide.
    sequence = first_slide.timeline.main_sequence

    # Mendapatkan efek pertama dari urutan utama
    first_effect = sequence[0]

    # Memeriksa efek untuk "No Sound"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Menambahkan suara untuk efek pertama
        first_effect.sound = effect_sound

    # Mendapatkan urutan interaktif pertama slide.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Mengatur flag "Stop previous sound" pada efek
    interactive_sequence[0].stop_previous_sound = True

    # Menulis file PPTX ke disk
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Mengekstrak Suara Efek Animasi**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi slide melalui indeksnya. 
3. Dapatkan urutan utama efek. 
4. Ekstrak `sound` yang terembed pada setiap efek animasi. 

Kode Python ini menunjukkan cara mengekstrak suara yang terembed dalam sebuah efek animasi:

```python
import aspose.slides as slides

# Membuat instance kelas presentasi yang mewakili file presentasi.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Mendapatkan urutan utama slide.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Mengekstrak suara efek dalam array byte
        audio = effect.sound.binary_data
```

## **Setelah Animasi**

Aspose.Slides untuk .NET memungkinkan Anda mengubah properti After animation dari sebuah efek animasi.

Berikut adalah panel Animation Effect dan menu lanjutan di Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Daftar drop-down **After animation** pada PowerPoint Effect cocok dengan properti berikut: 

- Properti `after_animation_type` yang menggambarkan tipe After animation :
  * PowerPoint **More Colors** cocok dengan tipe [COLOR](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** cocok dengan tipe [DO_NOT_DIM](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/afteranimationtype/) (tipe after animation default);
  * PowerPoint **Hide After Animation** cocok dengan tipe [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** cocok dengan tipe [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/afteranimationtype/);
- Properti `after_animation_color` yang menentukan format warna after animation. Properti ini bekerja bersama dengan tipe [COLOR](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/afteranimationtype/). Jika Anda mengubah tipe ke yang lain, warna after animation akan dibersihkan.

Kode Python ini menunjukkan cara mengubah efek after animation:

```python
import aspose.slides as slides

# Membuat instance kelas presentasi yang mewakili file presentasi
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Mendapatkan efek pertama dari urutan utama
    first_effect = first_slide.timeline.main_sequence[0]

    # Mengubah tipe after animation menjadi Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Menetapkan warna dim after animation
    first_effect.after_animation_color.color = Color.alice_blue

    # Menulis file PPTX ke disk
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animasi Teks**

Aspose.Slides menyediakan properti berikut untuk memungkinkan Anda bekerja dengan blok *Animate text* pada sebuah efek animasi:

- `animate_text_type` yang menggambarkan tipe animate text pada efek. Teks shape dapat dianimasikan:
  - Semua sekaligus ([ALL_AT_ONCE](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/animatetexttype/) tipe)
  - Per kata ([BY_WORD](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/animatetexttype/) tipe)
  - Per huruf ([BY_LETTER](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/animatetexttype/) tipe)
- `delay_between_text_parts` mengatur jeda antara bagian teks yang dianimasikan (kata atau huruf). Nilai positif menentukan persentase durasi efek. Nilai negatif menentukan jeda dalam detik.

Berikut cara Anda dapat mengubah properti Effect Animate text:

1. [Terapkan](#apply-animation-to-shape) atau dapatkan efek animasi.
2. Setel properti `build_type` ke nilai [AS_ONE_OBJECT](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/buildtype/) untuk mematikan mode animasi *By Paragraphs*.
3. Setel nilai baru untuk properti `animate_text_type` dan `delay_between_text_parts`.
4. Simpan file PPTX yang telah dimodifikasi.

Kode Python ini mendemonstrasikan operasi:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Mendapatkan efek pertama dari urutan utama
    first_effect = first_slide.timeline.main_sequence[0]

    # Mengubah tipe animasi teks efek menjadi "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Mengubah tipe Animate text efek menjadi "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Menetapkan jeda antara kata menjadi 20% dari durasi efek
    first_effect.delay_between_text_parts = 20

    # Menulis file PPTX ke disk
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**Bagaimana saya dapat memastikan animasi tetap terjaga ketika mempublikasikan presentasi ke web?**

[Export to HTML5](/slides/id/python-net/export-to-html5/) dan aktifkan [opsi](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/html5options/) yang bertanggung jawab atas animasi [shape](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/html5options/animate_shapes/) dan [transition](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/html5options/animate_transitions/). HTML biasa tidak memutar animasi slide, sementara HTML5 melakukannya.

**Bagaimana perubahan z-order (urutan lapisan) shape memengaruhi animasi?**

Animasi dan urutan gambar bersifat independen: sebuah efek mengontrol timing dan tipe muncul/menghilang, sementara [z-order](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/z_order_position/) menentukan apa yang menutupi apa. Hasil yang terlihat ditentukan oleh kombinasi keduanya. (Ini adalah perilaku umum PowerPoint; model effects-and-shapes Aspose.Slides mengikuti logika yang sama.)

**Apakah ada keterbatasan saat mengonversi animasi ke video untuk efek tertentu?**

Secara umum, [animasi didukung](/slides/id/python-net/convert-powerpoint-to-video/), namun kasus langka atau efek tertentu dapat dirender secara berbeda. Disarankan untuk menguji dengan efek yang Anda gunakan dan dengan versi pustaka.