---
title: Kelola Slide Master Presentasi di Python
linktitle: Slide Master
type: docs
weight: 80
url: /id/python-net/slide-master/
keywords:
- slide master
- master slide
- slide master PPT
- banyak slide master
- bandingkan slide master
- latar belakang
- placeholder
- gandakan slide master
- salin slide master
- duplikasi slide master
- slide master yang tidak terpakai
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kelola slide master di Aspose.Slides untuk Python via .NET: akses, edit, menggandakan, membandingkan, dan menghapus slide master dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Sebuah **slide master** mendefinisikan pengaturan desain bersama untuk sekelompok slide. Ia dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit slide master adalah cara biasa untuk menjaga konsistensi presentasi tanpa mengulang format yang sama pada setiap slide.

Aspose.Slides for Python via .NET mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih slide master, dan setiap slide master dapat berisi beberapa layout slide. Slide normal biasanya tidak merujuk langsung ke slide master. Sebaliknya, slide normal menggunakan layout slide, dan layout slide tersebut milik sebuah slide master.

Hierarki nya adalah:

1. **Slide master** – mendefinisikan desain dan tema bersama.
1. **Layout slide** – mendefinisikan susunan placeholder dan format tingkat layout tertentu.
1. **Normal slide** – berisi konten presentasi sebenarnya dan menggunakan satu layout slide.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Di Aspose.Slides, slide master direpresentasikan oleh kelas [MasterSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslide/). Semua master slide dalam sebuah presentasi dapat diakses melalui koleksi `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}

Ketika properti yang sama didefinisikan pada lebih dari satu level, level yang lebih spesifik yang menang. Misalnya, jika sebuah master slide dan sebuah layout slide keduanya mendefinisikan latar belakang, slide yang berbasis pada layout tersebut menggunakan latar belakang layout. Untuk informasi lebih lanjut tentang layout slide, lihat [Apply or Change Slide Layouts](/slides/id/python-net/slide-layout/).

{{% /alert %}}

## **Mengakses Slide Master**

Di PowerPoint, Anda dapat membuka tampilan Slide Master dari **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Di Aspose.Slides, gunakan koleksi `masters` untuk mengakses master slide:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Anda juga dapat memperoleh slide master yang digunakan oleh slide normal melalui layout-nya:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Apa yang Dimiliki Slide Master**

Sebuah master slide adalah objek mirip slide. Ia mewarisi perilaku slide umum dari kelas [BaseSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/), sehingga mengekspos banyak properti slide yang sama yang digunakan oleh slide normal dan layout. Anggota khusus master terdaftar pada halaman API [MasterSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslide/).

Anggota master slide yang sering digunakan meliputi:

| Member | Purpose |
| --- | --- |
| `background` | Menetapkan latar belakang slide pada level master. |
| `shapes` | Menyimpan bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `layout_slides` | Menyimpan layout slide yang menjadi milik master. |
| `theme_manager` | Menyediakan akses ke API tema master. |
| `header_footer_manager` | Mengontrol header, footer, tanggal, dan nomor slide untuk master dan layout anaknya. |
| `get_depending_slides` | Mengembalikan slide normal yang bergantung pada master melalui layout mereka. |

## **Menambahkan Gambar ke Slide Master**

Ketika Anda menambahkan gambar ke master slide, gambar tersebut muncul pada slide yang menggunakan layout dari master itu. Hal ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

Contoh berikut menambahkan logo ke master slide pertama:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Picture Frame](/slides/id/python-net/picture-frame/).

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada layout slide. Slide master menyediakan gaya dan tema bersama yang diwarisi oleh layout tersebut, sementara setiap layout menentukan placeholder apa yang tersedia dan di mana penempatannya.

Di PowerPoint, perintah placeholder tersedia di tampilan Slide Master.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, kerjakan layout slide yang menjadi milik master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

Anda juga dapat memformat bentuk placeholder yang sudah ada pada master slide. Contoh berikut menemukan placeholder judul dan menerapkan isian gradien linear:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Untuk lebih banyak opsi pemformatan placeholder dan teks, lihat [Set Prompt Text in Placeholder](/slides/id/python-net/manage-placeholder/) dan [Text Formatting](/slides/id/python-net/text-formatting/).

## **Mengubah Latar Belakang Slide Master**

Latar belakang master diwariskan oleh layout dan slide yang tidak menimpanya. Contoh berikut menetapkan warna latar belakang solid untuk master slide pertama:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

Untuk topik terkait, lihat [Presentation Background](/slides/id/python-net/presentation-background/) dan [Presentation Theme](/slides/id/python-net/presentation-theme/).

## **Menggandakan Slide Master ke Presentasi Lain**

Gunakan metode `add_clone` pada kelas [MasterSlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslidecollection/) untuk menyalin master slide ke presentasi lain. Master yang disalin kemudian dapat digunakan oleh layout dan slide dalam presentasi tujuan.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Jika Anda perlu menggandakan slide normal bersama master-nya, lihat [Clone Slides](/slides/id/python-net/clone-slides/).

## **Menambahkan Beberapa Slide Master**

Sebuah presentasi dapat berisi banyak master slide. Hal ini berguna ketika bagian yang berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Contoh berikut menggandakan master default, memberi klon latar belakang yang berbeda, memperoleh layout kosong di bawah master yang digandakan, dan menambahkan slide baru berdasarkan layout tersebut:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Membandingkan Slide Master**

Slide master dapat dibandingkan dengan metode `equals` yang diwarisi dari kelas [BaseSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/). Perbandingan memeriksa struktur dan konten statis, seperti bentuk, teks, pemformatan, animasi, dan pengaturan slide lainnya. Tidak dibandingkan pengidentifikasi unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

Untuk informasi lebih lanjut, lihat [Compare Presentation Slides](/slides/id/python-net/compare-slides/).

## **Menetapkan Tampilan Slide Master sebagai Tampilan Default**

Gunakan properti `last_view` pada [ViewProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/) presentasi untuk mengontrol tampilan yang pertama kali dibuka PowerPoint. Contoh berikut membuka presentasi dalam tampilan Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Untuk pengaturan tampilan lainnya, lihat [Save Presentation](/slides/id/python-net/save-presentation/).

## **Menghapus Slide Master yang Tidak Digunakan**

Presentasi kadang berisi slide master yang tidak lagi dipakai oleh slide normal mana pun. Menghapus master yang tidak terpakai dapat mengurangi ukuran file dan mempermudah pemeliharaan templat.

Gunakan `remove_unused` untuk menghapus master yang tidak terpakai dari koleksi `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Anda juga dapat menggunakan metode low‑code `remove_unused_master_slides` dari kelas [Compress](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### Apa perbedaan antara slide master dan layout slide?

Slide master mendefinisikan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Layout slide merupakan bagian dari slide master dan mendefinisikan susunan placeholder tertentu. Slide normal menggunakan layout slide, sehingga mewarisi dari layout dan master.

### Dapatkah satu presentasi berisi beberapa slide master?

Ya. Sebuah presentasi dapat berisi beberapa slide master. Gunakan beberapa master ketika bagian yang berbeda memerlukan sistem visual atau branding yang berbeda.

### Haruskah saya menambahkan placeholder ke slide master atau layout slide?

Dalam kebanyakan kasus, tambahkan placeholder ke layout slide. Letakkan elemen visual bersama dan format bersama pada slide master, kemudian letakkan placeholder konten pada layout yang akan digunakan slide normal.

### Bisakah saya menghapus slide master yang masih digunakan?

Tidak. Slide master yang memiliki slide tergantung tidak dapat dihapus secara langsung dengan aman. Pindahkan dulu slide tersebut ke layout di bawah master lain, atau gunakan metode pembersihan master yang tidak terpakai yang hanya menghapus master yang tidak digunakan.