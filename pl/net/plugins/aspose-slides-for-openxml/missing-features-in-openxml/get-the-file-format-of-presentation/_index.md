---
title: Uzyskaj format pliku prezentacji
type: docs
weight: 50
url: /pl/net/get-the-file-format-of-presentation/
---
Aby uzyskać format pliku, proszę postępować zgodnie z poniższymi krokami:

- Utwórz instancję klasy **IPresentationInfo**
- Pobierz informacje o prezentacji

W poniższym przykładzie uzyskano format pliku.
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
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Pobierz działający przykład**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)