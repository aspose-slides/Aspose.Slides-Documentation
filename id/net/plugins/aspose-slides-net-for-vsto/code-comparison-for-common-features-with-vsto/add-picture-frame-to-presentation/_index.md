---
title: Menambahkan Frame Gambar ke Presentasi
type: docs
weight: 50
url: /id/net/add-picture-frame-to-presentation/
---
## **VSTO**
Berikut adalah kode untuk menambahkan gambar dalam presentasi VSTO:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Untuk menambahkan frame gambar sederhana ke slide Anda, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas Presentation.
1. Dapatkan referensi slide dengan menggunakan indeksnya.
1. Buat objek Image dengan menambahkan gambar ke koleksi Images yang terkait dengan objek Presentation yang akan digunakan untuk mengisi Shape.
1. Hitung lebar dan tinggi gambar.
1. Buat PictureFrame sesuai lebar dan tinggi gambar dengan menggunakan metode AddPictureFrame yang disediakan oleh objek Shapes yang terkait dengan slide yang direferensikan.
1. Tambahkan frame gambar (yang berisi gambar) ke slide.
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Langkah-langkah di atas diimplementasikan dalam contoh yang diberikan di bawah ini.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instansiasi kelas Presentation yang mewakili PPTX

  Presentation pres = new Presentation();

  //Dapatkan slide pertama

  ISlide sld = pres.Slides[0];

  //Instansiasi kelas ImageEx

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Tambahkan Frame Gambar dengan tinggi dan lebar yang setara dengan Gambar

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)