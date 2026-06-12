---
title: Mengapa Tidak Menggunakan Otomasi
type: docs
weight: 50
url: /id/php-java/why-not-automation/
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
- PHP
- Aspose.Slides
description: "Temukan mengapa otomasi Office berisiko bagi server dan layanan, serta lihat bagaimana Aspose.Slides menawarkan pemrosesan presentasi yang lebih aman dan lebih cepat untuk PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Ada beberapa alasan mengapa komponen Aspose menjadi alternatif yang lebih baik dibandingkan otomasi. Beberapa alasan utama meliputi:

- Keamanan
- Stabilitas
- Skalabilitas/Kecepatan
- Harga
- Fitur

Berikut penjelasan lebih rinci tentang masing‑masing poin utama.

## **Pertanyaan Penting**

Ada dua pertanyaan yang sering kami dengar di Aspose:

- Apakah produk Anda memerlukan Microsoft Office terpasang untuk dapat dijalankan?

Jawaban singkat dan sederhana adalah **TIDAK**.

Komponen Aspose sepenuhnya independen dan tidak berafiliasi dengan, diotorisasi oleh, disponsori, atau disetujui oleh Microsoft Corporation.

- Mengapa kami harus menggunakan produk Aspose daripada Microsoft Office Automation?

Pertama, ada banyak [manfaat yang Anda dapatkan ketika menggunakan Aspose.Slides](/slides/id/php-java/product-overview/).

Kedua, Microsoft sendiri sangat **menyarankan untuk tidak** menggunakan Office Automation dalam solusi perangkat lunak.

## **Keamanan**

Berikut kutipan langsung dari Artikel Microsoft: 

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."* 

Produk Aspose sangat aman. Komponen Aspose tidak menimbulkan risiko potensial terhadap sumber daya sistem yang penting. Selain itu, ketika sebuah dokumen dibuka oleh komponen Aspose, makro tidak dijalankan secara otomatis. Komponen Aspose dibangun dengan tujuan memungkinkan pengembang membuat, memanipulasi, dan menyimpan file Office. Tidak ada risiko yang terkait dengan paket Microsoft Office yang melekat pada komponen Aspose. 

## **Stabilitas**
Berikut kutipan langsung dari Artikel Microsoft: 

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."* 

Komponen Aspose telah diuji secara menyeluruh dan sangat stabil. Komponen Aspose digunakan oleh [Perusahaan](https://about.aspose.com/customers) seperti: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, dan masih banyak lagi. 

## **Skalabilitas/Kecepatan**
Berikut kutipan langsung dari Artikel Microsoft: 

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.* 

Komponen Aspose sangat skalabel dan super cepat. Aplikasi Office tidak dirancang untuk digunakan secara bersamaan oleh ratusan atau ribuan pengguna. Namun, komponen Aspose dirancang khusus untuk itu. Komponen kami berfungsi tanpa gangguan baik pada satu server, satu aplikasi, maupun pada Web Form yang dityeimbangkan beban untuk mendukung aplikasi perusahaan secara luas. 

## **Harga**
Saat sebuah aplikasi menggunakan Microsoft Office Automation, salinan Microsoft Office harus dibeli untuk setiap mesin yang menjalankan aplikasi tersebut. Seringkali sebuah aplikasi perlu membuat atau memanipulasi file Office tanpa mengharuskan pengguna memiliki Microsoft Office. Aspose menawarkan lisensi yang sangat [Cost Effective](https://purchase.aspose.com/) dan bebas royalti yang memungkinkan penyebaran ke jumlah pengguna tak terbatas tanpa kekhawatiran lisensi. 

Saat membuat aplikasi berbasis web, penting untuk diketahui bahwa komponen Microsoft Office Automation tidak memiliki harga atau lisensi untuk solusi sisi server; oleh karena itu tidak ada solusi lisensi yang tepat untuk menyebarkan aplikasi web yang menggunakan komponen Microsoft Office. Aspose juga menawarkan solusi yang sangat Cost Effective untuk aplikasi sisi server. 

## **Fitur**
Komponen Aspose menyediakan semua yang diperlukan untuk mengelola file Office serta banyak lagi. Mereka dirancang dengan filosofi memungkinkan pengembang mencapai hasil terbesar dengan upaya paling sedikit. Tidak seperti Office Automation, komponen Aspose menyediakan banyak fungsi yang kuat dan menghemat waktu. Misalnya, [Aspose.Cells](https://products.aspose.com/cells/php-java/) memberikan kemampuan bagi pengembang untuk mengimpor data dari **DataTable** atau **DataView** langsung ke file Excel. [Setiap Komponen](https://products.aspose.com/total/php-java/) dalam keluarga Aspose menawarkan kumpulan fitur unik dan kuat masing‑masing. 

Bagian terbaik dari membeli komponen Aspose (atau suite komponen seperti [Aspose.Total](https://products.aspose.com/total/php-java/)) adalah mendapatkan akses ke tim pengembangan kami. Tim kami menyadari bahwa jika ada fitur yang dibutuhkan perusahaan Anda, kemungkinan besar perusahaan lain juga membutuhkannya. Walaupun tidak setiap permintaan fitur dapat dipenuhi, tim kami berusaha terbuka dan fleksibel dalam memberikan bantuan. Sikap inilah yang menjadikan komponen Aspose begitu kuat. Jika ada fitur tambahan yang Anda perlukan dari objek Office Automation, peluang mereka ditambahkan sangat, sangat rendah. 

## **Kesimpulan**
{{% alert color="primary" %}} 

Meskipun artikel ini telah membahas banyak poin utama mengapa komponen Aspose menjadi pilihan yang lebih baik daripada Office Automation, masih banyak lagi yang belum disebutkan. Artikel ini hanya menyentuh poin‑poin paling penting. Semua komponen Aspose yang berbeda menawarkan [Version Evaluasi](https://downloads.aspose.com/slides/id/java) tanpa risiko dan tanpa kewajiban. Kami mendorong Anda memanfaatkan Evaluasi tersebut untuk melihat secara langsung apa yang dapat dilakukan Aspose untuk aplikasi Anda. 

{{% /alert %}}