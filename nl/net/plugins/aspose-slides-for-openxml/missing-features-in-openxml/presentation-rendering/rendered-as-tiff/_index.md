---
title: Weergegeven als Tiff
type: docs
weight: 30
url: /nl/net/rendered-as-tiff/
---
TIFF-formaat staat bekend om zijn flexibiliteit om meervoudige paginabeelden en -gegevens te accommoderen. Met het oog op het belang en de populariteit van het TIFF-formaat, biedt Aspose.Slides for .NET ondersteuning voor het converteren van presentaties naar een TIFF-document.
Dit artikel legt de verschillende TIFF-exportopties uit:

- Presentatie converteren naar TIFF met standaardgrootte.
- Presentatie converteren naar TIFF met aangepaste grootte.

De **Save**-methode die wordt blootgesteld door de **Presentation**-klasse kan door ontwikkelaars worden aangeroepen om de volledige presentatie te converteren naar een **TIFF**-document. Daarnaast stelt de TiffOptions-klasse de eigenschap ImageSize beschikbaar, waarmee de ontwikkelaar de grootte van de afbeelding kan definiëren indien nodig.

``` csharp
using Aspose.Slides;


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