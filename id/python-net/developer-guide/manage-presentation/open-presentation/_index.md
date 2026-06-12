---
title: Membuka Presentasi dengan Python
linktitle: Membuka Presentasi
type: docs
weight: 20
url: /id/python-net/open-presentation/
keywords:
- buka PowerPoint
- buka presentasi
- buka PPTX
- buka PPT
- buka ODP
- muat presentasi
- muat PPTX
- muat PPT
- muat ODP
- presentasi terlindungi
- presentasi besar
- sumber daya eksternal
- objek biner
- Python
- Aspose.Slides
description: "Buka presentasi PowerPoint (.pptx, .ppt) dan OpenDocument (.odp) dengan mudah menggunakan Aspose.Slides untuk Python via .NET—cepat, andal, fitur lengkap."
---
## **Pendahuluan**

Selain membuat presentasi PowerPoint dari awal, Aspose.Slides juga memungkinkan Anda membuka presentasi yang sudah ada. Setelah memuat sebuah presentasi, Anda dapat mengambil informasi tentangnya, mengedit konten slide, menambahkan slide baru, menghapus slide yang ada, dan lain-lain.

## **Membuka Presentasi**

Untuk membuka sebuah presentasi yang sudah ada, buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan berikan jalur file ke konstruktorannya.

Contoh Python berikut menunjukkan cara membuka sebuah presentasi dan mendapatkan jumlah slide:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation dan memberikan jalur file ke konstruktor.
with slides.Presentation("sample.pptx") as presentation:
    # Mencetak total jumlah slide dalam presentasi.
    print(presentation.slides.length)
```

## **Membuka Presentasi yang Dilindungi Kata Sandi**

Ketika Anda perlu membuka presentasi yang dilindungi kata sandi, berikan kata sandi melalui properti [password](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/password/) dari kelas [LoadOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/) untuk mendekripsi dan memuatnya. Kode Python berikut mendemonstrasikan operasi ini:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Lakukan operasi pada presentasi yang telah didekripsi.
```

## **Membuka Presentasi Besar**

Aspose.Slides menyediakan opsi—khususnya properti [blob_management_options](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/blob_management_options/) dalam kelas [LoadOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/)—untuk membantu Anda memuat presentasi berukuran besar.

Kode Python berikut menunjukkan cara memuat presentasi besar (misalnya, 2 GB):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Pilih perilaku KeepLocked—file presentasi akan tetap terkunci selama masa hidup 
# instance Presentation, tetapi tidak perlu dimuat ke memori atau disalin ke file sementara.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # Presentasi besar telah dimuat dan dapat digunakan, sementara konsumsi memori tetap rendah.

    # Lakukan perubahan pada presentasi.
    presentation.slides[0].name = "Large presentation"

    # Simpan presentasi ke file lain. Konsumsi memori tetap rendah selama operasi ini.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Jangan lakukan ini! Pengecualian I/O akan dilempar karena file terkunci sampai objek presentasi dibuang.
    os.remove(file_path)

# Boleh dilakukan di sini. File sumber tidak lagi terkunci oleh objek presentasi.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
Untuk mengatasi batasan tertentu saat bekerja dengan stream, Aspose.Slides dapat menyalin isi stream. Memuat presentasi besar dari stream menyebabkan presentasi disalin dan dapat memperlambat proses pemuatan. Oleh karena itu, ketika Anda perlu memuat presentasi besar, kami sangat menyarankan menggunakan jalur file presentasi daripada stream.

Saat membuat presentasi yang berisi objek besar (video, audio, gambar resolusi tinggi, dll.), Anda dapat menggunakan [BLOB management](/slides/id/python-net/manage-blob/) untuk mengurangi konsumsi memori.
{{%/alert %}}

## **Memuat Presentasi Tanpa Objek Biner Tersemat**

Sebuah presentasi PowerPoint dapat berisi jenis objek biner tersemat berikut:

- Proyek VBA (dapat diakses melalui [Presentation.vba_project](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/vba_project/));
- Data tersemat objek OLE (dapat diakses melalui [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/id/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- Data biner kontrol ActiveX (dapat diakses melalui [Control.active_x_control_binary](https://reference.aspose.com/slides/id/python-net/aspose.slides/control/active_x_control_binary/)).

Dengan menggunakan properti [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/id/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/), Anda dapat memuat sebuah presentasi tanpa objek biner tersemat apa pun.

Properti ini berguna untuk menghapus konten biner yang berpotensi berbahaya. Kode Python berikut mendemonstrasikan cara memuat presentasi tanpa konten biner tersemat apa pun:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Lakukan operasi pada presentasi.
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa sebuah file rusak dan tidak dapat dibuka?**

Anda akan menerima pengecualian validasi parsing/format saat memuat. Kesalahan semacam ini biasanya menyebutkan struktur ZIP yang tidak valid atau rekaman PowerPoint yang rusak.

**Apa yang terjadi jika font yang diperlukan tidak ada saat membuka?**

File akan terbuka, tetapi kemudian [rendering/export](/slides/id/python-net/convert-presentation/) mungkin akan mengganti font. [Configure font substitutions](/slides/id/python-net/font-substitution/) atau [add the required fonts](/slides/id/python-net/custom-font/) ke lingkungan runtime.

**Bagaimana dengan media tersemat (video/audio) saat membuka?**

Media tersebut menjadi tersedia sebagai sumber daya presentasi. Jika media direferensikan melalui jalur eksternal, pastikan jalur tersebut dapat diakses di lingkungan Anda; bila tidak, [rendering/export](/slides/id/python-net/convert-presentation/) mungkin akan mengabaikan media.