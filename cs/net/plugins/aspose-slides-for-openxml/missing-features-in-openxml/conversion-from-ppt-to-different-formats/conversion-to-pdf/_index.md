---
title: Převod do PDF
type: docs
weight: 30
url: /cs/net/conversion-to-pdf/
---
PDF dokumenty jsou široce používány jako standardní formát pro výměnu dokumentů mezi organizacemi, vládními sektory a jednotlivci. Jedná se o populární formát, takže vývojáři jsou často žádáni o konverzi souborů prezentací Microsoft PowerPoint do PDF dokumentů. Vzhledem k tomuto možnému požadavku Aspose.Slides pro .NET podporuje převod prezentací do PDF dokumentů bez použití jakékoli jiné komponenty.

**Aspose.Slides pro .NET** nabízí třídu Presentation, která představuje soubor prezentace. Třída **Presentation** vystavuje metodu Save, kterou lze zavolat k převodu celé prezentace do **PDF** dokumentu. Třída **PdfOptions** poskytuje možnosti pro vytvoření **PDF**, jako jsou JpegQuality, TextCompression, Compliance a další. Tyto možnosti lze použít k dosažení požadovaného standardu PDF.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Vytvořte instanci objektu Presentation, který představuje soubor prezentace

Presentation pres = new Presentation(srcFileName);

//Uložte prezentaci do PDF s výchozími možnostmi

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Stáhněte si ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)