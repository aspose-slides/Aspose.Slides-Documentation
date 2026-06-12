---
title: Menambahkan Gambar dalam Sel Tabel
type: docs
weight: 10
url: /id/net/add-image-in-table-cell/
---
## **VSTO**
Berikut adalah kode untuk menambahkan gambar dalam sel Tabel:

``` csharp

    //Buka kelas Prsentation yang berisi tabel

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Dapatkan slide pertama

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          Cell cell= shp.Table.Rows[1].Cells[1];

          cell.Shape.Fill.UserPicture(ImageFile);

      }

   }

``` 
## **Aspose.Slides**
Aspose.Slides untuk .NET telah menyediakan API paling sederhana untuk membuat tabel dengan cara yang paling mudah. Untuk menambahkan gambar dalam sel tabel saat membuat tabel baru, ikuti langkah-langkah berikut:

- Buat instance dari kelas Presentation
- Dapatkan referensi slide dengan menggunakan Indeksnya
- Tentukan Array Kolom dengan Lebar
- Tentukan Array Baris dengan Tinggi
- Tambahkan Tabel ke slide menggunakan metode AddTable yang disediakan oleh objek IShapes
- Buat objek Bitmap untuk menampung file gambar
- Tambahkan gambar Bitmap ke Objek IPPImage
- Atur Format Isi Sel Tabel sebagai Gambar
- Tambahkan gambar ke sel pertama tabel
- Simpan presentasi yang telah dimodifikasi sebagai file PPTX

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Dapatkan Slide Pertama

  ISlide sld = MyPresentation.Slides[0];

  //Membuat objek Bitmap Image untuk menampung file gambar

  using IImage image = Images.FromFile(ImageFile);

  //Buat objek IPPImage menggunakan objek bitmap

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Tambahkan gambar ke sel tabel pertama

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Simpan PPTX ke Disk

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Unduh Kode yang Berjalan**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Unduh Contoh Kode**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)