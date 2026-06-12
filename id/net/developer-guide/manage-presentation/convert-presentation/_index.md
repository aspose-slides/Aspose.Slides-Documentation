---
title: Mengonversi Presentasi ke Berbagai Format di .NET
linktitle: Mengonversi Presentasi
type: docs
weight: 70
url: /id/net/convert-presentation/
keywords:
- mengonversi presentasi
- mengekspor presentasi
- PPT ke PPTX
- PPTX ke PPT
- ODP ke PPTX
- PPT ke PDF
- PPTX ke PDF
- ODP ke PDF
- PPT ke HTML
- PPTX ke HTML
- ODP ke HTML
- PPT ke PNG
- PPTX ke PNG
- ODP ke PNG
- PPTX ke JPG
- ODP ke JPG
- PPT ke XPS
- PPTX ke XPS
- ODP ke XPS
- PPT ke TIFF
- PPTX ke TIFF
- ODP ke TIFF
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint dan OpenDocument ke PPTX, PDF, HTML, gambar, XPS, TIFF, dan lainnya dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Aspose.Slides for .NET dapat memuat presentasi PowerPoint dan OpenDocument serta menyimpan atau merendernya ke banyak format lain tanpa Microsoft PowerPoint, OpenOffice, atau LibreOffice. Anda dapat mengonversi file PPT lama ke PPTX modern, mengekspor presentasi ke dokumen berlayout tetap seperti PDF dan XPS, memublikasikan slide sebagai HTML, atau merender slide sebagai file gambar untuk pratinjau, thumbnail, dan arsip.

Sebagian besar konversi dokumen menggunakan alur kerja umum yang sama: muat file sumber, pilih format output yang dibutuhkan, dan terapkan opsi khusus format bila diperlukan. Untuk format gambar, setiap slide dirender secara terpisah lalu disimpan sebagai gambar raster atau vektor. Artikel khusus yang ditautkan di bawah ini memberikan detail implementasi untuk setiap kasus.

## **Pilih Skenario Konversi**

Gunakan artikel di bawah ini untuk contoh C# lengkap dan opsi khusus format.

| Skenario | Gunakan ketika Anda perlu | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP ke PPTX | Memodernisasi file PPT lama, menormalkan file PPTX yang ada, atau mengonversi presentasi OpenDocument ke PowerPoint PPTX. | [Konversi PPT ke PPTX](/slides/id/net/convert-ppt-to-pptx/), [Konversi ODP ke PPTX](/slides/id/net/convert-odp-to-pptx/), [Simpan Presentasi](/slides/id/net/save-presentation/) |
| PPTX ke PPT | Menyimpan presentasi PowerPoint modern ke format biner PPT lama untuk kompatibilitas dengan alur kerja yang lebih tua. | [Konversi PPTX ke PPT](/slides/id/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP ke PDF | Membuat dokumen berlayout tetap yang portabel, dapat dicari, untuk berbagi, mencetak, atau mengarsipkan. | [Konversi PowerPoint ke PDF](/slides/id/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP ke PDF dengan catatan | Mengekspor catatan pembicara bersama konten slide. | [Konversi PowerPoint ke PDF dengan Catatan](/slides/id/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP ke HTML | Mempublikasikan presentasi sebagai halaman HTML dan mengontrol gambar, font, catatan, serta opsi layout responsif. | [Konversi PowerPoint ke HTML](/slides/id/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP ke HTML5 | Mengekspor slide ke HTML5 untuk tampilan berbasis peramban dengan format dan interaktivitas yang tetap. | [Konversi Presentasi ke HTML5](/slides/id/net/export-to-html5/) |
| PPT/PPTX/ODP ke PNG | Merender setiap slide menjadi gambar PNG untuk pratinjau, thumbnail, atau output web. | [Konversi PowerPoint ke PNG](/slides/id/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP ke JPG | Merender slide ke gambar JPG dan mengontrol dimensi serta kualitas gambar. | [Konversi PowerPoint ke JPG](/slides/id/net/convert-powerpoint-to-jpg/) |
| Slide ke SVG | Mengekspor slide individual sebagai grafik vektor skalabel. | [Render Slide sebagai SVG](/slides/id/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP ke XPS | Menghasilkan dokumen XPS berlayout tetap. | [Konversi PowerPoint ke XPS](/slides/id/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP ke TIFF | Menyimpan presentasi sebagai file TIFF multipage untuk pencetakan, pemindaian, faks, atau alur kerja arsip. | [Konversi PowerPoint ke TIFF](/slides/id/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP ke TIFF dengan catatan | Menyimpan slide dengan catatan pembicara ke TIFF. | [Konversi PowerPoint ke TIFF dengan Catatan](/slides/id/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX ke Word | Mengonversi slide ke dokumen Word ketika Anda memerlukan output bergaya dokumen. | [Konversi PowerPoint ke Word](/slides/id/net/convert-powerpoint-to-word/) |
| PPT/PPTX ke Markdown | Mengekstrak konten presentasi ke Markdown untuk dokumentasi dan alur kerja berbasis teks. | [Konversi PowerPoint ke Markdown](/slides/id/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX ke GIF animasi | Membuat GIF animasi dari slide. | [Konversi PowerPoint ke GIF Animasi](/slides/id/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX ke video | Membangun alur kerja ekspor video dari slide presentasi. | [Konversi PowerPoint ke Video](/slides/id/net/convert-powerpoint-to-video/) |
| Presentasi ke XAML | Mengekspor slide ke XAML untuk skenario UI .NET. | [Ekspor Presentasi ke XAML](/slides/id/net/export-to-xaml/) |

Untuk daftar yang lebih luas dari format input dan output, lihat [Format File yang Didukung](/slides/id/net/supported-file-formats/).

## **Konversi PowerPoint dan OpenDocument**

Aspose.Slides for .NET mendukung konversi dari format presentasi yang umum digunakan seperti PPT, PPTX, PPS, PPSX, POT, POTX, dan ODP. API konversi yang sama digunakan untuk file PowerPoint dan OpenDocument, sehingga alur kerja yang menyimpan file PPTX ke PDF biasanya dapat diterapkan pada file ODP hanya dengan mengubah file masukan.

Saat mengonversi file ODP, ingat bahwa aplikasi PowerPoint dan OpenDocument tidak mendukung setiap tata letak dan fitur pemformatan dengan cara yang persis sama. Jika file ODP dibuat di LibreOffice atau OpenOffice Impress, tinjau outputnya dan gunakan opsi yang dijelaskan di [Konversi Presentasi OpenDocument](/slides/id/net/convert-openoffice-odp/) ketika Anda memerlukan panduan khusus format.

## **Konversi PPT ke PPTX**

PPT adalah format binary PowerPoint yang lebih lama, sementara PPTX adalah format Office Open XML yang modern. Aspose.Slides for .NET mendukung konversi PPT ke PPTX dengan fidelitas tinggi sambil mempertahankan struktur presentasi kompleks seperti master, layout, slide, chart, grup shape, placeholder, text frame, tekstur, dan isi gambar.

Untuk detailnya, lihat [Konversi PPT ke PPTX](/slides/id/net/convert-ppt-to-pptx/) dan [PPT vs PPTX](/slides/id/net/ppt-vs-pptx/).

## **Ekspor Berlayout Tetap**

PDF, XPS, dan TIFF berguna ketika output harus terlihat sama di semua perangkat dan tidak boleh diedit sebagai presentasi. Gunakan [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/xpsoptions/) , dan [TiffOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/) untuk mengontrol kepatuhan, slide tersembunyi, catatan, kualitas gambar, kompresi, format piksel, dan ukuran output.

## **Ekspor HTML dan Gambar**

Ekspor HTML dan HTML5 berguna untuk tampilan berbasis peramban, publikasi web, dan berbagi ringan. Ekspor gambar berguna ketika setiap slide harus menjadi pratinjau, thumbnail, atau aset raster terpisah. Gunakan artikel PNG, JPG, dan SVG untuk panduan render khusus format.

## **FAQ**

**Apakah saya memerlukan Microsoft PowerPoint untuk mengonversi presentasi?**

Tidak. Aspose.Slides for .NET adalah pustaka mandiri dan tidak memerlukan Microsoft PowerPoint atau otomasi Office.

**Apakah saya dapat mengonversi banyak presentasi secara batch?**

Ya. Muat setiap presentasi, simpan ke format yang dibutuhkan, dan buang objek `Presentation` setelah diproses. Untuk pemrosesan paralel, gunakan instance presentasi terpisah dan ikuti panduan [multithreading](/slides/id/net/multithreading/).

**Apakah saya dapat mengekspor hanya slide yang dipilih?**

Ya. Beberapa metode ekspor memungkinkan Anda melewatkan indeks slide atau merender slide individual, tergantung pada format output. Lihat artikel khusus untuk format target.

**Apakah saya dapat menyertakan slide tersembunyi saat mengekspor ke PDF atau XPS?**

Ya. Gunakan properti `ShowHiddenSlides` di [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/) atau [XpsOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/xpsoptions/).

**Apakah saya dapat membuat output PDF/A?**

Ya. Pengaturan kepatuhan PDF tersedia melalui [PdfOptions.Compliance](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/compliance/) dan [PdfCompliance](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfcompliance/).

**Bagaimana font ditangani selama konversi?**

Aspose.Slides dapat menggunakan font yang disematkan, fallback font, dan pengaturan substitusi font. Lihat [Embedded Font](/slides/id/net/embedded-font/), [Fallback Font](/slides/id/net/fallback-font/), dan [Font Substitution](/slides/id/net/font-substitution/).