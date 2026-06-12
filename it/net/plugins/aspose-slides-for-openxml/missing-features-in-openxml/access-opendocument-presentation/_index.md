---
title: Accesso a OpenDocument Presentation
type: docs
weight: 10
url: /it/net/access-opendocument-presentation/
---
Aspose.Slides per .NET offre la classe **Presentation** che rappresenta un file di presentazione. La classe **Presentation** può ora accedere anche a **ODP** tramite il costruttore **Presentation** quando l'oggetto viene istanziato.
## **Esempio**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//Instanzia un oggetto Presentation che rappresenta un file di presentazione

using (Presentation pres = new Presentation(srcFileName))

{

    //Salva la presentazione PPTX nel formato PPTX

    pres.Save(destFileName, SaveFormat.Pptx);

}
```
## **Scarica Codice di Esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Scarica Esempio in Esecuzione**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)