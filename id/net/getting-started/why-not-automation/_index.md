---
title: Mengapa Tidak Otomasi
type: docs
weight: 40
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
description: "Temukan mengapa otomasi Office berisiko bagi server dan layanan, serta lihat bagaimana Aspose.Slides menawarkan pemrosesan presentasi yang lebih aman dan lebih cepat untuk PowerPoint dan OpenDocument."
---
## **Pendahuluan**

Ada beberapa alasan mengapa komponen Aspose menjadi alternatif yang lebih baik dibandingkan otomatisasi. Beberapa alasan utama adalah:

- Keamanan
- Stabilitas
- Skalabilitas/Kecepatan
- Harga
- Fitur

Berikut adalah penjelasan lebih rinci untuk setiap poin utama.

## **Pertanyaan Penting**

Ada dua pertanyaan yang sering kami dengar di Aspose:

- Apakah produk Anda memerlukan Microsoft Office terinstal untuk dapat dijalankan?

Jawaban singkat dan sederhana adalah **TIDAK**.

Komponen Aspose sepenuhnya independen dan tidak berafiliasi, tidak diotorisasi, tidak disponsori, atau disetujui oleh Microsoft Corporation.

- Mengapa kami harus menggunakan produk Aspose alih-alih Microsoft Office Automation?

Pertama, ada banyak [manfaat yang Anda dapatkan saat menggunakan Aspose.Slides](/slides/id/net/product-overview/).

Kedua, Microsoft sendiri sangat **menyarankan melawan** penggunaan Office Automation dari solusi perangkat lunak.

## **Keamanan**
Berikut adalah kutipan langsung dari Artikel Microsoft:

> Aplikasi Office tidak pernah dirancang untuk digunakan di sisi server, sehingga tidak mempertimbangkan masalah keamanan yang dihadapi oleh komponen terdistribusi. Office tidak mengautentikasi permintaan masuk, dan tidak melindungi Anda dari menjalankan makro secara tidak sengaja, atau memulai server lain yang mungkin menjalankan makro, dari kode sisi server Anda. Jangan membuka file yang diunggah ke server dari Web anonim! Berdasarkan pengaturan keamanan yang terakhir ditetapkan, server dapat menjalankan makro dengan konteks Administrator atau Sistem dengan hak penuh dan dapat mengompromikan jaringan Anda! Selain itu, Office menggunakan banyak komponen sisi klien (seperti Simple MAPI, WinInet, MSDAIPP) yang dapat menyimpan informasi autentikasi klien untuk mempercepat pemrosesan. Jika Office diotomatisasi di sisi server, satu instance dapat melayani lebih dari satu klien, dan karena informasi autentikasi telah disimpan untuk sesi tersebut, memungkinkan satu klien menggunakan kredensial yang disimpan dari klien lain, sehingga memperoleh izin akses yang tidak diberikan dengan menyamar sebagai pengguna lain.

Produk Aspose sangat **aman**. Komponen Aspose berjalan dalam konteks pengguna yang sama dengan semua aplikasi ASP.NET (di bawah pengguna ASPNET). Oleh karena itu, komponen Aspose **tidak** menimbulkan risiko keamanan. Mereka juga tidak mengonsumsi sumber daya sistem yang kritis. Selain itu, ketika sebuah komponen Aspose membuka dokumen, makro tidak dijalankan secara otomatis. Komponen Aspose dibangun untuk memungkinkan pengembang membuat, memanipulasi, dan menyimpan file Office.

{{% alert color="primary" %}} 

Tidak ada risiko yang terkait dengan paket Microsoft Office yang berlaku untuk komponen Aspose.

{{% /alert %}} 

## **Stabilitas**
Teks ini adalah kutipan langsung dari Artikel Microsoft yang sebelumnya disebutkan:

> Office 2000, Office XP, dan Office 2003 menggunakan teknologi Microsoft Windows Installer (MSI) untuk mempermudah instalasi dan perbaikan otomatis bagi pengguna akhir. MSI memperkenalkan konsep "install on first use", yang memungkinkan fitur dipasang atau dikonfigurasi secara dinamis pada waktu berjalan (untuk sistem, atau lebih sering untuk pengguna tertentu). Dalam lingkungan sisi server, hal ini memperlambat kinerja dan meningkatkan kemungkinan munculnya kotak dialog yang meminta pengguna menyetujui instalasi atau menyediakan disk instalasi yang sesuai. Meskipun dirancang untuk meningkatkan ketahanan Office sebagai produk pengguna akhir, implementasi kemampuan MSI oleh Office bersifat kontraproduktif dalam lingkungan sisi server. Selain itu, stabilitas Office secara umum tidak dapat dijamin ketika dijalankan di sisi server karena tidak dirancang atau diuji untuk penggunaan semacam ini. Menggunakan Office sebagai komponen layanan pada server jaringan dapat mengurangi stabilitas mesin tersebut dan akibatnya jaringan Anda secara keseluruhan. Jika Anda berencana mengotomatisasi Office di sisi server, usahakan mengisolasi program ke komputer khusus yang tidak dapat memengaruhi fungsi kritis, dan yang dapat di-restart bila diperlukan.

Karena komponen Aspose dikemas dalam satu file DLL, penggunanya tidak pernah perlu menginstal bagian tambahan agar berfungsi. Komponen Aspose hanya digunakan oleh aplikasi .NET dan tidak ada bagian kode komponen yang dirancang untuk menunggu respons manusia.

{{% alert color="primary" %}} 

Komponen Aspose telah diuji secara menyeluruh dan dikonfirmasi sangat stabil. Komponen Aspose digunakan oleh [perusahaan](http://www.aspose.com/Corporate/Aspose/Customerlist.html) seperti **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, dan banyak organisasi terkemuka lainnya di berbagai industri dan bidang. 

{{% /alert %}} 

## **Skalabilitas/Kecepatan**
Berikut adalah kutipan langsung dari Artikel Microsoft:

> Komponen sisi server harus sangat reentrant, komponen COM multithread dengan overhead minimal dan throughput tinggi untuk banyak klien. Aplikasi Office dalam hampir semua hal merupakan kebalikan yang tepat. Mereka adalah server Automation berbasis STA yang non-reentrant, dirancang untuk menyediakan fungsi yang beragam tetapi intensif sumber daya bagi satu klien. Mereka menawarkan skalabilitas yang sangat sedikit sebagai solusi sisi server, dan memiliki batas tetap pada elemen penting, seperti memori, yang tidak dapat diubah melalui konfigurasi. Lebih penting lagi, mereka menggunakan sumber daya global (seperti file memori yang dipetakan, add-in atau templat global, dan server Automation bersama), yang dapat membatasi jumlah instance yang dapat berjalan secara bersamaan dan menyebabkan kondisi balapan jika dikonfigurasikan dalam lingkungan multi-klien. Pengembang yang berencana menjalankan lebih dari satu instance dari aplikasi Office secara bersamaan perlu mempertimbangkan Pooling atau Serializing Access ke aplikasi Office untuk menghindari potensi Deadlock atau Korupsi Data.

Komponen Aspose sangat skalabel dan sangat cepat. Aplikasi Office tidak dirancang untuk digunakan secara bersamaan oleh ratusan atau ribuan pengguna, namun komponen Aspose dirancang khusus untuk itu. Komponen kami adalah solusi .NET sejati.

{{% alert color="primary" %}} 

Kinerja komponen Aspose tanpa cela pada server tunggal (menjalankan satu aplikasi) atau pada formulir web yang dityeimbangkan beban (menjalankan aplikasi seluruh perusahaan). 

{{% /alert %}} 

## **Harga**
Ketika sebuah aplikasi menggunakan Microsoft Office Automation, salinan Microsoft Office harus dibeli untuk setiap mesin yang menjalankan aplikasi tersebut. Ada banyak kasus di mana aplikasi perlu membuat atau memanipulasi file Office, tetapi proses tersebut tidak memerlukan Microsoft Office. 

{{% alert color="primary" %}} 

Aspose menyediakan lisensi distribusi ulang yang sangat [efisien biaya](https://purchase.aspose.com/) dan bebas royalti yang memungkinkan penyebaran ke jumlah pengguna tak terbatas tanpa kekhawatiran lisensi. 

{{% /alert %}} 

Ketika membuat aplikasi berbasis web, penting diingat bahwa komponen Microsoft Office Automation tidak memiliki harga maupun lisensi untuk solusi sisi server. Oleh karena itu, tidak ada solusi lisensi yang baik untuk penyebaran aplikasi web yang menggunakan komponen Microsoft Office. Aspose, di sisi lain, menyediakan solusi yang sangat [efisien biaya](https://purchase.aspose.com/) untuk aplikasi berbasis server juga.

## **Fitur**
Komponen Aspose menyediakan semua yang diperlukan untuk mengelola file Office dan banyak lagi. Kami merancangnya berdasarkan filosofi kami untuk membantu pengembang mencapai hasil terbaik dengan upaya minimal.

{{% alert color="primary" %}} 

Berbeda dengan Office Automation, komponen Aspose menyediakan banyak fungsi yang kuat dan menghemat waktu. 

{{% /alert %}} 

Misalnya, [Aspose.Cells](https://products.aspose.com/cells/net/) memberi pengembang kemampuan mengimpor data dari **DataTable** atau **DataView** langsung ke file Excel. [Aspose.Words](https://products.aspose.com/words/net/) menyediakan fitur serupa yang memungkinkan pengembang mengisi dokumen Word (yaitu Mail Merge) langsung dari objek data .NET apa pun. [Setiap komponen](https://products.aspose.com/total/net/) dalam keluarga Aspose menawarkan set fitur unik dan kuat mereka masing‑masing. 

Bagian terbaik dari membeli komponen Aspose adalah mendapatkan akses ke tim pengembangan kami. Misalnya, jika Anda menggunakan objek Office Automation dan membutuhkan fitur tertentu, peluang fitur tersebut ditambahkan sangat, sangat rendah. Namun, keadaan berbeda dengan komponen Aspose. 

{{% alert color="primary" %}} 

Tim pengembangan kami memahami bahwa jika ada fitur yang dibutuhkan perusahaan Anda, ada peluang besar bahwa perusahaan lain juga membutuhkannya. Meskipun kami sadar tidak dapat mengimplementasikan setiap permintaan fitur, kami berusaha menambahkan sebanyak mungkin fitur berdasarkan umpan balik dari pelanggan kami. 

{{% /alert %}} 

Tim kami selalu berpikiran terbuka dan fleksibel dalam memberikan bantuan—dan inilah alasan mengapa komponen Aspose tumbuh menjadi sekuat sekarang. 

## **Kesimpulan**
{{% alert color="primary" %}} 

Walaupun artikel ini membahas beberapa poin utama mengapa komponen Aspose merupakan pilihan yang lebih baik dibandingkan Office Automation, Anda harus memahami bahwa masih ada banyak manfaat lainnya. Kami hanya menyentuh beberapa keuntungan utama.

Selain itu, semua produk dan komponen Aspose menawarkan [Versi Evaluasi](https://downloads.aspose.com/slides/id/net) yang bebas risiko dan tanpa kewajiban. Kami mendorong Anda untuk memanfaatkan evaluasi tersebut guna melihat apa yang dapat dilakukan Aspose untuk aplikasi atau bisnis Anda. 

{{% /alert %}}