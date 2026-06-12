---
title: Mengapa Tidak Otomasi
type: docs
weight: 50
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
description: "Temukan mengapa otomasi Office berisiko untuk server dan layanan, serta lihat bagaimana Aspose.Slides menawarkan pemrosesan presentasi yang lebih aman dan lebih cepat untuk PowerPoint dan OpenDocument."
---
## **Pendahuluan**

Ada beberapa alasan mengapa komponen Aspose menjadi alternatif yang lebih baik dibandingkan otomasi. Beberapa alasan utama adalah:

- Keamanan
- Stabilitas
- Skalabilitas/Kecepatan
- Harga
- Fitur

Berikut adalah penjelasan lebih rinci tentang setiap poin penting.

## **Pertanyaan Penting**

Ada dua pertanyaan yang sering kami dengar di Aspose:

- Apakah produk Anda memerlukan Microsoft Office terpasang untuk dapat dijalankan?

Jawaban singkat dan sederhana adalah **TIDAK**.

Komponen Aspose sepenuhnya independen dan tidak berafiliasi dengan, diotorisasi oleh, disponsori oleh, atau disetujui oleh Microsoft Corporation.

- Mengapa kami harus menggunakan produk Aspose alih-alih Microsoft Office Automation?

Pertama, ada banyak [manfaat yang Anda dapatkan ketika menggunakan Aspose.Slides](/slides/id/java/product-overview/).

Kedua, Microsoft sendiri sangat **menyarankan untuk tidak** menggunakan Office Automation dari solusi perangkat lunak.

## **Keamanan**

Berikut ini kutipan langsung dari Artikel Microsoft:

*"Aplikasi Office tidak pernah dimaksudkan untuk digunakan di sisi server, sehingga tidak mempertimbangkan masalah keamanan yang dihadapi oleh komponen terdistribusi. Office tidak mengautentikasi permintaan masuk, dan tidak melindungi Anda dari menjalankan makro secara tidak sengaja, atau memulai server lain yang mungkin menjalankan makro, dari kode sisi server Anda. Jangan membuka file yang diunggah ke server dari Web anonim! Berdasarkan pengaturan keamanan yang terakhir disetel, server dapat menjalankan makro dengan konteks Administrator atau Sistem dengan hak penuh dan mengompromikan jaringan Anda! Selain itu, Office menggunakan banyak komponen sisi klien (seperti Simple MAPI, WinInet, MSDAIPP) yang dapat menyimpan cache informasi autentikasi klien untuk mempercepat pemrosesan. Jika Office diotomatiskan di sisi server, satu instance dapat melayani lebih dari satu klien, dan karena informasi autentikasi telah dicache untuk sesi tersebut, memungkinkan satu klien menggunakan kredensial yang dicache dari klien lain, dan dengan demikian memperoleh izin akses yang tidak diberikan dengan menyamar sebagai pengguna lain."*

Produk Aspose sangat aman. Komponen Aspose tidak menimbulkan risiko potensial terhadap sumber daya sistem yang penting. Selain itu, ketika dokumen dibuka oleh komponen Aspose, makro tidak dijalankan secara otomatis. Komponen Aspose dibuat dengan tujuan memungkinkan pengembang untuk membuat, memanipulasi, dan menyimpan file Office. Tidak ada risiko yang terkait dengan paket Microsoft Office yang melekat pada komponen Aspose.

## **Stabilitas**

Berikut ini kutipan langsung dari Artikel Microsoft:

*"Office 2000, Office XP, dan Office 2003 menggunakan teknologi Microsoft Windows Installer (MSI) untuk mempermudah instalasi dan perbaikan otomatis bagi pengguna akhir. MSI memperkenalkan konsep "install on first use", yang memungkinkan fitur dipasang atau dikonfigurasi secara dinamis saat runtime (untuk sistem, atau lebih sering untuk pengguna tertentu). Di lingkungan sisi server, hal ini memperlambat kinerja dan meningkatkan kemungkinan munculnya kotak dialog yang meminta pengguna menyetujui instalasi atau menyediakan disk instalasi yang sesuai. Meskipun dirancang untuk meningkatkan ketahanan Office sebagai produk pengguna akhir, implementasi kemampuan MSI oleh Office bersifat kontraproduktif di lingkungan sisi server. Selain itu, stabilitas Office secara umum tidak dapat dijamin ketika dijalankan di sisi server karena tidak dirancang atau diuji untuk jenis penggunaan ini. Menggunakan Office sebagai komponen layanan pada server jaringan dapat mengurangi stabilitas mesin tersebut dan akibatnya jaringan Anda secara keseluruhan. Jika Anda berencana mengotomatisasi Office di sisi server, cobalah mengisolasi program ke komputer khusus yang tidak dapat memengaruhi fungsi kritis, dan yang dapat direstart sesuai kebutuhan."*

Komponen Aspose telah diuji secara menyeluruh dan sangat stabil. Komponen Aspose digunakan oleh [Perusahaan](https://about.aspose.com/customers) seperti: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, dan masih banyak lagi.

## **Skalabilitas/Kecepatan**

Berikut ini kutipan langsung dari Artikel Microsoft:

*"Komponen sisi server harus sangat reentran, komponen COM multi‑threaded dengan overhead minimal dan throughput tinggi untuk banyak klien. Aplikasi Office hampir di semua aspek merupakan kebalikan yang tepat. Mereka adalah server Otomasi berbasis STA yang tidak reentran yang dirancang untuk menyediakan fungsionalitas beragam namun intensif sumber daya untuk satu klien. Mereka menawarkan sedikit skalabilitas sebagai solusi sisi server, dan memiliki batas tetap pada elemen penting, seperti memori, yang tidak dapat diubah melalui konfigurasi. Lebih penting lagi, mereka menggunakan sumber daya global (seperti file memori yang dipetakan, add‑in atau template global, dan server Otomasi bersama), yang dapat membatasi jumlah instance yang dapat berjalan secara bersamaan dan menyebabkan kondisi balapan jika dikonfigurasi dalam lingkungan multi‑klien. Pengembang yang berencana menjalankan lebih dari satu instance dari aplikasi Office sekaligus perlu mempertimbangkan* ***Pooling*** *atau* ***Serializing Access*** *ke Aplikasi Office untuk menghindari potensi* ***Deadlocks*** *atau* ***Data Corruption*** *.*"

Komponen Aspose sangat skalabel dan sangat cepat. Aplikasi Office tidak dirancang untuk digunakan secara bersamaan oleh ratusan hingga ribuan pengguna. Namun, komponen Aspose dirancang khusus untuk itu. Komponen kami berfungsi tanpa masalah baik pada satu server, mendukung satu aplikasi, maupun pada Web Form yang seimbang beban yang mendukung aplikasi enterprise secara menyeluruh.

## **Harga**

Ketika sebuah aplikasi menggunakan Microsoft Office Automation, salinan Microsoft Office harus dibeli untuk setiap mesin yang menjalankan aplikasi tersebut. Banyak kasus di mana aplikasi perlu membuat atau memanipulasi file Office tetapi tidak memerlukan pengguna memiliki Microsoft Office. Aspose menawarkan lisensi redistribusi yang sangat [Efisien Biaya](https://purchase.aspose.com/) dan bebas royalti yang memungkinkan penyebaran ke jumlah pengguna tak terbatas tanpa kekhawatiran lisensi.

Ketika membuat aplikasi berbasis web, penting untuk diketahui bahwa komponen Microsoft Office Automation tidak memiliki harga maupun lisensi untuk solusi sisi server; oleh karena itu, tidak ada solusi lisensi yang cocok untuk menyebarkan aplikasi web yang menggunakan komponen Microsoft Office. Aspose juga menawarkan solusi yang sangat Efisien Biaya untuk aplikasi berbasis server.

## **Fitur**

Komponen Aspose menyediakan semua yang dibutuhkan untuk mengelola file Office serta banyak lagi. Mereka dirancang dengan filosofi memungkinkan pengembang mencapai hasil maksimal dengan upaya minimal. Tidak seperti Office Automation, komponen Aspose menyediakan banyak fungsi yang kuat dan menghemat waktu. Misalnya, [Aspose.Cells](https://products.aspose.com/cells/java/) memberikan kemampuan kepada pengembang untuk mengimpor data dari **DataTable** atau **DataView** langsung ke dalam file Excel. [Aspose.Words](https://products.aspose.com/words/java/) menawarkan fitur serupa yang memungkinkan pengembang mengisi dokumen Word (yaitu Mail Merge). [Setiap Komponen](https://products.aspose.com/total/java/) dalam keluarga Aspose menawarkan kumpulan fitur unik dan kuat masing‑masing.

Bagian terbaik dari membeli komponen Aspose (atau paket komponen seperti [Aspose.Total](https://products.aspose.com/total/java/)) adalah mendapatkan akses ke tim pengembangan kami. Tim pengembangan kami menyadari bahwa jika ada fitur yang dibutuhkan perusahaan Anda, kemungkinan besar perusahaan lain juga membutuhkannya. Meskipun tidak setiap permintaan fitur dapat ditambahkan, tim kami berusaha sangat terbuka dan fleksibel dalam memberikan bantuan. Pola pikir itu yang membantu komponen Aspose menjadi sekuat sekarang. Jika ada fitur tambahan yang Anda butuhkan dari objek Office Automation, peluang Anda untuk menambahkannya sangat, sangat rendah.

## **Kesimpulan**
{{% alert color="primary" %}} 

Meski artikel ini telah mencakup banyak poin utama mengapa komponen Aspose menjadi pilihan yang lebih baik dibandingkan Office Automation, masih ada banyak lagi. Artikel ini terutama membahas hanya poin-poin utama. Semua komponen Aspose yang berbeda menawarkan versi evaluasi tanpa risiko dan tanpa kewajiban [Evaluation Version](https://downloads.aspose.com/slides/id/java). Kami mendorong Anda untuk memanfaatkan Evaluasi tersebut agar dapat melihat lebih baik apa yang dapat dilakukan Aspose untuk aplikasi Anda. 

{{% /alert %}}