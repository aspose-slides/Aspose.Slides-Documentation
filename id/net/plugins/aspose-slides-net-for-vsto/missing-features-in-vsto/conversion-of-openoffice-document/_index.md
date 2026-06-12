---
title: Konversi Dokumen OpenOffice
type: docs
weight: 30
url: /id/net/conversion-of-openoffice-document/
---
Aspose.Slides for .NET menawarkan kelas **Presentation** yang mewakili file presentasi. Kelas **Presentation** sekarang juga dapat mengakses **ODP** melalui konstruktor Presentation saat objek diinstansiasi.

Berikut adalah contoh mengonversi dari ODP ke PPT/PPTX.
## **Contoh**
```

 //Instansiasi objek Presentation yang mewakili file presentasi

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Menyimpan presentasi PPTX ke format PPTX

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

Berikut adalah contoh mengonversi dari PPT/PPTX ke ODP.
## **Contoh**
``` 

 //Instansiasi objek Presentation yang mewakili file presentasi

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Menyimpan presentasi PPTX ke format PPTX

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Unduh Contoh yang Dijalankan**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Unduh Kode Contoh**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)