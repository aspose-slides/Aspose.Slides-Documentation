---
title: Konversi Presentasi ke Tiff dengan Catatan
type: docs
weight: 50
url: /id/net/convert-presentation-to-tiff-with-notes/
---
TIFF merupakan salah satu dari beberapa format gambar yang banyak digunakan yang didukung oleh Aspose.Slides untuk .NET untuk mengonversi presentasi dengan catatan menjadi gambar. Anda juga dapat menghasilkan thumbnail slide dalam tampilan Slide Catatan. Di bawah ini ada dua cuplikan kode yang menunjukkan cara menghasilkan gambar TIFF dari presentasi dalam tampilan Slide Catatan.

Metode [Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/methods/save) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dapat digunakan untuk mengonversi seluruh presentasi dalam tampilan Slide Catatan menjadi TIFF. Anda juga dapat menghasilkan thumbnail slide dalam tampilan Slide Catatan untuk slide individual.
## **Contoh**

``` 

  //Instansiasi objek Presentation yang mewakili file presentasi

 Presentation pres = new Presentation("Conversion.pptx");

 //Menyimpan presentasi ke TIFF dengan catatan

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Unduh Contoh yang Dijalankan**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Untuk detail lebih lanjut, kunjungi [Konversi Presentasi PowerPoint ke TIFF dengan Catatan di .NET](/slides/id/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}