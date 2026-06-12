---
title: Menghasilkan Thumbnail dari Slide dengan Dimensi yang Ditentukan Pengguna
type: docs
weight: 100
url: /id/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
Untuk menghasilkan thumbnail dari slide yang diinginkan menggunakan Aspose.Slides for .NET:

- Buat sebuah instance dari kelas Presentation.
- Dapatkan referensi slide yang diinginkan dengan menggunakan ID atau indeksnya.
- Dapatkan faktor skala X dan Y berdasarkan dimensi X dan Y yang didefinisikan pengguna.
- Dapatkan gambar thumbnail dari slide yang direferensikan pada skala tertentu.
- Simpan gambar thumbnail dalam format gambar yang diinginkan.

## **Contoh**
```cs
//Instansiasi kelas Presentation yang mewakili file presentasi
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Akses slide pertama
    ISlide sld = pres.Slides[0];

    //Dimensi yang ditentukan pengguna
    int desiredX = 1200;
    int desiredY = 800;

    //Mendapatkan nilai skala  X dan Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Membuat gambar skala penuh
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Simpan gambar ke disk dalam format JPEG
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Unduh Contoh yang Berjalan**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Untuk detail lebih lanjut, kunjungi [Konversi Slide](/slides/id/net/convert-slide/).
{{% /alert %}}