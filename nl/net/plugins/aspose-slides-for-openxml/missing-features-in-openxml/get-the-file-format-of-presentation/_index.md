---
title: Het bestandsformaat van de presentatie ophalen
type: docs
weight: 50
url: /nl/net/get-the-file-format-of-presentation/
aliases:
  - /net/presentation-format/
---
Om het bestandsformaat te achterhalen, volgt u de onderstaande stappen:

- Maak een instantie van de **IPresentationInfo**-klasse
- Haal informatie over de presentatie op

In het onderstaande voorbeeld hebben we het bestandsformaat verkregen.
## **Voorbeeld**
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
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Werkend voorbeeld downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)