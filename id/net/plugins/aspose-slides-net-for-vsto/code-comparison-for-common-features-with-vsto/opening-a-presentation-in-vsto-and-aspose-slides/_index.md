---
title: Membuka Presentasi di VSTO dan Aspose.Slides
type: docs
weight: 120
url: /id/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
Berikut adalah cuplikan kode untuk membuka presentasi:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides untuk .NET menyediakan kelas **Presentation** yang digunakan untuk membuka presentasi yang sudah ada. Ia menawarkan beberapa konstruktor yang overload dan kita dapat menggunakan salah satu konstruktor yang cocok dari kelas **Presentation** untuk membuat objeknya berdasarkan presentasi yang ada. Dalam contoh di bawah, kami telah memberikan nama file presentasi (yang akan dibuka) ke konstruktor kelas Presentation. Setelah file dibuka, kami mendapatkan total jumlah slide yang ada dalam presentasi untuk ditampilkan di layar.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Unduh Kode yang Berjalan**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)