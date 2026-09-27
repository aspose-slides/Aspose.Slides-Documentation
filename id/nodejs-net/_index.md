---
title: Aspose.Slides untuk Node.js via .NET
second_title: Aspose.Slides untuk Node.js
type: docs
weight: 47
url: /id/nodejs-net/
keywords:
- dokumentasi
- pemrosesan presentasi
- konversi presentasi
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Mulailah di sini: instal Aspose.Slides untuk Node.js via .NET, buat presentasi pertama, dan temukan panduan untuk tugas umum, lisensi, referensi API, dan dukungan."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET adalah perpustakaan untuk membuat, membaca, mengedit, dan mengonversi presentasi PowerPoint serta OpenDocument dalam aplikasi Node.js, tanpa Microsoft PowerPoint atau Office Automation. Ini menjalankan Aspose.Slides untuk .NET melalui jembatan edge‑js, sehingga API JavaScript‑nya mencerminkan API .NET, dengan nama anggota camelCase.

Perpustakaan ini memuat dan menyimpan PPT, PPTX, PPS, POT, dan ODP, termasuk varian yang mendukung makro dan templat, serta mengekspor ke PDF, XPS, HTML, TIFF, Markdown, dan gambar.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/id/nodejs-net/installation/">Instalasi</a></li>
<li><a href="/slides/id/nodejs-net/create-presentation/">Buat presentasi pertama Anda</a></li>
<li><a href="/slides/id/nodejs-net/developer-guide/">Panduan pengembang</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/id/nodejs-net/evaluate-aspose-slides/">Batasan percobaan</a></li>
<li><a href="/slides/id/nodejs-net/licensing/">Lisensi</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/id/nodejs-net/open-presentation/">Buka dan simpan presentasi</a></li>
<li><a href="/slides/id/nodejs-net/convert-powerpoint-to-pdf/">Konversi ke PDF</a></li>
<li><a href="/slides/id/nodejs-net/convert-slide/">Render slide sebagai gambar</a></li>
<li><a href="/slides/id/nodejs-net/manage-text/">Edit teks</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Referensi API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Catatan rilis</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Unduh</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum dukungan gratis</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk dukungan berbayar</a></li>
</ul>
</div>
</div>

------

## **Presentasi pertama Anda**

Anda memerlukan Node.js 22 atau 24 serta .NET SDK 8 atau yang lebih baru; Linux juga memerlukan beberapa paket sistem. [Instalasi](/slides/id/nodejs-net/installation/) mencantumkannya serta platform yang telah diuji. Buat proyek, tambahkan override yang memberi tahu npm rilis edge‑js mana yang akan dipasang, dan instal paketnya:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Sekali per mesin, pulihkan paket .NET yang menjadi dependensi perpustakaan. Simpan berkas `deps.csproj` dari [Pulihkan Ketergantungan .NET](/slides/id/nodejs-net/installation/#restore-the-net-dependencies) ke dalam folder `deps` di dalam folder proyek, kemudian jalankan:

```sh
dotnet restore deps/deps.csproj
```

Simpan kode ini sebagai *hello.js* di folder proyek:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Presentasi baru berisi satu slide kosong.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Posisi dan ukuran dalam poin (1/72 inci): x, y, lebar, tinggi.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Lepaskan objek .NET yang mendasari presentasi.
    presentation.dispose();
}
```

Jalankan dari folder proyek:

```sh
node hello.js
```

Skrip mencetak `Saved hello.pptx` dan menyimpan *hello.pptx* dengan satu slide yang berisi persegi panjang berisi teks. Tanpa lisensi, berkas yang disimpan akan memiliki watermark evaluasi — lihat [Lisensi](/slides/id/nodejs-net/licensing/). Untuk cara lain membuat dan mengisi presentasi, lihat [Buat Presentasi](/slides/id/nodejs-net/create-presentation/).