---
title: Arbeiten mit Größe und Layout der Präsentation
type: docs
weight: 90
url: /de/net/working-with-size-and-layout-of-presentation/
---

**SlideSize.Type** und **SlideSize.Size** sind die Eigenschaften der Präsentationsklasse, die wie unten im Beispiel gesetzt oder abgerufen werden können.
## **Beispiel**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Instantiate a Presentation object that represents a presentation file 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Set the slide size of generated presentations to that of source

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Save Presentation to disk

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Laufendes Beispiel herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 
Für weitere Details besuchen Sie [Ändern der Präsentationsfoliengröße in .NET](/slides/de/net/slide-size/).
{{% /alert %}}