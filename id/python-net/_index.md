---
title: "Aspose.Slides untuk Python via .NET"
second_title: "Aspose.Slides untuk Python"
type: docs
weight: 35
url: /id/python-net/
is_root: true
keywords:
- "Aspose.Slides untuk Python"
- "Otomasi PowerPoint dengan Python"
- "Pustaka PPT Python"
- "Ekspor PowerPoint ke PDF dengan Python"
- "Ekspor PowerPoint ke SVG dengan Python"
- "Edit PowerPoint di Python"
- "PowerPoint Python tanpa Microsoft Office"
- "Kelola PPTX dengan Python"
- "Pratinjau slide dengan Python"
- "Python menambahkan audio ke slide"
- "PowerPoint"
- "OpenDocument"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET menawarkan rangkaian fitur lengkap, termasuk mengelola teks, bentuk, tabel, dan animasi, menambahkan audio dan video ke slide, menampilkan pratinjau slide, serta mengekspor ke SVG, PDF, dan lainnya."
---
{{% alert color="primary" %}}

**Selamat datang di Aspose.Slides for Python via .NET**

![Aspose.Slides for Python via .NET Product Logo](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET adalah pustaka kelas yang kuat yang memungkinkan aplikasi Anda membaca dan menulis presentasi PowerPoint® tanpa memerlukan Microsoft PowerPoint®.

Ini adalah komponen pertama dan satu-satunya yang menyediakan manajemen dokumen PowerPoint® lengkap untuk pengembang Python.

Aspose.Slides for Python via .NET mencakup berbagai fitur seperti bekerja dengan teks, bentuk, tabel, dan animasi; menambahkan audio dan video; meninjau slide; dan mengekspor slide ke format seperti SVG, PDF, dan lainnya.

{{% /alert %}}

## Instal Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

Paket ini menyertakan runtime .NET yang diperlukan, sehingga tidak ada hal lain yang perlu diinstal dan Microsoft PowerPoint tidak diperlukan. Python 3.7 atau lebih baru di Windows, Linux, atau macOS.

## Membuat Presentasi PowerPoint di Python

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

Tanpa lisensi perpustakaan berjalan dalam mode evaluasi, yang menambahkan watermark dan membatasi jumlah slide. Lihat [Licensing](/slides/id/python-net/licensing/) untuk menerapkannya.

## Sumber Daya Aspose.Slides for Python via .NET

Jelajahi sumber daya berguna berikut::

- [Aspose.Slides for Python via .NET Online Documentation](/slides/id/python-net/)
- [Aspose.Slides for Python via .NET Features](/slides/id/python-net/features-overview/)
- [Aspose.Slides for Python via .NET Release Notes](https://releases.aspose.com/slides/id/python-net/release-notes/)
- [Aspose.Slides for Python via .NET Product Page](https://products.aspose.com/slides/id/python-net/)
- [Download Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/id/python-net/)
- [Install Aspose.Slides for Python via .NET PyPi Package](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET API Reference Guide](https://reference.aspose.com/slides/id/python-net/)
- [Aspose.Slides for Python via .NET Free Support Forum](https://forum.aspose.com/c/slides/id/11)
- [Aspose.Slides for Python via .NET Paid Support Helpdesk](https://helpdesk.aspose.com/)

## FAQ

### Apa itu Aspose.Slides for Python via .NET?

Aspose.Slides for Python via .NET adalah pustaka Python yang kuat yang memungkinkan Anda membuat, mengedit, dan mengonversi presentasi PowerPoint (PPT, PPTX, ODP) secara programatik tanpa harus menginstal Microsoft PowerPoint.

### Fitur presentasi apa yang didukung oleh Aspose.Slides?

Perpustakaan ini mendukung pengelolaan teks, bentuk, tabel, diagram, animasi, master slide, audio, video, dan lainnya. Ini juga memungkinkan pratinjau slide, rendering, pencetakan, dan ekspor ke format seperti PDF, SVG, HTML, dan gambar.

### Bisakah saya mengonversi presentasi ke format lain menggunakan Aspose.Slides?

Ya. Aspose.Slides memungkinkan konversi file PowerPoint ke PDF, SVG, HTML, JPG, PNG, TIFF, dan format lain dengan fidelitas tinggi dan performa yang baik.

### Apakah Microsoft PowerPoint diperlukan untuk menggunakan Aspose.Slides?

Tidak. Aspose.Slides adalah API mandiri dan tidak memerlukan Microsoft Office atau perangkat lunak pihak ketiga lainnya.

### Platform apa yang didukung oleh Aspose.Slides for Python via .NET?

Ini bersifat lintas platform dan berfungsi di lingkungan Windows, Linux, dan macOS.

### Bagaimana cara memulai dengan Aspose.Slides for Python?

Anda dapat menginstalnya melalui PyPi dan menjelajahi [Developer Guide](/slides/id/python-net/developer-guide/) untuk memulai dengan contoh, referensi API, dan tutorial.