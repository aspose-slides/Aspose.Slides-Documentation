---
title: "Kelola Master Slide Presentasi di Python"
linktitle: "Master Slide"
type: docs
weight: 80
url: /id/python-net/slide-master/
keywords:
- master slide
- master slide
- master slide PPT
- banyak master slide
- bandingkan master slide
- latar belakang
- placeholder
- kloning master slide
- salin master slide
- duplikasi master slide
- master slide tidak digunakan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kelola master slide di Aspose.Slides untuk Python via .NET: akses, edit, kloning, bandingkan, dan hapus master slide dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

**master slide** mendefinisikan pengaturan desain bersama untuk sekelompok slide. Ia dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit master slide merupakan cara umum untuk menjaga konsistensi presentasi tanpa mengulang format yang sama pada setiap slide.

Aspose.Slides for Python via .NET mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih master slide, dan setiap master slide dapat berisi beberapa layout slide. Slide normal biasanya tidak merujuk langsung ke master slide. Sebaliknya, slide normal menggunakan layout slide, dan layout slide tersebut merupakan bagian dari master slide.

The hierarchy is:

1. **Master slide** - mendefinisikan desain dan tema bersama.
2. **Layout slide** - mendefinisikan susunan khusus placeholder dan pemformatan tingkat layout.
3. **Slide normal** - berisi konten presentasi sebenarnya dan menggunakan satu layout slide.

![Hierarki master slide, layout slide, dan slide normal](slide-master_2.jpg)

Di Aspose.Slides, master slide diwakili oleh kelas [MasterSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslide/) . Semua master slide dalam sebuah presentasi tersedia melalui koleksi `Presentation.masters` .

{{% alert color="info" title="Inheritance" %}}
Ketika properti yang sama didefinisikan pada lebih dari satu tingkat, tingkat yang lebih spesifik yang menang. Misalnya, jika master slide dan layout slide keduanya mendefinisikan latar belakang, slide yang berbasis layout tersebut akan menggunakan latar belakang layout. Untuk informasi lebih lanjut tentang layout slide, lihat [Apply or Change Slide Layouts](/python-net/slide-layout/) .
{{% /alert %}}

## **Akses Master Slide**

Di PowerPoint, Anda dapat membuka tampilan Slide Master dari **View** > **Slide Master**.

![Perintah Slide Master pada tab View di PowerPoint](slide-master_3.jpg)

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

Anda juga dapat memperoleh master slide yang digunakan oleh slide normal melalui layoutnya:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Apa yang Dimiliki Master Slide**

Master slide adalah objek yang mirip slide. Ia mewarisi perilaku slide umum dari kelas [BaseSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/) , sehingga ia menampilkan banyak properti slide yang sama yang digunakan oleh slide normal dan layout. Anggota khusus master terdaftar pada halaman API [MasterSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslide/) .

Commonly used master slide members include:

| Anggota | Tujuan |
| --- | --- |
| `background` | Menetapkan latar belakang slide tingkat master. |
| `shapes` | Menyimpan shape yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `layout_slides` | Menyimpan layout slide yang menjadi milik master. |
| `theme_manager` | Memberikan akses ke API tema master. |
| `header_footer_manager` | Mengontrol header, footer, tanggal, dan nomor slide untuk master dan layout turunannya. |
| `get_depending_slides` | Mengembalikan slide normal yang bergantung pada master melalui layout mereka. |

## **Menambahkan Gambar ke Master Slide**

Ketika Anda menambahkan gambar ke master slide, gambar tersebut muncul pada slide yang menggunakan layout dari master tersebut. Ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

The following example adds a logo to the first master slide:

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

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Picture Frame](/python-net/picture-frame/) .

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada layout slide. Master slide menyediakan gaya dan tema bersama yang diwarisi oleh layout tersebut, sementara setiap layout menentukan placeholder mana yang tersedia dan di mana mereka ditempatkan.

Di PowerPoint, perintah placeholder tersedia di tampilan Slide Master.

![Perintah Insert Placeholder dalam tampilan Slide Master PowerPoint](slide-master_5.png)

To add new placeholders with Aspose.Slides, work with the layout slide that belongs to the master:

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

Anda juga dapat memformat shape placeholder yang sudah ada pada master slide. Contoh berikut menemukan placeholder judul dan menerapkan isian gradien linear:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Placeholder judul yang diformat yang diwarisi oleh slide normal](slide-master_8.png)

Untuk opsi placeholder dan pemformatan teks lebih lanjut, lihat [Set Prompt Text in Placeholder](/python-net/manage-placeholder/) dan [Text Formatting](/python-net/text-formatting/) .

## **Mengubah Latar Belakang Master Slide**

Latar belakang master diwarisi oleh layout dan slide yang tidak menimpanya. Contoh berikut menetapkan warna latar belakang solid untuk master slide pertama:

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

Untuk topik terkait, lihat [Presentation Background](/python-net/presentation-background/) dan [Presentation Theme](/python-net/presentation-theme/) .

## **Menduplikasi Master Slide ke Presentasi Lain**

Gunakan metode `add_clone` pada kelas [MasterSlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslidecollection/) untuk menyalin master slide ke presentasi lain. Master yang disalin kemudian dapat digunakan oleh layout dan slide dalam presentasi tujuan.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Jika Anda perlu menduplikasi slide normal bersama master-nya, lihat [Clone Slides](/python-net/clone-slides/) .

## **Menambahkan Beberapa Master Slide**

Sebuah presentasi dapat berisi beberapa master slide. Ini berguna ketika bagian yang berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola master slide](slide-master_9.jpg)

The following example clones the default master, gives the clone a different background, gets a blank layout under that cloned master, and adds a new slide based on that layout:

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

## **Membandingkan Master Slide**

Master slide dapat dibandingkan dengan metode `equals` yang diwarisi dari kelas [BaseSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/) . Perbandingan memeriksa struktur dan konten statis, seperti shape, teks, pemformatan, animasi, dan pengaturan slide lainnya. Ini tidak membandingkan pengidentifikasi unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

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

Untuk informasi lebih lanjut, lihat [Compare Presentation Slides](/python-net/compare-slides/) .

## **Menetapkan Tampilan Master Slide sebagai Tampilan Default**

Gunakan properti `last_view` pada [ViewProperties] presentasi untuk mengontrol tampilan yang pertama kali dibuka PowerPoint. Contoh berikut membuka presentasi dalam tampilan Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Untuk pengaturan tampilan lebih lanjut, lihat [Save Presentation](/python-net/save-presentation/) .

## **Menghapus Master Slide yang Tidak Digunakan**

Presentasi kadang-kadang berisi master slide yang tidak lagi digunakan oleh slide normal mana pun. Menghapus master yang tidak digunakan dapat mengurangi ukuran file dan menyederhanakan pemeliharaan templat.

Gunakan `remove_unused` untuk menghapus master yang tidak digunakan dari koleksi `masters` :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Anda juga dapat menggunakan metode low-code `remove_unused_master_slides` dari kelas [Compress](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/) :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apa perbedaan antara master slide dan layout slide?**

Master slide mendefinisikan pengaturan desain bersama seperti tema, latar belakang, shape umum, dan gaya teks. Layout slide merupakan bagian dari master slide dan mendefinisikan susunan khusus placeholder. Slide normal menggunakan layout slide, sehingga ia mewarisi dari layout serta master.

**Apakah satu presentasi dapat berisi beberapa master slide?**

Ya. Sebuah presentasi dapat berisi beberapa master slide. Gunakan beberapa master ketika bagian yang berbeda memerlukan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke master slide atau layout slide?**

Dalam kebanyakan kasus, tambahkan placeholder ke layout slide. Letakkan elemen visual bersama dan pemformatan bersama pada master slide, kemudian letakkan placeholder konten pada layout yang akan digunakan slide normal.

**Apakah saya dapat menghapus master slide yang masih digunakan?**

Tidak. Master slide yang memiliki slide tergantung tidak dapat dihapus secara langsung dengan aman. Pertama pindahkan slide tersebut ke layout di bawah master lain, atau gunakan metode pembersihan master yang tidak terpakai yang hanya menghapus master yang tidak digunakan.