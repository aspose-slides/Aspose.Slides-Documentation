---
title: Převod do XPS
type: docs
weight: 40
url: /cs/net/conversion-to-xps/
---
**XPS** formát je také široce používán pro výměnu dat. Aspose.Slides for .NET se stará o jeho význam a poskytuje vestavěnou podporu pro převod prezentace do XPS dokumentu.

**Save** metoda vystavená třídou Presentation může být použita k převodu celé prezentace do **XPS** dokumentu. Dále třída **XpsOptions** vystavuje vlastnost **SaveMetafileAsPng**, kterou lze nastavit na true nebo false podle požadavku.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Vytvořte objekt Presentation, který představuje soubor prezentace

Presentation pres = new Presentation(srcFileName);

//Ukládání prezentace do dokumentu TIFF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)