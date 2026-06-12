---
title: Buat Slide sebagai Gambar SVG
type: docs
weight: 70
url: /id/net/create-slide-as-svg-image/
---
Untuk menghasilkan gambar SVG dari slide mana pun yang diinginkan dengan Aspose.Slides.Pptx untuk .NET, ikuti langkah-langkah di bawah ini:

- Buat instance dari kelas Presentation.
- Dapatkan referensi slide yang diinginkan dengan menggunakan ID atau indeksnya.
- Dapatkan gambar SVG dalam memori stream.
- Simpan memori stream ke file.
## **Contoh**

```

 //Instansiasi kelas Presentation yang mewakili file presentasi

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Akses slide kedua

   ISlide sld = pres.Slides[1];

   //Buat objek memory stream

   MemoryStream SvgStream = new MemoryStream();

   //Hasilkan gambar SVG dari slide dan simpan di memory stream

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Simpan memory stream ke file

   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))

   {

     byte[] buffer = new byte[8 * 1024];

     int len;

     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)

     {

       fileStream.Write(buffer, 0, len);

     }

   }

}

SvgStream.Close();

``` 
## **Unduh Contoh yang Berjalan**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Untuk detail lebih lanjut, kunjungi [Render Slide Presentasi sebagai Gambar SVG di .NET](/slides/id/net/render-a-slide-as-an-svg-image/).

{{% /alert %}}