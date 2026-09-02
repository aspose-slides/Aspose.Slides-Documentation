---
title: Aspose.Slides untuk Python via .NET
second_title: Aspose.Slides untuk Python
type: docs
weight: 35
url: /id/python-net/
is_root: true
keywords:
- Aspose.Slides untuk Python
- Otomasi PowerPoint dengan Python
- Pustaka PPT Python
- Ekspor PowerPoint ke PDF dengan Python
- Ekspor PowerPoint ke SVG dengan Python
- Edit PowerPoint menggunakan Python
- PowerPoint Python tanpa Microsoft Office
- Kelola PPTX dengan Python
- Pratinjau slide dengan Python
- Python menambahkan audio ke slide
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET menawarkan seperangkat fitur lengkap, termasuk mengelola teks, bentuk, tabel, dan animasi, menambahkan audio dan video ke slide, meninjau slide, serta mengekspor ke SVG, PDF, dan lainnya."
---
{{% alert color="info" %}}

**Selamat datang di Aspose.Slides for Python via .NET**

![Logo Produk Aspose.Slides for Python via .NET](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET adalah pustaka kelas yang kuat yang memungkinkan aplikasi Anda membaca dan menulis presentasi PowerPoint® tanpa memerlukan Microsoft PowerPoint®.

Ini adalah komponen pertama dan satu-satunya yang menyediakan manajemen dokumen PowerPoint® lengkap bagi pengembang Python.

Aspose.Slides for Python via .NET mencakup berbagai fitur seperti bekerja dengan teks, bentuk, tabel, dan animasi; menambahkan audio dan video; meninjau slide; serta mengekspor slide ke format seperti SVG, PDF, dan lainnya.

{{% /alert %}}

## Instal Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

Paket ini menyertakan runtime .NET yang dibutuhkan, jadi tidak ada yang perlu diinstal lagi dan Microsoft PowerPoint tidak diperlukan. Python 3.7 atau lebih baru pada Windows, Linux, atau macOS.

## Buat Presentasi PowerPoint di Python

Contoh ini membuat sebuah presentasi, menambahkan bentuk dengan teks ke slide pertama, dan menyimpan hasilnya sebagai PPTX dan PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

Menjalankannya akan menulis `presentation.pptx` (sekitar 34 KB) dan `presentation.pdf` (sekitar 36 KB) ke direktori kerja.

Tanpa lisensi, pustaka berjalan dalam mode evaluasi, yang menambahkan watermark dan membatasi jumlah slide. Lihat [Lisensi](/slides/id/python-net/licensing/) untuk menerapkannya.

## Sumber Daya Aspose.Slides for Python via .NET

Jelajahi sumber daya berguna berikut:

- [Dokumentasi Online Aspose.Slides for Python via .NET](/slides/id/python-net/)
- [Fitur Aspose.Slides for Python via .NET](/slides/id/python-net/features-overview/)
- [Catatan Rilis Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/id/python-net/release-notes/)
- [Halaman Produk Aspose.Slides for Python via .NET](https://products.aspose.com/slides/id/python-net/)
- [Unduh Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/id/python-net/)
- [Pasang Paket PyPi Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/)
- [Panduan Referensi API Aspose.Slides for Python via .NET](https://reference.aspose.com/slides/id/python-net/)
- [Forum Dukungan Gratis Aspose.Slides for Python via .NET](https://forum.aspose.com/c/slides/id/11)
- [Helpdesk Dukungan Berbayar Aspose.Slides for Python via .NET](https://helpdesk.aspose.com/)

## Tanya Jawab

### Apa itu Aspose.Slides for Python via .NET?

Aspose.Slides for Python via .NET adalah pustaka Python yang kuat yang memungkinkan Anda membuat, mengedit, dan mengonversi presentasi PowerPoint (PPT, PPTX, ODP) secara programatik tanpa perlu menginstal Microsoft PowerPoint.

### Fitur presentasi apa yang didukung Aspose.Slides?

Pustaka ini mendukung pengelolaan teks, bentuk, tabel, diagram, animasi, master slide, audio, video, dan lainnya. Ia juga memungkinkan pratinjau slide, rendering, dan ekspor ke format seperti PDF, SVG, HTML, dan gambar.

### Bisakah saya mengonversi presentasi ke format lain menggunakan Aspose.Slides?

Ya. Aspose.Slides memungkinkan konversi file PowerPoint ke PDF, SVG, HTML, JPG, PNG, TIFF, dan format lain dengan fidelitas dan kinerja tinggi.

### Apakah Microsoft PowerPoint diperlukan untuk menggunakan Aspose.Slides?

Tidak. Aspose.Slides adalah API mandiri dan tidak memerlukan Microsoft Office atau perangkat lunak pihak ketiga apa pun.

### Platform apa yang didukung Aspose.Slides for Python via .NET?

Ini lintas platform dan bekerja pada lingkungan Windows, Linux, dan macOS.

### Bagaimana cara memulai dengan Aspose.Slides for Python?

Anda dapat menginstalnya melalui PyPi dan menjelajahi [Panduan Pengembang](/slides/id/python-net/developer-guide/) untuk memulai dengan contoh, referensi API, dan tutorial.