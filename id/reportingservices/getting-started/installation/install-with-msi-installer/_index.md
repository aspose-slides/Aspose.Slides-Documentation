---
title: Instal dengan Penginstal MSI
type: docs
weight: 20
url: /id/reportingservices/install-with-msi-installer/
keywords:
- Penginstal MSI
- instalasi
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Instal Aspose.Slides for Reporting Services dengan penginstal MSI-nya: apa yang dibutuhkan penginstal, apa yang diubah pada setiap instance server laporan, dan cara memeriksa hasilnya."
---
## **Instalasi**

Penginstal MSI adalah cara termudah untuk menginstal Aspose.Slides for Reporting Services. Ia memerlukan .NET Framework 3.5 dan hak administrator pada server laporan; lihat [Persyaratan Sistem](/slides/id/reportingservices/system-requirements/).

1. Unduh penginstal MSI, *Aspose.Slides for Reporting Services XX.XX*, dari [halaman unduhan](https://releases.aspose.com/slides/reportingservices/) dan salin ke server laporan.
2. Jalankan sebagai administrator. Jika .NET Framework 3.5 tidak ada, penginstal berhenti dengan pesan; instal fitur .NET Framework 3.5 dan jalankan kembali.
3. Terima perjanjian lisensi.
4. Pada halaman **Custom Setup**, pohon fitur menampilkan setiap instance SQL Server Reporting Services dan Power BI Report Server yang terdeteksi oleh penginstal pada mesin. Untuk membiarkan sebuah instance tidak berubah, klik ikonnya dan pilih **Entire feature will be unavailable**. Edisi Express tidak mendukung ekstensi rendering, jadi jangan pilih instance Express. Penginstal menyembunyikan instance Express dari SQL Server 2016 dan sebelumnya.
5. Pilih **Next**, lalu **Install**.

Fitur opsional **Rpl Export** tidak dipilih secara default. Fitur ini menambahkan ekstensi tersembunyi yang menyimpan laporan dalam format RPL, yang berguna saat Anda mengirim laporan masalah ke Aspose; lihat [Mengekspor Laporan ke Format RPL](/slides/id/reportingservices/exporting-reports-to-rpl-format/).

## **Apa yang Diubah Penginstal**

Penginstal menyimpan file‑nya di *Aspose\Aspose.Slides for Reporting Services* di dalam folder Program Files — *Program Files (x86)* pada Windows 64‑bit, karena penginstal merupakan paket 32‑bit. Kemudian, untuk setiap instance yang dipilih, ia:

- menyalin *Aspose.Slides.ReportingServices.dll* ke folder *ReportServer\bin* pada instance — build untuk SQL Server 2005, atau build untuk SQL Server 2008 dan selanjutnya serta Power BI Report Server;
- menambahkan enam ekstensi rendering — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS dan ASODP — ke elemen `<Render>` pada *rsreportserver.config*;
- menambahkan grup kode yang memberikan kepercayaan penuh pada assembly ke *rssrvpolicy.config*;
- menyimpan salinan setiap file konfigurasi yang diubah, dengan tambahan *.bak* pada nama file.

[Instal Secara Manual](/slides/id/reportingservices/install-manually/) menunjukkan perubahan ini langkah demi langkah.

Jika sebuah instance tidak dapat dikonfigurasi, penginstal menamainya dalam pesan dan menuliskan detailnya ke *rserrors&lt;date&gt;.log* di folder instalasi. Instal ekstensi pada instance tersebut secara manual.

## **Periksa Instalasi**

Buka laporan berhalaman di portal web (Report Manager pada SQL Server 2014 dan sebelumnya) dan buka daftar **Export**. Sekarang daftar tersebut mencakup format berikut:

- PPT - Presentasi PowerPoint via Aspose.Slides
- PPS - SlideShow PowerPoint via Aspose.Slides
- PPTX - Presentasi PowerPoint 2007 via Aspose.Slides
- PPSX - SlideShow PowerPoint 2007 via Aspose.Slides
- ODP - Presentasi OpenDocument via Aspose.Slides
- XPS - via Aspose.Slides

Tanpa lisensi, file yang diekspor memiliki watermark evaluasi; lihat [Lisensi](/slides/id/reportingservices/license-aspose-slides-for-reporting-services/).

## **Kapan Harus Menginstal Secara Manual**

Instal ekstensi [secara manual](/slides/id/reportingservices/install-manually/) sebagai gantinya ketika:

- penginstal tidak dapat mengkonfigurasi sebuah instance, misalnya karena pengaturan keamanan pada server;
- setelah peningkatan, Anda ingin mengganti hanya assembly saja alih‑alih mencopot versi lama dan menjalankan penginstal baru.

Mencopot pemasangan produk menghapus assembly dan entri konfigurasi dari setiap instance.