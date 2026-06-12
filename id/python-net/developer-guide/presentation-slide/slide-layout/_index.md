---
title: Menerapkan atau Mengubah Tata Letak Slide di Python
linktitle: Tata Letak Slide
type: docs
weight: 60
url: /id/python-net/slide-layout/
keywords:
- tata letak slide
- tata letak konten
- placeholder
- desain presentasi
- desain slide
- tata letak tidak terpakai
- visibilitas footer
- slide judul
- judul dan konten
- tajuk bagian
- dua konten
- perbandingan
- hanya judul
- tata letak kosong
- konten dengan keterangan
- gambar dengan keterangan
- judul dan teks vertikal
- judul vertikal dan teks
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Pelajari cara mengelola dan menyesuaikan tata letak slide di Aspose.Slides untuk Python melalui .NET. Jelajahi jenis tata letak, kontrol placeholder, visibilitas footer, dan manipulasi tata letak melalui contoh kode dalam Python."
---
## **Pendahuluan**

Sebuah tata letak slide mendefinisikan pengaturan kotak placeholder dan pemformatan untuk konten pada slide. Ini mengontrol placeholder mana yang tersedia dan di mana mereka muncul. Tata letak slide membantu Anda merancang presentasi dengan cepat dan konsisten—baik Anda membuat sesuatu yang sederhana maupun yang lebih kompleks. Beberapa tata letak slide yang paling umum di PowerPoint meliputi:

**Title Slide layout** – Mencakup dua placeholder teks: satu untuk judul dan satu untuk subtitel.

**Title and Content layout** – Menampilkan placeholder judul yang lebih kecil di bagian atas dan yang lebih besar di bawah untuk konten utama (seperti teks, poin-poin, bagan, gambar, dan lainnya).

**Blank layout** – Tidak berisi placeholder, memberikan Anda kontrol penuh untuk merancang slide dari awal.

Tata letak slide merupakan bagian dari slide master, yang merupakan slide tingkat atas yang mendefinisikan gaya tata letak untuk presentasi. Anda dapat mengakses dan memodifikasi tata letak slide melalui slide master—baik berdasarkan tipe, nama, atau ID uniknya. Alternatifnya, Anda dapat mengedit tata letak slide tertentu secara langsung dalam presentasi.

Untuk bekerja dengan tata letak slide di Aspose.Slides for Python, Anda dapat menggunakan:

- Properti seperti [layout_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/layout_slides/) dan [masters](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/masters/) di bawah kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) 
- Tipe seperti [LayoutSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutplaceholdermanager/), dan [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Untuk mempelajari lebih lanjut tentang bekerja dengan slide master, lihat artikel [Kelola Slide Master PowerPoint di Python](/slides/id/python-net/slide-master/).
{{% /alert %}}

## **Menambahkan Tata Letak Slide ke Presentasi**

Untuk menyesuaikan tampilan dan struktur slide Anda, Anda mungkin perlu menambahkan tata letak slide baru ke sebuah presentasi. Aspose.Slides for Python memungkinkan Anda memeriksa apakah tata letak tertentu sudah ada, menambahkan yang baru jika diperlukan, dan menggunakannya untuk menyisipkan slide berdasarkan tata letak tersebut.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Akses [MasterLayoutSlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterlayoutslidecollection/).
3. Periksa apakah tata letak slide yang diinginkan sudah ada dalam koleksi. Jika tidak, tambahkan tata letak slide yang Anda butuhkan.
4. Tambahkan slide kosong berdasarkan tata letak slide baru.
5. Simpan presentasi.

Kode Python berikut menunjukkan cara menambahkan tata letak slide ke presentasi PowerPoint:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation untuk membuka file presentasi.
with slides.Presentation("sample.pptx") as presentation:
    # Melalui semua tipe slide tata letak untuk memilih slide tata letak.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Situasi di mana presentasi tidak berisi semua tipe tata letak.
        # File presentasi hanya berisi tipe tata letak Blank dan Custom.
        # Namun, slide tata letak dengan tipe khusus mungkin memiliki nama yang dapat dikenali,
        # seperti "Title", "Title and Content", dll., yang dapat digunakan untuk pemilihan slide tata letak.
        # Anda juga dapat mengandalkan sekumpulan tipe bentuk placeholder.
        # Sebagai contoh, slide Title seharusnya hanya memiliki tipe placeholder Title, dan seterusnya.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Menambahkan slide kosong menggunakan slide tata letak yang ditambahkan.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Menyimpan presentasi ke disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Menghapus Tata Letak Slide yang Tidak Digunakan**

Aspose.Slides menyediakan metode [remove_unused_layout_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) dari kelas [Compress](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/) untuk memungkinkan Anda menghapus tata letak slide yang tidak diinginkan dan tidak terpakai.

Kode Python berikut menunjukkan cara menghapus tata letak slide dari presentasi PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Menambahkan Placeholder ke Tata Letak Slide**

Aspose.Slides menyediakan properti [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/placeholder_manager/), yang memungkinkan Anda menambahkan placeholder baru ke sebuah tata letak slide.

Manajer ini berisi metode untuk tipe placeholder berikut:

| Placeholder PowerPoint | Metode [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutplaceholdermanager/) |
| ---------------------- | ------------------------------------------------------------ |
| ![Konten](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Konten (Vertikal)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Teks](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Teks (Vertikal)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Gambar](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Diagram](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Tabel](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Gambar Online](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

Kode Python berikut menunjukkan cara menambahkan bentuk placeholder baru ke tata letak Blank:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Dapatkan slide tata letak Blank.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Dapatkan manajer placeholder dari slide tata letak.
    placeholder_manager = layout.placeholder_manager

    # Tambahkan placeholder berbeda ke slide tata letak Blank.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Tambahkan slide baru dengan tata letak Blank.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The placeholders on the layout slide](add_placeholders.png)

## **Mengatur Visibilitas Footer untuk Tata Letak Slide**

Dalam presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat ditampilkan atau disembunyikan tergantung pada tata letak slide. Aspose.Slides for Python memungkinkan Anda mengontrol visibilitas placeholder footer ini. Hal ini berguna ketika Anda ingin tata letak tertentu menampilkan informasi footer sementara yang lain tetap bersih dan minimal.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi tata letak slide berdasarkan indeksnya.
3. Atur placeholder footer slide menjadi terlihat.
4. Atur placeholder nomor slide menjadi terlihat.
5. Atur placeholder tanggal-waktu menjadi terlihat.
Simpan presentasi.

Kode Python berikut menunjukkan cara mengatur visibilitas footer slide dan melakukan tugas terkait:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **Mengatur Visibilitas Footer Anak untuk Slide**

Dalam presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat dikontrol pada tingkat slide master untuk memastikan konsistensi di semua tata letak slide. Aspose.Slides for Python memungkinkan Anda mengatur visibilitas dan konten placeholder footer ini pada slide master dan menyebarkan pengaturan tersebut ke semua tata letak slide anak. Pendekatan ini memastikan informasi footer yang seragam di seluruh presentasi.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide master berdasarkan indeksnya.
3. Atur placeholder footer master dan semua anak menjadi terlihat.
4. Atur placeholder nomor slide master dan semua anak menjadi terlihat.
5. Atur placeholder tanggal-waktu master dan semua anak menjadi terlihat.
Simpan presentasi.

Kode Python berikut mendemonstrasikan operasi ini:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apa perbedaan antara slide master dan slide tata letak?**

Sebuah slide master mendefinisikan tema keseluruhan dan pemformatan default, sementara slide tata letak mendefinisikan pengaturan spesifik placeholder untuk berbagai jenis konten.

**Apakah saya dapat menyalin slide tata letak dari satu presentasi ke presentasi lain?**

Ya, Anda dapat mengkloning slide tata letak dari koleksi [layout_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/layout_slides/) sebuah presentasi dan menyisipkannya ke presentasi lain menggunakan metode `add_clone`.

**Apa yang terjadi jika saya menghapus slide tata letak yang masih digunakan oleh slide lain?**

Jika Anda mencoba menghapus slide tata letak yang masih direferensikan oleh setidaknya satu slide dalam presentasi, Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/python-net/aspose.slides/pptxeditexception/). Untuk menghindarinya, gunakan [remove_unused_layout_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) yang secara aman menghapus hanya tata letak slide yang tidak digunakan.