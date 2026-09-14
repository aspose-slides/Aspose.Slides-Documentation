---
title: Kelola Slide Master Presentasi di Python via Java
linktitle: Master Slide
type: docs
weight: 70
url: /id/python-java/slide-master/
keywords:
- master slide
- master slide
- master slide PPT
- banyak master slide
- bandingkan master slide
- latar belakang
- placeholder
- klon master slide
- salin master slide
- duplikat master slide
- master slide tidak terpakai
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kelola master slide di Aspose.Slides untuk Python via Java: akses, edit, klon, bandingkan, dan hapus master slide dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

A **slide master** mendefinisikan pengaturan desain bersama untuk sekelompok slide. Ia dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit slide master adalah cara umum untuk menjaga konsistensi presentasi tanpa harus mengulang format yang sama pada setiap slide.

Aspose.Slides untuk Python via Java mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih master slide, dan tiap master slide dapat berisi beberapa layout slide. Slide normal biasanya tidak merujuk langsung ke master slide. Sebaliknya, slide normal menggunakan layout slide, dan layout slide tersebut milik sebuah master slide.

Hierarki nya adalah:

1. **Slide master** – mendefinisikan desain dan tema bersama.
1. **Layout slide** – mendefinisikan susunan placeholder dan format pada tingkat layout.
1. **Normal slide** – berisi konten presentasi aktual dan menggunakan satu layout slide.

![Hierarki master slide, layout slide, dan normal slide](slide-master_2.jpg)

Di Aspose.Slides, slide master direpresentasikan oleh kelas [MasterSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslide/). Semua master slide dalam sebuah presentasi dapat diakses melalui koleksi [Presentation.getMasters](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getMasters), yang direpresentasikan oleh [MasterSlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Ketika properti yang sama didefinisikan pada lebih dari satu level, level yang lebih spesifik yang akan dipilih. Misalnya, jika sebuah master slide dan layout slide keduanya mendefinisikan latar belakang, slide yang berbasis pada layout tersebut akan menggunakan latar belakang layout. Untuk informasi lebih lanjut tentang layout slide, lihat [Apply or Change Slide Layouts](/slides/id/python-java/slide-layout/).
{{% /alert %}}

## **Mengakses Slide Master**

Di PowerPoint, Anda dapat membuka tampilan Slide Master melalui **View** > **Slide Master**.

![Perintah Slide Master pada tab View di PowerPoint](slide-master_3.jpg)

Di Aspose.Slides, gunakan koleksi [Presentation.getMasters](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getMasters) untuk mengakses master slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

Anda juga dapat mendapatkan master slide yang digunakan oleh slide normal melalui layout-nya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **Apa yang Dimiliki Slide Master**

Sebuah master slide adalah objek yang mirip slide. Ia mewarisi dari [BaseSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/), sehingga menampilkan banyak properti slide yang sama yang digunakan oleh slide normal dan layout. Anggota khusus master dapat dilihat pada halaman API [MasterSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslide/).

Anggota master slide yang sering digunakan meliputi:

| Member | Purpose |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#getBackground) | Menetapkan latar belakang slide pada level master. |
| [getShapes](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#getShapes) | Menyimpan bentuk‑bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| [getLayoutSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslide/#getLayoutSlides) | Menyimpan layout slide yang termasuk dalam master. |
| [getThemeManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslide/#getThemeManager) | Menyediakan akses ke API tema master. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | Mengontrol header, footer, tanggal, dan nomor slide untuk master serta layout‑layout anaknya. |
| [getDependingSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslide/#getDependingSlides) | Mengembalikan slide normal yang bergantung pada master melalui layout‑nya. |

## **Menambahkan Gambar ke Slide Master**

Saat Anda menambahkan gambar ke master slide, gambar tersebut akan muncul pada slide yang menggunakan layout dari master tersebut. Ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

Contoh berikut menambahkan logo ke master slide pertama:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Picture Frame](/slides/id/python-java/picture-frame/).

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada layout slide. Master slide menyediakan gaya dan tema bersama yang diwarisi oleh layout, sementara setiap layout menentukan placeholder apa yang tersedia dan di mana penempatannya.

Di PowerPoint, perintah placeholder tersedia dalam tampilan Slide Master.

![Perintah Insert Placeholder dalam tampilan Slide Master PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, kerjakan layout slide yang termasuk dalam master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Anda juga dapat memformat bentuk placeholder yang sudah ada pada master slide. Contoh berikut menemukan placeholder judul dan menerapkan isian gradien linear:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Placeholder judul yang diformat dan diwarisi oleh slide normal](slide-master_8.png)

Untuk opsi pemformatan placeholder dan teks lebih lanjut, lihat [Set Prompt Text in Placeholder](/slides/id/python-java/manage-placeholder/) dan [Text Formatting](/slides/id/python-java/text-formatting/).

## **Mengubah Latar Belakang Slide Master**

Latar belakang master diwarisi oleh layout dan slide yang tidak menimpanya. Contoh berikut menetapkan warna latar belakang solid untuk master slide pertama:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Untuk topik terkait, lihat [Presentation Background](/slides/id/python-java/presentation-background/) dan [Presentation Theme](/slides/id/python-java/presentation-theme/).

## **Mengkloning Slide Master ke Presentasi Lain**

Gunakan [MasterSlideCollection.addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslidecollection/#addClone) untuk menyalin master slide ke presentasi lain. Master yang disalin kemudian dapat digunakan oleh layout dan slide di presentasi tujuan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

Jika Anda perlu mengkloning slide normal bersama masternya, lihat [Clone Slides](/slides/id/python-java/clone-slides/).

## **Menambahkan Beberapa Slide Master**

Sebuah presentasi dapat berisi beberapa master slide. Ini berguna ketika bagian‑bagian berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola master slide](slide-master_9.jpg)

Contoh berikut mengkloning master standar, memberi klon latar belakang berbeda, membuat layout di bawah master yang diklon, dan menambahkan slide baru berdasarkan layout tersebut:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Membandingkan Slide Master**

Slide master dapat dibandingkan dengan metode [equals](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#equals) yang diwarisi dari [BaseSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/). Perbandingan memeriksa struktur dan konten statis, seperti bentuk, teks, pemformatan, animasi, dan pengaturan slide lainnya. Ia tidak membandingkan pengidentifikasi unik seperti ID slide, atau nilai placeholder dinamis seperti tanggal saat ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

Untuk informasi lebih lanjut, lihat [Compare Presentation Slides](/slides/id/python-java/compare-slides/).

## **Menetapkan Tampilan Slide Master sebagai Tampilan Default**

Gunakan metode [setLastView](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/#setLastView) pada [ViewProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/viewproperties/) untuk mengatur tampilan yang pertama kali dibuka PowerPoint. Contoh berikut membuka presentasi dalam tampilan Slide Master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Untuk pengaturan tampilan lainnya, lihat [Save Presentation](/slides/id/python-java/save-presentation/).

## **Menghapus Slide Master yang Tidak Digunakan**

Kadang‑kadang presentasi berisi slide master yang tidak lagi dipakai oleh slide normal mana pun. Menghapus master yang tidak digunakan dapat mengurangi ukuran file dan menyederhanakan pemeliharaan template.

Gunakan [removeUnused](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslidecollection/#removeUnused) untuk menghapus master yang tidak terpakai dari koleksi [Presentation.getMasters](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getMasters):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Anda juga dapat menggunakan metode low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apa perbedaan antara slide master dan layout slide?**

Slide master mendefinisikan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Layout slide merupakan bagian dari master slide dan mendefinisikan susunan placeholder tertentu. Slide normal menggunakan layout slide, sehingga mewarisi baik dari layout maupun master.

**Apakah satu presentasi dapat berisi beberapa slide master?**

Ya. Sebuah presentasi dapat berisi beberapa slide master. Gunakan beberapa master ketika bagian‑bagian berbeda memerlukan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke slide master atau layout slide?**

Dalam kebanyakan kasus, tambahkan placeholder ke layout slide. Letakkan elemen visual dan pemformatan bersama pada slide master, kemudian tempatkan placeholder konten pada layout yang akan dipakai slide normal.

**Bisakah saya menghapus slide master yang masih digunakan?**

Tidak. Slide master yang memiliki slide bergantung tidak dapat dihapus secara langsung dengan aman. Pindahkan slide‑slide tersebut ke layout di bawah master lain, atau gunakan metode pembersihan master yang tidak terpakai yang hanya menghapus master yang tidak digunakan.