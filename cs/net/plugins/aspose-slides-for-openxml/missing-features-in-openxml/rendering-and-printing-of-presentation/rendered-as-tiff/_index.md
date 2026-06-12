---
title: Vykresleno jako Tiff
type: docs
weight: 30
url: /cs/net/rendered-as-tiff/
---
Formát TIFF je známý svou flexibilitou umožňující zpracovávat více stranové obrázky a data. Vzhledem k významu a popularitě formátu TIFF poskytuje Aspose.Slides pro .NET podporu pro převod prezentací do dokumentu TIFF.
Tento článek vysvětluje různé možnosti exportu do formátu TIFF:

- Převod prezentace do TIFF s výchozí velikostí.
- Převod prezentace do TIFF s vlastní velikostí.

Metodu **Save**, která je součástí třídy **Presentation**, mohou vývojáři použít k převodu celé prezentace do dokumentu **TIFF**. Dále třída TiffOptions vystavuje vlastnost ImageSize, která umožňuje vývojáři definovat velikost obrázku podle potřeby.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Vytvořte objekt Presentation, který představuje soubor prezentace

using (Presentation pres = new Presentation(srcFileName))

{

    //Ukládání prezentace do TIFF dokumentu

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)