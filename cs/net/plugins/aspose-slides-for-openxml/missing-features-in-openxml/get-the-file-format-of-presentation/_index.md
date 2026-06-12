---
title: Získání formátu souboru prezentace
type: docs
weight: 50
url: /cs/net/get-the-file-format-of-presentation/
---
Pro získání formátu souboru postupujte podle následujících kroků:

- Vytvořte instanci třídy **IPresentationInfo** class
- Získejte informace o prezentaci

V níže uvedeném příkladu získáme formát souboru.
## **Příklad**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Stáhnout spuštěný příklad**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)