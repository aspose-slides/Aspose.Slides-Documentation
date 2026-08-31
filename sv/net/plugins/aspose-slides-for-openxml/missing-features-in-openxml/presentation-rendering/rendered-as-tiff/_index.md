---
title: Renderad som Tiff
type: docs
weight: 30
url: /sv/net/rendered-as-tiff/
---
TIFF-format är känt för sin flexibilitet att hantera flersidiga bilder och data. Med tanke på TIFF-formatets betydelse och popularitet erbjuder Aspose.Slides för .NET stöd för att konvertera presentationer till TIFF-dokument. Denna artikel förklarar hur olika TIFF-exportalternativ:

- Konvertera presentation till TIFF med standardstorlek.
- Konvertera presentation till TIFF med anpassad storlek.

Metoden **Save** som exponeras av klassen **Presentation** kan anropas av utvecklare för att konvertera hela presentationen till ett **TIFF**-dokument. Vidare exponerar klassen TiffOptions egenskapen ImageSize som gör det möjligt för utvecklaren att ange bildens storlek om så krävs.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instansiera ett Presentation-objekt som representerar en presentationsfil

using (Presentation pres = new Presentation(srcFileName))

{
    //Sparar presentationen till ett TIFF-dokument
    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);
}
``` 
## **Ladda ner exempel på kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)