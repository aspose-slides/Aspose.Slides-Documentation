---
title: Mengapa Tidak Menggunakan Otomatisasi
type: docs
weight: 40
url: /id/net/why-not-automation/
keywords:
- otomatisasi
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
description: "Temukan mengapa otomatisasi Office berisiko bagi server dan layanan, serta lihat bagaimana Aspose.Slides menawarkan pemrosesan presentasi yang lebih aman dan lebih cepat untuk PowerPoint dan OpenDocument."
---
## **Pendahuluan**

Ada beberapa alasan mengapa komponen Aspose menjadi alternatif yang lebih baik dibandingkan otomatisasi. Beberapa alasan utama adalah:

- Keamanan
- Stabilitas
- Skalabilitas/Kecepatan
- Harga
- Fitur

Berikut adalah penjelasan lebih rinci mengenai setiap poin utama.

## **Pertanyaan Penting**

Ada dua pertanyaan yang sering kami dengar di Aspose:

- Apakah produk Anda memerlukan Microsoft Office terinstal untuk dapat dijalankan?

Jawaban singkat dan sederhana adalah **TIDAK**.

Komponen Aspose sepenuhnya independen dan tidak berafiliasi, tidak diotorisasi, tidak disponsori, atau disetujui dalam bentuk apapun oleh Microsoft Corporation.

- Mengapa kami harus menggunakan produk Aspose alih-alih Microsoft Office Automation?

Pertama, ada banyak [manfaat yang Anda dapatkan ketika menggunakan Aspose.Slides](/slides/id/net/product-overview/).

Kedua, Microsoft sendiri sangat **menyarankan untuk tidak** menggunakan Office Automation dalam solusi perangkat lunak.

## **Keamanan**
Berikut adalah kutipan langsung dari Artikel Microsoft: 

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Produk Aspose sangat **aman**. Komponen Aspose berjalan dalam konteks pengguna yang sama dengan semua aplikasi ASP.NET (di bawah pengguna ASPNET). Oleh karena itu, komponen Aspose **tidak** menimbulkan risiko keamanan. Mereka juga tidak mengonsumsi sumber daya sistem yang kritis. Selain itu, ketika sebuah komponen Aspose membuka dokumen, makro tidak dijalankan secara otomatis. Komponen Aspose dibangun untuk memungkinkan pengembang membuat, memanipulasi, dan menyimpan file Office.

{{% alert color="info" %}} 
Tidak ada risiko yang terkait dengan paket Microsoft Office yang berlaku untuk komponen Aspose.
{{% /alert %}} 

## **Stabilitas**
Teks ini adalah kutipan langsung dari Artikel Microsoft yang disebutkan sebelumnya: 

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Karena komponen Aspose dikemas dalam satu file DLL tunggal, penggunanya tidak pernah perlu menginstal bagian tambahan agar berfungsi. Komponen Aspose hanya digunakan oleh aplikasi .NET dan tidak ada bagian kode komponen yang dirancang untuk menunggu respons manusia.

{{% alert color="info" %}} 
Komponen Aspose telah diuji secara menyeluruh dan dikonfirmasi sangat stabil. Komponen Aspose digunakan oleh [perusahaan](http://www.aspose.com/Corporate/Aspose/Customerlist.html) seperti **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, dan banyak organisasi terkemuka lainnya di berbagai industri dan bidang. 
{{% /alert %}} 

## **Skalabilitas/Kecepatan**
Berikut adalah kutipan langsung dari Artikel Microsoft: 

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Komponen Aspose sangat skalabel dan sangat cepat. Aplikasi Office tidak dirancang untuk digunakan secara bersamaan oleh ratusan atau ribuan pengguna, tetapi komponen Aspose dirancang khusus untuk itu. Komponen kami adalah solusi .NET sejati. 

{{% alert color="info" %}} 
Kinerja komponen Aspose sempurna pada satu server (menjalankan satu aplikasi) atau pada form web yang dibalik beban (menjalankan aplikasi berskala perusahaan). 
{{% /alert %}} 

## **Harga**
Ketika sebuah aplikasi menggunakan Microsoft Office Automation, salinan Microsoft Office harus dibeli untuk setiap mesin yang menjalankan aplikasi tersebut. Ada banyak contoh di mana sebuah aplikasi mungkin perlu membuat atau memanipulasi file office, tetapi proses tersebut tidak memerlukan Microsoft Office. 

{{% alert color="info" %}} 
Aspose menyediakan lisensi redistribusi yang sangat [efisien biaya](https://purchase.aspose.com/) dan bebas royalti yang memungkinkan penyebaran ke jumlah pengguna tak terbatas tanpa kekhawatiran lisensi. 
{{% /alert %}} 

Saat membuat aplikasi berbasis web, penting untuk diingat bahwa komponen Microsoft Office Automation tidak memiliki harga maupun lisensi untuk solusi sisi server. Oleh karena itu, tidak ada solusi lisensi yang baik untuk penyebaran aplikasi web yang menggunakan komponen Microsoft Office. Aspose, di sisi lain, menyediakan solusi yang sangat [efisien biaya](https://purchase.aspose.com/) untuk aplikasi berbasis server juga.

## **Fitur**
Komponen Aspose menyediakan segala yang dibutuhkan untuk mengelola file Office dan lebih banyak lagi. Kami merancangnya berdasarkan filosofi membantu pengembang mencapai hasil terbesar dengan usaha paling sedikit. 

{{% alert color="info" %}} 
Berbeda dengan Office Automation, komponen Aspose menyediakan banyak fungsi yang kuat dan menghemat waktu. 
{{% /alert %}} 

Sebagai contoh, [Aspose.Cells](https://products.aspose.com/cells/net/) memberi pengembang kemampuan mengimpor data dari **DataTable** atau **DataView** langsung ke file Excel. [Aspose.Words](https://products.aspose.com/words/net/) menyediakan fitur serupa yang memungkinkan pengembang mengisi dokumen Word (misalnya Mail Merge) langsung dari objek data .NET apa pun. [Setiap komponen](https://products.aspose.com/total/net/) dalam keluarga Aspose menawarkan set fitur unik dan kuat masing‑masing. 

Bagian terbaik membeli komponen Aspose adalah mendapatkan akses ke tim pengembangan kami. Misalnya, jika Anda menggunakan objek Office Automation dan membutuhkan fitur tertentu, peluang Anda mendapatkan fitur tersebut ditambahkan sangat, sangat rendah. Namun, halnya berbeda dengan komponen Aspose. 

{{% alert color="info" %}} 
Tim pengembangan kami memahami bahwa jika ada fitur yang dibutuhkan perusahaan Anda, ada kemungkinan besar perusahaan lain juga membutuhkannya. Meskipun kami tahu tidak dapat mengimplementasikan setiap fitur yang diminta, kami berusaha menambahkan sebanyak mungkin fitur berdasarkan umpan balik pelanggan. 
{{% /alert %}} 

Tim kami selalu berpikiran terbuka dan fleksibel dalam memberikan bantuan—dan inilah alasan komponen Aspose tumbuh menjadi sekuat sekarang. 

## **Kesimpulan**
{{% alert color="info" %}} 
Meskipun artikel ini mencakup beberapa poin utama mengapa komponen Aspose menjadi pilihan yang lebih baik dibandingkan Office Automation, Anda harus memahami bahwa masih ada banyak manfaat lain. Kami hanya menyebutkan beberapa keunggulan utama. 

Selain itu, semua produk dan komponen Aspose menawarkan Versi Evaluasi tanpa risiko dan tanpa kewajiban [Evaluation Version](https://downloads.aspose.com/slides/id/net). Kami mendorong Anda memanfaatkan evaluasi tersebut untuk melihat apa yang dapat Aspose lakukan untuk aplikasi atau bisnis Anda. 
{{% /alert %}}