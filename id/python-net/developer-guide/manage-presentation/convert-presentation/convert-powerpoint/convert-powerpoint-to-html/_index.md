---
title: Mengonversi Presentasi PowerPoint ke HTML dengan Python
linktitle: PowerPoint ke HTML
type: docs
weight: 30
url: /id/python-net/convert-powerpoint-to-html/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke HTML
- presentasi ke HTML
- slide ke HTML
- PPT ke HTML
- PPTX ke HTML
- simpan PowerPoint sebagai HTML
- simpan presentasi sebagai HTML
- simpan slide sebagai HTML
- simpan PPT sebagai HTML
- simpan PPTX sebagai HTML
- ekspor PPT ke HTML
- ekspor PPTX ke HTML
- Python
- Aspose.Slides
description: "Konversi presentasi PowerPoint ke HTML dengan Python. Gunakan Aspose.Slides untuk mengekspor file PPT dan PPTX, slide terpilih, catatan, font, gambar, SVG, dan media."
---
## **Overview**

Aspose.Slides untuk Python via .NET dapat menyimpan presentasi PowerPoint sebagai HTML tanpa Microsoft PowerPoint. Konversi dasar adalah memuat satu [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan memanggil `save` dengan [SaveFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/). Gunakan [HtmlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmloptions/) ketika Anda perlu mengontrol tata letak, font, gambar, catatan, komentar, output SVG, atau sumber daya yang ditautkan.

Panduan ini berfokus pada skenario ekspor HTML yang praktis:

- Ekspor seluruh presentasi atau slide yang dipilih.
- Hasilkan HTML dengan tata letak tetap, responsif, atau berbasis SVG.
- Sertakan catatan pembicara dan komentar.
- Kontrol kualitas gambar dan data gambar yang dipangkas.
- Sematkan font atau simpan file font secara terpisah.
- Pilih cara sumber daya eksternal dan file media ditulis dan direferensikan.

Secara default, ekspor HTML menghasilkan dokumen HTML yang mandiri di mana sebagian besar sumber daya disematkan. Ini memudahkan berbagi satu file, tetapi dapat meningkatkan ukuran output. Untuk penerbitan web, pertimbangkan sumber daya eksternal, menurunkan DPI gambar, dan hanya menyematkan font yang tidak tersedia secara andal di lingkungan target.

## **Convert a Presentation to HTML**

Untuk mengekspor sebuah presentasi ke HTML, muat dengan [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan simpan dengan [SaveFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Contoh ini menulis satu file HTML. Pernyataan `with` membuang objek presentation dan melepaskan handle file serta sumber daya rendering setelah ekspor.

## **Use HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmloptions/) adalah kelas konfigurasi utama untuk ekspor HTML. Pengaturan umum meliputi:

- `slides_layout_options`: menambahkan catatan, komentar, handout, atau informasi tata letak lainnya.
- `html_formatter`: mengubah struktur dokumen HTML atau mendelegasikan pemformatan ke sebuah controller.
- `slide_image_format`: mengubah cara slide direpresentasikan, misalnya sebagai SVG.
- `pictures_compression`: mengontrol DPI gambar dan ukuran output.
- `delete_pictures_cropped_areas`: mempertahankan atau menghapus data gambar yang dipangkas.
- `svg_responsive_layout`: membuat konten SVG yang diekspor menyesuaikan dengan kontainer.
- `show_hidden_slides`: menyertakan slide tersembunyi bila diperlukan.

Bagian berikut menunjukkan opsi paling umum secara terpisah sehingga Anda dapat menggabungkan hanya yang diperlukan oleh alur kerja Anda.

## **Convert Selected Slides to HTML**

`save` overload yang menerima nomor slide menggunakan posisi slide berbasis 1. Loop di bawah menyimpan setiap slide ke file HTML terpisah.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Gunakan pola ini ketika sebuah situs web atau aplikasi membutuhkan satu halaman HTML per slide. Jika setiap slide harus memiliki tata letak yang sama, buat satu instance [HtmlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmloptions/) dan berikan ke setiap pemanggilan `save`.

## **Create Responsive HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/responsivehtmlcontroller/) menyediakan output HTML responsif melalui [HtmlFormatter](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmlformatter/). Gunakan ketika halaman yang diekspor harus lebih baik beradaptasi dengan lebar browser.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

Untuk tata letak responsif berbasis SVG, atur `svg_responsive_layout` pada [HtmlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmloptions/). Ini berguna ketika konten slide diekspor sebagai markup SVG yang skalabel.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Include Speaker Notes and Comments**

Gunakan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/notescommentslayoutingoptions/) melalui `html_options.slides_layout_options` untuk menyertakan catatan pembicara atau komentar. Catatan dan komentar disembunyikan secara default kecuali Anda memilih posisinya.

Misalkan presentasi sumber berisi catatan pembicara:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Kode berikut mengekspor konten slide dengan catatan pembicara di bawah slide.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

HTML yang diekspor menyertakan area catatan:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Untuk mengekspor komentar, atur `comments_position`, misalnya ke `CommentsPositions.RIGHT` atau `CommentsPositions.BOTTOM`. Jika Anda hanya memerlukan komentar, hapus `notes_position`. Jika Anda memerlukan keduanya, atur kedua properti tersebut.

## **Control Image Quality and Cropped Areas**

Ekspor HTML dapat mengompres gambar slide untuk mengurangi ukuran output. Atur `pictures_compression` ke nilai dari [PicturesCompression](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/picturescompression/) ketika Anda memerlukan kualitas gambar yang lebih tinggi.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

Secara default, area yang dipangkas dari gambar dapat dihapus dari output yang diekspor. Simpan data yang dipangkas hanya ketika pengguna harus dapat memulihkan atau memeriksa bagian gambar yang tersembunyi tersebut. Menyimpannya dapat meningkatkan ukuran HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **Add CSS**

Untuk styling sederhana, berikan string CSS ke [HtmlFormatter](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmlformatter/). Ini mengubah dokumen HTML di sekitarnya sementara Aspose.Slides tetap merender konten slide.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Untuk header dokumen khusus, file CSS yang ditautkan, atau markup khusus di sekitar slide dan shape, gunakan controller format khusus dan berikan ke [HtmlFormatter](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmlformatter/) dengan `create_custom_formatter`.

## **Embed Fonts**

Jika lingkungan target mungkin tidak memiliki font presentasi yang terpasang, sematkan font dalam HTML dengan [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Penyematan meningkatkan kesetiaan visual tetapi menambah ukuran output.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Kecualikan sebuah font hanya ketika Anda yakin bahwa peramban atau sistem target sudah menyediakan font tersebut. Untuk font merek atau font yang kurang umum, penyematan biasanya lebih aman.

## **Link Font Files Instead of Embedding Them**

Untuk mengurangi ukuran file HTML, Anda dapat menulis data font ke file WOFF terpisah dan menambahkan aturan `@font-face` ke HTML. Ini memerlukan controller yang menyesuaikan cara data font ditulis selama ekspor. Di Python via .NET, implementasikan controller tersebut dalam assembly helper .NET kecil, muat di Python, dan berikan objek helper ke [HtmlFormatter](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmlformatter/) dengan `create_custom_formatter`.

Saat Anda mengeksternalisasi font, pilih dua jalur dengan sengaja:

- Direktori output sistem file tempat file WOFF yang dihasilkan akan ditulis.
- Path URL yang akan muncul di dokumen HTML dan yang akan digunakan browser untuk memuat file font tersebut.

Simpan file HTML dan file font yang dihasilkan bersama sampai jalur penyebaran final. Jika file disebarkan ke lokasi lain, pastikan prefiks URL cocok dengan jalur URL yang disebarkan.

## **Save Resources Externally**

HTML yang mandiri mudah dipindahkan, tetapi sumber daya Base64 yang disematkan dapat membuat file menjadi besar. Jika aplikasi Anda memerlukan file gambar, font, audio, atau video eksternal, gunakan controller link/embed khusus dan berikan ke konstruktor [HtmlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmloptions/).

Saat Anda mengeksternalisasi sumber daya, pilih dua jalur dengan sengaja:

- Path output sistem file, tempat aplikasi Anda menulis gambar, font, audio, atau video yang dihasilkan.
- Path URL, yaitu apa yang digunakan browser dari dokumen HTML untuk memuat file-file tersebut.

Untuk pembahasan lengkap tentang penautan gambar, lihat [Export Presentations to HTML with Externally Linked Images](/slides/id/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Export Media Files**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/videoplayerhtmlcontroller/) mengekspor file video dan audio serta menulis HTML yang dapat memainkannya di peramban. Konstruktornya menerima:

- `path`: direktori tempat file media yang dihasilkan akan ditulis.
- `file_name`: nama file HTML yang sedang dihasilkan.
- `base_uri`: prefiks URI absolut yang digunakan dalam tautan HTML ke file media.

Jika file HTML adalah `html-output/presentation.html` dan file media disimpan di `html-output/media`, `path` harus mengacu ke direktori media di disk, sementara `base_uri` harus mengacu ke direktori yang sama dari perspektif peramban. Untuk pratinjau lokal, Anda dapat membangun URI `file:///` dari direktori media. Untuk aplikasi yang disebarkan, gunakan URL absolut dari direktori media yang dipublikasikan.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Gunakan direktori output yang unik per pekerjaan ekspor, terutama pada aplikasi server. Path output yang dibagi dapat menyebabkan file dari konversi berbeda saling menimpa.

## **Performance and Resource Management**

Konversi HTML adalah operasi rendering, sehingga waktu pemrosesan dan penggunaan memori bergantung pada jumlah slide, resolusi gambar, font, efek, diagram, dan media yang disematkan. Nilai DPI `pictures_compression` yang lebih tinggi, font yang disematkan, output SVG, dan area gambar yang dipangkas yang dipertahankan dapat meningkatkan kesetiaan tetapi biasanya menambah ukuran output.

Untuk konversi batch:

- Segera dispose setiap instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
- Gunakan direktori output terpisah untuk pekerjaan yang terpisah.
- Hindari menyematkan font umum kecuali diperlukan untuk kesetiaan.
- Turunkan DPI gambar ketika HTML hanya untuk pratinjau atau thumbnail.
- Simpan presentasi sumber, HTML yang dihasilkan, dan sumber daya eksternal bersama-sama hingga path penyebaran final.

## **FAQ**

**Are hyperlinks preserved in HTML output?**  
**Apakah hyperlink dipertahankan dalam output HTML?**  
Ya. Hyperlink presentasi diekspor ke HTML dan tetap dapat diklik ketika URL target valid.

**Can I convert presentations to HTML in parallel?**  
**Bisakah saya mengonversi presentasi ke HTML secara paralel?**  
Ya, tetapi jangan berbagi satu instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) di beberapa thread. Proses file yang berbeda dengan instance presentation terpisah, aliran terpisah, dan direktori output terpisah. Lihat [multithreading guidance](/slides/id/python-net/multithreading/) untuk detailnya.

**Is a Presentation object thread-safe?**  
**Apakah objek Presentation aman untuk thread?**  
Tidak. Satu instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) harus dimuat, dimodifikasi, disimpan, dan di‑dispose pada satu thread. Untuk pekerjaan paralel, buat instance independen per thread atau proses.

**Why is the generated HTML file large?**  
**Mengapa file HTML yang dihasilkan besar?**  
Ekspor default dapat menyematkan sumber daya langsung ke HTML. Font yang disematkan, gambar DPI tinggi, media, konten SVG, dan area gambar yang dipangkas yang dipertahankan semuanya menambah ukuran. Gunakan sumber daya eksternal, kecualikan font umum dari penyematan, dan turunkan `pictures_compression` ketika keluaran yang lebih kecil lebih penting daripada kesetiaan maksimum.

**Why does a PowerPoint font size such as 24 pt appear as 17.999819 pt in HTML?**  
**Mengapa ukuran font PowerPoint seperti 24 pt muncul sebagai 17,999819 pt di HTML?**  
Hal ini dapat terjadi karena PowerPoint dan HTML menggunakan model DPI yang berbeda. PowerPoint menyimpan ukuran teks dalam poin tipografis berdasarkan 72 DPI, sementara tata letak HTML didasarkan pada piksel CSS dalam model 96 DPI. Saat Aspose.Slides mengekspor presentasi ke HTML, ukuran font diterjemahkan antara kedua sistem tersebut, dan konversi dapat memperkenalkan perbedaan pembulatan kecil. Nilai‑nilai ini tidak menunjukkan perubahan ukuran visual yang nyata; mereka hanyalah efek samping matematis dari konversi metrik teks antara PowerPoint dan HTML.

**How should I choose base_uri for media export?**  
**Bagaimana saya harus memilih base_uri untuk ekspor media?**  
Pilih `base_uri` dari perspektif peramban dan berikan sebagai URI absolut. Untuk pratinjau lokal, Anda dapat menurunkannya dari direktori output dengan `Path(media_directory).as_uri() + "/"`. Untuk penyebaran, gunakan URL absolut dari direktori media yang dipublikasikan. Path sistem file `path` dan `base_uri` browser tidak harus berupa string yang sama, tetapi keduanya harus menggambarkan lokasi sumber daya yang sama.

**Can I include hidden slides?**  
**Bisakah saya menyertakan slide tersembunyi?**  
Ya. Atur `show_hidden_slides = True` pada [HtmlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmloptions/) ketika slide tersembunyi harus diekspor.