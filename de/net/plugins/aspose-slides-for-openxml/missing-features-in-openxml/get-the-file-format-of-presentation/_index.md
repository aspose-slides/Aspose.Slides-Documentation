---
title: Ermitteln des Dateiformats der Präsentation
type: docs
weight: 50
url: /net/get-the-file-format-of-presentation/
---

Um das Dateiformat zu ermitteln, folgen Sie bitte den unten stehenden Schritten:

- Erstellen Sie eine Instanz der Klasse **IPresentationInfo**
- Holen Sie Informationen über die Präsentation

Im folgenden Beispiel haben wir das Dateiformat ermittelt.
## **Beispiel**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Ermitteln des Formats einer Datei.pptx";

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
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Laufendes Beispiel herunterladen**
- [Codeplex](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)