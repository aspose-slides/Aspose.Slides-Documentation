---
title: Конвертация документа OpenOffice
type: docs
weight: 30
url: /ru/net/conversion-of-openoffice-document/
---

Aspose.Slides for .NET предлагает **Presentation** класс, представляющий файл презентации. **Presentation** класс теперь также может работать с **ODP** через конструктор Presentation при создании объекта.

Ниже приведён пример конвертации из ODP в PPT/PPTX.
## **Пример**
```

 //Instantiate a Presentation object that represents a presentation file

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Saving the PPTX presentation to PPTX format

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

Ниже приведён пример конвертации из PPT/PPTX в ODP.
## **Пример**
``` 

 //Instantiate a Presentation object that represents a presentation file

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Saving the PPTX presentation to PPTX format

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Скачать работающий пример**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)