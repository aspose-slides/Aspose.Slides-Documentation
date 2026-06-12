---
title: Kelola Zoom dalam Presentasi dengan Python
linktitle: Zoom
type: docs
weight: 60
url: /id/python-net/manage-zoom/
keywords:
- zoom
- bingkai zoom
- zoom slide
- zoom bagian
- zoom ringkasan
- tambahkan zoom
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Buat dan sesuaikan Zoom dengan Aspose.Slides untuk Python via .NET — lompat antar bagian, tambahkan thumbnail dan transisi pada presentasi PPT, PPTX, dan ODP."
---
## **Pendahuluan**

Zoom di PowerPoint memungkinkan Anda melompat ke dan dari slide, bagian, dan bagian tertentu dari presentasi. Saat Anda menyajikan, kemampuan menavigasi dengan cepat melalui konten ini dapat sangat berguna. 

![ikhtisar](overview.png)

* Untuk merangkum seluruh presentasi pada satu slide, gunakan [Summary Zoom](#Summary-Zoom).
* Untuk menampilkan hanya slide yang dipilih, gunakan [Slide Zoom](#Slide-Zoom).
* Untuk menampilkan hanya satu bagian, gunakan [Section Zoom](#Section-Zoom).

## **Zoom Slide**

Zoom slide dapat membuat presentasi Anda lebih dinamis, memungkinkan Anda menavigasi secara bebas antara slide dalam urutan apa pun yang Anda pilih tanpa mengganggu alur presentasi. Zoom slide sangat cocok untuk presentasi singkat tanpa banyak bagian, tetapi Anda tetap dapat menggunakannya dalam berbagai skenario presentasi.

Zoom slide membantu Anda menggali banyak potongan informasi seolah‑olah Anda berada pada satu kanvas. 

![pilihan zoom slide](slidezoomsel.png)

Untuk objek zoom slide, Aspose.Slides menyediakan enumerasi [ZoomImageType](https://reference.aspose.com/slides/id/python-net/aspose.slides/zoomimagetype/), kelas [ZoomFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/zoomframe/), dan beberapa metode di kelas [ShapeCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/).

### **Membuat Bingkai Zoom**
Anda dapat menambahkan bingkai zoom pada slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2.	Buat slide baru yang akan Anda tautkan. 
3.	Tambahkan teks identifikasi dan latar belakang ke slide yang dibuat.
4.	Tambahkan bingkai zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Tambahkan slide baru ke presentasi
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    #Buat latar belakang untuk slide kedua
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    #Buat kotak teks untuk slide kedua
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    #Buat latar belakang untuk slide ketiga
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    #Buat kotak teks untuk slide ketiga
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Tambahkan objek ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    #Simpan presentasi
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Membuat Bingkai Zoom dengan Gambar Kustom**
Dengan Aspose.Slides untuk Python via .NET, Anda dapat membuat bingkai zoom dengan gambar selain gambar pratinjau slide dengan cara berikut: 
1.	Buat instance dari kelas `Presentation`.
2.	Buat slide baru yang akan Anda tautkan. 
3.	Tambahkan teks identifikasi dan latar belakang ke slide yang dibuat.
4.	Buat objek [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek Presentation yang akan digunakan untuk mengisi bingkai.
5.	Tambahkan bingkai zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
6.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Tambahkan slide baru ke presentasi
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Buat latar belakang untuk slide kedua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Buat kotak teks untuk slide ketiga
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Buat gambar baru untuk objek zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Tambahkan objek ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Simpan presentasi
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```
### **Memformat Bingkai Zoom**
Pada bagian sebelumnya, kami menunjukkan cara membuat bingkai zoom sederhana. Untuk membuat bingkai zoom yang lebih rumit, Anda harus mengubah format bingkai. Ada beberapa pengaturan format yang dapat Anda terapkan pada bingkai zoom. 

Anda dapat mengontrol format bingkai zoom pada slide dengan cara berikut:

1.	Buat instance dari kelas `Presentation`.
2.	Buat slide baru yang akan ditautkan.
3.	Tambahkan teks identifikasi dan latar belakang ke slide yang dibuat.
4.	Tambahkan bingkai zoom (yang berisi referensi ke slide yang dibuat) ke slide pertama.
5.	Buat objek [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek Presentation yang akan digunakan untuk mengisi bingkai.
6.	Tetapkan gambar kustom untuk objek bingkai zoom pertama.
7.	Ubah format garis untuk objek bingkai zoom kedua.
8.	Hapus latar belakang dari gambar objek bingkai zoom kedua.
9.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Tambahkan slide baru ke presentasi
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Buat latar belakang untuk slide kedua
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Buat kotak teks untuk slide kedua
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Buat latar belakang untuk slide ketiga
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Buat kotak teks untuk slide ketiga
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Tambahkan objek ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Buat gambar baru untuk objek zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Tetapkan gambar kustom untuk objek zoomFrame1
    zoomFrame1.image = image

    # Tetapkan format bingkai zoom untuk objek zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Jangan tampilkan latar belakang untuk objek zoomFrame2
    zoomFrame2.show_background = False

    # Simpan presentasi
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom Bagian**

Zoom bagian merupakan tautan ke sebuah bagian dalam presentasi Anda. Anda dapat menggunakan zoom bagian untuk kembali ke bagian yang ingin Anda tekankan. Atau Anda dapat menggunakannya untuk menyoroti bagaimana potongan tertentu dari presentasi Anda terhubung. 

![pilihan zoom bagian](seczoomsel.png)

Untuk objek zoom bagian, Aspose.Slides menyediakan kelas [SectionZoomFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/sectionzoomframe/) dan beberapa metode di kelas [ShapeCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/).

### **Membuat Bingkai Zoom Bagian**

Anda dapat menambahkan bingkai zoom bagian ke slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2.	Buat slide baru. 
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda tautkan dengan bingkai zoom. 
5.	Tambahkan bingkai zoom bagian (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Menambahkan slide baru ke presentasi
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Menambahkan Section baru ke presentasi
    pres.sections.add_section("Section 1", slide)

    # Menambahkan objek SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Menyimpan presentasi
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```
### **Membuat Bingkai Zoom Bagian dengan Gambar Kustom**

Dengan Aspose.Slides untuk Python, Anda dapat membuat bingkai zoom bagian dengan gambar pratinjau slide yang berbeda dengan cara berikut: 

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2.	Buat slide baru.
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda tautkan dengan bingkai zoom. 
5.	Buat objek [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang akan digunakan untuk mengisi bingkai.
6.	Tambahkan bingkai zoom bagian (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
7.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Menambahkan slide baru ke presentasi
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Menambahkan Section baru ke presentasi
    pres.sections.add_section("Section 1", slide)

    # Membuat gambar baru untuk objek zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Menambahkan objek SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Menyimpan presentasi
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```
### **Memformat Bingkai Zoom Bagian**

Untuk membuat bingkai zoom bagian yang lebih rumit, Anda harus mengubah format bingkai sederhana. Ada beberapa opsi format yang dapat Anda terapkan pada bingkai zoom bagian. 

Anda dapat mengontrol format bingkai zoom bagian pada slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2.	Buat slide baru.
3.	Tambahkan latar belakang identifikasi ke slide yang dibuat.
4.	Buat bagian baru yang akan Anda tautkan dengan bingkai zoom. 
5.	Tambahkan bingkai zoom bagian (yang berisi referensi ke bagian yang dibuat) ke slide pertama.
6.	Ubah ukuran dan posisi objek zoom bagian yang dibuat.
7.	Buat objek [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) dengan menambahkan gambar ke koleksi Images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang akan digunakan untuk mengisi bingkai.
8.	Tetapkan gambar kustom untuk objek bingkai zoom bagian yang dibuat.
9.	Tetapkan kemampuan *kembali ke slide asli dari bagian yang ditautkan*. 
10.	Hapus latar belakang dari gambar objek bingkai zoom bagian.
11.	Ubah format garis untuk objek bingkai zoom kedua.
12.	Ubah durasi transisi.
13.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Menambahkan slide baru ke presentasi
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Menambahkan Section baru ke presentasi
    pres.sections.add_section("Section 1", slide)

    # Menambahkan objek SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Pemformatan untuk SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Menyimpan presentasi
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom Ringkasan**

Zoom ringkasan seperti halaman arahan tempat semua bagian presentasi Anda ditampilkan sekaligus. Saat Anda menyajikan, Anda dapat menggunakan zoom untuk berpindah dari satu tempat ke tempat lain dalam urutan apa pun yang Anda inginkan. Anda dapat berkreasi, melewatkan bagian, atau mengunjungi kembali potongan slide show tanpa mengganggu alur presentasi.

![ikhtisar gambar](summaryzoom.png)

Untuk objek zoom ringkasan, Aspose.Slides menyediakan kelas [SummaryZoomFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/id/python-net/aspose.slides/summaryzoomsection/), dan [SummaryZoomSectionCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/summaryzoomsectioncollection/) serta beberapa metode di kelas [ShapeCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/).

### **Membuat Zoom Ringkasan**

Anda dapat menambahkan bingkai zoom ringkasan ke slide dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan bingkai zoom ringkasan ke slide pertama.
4.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Buat array slide
    for slideNumber in range(5):
        #Tambahkan slide baru ke presentasi
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Buat latar belakang untuk slide
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Buat kotak teks untuk slide
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Buat objek zoom untuk semua slide di slide pertama
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Atur properti ReturnToParent untuk kembali ke slide pertama
        zoomFrame.return_to_parent = True

    # Simpan presentasi
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```
### **Menambahkan dan Menghapus Bagian Zoom Ringkasan**

Semua bagian dalam bingkai zoom ringkasan direpresentasikan oleh objek [SummaryZoomSection](https://reference.aspose.com/slides/id/python-net/aspose.slides/summaryzoomsection/), yang disimpan dalam objek [SummaryZoomSectionCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/summaryzoomsectioncollection/). Anda dapat menambahkan atau menghapus objek bagian zoom ringkasan melalui kelas [SummaryZoomSectionCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/summaryzoomsectioncollection/) dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan bingkai zoom ringkasan ke slide pertama.
4.	Tambahkan slide dan bagian baru ke presentasi.
5.	Tambahkan bagian yang dibuat ke bingkai zoom ringkasan.
6.	Hapus bagian pertama dari bingkai zoom ringkasan.
7.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Menambahkan slide baru ke presentasi
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Menambahkan section baru ke presentasi
    pres.sections.add_section("Section 1", slide)

    #Menambahkan slide baru ke presentasi
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Menambahkan section baru ke presentasi
    pres.sections.add_section("Section 2", slide)

    # Menambahkan objek SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Menambahkan slide baru ke presentasi
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Menambahkan section baru ke presentasi
    section3 = pres.sections.add_section("Section 3", slide)

    # Menambahkan section ke Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Menghapus section dari Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Menyimpan presentasi
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```
### **Memformat Bagian Zoom Ringkasan**

Untuk membuat objek bagian zoom ringkasan yang lebih rumit, Anda harus mengubah format bingkai sederhana. Ada beberapa opsi format yang dapat Anda terapkan pada objek bagian zoom ringkasan. 

Anda dapat mengontrol format objek bagian zoom ringkasan dalam bingkai zoom ringkasan dengan cara berikut:

1.	Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2.	Buat slide baru dengan latar belakang identifikasi dan bagian baru untuk slide yang dibuat.
3.	Tambahkan bingkai zoom ringkasan ke slide pertama.
4.	Dapatkan objek bagian zoom ringkasan untuk objek pertama dari `SummaryZoomSectionCollection`.
5.	Buat objek `PPImage` dengan menambahkan gambar ke koleksi images yang terkait dengan objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang akan digunakan untuk mengisi bingkai.
6.	Tetapkan gambar kustom untuk objek bingkai zoom bagian yang dibuat.
7.	Tetapkan kemampuan *kembali ke slide asli dari bagian yang ditautkan*. 
8.	Ubah format garis untuk objek bingkai zoom kedua.
9.	Ubah durasi transisi.
10.	Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Menambahkan slide baru ke presentasi
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Menambahkan section baru ke presentasi
    pres.sections.add_section("Section 1", slide)

    #Menambahkan slide baru ke presentasi
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Menambahkan section baru ke presentasi
    pres.sections.add_section("Section 2", slide)

    # Menambahkan objek SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Mendapatkan objek SummaryZoomSection pertama
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Pemformatan untuk objek SummaryZoomSection
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Menyimpan presentasi
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat mengontrol kembali ke slide 'induk' setelah menampilkan target?**

Ya. [Zoom frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/zoomframe/) atau [section](https://reference.aspose.com/slides/id/python-net/aspose.slides/sectionzoomframe/) memiliki perilaku `return_to_parent` yang, bila diaktifkan, mengirim penonton kembali ke slide asal setelah mereka mengunjungi konten target.

**Apakah saya dapat menyesuaikan 'kecepatan' atau durasi transisi Zoom?**

Ya. Zoom mendukung pengaturan `transition_duration` sehingga Anda dapat mengontrol berapa lama animasi lompatan berlangsung.

**Apakah ada batasan jumlah objek Zoom yang dapat dimiliki sebuah presentasi?**

Tidak ada batasan API keras yang didokumentasikan. Batas praktis bergantung pada kompleksitas keseluruhan presentasi dan kinerja penampil. Anda dapat menambahkan banyak bingkai Zoom, tetapi pertimbangkan ukuran file dan waktu rendering.