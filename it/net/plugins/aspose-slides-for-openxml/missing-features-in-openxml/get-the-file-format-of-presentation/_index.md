---
title: Ottieni il formato del file della presentazione
type: docs
weight: 50
url: /it/net/get-the-file-format-of-presentation/
---
Per ottenere il formato del file, segui i passaggi seguenti:

- Crea un'istanza della classe **IPresentationInfo** 
- Ottieni informazioni sulla presentazione

Nell'esempio riportato di seguito, otteniamo il formato del file.
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
## **Scarica Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Scarica Esempio Eseguibile**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)