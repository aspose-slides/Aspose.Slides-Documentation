---
title: Konversi Presentasi PowerPoint ke Video dengan Python
linktitle: PowerPoint ke Video
type: docs
weight: 130
url: /id/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint ke video
- konversi PowerPoint ke video
- presentasi ke video
- konversi presentasi ke video
- PPT ke video
- konversi PPT ke video
- PPTX ke video
- konversi PPTX ke video
- ODP ke video
- konversi ODP ke video
- PowerPoint ke MP4
- konversi PowerPoint ke MP4
- presentasi ke MP4
- konversi presentasi ke MP4
- PPT ke MP4
- konversi PPT ke MP4
- PPTX ke MP4
- konversi PPTX ke MP4
- konversi PowerPoint ke video
- konversi presentasi ke video
- konversi PPT ke video
- konversi PPTX ke video
- konversi ODP ke video
- konversi video Python
- PowerPoint
- Python
- Aspose.Slides
description: "Pelajari cara mengonversi presentasi PowerPoint dan OpenDocument ke video menggunakan Python. Temukan contoh kode dan teknik otomasi untuk menyederhanakan alur kerja Anda."
---
## **Introduction**

Dengan mengonversi presentasi PowerPoint atau OpenDocument Anda ke video, Anda mendapatkan:

**Aksesibilitas yang meningkat:** Semua perangkat, terlepas dari platformnya, dilengkapi dengan pemutar video secara default, sehingga lebih mudah bagi pengguna untuk membuka atau memutar video dibandingkan aplikasi presentasi tradisional.

**Jangkauan yang lebih luas:** Video memungkinkan Anda menjangkau audiens yang lebih besar dan menyajikan informasi dalam format yang lebih menarik. Survei dan statistik menunjukkan bahwa orang lebih menyukai menonton dan mengonsumsi konten video dibandingkan bentuk lain, menjadikan pesan Anda lebih berdampak.

{{% alert color="primary" %}} 
Lihat [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/id/video) kami karena menyediakan implementasi langsung dan efektif dari proses yang dijelaskan di sini.
{{% /alert %}} 

Di [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/id/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/), kami menambahkan dukungan untuk mengonversi presentasi ke video.

* Gunakan Aspose.Slides for Python untuk menghasilkan frame dari slide presentasi dengan kecepatan frame (FPS) yang ditentukan.
* Kemudian, gunakan utilitas pihak ketiga seperti ffmpeg untuk mengompilasi frame tersebut menjadi video.

## **Mengonversi Presentasi PowerPoint ke Video**

1. Gunakan perintah pip install untuk menambahkan Aspose.Slides for Python ke proyek Anda: `pip install aspose-slides==24.4.0`
2. Unduh ffmpeg dari [sini](https://ffmpeg.org/download.html) atau instal melalui manajer paket.
3. Pastikan ffmpeg berada di dalam `PATH`. Jika tidak, jalankan ffmpeg dengan menggunakan path lengkap ke binary (misalnya `C:\ffmpeg\ffmpeg.exe` di Windows atau `/opt/ffmpeg/ffmpeg` di Linux).
4. Jalankan kode konversi PowerPoint ke video.

Kode Python ini memperlihatkan cara mengonversi presentasi (yang berisi bentuk dan dua efek animasi) menjadi video:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```

## **Efek Video**

Saat mengonversi presentasi PowerPoint ke video menggunakan Aspose.Slides for Python, Anda dapat menerapkan berbagai efek video untuk meningkatkan kualitas visual output. Efek-efek ini memungkinkan Anda mengontrol tampilan slide dalam video akhir dengan menambahkan transisi halus, animasi, dan elemen visual lainnya. Bagian ini menjelaskan opsi efek video yang tersedia dan cara menerapkannya.

{{% alert color="primary" %}} 
Lihat [PowerPoint Animation](https://docs.aspose.com/slides/id/python-net/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/id/python-net/shape-animation/), dan [Shape Effect](https://docs.aspose.com/slides/id/python-net/shape-effect/).
{{% /alert %}} 

Animasi dan transisi membuat slide lebih menarik dan menarik — dan hal yang sama berlaku untuk video. Mari tambahkan slide dan transisi lain ke kode untuk presentasi sebelumnya:

```python
import aspose.pydrawing as drawing

# Tambahkan bentuk senyum dan animasikan.
# ...

# Tambahkan slide baru dan transisi animasi.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python juga mendukung animasi teks. Dalam contoh ini, kami menganimasikan paragraf pada objek sehingga muncul satu per satu, dengan jeda satu detik di antara mereka:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Tambahkan teks dan animasi.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Konversi frame ke video.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Kelas Konversi Video**

Untuk memungkinkan tugas konversi PowerPoint ke video, Aspose.Slides for Python menyediakan [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/presentationenumerableframesgenerator/).

`PresentationEnumerableFramesGenerator` memungkinkan Anda mengatur ukuran frame untuk video (yang akan dibuat kemudian) dan nilai FPS (frame per detik) melalui konstruktor-nya. Jika Anda memberikan instance presentasi, `Presentation.SlideSize`-nya yang akan digunakan.

Untuk membuat semua animasi dalam presentasi diputar sekaligus, gunakan metode `PresentationEnumerableFramesGenerator.enumerate_frames`. Metode ini menerima kumpulan slide dan secara berurutan mengembalikan [EnumerableFrameArgs](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/enumerableframeargs/). Kemudian, gunakan `EnumerableFrameArgs.get_frame()` untuk mendapatkan setiap frame video.

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

Kemudian frame yang dihasilkan dapat dikompilasi menjadi video. Untuk detail lebih lanjut, lihat bagian [Convert PowerPoint to Video](https://docs.aspose.com/slides/id/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animasi dan Efek yang Didukung**

Saat mengonversi presentasi PowerPoint ke video menggunakan Aspose.Slides for Python, penting untuk memahami animasi dan efek mana yang didukung dalam output. Aspose.Slides mendukung beragam efek masuk, keluar, dan penekanan umum seperti fade, fly in, zoom, dan spin. Namun, beberapa animasi lanjutan atau kustom mungkin tidak sepenuhnya dipertahankan atau dapat muncul berbeda dalam video akhir. Bagian ini merangkum animasi dan efek yang didukung.

**Masuk**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Penekanan**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Keluar**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Jalur Gerakan**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Efek Transisi Slide yang Didukung**

Efek transisi slide memainkan peran penting dalam menciptakan perubahan yang mulus dan menarik secara visual antara slide dalam video. Aspose.Slides for Python mendukung berbagai efek transisi yang umum digunakan untuk membantu mempertahankan alur dan gaya presentasi asli Anda. Bagian ini menyoroti efek transisi mana yang didukung selama proses konversi.

**Halus**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Menarik**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Konten Dinamis**:

| Jenis Animasi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Apakah memungkinkan mengonversi presentasi yang dilindungi kata sandi?**

Ya, Aspose.Slides for Python memungkinkan bekerja dengan presentasi yang dilindungi kata sandi. Saat memproses file semacam itu, Anda perlu menyediakan kata sandi yang benar agar perpustakaan dapat mengakses isi presentasi.

**Apakah Aspose.Slides for Python mendukung penggunaan dalam solusi cloud?**

Ya, Aspose.Slides for Python dapat diintegrasikan ke dalam aplikasi dan layanan cloud. Perpustakaan ini dirancang untuk bekerja di lingkungan server, memastikan kinerja tinggi dan skalabilitas untuk pemrosesan batch file.

**Apakah ada batasan ukuran untuk presentasi selama konversi?**

Aspose.Slides for Python mampu menangani presentasi dengan ukuran apa pun secara praktis. Namun, saat bekerja dengan file yang sangat besar, mungkin diperlukan sumber daya sistem tambahan, dan terkadang disarankan untuk mengoptimalkan presentasi guna meningkatkan kinerja.