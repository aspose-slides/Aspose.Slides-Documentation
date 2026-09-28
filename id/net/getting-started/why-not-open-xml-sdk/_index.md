---
title: Mengapa Tidak Open XML SDK
type: docs
weight: 180
url: /id/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- perbandingan
- model objek presentasi
- konversi berkualitas tinggi
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Lihat mengapa Aspose.Slides adalah pilihan yang lebih baik daripada Open XML SDK gratis: bandingkan fitur, konversi tanpa otomatisasi, dan dukungan luas untuk PPT, PPTX dan ODP."
---
## **Overview**

Artikel ini menjelaskan kapan pengembang mungkin memilih Open XML SDK atau Aspose.Slides untuk bekerja dengan dokumen presentasi. Artikel ini menggambarkan Open XML SDK sebagai perpustakaan untuk memanipulasi paket OOXML dan elemen XML yang mendasarinya, sementara Aspose.Slides disajikan sebagai perpustakaan pemrosesan presentasi dengan model objek tingkat tinggi dan dukungan untuk banyak tugas terkait PowerPoint.

Artikel ini membandingkan kedua pilihan berdasarkan format yang didukung, model pemrograman, rendering, dukungan platform, dan kasus penggunaan umum. Artikel ini juga menjelaskan bahwa Open XML SDK mungkin cocok untuk operasi PPTX dasar atau akses langsung ke elemen OOXML, sedangkan Aspose.Slides lebih tepat untuk tugas presentasi yang kompleks seperti bekerja dengan berbagai format PowerPoint, menyalin atau mengkloning bentuk, mengganti teks, menerapkan animasi, dan mengonversi presentasi ke PDF, TIFF, atau XPS.

## **What Is Open XML SDK?**
Kadang‑kadang, kami mendapatkan pertanyaan ini: *Mengapa kami harus menggunakan produk Aspose daripada Open XML SDK yang gratis?*

Kami menemukan bahwa mudah menjawab pertanyaan ini dalam hal fitur dan fungsionalitas.

Menurut [MSDN Library](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK didefinisikan sebagai berikut:

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **What Is Aspose.Slides?**
Aspose.Slides adalah perpustakaan kelas yang memungkinkan aplikasi melakukan tugas pemrosesan presentasi berikut:

- Pemrograman dengan model objek presentasi.
- Konversi berkualitas tinggi yang mencakup semua format presentasi PowerPoint yang populer, termasuk konversi ke PDF, XPS, dan TIFF.
- Menghasilkan thumbnail slide dalam format yang dikenal seperti PNG, JPEG, dan BMP serta mengekspor slide ke SVG.
- Membuat presentasi dari awal atau dengan menggabungkan elemen dari satu atau beberapa dokumen.
- Menambahkan animasi, OLE Frame, tabel, serta membuat dan mengelola diagram.
- Mengontrol (kontrol ekstensif) dan mengelola pemformatan teks pada tingkat TextFrames, Paragraphs, dan Portions.

  Untuk detail lebih lanjut tentang fitur yang tersedia, silakan lihat halaman [Aspose.Slides Features](/slides/id/net/product-overview/).

## **Compare Open XML SDK with Aspose.Slides**
Tabel ini membandingkan kemampuan dan fitur Open XML SDK dengan Aspose.Slides.

|**Fitur atau Kategori Fitur**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Format presentasi yang didukung|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konversi dari PPT ke PPTX |No|Yes|
|<p>Pemrograman tingkat tinggi dengan Presentation Document Object Model (DOM): </p><p>- Temukan dan ganti teks.</p><p>- Susun slide dalam presentasi.</p>|No|Yes|
|Pemrograman terperinci dengan model objek dokumen; akses ke elemen individual dan pemformatan seperti TextHolders, TextFrames, Paragraphs, dan Portions.|Yes|Yes|
|Akses langsung dan penuh tingkat rendah ke elemen XML dan atribut yang mendasari seperti pengidentifikasi hubungan, pengidentifikasi daftar pada dokumen OOXML.|Yes|No|
|<p>Rendering Presentasi:</p><p>- Render presentasi ke PDF, PDF Notes, XPS, gambar TIFF.</p><p>- Render thumbnail slide ke PNG, JPEG, BMP, SVG, dan TIFF.</p><p>- Tentukan resolusi gambar, kualitas, kompresi, dan opsi lainnya.</p>|No|Yes|
|Platform yang didukung|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Conclusion**
Open XML SDK dan Aspose.Slides tidak bersaing secara langsung karena mereka memenuhi kebutuhan yang sangat berbeda, dan mereka menargetkan audiens yang berbeda.

{{% alert color="info" title="Note" %}}
Open XML SDK adalah perpustakaan kelas yang menyediakan cara bertipe kuat untuk bekerja dengan dokumen OOXML sementara Aspose.Slides adalah perpustakaan pemrosesan presentasi yang sangat berguna yang memberikan dukungan hebat untuk hampir semua format file Microsoft PowerPoint.
{{% /alert %}}

Jika alur kerja Anda berupa operasi pemrograman dasar pada dokumen PPTX, maka Open XML SDK mungkin menjadi pilihan yang baik. Dengan Open XML SDK, Anda dapat dengan mudah melakukan tugas sederhana seperti menghasilkan dokumen PPTX sederhana atau menghapus komentar, header/footer, mengekstrak gambar, atau lainnya. Beberapa tugas dapat dilakukan dengan Open XML SDK tetapi tidak dapat dilakukan dengan Aspose.Slides. Misalnya, jika Anda perlu mengakses langsung elemen XML dan atribut dokumen OOXML, maka Anda harus menggunakan Open XML SDK.

Jika Anda perlu melakukan tugas kompleks pada dokumen—seperti tugas pada daftar di bawah ini—maka Aspose.Slides adalah opsi terbaik Anda.

- Operasi yang melibatkan format PowerPoint lama (dan PPTX juga).
- Menyalin atau mengkloning bentuk di dalam slide dengan cara yang menggabungkan objek, gaya, dan elemen pemformatan lainnya secara tepat.
- Mengganti teks yang diformat atau tidak diformat.
- Menerapkan animasi dan menggunakan konektor dengan bentuk.
- Mengonversi dokumen ke PDF, TIFF, atau XPS sehingga tampil seperti Microsoft PowerPoint yang melakukan konversi.
- Mengembangkan aplikasi .NET atau Java baik di lingkungan desktop maupun berbasis web.