---
title: Render Slide sebagai Thumbnail ke JPEG
type: docs
weight: 60
url: /id/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** digunakan untuk membuat file presentasi yang berisi slide. Slide ini dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun terkadang, pengembang mungkin perlu melihat slide sebagai gambar menggunakan penampil gambar favorit mereka. Dalam kasus tersebut, Aspose.Slides for .NET membantu Anda menghasilkan gambar thumbnail dari slide.

Untuk menghasilkan thumbnail dari slide mana pun yang diinginkan menggunakan Aspose.Slides for .NET:

1. Buat instance dari kelas **Presentation**.
1. Dapatkan referensi slide yang diinginkan dengan menggunakan ID atau indeksnya.
1. Ambil gambar thumbnail dari slide yang direferensikan dengan skala tertentu.
1. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Membuat instance kelas Presentation yang mewakili file presentasi
using (Presentation pres = new Presentation(srcFileName))
{
    //Mengakses slide pertama
    ISlide sld = pres.Slides[0];

    //Membuat gambar skala penuh
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Menyimpan gambar ke disk dalam format JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)