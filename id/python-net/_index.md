---
title: Aspose.Slides untuk Python via .NET
second_title: Aspose.Slides untuk Python
type: docs
weight: 35
url: /id/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- Otomasi PowerPoint dengan Python
- Pustaka PPT Python
- Ekspor PowerPoint ke PDF dengan Python
- Ekspor PowerPoint ke SVG dengan Python
- Edit PowerPoint dalam Python
- PowerPoint Python tanpa Microsoft Office
- Kelola PPTX dengan Python
- Pratinjau slide dengan Python
- Python menambahkan audio ke slide
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Mulai di sini: instal Aspose.Slides for Python via .NET, buat presentasi pertama, dan temukan panduan untuk tugas umum, referensi API, serta dukungan."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET adalah pustaka Python untuk membuat, membaca, mengedit, dan mengonversi presentasi PowerPoint dan OpenDocument, tanpa Microsoft PowerPoint atau Microsoft Office.

Ia memuat dan menyimpan PPT, PPTX, PPS, POT, dan ODP, termasuk varian yang mendukung makro dan template, serta mengekspor ke PDF, XPS, HTML, SVG, TIFF, Markdown, dan gambar.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Mulai</b></p>
<hr>
<p>MEMULAI</p>
<ul>
<li><a href="/slides/id/python-net/installation/">Instalasi</a></li>
<li><a href="/slides/id/python-net/create-presentation/">Buat presentasi pertama Anda</a></li>
<li><a href="/slides/id/python-net/getting-started/">Panduan memulai</a></li>
</ul>
<p>EVALUASI</p>
<ul>
<li><a href="/slides/id/python-net/supported-file-formats/">Format file yang didukung</a></li>
<li><a href="/slides/id/python-net/evaluate-aspose-slides/">Batasan trial</a></li>
<li><a href="/slides/id/python-net/licensing/">Lisensi</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bangun dengan Slides</b></p>
<hr>
<p>TUGAS UMUM</p>
<ul>
<li><a href="/slides/id/python-net/open-presentation/">Buka presentasi</a></li>
<li><a href="/slides/id/python-net/save-presentation/">Simpan presentasi</a></li>
<li><a href="/slides/id/python-net/convert-powerpoint-to-pdf/">Konversi ke PDF</a></li>
<li><a href="/slides/id/python-net/convert-slide/">Render slide menjadi gambar</a></li>
<li><a href="/slides/id/python-net/manage-text/">Edit teks dan bentuk</a></li>
</ul>
<p>ALUR KERJA SLIDES</p>
<ul>
<li><a href="/slides/id/python-net/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/id/python-net/powerpoint-animation/">Animasi</a></li>
<li><a href="/slides/id/python-net/manage-media-files/">Audio dan video</a></li>
<li><a href="/slides/id/python-net/presentation-design/">Desain slide</a></li>
<li><a href="/slides/id/python-net/merge-presentation/">Gabungkan presentasi</a></li>
</ul>
<p>CONTOH</p>
<ul>
<li><a href="/slides/id/python-net/examples/">Contoh per elemen slide</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Contoh di GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referensi &amp; Dukungan</b></p>
<hr>
<p>REFERENSI</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">Referensi API</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Catatan rilis</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">Halaman produk</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">Unduh</a></li>
</ul>
<p>DUKUNGAN</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum dukungan gratis</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk dukungan berbayar</a></li>
</ul>
</div>
</div>

------

## **Presentasi pertama Anda**

Instal paket dari PyPI:

```bash
pip install aspose.slides
```

Paket tersebut menyertakan runtime .NET yang digunakannya, jadi Anda tidak perlu menginstal .NET. Di Linux, juga instal pustaka libgdiplus dan ICU, dan dengan Python sistem Debian atau Ubuntu, jalankan perintah dalam lingkungan virtual. macOS memiliki prasyarat tambahan, dan kami belum memverifikasi instalasi di sana. Lihat [Instalasi](/slides/id/python-net/installation/) untuk perintah, prasyarat macOS, dan versi Python yang didukung.

Simpan kode ini sebagai *hello.py*:

```py
import aspose.slides as slides

# Instansiasi kelas Presentation yang merepresentasikan file presentasi.
with slides.Presentation() as presentation:
    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto-shape tipe CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Simpan presentasi sebagai file PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Jalankan dengan `python hello.py`. Skrip menyimpan *new_presentation.pptx* di folder saat ini, dengan satu slide yang berisi bentuk awan dengan teks "Hello, Aspose!". Tanpa lisensi, file yang disimpan memiliki watermark evaluasi — lihat [Lisensi](/slides/id/python-net/licensing/). Untuk cara lebih banyak membuat dan mengisi presentasi, lihat [Buat Presentasi](/slides/id/python-net/create-presentation/).