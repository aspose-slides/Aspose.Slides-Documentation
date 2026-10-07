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
description: "Mulai di sini: instal Aspose.Slides untuk Node.js via .NET, buat presentasi pertama, dan temukan panduan untuk tugas umum, lisensi, referensi API, dan dukungan."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET adalah perpustakaan untuk membuat, membaca, mengedit, dan mengonversi presentasi PowerPoint dan OpenDocument dalam aplikasi Node.js, tanpa Microsoft PowerPoint atau Office Automation. Ia menjalankan Aspose.Slides for .NET melalui jembatan edge-js, sehingga API JavaScript‑nya meniru API .NET, dengan nama anggota camelCase.

Ia memuat dan menyimpan PPT, PPTX, PPS, POT, dan ODP, termasuk varian yang mendukung makro dan template, serta mengekspor ke PDF, XPS, HTML, TIFF, Markdown, dan gambar.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Mulai</b></p>
<hr>
<p>MEMULAI</p>
<ul>
<li><a href="/slides/id/nodejs-net/installation/">Instalasi</a></li>
<li><a href="/slides/id/nodejs-net/create-presentation/">Buat presentasi pertama Anda</a></li>
<li><a href="/slides/id/nodejs-net/developer-guide/">Panduan pengembang</a></li>
</ul>
<p>EVALUASI</p>
<ul>
<li><a href="/slides/id/nodejs-net/evaluate-aspose-slides/">Batasan percobaan</a></li>
<li><a href="/slides/id/nodejs-net/licensing/">Lisensi</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bangun dengan Slides</b></p>
<hr>
<p>TUGAS UMUM</p>
<ul>
<li><a href="/slides/id/nodejs-net/open-presentation/">Buka dan simpan sebuah presentasi</a></li>
<li><a href="/slides/id/nodejs-net/convert-powerpoint-to-pdf/">Konversi ke PDF</a></li>
<li><a href="/slides/id/nodejs-net/convert-slide/">Render slide sebagai gambar</a></li>
<li><a href="/slides/id/nodejs-net/manage-text/">Edit teks</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referensi &amp; Dukungan</b></p>
<hr>
<p>REFERENSI</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Referensi API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Catatan rilis</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">Halaman produk</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Unduh</a></li>
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

Anda memerlukan Node.js 22 atau 24 dan .NET SDK 8 atau yang lebih baru; Linux juga memerlukan beberapa paket sistem. [Installation](/slides/id/nodejs-net/installation/) mencantumkannya serta platform yang telah diuji. Buat sebuah proyek, tambahkan override yang memberi tahu npm rilis edge-js mana yang akan diinstal, dan instal paket:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Sekali per mesin, pulihkan paket .NET yang menjadi dependensi perpustakaan. Simpan file `deps.csproj` dari [Restore the .NET Dependencies](/slides/id/nodejs-net/installation/#restore-the-net-dependencies) ke dalam folder `deps` di dalam folder proyek, kemudian jalankan:

```sh
dotnet restore deps/deps.csproj
```

Simpan kode ini sebagai *hello.js* di folder proyek:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Sebuah presentasi baru berisi satu slide kosong.
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

Skrip ini mencetak `Saved hello.pptx` dan menyimpan *hello.pptx* dengan satu slide yang berisi sebuah persegi panjang dengan teks. Tanpa lisensi, file yang disimpan membawa watermark evaluasi — lihat [Licensing](/slides/id/nodejs-net/licensing/). Untuk lebih banyak cara membuat dan mengisi presentasi, lihat [Create a Presentation](/slides/id/nodejs-net/create-presentation/).