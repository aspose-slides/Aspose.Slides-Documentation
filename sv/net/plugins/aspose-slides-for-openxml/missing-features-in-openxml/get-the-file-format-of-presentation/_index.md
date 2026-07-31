---
title: Hämta filformatet för presentationen
type: docs
weight: 50
url: /sv/net/get-the-file-format-of-presentation/
aliases:
  - /net/presentation-format/
---
För att få filformatet, följ stegen nedan:

- Skapa en instans av klassen **IPresentationInfo**
- Hämta information om presentationen

I exemplet nedan har vi fått filformatet.
## **Exempel**
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
## **Ladda ner exempelkod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Ladda ner körbart exempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)