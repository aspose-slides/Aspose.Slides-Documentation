---
title: Mengapa Tidak Menggunakan Otomasi
type: docs
weight: 170
url: /id/net/why-not-automation/
keywords:
- otomasi
- Microsoft Office
- perbandingan
- keamanan
- stabilitas
- skalabilitas
- fitur
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan mengapa otomasi Office berisiko untuk server dan layanan, serta lihat bagaimana Aspose.Slides menawarkan pemrosesan presentasi yang lebih aman dan lebih cepat untuk PowerPoint dan OpenDocument."
---
## **Pendahuluan**

Ada beberapa alasan mengapa komponen Aspose merupakan alternatif yang lebih baik dibandingkan otomatisasi. Beberapa alasan utama antara lain:

- Keamanan
- Stabilitas
- Skalabilitas/Kecepatan
- Harga
- Fitur

Berikut adalah penjelasan lebih rinci dari setiap poin utama.

## **Pertanyaan Penting**

Ada dua pertanyaan yang sering kami dengar di Aspose:

- Apakah produk Anda memerlukan Microsoft Office terinstal untuk dapat dijalankan?

  Jawaban singkat dan sederhana adalah **TIDAK**.

- Mengapa kami harus menggunakan produk Aspose alih-alih Microsoft Office Automation?

  Pertama, ada banyak [manfaat yang Anda dapatkan ketika menggunakan Aspose.Slides](/slides/id/net/product-overview/).

  Kedua, Microsoft sendiri sangat **menyarankan untuk tidak** menggunakan Office Automation dalam solusi perangkat lunak.

## **Keamanan**
Berikut adalah kutipan langsung dari artikel Microsoft:

> Office Applications tidak pernah dirancang untuk digunakan di sisi server, sehingga tidak memperhitungkan masalah keamanan yang dihadapi oleh komponen terdistribusi. Office tidak mengautentikasi permintaan masuk, dan tidak melindungi Anda dari menjalankan makro secara tidak sengaja, atau memulai server lain yang mungkin menjalankan makro, dari kode sisi server Anda. Jangan membuka file yang diunggah ke server dari Web anonim! Berdasarkan pengaturan keamanan yang terakhir diatur, server dapat menjalankan makro di bawah konteks Administrator atau System dengan hak penuh dan membahayakan jaringan Anda! Selain itu, Office menggunakan banyak komponen sisi klien (seperti Simple MAPI, WinInet, MSDAIPP) yang dapat menyimpan informasi autentikasi klien dalam cache untuk mempercepat proses. Jika Office diotomatisasi di sisi server, satu instance dapat melayani lebih dari satu klien, dan karena informasi autentikasi telah di-cache untuk sesi tersebut, memungkinkan satu klien menggunakan kredensial yang di-cache dari klien lain, sehingga memperoleh izin akses yang tidak diberikan dengan menyamar sebagai pengguna lain.

Produk Aspose sangat **aman**. Komponen Aspose berjalan dalam konteks pengguna yang sama dengan semua aplikasi ASP.NET (di bawah pengguna ASPNET). Oleh karena itu, komponen Aspose **tidak** menimbulkan risiko keamanan. Mereka juga tidak mengonsumsi sumber daya sistem yang kritis. Selain itu, ketika komponen Aspose membuka dokumen, makro tidak akan dijalankan secara otomatis. Komponen Aspose dibangun untuk memungkinkan pengembang membuat, memanipulasi, dan menyimpan file Office.

{{% alert color="info" title="Note" %}}
Tidak ada risiko yang terkait dengan paket Microsoft Office yang berlaku untuk komponen Aspose.
{{% /alert %}}

## **Stabilitas**
Teks ini adalah kutipan langsung dari artikel Microsoft yang disebutkan sebelumnya:

> Office 2000, Office XP, dan Office 2003 menggunakan teknologi Microsoft Windows Installer (MSI) untuk mempermudah instalasi dan perbaikan mandiri bagi pengguna akhir. MSI memperkenalkan konsep "install on first use", yang memungkinkan fitur dipasang secara dinamis atau dikonfigurasi pada waktu berjalan (untuk sistem, atau lebih sering untuk pengguna tertentu). Dalam lingkungan sisi server, hal ini memperlambat kinerja dan meningkatkan kemungkinan munculnya kotak dialog yang meminta pengguna menyetujui instalasi atau menyediakan disk instalasi yang sesuai. Meskipun dirancang untuk meningkatkan ketahanan Office sebagai produk pengguna akhir, implementasi kemampuan MSI oleh Office justru kontraproduktif di lingkungan sisi server. Selain itu, stabilitas Office secara umum tidak dapat dijamin ketika dijalankan di sisi server karena belum dirancang atau diuji untuk penggunaan tersebut. Menggunakan Office sebagai komponen layanan pada server jaringan dapat mengurangi stabilitas mesin tersebut dan konsekuensinya jaringan Anda secara keseluruhan. Jika Anda berencana mengotomatisasi Office di sisi server, usahakan mengisolasi program ke komputer khusus yang tidak dapat memengaruhi fungsi penting, dan yang dapat di‑restart sesuai kebutuhan.

Karena komponen Aspose dikemas dalam satu DLL, penggunanya tidak pernah perlu menginstal bagian tambahan agar berfungsi. Komponen Aspose hanya digunakan oleh aplikasi .NET dan tidak ada bagian kode komponen yang dirancang untuk menunggu respons manusia.

{{% alert color="info" title="Note" %}}
Komponen Aspose telah diuji secara menyeluruh dan dikonfirmasi sangat stabil. Komponen Aspose digunakan oleh [perusahaan](https://about.aspose.com/customers/) seperti **Bank of America** dan banyak organisasi terkemuka lainnya di berbagai industri dan bidang.
{{% /alert %}}

## **Skalabilitas/Kecepatan**
Berikut adalah kutipan langsung dari artikel Microsoft:

> Komponen sisi server harus sangat reentrant, komponen COM multithreaded dengan overhead minimal dan throughput tinggi untuk banyak klien. Aplikasi Office dalam hampir semua hal merupakan kebalikan yang tepat. Mereka adalah server Otomasi berbasis STA yang tidak reentrant, yang dirancang untuk menyediakan fungsi beragam namun intensif sumber daya untuk satu klien. Mereka menawarkan sedikit skalabilitas sebagai solusi sisi server, dan memiliki batas tetap pada elemen penting, seperti memori, yang tidak dapat diubah melalui konfigurasi. Lebih penting lagi, mereka menggunakan sumber daya global (seperti file memori yang dipetakan, add‑in atau template global, dan server Otomasi bersama), yang dapat membatasi jumlah instance yang dapat berjalan secara bersamaan dan menyebabkan kondisi balapan jika dikonfigurasi dalam lingkungan multi‑klien. Pengembang yang berencana menjalankan lebih dari satu instance dari aplikasi Office secara bersamaan perlu mempertimbangkan Pooling atau Serializing Access ke aplikasi Office untuk menghindari potensi Deadlocks atau Data Corruption.

Komponen Aspose sangat scalable dan sangat cepat. Aplikasi Office tidak dirancang untuk digunakan secara bersamaan oleh ratusan atau ribuan pengguna, tetapi komponen Aspose dirancang khusus untuk itu. Komponen kami adalah solusi .NET sejati.

{{% alert color="info" title="Note" %}}
Kinerja komponen Aspose sempurna pada satu server (menjalankan satu aplikasi) atau pada formulir web yang di‑load balancing (menjalankan aplikasi tingkat perusahaan).
{{% /alert %}}

## **Harga**
Ketika sebuah aplikasi menggunakan Microsoft Office Automation, salinan Microsoft Office harus dibeli untuk setiap mesin yang menjalankan aplikasi tersebut. Ada banyak situasi di mana aplikasi mungkin perlu membuat atau memanipulasi file Office, tetapi proses tersebut tidak memerlukan Microsoft Office.

{{% alert color="info" title="Note" %}}
Aspose menyediakan lisensi redistribusi yang sangat [ekonomis](https://purchase.aspose.com/) dan bebas royalti yang memungkinkan penyebaran ke jumlah pengguna tak terbatas tanpa kekhawatiran lisensi.
{{% /alert %}}

Saat membuat aplikasi berbasis web, penting untuk diingat bahwa komponen Microsoft Office Automation tidak memiliki harga maupun lisensi untuk solusi sisi server. Oleh karena itu, tidak ada solusi lisensi yang baik untuk penyebaran aplikasi web yang menggunakan komponen Microsoft Office. Aspose, sebaliknya, menyediakan solusi yang sangat [ekonomis](https://purchase.aspose.com/) untuk aplikasi berbasis server.

## **Fitur**
Komponen Aspose menyediakan semua yang dibutuhkan untuk mengelola file Office dan banyak lagi. Kami merancangnya berdasarkan filosofi kami untuk membantu pengembang mencapai hasil terbaik dengan upaya paling sedikit.

{{% alert color="info" title="Note" %}}
Berbeda dengan Office Automation, komponen Aspose menyediakan banyak fungsi yang kuat dan menghemat waktu.
{{% /alert %}}

Misalnya, [Aspose.Cells](https://products.aspose.com/cells/net/) memberi pengembang kemampuan untuk mengimpor data dari **DataTable** atau **DataView** langsung ke file Excel. [Aspose.Words](https://products.aspose.com/words/net/) menyediakan fitur serupa yang memungkinkan pengembang mengisi dokumen Word (yaitu, Mail Merge) langsung dari objek data .NET apa pun. [Setiap komponen](https://products.aspose.com/total/net/) dalam keluarga Aspose menawarkan serangkaian fitur unik dan kuat masing‑masing.

Bagian terbaik dari membeli komponen Aspose adalah mendapatkan akses ke tim pengembangan kami. Misalnya, jika Anda menggunakan objek Office Automation dan memerlukan fitur tertentu, peluang agar fitur tersebut ditambahkan sangat, sangat rendah. Namun, halnya berbeda dengan komponen Aspose.

{{% alert color="info" title="Note" %}}
Tim pengembangan kami memahami bahwa jika ada fitur yang dibutuhkan perusahaan Anda, ada peluang besar bahwa perusahaan lain juga membutuhkan fitur yang sama. Meskipun kami menyadari bahwa tidak dapat mengimplementasikan setiap fitur yang diminta, kami berusaha menambahkan sebanyak mungkin fitur berdasarkan masukan dari pelanggan kami.
{{% /alert %}}

Tim kami selalu berpikiran terbuka dan fleksibel dalam memberikan bantuan—dan inilah alasan mengapa komponen Aspose telah berkembang menjadi sekuat sekarang.

## **Kesimpulan**
{{% alert color="info" title="Note" %}}
Meskipun artikel ini mencakup beberapa poin utama mengapa komponen Aspose merupakan pilihan yang lebih baik dibandingkan Office Automation, Anda harus memahami bahwa masih ada banyak, banyak manfaat lainnya. Kami hanya membahas beberapa keunggulan utama.

Selain itu, semua produk dan komponen Aspose menawarkan [Versi Evaluasi](https://releases.aspose.com/slides/id/net/) yang bebas risiko dan tanpa kewajiban. Kami mendorong Anda untuk memanfaatkan evaluasi tersebut untuk melihat apa yang dapat dilakukan Aspose untuk aplikasi atau bisnis Anda.
{{% /alert %}}