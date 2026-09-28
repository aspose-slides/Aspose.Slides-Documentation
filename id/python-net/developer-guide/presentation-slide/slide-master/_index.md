---
title: Kelola Slide Master Presentasi di Python
linktitle: Master Slide
type: docs
weight: 80
url: /id/python-net/slide-master/
keywords:
- master slide
- slide master
- slide master PPT
- beberapa slide master
- bandingkan slide master
- latar belakang
- placeholder
- kloning slide master
- menyalin slide master
- duplikat slide master
- slide master yang tidak terpakai
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kelola slide master di Aspose.Slides untuk Python via .NET: mengakses, menyunting, mengkloning, membandingkan, dan menghapus slide master dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

A **slide master** mendefinisikan pengaturan desain bersama untuk sekelompok slide. Ini dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit slide master adalah cara umum untuk menjaga konsistensi presentasi tanpa mengulangi format yang sama pada setiap slide.

Aspose.Slides for Python via .NET mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih slide master, dan setiap slide master dapat berisi beberapa slide tata letak. Slide normal biasanya tidak merujuk langsung ke slide master. Sebaliknya, slide normal menggunakan slide tata letak, dan slide tata letak tersebut termasuk dalam slide master.

Hierarki adalah:

1. **Slide master** - mendefinisikan desain dan tema bersama.
1. **Layout slide** - mendefinisikan susunan khusus placeholder dan format tingkat tata letak.
1. **Normal slide** - berisi konten presentasi aktual dan menggunakan satu layout slide.

![Hierarki slide master, slide tata letak, dan slide normal](slide-master_2.jpg)

Di Aspose.Slides, slide master direpresentasikan oleh kelas [MasterSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslide/). Semua slide master dalam sebuah presentasi tersedia melalui koleksi `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}
Ketika properti yang sama didefinisikan pada lebih dari satu tingkat, tingkat yang lebih spesifik yang menang. Misalnya, jika slide master dan slide tata letak keduanya mendefinisikan latar belakang, slide yang didasarkan pada tata letak tersebut menggunakan latar belakang tata letak. Untuk informasi lebih lanjut tentang slide tata letak, lihat [Terapkan atau Ubah Tata Letak Slide](/slides/id/python-net/slide-layout/).
{{% /alert %}}

## **Mengakses Slide Master**

Di PowerPoint, Anda dapat membuka tampilan Slide Master dari **View** > **Slide Master**.

![Perintah Slide Master pada tab View PowerPoint](slide-master_3.jpg)

Di Aspose.Slides, gunakan koleksi `masters` untuk mengakses slide master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Anda juga dapat mendapatkan slide master yang digunakan oleh slide normal melalui tata letaknya:

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

Slide master adalah objek mirip slide. Ia mewarisi perilaku slide umum dari kelas [BaseSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/) , sehingga mengekspos banyak properti slide yang sama yang digunakan oleh slide normal dan tata letak. Anggota khusus master tercantum pada halaman API [MasterSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslide/).

Anggota slide master yang umum digunakan meliputi:

| Anggota | Tujuan |
| --- | --- |
| `background` | Mengatur latar belakang slide pada tingkat master. |
| `shapes` | Menyimpan bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `layout_slides` | Menyimpan slide tata letak yang termasuk dalam master. |
| `theme_manager` | Memberikan akses ke API tema master. |
| `header_footer_manager` | Mengontrol header, footer, tanggal, dan nomor slide untuk master dan tata letak turunannya. |
| `get_depending_slides` | Mengembalikan slide normal yang bergantung pada master melalui tata letaknya. |

## **Menambahkan Gambar ke Slide Master**

Saat Anda menambahkan gambar ke slide master, gambar tersebut muncul pada slide yang menggunakan tata letak dari master tersebut. Ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

Contoh berikut menambahkan logo ke slide master pertama:

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

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Bingkai Gambar](/slides/id/python-net/picture-frame/).

## **Mengendalikan Visibilitas Grafik Master**

Gunakan [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/show_master_shapes/) untuk menyembunyikan grafik master yang diwariskan, seperti logo atau bentuk dekoratif, tanpa menghapusnya dari master. Setel [Slide.show_master_shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/show_master_shapes/) ke `False` pada slide yang harus menghilangkan grafik tersebut dan biarkan `True` pada slide yang harus menampilkannya.

Contoh mandiri berikut membuat pita dekoratif biru pada master dan dua slide yang menggunakan tata letak kosong yang sama. Pita tersebut terlihat pada slide pertama dan disembunyikan pada slide kedua. Tidak diperlukan presentasi atau gambar masukan.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

Contoh menggunakan tata letak **Blank** yang disertakan dengan presentasi baru dan menghapus placeholder milik slide awal.

### **Pilih Lingkup Pengaturan**

Slide normal menggunakan master melalui [Slide.layout_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/layout_slide/) dan [LayoutSlide.master_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/master_slide/). Menetapkan properti pada slide individu memengaruhi hanya slide tersebut. Menetapkan [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/show_master_shapes/) ke `False` menyembunyikan grafik master untuk semua slide yang memakai tata letak bersama itu, meskipun pengaturan mereka sendiri `True`. Untuk menyembunyikan grafik hanya pada satu slide, ubah properti slide dan biarkan tata letak bersama tidak berubah.

Pengaturan ini tidak didukung sebagai kontrol visibilitas pada slide master itu sendiri. Pada master selalu mengembalikan `False`, dan menetapkan `True` menimbulkan pengecualian. Terapkan pada slide normal atau tata letak saja.

### **Membedakan Grafik dari Latar Belakang**

| Operasi | Efek |
| --- | --- |
| Sembunyikan grafik master | Mengendalikan visibilitas bentuk master yang diwariskan tanpa menghapusnya atau mengubah bentuk slide sendiri. |
| Ubah isi latar belakang slide | Mengubah warna, gradien, atau gambar latar belakang. Grafik master adalah bentuk terpisah dan dapat tetap terlihat di atas latar belakang tersebut. Lihat [Presentation Background](/slides/id/python-net/presentation-background/). |
| Hapus bentuk dari master | Menghapus bentuk sumber yang dibagikan, sehingga tidak lagi tersedia untuk slide mana pun yang menggunakan master tersebut. |

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada slide tata letak. Slide master menyediakan gaya dan tema bersama yang diwarisi oleh tata letak tersebut, sementara setiap tata letak menentukan placeholder apa yang tersedia dan di mana mereka ditempatkan.

Di PowerPoint, perintah placeholder tersedia di tampilan Slide Master.

![Perintah Insert Placeholder dalam tampilan Slide Master PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, kerjakan slide tata letak yang termasuk dalam master:

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

Anda juga dapat memformat bentuk placeholder yang sudah ada pada slide master. Contoh berikut menemukan placeholder judul dan menerapkan isian gradien linear:

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

![Placeholder judul yang diformat dan diwariskan oleh slide normal](slide-master_8.png)

Untuk opsi pemformatan placeholder dan teks lebih lanjut, lihat [Set Prompt Text in Placeholder](/slides/id/python-net/manage-placeholder/) dan [Text Formatting](/slides/id/python-net/text-formatting/).

## **Mengubah Latar Belakang Slide Master**

Latar belakang master diwariskan oleh tata letak dan slide yang tidak menimpanya. Contoh berikut menetapkan warna latar belakang padat untuk slide master pertama:

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

## **Menyalin Slide Master ke Presentasi Lain**

Gunakan metode `add_clone` pada kelas [MasterSlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslidecollection/) untuk menyalin slide master ke presentasi lain. Master yang disalin kemudian dapat digunakan oleh tata letak dan slide di presentasi tujuan.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Jika Anda perlu menyalin slide normal bersama masternya, lihat [Clone Slides](/slides/id/python-net/clone-slides/).

## **Menambahkan Beberapa Slide Master**

Sebuah presentasi dapat berisi beberapa slide master. Ini berguna ketika bagian yang berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola slide master](slide-master_9.jpg)

Contoh berikut menyalin master default, memberi salinan latar belakang berbeda, mengambil tata letak kosong di bawah master yang disalin, dan menambahkan slide baru berdasarkan tata letak tersebut:

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

Slide master dapat dibandingkan dengan metode `equals` yang diwarisi dari kelas [BaseSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/). Perbandingan memeriksa struktur dan konten statis, seperti bentuk, teks, pemformatan, animasi, dan pengaturan slide lainnya. Ia tidak membandingkan pengenal unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

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

Gunakan properti `last_view` pada [ViewProperties](https://reference.aspose.com/slides/id/python-net/aspose.slides/viewproperties/) presentasi untuk mengendalikan tampilan yang dibuka PowerPoint pertama kali. Contoh berikut membuka presentasi dalam tampilan Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Untuk pengaturan tampilan lainnya, lihat [Save Presentation](/slides/id/python-net/save-presentation/).

## **Menghapus Slide Master yang Tidak Digunakan**

Presentasi kadang-kadang berisi slide master yang tidak lagi dipakai oleh slide normal mana pun. Menghapus master yang tidak terpakai dapat mengurangi ukuran file dan menyederhanakan pemeliharaan templat.

Gunakan `remove_unused` untuk menghapus master yang tidak terpakai dari koleksi `masters`:

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

**Apa perbedaan antara slide master dan slide tata letak?**

Slide master mendefinisikan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Slide tata letak termasuk dalam slide master dan mendefinisikan susunan spesifik placeholder. Slide normal menggunakan slide tata letak, sehingga ia mewarisi dari tata letak dan master.

**Apakah satu presentasi dapat berisi beberapa slide master?**

Ya. Sebuah presentasi dapat berisi beberapa slide master. Gunakan master ganda ketika bagian yang berbeda memerlukan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke slide master atau slide tata letak?**

Sebagian besar kasus, tambahkan placeholder ke slide tata letak. Letakkan elemen visual dan format bersama pada slide master, kemudian letakkan placeholder konten pada tata letak yang akan digunakan slide normal.

**Apakah saya dapat menghapus slide master yang masih digunakan?**

Tidak. Slide master yang memiliki slide tergantung tidak dapat dihapus secara aman langsung. Pindahkan slide tersebut ke tata letak di bawah master lain, atau gunakan metode pembersihan master yang tidak terpakai yang hanya menghapus master yang tidak digunakan.