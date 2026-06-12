---
title: Konversi Presentasi PowerPoint ke Markdown dengan Python
linktitle: PowerPoint ke Markdown
type: docs
weight: 140
url: /id/python-net/convert-powerpoint-to-markdown/
keywords:
- konversi PowerPoint ke Markdown
- konversi OpenDocument ke Markdown
- konversi presentasi ke Markdown
- konversi slide ke Markdown
- konversi PPT ke Markdown
- konversi PPTX ke Markdown
- konversi ODP ke Markdown
- konversi PowerPoint ke MD
- konversi OpenDocument ke MD
- konversi presentasi ke MD
- konversi slide ke MD
- konversi PPT ke MD
- konversi PPTX ke MD
- konversi ODP ke MD
- PowerPoint
- OpenDocument
- presentasi
- Markdown
- Python
- Aspose.Slides
description: "Konversi slide PowerPoint dan OpenDocument—PPT, PPTX, ODP—menjadi Markdown bersih dengan Aspose.Slides untuk Python via .NET, otomatisasi dokumentasi dan mempertahankan format."
---
## **Pendahuluan**

Aspose.Slides memungkinkan Anda mengonversi presentasi PowerPoint ke Markdown, yang dapat berguna untuk alur kerja dokumentasi, pembuatan situs statis, migrasi konten, dan penerbitan teks yang dikontrol versi. API mendukung ekspor langsung dari presentasi PPT dan PPTX ke file MD dan menyediakan opsi tambahan untuk mengatur bagaimana konten slide direpresentasikan dalam dokumen Markdown yang dihasilkan.

Anda dapat mengekspor presentasi sebagai Markdown biasa, memilih dari berbagai varian Markdown seperti CommonMark dan GitHub Flavored Markdown, serta mengonfigurasi cara penanganan gambar selama ekspor. Untuk presentasi yang berisi konten visual, Aspose.Slides juga memungkinkan Anda menyimpan gambar ke folder terpisah dan merujuknya dari file Markdown yang dihasilkan.

{{% alert color="warning" %}}
Ekspor PowerPoint-ke-Markdown **tanpa gambar** secara default. Jika Anda ingin mengekspor dokumen PowerPoint yang berisi gambar, Anda harus mengatur `export_type = MarkdownExportType.VISUAL` dan menentukan `base_path`, tempat gambar yang dirujuk dalam dokumen Markdown akan disimpan.
{{% /alert %}}

## **Konversi Presentasi ke Markdown**

Contoh di bawah menunjukkan cara paling sederhana untuk mengonversi presentasi PowerPoint ke Markdown menggunakan Aspose.Slides untuk Python via .NET dengan pengaturan default.

1. Buat instance sebuah [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk memuat presentasi.
1. Panggil `save` untuk mengekspornya sebagai file Markdown.

Gunakan potongan kode Python di bawah ini untuk melakukan konversi:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Konversi Presentasi ke Varian Markdown**

Aspose.Slides memungkinkan Anda mengonversi presentasi ke format Markdown, termasuk Markdown dasar, CommonMark, GitHub-flavored Markdown, Trello, XWiki, GitLab, dan 17 varian Markdown lainnya.

Contoh Python berikut menunjukkan cara mengonversi presentasi PowerPoint ke CommonMark:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

23 varian Markdown yang didukung tercantum dalam enumerasi [Flavor](https://reference.aspose.com/slides/id/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) pada kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Konversi Presentasi yang Berisi Gambar ke Markdown**

Kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) menyediakan properti dan enumerasi yang memungkinkan Anda mengonfigurasi file Markdown yang dihasilkan. Misalnya, enum [MarkdownExportType](https://reference.aspose.com/slides/id/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) mengatur cara penanganan gambar: `SEQUENTIAL`, `TEXT_ONLY`, atau `VISUAL`.

### **Konversi Gambar Secara Berurutan**

Jika Anda menginginkan gambar muncul secara terpisah—satu per satu—in dalam Markdown yang dihasilkan, pilih opsi `SEQUENTIAL`. Contoh Python di bawah ini menunjukkan cara mengonversi presentasi dengan gambar ke Markdown.

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **Konversi Gambar Secara Visual**

Jika Anda menginginkan gambar muncul bersamaan dalam Markdown yang dihasilkan, pilih opsi `VISUAL`. Dalam mode ini, gambar disimpan ke direktori saat ini aplikasi (dan dokumen Markdown menggunakan jalur relatif), atau Anda dapat menentukan jalur keluaran khusus dan nama folder.

Contoh Python berikut mendemonstrasikan operasi ini:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **FAQ**

**Apakah hyperlink tetap ada setelah ekspor ke Markdown?**

Ya. Teks [hyperlinks](/slides/id/python-net/manage-hyperlinks/) dipertahankan sebagai tautan Markdown standar. Slide [transitions](/slides/id/python-net/slide-transition/) dan [animations](/slides/id/python-net/powerpoint-animation/) tidak dikonversi.

**Bisakah saya mempercepat konversi dengan menjalankannya di beberapa thread?**

Anda dapat memparallelkan antar file, tetapi [don’t share](/slides/id/python-net/multithreading/) instance [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang sama di antara thread. Gunakan instance/proses terpisah per file untuk menghindari kontensi.

**Apa yang terjadi pada gambar—di mana mereka disimpan, dan apakah jalurnya relatif?**

[Images](/slides/id/python-net/image/) diekspor ke folder khusus, dan file Markdown merujuknya dengan jalur relatif secara default. Anda dapat mengonfigurasi jalur output dasar dan nama folder aset untuk menjaga struktur repositori yang dapat diprediksi.