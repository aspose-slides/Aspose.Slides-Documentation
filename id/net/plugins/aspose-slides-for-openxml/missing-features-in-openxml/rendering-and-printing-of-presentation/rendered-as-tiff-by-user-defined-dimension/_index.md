---
title: Dihasilkan Sebagai Tiff Dengan Dimensi yang Ditentukan Pengguna
type: docs
weight: 40
url: /id/net/rendered-as-tiff-by-user-defined-dimension/
---
Contoh berikut menunjukkan cara mengonversi presentasi menjadi dokumen TIFF dengan ukuran gambar yang disesuaikan menggunakan kelas **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Membuat objek Presentation yang mewakili file Presentation
Presentation pres = new Presentation(srcFileName);

//Membuat instance kelas TiffOptions
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Mengatur jenis kompresi
opts.CompressionType = TiffCompressionTypes.Default;

//Jenis Kompresi
//Default - Menentukan skema kompresi default (LZW).
//None - Menentukan tidak ada kompresi.
//CCITT3
//CCITT4
//LZW
//RLE
//Depth - tergantung pada jenis kompresi dan tidak dapat diatur secara manual.
//Resolution unit - selalu bernilai "2" (dot per inci)
//Mengatur DPI gambar
opts.DpiX = 200;

opts.DpiY = 100;

//Atur Ukuran Gambar
opts.ImageSize = new Size(1728, 1078);

//Simpan presentasi ke TIFF dengan ukuran gambar yang ditentukan
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);
```
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)