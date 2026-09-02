---
title: Convert Presentations to Multiple Formats in .NET
linktitle: Convert Presentation
type: docs
weight: 70
url: /id/net/convert-presentation/
keywords:
- konversi presentasi
- ekspor presentasi
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
description: "Konversi presentasi PowerPoint dan OpenDocument ke PPTX, PDF, HTML, gambar, XPS, TIFF, dan lainnya dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Aspose.Slides untuk .NET dapat memuat presentasi PowerPoint dan OpenDocument serta menyimpan atau merendernya ke banyak format lain tanpa Microsoft PowerPoint, OpenOffice, atau LibreOffice. Anda dapat mengonversi file PPT lama ke PPTX modern, mengekspor presentasi ke dokumen tata letak tetap seperti PDF dan XPS, memublikasikan slide sebagai HTML, atau merender slide sebagai file gambar untuk pratinjau, thumbnail, dan arsip.

Sebagian besar konversi dokumen menggunakan alur kerja umum yang sama: memuat file sumber, memilih format output yang diperlukan, dan menerapkan opsi khusus format bila diperlukan. Untuk format gambar, setiap slide dirender secara terpisah dan kemudian disimpan sebagai gambar raster atau vektor. Artikel‑artikel khusus yang ditautkan di bawah ini memberikan detail implementasi untuk masing‑masing kasus.

## **Pilih Skenario Konversi**

Gunakan artikel di bawah ini untuk contoh lengkap C# dan opsi khusus format.

| Skenario | Gunakan ketika Anda perlu | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Memodernisasi file PPT lama, menormalkan file PPTX yang ada, atau mengonversi presentasi OpenDocument ke PowerPoint PPTX. | [Konversi PPT ke PPTX](/slides/id/net/convert-ppt-to-pptx/), [Konversi ODP ke PPTX](/slides/id/net/convert-odp-to-pptx/), [Simpan Presentasi](/slides/id/net/save-presentation/) |
| PPTX to PPT | Simpan presentasi PowerPoint modern ke format PPT biner lama untuk kompatibilitas dengan alur kerja lama. | [Konversi PPTX ke PPT](/slides/id/net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Buat dokumen tata letak tetap yang dapat dipindahkan, dapat dicari, untuk berbagi, mencetak, atau mengarsipkan. | [Konversi PowerPoint ke PDF](/slides/id/net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Ekspor catatan pembicara bersama konten slide. | [Konversi PowerPoint ke PDF dengan Catatan](/slides/id/net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Publikasikan presentasi sebagai halaman HTML dan kontrol gambar, font, catatan, serta opsi tata letak responsif. | [Konversi PowerPoint ke HTML](/slides/id/net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Ekspor slide ke HTML5 untuk tampilan berbasis peramban dengan format dan interaktivitas yang dipertahankan. | [Konversi Presentasi ke HTML5](/slides/id/net/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Render setiap slide menjadi gambar PNG untuk pratinjau, thumbnail, atau output web. | [Konversi PowerPoint ke PNG](/slides/id/net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Render slide menjadi gambar JPG dan kontrol dimensi serta kualitas gambar. | [Konversi PowerPoint ke JPG](/slides/id/net/convert-powerpoint-to-jpg/) |
| Slide to SVG | Ekspor slide individual sebagai grafik vektor skalabel. | [Render Slide sebagai SVG](/slides/id/net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Hasilkan dokumen XPS dengan tata letak tetap. | [Konversi PowerPoint ke XPS](/slides/id/net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Simpan presentasi sebagai file TIFF multi‑halaman untuk pencetakan, pemindaian, faks, atau alur kerja arsip. | [Konversi PowerPoint ke TIFF](/slides/id/net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Simpan slide dengan catatan pembicara ke TIFF. | [Konversi PowerPoint ke TIFF dengan Catatan](/slides/id/net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Konversi slide ke dokumen Word ketika Anda membutuhkan output bergaya dokumen. | [Konversi PowerPoint ke Word](/slides/id/net/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Ekstrak konten presentasi ke dalam Markdown untuk dokumentasi dan alur kerja berbasis teks. | [Konversi PowerPoint ke Markdown](/slides/id/net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | Buat Presentasi PowerPoint XML berbasis teks untuk inspeksi, perbandingan, pemecahan masalah, atau alur kerja berbasis XML. | [Konversi PowerPoint ke XML](/slides/id/net/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Buat GIF animasi dari slide. | [Konversi PowerPoint ke GIF Animasi](/slides/id/net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Bangun alur kerja ekspor video dari slide presentasi. | [Konversi PowerPoint ke Video](/slides/id/net/convert-powerpoint-to-video/) |
| Presentation to XAML | Ekspor slide ke XAML untuk skenario UI .NET. | [Ekspor Presentasi ke XAML](/slides/id/net/export-to-xaml/) |

Untuk daftar yang lebih luas tentang format input dan output, lihat [Format File yang Didukung](/slides/id/net/supported-file-formats/).

## **Konversi PowerPoint dan OpenDocument**

Aspose.Slides untuk .NET mendukung konversi dari format presentasi yang umum digunakan seperti PPT, PPTX, PPS, PPSX, POT, POTX, dan ODP. API konversi yang sama digunakan untuk file PowerPoint dan OpenDocument, sehingga alur kerja yang menyimpan file PPTX ke PDF biasanya dapat diterapkan pada file ODP dengan hanya mengubah file input.

Saat mengonversi file ODP, ingat bahwa aplikasi PowerPoint dan OpenDocument tidak mendukung setiap tata letak dan fitur pemformatan dengan cara yang persis sama. Jika file ODP dibuat di LibreOffice atau OpenOffice Impress, tinjau hasilnya dan gunakan opsi yang dijelaskan dalam [Konversi Presentasi OpenDocument](/slides/id/net/convert-openoffice-odp/) ketika Anda membutuhkan panduan khusus format.

## **Konversi PPT ke PPTX**

PPT adalah format PowerPoint biner lama, sementara PPTX adalah format Office Open XML modern. Aspose.Slides untuk .NET mendukung konversi PPT ke PPTX dengan fidelitas tinggi sambil mempertahankan struktur presentasi yang kompleks seperti master, tata letak, slide, diagram, bentuk yang dikelompokkan, placeholder, bingkai teks, tekstur, dan isian gambar.

Untuk detailnya, lihat [Konversi PPT ke PPTX](/slides/id/net/convert-ppt-to-pptx/) dan [PPT vs PPTX](/slides/id/net/ppt-vs-pptx/).

## **Ekspor Tata Letak Tetap**

PDF, XPS, dan TIFF berguna ketika output harus terlihat sama di semua perangkat dan tidak boleh diedit sebagai presentasi. Gunakan [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/), [XpsOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/xpsoptions/), dan [TiffOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/) untuk mengontrol kepatuhan, slide tersembunyi, catatan, kualitas gambar, kompresi, format piksel, dan ukuran output.

## **Ekspor HTML dan Gambar**

Ekspor HTML dan HTML5 berguna untuk tampilan di peramban, publikasi web, dan berbagi ringan. Ekspor gambar berguna ketika setiap slide harus menjadi pratinjau, thumbnail, atau aset raster terpisah. Gunakan artikel PNG, JPG, dan SVG untuk panduan render khusus format.

## **FAQ**

**Apakah saya membutuhkan Microsoft PowerPoint untuk mengonversi presentasi?**

Tidak. Aspose.Slides untuk .NET adalah pustaka mandiri dan tidak memerlukan Microsoft PowerPoint atau automasi Office.

**Bisakah saya mengonversi banyak presentasi secara batch?**

Ya. Muat setiap presentasi, simpan ke format yang diperlukan, dan buang objek `Presentation` setelah diproses. Untuk pemrosesan paralel, gunakan instansi presentasi terpisah dan ikuti panduan [multithreading](/slides/id/net/multithreading/).

**Bisakah saya mengekspor hanya slide yang dipilih?**

Ya. Beberapa metode ekspor memungkinkan Anda memberikan indeks slide atau merender slide individu, tergantung pada format output. Lihat artikel khusus untuk format target.

**Bisakah saya menyertakan slide tersembunyi saat mengekspor ke PDF atau XPS?**

Ya. Gunakan properti `ShowHiddenSlides` pada [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/) atau [XpsOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/xpsoptions/).

**Bisakah saya membuat output PDF/A?**

Ya. Pengaturan kepatuhan PDF tersedia melalui [PdfOptions.Compliance](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/compliance/) dan [PdfCompliance](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfcompliance/).

**Bagaimana cara penanganan font selama konversi?**

Aspose.Slides dapat menggunakan font yang disematkan, fallback font, dan pengaturan substitusi font. Lihat [Font Tertanam](/slides/id/net/embedded-font/), [Font Cadangan](/slides/id/net/fallback-font/), dan [Substitusi Font](/slides/id/net/font-substitution/).