---
title: Vykresleno jako TIFF
type: docs
weight: 30
url: /cs/net/rendered-as-tiff/
---
Formát TIFF je známý svou flexibilitou, která umožňuje zpracovávat vícestránkové obrázky a data. Vzhledem k důležitosti a popularitě formátu TIFF poskytuje Aspose.Slides pro .NET podporu pro převod prezentací do dokumentu TIFF.
Tento článek vysvětluje různé možnosti exportu do TIFF:

- Převod prezentace do TIFF s výchozí velikostí.
- Převod prezentace do TIFF s vlastní velikostí.

Metoda **Save**, kterou poskytuje třída **Presentation**, může být volána vývojáři k převodu celé prezentace do dokumentu **TIFF**. Dále třída TiffOptions zveřejňuje vlastnost ImageSize, která umožňuje vývojáři definovat velikost obrázku, pokud je to potřeba.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instancujte objekt Presentation, který představuje soubor prezentace

using (Presentation pres = new Presentation(srcFileName))

{

    //Ukládání prezentace do TIFF dokumentu

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)