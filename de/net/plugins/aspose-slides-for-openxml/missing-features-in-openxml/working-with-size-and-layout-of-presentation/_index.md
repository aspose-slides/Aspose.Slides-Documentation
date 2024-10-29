---
title: Arbeiten mit Größe und Layout von Präsentationen
type: docs
weight: 90
url: /de/net/working-with-size-and-layout-of-presentation/
---

**SlideSize.Type** und **SlideSize.Size** sind die Eigenschaften der Präsentationsklasse, die wie im folgenden Beispiel gesetzt oder abgerufen werden können.
## **Beispiel**
``` csharp

 string FilePath = @"..\..\..\Beispieldateien\";

string FileName = FilePath + "Arbeiten mit Größe und Layout.pptx";

//Erstellen eines Präsentationsobjekts, das eine Präsentationsdatei darstellt 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Setzen Sie die Foliengröße der erzeugten Präsentationen auf die des Quells

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Präsentation auf der Festplatte speichern

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Beispielcode herunterladen**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Laufendes Beispiel herunterladen**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Working With Size and Layout/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

Für weitere Einzelheiten besuchen Sie [Arbeiten mit Foliengröße und Layout](/slides/de/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}