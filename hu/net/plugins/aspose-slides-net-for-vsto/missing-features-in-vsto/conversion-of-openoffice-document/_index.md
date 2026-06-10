---
title: OpenOffice dokumentum konvertálása
type: docs
weight: 30
url: /hu/net/conversion-of-openoffice-document/
---
Aspose.Slides for .NET kínálja a **Presentation** osztályt, amely egy bemutatófájlt képvisel. A **Presentation** osztály mostantól **ODP**-t is elérhet a Presentation konstruktoron keresztül, amikor az objektum példányosítva van.

Az alábbi példa bemutatja az ODP-ről PPT/PPTX-re konvertálást.
## **Példa**
```

 //Példányosít egy Presentation objektumot, amely egy bemutatófájlt képvisel

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //A PPTX bemutató mentése PPTX formátumba

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

Az alábbi példa bemutatja a PPT/PPTX-ről ODP-re konvertálást.
## **Példa**
``` 

 //Példányosít egy Presentation objektumot, amely egy bemutatófájlt képvisel

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //A PPTX bemutató mentése PPTX formátumba

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Példakód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)