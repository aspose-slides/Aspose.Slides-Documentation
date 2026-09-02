---
title: Konversi Presentasi PowerPoint ke Markdown dengan Python
linktitle: PowerPoint ke Markdown
type: docs
weight: 140
url: /id/python-net/convert-powerpoint-to-markdown/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke MD
- presentasi ke MD
- slide ke MD
- PPT ke MD
- PPTX ke MD
- simpan PowerPoint sebagai Markdown
- simpan presentasi sebagai Markdown
- simpan slide sebagai Markdown
- simpan PPT sebagai MD
- simpan PPTX sebagai MD
- ekspor PPT ke MD
- ekspor PPTX ke MD
- ekspor gambar Markdown
- tautan gambar CDN
- PowerPoint
- presentasi
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: "Konversi presentasi PPT dan PPTX ke Markdown dengan Python serta mengontrol lokasi penyimpanan gambar yang diekspor dan cara referensi Markdown yang dihasilkan."
---
## **Gambaran Umum**

Aspose.Slides for Python via .NET dapat mengonversi presentasi PPT dan PPTX ke Markdown untuk dokumentasi, situs statis, migrasi konten, dan alur kerja kontrol versi. Anda dapat memilih variasi Markdown, mengontrol bagaimana konten slide dirender, dan memutuskan di mana gambar yang diekspor disimpan serta bagaimana Markdown yang dihasilkan merujuknya.

Secara default, ekspor Markdown menggunakan output hanya teks. Untuk mengekspor konten visual, set properti [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/markdownsaveoptions/export_type/) ke nilai `SEQUENTIAL` atau `VISUAL` dari enumerasi [MarkdownExportType](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/markdownexporttype/). `SEQUENTIAL` merender item slide secara terpisah dan berurutan, sementara `VISUAL` menjaga item yang dikelompokkan bersama untuk mempertahankan hubungan visual mereka. Nilai `TEXT_ONLY` tidak menghasilkan sumber daya gambar.

## **Konversi Presentasi ke Markdown**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/), kemudian panggil metode [Presentation.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/ipresentation/save/) dengan nilai `MD` dari enumerasi [SaveFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Pilih Variasi Markdown**

Properti [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/markdownsaveoptions/flavor/) mengontrol spesifikasi Markdown yang digunakan untuk output. Enumerasi [Flavor](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/flavor/) mencakup CommonMark, GitHub Flavored Markdown, dan varian lain yang didukung.

Contoh berikut mengekspor presentasi sebagai CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Ekspor Gambar dengan Perilaku Penyimpanan Lokal Default**

Kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/markdownsaveoptions/) menyediakan dua properti untuk gambar yang disimpan secara lokal:

- [base_path](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/markdownsaveoptions/base_path/) menentukan direktori dasar untuk dokumen Markdown dan sumber dayanya.
- [images_save_folder_name](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) menentukan subdirektori gambar. Nilai defaultnya adalah `Images`.

Contoh berikut merender konten visual, menulis gambar ke `output/assets`, dan membuat referensi gambar relatif dalam dokumen Markdown:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides membuat subdirektori gambar ketika ekspor menghasilkan sumber daya gambar, tetapi aplikasi harus membuat `base_path` sebelum menyimpan file Markdown.

## **Siapkan Markdown dan Gambar untuk Publikasi**

Aspose.Slides for Python via .NET tidak mengekspos callback penyimpanan gambar .NET untuk mengganti setiap tautan gambar yang dihasilkan selama ekspor. Sebagai gantinya, ekspor dokumen Markdown dan folder gambarnya ke direktori publikasi, lalu publikasikan direktori tersebut tanpa mengubah struktur relatifnya.

Contoh berikut menyiapkan `cdn-origin/presentations/quarterly-report` sebagai direktori publikasi yang dipasang atau disinkronkan. Contoh itu sendiri tidak melakukan unggahan jaringan: tautan yang dihasilkan menjadi valid setelah direktori dipublikasikan di situs atau lokasi CDN yang dimaksud.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Publikasikan `presentation.md` bersama dengan direktori `assets`. Dokumen Markdown menggunakan referensi gambar relatif, sehingga kedua item harus mempertahankan hubungan yang sama di tujuan. Jika sistem penerbitan memerlukan URL eksternal absolut, ubah tautan yang dihasilkan sebagai langkah pasca‑proses terpisah setelah semua file gambar dipublikasikan.

## **FAQ**

**Apakah callback Python dapat menyesuaikan file gambar individu dan tautan selama ekspor Markdown?**

Tidak. Aspose.Slides for Python via .NET tidak mengekspos callback .NET `ImageSaving` dan `SvgImageSaving`. Konfigurasikan output lokal dengan [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/markdownsaveoptions/base_path/) dan [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), kemudian publikasikan atau proses kembali sumber daya yang dihasilkan.

**Di mana gambar yang diekspor disimpan?**

Lokasi gambar dikontrol oleh [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/markdownsaveoptions/base_path/) dan [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). Dokumen Markdown merujuk gambar tersebut dengan jalur relatif.

**Pemisa jalur mana yang harus digunakan pada tautan gambar?**

Gunakan garis miring maju (`/`) pada tautan Markdown dan URL. Gunakan `os.path.join` hanya untuk jalur sistem berkas, dan normalisasikan setiap tautan yang dibuat selama pasca‑proses secara terpisah.

**Apakah tautan hiper tetap dipertahankan selama ekspor Markdown?**

Ya. Teks [hyperlinks](/slides/id/python-net/manage-hyperlinks/) dipertahankan sebagai tautan Markdown standar. Slide [transitions](/slides/id/python-net/slide-transition/) dan [animations](/slides/id/python-net/powerpoint-animation/) tidak dikonversi.

**Apakah presentasi dapat dikonversi ke Markdown secara paralel?**

Anda dapat memproses file presentasi yang berbeda secara paralel, tetapi jangan berbagi instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang sama antar thread. Ikuti [multithreading guidelines](/slides/id/python-net/multithreading/) dan gunakan instance terpisah untuk setiap file.