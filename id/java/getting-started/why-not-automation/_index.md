---
title: Mengapa Tidak Otomasi
type: docs
weight: 170
url: /id/java/why-not-automation/
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
- Java
- Aspose.Slides
description: "Temukan mengapa otomasi Office berisiko bagi server dan layanan, serta lihat bagaimana Aspose.Slides menawarkan pemrosesan presentasi yang lebih aman dan lebih cepat untuk PowerPoint dan OpenDocument."
---
## **Pendahuluan**

Ada beberapa alasan mengapa komponen Aspose merupakan alternatif yang lebih baik dibandingkan otomasi. Beberapa alasan utama adalah:

- Keamanan
- Stabilitas
- Skalabilitas/Kecepatan
- Harga
- Fitur

Berikut penjelasan lebih rinci tentang tiap poin utama.

## **Pertanyaan Penting**

Ada dua pertanyaan yang sering kami dengar di Aspose:

- Apakah produk Anda memerlukan Microsoft Office terpasang untuk dapat dijalankan?

Jawaban singkat dan sederhana adalah **TIDAK**.

Komponen Aspose sepenuhnya independen dan tidak berafiliasi dengan, tidak diotorisasi oleh, tidak disponsori oleh, atau disetujui oleh Microsoft Corporation.

- Mengapa kami harus menggunakan produk Aspose daripada Microsoft Office Automation?

Pertama, ada banyak [manfaat yang Anda dapatkan ketika menggunakan Aspose.Slides](/slides/id/java/product-overview/).

Kedua, Microsoft sendiri sangat **menyarankan untuk tidak** menggunakan Office Automation dalam solusi perangkat lunak.

## **Keamanan**
*"Applikasi Office tidak pernah dirancang untuk digunakan di sisi server, sehingga tidak mempertimbangkan masalah keamanan yang dihadapi oleh komponen terdistribusi. Office tidak mengautentikasi permintaan masuk, dan tidak melindungi Anda dari menjalankan makro secara tidak sengaja, atau memulai server lain yang mungkin menjalankan makro, dari kode sisi server Anda. Jangan membuka file yang diunggah ke server dari Web anonim! Berdasarkan pengaturan keamanan yang terakhir disetel, server dapat menjalankan makro di bawah konteks Administrator atau Sistem dengan hak istimewa penuh dan membahayakan jaringan Anda! Selain itu, Office menggunakan banyak komponen sisi klien (seperti Simple MAPI, WinInet, MSDAIPP) yang dapat menyimpan informasi autentikasi klien dalam cache untuk mempercepat pemrosesan. Jika Office diotomatisasi di sisi server, satu instance dapat melayani lebih dari satu klien, dan karena informasi autentikasi telah dicache untuk sesi tersebut, memungkinkan satu klien menggunakan kredensial yang dicache dari klien lain, sehingga memperoleh izin akses yang tidak diberikan dengan menyamar sebagai pengguna lain."*

Produk Aspose sangat aman. Komponen Aspose tidak menimbulkan risiko potensial pada sumber daya sistem yang vital. Selain itu, ketika dokumen dibuka oleh komponen Aspose, makro tidak dijalankan secara otomatis. Komponen Aspose dibangun dengan tujuan memungkinkan pengembang membuat, memanipulasi, dan menyimpan file Office. Tidak ada risiko yang terkait dengan paket Microsoft Office yang melekat pada komponen Aspose.

## **Stabilitas**
*"Office 2000, Office XP, dan Office 2003 menggunakan teknologi Microsoft Windows Installer (MSI) untuk mempermudah instalasi dan perbaikan mandiri bagi pengguna akhir. MSI memperkenalkan konsep "install on first use", yang memungkinkan fitur-fitur dipasang atau dikonfigurasi secara dinamis pada waktu jalan (untuk sistem, atau lebih sering untuk pengguna tertentu). Di lingkungan sisi server, hal ini memperlambat kinerja dan meningkatkan kemungkinan kotak dialog muncul yang meminta pengguna untuk menyetujui instalasi atau menyediakan disk instalasi yang sesuai. Meskipun dirancang untuk meningkatkan ketahanan Office sebagai produk pengguna akhir, implementasi kemampuan MSI oleh Office justru kontraproduktif di lingkungan sisi server. Selain itu, stabilitas Office secara umum tidak dapat dijamin ketika dijalankan di sisi server karena tidak dirancang atau diuji untuk penggunaan jenis ini. Menggunakan Office sebagai komponen layanan pada server jaringan dapat mengurangi stabilitas mesin tersebut dan akibatnya jaringan Anda secara keseluruhan. Jika Anda berencana mengotomatisasi Office di sisi server, usahakan untuk mengisolasi program ke komputer khusus yang tidak dapat memengaruhi fungsi kritis, dan yang dapat di-restart sesuai kebutuhan."*

Komponen Aspose telah diuji secara menyeluruh dan sangat stabil. Komponen Aspose digunakan oleh [perusahaan](https://about.aspose.com/customers/) seperti **Bank of America** dan masih banyak lagi.

## **Skalabilitas/Kecepatan**
*"Komponen sisi server harus bersifat sangat dapat dipanggil kembali (reentrant), komponen COM multi-threaded dengan overhead minimal dan throughput tinggi untuk banyak klien. Aplikasi Office justru kebalikan hampir di semua hal. Mereka adalah server Otomasi berbasis STA yang tidak dapat dipanggil kembali, dirancang untuk menyediakan fungsi beragam namun intensif sumber daya untuk satu klien. Mereka menawarkan sedikit skalabilitas sebagai solusi sisi server, dan memiliki batas tetap pada elemen penting, seperti memori, yang tidak dapat diubah melalui konfigurasi. Lebih penting lagi, mereka menggunakan sumber daya global (seperti file memori yang dipetakan, add-in atau template global, dan server Otomasi bersama), yang dapat membatasi jumlah instance yang dapat berjalan secara bersamaan dan menyebabkan kondisi race jika dikonfigurasikan dalam lingkungan banyak klien. Pengembang yang berencana menjalankan lebih dari satu instance dari aplikasi Office secara bersamaan harus mempertimbangkan ***Pooling*** atau ***Serializing Access*** ke aplikasi Office untuk menghindari potensi ***Deadlocks*** atau ***Data Corruption***."*

Komponen Aspose sangat skalabel dan sangat cepat. Aplikasi Office tidak dirancang untuk digunakan secara bersamaan oleh ratusan atau ribuan pengguna. Namun, komponen Aspose dirancang khusus untuk itu. Komponen kami berfungsi tanpa cacat baik pada satu server, mendukung satu aplikasi, maupun pada farm server web yang load-balanced yang mendukung aplikasi skala perusahaan.

## **Harga**
Ketika sebuah aplikasi menggunakan Microsoft Office Automation, salinan Microsoft Office harus dibeli untuk setiap mesin yang menjalankan aplikasi tersebut. Seringkali sebuah aplikasi perlu membuat atau memanipulasi file office tetapi tidak memerlukan pengguna memiliki Microsoft Office. Aspose menawarkan lisensi [Efisien Biaya](https://purchase.aspose.com/) dan royalty free redistribution yang memungkinkan penerapan ke jumlah tak terbatas pengguna tanpa kekhawatiran lisensi.

Ketika membuat aplikasi berbasis web, penting untuk mengetahui bahwa komponen Microsoft Office Automation tidak memiliki harga maupun lisensi untuk solusi sisi server; oleh karena itu, tidak ada solusi lisensi yang baik untuk menyebarkan aplikasi web yang menggunakan komponen Microsoft Office. Aspose menawarkan solusi yang sangat Efisien Biaya untuk aplikasi berbasis server juga.

## **Fitur**
Komponen Aspose menyediakan semua yang dibutuhkan untuk mengelola file Office plus banyak lagi. Mereka dirancang dengan filosofi memungkinkan pengembang mencapai hasil terbaik dengan usaha minimal. Tidak seperti Office Automation, komponen Aspose menyediakan banyak fungsi kuat dan menghemat waktu. Misalnya, [Aspose.Cells](https://products.aspose.com/cells/java/) memberi pengembang kemampuan mengimpor data dari **DataTable** atau **DataView** langsung ke file Excel. [Aspose.Words](https://products.aspose.com/words/java/) menawarkan fitur serupa yang memungkinkan pengembang mengisi dokumen Word (yang merupakan Mail Merge). [Every Component](https://products.aspose.com/total/java/) dalam keluarga Aspose menawarkan set fitur unik dan kuat masing-masing.

Bagi Anda yang membeli komponen Aspose (atau suite komponen seperti [Aspose.Total](https://products.aspose.com/total/java/)) keuntungannya adalah mendapatkan akses ke tim pengembangan kami. Tim pengembangan kami menyadari bahwa jika ada fitur yang dibutuhkan perusahaan Anda, kemungkinan besar perusahaan lain juga membutuhkannya. Meskipun tidak setiap permintaan fitur dapat ditambahkan, tim kami berusaha sangat terbuka dan fleksibel saat memberikan bantuan. Pemikiran inilah yang membantu komponen Aspose menjadi sekuat ini. Jika ada fitur tambahan yang Anda butuhkan dari objek Office Automation, peluang agar mereka ditambahkan sangat, sangat rendah.

## **Kesimpulan**
{{% alert color="info" title="Note" %}}
Meski artikel ini telah membahas banyak poin utama mengapa komponen Aspose merupakan pilihan yang lebih baik daripada Office Automation, masih banyak lagi. Artikel ini hanya membahas poin-poin utama saja. Semua komponen Aspose yang berbeda menawarkan versi evaluasi bebas risiko, tanpa kewajiban [Evaluation Version](https://releases.aspose.com/slides/id/java/). Kami mendorong Anda memanfaatkan Evaluasi tersebut untuk lebih melihat apa yang dapat dilakukan Aspose untuk aplikasi Anda.
{{% /alert %}}