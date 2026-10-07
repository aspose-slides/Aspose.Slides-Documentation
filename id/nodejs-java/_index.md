---
title: Aspose.Slides untuk Node.js via Java
second_title: Aspose.Slides untuk Node.js
type: docs
weight: 47
url: /id/nodejs-java/
keywords:
- dokumentasi
- pemrosesan presentasi
- konversi presentasi
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Mulai di sini: instal Aspose.Slides untuk Node.js via Java, buat presentasi pertama, dan temukan panduan untuk tugas umum, referensi API, dan dukungan."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java adalah perpustakaan untuk membuat, membaca, mengedit, dan mengonversi presentasi PowerPoint dan OpenDocument dalam aplikasi Node.js, tanpa Microsoft PowerPoint.

Ia memuat dan menyimpan PPT, PPTX, PPS, POT, dan ODP, termasuk varian yang mendukung makro dan templat, serta mengekspor ke PDF, XPS, HTML, SVG, TIFF, Markdown, dan gambar.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Mulai</b></p>
<hr>
<p>MEMULAI</p>
<ul>
<li><a href="/slides/id/nodejs-java/installation/">Instalasi</a></li>
<li><a href="/slides/id/nodejs-java/create-presentation/">Buat presentasi pertama Anda</a></li>
<li><a href="/slides/id/nodejs-java/getting-started/">Panduan memulai</a></li>
</ul>
<p>EVALUASI</p>
<ul>
<li><a href="/slides/id/nodejs-java/supported-file-formats/">Format file yang didukung</a></li>
<li><a href="/slides/id/nodejs-java/evaluate-aspose-slides/">Batasan percobaan</a></li>
<li><a href="/slides/id/nodejs-java/licensing/">Lisensi</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bangun dengan Slides</b></p>
<hr>
<p>TUGAS UMUM</p>
<ul>
<li><a href="/slides/id/nodejs-java/open-presentation/">Buka presentasi</a></li>
<li><a href="/slides/id/nodejs-java/save-presentation/">Simpan presentasi</a></li>
<li><a href="/slides/id/nodejs-java/convert-powerpoint-to-pdf/">Konversi ke PDF</a></li>
<li><a href="/slides/id/nodejs-java/convert-slide/">Render slide sebagai gambar</a></li>
<li><a href="/slides/id/nodejs-java/manage-text/">Edit teks dan bentuk</a></li>
</ul>
<p>ALUR KERJA SLIDES</p>
<ul>
<li><a href="/slides/id/nodejs-java/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/id/nodejs-java/powerpoint-animation/">Animasi</a></li>
<li><a href="/slides/id/nodejs-java/manage-media-files/">Audio dan video</a></li>
<li><a href="/slides/id/nodejs-java/presentation-design/">Desain slide</a></li>
<li><a href="/slides/id/nodejs-java/merge-presentation/">Gabungkan presentasi</a></li>
</ul>
<p>CONTOH</p>
<ul>
<li><a href="/slides/id/nodejs-java/examples/">Contoh berdasarkan elemen slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referensi &amp; Dukungan</b></p>
<hr>
<p>REFERENSI</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">Referensi API</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">Catatan rilis</a></li>
<li><a href="/slides/id/nodejs-java/known-issues/">Masalah yang diketahui</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-java/">Halaman produk</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">Unduh</a></li>
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

Selain Node.js 20 atau yang lebih baru, paket ini memerlukan Java Development Kit (JDK), Python, dan toolchain build C++, karena npm mengkompilasi jembatan `java`-nya selama instalasi. Lihat [Instalasi](/slides/id/nodejs-java/installation/) untuk langkah-langkah pada masing-masing sistem operasi. Kemudian buat proyek dan instal paket dari npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Simpan kode ini sebagai *hello.js* di folder proyek:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides berjalan di mesin virtual Java yang membuat Node.js tetap berjalan, jadi akhiri proses secara eksplisit.
process.exit(0);
```

Jalankan dengan `node hello.js`. Skrip ini menyimpan *hello.pptx* dengan satu slide yang berisi kotak teks. Tanpa lisensi, file yang disimpan menampilkan watermark evaluasi — lihat [Lisensi](/slides/id/nodejs-java/licensing/). Untuk lebih banyak cara membuat dan mengisi presentasi, lihat [Buat Presentasi](/slides/id/nodejs-java/create-presentation/).