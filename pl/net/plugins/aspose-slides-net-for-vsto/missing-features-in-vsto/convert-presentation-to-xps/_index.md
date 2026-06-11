---
title: Konwertowanie prezentacji do XPS
type: docs
weight: 60
url: /pl/net/convert-presentation-to-xps/
---
**XPS** format jest również szeroko używany do wymiany danych. Aspose.Slides for .NET dba o jego znaczenie i zapewnia wbudowane wsparcie dla konwertowania prezentacji do dokumentu XPS.

Metodę **Save** udostępnioną przez klasę Presentation można użyć do konwersji całej prezentacji do dokumentu **XPS**. Ponadto klasa **XpsOptions** udostępnia właściwość **SaveMetafileAsPng**, którą można ustawić na true lub false w zależności od potrzeb.
## **Example**

``` 

 //Utwórz obiekt Presentation, który reprezentuje plik prezentacji

Presentation pres = new Presentation("Conversion.ppt");

//Zapisanie prezentacji do dokumentu TIFF

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Pobierz działający przykład**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Po więcej szczegółów odwiedź [Konwertowanie prezentacji PowerPoint do XPS w .NET](/slides/pl/net/convert-powerpoint-to-xps/).

{{% /alert %}}