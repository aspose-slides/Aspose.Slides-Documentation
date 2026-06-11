---
title: Dostęp do prezentacji OpenDocument
type: docs
weight: 10
url: /pl/net/access-opendocument-presentation/
---
Aspose.Slides for .NET udostępnia klasę **Presentation**, która reprezentuje plik prezentacji. Klasa **Presentation** może teraz również uzyskać dostęp do **ODP** poprzez konstruktor **Presentation**, gdy obiekt jest tworzony.
## **Przykład**
```csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//Utwórz obiekt Presentation, który reprezentuje plik prezentacji

using (Presentation pres = new Presentation(srcFileName))

{
    //Zapisywanie prezentacji PPTX w formacie PPTX
    pres.Save(destFileName, SaveFormat.Pptx);
}
``` 
## **Pobierz kod przykładu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Pobierz działający przykład**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)