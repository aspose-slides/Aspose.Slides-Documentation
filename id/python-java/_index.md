---
title: Aspose.Slides untuk Python via Java
second_title: Aspose.Slides untuk Python
type: docs
weight: 47
url: /id/python-java/
is_root: true
keywords:
- Aspose.Slides untuk Python via Java
- Perpustakaan PowerPoint Python
- mengelola presentasi PowerPoint di Python
- membaca dan menulis PowerPoint di Python
- mengedit slide PowerPoint di Python
- mengekspor PowerPoint ke PDF di Python
- mengekspor PowerPoint ke SVG di Python
- pratinjau slide di Python
- menambahkan audio dan video ke slide di Python
- PowerPoint tanpa Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Mulai di sini: instal Aspose.Slides untuk Python via Java, buat presentasi pertama, dan temukan panduan untuk tugas umum, referensi API, serta dukungan."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides untuk Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides untuk Python via Java adalah perpustakaan untuk membuat, membaca, mengedit, dan mengonversi presentasi PowerPoint serta OpenDocument dalam aplikasi Python, tanpa Microsoft PowerPoint; ia menjalankan mesin Aspose.Slides Java dalam proses Python Anda melalui JPype.

Perpustakaan ini memuat dan menyimpan PPT, PPTX, PPS, POT, dan ODP, termasuk varian yang mendukung makro dan template, serta mengekspor ke PDF, XPS, HTML, SVG, TIFF, Markdown, dan gambar.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Mulai</b></p>
<hr>
<p>MEMULAI</p>
<ul>
<li><a href="/slides/id/python-java/installation/">Instalasi</a></li>
<li><a href="/slides/id/python-java/create-presentation/">Buat presentasi pertama Anda</a></li>
<li><a href="/slides/id/python-java/getting-started/">Panduan memulai</a></li>
</ul>
<p>EVALUASI</p>
<ul>
<li><a href="/slides/id/python-java/supported-file-formats/">Format file yang didukung</a></li>
<li><a href="/slides/id/python-java/evaluate-aspose-slides/">Batasan percobaan</a></li>
<li><a href="/slides/id/python-java/licensing/">Lisensi</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Membangun dengan Slides</b></p>
<hr>
<p>TUGAS UMUM</p>
<ul>
<li><a href="/slides/id/python-java/open-presentation/">Buka presentasi</a></li>
<li><a href="/slides/id/python-java/save-presentation/">Simpan presentasi</a></li>
<li><a href="/slides/id/python-java/convert-powerpoint-to-pdf/">Konversi ke PDF</a></li>
<li><a href="/slides/id/python-java/convert-slide/">Render slide sebagai gambar</a></li>
<li><a href="/slides/id/python-java/manage-text/">Edit teks dan bentuk</a></li>
</ul>
<p>ALUR KERJA SLIDES</p>
<ul>
<li><a href="/slides/id/python-java/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/id/python-java/powerpoint-animation/">Animasi</a></li>
<li><a href="/slides/id/python-java/manage-media-files/">Audio dan video</a></li>
<li><a href="/slides/id/python-java/presentation-design/">Desain slide</a></li>
<li><a href="/slides/id/python-java/merge-presentation/">Gabungkan presentasi</a></li>
</ul>
<p>CONTOH</p>
<ul>
<li><a href="/slides/id/python-java/examples/">Contoh berdasarkan elemen slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referensi &amp; Dukungan</b></p>
<hr>
<p>REFERENSI</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">Referensi API</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Catatan rilis</a></li>
<li><a href="/slides/id/python-java/known-issues/">Masalah yang diketahui</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">Halaman produk</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Unduh</a></li>
</ul>
<p>Dukungan</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum dukungan gratis</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk dukungan berbayar</a></li>
</ul>
</div>
</div>

------

## **Presentasi pertama Anda**

Instal Python dan JDK, tetapkan `JAVA_HOME`, serta buat dan aktifkan lingkungan virtual seperti yang dijelaskan di [Instalasi](/slides/id/python-java/installation/). Kemudian instal JPype dan Aspose.Slides dari PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Simpan kode ini sebagai *hello.py*. Kode ini memulai Java Virtual Machine, menambahkan bentuk awan dengan teks ke slide pertama dari presentasi baru, dan menyimpan presentasi:

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Buat presentasi dengan satu slide kosong.
presentation = Presentation()
try:
    # Dapatkan slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan bentuk awan dan atur teksnya.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Simpan presentasi sebagai file PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jalankan dalam lingkungan virtual yang sama:

```sh
python hello.py
```

Skrip ini menyimpan *new_presentation.pptx* dengan satu slide yang berisi bentuk awan berisi teks "Hello, Aspose!". Tanpa lisensi, file yang disimpan juga menampilkan watermark evaluasi — lihat [Lisensi](/slides/id/python-java/licensing/). Untuk cara lain membuat dan mengisi presentasi, lihat [Buat Presentasi](/slides/id/python-java/create-presentation/).