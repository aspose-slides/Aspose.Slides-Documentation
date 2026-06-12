---
title: "Konversi Presentasi ke Berbagai Format dalam JavaScript"
linktitle: "Konversi Presentasi"
type: docs
weight: 70
url: /id/nodejs-java/convert-presentation/
keywords:
- "konversi presentasi"
- "ekspor presentasi"
- "PPT ke PPTX"
- "PPTX ke PPT"
- "ODP ke PPTX"
- "PPT ke PDF"
- "PPTX ke PDF"
- "ODP ke PDF"
- "PPT ke HTML"
- "PPTX ke HTML"
- "ODP ke HTML"
- "PPT ke PNG"
- "PPTX ke PNG"
- "ODP ke PNG"
- "PPTX ke JPG"
- "ODP ke JPG"
- "PPT ke XPS"
- "PPTX ke XPS"
- "ODP ke XPS"
- "PPT ke TIFF"
- "PPTX ke TIFF"
- "ODP ke TIFF"
- "PowerPoint"
- "OpenDocument"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Konversi presentasi PowerPoint dan OpenDocument ke PPTX, PDF, HTML, gambar, XPS, TIFF, dan lainnya dengan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Aspose.Slides for Node.js via Java dapat memuat presentasi PowerPoint dan OpenDocument serta menyimpan atau merendernya ke banyak format lain tanpa Microsoft PowerPoint, OpenOffice, atau LibreOffice. Anda dapat mengonversi file PPT lama ke PPTX modern, mengekspor presentasi ke dokumen berlayout tetap seperti PDF dan XPS, menerbitkan slide sebagai HTML, atau merender slide sebagai file gambar untuk pratinjau, thumbnail, dan arsip.

Sebagian besar konversi dokumen menggunakan alur kerja umum yang sama: memuat file sumber, memilih format output yang diperlukan, dan menerapkan opsi spesifik format bila diperlukan. Untuk format gambar, setiap slide dirender secara terpisah lalu disimpan sebagai gambar raster atau vektor. Artikel khusus yang ditautkan di bawah ini memberikan detail implementasi untuk setiap kasus.

## **Pilih Skenario Konversi**

Gunakan artikel di bawah untuk contoh JavaScript lengkap dan opsi khusus format.

| Skenario | Gunakan ketika Anda perlu | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP ke PPTX | Memodernisasi file PPT lama, menormalkan file PPTX yang sudah ada, atau mengonversi presentasi OpenDocument ke PowerPoint PPTX. | [Ubah PPT ke PPTX](/slides/id/nodejs-java/convert-ppt-to-pptx/), [Ubah ODP ke PPTX](/slides/id/nodejs-java/convert-odp-to-pptx/), [Simpan Presentasi](/slides/id/nodejs-java/save-presentation/) |
| PPTX ke PPT | Simpan presentasi PowerPoint modern ke format PPT biner lama untuk kompatibilitas dengan alur kerja lama. | [Ubah PPTX ke PPT](/slides/id/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP ke PDF | Buat dokumen berlayout tetap yang portabel, dapat dicari, untuk berbagi, mencetak, atau mengarsipkan. | [Ubah PowerPoint ke PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP ke PDF dengan catatan | Ekspor catatan pembicara bersamaan dengan konten slide. | [Ubah PowerPoint ke PDF dengan Catatan](/slides/id/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP ke HTML | Menerbitkan presentasi sebagai halaman HTML dan mengontrol gambar, font, catatan, serta opsi tata letak responsif. | [Ubah PowerPoint ke HTML](/slides/id/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP ke HTML5 | Ekspor slide ke HTML5 untuk tampilan berbasis browser dengan format dan interaktivitas yang dipertahankan. | [Ubah Presentasi ke HTML5](/slides/id/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP ke PNG | Render setiap slide menjadi gambar PNG untuk pratinjau, thumbnail, atau output web. | [Ubah PowerPoint ke PNG](/slides/id/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP ke JPG | Render slide ke gambar JPG dan mengontrol dimensi serta kualitas gambar. | [Ubah PowerPoint ke JPG](/slides/id/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide ke SVG | Ekspor slide individual sebagai grafik vektor skalabel. | [Render Slide sebagai SVG](/slides/id/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP ke XPS | Hasilkan dokumen XPS berlayout tetap. | [Ubah PowerPoint ke XPS](/slides/id/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP ke TIFF | Simpan presentasi sebagai file TIFF multi-halaman untuk pencetakan, pemindaian, faks, atau alur kerja arsip. | [Ubah PowerPoint ke TIFF](/slides/id/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP ke TIFF dengan catatan | Simpan slide dengan catatan pembicara ke TIFF. | [Ubah PowerPoint ke TIFF dengan Catatan](/slides/id/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX ke Markdown | Ekstrak konten presentasi ke Markdown untuk dokumentasi dan alur kerja berbasis teks. | [Ubah PowerPoint ke Markdown](/slides/id/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX ke GIF animasi | Buat GIF animasi dari slide. | [Ubah PowerPoint ke GIF Animasi](/slides/id/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX ke video | Bangun alur kerja ekspor video dari slide presentasi. | [Ubah PowerPoint ke Video](/slides/id/nodejs-java/convert-powerpoint-to-video/) |
| Presentasi ke XAML | Ekspor slide ke XAML untuk skenario UI JavaScript atau Java. | [Ekspor Presentasi ke XAML](/slides/id/nodejs-java/export-to-xaml/) |

Untuk daftar yang lebih luas tentang format masukan dan keluaran, lihat [Format File yang Didukung](/slides/id/nodejs-java/supported-file-formats/).

## **Konversi PowerPoint dan OpenDocument**

Aspose.Slides untuk Node.js via Java mendukung konversi dari format presentasi yang umum digunakan seperti PPT, PPTX, PPS, PPSX, POT, POTX, dan ODP. API konversi yang sama digunakan untuk file PowerPoint dan OpenDocument, sehingga alur kerja yang menyimpan file PPTX ke PDF biasanya dapat diterapkan pada file ODP hanya dengan mengubah file masukan.

Saat mengonversi file ODP, ingat bahwa aplikasi PowerPoint dan OpenDocument tidak mendukung setiap tata letak dan fitur pemformatan dengan cara yang sama persis. Jika file ODP dibuat di LibreOffice atau OpenOffice Impress, tinjau hasilnya dan gunakan opsi yang dijelaskan di [Ubah Presentasi OpenDocument](/slides/id/nodejs-java/convert-openoffice-odp/) ketika Anda membutuhkan panduan khusus format.

## **Konversi PPT ke PPTX**

PPT adalah format PowerPoint biner lama, sedangkan PPTX adalah format Office Open XML modern. Aspose.Slides untuk Node.js via Java mendukung konversi PPT ke PPTX dengan fidelitas tinggi sambil mempertahankan struktur presentasi yang kompleks seperti master, tata letak, slide, bagan, bentuk berkelompok, placeholder, bingkai teks, tekstur, dan isian gambar.

Untuk detail, lihat [Ubah PPT ke PPTX](/slides/id/nodejs-java/convert-ppt-to-pptx/) dan [PPT vs PPTX](/slides/id/nodejs-java/ppt-vs-pptx/).

## **Ekspor Berlayout Tetap**

PDF, XPS, dan TIFF berguna ketika output harus terlihat sama di semua perangkat dan tidak boleh diedit sebagai presentasi. Artikel khusus PDF, XPS, dan TIFF menjelaskan cara mengontrol kepatuhan, slide tersembunyi, catatan, kualitas gambar, kompresi, format piksel, dan ukuran output.

## **Ekspor HTML dan Gambar**

Ekspor HTML dan HTML5 berguna untuk penampilan di browser, penerbitan web, dan berbagi ringan. Ekspor gambar berguna ketika setiap slide harus menjadi pratinjau, thumbnail, atau aset raster terpisah. Gunakan artikel PNG, JPG, dan SVG untuk panduan rendering khusus format.

## **FAQ**

**Apakah saya membutuhkan Microsoft PowerPoint untuk mengonversi presentasi?**

Tidak. Aspose.Slides untuk Node.js via Java adalah pustaka mandiri dan tidak memerlukan Microsoft PowerPoint atau otomatisasi Office.

**Apakah saya dapat mengonversi banyak presentasi secara batch?**

Ya. Muat setiap presentasi, simpan ke format yang diperlukan, dan buang objek presentasi setelah diproses. Untuk pemrosesan paralel, gunakan instance presentasi terpisah dan ikuti panduan [multithreading](/slides/id/nodejs-java/multithreading/).

**Apakah saya dapat mengekspor hanya slide tertentu?**

Ya. Beberapa metode ekspor memungkinkan Anda memberikan indeks slide atau merender slide individual, tergantung pada format output. Lihat artikel khusus untuk format target.

**Apakah saya dapat menyertakan slide tersembunyi saat mengekspor ke PDF atau XPS?**

Ya. Gunakan pengaturan ekspor slide tersembunyi yang dijelaskan dalam artikel konversi [PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/) dan [XPS](/slides/id/nodejs-java/convert-powerpoint-to-xps/).

**Apakah saya dapat membuat output PDF/A?**

Ya. Pengaturan kepatuhan PDF tersedia untuk ekspor PDF. Lihat [Ubah PowerPoint ke PDF](/slides/id/nodejs-java/convert-powerpoint-to-pdf/) untuk detail.

**Bagaimana font ditangani selama konversi?**

Aspose.Slides dapat menggunakan font tersemat, font cadangan, dan pengaturan penggantian font. Lihat [Font Tersemat](/slides/id/nodejs-java/embedded-font/), [Font Cadangan](/slides/id/nodejs-java/fallback-font/), dan [Penggantian Font](/slides/id/nodejs-java/font-substitution/).