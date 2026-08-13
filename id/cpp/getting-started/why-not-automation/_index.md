---
title: Mengapa Tidak Otomasi
type: docs
weight: 50
url: /id/cpp/why-not-automation/
keywords:
- otomasi
- Microsoft Office
- membandingkan
- keamanan
- stabilitas
- skalabilitas
- fitur
- PowerPoint
- OpenDocument
- presentasi
- C++
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

Berikut ini penjelasan lebih rinci tentang setiap poin utama.

## **Pertanyaan Penting**
- Mengapa komponen Aspose jauh lebih baik daripada Microsoft Office Automation?

Ada dua pertanyaan yang paling sering kami dengar di Aspose :

- Apakah produk Anda memerlukan instalasi Microsoft Office agar dapat berjalan?

Jawaban singkatnya adalah **NO**. Aspose dan komponen Aspose sepenuhnya independen dan tidak berafiliasi dengan, maupun diotorisasi, disponsori, atau disetujui oleh Microsoft Corporation.

- Mengapa kami harus menggunakan produk Aspose alih-alih menggunakan Microsoft Office Automation?

Jawaban singkat yang dapat kami berikan adalah bahwa ada banyak alasan dengan yang teratas adalah bahwa *Microsoft sendiri sangat menyarankan untuk tidak menggunakan Office Automation dalam solusi perangkat lunak: [Microsoft Article

## **Keamanan**
Berikut ini kutipan langsung dari Microsoft Article yang disebutkan di atas:  
*"Office Applications tidak pernah dimaksudkan untuk digunakan di sisi server, sehingga tidak mempertimbangkan masalah keamanan yang dihadapi oleh komponen terdistribusi. Office tidak mengautentikasi permintaan yang masuk, dan tidak melindungi Anda dari menjalankan makro secara tidak sengaja, atau memulai server lain yang mungkin menjalankan makro, dari kode sisi server Anda. Jangan membuka file yang diunggah ke server dari Web anonim! Berdasarkan pengaturan keamanan yang terakhir diset, server dapat menjalankan makro dengan konteks Administrator atau System dengan hak penuh dan dapat mengkompromikan jaringan Anda! Selain itu, Office menggunakan banyak komponen sisi klien (seperti Simple MAPI, WinInet, MSDAIPP) yang dapat menyimpan informasi autentikasi klien untuk mempercepat pemrosesan. Jika Office diotomatisasi di sisi server, satu instance dapat melayani lebih dari satu klien, dan karena informasi autentikasi telah disimpan untuk sesi tersebut, memungkinkan satu klien menggunakan kredensial yang disimpan dari klien lain, dan dengan demikian memperoleh izin akses yang tidak diberikan dengan menyamar sebagai pengguna lain."*

Produk Aspose sangat aman. Oleh karena itu, komponen Aspose tidak menimbulkan risiko potensial terhadap sumber daya sistem yang penting. Selain itu, ketika dokumen dibuka oleh komponen Aspose, makro tidak dijalankan secara otomatis. Komponen Aspose dibangun dengan tujuan memungkinkan pengembang membuat, memanipulasi, dan menyimpan file Office. Tidak ada risiko yang terkait dengan paket Microsoft Office yang melekat pada komponen Aspose.

## **Stabilitas**
Berikut ini kutipan langsung dari Microsoft Article yang disebutkan di atas:  
*"Office 2000, Office XP, dan Office 2003 menggunakan teknologi Microsoft Windows Installer (MSI) untuk mempermudah instalasi dan perbaikan mandiri bagi pengguna akhir. MSI memperkenalkan konsep "install on first use", yang memungkinkan fitur diinstal atau dikonfigurasi secara dinamis pada waktu berjalan (untuk sistem, atau lebih sering untuk pengguna tertentu). Di lingkungan sisi server, hal ini memperlambat kinerja dan meningkatkan kemungkinan munculnya kotak dialog yang meminta pengguna menyetujui instalasi atau menyediakan disk instalasi yang sesuai. Meskipun dirancang untuk meningkatkan ketahanan Office sebagai produk pengguna akhir, implementasi kemampuan MSI oleh Office justru kontraproduktif di lingkungan sisi server. Selain itu, stabilitas Office secara umum tidak dapat dijamin saat dijalankan di sisi server karena tidak dirancang atau diuji untuk jenis penggunaan ini. Menggunakan Office sebagai komponen layanan pada server jaringan dapat mengurangi stabilitas mesin tersebut dan akibatnya jaringan Anda secara keseluruhan. Jika Anda berencana mengotomatisasi Office di sisi server, usahakan mengisolasi program ke komputer khusus yang tidak dapat memengaruhi fungsi kritis, dan yang dapat di-restart sesuai kebutuhan."*

Karena komponen Aspose dikemas dalam satu file DLL, tidak akan pernah diperlukan instalasi bagian tambahan apa pun agar mereka berfungsi. Komponen Aspose hanya digunakan oleh aplikasi C++ dan tidak ada bagian kode komponen yang dirancang untuk menunggu respons manusia. Komponen Aspose telah diuji secara menyeluruh dan sangat stabil. Komponen Aspose digunakan oleh [Companies](https://about.aspose.com/customers) seperti: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** dan masih banyak lagi.

## **Skalabilitas/Kecepatan**
Berikut ini kutipan langsung dari Microsoft Article yang disebutkan di atas:  
*"Komponen sisi server perlu sangat reentran, komponen COM multi-threaded dengan overhead minimal dan throughput tinggi untuk banyak klien. Aplikasi Office dalam hampir semua hal justru kebalikan. Mereka adalah server Otomasi berbasis STA yang tidak reentran, dirancang untuk menyediakan fungsionalitas beragam namun memakan sumber daya untuk satu klien. Mereka menawarkan skalabilitas yang rendah sebagai solusi sisi server, dan memiliki batas tetap pada elemen penting, seperti memori, yang tidak dapat diubah melalui konfigurasi. Lebih penting lagi, mereka menggunakan sumber daya global (seperti file memori terpetakan, add-in atau templat global, dan server Otomasi bersama), yang dapat membatasi jumlah instance yang dapat berjalan bersamaan dan menyebabkan kondisi balapan jika dikonfigurasi dalam lingkungan multi-klien. Pengembang yang berencana menjalankan lebih dari satu instance dari aplikasi Office secara bersamaan perlu mempertimbangkan Pooling atau Serializing Access ke aplikasi Office untuk menghindari potensi Deadlock atau Korupsi Data.”*

Komponen Aspose sangat skalabel dan sangat cepat. Aplikasi Office tidak dirancang untuk digunakan secara bersamaan oleh ratusan atau ribuan pengguna. Namun, komponen Aspose dirancang khusus untuk itu. Komponen kami adalah solusi C++ sejati dan berfungsi tanpa cacat baik pada satu server, menggerakkan satu aplikasi, maupun pada Web Form yang dityeimbangkan beban untuk aplikasi skala perusahaan.

## **Harga**
Ketika sebuah aplikasi menggunakan Microsoft Office Automation, salinan Microsoft Office harus dibeli untuk setiap mesin yang menjalankan aplikasi tersebut. Seringkali sebuah aplikasi perlu membuat atau memanipulasi file Office namun tidak memerlukan pengguna memiliki Microsoft Office. Aspose menawarkan lisensi redistribusi yang sangat [Cost Effective](https://purchase.aspose.com/) dan bebas royalti yang memungkinkan penyebaran ke jumlah pengguna tak terbatas tanpa kekhawatiran lisensi. Saat membuat aplikasi berbasis web, penting untuk diketahui bahwa komponen Microsoft Office Automation tidak memiliki harga maupun lisensi untuk solusi sisi server; sehingga tidak ada solusi lisensi yang baik untuk menyebarkan aplikasi web yang menggunakan komponen Microsoft Office. Aspose juga menawarkan solusi yang sangat [Cost Effective](https://purchase.aspose.com/) untuk aplikasi berbasis server.

## **Fitur**
Aspose components menyediakan semua yang dibutuhkan untuk mengelola file Office plus banyak lagi. Mereka dirancang dengan filosofi memungkinkan pengembang mencapai hasil maksimal dengan kerja minimal. Tidak seperti Office Automation, komponen Aspose menyediakan banyak fungsi yang kuat dan menghemat waktu. Misalnya, [Aspose.Cells](https://products.aspose.com/cells/cpp/) memberikan kemampuan kepada pengembang untuk mengimpor data dari **DataTable** atau **DataView** langsung ke file Excel. [Aspose.Words](https://products.aspose.com/words/net/) menawarkan fitur serupa yang memungkinkan pengembang mengisi dokumen Word (yaitu Mail Merge) langsung dari objek data C++ apa pun. [Every Component](https://products.aspose.com/total/cpp/) dalam keluarga Aspose menawarkan serangkaian fitur unik dan kuat masing‑masing. Bagian terbaik membeli komponen Aspose adalah mendapatkan akses ke tim pengembangan kami. Tim pengembangan kami menyadari bahwa jika ada fitur yang dibutuhkan perusahaan Anda, kemungkinan besar perusahaan lain juga membutuhkannya. Meskipun tidak setiap permintaan fitur dapat ditambahkan, tim kami berusaha sangat terbuka dan fleksibel dalam memberikan bantuan. Sikap inilah yang membantu komponen Aspose menjadi sekuat itu. Jika ada fitur tambahan yang Anda perlukan dari objek Office Automation, peluang Anda untuk menambahkannya sangat, sangat kecil.

## **Kesimpulan**
{{% alert color="info" %}} 

Walaupun artikel ini telah mencakup banyak poin utama mengapa komponen Aspose merupakan pilihan yang lebih baik daripada Office Automation, masih ada banyak lagi. Artikel ini terutama membahas hanya poin-poin utama. Semua komponen Aspose yang berbeda menawarkan versi evaluasi tanpa risiko dan tanpa kewajiban [Evaluation Version](https://downloads.aspose.com/slides/id/cpp). Kami mendorong Anda memanfaatkan [Evaluation](https://downloads.aspose.com/slides/id/cpp) tersebut untuk lebih melihat apa yang dapat dilakukan Aspose untuk aplikasi Anda.
{{% /alert %}}