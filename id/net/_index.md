---
title: Aspose.Slides untuk .NET
second_title: Aspose.Slides untuk .NET
type: docs
weight: 10
url: /id/net/
keywords:
- dokumentasi
- pemrosesan presentasi
- konversi presentasi
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Mulai di sini: instal Aspose.Slides untuk .NET, buat presentasi pertama, dan temukan panduan untuk tugas umum, referensi API, serta dukungan."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET adalah perpustakaan kelas untuk membuat, membaca, mengedit, dan mengonversi presentasi PowerPoint dan OpenDocument dalam aplikasi .NET, tanpa Microsoft PowerPoint atau Otomasi Office.

Ia memuat dan menyimpan PPT, PPTX, PPS, POT, dan ODP, termasuk varian yang mendukung makro dan templat, serta mengekspor ke PDF, XPS, HTML, SVG, TIFF, Markdown, dan gambar.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Mulai</b></p>
<hr>
<p>MEMULAI</p>
<ul>
<li><a href="/slides/id/net/installation/">Instalasi</a></li>
<li><a href="/slides/id/net/create-presentation/">Buat presentasi pertama Anda</a></li>
<li><a href="/slides/id/net/getting-started/">Panduan memulai</a></li>
</ul>
<p>EVALUASI</p>
<ul>
<li><a href="/slides/id/net/supported-file-formats/">Format file yang didukung</a></li>
<li><a href="/slides/id/net/evaluate-aspose-slides/">Batasan percobaan</a></li>
<li><a href="/slides/id/net/licensing/">Lisensi</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bangun dengan Slides</b></p>
<hr>
<p>TUGAS UMUM</p>
<ul>
<li><a href="/slides/id/net/open-presentation/">Buka presentasi</a></li>
<li><a href="/slides/id/net/save-presentation/">Simpan presentasi</a></li>
<li><a href="/slides/id/net/convert-powerpoint-to-pdf/">Konversi ke PDF</a></li>
<li><a href="/slides/id/net/convert-slide/">Render slide sebagai gambar</a></li>
<li><a href="/slides/id/net/manage-text/">Edit teks dan bentuk</a></li>
</ul>
<p>ALUR KERJA SLIDES</p>
<ul>
<li><a href="/slides/id/net/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/id/net/powerpoint-animation/">Animasi</a></li>
<li><a href="/slides/id/net/manage-media-files/">Audio dan video</a></li>
<li><a href="/slides/id/net/presentation-design/">Desain slide</a></li>
<li><a href="/slides/id/net/merge-presentation/">Gabungkan presentasi</a></li>
</ul>
<p>CONTOH</p>
<ul>
<li><a href="/slides/id/net/examples/">Contoh berdasarkan elemen slide</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Contoh di GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referensi &amp; Dukungan</b></p>
<hr>
<p>REFERENSI</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Referensi API</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Catatan rilis</a></li>
<li><a href="/slides/id/net/known-issues/">Masalah yang dikenal</a></li>
<li><a href="https://releases.aspose.com/slides/net/">Download</a></li>
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

Buat aplikasi konsol dengan .NET SDK 6 atau yang lebih baru:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Kemudian tambahkan satu paket untuk platform Anda:

- Pada Windows: `dotnet add package Aspose.Slides.NET`
- Pada Linux dan macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — lihat [Instalasi](/slides/id/net/installation/) untuk prasyarat Linux dan untuk sistem yang membutuhkan Aspose.Slides.NET sebagai gantinya.

Ganti isi *Program.cs* dengan kode ini dan jalankan `dotnet run`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Program ini menyimpan *hello.pptx* dengan satu slide yang berisi kotak teks. Tanpa lisensi, file yang disimpan menampilkan watermark evaluasi — lihat [Lisensi](/slides/id/net/licensing/). Untuk cara lain membuat dan mengisi presentasi, lihat [Buat Presentasi](/slides/id/net/create-presentation/).