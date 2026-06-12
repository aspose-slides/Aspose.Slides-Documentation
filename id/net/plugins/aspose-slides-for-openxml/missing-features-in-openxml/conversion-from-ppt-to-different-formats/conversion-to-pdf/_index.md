---
title: Konversi ke PDF
type: docs
weight: 30
url: /id/net/conversion-to-pdf/
---
Dokumen PDF banyak digunakan sebagai format standar untuk bertukar dokumen antara organisasi, sektor pemerintah, dan individu. Itu adalah format yang populer sehingga pengembang sering diminta untuk mengonversi file presentasi Microsoft PowerPoint ke dokumen PDF. Menyadari kemungkinan kebutuhan ini, Aspose.Slides for .NET mendukung konversi presentasi ke dokumen PDF tanpa menggunakan komponen lain.

**Aspose.Slides for .NET** menawarkan kelas Presentation yang mewakili file presentasi. Kelas **Presentation** menampilkan metode Save yang dapat dipanggil untuk mengonversi seluruh presentasi menjadi dokumen **PDF**. Kelas **PdfOptions** menyediakan opsi untuk membuat **PDF** seperti JpegQuality, TextCompression, Compliance, dan lainnya. Opsi-opsi ini dapat digunakan untuk mendapatkan standar PDF yang diinginkan.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Membuat objek Presentation yang merepresentasikan file presentasi

Presentation pres = new Presentation(srcFileName);

//Simpan presentasi ke PDF dengan opsi default

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Unduh Contoh Kode**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)