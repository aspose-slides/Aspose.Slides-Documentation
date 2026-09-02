---
title: "Mengonversi Presentasi ke Berbagai Format dalam Java"
linktitle: "Konversi Presentasi"
type: docs
weight: 70
url: /id/java/convert-presentation/
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
  - "Java"
  - "Aspose.Slides"
description: "Konversi presentasi PowerPoint dan OpenDocument ke PPTX, PDF, HTML, gambar, XPS, TIFF, dan lainnya dengan Aspose.Slides untuk Java."
---
## **Ikhtisar**

Aspose.Slides untuk Java dapat memuat presentasi PowerPoint dan OpenDocument serta menyimpan atau merendernya ke banyak format lain tanpa Microsoft PowerPoint, OpenOffice, atau LibreOffice. Anda dapat mengonversi file PPT lama ke PPTX modern, mengekspor presentasi ke dokumen layout tetap seperti PDF dan XPS, menerbitkan slide sebagai HTML, atau merender slide sebagai file gambar untuk pratinjau, thumbnail, dan arsip.

Sebagian besar konversi dokumen menggunakan alur kerja umum yang sama: memuat file sumber, memilih format output yang diperlukan, dan menerapkan opsi khusus format bila diperlukan. Untuk format gambar, setiap slide dirender secara terpisah dan kemudian disimpan sebagai gambar raster atau vektor. Artikel khusus yang ditautkan di bawah ini menyediakan detail implementasi untuk setiap kasus.

## **Pilih Skenario Konversi**

Gunakan artikel di bawah ini untuk contoh lengkap Java dan opsi khusus format.

| Skenario | Gunakan ketika Anda perlu | Artikel |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | Modernisasi file PPT lama, normalisasi file PPTX yang ada, atau konversi presentasi OpenDocument ke PowerPoint PPTX. | [Konversi PPT ke PPTX](/slides/id/java/convert-ppt-to-pptx/), [Konversi ODP ke PPTX](/slides/id/java/convert-odp-to-pptx/), [Simpan Presentasi](/slides/id/java/save-presentation/) |
| PPTX to PPT | Simpan presentasi PowerPoint modern ke format PPT biner lama untuk kompatibilitas dengan alur kerja yang lebih lama. | [Konversi PPTX ke PPT](/slides/id/java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | Buat dokumen layout tetap yang dapat dipindahkan, dapat dicari, untuk berbagi, mencetak, atau mengarsipkan. | [Konversi PowerPoint ke PDF](/slides/id/java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | Ekspor catatan pembicara bersama dengan konten slide. | [Konversi PowerPoint ke PDF dengan Catatan](/slides/id/java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | Terbitkan presentasi sebagai halaman HTML dan kendalikan gambar, font, catatan, serta opsi layout responsif. | [Konversi PowerPoint ke HTML](/slides/id/java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | Ekspor slide ke HTML5 untuk tampilan berbasis peramban dengan format dan interaktivitas yang dipertahankan. | [Konversi Presentasi ke HTML5](/slides/id/java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | Render setiap slide menjadi gambar PNG untuk pratinjau, thumbnail, atau output web. | [Konversi PowerPoint ke PNG](/slides/id/java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | Render slide menjadi gambar JPG dan kendalikan dimensi serta kualitas gambar. | [Konversi PowerPoint ke JPG](/slides/id/java/convert-powerpoint-to-jpg/) |
| Slide to SVG | Ekspor slide individu sebagai grafik vektor yang dapat diskalakan. | [Render Slide sebagai SVG](/slides/id/java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | Hasilkan dokumen XPS layout tetap. | [Konversi PowerPoint ke XPS](/slides/id/java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | Simpan presentasi sebagai file TIFF multipage untuk pencetakan, pemindaian, faks, atau alur kerja arsip. | [Konversi PowerPoint ke TIFF](/slides/id/java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | Simpan slide dengan catatan pembicara ke TIFF. | [Konversi PowerPoint ke TIFF dengan Catatan](/slides/id/java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | Konversi slide ke dokumen Word ketika Anda memerlukan output bergaya dokumen. | [Konversi PowerPoint ke Word](/slides/id/java/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | Ekstrak konten presentasi ke Markdown untuk dokumentasi dan alur kerja berbasis teks. | [Konversi PowerPoint ke Markdown](/slides/id/java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | Buat Presentasi PowerPoint XML berbasis teks untuk inspeksi, perbandingan, pemecahan masalah, atau alur kerja berbasis XML. | [Konversi PowerPoint ke XML](/slides/id/java/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | Buat GIF animasi dari slide. | [Konversi PowerPoint ke GIF Animasi](/slides/id/java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | Bangun alur kerja ekspor video dari slide presentasi. | [Konversi PowerPoint ke Video](/slides/id/java/convert-powerpoint-to-video/) |
| Presentation to XAML | Ekspor slide ke XAML untuk skenario UI Java. | [Ekspor Presentasi ke XAML](/slides/id/java/export-to-xaml/) |

Untuk daftar yang lebih luas dari format input dan output, lihat [Format File yang Didukung](/slides/id/java/supported-file-formats/).

## **Konversi PowerPoint dan OpenDocument**

Aspose.Slides untuk Java mendukung konversi dari format presentasi yang umum digunakan seperti PPT, PPTX, PPS, PPSX, POT, POTX, dan ODP. API konversi yang sama digunakan untuk file PowerPoint dan OpenDocument, sehingga alur kerja yang menyimpan file PPTX ke PDF biasanya dapat diterapkan pada file ODP hanya dengan mengubah file input.

Saat mengonversi file ODP, ingat bahwa aplikasi PowerPoint dan OpenDocument tidak mendukung setiap tata letak dan fitur pemformatan dengan cara yang persis sama. Jika file ODP dibuat di LibreOffice atau OpenOffice Impress, tinjau output dan gunakan opsi yang dijelaskan dalam [Konversi Presentasi OpenDocument](/slides/id/java/convert-openoffice-odp/) ketika Anda memerlukan panduan khusus format.

## **Konversi PPT ke PPTX**

PPT adalah format PowerPoint biner lama, sedangkan PPTX adalah format Office Open XML modern. Aspose.Slides untuk Java mendukung konversi PPT ke PPTX dengan fidelitas tinggi sambil mempertahankan struktur presentasi yang kompleks seperti master, tata letak, slide, diagram, bentuk yang dikelompokkan, placeholder, bingkai teks, tekstur, dan isian gambar.

Untuk detail, lihat [Konversi PPT ke PPTX](/slides/id/java/convert-ppt-to-pptx/) dan [PPT vs PPTX](/slides/id/java/ppt-vs-pptx/).

## **Ekspor Layout Tetap**

PDF, XPS, dan TIFF berguna ketika output harus tampak sama di semua perangkat dan tidak boleh diedit sebagai presentasi. Artikel khusus PDF, XPS, dan TIFF menjelaskan cara mengontrol kepatuhan, slide tersembunyi, catatan, kualitas gambar, kompresi, format piksel, dan ukuran output.

## **Ekspor HTML dan Gambar**

Ekspor HTML dan HTML5 berguna untuk tampilan di peramban, penerbitan web, dan berbagi ringan. Ekspor gambar berguna ketika setiap slide harus menjadi pratinjau, thumbnail, atau aset raster terpisah. Gunakan artikel PNG, JPG, dan SVG untuk panduan rendering khusus format.

## **Tanya Jawab**

**Apakah saya memerlukan Microsoft PowerPoint untuk mengonversi presentasi?**

Tidak. Aspose.Slides untuk Java adalah pustaka mandiri dan tidak memerlukan Microsoft PowerPoint atau automasi Office.

**Apakah saya dapat mengonversi banyak presentasi secara batch?**

Ya. Muat setiap presentasi, simpan ke format yang diperlukan, dan buang objek presentasi setelah pemrosesan. Untuk pemrosesan paralel, gunakan instance presentasi terpisah dan ikuti panduan [multithreading](/slides/id/java/multithreading/).

**Apakah saya dapat mengekspor hanya slide yang dipilih?**

Ya. Beberapa metode ekspor memungkinkan Anda menyertakan indeks slide atau merender slide individu, tergantung pada format output. Lihat artikel khusus untuk format target.

**Apakah saya dapat menyertakan slide tersembunyi saat mengekspor ke PDF atau XPS?**

Ya. Gunakan pengaturan ekspor slide tersembunyi yang dijelaskan dalam artikel [PDF](/slides/id/java/convert-powerpoint-to-pdf/) dan [XPS](/slides/id/java/convert-powerpoint-to-xps/).

**Apakah saya dapat membuat output PDF/A?**

Ya. Pengaturan kepatuhan PDF tersedia untuk ekspor PDF. Lihat [Konversi PowerPoint ke PDF](/slides/id/java/convert-powerpoint-to-pdf/) untuk detail.

**Bagaimana font ditangani selama konversi?**

Aspose.Slides dapat menggunakan font tertanam, fallback font, dan pengaturan substitusi font. Lihat [Embedded Font](/slides/id/java/embedded-font/), [Fallback Font](/slides/id/java/fallback-font/), dan [Font Substitution](/slides/id/java/font-substitution/).