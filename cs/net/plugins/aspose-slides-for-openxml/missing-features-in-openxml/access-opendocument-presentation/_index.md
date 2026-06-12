---
title: Přístup k OpenDocument prezentaci
type: docs
weight: 10
url: /cs/net/access-opendocument-presentation/
---
Aspose.Slides pro .NET nabízí třídu **Presentation**, která představuje soubor prezentace. Třída **Presentation** nyní také může přistupovat k **ODP** přes konstruktor **Presentation**, když je objekt vytvořen.
## **Příklad**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//Vytvořte objekt Presentation, který představuje soubor prezentace

using (Presentation pres = new Presentation(srcFileName))

{

    //Ukládá prezentaci PPTX do formátu PPTX

    pres.Save(destFileName, SaveFormat.Pptx);

}

```
## **Stáhnout ukázkový kód**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Stáhnout spustitelný příklad**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)