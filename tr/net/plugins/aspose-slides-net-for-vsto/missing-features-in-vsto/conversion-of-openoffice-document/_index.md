---
title: OpenOffice Belgesinin Dönüştürülmesi
type: docs
weight: 30
url: /tr/net/conversion-of-openoffice-document/
---
Aspose.Slides for .NET, bir sunum dosyasını temsil eden **Presentation** sınıfını sunar. **Presentation** sınıfı artık nesne örneklenirken Presentation yapıcı üzerinden **ODP**ye de erişebilir.

Aşağıda ODP'den PPT/PPTX'e dönüştürme örneği verilmiştir.
## **Örnek**
```

 //Sunum dosyasını temsil eden bir Presentation nesnesi oluşturun

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //PPTX sunumunu PPTX formatında kaydediyor

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

Aşağıda PPT/PPTX'den ODP'ye dönüştürme örneği verilmiştir.
## **Örnek**
``` 

 //Sunum dosyasını temsil eden bir Presentation nesnesi oluşturun

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //PPTX sunumunu PPTX formatında kaydediyor

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Çalışan Örneği İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)