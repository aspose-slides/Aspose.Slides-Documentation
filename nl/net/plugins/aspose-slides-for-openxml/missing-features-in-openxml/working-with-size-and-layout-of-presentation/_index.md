---
title: Werken met grootte en indeling van presentatie
type: docs
weight: 90
url: /nl/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** en **SlideSize.Size** zijn de eigenschappen van de presentatieklasse die ingesteld of opgehaald kunnen worden zoals hieronder in het voorbeeld wordt getoond.
## **Voorbeeld**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Initialiseer een Presentation-object dat een presentatiebestand vertegenwoordigt 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Stel de slidegrootte van gegenereerde presentaties in op die van de bron

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Sla de presentatie op schijf

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Werkend voorbeeld downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 
Voor meer details, bezoek [de presentatieslidesgrootte wijzigen in .NET](/slides/nl/net/slide-size/).
{{% /alert %}}