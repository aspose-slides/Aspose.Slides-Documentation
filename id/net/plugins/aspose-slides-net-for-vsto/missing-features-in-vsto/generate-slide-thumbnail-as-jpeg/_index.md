---
title: Menghasilkan Thumbnail Slide sebagai JPEG
type: docs
weight: 90
url: /id/net/generate-slide-thumbnail-as-jpeg/
---
Untuk menghasilkan thumbnail dari slide mana pun yang diinginkan menggunakan Aspose.Slides untuk .NET:

- Buat sebuah instance dari kelas Presentation.
- Dapatkan referensi slide yang diinginkan dengan menggunakan ID atau indeksnya.
- Ambil gambar thumbnail dari slide yang direferensikan dengan skala tertentu.
- Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.
## **Contoh**
```cs
//Instansiasi kelas Presentation yang mewakili file presentasi
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Akses slide pertama
    ISlide sld = pres.Slides[0];

    //Buat gambar skala penuh
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Simpan gambar ke disk dalam format JPEG
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Unduh Contoh yang Berjalan**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Untuk detail lebih lanjut, kunjungi [Konversi PPT dan PPTX ke JPG di .NET](/slides/id/net/convert-powerpoint-to-jpg/).

{{% /alert %}}