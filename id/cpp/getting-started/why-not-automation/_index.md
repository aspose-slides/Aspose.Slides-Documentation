---
title: Mengapa Tidak Otomasi
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
description: "Temukan mengapa otomasi Office berisiko untuk server dan layanan, serta lihat bagaimana Aspose.Slides menawarkan pemrosesan presentasi yang lebih aman dan lebih cepat untuk PowerPoint dan OpenDocument."
---
## **Pendahuluan**

Ada beberapa alasan mengapa komponen Aspose menjadi alternatif yang lebih baik dibandingkan otomatisasi. Beberapa alasan utama meliputi:

- Keamanan
- Stabilitas
- Skalabilitas/Kecepatan
- Harga
- Fitur

Berikut penjelasan lebih detail untuk setiap poin utama.

## **Pertanyaan Penting**
- Mengapa komponen Aspose jauh lebih baik daripada Microsoft Office Automation?

Ada dua pertanyaan yang paling sering kami dengar di Aspose :

- Apakah produk Anda memerlukan Microsoft Office terpasang agar dapat berjalan?

Jawaban singkatnya **TIDAK**. Aspose dan komponen Aspose bersifat independen total dan tidak berafiliasi dengan, maupun diotorisasi, disponsori, atau disetujui oleh Microsoft Corporation.

- Mengapa kami harus menggunakan produk Aspose daripada memanfaatkan Microsoft Office Automation?

Jawaban singkatnya adalah bahwa ada banyak alasan, dengan yang utama adalah *Microsoft sendiri sangat menyarankan untuk tidak menggunakan Office Automation dari solusi perangkat lunak*: [Microsoft Article]({{guid}})

## **Keamanan**
Berikut kutipan langsung dari Microsoft Article yang dirujuk di atas :

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Produk Aspose sangat aman. Oleh karena itu, komponen Aspose tidak menimbulkan risiko potensial terhadap sumber daya sistem yang vital. Selain itu, ketika dokumen dibuka oleh komponen Aspose, makro tidak dijalankan secara otomatis. Komponen Aspose dibangun dengan tujuan memungkinkan pengembang membuat, memanipulasi, dan menyimpan file Office. Tidak ada risiko yang terkait dengan paket Microsoft Office yang melekat pada komponen Aspose.

## **Stabilitas**
Berikut kutipan langsung dari Microsoft Article yang dirujuk di atas :

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Karena komponen Aspose dikemas dalam satu file DLL, tidak pernah diperlukan pemasangan bagian tambahan apa pun agar berfungsi. Komponen Aspose hanya digunakan oleh aplikasi C++ dan tidak ada bagian kode komponen yang menunggu respons manusia. Komponen Aspose telah diuji secara menyeluruh dan sangat stabil. Komponen Aspose digunakan oleh [Perusahaan](https://about.aspose.com/customers) seperti: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, dan masih banyak lagi.

## **Skalabilitas/Kecepatan**
Berikut kutipan langsung dari Microsoft Article yang dirujuk di atas :

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

Komponen Aspose sangat skalabel dan super cepat. Aplikasi Office tidak dirancang untuk digunakan secara bersamaan oleh ratusan atau ribuan pengguna. Namun, komponen Aspose dirancang khusus untuk itu. Komponen kami adalah solusi C++ sejati dan berfungsi tanpa masalah baik pada satu server, satu aplikasi, maupun pada Web Form yang dityeimbangkan beban untuk aplikasi skala perusahaan.

## **Harga**
Ketika sebuah aplikasi menggunakan Microsoft Office Automation, salinan Microsoft Office harus dibeli untuk tiap mesin yang menjalankan aplikasi tersebut. Seringkali sebuah aplikasi perlu membuat atau memanipulasi file Office tetapi tidak memerlukan pengguna memiliki Microsoft Office. Aspose menawarkan lisensi [Cost Effective](https://purchase.aspose.com/) yang bebas royalti dan memungkinkan penyebaran ke jumlah pengguna tak terbatas tanpa kekhawatiran lisensi. Saat membuat aplikasi berbasis web penting untuk diketahui bahwa komponen Microsoft Office Automation tidak memiliki harga atau lisensi untuk solusi sisi server; sehingga tidak ada solusi lisensi yang tepat untuk menyebarkan aplikasi web yang memanfaatkan komponen Microsoft Office. Aspose menawarkan solusi [Cost Effective](https://purchase.aspose.com/) untuk aplikasi berbasis server juga.

## **Fitur**
Komponen Aspose menyediakan semua yang diperlukan untuk mengelola file Office plus banyak lagi. Mereka dirancang dengan filosofi memungkinkan pengembang mencapai hasil maksimal dengan usaha minimal. Tidak seperti Office Automation, komponen Aspose menyediakan banyak fungsi kuat yang menghemat waktu. Misalnya, [Aspose.Cells](https://products.aspose.com/cells/cpp/) memberi pengembang kemampuan mengimpor data dari **DataTable** atau **DataView** langsung ke file Excel. [Aspose.Words](https://products.aspose.com/words/net/) menawarkan fitur serupa yang memungkinkan pengembang mengisi dokumen Word (Mail Merge) langsung dari objek data C++ apa pun. [Setiap Komponen](https://products.aspose.com/total/cpp/) dalam keluarga Aspose menawarkan rangkaian fitur unik dan kuat masing‑masing. Bagian terbaik dari membeli komponen Aspose adalah akses ke tim pengembang kami. Tim kami menyadari bahwa jika ada fitur yang dibutuhkan perusahaan Anda, kemungkinan besar perusahaan lain juga membutuhkannya. Meskipun tidak setiap permintaan fitur dapat ditambahkan, tim kami berusaha sangat terbuka dan fleksibel dalam memberikan bantuan. Pola pikir inilah yang membuat komponen Aspose menjadi begitu kuat. Jika ada fitur tambahan yang Anda butuhkan dari objek Office Automation, peluang untuk menambahkannya sangat, sangat kecil.

## **Kesimpulan**
{{% alert color="primary" %}} 

Meskipun artikel ini telah membahas banyak poin utama mengapa komponen Aspose merupakan pilihan yang lebih baik daripada Office Automation, masih ada banyak lagi. Artikel ini terutama menyoroti poin‑poin paling penting. Semua komponen Aspose menawarkan [Evaluation Version](https://downloads.aspose.com/slides/id/cpp) tanpa risiko dan tanpa kewajiban. Kami mendorong Anda memanfaatkan [Evaluation](https://downloads.aspose.com/slides/id/cpp) tersebut untuk melihat secara langsung apa yang dapat dilakukan Aspose untuk aplikasi Anda.