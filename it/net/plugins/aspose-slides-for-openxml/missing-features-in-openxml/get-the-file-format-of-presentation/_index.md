---
title: Ottenere il formato del file della presentazione
type: docs
weight: 50
url: /it/net/get-the-file-format-of-presentation/
aliases:
  - /net/presentation-format/
---
Per ottenere il formato del file, segui i passaggi seguenti:

- Crea un'istanza della classe **IPresentationInfo**
- Ottieni le informazioni sulla presentazione

Nel seguente esempio, otteniamo il formato del file.
## **Esempio**
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
## **Scarica il codice di esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Scarica l'esempio in esecuzione**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)