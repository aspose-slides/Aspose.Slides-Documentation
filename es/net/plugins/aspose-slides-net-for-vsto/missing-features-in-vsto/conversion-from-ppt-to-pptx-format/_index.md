---
title: Conversión del formato PPT a PPTX
type: docs
weight: 20
url: /es/net/conversion-from-ppt-to-pptx-format/
---

Característica única de Aspose.Slides que proporciona flexibilidad en las conversiones de versiones sin afectar el trabajo.
SaveFormat es una enumeración que puede convertir documentos a las extensiones que se indican a continuación en la tabla.

|**Nombre del miembro**|**Valor**|**Descripción**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |
A continuación se muestra un fragmento de código que muestra la conversión de PPT a PPTX; también puede hacerlo al revés.

``` csharp
 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Instanciar un objeto Presentation que representa un archivo PPTX

Presentation pres = new Presentation(srcFileName);

//Guardar la presentación PPTX en formato PPTX

pres.Save(destFileName, SaveFormat.Pptx);
``` 
## **Descargar código de ejemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)