---
title: Konversi dari format PPT ke PPTX di Aspose.Slides
type: docs
weight: 10
url: /id/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** for .NET kini memudahkan pengembang untuk mengakses PPT menggunakan instance kelas Presentation dan mengonversinya ke format PPTX yang sesuai. Saat ini, ia mendukung konversi parsial dari PPT ke PPTX. Untuk detail lebih lanjut tentang fitur apa yang didukung dan tidak didukung dalam konversi PPT ke PPTX, silakan kunjungi tautan dokumentasi ini.

**Aspose.Slides** for .NET menawarkan kelas Presentation yang mewakili file presentasi PPTX. Kelas Presentation kini juga dapat mengakses PPT melalui Presentation saat objek diinstansiasi.

``` csharp

 //Buat instance objek Presentation yang mewakili file PPTX

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Menyimpan presentasi PPTX ke format PPTX

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Unduh Kode Contoh**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)