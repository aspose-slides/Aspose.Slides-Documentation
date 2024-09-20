---
title: Конвертация документа OpenOffice
type: docs
weight: 30
url: /net/conversion-of-openoffice-document/
---

Aspose.Slides для .NET предлагает класс **Presentation**, который представляет файл презентации. Класс **Presentation** теперь также может получать доступ к **ODP** через конструктор Presentation при создании объекта.

Ниже приведен пример конвертации из ODP в PPT/PPTX.
## **Пример**
```

 //Создание объекта Presentation, представляющего файл презентации

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Сохранение презентации PPTX в формате PPTX

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

Ниже приведен пример конвертации из PPT/PPTX в ODP.
## **Пример**
``` 

 //Создание объекта Presentation, представляющего файл презентации

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Сохранение презентации PPTX в формате ODP

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Скачать работающий пример**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Conversion from ODP to PPTX/Converting From and To ODP/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Скачать пример кода**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)