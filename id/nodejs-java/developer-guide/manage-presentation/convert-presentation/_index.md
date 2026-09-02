---
title: Konversi Presentasi ke Berbagai Format dalam JavaScript
linktitle: Konversi Presentasi
type: docs
weight: 70
url: /id/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konversi presentasi PowerPoint dan OpenDocument ke PPTX, PDF, HTML, gambar, XPS, TIFF, dan lainnya dengan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Aspose.Slides for Node.js via Java dapat memuat presentasi PowerPoint dan OpenDocument serta menyimpan atau merendernya ke banyak format lain tanpa Microsoft PowerPoint, OpenOffice, atau LibreOffice. Anda dapat mengonversi file PPT lama ke PPTX modern, mengekspor presentasi ke dokumen tata letak tetap seperti PDF dan XPS, memublikasikan slide sebagai HTML, atau merender slide sebagai file gambar untuk pratinjau, thumbnail, dan arsip.

Sebagian besar konversi dokumen menggunakan alur kerja umum yang sama: memuat file sumber, memilih format output yang diperlukan, dan menerapkan opsi khusus format bila diperlukan. Untuk format gambar, setiap slide dirender secara terpisah dan kemudian disimpan sebagai gambar raster atau vektor. Artikel khusus yang ditautkan di bawah ini menyediakan detail implementasi untuk setiap kasus.

## **Pilih Skenario Konversi**

Gunakan artikel di bawah ini untuk contoh JavaScript lengkap dan opsi khusus format.

| Skenario | Gunakan ketika Anda perlu | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP ke PPTX | Modernisasi file PPT lama, menormalkan file PPTX yang ada, atau mengonversi presentasi OpenDocument ke PowerPoint PPTX. | [Konversi PPT ke PPTX](/slides/id/nodejs-java/convert-ppt-to-pptx/), [Konversi ODP ke PPTX](/slides/id/nodejs-java/convert-odp-to-pptx/), [Simpan Presentasi](/slides/id/nodejs-java/save-presentation/) |
| PPTX ke PPT | Simpan presentasi PowerPoint modern ke format PPT biner lama untuk kompatibilitas dengan alur kerja lama. | [Konversi PPTX ke PPT](/slides/id/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP ke PDF | Buat dokumen portabel, dapat dicari, dengan tata letak tetap untuk berbagi, mencetak, atau mengarsipkan. | [Konversi PowerPoint ke PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP ke PDF dengan catatan | Ekspor catatan pembicara bersama konten slide. | [Konversi PowerPoint ke PDF dengan Catatan](/slides/id/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP ke HTML | Publikasikan presentasi sebagai halaman HTML dan kendalikan gambar, font, catatan, serta opsi tata letak responsif. | [Konversi PowerPoint ke HTML](/slides/id/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP ke HTML5 | Ekspor slide ke HTML5 untuk tampilan berbasis peramban dengan format dan interaktivitas yang terjaga. | [Konversi Presentasi ke HTML5](/slides/id/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP ke PNG | Render setiap slide menjadi gambar PNG untuk pratinjau, thumbnail, atau output web. | [Konversi PowerPoint ke PNG](/slides/id/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP ke JPG | Render slide menjadi gambar JPG dan kendalikan dimensi serta kualitas gambar. | [Konversi PowerPoint ke JPG](/slides/id/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide ke SVG | Ekspor slide individual sebagai grafik vektor dapat diskalakan. | [Render Slide sebagai SVG](/slides/id/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP ke XPS | Hasilkan dokumen XPS dengan tata letak tetap. | [Konversi PowerPoint ke XPS](/slides/id/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP ke TIFF | Simpan presentasi sebagai file TIFF multi-halaman untuk pencetakan, pemindaian, faks, atau alur kerja arsip. | [Konversi PowerPoint ke TIFF](/slides/id/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP ke TIFF dengan catatan | Simpan slide dengan catatan pembicara ke TIFF. | [Konversi PowerPoint ke TIFF dengan Catatan](/slides/id/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX ke Markdown | Ekstrak konten presentasi ke dalam Markdown untuk dokumentasi dan alur kerja berbasis teks. | [Konversi PowerPoint ke Markdown](/slides/id/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP ke XML | Buat Presentasi PowerPoint XML berbasis teks untuk inspeksi, perbandingan, pemecahan masalah, atau alur kerja berbasis XML. | [Konversi PowerPoint ke XML](/slides/id/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX ke GIF animasi | Buat GIF animasi dari slide. | [Konversi PowerPoint ke GIF Animasi](/slides/id/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX ke video | Bangun alur kerja ekspor video dari slide presentasi. | [Konversi PowerPoint ke Video](/slides/id/nodejs-java/convert-powerpoint-to-video/) |
| Presentasi ke XAML | Ekspor slide ke XAML untuk skenario UI JavaScript atau Java. | [Ekspor Presentasi ke XAML](/slides/id/nodejs-java/export-to-xaml/) |

Untuk daftar yang lebih luas dari format input dan output, lihat [Format File yang Didukung](/slides/id/nodejs-java/supported-file-formats/).

## **Konversi PowerPoint dan OpenDocument**

Aspose.Slides for Node.js via Java mendukung konversi dari format presentasi yang umum digunakan seperti PPT, PPTX, PPS, PPSX, POT, POTX, dan ODP. API konversi yang sama digunakan untuk file PowerPoint dan OpenDocument, sehingga alur kerja yang menyimpan file PPTX ke PDF biasanya dapat diterapkan pada file ODP hanya dengan mengubah file input.

Saat mengonversi file ODP, ingat bahwa aplikasi PowerPoint dan OpenDocument tidak mendukung setiap tata letak dan fitur pemformatan dengan cara yang persis sama. Jika file ODP dibuat di LibreOffice atau OpenOffice Impress, tinjau outputnya dan gunakan opsi yang dijelaskan di [Konversi Presentasi OpenDocument](/slides/id/nodejs-java/convert-openoffice-odp/) ketika Anda memerlukan panduan khusus format.

## **Konversi PPT ke PPTX**

PPT adalah format PowerPoint biner lama, sementara PPTX adalah format Office Open XML modern. Aspose.Slides for Node.js via Java mendukung konversi PPT ke PPTX dengan fidelitas tinggi sambil mempertahankan struktur presentasi yang kompleks seperti master, tata letak, slide, diagram, bentuk yang dikelompokkan, placeholder, bingkai teks, tekstur, dan pengisian gambar.

Untuk detail, lihat [Konversi PPT ke PPTX](/slides/id/nodejs-java/convert-ppt-to-pptx/) dan [PPT vs PPTX](/slides/id/nodejs-java/ppt-vs-pptx/).

## **Ekspor Tata Letak Tetap**

PDF, XPS, dan TIFF berguna ketika output harus terlihat sama di semua perangkat dan tidak boleh diedit sebagai presentasi. Artikel khusus PDF, XPS, dan TIFF menjelaskan cara mengendalikan kepatuhan, slide tersembunyi, catatan, kualitas gambar, kompresi, format piksel, dan ukuran output.

## **Ekspor HTML dan Gambar**

Ekspor HTML dan HTML5 berguna untuk tampilan di peramban, publikasi web, dan berbagi ringan. Ekspor gambar berguna ketika tiap slide harus menjadi pratinjau terpisah, thumbnail, atau aset raster. Gunakan artikel PNG, JPG, dan SVG untuk panduan rendering khusus format.

## **FAQ**

**Apakah saya memerlukan Microsoft PowerPoint untuk mengonversi presentasi?**

Tidak. Aspose.Slides for Node.js via Java adalah pustaka mandiri dan tidak memerlukan Microsoft PowerPoint atau otomatisasi Office.

**Apakah saya dapat mengonversi banyak presentasi secara batch?**

Ya. Muat setiap presentasi, simpan ke format yang diperlukan, dan buang objek presentasi setelah diproses. Untuk pemrosesan paralel, gunakan instance presentasi terpisah dan ikuti panduan [multithreading](/slides/id/nodejs-java/multithreading/).

**Apakah saya dapat mengekspor hanya slide yang dipilih?**

Ya. Beberapa metode ekspor memungkinkan Anda mengirimkan indeks slide atau merender slide individual, tergantung pada format output. Lihat artikel khusus untuk format target.

**Apakah saya dapat menyertakan slide tersembunyi saat mengekspor ke PDF atau XPS?**

Ya. Gunakan pengaturan ekspor slide tersembunyi yang dijelaskan dalam artikel konversi [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/) dan [XPS](/slides/id/nodejs-java/convert-powerpoint-to-xps/).

**Apakah saya dapat membuat output PDF/A?**

Ya. Pengaturan kepatuhan PDF tersedia untuk ekspor PDF. Lihat [Konversi PowerPoint ke PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/) untuk detail.

**Bagaimana font ditangani selama konversi?**

Aspose.Slides dapat menggunakan font yang tertanam, font fallback, dan pengaturan substitusi font. Lihat [Font Tertanam](/slides/id/nodejs-java/embedded-font/), [Font Fallback](/slides/id/nodejs-java/fallback-font/), dan [Substitusi Font](/slides/id/nodejs-java/font-substitution/).