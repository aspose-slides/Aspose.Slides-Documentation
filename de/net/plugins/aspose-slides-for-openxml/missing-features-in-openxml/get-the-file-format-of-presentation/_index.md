---
title: Dateiformat der Präsentation abrufen
type: docs
weight: 50
url: /de/net/get-the-file-format-of-presentation/
---

Um das Dateiformat zu erhalten, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse **IPresentationInfo**
- Rufen Sie Informationen zur Präsentation ab

Im nachstehenden Beispiel haben wir das Dateiformat ermittelt.
## **Beispiel**
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
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Laufendes Beispiel herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)