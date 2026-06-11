---
title: Arbeta med storlek och layout för presentation
type: docs
weight: 90
url: /sv/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** och **SlideSize.Size** är egenskaperna i presentationsklassen som kan sättas eller hämtas som visas nedan i exemplet.
## **Exempel**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Skapa ett Presentation-objekt som representerar en presentationsfil

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Ställ in bildstorleken för genererade presentationer till samma som källan

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Spara presentationen till disk

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Ladda ner exempelkod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Ladda ner körande exempel**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 
För mer information, besök [Ändra presentationsbildens storlek i .NET](/slides/sv/net/slide-size/).
{{% /alert %}}