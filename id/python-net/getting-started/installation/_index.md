---
title: Instalasi
type: docs
weight: 70
url: /id/python-net/installation/
keywords:
- unduh Aspose.Slides
- instal Aspose.Slides
- gunakan Aspose.Slides
- instalasi Aspose.Slides
- Windows
- macOS
- Python
description: "Pelajari cara menginstal Aspose.Slides untuk Python via .NET dengan cepat. Panduan langkah demi langkah, persyaratan sistem, dan contoh kode — mulai bekerja dengan presentasi PowerPoint hari ini!"
---
## **Ikhtisar**

Paket Aspose.Slides for Python via .NET menyertakan semua pustaka .NET penting secara terbundel, sehingga tidak perlu menginstal .NET secara terpisah. Hal ini menyederhanakan proses penyiapan dan memungkinkan pengembang mulai bekerja dengan presentasi segera. Namun, penting untuk dicatat bahwa tergantung pada sistem operasi atau lingkungan Anda, Anda mungkin tetap perlu menginstal beberapa ketergantungan spesifik platform yang dibutuhkan oleh .NET. Selain itu, beberapa persyaratan sistem harus dipenuhi agar paket dapat berfungsi dengan kompatibilitas penuh.

## **Windows**

**Persyaratan Sistem**

Periksa dan pastikan bahwa spesifikasi mesin Anda memenuhi atau melampaui [persyaratan sistem](/slides/id/python-net/system-requirements/).

### **Instal Aspose.Slides**

`pip` adalah cara termudah untuk mengunduh dan menginstal [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) di Windows.

Untuk menginstal Aspose.Slides, jalankan perintah berikut:

```sh
pip install aspose-slides
```

**Gunakan Aspose.Slides**

Uji instalasi Aspose.Slides Anda dengan menjalankan kode berikut untuk membuat presentasi PowerPoint:

```python
# Impor modul Aspose.Slides untuk Python via .NET.
import aspose.slides as slides

# Buat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Persyaratan Sistem**

Periksa dan pastikan bahwa spesifikasi mesin Anda memenuhi atau melampaui [persyaratan sistem](/slides/id/python-net/system-requirements/).

### **Prasyarat**

**Python dengan Perpustakaan Bersama**

Ada beberapa cara untuk menginstal Python di macOS, tetapi kami sangat menyarankan menggunakan [pyenv tool](https://github.com/pyenv/pyenv#homebrew-in-macos).

Setelah menginstal dan mengkonfigurasi **pyenv**, instal Python dengan perpustakaan bersama dengan menjalankan perintah berikut di aplikasi Terminal:

1. Instal Python:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. Atur sebagai versi Python global:

```sh
pyenv global 3.9.13
```

3. Atur sebagai versi Python khusus shell:

```sh
pyenv shell 3.9.13
```

4. Buat tautan simbolik untuk pustaka libpython di direktori pustaka sistem:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

Catatan: Python 3.5 atau lebih tinggi diperlukan. Versi 3.9.13 digunakan di sini hanya sebagai contoh.

**Instal Perpustakaan libgdiplus**

Perpustakaan **libgdiplus** adalah implementasi Windows GDI+ untuk macOS dan Linux yang menjadi ketergantungan .NET untuk fungsi grafis pada platform tersebut.  
Untuk menginstal perpustakaan ini di macOS, jalankan perintah berikut:

```sh
brew install mono-libgdiplus
```

### **Instal Aspose.Slides**

`pip` adalah cara termudah untuk mengunduh dan menginstal [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) di macOS.

Untuk menginstal Aspose.Slides, jalankan perintah berikut:

```sh
pip install aspose-slides
```

**Gunakan Aspose.Slides**

Uji instalasi Aspose.Slides Anda dengan menjalankan kode berikut untuk membuat presentasi PowerPoint:

```python
# Impor modul Aspose.Slides untuk Python via .NET.
import aspose.slides as slides

# Buat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat menginstal Aspose.Slides di lingkungan virtual?**

Ya, Anda dapat menginstalnya di lingkungan virtual Python apa pun menggunakan `pip`. Pastikan saja lingkungan tersebut memiliki akses ke dependensi native yang diperlukan tergantung pada OS Anda.

**Apakah saya dapat menggunakan Aspose.Slides dalam kontainer Docker?**

Ya, tetapi Anda harus memastikan image Docker Anda mencakup perpustakaan native yang diperlukan (**libgdiplus**, paket font, dll.) dan versi Python yang tepat.

**Apakah ada versi gratis atau batasan trial?**

Ya, secara default, Aspose.Slides berjalan dalam mode evaluasi, yang menambahkan watermark dan mungkin memiliki batasan lain. Untuk menghapus pembatasan, Anda perlu menerapkan [lisensi](/slides/id/python-net/licensing/) yang valid.