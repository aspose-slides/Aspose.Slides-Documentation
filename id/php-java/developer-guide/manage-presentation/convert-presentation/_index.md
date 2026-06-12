---
title: Mengonversi Presentasi ke Berbagai Format dalam PHP
linktitle: Mengonversi Presentasi
type: docs
weight: 70
url: /id/php-java/convert-presentation/
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
- PHP
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint dan OpenDocument ke PPTX, PDF, HTML, gambar, XPS, TIFF, dan lainnya dengan Aspose.Slides for PHP via Java."
---
## **Ikhtisar**

Aspose.Slides for PHP via Java dapat memuat presentasi PowerPoint dan OpenDocument serta menyimpan atau merendernya ke banyak format lain tanpa Microsoft PowerPoint, OpenOffice, atau LibreOffice. Anda dapat mengonversi file PPT lama ke PPTX modern, mengekspor presentasi ke dokumen layout tetap seperti PDF dan XPS, memublikasikan slide sebagai HTML, atau merender slide sebagai file gambar untuk preview, thumbnail, dan arsip.

Sebagian besar konversi dokumen menggunakan alur kerja umum yang sama: memuat file sumber, memilih format output yang diperlukan, dan menerapkan opsi khusus format bila diperlukan. Untuk format gambar, setiap slide dirender secara terpisah dan kemudian disimpan sebagai gambar raster atau vektor. Artikel khusus yang ditautkan di bawah ini menyediakan detail implementasinya untuk setiap kasus.

## **Pilih Skenario Konversi**

Gunakan artikel di bawah ini untuk contoh PHP lengkap dan opsi khusus format.

| Skenario | Gunakan ketika Anda perlu | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP ke PPTX | Modernisasi file PPT lama, normalisasi file PPTX yang ada, atau mengonversi presentasi OpenDocument ke PowerPoint PPTX. | [Konversi PPT ke PPTX](/slides/id/php-java/convert-ppt-to-pptx/), [Konversi ODP ke PPTX](/slides/id/php-java/convert-odp-to-pptx/), [Simpan Presentasi](/slides/id/php-java/save-presentation/) |
| PPTX ke PPT | Simpan presentasi PowerPoint modern ke format PPT biner lama untuk kompatibilitas dengan alur kerja yang lebih lama. | [Konversi PPTX ke PPT](/slides/id/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP ke PDF | Buat dokumen layout tetap yang portabel, dapat dicari, untuk berbagi, mencetak, atau mengarsipkan. | [Konversi PowerPoint ke PDF](/slides/id/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP ke PDF dengan catatan | Ekspor catatan pembicara bersama dengan konten slide. | [Konversi PowerPoint ke PDF dengan Catatan](/slides/id/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP ke HTML | Publikasikan presentasi sebagai halaman HTML dan kontrol gambar, font, catatan, serta opsi layout responsif. | [Konversi PowerPoint ke HTML](/slides/id/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP ke HTML5 | Ekspor slide ke HTML5 untuk tampilan berbasis browser dengan format dan interaktivitas yang terjaga. | [Konversi Presentasi ke HTML5](/slides/id/php-java/export-to-html5/) |
| PPT/PPTX/ODP ke PNG | Render setiap slide ke gambar PNG untuk preview, thumbnail, atau output web. | [Konversi PowerPoint ke PNG](/slides/id/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP ke JPG | Render slide ke gambar JPG dan kontrol dimensi serta kualitas gambar. | [Konversi PowerPoint ke JPG](/slides/id/php-java/convert-powerpoint-to-jpg/) |
| Slide ke SVG | Ekspor slide individual sebagai grafik vektor yang dapat diskalakan. | [Render Slide sebagai SVG](/slides/id/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP ke XPS | Hasilkan dokumen XPS layout tetap. | [Konversi PowerPoint ke XPS](/slides/id/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP ke TIFF | Simpan presentasi sebagai file TIFF multi-halaman untuk pencetakan, pemindaian, faks, atau alur kerja arsip. | [Konversi PowerPoint ke TIFF](/slides/id/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP ke TIFF dengan catatan | Simpan slide dengan catatan pembicara ke TIFF. | [Konversi PowerPoint ke TIFF dengan Catatan](/slides/id/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX ke Markdown | Ekstrak konten presentasi ke Markdown untuk dokumentasi dan alur kerja berbasis teks. | [Konversi PowerPoint ke Markdown](/slides/id/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX ke GIF animasi | Buat GIF animasi dari slide. | [Konversi PowerPoint ke GIF Animasi](/slides/id/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX ke video | Bangun alur kerja ekspor video dari slide presentasi. | [Konversi PowerPoint ke Video](/slides/id/php-java/convert-powerpoint-to-video/) |
| Presentasi ke XAML | Ekspor slide ke XAML untuk skenario UI PHP atau Java. | [Ekspor Presentasi ke XAML](/slides/id/php-java/export-to-xaml/) |

Untuk daftar yang lebih luas tentang format input dan output, lihat [Format File yang Didukung](/slides/id/php-java/supported-file-formats/).

## **Konversi PowerPoint dan OpenDocument**

Aspose.Slides for PHP via Java mendukung konversi dari format presentasi yang umum digunakan seperti PPT, PPTX, PPS, PPSX, POT, POTX, dan ODP. API konversi yang sama digunakan untuk file PowerPoint dan OpenDocument, sehingga alur kerja yang menyimpan file PPTX ke PDF biasanya dapat diterapkan pada file ODP hanya dengan mengubah file input.

Saat mengonversi file ODP, ingat bahwa aplikasi PowerPoint dan OpenDocument tidak mendukung setiap tata letak dan fitur pemformatan dengan cara yang persis sama. Jika file ODP dibuat di LibreOffice atau OpenOffice Impress, tinjau hasilnya dan gunakan opsi yang dijelaskan dalam [Konversi Presentasi OpenDocument](/slides/id/php-java/convert-openoffice-odp/) ketika Anda membutuhkan panduan khusus format.

## **Konversi PPT ke PPTX**

PPT adalah format PowerPoint biner lama, sedangkan PPTX adalah format Office Open XML modern. Aspose.Slides for PHP via Java mendukung konversi PPT ke PPTX dengan fidelitas tinggi sambil mempertahankan struktur presentasi kompleks seperti master, layout, slide, diagram, bentuk yang digabungkan, placeholder, bingkai teks, tekstur, dan isi gambar.

Untuk detail, lihat [Konversi PPT ke PPTX](/slides/id/php-java/convert-ppt-to-pptx/) dan [PPT vs PPTX](/slides/id/php-java/ppt-vs-pptx/).

## **Ekspor Layout Tetap**

PDF, XPS, dan TIFF berguna ketika output harus tampak sama di semua perangkat dan tidak boleh diedit sebagai presentasi. Artikel khusus PDF, XPS, dan TIFF menjelaskan cara mengontrol kepatuhan, slide tersembunyi, catatan, kualitas gambar, kompresi, format piksel, dan ukuran output.

## **Ekspor HTML dan Gambar**

Ekspor HTML dan HTML5 berguna untuk tampilan di browser, penerbitan web, dan berbagi ringan. Ekspor gambar berguna ketika tiap slide harus menjadi preview, thumbnail, atau aset raster terpisah. Gunakan artikel PNG, JPG, dan SVG untuk panduan rendering khusus format.

## **FAQ**

**Apakah saya memerlukan Microsoft PowerPoint untuk mengonversi presentasi?**

Tidak. Aspose.Slides for PHP via Java adalah pustaka mandiri dan tidak memerlukan Microsoft PowerPoint atau otomasi Office.

**Bisakah saya mengonversi banyak presentasi secara batch?**

Ya. Muat setiap presentasi, simpan ke format yang diperlukan, dan buang objek presentasi setelah diproses. Untuk pemrosesan paralel, gunakan instance presentasi terpisah dan ikuti panduan [multithreading](/slides/id/php-java/multithreading/).

**Bisakah saya mengekspor hanya slide terpilih?**

Ya. Beberapa metode ekspor memungkinkan Anda melewatkan indeks slide atau merender slide individual, tergantung pada format output. Lihat artikel khusus untuk format target.

**Bisakah saya menyertakan slide tersembunyi saat mengekspor ke PDF atau XPS?**

Ya. Gunakan pengaturan ekspor slide tersembunyi yang dijelaskan dalam artikel [PDF](/slides/id/php-java/convert-powerpoint-to-pdf/) dan [XPS](/slides/id/php-java/convert-powerpoint-to-xps/).

**Bisakah saya membuat output PDF/A?**

Ya. Pengaturan kepatuhan PDF tersedia untuk ekspor PDF. Lihat [Konversi PowerPoint ke PDF](/slides/id/php-java/convert-powerpoint-to-pdf/) untuk detail.

**Bagaimana font ditangani selama konversi?**

Aspose.Slides dapat menggunakan font yang disematkan, fallback font, dan pengaturan substitusi font. Lihat [Embedded Font](/slides/id/php-java/embedded-font/), [Fallback Font](/slides/id/php-java/fallback-font/), dan [Font Substitution](/slides/id/php-java/font-substitution/).