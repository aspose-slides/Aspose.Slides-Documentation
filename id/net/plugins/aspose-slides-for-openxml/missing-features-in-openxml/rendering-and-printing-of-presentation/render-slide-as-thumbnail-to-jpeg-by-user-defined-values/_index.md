---
title: Render Slide sebagai Thumbnail ke JPEG dengan Nilai yang Ditentukan Pengguna
type: docs
weight: 70
url: /id/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Untuk menghasilkan thumbnail dari slide yang diinginkan menggunakan Aspose.Slides untuk .NET:

1. Buat instance dari kelas **Presentation**.
1. Dapatkan referensi slide yang diinginkan dengan menggunakan ID atau indeksnya.
1. Dapatkan faktor skala X dan Y berdasarkan dimensi X dan Y yang ditentukan pengguna.
1. Dapatkan gambar thumbnail dari slide yang direferensikan pada skala yang ditentukan.
1. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Membuat instance kelas Presentation yang mewakili file presentasi
using (Presentation pres = new Presentation(srcFileName))
{
    //Mengakses slide pertama
    ISlide sld = pres.Slides[0];

    //Dimensi yang ditentukan pengguna
    int desiredX = 1200;
    int desiredY = 800;

    //Mendapatkan nilai skala X dan Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Membuat gambar dengan skala penuh
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Menyimpan gambar ke disk dalam format JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)