---
title: Acceder a la presentación de OpenDocument
type: docs
weight: 10
url: /net/access-opendocument-presentation/
---

Aspose.Slides para .NET ofrece la clase **Presentation** que representa un archivo de presentación. La clase **Presentation** ahora también puede acceder a **ODP** a través del constructor de **Presentation** cuando se instancia el objeto.
## **Ejemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Presentación de OpenDocument.odp";

string destFileName = FilePath + "Presentación de OpenDocument.pptx";

//Instanciar un objeto Presentation que representa un archivo de presentación

using (Presentation pres = new Presentation(srcFileName))

{

    //Guardar la presentación PPTX en formato PPTX

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **Descargar código de ejemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Descargar ejemplo en ejecución**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)