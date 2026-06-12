---
title: Menambahkan Bentuk ke Presentasi
type: docs
weight: 30
url: /id/net/adding-shapes-to-presentation/
---
## **VSTO**
Berikut adalah potongan kode untuk menambahkan bentuk garis:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Untuk menambahkan garis sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah berikut:

- Buat instance kelas Presentation
- Dapatkan referensi slide dengan menggunakan Indeksnya
- Tambahkan AutoShape tipe Garis menggunakan metode AddAutoShape yang tersedia pada objek Shapes
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX

Pada contoh di bawah ini, kami telah menambahkan garis ke slide pertama presentasi.

``` csharp

   //Instansiasi kelas Presentation yang mewakili PPTX

  Presentation pres = new Presentation();

  //Ambil slide pertama

  ISlide slide = pres.Slides[0];

  //Tambahkan autoshape tipe garis

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)