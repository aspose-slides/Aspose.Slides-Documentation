---
title: Práce s velikostí a rozložením prezentace
type: docs
weight: 90
url: /cs/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** a **SlideSize.Size** jsou vlastnosti třídy prezentace, které lze nastavit nebo získat, jak je ukázáno níže v příkladu.
## **Příklad**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Vytvořte objekt Presentation, který představuje soubor prezentace 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Nastavte velikost snímku vygenerovaných prezentací na velikost zdroje

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Uložte prezentaci na disk

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Stáhnout běžící příklad**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 
Pro podrobnější informace navštivte [Změna velikosti snímku prezentace v .NET](/slides/cs/net/slide-size/).
{{% /alert %}}