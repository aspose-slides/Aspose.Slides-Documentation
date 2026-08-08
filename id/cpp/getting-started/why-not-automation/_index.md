---
title: Mengapa Tidak Menggunakan Otomasi
type: docs
weight: 50
url: /id/cpp/why-not-automation/
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
- C++
- Aspose.Slides
description: "Temukan mengapa otomasi Office berisiko bagi server dan layanan, serta lihat bagaimana Aspose.Slides menawarkan pemrosesan presentasi yang lebih aman dan lebih cepat untuk PowerPoint dan OpenDocument."
---
## **Pendahuluan**

Ada beberapa alasan mengapa komponen Aspose menjadi alternatif yang lebih baik dibandingkan otomasi. Beberapa alasan utama adalah:

- Keamanan
- Stabilitas
- Skalabilitas/Kecepatan
- Harga
- Fitur

Berikut adalah penjelasan lebih rinci tentang masing-masing poin utama.

## **Pertanyaan Penting**
- Mengapa komponen Aspose jauh lebih baik dibandingkan Microsoft Office Automation?

Ada dua pertanyaan yang paling sering kami dengar di Aspose :

- Apakah produk Anda memerlukan Microsoft Office terinstal agar dapat berjalan?

Jawaban singkatnya adalah **TIDAK**. Aspose dan komponen Aspose sepenuhnya independen dan tidak berafiliasi dengan, maupun diotorisasi, disponsori, atau disetujui oleh Microsoft Corporation.

- Mengapa kami harus menggunakan produk Aspose daripada memanfaatkan Microsoft Office Automation?

Jawaban paling singkat yang dapat kami berikan adalah bahwa ada banyak alasan dengan yang teratas adalah bahwa *Microsoft sendiri sangat merekomendasikan untuk tidak menggunakan Office Automation dari solusi perangkat lunak: [Microsoft Article*

## **Keamanan**
Berikut adalah kutipan langsung dari Microsoft Article yang disebutkan di atas:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Produk Aspose sangat aman. Oleh karena itu, komponen Aspose tidak menimbulkan risiko potensial terhadap sumber daya sistem yang penting. Selain itu, ketika sebuah dokumen dibuka oleh komponen Aspose, makro tidak dijalankan secara otomatis. Komponen Aspose dibangun dengan tujuan memungkinkan pengembang membuat, memanipulasi, dan menyimpan file Office. Tidak ada risiko yang terkait dengan paket Microsoft Office yang melekat pada komponen Aspose.

## **Stabilitas**
Berikut adalah kutipan langsung dari Microsoft Article yang disebutkan di atas:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Karena komponen Aspose dikemas dalam satu file DLL tunggal, tidak akan pernah diperlukan pemasangan bagian tambahan agar mereka berfungsi. Komponen Aspose hanya digunakan oleh aplikasi C++ dan tidak ada bagian kode komponen yang dirancang untuk menunggu respons manusia. Komponen Aspose telah diuji secara menyeluruh dan sangat stabil. Komponen Aspose digunakan oleh [Perusahaan](https://about.aspose.com/customers) seperti: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** dan masih banyak lagi.

## **Skalabilitas/Kecepatan**
Berikut adalah kutipan langsung dari Microsoft Article yang disebutkan di atas:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

Komponen Aspose sangat skalabel dan sangat cepat. Aplikasi Office tidak dirancang untuk digunakan secara bersamaan oleh ratusan atau ribuan pengguna. Namun, komponen Aspose dirancang khusus untuk itu. Komponen kami adalah solusi C++ sejati dan berfungsi tanpa cacat baik pada server tunggal, mendukung satu aplikasi, maupun pada Form Web yang diseimbangkan beban untuk mendukung aplikasi seluruh perusahaan.

## **Harga**
Ketika sebuah aplikasi menggunakan Microsoft Office Automation, satu salinan Microsoft Office harus dibeli untuk setiap mesin yang menjalankan aplikasi tersebut. Sering kali sebuah aplikasi perlu membuat atau memanipulasi file office namun tidak mengharuskan pengguna memiliki Microsoft Office. Aspose menawarkan lisensi redistribusi [Biaya Efektif](https://purchase.aspose.com/) yang bebas royalti dan memungkinkan penyebaran ke jumlah pengguna tak terbatas tanpa kekhawatiran lisensi. Saat membuat aplikasi berbasis web penting untuk diketahui bahwa komponen Microsoft Office Automation tidak memiliki harga atau lisensi untuk solusi sisi server; sehingga tidak ada solusi lisensi yang tepat untuk menyebarkan aplikasi web yang menggunakan komponen Microsoft Office. Aspose juga menawarkan solusi [Biaya Efektif](https://purchase.aspose.com/) untuk aplikasi berbasis server.

## **Fitur**
Komponen Aspose menyediakan segala yang dibutuhkan untuk mengelola file Office serta banyak lagi. Mereka dirancang dengan filosofi memungkinkan pengembang mencapai hasil terbaik dengan upaya paling sedikit. Tidak seperti Office Automation, komponen Aspose menyediakan banyak fungsi yang kuat dan menghemat waktu. Misalnya, [Aspose.Cells](https://products.aspose.com/cells/cpp/) memberikan kemampuan bagi pengembang untuk mengimpor data dari **DataTable** atau **DataView** langsung ke file Excel. [Aspose.Words](https://products.aspose.com/words/net/) menawarkan fitur serupa yang memungkinkan pengembang mengisi dokumen Word (Mail Merge) langsung dari objek data C++ apa pun. [Every Component](https://products.aspose.com/total/cpp/) dalam keluarga Aspose menawarkan set fitur unik dan kuat masing‑masing. Bagian terbaik dari membeli komponen Aspose adalah akses ke tim pengembangan kami. Tim kami menyadari bahwa jika ada fitur yang dibutuhkan perusahaan Anda, kemungkinan besar perusahaan lain juga membutuhkannya. Meskipun tidak setiap permintaan fitur dapat ditambahkan, tim kami berusaha bersikap terbuka dan fleksibel dalam memberikan bantuan. Sikap inilah yang membuat komponen Aspose menjadi begitu kuat. Jika ada fitur tambahan yang Anda perlukan dari objek Office Automation, peluang mereka ditambahkan sangat, sangat rendah.

## **Kesimpulan**
{{% alert color="primary" %}} 
Sementara artikel ini telah membahas banyak poin utama mengapa komponen Aspose merupakan pilihan yang lebih baik dibandingkan Office Automation, masih ada banyak lagi. Artikel ini terutama membahas hanya poin‑poin utama. Semua komponen Aspose yang berbeda menawarkan versi evaluasi tanpa risiko dan tanpa kewajiban [Versi Evaluasi](https://downloads.aspose.com/slides/id/cpp). Kami mendorong Anda untuk memanfaatkan [Evaluasi](https://downloads.aspose.com/slides/id/cpp) agar dapat melihat lebih jelas apa yang dapat dilakukan Aspose untuk aplikasi Anda.
{{% /alert %}}