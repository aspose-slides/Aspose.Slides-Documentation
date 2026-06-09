---
title: Conversão de PPT para PPTX
type: docs
weight: 20
url: /pt/net/conversion-from-ppt-to-pptx-format/
---
Recurso exclusivo do Aspose.Slides que oferece flexibilidade na conversão de versões sem afetar o trabalho.  
SaveFormat é uma enumeração que pode converter documentos nas extensões apresentadas na tabela abaixo.

|**Nome do Membro**|**Valor**|**Descrição**|
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
Abaixo está um trecho de código que mostra a conversão de PPT para PPTX; você também pode fazer o inverso.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Instanciar um objeto Presentation que representa um arquivo PPTX

Presentation pres = new Presentation(srcFileName);

//Salvar a apresentação PPTX no formato PPTX

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)