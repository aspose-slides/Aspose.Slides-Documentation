---
title: Pobierz format pliku prezentacji
type: docs
weight: 50
url: /pl/net/get-the-file-format-of-presentation/
aliases:
  - /net/presentation-format/
---
Aby uzyskać format pliku, proszę wykonać poniższe kroki:

- Utwórz instancję klasy **IPresentationInfo**
- Pobierz informacje o prezentacji

W poniższym przykładzie uzyskaliśmy format pliku.
## **Przykład**
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
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Pobierz działający przykład**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)