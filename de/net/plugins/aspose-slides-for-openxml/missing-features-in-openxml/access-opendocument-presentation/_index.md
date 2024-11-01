---
title: Zugriff auf OpenDocument-Präsentation
type: docs
weight: 10
url: /de/net/access-opendocument-presentation/
---

Aspose.Slides für .NET bietet die **Presentation**-Klasse, die eine Präsentationsdatei darstellt. Die **Presentation**-Klasse kann jetzt auch über den **Presentation**-Konstruktor auf **ODP** zugreifen, wenn das Objekt instanziiert wird.
## **Beispiel**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Präsentation.odp";

string destFileName = FilePath + "OpenDocument Präsentation.pptx";

//Ein Presentation-Objekt instanziieren, das eine Präsentationsdatei darstellt

using (Presentation pres = new Presentation(srcFileName))

{

    //Speichern der PPTX-Präsentation im PPTX-Format

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Laufendes Beispiel herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)