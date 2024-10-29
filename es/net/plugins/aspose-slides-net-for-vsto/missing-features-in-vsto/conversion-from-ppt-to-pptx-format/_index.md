---
title: Conversión de formato PPT a PPTX
type: docs
weight: 20
url: /es/net/conversion-from-ppt-to-pptx-format/
---

La característica única de Aspose.Slides que proporciona flexibilidad en las conversiones de versión sin afectar el trabajo. SaveFormat es una enumeración que puede convertir documentos en las extensiones dadas a continuación en la tabla.

|**Nombre del Miembro**|**Valor**|**Descripción**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|Notas PDF|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|Notas Tiff|14| |
|XPS|2| |
A continuación se muestra un fragmento de código que muestra la conversión de PPT a PPTX, también puede hacerlo a la inversa.

``` csharp

 string FilePath = @"..\..\..\Archivos de muestra\";

string srcFileName = FilePath + "Conversión PPT a PPTX.ppt";

string destFileName = FilePath + "Conversión PPT a PPTX.pptx";

//Instanciar un objeto Presentation que representa un archivo PPTX

Presentation pres = new Presentation(srcFileName);

//Guardar la presentación PPTX en formato PPTX

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Descargar Código de Muestra**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)