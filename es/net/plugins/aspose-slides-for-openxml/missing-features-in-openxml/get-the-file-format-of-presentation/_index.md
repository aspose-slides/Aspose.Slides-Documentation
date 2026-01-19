---
title: Obtener el formato de archivo de la presentación
type: docs
weight: 50
url: /es/net/get-the-file-format-of-presentation/
---

Para obtener el formato del archivo. Siga los pasos a continuación:

- Cree una instancia de la clase **IPresentationInfo**
- Obtenga información sobre la presentación

En el ejemplo a continuación, obtenemos el formato del archivo.
## **Ejemplo**
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
## **Descargar código de muestra**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Descargar ejemplo en ejecución**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)