---
title: Weergegeven als Tiff
type: docs
weight: 30
url: /nl/net/rendered-as-tiff/
---
Het TIFF‑formaat staat bekend om zijn flexibiliteit om meerpagina‑afbeeldingen en -data te accommoderen. Met het oog op het belang en de populariteit van het TIFF‑formaat, biedt Aspose.Slides voor .NET ondersteuning voor het converteren van presentaties naar een TIFF‑document.  
Dit artikel legt uit hoe verschillende TIFF‑exportopties werken:

- Een presentatie naar TIFF converteren met de standaardgrootte.  
- Een presentatie naar TIFF converteren met een aangepaste grootte.

De **Save**-methode die wordt blootgesteld door de **Presentation**-klasse kan door ontwikkelaars worden aangeroepen om de volledige presentatie naar een **TIFF**-document te converteren. Daarnaast maakt de TiffOptions-klasse de eigenschap ImageSize beschikbaar, waardoor de ontwikkelaar de grootte van de afbeelding kan definiëren indien nodig.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt

using (Presentation pres = new Presentation(srcFileName))

{

    //De presentatie opslaan als TIFF-document

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)