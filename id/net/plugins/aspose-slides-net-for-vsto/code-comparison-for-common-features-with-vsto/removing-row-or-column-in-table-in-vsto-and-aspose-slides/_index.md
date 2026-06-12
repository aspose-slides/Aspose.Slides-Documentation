---
title: Menghapus baris atau kolom dalam Tabel di VSTO dan Aspose.Slides
type: docs
weight: 130
url: /id/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
Berikut adalah kode untuk menghapus baris atau kolom dari tabel menggunakan VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Dapatkan slide pertama

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          shp.Table.Rows[1].Delete();

      }

   }

``` 
## **Aspose.Slides**
Aspose.Slides untuk .NET telah menyediakan API paling sederhana untuk membuat tabel dengan cara termudah. Untuk membuat tabel dalam slide dan melakukan beberapa operasi dasar pada tabel, ikuti langkah-langkah di bawah ini:

- Buat sebuah instance dari kelas Presentation
- Dapatkan referensi slide dengan menggunakan Indeksnya
- Tentukan Array Kolom dengan Lebar
- Tentukan Array Baris dengan Tinggi
- Tambahkan Tabel ke slide menggunakan metode AddTable yang tersedia pada objek IShapes
- Hapus baris tabel
- Hapus kolom tabel
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Dapatkan Slide Pertama

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Unduh Kode yang Berjalan**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Unduh Contoh Kode**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)